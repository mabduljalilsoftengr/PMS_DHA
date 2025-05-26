namespace PeshawarDHASW.Application_Layer.NDC.NDC_CheckList
{
    partial class frmNDC_CheckList_Binding_Updating
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
            this.txtNDCNo = new Telerik.WinControls.UI.RadTextBox();
            this.Find = new Telerik.WinControls.UI.RadButton();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.grdChecklist = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNDCNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Find)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdChecklist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChecklist.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.txtNDCNo);
            this.radGroupBox1.Controls.Add(this.Find);
            this.radGroupBox1.Controls.Add(this.radLabel3);
            this.radGroupBox1.HeaderText = "NDC Info";
            this.radGroupBox1.Location = new System.Drawing.Point(3, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1086, 63);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "NDC Info";
            // 
            // txtNDCNo
            // 
            this.txtNDCNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNDCNo.Location = new System.Drawing.Point(155, 23);
            this.txtNDCNo.Name = "txtNDCNo";
            this.txtNDCNo.Size = new System.Drawing.Size(193, 27);
            this.txtNDCNo.TabIndex = 4;
            this.txtNDCNo.Leave += new System.EventHandler(this.txtNDCNo_Leave);
            // 
            // Find
            // 
            this.Find.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Find.Location = new System.Drawing.Point(388, 22);
            this.Find.Name = "Find";
            this.Find.Size = new System.Drawing.Size(89, 28);
            this.Find.TabIndex = 3;
            this.Find.Text = "Find";
            this.Find.Click += new System.EventHandler(this.Find_Click);
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(27, 23);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(106, 25);
            this.radLabel3.TabIndex = 1;
            this.radLabel3.Text = "NDC Number";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.grdChecklist);
            this.radGroupBox2.HeaderText = "Checklist";
            this.radGroupBox2.Location = new System.Drawing.Point(3, 64);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(1086, 394);
            this.radGroupBox2.TabIndex = 1;
            this.radGroupBox2.Text = "Checklist";
            // 
            // grdChecklist
            // 
            this.grdChecklist.Location = new System.Drawing.Point(4, 23);
            // 
            // 
            // 
            this.grdChecklist.MasterTemplate.AllowAddNewRow = false;
            this.grdChecklist.MasterTemplate.AllowColumnReorder = false;
            this.grdChecklist.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "NDC_Map_ID";
            gridViewTextBoxColumn1.HeaderText = "NDC_Map_ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "NDC_Map_ID";
            gridViewTextBoxColumn1.Width = 47;
            gridViewTextBoxColumn2.FieldName = "NDC_ItemID";
            gridViewTextBoxColumn2.HeaderText = "NDC ItemID";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "NDC_ItemID";
            gridViewTextBoxColumn3.FieldName = "Category";
            gridViewTextBoxColumn3.HeaderText = "Category";
            gridViewTextBoxColumn3.Name = "Category";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 384;
            gridViewTextBoxColumn4.FieldName = "Particular";
            gridViewTextBoxColumn4.HeaderText = "Particular";
            gridViewTextBoxColumn4.Name = "Particular";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 506;
            gridViewTextBoxColumn5.FieldName = "Detail";
            gridViewTextBoxColumn5.HeaderText = "Detail(CPR No.)";
            gridViewTextBoxColumn5.Name = "Detail";
            gridViewTextBoxColumn5.Width = 168;
            this.grdChecklist.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.grdChecklist.MasterTemplate.EnableSorting = false;
            this.grdChecklist.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdChecklist.Name = "grdChecklist";
            this.grdChecklist.ShowGroupPanel = false;
            this.grdChecklist.Size = new System.Drawing.Size(1077, 366);
            this.grdChecklist.TabIndex = 0;
            this.grdChecklist.Text = "Check Lists";
            this.grdChecklist.CellEndEdit += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdChecklist_CellEndEdit);
            // 
            // frmNDC_CheckList_Binding_Updating
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 464);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmNDC_CheckList_Binding_Updating";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmNDC_CheckList_Binding_Updating";
            this.ThemeName = "TelerikMetroBlue";
            this.Load += new System.EventHandler(this.frmCheckListFilling_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNDCNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Find)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdChecklist.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChecklist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroBlueTheme telerikMetroBlueTheme1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton Find;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadGridView grdChecklist;
        private Telerik.WinControls.UI.RadTextBox txtNDCNo;
    }
}
