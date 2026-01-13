namespace PeshawarDHASW.Application_Layer.Transfer
{
    partial class frmNDCVerification
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
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnTransfer = new Telerik.WinControls.UI.RadButton();
            this.lblndcexpire = new Telerik.WinControls.UI.RadLabel();
            this.txtmsname = new Telerik.WinControls.UI.RadLabel();
            this.txtfileno = new Telerik.WinControls.UI.RadLabel();
            this.txtdateofexpire = new Telerik.WinControls.UI.RadLabel();
            this.txtdateofissue = new Telerik.WinControls.UI.RadLabel();
            this.btnNDCVerification = new Telerik.WinControls.UI.RadButton();
            this.txtNDCNumber = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnTransfer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblndcexpire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmsname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtfileno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdateofexpire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdateofissue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNDCVerification)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNDCNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radGroupBox1.Controls.Add(this.btnTransfer);
            this.radGroupBox1.Controls.Add(this.lblndcexpire);
            this.radGroupBox1.Controls.Add(this.txtmsname);
            this.radGroupBox1.Controls.Add(this.txtfileno);
            this.radGroupBox1.Controls.Add(this.txtdateofexpire);
            this.radGroupBox1.Controls.Add(this.txtdateofissue);
            this.radGroupBox1.Controls.Add(this.btnNDCVerification);
            this.radGroupBox1.Controls.Add(this.txtNDCNumber);
            this.radGroupBox1.HeaderText = "Verify NDC No";
            this.radGroupBox1.Location = new System.Drawing.Point(155, 62);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(526, 325);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Verify NDC No";
            this.radGroupBox1.ThemeName = "TelerikMetro";
            // 
            // btnTransfer
            // 
            this.btnTransfer.Location = new System.Drawing.Point(106, 272);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(296, 38);
            this.btnTransfer.TabIndex = 7;
            this.btnTransfer.Text = "Next to Transfer";
            this.btnTransfer.ThemeName = "TelerikMetro";
            this.btnTransfer.Visible = false;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // lblndcexpire
            // 
            this.lblndcexpire.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblndcexpire.ForeColor = System.Drawing.Color.Red;
            this.lblndcexpire.Location = new System.Drawing.Point(48, 171);
            this.lblndcexpire.Name = "lblndcexpire";
            this.lblndcexpire.Size = new System.Drawing.Size(420, 49);
            this.lblndcexpire.TabIndex = 6;
            this.lblndcexpire.Text = "NDC is Expired Or Not Issue";
            this.lblndcexpire.Visible = false;
            // 
            // txtmsname
            // 
            this.txtmsname.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmsname.Location = new System.Drawing.Point(106, 156);
            this.txtmsname.Name = "txtmsname";
            this.txtmsname.Size = new System.Drawing.Size(13, 30);
            this.txtmsname.TabIndex = 5;
            this.txtmsname.Text = ".";
            this.txtmsname.Visible = false;
            // 
            // txtfileno
            // 
            this.txtfileno.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfileno.Location = new System.Drawing.Point(106, 126);
            this.txtfileno.Name = "txtfileno";
            this.txtfileno.Size = new System.Drawing.Size(13, 30);
            this.txtfileno.TabIndex = 4;
            this.txtfileno.Text = ".";
            this.txtfileno.Visible = false;
            // 
            // txtdateofexpire
            // 
            this.txtdateofexpire.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdateofexpire.Location = new System.Drawing.Point(106, 226);
            this.txtdateofexpire.Name = "txtdateofexpire";
            this.txtdateofexpire.Size = new System.Drawing.Size(13, 30);
            this.txtdateofexpire.TabIndex = 4;
            this.txtdateofexpire.Text = ".";
            this.txtdateofexpire.Visible = false;
            // 
            // txtdateofissue
            // 
            this.txtdateofissue.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdateofissue.Location = new System.Drawing.Point(106, 190);
            this.txtdateofissue.Name = "txtdateofissue";
            this.txtdateofissue.Size = new System.Drawing.Size(13, 30);
            this.txtdateofissue.TabIndex = 3;
            this.txtdateofissue.Text = ".";
            this.txtdateofissue.Visible = false;
            // 
            // btnNDCVerification
            // 
            this.btnNDCVerification.Location = new System.Drawing.Point(106, 80);
            this.btnNDCVerification.Name = "btnNDCVerification";
            this.btnNDCVerification.Size = new System.Drawing.Size(296, 40);
            this.btnNDCVerification.TabIndex = 1;
            this.btnNDCVerification.Text = "Verify NDC";
            this.btnNDCVerification.ThemeName = "TelerikMetro";
            this.btnNDCVerification.Click += new System.EventHandler(this.btnNDCVerification_Click);
            // 
            // txtNDCNumber
            // 
            this.txtNDCNumber.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNDCNumber.Location = new System.Drawing.Point(106, 43);
            this.txtNDCNumber.Name = "txtNDCNumber";
            this.txtNDCNumber.NullText = "Enter NDc Number here . . . ";
            this.txtNDCNumber.Size = new System.Drawing.Size(296, 31);
            this.txtNDCNumber.TabIndex = 0;
            // 
            // frmNDCVerification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 412);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmNDCVerification";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "NDC Verification";
            this.ThemeName = "TelerikMetro";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNDCVerification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnTransfer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblndcexpire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmsname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtfileno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdateofexpire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdateofissue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNDCVerification)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNDCNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton btnNDCVerification;
        private Telerik.WinControls.UI.RadTextBox txtNDCNumber;
        private Telerik.WinControls.UI.RadLabel txtmsname;
        private Telerik.WinControls.UI.RadLabel txtfileno;
        private Telerik.WinControls.UI.RadLabel txtdateofexpire;
        private Telerik.WinControls.UI.RadLabel txtdateofissue;
        private Telerik.WinControls.UI.RadLabel lblndcexpire;
        private Telerik.WinControls.UI.RadButton btnTransfer;
    }
}
