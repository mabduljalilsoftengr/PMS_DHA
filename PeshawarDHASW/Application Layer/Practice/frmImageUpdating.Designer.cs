namespace PeshawarDHASW.Application_Layer.Practice
{
    partial class frmImageUpdating
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
            this.btnBrowseFile = new System.Windows.Forms.Button();
            this.btnUploadtoDB = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowseFile
            // 
            this.btnBrowseFile.Location = new System.Drawing.Point(27, 12);
            this.btnBrowseFile.Name = "btnBrowseFile";
            this.btnBrowseFile.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseFile.TabIndex = 0;
            this.btnBrowseFile.Text = "Browse . . .";
            this.btnBrowseFile.UseVisualStyleBackColor = true;
            this.btnBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // btnUploadtoDB
            // 
            this.btnUploadtoDB.Location = new System.Drawing.Point(27, 42);
            this.btnUploadtoDB.Name = "btnUploadtoDB";
            this.btnUploadtoDB.Size = new System.Drawing.Size(75, 23);
            this.btnUploadtoDB.TabIndex = 1;
            this.btnUploadtoDB.Text = "Upload";
            this.btnUploadtoDB.UseVisualStyleBackColor = true;
            this.btnUploadtoDB.Click += new System.EventHandler(this.btnUploadtoDB_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(127, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(505, 308);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // frmImageUpdating
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 360);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnUploadtoDB);
            this.Controls.Add(this.btnBrowseFile);
            this.Name = "frmImageUpdating";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmImageUpdating";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowseFile;
        private System.Windows.Forms.Button btnUploadtoDB;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
