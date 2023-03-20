using System.ComponentModel;
using System.Text;

using DBQueryConstructor.DatabaseInteractions.Models;
using DBQueryConstructor.Properties;

namespace DBQueryConstructor.Controls.DatabasePanels;

internal class DatabasePanel : Panel
{
    private readonly TreeView _DatabaseTableTreeView;

    public DatabasePanel() : base()
    {
        _DatabaseTableTreeView = new TreeView();
        _DatabaseTableTreeView.AllowDrop = true;
        _DatabaseTableTreeView.BackColor = Color.White;
        _DatabaseTableTreeView.BorderStyle = BorderStyle.None;
        _DatabaseTableTreeView.Dock = DockStyle.Fill;
        _DatabaseTableTreeView.ImageIndex = 0;
        _DatabaseTableTreeView.Indent = 19;
        _DatabaseTableTreeView.ItemHeight = 21;
        _DatabaseTableTreeView.Location = new Point(0, 25);
        _DatabaseTableTreeView.Name = "databaseTableTreeView";
        _DatabaseTableTreeView.SelectedImageIndex = 0;
        _DatabaseTableTreeView.Size = new Size(198, 484);
        _DatabaseTableTreeView.TabIndex = 1;
        _DatabaseTableTreeView.ItemDrag += DatabaseTableTreeView_ItemDrag;
        _DatabaseTableTreeView.DragEnter += DatabaseTableTreeView_DragEnter;

        FillPanel();
    }

    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public ImageList ImageList
    {
        get => _DatabaseTableTreeView.ImageList;
        set => _DatabaseTableTreeView.ImageList = value;
    }

    public event EventHandler CloseConnection;

    private void FillPanel()
    {
        ToolStripButton openConnectionDatabaseToolStripButton = new ToolStripButton();
        openConnectionDatabaseToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
        openConnectionDatabaseToolStripButton.Image = Resources.Open_Database;
        openConnectionDatabaseToolStripButton.ImageTransparentColor = Color.Magenta;
        openConnectionDatabaseToolStripButton.Name = "openConnectionDatabaseToolStripButton";
        openConnectionDatabaseToolStripButton.Size = new Size(23, 22);
        openConnectionDatabaseToolStripButton.ToolTipText = "Открыть соединение";
        openConnectionDatabaseToolStripButton.Click += OpenConnectionDatabaseToolStripButton_Click;

        ToolStripButton closeConnectionDatabaseToolStripButton = new ToolStripButton();
        closeConnectionDatabaseToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
        closeConnectionDatabaseToolStripButton.Image = Resources.Close_Database;
        closeConnectionDatabaseToolStripButton.ImageTransparentColor = Color.Magenta;
        closeConnectionDatabaseToolStripButton.Name = "closeConnectionDatabaseToolStripButton";
        closeConnectionDatabaseToolStripButton.Size = new Size(23, 22);
        closeConnectionDatabaseToolStripButton.ToolTipText = "Закрыть соединение";
        closeConnectionDatabaseToolStripButton.Click += CloseConnectionDatabaseToolStripButton_Click;

        ToolStrip databaseToolStrip = new ToolStrip();
        databaseToolStrip.BackColor = Color.White;
        databaseToolStrip.GripStyle = ToolStripGripStyle.Hidden;
        databaseToolStrip.Location = new Point(0, 0);
        databaseToolStrip.Name = "databaseToolStrip";
        databaseToolStrip.RenderMode = ToolStripRenderMode.System;
        databaseToolStrip.Size = new Size(198, 25);
        databaseToolStrip.TabIndex = 0;
        databaseToolStrip.Items.AddRange(new ToolStripItem[]
            {
                openConnectionDatabaseToolStripButton,
                closeConnectionDatabaseToolStripButton
            });

        Controls.Add(_DatabaseTableTreeView);
        Controls.Add(databaseToolStrip);
    }

