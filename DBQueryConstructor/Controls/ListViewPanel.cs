namespace DBQueryConstructor.Controls
{
    /// <summary>
    /// Панель с массивом объектов выбранного наследника типа Control
    /// Тип лучше указывать, который наследуется от ViewGroupBox
    /// </summary>
    /// <remarks>Тип лучше указывать, который наследуется от ViewGroupBox</remarks>
    /// <typeparam name="PanelType"></typeparam>
    internal abstract class ListViewPanel<PanelType> : TableLayoutPanel where PanelType : GroupBox
    {
        public ListViewPanel() : base() { }

        public IEnumerable<PanelType> Panels => Controls.OfType<PanelType>();

        public event EventHandler DataChanged;

        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            if (drgevent.Data.GetDataPresent(typeof(TablePanel)))
            {
                drgevent.Effect = DragDropEffects.Move;
            }
        }

        public void OnDataChanged() => DataChanged?.Invoke(this, EventArgs.Empty);
    }
}