using DBQueryConstructor.ControlAbstraction;
using DBQueryConstructor.Controls.DatabasePanels;
using DBQueryConstructor.DatabaseInteractions.Models;

namespace DBQueryConstructor.Controls.TablePanels;

internal class TableListView : ListViewPanel<TablePanel>
{
    private readonly ContextMenuStrip _contextMenuStrip;

    public TableListView() : base()
    {
        _contextMenuStrip = new ContextMenuStrip();

        FillContextMenu();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics graphics = e.Graphics;

        if (Controls.Count == 0)
        {
            const string message = "Первая добавленная таблица является главной и не подлежит удалению";
            Font textFont = new Font("Tahoma", 14);
            Brush lightGreen = Brushes.DimGray;
            SizeF messageMeasure = graphics.MeasureString(message, textFont);
            PointF point = new PointF((Width / 2) - (messageMeasure.Width / 2), Height / 2);

            graphics.DrawString(message, textFont, lightGreen, point);
        }

        base.OnPaint(e);
    }

    protected override void OnDragEnter(DragEventArgs drgevent)
    {
        if (!drgevent.Data.GetDataPresent(typeof(TableTreeNode)))
        {
            return;
        }

        drgevent.Effect = DragDropEffects.Move;
    }

    protected override void OnDragDrop(DragEventArgs drgevent)
    {
        TableTreeNode selectedTableNode = (TableTreeNode)drgevent.Data.GetData(typeof(TableTreeNode));

        bool isExists = Panels
            .Any(currentTablePanel => currentTablePanel.Model == selectedTableNode.Element);

        if (isExists)
        {
            const string message = "Такая таблица уже добавлена в конструктор!";
            const string title = "Ошибка добавления таблицы";

            MessageBox
                .Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        TablePanel newPanel = CreateTablePanel(selectedTableNode.Element);

        AddPanel(newPanel);
    }

    protected override void OnControlAdded(ControlEventArgs e)
    {
        TablePanel addedTablePanel = (TablePanel)e.Control;
        addedTablePanel.DataChanged += TablePanelDataChanged;

        OnDataChanged();
    }

    private void FillContextMenu()
    {
        ToolStripButton toolStripButton = new ToolStripButton();
        toolStripButton.Text = "Удалить";
        toolStripButton.Width = 50;
        toolStripButton.Click += ToolStripButton_Click;

        _contextMenuStrip.Items.Add(toolStripButton);
    }

    private void TablePanelDataChanged(object sender, EventArgs e) => OnDataChanged();

    private void ToolStripButton_Click(object sender, EventArgs e)
    {
        TablePanel parent = (TablePanel)_contextMenuStrip.SourceControl;

        if (parent == null)
        {
            return;
        }

        Controls.Remove(parent);
    }

    public TablePanel CreateTablePanel(TableModel model)
    {
        bool isMainTable = Controls.Count == 0;
        TablePanel newTablePanel = new TablePanel(model);

        if (!isMainTable)
        {
            newTablePanel.ContextMenuStrip = _contextMenuStrip;
        }

        newTablePanel.Parameter.IsMainTable = isMainTable;
        newTablePanel.ColumnEnable = isMainTable;

        return newTablePanel;
    }
}