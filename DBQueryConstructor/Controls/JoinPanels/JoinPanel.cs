using DBQueryConstructor.Controls.JoinPanels;
using DBQueryConstructor.Controls.TablePanels;
using DBQueryConstructor.Database.Models;
using DBQueryConstructor.QueryInteractions;

namespace DBQueryConstructor.Controls
{
    internal class JoinPanel : ViewGroupBox<TablePanel, ForeignTableJoin>
    {
        private ComboBox _QueryJoinSelectComboBox;
        private ComboBox _QueryJoinTableSelectComboBox;
        private Label _QueryJoinEqualsLabel;
        private ComboBox _QueryJoinMainTableSelectComboBox;
        private Button _QueryJoinDeleteButton;

        public JoinPanel(TablePanel tablePanel) : base(tablePanel)
        {
            Text = Model.Model.GetTableName();
            BackColor = Color.Bisque;

            tablePanel.Join = this;

            FillPanel();
        }

        public ComboBox JoinMainTableColumn => _QueryJoinMainTableSelectComboBox;

        private void FillPanel()
        {
            QueryJoinType[] joins = Enum.GetValues<QueryJoinType>();

            _QueryJoinSelectComboBox = new ComboBox();
            _QueryJoinSelectComboBox.DataSource = joins;
            _QueryJoinSelectComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _QueryJoinSelectComboBox.Dock = DockStyle.Left;
            _QueryJoinSelectComboBox.SelectedValueChanged += QueryJoinSelectComboBox_SelectedValueChanged;
            _QueryJoinSelectComboBox.SelectedValueChanged += ComboBox_SelectedValueChanged;

            _QueryJoinTableSelectComboBox = new ComboBox();
            _QueryJoinTableSelectComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _QueryJoinTableSelectComboBox.Dock = DockStyle.Left;
            _QueryJoinTableSelectComboBox.DropDownWidth = 275;
            _QueryJoinTableSelectComboBox.Width = 275;
            _QueryJoinTableSelectComboBox.DropDown += QueryJoinTableSelectComboBox_DropDown;
            _QueryJoinTableSelectComboBox.SelectedValueChanged += QueryJoinTableSelectComboBox_SelectedIndexChanged;
            _QueryJoinTableSelectComboBox.SelectedValueChanged += ComboBox_SelectedValueChanged;

            _QueryJoinEqualsLabel = new Label();
            _QueryJoinEqualsLabel.Text = "=";
            _QueryJoinEqualsLabel.Width = 17;
            _QueryJoinEqualsLabel.Font = new Font("Tahoma", 11);
            _QueryJoinEqualsLabel.Dock = DockStyle.Left;

            _QueryJoinMainTableSelectComboBox = new ComboBox();
            _QueryJoinMainTableSelectComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _QueryJoinMainTableSelectComboBox.Dock = DockStyle.Left;
            _QueryJoinMainTableSelectComboBox.DropDownWidth = 275;
            _QueryJoinMainTableSelectComboBox.Width = 275;
            _QueryJoinMainTableSelectComboBox.DropDown += QueryJoinMainTableSelectComboBox_DropDown;
            _QueryJoinMainTableSelectComboBox.SelectedValueChanged += QueryJoinMainTableSelectComboBox_SelectedValueChanged;
            _QueryJoinMainTableSelectComboBox.SelectedValueChanged += ComboBox_SelectedValueChanged;

            _QueryJoinDeleteButton = new Button();
            _QueryJoinDeleteButton.ForeColor = Color.Red;
            _QueryJoinDeleteButton.Text = "Удалить";
            _QueryJoinDeleteButton.FlatStyle = FlatStyle.Flat;
            _QueryJoinDeleteButton.Dock = DockStyle.Right;
            _QueryJoinDeleteButton.FlatAppearance.BorderSize = 1;
            _QueryJoinDeleteButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            _QueryJoinDeleteButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            _QueryJoinDeleteButton.Click += QueryJoinDeleteButton_Click;

            Control[] controls = new Control[]
            {
                _QueryJoinDeleteButton,
                _QueryJoinMainTableSelectComboBox,
                _QueryJoinEqualsLabel ,
                _QueryJoinTableSelectComboBox,
                _QueryJoinSelectComboBox
            };

            Controls.AddRange(controls);
        }

        private void QueryJoinSelectComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            Parameter.Join = (QueryJoinType)_QueryJoinSelectComboBox.SelectedItem;
        }

        private void QueryJoinTableSelectComboBox_DropDown(object sender, EventArgs e)
        {
            TableColumnModel[] columns = Model.Model.Columns;

            ((JoinListView)Parent).ClearJoinMainTableColumns(Text);

            _QueryJoinTableSelectComboBox.SelectedIndex = -1;
            _QueryJoinMainTableSelectComboBox.SelectedIndex = -1;

            _QueryJoinTableSelectComboBox.Items.Clear();
            _QueryJoinMainTableSelectComboBox.Items.Clear();
            _QueryJoinTableSelectComboBox.Items.AddRange(columns);
        }

        private void QueryJoinTableSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_QueryJoinTableSelectComboBox.SelectedIndex == -1)
            {
                Parameter.JoinedColumnTable = null;

                return;
            }

            Parameter.JoinedColumnTable = (TableColumnModel)_QueryJoinTableSelectComboBox.SelectedItem;
        }

        private void QueryJoinMainTableSelectComboBox_DropDown(object sender, EventArgs e)
        {
            ((JoinListView)Parent).ClearJoinMainTableColumns(Text);

            _QueryJoinMainTableSelectComboBox.SelectedIndex = -1;
            _QueryJoinMainTableSelectComboBox.Items.Clear();

            if(_QueryJoinTableSelectComboBox.SelectedIndex == -1)
            {
                return;
            }

            TableColumnModel selectedJoinColumn = (TableColumnModel)_QueryJoinTableSelectComboBox.SelectedItem;

            IEnumerable<JoinPanel> joinPanels = ((JoinListView)Parent).Panels
                .Take(Array.IndexOf(Parent.Controls.OfType<JoinPanel>().ToArray(), this) + 1);

            IEnumerable<TablePanel> tablePanels = ((TableListView)Model.Parent).Panels
                .Where(currentPanel => currentPanel.Model.GetTableName() != selectedJoinColumn.GetTableName() && currentPanel.ColumnEnable);

            if(Parent.Controls.Count > 1)
            {
                tablePanels = tablePanels.Where(currentPanel =>
                    joinPanels.Any(currentJoin => currentJoin.Model == currentPanel) ||
                    currentPanel.Parameter);
            }

            TableColumnModel[] columns = tablePanels
               .SelectMany(currentPanel => currentPanel.Model.Columns)
               .ToArray();

            _QueryJoinMainTableSelectComboBox.Items.Clear();
            _QueryJoinMainTableSelectComboBox.Items.AddRange(columns);
        }

        private void QueryJoinMainTableSelectComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if(_QueryJoinMainTableSelectComboBox.SelectedIndex == -1)
            {
                Parameter.MainColumnTable = null;

                return;
            }

            TableColumnModel selectedJoinColumn = (TableColumnModel)_QueryJoinMainTableSelectComboBox.SelectedItem;

            Parameter.MainColumnTable = selectedJoinColumn;
        }

        private void ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            Model.ColumnEnable = Parameter.Validate();

            OnDataChanged();
        }

        private void QueryJoinDeleteButton_Click(object sender, EventArgs e)
        {
            Model.ColumnEnable = false;
            Model.Join = null;

            ((JoinListView)Parent).ClearJoinMainTableColumns(Text);

            Parent.Controls.Remove(this);

            OnDataChanged();
        }
    }
}