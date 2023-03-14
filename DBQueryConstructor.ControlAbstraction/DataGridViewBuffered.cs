namespace DBQueryConstructor.ControlAbstraction;

public class DataGridViewBuffered : DataGridView
{
    protected override bool DoubleBuffered => true;
}