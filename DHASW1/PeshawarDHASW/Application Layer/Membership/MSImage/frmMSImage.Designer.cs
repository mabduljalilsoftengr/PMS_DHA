namespace PeshawarDHASW.Application_Layer.Membership.MSImage
{
    partial class frmMSImage
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GDVImageInfo = new Telerik.WinControls.UI.RadGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ImageView = new System.Windows.Forms.PictureBox();
            this.btnImageDelete = new Telerik.WinControls.UI.RadButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GDVImageInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GDVImageInfo.MasterTemplate)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImageDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.GDVImageInfo);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 686);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Membership Image";
            // 
            // GDVImageInfo
            // 
            this.GDVImageInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GDVImageInfo.EnableGestures = false;
            this.GDVImageInfo.Location = new System.Drawing.Point(7, 22);
            // 
            // 
            // 
            this.GDVImageInfo.MasterTemplate.AllowAddNewRow = false;
            this.GDVImageInfo.MasterTemplate.AllowColumnReorder = false;
            this.GDVImageInfo.MasterTemplate.AllowDragToGroup = false;
            this.GDVImageInfo.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "ID";
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "ID";
            gridViewTextBoxColumn1.VisibleInColumnChooser = false;
            gridViewTextBoxColumn1.Width = 110;
            gridViewTextBoxColumn2.FieldName = "MemberID";
            gridViewTextBoxColumn2.HeaderText = "MemberID";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "MemberID";
            gridViewTextBoxColumn2.VisibleInColumnChooser = false;
            gridViewTextBoxColumn2.Width = 83;
            gridViewTextBoxColumn3.FieldName = "ImageName";
            gridViewTextBoxColumn3.HeaderText = "ImageName";
            gridViewTextBoxColumn3.Name = "ImageName";
            gridViewTextBoxColumn3.Width = 164;
            gridViewTextBoxColumn4.FieldName = "Description";
            gridViewTextBoxColumn4.HeaderText = "Description";
            gridViewTextBoxColumn4.Name = "Description";
            gridViewTextBoxColumn4.Width = 166;
            this.GDVImageInfo.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.GDVImageInfo.MasterTemplate.EnableFiltering = true;
            this.GDVImageInfo.MasterTemplate.EnableGrouping = false;
            this.GDVImageInfo.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GDVImageInfo.Name = "GDVImageInfo";
            this.GDVImageInfo.ReadOnly = true;
            this.GDVImageInfo.Size = new System.Drawing.Size(350, 658);
            this.GDVImageInfo.TabIndex = 0;
            this.GDVImageInfo.Text = "radGridView1";
            this.GDVImageInfo.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.GDVImageInfo_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnImageDelete);
            this.groupBox2.Controls.Add(this.ImageView);
            this.groupBox2.Location = new System.Drawing.Point(381, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(622, 686);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "View Image";
            // 
            // ImageView
            // 
            this.ImageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageView.Location = new System.Drawing.Point(3, 18);
            this.ImageView.Name = "ImageView";
            this.ImageView.Size = new System.Drawing.Size(616, 665);
            this.ImageView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageView.TabIndex = 0;
            this.ImageView.TabStop = false;
            // 
            // btnImageDelete
            // 
            this.btnImageDelete.Location = new System.Drawing.Point(512, 662);
            this.btnImageDelete.Name = "btnImageDelete";
            this.btnImageDelete.Size = new System.Drawing.Size(110, 24);
            this.btnImageDelete.TabIndex = 1;
            this.btnImageDelete.Text = "Delete Image";
            this.btnImageDelete.Click += new System.EventHandler(this.btnImageDelete_Click);
            // 
            // frmMSImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 710);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMSImage";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmMSImage";
            this.Load += new System.EventHandler(this.frmMSImage_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GDVImageInfo.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GDVImageInfo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImageView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImageDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadGridView GDVImageInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox ImageView;
        private Telerik.WinControls.UI.RadButton btnImageDelete;
    }
}
