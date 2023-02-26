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

        #region DatabasePanel
        private void FillTableTreeView()
        {
            TreeNode rootNode = databaseTableTreeView.Nodes.Add(Program.UsedDatabase.Connection.Database);
            rootNode.ImageKey = "databaseview";
            rootNode.SelectedImageKey = "databaseview";

            TableModel[] tables = Program.UsedDatabase.Table.ToArray();
            TableColumnModel[] tablesColumns = Program.UsedDatabase.TableColumn.ToArray();

            if (tablesColumns.Length == 0)
            {
                return;
            }

            TableConstraintModel[] tableConstraints = Program.UsedDatabase.TableConstraint.ToArray();
            ColumnConstraintModel[] columnConstraints = Program.UsedDatabase.ColumnConstraint.ToArray();
            IEnumerable<IGrouping<string, TableColumnModel>> tableGroup = tablesColumns
                .GroupBy(currentColumn => $"{currentColumn.TableSchema}.{currentColumn.TableName}");

            foreach (IGrouping<string, TableColumnModel> currentGroup in tableGroup)
            {
                TableModel selectedTable = tables
                    .FirstOrDefault(currentTable => $"{currentTable.Schema}.{currentTable.Name}" == currentGroup.Key);

                if (selectedTable == null)
                {
                    continue;
                }

                selectedTable.Columns = currentGroup.ToArray();

                TableTreeNode tableTreeNode = new TableTreeNode(selectedTable);
                TableConstraintModel[] selectedTableConstraints = tableConstraints
                    .Where(currentTableConstraint =>
                        $"{currentTableConstraint.SchemaName}.{currentTableConstraint.TableName}" == currentGroup.Key)
                    .ToArray();

                rootNode.Nodes.Add(tableTreeNode);

                foreach (TableColumnModel currentColumn in currentGroup)
                {
                    StringBuilder columnBuilder = new StringBuilder($"{currentColumn.Name} (");

                    foreach (TableConstraintModel currentTableConstraint in selectedTableConstraints)
                    {
                        ColumnConstraintModel selectedColumnConstraint = columnConstraints
                            .FirstOrDefault(currentColumnConstraint =>
                                currentColumnConstraint.SchemaName == currentTableConstraint.SchemaName &&
                                currentColumnConstraint.TableName == currentTableConstraint.TableName &&
                                currentColumnConstraint.ColumnName == currentColumn.Name &&
                                currentColumnConstraint.Name == currentTableConstraint.Name);

                        if (selectedColumnConstraint == null)
                        {
                            continue;
                        }

                        currentColumn.Constraint = selectedColumnConstraint;

                        columnBuilder.Append($"{currentTableConstraint.Type}, ");

                        break;
                    }

                    columnBuilder.Append($"{currentColumn.Type}, ");
                    columnBuilder.Append($"{(currentColumn.IsNullable.Equals("YES") ? "null" : "not null")})");

                    TreeNode tableColumnNode = new TreeNode(columnBuilder.ToString());
                    tableColumnNode.ImageKey = "column.png";
                    tableColumnNode.SelectedImageKey = "column.png";

                    tableTreeNode.Nodes.Add(tableColumnNode);
                }
            }

            rootNode.Expand();
        }

        private void OpenConnectionDatabaseToolStripButton_Click(object sender, EventArgs e)
        {
            if (Program.UsedDatabase != null)
            {
                return;
            }

            Program.UsedDatabase = new UsedDatabase("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;");
            FillTableTreeView();
        }

        private void CloseConnectionDatabaseToolStripButton_Click(object sender, EventArgs e)
        {
            databaseTableTreeView.Nodes.Clear();
            queryConstructorTableListView.Controls.Clear();
            queryConstructorMiscFieldListView.Controls.Clear();
            queryConstructorMiscJoinTabPage.Controls.Clear();
            queryConstructorMiscConditionTabPage.Controls.Clear();
            queryConstructorQueryText.Text = null;
            queryConstructorMiscResultTabPage.Controls.Clear();

            Program.UsedDatabase?.Dispose();
            Program.UsedDatabase = null;
        }

        private void DatabaseTableTreeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Item is TableTreeNode)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void DatabaseTableTreeView_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(typeof(TablePanel)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void DatabaseTableTreeView_DragDrop(object sender, DragEventArgs e)
        {
            TablePanel selectedTableNode = (TablePanel)e.Data.GetData(typeof(TablePanel));
            queryConstructorTableListView.Controls.Remove(selectedTableNode);
        }
        #endregion

        #region Query Constructor
        private void QueryConstructorTableListView_ControlRemoved(object sender, ControlEventArgs e)
        {
            TablePanel removedTablePanel = (TablePanel)e.Control;

            queryConstructorMiscJoinListView.Controls.Remove(removedTablePanel.Join);

            foreach(ColumnPanel currentTableColumnPanel in removedTablePanel.QueryColumns)
            {
                queryConstructorMiscFieldListView.Controls.Remove(currentTableColumnPanel);
            }

            foreach(ConditionPanel currentTableConditionPanel in removedTablePanel.QueryConditions)
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

        private void QueryConstructorMiscListView_DataChanged(object sender, EventArgs e)
        {
            GenerateQuery();
        }

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
                if(!currentColumn.Model.TablePanel.ColumnEnable)
                {
                    continue;
                }

                if(!currentColumn.Model.Checked)
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