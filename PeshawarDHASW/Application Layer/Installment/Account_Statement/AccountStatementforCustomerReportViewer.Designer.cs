namespace PeshawarDHASW.Application_Layer.Installment.Account_Statement
{
    partial class AccountStatementforCustomerReportViewer
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
            this.ReportViewer_AC = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportViewer_AC
            // 
            this.ReportViewer_AC.ActiveViewIndex = -1;
            this.ReportViewer_AC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReportViewer_AC.Cursor = System.Windows.Forms.Cursors.Default;
            this.ReportViewer_AC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportViewer_AC.Location = new System.Drawing.Point(0, 0);
            this.ReportViewer_AC.Name = "ReportViewer_AC";
            this.ReportViewer_AC.Size = new System.Drawing.Size(987, 518);
            this.ReportViewer_AC.TabIndex = 0;
            this.ReportViewer_AC.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // AccountStatementforCustomerReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 518);
            this.Controls.Add(this.ReportViewer_AC);
            this.Name = "AccountStatementforCustomerReportViewer";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AccountStatementforCustomerReportViewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AccountStatementforCustomerReportViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer ReportViewer_AC;
    }
}
