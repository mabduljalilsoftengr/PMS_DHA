namespace PeshawarDHASW.Application_Layer.PlotsPosession
{
    partial class frrmRepot_DuesRemainingUptoPosesion
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
            this.crpvPosessionReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // crpvPosessionReport
            // 
            this.crpvPosessionReport.ActiveViewIndex = -1;
            this.crpvPosessionReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crpvPosessionReport.Cursor = System.Windows.Forms.Cursors.Default;
            this.crpvPosessionReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crpvPosessionReport.Location = new System.Drawing.Point(0, 0);
            this.crpvPosessionReport.Name = "crpvPosessionReport";
            this.crpvPosessionReport.Size = new System.Drawing.Size(1022, 753);
            this.crpvPosessionReport.TabIndex = 0;
            // 
            // frrmRepot_DuesRemainingUptoPosesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 753);
            this.Controls.Add(this.crpvPosessionReport);
            this.Name = "frrmRepot_DuesRemainingUptoPosesion";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frrmRepot_DuesRemainingUptoPosesion";
            this.Load += new System.EventHandler(this.frrmRepot_DuesRemainingUptoPosesion_Load);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crpvPosessionReport;
    }
}
