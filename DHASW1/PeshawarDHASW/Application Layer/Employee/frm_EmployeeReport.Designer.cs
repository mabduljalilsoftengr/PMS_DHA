namespace PeshawarDHASW.Application_Layer.Employee
{
    partial class frm_EmployeeBulkReport
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
            this.emp_bulk_report = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // emp_bulk_report
            // 
            this.emp_bulk_report.ActiveViewIndex = -1;
            this.emp_bulk_report.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emp_bulk_report.Cursor = System.Windows.Forms.Cursors.Default;
            this.emp_bulk_report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emp_bulk_report.Location = new System.Drawing.Point(0, 0);
            this.emp_bulk_report.Name = "emp_bulk_report";
            this.emp_bulk_report.Size = new System.Drawing.Size(1122, 724);
            this.emp_bulk_report.TabIndex = 0;
            // 
            // frm_EmployeeBulkReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 724);
            this.Controls.Add(this.emp_bulk_report);
            this.Name = "frm_EmployeeBulkReport";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frm_EmployeeBulkReport";
            this.Load += new System.EventHandler(this.frm_EmployeeBulkReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer emp_bulk_report;
    }
}
