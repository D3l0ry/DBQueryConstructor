using System.Data.Common;

using DBQueryConstructor.Controls.ColumnPanels;
using DBQueryConstructor.Controls.ConditionPanels;
using DBQueryConstructor.Controls.JoinPanels;
using DBQueryConstructor.Controls.TablePanels;
using DBQueryConstructor.Parameters;
using DBQueryConstructor.QueryInteractions;

namespace DBQueryConstructor.Controls.ConstructorPanels;
internal class ConstructorTabPage : TabPage
{
    private readonly QueryBuilder _queryBuilder;
    private readonly TableListView _tableListView;
    private readonly ColumnListView _columnListView;
    private readonly JoinListView _joinListView;
    private readonly ConditionListView _conditionListView;
    private readonly TextBox _queryTextBox;
    private readonly DataGridView _resultDataGrid;

    private readonly TabControl _constructorMiscTabControl;
    private readonly TabPage _queryConstructorMiscFieldTabPage;
    private readonly TabPage _queryConstructorMiscJoinTabPage;
    private readonly TabPage _queryConstructorMiscConditionTabPage;
    private readonly TabPage _queryConstructorMiscQueryTabPage;
    private readonly TabPage _queryConstructorMiscResultTabPage;

    public ConstructorTabPage(string text) : base(text)
    {
        _queryBuilder = new();
        _tableListView = new();
        _columnListView = new();
        _joinListView = new();
        _conditionListView = new();
        _queryTextBox = new();
        _resultDataGrid = new();

        _constructorMiscTabControl = new();
        _queryConstructorMiscFieldTabPage = new("Поля");
        _queryConstructorMiscJoinTabPage = new("Присоединения");
        _queryConstructorMiscConditionTabPage = new("Условия");
        _queryConstructorMiscQueryTabPage = new("Запрос");
        _queryConstructorMiscResultTabPage = new("Результат");

        BackColor = Color.White;

        InitializeComponent();
    }

    private void InitializeComponent()
    {
        ColumnStyle columnStyle1 = new(SizeType.Percent, 33.33f);
        ColumnStyle columnStyle2 = new(SizeType.Percent, 33.33f);
        ColumnStyle columnStyle3 = new(SizeType.Percent, 33.33f);

        SplitContainer splitContainer = new();
        splitContainer.Orientation = Orientation.Horizontal;
        splitContainer.Dock = DockStyle.Fill;
        splitContainer.Panel1.Controls.Add(_tableListView);
        splitContainer.Panel2.Controls.Add(_constructorMiscTabControl);

        _resultDataGrid.AllowUserToAddRows = false;
        _resultDataGrid.AllowUserToDeleteRows = false;
        _resultDataGrid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
        _resultDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        _tableListView.AutoScroll = true;
        _columnListView.AutoScroll = true;
        _joinListView.AutoScroll = true;
        _conditionListView.AutoScroll = true;

        _tableListView.AllowDrop = true;
        _joinListView.AllowDrop = true;
        _conditionListView.AllowDrop = true;

        _queryTextBox.Multiline = true;

        _tableListView.ColumnCount = 7;
        _columnListView.ColumnCount = 3;

        _tableListView.Dock = DockStyle.Fill;
        _columnListView.Dock = DockStyle.Fill;
        _joinListView.Dock = DockStyle.Fill;
        _conditionListView.Dock = DockStyle.Fill;
        _queryTextBox.Dock = DockStyle.Fill;
        _resultDataGrid.Dock = DockStyle.Fill;
        _constructorMiscTabControl.Dock = DockStyle.Fill;

        _queryConstructorMiscFieldTabPage.BackColor = Color.White;
        _queryConstructorMiscJoinTabPage.BackColor = Color.White;
        _queryConstructorMiscConditionTabPage.BackColor = Color.White;
        _queryConstructorMiscQueryTabPage.BackColor = Color.White;
        _queryConstructorMiscResultTabPage.BackColor = Color.White;
        _resultDataGrid.BackgroundColor = Color.White;

        _tableListView.ControlRemoved += TableListView_TableRemoved;
        _tableListView.DataChanged += TableListView_DataChanged;
        _columnListView.DataChanged += ListView_DataChanged;
        _joinListView.DataChanged += ListView_DataChanged;
        _conditionListView.DataChanged += ListView_DataChanged;

        _constructorMiscTabControl.TabPages.Add(_queryConstructorMiscFieldTabPage);
        _constructorMiscTabControl.TabPages.Add(_queryConstructorMiscJoinTabPage);
        _constructorMiscTabControl.TabPages.Add(_queryConstructorMiscConditionTabPage);
        _constructorMiscTabControl.TabPages.Add(_queryConstructorMiscQueryTabPage);
        _constructorMiscTabControl.TabPages.Add(_queryConstructorMiscResultTabPage);

        _queryConstructorMiscFieldTabPage.Controls.Add(_columnListView);
        _queryConstructorMiscJoinTabPage.Controls.Add(_joinListView);
        _queryConstructorMiscConditionTabPage.Controls.Add(_conditionListView);
        _queryConstructorMiscQueryTabPage.Controls.Add(_queryTextBox);
        _queryConstructorMiscResultTabPage.Controls.Add(_resultDataGrid);

        _columnListView.ColumnStyles.Add(columnStyle1);
        _columnListView.ColumnStyles.Add(columnStyle2);
        _columnListView.ColumnStyles.Add(columnStyle3);

        Controls.Add(splitContainer);
    }

