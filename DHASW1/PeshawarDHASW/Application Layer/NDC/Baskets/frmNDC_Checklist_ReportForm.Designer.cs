namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    partial class frmNDC_Checklist_ReportForm
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
            this.NDCChecklistReportViwer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // NDCChecklistReportViwer
            // 
            this.NDCChecklistReportViwer.ActiveViewIndex = -1;
            this.NDCChecklistReportViwer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NDCChecklistReportViwer.Cursor = System.Windows.Forms.Cursors.Default;
            this.NDCChecklistReportViwer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NDCChecklistReportViwer.Location = new System.Drawing.Point(0, 0);
            this.NDCChecklistReportViwer.Name = "NDCChecklistReportViwer";
            this.NDCChecklistReportViwer.Size = new System.Drawing.Size(920, 721);
            this.NDCChecklistReportViwer.TabIndex = 0;
            // 
            // frmNDC_Checklist_ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 721);
            this.Controls.Add(this.NDCChecklistReportViwer);
            this.Name = "frmNDC_Checklist_ReportForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmNDC_Checklist_ReportForm";
            this.Load += new System.EventHandler(this.frmNDC_Checklist_ReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer NDCChecklistReportViwer;
    }
}
