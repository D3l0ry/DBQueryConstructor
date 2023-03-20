using System.Collections.ObjectModel;

using DBQueryConstructor.ControlAbstraction;
using DBQueryConstructor.Controls.ColumnPanels;
using DBQueryConstructor.Controls.TablePanels;
using DBQueryConstructor.DatabaseInteractions.Models;

namespace DBQueryConstructor.Controls;

/// <summary>
/// Модель таблицы базы данных в виде панели
/// </summary>
/// <remarks>bool значение с именем Parameter обозначанет, что панель является главной</remarks>
internal class TablePanel : ViewGroupBox<TableModel, TableParameter>
{
    private readonly Panel _ColumnPanel;
    private readonly ReadOnlyCollection<ColumnPanel> _QueryColumns;
    private readonly List<ConditionPanel> _QueryConditions;

    public TablePanel(TableModel table) : base(table)
    {
        _ColumnPanel = new Panel();
        _QueryConditions = new List<ConditionPanel>();

        Parameter.Table = table;
        AutoSize = true;
        MinimumSize = new Size(175, 50);
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        Padding = new Padding(5, 1, 5, 5);

        FillPanel();

        ColumnPanel[] queryColumns = GetQueryColumns();
        _QueryColumns = new ReadOnlyCollection<ColumnPanel>(queryColumns);
    }

    public IEnumerable<ColumnCheckBox> Columns => _ColumnPanel.Controls.OfType<ColumnCheckBox>().Reverse();

    public IEnumerable<ColumnCheckBox> CheckedColumns => Columns.Where(currentCheckBox => currentCheckBox.Checked);

    public ReadOnlyCollection<ColumnPanel> QueryColumns => _QueryColumns;

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

    private ColumnPanel[] GetQueryColumns()
    {
        List<ColumnPanel> labels = new List<ColumnPanel>();

        foreach (ColumnCheckBox currentTablePanelCheckBox in Columns)
        {
            ColumnPanel newFieldLabel = new ColumnPanel(currentTablePanelCheckBox);

            labels.Add(newFieldLabel);
        }

        return labels.ToArray();
    }

    private void FillPanel()
    {
        Panel topPanel = new Panel();
        Label topPanelLabel = new Label();
        Stack<ColumnCheckBox> checkBoxes = new Stack<ColumnCheckBox>(Model.Columns.Length);

        _ColumnPanel.AutoSize = true;
        _ColumnPanel.Dock = DockStyle.Fill;
        _ColumnPanel.Enabled = false;

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
            newColumnCheckBox.Dock = DockStyle.Top;
            newColumnCheckBox.Text = currentColumn.Name;
            newColumnCheckBox.CheckedChanged += CheckBox_CheckedChanged;

            checkBoxes.Push(newColumnCheckBox);
        }

        _ColumnPanel.Controls.AddRange(checkBoxes.ToArray());
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