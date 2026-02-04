namespace PeshawarDHASW.Application_Layer.Splash
{
    partial class splashscreen
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.notificationtext = new Telerik.WinControls.UI.RadTextBox();
            this.splashtimer = new System.Windows.Forms.Timer(this.components);
            this.radProgressBar1 = new Telerik.WinControls.UI.RadProgressBar();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.lblClock = new Telerik.WinControls.UI.RadLabel();
            this.splashmainpicture = new System.Windows.Forms.PictureBox();
            this.lbluserinfo = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationtext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblClock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splashmainpicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbluserinfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PeshawarDHASW.Properties.Resources.DHALogo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(162, 172);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.notificationtext);
            this.groupBox1.Location = new System.Drawing.Point(0, 226);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(683, 105);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Notification";
            // 
            // notificationtext
            // 
            this.notificationtext.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notificationtext.AutoSize = false;
            this.notificationtext.Enabled = false;
            this.notificationtext.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationtext.Location = new System.Drawing.Point(7, 19);
            this.notificationtext.Multiline = true;
            this.notificationtext.Name = "notificationtext";
            this.notificationtext.ReadOnly = true;
            this.notificationtext.Size = new System.Drawing.Size(670, 80);
            this.notificationtext.TabIndex = 0;
            this.notificationtext.Text = "Welcome to DHA Peshawar ";
            this.notificationtext.ThemeName = "TelerikMetro";
            // 
            // splashtimer
            // 
            this.splashtimer.Enabled = true;
            this.splashtimer.Tick += new System.EventHandler(this.splashtimer_Tick);
            // 
            // radProgressBar1
            // 
            this.radProgressBar1.Dash = true;
            this.radProgressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radProgressBar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radProgressBar1.ForeColor = System.Drawing.Color.BlueViolet;
            this.radProgressBar1.Location = new System.Drawing.Point(0, 337);
            this.radProgressBar1.Name = "radProgressBar1";
            this.radProgressBar1.SeparatorColor1 = System.Drawing.Color.BlueViolet;
            this.radProgressBar1.SeparatorColor2 = System.Drawing.Color.Indigo;
            this.radProgressBar1.SeparatorColor3 = System.Drawing.Color.DarkOrchid;
            this.radProgressBar1.SeparatorColor4 = System.Drawing.Color.Fuchsia;
            this.radProgressBar1.Size = new System.Drawing.Size(683, 24);
            this.radProgressBar1.TabIndex = 3;
            this.radProgressBar1.Text = "radProgressBar1";
            this.radProgressBar1.ThemeName = "TelerikMetro";
            ((Telerik.WinControls.UI.RadProgressBarElement)(this.radProgressBar1.GetChildAt(0))).Dash = true;
            ((Telerik.WinControls.UI.RadProgressBarElement)(this.radProgressBar1.GetChildAt(0))).Text = "radProgressBar1";
            ((Telerik.WinControls.UI.ProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(0))).BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(7)))), ((int)(((byte)(252)))));
            ((Telerik.WinControls.UI.ProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(0))).BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(7)))), ((int)(((byte)(252)))));
            ((Telerik.WinControls.UI.ProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(0))).BorderColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(7)))), ((int)(((byte)(252)))));
            ((Telerik.WinControls.UI.ProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(0))).BorderColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(7)))), ((int)(((byte)(252)))));
            ((Telerik.WinControls.UI.ProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(0))).BorderInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(7)))), ((int)(((byte)(252)))));
            ((Telerik.WinControls.UI.ProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(0))).BorderInnerColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(7)))), ((int)(((byte)(252)))));
            ((Telerik.WinControls.UI.ProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(0))).BorderInnerColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(7)))), ((int)(((byte)(252)))));
            ((Telerik.WinControls.UI.ProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(0))).BorderInnerColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(7)))), ((int)(((byte)(252)))));
            ((Telerik.WinControls.UI.ProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(10)))), ((int)(((byte)(189)))));
            ((Telerik.WinControls.UI.ProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(7)))), ((int)(((byte)(196)))));
            ((Telerik.WinControls.UI.ProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(8)))), ((int)(((byte)(189)))));
            ((Telerik.WinControls.UI.ProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(0))).HorizontalLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            ((Telerik.WinControls.UI.ProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(7)))), ((int)(((byte)(252)))));
            ((Telerik.WinControls.UI.ProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(1))).BorderColor = System.Drawing.Color.BlueViolet;
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(1))).BorderColor2 = System.Drawing.Color.BlueViolet;
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(1))).BorderColor3 = System.Drawing.Color.BlueViolet;
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(1))).BorderColor4 = System.Drawing.Color.BlueViolet;
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(1))).BorderInnerColor = System.Drawing.Color.BlueViolet;
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(1))).BorderInnerColor2 = System.Drawing.Color.BlueViolet;
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(1))).BorderInnerColor3 = System.Drawing.Color.BlueViolet;
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(1))).BorderInnerColor4 = System.Drawing.Color.BlueViolet;
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(1))).BackColor2 = System.Drawing.Color.BlueViolet;
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(1))).BackColor3 = System.Drawing.Color.BlueViolet;
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(1))).BackColor4 = System.Drawing.Color.BlueViolet;
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(1))).BackColor = System.Drawing.Color.BlueViolet;
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.SeparatorsElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(2))).SeparatorColor1 = System.Drawing.Color.BlueViolet;
            ((Telerik.WinControls.UI.SeparatorsElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(2))).SeparatorColor2 = System.Drawing.Color.Indigo;
            ((Telerik.WinControls.UI.SeparatorsElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(2))).SeparatorColor3 = System.Drawing.Color.DarkOrchid;
            ((Telerik.WinControls.UI.SeparatorsElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(2))).SeparatorColor4 = System.Drawing.Color.Fuchsia;
            ((Telerik.WinControls.UI.SeparatorsElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(2))).BackColor = System.Drawing.Color.BlueViolet;
            ((Telerik.WinControls.UI.ProgressBarTextElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(3))).BackColor2 = System.Drawing.Color.Black;
            ((Telerik.WinControls.UI.ProgressBarTextElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(3))).BackColor3 = System.Drawing.Color.Black;
            ((Telerik.WinControls.UI.ProgressBarTextElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(3))).BackColor4 = System.Drawing.Color.Black;
            ((Telerik.WinControls.UI.ProgressBarTextElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(3))).Text = "radProgressBar1";
            ((Telerik.WinControls.UI.ProgressBarTextElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(3))).BackColor = System.Drawing.Color.Black;
            // 
            // lblClock
            // 
            this.lblClock.Font = new System.Drawing.Font("Felix Titling", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClock.Location = new System.Drawing.Point(27, 190);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(116, 27);
            this.lblClock.TabIndex = 4;
            this.lblClock.Text = "radLabel1";
            // 
            // splashmainpicture
            // 
            this.splashmainpicture.Image = global::PeshawarDHASW.Properties.Resources.studio;
            this.splashmainpicture.Location = new System.Drawing.Point(181, 12);
            this.splashmainpicture.Name = "splashmainpicture";
            this.splashmainpicture.Size = new System.Drawing.Size(490, 172);
            this.splashmainpicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.splashmainpicture.TabIndex = 5;
            this.splashmainpicture.TabStop = false;
            // 
            // lbluserinfo
            // 
            this.lbluserinfo.Font = new System.Drawing.Font("Felix Titling", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbluserinfo.Location = new System.Drawing.Point(181, 193);
            this.lbluserinfo.Name = "lbluserinfo";
            this.lbluserinfo.Size = new System.Drawing.Size(116, 27);
            this.lbluserinfo.TabIndex = 5;
            this.lbluserinfo.Text = "radLabel1";
            // 
            // splashscreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(683, 361);
            this.Controls.Add(this.lbluserinfo);
            this.Controls.Add(this.splashmainpicture);
            this.Controls.Add(this.lblClock);
            this.Controls.Add(this.radProgressBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "splashscreen";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "splashscreen";
            this.ThemeName = "TelerikMetro";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.notificationtext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblClock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splashmainpicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbluserinfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadTextBox notificationtext;
        private System.Windows.Forms.Timer splashtimer;
        private Telerik.WinControls.UI.RadProgressBar radProgressBar1;
        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadLabel lblClock;
        private System.Windows.Forms.PictureBox splashmainpicture;
        private Telerik.WinControls.UI.RadLabel lbluserinfo;
    }
}
