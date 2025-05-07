namespace PeshawarDHASW.Application_Layer.Caution
{
    partial class frmCautionImageUpload
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
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn2 = new Telerik.WinControls.UI.GridViewImageColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.ImageSource = new Telerik.WinControls.UI.RadGridView();
            this.btnBrowseforSingleimage = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox4 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.txtFrontBack = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageSource.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowseforSingleimage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).BeginInit();
            this.radGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrontBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radGroupBox4);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(2, 6);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(726, 507);
            this.radGroupBox1.TabIndex = 0;
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
            this.ImageSource.Location = new System.Drawing.Point(10, 70);
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
            gridViewImageColumn2.EnableExpressionEditor = false;
            gridViewImageColumn2.FieldName = "MemberImage";
            gridViewImageColumn2.HeaderText = "Preview";
            gridViewImageColumn2.Name = "MemberImage";
            gridViewImageColumn2.Width = 538;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "Description";
            gridViewTextBoxColumn3.HeaderText = "Image Name";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "Description";
            gridViewTextBoxColumn3.Width = 178;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "ImageName";
            gridViewTextBoxColumn4.HeaderText = "Image Type";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "ImageName";
            gridViewTextBoxColumn4.Width = 110;
            gridViewCommandColumn2.DefaultText = "X";
            gridViewCommandColumn2.EnableExpressionEditor = false;
            gridViewCommandColumn2.FieldName = "btnRemove";
            gridViewCommandColumn2.HeaderText = "Remove";
            gridViewCommandColumn2.Name = "btnRemove";
            gridViewCommandColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.UseDefaultText = true;
            gridViewCommandColumn2.Width = 155;
            this.ImageSource.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewImageColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewCommandColumn2});
            this.ImageSource.MasterTemplate.EnableGrouping = false;
            this.ImageSource.MasterTemplate.ShowRowHeaderColumn = false;
            this.ImageSource.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.ImageSource.Name = "ImageSource";
            this.ImageSource.ReadOnly = true;
            this.ImageSource.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ImageSource.ShowGroupPanel = false;
            this.ImageSource.Size = new System.Drawing.Size(693, 402);
            this.ImageSource.TabIndex = 9;
            this.ImageSource.Text = "radGridView1";
            this.ImageSource.ThemeName = "TelerikMetro";
            this.ImageSource.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.ImageSource_CellClick);
            // 
            // btnBrowseforSingleimage
            // 
            this.btnBrowseforSingleimage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseforSingleimage.Location = new System.Drawing.Point(392, 31);
            this.btnBrowseforSingleimage.Name = "btnBrowseforSingleimage";
            this.btnBrowseforSingleimage.Size = new System.Drawing.Size(114, 26);
            this.btnBrowseforSingleimage.TabIndex = 10;
            this.btnBrowseforSingleimage.Text = "Add Attachment";
            this.btnBrowseforSingleimage.ThemeName = "TelerikMetro";
            this.btnBrowseforSingleimage.Click += new System.EventHandler(this.btnBrowseforSingleimage_Click);
            // 
            // radGroupBox4
            // 
            this.radGroupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox4.Controls.Add(this.radLabel1);
            this.radGroupBox4.Controls.Add(this.txtFrontBack);
            this.radGroupBox4.Controls.Add(this.btnSave);
            this.radGroupBox4.Controls.Add(this.ImageSource);
            this.radGroupBox4.Controls.Add(this.btnBrowseforSingleimage);
            this.radGroupBox4.HeaderText = "Attachment";
            this.radGroupBox4.Location = new System.Drawing.Point(10, 19);
            this.radGroupBox4.Name = "radGroupBox4";
            this.radGroupBox4.Size = new System.Drawing.Size(708, 477);
            this.radGroupBox4.TabIndex = 28;
            this.radGroupBox4.Text = "Attachment";
            this.radGroupBox4.ThemeName = "TelerikMetro";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(525, 27);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 31);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.ThemeName = "TelerikMetroBlue";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtFrontBack
            // 
            this.txtFrontBack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFrontBack.Location = new System.Drawing.Point(196, 31);
            this.txtFrontBack.Name = "txtFrontBack";
            this.txtFrontBack.Size = new System.Drawing.Size(170, 27);
            this.txtFrontBack.TabIndex = 12;
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(16, 32);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(173, 25);
            this.radLabel1.TabIndex = 13;
            this.radLabel1.Text = "Caution Add / Remove";
            // 
            // frmCautionImageUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 516);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmCautionImageUpload";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmCautionImageUpload";
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImageSource.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowseforSingleimage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).EndInit();
            this.radGroupBox4.ResumeLayout(false);
            this.radGroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrontBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox4;
        private Telerik.WinControls.UI.RadGridView ImageSource;
        private Telerik.WinControls.UI.RadButton btnBrowseforSingleimage;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtFrontBack;
    }
}
