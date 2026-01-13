namespace PeshawarDHASW.Application_Layer.User
{
    partial class UpdateSignature
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
            this.btnbrowse = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.lblfileName = new Telerik.WinControls.UI.RadLabel();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.lblUserName = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.btnbrowse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblfileName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnbrowse
            // 
            this.btnbrowse.Location = new System.Drawing.Point(2, 53);
            this.btnbrowse.Name = "btnbrowse";
            this.btnbrowse.Size = new System.Drawing.Size(117, 24);
            this.btnbrowse.TabIndex = 0;
            this.btnbrowse.Text = "Browse . . . ";
            this.btnbrowse.Click += new System.EventHandler(this.btnbrowse_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(2, 84);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(59, 18);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "File Name:";
            // 
            // lblfileName
            // 
            this.lblfileName.Location = new System.Drawing.Point(64, 84);
            this.lblfileName.Name = "lblfileName";
            this.lblfileName.Size = new System.Drawing.Size(42, 18);
            this.lblfileName.TabIndex = 2;
            this.lblfileName.Text = "--------";
            // 
            // picImage
            // 
            this.picImage.Location = new System.Drawing.Point(2, 108);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(194, 71);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage.TabIndex = 3;
            this.picImage.TabStop = false;
            // 
            // radButton2
            // 
            this.radButton2.Location = new System.Drawing.Point(2, 185);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(194, 28);
            this.radButton2.TabIndex = 1;
            this.radButton2.Text = "Save Changes";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(2, 3);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(64, 18);
            this.radLabel3.TabIndex = 2;
            this.radLabel3.Text = "User Name:";
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(5, 27);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(15, 18);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "--";
            // 
            // UpdateSignature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 221);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.lblfileName);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.btnbrowse);
            this.Name = "UpdateSignature";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "UpdateSignature";
            ((System.ComponentModel.ISupportInitialize)(this.btnbrowse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblfileName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadButton btnbrowse;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel lblfileName;
        private System.Windows.Forms.PictureBox picImage;
        private Telerik.WinControls.UI.RadButton radButton2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel lblUserName;
    }
}
