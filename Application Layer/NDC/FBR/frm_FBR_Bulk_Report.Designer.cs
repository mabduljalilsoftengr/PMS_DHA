namespace PeshawarDHASW.Application_Layer.NDC.FBR
{
    partial class frm_FBR_Bulk_Report
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
            this.crvNDC = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // crvNDC
            // 
            this.crvNDC.ActiveViewIndex = -1;
            this.crvNDC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvNDC.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvNDC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvNDC.Location = new System.Drawing.Point(2, 18);
            this.crvNDC.Name = "crvNDC";
            this.crvNDC.Size = new System.Drawing.Size(1182, 665);
            this.crvNDC.TabIndex = 0;
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.crvNDC);
            this.radGroupBox1.HeaderText = "Report";
            this.radGroupBox1.Location = new System.Drawing.Point(3, -1);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1186, 685);
            this.radGroupBox1.TabIndex = 5;
            this.radGroupBox1.Text = "Report";
            // 
            // frm_FBR_Bulk_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 688);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frm_FBR_Bulk_Report";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frm_FBR_Bulk_Report";
            this.Load += new System.EventHandler(this.frm_FBR_Bulk_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvNDC;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    }
}
