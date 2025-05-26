namespace PeshawarDHASW.Application_Layer.Installment.Discount
{
    partial class frmDiscountSummaryReport
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.grdAllDiscountInfo = new Telerik.WinControls.UI.RadGridView();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            ((System.ComponentModel.ISupportInitialize)(this.grdAllDiscountInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAllDiscountInfo.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // grdAllDiscountInfo
            // 
            this.grdAllDiscountInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAllDiscountInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grdAllDiscountInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdAllDiscountInfo.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.grdAllDiscountInfo.ForeColor = System.Drawing.Color.Black;
            this.grdAllDiscountInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdAllDiscountInfo.Location = new System.Drawing.Point(1, 28);
            // 
            // 
            // 
            this.grdAllDiscountInfo.MasterTemplate.AllowAddNewRow = false;
            this.grdAllDiscountInfo.MasterTemplate.AllowColumnReorder = false;
            this.grdAllDiscountInfo.MasterTemplate.AllowSearchRow = true;
            gridViewTextBoxColumn1.FieldName = "TRXID";
            gridViewTextBoxColumn1.HeaderText = "TRXID";
            gridViewTextBoxColumn1.Name = "TRXID";
            gridViewTextBoxColumn2.FieldName = "FileNo";
            gridViewTextBoxColumn2.HeaderText = "FileNo";
            gridViewTextBoxColumn2.Name = "FileNo";
            gridViewTextBoxColumn3.FieldName = "FileLock";
            gridViewTextBoxColumn3.HeaderText = "FileLock";
            gridViewTextBoxColumn3.Name = "FileLock";
            gridViewTextBoxColumn4.FieldName = "MembershipNo";
            gridViewTextBoxColumn4.HeaderText = "MembershipNo";
            gridViewTextBoxColumn4.Name = "MembershipNo";
            gridViewTextBoxColumn5.FieldName = "MemberName";
            gridViewTextBoxColumn5.HeaderText = "Owner Name";
            gridViewTextBoxColumn5.Name = "MemberName";
            gridViewTextBoxColumn6.FieldName = "DiscountType";
            gridViewTextBoxColumn6.HeaderText = "DiscountType";
            gridViewTextBoxColumn6.Name = "DiscountType";
            gridViewTextBoxColumn7.FieldName = "DiscountAmount";
            gridViewTextBoxColumn7.HeaderText = "DiscountAmount";
            gridViewTextBoxColumn7.Name = "DiscountAmount";
            gridViewTextBoxColumn8.FieldName = "DateofDiscount";
            gridViewTextBoxColumn8.HeaderText = "DateofDiscount";
            gridViewTextBoxColumn8.Name = "DateofDiscount";
            gridViewTextBoxColumn9.FieldName = "DiscountStatus";
            gridViewTextBoxColumn9.HeaderText = "DiscountStatus";
            gridViewTextBoxColumn9.Name = "DiscountStatus";
            gridViewTextBoxColumn10.FieldName = "RequestBy";
            gridViewTextBoxColumn10.HeaderText = "RequestBy";
            gridViewTextBoxColumn10.Name = "RequestBy";
            gridViewTextBoxColumn11.FieldName = "RequestDatetime";
            gridViewTextBoxColumn11.HeaderText = "RequestDatetime";
            gridViewTextBoxColumn11.Name = "RequestDatetime";
            gridViewTextBoxColumn12.FieldName = "RequestRemarks";
            gridViewTextBoxColumn12.HeaderText = "RequestRemarks";
            gridViewTextBoxColumn12.Name = "RequestRemarks";
            gridViewTextBoxColumn13.FieldName = "ApprovedBy";
            gridViewTextBoxColumn13.HeaderText = "ApprovedBy";
            gridViewTextBoxColumn13.Name = "ApprovedBy";
            gridViewTextBoxColumn14.FieldName = "ApprovedDate";
            gridViewTextBoxColumn14.HeaderText = "ApprovedDate";
            gridViewTextBoxColumn14.Name = "ApprovedDate";
            gridViewTextBoxColumn15.FieldName = "ApprovedRemarksa";
            gridViewTextBoxColumn15.HeaderText = "ApprovedRemark";
            gridViewTextBoxColumn15.Name = "ApprovedRemarksa";
            this.grdAllDiscountInfo.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewTextBoxColumn15});
            this.grdAllDiscountInfo.MasterTemplate.EnableFiltering = true;
            this.grdAllDiscountInfo.MasterTemplate.ShowFilterCellOperatorText = false;
            this.grdAllDiscountInfo.MasterTemplate.ShowFilteringRow = false;
            this.grdAllDiscountInfo.MasterTemplate.ShowHeaderCellButtons = true;
            this.grdAllDiscountInfo.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdAllDiscountInfo.Name = "grdAllDiscountInfo";
            this.grdAllDiscountInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grdAllDiscountInfo.ShowHeaderCellButtons = true;
            this.grdAllDiscountInfo.Size = new System.Drawing.Size(954, 348);
            this.grdAllDiscountInfo.TabIndex = 25;
            this.grdAllDiscountInfo.Text = "radGridView1";
            this.grdAllDiscountInfo.ThemeName = "TelerikMetro";
            // 
            // radButton1
            // 
            this.radButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radButton1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButton1.Location = new System.Drawing.Point(842, 1);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(110, 24);
            this.radButton1.TabIndex = 26;
            this.radButton1.Text = "Export to Excel";
            this.radButton1.ThemeName = "TelerikMetro";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // frmDiscountSummaryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 379);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.grdAllDiscountInfo);
            this.Name = "frmDiscountSummaryReport";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmDiscountSummaryReport";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.frmDiscountSummaryReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdAllDiscountInfo.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAllDiscountInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grdAllDiscountInfo;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
    }
}
