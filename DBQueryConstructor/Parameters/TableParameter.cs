using DBQueryConstructor.DatabaseInteractions.Models;

namespace DBQueryConstructor.Parameters;
internal class TableParameter
{
    public TableModel Table { get; set; }

    public bool IsMainTable { get; set; }
}