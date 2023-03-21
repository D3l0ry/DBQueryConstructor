using System.Data.Common;
using System.Text.Json;

using DBQueryConstructor.Controls;
using DBQueryConstructor.Controls.ColumnPanels;
using DBQueryConstructor.Parameters;
using DBQueryConstructor.QueryInteractions;

using Handy;

namespace DBQueryConstructor;

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
            CreateParams parameters = base.CreateParams;
            parameters.ExStyle = 0x2000000;

            return parameters;
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
        ColumnPanel[] queryColumns = queryConstructorTableListView.Panels
            .SelectMany(currentPanel => currentPanel.QueryColumns)
            .Where(currentColumn => currentColumn.Model.Checked)
            .ToArray();

        queryConstructorMiscFieldListView.Controls.Clear();
        queryConstructorMiscFieldListView.Controls.AddRange(queryColumns);

        GenerateQuery();
    }

    private void QueryConstructorMiscListView_DataChanged(object sender, EventArgs e) => GenerateQuery();

    private void QueryConstructorOpenToolStripButton_Click(object sender, EventArgs e)
    {
        if (openFileDialog.ShowDialog() != DialogResult.OK)
        {
            return;
        }

        ClearConstructor();

        using Stream storedFile = openFileDialog.OpenFile();
        QueryStored stored = JsonSerializer.Deserialize<QueryStored>(storedFile);

        if (stored == null)
        {
            return;
        }

        foreach (TableParameter currentTable in stored.Tables)
        {
            TablePanel tablePanel = queryConstructorTableListView.CreateTablePanel(currentTable.Table);

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

                selectedColumnPanel.Parameter = currentField;
                selectedCheckBox.Checked = true;
            }

            queryConstructorTableListView.AddPanel(tablePanel);
        }

        foreach (ForeignTableJoinParameter currentJoin in stored.Joins)
        {
            TablePanel tablePanel = queryConstructorTableListView.Panels
                .FirstOrDefault(currentTablePanel =>
                    currentTablePanel.Model.GetTableName() == currentJoin.TableName);

            if (tablePanel == null)
            {
                continue;
            }

            JoinPanel newJoin = queryConstructorMiscJoinListView.CreateJoinPanel(tablePanel);
            newJoin.Parameter = currentJoin;

            queryConstructorMiscJoinListView.AddPanel(newJoin);
        }

        foreach (QueryConditionParameter currentCondition in stored.Conditions)
        {
            TablePanel tablePanel = queryConstructorTableListView.Panels
                .FirstOrDefault(currentTablePanel =>
                    currentTablePanel.Model.GetTableName() == currentCondition.TableName);

            if (tablePanel == null)
            {
                continue;
            }

            ConditionPanel newCondition = queryConstructorMiscConditionListView.CreateConditionPanel(tablePanel);
            newCondition.Parameter = currentCondition;

            queryConstructorMiscConditionListView.AddPanel(newCondition);
        }
    }

    private void QueryConstructorSaveToolStripButton_Click(object sender, EventArgs e)
    {
        if (saveFileDialog.ShowDialog() != DialogResult.OK)
        {
            return;
        }

        QueryStored stored = new QueryStored();

        stored.Server = Program.UsedDatabase.Connection.DataSource;
        stored.Database = Program.UsedDatabase.Connection.Database;
        stored.Tables = queryConstructorTableListView.Panels.Select(x => x.Parameter).ToArray();
        stored.Columns = queryConstructorMiscFieldListView.Panels.Select(x => x.Parameter).ToArray();
        stored.Joins = queryConstructorMiscJoinListView.Panels.Select(x => x.Parameter).ToArray();
        stored.Conditions = queryConstructorMiscConditionListView.Panels.Select(x => x.Parameter).ToArray();

        using FileStream storedFile = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
        JsonSerializerOptions options = new JsonSerializerOptions();

        options.WriteIndented = true;

        JsonSerializer.Serialize(storedFile, stored, options);
    }

    private void QueryConstructorExecuteButton_Click(object sender, EventArgs e)
    {
        queryConstructorMiscResultDataGrid.Visible = true;

        queryConstructorMiscResultTabPage.Controls.RemoveByKey("queryError");
        queryConstructorMiscResultDataGrid.Rows.Clear();
        queryConstructorMiscResultDataGrid.Columns.Clear();

        if (string.IsNullOrWhiteSpace(queryConstructorQueryText.Text))
        {
            return;
        }

        DbCommand command = Program.UsedDatabase.Connection.CreateCommand();
        DbDataReader dataReader = null;

        command.CommandText = queryConstructorQueryText.Text;

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

            if (currentTablePanel.Parameter.IsMainTable)
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