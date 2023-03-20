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
            this.queryTabPage1 = new System.Windows.Forms.TabPage();
            this.queryTabPageSplitContainer = new System.Windows.Forms.SplitContainer();
            this.queryConstructorTableListView = new DBQueryConstructor.Controls.TablePanels.TableListView();
            this.queryConstructorInteractionsTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.queryConstructorMiscTabControl = new System.Windows.Forms.TabControl();
            this.queryConstructorMiscFieldTabPage = new System.Windows.Forms.TabPage();
            this.queryConstructorMiscFieldListView = new DBQueryConstructor.Controls.ColumnPanels.ColumnListView();
            this.queryConstructorMiscJoinTabPage = new System.Windows.Forms.TabPage();
            this.queryConstructorMiscJoinListView = new DBQueryConstructor.Controls.JoinPanels.JoinListView();
            this.queryConstructorMiscConditionTabPage = new System.Windows.Forms.TabPage();
            this.queryConstructorMiscConditionListView = new DBQueryConstructor.Controls.ConditionPanels.ConditionListView();
            this.queryConstructorMiscQueryTabPage = new System.Windows.Forms.TabPage();
            this.queryConstructorQueryText = new System.Windows.Forms.TextBox();
            this.queryConstructorMiscResultTabPage = new System.Windows.Forms.TabPage();
            this.queryConstructorMiscResultDataGrid = new DBQueryConstructor.ControlAbstraction.DataGridViewBuffered();
            this.queryConstructorMiscResultToolStrip = new System.Windows.Forms.ToolStrip();
            this.queryConstructorMiscResultRowCountLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.mainFormSplitContainer = new System.Windows.Forms.SplitContainer();
            this.databasePanel = new DBQueryConstructor.Controls.DatabasePanels.DatabasePanel();
            this.queryConstructorToolStrip = new System.Windows.Forms.ToolStrip();
            this.clearConstructorToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.queryConstructorOpenToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.queryConstructorSaveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.queryConstructorQueryExecuteButton = new System.Windows.Forms.ToolStripButton();
            this.queryConstructorTabControl.SuspendLayout();
            this.queryTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.queryTabPageSplitContainer)).BeginInit();
            this.queryTabPageSplitContainer.Panel1.SuspendLayout();
            this.queryTabPageSplitContainer.Panel2.SuspendLayout();
            this.queryTabPageSplitContainer.SuspendLayout();
            this.queryConstructorInteractionsTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.queryConstructorMiscTabControl.SuspendLayout();
            this.queryConstructorMiscFieldTabPage.SuspendLayout();
            this.queryConstructorMiscJoinTabPage.SuspendLayout();
            this.queryConstructorMiscConditionTabPage.SuspendLayout();
            this.queryConstructorMiscQueryTabPage.SuspendLayout();
            this.queryConstructorMiscResultTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.queryConstructorMiscResultDataGrid)).BeginInit();
            this.queryConstructorMiscResultToolStrip.SuspendLayout();
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
            this.queryConstructorTabControl.Controls.Add(this.queryTabPage1);
            this.queryConstructorTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryConstructorTabControl.ItemSize = new System.Drawing.Size(31, 20);
            this.queryConstructorTabControl.Location = new System.Drawing.Point(0, 25);
            this.queryConstructorTabControl.Name = "queryConstructorTabControl";
            this.queryConstructorTabControl.SelectedIndex = 0;
            this.queryConstructorTabControl.Size = new System.Drawing.Size(979, 486);
            this.queryConstructorTabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.queryConstructorTabControl.TabIndex = 1;
            // 
            // queryTabPage1
            // 
            this.queryTabPage1.BackColor = System.Drawing.Color.White;
            this.queryTabPage1.Controls.Add(this.queryTabPageSplitContainer);
            this.queryTabPage1.Location = new System.Drawing.Point(4, 24);
            this.queryTabPage1.Name = "queryTabPage1";
            this.queryTabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.queryTabPage1.Size = new System.Drawing.Size(971, 458);
            this.queryTabPage1.TabIndex = 0;
            this.queryTabPage1.Text = "Конструктор";
            // 
            // queryTabPageSplitContainer
            // 
            this.queryTabPageSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.queryTabPageSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryTabPageSplitContainer.Location = new System.Drawing.Point(3, 3);
            this.queryTabPageSplitContainer.Name = "queryTabPageSplitContainer";
            this.queryTabPageSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // queryTabPageSplitContainer.Panel1
            // 
            this.queryTabPageSplitContainer.Panel1.Controls.Add(this.queryConstructorTableListView);
            // 
            // queryTabPageSplitContainer.Panel2
            // 
            this.queryTabPageSplitContainer.Panel2.Controls.Add(this.queryConstructorInteractionsTabControl);
            this.queryTabPageSplitContainer.Size = new System.Drawing.Size(965, 452);
            this.queryTabPageSplitContainer.SplitterDistance = 253;
            this.queryTabPageSplitContainer.SplitterWidth = 7;
            this.queryTabPageSplitContainer.TabIndex = 0;
            // 
            // queryConstructorTableListView
            // 
            this.queryConstructorTableListView.AllowDrop = true;
            this.queryConstructorTableListView.AutoScroll = true;
            this.queryConstructorTableListView.ColumnCount = 7;
            this.queryConstructorTableListView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.queryConstructorTableListView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.queryConstructorTableListView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.queryConstructorTableListView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.queryConstructorTableListView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.queryConstructorTableListView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.queryConstructorTableListView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.queryConstructorTableListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryConstructorTableListView.Location = new System.Drawing.Point(0, 0);
            this.queryConstructorTableListView.Name = "queryConstructorTableListView";
            this.queryConstructorTableListView.Padding = new System.Windows.Forms.Padding(10);
            this.queryConstructorTableListView.Size = new System.Drawing.Size(963, 251);
            this.queryConstructorTableListView.TabIndex = 0;
            this.queryConstructorTableListView.DataChanged += new System.EventHandler(this.QueryConstructorTableListView_DataChanged);
            this.queryConstructorTableListView.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.QueryConstructorTableListView_ControlRemoved);
            // 
            // queryConstructorInteractionsTabControl
            // 
            this.queryConstructorInteractionsTabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.queryConstructorInteractionsTabControl.Controls.Add(this.tabPage1);
            this.queryConstructorInteractionsTabControl.Controls.Add(this.queryConstructorMiscQueryTabPage);
            this.queryConstructorInteractionsTabControl.Controls.Add(this.queryConstructorMiscResultTabPage);
            this.queryConstructorInteractionsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryConstructorInteractionsTabControl.Location = new System.Drawing.Point(0, 0);
            this.queryConstructorInteractionsTabControl.Name = "queryConstructorInteractionsTabControl";
            this.queryConstructorInteractionsTabControl.SelectedIndex = 0;
            this.queryConstructorInteractionsTabControl.Size = new System.Drawing.Size(963, 190);
            this.queryConstructorInteractionsTabControl.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.queryConstructorMiscTabControl);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(955, 164);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Конструктор";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // queryConstructorMiscTabControl
            // 
            this.queryConstructorMiscTabControl.Controls.Add(this.queryConstructorMiscFieldTabPage);
            this.queryConstructorMiscTabControl.Controls.Add(this.queryConstructorMiscJoinTabPage);
            this.queryConstructorMiscTabControl.Controls.Add(this.queryConstructorMiscConditionTabPage);
            this.queryConstructorMiscTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryConstructorMiscTabControl.Location = new System.Drawing.Point(3, 3);
            this.queryConstructorMiscTabControl.Name = "queryConstructorMiscTabControl";
            this.queryConstructorMiscTabControl.Padding = new System.Drawing.Point(10, 3);
            this.queryConstructorMiscTabControl.SelectedIndex = 0;
            this.queryConstructorMiscTabControl.Size = new System.Drawing.Size(949, 158);
            this.queryConstructorMiscTabControl.TabIndex = 0;
            // 
            // queryConstructorMiscFieldTabPage
            // 
            this.queryConstructorMiscFieldTabPage.Controls.Add(this.queryConstructorMiscFieldListView);
            this.queryConstructorMiscFieldTabPage.Location = new System.Drawing.Point(4, 22);
            this.queryConstructorMiscFieldTabPage.Name = "queryConstructorMiscFieldTabPage";
            this.queryConstructorMiscFieldTabPage.Size = new System.Drawing.Size(941, 132);
            this.queryConstructorMiscFieldTabPage.TabIndex = 0;
            this.queryConstructorMiscFieldTabPage.Text = "Поля";
            this.queryConstructorMiscFieldTabPage.UseVisualStyleBackColor = true;
            // 
            // queryConstructorMiscFieldListView
            // 
            this.queryConstructorMiscFieldListView.AutoScroll = true;
            this.queryConstructorMiscFieldListView.ColumnCount = 3;
            this.queryConstructorMiscFieldListView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.queryConstructorMiscFieldListView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.queryConstructorMiscFieldListView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.queryConstructorMiscFieldListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryConstructorMiscFieldListView.Location = new System.Drawing.Point(0, 0);
            this.queryConstructorMiscFieldListView.Name = "queryConstructorMiscFieldListView";
            this.queryConstructorMiscFieldListView.Size = new System.Drawing.Size(941, 132);
            this.queryConstructorMiscFieldListView.TabIndex = 0;
            this.queryConstructorMiscFieldListView.DataChanged += new System.EventHandler(this.QueryConstructorMiscListView_DataChanged);
            // 
            // queryConstructorMiscJoinTabPage
            // 
            this.queryConstructorMiscJoinTabPage.AllowDrop = true;
            this.queryConstructorMiscJoinTabPage.AutoScroll = true;
            this.queryConstructorMiscJoinTabPage.Controls.Add(this.queryConstructorMiscJoinListView);
            this.queryConstructorMiscJoinTabPage.Location = new System.Drawing.Point(4, 22);
            this.queryConstructorMiscJoinTabPage.Name = "queryConstructorMiscJoinTabPage";
            this.queryConstructorMiscJoinTabPage.Size = new System.Drawing.Size(941, 132);
            this.queryConstructorMiscJoinTabPage.TabIndex = 2;
            this.queryConstructorMiscJoinTabPage.Text = "Присоединения";
            this.queryConstructorMiscJoinTabPage.UseVisualStyleBackColor = true;
            // 
            // queryConstructorMiscJoinListView
            // 
            this.queryConstructorMiscJoinListView.AllowDrop = true;
            this.queryConstructorMiscJoinListView.AutoScroll = true;
            this.queryConstructorMiscJoinListView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.queryConstructorMiscJoinListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryConstructorMiscJoinListView.Location = new System.Drawing.Point(0, 0);
            this.queryConstructorMiscJoinListView.Name = "queryConstructorMiscJoinListView";
            this.queryConstructorMiscJoinListView.Size = new System.Drawing.Size(941, 132);
            this.queryConstructorMiscJoinListView.TabIndex = 0;
            this.queryConstructorMiscJoinListView.DataChanged += new System.EventHandler(this.QueryConstructorMiscListView_DataChanged);
            // 
            // queryConstructorMiscConditionTabPage
            // 
            this.queryConstructorMiscConditionTabPage.AllowDrop = true;
            this.queryConstructorMiscConditionTabPage.Controls.Add(this.queryConstructorMiscConditionListView);
            this.queryConstructorMiscConditionTabPage.Location = new System.Drawing.Point(4, 22);
            this.queryConstructorMiscConditionTabPage.Name = "queryConstructorMiscConditionTabPage";
            this.queryConstructorMiscConditionTabPage.Size = new System.Drawing.Size(941, 132);
            this.queryConstructorMiscConditionTabPage.TabIndex = 1;
            this.queryConstructorMiscConditionTabPage.Text = "Условия";
            this.queryConstructorMiscConditionTabPage.UseVisualStyleBackColor = true;
            // 
            // queryConstructorMiscConditionListView
            // 
            this.queryConstructorMiscConditionListView.AllowDrop = true;
            this.queryConstructorMiscConditionListView.AutoScroll = true;
            this.queryConstructorMiscConditionListView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.queryConstructorMiscConditionListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryConstructorMiscConditionListView.Location = new System.Drawing.Point(0, 0);
            this.queryConstructorMiscConditionListView.Name = "queryConstructorMiscConditionListView";
            this.queryConstructorMiscConditionListView.Size = new System.Drawing.Size(941, 132);
            this.queryConstructorMiscConditionListView.TabIndex = 0;
            this.queryConstructorMiscConditionListView.DataChanged += new System.EventHandler(this.QueryConstructorMiscListView_DataChanged);
            // 
            // queryConstructorMiscQueryTabPage
            // 
            this.queryConstructorMiscQueryTabPage.Controls.Add(this.queryConstructorQueryText);
            this.queryConstructorMiscQueryTabPage.Location = new System.Drawing.Point(4, 4);
            this.queryConstructorMiscQueryTabPage.Name = "queryConstructorMiscQueryTabPage";
            this.queryConstructorMiscQueryTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.queryConstructorMiscQueryTabPage.Size = new System.Drawing.Size(955, 164);
            this.queryConstructorMiscQueryTabPage.TabIndex = 1;
            this.queryConstructorMiscQueryTabPage.Text = "Запрос";
            this.queryConstructorMiscQueryTabPage.UseVisualStyleBackColor = true;
            // 
            // queryConstructorQueryText
            // 
            this.queryConstructorQueryText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryConstructorQueryText.Location = new System.Drawing.Point(3, 3);
            this.queryConstructorQueryText.Multiline = true;
            this.queryConstructorQueryText.Name = "queryConstructorQueryText";
            this.queryConstructorQueryText.ReadOnly = true;
            this.queryConstructorQueryText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.queryConstructorQueryText.Size = new System.Drawing.Size(949, 158);
            this.queryConstructorQueryText.TabIndex = 2;
            // 
            // queryConstructorMiscResultTabPage
            // 
            this.queryConstructorMiscResultTabPage.Controls.Add(this.queryConstructorMiscResultDataGrid);
            this.queryConstructorMiscResultTabPage.Controls.Add(this.queryConstructorMiscResultToolStrip);
            this.queryConstructorMiscResultTabPage.Location = new System.Drawing.Point(4, 4);
            this.queryConstructorMiscResultTabPage.Name = "queryConstructorMiscResultTabPage";
            this.queryConstructorMiscResultTabPage.Size = new System.Drawing.Size(955, 164);
            this.queryConstructorMiscResultTabPage.TabIndex = 2;
            this.queryConstructorMiscResultTabPage.Text = "Результат";
            this.queryConstructorMiscResultTabPage.UseVisualStyleBackColor = true;
            // 
            // queryConstructorMiscResultDataGrid
            // 
            this.queryConstructorMiscResultDataGrid.AllowUserToAddRows = false;
            this.queryConstructorMiscResultDataGrid.AllowUserToDeleteRows = false;
            this.queryConstructorMiscResultDataGrid.AllowUserToResizeRows = false;
            this.queryConstructorMiscResultDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.queryConstructorMiscResultDataGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.queryConstructorMiscResultDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.queryConstructorMiscResultDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryConstructorMiscResultDataGrid.GridColor = System.Drawing.Color.WhiteSmoke;
            this.queryConstructorMiscResultDataGrid.Location = new System.Drawing.Point(0, 0);
            this.queryConstructorMiscResultDataGrid.Name = "queryConstructorMiscResultDataGrid";
            this.queryConstructorMiscResultDataGrid.ReadOnly = true;
            this.queryConstructorMiscResultDataGrid.RowTemplate.Height = 23;
            this.queryConstructorMiscResultDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.queryConstructorMiscResultDataGrid.Size = new System.Drawing.Size(955, 139);
            this.queryConstructorMiscResultDataGrid.TabIndex = 3;
            // 
            // queryConstructorMiscResultToolStrip
            // 
            this.queryConstructorMiscResultToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.queryConstructorMiscResultToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.queryConstructorMiscResultToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.queryConstructorMiscResultRowCountLabel,
            this.toolStripLabel1});
            this.queryConstructorMiscResultToolStrip.Location = new System.Drawing.Point(0, 139);
            this.queryConstructorMiscResultToolStrip.Name = "queryConstructorMiscResultToolStrip";
            this.queryConstructorMiscResultToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.queryConstructorMiscResultToolStrip.Size = new System.Drawing.Size(955, 25);
            this.queryConstructorMiscResultToolStrip.TabIndex = 2;
            this.queryConstructorMiscResultToolStrip.Text = "toolStrip1";
            // 
            // queryConstructorMiscResultRowCountLabel
            // 
            this.queryConstructorMiscResultRowCountLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.queryConstructorMiscResultRowCountLabel.Name = "queryConstructorMiscResultRowCountLabel";
            this.queryConstructorMiscResultRowCountLabel.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(99, 22);
            this.toolStripLabel1.Text = "Количество строк";
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
            this.databasePanel.ImageList = this.treeViewImageList;
            this.databasePanel.Location = new System.Drawing.Point(0, 0);
            this.databasePanel.Name = "databasePanel";
            this.databasePanel.Size = new System.Drawing.Size(200, 511);
            this.databasePanel.TabIndex = 0;
            this.databasePanel.CloseConnection += new System.EventHandler(this.DatabasePanel_CloseConnection);
            // 
            // queryConstructorToolStrip
            // 
            this.queryConstructorToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.queryConstructorToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearConstructorToolStripButton,
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
            this.queryConstructorQueryExecuteButton.Image = global::DBQueryConstructor.Properties.Resources.play;
            this.queryConstructorQueryExecuteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.queryConstructorQueryExecuteButton.Name = "queryConstructorQueryExecuteButton";
            this.queryConstructorQueryExecuteButton.Size = new System.Drawing.Size(83, 22);
            this.queryConstructorQueryExecuteButton.Text = "Выполнить";
            this.queryConstructorQueryExecuteButton.Click += new System.EventHandler(this.QueryConstructorExecuteButton_Click);
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
            this.queryConstructorTabControl.ResumeLayout(false);
            this.queryTabPage1.ResumeLayout(false);
            this.queryTabPageSplitContainer.Panel1.ResumeLayout(false);
            this.queryTabPageSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.queryTabPageSplitContainer)).EndInit();
            this.queryTabPageSplitContainer.ResumeLayout(false);
            this.queryConstructorInteractionsTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.queryConstructorMiscTabControl.ResumeLayout(false);
            this.queryConstructorMiscFieldTabPage.ResumeLayout(false);
            this.queryConstructorMiscJoinTabPage.ResumeLayout(false);
            this.queryConstructorMiscConditionTabPage.ResumeLayout(false);
            this.queryConstructorMiscQueryTabPage.ResumeLayout(false);
            this.queryConstructorMiscQueryTabPage.PerformLayout();
            this.queryConstructorMiscResultTabPage.ResumeLayout(false);
            this.queryConstructorMiscResultTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.queryConstructorMiscResultDataGrid)).EndInit();
            this.queryConstructorMiscResultToolStrip.ResumeLayout(false);
            this.queryConstructorMiscResultToolStrip.PerformLayout();
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
        private TabPage queryTabPage1;
        private SplitContainer queryTabPageSplitContainer;
        private TabControl queryConstructorMiscTabControl;
        private TabPage queryConstructorMiscFieldTabPage;
        private TabPage queryConstructorMiscConditionTabPage;
        internal TabPage queryConstructorMiscJoinTabPage;
        internal Controls.TablePanels.TableListView queryConstructorTableListView;
        private Controls.JoinPanels.JoinListView queryConstructorMiscJoinListView;
        private Controls.ConditionPanels.ConditionListView queryConstructorMiscConditionListView;
        private ImageList treeViewImageList;
        private Controls.ColumnPanels.ColumnListView queryConstructorMiscFieldListView;
        private Controls.DatabasePanels.DatabasePanel databasePanel;
        private ToolStrip queryConstructorToolStrip;
        private ToolStripButton clearConstructorToolStripButton;
        private TabControl queryConstructorInteractionsTabControl;
        private TabPage tabPage1;
        private TabPage queryConstructorMiscQueryTabPage;
        private TextBox queryConstructorQueryText;
        private TabPage queryConstructorMiscResultTabPage;
        private DataGridViewBuffered queryConstructorMiscResultDataGrid;
        private ToolStrip queryConstructorMiscResultToolStrip;
        private ToolStripLabel queryConstructorMiscResultRowCountLabel;
        private ToolStripLabel toolStripLabel1;
        private ToolStripButton queryConstructorQueryExecuteButton;
        private ToolStripButton queryConstructorSaveToolStripButton;
        private ToolStripButton queryConstructorOpenToolStripButton;
    }
}