using DBQueryConstructor.Parameters;

namespace DBQueryConstructor.QueryInteractions;
internal class QueryStored
{
    public string Server { get; set; }

    public string Database { get; set; }

    public TableParameter[] Tables { get; set; }

    public QueryFieldParameter[] Columns { get; set; }

    public ForeignTableJoinParameter[] Joins { get; set; }

    public QueryConditionParameter[] Conditions { get; set; }
}