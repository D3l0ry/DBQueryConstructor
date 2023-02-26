using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using DBQueryConstructor.Database.Models;
using DBQueryConstructor.QueryInteractions;

namespace DBQueryConstructor.Controls.ColumnPanels
{
    internal class ColumnPanel : ViewGroupBox<ColumnCheckBox, QueryField>
    {
        public ColumnPanel(ColumnCheckBox model) : base(model)
        {
            Text = model.Column.GetColumnName();
            BackColor = Color.Bisque;
            Dock = DockStyle.Top;

            Parameter.Column = model.Column;

            FillPanel();
        }

        private void FillPanel()
        {
            Label aliasLabel = new Label();
            aliasLabel.Dock = DockStyle.Left;
            aliasLabel.Text = "Псевдоним";

            TextBox aliasTextBox = new TextBox();
            aliasTextBox.Dock = DockStyle.Left;
            aliasTextBox.Width = 150;
            aliasTextBox.TextChanged += Alias_TextChanged;
            aliasTextBox.KeyPress += AliasTextBox_KeyPress;

            Controls.Add(aliasTextBox);
            Controls.Add(aliasLabel);
        }

        private void AliasTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '\b';
        }

        private void Alias_TextChanged(object sender, EventArgs e)
        {
            TextBox aliasTextBox = (TextBox)sender;

            Parameter.ColumnAlias = aliasTextBox.Text.Trim();

            OnDataChanged();
        }
    }
}