namespace PeshawarDHASW.Application_Layer.Caution
{
    partial class frmCautionImageView
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.GDVImageInfo = new Telerik.WinControls.UI.RadGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ImageView = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.GDVImageInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GDVImageInfo.MasterTemplate)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageView)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
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
            gridViewTextBoxColumn4.FieldName = "CautionImageID";
            gridViewTextBoxColumn4.HeaderText = "CautionImageID";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "CautionImageID";
            gridViewTextBoxColumn4.VisibleInColumnChooser = false;
            gridViewTextBoxColumn4.Width = 83;
            gridViewTextBoxColumn5.FieldName = "CautionID";
            gridViewTextBoxColumn5.HeaderText = "CautionID";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "CautionID";
            gridViewTextBoxColumn5.VisibleInColumnChooser = false;
            gridViewTextBoxColumn5.Width = 83;
            gridViewTextBoxColumn6.FieldName = "CautionAddRemoveStatus";
            gridViewTextBoxColumn6.HeaderText = "Status";
            gridViewTextBoxColumn6.Name = "CautionAddRemoveStatus";
            gridViewTextBoxColumn6.Width = 329;
            this.GDVImageInfo.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.GDVImageInfo.MasterTemplate.EnableFiltering = true;
            this.GDVImageInfo.MasterTemplate.EnableGrouping = false;
            this.GDVImageInfo.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.GDVImageInfo.Name = "GDVImageInfo";
            this.GDVImageInfo.ReadOnly = true;
            this.GDVImageInfo.Size = new System.Drawing.Size(350, 672);
            this.GDVImageInfo.TabIndex = 0;
            this.GDVImageInfo.Text = "radGridView1";
            this.GDVImageInfo.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.GDVImageInfo_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.GDVImageInfo);
            this.groupBox1.Location = new System.Drawing.Point(-1, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 700);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Caution Images";
            // 
            // ImageView
            // 
            this.ImageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageView.Location = new System.Drawing.Point(3, 18);
            this.ImageView.Name = "ImageView";
            this.ImageView.Size = new System.Drawing.Size(768, 679);
            this.ImageView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageView.TabIndex = 0;
            this.ImageView.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.ImageView);
            this.groupBox2.Location = new System.Drawing.Point(368, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(774, 700);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "View Image";
            // 
            // frmCautionImageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 724);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmCautionImageView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmCautionImageView";
            this.Load += new System.EventHandler(this.frmCautionImageView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GDVImageInfo.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GDVImageInfo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImageView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView GDVImageInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox ImageView;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
