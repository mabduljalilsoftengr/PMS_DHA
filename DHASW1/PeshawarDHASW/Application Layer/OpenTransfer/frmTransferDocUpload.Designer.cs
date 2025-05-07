namespace PeshawarDHASW.Application_Layer.OpenTransfer
{
    partial class frmTransferDocUpload
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
            this.btnFileUpload = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.lblFilePath = new Telerik.WinControls.UI.RadLabel();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.btnUploadReporttoDB = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnFileUpload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilePath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUploadReporttoDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFileUpload
            // 
            this.btnFileUpload.Location = new System.Drawing.Point(12, 47);
            this.btnFileUpload.Name = "btnFileUpload";
            this.btnFileUpload.Size = new System.Drawing.Size(139, 29);
            this.btnFileUpload.TabIndex = 5;
            this.btnFileUpload.Text = "Browse . . .";
            this.btnFileUpload.ThemeName = "TelerikMetro";
            this.btnFileUpload.Click += new System.EventHandler(this.btnFileUpload_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(13, 23);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(23, 18);
            this.radLabel1.TabIndex = 6;
            this.radLabel1.Text = "File";
            // 
            // lblFilePath
            // 
            this.lblFilePath.Location = new System.Drawing.Point(42, 23);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(23, 18);
            this.lblFilePath.TabIndex = 7;
            this.lblFilePath.Text = ". . . ";
            // 
            // btnUploadReporttoDB
            // 
            this.btnUploadReporttoDB.Location = new System.Drawing.Point(157, 47);
            this.btnUploadReporttoDB.Name = "btnUploadReporttoDB";
            this.btnUploadReporttoDB.Size = new System.Drawing.Size(139, 29);
            this.btnUploadReporttoDB.TabIndex = 6;
            this.btnUploadReporttoDB.Text = "Upload Report";
            this.btnUploadReporttoDB.ThemeName = "TelerikMetro";
            this.btnUploadReporttoDB.Click += new System.EventHandler(this.btnUploadReporttoDB_Click);
            // 
            // frmTransferDocUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 112);
            this.Controls.Add(this.btnUploadReporttoDB);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.btnFileUpload);
            this.Name = "frmTransferDocUpload";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmTransferDocUpload";
            this.ThemeName = "TelerikMetro";
            ((System.ComponentModel.ISupportInitialize)(this.btnFileUpload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilePath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUploadReporttoDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnFileUpload;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel lblFilePath;
        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadButton btnUploadReporttoDB;
    }
}
