using DBQueryConstructor.DatabaseInteractions.Models;

namespace DBQueryConstructor.Controls;

internal class ColumnCheckBox : CheckBox
{
    private readonly TableColumnModel _Column;

    public ColumnCheckBox(TableColumnModel column) : base()
    {
        if (column == null)
        {
            throw new ArgumentNullException(nameof(column));
        }

        _Column = column;
    }

    public TableColumnModel Column => _Column;
}