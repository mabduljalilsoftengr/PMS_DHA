namespace PeshawarDHASW.Application_Layer.Refund
{
    partial class frmRefundModify
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
            Telerik.WinControls.UI.ConditionalFormattingObject conditionalFormattingObject1 = new Telerik.WinControls.UI.ConditionalFormattingObject();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.ConditionalFormattingObject conditionalFormattingObject2 = new Telerik.WinControls.UI.ConditionalFormattingObject();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.btnrefresh = new Telerik.WinControls.UI.RadButton();
            this.grdrefunddata = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.btnrefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdrefunddata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdrefunddata.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnrefresh
            // 
            this.btnrefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnrefresh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrefresh.Location = new System.Drawing.Point(813, 2);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(156, 23);
            this.btnrefresh.TabIndex = 1;
            this.btnrefresh.Text = "Refresh";
            this.btnrefresh.ThemeName = "TelerikMetro";
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // grdrefunddata
            // 
            this.grdrefunddata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdrefunddata.BackColor = System.Drawing.Color.White;
            this.grdrefunddata.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdrefunddata.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdrefunddata.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdrefunddata.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdrefunddata.Location = new System.Drawing.Point(2, 31);
            // 
            // 
            // 
            this.grdrefunddata.MasterTemplate.AllowAddNewRow = false;
            this.grdrefunddata.MasterTemplate.AllowColumnReorder = false;
            this.grdrefunddata.MasterTemplate.AllowSearchRow = true;
            this.grdrefunddata.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "RefundID";
            gridViewTextBoxColumn1.HeaderText = "RefundID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "RefundID";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "FileNo";
            gridViewTextBoxColumn2.HeaderText = "File No.";
            gridViewTextBoxColumn2.Name = "FileNo";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 90;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "PaymentType";
            gridViewTextBoxColumn3.HeaderText = "Payment Type";
            gridViewTextBoxColumn3.Name = "PaymentType";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 90;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "ChallanNo";
            gridViewTextBoxColumn4.HeaderText = "Challan No.";
            gridViewTextBoxColumn4.Name = "ChallanNo";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 90;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "Status";
            gridViewTextBoxColumn5.HeaderText = "Status";
            gridViewTextBoxColumn5.Name = "Status";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 90;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "AdjustmentType";
            gridViewTextBoxColumn6.HeaderText = "Type";
            gridViewTextBoxColumn6.Name = "AdjustmentType";
            gridViewTextBoxColumn6.ReadOnly = true;
            gridViewTextBoxColumn6.Width = 90;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "TRXID";
            gridViewTextBoxColumn7.HeaderText = "Trx ID";
            gridViewTextBoxColumn7.Name = "TRXID";
            gridViewTextBoxColumn7.ReadOnly = true;
            gridViewTextBoxColumn7.Width = 90;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "NDCNo";
            gridViewTextBoxColumn8.HeaderText = "NDCNo";
            gridViewTextBoxColumn8.Name = "NDCNo";
            gridViewTextBoxColumn8.ReadOnly = true;
            gridViewTextBoxColumn8.Width = 90;
            conditionalFormattingObject1.CellBackColor = System.Drawing.Color.LightGray;
            conditionalFormattingObject1.CellForeColor = System.Drawing.Color.Black;
            conditionalFormattingObject1.Name = "NewCondition";
            conditionalFormattingObject1.RowBackColor = System.Drawing.Color.Empty;
            conditionalFormattingObject1.RowForeColor = System.Drawing.Color.Empty;
            gridViewTextBoxColumn9.ConditionalFormattingObjectList.Add(conditionalFormattingObject1);
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "chqNumber";
            gridViewTextBoxColumn9.HeaderText = "Cheque No.";
            gridViewTextBoxColumn9.Name = "chqNumber";
            gridViewTextBoxColumn9.Width = 90;
            conditionalFormattingObject2.CellBackColor = System.Drawing.Color.Silver;
            conditionalFormattingObject2.CellForeColor = System.Drawing.Color.Black;
            conditionalFormattingObject2.Name = "NewCondition";
            conditionalFormattingObject2.RowBackColor = System.Drawing.Color.Empty;
            conditionalFormattingObject2.RowForeColor = System.Drawing.Color.Empty;
            gridViewTextBoxColumn10.ConditionalFormattingObjectList.Add(conditionalFormattingObject2);
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "vchNo";
            gridViewTextBoxColumn10.HeaderText = "Voucher No.";
            gridViewTextBoxColumn10.Name = "vchNo";
            gridViewTextBoxColumn10.Width = 90;
            gridViewCommandColumn1.DefaultText = "Apply Changes";
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.FieldName = "btnModify";
            gridViewCommandColumn1.HeaderText = "Modification";
            gridViewCommandColumn1.Image = global::PeshawarDHASW.Properties.Resources.edit_9_16;
            gridViewCommandColumn1.Name = "btnModify";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 95;
            gridViewCommandColumn2.DefaultText = "View";
            gridViewCommandColumn2.FieldName = "Attachment";
            gridViewCommandColumn2.HeaderText = "Attachment";
            gridViewCommandColumn2.Image = global::PeshawarDHASW.Properties.Resources.user;
            gridViewCommandColumn2.Name = "btnAttachment";
            gridViewCommandColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.UseDefaultText = true;
            gridViewCommandColumn2.Width = 51;
            this.grdrefunddata.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
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
            gridViewCommandColumn1,
            gridViewCommandColumn2});
            this.grdrefunddata.MasterTemplate.EnableAlternatingRowColor = true;
            this.grdrefunddata.MasterTemplate.EnableFiltering = true;
            this.grdrefunddata.MasterTemplate.ShowFilteringRow = false;
            this.grdrefunddata.MasterTemplate.ShowHeaderCellButtons = true;
            this.grdrefunddata.MasterTemplate.ShowTotals = true;
            this.grdrefunddata.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdrefunddata.Name = "grdrefunddata";
            this.grdrefunddata.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grdrefunddata.ShowHeaderCellButtons = true;
            this.grdrefunddata.Size = new System.Drawing.Size(967, 476);
            this.grdrefunddata.TabIndex = 0;
            this.grdrefunddata.Text = "radGridView1";
            this.grdrefunddata.ThemeName = "TelerikMetro";
            this.grdrefunddata.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdrefunddata_CellClick);
            // 
            // frmRefundModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 519);
            this.Controls.Add(this.grdrefunddata);
            this.Controls.Add(this.btnrefresh);
            this.Name = "frmRefundModify";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmRefundModify";
            this.ThemeName = "TelerikMetro";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRefundModify_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnrefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdrefunddata.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdrefunddata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadButton btnrefresh;
        private Telerik.WinControls.UI.RadGridView grdrefunddata;
    }
}
