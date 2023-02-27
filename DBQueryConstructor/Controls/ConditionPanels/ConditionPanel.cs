﻿using DBQueryConstructor.Database.Models;
using DBQueryConstructor.QueryInteractions;

namespace DBQueryConstructor.Controls
{
    internal class ConditionPanel : ViewGroupBox<TablePanel, QueryConditionParameter>
    {
        private readonly ComboBox _ConditionComboBox;
        private readonly ComboBox _ColumnComboBox;
        private readonly ComboBox _EqualComboBox;
        private readonly TextBox _ParameterValue;
        private readonly CheckBox _ParameterIsNull;
        private readonly Button _DeleteButton;

        public ConditionPanel(TablePanel panel) : base(panel)
        {
            _ConditionComboBox = new ComboBox();
            _ColumnComboBox = new ComboBox();
            _EqualComboBox = new ComboBox();
            _ParameterValue = new TextBox();
            _ParameterIsNull = new CheckBox();
            _DeleteButton = new Button();

            Text = Model.Model.GetTableName();
            BackColor = Color.Bisque;

            panel.QueryConditions.Add(this);

            FillPanel();
        }

        private void FillPanel()
        {
            QueryConditionType[] conditions = Enum.GetValues<QueryConditionType>();
            string[] equals = new string[] { "Равно", "Не равно", "Промежуток" };

            _ConditionComboBox.DataSource = conditions;
            _ConditionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _ConditionComboBox.Dock = DockStyle.Left;
            _ConditionComboBox.SelectedValueChanged += ConditionComboBox_SelectedValueChanged;
            _ConditionComboBox.SelectedValueChanged += ValueChanged;

            _ColumnComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _ColumnComboBox.DropDownWidth = 250;
            _ColumnComboBox.Dock = DockStyle.Left;
            _ColumnComboBox.DropDown += ColumnComboBox_DropDown;
            _ColumnComboBox.SelectedValueChanged += ColumnComboBox_SelectedValueChanged;
            _ColumnComboBox.SelectedValueChanged += ValueChanged;

            _EqualComboBox.DataSource = equals;
            _EqualComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _EqualComboBox.Dock = DockStyle.Left;
            _EqualComboBox.SelectedValueChanged += EqualComboBox_SelectedValueChanged;
            _EqualComboBox.SelectedValueChanged += ValueChanged;

            _ParameterValue.Width = 100;
            _ParameterValue.Dock = DockStyle.Left;
            _ParameterValue.TextChanged += ParameterValue_TextChanged;
            _ParameterValue.TextChanged += ValueChanged;

            _ParameterIsNull.Dock = DockStyle.Left;
            _ParameterIsNull.Text = "NULL";
            _ParameterIsNull.Padding = new Padding(7, 0, 0, 3);
            _ParameterIsNull.CheckedChanged += ParameterIsNull_CheckedChanged;
            _ParameterIsNull.CheckedChanged += ValueChanged;

            _DeleteButton.ForeColor = Color.Red;
            _DeleteButton.Text = "Удалить";
            _DeleteButton.FlatStyle = FlatStyle.Flat;
            _DeleteButton.Dock = DockStyle.Right;
            _DeleteButton.FlatAppearance.BorderSize = 1;
            _DeleteButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            _DeleteButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            _DeleteButton.Click += DeleteButton_Click;

            Control[] controls = new Control[]
            {
                _DeleteButton,
                _ParameterIsNull,
                _ParameterValue,
                _EqualComboBox,
                _ColumnComboBox,
                _ConditionComboBox
            };

            Controls.AddRange(controls);
        }

        private void ConditionComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            Parameter.Condition = (QueryConditionType)_ConditionComboBox.SelectedItem;
        }

        private void ColumnComboBox_DropDown(object sender, EventArgs e)
        {
            TableColumnModel[] columns = Model.Model.Columns;

            _ColumnComboBox.Items.Clear();
            _ColumnComboBox.Items.AddRange(columns);
        }

        private void ColumnComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            Parameter.Column = (TableColumnModel)_ColumnComboBox.SelectedItem;
        }

        private void EqualComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            Parameter.Equal = (string)_EqualComboBox.SelectedItem;
        }

        private void ParameterValue_TextChanged(object sender, EventArgs e)
        {
            Parameter.ParameterValue = _ParameterValue.Text;
        }

        private void ParameterIsNull_CheckedChanged(object sender, EventArgs e)
        {
            Parameter.IsNull = _ParameterIsNull.Checked;
        }

        private void ValueChanged(object sender, EventArgs e) => OnDataChanged();

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Model.QueryConditions.Remove(this);
            Parent.Controls.Remove(this);

            OnDataChanged();
        }
    }
}