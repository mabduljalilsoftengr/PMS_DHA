namespace PeshawarDHASW.Application_Layer.Launching
{
    partial class FinBankReceiveInfoUploading_OnlineFeeVerification
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox5 = new Telerik.WinControls.UI.RadGroupBox();
            this.ntbOnlinePaymentReconsilation = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtBankTransactionID = new Telerik.WinControls.UI.RadTextBox();
            this.grdtransactionID = new Telerik.WinControls.UI.RadGridView();
            this.btnverify = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox5)).BeginInit();
            this.radGroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ntbOnlinePaymentReconsilation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankTransactionID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdtransactionID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdtransactionID.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnverify)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox5
            // 
            this.radGroupBox5.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox5.Controls.Add(this.ntbOnlinePaymentReconsilation);
            this.radGroupBox5.Controls.Add(this.radLabel1);
            this.radGroupBox5.Controls.Add(this.txtBankTransactionID);
            this.radGroupBox5.Controls.Add(this.grdtransactionID);
            this.radGroupBox5.Controls.Add(this.btnverify);
            this.radGroupBox5.HeaderText = "Online Payment";
            this.radGroupBox5.Location = new System.Drawing.Point(3, 1);
            this.radGroupBox5.Name = "radGroupBox5";
            this.radGroupBox5.Size = new System.Drawing.Size(1136, 733);
            this.radGroupBox5.TabIndex = 6;
            this.radGroupBox5.Text = "Online Payment";
            // 
            // ntbOnlinePaymentReconsilation
            // 
            this.ntbOnlinePaymentReconsilation.Location = new System.Drawing.Point(899, 19);
            this.ntbOnlinePaymentReconsilation.Name = "ntbOnlinePaymentReconsilation";
            this.ntbOnlinePaymentReconsilation.Size = new System.Drawing.Size(227, 24);
            this.ntbOnlinePaymentReconsilation.TabIndex = 11;
            this.ntbOnlinePaymentReconsilation.Text = "Online Payments Reconsilation";
            this.ntbOnlinePaymentReconsilation.Click += new System.EventHandler(this.ntbOnlinePaymentReconsilation_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(10, 22);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(124, 21);
            this.radLabel1.TabIndex = 10;
            this.radLabel1.Text = "Bank Transaction ID";
            // 
            // txtBankTransactionID
            // 
            this.txtBankTransactionID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBankTransactionID.Location = new System.Drawing.Point(143, 22);
            this.txtBankTransactionID.Name = "txtBankTransactionID";
            this.txtBankTransactionID.Size = new System.Drawing.Size(169, 23);
            this.txtBankTransactionID.TabIndex = 9;
            // 
            // grdtransactionID
            // 
            this.grdtransactionID.EnableKeyMap = true;
            this.grdtransactionID.Location = new System.Drawing.Point(8, 53);
            // 
            // 
            // 
            this.grdtransactionID.MasterTemplate.AllowSearchRow = true;
            this.grdtransactionID.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "ReciveBankChallan_ID";
            gridViewTextBoxColumn1.HeaderText = "ReciveBankChallan_ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "ReciveBankChallan_ID";
            gridViewTextBoxColumn2.FieldName = "Bank_Transaction_ID";
            gridViewTextBoxColumn2.HeaderText = "Trx ID";
            gridViewTextBoxColumn2.Name = "Bank_Transaction_ID";
            gridViewTextBoxColumn2.Width = 176;
            gridViewTextBoxColumn3.FieldName = "ChallanNo";
            gridViewTextBoxColumn3.HeaderText = "ChallanNo";
            gridViewTextBoxColumn3.Name = "ChallanNo";
            gridViewTextBoxColumn3.Width = 153;
            gridViewTextBoxColumn4.FieldName = "CNIC";
            gridViewTextBoxColumn4.HeaderText = "CNIC";
            gridViewTextBoxColumn4.Name = "CNIC";
            gridViewTextBoxColumn4.Width = 176;
            gridViewTextBoxColumn5.FieldName = "BankName";
            gridViewTextBoxColumn5.HeaderText = "Bank";
            gridViewTextBoxColumn5.Name = "BankName";
            gridViewTextBoxColumn5.Width = 176;
            gridViewTextBoxColumn6.FieldName = "FileNo";
            gridViewTextBoxColumn6.HeaderText = "File No";
            gridViewTextBoxColumn6.Name = "FileNo";
            gridViewTextBoxColumn6.Width = 132;
            gridViewTextBoxColumn7.FieldName = "Status";
            gridViewTextBoxColumn7.HeaderText = "Status";
            gridViewTextBoxColumn7.Name = "Status";
            gridViewTextBoxColumn7.Width = 176;
            gridViewCommandColumn1.DefaultText = "Verify";
            gridViewCommandColumn1.FieldName = "Verify";
            gridViewCommandColumn1.HeaderText = "Verify";
            gridViewCommandColumn1.Name = "Verify";
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 114;
            this.grdtransactionID.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewCommandColumn1});
            this.grdtransactionID.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdtransactionID.Name = "grdtransactionID";
            this.grdtransactionID.Size = new System.Drawing.Size(1118, 671);
            this.grdtransactionID.TabIndex = 8;
            this.grdtransactionID.Text = "radGridView1";
            this.grdtransactionID.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdtransactionID_CellClick);
            // 
            // btnverify
            // 
            this.btnverify.Location = new System.Drawing.Point(321, 23);
            this.btnverify.Name = "btnverify";
            this.btnverify.Size = new System.Drawing.Size(132, 24);
            this.btnverify.TabIndex = 6;
            this.btnverify.Text = "Load data";
            this.btnverify.Click += new System.EventHandler(this.btnverify_Click);
            // 
            // FinBankReceiveInfoUploading_OnlineFeeVerification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 737);
            this.Controls.Add(this.radGroupBox5);
            this.Name = "FinBankReceiveInfoUploading_OnlineFeeVerification";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "FinBankReceiveInfoUploading_OnlineFeeVerification";
            this.Load += new System.EventHandler(this.FinBankReceiveInfoUploading_OnlineFeeVerification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox5)).EndInit();
            this.radGroupBox5.ResumeLayout(false);
            this.radGroupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ntbOnlinePaymentReconsilation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankTransactionID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdtransactionID.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdtransactionID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnverify)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox5;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtBankTransactionID;
        private Telerik.WinControls.UI.RadGridView grdtransactionID;
        private Telerik.WinControls.UI.RadButton btnverify;
        private Telerik.WinControls.UI.RadButton ntbOnlinePaymentReconsilation;
    }
}
