namespace PeshawarDHASW.Application_Layer.Membership.AddMemberships
{
    partial class frmAddNewMembership
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
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnNewMS = new Telerik.WinControls.UI.RadButton();
            this.txtNewMS = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.btnNewMS);
            this.radGroupBox1.Controls.Add(this.txtNewMS);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox1.HeaderText = "Add New Membership";
            this.radGroupBox1.Location = new System.Drawing.Point(13, 13);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(342, 202);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Add New Membership";
            // 
            // btnNewMS
            // 
            this.btnNewMS.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewMS.Location = new System.Drawing.Point(6, 87);
            this.btnNewMS.Name = "btnNewMS";
            this.btnNewMS.Size = new System.Drawing.Size(331, 35);
            this.btnNewMS.TabIndex = 2;
            this.btnNewMS.Text = "Add New";
            this.btnNewMS.Click += new System.EventHandler(this.btnNewMS_Click);
            // 
            // txtNewMS
            // 
            this.txtNewMS.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewMS.Location = new System.Drawing.Point(6, 54);
            this.txtNewMS.Name = "txtNewMS";
            this.txtNewMS.Size = new System.Drawing.Size(331, 27);
            this.txtNewMS.TabIndex = 1;
            this.txtNewMS.TextChanged += new System.EventHandler(this.txtNewMS_TextChanged);
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(6, 28);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(99, 25);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Membership";
            // 
            // frmAddNewMembership
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 227);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmAddNewMembership";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Add New Membership";
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton btnNewMS;
        private Telerik.WinControls.UI.RadTextBox txtNewMS;
        private Telerik.WinControls.UI.RadLabel radLabel1;
    }
}
