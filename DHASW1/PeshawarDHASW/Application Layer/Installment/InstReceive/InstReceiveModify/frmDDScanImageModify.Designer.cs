namespace PeshawarDHASW.Application_Layer.Installment.InstReceive.InstReceiveModify
{
    partial class frmDDScanImageModify
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.ImageBox = new System.Windows.Forms.PictureBox();
            this.radGroupBox4 = new Telerik.WinControls.UI.RadGroupBox();
            this.ImageSource = new Telerik.WinControls.UI.RadGridView();
            this.btnBrowseforSingleimage = new Telerik.WinControls.UI.RadButton();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.btnPrintImage = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).BeginInit();
            this.radGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageSource.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowseforSingleimage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.btnPrintImage);
            this.radGroupBox1.Controls.Add(this.ImageBox);
            this.radGroupBox1.HeaderText = "Attachment Viewer";
            this.radGroupBox1.Location = new System.Drawing.Point(336, 4);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(573, 561);
            this.radGroupBox1.TabIndex = 16;
            this.radGroupBox1.Text = "Attachment Viewer";
            this.radGroupBox1.ThemeName = "TelerikMetro";
            // 
            // ImageBox
            // 
            this.ImageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImageBox.Location = new System.Drawing.Point(2, 26);
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(569, 533);
            this.ImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageBox.TabIndex = 0;
            this.ImageBox.TabStop = false;
            // 
            // radGroupBox4
            // 
            this.radGroupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.radGroupBox4.Controls.Add(this.ImageSource);
            this.radGroupBox4.Controls.Add(this.btnBrowseforSingleimage);
            this.radGroupBox4.HeaderText = "Attachment";
            this.radGroupBox4.Location = new System.Drawing.Point(5, 15);
            this.radGroupBox4.Name = "radGroupBox4";
            this.radGroupBox4.Size = new System.Drawing.Size(324, 550);
            this.radGroupBox4.TabIndex = 15;
            this.radGroupBox4.Text = "Attachment";
            this.radGroupBox4.ThemeName = "TelerikMetro";
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
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "ID";
            gridViewTextBoxColumn3.HeaderText = "ID";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "ID";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 46;
            this.ImageSource.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewImageColumn1,
            gridViewTextBoxColumn1,
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
            this.ImageSource.Size = new System.Drawing.Size(310, 498);
            this.ImageSource.TabIndex = 11;
            this.ImageSource.Text = "radGridView1";
            this.ImageSource.ThemeName = "TelerikMetro";
            this.ImageSource.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.ImageSource_CellClick);
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
            // btnPrintImage
            // 
            this.btnPrintImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintImage.Location = new System.Drawing.Point(456, 0);
            this.btnPrintImage.Name = "btnPrintImage";
            this.btnPrintImage.Size = new System.Drawing.Size(115, 24);
            this.btnPrintImage.TabIndex = 1;
            this.btnPrintImage.Text = "Print";
            this.btnPrintImage.ThemeName = "TelerikMetro";
            this.btnPrintImage.Click += new System.EventHandler(this.btnPrintImage_Click);
            // 
            // frmDDScanImageModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 568);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.radGroupBox4);
            this.Name = "frmDDScanImageModify";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Modify DD Attachments";
            this.ThemeName = "TelerikMetro";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.frmDDScanImageModify_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).EndInit();
            this.radGroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImageSource.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowseforSingleimage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private System.Windows.Forms.PictureBox ImageBox;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox4;
        private Telerik.WinControls.UI.RadGridView ImageSource;
        private Telerik.WinControls.UI.RadButton btnBrowseforSingleimage;
        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadButton btnPrintImage;
    }
}
