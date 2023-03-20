using System.Text;

using DBQueryConstructor.DatabaseInteractions.Models;

namespace DBQueryConstructor.Controls.ColumnPanels;

internal class QueryField
{
    public TableColumnModel Column { get; set; }

    public string ColumnAlias { get; set; }

    public bool Valid() => Column != null;

    public override string ToString()
    {
        if (Column == null)
        {
            return string.Empty;
        }

        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append(Column.GetColumnName());

        if (!string.IsNullOrWhiteSpace(ColumnAlias))
        {
            stringBuilder.Append(" AS ");
            stringBuilder.Append('[');
            stringBuilder.Append(ColumnAlias);
            stringBuilder.Append(']');
        }

        return stringBuilder.ToString();
    }
}