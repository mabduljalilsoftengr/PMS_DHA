namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    partial class frmReadyForTransferReport
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.grd_ReadyForReport = new Telerik.WinControls.UI.RadGridView();
            this.btnRefresh = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.dtpTransferDate = new Telerik.WinControls.UI.RadDateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_ReadyForReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_ReadyForReport.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTransferDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox2.Controls.Add(this.grd_ReadyForReport);
            this.radGroupBox2.HeaderText = "Ready For Report";
            this.radGroupBox2.Location = new System.Drawing.Point(2, 54);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(1088, 654);
            this.radGroupBox2.TabIndex = 2;
            this.radGroupBox2.Text = "Ready For Report";
            // 
            // grd_ReadyForReport
            // 
            this.grd_ReadyForReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd_ReadyForReport.EnableKeyMap = true;
            this.grd_ReadyForReport.Location = new System.Drawing.Point(5, 21);
            // 
            // 
            // 
            this.grd_ReadyForReport.MasterTemplate.AllowAddNewRow = false;
            this.grd_ReadyForReport.MasterTemplate.AllowColumnReorder = false;
            this.grd_ReadyForReport.MasterTemplate.AllowSearchRow = true;
            this.grd_ReadyForReport.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "NDCNo";
            gridViewTextBoxColumn1.HeaderText = "NDCNo";
            gridViewTextBoxColumn1.Name = "NDCNo";
            gridViewTextBoxColumn1.Width = 116;
            gridViewTextBoxColumn2.FieldName = "SellerMS_String";
            gridViewTextBoxColumn2.HeaderText = "Seller";
            gridViewTextBoxColumn2.Name = "SellerMS_String";
            gridViewTextBoxColumn2.Width = 200;
            gridViewTextBoxColumn3.FieldName = "BuyerMS_String";
            gridViewTextBoxColumn3.HeaderText = "Buyer";
            gridViewTextBoxColumn3.Name = "BuyerMS_String";
            gridViewTextBoxColumn3.Width = 197;
            gridViewTextBoxColumn4.FieldName = "FileNo";
            gridViewTextBoxColumn4.HeaderText = "File No.";
            gridViewTextBoxColumn4.Name = "FileNo";
            gridViewTextBoxColumn4.Width = 153;
            gridViewTextBoxColumn5.FieldName = "PlotSize";
            gridViewTextBoxColumn5.HeaderText = "Plot Size";
            gridViewTextBoxColumn5.Name = "PlotSize";
            gridViewTextBoxColumn5.Width = 76;
            gridViewTextBoxColumn6.FieldName = "RequestedBy";
            gridViewTextBoxColumn6.HeaderText = "Propety Dealer";
            gridViewTextBoxColumn6.Name = "RequestedBy";
            gridViewTextBoxColumn6.Width = 238;
            gridViewTextBoxColumn7.FieldName = "TransferNo";
            gridViewTextBoxColumn7.HeaderText = "Transfer No";
            gridViewTextBoxColumn7.Name = "TransferNo";
            gridViewTextBoxColumn7.Width = 83;
            gridViewTextBoxColumn8.FieldName = "PurchaseTypeID";
            gridViewTextBoxColumn8.HeaderText = "PurchaseTypeID";
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.Name = "PurchaseTypeID";
            gridViewTextBoxColumn8.Width = 46;
            this.grd_ReadyForReport.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8});
            this.grd_ReadyForReport.MasterTemplate.EnableGrouping = false;
            this.grd_ReadyForReport.MasterTemplate.EnableSorting = false;
            this.grd_ReadyForReport.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grd_ReadyForReport.Name = "grd_ReadyForReport";
            this.grd_ReadyForReport.Size = new System.Drawing.Size(1078, 621);
            this.grd_ReadyForReport.TabIndex = 1;
            this.grd_ReadyForReport.Text = "radGridView1";
            this.grd_ReadyForReport.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grd_ReadyForReport_CellClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(337, 9);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(155, 28);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(6, 9);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(109, 25);
            this.radLabel1.TabIndex = 4;
            this.radLabel1.Text = "Transfer Date.";
            // 
            // dtpTransferDate
            // 
            this.dtpTransferDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTransferDate.Location = new System.Drawing.Point(117, 10);
            this.dtpTransferDate.Name = "dtpTransferDate";
            this.dtpTransferDate.Size = new System.Drawing.Size(211, 27);
            this.dtpTransferDate.TabIndex = 5;
            this.dtpTransferDate.TabStop = false;
            this.dtpTransferDate.Value = new System.DateTime(((long)(0)));
            // 
            // frmReadyForTransferReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 726);
            this.Controls.Add(this.dtpTransferDate);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.radGroupBox2);
            this.Name = "frmReadyForTransferReport";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Transfer Report";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.frmReadyForReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_ReadyForReport.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_ReadyForReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTransferDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadGridView grd_ReadyForReport;
        private Telerik.WinControls.UI.RadButton btnRefresh;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDateTimePicker dtpTransferDate;
    }
}
