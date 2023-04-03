using DBQueryConstructor.ControlAbstraction;
using DBQueryConstructor.Parameters;

namespace DBQueryConstructor.Controls.ColumnPanels;

internal class ColumnPanel : ViewGroupBox<ColumnCheckBox, QueryFieldParameter>
{
    private readonly TextBox _AliasTextBox;

    public ColumnPanel(ColumnCheckBox model) : base(model)
    {
        _AliasTextBox = new TextBox();

        Text = model.Column.GetColumnName();
        BackColor = Color.Bisque;
        Dock = DockStyle.Top;

        Parameter.Column = model.Column;
    }

    protected override void InitializeComponent()
    {
        Label aliasLabel = new();

        aliasLabel.Dock = DockStyle.Left;
        aliasLabel.Text = "Псевдоним";

        _AliasTextBox.Dock = DockStyle.Left;
        _AliasTextBox.Width = 150;
        _AliasTextBox.KeyPress += AliasTextBox_KeyPress;
        _AliasTextBox.TextChanged += Alias_TextChanged;

        Controls.Add(_AliasTextBox);
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