namespace PeshawarDHASW.Application_Layer.Installment.Reminder
{
    partial class frmReportViewer
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
            this.crpReminderDuesSurcharge = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // crpReminderDuesSurcharge
            // 
            this.crpReminderDuesSurcharge.ActiveViewIndex = -1;
            this.crpReminderDuesSurcharge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crpReminderDuesSurcharge.Cursor = System.Windows.Forms.Cursors.Default;
            this.crpReminderDuesSurcharge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crpReminderDuesSurcharge.Location = new System.Drawing.Point(0, 0);
            this.crpReminderDuesSurcharge.Name = "crpReminderDuesSurcharge";
            this.crpReminderDuesSurcharge.Size = new System.Drawing.Size(1037, 798);
            this.crpReminderDuesSurcharge.TabIndex = 0;
            // 
            // frmReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 798);
            this.Controls.Add(this.crpReminderDuesSurcharge);
            this.Name = "frmReportViewer";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmReportViewer";
            this.Load += new System.EventHandler(this.frmReportViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crpReminderDuesSurcharge;
    }
}
