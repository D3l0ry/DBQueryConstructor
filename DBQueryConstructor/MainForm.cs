using System.Data.Common;
using System.Text;

using DBQueryConstructor.Controls;
using DBQueryConstructor.Controls.ColumnPanels;
using DBQueryConstructor.Controls.TablePanels;
using DBQueryConstructor.Database;
using DBQueryConstructor.Database.Models;
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

        private void DatabasePanel_CloseConnection(object sender, EventArgs e)
        {
            queryConstructorTableListView.Controls.Clear();
            queryConstructorMiscFieldListView.Controls.Clear();
            queryConstructorMiscJoinTabPage.Controls.Clear();
            queryConstructorMiscConditionTabPage.Controls.Clear();
            queryConstructorQueryText.Text = null;
            queryConstructorMiscResultTabPage.Controls.Clear();
        }

        private void DatabasePanel_TableDragDrop(object sender, DragEventArgs e)
        {
            TablePanel selectedTableNode = (TablePanel)e.Data.GetData(typeof(TablePanel));
            queryConstructorTableListView.Controls.Remove(selectedTableNode);
        }

        #region Query Constructor
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
            TableListView tableListView = (TableListView)sender;
            ColumnPanel[] queryColumns = tableListView.Panels.SelectMany(currentPanel => currentPanel.QueryColumns)
                .Where(currentColumn => currentColumn.Model.Checked)
                .ToArray();

            queryConstructorMiscFieldListView.Controls.Clear();
            queryConstructorMiscFieldListView.Controls.AddRange(queryColumns);

            GenerateQuery();
        }

        private void QueryConstructorMiscListView_DataChanged(object sender, EventArgs e) => GenerateQuery();

        private void QueryConstructorQueryToolExecuteButton_Click(object sender, EventArgs e)
        {
            queryConstructorMiscResultTabPage.Controls.Clear();

            if (string.IsNullOrWhiteSpace(queryConstructorQueryText.Text))
            {
                return;
            }

            DataGridView dataGridView = new DataGridView();
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeColumns = true;
            dataGridView.Dock = DockStyle.Fill;

            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            DbCommand command = Program.UsedDatabase.Connection.CreateCommand();
            command.CommandText = queryConstructorQueryText.Text;
            DbDataReader dataReader = null;

            try
            {
                dataReader = command.ExecuteReader();

                for (int index = 0; index < dataReader.FieldCount; index++)
                {
                    DataGridViewColumn viewColumn = new DataGridViewColumn();
                    DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                    viewColumn.Name = dataReader.GetName(index);
                    viewColumn.CellTemplate = cell;

                    dataGridView.Columns.Add(viewColumn);
                }

                while (dataReader.Read())
                {
                    List<object> values = new List<object>();

                    for (int index = 0; index < dataReader.FieldCount; index++)
                    {
                        object value = dataReader.GetValue(index);

                        values.Add(value);
                    }

                    dataGridView.Rows.Add(values.ToArray());
                }

                queryConstructorMiscResultTabPage.Controls.Add(dataGridView);
            }
            catch (Exception ex)
            {
                TextBox errorTextBox = new TextBox();
                errorTextBox.ReadOnly = true;
                errorTextBox.Multiline = true;
                errorTextBox.Dock = DockStyle.Fill;
                errorTextBox.Text = ex.Message;

                queryConstructorMiscResultTabPage.Controls.Add(errorTextBox);
            }
            finally
            {
                dataReader?.Close();

                queryConstructorMiscTabControl.SelectedIndex = queryConstructorMiscTabControl.TabCount - 1;
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

            IEnumerable<TablePanel> tablePanels = queryConstructorTableListView.Panels
                .Where(currentTablePanel => currentTablePanel.ColumnEnable);
            IEnumerable<ColumnPanel> columnPanels = queryConstructorMiscFieldListView.Panels;
            IEnumerable<JoinPanel> joinPanels = queryConstructorMiscJoinListView.Panels;
            IEnumerable<ConditionPanel> conditionPanels = queryConstructorMiscConditionListView.Panels;
            TableModel mainTable = tablePanels.First(currentTable => currentTable.Parameter).Model;

            _QueryBuilder.AddMainTable(mainTable);

            foreach (ColumnPanel currentColumn in columnPanels)
            {
                if (!currentColumn.Model.TablePanel.ColumnEnable)
                {
                    continue;
                }

                if (!currentColumn.Model.Checked)
                {
                    continue;
                }

                _QueryBuilder.AddColumn(currentColumn.Parameter);
            }

            foreach (JoinPanel currentJoinPanel in joinPanels)
            {
                if (!currentJoinPanel.Model.ColumnEnable)
                {
                    continue;
                }

                _QueryBuilder.AddJoin(currentJoinPanel.Parameter);
            }

            foreach (ConditionPanel currentConditionPanel in conditionPanels)
            {
                if (!currentConditionPanel.Model.ColumnEnable)
                {
                    continue;
                }

                if (!currentConditionPanel.Parameter.Valid())
                {
                    continue;
                }

                _QueryBuilder.AddCondition(currentConditionPanel.Parameter);
            }

            queryConstructorQueryText.Text = _QueryBuilder.Build();
        }
        #endregion
    }
}