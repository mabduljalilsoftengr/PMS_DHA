namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    partial class frmNDCReport_Reprint
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
            this.btnreprintndc = new Telerik.WinControls.UI.RadButton();
            this.txtndcno = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnreprintndc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtndcno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(36, 53);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(72, 25);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "NDC No.";
            // 
            // btnreprintndc
            // 
            this.btnreprintndc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreprintndc.Location = new System.Drawing.Point(200, 108);
            this.btnreprintndc.Name = "btnreprintndc";
            this.btnreprintndc.Size = new System.Drawing.Size(110, 46);
            this.btnreprintndc.TabIndex = 1;
            this.btnreprintndc.Text = "Re-Print";
            this.btnreprintndc.Click += new System.EventHandler(this.btnreprintndc_Click);
            // 
            // txtndcno
            // 
            this.txtndcno.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtndcno.Location = new System.Drawing.Point(137, 53);
            this.txtndcno.Name = "txtndcno";
            this.txtndcno.Size = new System.Drawing.Size(253, 27);
            this.txtndcno.TabIndex = 2;
            // 
            // frmNDCReport_Reprint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 214);
            this.Controls.Add(this.txtndcno);
            this.Controls.Add(this.btnreprintndc);
            this.Controls.Add(this.radLabel1);
            this.Name = "frmNDCReport_Reprint";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmNDCReport_Reprint";
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnreprintndc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtndcno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton btnreprintndc;
        private Telerik.WinControls.UI.RadTextBox txtndcno;
    }
}
