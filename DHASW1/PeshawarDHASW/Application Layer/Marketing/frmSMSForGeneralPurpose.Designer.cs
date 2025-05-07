namespace PeshawarDHASW.Application_Layer.Marketing
{
    partial class frmSMSForGeneralPurpose
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            this.lblremainingSMS = new Telerik.WinControls.UI.RadLabel();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.lblTotalSMS = new Telerik.WinControls.UI.RadLabel();
            this.lblSendSlot = new Telerik.WinControls.UI.RadLabel();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.btnSendSMS = new Telerik.WinControls.UI.RadButton();
            this.txtDateSMS = new Telerik.WinControls.UI.RadTextBox();
            this.txtSMSType = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnmobilenumers = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.lbltotalcount = new Telerik.WinControls.UI.RadLabel();
            this.DGVMObileData = new Telerik.WinControls.UI.RadGridView();
            this.SendSMSBluk = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.lblremainingSMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalSMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSendSlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSendSMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateSMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSMSType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnmobilenumers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbltotalcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMObileData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMObileData.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lblremainingSMS
            // 
            this.lblremainingSMS.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblremainingSMS.Location = new System.Drawing.Point(134, 311);
            this.lblremainingSMS.Name = "lblremainingSMS";
            this.lblremainingSMS.Size = new System.Drawing.Size(19, 30);
            this.lblremainingSMS.TabIndex = 12;
            this.lblremainingSMS.Text = "0";
            this.lblremainingSMS.Visible = false;
            // 
            // radLabel8
            // 
            this.radLabel8.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel8.Location = new System.Drawing.Point(65, 275);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(144, 30);
            this.radLabel8.TabIndex = 11;
            this.radLabel8.Text = "Remaining SMS";
            this.radLabel8.Visible = false;
            // 
            // lblTotalSMS
            // 
            this.lblTotalSMS.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSMS.Location = new System.Drawing.Point(118, 167);
            this.lblTotalSMS.Name = "lblTotalSMS";
            this.lblTotalSMS.Size = new System.Drawing.Size(19, 30);
            this.lblTotalSMS.TabIndex = 9;
            this.lblTotalSMS.Text = "0";
            // 
            // lblSendSlot
            // 
            this.lblSendSlot.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSendSlot.Location = new System.Drawing.Point(118, 239);
            this.lblSendSlot.Name = "lblSendSlot";
            this.lblSendSlot.Size = new System.Drawing.Size(19, 30);
            this.lblSendSlot.TabIndex = 10;
            this.lblSendSlot.Text = "0";
            this.lblSendSlot.Visible = false;
            // 
            // radLabel7
            // 
            this.radLabel7.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel7.Location = new System.Drawing.Point(78, 203);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(91, 30);
            this.radLabel7.TabIndex = 9;
            this.radLabel7.Text = "Send Slot";
            this.radLabel7.Visible = false;
            // 
            // radLabel5
            // 
            this.radLabel5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel5.Location = new System.Drawing.Point(23, 131);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(201, 30);
            this.radLabel5.TabIndex = 8;
            this.radLabel5.Text = "Total SMS for Sending";
            // 
            // btnSendSMS
            // 
            this.btnSendSMS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendSMS.Location = new System.Drawing.Point(128, 79);
            this.btnSendSMS.Name = "btnSendSMS";
            this.btnSendSMS.Size = new System.Drawing.Size(85, 33);
            this.btnSendSMS.TabIndex = 7;
            this.btnSendSMS.Text = "Start Sending";
            this.btnSendSMS.Click += new System.EventHandler(this.btnSendSMS_Click);
            // 
            // txtDateSMS
            // 
            this.txtDateSMS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDateSMS.Location = new System.Drawing.Point(90, 53);
            this.txtDateSMS.Name = "txtDateSMS";
            this.txtDateSMS.Size = new System.Drawing.Size(156, 20);
            this.txtDateSMS.TabIndex = 3;
            // 
            // txtSMSType
            // 
            this.txtSMSType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSMSType.Location = new System.Drawing.Point(90, 29);
            this.txtSMSType.Name = "txtSMSType";
            this.txtSMSType.Size = new System.Drawing.Size(156, 20);
            this.txtSMSType.TabIndex = 1;
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(8, 55);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(68, 18);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "Date of SMS";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(8, 31);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(55, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "SMS Type";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.lblremainingSMS);
            this.radGroupBox2.Controls.Add(this.radLabel8);
            this.radGroupBox2.Controls.Add(this.lblTotalSMS);
            this.radGroupBox2.Controls.Add(this.lblSendSlot);
            this.radGroupBox2.Controls.Add(this.radLabel7);
            this.radGroupBox2.Controls.Add(this.radLabel5);
            this.radGroupBox2.Controls.Add(this.btnSendSMS);
            this.radGroupBox2.Controls.Add(this.txtDateSMS);
            this.radGroupBox2.Controls.Add(this.txtSMSType);
            this.radGroupBox2.Controls.Add(this.radLabel2);
            this.radGroupBox2.Controls.Add(this.radLabel1);
            this.radGroupBox2.HeaderText = "Message Information";
            this.radGroupBox2.Location = new System.Drawing.Point(495, 11);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(263, 478);
            this.radGroupBox2.TabIndex = 1;
            this.radGroupBox2.Text = "Message Information";
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.btnmobilenumers);
            this.radGroupBox3.Controls.Add(this.radGroupBox1);
            this.radGroupBox3.Controls.Add(this.radGroupBox2);
            this.radGroupBox3.HeaderText = "Detail";
            this.radGroupBox3.Location = new System.Drawing.Point(1, 5);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Size = new System.Drawing.Size(768, 495);
            this.radGroupBox3.TabIndex = 4;
            this.radGroupBox3.Text = "Detail";
            // 
            // btnmobilenumers
            // 
            this.btnmobilenumers.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnmobilenumers.Location = new System.Drawing.Point(5, 21);
            this.btnmobilenumers.Name = "btnmobilenumers";
            this.btnmobilenumers.Size = new System.Drawing.Size(482, 39);
            this.btnmobilenumers.TabIndex = 2;
            this.btnmobilenumers.Text = "Load Mobile Numbers";
            this.btnmobilenumers.Click += new System.EventHandler(this.btnmobilenumers_Click);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.lbltotalcount);
            this.radGroupBox1.Controls.Add(this.DGVMObileData);
            this.radGroupBox1.HeaderText = "Mobile Nos";
            this.radGroupBox1.Location = new System.Drawing.Point(4, 68);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(485, 419);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Mobile Nos";
            // 
            // lbltotalcount
            // 
            this.lbltotalcount.Location = new System.Drawing.Point(135, -2);
            this.lbltotalcount.Name = "lbltotalcount";
            this.lbltotalcount.Size = new System.Drawing.Size(65, 18);
            this.lbltotalcount.TabIndex = 1;
            this.lbltotalcount.Text = "Total Count";
            // 
            // DGVMObileData
            // 
            this.DGVMObileData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.DGVMObileData.Cursor = System.Windows.Forms.Cursors.Default;
            this.DGVMObileData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVMObileData.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.DGVMObileData.ForeColor = System.Drawing.Color.Black;
            this.DGVMObileData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DGVMObileData.Location = new System.Drawing.Point(2, 18);
            // 
            // 
            // 
            this.DGVMObileData.MasterTemplate.AllowColumnReorder = false;
            this.DGVMObileData.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.DGVMObileData.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.DGVMObileData.Name = "DGVMObileData";
            this.DGVMObileData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DGVMObileData.Size = new System.Drawing.Size(481, 399);
            this.DGVMObileData.TabIndex = 0;
            this.DGVMObileData.Text = "radGridView1";
            // 
            // SendSMSBluk
            // 
            this.SendSMSBluk.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SendSMSBluk_DoWork);
            this.SendSMSBluk.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.SendSMSBluk_RunWorkerCompleted);
            // 
            // frmSMSForGeneralPurpose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 512);
            this.Controls.Add(this.radGroupBox3);
            this.Name = "frmSMSForGeneralPurpose";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmSMSForGeneralPurpose";
            ((System.ComponentModel.ISupportInitialize)(this.lblremainingSMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalSMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSendSlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSendSMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateSMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSMSType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnmobilenumers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbltotalcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMObileData.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMObileData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblremainingSMS;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadLabel lblTotalSMS;
        private Telerik.WinControls.UI.RadLabel lblSendSlot;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadButton btnSendSMS;
        private Telerik.WinControls.UI.RadTextBox txtDateSMS;
        private Telerik.WinControls.UI.RadTextBox txtSMSType;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private Telerik.WinControls.UI.RadButton btnmobilenumers;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadLabel lbltotalcount;
        private Telerik.WinControls.UI.RadGridView DGVMObileData;
        private System.ComponentModel.BackgroundWorker SendSMSBluk;
    }
}
