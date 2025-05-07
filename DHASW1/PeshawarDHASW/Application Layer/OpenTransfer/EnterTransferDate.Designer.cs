namespace PeshawarDHASW.Application_Layer.OpenTransfer
{
    partial class Enter_Transfer_Date
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
            this.dtptransferdate = new System.Windows.Forms.DateTimePicker();
            this.btnsedate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Transfer Date";
            // 
            // dtptransferdate
            // 
            this.dtptransferdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtptransferdate.Location = new System.Drawing.Point(131, 49);
            this.dtptransferdate.Name = "dtptransferdate";
            this.dtptransferdate.Size = new System.Drawing.Size(203, 20);
            this.dtptransferdate.TabIndex = 1;
            // 
            // btnsedate
            // 
            this.btnsedate.Location = new System.Drawing.Point(171, 100);
            this.btnsedate.Name = "btnsedate";
            this.btnsedate.Size = new System.Drawing.Size(130, 23);
            this.btnsedate.TabIndex = 2;
            this.btnsedate.Text = "Set Date";
            this.btnsedate.UseVisualStyleBackColor = true;
            this.btnsedate.Click += new System.EventHandler(this.btnsedate_Click);
            // 
            // Enter_Transfer_Date
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 146);
            this.Controls.Add(this.btnsedate);
            this.Controls.Add(this.dtptransferdate);
            this.Controls.Add(this.label1);
            this.Name = "Enter_Transfer_Date";
            this.Text = "Enter_Transfer_Date";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtptransferdate;
        private System.Windows.Forms.Button btnsedate;
    }
}