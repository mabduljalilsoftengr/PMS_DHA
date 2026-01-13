namespace PeshawarDHASW.Application_Layer.Installment.Surcharge
{
    partial class frmSurchageWaiveOffRequest
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
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn3 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn5 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn17 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn6 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn18 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn5 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn6 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            this.grd_DDTransferBasket = new Telerik.WinControls.UI.RadGridView();
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtfileno = new Telerik.WinControls.UI.RadTextBox();
            this.btnRequest = new Telerik.WinControls.UI.RadButton();
            this.btnExporttoExcel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.grd_DDTransferBasket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_DDTransferBasket.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtfileno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRequest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExporttoExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // grd_DDTransferBasket
            // 
            this.grd_DDTransferBasket.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd_DDTransferBasket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grd_DDTransferBasket.Cursor = System.Windows.Forms.Cursors.Default;
            this.grd_DDTransferBasket.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.grd_DDTransferBasket.ForeColor = System.Drawing.Color.Black;
            this.grd_DDTransferBasket.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grd_DDTransferBasket.Location = new System.Drawing.Point(3, 69);
            // 
            // 
            // 
            this.grd_DDTransferBasket.MasterTemplate.AllowAddNewRow = false;
            this.grd_DDTransferBasket.MasterTemplate.AllowColumnReorder = false;
            this.grd_DDTransferBasket.MasterTemplate.AllowSearchRow = true;
            this.grd_DDTransferBasket.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewDecimalColumn3.EnableExpressionEditor = false;
            gridViewDecimalColumn3.FieldName = "RowNum";
            gridViewDecimalColumn3.HeaderText = "S.No";
            gridViewDecimalColumn3.Name = "RowNum";
            gridViewDecimalColumn3.Width = 93;
            gridViewTextBoxColumn13.EnableExpressionEditor = false;
            gridViewTextBoxColumn13.FieldName = "FileNo";
            gridViewTextBoxColumn13.HeaderText = "FileNo";
            gridViewTextBoxColumn13.Name = "FileNo";
            gridViewTextBoxColumn13.ReadOnly = true;
            gridViewTextBoxColumn13.Width = 153;
            gridViewTextBoxColumn14.EnableExpressionEditor = false;
            gridViewTextBoxColumn14.FieldName = "RequestBy";
            gridViewTextBoxColumn14.HeaderText = "Requested By";
            gridViewTextBoxColumn14.Name = "RequestBy";
            gridViewTextBoxColumn14.ReadOnly = true;
            gridViewTextBoxColumn14.Width = 153;
            gridViewTextBoxColumn15.EnableExpressionEditor = false;
            gridViewTextBoxColumn15.FieldName = "RequestRemarks";
            gridViewTextBoxColumn15.HeaderText = "Requester Remarks";
            gridViewTextBoxColumn15.Name = "RequestRemarks";
            gridViewTextBoxColumn15.ReadOnly = true;
            gridViewTextBoxColumn15.Width = 138;
            gridViewDateTimeColumn5.EnableExpressionEditor = false;
            gridViewDateTimeColumn5.FieldName = "RequestedDate";
            gridViewDateTimeColumn5.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            gridViewDateTimeColumn5.FormatString = "{0:dd/MMM/yyyy}";
            gridViewDateTimeColumn5.HeaderText = "Requested Date";
            gridViewDateTimeColumn5.Name = "RequestedDate";
            gridViewDateTimeColumn5.Width = 127;
            gridViewTextBoxColumn16.EnableExpressionEditor = false;
            gridViewTextBoxColumn16.FieldName = "Status";
            gridViewTextBoxColumn16.HeaderText = "Status";
            gridViewTextBoxColumn16.Name = "Status";
            gridViewTextBoxColumn16.ReadOnly = true;
            gridViewTextBoxColumn16.Width = 121;
            gridViewTextBoxColumn17.EnableExpressionEditor = false;
            gridViewTextBoxColumn17.FieldName = "ApprovalRemarks";
            gridViewTextBoxColumn17.HeaderText = "Approver Remarks";
            gridViewTextBoxColumn17.Name = "ApprovalRemarks";
            gridViewTextBoxColumn17.Width = 80;
            gridViewDateTimeColumn6.EnableExpressionEditor = false;
            gridViewDateTimeColumn6.FieldName = "ApprovalDate";
            gridViewDateTimeColumn6.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            gridViewDateTimeColumn6.HeaderText = "Approval/Cancellation Date";
            gridViewDateTimeColumn6.Name = "ApprovalDate";
            gridViewDateTimeColumn6.Width = 86;
            gridViewTextBoxColumn18.EnableExpressionEditor = false;
            gridViewTextBoxColumn18.FieldName = "SurWayOffMasID";
            gridViewTextBoxColumn18.HeaderText = "Transaction ID";
            gridViewTextBoxColumn18.Name = "SurWayOffMasID";
            gridViewTextBoxColumn18.Width = 99;
            gridViewCommandColumn5.DefaultText = "View";
            gridViewCommandColumn5.EnableExpressionEditor = false;
            gridViewCommandColumn5.FieldName = "ImageView";
            gridViewCommandColumn5.HeaderText = "Attachment";
            gridViewCommandColumn5.Name = "ImageView";
            gridViewCommandColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn5.UseDefaultText = true;
            gridViewCommandColumn5.Width = 149;
            gridViewCommandColumn6.DefaultText = "View/Edit";
            gridViewCommandColumn6.EnableExpressionEditor = false;
            gridViewCommandColumn6.FieldName = "ViewDetails";
            gridViewCommandColumn6.HeaderText = "View Details";
            gridViewCommandColumn6.Name = "ViewDetails";
            gridViewCommandColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn6.UseDefaultText = true;
            gridViewCommandColumn6.Width = 79;
            this.grd_DDTransferBasket.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn3,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewTextBoxColumn15,
            gridViewDateTimeColumn5,
            gridViewTextBoxColumn16,
            gridViewTextBoxColumn17,
            gridViewDateTimeColumn6,
            gridViewTextBoxColumn18,
            gridViewCommandColumn5,
            gridViewCommandColumn6});
            this.grd_DDTransferBasket.MasterTemplate.EnableFiltering = true;
            this.grd_DDTransferBasket.MasterTemplate.EnableGrouping = false;
            this.grd_DDTransferBasket.MasterTemplate.ShowFilteringRow = false;
            this.grd_DDTransferBasket.MasterTemplate.ShowHeaderCellButtons = true;
            this.grd_DDTransferBasket.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.grd_DDTransferBasket.Name = "grd_DDTransferBasket";
            this.grd_DDTransferBasket.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grd_DDTransferBasket.ShowHeaderCellButtons = true;
            this.grd_DDTransferBasket.Size = new System.Drawing.Size(1289, 591);
            this.grd_DDTransferBasket.TabIndex = 0;
            this.grd_DDTransferBasket.ThemeName = "TelerikMetro";
            this.grd_DDTransferBasket.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grd_DDTransferBasket_CellClick);
            // 
            // radPageView1
            // 
            this.radPageView1.Controls.Add(this.radPageViewPage1);
            this.radPageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPageView1.Location = new System.Drawing.Point(0, 0);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.radPageViewPage1;
            this.radPageView1.Size = new System.Drawing.Size(1302, 698);
            this.radPageView1.TabIndex = 3;
            this.radPageView1.ThemeName = "TelerikMetro";
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Controls.Add(this.radLabel1);
            this.radPageViewPage1.Controls.Add(this.txtfileno);
            this.radPageViewPage1.Controls.Add(this.btnRequest);
            this.radPageViewPage1.Controls.Add(this.btnExporttoExcel);
            this.radPageViewPage1.Controls.Add(this.grd_DDTransferBasket);
            this.radPageViewPage1.ItemSize = new System.Drawing.SizeF(67F, 25F);
            this.radPageViewPage1.Location = new System.Drawing.Point(5, 31);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(1292, 662);
            this.radPageViewPage1.Text = "Surcharge";
            // 
            // radLabel1
            // 
            this.radLabel1.Enabled = false;
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(22, 19);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(63, 25);
            this.radLabel1.TabIndex = 24;
            this.radLabel1.Text = "File No.";
            // 
            // txtfileno
            // 
            this.txtfileno.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfileno.Location = new System.Drawing.Point(110, 17);
            this.txtfileno.Name = "txtfileno";
            this.txtfileno.Size = new System.Drawing.Size(325, 30);
            this.txtfileno.TabIndex = 25;
            this.txtfileno.ThemeName = "TelerikMetro";
            // 
            // btnRequest
            // 
            this.btnRequest.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRequest.Location = new System.Drawing.Point(456, 17);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(159, 30);
            this.btnRequest.TabIndex = 23;
            this.btnRequest.Text = "Search";
            this.btnRequest.ThemeName = "TelerikMetro";
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // btnExporttoExcel
            // 
            this.btnExporttoExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExporttoExcel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExporttoExcel.Location = new System.Drawing.Point(1141, 17);
            this.btnExporttoExcel.Name = "btnExporttoExcel";
            this.btnExporttoExcel.Size = new System.Drawing.Size(144, 46);
            this.btnExporttoExcel.TabIndex = 22;
            this.btnExporttoExcel.Text = "Export to Excel";
            this.btnExporttoExcel.ThemeName = "TelerikMetro";
            this.btnExporttoExcel.Click += new System.EventHandler(this.btnExporttoExcel_Click);
            // 
            // frmSurchageWaiveOffRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 698);
            this.Controls.Add(this.radPageView1);
            this.Name = "frmSurchageWaiveOffRequest";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Surcharge Wavier Old History";
            this.Load += new System.EventHandler(this.frmSurchageWaiveOffRequest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grd_DDTransferBasket.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_DDTransferBasket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            this.radPageViewPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtfileno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRequest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExporttoExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grd_DDTransferBasket;
        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private Telerik.WinControls.UI.RadButton btnExporttoExcel;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtfileno;
        private Telerik.WinControls.UI.RadButton btnRequest;
    }
}
