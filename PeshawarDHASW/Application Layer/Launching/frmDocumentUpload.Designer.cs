namespace PeshawarDHASW.Application_Layer.Launching
{
    partial class frmDocumentUpload
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
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn1 = new Telerik.WinControls.UI.GridViewImageColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtFormNo = new Telerik.WinControls.UI.RadTextBox();
            this.btnFind = new Telerik.WinControls.UI.RadButton();
            this.gbCheckList = new Telerik.WinControls.UI.RadGroupBox();
            this.btnforwardto_Observationteam = new Telerik.WinControls.UI.RadButton();
            this.txtremarks = new Telerik.WinControls.UI.RadTextBox();
            this.btnSaveImages = new Telerik.WinControls.UI.RadButton();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.chkDischargeorRetirement = new System.Windows.Forms.CheckBox();
            this.chkServiceCertificate = new System.Windows.Forms.CheckBox();
            this.chkNICOP = new System.Windows.Forms.CheckBox();
            this.chkPassport = new System.Windows.Forms.CheckBox();
            this.chkCNIC = new System.Windows.Forms.CheckBox();
            this.gb_DocumentUpload = new Telerik.WinControls.UI.RadGroupBox();
            this.ImageSource = new Telerik.WinControls.UI.RadGridView();
            this.ckform = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbCheckList)).BeginInit();
            this.gbCheckList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnforwardto_Observationteam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtremarks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveImages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gb_DocumentUpload)).BeginInit();
            this.gb_DocumentUpload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageSource.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.radLabel1.Location = new System.Drawing.Point(13, 13);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(62, 22);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Form No";
            // 
            // txtFormNo
            // 
            this.txtFormNo.Location = new System.Drawing.Point(93, 13);
            this.txtFormNo.Name = "txtFormNo";
            this.txtFormNo.Size = new System.Drawing.Size(179, 20);
            this.txtFormNo.TabIndex = 1;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(277, 12);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(89, 24);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "Find";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // gbCheckList
            // 
            this.gbCheckList.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbCheckList.Controls.Add(this.ckform);
            this.gbCheckList.Controls.Add(this.btnforwardto_Observationteam);
            this.gbCheckList.Controls.Add(this.txtremarks);
            this.gbCheckList.Controls.Add(this.btnSaveImages);
            this.gbCheckList.Controls.Add(this.radLabel2);
            this.gbCheckList.Controls.Add(this.chkDischargeorRetirement);
            this.gbCheckList.Controls.Add(this.chkServiceCertificate);
            this.gbCheckList.Controls.Add(this.chkNICOP);
            this.gbCheckList.Controls.Add(this.chkPassport);
            this.gbCheckList.Controls.Add(this.chkCNIC);
            this.gbCheckList.Enabled = false;
            this.gbCheckList.HeaderText = "Document Required Check List";
            this.gbCheckList.Location = new System.Drawing.Point(13, 51);
            this.gbCheckList.Name = "gbCheckList";
            this.gbCheckList.Size = new System.Drawing.Size(320, 340);
            this.gbCheckList.TabIndex = 3;
            this.gbCheckList.Text = "Document Required Check List";
            // 
            // btnforwardto_Observationteam
            // 
            this.btnforwardto_Observationteam.Location = new System.Drawing.Point(135, 302);
            this.btnforwardto_Observationteam.Name = "btnforwardto_Observationteam";
            this.btnforwardto_Observationteam.Size = new System.Drawing.Size(173, 24);
            this.btnforwardto_Observationteam.TabIndex = 6;
            this.btnforwardto_Observationteam.Text = "Forward to Observation team";
            this.btnforwardto_Observationteam.Click += new System.EventHandler(this.btnforwardto_Observationteam_Click);
            // 
            // txtremarks
            // 
            this.txtremarks.AutoSize = false;
            this.txtremarks.Location = new System.Drawing.Point(21, 194);
            this.txtremarks.Multiline = true;
            this.txtremarks.Name = "txtremarks";
            this.txtremarks.Size = new System.Drawing.Size(287, 102);
            this.txtremarks.TabIndex = 6;
            // 
            // btnSaveImages
            // 
            this.btnSaveImages.Location = new System.Drawing.Point(21, 302);
            this.btnSaveImages.Name = "btnSaveImages";
            this.btnSaveImages.Size = new System.Drawing.Size(108, 24);
            this.btnSaveImages.TabIndex = 5;
            this.btnSaveImages.Text = "Form is Complete";
            this.btnSaveImages.Click += new System.EventHandler(this.btnSaveImages_Click);
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(21, 170);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(49, 18);
            this.radLabel2.TabIndex = 5;
            this.radLabel2.Text = "Remarks";
            // 
            // chkDischargeorRetirement
            // 
            this.chkDischargeorRetirement.AutoSize = true;
            this.chkDischargeorRetirement.Location = new System.Drawing.Point(21, 138);
            this.chkDischargeorRetirement.Name = "chkDischargeorRetirement";
            this.chkDischargeorRetirement.Size = new System.Drawing.Size(287, 17);
            this.chkDischargeorRetirement.TabIndex = 4;
            this.chkDischargeorRetirement.Text = "Photocopy Of Discharge Book or Retirement Order";
            this.chkDischargeorRetirement.UseVisualStyleBackColor = true;
            this.chkDischargeorRetirement.CheckedChanged += new System.EventHandler(this.chkDischargeorRetirement_CheckedChanged);
            // 
            // chkServiceCertificate
            // 
            this.chkServiceCertificate.AutoSize = true;
            this.chkServiceCertificate.Location = new System.Drawing.Point(21, 115);
            this.chkServiceCertificate.Name = "chkServiceCertificate";
            this.chkServiceCertificate.Size = new System.Drawing.Size(193, 17);
            this.chkServiceCertificate.TabIndex = 3;
            this.chkServiceCertificate.Text = "Photocopy Of Service Certificate ";
            this.chkServiceCertificate.UseVisualStyleBackColor = true;
            this.chkServiceCertificate.CheckedChanged += new System.EventHandler(this.chkServiceCertificate_CheckedChanged);
            // 
            // chkNICOP
            // 
            this.chkNICOP.AutoSize = true;
            this.chkNICOP.Location = new System.Drawing.Point(21, 92);
            this.chkNICOP.Name = "chkNICOP";
            this.chkNICOP.Size = new System.Drawing.Size(133, 17);
            this.chkNICOP.TabIndex = 2;
            this.chkNICOP.Text = "Photocopy Of NICOP";
            this.chkNICOP.UseVisualStyleBackColor = true;
            this.chkNICOP.CheckedChanged += new System.EventHandler(this.chkNICOP_CheckedChanged);
            // 
            // chkPassport
            // 
            this.chkPassport.AutoSize = true;
            this.chkPassport.Location = new System.Drawing.Point(21, 69);
            this.chkPassport.Name = "chkPassport";
            this.chkPassport.Size = new System.Drawing.Size(144, 17);
            this.chkPassport.TabIndex = 1;
            this.chkPassport.Text = "Photocopy Of Passport";
            this.chkPassport.UseVisualStyleBackColor = true;
            this.chkPassport.CheckedChanged += new System.EventHandler(this.chkPassport_CheckedChanged);
            // 
            // chkCNIC
            // 
            this.chkCNIC.AutoSize = true;
            this.chkCNIC.Location = new System.Drawing.Point(21, 46);
            this.chkCNIC.Name = "chkCNIC";
            this.chkCNIC.Size = new System.Drawing.Size(125, 17);
            this.chkCNIC.TabIndex = 0;
            this.chkCNIC.Text = "Photocopy Of CNIC";
            this.chkCNIC.UseVisualStyleBackColor = true;
            this.chkCNIC.CheckedChanged += new System.EventHandler(this.chkCNIC_CheckedChanged);
            // 
            // gb_DocumentUpload
            // 
            this.gb_DocumentUpload.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gb_DocumentUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_DocumentUpload.Controls.Add(this.ImageSource);
            this.gb_DocumentUpload.Enabled = false;
            this.gb_DocumentUpload.HeaderText = "Document Upload";
            this.gb_DocumentUpload.Location = new System.Drawing.Point(340, 51);
            this.gb_DocumentUpload.Name = "gb_DocumentUpload";
            this.gb_DocumentUpload.Size = new System.Drawing.Size(714, 345);
            this.gb_DocumentUpload.TabIndex = 4;
            this.gb_DocumentUpload.Text = "Document Upload";
            // 
            // ImageSource
            // 
            this.ImageSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImageSource.BackColor = System.Drawing.Color.White;
            this.ImageSource.Cursor = System.Windows.Forms.Cursors.Default;
            this.ImageSource.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ImageSource.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ImageSource.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ImageSource.Location = new System.Drawing.Point(5, 21);
            // 
            // 
            // 
            this.ImageSource.MasterTemplate.AllowAddNewRow = false;
            this.ImageSource.MasterTemplate.AllowColumnChooser = false;
            this.ImageSource.MasterTemplate.AllowColumnReorder = false;
            this.ImageSource.MasterTemplate.AllowDragToGroup = false;
            this.ImageSource.MasterTemplate.AllowEditRow = false;
            this.ImageSource.MasterTemplate.AllowRowResize = false;
            this.ImageSource.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "DocumentType";
            gridViewTextBoxColumn1.HeaderText = "Document Type";
            gridViewTextBoxColumn1.Name = "DocumentType";
            gridViewTextBoxColumn1.Width = 240;
            gridViewImageColumn1.EnableExpressionEditor = false;
            gridViewImageColumn1.FieldName = "ApplicationDoc";
            gridViewImageColumn1.HeaderText = "Preview";
            gridViewImageColumn1.Name = "ApplicationDoc";
            gridViewImageColumn1.Width = 379;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "Remarks";
            gridViewTextBoxColumn2.HeaderText = "Image Type";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "Remarks";
            gridViewTextBoxColumn2.Width = 93;
            gridViewCommandColumn1.DefaultText = "X";
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.FieldName = "btnRemove";
            gridViewCommandColumn1.HeaderText = "Remove";
            gridViewCommandColumn1.Name = "btnRemove";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 86;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "ApplicationID";
            gridViewTextBoxColumn3.HeaderText = "ApplicationID";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "ApplicationID";
            gridViewTextBoxColumn3.Width = 45;
            this.ImageSource.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewImageColumn1,
            gridViewTextBoxColumn2,
            gridViewCommandColumn1,
            gridViewTextBoxColumn3});
            this.ImageSource.MasterTemplate.EnableGrouping = false;
            this.ImageSource.MasterTemplate.ShowRowHeaderColumn = false;
            this.ImageSource.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.ImageSource.Name = "ImageSource";
            this.ImageSource.ReadOnly = true;
            this.ImageSource.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ImageSource.ShowGroupPanel = false;
            this.ImageSource.Size = new System.Drawing.Size(704, 319);
            this.ImageSource.TabIndex = 10;
            this.ImageSource.Text = "radGridView1";
            this.ImageSource.ThemeName = "TelerikMetro";
            this.ImageSource.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.ImageSource_CellClick);
            // 
            // ckform
            // 
            this.ckform.AutoSize = true;
            this.ckform.Location = new System.Drawing.Point(21, 23);
            this.ckform.Name = "ckform";
            this.ckform.Size = new System.Drawing.Size(52, 17);
            this.ckform.TabIndex = 7;
            this.ckform.Text = "Form";
            this.ckform.UseVisualStyleBackColor = true;
            this.ckform.CheckedChanged += new System.EventHandler(this.ckform_CheckedChanged);
            // 
            // frmDocumentUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 408);
            this.Controls.Add(this.gb_DocumentUpload);
            this.Controls.Add(this.gbCheckList);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.txtFormNo);
            this.Controls.Add(this.radLabel1);
            this.Name = "frmDocumentUpload";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmDocumentUpload";
            this.Load += new System.EventHandler(this.frmDocumentUpload_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbCheckList)).EndInit();
            this.gbCheckList.ResumeLayout(false);
            this.gbCheckList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnforwardto_Observationteam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtremarks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveImages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gb_DocumentUpload)).EndInit();
            this.gb_DocumentUpload.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImageSource.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtFormNo;
        private Telerik.WinControls.UI.RadButton btnFind;
        private Telerik.WinControls.UI.RadGroupBox gbCheckList;
        private System.Windows.Forms.CheckBox chkDischargeorRetirement;
        private System.Windows.Forms.CheckBox chkServiceCertificate;
        private System.Windows.Forms.CheckBox chkNICOP;
        private System.Windows.Forms.CheckBox chkPassport;
        private System.Windows.Forms.CheckBox chkCNIC;
        private Telerik.WinControls.UI.RadTextBox txtremarks;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton btnSaveImages;
        private Telerik.WinControls.UI.RadGroupBox gb_DocumentUpload;
        private Telerik.WinControls.UI.RadGridView ImageSource;
        private Telerik.WinControls.UI.RadButton btnforwardto_Observationteam;
        private System.Windows.Forms.CheckBox ckform;
    }
}
