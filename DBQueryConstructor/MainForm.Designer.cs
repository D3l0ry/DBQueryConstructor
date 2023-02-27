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
            this.queryConstructorMiscTabControl = new System.Windows.Forms.TabControl();
            this.queryConstructorMiscFieldTabPage = new System.Windows.Forms.TabPage();
            this.queryConstructorMiscFieldListView = new DBQueryConstructor.Controls.ColumnPanels.ColumnListView();
            this.queryConstructorMiscJoinTabPage = new System.Windows.Forms.TabPage();
            this.queryConstructorMiscJoinListView = new DBQueryConstructor.Controls.JoinPanels.JoinListView();
            this.queryConstructorMiscConditionTabPage = new System.Windows.Forms.TabPage();
            this.queryConstructorMiscConditionListView = new DBQueryConstructor.Controls.ConditionPanels.ConditionListView();
            this.queryConstructorMiscQueryTextTabPage = new System.Windows.Forms.TabPage();
            this.queryConstructorQueryText = new System.Windows.Forms.TextBox();
            this.queryConsturctorQueryToolStrip = new System.Windows.Forms.ToolStrip();
            this.queryConstructorQueryToolExecuteButton = new System.Windows.Forms.ToolStripButton();
            this.queryConstructorMiscResultTabPage = new System.Windows.Forms.TabPage();
            this.mainFormSplitContainer = new System.Windows.Forms.SplitContainer();
            this.databasePanel1 = new DBQueryConstructor.Controls.DatabasePanels.DatabasePanel();
            this.queryConstructorTabControl.SuspendLayout();
            this.queryTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.queryTabPageSplitContainer)).BeginInit();
            this.queryTabPageSplitContainer.Panel1.SuspendLayout();
            this.queryTabPageSplitContainer.Panel2.SuspendLayout();
            this.queryTabPageSplitContainer.SuspendLayout();
            this.queryConstructorMiscTabControl.SuspendLayout();
            this.queryConstructorMiscFieldTabPage.SuspendLayout();
            this.queryConstructorMiscJoinTabPage.SuspendLayout();
            this.queryConstructorMiscConditionTabPage.SuspendLayout();
            this.queryConstructorMiscQueryTextTabPage.SuspendLayout();
            this.queryConsturctorQueryToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainFormSplitContainer)).BeginInit();
            this.mainFormSplitContainer.Panel1.SuspendLayout();
            this.mainFormSplitContainer.Panel2.SuspendLayout();
            this.mainFormSplitContainer.SuspendLayout();
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
            this.queryConstructorTabControl.Location = new System.Drawing.Point(0, 0);
            this.queryConstructorTabControl.Name = "queryConstructorTabControl";
            this.queryConstructorTabControl.SelectedIndex = 0;
            this.queryConstructorTabControl.Size = new System.Drawing.Size(979, 511);
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
            this.queryTabPage1.Size = new System.Drawing.Size(971, 483);
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
            this.queryTabPageSplitContainer.Panel2.Controls.Add(this.queryConstructorMiscTabControl);
            this.queryTabPageSplitContainer.Size = new System.Drawing.Size(965, 477);
            this.queryTabPageSplitContainer.SplitterDistance = 267;
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
            this.queryConstructorTableListView.Size = new System.Drawing.Size(963, 265);
            this.queryConstructorTableListView.TabIndex = 0;
            this.queryConstructorTableListView.DataChanged += new System.EventHandler(this.QueryConstructorTableListView_DataChanged);
            this.queryConstructorTableListView.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.QueryConstructorTableListView_ControlRemoved);
            // 
            // queryConstructorMiscTabControl
            // 
            this.queryConstructorMiscTabControl.Controls.Add(this.queryConstructorMiscFieldTabPage);
            this.queryConstructorMiscTabControl.Controls.Add(this.queryConstructorMiscJoinTabPage);
            this.queryConstructorMiscTabControl.Controls.Add(this.queryConstructorMiscConditionTabPage);
            this.queryConstructorMiscTabControl.Controls.Add(this.queryConstructorMiscQueryTextTabPage);
            this.queryConstructorMiscTabControl.Controls.Add(this.queryConstructorMiscResultTabPage);
            this.queryConstructorMiscTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryConstructorMiscTabControl.Location = new System.Drawing.Point(0, 0);
            this.queryConstructorMiscTabControl.Name = "queryConstructorMiscTabControl";
            this.queryConstructorMiscTabControl.Padding = new System.Drawing.Point(10, 3);
            this.queryConstructorMiscTabControl.SelectedIndex = 0;
            this.queryConstructorMiscTabControl.Size = new System.Drawing.Size(963, 201);
            this.queryConstructorMiscTabControl.TabIndex = 0;
            // 
            // queryConstructorMiscFieldTabPage
            // 
            this.queryConstructorMiscFieldTabPage.Controls.Add(this.queryConstructorMiscFieldListView);
            this.queryConstructorMiscFieldTabPage.Location = new System.Drawing.Point(4, 22);
            this.queryConstructorMiscFieldTabPage.Name = "queryConstructorMiscFieldTabPage";
            this.queryConstructorMiscFieldTabPage.Size = new System.Drawing.Size(955, 175);
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
            this.queryConstructorMiscFieldListView.Size = new System.Drawing.Size(955, 175);
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
            this.queryConstructorMiscJoinTabPage.Padding = new System.Windows.Forms.Padding(1);
            this.queryConstructorMiscJoinTabPage.Size = new System.Drawing.Size(955, 175);
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
            this.queryConstructorMiscJoinListView.Location = new System.Drawing.Point(1, 1);
            this.queryConstructorMiscJoinListView.Name = "queryConstructorMiscJoinListView";
            this.queryConstructorMiscJoinListView.Size = new System.Drawing.Size(953, 173);
            this.queryConstructorMiscJoinListView.TabIndex = 0;
            this.queryConstructorMiscJoinListView.DataChanged += new System.EventHandler(this.QueryConstructorMiscListView_DataChanged);
            // 
            // queryConstructorMiscConditionTabPage
            // 
            this.queryConstructorMiscConditionTabPage.AllowDrop = true;
            this.queryConstructorMiscConditionTabPage.Controls.Add(this.queryConstructorMiscConditionListView);
            this.queryConstructorMiscConditionTabPage.Location = new System.Drawing.Point(4, 22);
            this.queryConstructorMiscConditionTabPage.Name = "queryConstructorMiscConditionTabPage";
            this.queryConstructorMiscConditionTabPage.Size = new System.Drawing.Size(955, 175);
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
            this.queryConstructorMiscConditionListView.Size = new System.Drawing.Size(955, 175);
            this.queryConstructorMiscConditionListView.TabIndex = 0;
            this.queryConstructorMiscConditionListView.DataChanged += new System.EventHandler(this.QueryConstructorMiscListView_DataChanged);
            // 
            // queryConstructorMiscQueryTextTabPage
            // 
            this.queryConstructorMiscQueryTextTabPage.Controls.Add(this.queryConstructorQueryText);
            this.queryConstructorMiscQueryTextTabPage.Controls.Add(this.queryConsturctorQueryToolStrip);
            this.queryConstructorMiscQueryTextTabPage.Location = new System.Drawing.Point(4, 22);
            this.queryConstructorMiscQueryTextTabPage.Name = "queryConstructorMiscQueryTextTabPage";
            this.queryConstructorMiscQueryTextTabPage.Size = new System.Drawing.Size(955, 175);
            this.queryConstructorMiscQueryTextTabPage.TabIndex = 3;
            this.queryConstructorMiscQueryTextTabPage.Text = "Запрос";
            this.queryConstructorMiscQueryTextTabPage.UseVisualStyleBackColor = true;
            // 
            // queryConstructorQueryText
            // 
            this.queryConstructorQueryText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryConstructorQueryText.Location = new System.Drawing.Point(0, 25);
            this.queryConstructorQueryText.Multiline = true;
            this.queryConstructorQueryText.Name = "queryConstructorQueryText";
            this.queryConstructorQueryText.ReadOnly = true;
            this.queryConstructorQueryText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.queryConstructorQueryText.Size = new System.Drawing.Size(955, 150);
            this.queryConstructorQueryText.TabIndex = 0;
            // 
            // queryConsturctorQueryToolStrip
            // 
            this.queryConsturctorQueryToolStrip.BackColor = System.Drawing.Color.Transparent;
            this.queryConsturctorQueryToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.queryConsturctorQueryToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.queryConstructorQueryToolExecuteButton});
            this.queryConsturctorQueryToolStrip.Location = new System.Drawing.Point(0, 0);
            this.queryConsturctorQueryToolStrip.Name = "queryConsturctorQueryToolStrip";
            this.queryConsturctorQueryToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.queryConsturctorQueryToolStrip.Size = new System.Drawing.Size(955, 25);
            this.queryConsturctorQueryToolStrip.TabIndex = 1;
            this.queryConsturctorQueryToolStrip.Text = "toolStrip1";
            // 
            // queryConstructorQueryToolExecuteButton
            // 
            this.queryConstructorQueryToolExecuteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.queryConstructorQueryToolExecuteButton.Image = global::DBQueryConstructor.Properties.Resources.play;
            this.queryConstructorQueryToolExecuteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.queryConstructorQueryToolExecuteButton.Name = "queryConstructorQueryToolExecuteButton";
            this.queryConstructorQueryToolExecuteButton.Size = new System.Drawing.Size(23, 22);
            this.queryConstructorQueryToolExecuteButton.Text = "Выполнть";
            this.queryConstructorQueryToolExecuteButton.Click += new System.EventHandler(this.QueryConstructorQueryToolExecuteButton_Click);
            // 
            // queryConstructorMiscResultTabPage
            // 
            this.queryConstructorMiscResultTabPage.Location = new System.Drawing.Point(4, 22);
            this.queryConstructorMiscResultTabPage.Name = "queryConstructorMiscResultTabPage";
            this.queryConstructorMiscResultTabPage.Size = new System.Drawing.Size(955, 175);
            this.queryConstructorMiscResultTabPage.TabIndex = 4;
            this.queryConstructorMiscResultTabPage.Text = "Результат";
            this.queryConstructorMiscResultTabPage.UseVisualStyleBackColor = true;
            // 
            // mainFormSplitContainer
            // 
            this.mainFormSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainFormSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainFormSplitContainer.Name = "mainFormSplitContainer";
            // 
            // mainFormSplitContainer.Panel1
            // 
            this.mainFormSplitContainer.Panel1.Controls.Add(this.databasePanel1);
            // 
            // mainFormSplitContainer.Panel2
            // 
            this.mainFormSplitContainer.Panel2.Controls.Add(this.queryConstructorTabControl);
            this.mainFormSplitContainer.Size = new System.Drawing.Size(1184, 511);
            this.mainFormSplitContainer.SplitterDistance = 200;
            this.mainFormSplitContainer.SplitterWidth = 5;
            this.mainFormSplitContainer.TabIndex = 2;
            // 
            // databasePanel1
            // 
            this.databasePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.databasePanel1.ImageList = this.treeViewImageList;
            this.databasePanel1.Location = new System.Drawing.Point(0, 0);
            this.databasePanel1.Name = "databasePanel1";
            this.databasePanel1.Size = new System.Drawing.Size(200, 511);
            this.databasePanel1.TabIndex = 0;
            this.databasePanel1.CloseConnection += new System.EventHandler(this.DatabasePanel_CloseConnection);
            this.databasePanel1.TableDragDrop += new System.EventHandler<System.Windows.Forms.DragEventArgs>(this.DatabasePanel_TableDragDrop);
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
            this.queryConstructorMiscTabControl.ResumeLayout(false);
            this.queryConstructorMiscFieldTabPage.ResumeLayout(false);
            this.queryConstructorMiscJoinTabPage.ResumeLayout(false);
            this.queryConstructorMiscConditionTabPage.ResumeLayout(false);
            this.queryConstructorMiscQueryTextTabPage.ResumeLayout(false);
            this.queryConstructorMiscQueryTextTabPage.PerformLayout();
            this.queryConsturctorQueryToolStrip.ResumeLayout(false);
            this.queryConsturctorQueryToolStrip.PerformLayout();
            this.mainFormSplitContainer.Panel1.ResumeLayout(false);
            this.mainFormSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainFormSplitContainer)).EndInit();
            this.mainFormSplitContainer.ResumeLayout(false);
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
        private TabPage queryConstructorMiscQueryTextTabPage;
        private TextBox queryConstructorQueryText;
        private TabPage queryConstructorMiscResultTabPage;
        internal TabPage queryConstructorMiscJoinTabPage;
        private ToolStrip queryConsturctorQueryToolStrip;
        private ToolStripButton queryConstructorQueryToolExecuteButton;
        internal Controls.TablePanels.TableListView queryConstructorTableListView;
        private Controls.JoinPanels.JoinListView queryConstructorMiscJoinListView;
        private Controls.ConditionPanels.ConditionListView queryConstructorMiscConditionListView;
        private ImageList treeViewImageList;
        private Controls.ColumnPanels.ColumnListView queryConstructorMiscFieldListView;
        private Controls.DatabasePanels.DatabasePanel databasePanel1;
    }
}