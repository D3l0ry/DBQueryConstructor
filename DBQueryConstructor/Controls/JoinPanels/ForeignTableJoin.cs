using System.Text;

using DBQueryConstructor.DatabaseInteractions.Models;
using DBQueryConstructor.QueryInteractions;

namespace DBQueryConstructor.Controls.JoinPanels;

internal class ForeignTableJoin : IComparable<ForeignTableJoin>
{
    public int Index { get; set; }

    public string TableName { get; set; }

    public TableColumnModel MainColumnTable { get; set; }

    public TableColumnModel JoinedColumnTable { get; set; }

    public QueryJoinType Join { get; set; }

    public bool Validate() => JoinedColumnTable != null && MainColumnTable != null;

    public int CompareTo(ForeignTableJoin other) => Index.CompareTo(other.Index);

    public override string ToString()
    {
        if (MainColumnTable == null || JoinedColumnTable == null)
        {
            return string.Empty;
        }

        StringBuilder stringBuilder = new StringBuilder();

        switch (Join)
        {
            case QueryJoinType.Join:
                stringBuilder.Append("JOIN ");
                break;

            case QueryJoinType.LeftJoin:
                stringBuilder.Append("LEFT JOIN ");
                break;
        }

        string joinTableName = JoinedColumnTable.GetTableName();
        string joinTableColumn = JoinedColumnTable.GetColumnName();
        string mainTableColumn = MainColumnTable.GetColumnName();

        stringBuilder.Append(joinTableName);
        stringBuilder.Append(" ON ");
        stringBuilder.Append(joinTableColumn);
        stringBuilder.Append('=');
        stringBuilder.Append(mainTableColumn);

        return stringBuilder.ToString();
    }
}