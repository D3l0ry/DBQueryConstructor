using DBQueryConstructor.Database.Models;

namespace DBQueryConstructor.Controls
{
    internal class TableTreeNode : TreeNode
    {
        public TableTreeNode(TableModel table) : base($"{table.Schema}.{table.Name}")
        {
            Element = table;
            ImageKey = "datatable.png";
            SelectedImageKey = "datatable.png";
        }

        public TableModel Element { get; private set; }
    }
}