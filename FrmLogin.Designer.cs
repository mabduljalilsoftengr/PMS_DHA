namespace PeshawarDHASW
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.txtusername = new Telerik.WinControls.UI.RadTextBox();
            this.txtpassword = new Telerik.WinControls.UI.RadTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.object_576f1736_6f88_4d6e_862a_a660e8598044 = new Telerik.WinControls.RootRadElement();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.officeShape1 = new Telerik.WinControls.UI.OfficeShape();
            this.ellipseShape1 = new Telerik.WinControls.EllipseShape();
            this.radThemeManager1 = new Telerik.WinControls.RadThemeManager();
            this.btnlogin = new Telerik.WinControls.UI.RadButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnexit = new Telerik.WinControls.UI.RadButton();
            this.btnforgotpwd = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtusername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnlogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnexit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnforgotpwd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // txtusername
            // 
            this.txtusername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtusername.BackColor = System.Drawing.Color.Gray;
            this.txtusername.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtusername.Location = new System.Drawing.Point(513, 390);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(308, 36);
            this.txtusername.TabIndex = 0;
            this.txtusername.ThemeName = "TelerikMetro";
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.txtusername.GetChildAt(0).GetChildAt(0))).NullTextColor = System.Drawing.Color.White;
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.txtusername.GetChildAt(0).GetChildAt(0))).ForeColor = System.Drawing.Color.Black;
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.txtusername.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.White;
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.txtusername.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtusername.GetChildAt(0).GetChildAt(2))).LeftColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtusername.GetChildAt(0).GetChildAt(2))).TopColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtusername.GetChildAt(0).GetChildAt(2))).RightColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtusername.GetChildAt(0).GetChildAt(2))).BottomColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtusername.GetChildAt(0).GetChildAt(2))).PaintUsingParentShape = true;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtusername.GetChildAt(0).GetChildAt(2))).BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtusername.GetChildAt(0).GetChildAt(2))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtusername.GetChildAt(0).GetChildAt(2))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            // 
            // txtpassword
            // 
            this.txtpassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtpassword.BackColor = System.Drawing.Color.Gray;
            this.txtpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpassword.Location = new System.Drawing.Point(513, 430);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '●';
            this.txtpassword.Size = new System.Drawing.Size(308, 36);
            this.txtpassword.TabIndex = 1;
            this.txtpassword.ThemeName = "TelerikMetro";
            this.txtpassword.UseSystemPasswordChar = true;
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.txtpassword.GetChildAt(0).GetChildAt(0))).ForeColor = System.Drawing.Color.Black;
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.txtpassword.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.White;
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.txtpassword.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtpassword.GetChildAt(0).GetChildAt(2))).LeftColor = System.Drawing.Color.Black;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtpassword.GetChildAt(0).GetChildAt(2))).TopColor = System.Drawing.Color.Black;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtpassword.GetChildAt(0).GetChildAt(2))).RightColor = System.Drawing.Color.Black;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtpassword.GetChildAt(0).GetChildAt(2))).BottomColor = System.Drawing.Color.Black;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtpassword.GetChildAt(0).GetChildAt(2))).BackColor = System.Drawing.Color.Black;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtpassword.GetChildAt(0).GetChildAt(2))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            // 
            // object_576f1736_6f88_4d6e_862a_a660e8598044
            // 
            this.object_576f1736_6f88_4d6e_862a_a660e8598044.Name = "object_576f1736_6f88_4d6e_862a_a660e8598044";
            this.object_576f1736_6f88_4d6e_862a_a660e8598044.StretchHorizontally = true;
            this.object_576f1736_6f88_4d6e_862a_a660e8598044.StretchVertically = true;
            // 
            // btnlogin
            // 
            this.btnlogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnlogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.btnlogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnlogin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogin.Image = global::PeshawarDHASW.Properties.Resources.login;
            this.btnlogin.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnlogin.Location = new System.Drawing.Point(555, 485);
            this.btnlogin.Name = "btnlogin";
            // 
            // 
            // 
            this.btnlogin.RootElement.FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            this.btnlogin.Size = new System.Drawing.Size(64, 64);
            this.btnlogin.TabIndex = 2;
            this.btnlogin.ThemeName = "Windows8";
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnlogin.GetChildAt(0))).Image = global::PeshawarDHASW.Properties.Resources.login;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnlogin.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnlogin.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnlogin.GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnlogin.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnlogin.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnlogin.GetChildAt(0).GetChildAt(0))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnlogin.GetChildAt(0).GetChildAt(0))).ShouldPaint = true;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnlogin.GetChildAt(0).GetChildAt(0))).Shape = null;
            ((Telerik.WinControls.Layouts.ImageAndTextLayoutPanel)(this.btnlogin.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Visible;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.btnlogin.GetChildAt(0).GetChildAt(1).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.btnlogin.GetChildAt(0).GetChildAt(1).GetChildAt(0))).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.btnlogin.GetChildAt(0).GetChildAt(1).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Visible;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnlogin.GetChildAt(0).GetChildAt(2))).BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnlogin.GetChildAt(0).GetChildAt(2))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnlogin.GetChildAt(0).GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            ((Telerik.WinControls.Primitives.FocusPrimitive)(this.btnlogin.GetChildAt(0).GetChildAt(3))).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::PeshawarDHASW.Properties.Resources.password;
            this.pictureBox2.Location = new System.Drawing.Point(472, 430);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 33);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::PeshawarDHASW.Properties.Resources.username;
            this.pictureBox1.Location = new System.Drawing.Point(472, 390);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 36);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnexit
            // 
            this.btnexit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnexit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexit.Image = global::PeshawarDHASW.Properties.Resources.logout;
            this.btnexit.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnexit.Location = new System.Drawing.Point(695, 485);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(64, 64);
            this.btnexit.TabIndex = 4;
            this.btnexit.ThemeName = "Windows8";
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnexit.GetChildAt(0))).Image = global::PeshawarDHASW.Properties.Resources.logout;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnexit.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnexit.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnexit.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Visible;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnexit.GetChildAt(0).GetChildAt(2))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnexit.GetChildAt(0).GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            ((Telerik.WinControls.Primitives.FocusPrimitive)(this.btnexit.GetChildAt(0).GetChildAt(3))).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            // 
            // btnforgotpwd
            // 
            this.btnforgotpwd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnforgotpwd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnforgotpwd.Image = global::PeshawarDHASW.Properties.Resources.forgotpassword;
            this.btnforgotpwd.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnforgotpwd.Location = new System.Drawing.Point(625, 485);
            this.btnforgotpwd.Name = "btnforgotpwd";
            this.btnforgotpwd.Size = new System.Drawing.Size(64, 64);
            this.btnforgotpwd.TabIndex = 3;
            this.btnforgotpwd.ThemeName = "Windows8";
            this.btnforgotpwd.Click += new System.EventHandler(this.btnforgotpwd_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnforgotpwd.GetChildAt(0))).Image = global::PeshawarDHASW.Properties.Resources.forgotpassword;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnforgotpwd.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnforgotpwd.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnforgotpwd.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Visible;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnforgotpwd.GetChildAt(0).GetChildAt(2))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnforgotpwd.GetChildAt(0).GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.btnlogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::PeshawarDHASW.Properties.Resources.loginbagckgournd3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1254, 693);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btnforgotpwd);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.txtusername);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IconScaling = Telerik.WinControls.Enumerations.ImageScaling.None;
            this.Name = "FrmLogin";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "PMS";
            this.ThemeName = "TelerikMetro";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.Shown += new System.EventHandler(this.FrmLogin_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.txtusername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnlogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnexit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnforgotpwd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBox txtusername;
        private Telerik.WinControls.UI.RadTextBox txtpassword;
        private Telerik.WinControls.UI.RadButton btnlogin;
        private Telerik.WinControls.UI.RadButton btnforgotpwd;
        private Telerik.WinControls.UI.RadButton btnexit;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.RootRadElement object_576f1736_6f88_4d6e_862a_a660e8598044;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private Telerik.WinControls.UI.OfficeShape officeShape1;
        private Telerik.WinControls.EllipseShape ellipseShape1;
        private Telerik.WinControls.RadThemeManager radThemeManager1;
    }
}