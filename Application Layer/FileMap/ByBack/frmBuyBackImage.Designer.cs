namespace PeshawarDHASW.Application_Layer.FileMap.ByBack
{
    partial class frmBuyBackImage
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.grdimages = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.pcbimage = new System.Windows.Forms.PictureBox();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdimages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdimages.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbimage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.radGroupBox1.Controls.Add(this.grdimages);
            this.radGroupBox1.HeaderText = "All Images";
            this.radGroupBox1.Location = new System.Drawing.Point(6, 4);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(259, 472);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "All Images";
            this.radGroupBox1.ThemeName = "TelerikMetro";
            // 
            // grdimages
            // 
            this.grdimages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grdimages.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdimages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdimages.EnableHotTracking = false;
            this.grdimages.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.grdimages.ForeColor = System.Drawing.Color.Black;
            this.grdimages.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdimages.Location = new System.Drawing.Point(2, 18);
            // 
            // 
            // 
            this.grdimages.MasterTemplate.AllowAddNewRow = false;
            this.grdimages.MasterTemplate.AllowColumnReorder = false;
            this.grdimages.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewImageColumn1.EnableExpressionEditor = false;
            gridViewImageColumn1.FieldName = "Image";
            gridViewImageColumn1.HeaderText = "Image";
            gridViewImageColumn1.Name = "Image";
            gridViewImageColumn1.Width = 234;
            this.grdimages.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewImageColumn1});
            this.grdimages.MasterTemplate.EnableGrouping = false;
            this.grdimages.MasterTemplate.EnableSorting = false;
            this.grdimages.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdimages.Name = "grdimages";
            this.grdimages.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grdimages.ShowGroupPanel = false;
            this.grdimages.Size = new System.Drawing.Size(255, 452);
            this.grdimages.TabIndex = 0;
            this.grdimages.Text = "radGridView1";
            this.grdimages.ThemeName = "TelerikMetro";
            this.grdimages.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdimages_CellClick);
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox2.Controls.Add(this.pcbimage);
            this.radGroupBox2.HeaderText = "Single Imaage View";
            this.radGroupBox2.Location = new System.Drawing.Point(271, 5);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(880, 514);
            this.radGroupBox2.TabIndex = 1;
            this.radGroupBox2.Text = "Single Imaage View";
            this.radGroupBox2.ThemeName = "TelerikMetro";
            // 
            // pcbimage
            // 
            this.pcbimage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pcbimage.Location = new System.Drawing.Point(13, 30);
            this.pcbimage.Name = "pcbimage";
            this.pcbimage.Size = new System.Drawing.Size(858, 472);
            this.pcbimage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbimage.TabIndex = 0;
            this.pcbimage.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(3, 482);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(257, 37);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.ThemeName = "TelerikMetro";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmBuyBackImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 531);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmBuyBackImage";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmBuyBackImage";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.frmBuyBackImage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdimages.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdimages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbimage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView grdimages;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private System.Windows.Forms.PictureBox pcbimage;
        private Telerik.WinControls.UI.RadButton btnSave;
    }
}
