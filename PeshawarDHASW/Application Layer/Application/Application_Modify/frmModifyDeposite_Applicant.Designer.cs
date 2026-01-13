namespace PeshawarDHASW.Application_Layer.Application.Application_Modify
{
    partial class frmModifyDeposite_Applicant
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
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.cmbDDStatus = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.dtpDeposite = new System.Windows.Forms.DateTimePicker();
            this.label31 = new System.Windows.Forms.Label();
            this.txtbankcode = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtbank = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtamount = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtplotsize = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.btnSave);
            this.radGroupBox3.Controls.Add(this.cmbDDStatus);
            this.radGroupBox3.Controls.Add(this.label32);
            this.radGroupBox3.Controls.Add(this.dtpDeposite);
            this.radGroupBox3.Controls.Add(this.label31);
            this.radGroupBox3.Controls.Add(this.txtbankcode);
            this.radGroupBox3.Controls.Add(this.label30);
            this.radGroupBox3.Controls.Add(this.txtbank);
            this.radGroupBox3.Controls.Add(this.label29);
            this.radGroupBox3.Controls.Add(this.txtamount);
            this.radGroupBox3.Controls.Add(this.label28);
            this.radGroupBox3.Controls.Add(this.txtplotsize);
            this.radGroupBox3.Controls.Add(this.label27);
            this.radGroupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox3.HeaderText = "Application Fee Deposite";
            this.radGroupBox3.Location = new System.Drawing.Point(12, 12);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Size = new System.Drawing.Size(677, 197);
            this.radGroupBox3.TabIndex = 3;
            this.radGroupBox3.Text = "Application Fee Deposite";
            this.radGroupBox3.ThemeName = "TelerikMetro";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(22, 129);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(632, 52);
            this.btnSave.TabIndex = 53;
            this.btnSave.Text = "Save";
            this.btnSave.ThemeName = "TelerikMetro";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbDDStatus
            // 
            this.cmbDDStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDDStatus.FormattingEnabled = true;
            this.cmbDDStatus.Items.AddRange(new object[] {
            "Pending",
            "Accept",
            "Rejected"});
            this.cmbDDStatus.Location = new System.Drawing.Point(495, 67);
            this.cmbDDStatus.Name = "cmbDDStatus";
            this.cmbDDStatus.Size = new System.Drawing.Size(159, 21);
            this.cmbDDStatus.TabIndex = 52;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(361, 68);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(56, 20);
            this.label32.TabIndex = 51;
            this.label32.Text = "Status";
            // 
            // dtpDeposite
            // 
            this.dtpDeposite.CustomFormat = "yyyy/MM/dd";
            this.dtpDeposite.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDeposite.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDeposite.Location = new System.Drawing.Point(495, 33);
            this.dtpDeposite.Name = "dtpDeposite";
            this.dtpDeposite.Size = new System.Drawing.Size(157, 26);
            this.dtpDeposite.TabIndex = 50;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(359, 35);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(130, 20);
            this.label31.TabIndex = 49;
            this.label31.Text = "Date of Deposite";
            // 
            // txtbankcode
            // 
            this.txtbankcode.Location = new System.Drawing.Point(495, 97);
            this.txtbankcode.Name = "txtbankcode";
            this.txtbankcode.Size = new System.Drawing.Size(157, 20);
            this.txtbankcode.TabIndex = 13;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(361, 97);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(88, 20);
            this.label30.TabIndex = 12;
            this.label30.Text = "Bank Code";
            // 
            // txtbank
            // 
            this.txtbank.Location = new System.Drawing.Point(116, 97);
            this.txtbank.Name = "txtbank";
            this.txtbank.Size = new System.Drawing.Size(225, 20);
            this.txtbank.TabIndex = 11;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(18, 97);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(92, 20);
            this.label29.TabIndex = 10;
            this.label29.Text = "Bank Name";
            // 
            // txtamount
            // 
            this.txtamount.Location = new System.Drawing.Point(116, 65);
            this.txtamount.Name = "txtamount";
            this.txtamount.Size = new System.Drawing.Size(225, 20);
            this.txtamount.TabIndex = 9;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(18, 65);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(65, 20);
            this.label28.TabIndex = 8;
            this.label28.Text = "Amount";
            // 
            // txtplotsize
            // 
            this.txtplotsize.Location = new System.Drawing.Point(116, 35);
            this.txtplotsize.Name = "txtplotsize";
            this.txtplotsize.Size = new System.Drawing.Size(225, 20);
            this.txtplotsize.TabIndex = 7;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(18, 35);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(71, 20);
            this.label27.TabIndex = 6;
            this.label27.Text = "Plot Size";
            // 
            // frmModifyDeposite_Applicant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 236);
            this.Controls.Add(this.radGroupBox3);
            this.Name = "frmModifyDeposite_Applicant";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Modify the Deposite of Application";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.frmModifyDeposite_Applicant_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            this.radGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private Telerik.WinControls.UI.RadButton btnSave;
        private System.Windows.Forms.ComboBox cmbDDStatus;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.DateTimePicker dtpDeposite;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txtbankcode;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtbank;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtamount;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtplotsize;
        private System.Windows.Forms.Label label27;
    }
}
