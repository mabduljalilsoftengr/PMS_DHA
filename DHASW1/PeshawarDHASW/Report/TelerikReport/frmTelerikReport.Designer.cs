namespace PeshawarDHASW.Report.TelerikReport
{
    partial class frmTelerikReport
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
            this.btnSampleReport = new Telerik.WinControls.UI.RadButton();
            this.SampleViewer = new Telerik.ReportViewer.WinForms.ReportViewer();           
            ((System.ComponentModel.ISupportInitialize)(this.btnSampleReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSampleReport
            // 
            this.btnSampleReport.Location = new System.Drawing.Point(12, 12);
            this.btnSampleReport.Name = "btnSampleReport";
            this.btnSampleReport.Size = new System.Drawing.Size(181, 41);
            this.btnSampleReport.TabIndex = 0;
            this.btnSampleReport.Text = "Sample Report";
            this.btnSampleReport.Click += new System.EventHandler(this.btnSampleReport_Click);
            // 
            // SampleViewer
            // 
            this.SampleViewer.Location = new System.Drawing.Point(12, 60);
            this.SampleViewer.Name = "SampleViewer";
            this.SampleViewer.Size = new System.Drawing.Size(704, 394);
            this.SampleViewer.TabIndex = 1;
            // 
            // accountStatement_ds1
            
            // 
            // frmTelerikReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 466);
            this.Controls.Add(this.SampleViewer);
            this.Controls.Add(this.btnSampleReport);
            this.Name = "frmTelerikReport";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmTelerikReport";
            ((System.ComponentModel.ISupportInitialize)(this.btnSampleReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnSampleReport;
        private Telerik.ReportViewer.WinForms.ReportViewer SampleViewer;
        
    }
}
