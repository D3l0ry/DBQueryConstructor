using DBQueryConstructor.ControlAbstraction;

namespace DBQueryConstructor.Controls.JoinPanels
{
    internal class JoinListView : ListViewPanel<JoinPanel>
    {
        public JoinListView() : base() { }

        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            if (!drgevent.Data.GetDataPresent(typeof(TablePanel)))
            {
                return;
            }

            TablePanel selectedPanel = (TablePanel)drgevent.Data.GetData(typeof(TablePanel));

            if (selectedPanel.Parameter)
            {
                return;
            }

            drgevent.Effect = DragDropEffects.Move;
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            TablePanel selectedTablePanel = (TablePanel)drgevent.Data.GetData(typeof(TablePanel));

            bool isExists = Panels.Any(currentTablePanel => currentTablePanel.Model == selectedTablePanel);

            if (isExists)
            {
                const string message = "Такая таблица уже добавлена в присоединение таблиц!";
                const string title = "Ошибка добавления таблицы";

                MessageBox
                    .Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            JoinPanel newJoin = new JoinPanel(selectedTablePanel);

            newJoin.Dock = DockStyle.Top;
            newJoin.DataChanged += JoinDataChanged;

            Controls.Add(newJoin);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int index = 0;

            foreach (JoinPanel currentPanel in Panels)
            {
                currentPanel.Parameter.Index = index++;
            }

            base.OnPaint(e);
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            JoinPanel removedPanel = (JoinPanel)e.Control;

            ClearJoinMainTableColumns(removedPanel);
            base.OnControlRemoved(e);
        }

        private void JoinDataChanged(object sender, EventArgs e) => OnDataChanged();

        public void ClearJoinMainTableColumns(JoinPanel panel)
        {
            string removedPanelTableName = panel.Text;

            IEnumerable<JoinPanel> joinPanels = Panels
                .Where(currentJoinPanel =>
                    currentJoinPanel.Parameter.MainColumnTable?.GetTableName() == removedPanelTableName);

            foreach (JoinPanel currentJoinPanel in joinPanels)
            {
                currentJoinPanel.JoinMainTableColumn.SelectedIndex = -1;
            }
        }
    }
}