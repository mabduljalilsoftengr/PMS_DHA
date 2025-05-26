namespace PeshawarDHASW.Application_Layer.NDC.FBR
{
    partial class frmImportFBRDatafrom_ExcelToDatabase
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
            this.btnImportFromExcelToDatabase = new Telerik.WinControls.UI.RadButton();
            this.lblSuccessmessage = new Telerik.WinControls.UI.RadLabel();
            this.btnDownload = new Telerik.WinControls.UI.RadButton();
            this.prgbdownload = new System.Windows.Forms.ProgressBar();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvActivityLog = new System.Windows.Forms.ListView();
            this.SheetName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Records = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.btnImportFromExcelToDatabase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuccessmessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDownload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImportFromExcelToDatabase
            // 
            this.btnImportFromExcelToDatabase.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportFromExcelToDatabase.Location = new System.Drawing.Point(18, 24);
            this.btnImportFromExcelToDatabase.Name = "btnImportFromExcelToDatabase";
            this.btnImportFromExcelToDatabase.Size = new System.Drawing.Size(295, 55);
            this.btnImportFromExcelToDatabase.TabIndex = 0;
            this.btnImportFromExcelToDatabase.Text = "Import From Excel To Database";
            this.btnImportFromExcelToDatabase.Click += new System.EventHandler(this.btnImportFromExcelToDatabase_Click);
            // 
            // lblSuccessmessage
            // 
            this.lblSuccessmessage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuccessmessage.Location = new System.Drawing.Point(325, 51);
            this.lblSuccessmessage.Name = "lblSuccessmessage";
            this.lblSuccessmessage.Size = new System.Drawing.Size(12, 21);
            this.lblSuccessmessage.TabIndex = 1;
            this.lblSuccessmessage.Text = "*";
            // 
            // btnDownload
            // 
            this.btnDownload.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownload.Location = new System.Drawing.Point(20, 26);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(296, 55);
            this.btnDownload.TabIndex = 2;
            this.btnDownload.Text = "Download File From FBR Website";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // prgbdownload
            // 
            this.prgbdownload.Location = new System.Drawing.Point(335, 52);
            this.prgbdownload.Name = "prgbdownload";
            this.prgbdownload.Size = new System.Drawing.Size(423, 23);
            this.prgbdownload.TabIndex = 3;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(333, 26);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(17, 18);
            this.radLabel1.TabIndex = 4;
            this.radLabel1.Text = "@";
            // 
            // radLabel2
            // 
            this.radLabel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.radLabel2.Location = new System.Drawing.Point(745, 28);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(13, 18);
            this.radLabel2.TabIndex = 5;
            this.radLabel2.Text = "#";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.dgvActivityLog);
            this.radGroupBox1.Controls.Add(this.label1);
            this.radGroupBox1.Controls.Add(this.lblStatus);
            this.radGroupBox1.Controls.Add(this.btnImportFromExcelToDatabase);
            this.radGroupBox1.Controls.Add(this.lblSuccessmessage);
            this.radGroupBox1.HeaderText = "Step-2 : Import Data To Database";
            this.radGroupBox1.Location = new System.Drawing.Point(2, 117);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(763, 306);
            this.radGroupBox1.TabIndex = 6;
            this.radGroupBox1.Text = "Step-2 : Import Data To Database";
            this.radGroupBox1.Click += new System.EventHandler(this.radGroupBox1_Click);
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.btnDownload);
            this.radGroupBox2.Controls.Add(this.prgbdownload);
            this.radGroupBox2.Controls.Add(this.radLabel2);
            this.radGroupBox2.Controls.Add(this.radLabel1);
            this.radGroupBox2.HeaderText = "Step-1 : Download data from Website";
            this.radGroupBox2.Location = new System.Drawing.Point(2, 9);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(763, 102);
            this.radGroupBox2.TabIndex = 7;
            this.radGroupBox2.Text = "Step-1 : Download data from Website";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(378, 34);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(129, 16);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Data Loading Status";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(322, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Status :";
            // 
            // dgvActivityLog
            // 
            this.dgvActivityLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvActivityLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SheetName,
            this.Records});
            this.dgvActivityLog.HideSelection = false;
            this.dgvActivityLog.Location = new System.Drawing.Point(20, 85);
            this.dgvActivityLog.Name = "dgvActivityLog";
            this.dgvActivityLog.Size = new System.Drawing.Size(738, 216);
            this.dgvActivityLog.TabIndex = 7;
            this.dgvActivityLog.UseCompatibleStateImageBehavior = false;
            this.dgvActivityLog.View = System.Windows.Forms.View.Details;
            // 
            // SheetName
            // 
            this.SheetName.Text = "Sheet No";
            this.SheetName.Width = 100;
            // 
            // Records
            // 
            this.Records.Text = "Records";
            this.Records.Width = 555;
            // 
            // frmImportFBRDatafrom_ExcelToDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(777, 435);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmImportFBRDatafrom_ExcelToDatabase";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmImportFBRDatafrom_ExcelToDatabase";
            this.Load += new System.EventHandler(this.frmImportFBRDatafrom_ExcelToDatabase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnImportFromExcelToDatabase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuccessmessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDownload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnImportFromExcelToDatabase;
        private Telerik.WinControls.UI.RadLabel lblSuccessmessage;
        private Telerik.WinControls.UI.RadButton btnDownload;
        private System.Windows.Forms.ProgressBar prgbdownload;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private System.Windows.Forms.ListView dgvActivityLog;
        private System.Windows.Forms.ColumnHeader SheetName;
        private System.Windows.Forms.ColumnHeader Records;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStatus;
    }
}
