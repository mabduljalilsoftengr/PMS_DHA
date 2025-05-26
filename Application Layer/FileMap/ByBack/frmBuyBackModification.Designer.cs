namespace PeshawarDHASW.Application_Layer.FileMap.ByBack
{
    partial class frmBuyBackModification
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
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.grdreportdata = new Telerik.WinControls.UI.RadGridView();
            this.btnsearch = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdreportdata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdreportdata.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnsearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
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
            this.grdreportdata.Location = new System.Drawing.Point(5, 42);
            // 
            // 
            // 
            this.grdreportdata.MasterTemplate.AllowAddNewRow = false;
            this.grdreportdata.MasterTemplate.AllowColumnReorder = false;
            this.grdreportdata.MasterTemplate.AllowSearchRow = true;
            gridViewCommandColumn1.DefaultText = "View";
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.FieldName = "btnview";
            gridViewCommandColumn1.HeaderText = "Attachment";
            gridViewCommandColumn1.Name = "btnview";
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 76;
            gridViewCommandColumn2.DefaultText = "Edit";
            gridViewCommandColumn2.EnableExpressionEditor = false;
            gridViewCommandColumn2.FieldName = "btnBuyBackModification";
            gridViewCommandColumn2.HeaderText = "Edit";
            gridViewCommandColumn2.Name = "btnBuyBackModification";
            gridViewCommandColumn2.UseDefaultText = true;
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
            gridViewTextBoxColumn7.IsVisible = false;
            gridViewTextBoxColumn7.Name = "Amount";
            gridViewTextBoxColumn7.Width = 124;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "CheckNo";
            gridViewTextBoxColumn8.HeaderText = "Cheque No.";
            gridViewTextBoxColumn8.IsVisible = false;
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
            this.grdreportdata.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCommandColumn1,
            gridViewCommandColumn2,
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
            gridViewTextBoxColumn12});
            this.grdreportdata.MasterTemplate.EnableSorting = false;
            this.grdreportdata.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdreportdata.Name = "grdreportdata";
            this.grdreportdata.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grdreportdata.Size = new System.Drawing.Size(948, 448);
            this.grdreportdata.TabIndex = 1;
            this.grdreportdata.Text = "radGridView1";
            this.grdreportdata.ThemeName = "TelerikMetro";
            this.grdreportdata.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdreportdata_CellClick);
            // 
            // btnsearch
            // 
            this.btnsearch.Location = new System.Drawing.Point(5, 10);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(152, 29);
            this.btnsearch.TabIndex = 5;
            this.btnsearch.Text = "Refresh";
            this.btnsearch.ThemeName = "TelerikMetro";
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // frmBuyBackModification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 495);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.grdreportdata);
            this.Name = "frmBuyBackModification";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmBuyBackModification";
            this.ThemeName = "TelerikMetro";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBuyBackModification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdreportdata.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdreportdata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnsearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grdreportdata;
        private Telerik.WinControls.UI.RadButton btnsearch;
    }
}
