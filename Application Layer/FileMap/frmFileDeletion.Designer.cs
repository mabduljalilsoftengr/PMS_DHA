namespace PeshawarDHASW.Application_Layer.FileMap
{
    partial class frmFileDeletion
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.dtpDateEntry = new Telerik.WinControls.UI.RadDateTimePicker();
            this.txtStatus = new Telerik.WinControls.UI.RadTextBox();
            this.txtRemarks = new Telerik.WinControls.UI.RadTextBox();
            this.txtAuthority = new Telerik.WinControls.UI.RadTextBox();
            this.txtBranchno = new Telerik.WinControls.UI.RadTextBox();
            this.txtIONNo = new Telerik.WinControls.UI.RadTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grdReceInstallment = new Telerik.WinControls.UI.RadGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grdFileDetails = new Telerik.WinControls.UI.RadGridView();
            this.btnDeleteFile = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtFileNo = new Telerik.WinControls.UI.RadTextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateEntry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAuthority)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBranchno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIONNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReceInstallment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReceInstallment.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFileDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFileDetails.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radGroupBox2);
            this.radGroupBox1.Controls.Add(this.grdReceInstallment);
            this.radGroupBox1.Controls.Add(this.label3);
            this.radGroupBox1.Controls.Add(this.label2);
            this.radGroupBox1.Controls.Add(this.grdFileDetails);
            this.radGroupBox1.Controls.Add(this.btnDeleteFile);
            this.radGroupBox1.Controls.Add(this.btnFind);
            this.radGroupBox1.Controls.Add(this.txtFileNo);
            this.radGroupBox1.Controls.Add(this.label1);
            this.radGroupBox1.HeaderText = "File Deletion";
            this.radGroupBox1.Location = new System.Drawing.Point(12, -2);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1010, 694);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "File Deletion";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.dtpDateEntry);
            this.radGroupBox2.Controls.Add(this.txtStatus);
            this.radGroupBox2.Controls.Add(this.txtRemarks);
            this.radGroupBox2.Controls.Add(this.txtAuthority);
            this.radGroupBox2.Controls.Add(this.txtBranchno);
            this.radGroupBox2.Controls.Add(this.txtIONNo);
            this.radGroupBox2.Controls.Add(this.label9);
            this.radGroupBox2.Controls.Add(this.label8);
            this.radGroupBox2.Controls.Add(this.label7);
            this.radGroupBox2.Controls.Add(this.label6);
            this.radGroupBox2.Controls.Add(this.label5);
            this.radGroupBox2.Controls.Add(this.label4);
            this.radGroupBox2.HeaderText = "Information";
            this.radGroupBox2.Location = new System.Drawing.Point(5, 398);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(1000, 231);
            this.radGroupBox2.TabIndex = 1;
            this.radGroupBox2.Text = "Information";
            // 
            // dtpDateEntry
            // 
            this.dtpDateEntry.Culture = new System.Globalization.CultureInfo("en");
            this.dtpDateEntry.CustomFormat = "dd/MM/yyyy";
            this.dtpDateEntry.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateEntry.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateEntry.Location = new System.Drawing.Point(154, 28);
            this.dtpDateEntry.Name = "dtpDateEntry";
            this.dtpDateEntry.Size = new System.Drawing.Size(267, 27);
            this.dtpDateEntry.TabIndex = 13;
            this.dtpDateEntry.TabStop = false;
            this.dtpDateEntry.Text = "18/07/2017";
            this.dtpDateEntry.Value = new System.DateTime(2017, 7, 18, 13, 2, 39, 254);
            // 
            // txtStatus
            // 
            this.txtStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(658, 68);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(267, 27);
            this.txtStatus.TabIndex = 12;
            // 
            // txtRemarks
            // 
            this.txtRemarks.AutoSize = false;
            this.txtRemarks.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(658, 103);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(267, 80);
            this.txtRemarks.TabIndex = 11;
            // 
            // txtAuthority
            // 
            this.txtAuthority.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuthority.Location = new System.Drawing.Point(658, 29);
            this.txtAuthority.Name = "txtAuthority";
            this.txtAuthority.Size = new System.Drawing.Size(267, 27);
            this.txtAuthority.TabIndex = 10;
            // 
            // txtBranchno
            // 
            this.txtBranchno.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranchno.Location = new System.Drawing.Point(154, 156);
            this.txtBranchno.Name = "txtBranchno";
            this.txtBranchno.Size = new System.Drawing.Size(267, 27);
            this.txtBranchno.TabIndex = 9;
            // 
            // txtIONNo
            // 
            this.txtIONNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIONNo.Location = new System.Drawing.Point(154, 92);
            this.txtIONNo.Name = "txtIONNo";
            this.txtIONNo.Size = new System.Drawing.Size(267, 27);
            this.txtIONNo.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(537, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 21);
            this.label9.TabIndex = 6;
            this.label9.Text = "Status";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(537, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 21);
            this.label8.TabIndex = 5;
            this.label8.Text = "Remarks";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(537, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 21);
            this.label7.TabIndex = 4;
            this.label7.Text = "By Authority";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 21);
            this.label6.TabIndex = 3;
            this.label6.Text = "Branch";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 21);
            this.label5.TabIndex = 2;
            this.label5.Text = "ION No.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 21);
            this.label4.TabIndex = 1;
            this.label4.Text = "Date";
            // 
            // grdReceInstallment
            // 
            this.grdReceInstallment.Location = new System.Drawing.Point(648, 96);
            // 
            // 
            // 
            this.grdReceInstallment.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.grdReceInstallment.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdReceInstallment.Name = "grdReceInstallment";
            this.grdReceInstallment.Size = new System.Drawing.Size(357, 296);
            this.grdReceInstallment.TabIndex = 7;
            this.grdReceInstallment.Text = "radGridView1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(659, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(262, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "File Receive Installment Information ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "File Owner Information";
            // 
            // grdFileDetails
            // 
            this.grdFileDetails.Location = new System.Drawing.Point(5, 96);
            // 
            // 
            // 
            this.grdFileDetails.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.grdFileDetails.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grdFileDetails.Name = "grdFileDetails";
            this.grdFileDetails.Size = new System.Drawing.Size(637, 296);
            this.grdFileDetails.TabIndex = 4;
            this.grdFileDetails.Text = "radGridView1";
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteFile.Location = new System.Drawing.Point(337, 635);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(305, 48);
            this.btnDeleteFile.TabIndex = 3;
            this.btnDeleteFile.Text = "Delete File ";
            this.btnDeleteFile.UseVisualStyleBackColor = true;
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Location = new System.Drawing.Point(429, 19);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 28);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            // 
            // txtFileNo
            // 
            this.txtFileNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileNo.Location = new System.Drawing.Point(128, 20);
            this.txtFileNo.Name = "txtFileNo";
            this.txtFileNo.Size = new System.Drawing.Size(267, 27);
            this.txtFileNo.TabIndex = 1;
            this.txtFileNo.Leave += new System.EventHandler(this.txtFileNo_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter File No.";
            // 
            // frmFileDeletion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 696);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmFileDeletion";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmFileDeletion";
            this.ThemeName = "TelerikMetro";
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateEntry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAuthority)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBranchno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIONNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReceInstallment.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReceInstallment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFileDetails.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFileDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView grdFileDetails;
        private System.Windows.Forms.Button btnDeleteFile;
        private System.Windows.Forms.Button btnFind;
        private Telerik.WinControls.UI.RadTextBox txtFileNo;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadGridView grdReceInstallment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadDateTimePicker dtpDateEntry;
        private Telerik.WinControls.UI.RadTextBox txtStatus;
        private Telerik.WinControls.UI.RadTextBox txtRemarks;
        private Telerik.WinControls.UI.RadTextBox txtAuthority;
        private Telerik.WinControls.UI.RadTextBox txtBranchno;
        private Telerik.WinControls.UI.RadTextBox txtIONNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}
