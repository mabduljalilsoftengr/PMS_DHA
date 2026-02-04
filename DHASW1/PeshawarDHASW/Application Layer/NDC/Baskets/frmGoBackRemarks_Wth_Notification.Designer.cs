namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    partial class frmGoBackRemarks_Wth_Notification
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
            this.StatusText = new System.Windows.Forms.Label();
            this.TextBoxMessage = new System.Windows.Forms.TextBox();
            this.ButtonSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // StatusText
            // 
            this.StatusText.Location = new System.Drawing.Point(7, 31);
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(452, 20);
            this.StatusText.TabIndex = 26;
            this.StatusText.Text = "Status";
            this.StatusText.Visible = false;
            // 
            // TextBoxMessage
            // 
            this.TextBoxMessage.Enabled = false;
            this.TextBoxMessage.Location = new System.Drawing.Point(59, 54);
            this.TextBoxMessage.Multiline = true;
            this.TextBoxMessage.Name = "TextBoxMessage";
            this.TextBoxMessage.Size = new System.Drawing.Size(400, 215);
            this.TextBoxMessage.TabIndex = 22;
            // 
            // ButtonSend
            // 
            this.ButtonSend.Enabled = false;
            this.ButtonSend.Location = new System.Drawing.Point(465, 52);
            this.ButtonSend.Name = "ButtonSend";
            this.ButtonSend.Size = new System.Drawing.Size(75, 91);
            this.ButtonSend.TabIndex = 21;
            this.ButtonSend.Text = "Send";
            this.ButtonSend.UseVisualStyleBackColor = true;
            this.ButtonSend.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Message";
            // 
            // frmGoBackRemarks_Wth_Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 281);
            this.Controls.Add(this.StatusText);
            this.Controls.Add(this.TextBoxMessage);
            this.Controls.Add(this.ButtonSend);
            this.Controls.Add(this.label1);
            this.Name = "frmGoBackRemarks_Wth_Notification";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmGoBackRemarks_Wth_Notification";
            this.Load += new System.EventHandler(this.frmGoBackRemarks_Wth_Notification_Load);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StatusText;
        private System.Windows.Forms.TextBox TextBoxMessage;
        private System.Windows.Forms.Button ButtonSend;
        private System.Windows.Forms.Label label1;
    }
}
