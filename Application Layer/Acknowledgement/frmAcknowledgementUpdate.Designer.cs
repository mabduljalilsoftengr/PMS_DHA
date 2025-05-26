namespace PeshawarDHASW.Application_Layer.Acknowledgement
{
    partial class frmAcknowledgementUpdate
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
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.AckStatus = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txtAmountinWords = new Telerik.WinControls.UI.RadTextBox();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnViewStatement = new Telerik.WinControls.UI.RadButton();
            this.DpInstallmentList = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.btnGenerateAck = new Telerik.WinControls.UI.RadButton();
            this.txtNote = new Telerik.WinControls.UI.RadTextBox();
            this.txtRemark = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.lblAmount = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.lblDDno = new Telerik.WinControls.UI.RadLabel();
            this.lblFileNo = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AckStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountinWords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewStatement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DpInstallmentList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenerateAck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDDno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFileNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.AckStatus);
            this.radGroupBox1.Controls.Add(this.radLabel3);
            this.radGroupBox1.Controls.Add(this.txtAmountinWords);
            this.radGroupBox1.Controls.Add(this.radGroupBox2);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.btnGenerateAck);
            this.radGroupBox1.Controls.Add(this.txtNote);
            this.radGroupBox1.Controls.Add(this.txtRemark);
            this.radGroupBox1.Controls.Add(this.radLabel8);
            this.radGroupBox1.Controls.Add(this.radLabel7);
            this.radGroupBox1.Controls.Add(this.lblAmount);
            this.radGroupBox1.Controls.Add(this.radLabel6);
            this.radGroupBox1.Controls.Add(this.lblDDno);
            this.radGroupBox1.Controls.Add(this.lblFileNo);
            this.radGroupBox1.Controls.Add(this.radLabel4);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.HeaderText = "Acknowledgement Information";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(820, 581);
            this.radGroupBox1.TabIndex = 1;
            this.radGroupBox1.Text = "Acknowledgement Information";
            // 
            // AckStatus
            // 
            this.AckStatus.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.AckStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radListDataItem1.Text = "Remaining";
            radListDataItem2.Text = "Sent";
            radListDataItem3.Text = "Cancel";
            this.AckStatus.Items.Add(radListDataItem1);
            this.AckStatus.Items.Add(radListDataItem2);
            this.AckStatus.Items.Add(radListDataItem3);
            this.AckStatus.Location = new System.Drawing.Point(235, 456);
            this.AckStatus.Name = "AckStatus";
            this.AckStatus.Size = new System.Drawing.Size(566, 27);
            this.AckStatus.TabIndex = 9;
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(28, 456);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(201, 25);
            this.radLabel3.TabIndex = 6;
            this.radLabel3.Text = "Acknowledgement Status :";
            // 
            // txtAmountinWords
            // 
            this.txtAmountinWords.AutoSize = false;
            this.txtAmountinWords.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountinWords.Location = new System.Drawing.Point(27, 137);
            this.txtAmountinWords.Multiline = true;
            this.txtAmountinWords.Name = "txtAmountinWords";
            this.txtAmountinWords.Size = new System.Drawing.Size(779, 69);
            this.txtAmountinWords.TabIndex = 8;
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.btnViewStatement);
            this.radGroupBox2.Controls.Add(this.DpInstallmentList);
            this.radGroupBox2.HeaderText = "Select Plan Upto Display That Installment Which is Cleared";
            this.radGroupBox2.Location = new System.Drawing.Point(342, 22);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(464, 88);
            this.radGroupBox2.TabIndex = 1;
            this.radGroupBox2.Text = "Select Plan Upto Display That Installment Which is Cleared";
            // 
            // btnViewStatement
            // 
            this.btnViewStatement.Location = new System.Drawing.Point(14, 56);
            this.btnViewStatement.Name = "btnViewStatement";
            this.btnViewStatement.Size = new System.Drawing.Size(445, 27);
            this.btnViewStatement.TabIndex = 1;
            this.btnViewStatement.Text = "View Account Statement";
            this.btnViewStatement.Click += new System.EventHandler(this.btnViewStatement_Click);
            // 
            // DpInstallmentList
            // 
            this.DpInstallmentList.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.DpInstallmentList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DpInstallmentList.Location = new System.Drawing.Point(14, 21);
            this.DpInstallmentList.Name = "DpInstallmentList";
            this.DpInstallmentList.Size = new System.Drawing.Size(445, 27);
            this.DpInstallmentList.TabIndex = 0;
            this.DpInstallmentList.Text = "radDropDownList1";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(24, 106);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(136, 25);
            this.radLabel2.TabIndex = 7;
            this.radLabel2.Text = "Amount in Words";
            // 
            // btnGenerateAck
            // 
            this.btnGenerateAck.Location = new System.Drawing.Point(24, 514);
            this.btnGenerateAck.Name = "btnGenerateAck";
            this.btnGenerateAck.Size = new System.Drawing.Size(782, 49);
            this.btnGenerateAck.TabIndex = 8;
            this.btnGenerateAck.Text = "Generate Acknowledgement";
            this.btnGenerateAck.Click += new System.EventHandler(this.btnGenerateAck_Click);
            // 
            // txtNote
            // 
            this.txtNote.AutoSize = false;
            this.txtNote.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.Location = new System.Drawing.Point(24, 349);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(782, 97);
            this.txtNote.TabIndex = 7;
            // 
            // txtRemark
            // 
            this.txtRemark.AutoSize = false;
            this.txtRemark.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(27, 243);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(782, 69);
            this.txtRemark.TabIndex = 6;
            // 
            // radLabel8
            // 
            this.radLabel8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel8.Location = new System.Drawing.Point(27, 318);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(52, 25);
            this.radLabel8.TabIndex = 5;
            this.radLabel8.Text = "Note :";
            // 
            // radLabel7
            // 
            this.radLabel7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel7.Location = new System.Drawing.Point(27, 212);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(71, 25);
            this.radLabel7.TabIndex = 4;
            this.radLabel7.Text = "Remark :";
            // 
            // lblAmount
            // 
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(106, 80);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(79, 25);
            this.lblAmount.TabIndex = 3;
            this.lblAmount.Text = "radLabel5";
            // 
            // radLabel6
            // 
            this.radLabel6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel6.Location = new System.Drawing.Point(24, 80);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(75, 25);
            this.radLabel6.TabIndex = 2;
            this.radLabel6.Text = "Amount :";
            // 
            // lblDDno
            // 
            this.lblDDno.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDDno.Location = new System.Drawing.Point(106, 55);
            this.lblDDno.Name = "lblDDno";
            this.lblDDno.Size = new System.Drawing.Size(79, 25);
            this.lblDDno.TabIndex = 3;
            this.lblDDno.Text = "radLabel3";
            // 
            // lblFileNo
            // 
            this.lblFileNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileNo.Location = new System.Drawing.Point(106, 29);
            this.lblFileNo.Name = "lblFileNo";
            this.lblFileNo.Size = new System.Drawing.Size(79, 25);
            this.lblFileNo.TabIndex = 1;
            this.lblFileNo.Text = "radLabel2";
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(24, 55);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(61, 25);
            this.radLabel4.TabIndex = 2;
            this.radLabel4.Text = "DDNo :";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(24, 29);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(63, 25);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "FileNo :";
            // 
            // frmAcknowledgementUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 605);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmAcknowledgementUpdate";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmAcknowledgementUpdate";
            this.Load += new System.EventHandler(this.frmAcknowledgementUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AckStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountinWords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewStatement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DpInstallmentList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenerateAck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDDno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFileNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadTextBox txtAmountinWords;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadButton btnViewStatement;
        private Telerik.WinControls.UI.RadDropDownList DpInstallmentList;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton btnGenerateAck;
        private Telerik.WinControls.UI.RadTextBox txtNote;
        private Telerik.WinControls.UI.RadTextBox txtRemark;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadLabel lblAmount;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel lblDDno;
        private Telerik.WinControls.UI.RadLabel lblFileNo;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDropDownList AckStatus;
        private Telerik.WinControls.UI.RadLabel radLabel3;
    }
}
