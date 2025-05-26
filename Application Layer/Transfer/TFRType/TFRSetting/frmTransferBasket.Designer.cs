namespace PeshawarDHASW.Application_Layer.Transfer.TFRSetting
{
    partial class frmTransferBasket
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            this.dddfd = new Telerik.WinControls.UI.RadGroupBox();
            this.grdFile_MultiOwner = new Telerik.WinControls.UI.RadGridView();
            this.radThemeManager1 = new Telerik.WinControls.RadThemeManager();
            this.btnRefresh = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox4 = new Telerik.WinControls.UI.RadGroupBox();
            this.grdEngageFiles = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox5 = new Telerik.WinControls.UI.RadGroupBox();
            this.grdFile_Complete = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dddfd)).BeginInit();
            this.dddfd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFile_MultiOwner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFile_MultiOwner.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).BeginInit();
            this.radGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEngageFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEngageFiles.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox5)).BeginInit();
            this.radGroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFile_Complete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFile_Complete.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // dddfd
            // 
            this.dddfd.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.dddfd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dddfd.Controls.Add(this.grdFile_MultiOwner);
            this.dddfd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dddfd.HeaderText = "File No (Having Multiple Owner and Status=Active)";
            this.dddfd.Location = new System.Drawing.Point(12, 70);
            this.dddfd.Name = "dddfd";
            this.dddfd.Size = new System.Drawing.Size(319, 611);
            this.dddfd.TabIndex = 0;
            this.dddfd.Text = "File No (Having Multiple Owner and Status=Active)";
            this.dddfd.ThemeName = "TelerikMetro";
            // 
            // grdFile_MultiOwner
            // 
            this.grdFile_MultiOwner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFile_MultiOwner.AutoSizeRows = true;
            this.grdFile_MultiOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdFile_MultiOwner.Location = new System.Drawing.Point(5, 33);
            // 
            // 
            // 
            this.grdFile_MultiOwner.MasterTemplate.AllowAddNewRow = false;
            this.grdFile_MultiOwner.MasterTemplate.AllowColumnReorder = false;
            this.grdFile_MultiOwner.MasterTemplate.AllowSearchRow = true;
            this.grdFile_MultiOwner.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "FileMapKey";
            gridViewTextBoxColumn1.HeaderText = "FileMapKey";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "naFileMapKey";
            gridViewTextBoxColumn2.FieldName = "FileNo";
            gridViewTextBoxColumn2.HeaderText = "FileNo";
            gridViewTextBoxColumn2.Name = "naFileNo";
            gridViewTextBoxColumn2.Width = 287;
            this.grdFile_MultiOwner.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2});
            this.grdFile_MultiOwner.MasterTemplate.EnableFiltering = true;
            this.grdFile_MultiOwner.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdFile_MultiOwner.Name = "grdFile_MultiOwner";
            this.grdFile_MultiOwner.ReadOnly = true;
            this.grdFile_MultiOwner.Size = new System.Drawing.Size(308, 568);
            this.grdFile_MultiOwner.TabIndex = 0;
            this.grdFile_MultiOwner.Text = "radGridView1";
            this.grdFile_MultiOwner.ThemeName = "TelerikMetro";
            this.grdFile_MultiOwner.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdFile_MultiOwner_CellClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(18, 20);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(313, 44);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // radGroupBox4
            // 
            this.radGroupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.radGroupBox4.Controls.Add(this.grdEngageFiles);
            this.radGroupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox4.HeaderText = "File No having Status = Engage";
            this.radGroupBox4.Location = new System.Drawing.Point(337, 7);
            this.radGroupBox4.Name = "radGroupBox4";
            this.radGroupBox4.Size = new System.Drawing.Size(324, 669);
            this.radGroupBox4.TabIndex = 3;
            this.radGroupBox4.Text = "File No having Status = Engage";
            this.radGroupBox4.ThemeName = "TelerikMetro";
            // 
            // grdEngageFiles
            // 
            this.grdEngageFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdEngageFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdEngageFiles.Location = new System.Drawing.Point(6, 22);
            // 
            // 
            // 
            this.grdEngageFiles.MasterTemplate.AllowAddNewRow = false;
            this.grdEngageFiles.MasterTemplate.AllowColumnReorder = false;
            this.grdEngageFiles.MasterTemplate.AllowSearchRow = true;
            this.grdEngageFiles.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn3.FieldName = "FileMapKey";
            gridViewTextBoxColumn3.HeaderText = "FileMapKey";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "naFileMapKey";
            gridViewTextBoxColumn4.FieldName = "FileNo";
            gridViewTextBoxColumn4.HeaderText = "FileNo";
            gridViewTextBoxColumn4.Name = "naFileNo";
            gridViewTextBoxColumn4.Width = 292;
            this.grdEngageFiles.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.grdEngageFiles.MasterTemplate.EnableFiltering = true;
            this.grdEngageFiles.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grdEngageFiles.Name = "grdEngageFiles";
            this.grdEngageFiles.ReadOnly = true;
            this.grdEngageFiles.Size = new System.Drawing.Size(313, 642);
            this.grdEngageFiles.TabIndex = 0;
            this.grdEngageFiles.Text = "radGridView1";
            this.grdEngageFiles.ThemeName = "TelerikMetro";
            // 
            // radGroupBox5
            // 
            this.radGroupBox5.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.radGroupBox5.Controls.Add(this.grdFile_Complete);
            this.radGroupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox5.HeaderText = "File No having Status = Complete";
            this.radGroupBox5.Location = new System.Drawing.Point(667, 7);
            this.radGroupBox5.Name = "radGroupBox5";
            this.radGroupBox5.Size = new System.Drawing.Size(324, 669);
            this.radGroupBox5.TabIndex = 4;
            this.radGroupBox5.Text = "File No having Status = Complete";
            this.radGroupBox5.ThemeName = "TelerikMetro";
            // 
            // grdFile_Complete
            // 
            this.grdFile_Complete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdFile_Complete.Location = new System.Drawing.Point(6, 22);
            // 
            // 
            // 
            this.grdFile_Complete.MasterTemplate.AllowAddNewRow = false;
            this.grdFile_Complete.MasterTemplate.AllowColumnReorder = false;
            this.grdFile_Complete.MasterTemplate.AllowSearchRow = true;
            this.grdFile_Complete.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn5.FieldName = "FileMapKey";
            gridViewTextBoxColumn5.HeaderText = "FileMapKey";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "naFileMapKey";
            gridViewTextBoxColumn6.FieldName = "FileNo";
            gridViewTextBoxColumn6.HeaderText = "FileNo";
            gridViewTextBoxColumn6.Name = "naFileNo";
            gridViewTextBoxColumn6.Width = 292;
            this.grdFile_Complete.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.grdFile_Complete.MasterTemplate.EnableFiltering = true;
            this.grdFile_Complete.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.grdFile_Complete.Name = "grdFile_Complete";
            this.grdFile_Complete.ReadOnly = true;
            this.grdFile_Complete.Size = new System.Drawing.Size(313, 642);
            this.grdFile_Complete.TabIndex = 0;
            this.grdFile_Complete.Text = "radGridView1";
            this.grdFile_Complete.ThemeName = "TelerikMetro";
            // 
            // frmTransferBasket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 693);
            this.Controls.Add(this.radGroupBox5);
            this.Controls.Add(this.radGroupBox4);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dddfd);
            this.Name = "frmTransferBasket";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmTransferBasket";
            this.Load += new System.EventHandler(this.frmTransferBasket_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dddfd)).EndInit();
            this.dddfd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFile_MultiOwner.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFile_MultiOwner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).EndInit();
            this.radGroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEngageFiles.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEngageFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox5)).EndInit();
            this.radGroupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFile_Complete.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFile_Complete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox dddfd;
        private Telerik.WinControls.UI.RadGridView grdFile_MultiOwner;
        private Telerik.WinControls.RadThemeManager radThemeManager1;
        private Telerik.WinControls.UI.RadButton btnRefresh;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox4;
        private Telerik.WinControls.UI.RadGridView grdEngageFiles;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox5;
        private Telerik.WinControls.UI.RadGridView grdFile_Complete;
    }
}
