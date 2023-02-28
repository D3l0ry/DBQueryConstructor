namespace DBQueryConstructor.Controls.JoinPanels
{
    internal class JoinListView : ListViewPanel<JoinPanel>
    {
        public JoinListView() : base() { }

        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            if(drgevent.Data.GetDataPresent(typeof(TablePanel)))
            {
                TablePanel selectedPanel = (TablePanel)drgevent.Data.GetData(typeof(TablePanel));

                if(selectedPanel.Parameter)
                {
                    return;
                }

                drgevent.Effect = DragDropEffects.Move;
            }
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            if(drgevent.Data.GetData(typeof(TablePanel)) is TablePanel selectedTablePanel)
            {
                bool isExists = Panels.Any(currentTablePanel => currentTablePanel.Model == selectedTablePanel);

                if(isExists)
                {
                    string message = "Такая таблица уже добавлена в присоединение таблиц!";
                    string title = "Ошибка добавления таблицы";

                    MessageBox
                        .Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }

                JoinPanel newJoin = new JoinPanel(selectedTablePanel);
                newJoin.Dock = DockStyle.Top;
                newJoin.DataChanged += JoinDataChanged;

                Controls.Add(newJoin);
            }
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            JoinPanel removedPanel = (JoinPanel)e.Control;
            string removedPanelTableName = removedPanel.Text;

            ClearJoinMainTableColumns(removedPanelTableName);
            base.OnControlRemoved(e);
        }

        private void JoinDataChanged(object sender, EventArgs e) => OnDataChanged();

        public void ClearJoinMainTableColumns(string table)
        {
            IEnumerable<JoinPanel> joinPanels = Panels
                .Where(currentJoinPanel => currentJoinPanel.Parameter.MainColumnTable?.GetTableName() == table);

            foreach(JoinPanel currentJoinPanel in joinPanels)
            {
                currentJoinPanel.JoinMainTableColumn.SelectedIndex = -1;
            }
        }
    }
}