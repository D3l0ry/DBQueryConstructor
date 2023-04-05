using DBQueryConstructor.ControlAbstraction;

namespace DBQueryConstructor
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.treeViewImageList = new System.Windows.Forms.ImageList(this.components);
            this.queryConstructorTabControl = new System.Windows.Forms.TabControl();
            this.mainFormSplitContainer = new System.Windows.Forms.SplitContainer();
            this.databasePanel = new DBQueryConstructor.Controls.DatabasePanels.DatabasePanel();
            this.queryConstructorToolStrip = new System.Windows.Forms.ToolStrip();
            this.clearConstructorToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.addNewConstructorToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.queryConstructorOpenToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.queryConstructorSaveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.queryConstructorQueryExecuteButton = new System.Windows.Forms.ToolStripButton();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.mainFormSplitContainer)).BeginInit();
            this.mainFormSplitContainer.Panel1.SuspendLayout();
            this.mainFormSplitContainer.Panel2.SuspendLayout();
            this.mainFormSplitContainer.SuspendLayout();
            this.queryConstructorToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewImageList
            // 
            this.treeViewImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.treeViewImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeViewImageList.ImageStream")));
            this.treeViewImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.treeViewImageList.Images.SetKeyName(0, "databaseview.png");
            this.treeViewImageList.Images.SetKeyName(1, "datatable.png");
            this.treeViewImageList.Images.SetKeyName(2, "column.png");
            // 
            // queryConstructorTabControl
            // 
            this.queryConstructorTabControl.AllowDrop = true;
            this.queryConstructorTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryConstructorTabControl.ItemSize = new System.Drawing.Size(31, 20);
            this.queryConstructorTabControl.Location = new System.Drawing.Point(0, 25);
            this.queryConstructorTabControl.Name = "queryConstructorTabControl";
            this.queryConstructorTabControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.queryConstructorTabControl.SelectedIndex = 0;
            this.queryConstructorTabControl.Size = new System.Drawing.Size(979, 486);
            this.queryConstructorTabControl.TabIndex = 1;
            // 
            // mainFormSplitContainer
            // 
            this.mainFormSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainFormSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainFormSplitContainer.Name = "mainFormSplitContainer";
            // 
            // mainFormSplitContainer.Panel1
            // 
            this.mainFormSplitContainer.Panel1.Controls.Add(this.databasePanel);
            // 
            // mainFormSplitContainer.Panel2
            // 
            this.mainFormSplitContainer.Panel2.Controls.Add(this.queryConstructorTabControl);
            this.mainFormSplitContainer.Panel2.Controls.Add(this.queryConstructorToolStrip);
            this.mainFormSplitContainer.Size = new System.Drawing.Size(1184, 511);
            this.mainFormSplitContainer.SplitterDistance = 200;
            this.mainFormSplitContainer.SplitterWidth = 5;
            this.mainFormSplitContainer.TabIndex = 2;
            // 
            // databasePanel
            // 
            this.databasePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.databasePanel.Location = new System.Drawing.Point(0, 0);
            this.databasePanel.Name = "databasePanel";
            this.databasePanel.Size = new System.Drawing.Size(200, 511);
            this.databasePanel.TabIndex = 0;
            this.databasePanel.OpenConnection += new System.EventHandler(this.DatabasePanel_OpenConnection);
            this.databasePanel.CloseConnection += new System.EventHandler(this.DatabasePanel_CloseConnection);
            // 
            // queryConstructorToolStrip
            // 
            this.queryConstructorToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.queryConstructorToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearConstructorToolStripButton,
            this.addNewConstructorToolStripButton,
            this.queryConstructorOpenToolStripButton,
            this.queryConstructorSaveToolStripButton,
            this.queryConstructorQueryExecuteButton});
            this.queryConstructorToolStrip.Location = new System.Drawing.Point(0, 0);
            this.queryConstructorToolStrip.Name = "queryConstructorToolStrip";
            this.queryConstructorToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.queryConstructorToolStrip.Size = new System.Drawing.Size(979, 25);
            this.queryConstructorToolStrip.TabIndex = 2;
            this.queryConstructorToolStrip.Text = "toolStrip1";
            // 
            // clearConstructorToolStripButton
            // 
            this.clearConstructorToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.clearConstructorToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("clearConstructorToolStripButton.Image")));
            this.clearConstructorToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearConstructorToolStripButton.Name = "clearConstructorToolStripButton";
            this.clearConstructorToolStripButton.Size = new System.Drawing.Size(144, 22);
            this.clearConstructorToolStripButton.Text = "Очистить конструктор";
            this.clearConstructorToolStripButton.Click += new System.EventHandler(this.ClearConstructorToolStripButton_Click);
            // 
            // addNewConstructorToolStripButton
            // 
            this.addNewConstructorToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addNewConstructorToolStripButton.Image")));
            this.addNewConstructorToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addNewConstructorToolStripButton.Name = "addNewConstructorToolStripButton";
            this.addNewConstructorToolStripButton.Size = new System.Drawing.Size(77, 22);
            this.addNewConstructorToolStripButton.Text = "Добавить";
            this.addNewConstructorToolStripButton.Click += new System.EventHandler(this.AddNewConstructorToolStripButton_Click);
            // 
            // queryConstructorOpenToolStripButton
            // 
            this.queryConstructorOpenToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("queryConstructorOpenToolStripButton.Image")));
            this.queryConstructorOpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.queryConstructorOpenToolStripButton.Name = "queryConstructorOpenToolStripButton";
            this.queryConstructorOpenToolStripButton.Size = new System.Drawing.Size(73, 22);
            this.queryConstructorOpenToolStripButton.Text = "Открыть";
            this.queryConstructorOpenToolStripButton.Click += new System.EventHandler(this.QueryConstructorOpenToolStripButton_Click);
            // 
            // queryConstructorSaveToolStripButton
            // 
            this.queryConstructorSaveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("queryConstructorSaveToolStripButton.Image")));
            this.queryConstructorSaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.queryConstructorSaveToolStripButton.Name = "queryConstructorSaveToolStripButton";
            this.queryConstructorSaveToolStripButton.Size = new System.Drawing.Size(82, 22);
            this.queryConstructorSaveToolStripButton.Text = "Сохранить";
            this.queryConstructorSaveToolStripButton.ToolTipText = "Сохранить";
            this.queryConstructorSaveToolStripButton.Click += new System.EventHandler(this.QueryConstructorSaveToolStripButton_Click);
            // 
            // queryConstructorQueryExecuteButton
            // 
            this.queryConstructorQueryExecuteButton.Enabled = false;
            this.queryConstructorQueryExecuteButton.Image = global::DBQueryConstructor.Properties.Resources.play;
            this.queryConstructorQueryExecuteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.queryConstructorQueryExecuteButton.Name = "queryConstructorQueryExecuteButton";
            this.queryConstructorQueryExecuteButton.Size = new System.Drawing.Size(83, 22);
            this.queryConstructorQueryExecuteButton.Text = "Выполнить";
            this.queryConstructorQueryExecuteButton.Click += new System.EventHandler(this.QueryConstructorExecuteButton_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Сохранение конструктора|*.dbcs";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Сохранение конструктора|*.dbcs";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 511);
            this.Controls.Add(this.mainFormSplitContainer);
            this.MinimumSize = new System.Drawing.Size(1200, 550);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Конструктор запросов";
            this.mainFormSplitContainer.Panel1.ResumeLayout(false);
            this.mainFormSplitContainer.Panel2.ResumeLayout(false);
            this.mainFormSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainFormSplitContainer)).EndInit();
            this.mainFormSplitContainer.ResumeLayout(false);
            this.queryConstructorToolStrip.ResumeLayout(false);
            this.queryConstructorToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private TabControl queryConstructorTabControl;
        private SplitContainer mainFormSplitContainer;
        private ImageList treeViewImageList;
        private Controls.DatabasePanels.DatabasePanel databasePanel;
        private ToolStrip queryConstructorToolStrip;
        private ToolStripButton clearConstructorToolStripButton;
        private ToolStripButton queryConstructorQueryExecuteButton;
        private ToolStripButton queryConstructorSaveToolStripButton;
        private ToolStripButton queryConstructorOpenToolStripButton;
        private SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;
        private ToolStripButton addNewConstructorToolStripButton;
    }
}