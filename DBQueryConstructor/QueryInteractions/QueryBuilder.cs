using System.Text;

using DBQueryConstructor.Controls;
using DBQueryConstructor.Controls.ColumnPanels;
using DBQueryConstructor.DatabaseInteractions.Models;
using DBQueryConstructor.Parameters;

namespace DBQueryConstructor.QueryInteractions;

internal class QueryBuilder
{
    private const string START_QUERY = "SELECT ";

    private readonly StringBuilder _stringBuilder;
    private TableModel _mainTable;
    private readonly List<QueryFieldParameter> _Columns;
    private readonly List<ForeignTableJoinParameter> _Joins;
    private readonly List<QueryConditionParameter> _Conditions;

    public QueryBuilder()
    {
        _stringBuilder = new StringBuilder(START_QUERY);
        _Columns = new List<QueryFieldParameter>();
        _Joins = new List<ForeignTableJoinParameter>();
        _Conditions = new List<QueryConditionParameter>();
    }

    public QueryFieldParameter[] Columns => _Columns.ToArray();

    public ForeignTableJoinParameter[] Joins => _Joins.ToArray();

    public QueryConditionParameter[] Conditions => _Conditions.ToArray();

    private void AppendColumnArray()
    {
        if (_Columns.Count == 0)
        {
            _stringBuilder.Append("* ");
        }

        for (int index = 0; index < _Columns.Count; index++)
        {
            QueryFieldParameter currentColumn = _Columns[index];

            if (!currentColumn.Valid())
            {
                continue;
            }

            _stringBuilder.Append(currentColumn);
            _stringBuilder.Append(',');

            if (index == _Columns.Count - 1)
            {
                _stringBuilder[_stringBuilder.Length - 1] = ' ';
            }
        }

        string tableName = _mainTable.GetTableName();

        _stringBuilder.Append($"FROM {tableName}");
    }

    private void AppendJoinArray()
    {
        _Joins.Sort();

        for (int index = 0; index < _Joins.Count; index++)
        {
            ForeignTableJoinParameter currentForeignTable = _Joins[index];
            string foreignTableResult = $"\r\n{currentForeignTable}";

            _stringBuilder.Append(foreignTableResult);
        }
    }

    private void AppendWhereArray()
    {
        if (_Conditions.Count == 0)
        {
            return;
        }

        _Conditions.Sort();
        _stringBuilder.Append("\r\nWHERE ");

        for (int index = 0; index < _Conditions.Count; index++)
        {
            QueryConditionParameter currentParameter = _Conditions[index];

            if (index != 0)
            {
                _stringBuilder.Append($"\r\n{currentParameter.Condition} ");
            }

            _stringBuilder.Append(currentParameter);
        }
    }

    public QueryBuilder AddMainTable(TableModel mainTable)
    {
        if (mainTable == null)
        {
            throw new ArgumentNullException(nameof(mainTable));
        }

        _mainTable = mainTable;

        return this;
    }

    public QueryBuilder AddColumn(QueryFieldParameter tableColumn)
    {
        if (tableColumn == null)
        {
            throw new ArgumentNullException(nameof(tableColumn));
        }

        _Columns.Add(tableColumn);

        return this;
    }

    public QueryBuilder AddTableColumns(TablePanel tablePanel)
    {
        if (tablePanel == null)
        {
            throw new ArgumentNullException(nameof(tablePanel));
        }

        foreach (ColumnPanel selectedColumnPanel in tablePanel.QueryColumns)
        {
            if (!selectedColumnPanel.Model.Checked)
            {
                continue;
            }

            AddColumn(selectedColumnPanel.Parameter);
        }

        return this;
    }

    public QueryBuilder AddJoin(ForeignTableJoinParameter join)
    {
        if (join == null)
        {
            throw new ArgumentNullException(nameof(join));
        }

        _Joins.Add(join);

        return this;
    }

    public QueryBuilder AddCondition(QueryConditionParameter conditionParameter)
    {
        if (conditionParameter == null)
        {
            throw new ArgumentNullException(nameof(conditionParameter));
        }

        _Conditions.Add(conditionParameter);

        return this;
    }

    public QueryBuilder AddTableConditions(TablePanel tablePanel)
    {
        if (tablePanel == null)
        {
            throw new ArgumentNullException(nameof(tablePanel));
        }

        foreach (ConditionPanel currentCondition in tablePanel.QueryConditions)
        {
            AddCondition(currentCondition.Parameter);
        }

        return this;
    }

    public QueryBuilder RemoveColumn(QueryFieldParameter tableColumn)
    {
        if (tableColumn == null)
        {
            throw new ArgumentNullException(nameof(tableColumn));
        }

        _Columns.Remove(tableColumn);

        return this;
    }

    public QueryBuilder RemoveJoin(ForeignTableJoinParameter join)
    {
        if (join == null)
        {
            throw new ArgumentNullException(nameof(join));
        }

        _Joins.Remove(join);

        return this;
    }

    public QueryBuilder RemoveCondition(QueryConditionParameter conditionParameter)
    {
        if (conditionParameter == null)
        {
            throw new ArgumentNullException(nameof(conditionParameter));
        }

        _Conditions.Remove(conditionParameter);

        return this;
    }

    public QueryBuilder ClearTables()
    {
        return this;
    }

    public QueryBuilder ClearColumns()
    {
        _Columns.Clear();
        return this;
    }

    public QueryBuilder ClearJoins()
    {
        _Joins.Clear();
        return this;
    }

    public QueryBuilder ClearCondition()
    {
        _Conditions.Clear();
        return this;
    }

    public QueryBuilder Clear()
    {
        _stringBuilder.Clear();

        ClearTables();
        ClearColumns();
        ClearJoins();
        ClearCondition();

        _stringBuilder.Append(START_QUERY);

        return this;
    }

    public string Build()
    {
        AppendColumnArray();
        AppendJoinArray();
        AppendWhereArray();

        return _stringBuilder.ToString();
    }
}