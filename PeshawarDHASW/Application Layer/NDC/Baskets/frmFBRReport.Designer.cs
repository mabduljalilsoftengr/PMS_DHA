namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    partial class frmFBRReport
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
            this.rptViewerFBRData = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rptViewerFBRData
            // 
            this.rptViewerFBRData.ActiveViewIndex = -1;
            this.rptViewerFBRData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rptViewerFBRData.Cursor = System.Windows.Forms.Cursors.Default;
            this.rptViewerFBRData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptViewerFBRData.Location = new System.Drawing.Point(0, 0);
            this.rptViewerFBRData.Name = "rptViewerFBRData";
            this.rptViewerFBRData.Size = new System.Drawing.Size(1124, 669);
            this.rptViewerFBRData.TabIndex = 0;
            // 
            // frmFBRReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 669);
            this.Controls.Add(this.rptViewerFBRData);
            this.Name = "frmFBRReport";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmFBRReport";
            this.Load += new System.EventHandler(this.frmFBRReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer rptViewerFBRData;
    }
}
