namespace PeshawarDHASW.Application_Layer.FileMap.FileCancelationProcess
{
    partial class ChequeNoChanges
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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtBank = new Telerik.WinControls.UI.RadTextBox();
            this.txtChequeNo = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.btnSaveChanges = new Telerik.WinControls.UI.RadButton();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.lblFileCancelationID = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChequeNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveChanges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFileCancelationID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(47, 32);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(30, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Bank";
            // 
            // txtBank
            // 
            this.txtBank.Location = new System.Drawing.Point(83, 32);
            this.txtBank.Name = "txtBank";
            this.txtBank.Size = new System.Drawing.Size(203, 20);
            this.txtBank.TabIndex = 1;
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.Location = new System.Drawing.Point(83, 57);
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(203, 20);
            this.txtChequeNo.TabIndex = 3;
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(14, 57);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(63, 18);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "Cheque No";
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(83, 83);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(203, 24);
            this.btnSaveChanges.TabIndex = 4;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.ThemeName = "TelerikMetro";
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(83, 8);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(84, 18);
            this.radLabel3.TabIndex = 1;
            this.radLabel3.Text = "Transaction No:";
            // 
            // lblFileCancelationID
            // 
            this.lblFileCancelationID.Location = new System.Drawing.Point(172, 8);
            this.lblFileCancelationID.Name = "lblFileCancelationID";
            this.lblFileCancelationID.Size = new System.Drawing.Size(12, 18);
            this.lblFileCancelationID.TabIndex = 5;
            this.lblFileCancelationID.Text = "0";
            // 
            // ChequeNoChanges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 117);
            this.Controls.Add(this.lblFileCancelationID);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.txtChequeNo);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.txtBank);
            this.Controls.Add(this.radLabel1);
            this.Name = "ChequeNoChanges";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "ChequeNoChanges";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.ChequeNoChanges_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChequeNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveChanges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFileCancelationID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtBank;
        private Telerik.WinControls.UI.RadTextBox txtChequeNo;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton btnSaveChanges;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel lblFileCancelationID;
    }
}
