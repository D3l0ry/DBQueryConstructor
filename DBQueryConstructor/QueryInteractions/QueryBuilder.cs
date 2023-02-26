using System.Text;

using DBQueryConstructor.Database.Models;

namespace DBQueryConstructor.QueryInteractions
{
    internal class QueryBuilder
    {
        private readonly StringBuilder _stringBuilder;
        private TableModel _mainTable;
        private readonly List<QueryField> _Columns;
        private readonly List<ForeignTableJoin> _Joins;
        private readonly List<QueryConditionParameter> _ConditionParameters;

        public QueryBuilder()
        {
            _stringBuilder = new StringBuilder("SELECT ");
            _Columns = new List<QueryField>();
            _Joins = new List<ForeignTableJoin>();
            _ConditionParameters = new List<QueryConditionParameter>();
        }

        private void AppendColumnArray()
        {
            if (_Columns.Count == 0)
            {
                _stringBuilder.Append("* ");
            }

            for (int index = 0; index < _Columns.Count; index++)
            {
                QueryField currentColumn = _Columns[index];
                
                if(!currentColumn.Valid())
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
            for (int index = 0; index < _Joins.Count; index++)
            {
                ForeignTableJoin currentForeignTable = _Joins[index];
                string foreignTableResult = $"\r\n{currentForeignTable}";

                _stringBuilder.Append(foreignTableResult);
            }
        }

        private void AppendWhereArray()
        {
            if (_ConditionParameters.Count == 0)
            {
                return;
            }

            _stringBuilder.Append("\r\nWHERE ");

            for (int index = 0; index < _ConditionParameters.Count; index++)
            {
                QueryConditionParameter currentParameter = _ConditionParameters[index];

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

        public QueryBuilder AddColumn(QueryField tableColumn)
        {
            if (tableColumn == null)
            {
                throw new ArgumentNullException(nameof(tableColumn));
            }

            _Columns.Add(tableColumn);

            return this;
        }

        public QueryBuilder RemoveColumn(QueryField tableColumn)
        {
            if (tableColumn == null)
            {
                throw new ArgumentNullException(nameof(tableColumn));
            }

            _Columns.Remove(tableColumn);

            return this;
        }

        public QueryBuilder ClearColumns()
        {
            _Columns.Clear();

            return this;
        }

        public QueryBuilder AddJoin(ForeignTableJoin join)
        {
            if (join == null)
            {
                throw new ArgumentNullException(nameof(join));
            }

            _Joins.Add(join);

            return this;
        }

        public QueryBuilder RemoveJoin(ForeignTableJoin join)
        {
            if (join == null)
            {
                throw new ArgumentNullException(nameof(join));
            }

            _Joins.Remove(join);

            return this;
        }

        public QueryBuilder ClearJoins()
        {
            _Joins.Clear();

            return this;
        }

        public QueryBuilder AddCondition(QueryConditionParameter conditionParameter)
        {
            if (conditionParameter == null)
            {
                throw new ArgumentNullException(nameof(conditionParameter));
            }

            _ConditionParameters.Add(conditionParameter);

            return this;
        }

        public QueryBuilder RemoveCondition(QueryConditionParameter conditionParameter)
        {
            if (conditionParameter == null)
            {
                throw new ArgumentNullException(nameof(conditionParameter));
            }

            _ConditionParameters.Remove(conditionParameter);

            return this;
        }

        public QueryBuilder ClearCondition()
        {
            _ConditionParameters.Clear();

            return this;
        }

        public QueryBuilder Clear()
        {
            _stringBuilder.Clear();

            ClearColumns();
            ClearJoins();
            ClearCondition();

            _stringBuilder.Append("SELECT ");

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
}