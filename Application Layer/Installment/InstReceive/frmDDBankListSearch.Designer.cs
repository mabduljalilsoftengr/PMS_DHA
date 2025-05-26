namespace PeshawarDHASW.Application_Layer.Installment.InstReceive
{
    partial class frmDDBankListSearch
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition4 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnFindDD = new Telerik.WinControls.UI.RadButton();
            this.txtDDNo = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.DGV_DDInfor = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.DGV_BankListInformation = new Telerik.WinControls.UI.RadGridView();
            this.btnBankListExporttoExcel = new Telerik.WinControls.UI.RadButton();
            this.btnDDExporttoExcel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFindDD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDDNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_DDInfor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_DDInfor.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_BankListInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_BankListInformation.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBankListExporttoExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDDExporttoExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.btnDDExporttoExcel);
            this.radGroupBox1.Controls.Add(this.btnBankListExporttoExcel);
            this.radGroupBox1.Controls.Add(this.btnFindDD);
            this.radGroupBox1.Controls.Add(this.txtDDNo);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.HeaderText = "Search Options";
            this.radGroupBox1.Location = new System.Drawing.Point(3, 4);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(935, 62);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Search Options";
            // 
            // btnFindDD
            // 
            this.btnFindDD.Location = new System.Drawing.Point(477, 22);
            this.btnFindDD.Name = "btnFindDD";
            this.btnFindDD.Size = new System.Drawing.Size(110, 24);
            this.btnFindDD.TabIndex = 2;
            this.btnFindDD.Text = "Find";
            this.btnFindDD.Click += new System.EventHandler(this.btnFindDD_Click);
            // 
            // txtDDNo
            // 
            this.txtDDNo.Location = new System.Drawing.Point(163, 22);
            this.txtDDNo.Name = "txtDDNo";
            this.txtDDNo.NullText = "Enter DD No here . . . ";
            this.txtDDNo.Size = new System.Drawing.Size(307, 20);
            this.txtDDNo.TabIndex = 1;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(21, 22);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(126, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Demand Draft / Cheque";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox2.Controls.Add(this.DGV_DDInfor);
            this.radGroupBox2.HeaderText = "Demand Draft Information";
            this.radGroupBox2.Location = new System.Drawing.Point(685, 72);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(253, 506);
            this.radGroupBox2.TabIndex = 1;
            this.radGroupBox2.Text = "Demand Draft Information";
            // 
            // DGV_DDInfor
            // 
            this.DGV_DDInfor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_DDInfor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.DGV_DDInfor.Cursor = System.Windows.Forms.Cursors.Default;
            this.DGV_DDInfor.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.DGV_DDInfor.ForeColor = System.Drawing.Color.Black;
            this.DGV_DDInfor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DGV_DDInfor.Location = new System.Drawing.Point(10, 22);
            // 
            // 
            // 
            this.DGV_DDInfor.MasterTemplate.AllowAddNewRow = false;
            this.DGV_DDInfor.MasterTemplate.EnableFiltering = true;
            this.DGV_DDInfor.MasterTemplate.ShowFilteringRow = false;
            this.DGV_DDInfor.MasterTemplate.ShowHeaderCellButtons = true;
            this.DGV_DDInfor.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.DGV_DDInfor.Name = "DGV_DDInfor";
            this.DGV_DDInfor.ReadOnly = true;
            this.DGV_DDInfor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DGV_DDInfor.ShowHeaderCellButtons = true;
            this.DGV_DDInfor.Size = new System.Drawing.Size(238, 479);
            this.DGV_DDInfor.TabIndex = 0;
            this.DGV_DDInfor.Text = "radGridView1";
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.radGroupBox3.Controls.Add(this.DGV_BankListInformation);
            this.radGroupBox3.HeaderText = "Bank List Information";
            this.radGroupBox3.Location = new System.Drawing.Point(3, 72);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Size = new System.Drawing.Size(686, 506);
            this.radGroupBox3.TabIndex = 2;
            this.radGroupBox3.Text = "Bank List Information";
            // 
            // DGV_BankListInformation
            // 
            this.DGV_BankListInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_BankListInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.DGV_BankListInformation.Cursor = System.Windows.Forms.Cursors.Default;
            this.DGV_BankListInformation.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.DGV_BankListInformation.ForeColor = System.Drawing.Color.Black;
            this.DGV_BankListInformation.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DGV_BankListInformation.Location = new System.Drawing.Point(5, 21);
            // 
            // 
            // 
            this.DGV_BankListInformation.MasterTemplate.AllowAddNewRow = false;
            this.DGV_BankListInformation.MasterTemplate.AllowSearchRow = true;
            this.DGV_BankListInformation.MasterTemplate.EnableFiltering = true;
            this.DGV_BankListInformation.MasterTemplate.ShowFilteringRow = false;
            this.DGV_BankListInformation.MasterTemplate.ShowHeaderCellButtons = true;
            this.DGV_BankListInformation.MasterTemplate.ViewDefinition = tableViewDefinition4;
            this.DGV_BankListInformation.Name = "DGV_BankListInformation";
            this.DGV_BankListInformation.ReadOnly = true;
            this.DGV_BankListInformation.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DGV_BankListInformation.ShowHeaderCellButtons = true;
            this.DGV_BankListInformation.Size = new System.Drawing.Size(676, 480);
            this.DGV_BankListInformation.TabIndex = 1;
            this.DGV_BankListInformation.Text = "radGridView2";
            // 
            // btnBankListExporttoExcel
            // 
            this.btnBankListExporttoExcel.Location = new System.Drawing.Point(593, 22);
            this.btnBankListExporttoExcel.Name = "btnBankListExporttoExcel";
            this.btnBankListExporttoExcel.Size = new System.Drawing.Size(139, 24);
            this.btnBankListExporttoExcel.TabIndex = 3;
            this.btnBankListExporttoExcel.Text = "Export Bank List to Excel";
            this.btnBankListExporttoExcel.Click += new System.EventHandler(this.btnBankListExporttoExcel_Click);
            // 
            // btnDDExporttoExcel
            // 
            this.btnDDExporttoExcel.Location = new System.Drawing.Point(738, 20);
            this.btnDDExporttoExcel.Name = "btnDDExporttoExcel";
            this.btnDDExporttoExcel.Size = new System.Drawing.Size(189, 24);
            this.btnDDExporttoExcel.TabIndex = 4;
            this.btnDDExporttoExcel.Text = "Export DD Information to Excel";
            this.btnDDExporttoExcel.Click += new System.EventHandler(this.btnDDExporttoExcel_Click);
            // 
            // frmDDBankListSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 583);
            this.Controls.Add(this.radGroupBox3);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmDDBankListSearch";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmDDBankListSearch";
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFindDD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDDNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_DDInfor.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_DDInfor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_BankListInformation.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_BankListInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBankListExporttoExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDDExporttoExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private Telerik.WinControls.UI.RadGridView DGV_DDInfor;
        private Telerik.WinControls.UI.RadGridView DGV_BankListInformation;
        private Telerik.WinControls.UI.RadButton btnFindDD;
        private Telerik.WinControls.UI.RadTextBox txtDDNo;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton btnDDExporttoExcel;
        private Telerik.WinControls.UI.RadButton btnBankListExporttoExcel;
    }
}
