namespace PeshawarDHASW.Application_Layer.NDC.NDCCheckListMap
{
    partial class frmNDCCheckListMapSearch
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.telerikMetroBlueTheme1 = new Telerik.WinControls.Themes.TelerikMetroBlueTheme();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.grdChecklist = new Telerik.WinControls.UI.RadGridView();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdChecklist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChecklist.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox2.Controls.Add(this.grdChecklist);
            this.radGroupBox2.HeaderText = "Checklist";
            this.radGroupBox2.Location = new System.Drawing.Point(12, 12);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(1150, 541);
            this.radGroupBox2.TabIndex = 3;
            this.radGroupBox2.Text = "Checklist";
            // 
            // grdChecklist
            // 
            this.grdChecklist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdChecklist.Location = new System.Drawing.Point(4, 16);
            // 
            // 
            // 
            this.grdChecklist.MasterTemplate.AllowAddNewRow = false;
            this.grdChecklist.MasterTemplate.AllowColumnReorder = false;
            this.grdChecklist.MasterTemplate.AllowSearchRow = true;
            this.grdChecklist.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "NDC_ItemID";
            gridViewTextBoxColumn1.HeaderText = "NDC ItemID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "NDC_ItemID";
            gridViewTextBoxColumn2.FieldName = "Category";
            gridViewTextBoxColumn2.HeaderText = "Category";
            gridViewTextBoxColumn2.Name = "Category";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 206;
            gridViewTextBoxColumn3.FieldName = "Particular";
            gridViewTextBoxColumn3.HeaderText = "Particular";
            gridViewTextBoxColumn3.Name = "Particular";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 206;
            gridViewTextBoxColumn4.FieldName = "NDC_Map_ID";
            gridViewTextBoxColumn4.HeaderText = "NDC_Map_ID";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "NDC_Map_ID";
            gridViewTextBoxColumn4.Width = 47;
            gridViewTextBoxColumn5.FieldName = "CheckListStatus";
            gridViewTextBoxColumn5.HeaderText = "CheckListStatus";
            gridViewTextBoxColumn5.Name = "CheckListStatus";
            gridViewTextBoxColumn5.Width = 236;
            gridViewTextBoxColumn6.FieldName = "CheckListRemarks";
            gridViewTextBoxColumn6.HeaderText = "CheckListRemarks";
            gridViewTextBoxColumn6.Name = "CheckListRemarks";
            gridViewTextBoxColumn6.Width = 269;
            gridViewTextBoxColumn7.FieldName = "Detail";
            gridViewTextBoxColumn7.HeaderText = "Detail";
            gridViewTextBoxColumn7.Name = "Detail";
            gridViewTextBoxColumn7.Width = 207;
            this.grdChecklist.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7});
            this.grdChecklist.MasterTemplate.EnableFiltering = true;
            this.grdChecklist.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdChecklist.Name = "grdChecklist";
            this.grdChecklist.Size = new System.Drawing.Size(1141, 520);
            this.grdChecklist.TabIndex = 0;
            this.grdChecklist.Text = "Check Lists";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(847, 559);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(315, 38);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.Visible = false;
            // 
            // frmNDCCheckListMapSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 607);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.radGroupBox2);
            this.Name = "frmNDCCheckListMapSearch";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmNDCCheckListMapSearch";
            this.ThemeName = "TelerikMetroBlue";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNDCCheckListMapSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdChecklist.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChecklist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroBlueTheme telerikMetroBlueTheme1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadGridView grdChecklist;
    }
}
