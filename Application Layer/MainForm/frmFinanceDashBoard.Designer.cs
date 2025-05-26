namespace PeshawarDHASW.Application_Layer.MainForm
{
    partial class frmFinanceDashBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.office2013DarkTheme1 = new Telerik.WinControls.Themes.Office2013DarkTheme();
            this.HeaderPanel = new Telerik.WinControls.UI.RadPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.documentContainer1 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.PanelTreeView = new Telerik.WinControls.UI.RadPanel();
            this.TreeMenuMain = new Telerik.WinControls.UI.RadTreeView();
            this.PanelDockContainer = new Telerik.WinControls.UI.RadPanel();
            this.radDock1 = new Telerik.WinControls.UI.Docking.RadDock();
            this.documentContainer2 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.txtTreeFilter = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderPanel)).BeginInit();
            this.HeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelTreeView)).BeginInit();
            this.PanelTreeView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreeMenuMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelDockContainer)).BeginInit();
            this.PanelDockContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radDock1)).BeginInit();
            this.radDock1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTreeFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.Controls.Add(this.pictureBox1);
            this.HeaderPanel.Controls.Add(this.radLabel1);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(1114, 50);
            this.HeaderPanel.TabIndex = 7;
            this.HeaderPanel.Text = "Header";
            this.HeaderPanel.ThemeName = "Office2013Dark";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PeshawarDHASW.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(1090, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(19, 25);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "X";
            this.radLabel1.Click += new System.EventHandler(this.radLabel1_Click);
            // 
            // documentContainer1
            // 
            this.documentContainer1.Name = "documentContainer1";
            // 
            // 
            // 
            this.documentContainer1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.documentContainer1.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
            // 
            // PanelTreeView
            // 
            this.PanelTreeView.Controls.Add(this.txtTreeFilter);
            this.PanelTreeView.Controls.Add(this.TreeMenuMain);
            this.PanelTreeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelTreeView.Location = new System.Drawing.Point(0, 50);
            this.PanelTreeView.Name = "PanelTreeView";
            this.PanelTreeView.Size = new System.Drawing.Size(200, 616);
            this.PanelTreeView.TabIndex = 8;
            this.PanelTreeView.Text = "TreeView";
            // 
            // TreeMenuMain
            // 
            this.TreeMenuMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeMenuMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.TreeMenuMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.TreeMenuMain.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.TreeMenuMain.ForeColor = System.Drawing.Color.Black;
            this.TreeMenuMain.LineStyle = Telerik.WinControls.UI.TreeLineStyle.Solid;
            this.TreeMenuMain.Location = new System.Drawing.Point(0, 30);
            this.TreeMenuMain.Name = "TreeMenuMain";
            this.TreeMenuMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TreeMenuMain.ShowLines = true;
            this.TreeMenuMain.Size = new System.Drawing.Size(200, 586);
            this.TreeMenuMain.TabIndex = 0;
            this.TreeMenuMain.Text = "radTreeView1";
            this.TreeMenuMain.ThemeName = "Office2013Dark";
            this.TreeMenuMain.SelectedNodeChanged += new Telerik.WinControls.UI.RadTreeView.RadTreeViewEventHandler(this.TreeMenuMain_SelectedNodeChanged);
            // 
            // PanelDockContainer
            // 
            this.PanelDockContainer.Controls.Add(this.radDock1);
            this.PanelDockContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelDockContainer.Location = new System.Drawing.Point(200, 50);
            this.PanelDockContainer.Name = "PanelDockContainer";
            this.PanelDockContainer.Size = new System.Drawing.Size(914, 616);
            this.PanelDockContainer.TabIndex = 9;
            // 
            // radDock1
            // 
            this.radDock1.AutoDetectMdiChildren = true;
            this.radDock1.BackgroundImage = global::PeshawarDHASW.Properties.Resources.logo;
            this.radDock1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radDock1.Controls.Add(this.documentContainer2);
            this.radDock1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radDock1.IsCleanUpTarget = true;
            this.radDock1.Location = new System.Drawing.Point(0, 0);
            this.radDock1.MainDocumentContainer = this.documentContainer2;
            this.radDock1.Name = "radDock1";
            // 
            // 
            // 
            this.radDock1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.radDock1.Size = new System.Drawing.Size(914, 616);
            this.radDock1.TabIndex = 0;
            this.radDock1.TabStop = false;
            // 
            // documentContainer2
            // 
            this.documentContainer2.Name = "documentContainer2";
            // 
            // 
            // 
            this.documentContainer2.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.documentContainer2.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
            // 
            // txtTreeFilter
            // 
            this.txtTreeFilter.Location = new System.Drawing.Point(3, 4);
            this.txtTreeFilter.Name = "txtTreeFilter";
            this.txtTreeFilter.Size = new System.Drawing.Size(191, 21);
            this.txtTreeFilter.TabIndex = 1;
            this.txtTreeFilter.ThemeName = "Office2013Dark";
            this.txtTreeFilter.TextChanged += new System.EventHandler(this.txtTreeFilter_TextChanged);
            // 
            // frmFinanceDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 666);
            this.Controls.Add(this.PanelDockContainer);
            this.Controls.Add(this.PanelTreeView);
            this.Controls.Add(this.HeaderPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "frmFinanceDashBoard";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmFinanceDashBoard";
            this.ThemeName = "Office2013Dark";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmFinanceDashBoard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HeaderPanel)).EndInit();
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelTreeView)).EndInit();
            this.PanelTreeView.ResumeLayout(false);
            this.PanelTreeView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreeMenuMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelDockContainer)).EndInit();
            this.PanelDockContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radDock1)).EndInit();
            this.radDock1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTreeFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.Themes.Office2013DarkTheme office2013DarkTheme1;

        private Telerik.WinControls.UI.RadPanel HeaderPanel;
        private Telerik.WinControls.UI.Docking.DocumentContainer documentContainer1;
        private Telerik.WinControls.UI.RadPanel PanelTreeView;
        private Telerik.WinControls.UI.RadTreeView TreeMenuMain;
        private Telerik.WinControls.UI.RadPanel PanelDockContainer;
        private Telerik.WinControls.UI.Docking.RadDock radDock1;
        private Telerik.WinControls.UI.Docking.DocumentContainer documentContainer2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Telerik.WinControls.UI.RadTextBox txtTreeFilter;
    }
}