    private void FillTableTreeView()
    {
        TreeNode rootNode = _DatabaseTableTreeView.Nodes.Add(Program.UsedDatabase.Connection.Database);
        rootNode.ImageKey = "databaseview";
        rootNode.SelectedImageKey = "databaseview";

        List<TableTreeNode> nodes = new List<TableTreeNode>();
        TableModel[] tables = Program.UsedDatabase.Table.ToArray();
        TableColumnModel[] tablesColumns = Program.UsedDatabase.TableColumn.ToArray();

        if (tablesColumns.Length == 0)
        {
            return;
        }

        TableConstraintModel[] tableConstraints = Program.UsedDatabase.TableConstraint.ToArray();
        ColumnConstraintModel[] columnConstraints = Program.UsedDatabase.ColumnConstraint.ToArray();
        IEnumerable<IGrouping<string, TableColumnModel>> tableGroup = tablesColumns
            .GroupBy(currentColumn => $"{currentColumn.TableSchema}.{currentColumn.TableName}");

        foreach (IGrouping<string, TableColumnModel> currentGroup in tableGroup)
        {
            TableModel selectedTable = tables
                .FirstOrDefault(currentTable => $"{currentTable.Schema}.{currentTable.Name}" == currentGroup.Key);

            if (selectedTable == null)
            {
                continue;
            }

            selectedTable.Columns = currentGroup.ToArray();

            TableTreeNode tableTreeNode = new TableTreeNode(selectedTable);
            TableConstraintModel[] selectedTableConstraints = tableConstraints
                .Where(currentTableConstraint =>
                    $"{currentTableConstraint.SchemaName}.{currentTableConstraint.TableName}" == currentGroup.Key)
                .ToArray();

            nodes.Add(tableTreeNode);

            foreach (TableColumnModel currentColumn in currentGroup)
            {
                StringBuilder columnBuilder = new StringBuilder($"{currentColumn.Name} (");

                foreach (TableConstraintModel currentTableConstraint in selectedTableConstraints)
                {
                    ColumnConstraintModel selectedColumnConstraint = columnConstraints
                        .FirstOrDefault(currentColumnConstraint =>
                            currentColumnConstraint.SchemaName == currentTableConstraint.SchemaName &&
                            currentColumnConstraint.TableName == currentTableConstraint.TableName &&
                            currentColumnConstraint.ColumnName == currentColumn.Name &&
                            currentColumnConstraint.Name == currentTableConstraint.Name);

                    if (selectedColumnConstraint == null)
                    {
                        continue;
                    }

                    currentColumn.Constraint = selectedColumnConstraint;

                    columnBuilder.Append($"{currentTableConstraint.Type}, ");

                    break;
                }

                columnBuilder.Append($"{currentColumn.Type}, ");
                columnBuilder.Append($"{(currentColumn.IsNullable.Equals("YES") ? "null" : "not null")})");

                TreeNode tableColumnNode = new TreeNode(columnBuilder.ToString());
                tableColumnNode.ImageKey = "column.png";
                tableColumnNode.SelectedImageKey = "column.png";

                tableTreeNode.Nodes.Add(tableColumnNode);
            }
        }

        nodes.Sort();
        rootNode.Nodes.AddRange(nodes.ToArray());
        rootNode.Expand();
    }

    private void OpenConnectionDatabaseToolStripButton_Click(object sender, EventArgs e)
    {
        ConnectionForm connectionForm = new ConnectionForm();
        DialogResult result = connectionForm.ShowDialog();

        if (result == DialogResult.Cancel)
        {
            return;
        }

        _DatabaseTableTreeView.Nodes.Clear();
        OnClosedConnection();
        FillTableTreeView();
    }

    private void CloseConnectionDatabaseToolStripButton_Click(object sender, EventArgs e)
    {
        _DatabaseTableTreeView.Nodes.Clear();
        OnClosedConnection();

        Program.UsedDatabase?.Dispose();
        Program.UsedDatabase = null;
    }

    private void DatabaseTableTreeView_ItemDrag(object sender, ItemDragEventArgs e)
    {
        if (e.Item is not TableTreeNode)
        {
            return;
        }

        DoDragDrop(e.Item, DragDropEffects.Move);
    }

    private void DatabaseTableTreeView_DragEnter(object sender, DragEventArgs e)
    {
        if (!e.Data.GetDataPresent(typeof(TablePanel)))
        {
            return;
        }

        TablePanel selectedTablePanel = (TablePanel)e.Data.GetData(typeof(TablePanel));

        if (selectedTablePanel.Parameter.IsMainTable)
        {
            return;
        }

        e.Effect = DragDropEffects.Move;
    }

    public void OnClosedConnection() => CloseConnection?.Invoke(this, EventArgs.Empty);
}