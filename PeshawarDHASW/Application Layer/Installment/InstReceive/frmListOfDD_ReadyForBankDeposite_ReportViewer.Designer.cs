namespace PeshawarDHASW.Application_Layer.Installment.InstReceive
{
    partial class frmListOfDD_ReadyForBankDeposite_ReportViewer
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
            this.crViewerListOfDDInBank = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // crViewerListOfDDInBank
            // 
            this.crViewerListOfDDInBank.ActiveViewIndex = -1;
            this.crViewerListOfDDInBank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crViewerListOfDDInBank.Cursor = System.Windows.Forms.Cursors.Default;
            this.crViewerListOfDDInBank.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crViewerListOfDDInBank.Location = new System.Drawing.Point(0, 0);
            this.crViewerListOfDDInBank.Name = "crViewerListOfDDInBank";
            this.crViewerListOfDDInBank.Size = new System.Drawing.Size(1257, 700);
            this.crViewerListOfDDInBank.TabIndex = 0;
            // 
            // frmListOfDD_ReadyForBankDeposite_ReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 700);
            this.Controls.Add(this.crViewerListOfDDInBank);
            this.Name = "frmListOfDD_ReadyForBankDeposite_ReportViewer";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Report for List Of Recieved DD\'s Ready For Bank ";
            this.Load += new System.EventHandler(this.frmListOfDD_ReadyForBankDeposite_ReportViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crViewerListOfDDInBank;
    }
}
