namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    partial class frmReaddyForTFRSlips
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
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn3 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.btnrefresh = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.grdNDCDetail = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.btnrefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNDCDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNDCDetail.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnrefresh
            // 
            this.btnrefresh.Location = new System.Drawing.Point(1, 6);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(110, 24);
            this.btnrefresh.TabIndex = 0;
            this.btnrefresh.Text = "Refresh";
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.grdNDCDetail);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 35);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(655, 666);
            this.radGroupBox1.TabIndex = 1;
            // 
            // grdNDCDetail
            // 
            this.grdNDCDetail.Location = new System.Drawing.Point(9, 9);
            // 
            // 
            // 
            this.grdNDCDetail.MasterTemplate.AllowAddNewRow = false;
            this.grdNDCDetail.MasterTemplate.AllowColumnReorder = false;
            this.grdNDCDetail.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "NDCNo";
            gridViewTextBoxColumn1.HeaderText = "NDC No. ";
            gridViewTextBoxColumn1.Name = "NDCNo";
            gridViewTextBoxColumn1.Width = 133;
            gridViewTextBoxColumn2.FieldName = "FilePlotNo";
            gridViewTextBoxColumn2.HeaderText = "File No.";
            gridViewTextBoxColumn2.Name = "FilePlotNo";
            gridViewTextBoxColumn2.Width = 133;
            gridViewTextBoxColumn3.FieldName = "TransferNo";
            gridViewTextBoxColumn3.HeaderText = "Transfer No.";
            gridViewTextBoxColumn3.Name = "TransferNo";
            gridViewTextBoxColumn3.Width = 106;
            gridViewCommandColumn1.DefaultText = "Report";
            gridViewCommandColumn1.FieldName = "btntfrslipquestion";
            gridViewCommandColumn1.HeaderText = "TFR Slip & Quest";
            gridViewCommandColumn1.Name = "btntfrslipquestion";
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 121;
            gridViewCommandColumn2.DefaultText = "Next";
            gridViewCommandColumn2.FieldName = "btnNext";
            gridViewCommandColumn2.HeaderText = "Next >>";
            gridViewCommandColumn2.Name = "btnNext";
            gridViewCommandColumn2.UseDefaultText = true;
            gridViewCommandColumn2.Width = 57;
            gridViewTextBoxColumn4.FieldName = "PurchaseTypeID";
            gridViewTextBoxColumn4.HeaderText = "PurchaseTypeID";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "PurchaseTypeID";
            gridViewTextBoxColumn4.Width = 45;
            gridViewTextBoxColumn5.FieldName = "RemainingDaysForExpiry";
            gridViewTextBoxColumn5.HeaderText = "RemainingDaysForExpiry";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "RemainingDaysForExpiry";
            gridViewTextBoxColumn5.Width = 45;
            gridViewCommandColumn3.DefaultText = "Back";
            gridViewCommandColumn3.FieldName = "btnBack";
            gridViewCommandColumn3.HeaderText = "<< Back";
            gridViewCommandColumn3.Name = "btnBack";
            gridViewCommandColumn3.UseDefaultText = true;
            gridViewCommandColumn3.Width = 75;
            this.grdNDCDetail.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewCommandColumn1,
            gridViewCommandColumn2,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewCommandColumn3});
            this.grdNDCDetail.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdNDCDetail.Name = "grdNDCDetail";
            this.grdNDCDetail.Size = new System.Drawing.Size(641, 647);
            this.grdNDCDetail.TabIndex = 0;
            this.grdNDCDetail.Text = "radGridView1";
            this.grdNDCDetail.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdNDCDetail_CellClick);
            // 
            // frmReaddyForTFRSlips
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 703);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.btnrefresh);
            this.Name = "frmReaddyForTFRSlips";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Transfer Slips";
            this.Load += new System.EventHandler(this.frmReaddyForTFRSlips_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnrefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNDCDetail.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNDCDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnrefresh;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView grdNDCDetail;
    }
}