    private void TableListView_DataChanged(object sender, EventArgs e)
    {
        ColumnPanel[] queryColumns = _tableListView.Panels
            .SelectMany(currentPanel => currentPanel.QueryColumns)
            .Where(currentColumn => currentColumn.Model.Checked)
            .ToArray();

        _columnListView.Controls.Clear();
        _columnListView.Controls.AddRange(queryColumns);

        GenerateQuery();
    }

    private void TableListView_TableRemoved(object sender, ControlEventArgs e)
    {
        TablePanel removedTablePanel = (TablePanel)e.Control;

        _joinListView.Controls.Remove(removedTablePanel.Join);

        foreach (ColumnPanel currentTableColumnPanel in removedTablePanel.QueryColumns)
        {
            _columnListView.Controls.Remove(currentTableColumnPanel);
        }

        foreach (ConditionPanel currentTableConditionPanel in removedTablePanel.QueryConditions)
        {
            _conditionListView.Controls.Remove(currentTableConditionPanel);
        }

        GenerateQuery();
    }

    private void ListView_DataChanged(object sender, EventArgs e) => GenerateQuery();

    private void GenerateQuery()
    {
        _queryBuilder.Clear();

        if (_tableListView.Controls.Count == 0)
        {
            _queryTextBox.Text = null;

            return;
        }

        foreach (TablePanel currentTablePanel in _tableListView.Panels)
        {
            if (!currentTablePanel.ColumnEnable)
            {
                continue;
            }

            if (currentTablePanel.Parameter.IsMainTable)
            {
                _queryBuilder.AddMainTable(currentTablePanel.Model);
            }

            if (currentTablePanel.Join != null)
            {
                _queryBuilder.AddJoin(currentTablePanel.Join.Parameter);
            }

            _queryBuilder.AddTableColumns(currentTablePanel);
            _queryBuilder.AddTableConditions(currentTablePanel);
        }

        _queryTextBox.Text = _queryBuilder.Build();
    }

    public void ClearConstructor()
    {
        _tableListView.Controls.Clear();
        _columnListView.Controls.Clear();
        _joinListView.Controls.Clear();
        _conditionListView.Controls.Clear();
        _queryConstructorMiscResultTabPage.Controls.RemoveByKey("queryError");
        _queryTextBox.Text = null;
    }

    public void ExecuteQuery()
    {
        _resultDataGrid.Visible = true;
        _resultDataGrid.Rows.Clear();
        _resultDataGrid.Columns.Clear();
        _queryConstructorMiscResultTabPage.Controls.RemoveByKey("queryError");

        if (string.IsNullOrWhiteSpace(_queryTextBox.Text))
        {
            return;
        }

        try
        {
            DbCommand command = Program.UsedDatabase.Connection.CreateCommand();
            command.CommandText = _queryTextBox.Text;

            using DbDataReader dataReader = command.ExecuteReader();
            int rowNumber = 1;

            for (int index = 0; index < dataReader.FieldCount; index++)
            {
                DataGridViewColumn viewColumn = new DataGridViewColumn();
                DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();

                viewColumn.Name = dataReader.GetName(index);
                viewColumn.CellTemplate = cell;

                _resultDataGrid.Columns.Add(viewColumn);
            }

            while (dataReader.Read())
            {
                object[] values = new object[dataReader.FieldCount];

                dataReader.GetValues(values);

                int rowIndex = _resultDataGrid.Rows.Add(values.ToArray());
                _resultDataGrid.Rows[rowIndex].HeaderCell.Value = rowNumber.ToString();

                rowNumber++;
            }
        }
        catch (Exception ex)
        {
            TextBox errorTextBox = new TextBox();
            errorTextBox.Name = "queryError";
            errorTextBox.ReadOnly = true;
            errorTextBox.Multiline = true;
            errorTextBox.Dock = DockStyle.Fill;
            errorTextBox.Text = ex.Message;

            _resultDataGrid.Visible = false;
            _queryConstructorMiscResultTabPage.Controls.Add(errorTextBox);
        }
        finally
        {
            _constructorMiscTabControl.SelectedIndex = _constructorMiscTabControl.TabCount - 1;
        }
    }

