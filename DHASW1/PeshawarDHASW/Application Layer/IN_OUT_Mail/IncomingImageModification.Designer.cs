namespace PeshawarDHASW.Application_Layer.IN_OUT_Mail
{
    partial class IncomingImageModification
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
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn2 = new Telerik.WinControls.UI.GridViewImageColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.GDVImageInfo = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.Image_View = new System.Windows.Forms.PictureBox();
            this.btnAddNew = new Telerik.WinControls.UI.RadButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDariyNo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GDVImageInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GDVImageInfo.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Image_View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // GDVImageInfo
            // 
            this.GDVImageInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GDVImageInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.GDVImageInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.GDVImageInfo.EnableGestures = false;
            this.GDVImageInfo.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.GDVImageInfo.ForeColor = System.Drawing.Color.Black;
            this.GDVImageInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GDVImageInfo.Location = new System.Drawing.Point(5, 21);
            // 
            // 
            // 
            this.GDVImageInfo.MasterTemplate.AllowAddNewRow = false;
            this.GDVImageInfo.MasterTemplate.AllowColumnReorder = false;
            this.GDVImageInfo.MasterTemplate.AllowDragToGroup = false;
            this.GDVImageInfo.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "ID";
            gridViewTextBoxColumn4.HeaderText = "Doc No";
            gridViewTextBoxColumn4.Name = "ID";
            gridViewTextBoxColumn4.VisibleInColumnChooser = false;
            gridViewTextBoxColumn4.Width = 38;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "MemberID";
            gridViewTextBoxColumn5.HeaderText = "MemberID";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "MemberID";
            gridViewTextBoxColumn5.VisibleInColumnChooser = false;
            gridViewTextBoxColumn5.Width = 83;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "Description";
            gridViewTextBoxColumn6.HeaderText = "Description";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "Description";
            gridViewTextBoxColumn6.Width = 184;
            gridViewImageColumn2.EnableExpressionEditor = false;
            gridViewImageColumn2.HeaderText = "ImageName";
            gridViewImageColumn2.Name = "ImageName";
            gridViewImageColumn2.Width = 134;
            gridViewCommandColumn2.DefaultText = "Remove";
            gridViewCommandColumn2.EnableExpressionEditor = false;
            gridViewCommandColumn2.HeaderText = "Edit";
            gridViewCommandColumn2.Name = "btnRemove";
            gridViewCommandColumn2.UseDefaultText = true;
            gridViewCommandColumn2.Width = 66;
            this.GDVImageInfo.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewImageColumn2,
            gridViewCommandColumn2});
            this.GDVImageInfo.MasterTemplate.EnableGrouping = false;
            this.GDVImageInfo.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.GDVImageInfo.Name = "GDVImageInfo";
            this.GDVImageInfo.ReadOnly = true;
            this.GDVImageInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GDVImageInfo.Size = new System.Drawing.Size(257, 472);
            this.GDVImageInfo.TabIndex = 1;
            this.GDVImageInfo.Text = "radGridView1";
            this.GDVImageInfo.ThemeName = "TelerikMetro";
            this.GDVImageInfo.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.GDVImageInfo_CellClick);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.GDVImageInfo);
            this.radGroupBox1.HeaderText = "Data";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 72);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(267, 498);
            this.radGroupBox1.TabIndex = 2;
            this.radGroupBox1.Text = "Data";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.Image_View);
            this.radGroupBox2.HeaderText = "Preview";
            this.radGroupBox2.Location = new System.Drawing.Point(285, 4);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(774, 561);
            this.radGroupBox2.TabIndex = 3;
            this.radGroupBox2.Text = "Preview";
            // 
            // Image_View
            // 
            this.Image_View.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Image_View.Location = new System.Drawing.Point(2, 18);
            this.Image_View.Name = "Image_View";
            this.Image_View.Size = new System.Drawing.Size(770, 541);
            this.Image_View.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Image_View.TabIndex = 0;
            this.Image_View.TabStop = false;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(17, 42);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(257, 24);
            this.btnAddNew.TabIndex = 4;
            this.btnAddNew.Text = "Add New Attachment";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Dairy No";
            // 
            // lblDariyNo
            // 
            this.lblDariyNo.AutoSize = true;
            this.lblDariyNo.Location = new System.Drawing.Point(88, 13);
            this.lblDariyNo.Name = "lblDariyNo";
            this.lblDariyNo.Size = new System.Drawing.Size(13, 13);
            this.lblDariyNo.TabIndex = 6;
            this.lblDariyNo.Text = "0";
            // 
            // IncomingImageModification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 573);
            this.Controls.Add(this.lblDariyNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "IncomingImageModification";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "IncomingImageModification";
            this.Load += new System.EventHandler(this.IncomingImageModification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GDVImageInfo.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GDVImageInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Image_View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView GDVImageInfo;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private System.Windows.Forms.PictureBox Image_View;
        private Telerik.WinControls.UI.RadButton btnAddNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDariyNo;
    }
}
