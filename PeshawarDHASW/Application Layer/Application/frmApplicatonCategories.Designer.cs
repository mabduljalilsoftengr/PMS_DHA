namespace PeshawarDHASW.Application_Layer.Application
{
    partial class frmApplicatonCategories
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtQuota = new Telerik.WinControls.UI.RadTextBox();
            this.txtCategory = new Telerik.WinControls.UI.RadTextBox();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnSearch = new Telerik.WinControls.UI.RadButton();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txtCategorySearch = new Telerik.WinControls.UI.RadTextBox();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.grdCategoryInfo = new Telerik.WinControls.UI.RadGridView();
            this.telerikMetroBlueTheme1 = new Telerik.WinControls.Themes.TelerikMetroBlueTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuota)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategorySearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCategoryInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCategoryInfo.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.btnSave);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.txtQuota);
            this.radGroupBox1.Controls.Add(this.txtCategory);
            this.radGroupBox1.HeaderText = "Selected Record Information";
            this.radGroupBox1.Location = new System.Drawing.Point(550, 81);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(248, 178);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Selected Record Information";
            this.radGroupBox1.ThemeName = "TelerikMetroBlue";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(21, 116);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(206, 37);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.ThemeName = "TelerikMetro";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(21, 67);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(37, 18);
            this.radLabel2.TabIndex = 9;
            this.radLabel2.Text = "Quota";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(17, 28);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(59, 18);
            this.radLabel1.TabIndex = 7;
            this.radLabel1.Text = "Categories";
            // 
            // txtQuota
            // 
            this.txtQuota.Location = new System.Drawing.Point(83, 66);
            this.txtQuota.Name = "txtQuota";
            this.txtQuota.Size = new System.Drawing.Size(145, 20);
            this.txtQuota.TabIndex = 8;
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(83, 26);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(145, 20);
            this.txtCategory.TabIndex = 6;
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.btnSearch);
            this.radGroupBox2.Controls.Add(this.radLabel3);
            this.radGroupBox2.Controls.Add(this.txtCategorySearch);
            this.radGroupBox2.HeaderText = "Search Category";
            this.radGroupBox2.Location = new System.Drawing.Point(13, 13);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(785, 60);
            this.radGroupBox2.TabIndex = 1;
            this.radGroupBox2.Text = "Search Category";
            this.radGroupBox2.ThemeName = "TelerikMetroBlue";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(278, 26);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(110, 24);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.ThemeName = "TelerikMetro";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(17, 30);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(59, 18);
            this.radLabel3.TabIndex = 9;
            this.radLabel3.Text = "Categories";
            // 
            // txtCategorySearch
            // 
            this.txtCategorySearch.Location = new System.Drawing.Point(84, 28);
            this.txtCategorySearch.Name = "txtCategorySearch";
            this.txtCategorySearch.Size = new System.Drawing.Size(187, 20);
            this.txtCategorySearch.TabIndex = 8;
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox3.Controls.Add(this.grdCategoryInfo);
            this.radGroupBox3.HeaderText = "Category Information";
            this.radGroupBox3.Location = new System.Drawing.Point(13, 80);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Size = new System.Drawing.Size(531, 282);
            this.radGroupBox3.TabIndex = 2;
            this.radGroupBox3.Text = "Category Information";
            this.radGroupBox3.ThemeName = "TelerikMetroBlue";
            // 
            // grdCategoryInfo
            // 
            this.grdCategoryInfo.Location = new System.Drawing.Point(0, 27);
            // 
            // 
            // 
            this.grdCategoryInfo.MasterTemplate.AllowAddNewRow = false;
            this.grdCategoryInfo.MasterTemplate.AllowColumnReorder = false;
            this.grdCategoryInfo.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "ID";
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "ID";
            gridViewTextBoxColumn2.FieldName = "Categories";
            gridViewTextBoxColumn2.HeaderText = "Category";
            gridViewTextBoxColumn2.Name = "Categories";
            gridViewTextBoxColumn2.Width = 234;
            gridViewTextBoxColumn3.FieldName = "Quota";
            gridViewTextBoxColumn3.HeaderText = "Quota";
            gridViewTextBoxColumn3.Name = "Quota";
            gridViewTextBoxColumn3.Width = 233;
            gridViewCommandColumn1.DefaultText = "Modify";
            gridViewCommandColumn1.FieldName = "Modify";
            gridViewCommandColumn1.HeaderText = "Modify";
            gridViewCommandColumn1.Name = "Modify";
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 45;
            this.grdCategoryInfo.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewCommandColumn1});
            this.grdCategoryInfo.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdCategoryInfo.Name = "grdCategoryInfo";
            this.grdCategoryInfo.ReadOnly = true;
            this.grdCategoryInfo.Size = new System.Drawing.Size(531, 255);
            this.grdCategoryInfo.TabIndex = 0;
            this.grdCategoryInfo.Text = "Category Data Grid";
            this.grdCategoryInfo.ThemeName = "TelerikMetro";
            this.grdCategoryInfo.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdCategoryInfo_CellClick);
            // 
            // frmApplicatonCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 374);
            this.Controls.Add(this.radGroupBox3);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmApplicatonCategories";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Applicaton   Categories";
            this.ThemeName = "TelerikMetroBlue";
            this.Load += new System.EventHandler(this.frmApplicatonCategories_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuota)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategorySearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCategoryInfo.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCategoryInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtQuota;
        private Telerik.WinControls.UI.RadTextBox txtCategory;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadButton btnSearch;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox txtCategorySearch;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private Telerik.WinControls.Themes.TelerikMetroBlueTheme telerikMetroBlueTheme1;
        private Telerik.WinControls.UI.RadGridView grdCategoryInfo;
    }
}