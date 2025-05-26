namespace PeshawarDHASW.Application_Layer.Practice
{
    partial class frmDGPaging
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
            this.btnScaanerCode = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnScaanerCode
            // 
            this.btnScaanerCode.Location = new System.Drawing.Point(12, 12);
            this.btnScaanerCode.Name = "btnScaanerCode";
            this.btnScaanerCode.Size = new System.Drawing.Size(117, 39);
            this.btnScaanerCode.TabIndex = 0;
            this.btnScaanerCode.Text = "Scanner Code";
            this.btnScaanerCode.UseVisualStyleBackColor = true;
            this.btnScaanerCode.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmDGPaging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 490);
            this.Controls.Add(this.btnScaanerCode);
            this.Name = "frmDGPaging";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmDGPaging";
            this.Load += new System.EventHandler(this.frmDGPaging_Load);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnScaanerCode;
    }
}
