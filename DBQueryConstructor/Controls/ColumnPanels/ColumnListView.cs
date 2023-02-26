using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBQueryConstructor.Controls.ColumnPanels
{
    internal class ColumnListView : ListViewPanel<ColumnPanel>
    {
        public ColumnListView():base() { }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            ColumnPanel newPanel = (ColumnPanel)e.Control;
            newPanel.DataChanged += Panel_DataChanged;

            base.OnControlAdded(e);
        }

        private void Panel_DataChanged(object sender, EventArgs e) => OnDataChanged();
    }
}