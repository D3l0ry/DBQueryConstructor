using DBQueryConstructor.DatabaseInteractions.Models;

namespace DBQueryConstructor.Controls.TablePanels;
internal class TableParameter
{
    public TableModel Table { get; set; }

    public bool IsMainTable { get; set; }
}