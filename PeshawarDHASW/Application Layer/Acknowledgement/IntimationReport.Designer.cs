namespace PeshawarDHASW.Application_Layer.Acknowledgement
{
    partial class IntimationReport
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
            this.ReportViewerIntimation = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportViewerIntimation
            // 
            this.ReportViewerIntimation.ActiveViewIndex = -1;
            this.ReportViewerIntimation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReportViewerIntimation.Cursor = System.Windows.Forms.Cursors.Default;
            this.ReportViewerIntimation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportViewerIntimation.Location = new System.Drawing.Point(0, 0);
            this.ReportViewerIntimation.Name = "ReportViewerIntimation";
            this.ReportViewerIntimation.Size = new System.Drawing.Size(806, 470);
            this.ReportViewerIntimation.TabIndex = 3;
            this.ReportViewerIntimation.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // IntimationReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 470);
            this.Controls.Add(this.ReportViewerIntimation);
            this.Name = "IntimationReport";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "IntimationReport";
            this.Load += new System.EventHandler(this.IntimationReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CrystalDecisions.Windows.Forms.CrystalReportViewer ReportViewerIntimation;
    }
}
