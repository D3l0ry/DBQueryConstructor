using DBQueryConstructor.DatabaseInteractions.Models;

namespace DBQueryConstructor.Controls.DatabasePanels
{
    internal class TableTreeNode : TreeNode, IComparable<TableTreeNode>
    {
        public TableTreeNode(TableModel table) : base($"{table.Schema}.{table.Name}")
        {
            Element = table;
            ImageKey = "datatable.png";
            SelectedImageKey = "datatable.png";
        }

        public TableModel Element { get; private set; }

        public int CompareTo(TableTreeNode other) => Text.CompareTo(other.Text);
    }
}