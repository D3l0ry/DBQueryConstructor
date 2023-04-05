using System.ComponentModel;

namespace DBQueryConstructor.ControlAbstraction;

public abstract class ViewGroupBox<TableModel, QueryParameter> : GroupBox where QueryParameter : new()
{
    private readonly TableModel _model;
    private readonly QueryParameter _parameter;

    public ViewGroupBox(TableModel model) : base()
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model));
        }

        _model = model;
        _parameter = new QueryParameter();

        if (_parameter is INotifyPropertyChanged notify)
        {
            notify.PropertyChanged += Notify_PropertyChanged;
        }

        Padding = new Padding(5);
        Height = 50;
    }

    public TableModel Model => _model;

    public virtual QueryParameter Parameter => _parameter;

    public event EventHandler DataChanged;

    protected abstract void InitializeComponent();

    protected override void OnCreateControl()
    {
        InitializeComponent();
        base.OnCreateControl();
    }

    private void Notify_PropertyChanged(object sender, PropertyChangedEventArgs e) => OnDataChanged();

    public virtual void OnDataChanged() => DataChanged?.Invoke(this, EventArgs.Empty);
}