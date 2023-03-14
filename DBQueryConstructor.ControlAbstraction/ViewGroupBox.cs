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

    public QueryParameter Parameter { get; set; }

    public event EventHandler DataChanged;

    public void OnDataChanged() => DataChanged?.Invoke(this, EventArgs.Empty);
}