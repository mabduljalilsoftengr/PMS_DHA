namespace PeshawarDHASW.Application_Layer.Transfer.TransferReport
{
    partial class frm_Checklist_Report_Viewer
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
            this.crvChecklist = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // crvChecklist
            // 
            this.crvChecklist.ActiveViewIndex = -1;
            this.crvChecklist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvChecklist.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvChecklist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvChecklist.Location = new System.Drawing.Point(0, 0);
            this.crvChecklist.Name = "crvChecklist";
            this.crvChecklist.Size = new System.Drawing.Size(1075, 707);
            this.crvChecklist.TabIndex = 0;
            // 
            // frm_Checklist_Report_Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 707);
            this.Controls.Add(this.crvChecklist);
            this.Name = "frm_Checklist_Report_Viewer";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frm_Checklist_Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_Checklist_Report_Viewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvChecklist;
    }
}
