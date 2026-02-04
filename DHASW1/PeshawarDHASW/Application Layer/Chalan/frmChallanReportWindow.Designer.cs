namespace PeshawarDHASW.Application_Layer.Chalan
{
    partial class frmChallanReportWindow
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
            Telerik.WinControls.UI.GridViewSummaryItem gridViewSummaryItem1 = new Telerik.WinControls.UI.GridViewSummaryItem();
            Telerik.WinControls.UI.GridViewSummaryItem gridViewSummaryItem2 = new Telerik.WinControls.UI.GridViewSummaryItem();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.grdChallanData = new Telerik.WinControls.UI.RadGridView();
            this.btnExporttoExcel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdChallanData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChallanData.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExporttoExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.grdChallanData);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(6, 38);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(677, 440);
            this.radGroupBox1.TabIndex = 0;
            // 
            // grdChallanData
            // 
            this.grdChallanData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grdChallanData.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdChallanData.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.grdChallanData.ForeColor = System.Drawing.Color.Black;
            this.grdChallanData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdChallanData.Location = new System.Drawing.Point(6, 8);
            // 
            // 
            // 
            this.grdChallanData.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "PlotSize";
            gridViewTextBoxColumn1.HeaderText = "Plot Size";
            gridViewTextBoxColumn1.Name = "PlotSize";
            gridViewTextBoxColumn1.Width = 161;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "Category_Name";
            gridViewTextBoxColumn2.HeaderText = "File Type";
            gridViewTextBoxColumn2.Name = "Category_Name";
            gridViewTextBoxColumn2.Width = 161;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "TotalFiles";
            gridViewTextBoxColumn3.HeaderText = "No of Files";
            gridViewTextBoxColumn3.Name = "TotalFiles";
            gridViewTextBoxColumn3.Width = 161;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "TotalAmountReceived";
            gridViewTextBoxColumn4.HeaderText = "Tfr Income";
            gridViewTextBoxColumn4.Name = "TotalAmountReceived";
            gridViewTextBoxColumn4.Width = 162;
            this.grdChallanData.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            gridViewSummaryItem1.Aggregate = Telerik.WinControls.UI.GridAggregateFunction.Sum;
            gridViewSummaryItem1.AggregateExpression = null;
            gridViewSummaryItem1.FormatString = "{0}";
            gridViewSummaryItem1.Name = "TotalFiles";
            gridViewSummaryItem2.Aggregate = Telerik.WinControls.UI.GridAggregateFunction.Sum;
            gridViewSummaryItem2.AggregateExpression = null;
            gridViewSummaryItem2.FormatString = "{0}";
            gridViewSummaryItem2.Name = "TotalAmountReceived";
            this.grdChallanData.MasterTemplate.SummaryRowsBottom.Add(new Telerik.WinControls.UI.GridViewSummaryRowItem(new Telerik.WinControls.UI.GridViewSummaryItem[] {
                gridViewSummaryItem1,
                gridViewSummaryItem2}));
            this.grdChallanData.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdChallanData.Name = "grdChallanData";
            this.grdChallanData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grdChallanData.Size = new System.Drawing.Size(663, 424);
            this.grdChallanData.TabIndex = 0;
            this.grdChallanData.Text = "radGridView1";
            // 
            // btnExporttoExcel
            // 
            this.btnExporttoExcel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExporttoExcel.Location = new System.Drawing.Point(555, 7);
            this.btnExporttoExcel.Name = "btnExporttoExcel";
            this.btnExporttoExcel.Size = new System.Drawing.Size(125, 25);
            this.btnExporttoExcel.TabIndex = 12;
            this.btnExporttoExcel.Text = "Export to Excel";
            this.btnExporttoExcel.ThemeName = "TelerikMetro";
            this.btnExporttoExcel.Click += new System.EventHandler(this.btnExporttoExcel_Click);
            // 
            // frmChallanReportWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 480);
            this.Controls.Add(this.btnExporttoExcel);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmChallanReportWindow";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmChallanReportWindow";
            this.Load += new System.EventHandler(this.frmChallanReportWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdChallanData.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChallanData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExporttoExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView grdChallanData;
        private Telerik.WinControls.UI.RadButton btnExporttoExcel;
    }
}
