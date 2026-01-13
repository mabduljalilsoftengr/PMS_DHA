namespace PeshawarDHASW.Application_Layer.Installment.InstReceive.InstReceiveModify
{
    partial class frmDDScanImagesUpload
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
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn1 = new Telerik.WinControls.UI.GridViewImageColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.btnBrowseforSingleimage = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox4 = new Telerik.WinControls.UI.RadGroupBox();
            this.ImageSource = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnSaveRecord = new Telerik.WinControls.UI.RadButton();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.ImageBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowseforSingleimage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).BeginInit();
            this.radGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageSource.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowseforSingleimage
            // 
            this.btnBrowseforSingleimage.Location = new System.Drawing.Point(187, 15);
            this.btnBrowseforSingleimage.Name = "btnBrowseforSingleimage";
            this.btnBrowseforSingleimage.Size = new System.Drawing.Size(128, 26);
            this.btnBrowseforSingleimage.TabIndex = 10;
            this.btnBrowseforSingleimage.Text = "Add Attachment";
            this.btnBrowseforSingleimage.ThemeName = "TelerikMetro";
            this.btnBrowseforSingleimage.Click += new System.EventHandler(this.btnBrowseforSingleimage_Click);
            // 
            // radGroupBox4
            // 
            this.radGroupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.radGroupBox4.Controls.Add(this.ImageSource);
            this.radGroupBox4.Controls.Add(this.btnBrowseforSingleimage);
            this.radGroupBox4.HeaderText = "Attachment";
            this.radGroupBox4.Location = new System.Drawing.Point(8, 8);
            this.radGroupBox4.Name = "radGroupBox4";
            this.radGroupBox4.Size = new System.Drawing.Size(324, 515);
            this.radGroupBox4.TabIndex = 12;
            this.radGroupBox4.Text = "Attachment";
            this.radGroupBox4.ThemeName = "TelerikMetro";
            this.radGroupBox4.Click += new System.EventHandler(this.radGroupBox4_Click);
            // 
            // ImageSource
            // 
            this.ImageSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ImageSource.BackColor = System.Drawing.Color.White;
            this.ImageSource.Cursor = System.Windows.Forms.Cursors.Default;
            this.ImageSource.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ImageSource.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ImageSource.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ImageSource.Location = new System.Drawing.Point(5, 47);
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
            gridViewImageColumn1.EnableExpressionEditor = false;
            gridViewImageColumn1.FieldName = "MemberImage";
            gridViewImageColumn1.HeaderText = "Preview";
            gridViewImageColumn1.Name = "MemberImage";
            gridViewImageColumn1.Width = 241;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "Description";
            gridViewTextBoxColumn1.HeaderText = "Image Name";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "Description";
            gridViewTextBoxColumn1.Width = 178;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "ImageName";
            gridViewTextBoxColumn2.HeaderText = "Image Type";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "ImageName";
            gridViewTextBoxColumn2.Width = 110;
            gridViewCommandColumn1.DefaultText = "X";
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.FieldName = "btnRemove";
            gridViewCommandColumn1.HeaderText = "Remove";
            gridViewCommandColumn1.Name = "btnRemove";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 69;
            this.ImageSource.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewImageColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewCommandColumn1});
            this.ImageSource.MasterTemplate.EnableGrouping = false;
            this.ImageSource.MasterTemplate.ShowRowHeaderColumn = false;
            this.ImageSource.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.ImageSource.Name = "ImageSource";
            this.ImageSource.ReadOnly = true;
            this.ImageSource.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ImageSource.ShowGroupPanel = false;
            this.ImageSource.Size = new System.Drawing.Size(310, 463);
            this.ImageSource.TabIndex = 11;
            this.ImageSource.Text = "radGridView1";
            this.ImageSource.ThemeName = "TelerikMetro";
            this.ImageSource.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.ImageSource_CellClick);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.ImageBox);
            this.radGroupBox1.HeaderText = "Attachment Viewer";
            this.radGroupBox1.Location = new System.Drawing.Point(339, -3);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(573, 561);
            this.radGroupBox1.TabIndex = 13;
            this.radGroupBox1.Text = "Attachment Viewer";
            this.radGroupBox1.ThemeName = "TelerikMetro";
            this.radGroupBox1.Click += new System.EventHandler(this.radGroupBox1_Click);
            // 
            // btnSaveRecord
            // 
            this.btnSaveRecord.Location = new System.Drawing.Point(13, 525);
            this.btnSaveRecord.Name = "btnSaveRecord";
            this.btnSaveRecord.Size = new System.Drawing.Size(319, 33);
            this.btnSaveRecord.TabIndex = 14;
            this.btnSaveRecord.Text = "Upload DD Record";
            this.btnSaveRecord.ThemeName = "TelerikMetro";
            this.btnSaveRecord.Click += new System.EventHandler(this.btnSaveRecord_Click);
            // 
            // ImageBox
            // 
            this.ImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageBox.Location = new System.Drawing.Point(2, 18);
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(569, 541);
            this.ImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageBox.TabIndex = 0;
            this.ImageBox.TabStop = false;
            // 
            // frmDDScanImagesUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 563);
            this.Controls.Add(this.btnSaveRecord);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.radGroupBox4);
            this.Name = "frmDDScanImagesUpload";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Add the attachment with DD here . . .";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.frmDDScanImagesUpload_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowseforSingleimage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).EndInit();
            this.radGroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImageSource.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnBrowseforSingleimage;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox4;
        private Telerik.WinControls.UI.RadGridView ImageSource;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private System.Windows.Forms.PictureBox ImageBox;
        private Telerik.WinControls.UI.RadButton btnSaveRecord;
        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
    }
}
