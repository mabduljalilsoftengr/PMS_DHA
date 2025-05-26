namespace PeshawarDHASW.Application_Layer.Launching
{
    partial class frmDocPictureModify
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
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.DGV_ImageInfo = new Telerik.WinControls.UI.RadGridView();
            this.pb_Doc = new System.Windows.Forms.PictureBox();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.DGVMissingDoc = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ImageInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ImageInfo.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Doc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMissingDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMissingDoc.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.radGroupBox1.Controls.Add(this.DGV_ImageInfo);
            this.radGroupBox1.HeaderText = "Image Information";
            this.radGroupBox1.Location = new System.Drawing.Point(238, 12);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(310, 438);
            this.radGroupBox1.TabIndex = 2;
            this.radGroupBox1.Text = "Image Information";
            // 
            // DGV_ImageInfo
            // 
            this.DGV_ImageInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_ImageInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.DGV_ImageInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.DGV_ImageInfo.EnableHotTracking = false;
            this.DGV_ImageInfo.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.DGV_ImageInfo.ForeColor = System.Drawing.Color.Black;
            this.DGV_ImageInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DGV_ImageInfo.Location = new System.Drawing.Point(6, 21);
            // 
            // 
            // 
            this.DGV_ImageInfo.MasterTemplate.AllowAddNewRow = false;
            this.DGV_ImageInfo.MasterTemplate.AllowColumnReorder = false;
            this.DGV_ImageInfo.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "DocumentTRX";
            gridViewTextBoxColumn1.HeaderText = "DocumentTRX";
            gridViewTextBoxColumn1.Name = "DocumentTRX";
            gridViewTextBoxColumn1.Width = 94;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "DocumentType";
            gridViewTextBoxColumn2.HeaderText = "DocumentType";
            gridViewTextBoxColumn2.Name = "DocumentType";
            gridViewTextBoxColumn2.Width = 94;
            gridViewCommandColumn1.DefaultText = "Edit";
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.FieldName = "btnEdit";
            gridViewCommandColumn1.HeaderText = "Edit";
            gridViewCommandColumn1.Name = "btnEdit";
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 92;
            this.DGV_ImageInfo.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewCommandColumn1});
            this.DGV_ImageInfo.MasterTemplate.EnableGrouping = false;
            this.DGV_ImageInfo.MasterTemplate.EnableSorting = false;
            this.DGV_ImageInfo.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.DGV_ImageInfo.Name = "DGV_ImageInfo";
            this.DGV_ImageInfo.ReadOnly = true;
            this.DGV_ImageInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DGV_ImageInfo.ShowGroupPanel = false;
            this.DGV_ImageInfo.Size = new System.Drawing.Size(299, 412);
            this.DGV_ImageInfo.TabIndex = 0;
            this.DGV_ImageInfo.Text = "radGridView1";
            this.DGV_ImageInfo.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.DGV_ImageInfo_CellClick);
            // 
            // pb_Doc
            // 
            this.pb_Doc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_Doc.Location = new System.Drawing.Point(2, 18);
            this.pb_Doc.Name = "pb_Doc";
            this.pb_Doc.Size = new System.Drawing.Size(478, 420);
            this.pb_Doc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Doc.TabIndex = 0;
            this.pb_Doc.TabStop = false;
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox2.Controls.Add(this.pb_Doc);
            this.radGroupBox2.HeaderText = "Picture Information";
            this.radGroupBox2.Location = new System.Drawing.Point(552, 12);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(482, 440);
            this.radGroupBox2.TabIndex = 3;
            this.radGroupBox2.Text = "Picture Information";
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.radGroupBox3.Controls.Add(this.DGVMissingDoc);
            this.radGroupBox3.HeaderText = "Document Not Present";
            this.radGroupBox3.Location = new System.Drawing.Point(12, 14);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Size = new System.Drawing.Size(220, 438);
            this.radGroupBox3.TabIndex = 3;
            this.radGroupBox3.Text = "Document Not Present";
            // 
            // DGVMissingDoc
            // 
            this.DGVMissingDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVMissingDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.DGVMissingDoc.Cursor = System.Windows.Forms.Cursors.Default;
            this.DGVMissingDoc.EnableHotTracking = false;
            this.DGVMissingDoc.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.DGVMissingDoc.ForeColor = System.Drawing.Color.Black;
            this.DGVMissingDoc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DGVMissingDoc.Location = new System.Drawing.Point(6, 21);
            // 
            // 
            // 
            this.DGVMissingDoc.MasterTemplate.AllowAddNewRow = false;
            this.DGVMissingDoc.MasterTemplate.AllowColumnReorder = false;
            this.DGVMissingDoc.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "ApplicationID";
            gridViewTextBoxColumn3.HeaderText = "ApplicationID";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "ApplicationID";
            gridViewTextBoxColumn3.Width = 197;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "DocumentType";
            gridViewTextBoxColumn4.HeaderText = "DocumentType";
            gridViewTextBoxColumn4.Name = "DocumentType";
            gridViewTextBoxColumn4.Width = 116;
            gridViewCommandColumn2.DefaultText = "Upload";
            gridViewCommandColumn2.EnableExpressionEditor = false;
            gridViewCommandColumn2.FieldName = "UploadDoc";
            gridViewCommandColumn2.HeaderText = "Upload Doc";
            gridViewCommandColumn2.Name = "UploadDoc";
            gridViewCommandColumn2.UseDefaultText = true;
            gridViewCommandColumn2.Width = 73;
            this.DGVMissingDoc.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewCommandColumn2});
            this.DGVMissingDoc.MasterTemplate.EnableGrouping = false;
            this.DGVMissingDoc.MasterTemplate.EnableSorting = false;
            this.DGVMissingDoc.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.DGVMissingDoc.Name = "DGVMissingDoc";
            this.DGVMissingDoc.ReadOnly = true;
            this.DGVMissingDoc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DGVMissingDoc.ShowGroupPanel = false;
            this.DGVMissingDoc.Size = new System.Drawing.Size(209, 412);
            this.DGVMissingDoc.TabIndex = 0;
            this.DGVMissingDoc.Text = "radGridView1";
            this.DGVMissingDoc.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.DGVMissingDoc_CellClick);
            // 
            // frmDocPictureModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 464);
            this.Controls.Add(this.radGroupBox3);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.radGroupBox2);
            this.Name = "frmDocPictureModify";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmDocPictureModify";
            this.Load += new System.EventHandler(this.frmDocPictureModify_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ImageInfo.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ImageInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Doc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVMissingDoc.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMissingDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView DGV_ImageInfo;
        private System.Windows.Forms.PictureBox pb_Doc;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private Telerik.WinControls.UI.RadGridView DGVMissingDoc;
    }
}
