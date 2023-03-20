using DBQueryConstructor.ControlAbstraction;

namespace DBQueryConstructor.Controls.ColumnPanels;

internal class ColumnListView : ListViewPanel<ColumnPanel>
{
    public ColumnListView() : base() { }

    protected override void OnControlAdded(ControlEventArgs e)
    {
        ColumnPanel newPanel = (ColumnPanel)e.Control;
        newPanel.DataChanged += Panel_DataChanged;

        base.OnControlAdded(e);
    }

    public override void AddPanel(ColumnPanel panel)
    {
        if (panel == null)
        {
            throw new ArgumentNullException(nameof(panel));
        }

        Controls.Add(panel);
    }

    private void Panel_DataChanged(object sender, EventArgs e) => OnDataChanged();
}