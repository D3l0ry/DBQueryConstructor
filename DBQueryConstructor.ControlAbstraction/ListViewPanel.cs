namespace DBQueryConstructor.ControlAbstraction;

/// <summary>
/// Панель с массивом объектов выбранного наследника типа Control
/// Тип лучше указывать, который наследуется от ViewGroupBox
/// </summary>
/// <remarks>Тип лучше указывать, который наследуется от ViewGroupBox</remarks>
/// <typeparam name="PanelType"></typeparam>
public abstract class ListViewPanel<PanelType> : TableLayoutPanel where PanelType : GroupBox
{
    public ListViewPanel() : base() { }

    public IEnumerable<PanelType> Panels => Controls.OfType<PanelType>();

    public event EventHandler DataChanged;

    public void OnDataChanged() => DataChanged?.Invoke(this, EventArgs.Empty);

    public abstract void AddPanel(PanelType panel);
}