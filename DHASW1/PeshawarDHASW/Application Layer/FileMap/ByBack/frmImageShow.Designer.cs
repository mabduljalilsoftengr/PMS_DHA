namespace PeshawarDHASW.Application_Layer.FileMap.ByBack
{
    partial class frmImageShow
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.grdimage = new Telerik.WinControls.UI.RadGridView();
            this.pcbbuybackimage = new System.Windows.Forms.PictureBox();
            this.btnDeleteDoc = new Telerik.WinControls.UI.RadButton();
            this.lblImage = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grdimage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdimage.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbbuybackimage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // grdimage
            // 
            this.grdimage.Location = new System.Drawing.Point(6, 9);
            // 
            // 
            // 
            this.grdimage.MasterTemplate.AllowAddNewRow = false;
            this.grdimage.MasterTemplate.AllowColumnReorder = false;
            this.grdimage.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewImageColumn2.FieldName = "ImageFile";
            gridViewImageColumn2.HeaderText = "Image File";
            gridViewImageColumn2.ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            gridViewImageColumn2.Name = "ImageFile";
            gridViewImageColumn2.Width = 286;
            gridViewTextBoxColumn2.FieldName = "ID";
            gridViewTextBoxColumn2.HeaderText = "ID";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "ID";
            gridViewTextBoxColumn2.Width = 43;
            this.grdimage.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewImageColumn2,
            gridViewTextBoxColumn2});
            this.grdimage.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grdimage.Name = "grdimage";
            this.grdimage.Size = new System.Drawing.Size(307, 662);
            this.grdimage.TabIndex = 0;
            this.grdimage.Text = "radGridView1";
            this.grdimage.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdimage_CellClick);
            // 
            // pcbbuybackimage
            // 
            this.pcbbuybackimage.Location = new System.Drawing.Point(319, 9);
            this.pcbbuybackimage.Name = "pcbbuybackimage";
            this.pcbbuybackimage.Size = new System.Drawing.Size(750, 662);
            this.pcbbuybackimage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbbuybackimage.TabIndex = 1;
            this.pcbbuybackimage.TabStop = false;
            // 
            // btnDeleteDoc
            // 
            this.btnDeleteDoc.Location = new System.Drawing.Point(959, 647);
            this.btnDeleteDoc.Name = "btnDeleteDoc";
            this.btnDeleteDoc.Size = new System.Drawing.Size(110, 24);
            this.btnDeleteDoc.TabIndex = 2;
            this.btnDeleteDoc.Text = "Delete Doc";
            this.btnDeleteDoc.Click += new System.EventHandler(this.btnDeleteDoc_Click);
            // 
            // lblImage
            // 
            this.lblImage.Location = new System.Drawing.Point(319, 653);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(11, 18);
            this.lblImage.TabIndex = 3;
            this.lblImage.Text = "-";
            // 
            // frmImageShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 677);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.btnDeleteDoc);
            this.Controls.Add(this.pcbbuybackimage);
            this.Controls.Add(this.grdimage);
            this.Name = "frmImageShow";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmImageShow";
            this.Load += new System.EventHandler(this.frmImageShow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdimage.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdimage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbbuybackimage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grdimage;
        private System.Windows.Forms.PictureBox pcbbuybackimage;
        private Telerik.WinControls.UI.RadButton btnDeleteDoc;
        private Telerik.WinControls.UI.RadLabel lblImage;
    }
}
