using DBQueryConstructor.ControlAbstraction;

namespace DBQueryConstructor.Controls.ConditionPanels
{
    internal class ConditionListView : ListViewPanel<ConditionPanel>
    {
        public ConditionListView() : base() { }

        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            bool isDataTablePanel = drgevent.Data.GetDataPresent(typeof(TablePanel));

            if (!isDataTablePanel)
            {
                return;
            }

            TablePanel selectedPanel = (TablePanel)drgevent.Data.GetData(typeof(TablePanel));

            if (!selectedPanel.ColumnEnable)
            {
                return;
            }

            drgevent.Effect = DragDropEffects.Move;
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            TablePanel selectedPanel = (TablePanel)drgevent.Data.GetData(typeof(TablePanel));
            ConditionPanel newConditionPanel = new ConditionPanel(selectedPanel);

            newConditionPanel.Dock = DockStyle.Top;
            newConditionPanel.DataChanged += ConditionDataChanged;

            Controls.Add(newConditionPanel);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int index = 0;

            foreach (ConditionPanel currentPanel in Panels)
            {
                currentPanel.Parameter.Index = index++;
            }

            base.OnPaint(e);
        }

        private void ConditionDataChanged(object sender, EventArgs e) => OnDataChanged();
    }
}