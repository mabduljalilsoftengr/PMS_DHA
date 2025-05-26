namespace PeshawarDHASW.Application_Layer.Launching
{
    partial class frmApplicantForm_Report
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
            this.crptApplicantRptViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // crptApplicantRptViewer
            // 
            this.crptApplicantRptViewer.ActiveViewIndex = -1;
            this.crptApplicantRptViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crptApplicantRptViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crptApplicantRptViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crptApplicantRptViewer.Location = new System.Drawing.Point(0, 0);
            this.crptApplicantRptViewer.Name = "crptApplicantRptViewer";
            this.crptApplicantRptViewer.Size = new System.Drawing.Size(995, 833);
            this.crptApplicantRptViewer.TabIndex = 0;
            // 
            // frmApplicantForm_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 833);
            this.Controls.Add(this.crptApplicantRptViewer);
            this.Name = "frmApplicantForm_Report";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmApplicantForm_Report";
            this.Load += new System.EventHandler(this.frmApplicantForm_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crptApplicantRptViewer;
    }
}
