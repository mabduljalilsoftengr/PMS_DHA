namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    partial class frm_NDC_ImageUpload
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
            this.telerikMetroBlueTheme1 = new Telerik.WinControls.Themes.TelerikMetroBlueTheme();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnForward = new Telerik.WinControls.UI.RadButton();
            this.btnBack = new Telerik.WinControls.UI.RadButton();
            this.btn_SaveImage = new Telerik.WinControls.UI.RadButton();
            this.btnBrows = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.pbNDC_Image = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnForward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_SaveImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNDC_Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radGroupBox2);
            this.radGroupBox1.Controls.Add(this.btnForward);
            this.radGroupBox1.Controls.Add(this.btnBack);
            this.radGroupBox1.Controls.Add(this.btn_SaveImage);
            this.radGroupBox1.Controls.Add(this.btnBrows);
            this.radGroupBox1.HeaderText = "Image Upload";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(838, 611);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Image Upload";
            // 
            // btnForward
            // 
            this.btnForward.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForward.Location = new System.Drawing.Point(574, 552);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(152, 51);
            this.btnForward.TabIndex = 3;
            this.btnForward.Text = "Forward >>";
            this.btnForward.Visible = false;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(258, 552);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(152, 51);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "<< Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btn_SaveImage
            // 
            this.btn_SaveImage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SaveImage.Location = new System.Drawing.Point(416, 552);
            this.btn_SaveImage.Name = "btn_SaveImage";
            this.btn_SaveImage.Size = new System.Drawing.Size(152, 51);
            this.btn_SaveImage.TabIndex = 1;
            this.btn_SaveImage.Text = "Save";
            this.btn_SaveImage.Click += new System.EventHandler(this.btn_SaveImage_Click);
            // 
            // btnBrows
            // 
            this.btnBrows.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrows.Location = new System.Drawing.Point(100, 552);
            this.btnBrows.Name = "btnBrows";
            this.btnBrows.Size = new System.Drawing.Size(152, 51);
            this.btnBrows.TabIndex = 0;
            this.btnBrows.Text = "Brows Image . . . ";
            this.btnBrows.Click += new System.EventHandler(this.btnBrows_Click);
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.pbNDC_Image);
            this.radGroupBox2.HeaderText = "Image";
            this.radGroupBox2.Location = new System.Drawing.Point(5, 21);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(826, 525);
            this.radGroupBox2.TabIndex = 1;
            this.radGroupBox2.Text = "Image";
            // 
            // pbNDC_Image
            // 
            this.pbNDC_Image.Location = new System.Drawing.Point(5, 21);
            this.pbNDC_Image.Name = "pbNDC_Image";
            this.pbNDC_Image.Size = new System.Drawing.Size(816, 499);
            this.pbNDC_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbNDC_Image.TabIndex = 0;
            this.pbNDC_Image.TabStop = false;
            // 
            // frm_NDC_ImageUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 623);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frm_NDC_ImageUpload";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frm_NDC_ImageUpload";
            this.ThemeName = "TelerikMetroBlue";
            this.Load += new System.EventHandler(this.frm_NDC_ImageUpload_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnForward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_SaveImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbNDC_Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroBlueTheme telerikMetroBlueTheme1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton btn_SaveImage;
        private Telerik.WinControls.UI.RadButton btnBrows;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private System.Windows.Forms.PictureBox pbNDC_Image;
        private Telerik.WinControls.UI.RadButton btnForward;
        private Telerik.WinControls.UI.RadButton btnBack;
    }
}
