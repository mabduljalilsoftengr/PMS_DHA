namespace PeshawarDHASW.Report.Simple_Layer
{
    partial class frmTransferReportImages
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
            this.crp_TFRImages = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.crp_TFRImages);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(2, -3);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1130, 669);
            this.radGroupBox1.TabIndex = 0;
            // 
            // crp_TFRImages
            // 
            this.crp_TFRImages.ActiveViewIndex = -1;
            this.crp_TFRImages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crp_TFRImages.Cursor = System.Windows.Forms.Cursors.Default;
            this.crp_TFRImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crp_TFRImages.Location = new System.Drawing.Point(2, 18);
            this.crp_TFRImages.Name = "crp_TFRImages";
            this.crp_TFRImages.Size = new System.Drawing.Size(1126, 649);
            this.crp_TFRImages.TabIndex = 0;
            this.crp_TFRImages.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmTransferReportImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 665);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmTransferReportImages";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Pctures Report";
            this.Load += new System.EventHandler(this.frmTransferReportImages_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crp_TFRImages;
    }
}
