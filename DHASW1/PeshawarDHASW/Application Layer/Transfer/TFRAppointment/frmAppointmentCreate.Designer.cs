namespace PeshawarDHASW.Application_Layer.Transfer.TFRAppointment
{
    partial class frmAppointmentCreate
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
            this.AppointmentGB = new Telerik.WinControls.UI.RadGroupBox();
            this.btnCreateAppointment = new Telerik.WinControls.UI.RadButton();
            this.radLabel11 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel10 = new Telerik.WinControls.UI.RadLabel();
            this.dateofexpire = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dateofissue = new Telerik.WinControls.UI.RadDateTimePicker();
            this.lblremainDays = new Telerik.WinControls.UI.RadLabel();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.txtPlotNo = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.btnNDCVerification = new Telerik.WinControls.UI.RadButton();
            this.txtNDC = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.lblappointmentExist = new Telerik.WinControls.UI.RadLabel();
            this.txtfileno = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentGB)).BeginInit();
            this.AppointmentGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCreateAppointment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateofexpire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateofissue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblremainDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlotNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNDCVerification)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNDC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblappointmentExist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtfileno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // AppointmentGB
            // 
            this.AppointmentGB.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.AppointmentGB.Controls.Add(this.btnCreateAppointment);
            this.AppointmentGB.Controls.Add(this.radLabel11);
            this.AppointmentGB.Controls.Add(this.radLabel10);
            this.AppointmentGB.Controls.Add(this.dateofexpire);
            this.AppointmentGB.Controls.Add(this.dateofissue);
            this.AppointmentGB.Controls.Add(this.lblremainDays);
            this.AppointmentGB.Controls.Add(this.radLabel7);
            this.AppointmentGB.Enabled = false;
            this.AppointmentGB.HeaderText = "Create Appointment";
            this.AppointmentGB.Location = new System.Drawing.Point(12, 180);
            this.AppointmentGB.Name = "AppointmentGB";
            this.AppointmentGB.Size = new System.Drawing.Size(693, 261);
            this.AppointmentGB.TabIndex = 0;
            this.AppointmentGB.Text = "Create Appointment";
            this.AppointmentGB.ThemeName = "TelerikMetro";
            // 
            // btnCreateAppointment
            // 
            this.btnCreateAppointment.Location = new System.Drawing.Point(21, 173);
            this.btnCreateAppointment.Name = "btnCreateAppointment";
            this.btnCreateAppointment.Size = new System.Drawing.Size(532, 63);
            this.btnCreateAppointment.TabIndex = 5;
            this.btnCreateAppointment.Text = "Create Appointment";
            this.btnCreateAppointment.ThemeName = "TelerikMetro";
            this.btnCreateAppointment.Click += new System.EventHandler(this.btnCreateAppointment_Click);
            // 
            // radLabel11
            // 
            this.radLabel11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel11.Location = new System.Drawing.Point(21, 137);
            this.radLabel11.Name = "radLabel11";
            this.radLabel11.Size = new System.Drawing.Size(90, 25);
            this.radLabel11.TabIndex = 6;
            this.radLabel11.Text = "Expire Date";
            // 
            // radLabel10
            // 
            this.radLabel10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel10.Location = new System.Drawing.Point(21, 106);
            this.radLabel10.Name = "radLabel10";
            this.radLabel10.Size = new System.Drawing.Size(83, 25);
            this.radLabel10.TabIndex = 8;
            this.radLabel10.Text = "Issue Date";
            // 
            // dateofexpire
            // 
            this.dateofexpire.CustomFormat = "dd/MM/yyyy";
            this.dateofexpire.Enabled = false;
            this.dateofexpire.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateofexpire.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateofexpire.Location = new System.Drawing.Point(133, 140);
            this.dateofexpire.Name = "dateofexpire";
            this.dateofexpire.Size = new System.Drawing.Size(420, 27);
            this.dateofexpire.TabIndex = 7;
            this.dateofexpire.TabStop = false;
            this.dateofexpire.Text = "15/09/2016";
            this.dateofexpire.Value = new System.DateTime(2016, 9, 15, 9, 28, 59, 0);
            // 
            // dateofissue
            // 
            this.dateofissue.CustomFormat = "dd/MM/yyyy";
            this.dateofissue.Enabled = false;
            this.dateofissue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateofissue.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateofissue.Location = new System.Drawing.Point(133, 106);
            this.dateofissue.Name = "dateofissue";
            this.dateofissue.Size = new System.Drawing.Size(420, 27);
            this.dateofissue.TabIndex = 6;
            this.dateofissue.TabStop = false;
            this.dateofissue.Text = "15/09/2016";
            this.dateofissue.Value = new System.DateTime(2016, 9, 15, 9, 28, 59, 0);
            // 
            // lblremainDays
            // 
            this.lblremainDays.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblremainDays.Location = new System.Drawing.Point(196, 51);
            this.lblremainDays.Name = "lblremainDays";
            this.lblremainDays.Size = new System.Drawing.Size(79, 25);
            this.lblremainDays.TabIndex = 3;
            this.lblremainDays.Text = "radLabel6";
            // 
            // radLabel7
            // 
            this.radLabel7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel7.Location = new System.Drawing.Point(21, 50);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(140, 25);
            this.radLabel7.TabIndex = 2;
            this.radLabel7.Text = "NDC Remain Days";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.txtPlotNo);
            this.radGroupBox2.Controls.Add(this.radLabel3);
            this.radGroupBox2.Controls.Add(this.btnNDCVerification);
            this.radGroupBox2.Controls.Add(this.txtNDC);
            this.radGroupBox2.Controls.Add(this.radLabel2);
            this.radGroupBox2.Controls.Add(this.lblappointmentExist);
            this.radGroupBox2.Controls.Add(this.txtfileno);
            this.radGroupBox2.Controls.Add(this.radLabel1);
            this.radGroupBox2.Controls.Add(this.radLabel9);
            this.radGroupBox2.HeaderText = "Create Appointment";
            this.radGroupBox2.Location = new System.Drawing.Point(12, 12);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(693, 162);
            this.radGroupBox2.TabIndex = 1;
            this.radGroupBox2.Text = "Create Appointment";
            this.radGroupBox2.ThemeName = "TelerikMetro";
            // 
            // txtPlotNo
            // 
            this.txtPlotNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlotNo.Location = new System.Drawing.Point(359, 41);
            this.txtPlotNo.Name = "txtPlotNo";
            this.txtPlotNo.Size = new System.Drawing.Size(152, 27);
            this.txtPlotNo.TabIndex = 2;
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(291, 41);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(63, 25);
            this.radLabel3.TabIndex = 1;
            this.radLabel3.Text = "Plot No";
            // 
            // btnNDCVerification
            // 
            this.btnNDCVerification.Location = new System.Drawing.Point(359, 74);
            this.btnNDCVerification.Name = "btnNDCVerification";
            this.btnNDCVerification.Size = new System.Drawing.Size(152, 44);
            this.btnNDCVerification.TabIndex = 4;
            this.btnNDCVerification.Text = "Check";
            this.btnNDCVerification.ThemeName = "TelerikMetro";
            this.btnNDCVerification.Click += new System.EventHandler(this.btnNDCVerification_Click);
            // 
            // txtNDC
            // 
            this.txtNDC.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNDC.Location = new System.Drawing.Point(133, 74);
            this.txtNDC.Name = "txtNDC";
            this.txtNDC.Size = new System.Drawing.Size(152, 27);
            this.txtNDC.TabIndex = 3;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(21, 74);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(106, 25);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "NDC Number";
            // 
            // lblappointmentExist
            // 
            this.lblappointmentExist.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblappointmentExist.Location = new System.Drawing.Point(234, 117);
            this.lblappointmentExist.Name = "lblappointmentExist";
            this.lblappointmentExist.Size = new System.Drawing.Size(79, 25);
            this.lblappointmentExist.TabIndex = 5;
            this.lblappointmentExist.Text = "radLabel8";
            // 
            // txtfileno
            // 
            this.txtfileno.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfileno.Location = new System.Drawing.Point(133, 43);
            this.txtfileno.Name = "txtfileno";
            this.txtfileno.Size = new System.Drawing.Size(152, 27);
            this.txtfileno.TabIndex = 1;
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(21, 41);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(63, 25);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "File No ";
            // 
            // radLabel9
            // 
            this.radLabel9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel9.Location = new System.Drawing.Point(21, 117);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(207, 25);
            this.radLabel9.TabIndex = 4;
            this.radLabel9.Text = "Precious Appointment Exist";
            // 
            // frmAppointmentCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 453);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.AppointmentGB);
            this.Name = "frmAppointmentCreate";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Transfer Appointment Create";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.frmAppointmentCreate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentGB)).EndInit();
            this.AppointmentGB.ResumeLayout(false);
            this.AppointmentGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCreateAppointment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateofexpire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateofissue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblremainDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlotNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNDCVerification)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNDC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblappointmentExist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtfileno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadGroupBox AppointmentGB;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadTextBox txtPlotNo;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadButton btnNDCVerification;
        private Telerik.WinControls.UI.RadTextBox txtNDC;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox txtfileno;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton btnCreateAppointment;
        private Telerik.WinControls.UI.RadLabel radLabel11;
        private Telerik.WinControls.UI.RadLabel radLabel10;
        private Telerik.WinControls.UI.RadDateTimePicker dateofexpire;
        private Telerik.WinControls.UI.RadDateTimePicker dateofissue;
        private Telerik.WinControls.UI.RadLabel lblremainDays;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadLabel lblappointmentExist;
        private Telerik.WinControls.UI.RadLabel radLabel9;
    }
}
