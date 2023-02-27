using DBQueryConstructor.Database.Models;

namespace DBQueryConstructor.Controls
{
    internal class ColumnCheckBox : CheckBox
    {
        private readonly TablePanel _Panel;
        private readonly TableColumnModel _Column;

        public ColumnCheckBox(TablePanel panel, TableColumnModel column) : base()
        {
            if (panel == null)
            {
                throw new ArgumentNullException(nameof(panel));
            }

            if (column == null)
            {
                throw new ArgumentNullException(nameof(column));
            }

            _Panel = panel;
            _Column = column;
        }

        public TablePanel TablePanel => _Panel;

        public TableColumnModel Column => _Column;
    }
}