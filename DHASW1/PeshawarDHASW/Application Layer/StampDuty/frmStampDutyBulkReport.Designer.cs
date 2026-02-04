namespace PeshawarDHASW.Application_Layer.StampDuty
{
    partial class frmStampDutyBulkReport
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
            this.crvStampDuty = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // crvStampDuty
            // 
            this.crvStampDuty.ActiveViewIndex = -1;
            this.crvStampDuty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvStampDuty.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvStampDuty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvStampDuty.Location = new System.Drawing.Point(2, 18);
            this.crvStampDuty.Name = "crvStampDuty";
            this.crvStampDuty.Size = new System.Drawing.Size(1191, 664);
            this.crvStampDuty.TabIndex = 0;
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.crvStampDuty);
            this.radGroupBox1.HeaderText = "Report";
            this.radGroupBox1.Location = new System.Drawing.Point(4, 2);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1195, 684);
            this.radGroupBox1.TabIndex = 1;
            this.radGroupBox1.Text = "Report";
            // 
            // frmStampDutyBulkReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 687);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmStampDutyBulkReport";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmStampDutyBulkReport";
            this.Load += new System.EventHandler(this.frmStampDutyBulkReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvStampDuty;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    }
}
