using System.Data.Common;

using DBQueryConstructor.Controls;
using DBQueryConstructor.Controls.ColumnPanels;
using DBQueryConstructor.QueryInteractions;

using Handy;

namespace DBQueryConstructor
{
    public partial class MainForm : Form
    {
        private readonly QueryBuilder _QueryBuilder;

        public MainForm()
        {
            _QueryBuilder = new QueryBuilder();

            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = 0x2000000;

                return cp;
            }
        }

        private void ClearConstructor()
        {
            queryConstructorTableListView.Controls.Clear();
            queryConstructorMiscFieldListView.Controls.Clear();
            queryConstructorMiscJoinListView.Controls.Clear();
            queryConstructorMiscConditionListView.Controls.Clear();
            queryConstructorMiscResultTabPage.Controls.RemoveByKey("queryDataResult");
            queryConstructorMiscResultTabPage.Controls.RemoveByKey("queryError");
            queryConstructorQueryText.Text = null;
        }

        private void DatabasePanel_CloseConnection(object sender, EventArgs e) => ClearConstructor();

        private void DatabasePanel_TableDragDrop(object sender, DragEventArgs e)
        {
            TablePanel selectedTableNode = (TablePanel)e.Data.GetData(typeof(TablePanel));

            queryConstructorTableListView.Controls.Remove(selectedTableNode);
        }

        private void ClearConstructorToolStripButton_Click(object sender, EventArgs e)
        {
            const string message = "Вы уверены, что хотите очистить конструктор?";
            const string title = "Очистка конструктора";

            DialogResult result = MessageBox
                .Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }

            ClearConstructor();
        }

        private void QueryConstructorTableListView_ControlRemoved(object sender, ControlEventArgs e)
        {
            TablePanel removedTablePanel = (TablePanel)e.Control;

            queryConstructorMiscJoinListView.Controls.Remove(removedTablePanel.Join);

            foreach (ColumnPanel currentTableColumnPanel in removedTablePanel.QueryColumns)
            {
                queryConstructorMiscFieldListView.Controls.Remove(currentTableColumnPanel);
            }

            foreach (ConditionPanel currentTableConditionPanel in removedTablePanel.QueryConditions)
            {
                queryConstructorMiscConditionListView.Controls.Remove(currentTableConditionPanel);
            }

            GenerateQuery();
        }

        private void QueryConstructorTableListView_DataChanged(object sender, EventArgs e)
        {
            ColumnPanel[] queryColumns = queryConstructorTableListView.Panels.SelectMany(currentPanel => currentPanel.QueryColumns)
                .Where(currentColumn => currentColumn.Model.Checked)
                .ToArray();

            queryConstructorMiscFieldListView.Controls.Clear();
            queryConstructorMiscFieldListView.Controls.AddRange(queryColumns);

            GenerateQuery();
        }

        private void QueryConstructorMiscListView_DataChanged(object sender, EventArgs e) => GenerateQuery();

        private void QueryConstructorExecuteButton_Click(object sender, EventArgs e)
        {
            queryConstructorMiscResultTabPage.Controls.RemoveByKey("queryError");
            queryConstructorMiscResultDataGrid.Visible = true;

            if (string.IsNullOrWhiteSpace(queryConstructorQueryText.Text))
            {
                return;
            }

            queryConstructorMiscResultDataGrid.Rows.Clear();
            queryConstructorMiscResultDataGrid.Columns.Clear();

            DbCommand command = Program.UsedDatabase.Connection.CreateCommand();
            command.CommandText = queryConstructorQueryText.Text;
            DbDataReader dataReader = null;

            try
            {
                int rowNumber = 1;
                dataReader = command.ExecuteReader();

                for (int index = 0; index < dataReader.FieldCount; index++)
                {
                    DataGridViewColumn viewColumn = new DataGridViewColumn();
                    DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();

                    viewColumn.Name = dataReader.GetName(index);
                    viewColumn.CellTemplate = cell;

                    queryConstructorMiscResultDataGrid.Columns.Add(viewColumn);
                }

                while (dataReader.Read())
                {
                    object[] values = new object[dataReader.FieldCount];

                    dataReader.GetValues(values);

                    int rowIndex = queryConstructorMiscResultDataGrid.Rows.Add(values.ToArray());
                    queryConstructorMiscResultDataGrid.Rows[rowIndex].HeaderCell.Value = rowNumber.ToString();

                    rowNumber++;
                }

                queryConstructorMiscResultRowCountLabel.Text = queryConstructorMiscResultDataGrid.RowCount.ToString();
            }
            catch (Exception ex)
            {
                TextBox errorTextBox = new TextBox();
                errorTextBox.Name = "queryError";
                errorTextBox.ReadOnly = true;
                errorTextBox.Multiline = true;
                errorTextBox.Dock = DockStyle.Fill;
                errorTextBox.Text = ex.Message;

                queryConstructorMiscResultDataGrid.Visible = false;
                queryConstructorMiscResultTabPage.Controls.Add(errorTextBox);
            }
            finally
            {
                dataReader?.Close();

                queryConstructorInteractionsTabControl.SelectedIndex = queryConstructorInteractionsTabControl.TabCount - 1;
            }
        }

        private void GenerateQuery()
        {
            _QueryBuilder.Clear();

            if (queryConstructorTableListView.Controls.Count == 0)
            {
                queryConstructorQueryText.Text = null;

                return;
            }

            foreach (TablePanel currentTablePanel in queryConstructorTableListView.Panels)
            {
                if (!currentTablePanel.ColumnEnable)
                {
                    continue;
                }

                if (currentTablePanel.Parameter)
                {
                    _QueryBuilder.AddMainTable(currentTablePanel.Model);
                }

                if (currentTablePanel.Join != null)
                {
                    _QueryBuilder.AddJoin(currentTablePanel.Join.Parameter);
                }

                _QueryBuilder.AddTableColumns(currentTablePanel);
                _QueryBuilder.AddTableConditions(currentTablePanel);
            }

            queryConstructorQueryText.Text = _QueryBuilder.Build();
        }
    }
}