namespace PeshawarDHASW.Application_Layer.Installment.AcknowledgmentSearch.Account_Statement_Report
{
    partial class frmAccountStatementReport
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
            this.rptAccountStatement = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rptAccountStatement
            // 
            this.rptAccountStatement.ActiveViewIndex = -1;
            this.rptAccountStatement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rptAccountStatement.Cursor = System.Windows.Forms.Cursors.Default;
            this.rptAccountStatement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptAccountStatement.Location = new System.Drawing.Point(0, 0);
            this.rptAccountStatement.Name = "rptAccountStatement";
            this.rptAccountStatement.Size = new System.Drawing.Size(1077, 647);
            this.rptAccountStatement.TabIndex = 0;
            this.rptAccountStatement.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmAccountStatementReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 647);
            this.Controls.Add(this.rptAccountStatement);
            this.Name = "frmAccountStatementReport";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Statement Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAccountStatementReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CrystalDecisions.Windows.Forms.CrystalReportViewer rptAccountStatement;
    }
}
