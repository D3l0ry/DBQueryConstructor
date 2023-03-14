using DBQueryConstructor.ControlAbstraction;

namespace DBQueryConstructor.Controls.ColumnPanels
{
    internal class ColumnListView : ListViewPanel<ColumnPanel>
    {
        public ColumnListView() : base() { }

        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            if (!drgevent.Data.GetDataPresent(typeof(TablePanel)))
            {
                return;
            }

            drgevent.Effect = DragDropEffects.Move;
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            ColumnPanel newPanel = (ColumnPanel)e.Control;
            newPanel.DataChanged += Panel_DataChanged;

            base.OnControlAdded(e);
        }

        private void Panel_DataChanged(object sender, EventArgs e) => OnDataChanged();
    }
}