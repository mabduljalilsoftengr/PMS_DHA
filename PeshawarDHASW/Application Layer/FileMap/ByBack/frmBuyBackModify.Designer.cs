namespace PeshawarDHASW.Application_Layer.FileMap.ByBack
{
    partial class frmBuyBackModify
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtchequeno = new System.Windows.Forms.TextBox();
            this.txtamount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpdtae = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.rdbpaymentdate = new Telerik.WinControls.UI.RadDateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.rdbpaymentdate)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cheque No.";
            // 
            // txtchequeno
            // 
            this.txtchequeno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtchequeno.Location = new System.Drawing.Point(112, 24);
            this.txtchequeno.Name = "txtchequeno";
            this.txtchequeno.Size = new System.Drawing.Size(207, 22);
            this.txtchequeno.TabIndex = 1;
            // 
            // txtamount
            // 
            this.txtamount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtamount.Location = new System.Drawing.Point(112, 52);
            this.txtamount.Name = "txtamount";
            this.txtamount.Size = new System.Drawing.Size(207, 22);
            this.txtamount.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(53, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Amount";
            // 
            // btnUpdtae
            // 
            this.btnUpdtae.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdtae.Location = new System.Drawing.Point(112, 119);
            this.btnUpdtae.Name = "btnUpdtae";
            this.btnUpdtae.Size = new System.Drawing.Size(207, 28);
            this.btnUpdtae.TabIndex = 4;
            this.btnUpdtae.Text = "Save Changes";
            this.btnUpdtae.UseVisualStyleBackColor = true;
            this.btnUpdtae.Click += new System.EventHandler(this.btnUpdtae_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Payment Date";
            // 
            // rdbpaymentdate
            // 
            this.rdbpaymentdate.CustomFormat = "dd/MM/yyyy";
            this.rdbpaymentdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.rdbpaymentdate.Location = new System.Drawing.Point(114, 83);
            this.rdbpaymentdate.Name = "rdbpaymentdate";
            this.rdbpaymentdate.Size = new System.Drawing.Size(205, 20);
            this.rdbpaymentdate.TabIndex = 6;
            this.rdbpaymentdate.TabStop = false;
            this.rdbpaymentdate.Value = new System.DateTime(((long)(0)));
            // 
            // frmBuyBackModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 163);
            this.Controls.Add(this.rdbpaymentdate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnUpdtae);
            this.Controls.Add(this.txtamount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtchequeno);
            this.Controls.Add(this.label1);
            this.Name = "frmBuyBackModify";
            this.Text = "Finance Cheque Detail Modification (frmBuyBackModify)";
            ((System.ComponentModel.ISupportInitialize)(this.rdbpaymentdate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtchequeno;
        private System.Windows.Forms.TextBox txtamount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUpdtae;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadDateTimePicker rdbpaymentdate;
    }
}