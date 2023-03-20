using DBQueryConstructor.ControlAbstraction;

namespace DBQueryConstructor.Controls.ColumnPanels;

internal class ColumnPanel : ViewGroupBox<ColumnCheckBox, QueryField>
{
    private readonly TextBox _AliasTextBox;

    public ColumnPanel(ColumnCheckBox model) : base(model)
    {
        _AliasTextBox = new TextBox();

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

        _AliasTextBox.Dock = DockStyle.Left;
        _AliasTextBox.Width = 150;
        _AliasTextBox.TextChanged += Alias_TextChanged;
        _AliasTextBox.KeyPress += AliasTextBox_KeyPress;

        Controls.Add(_AliasTextBox);
        Controls.Add(aliasLabel);
    }

    public override QueryField Parameter
    {
        get => base.Parameter;
        set
        {
            base.Parameter = value;

            if (_AliasTextBox != null)
            {
                _AliasTextBox.Text = value.ColumnAlias;
            }
        }
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