namespace PeshawarDHASW.Application_Layer
{
    partial class maintestform
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
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.radButton3 = new Telerik.WinControls.UI.RadButton();
            this.radButton4 = new Telerik.WinControls.UI.RadButton();
            this.radButton5 = new Telerik.WinControls.UI.RadButton();
            this.SendSMSBluk = new System.ComponentModel.BackgroundWorker();
            this.lblname = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(24, 12);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(110, 37);
            this.radButton1.TabIndex = 0;
            this.radButton1.Text = "SMS Pak";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // radButton2
            // 
            this.radButton2.Location = new System.Drawing.Point(153, 12);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(158, 37);
            this.radButton2.TabIndex = 1;
            this.radButton2.Text = "Posession Verification";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // radButton3
            // 
            this.radButton3.Location = new System.Drawing.Point(333, 12);
            this.radButton3.Name = "radButton3";
            this.radButton3.Size = new System.Drawing.Size(158, 37);
            this.radButton3.TabIndex = 2;
            this.radButton3.Text = "Payment";
            this.radButton3.Click += new System.EventHandler(this.radButton3_Click);
            // 
            // radButton4
            // 
            this.radButton4.Location = new System.Drawing.Point(24, 55);
            this.radButton4.Name = "radButton4";
            this.radButton4.Size = new System.Drawing.Size(110, 40);
            this.radButton4.TabIndex = 3;
            this.radButton4.Text = "Notification";
            this.radButton4.Click += new System.EventHandler(this.radButton4_Click);
            // 
            // radButton5
            // 
            this.radButton5.Location = new System.Drawing.Point(153, 58);
            this.radButton5.Name = "radButton5";
            this.radButton5.Size = new System.Drawing.Size(158, 37);
            this.radButton5.TabIndex = 4;
            this.radButton5.Text = "SMS to Due Rmng Alert";
            this.radButton5.Click += new System.EventHandler(this.radButton5_Click);
            // 
            // SendSMSBluk
            // 
            this.SendSMSBluk.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SendSMSBluk_DoWork);
            this.SendSMSBluk.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.SendSMSBluk_RunWorkerCompleted);
            // 
            // lblname
            // 
            this.lblname.Location = new System.Drawing.Point(94, 122);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(55, 18);
            this.lblname.TabIndex = 5;
            this.lblname.Text = "radLabel1";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(94, 158);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(55, 18);
            this.radLabel1.TabIndex = 6;
            this.radLabel1.Text = "radLabel1";
            // 
            // maintestform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 216);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.lblname);
            this.Controls.Add(this.radButton5);
            this.Controls.Add(this.radButton4);
            this.Controls.Add(this.radButton3);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.radButton1);
            this.Name = "maintestform";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "maintestform";
            this.Load += new System.EventHandler(this.maintestform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadButton radButton2;
        private Telerik.WinControls.UI.RadButton radButton3;
        private Telerik.WinControls.UI.RadButton radButton4;
        private Telerik.WinControls.UI.RadButton radButton5;
        private System.ComponentModel.BackgroundWorker SendSMSBluk;
        private Telerik.WinControls.UI.RadLabel lblname;
        private Telerik.WinControls.UI.RadLabel radLabel1;
    }
}
