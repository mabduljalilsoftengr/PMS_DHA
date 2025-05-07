namespace PeshawarDHASW.Application_Layer.FileMap.ByBack
{
    partial class frmBuyBackReportForm
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
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.rdpstatus = new Telerik.WinControls.UI.RadDropDownList();
            this.btnsearch = new Telerik.WinControls.UI.RadButton();
            this.btnExcelExport = new Telerik.WinControls.UI.RadButton();
            this.grdreportdata = new Telerik.WinControls.UI.RadGridView();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdpstatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnsearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExcelExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdreportdata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdreportdata.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.rdpstatus);
            this.radGroupBox1.Controls.Add(this.btnsearch);
            this.radGroupBox1.Controls.Add(this.btnExcelExport);
            this.radGroupBox1.Controls.Add(this.grdreportdata);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGroupBox1.HeaderText = "Report";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(961, 588);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Report";
            this.radGroupBox1.ThemeName = "TelerikMetro";
            // 
            // rdpstatus
            // 
            this.rdpstatus.Location = new System.Drawing.Point(8, 22);
            this.rdpstatus.Name = "rdpstatus";
            this.rdpstatus.Size = new System.Drawing.Size(252, 24);
            this.rdpstatus.TabIndex = 3;
            this.rdpstatus.ThemeName = "TelerikMetro";
            // 
            // btnsearch
            // 
            this.btnsearch.Location = new System.Drawing.Point(266, 20);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(152, 29);
            this.btnsearch.TabIndex = 2;
            this.btnsearch.Text = "Search";
            this.btnsearch.ThemeName = "TelerikMetro";
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // btnExcelExport
            // 
            this.btnExcelExport.Location = new System.Drawing.Point(424, 21);
            this.btnExcelExport.Name = "btnExcelExport";
            this.btnExcelExport.Size = new System.Drawing.Size(152, 29);
            this.btnExcelExport.TabIndex = 1;
            this.btnExcelExport.Text = "Excel Report";
            this.btnExcelExport.ThemeName = "TelerikMetro";
            this.btnExcelExport.Click += new System.EventHandler(this.btnExcelExport_Click);
            // 
            // grdreportdata
            // 
            this.grdreportdata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdreportdata.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grdreportdata.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdreportdata.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.grdreportdata.ForeColor = System.Drawing.Color.Black;
            this.grdreportdata.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdreportdata.Location = new System.Drawing.Point(8, 55);
            // 
            // 
            // 
            this.grdreportdata.MasterTemplate.AllowAddNewRow = false;
            this.grdreportdata.MasterTemplate.AllowColumnReorder = false;
            this.grdreportdata.MasterTemplate.AllowSearchRow = true;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "SNo";
            gridViewTextBoxColumn1.HeaderText = "SNo";
            gridViewTextBoxColumn1.Name = "SNo";
            gridViewTextBoxColumn1.Width = 74;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "BID";
            gridViewTextBoxColumn2.HeaderText = "BID";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "BID";
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "InvestorName";
            gridViewTextBoxColumn3.HeaderText = "Investor Name";
            gridViewTextBoxColumn3.Name = "InvestorName";
            gridViewTextBoxColumn3.Width = 171;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "FileNo";
            gridViewTextBoxColumn4.HeaderText = "File No.";
            gridViewTextBoxColumn4.Name = "FileNo";
            gridViewTextBoxColumn4.Width = 103;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "SQYard";
            gridViewTextBoxColumn5.HeaderText = "SQYard";
            gridViewTextBoxColumn5.Name = "SQYard";
            gridViewTextBoxColumn5.Width = 143;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "TotalReceivedAmountFromCust";
            gridViewTextBoxColumn6.FormatString = "{0:#,###0.00;(#,###0.00);0}";
            gridViewTextBoxColumn6.HeaderText = "Total Received Amount";
            gridViewTextBoxColumn6.Name = "TotalReceivedAmountFromCust";
            gridViewTextBoxColumn6.Width = 144;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "Amount";
            gridViewTextBoxColumn7.FormatString = "{0:#,###0.00;(#,###0.00);0}";
            gridViewTextBoxColumn7.HeaderText = "Payble Amount";
            gridViewTextBoxColumn7.Name = "Amount";
            gridViewTextBoxColumn7.Width = 124;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "CheckNo";
            gridViewTextBoxColumn8.HeaderText = "Cheque No.";
            gridViewTextBoxColumn8.Name = "CheckNo";
            gridViewTextBoxColumn8.Width = 104;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "PerFileRate";
            gridViewTextBoxColumn9.FormatString = "{0:#,###0.00;(#,###0.00);0}";
            gridViewTextBoxColumn9.HeaderText = "Per File Rate";
            gridViewTextBoxColumn9.Name = "PerFileRate";
            gridViewTextBoxColumn9.Width = 129;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "DateofNewQota_ByBack";
            gridViewTextBoxColumn10.HeaderText = "BuyBack Date";
            gridViewTextBoxColumn10.Name = "DateofNewQota_ByBack";
            gridViewTextBoxColumn10.Width = 115;
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.FieldName = "Status";
            gridViewTextBoxColumn11.HeaderText = "Status";
            gridViewTextBoxColumn11.Name = "Status";
            gridViewTextBoxColumn11.Width = 80;
            gridViewTextBoxColumn12.EnableExpressionEditor = false;
            gridViewTextBoxColumn12.FieldName = "PlotSize";
            gridViewTextBoxColumn12.HeaderText = "Plot Size";
            gridViewTextBoxColumn12.Name = "PlotSize";
            gridViewTextBoxColumn12.Width = 81;
            gridViewCommandColumn1.DefaultText = "View";
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.FieldName = "btnview";
            gridViewCommandColumn1.HeaderText = "View";
            gridViewCommandColumn1.Name = "btnview";
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 76;
            this.grdreportdata.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
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
            gridViewCommandColumn1});
            this.grdreportdata.MasterTemplate.EnableSorting = false;
            this.grdreportdata.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdreportdata.Name = "grdreportdata";
            this.grdreportdata.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grdreportdata.Size = new System.Drawing.Size(948, 522);
            this.grdreportdata.TabIndex = 0;
            this.grdreportdata.Text = "radGridView1";
            this.grdreportdata.ThemeName = "TelerikMetro";
            this.grdreportdata.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdreportdata_CellClick);
            // 
            // frmBuyBackReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 588);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmBuyBackReportForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmBuyBackReportForm";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.frmBuyBackReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdpstatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnsearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExcelExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdreportdata.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdreportdata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView grdreportdata;
        private Telerik.WinControls.UI.RadButton btnExcelExport;
        private Telerik.WinControls.UI.RadDropDownList rdpstatus;
        private Telerik.WinControls.UI.RadButton btnsearch;
        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
    }
}
