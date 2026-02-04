namespace PeshawarDHASW.Application_Layer.NDC.NDC_CheckList
{
    partial class frmNDCCheckListSearch
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.telerikMetroBlueTheme1 = new Telerik.WinControls.Themes.TelerikMetroBlueTheme();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.grdCheckListSearch = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCheckListSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCheckListSearch.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.grdCheckListSearch);
            this.radGroupBox1.HeaderText = "Check list";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(786, 395);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Check list";
            // 
            // grdCheckListSearch
            // 
            this.grdCheckListSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdCheckListSearch.Location = new System.Drawing.Point(5, 21);
            // 
            // 
            // 
            this.grdCheckListSearch.MasterTemplate.AllowAddNewRow = false;
            this.grdCheckListSearch.MasterTemplate.AllowColumnReorder = false;
            this.grdCheckListSearch.MasterTemplate.AllowSearchRow = true;
            this.grdCheckListSearch.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "NDC_ItemID";
            gridViewTextBoxColumn1.HeaderText = "NDC_ItemID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "NDC_ItemID";
            gridViewTextBoxColumn2.FieldName = "Category";
            gridViewTextBoxColumn2.HeaderText = "Category";
            gridViewTextBoxColumn2.Name = "Category";
            gridViewTextBoxColumn2.Width = 190;
            gridViewTextBoxColumn3.FieldName = "Particular";
            gridViewTextBoxColumn3.HeaderText = "Particular";
            gridViewTextBoxColumn3.Name = "Particular";
            gridViewTextBoxColumn3.Width = 190;
            gridViewTextBoxColumn4.FieldName = "Remarks";
            gridViewTextBoxColumn4.HeaderText = "Remarks";
            gridViewTextBoxColumn4.Name = "Remarks";
            gridViewTextBoxColumn4.Width = 190;
            gridViewTextBoxColumn5.FieldName = "Status";
            gridViewTextBoxColumn5.HeaderText = "Status";
            gridViewTextBoxColumn5.Name = "Status";
            gridViewTextBoxColumn5.Width = 188;
            this.grdCheckListSearch.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.grdCheckListSearch.MasterTemplate.EnableFiltering = true;
            this.grdCheckListSearch.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdCheckListSearch.Name = "grdCheckListSearch";
            this.grdCheckListSearch.ReadOnly = true;
            this.grdCheckListSearch.Size = new System.Drawing.Size(776, 369);
            this.grdCheckListSearch.TabIndex = 0;
            this.grdCheckListSearch.Text = "radGridView1";
            // 
            // frmNDCCheckListSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 415);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmNDCCheckListSearch";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmCheckListSearch";
            this.ThemeName = "TelerikMetroBlue";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNDCCheckListSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCheckListSearch.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCheckListSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroBlueTheme telerikMetroBlueTheme1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView grdCheckListSearch;
    }
}
