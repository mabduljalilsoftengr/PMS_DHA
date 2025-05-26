namespace PeshawarDHASW.Application_Layer.StampDuty
{
    partial class frmStampDuty_Report_Viewer
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
            this.rpt_stamp_duty = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnPrint = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rpt_stamp_duty
            // 
            this.rpt_stamp_duty.ActiveViewIndex = -1;
            this.rpt_stamp_duty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rpt_stamp_duty.Cursor = System.Windows.Forms.Cursors.Default;
            this.rpt_stamp_duty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpt_stamp_duty.Location = new System.Drawing.Point(0, 0);
            this.rpt_stamp_duty.Name = "rpt_stamp_duty";
            this.rpt_stamp_duty.ShowLogo = false;
            this.rpt_stamp_duty.ShowPrintButton = false;
            this.rpt_stamp_duty.Size = new System.Drawing.Size(1169, 829);
            this.rpt_stamp_duty.TabIndex = 0;
            this.rpt_stamp_duty.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(1004, 0);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(165, 30);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmStampDuty_Report_Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 829);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.rpt_stamp_duty);
            this.Name = "frmStampDuty_Report_Viewer";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmStampDuty_Report_Viewer";
            this.Load += new System.EventHandler(this.frmStampDuty_Report_Viewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer rpt_stamp_duty;
        private Telerik.WinControls.UI.RadButton btnPrint;
    }
}
