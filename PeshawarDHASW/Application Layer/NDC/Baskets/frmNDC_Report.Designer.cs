namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    partial class frmNDC_Report
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
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.NDC_ReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.telerikMetroBlueTheme1 = new Telerik.WinControls.Themes.TelerikMetroBlueTheme();
            this.btnBack = new Telerik.WinControls.UI.RadButton();
            this.btnForward = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.lblPreparedby = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.lblReviewby = new Telerik.WinControls.UI.RadLabel();
            this.lblPreparedbyDate = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.lblReviewedbyDate = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnForward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPreparedby)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReviewby)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPreparedbyDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReviewedbyDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.NDC_ReportViewer);
            this.radGroupBox1.HeaderText = "Report Viewer";
            this.radGroupBox1.Location = new System.Drawing.Point(1, 3);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1132, 695);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Report Viewer";
            // 
            // NDC_ReportViewer
            // 
            this.NDC_ReportViewer.ActiveViewIndex = -1;
            this.NDC_ReportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NDC_ReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NDC_ReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.NDC_ReportViewer.Location = new System.Drawing.Point(2, 18);
            this.NDC_ReportViewer.Name = "NDC_ReportViewer";
            this.NDC_ReportViewer.Size = new System.Drawing.Size(1128, 675);
            this.NDC_ReportViewer.TabIndex = 0;
            this.NDC_ReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(4, 704);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(250, 29);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "<< Back to Re-Verification";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnForward
            // 
            this.btnForward.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnForward.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForward.Location = new System.Drawing.Point(263, 704);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(274, 29);
            this.btnForward.TabIndex = 2;
            this.btnForward.Text = "Forward to Signed>>";
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.radLabel1.Location = new System.Drawing.Point(581, 699);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(75, 18);
            this.radLabel1.TabIndex = 3;
            this.radLabel1.Text = "Prepared By : ";
            // 
            // lblPreparedby
            // 
            this.lblPreparedby.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblPreparedby.Location = new System.Drawing.Point(583, 717);
            this.lblPreparedby.Name = "lblPreparedby";
            this.lblPreparedby.Size = new System.Drawing.Size(13, 18);
            this.lblPreparedby.TabIndex = 4;
            this.lblPreparedby.Text = "#";
            // 
            // radLabel3
            // 
            this.radLabel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.radLabel3.Location = new System.Drawing.Point(850, 700);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(77, 18);
            this.radLabel3.TabIndex = 5;
            this.radLabel3.Text = "Reviewed By : ";
            // 
            // lblReviewby
            // 
            this.lblReviewby.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblReviewby.Location = new System.Drawing.Point(850, 719);
            this.lblReviewby.Name = "lblReviewby";
            this.lblReviewby.Size = new System.Drawing.Size(13, 18);
            this.lblReviewby.TabIndex = 4;
            this.lblReviewby.Text = "#";
            // 
            // lblPreparedbyDate
            // 
            this.lblPreparedbyDate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblPreparedbyDate.Location = new System.Drawing.Point(720, 718);
            this.lblPreparedbyDate.Name = "lblPreparedbyDate";
            this.lblPreparedbyDate.Size = new System.Drawing.Size(13, 18);
            this.lblPreparedbyDate.TabIndex = 7;
            this.lblPreparedbyDate.Text = "#";
            // 
            // radLabel4
            // 
            this.radLabel4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.radLabel4.Location = new System.Drawing.Point(718, 700);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(38, 18);
            this.radLabel4.TabIndex = 6;
            this.radLabel4.Text = "Date : ";
            // 
            // lblReviewedbyDate
            // 
            this.lblReviewedbyDate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblReviewedbyDate.Location = new System.Drawing.Point(1012, 718);
            this.lblReviewedbyDate.Name = "lblReviewedbyDate";
            this.lblReviewedbyDate.Size = new System.Drawing.Size(13, 18);
            this.lblReviewedbyDate.TabIndex = 9;
            this.lblReviewedbyDate.Text = "#";
            // 
            // radLabel5
            // 
            this.radLabel5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.radLabel5.Location = new System.Drawing.Point(1010, 700);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(38, 18);
            this.radLabel5.TabIndex = 8;
            this.radLabel5.Text = "Date : ";
            // 
            // frmNDC_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 737);
            this.Controls.Add(this.lblReviewedbyDate);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.lblPreparedbyDate);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.lblPreparedby);
            this.Controls.Add(this.lblReviewby);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.btnForward);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmNDC_Report";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmNDC_Report";
            this.ThemeName = "TelerikMetroBlue";
            this.Load += new System.EventHandler(this.frmNDC_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnForward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPreparedby)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReviewby)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPreparedbyDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReviewedbyDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer NDC_ReportViewer;
        private Telerik.WinControls.Themes.TelerikMetroBlueTheme telerikMetroBlueTheme1;
        private Telerik.WinControls.UI.RadButton btnBack;
        private Telerik.WinControls.UI.RadButton btnForward;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel lblPreparedby;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel lblReviewby;
        private Telerik.WinControls.UI.RadLabel lblPreparedbyDate;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel lblReviewedbyDate;
        private Telerik.WinControls.UI.RadLabel radLabel5;
    }
}
