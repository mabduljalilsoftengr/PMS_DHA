namespace PeshawarDHASW.Application_Layer.DashBoards.frm_DashBoardDetail
{
    partial class frm_SectorDetail
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
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn3 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewSummaryItem gridViewSummaryItem1 = new Telerik.WinControls.UI.GridViewSummaryItem();
            Telerik.WinControls.UI.GridViewSummaryItem gridViewSummaryItem2 = new Telerik.WinControls.UI.GridViewSummaryItem();
            Telerik.WinControls.UI.GridViewSummaryItem gridViewSummaryItem3 = new Telerik.WinControls.UI.GridViewSummaryItem();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.DGVSectorInformation = new Telerik.WinControls.UI.RadGridView();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.btnExcelExport = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSectorInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSectorInformation.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExcelExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVSectorInformation
            // 
            this.DGVSectorInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVSectorInformation.BackColor = System.Drawing.Color.White;
            this.DGVSectorInformation.Cursor = System.Windows.Forms.Cursors.Default;
            this.DGVSectorInformation.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.DGVSectorInformation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DGVSectorInformation.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DGVSectorInformation.Location = new System.Drawing.Point(3, 59);
            // 
            // 
            // 
            this.DGVSectorInformation.MasterTemplate.AllowAddNewRow = false;
            this.DGVSectorInformation.MasterTemplate.AllowColumnReorder = false;
            this.DGVSectorInformation.MasterTemplate.AllowDeleteRow = false;
            this.DGVSectorInformation.MasterTemplate.AllowEditRow = false;
            this.DGVSectorInformation.MasterTemplate.AllowSearchRow = true;
            this.DGVSectorInformation.MasterTemplate.AutoExpandGroups = true;
            this.DGVSectorInformation.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "Sector_ID";
            gridViewTextBoxColumn1.HeaderText = "Sector_ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "Sector_ID";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "S.No";
            gridViewTextBoxColumn2.HeaderText = "S.No";
            gridViewTextBoxColumn2.Name = "S.No";
            gridViewTextBoxColumn2.Width = 20;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "Category_Name";
            gridViewTextBoxColumn3.HeaderText = "Plot Category";
            gridViewTextBoxColumn3.Name = "Category_Name";
            gridViewTextBoxColumn3.Width = 347;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "PlotSize";
            gridViewTextBoxColumn4.HeaderText = "Plot Size";
            gridViewTextBoxColumn4.Name = "PlotSize";
            gridViewTextBoxColumn4.Width = 85;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "Phase";
            gridViewTextBoxColumn5.HeaderText = "Phase";
            gridViewTextBoxColumn5.Name = "Phase";
            gridViewTextBoxColumn5.Width = 67;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "Sector";
            gridViewTextBoxColumn6.HeaderText = "Sector";
            gridViewTextBoxColumn6.Name = "Sector";
            gridViewTextBoxColumn6.Width = 69;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "FileNo";
            gridViewTextBoxColumn7.HeaderText = "File No";
            gridViewTextBoxColumn7.Name = "FileNo";
            gridViewTextBoxColumn7.Width = 75;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "PlotNo";
            gridViewTextBoxColumn8.HeaderText = "Plot No";
            gridViewTextBoxColumn8.Name = "PlotNo";
            gridViewTextBoxColumn8.Width = 77;
            gridViewDecimalColumn1.EnableExpressionEditor = false;
            gridViewDecimalColumn1.FieldName = "TotalDueAmount";
            gridViewDecimalColumn1.FormatString = "{0:#,###0.00;(#,###0.00);0}";
            gridViewDecimalColumn1.HeaderText = "Total Due Amount";
            gridViewDecimalColumn1.Name = "TotalDueAmount";
            gridViewDecimalColumn1.Width = 150;
            gridViewDecimalColumn2.EnableExpressionEditor = false;
            gridViewDecimalColumn2.FieldName = "TotalReceiveAmount";
            gridViewDecimalColumn2.FormatString = "{0:#,###0.00;(#,###0.00);0}";
            gridViewDecimalColumn2.HeaderText = "Total Receive Amount";
            gridViewDecimalColumn2.Name = "TotalReceiveAmount";
            gridViewDecimalColumn2.Width = 175;
            gridViewDecimalColumn3.EnableExpressionEditor = false;
            gridViewDecimalColumn3.FieldName = "TotalRemaning";
            gridViewDecimalColumn3.FormatString = "{0:#,###0.00;(#,###0.00);0}";
            gridViewDecimalColumn3.HeaderText = "Total Remaning";
            gridViewDecimalColumn3.Name = "TotalRemaning";
            gridViewDecimalColumn3.Width = 135;
            this.DGVSectorInformation.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewDecimalColumn1,
            gridViewDecimalColumn2,
            gridViewDecimalColumn3});
            this.DGVSectorInformation.MasterTemplate.EnableFiltering = true;
            this.DGVSectorInformation.MasterTemplate.SearchRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.DGVSectorInformation.MasterTemplate.ShowFilteringRow = false;
            this.DGVSectorInformation.MasterTemplate.ShowHeaderCellButtons = true;
            this.DGVSectorInformation.MasterTemplate.ShowParentGroupSummaries = true;
            this.DGVSectorInformation.MasterTemplate.ShowTotals = true;
            gridViewSummaryItem1.Aggregate = Telerik.WinControls.UI.GridAggregateFunction.Sum;
            gridViewSummaryItem1.AggregateExpression = null;
            gridViewSummaryItem1.FormatString = "{0:#,###0.00;(#,###0.00);0}";
            gridViewSummaryItem1.Name = "TotalDueAmount";
            gridViewSummaryItem2.Aggregate = Telerik.WinControls.UI.GridAggregateFunction.Sum;
            gridViewSummaryItem2.AggregateExpression = null;
            gridViewSummaryItem2.FormatString = "{0:#,###0.00;(#,###0.00);0}";
            gridViewSummaryItem2.Name = "TotalReceiveAmount";
            gridViewSummaryItem3.Aggregate = Telerik.WinControls.UI.GridAggregateFunction.Sum;
            gridViewSummaryItem3.AggregateExpression = null;
            gridViewSummaryItem3.FormatString = "{0:#,###0.00;(#,###0.00);0}";
            gridViewSummaryItem3.Name = "TotalRemaing";
            this.DGVSectorInformation.MasterTemplate.SummaryRowsBottom.Add(new Telerik.WinControls.UI.GridViewSummaryRowItem(new Telerik.WinControls.UI.GridViewSummaryItem[] {
                gridViewSummaryItem1,
                gridViewSummaryItem2,
                gridViewSummaryItem3}));
            this.DGVSectorInformation.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.DGVSectorInformation.Name = "DGVSectorInformation";
            this.DGVSectorInformation.ReadOnly = true;
            this.DGVSectorInformation.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DGVSectorInformation.ShowHeaderCellButtons = true;
            this.DGVSectorInformation.Size = new System.Drawing.Size(1212, 371);
            this.DGVSectorInformation.TabIndex = 1;
            this.DGVSectorInformation.Text = "radGridView1";
            this.DGVSectorInformation.ThemeName = "TelerikMetro";
            this.DGVSectorInformation.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.DGVSectorInformation_CellFormatting);
            // 
            // btnExcelExport
            // 
            this.btnExcelExport.Location = new System.Drawing.Point(1052, 13);
            this.btnExcelExport.Name = "btnExcelExport";
            this.btnExcelExport.Size = new System.Drawing.Size(154, 40);
            this.btnExcelExport.TabIndex = 2;
            this.btnExcelExport.Text = "Exel Export";
            this.btnExcelExport.ThemeName = "TelerikMetro";
            this.btnExcelExport.Click += new System.EventHandler(this.btnExcelExport_Click);
            // 
            // frm_SectorDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 439);
            this.Controls.Add(this.btnExcelExport);
            this.Controls.Add(this.DGVSectorInformation);
            this.Name = "frm_SectorDetail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Sector Detail";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.frm_SectorDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVSectorInformation.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSectorInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExcelExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView DGVSectorInformation;
        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadButton btnExcelExport;
    }
}
