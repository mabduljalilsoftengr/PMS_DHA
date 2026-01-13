namespace PeshawarDHASW.Application_Layer.FileMap.ByBack
{
    partial class frmLandProviderQuoaDetail_Specific
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.grddata = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grddata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grddata.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(938, 686);
            this.radGroupBox1.TabIndex = 0;
            // 
            // grddata
            // 
            this.grddata.Location = new System.Drawing.Point(17, 19);
            // 
            // 
            // 
            this.grddata.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "ByBackQuota";
            gridViewTextBoxColumn1.HeaderText = "Total BuyBack Files";
            gridViewTextBoxColumn1.Name = "ByBackQuota";
            gridViewTextBoxColumn1.Width = 130;
            gridViewTextBoxColumn2.FieldName = "FileNo";
            gridViewTextBoxColumn2.HeaderText = "File No";
            gridViewTextBoxColumn2.Name = "FileNo";
            gridViewTextBoxColumn2.Width = 135;
            gridViewTextBoxColumn3.FieldName = "TotalReceivedAmountFromCust";
            gridViewTextBoxColumn3.HeaderText = "Total Received Amount";
            gridViewTextBoxColumn3.Name = "TotalReceivedAmountFromCust";
            gridViewTextBoxColumn3.Width = 131;
            gridViewTextBoxColumn4.FieldName = "CheckNo";
            gridViewTextBoxColumn4.HeaderText = "Cheque No";
            gridViewTextBoxColumn4.Name = "CheckNo";
            gridViewTextBoxColumn4.Width = 121;
            gridViewTextBoxColumn5.FieldName = "Amount";
            gridViewTextBoxColumn5.HeaderText = "Paid Amount";
            gridViewTextBoxColumn5.Name = "Amount";
            gridViewTextBoxColumn5.Width = 169;
            gridViewTextBoxColumn6.FieldName = "Remarks";
            gridViewTextBoxColumn6.HeaderText = "Remarks";
            gridViewTextBoxColumn6.Name = "Remarks";
            gridViewTextBoxColumn6.Width = 96;
            gridViewTextBoxColumn7.FieldName = "IsByBack_NewQuotaAdded";
            gridViewTextBoxColumn7.HeaderText = "IsByBack_NewQuotaAdded";
            gridViewTextBoxColumn7.IsVisible = false;
            gridViewTextBoxColumn7.Name = "IsByBack_NewQuotaAdded";
            gridViewTextBoxColumn7.Width = 127;
            gridViewTextBoxColumn8.FieldName = "DateofNewQota_ByBack";
            gridViewTextBoxColumn8.HeaderText = "Date";
            gridViewTextBoxColumn8.Name = "DateofNewQota_ByBack";
            gridViewTextBoxColumn8.Width = 131;
            gridViewTextBoxColumn9.FieldName = "IsFilesIssued_RawLand";
            gridViewTextBoxColumn9.HeaderText = "FilesIssued/RawLand";
            gridViewTextBoxColumn9.IsVisible = false;
            gridViewTextBoxColumn9.Name = "IsFilesIssued_RawLand";
            gridViewTextBoxColumn9.Width = 160;
            this.grddata.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9});
            this.grddata.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grddata.Name = "grddata";
            this.grddata.Size = new System.Drawing.Size(928, 671);
            this.grddata.TabIndex = 0;
            this.grddata.Text = "radGridView1";
            // 
            // frmLandProviderQuoaDetail_Specific
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 710);
            this.Controls.Add(this.grddata);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmLandProviderQuoaDetail_Specific";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmLandProviderQuotaDetail_Specific";
            this.Load += new System.EventHandler(this.frmLandProviderQuoaDetail_Specific_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grddata.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grddata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView grddata;
    }
}
