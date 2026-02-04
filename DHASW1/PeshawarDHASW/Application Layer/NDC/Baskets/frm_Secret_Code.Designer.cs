namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    partial class frm_Secret_Code
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
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.txtSecretCode = new Telerik.WinControls.UI.RadTextBox();
            this.btnSecretCode = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecretCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSecretCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSecretCode
            // 
            this.txtSecretCode.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecretCode.Location = new System.Drawing.Point(92, 43);
            this.txtSecretCode.Name = "txtSecretCode";
            this.txtSecretCode.PasswordChar = '*';
            this.txtSecretCode.Size = new System.Drawing.Size(343, 31);
            this.txtSecretCode.TabIndex = 0;
            // 
            // btnSecretCode
            // 
            this.btnSecretCode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSecretCode.Location = new System.Drawing.Point(92, 80);
            this.btnSecretCode.Name = "btnSecretCode";
            this.btnSecretCode.Size = new System.Drawing.Size(343, 51);
            this.btnSecretCode.TabIndex = 1;
            this.btnSecretCode.Text = "Check for Permission";
            this.btnSecretCode.Click += new System.EventHandler(this.btnSecretCode_Click);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.btnSecretCode);
            this.radGroupBox1.Controls.Add(this.txtSecretCode);
            this.radGroupBox1.HeaderText = "Secret Code";
            this.radGroupBox1.Location = new System.Drawing.Point(118, 52);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(521, 154);
            this.radGroupBox1.TabIndex = 2;
            this.radGroupBox1.Text = "Secret Code";
            // 
            // frm_Secret_Code
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 268);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frm_Secret_Code";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Secret Code";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.frm_Secret_Code_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtSecretCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSecretCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadTextBox txtSecretCode;
        private Telerik.WinControls.UI.RadButton btnSecretCode;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    }
}
