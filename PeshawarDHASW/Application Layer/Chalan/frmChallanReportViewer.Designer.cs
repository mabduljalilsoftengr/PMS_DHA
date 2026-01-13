namespace PeshawarDHASW.Application_Layer.Chalan
{
    partial class frmChallanReportViewer
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
            this.challanViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // challanViewer
            // 
            this.challanViewer.ActiveViewIndex = -1;
            this.challanViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.challanViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.challanViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.challanViewer.Location = new System.Drawing.Point(0, 0);
            this.challanViewer.Name = "challanViewer";
            this.challanViewer.ShowLogo = false;
            this.challanViewer.Size = new System.Drawing.Size(1028, 688);
            this.challanViewer.TabIndex = 0;
            this.challanViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmChallanReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 688);
            this.Controls.Add(this.challanViewer);
            this.Name = "frmChallanReportViewer";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmChallanReportViewer";
            this.ThemeName = "TelerikMetro";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmChallanReportViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer challanViewer;
    }
}