    public QueryStored GetQueryStored()
    {
        QueryStored stored = new QueryStored();

        stored.Server = Program.UsedDatabase.Connection.DataSource;
        stored.Database = Program.UsedDatabase.Connection.Database;
        stored.Tables = _tableListView.Panels.Select(x => x.Parameter).ToArray();
        stored.Columns = _columnListView.Panels.Select(x => x.Parameter).ToArray();
        stored.Joins = _joinListView.Panels.Select(x => x.Parameter).ToArray();
        stored.Conditions = _conditionListView.Panels.Select(x => x.Parameter).ToArray();

        return stored;
    }

    public void LoadQueryStored(QueryStored stored)
    {
        if (stored == null)
        {
            return;
        }

        ClearConstructor();

        foreach (TableParameter currentTable in stored.Tables)
        {
            TablePanel tablePanel = _tableListView.CreateTablePanel(currentTable.Table);

            _tableListView.AddPanel(tablePanel);

            foreach (QueryFieldParameter currentField in stored.Columns)
            {
                ColumnCheckBox selectedCheckBox = tablePanel.Columns
                    .FirstOrDefault(currentColumn =>
                            currentColumn.Column.GetColumnName() == currentField.Column.GetColumnName());

                if (selectedCheckBox == null)
                {
                    continue;
                }

                ColumnPanel selectedColumnPanel = tablePanel.QueryColumns
                    .First(currentColumn =>
                        currentColumn.Model == selectedCheckBox);

                selectedColumnPanel.Parameter.Column = currentField.Column;
                selectedColumnPanel.Parameter.ColumnAlias = currentField.ColumnAlias;
                selectedCheckBox.Checked = true;
            }
        }

        foreach (ForeignTableJoinParameter currentJoin in stored.Joins)
        {
            TablePanel tablePanel = _tableListView.Panels
                .FirstOrDefault(currentTablePanel =>
                    currentTablePanel.Model.GetTableName() == currentJoin.TableName);

            if (tablePanel == null)
            {
                continue;
            }

            JoinPanel newJoin = _joinListView.CreateJoinPanel(tablePanel);

            newJoin.Parameter.Index = currentJoin.Index;
            newJoin.Parameter.TableName = currentJoin.TableName;
            newJoin.Parameter.MainColumnTable = currentJoin.MainColumnTable;
            newJoin.Parameter.JoinedColumnTable = currentJoin.JoinedColumnTable;
            newJoin.Parameter.Join = currentJoin.Join;

            _joinListView.AddPanel(newJoin);

            tablePanel.ColumnEnable = newJoin.Parameter.Validate();
        }

        foreach (QueryConditionParameter currentCondition in stored.Conditions)
        {
            TablePanel tablePanel = _tableListView.Panels
                .FirstOrDefault(currentTablePanel =>
                    currentTablePanel.Model.GetTableName() == currentCondition.TableName);

            if (tablePanel == null)
            {
                continue;
            }

            ConditionPanel newCondition = _conditionListView.CreateConditionPanel(tablePanel);

            newCondition.Parameter.Index = currentCondition.Index;
            newCondition.Parameter.TableName = currentCondition.TableName;
            newCondition.Parameter.Condition = currentCondition.Condition;
            newCondition.Parameter.Equal = currentCondition.Equal;
            newCondition.Parameter.Column = currentCondition.Column;
            newCondition.Parameter.ParameterValue = currentCondition.ParameterValue;
            newCondition.Parameter.IsNull = currentCondition.IsNull;

            _conditionListView.AddPanel(newCondition);
        }
    }
}