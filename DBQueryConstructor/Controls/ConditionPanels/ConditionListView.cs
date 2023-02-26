namespace DBQueryConstructor.Controls.ConditionPanels
{
    internal class ConditionListView : ListViewPanel<ConditionPanel>
    {
        public ConditionListView() : base() { }

        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            if (drgevent.Data.GetDataPresent(typeof(TablePanel)))
            {
                TablePanel selectedPanel = (TablePanel)drgevent.Data.GetData(typeof(TablePanel));

                if (!selectedPanel.ColumnEnable)
                {
                    return;
                }

                drgevent.Effect = DragDropEffects.Move;
            }
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            if (drgevent.Data.GetData(typeof(TablePanel)) is TablePanel selectedTablePanel)
            {
                ConditionPanel newConditionPanel = new ConditionPanel(selectedTablePanel);
                newConditionPanel.Dock = DockStyle.Top;
                newConditionPanel.DataChanged += ConditionDataChanged;

                Controls.Add(newConditionPanel);
            }
        }

        private void ConditionDataChanged(object sender, EventArgs e) => OnDataChanged();
    }
}