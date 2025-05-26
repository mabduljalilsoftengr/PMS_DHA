namespace PeshawarDHASW.Application_Layer.NDC
{
    partial class frm_SurchargInstallmentInfoDetailReport_ForNDC
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
            this.crprtv_instsurchage = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // crprtv_instsurchage
            // 
            this.crprtv_instsurchage.ActiveViewIndex = -1;
            this.crprtv_instsurchage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crprtv_instsurchage.Cursor = System.Windows.Forms.Cursors.Default;
            this.crprtv_instsurchage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crprtv_instsurchage.Location = new System.Drawing.Point(0, 0);
            this.crprtv_instsurchage.Name = "crprtv_instsurchage";
            this.crprtv_instsurchage.Size = new System.Drawing.Size(1234, 735);
            this.crprtv_instsurchage.TabIndex = 0;
            this.crprtv_instsurchage.Load += new System.EventHandler(this.crprtv_instsurchage_Load);
            // 
            // frm_SurchargInstallmentInfoDetailReport_ForNDC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 735);
            this.Controls.Add(this.crprtv_instsurchage);
            this.Name = "frm_SurchargInstallmentInfoDetailReport_ForNDC";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frm_SurchargInstallmentInfoDetailReport";
            this.Load += new System.EventHandler(this.frm_SurchargInstallmentInfoDetailReport_ForNDC_Load);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crprtv_instsurchage;
    }
}
