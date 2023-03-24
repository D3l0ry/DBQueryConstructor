using DBQueryConstructor.ControlAbstraction;

namespace DBQueryConstructor.Controls.ColumnPanels;

internal class ColumnListView : ListViewPanel<ColumnPanel>
{
    public ColumnListView() : base() { }

    protected override void OnControlAdded(ControlEventArgs e)
    {
        ColumnPanel newPanel = (ColumnPanel)e.Control;
        newPanel.DataChanged += Panel_DataChanged;
    }

    private void Panel_DataChanged(object sender, EventArgs e) => OnDataChanged();
}