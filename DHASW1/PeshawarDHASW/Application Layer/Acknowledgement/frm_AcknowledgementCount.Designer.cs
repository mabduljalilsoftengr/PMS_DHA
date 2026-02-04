namespace PeshawarDHASW.Application_Layer.Acknowledgement
{
    partial class frm_AcknowledgementCount
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.dgAckCount = new Telerik.WinControls.UI.RadGridView();
            this.btnExporttoExcel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgAckCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAckCount.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExporttoExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // dgAckCount
            // 
            this.dgAckCount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgAckCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.dgAckCount.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgAckCount.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dgAckCount.ForeColor = System.Drawing.Color.Black;
            this.dgAckCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgAckCount.Location = new System.Drawing.Point(0, 2);
            // 
            // 
            // 
            this.dgAckCount.MasterTemplate.AllowAddNewRow = false;
            this.dgAckCount.MasterTemplate.AllowColumnReorder = false;
            this.dgAckCount.MasterTemplate.AllowSearchRow = true;
            this.dgAckCount.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "RowNumber";
            gridViewTextBoxColumn1.HeaderText = "S.No";
            gridViewTextBoxColumn1.Name = "RowNumber";
            gridViewTextBoxColumn1.Width = 124;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "Category_Name";
            gridViewTextBoxColumn2.HeaderText = "Category Name";
            gridViewTextBoxColumn2.Name = "Category_Name";
            gridViewTextBoxColumn2.Width = 256;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "PlotSize";
            gridViewTextBoxColumn3.HeaderText = "Plot Size";
            gridViewTextBoxColumn3.Name = "PlotSize";
            gridViewTextBoxColumn3.Width = 162;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "NoOfFiles";
            gridViewTextBoxColumn4.HeaderText = "Files Count";
            gridViewTextBoxColumn4.Name = "NoOfFiles";
            gridViewTextBoxColumn4.Width = 161;
            this.dgAckCount.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.dgAckCount.MasterTemplate.EnableFiltering = true;
            gridViewSummaryItem1.Aggregate = Telerik.WinControls.UI.GridAggregateFunction.Sum;
            gridViewSummaryItem1.AggregateExpression = null;
            gridViewSummaryItem1.FormatString = "{0}";
            gridViewSummaryItem1.Name = "NoOfFiles";
            this.dgAckCount.MasterTemplate.SummaryRowsBottom.Add(new Telerik.WinControls.UI.GridViewSummaryRowItem(new Telerik.WinControls.UI.GridViewSummaryItem[] {
                gridViewSummaryItem1}));
            this.dgAckCount.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dgAckCount.Name = "dgAckCount";
            this.dgAckCount.ReadOnly = true;
            this.dgAckCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgAckCount.Size = new System.Drawing.Size(721, 339);
            this.dgAckCount.TabIndex = 1;
            // 
            // btnExporttoExcel
            // 
            this.btnExporttoExcel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExporttoExcel.Location = new System.Drawing.Point(581, 350);
            this.btnExporttoExcel.Name = "btnExporttoExcel";
            this.btnExporttoExcel.Size = new System.Drawing.Size(128, 31);
            this.btnExporttoExcel.TabIndex = 22;
            this.btnExporttoExcel.Text = "Export to Excel";
            this.btnExporttoExcel.ThemeName = "TelerikMetro";
            this.btnExporttoExcel.Click += new System.EventHandler(this.btnExporttoExcel_Click);
            // 
            // frm_AcknowledgementCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 390);
            this.Controls.Add(this.btnExporttoExcel);
            this.Controls.Add(this.dgAckCount);
            this.Name = "frm_AcknowledgementCount";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acknowledgment Count";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.frm_AcknowledgementCount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgAckCount.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAckCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExporttoExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView dgAckCount;
        private Telerik.WinControls.UI.RadButton btnExporttoExcel;
    }
}
