using DBQueryConstructor.Controls.ColumnPanels;
using DBQueryConstructor.Controls.ConditionPanels;
using DBQueryConstructor.Controls.JoinPanels;
using DBQueryConstructor.Controls.TablePanels;

namespace DBQueryConstructor.QueryInteractions;
internal class QueryStored
{
    public string Server { get; set; }

    public string Database { get; set; }

    public TableParameter[] Tables { get; set; }

    public QueryField[] Columns { get; set; }

    public ForeignTableJoin[] Joins { get; set; }

    public QueryConditionParameter[] Conditions { get; set; }
}