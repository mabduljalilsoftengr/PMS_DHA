namespace PeshawarDHASW.Application_Layer.Installment.InstReceive
{
    partial class ChallanImageUpload
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
            this.txtImageName = new Telerik.WinControls.UI.RadTextBoxControl();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnBrowseImage = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.lblstatusofimage = new Telerik.WinControls.UI.RadLabel();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.pbChallanimage = new System.Windows.Forms.PictureBox();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            ((System.ComponentModel.ISupportInitialize)(this.txtImageName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowseImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblstatusofimage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChallanimage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // txtImageName
            // 
            this.txtImageName.Location = new System.Drawing.Point(90, 34);
            this.txtImageName.Name = "txtImageName";
            this.txtImageName.Size = new System.Drawing.Size(239, 30);
            this.txtImageName.TabIndex = 0;
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.btnBrowseImage);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.txtImageName);
            this.radGroupBox1.HeaderText = "Image Detail";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(337, 138);
            this.radGroupBox1.TabIndex = 9;
            this.radGroupBox1.Text = "Image Detail";
            this.radGroupBox1.ThemeName = "TelerikMetro";
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseImage.Location = new System.Drawing.Point(14, 82);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(315, 32);
            this.btnBrowseImage.TabIndex = 6;
            this.btnBrowseImage.Text = "Browse Image";
            this.btnBrowseImage.ThemeName = "TelerikMetro";
            this.btnBrowseImage.Click += new System.EventHandler(this.btnBrowseImage_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(8, 38);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(70, 18);
            this.radLabel1.TabIndex = 4;
            this.radLabel1.Text = "Image Name";
            // 
            // lblstatusofimage
            // 
            this.lblstatusofimage.Location = new System.Drawing.Point(123, 225);
            this.lblstatusofimage.Name = "lblstatusofimage";
            this.lblstatusofimage.Size = new System.Drawing.Size(55, 18);
            this.lblstatusofimage.TabIndex = 12;
            this.lblstatusofimage.Text = "radLabel3";
            this.lblstatusofimage.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(12, 156);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(337, 51);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.ThemeName = "TelerikMetro";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pbChallanimage
            // 
            this.pbChallanimage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbChallanimage.Location = new System.Drawing.Point(355, 12);
            this.pbChallanimage.Name = "pbChallanimage";
            this.pbChallanimage.Size = new System.Drawing.Size(764, 395);
            this.pbChallanimage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbChallanimage.TabIndex = 10;
            this.pbChallanimage.TabStop = false;
            // 
            // ChallanImageUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 424);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.lblstatusofimage);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pbChallanimage);
            this.Name = "ChallanImageUpload";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Challan Image Upload";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.ChallanImageUpload_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtImageName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowseImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblstatusofimage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChallanimage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBoxControl txtImageName;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton btnBrowseImage;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel lblstatusofimage;
        private Telerik.WinControls.UI.RadButton btnSave;
        private System.Windows.Forms.PictureBox pbChallanimage;
        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
    }
}
