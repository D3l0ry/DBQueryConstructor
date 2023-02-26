using System.Collections.ObjectModel;

using DBQueryConstructor.Controls.ColumnPanels;
using DBQueryConstructor.Database.Models;
using DBQueryConstructor.QueryInteractions;

namespace DBQueryConstructor.Controls
{
    internal class TablePanel : ViewGroupBox<TableModel, bool>
    {
        private readonly Panel _ColumnPanel;
        private readonly ReadOnlyCollection<ColumnPanel> _QueryColumns;
        private readonly List<ConditionPanel> _QueryConditions;

        public TablePanel(TableModel table) : base(table)
        {
            _ColumnPanel = new Panel();
            _QueryConditions = new List<ConditionPanel>();

            AutoSize = true;
            MinimumSize = new Size(175, 50);
            AutoSizeMode = AutoSizeMode.GrowAndShrink;

            FillPanel();

            ColumnPanel[] queryColumns = GetQueryColumns();
            _QueryColumns = new ReadOnlyCollection<ColumnPanel>(queryColumns);
        }

        public IEnumerable<ColumnCheckBox> Columns => _ColumnPanel.Controls.OfType<ColumnCheckBox>().Reverse();

        public IEnumerable<ColumnPanel> QueryColumns => _QueryColumns;

        public List<ConditionPanel> QueryConditions => _QueryConditions;

        public JoinPanel Join { get; set; }

        public new bool Parameter { get; set; }

        public bool ColumnEnable
        {
            get => _ColumnPanel.Enabled;
            set => _ColumnPanel.Enabled = value;
        }

        private ColumnPanel[] GetQueryColumns()
        {
            List<ColumnPanel> labels = new List<ColumnPanel>();

            foreach (ColumnCheckBox currentTablePanelCheckBox in Columns)
            {
                ColumnPanel newFieldLabel = new ColumnPanel(currentTablePanelCheckBox);

                labels.Add(newFieldLabel);
            }

            return labels.ToArray();
        }

        private void FillPanel()
        {
            Panel topPanel = new Panel();
            Label topPanelLabel = new Label();
            Stack<ColumnCheckBox> checkBoxes = new Stack<ColumnCheckBox>(Model.Columns.Length);

            _ColumnPanel.AutoSize = true;
            _ColumnPanel.Dock = DockStyle.Fill;
            _ColumnPanel.Enabled = false;

            topPanel.BackColor = Color.Aqua;
            topPanel.BorderStyle = BorderStyle.FixedSingle;
            topPanel.Dock = DockStyle.Top;
            topPanel.Width = 50;
            topPanel.Height = 25;
            topPanel.Enabled = false;

            topPanel.Controls.Add(topPanelLabel);

            topPanelLabel.Text = Model.GetTableName();
            topPanelLabel.Dock = DockStyle.Top;

            foreach (TableColumnModel currentColumn in Model.Columns)
            {
                ColumnCheckBox newColumnCheckBox = new ColumnCheckBox(this,currentColumn);
                newColumnCheckBox.Dock = DockStyle.Top;
                newColumnCheckBox.Text = currentColumn.Name;
                newColumnCheckBox.CheckedChanged += CheckBox_CheckedChanged;

                checkBoxes.Push(newColumnCheckBox);
            }

            _ColumnPanel.Controls.AddRange(checkBoxes.ToArray());
            Controls.Add(_ColumnPanel);
            Controls.Add(topPanel);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            DoDragDrop(this, DragDropEffects.Move);

            base.OnMouseDown(e);
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e) => OnDataChanged();
    }
}