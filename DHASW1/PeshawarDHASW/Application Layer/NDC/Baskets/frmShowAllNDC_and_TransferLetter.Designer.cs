namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    partial class frmShowAllNDC_and_TransferLetter
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn3 = new Telerik.WinControls.UI.GridViewImageColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn3 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn4 = new Telerik.WinControls.UI.GridViewImageColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn4 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition4 = new Telerik.WinControls.UI.TableViewDefinition();
            this.grdNDCNo = new Telerik.WinControls.UI.RadGridView();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.txtTfrNoNDCNo = new Telerik.WinControls.UI.RadTextBox();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.grdTFRLetter = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.grdNDCNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNDCNo.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTfrNoNDCNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTFRLetter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTFRLetter.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // grdNDCNo
            // 
            this.grdNDCNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grdNDCNo.Location = new System.Drawing.Point(8, 38);
            // 
            // 
            // 
            this.grdNDCNo.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn8.FieldName = "Img_ID";
            gridViewTextBoxColumn8.HeaderText = "Img_ID";
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.Name = "Img_ID";
            gridViewTextBoxColumn9.FieldName = "NDCNo";
            gridViewTextBoxColumn9.HeaderText = "NDCNo";
            gridViewTextBoxColumn9.Name = "NDCNo";
            gridViewTextBoxColumn9.Width = 105;
            gridViewImageColumn3.FieldName = "NDC_Image";
            gridViewImageColumn3.HeaderText = "NDC Image";
            gridViewImageColumn3.Name = "NDC_Image";
            gridViewImageColumn3.Width = 105;
            gridViewTextBoxColumn10.FieldName = "Upload_Date";
            gridViewTextBoxColumn10.HeaderText = "Upload_Date";
            gridViewTextBoxColumn10.IsVisible = false;
            gridViewTextBoxColumn10.Name = "Upload_Date";
            gridViewCommandColumn3.DefaultText = "View";
            gridViewCommandColumn3.FieldName = "btn_View";
            gridViewCommandColumn3.HeaderText = "View";
            gridViewCommandColumn3.Name = "btn_View";
            gridViewCommandColumn3.UseDefaultText = true;
            gridViewCommandColumn3.Width = 105;
            this.grdNDCNo.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewImageColumn3,
            gridViewTextBoxColumn10,
            gridViewCommandColumn3});
            this.grdNDCNo.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.grdNDCNo.Name = "grdNDCNo";
            this.grdNDCNo.Size = new System.Drawing.Size(334, 234);
            this.grdNDCNo.TabIndex = 0;
            this.grdNDCNo.Text = "radGridView1";
            this.grdNDCNo.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdNDCNo_CellClick);
            // 
            // radButton1
            // 
            this.radButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButton1.Location = new System.Drawing.Point(238, 13);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(111, 24);
            this.radButton1.TabIndex = 1;
            this.radButton1.Text = "Find";
            // 
            // txtTfrNoNDCNo
            // 
            this.txtTfrNoNDCNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTfrNoNDCNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTfrNoNDCNo.Location = new System.Drawing.Point(14, 13);
            this.txtTfrNoNDCNo.Name = "txtTfrNoNDCNo";
            this.txtTfrNoNDCNo.NullText = "Enter NDC / Transfer No.";
            this.txtTfrNoNDCNo.Size = new System.Drawing.Size(218, 24);
            this.txtTfrNoNDCNo.TabIndex = 2;
            this.txtTfrNoNDCNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTfrNoNDCNo.Leave += new System.EventHandler(this.txtTfrNoNDCNo_Leave);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.grdNDCNo);
            this.radGroupBox1.HeaderText = "NDC";
            this.radGroupBox1.Location = new System.Drawing.Point(8, 43);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(350, 280);
            this.radGroupBox1.TabIndex = 3;
            this.radGroupBox1.Text = "NDC";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.radGroupBox2.Controls.Add(this.grdTFRLetter);
            this.radGroupBox2.HeaderText = "Transfer Letter";
            this.radGroupBox2.Location = new System.Drawing.Point(5, 329);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(353, 324);
            this.radGroupBox2.TabIndex = 4;
            this.radGroupBox2.Text = "Transfer Letter";
            // 
            // grdTFRLetter
            // 
            this.grdTFRLetter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grdTFRLetter.Location = new System.Drawing.Point(8, 21);
            // 
            // 
            // 
            this.grdTFRLetter.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn11.FieldName = "TFRH_ID";
            gridViewTextBoxColumn11.HeaderText = "TFRH_ID";
            gridViewTextBoxColumn11.IsVisible = false;
            gridViewTextBoxColumn11.Name = "TFRH_ID";
            gridViewTextBoxColumn12.FieldName = "NDCNo";
            gridViewTextBoxColumn12.HeaderText = "NDCNo";
            gridViewTextBoxColumn12.Name = "NDCNo";
            gridViewTextBoxColumn12.Width = 79;
            gridViewImageColumn4.FieldName = "Image";
            gridViewImageColumn4.HeaderText = "Image";
            gridViewImageColumn4.Name = "Image";
            gridViewImageColumn4.Width = 79;
            gridViewTextBoxColumn13.FieldName = "Description";
            gridViewTextBoxColumn13.HeaderText = "Description";
            gridViewTextBoxColumn13.Name = "Description";
            gridViewTextBoxColumn13.Width = 79;
            gridViewTextBoxColumn14.FieldName = "TransferNo_tblTFRTracking";
            gridViewTextBoxColumn14.HeaderText = "TFR No.";
            gridViewTextBoxColumn14.IsVisible = false;
            gridViewTextBoxColumn14.Name = "TransferNo_tblTFRTracking";
            gridViewCommandColumn4.DefaultText = "View";
            gridViewCommandColumn4.FieldName = "btnView";
            gridViewCommandColumn4.HeaderText = "View";
            gridViewCommandColumn4.Name = "btnView";
            gridViewCommandColumn4.UseDefaultText = true;
            gridViewCommandColumn4.Width = 79;
            this.grdTFRLetter.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewImageColumn4,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewCommandColumn4});
            this.grdTFRLetter.MasterTemplate.ViewDefinition = tableViewDefinition4;
            this.grdTFRLetter.Name = "grdTFRLetter";
            this.grdTFRLetter.Size = new System.Drawing.Size(334, 295);
            this.grdTFRLetter.TabIndex = 0;
            this.grdTFRLetter.Text = "radGridView1";
            this.grdTFRLetter.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdTFRLetter_CellClick);
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox3.Controls.Add(this.crystalReportViewer1);
            this.radGroupBox3.HeaderText = "Report";
            this.radGroupBox3.Location = new System.Drawing.Point(371, 12);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Size = new System.Drawing.Size(688, 653);
            this.radGroupBox3.TabIndex = 5;
            this.radGroupBox3.Text = "Report";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(6, 19);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(677, 623);
            this.crystalReportViewer1.TabIndex = 1;
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.txtTfrNoNDCNo);
            this.radPanel1.Controls.Add(this.radButton1);
            this.radPanel1.Controls.Add(this.radGroupBox2);
            this.radPanel1.Controls.Add(this.radGroupBox1);
            this.radPanel1.Location = new System.Drawing.Point(4, 3);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(361, 662);
            this.radPanel1.TabIndex = 6;
            // 
            // frmShowAllNDC_and_TransferLetter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 669);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.radGroupBox3);
            this.Name = "frmShowAllNDC_and_TransferLetter";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmShowAllNDC_and_TransferLetter";
            this.Load += new System.EventHandler(this.frmShowAllNDC_and_TransferLetter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdNDCNo.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNDCNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTfrNoNDCNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTFRLetter.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTFRLetter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grdNDCNo;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadTextBox txtTfrNoNDCNo;
        private Telerik.WinControls.UI.RadGridView grdTFRLetter;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private Telerik.WinControls.UI.RadPanel radPanel1;
    }
}
