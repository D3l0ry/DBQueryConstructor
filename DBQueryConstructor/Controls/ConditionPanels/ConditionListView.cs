using DBQueryConstructor.ControlAbstraction;

namespace DBQueryConstructor.Controls.ConditionPanels;

internal class ConditionListView : ListViewPanel<ConditionPanel>
{
    public ConditionListView() : base() { }

    protected override void OnPaint(PaintEventArgs e)
    {
        int index = 0;

        foreach (ConditionPanel currentPanel in Panels)
        {
            currentPanel.Parameter.Index = index++;
        }

        base.OnPaint(e);
    }

    protected override void OnDragEnter(DragEventArgs drgevent)
    {
        bool isDataTablePanel = drgevent.Data.GetDataPresent(typeof(TablePanel));

        if (!isDataTablePanel)
        {
            return;
        }

        TablePanel selectedPanel = (TablePanel)drgevent.Data.GetData(typeof(TablePanel));

        if (!selectedPanel.ColumnEnable)
        {
            return;
        }

        drgevent.Effect = DragDropEffects.Move;
    }

    protected override void OnDragDrop(DragEventArgs drgevent)
    {
        TablePanel selectedPanel = (TablePanel)drgevent.Data.GetData(typeof(TablePanel));
        ConditionPanel newConditionPanel = CreateConditionPanel(selectedPanel);

        AddPanel(newConditionPanel);
    }

    protected override void OnControlAdded(ControlEventArgs e)
    {
        ConditionPanel conditionPanel = (ConditionPanel)e.Control;
        conditionPanel.DataChanged += ConditionDataChanged;

        conditionPanel.Model.QueryConditions.Add(conditionPanel);
        OnDataChanged();
    }

    public ConditionPanel CreateConditionPanel(TablePanel panel)
    {
        if (panel == null)
        {
            throw new ArgumentNullException(nameof(panel));
        }

        ConditionPanel newConditionPanel = new ConditionPanel(panel);
        newConditionPanel.Dock = DockStyle.Top;

        return newConditionPanel;
    }

    private void ConditionDataChanged(object sender, EventArgs e) => OnDataChanged();
}