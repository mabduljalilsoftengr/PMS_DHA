namespace PeshawarDHASW.Application_Layer.FileMap.ByBack
{
    partial class frmByBackMainForm_FinBr
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
            this.btnBuybackUpdate = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnFileCancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuybackUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFileCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuybackUpdate
            // 
            this.btnBuybackUpdate.Location = new System.Drawing.Point(9, 21);
            this.btnBuybackUpdate.Name = "btnBuybackUpdate";
            this.btnBuybackUpdate.Size = new System.Drawing.Size(318, 49);
            this.btnBuybackUpdate.TabIndex = 7;
            this.btnBuybackUpdate.Text = "Update BuyBack Detail";
            this.btnBuybackUpdate.Click += new System.EventHandler(this.btnBuybackUpdate_Click);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.btnBuybackUpdate);
            this.radGroupBox1.HeaderText = "File Buyback Process";
            this.radGroupBox1.Location = new System.Drawing.Point(3, -2);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(340, 92);
            this.radGroupBox1.TabIndex = 8;
            this.radGroupBox1.Text = "File Buyback Process";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.btnFileCancel);
            this.radGroupBox2.HeaderText = "File Cancellation Process";
            this.radGroupBox2.Location = new System.Drawing.Point(3, 106);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(340, 95);
            this.radGroupBox2.TabIndex = 9;
            this.radGroupBox2.Text = "File Cancellation Process";
            // 
            // btnFileCancel
            // 
            this.btnFileCancel.Location = new System.Drawing.Point(11, 28);
            this.btnFileCancel.Name = "btnFileCancel";
            this.btnFileCancel.Size = new System.Drawing.Size(318, 49);
            this.btnFileCancel.TabIndex = 3;
            this.btnFileCancel.Text = "Apply For File Cancellation";
            this.btnFileCancel.Click += new System.EventHandler(this.btnFileCancel_Click);
            // 
            // frmByBackMainForm_FinBr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 215);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmByBackMainForm_FinBr";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmByBackMainForm_FinBr";
            ((System.ComponentModel.ISupportInitialize)(this.btnBuybackUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnFileCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnBuybackUpdate;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadButton btnFileCancel;
    }
}
