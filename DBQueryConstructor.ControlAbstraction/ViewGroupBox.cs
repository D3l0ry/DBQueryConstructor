namespace DBQueryConstructor.ControlAbstraction;

public abstract class ViewGroupBox<TableModel, QueryParameter> : GroupBox where QueryParameter : new()
{
    private readonly TableModel _Model;

    public ViewGroupBox(TableModel model) : base()
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model));
        }

        _Model = model;
        Parameter = new QueryParameter();

        Padding = new Padding(5);
        Height = 50;
    }

    public TableModel Model => _Model;

    public virtual QueryParameter Parameter { get; private set; }

    public event EventHandler DataChanged;

    protected abstract void InitializeComponent();

    protected override void OnCreateControl()
    {
        InitializeComponent();
        base.OnCreateControl();
    }

    public virtual void OnDataChanged() => DataChanged?.Invoke(this, EventArgs.Empty);
}