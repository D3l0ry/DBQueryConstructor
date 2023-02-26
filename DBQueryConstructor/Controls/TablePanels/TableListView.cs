namespace DBQueryConstructor.Controls.TablePanels
{
    internal class TableListView : ListViewPanel<TablePanel>
    {
        public TableListView() : base() { }

        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            if (drgevent.Data.GetDataPresent(typeof(TableTreeNode)))
            {
                drgevent.Effect = DragDropEffects.Move;
            }
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            TableTreeNode selectedTableNode = (TableTreeNode)drgevent.Data.GetData(typeof(TableTreeNode));

            if (selectedTableNode == null)
            {
                return;
            }

            bool isExists = Controls
                .Cast<TablePanel>()
                .Any(currentTablePanel => currentTablePanel.Model == selectedTableNode.Element);

            if (isExists)
            {
                string message = "Такая таблица уже добавлена в конструктор!";
                string title = "Ошибка добавления таблицы";

                MessageBox
                    .Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            TablePanel newTablePanel = new TablePanel(selectedTableNode.Element);
            newTablePanel.Parameter = Controls.Count == 0;
            newTablePanel.ColumnEnable = newTablePanel.Parameter;
            newTablePanel.DataChanged += TablePanelDataChanged;

            Controls.Add(newTablePanel);
            OnDataChanged();
        }

        private void TablePanelDataChanged(object sender, EventArgs e) => OnDataChanged();
    }
}