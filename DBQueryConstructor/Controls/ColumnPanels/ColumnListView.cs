using DBQueryConstructor.ControlAbstraction;

namespace DBQueryConstructor.Controls.ColumnPanels;

internal class ColumnListView : ListViewPanel<ColumnPanel>
{
    public ColumnListView() : base() { }

    protected override void OnControlAdded(ControlEventArgs e)
    {
        ColumnPanel addedColumnPanel = (ColumnPanel)e.Control;

        addedColumnPanel.DataChanged += Panel_DataChanged;
    }

    private void Panel_DataChanged(object sender, EventArgs e) => OnDataChanged();
}