namespace PeshawarDHASW.Application_Layer.Installment.AcknowledgmentSearch
{
    partial class AckFinReportViewer
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
            this.AcknowledgementReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnPrint = new Telerik.WinControls.UI.RadButton();
            this.btnexporttofile = new Telerik.WinControls.UI.RadButton();
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.tabMain = new Telerik.WinControls.UI.RadPageViewPage();
            this.TabSummary = new Telerik.WinControls.UI.RadPageViewPage();
            this.SummarReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnexporttofile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.TabSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // AcknowledgementReportViewer
            // 
            this.AcknowledgementReportViewer.ActiveViewIndex = -1;
            this.AcknowledgementReportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AcknowledgementReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AcknowledgementReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.AcknowledgementReportViewer.Location = new System.Drawing.Point(2, 0);
            this.AcknowledgementReportViewer.Name = "AcknowledgementReportViewer";
            this.AcknowledgementReportViewer.ShowCloseButton = false;
            this.AcknowledgementReportViewer.ShowExportButton = false;
            this.AcknowledgementReportViewer.ShowLogo = false;
            this.AcknowledgementReportViewer.ShowPrintButton = false;
            this.AcknowledgementReportViewer.ShowZoomButton = false;
            this.AcknowledgementReportViewer.Size = new System.Drawing.Size(1174, 431);
            this.AcknowledgementReportViewer.TabIndex = 0;
            this.AcknowledgementReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(456, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(117, 24);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnexporttofile
            // 
            this.btnexporttofile.Location = new System.Drawing.Point(590, 3);
            this.btnexporttofile.Name = "btnexporttofile";
            this.btnexporttofile.Size = new System.Drawing.Size(110, 24);
            this.btnexporttofile.TabIndex = 3;
            this.btnexporttofile.Text = "Export to File";
            this.btnexporttofile.Click += new System.EventHandler(this.btnexporttofile_Click);
            // 
            // radPageView1
            // 
            this.radPageView1.Controls.Add(this.tabMain);
            this.radPageView1.Controls.Add(this.TabSummary);
            this.radPageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPageView1.Location = new System.Drawing.Point(0, 0);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.tabMain;
            this.radPageView1.Size = new System.Drawing.Size(1197, 480);
            this.radPageView1.TabIndex = 4;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.btnexporttofile);
            this.tabMain.Controls.Add(this.btnPrint);
            this.tabMain.Controls.Add(this.AcknowledgementReportViewer);
            this.tabMain.ItemSize = new System.Drawing.SizeF(140F, 28F);
            this.tabMain.Location = new System.Drawing.Point(10, 37);
            this.tabMain.Name = "tabMain";
            this.tabMain.Size = new System.Drawing.Size(1176, 432);
            this.tabMain.Text = "Acknowledgment Report";
            // 
            // TabSummary
            // 
            this.TabSummary.Controls.Add(this.SummarReportViewer);
            this.TabSummary.ItemSize = new System.Drawing.SizeF(100F, 28F);
            this.TabSummary.Location = new System.Drawing.Point(10, 37);
            this.TabSummary.Name = "TabSummary";
            this.TabSummary.Size = new System.Drawing.Size(1176, 432);
            this.TabSummary.Text = "Summary Report";
            // 
            // SummarReportViewer
            // 
            this.SummarReportViewer.ActiveViewIndex = -1;
            this.SummarReportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SummarReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SummarReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.SummarReportViewer.Location = new System.Drawing.Point(0, 0);
            this.SummarReportViewer.Name = "SummarReportViewer";
            this.SummarReportViewer.ShowGroupTreeButton = false;
            this.SummarReportViewer.ShowLogo = false;
            this.SummarReportViewer.Size = new System.Drawing.Size(1176, 429);
            this.SummarReportViewer.TabIndex = 0;
            this.SummarReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // AckFinReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 480);
            this.Controls.Add(this.radPageView1);
            this.Name = "AckFinReportViewer";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Ack Report Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AckFinReportViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnexporttofile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.TabSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer AcknowledgementReportViewer;
        private Telerik.WinControls.UI.RadButton btnPrint;
        private Telerik.WinControls.UI.RadButton btnexporttofile;
        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage tabMain;
        private Telerik.WinControls.UI.RadPageViewPage TabSummary;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer SummarReportViewer;
    }
}
