using System.Collections.ObjectModel;

using DBQueryConstructor.ControlAbstraction;
using DBQueryConstructor.Controls.ColumnPanels;
using DBQueryConstructor.DatabaseInteractions.Models;
using DBQueryConstructor.Parameters;

namespace DBQueryConstructor.Controls;

/// <summary>
/// Модель таблицы базы данных в виде панели
/// </summary>
/// <remarks>bool значение с именем Parameter обозначанет, что панель является главной</remarks>
internal class TablePanel : ViewGroupBox<TableModel, TableParameter>
{
    private TableLayoutPanel _ColumnPanel;
    private List<ColumnPanel> _QueryColumns;
    private List<ConditionPanel> _QueryConditions;

    public TablePanel(TableModel table) : base(table)
    {
        _ColumnPanel = new TableLayoutPanel();
        _QueryColumns = new List<ColumnPanel>();
        _QueryConditions = new List<ConditionPanel>();

        Parameter.Table = table;
        AutoSize = true;
        MinimumSize = new Size(175, 50);
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        Padding = new Padding(5, 1, 5, 5);
    }

    public IEnumerable<ColumnCheckBox> Columns => _ColumnPanel.Controls.OfType<ColumnCheckBox>();

    public IEnumerable<ColumnCheckBox> CheckedColumns => Columns.Where(currentCheckBox => currentCheckBox.Checked);

    public ReadOnlyCollection<ColumnPanel> QueryColumns => new ReadOnlyCollection<ColumnPanel>(_QueryColumns);

    public List<ConditionPanel> QueryConditions => _QueryConditions;

    public JoinPanel Join { get; set; }

    public bool ColumnEnable
    {
        get => _ColumnPanel.Enabled;
        set
        {
            _ColumnPanel.Enabled = value;
            OnDataChanged();
        }
    }

    protected override void InitializeComponent()
    {
        Panel topPanel = new Panel();
        Label topPanelLabel = new Label();

        _ColumnPanel.AutoSize = true;
        _ColumnPanel.Dock = DockStyle.Fill;

        topPanel.BackColor = Color.Aqua;
        topPanel.BorderStyle = BorderStyle.FixedSingle;
        topPanel.Dock = DockStyle.Top;
        topPanel.Width = 50;
        topPanel.Height = 25;
        topPanel.MouseDown += Panel_MouseDown;
        topPanel.Controls.Add(topPanelLabel);

        topPanelLabel.Text = Model.GetTableName();
        topPanelLabel.Enabled = false;
        topPanelLabel.Dock = DockStyle.Top;

        foreach (TableColumnModel currentColumn in Model.Columns)
        {
            ColumnCheckBox newColumnCheckBox = new ColumnCheckBox(currentColumn);
            ColumnPanel newColumnPanel = new ColumnPanel(newColumnCheckBox);

            newColumnCheckBox.Dock = DockStyle.Top;
            newColumnCheckBox.Text = currentColumn.Name;
            newColumnCheckBox.CheckedChanged += CheckBox_CheckedChanged;

            _QueryColumns.Add(newColumnPanel);
            _ColumnPanel.Controls.Add(newColumnCheckBox);
        }

        Controls.Add(_ColumnPanel);
        Controls.Add(topPanel);
    }

    private void Panel_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Left)
        {
            return;
        }

        DoDragDrop(this, DragDropEffects.Move);
    }

    private void CheckBox_CheckedChanged(object sender, EventArgs e) => OnDataChanged();
}