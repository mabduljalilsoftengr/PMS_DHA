namespace PeshawarDHASW.Application_Layer.Employee
{
    partial class frm_Employee_Report
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.emp_report_viewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1117, 683);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // emp_report_viewer
            // 
            this.emp_report_viewer.ActiveViewIndex = -1;
            this.emp_report_viewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emp_report_viewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.emp_report_viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emp_report_viewer.Location = new System.Drawing.Point(0, 0);
            this.emp_report_viewer.Name = "emp_report_viewer";
            this.emp_report_viewer.Size = new System.Drawing.Size(1117, 683);
            this.emp_report_viewer.TabIndex = 1;
            // 
            // frm_Employee_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 683);
            this.Controls.Add(this.emp_report_viewer);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "frm_Employee_Report";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frm_EmployeeReport1";
            this.Load += new System.EventHandler(this.frm_Employee_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer emp_report_viewer;
    }
}
