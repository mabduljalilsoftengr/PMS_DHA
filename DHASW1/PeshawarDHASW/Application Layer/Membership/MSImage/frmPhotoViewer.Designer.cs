namespace PeshawarDHASW.Application_Layer.Membership.MSImage
{
    partial class frmPhotoViewer
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
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn1 = new Telerik.WinControls.UI.GridViewImageColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.Image_View = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GDVImageInfo = new Telerik.WinControls.UI.RadGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAddImage = new Telerik.WinControls.UI.RadButton();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            ((System.ComponentModel.ISupportInitialize)(this.Image_View)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GDVImageInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GDVImageInfo.MasterTemplate)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddImage)).BeginInit();
            this.SuspendLayout();
            // 
            // Image_View
            // 
            this.Image_View.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Image_View.Location = new System.Drawing.Point(3, 16);
            this.Image_View.Name = "Image_View";
            this.Image_View.Size = new System.Drawing.Size(728, 571);
            this.Image_View.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Image_View.TabIndex = 0;
            this.Image_View.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.GDVImageInfo);
            this.groupBox1.Location = new System.Drawing.Point(8, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 555);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image";
            // 
            // GDVImageInfo
            // 
            this.GDVImageInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GDVImageInfo.BackColor = System.Drawing.SystemColors.Control;
            this.GDVImageInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.GDVImageInfo.EnableGestures = false;
            this.GDVImageInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.GDVImageInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GDVImageInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GDVImageInfo.Location = new System.Drawing.Point(7, 22);
            // 
            // 
            // 
            this.GDVImageInfo.MasterTemplate.AllowAddNewRow = false;
            this.GDVImageInfo.MasterTemplate.AllowColumnReorder = false;
            this.GDVImageInfo.MasterTemplate.AllowDragToGroup = false;
            this.GDVImageInfo.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "ID";
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "ID";
            gridViewTextBoxColumn1.VisibleInColumnChooser = false;
            gridViewTextBoxColumn1.Width = 110;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "MemberID";
            gridViewTextBoxColumn2.HeaderText = "MemberID";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "MemberID";
            gridViewTextBoxColumn2.VisibleInColumnChooser = false;
            gridViewTextBoxColumn2.Width = 83;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "Description";
            gridViewTextBoxColumn3.HeaderText = "Description";
            gridViewTextBoxColumn3.Name = "Description";
            gridViewTextBoxColumn3.Width = 69;
            gridViewImageColumn1.EnableExpressionEditor = false;
            gridViewImageColumn1.HeaderText = "ImageName";
            gridViewImageColumn1.Name = "ImageName";
            gridViewImageColumn1.Width = 100;
            gridViewCommandColumn1.DefaultText = "Remove";
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.HeaderText = "Edit";
            gridViewCommandColumn1.Name = "btnRemove";
            gridViewCommandColumn1.UseDefaultText = true;
            this.GDVImageInfo.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewImageColumn1,
            gridViewCommandColumn1});
            this.GDVImageInfo.MasterTemplate.EnableGrouping = false;
            this.GDVImageInfo.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GDVImageInfo.Name = "GDVImageInfo";
            this.GDVImageInfo.ReadOnly = true;
            this.GDVImageInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GDVImageInfo.Size = new System.Drawing.Size(238, 527);
            this.GDVImageInfo.TabIndex = 0;
            this.GDVImageInfo.Text = "radGridView1";
            this.GDVImageInfo.ThemeName = "TelerikMetro";
            this.GDVImageInfo.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.GDVImageInfo_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.Image_View);
            this.groupBox2.Location = new System.Drawing.Point(265, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(734, 590);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "View Image";
            // 
            // btnAddImage
            // 
            this.btnAddImage.Location = new System.Drawing.Point(15, 7);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(238, 29);
            this.btnAddImage.TabIndex = 4;
            this.btnAddImage.Text = "Add Image";
            this.btnAddImage.ThemeName = "TelerikMetro";
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // frmPhotoViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 609);
            this.Controls.Add(this.btnAddImage);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmPhotoViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmPhotoViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Image_View)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GDVImageInfo.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GDVImageInfo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAddImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Image_View;
        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadGridView GDVImageInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private Telerik.WinControls.UI.RadButton btnAddImage;
        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
    }
}