namespace DBQueryConstructor.Controls;

internal class DataGridViewBuffered : DataGridView
{
    protected override bool DoubleBuffered => true;
}