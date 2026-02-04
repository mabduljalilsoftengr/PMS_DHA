namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    partial class frmToComplete_The_Transfer
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
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.grdUploadImage = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUploadImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUploadImage.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.grdUploadImage);
            this.radGroupBox1.HeaderText = "To Upload The Image";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 3);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(527, 448);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "To Upload The Image";
            // 
            // grdUploadImage
            // 
            this.grdUploadImage.Location = new System.Drawing.Point(5, 21);
            // 
            // 
            // 
            this.grdUploadImage.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.HeaderText = "column1";
            gridViewTextBoxColumn1.Name = "column1";
            gridViewTextBoxColumn1.Width = 166;
            gridViewTextBoxColumn2.HeaderText = "column2";
            gridViewTextBoxColumn2.Name = "column2";
            gridViewTextBoxColumn2.Width = 166;
            gridViewCommandColumn1.FieldName = "Image_Upload";
            gridViewCommandColumn1.HeaderText = "Image Upload";
            gridViewCommandColumn1.Name = "Image_Upload";
            gridViewCommandColumn1.Width = 166;
            this.grdUploadImage.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewCommandColumn1});
            this.grdUploadImage.MasterTemplate.EnableGrouping = false;
            this.grdUploadImage.MasterTemplate.EnableSorting = false;
            this.grdUploadImage.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdUploadImage.Name = "grdUploadImage";
            this.grdUploadImage.ShowGroupPanel = false;
            this.grdUploadImage.Size = new System.Drawing.Size(517, 422);
            this.grdUploadImage.TabIndex = 0;
            this.grdUploadImage.Text = "radGridView1";
            this.grdUploadImage.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdUploadImage_CellClick);
            // 
            // frmToComplete_The_Transfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 457);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmToComplete_The_Transfer";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmToComplete_The_Transfer";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.frmToComplete_The_Transfer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUploadImage.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUploadImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView grdUploadImage;
    }
}
