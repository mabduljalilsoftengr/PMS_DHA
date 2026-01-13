namespace PeshawarDHASW.Application_Layer.Membership.Modify
{
    partial class PHP
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
            this.txtfndbtn = new System.Windows.Forms.Button();
            this.txtmembershipno = new System.Windows.Forms.TextBox();
            this.lbldetail = new System.Windows.Forms.Label();
            this.btnadd = new System.Windows.Forms.Button();
            this.btnremove = new System.Windows.Forms.Button();
            this.lblrslt = new System.Windows.Forms.Label();
            this.lblstatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtfndbtn
            // 
            this.txtfndbtn.Location = new System.Drawing.Point(271, 10);
            this.txtfndbtn.Name = "txtfndbtn";
            this.txtfndbtn.Size = new System.Drawing.Size(153, 23);
            this.txtfndbtn.TabIndex = 0;
            this.txtfndbtn.Text = "Find";
            this.txtfndbtn.UseVisualStyleBackColor = true;
            this.txtfndbtn.Click += new System.EventHandler(this.txtfndbtn_Click);
            // 
            // txtmembershipno
            // 
            this.txtmembershipno.Location = new System.Drawing.Point(12, 12);
            this.txtmembershipno.Name = "txtmembershipno";
            this.txtmembershipno.Size = new System.Drawing.Size(253, 20);
            this.txtmembershipno.TabIndex = 1;
            // 
            // lbldetail
            // 
            this.lbldetail.AutoSize = true;
            this.lbldetail.Location = new System.Drawing.Point(12, 68);
            this.lbldetail.Name = "lbldetail";
            this.lbldetail.Size = new System.Drawing.Size(14, 13);
            this.lbldetail.TabIndex = 2;
            this.lbldetail.Text = "#";
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(15, 135);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(197, 23);
            this.btnadd.TabIndex = 3;
            this.btnadd.Text = "Add to PHP List";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btnremove
            // 
            this.btnremove.Location = new System.Drawing.Point(234, 135);
            this.btnremove.Name = "btnremove";
            this.btnremove.Size = new System.Drawing.Size(190, 23);
            this.btnremove.TabIndex = 4;
            this.btnremove.Text = "Remove from PHP List";
            this.btnremove.UseVisualStyleBackColor = true;
            this.btnremove.Click += new System.EventHandler(this.btnremove_Click);
            // 
            // lblrslt
            // 
            this.lblrslt.AutoSize = true;
            this.lblrslt.Location = new System.Drawing.Point(12, 217);
            this.lblrslt.Name = "lblrslt";
            this.lblrslt.Size = new System.Drawing.Size(14, 13);
            this.lblrslt.TabIndex = 5;
            this.lblrslt.Text = "#";
            // 
            // lblstatus
            // 
            this.lblstatus.AutoSize = true;
            this.lblstatus.Location = new System.Drawing.Point(271, 68);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(14, 13);
            this.lblstatus.TabIndex = 6;
            this.lblstatus.Text = "#";
            // 
            // PHP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 296);
            this.Controls.Add(this.lblstatus);
            this.Controls.Add(this.lblrslt);
            this.Controls.Add(this.btnremove);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.lbldetail);
            this.Controls.Add(this.txtmembershipno);
            this.Controls.Add(this.txtfndbtn);
            this.Name = "PHP";
            this.Text = "PHP\'s";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button txtfndbtn;
        private System.Windows.Forms.TextBox txtmembershipno;
        private System.Windows.Forms.Label lbldetail;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button btnremove;
        private System.Windows.Forms.Label lblrslt;
        private System.Windows.Forms.Label lblstatus;
    }
}