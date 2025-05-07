namespace PeshawarDHASW.Application_Layer.Installment.Reminder
{
    partial class frmReminderDuesAndSurcharge
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnReport = new Telerik.WinControls.UI.RadButton();
            this.btnShowDataInGrid = new Telerik.WinControls.UI.RadButton();
            this.dtpcurrentdate = new System.Windows.Forms.DateTimePicker();
            this.btnDataReadyForSMS = new Telerik.WinControls.UI.RadButton();
            this.grdDataReady = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowDataInGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDataReadyForSMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDataReady)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDataReady.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.btnReport);
            this.radGroupBox3.Controls.Add(this.btnShowDataInGrid);
            this.radGroupBox3.Controls.Add(this.dtpcurrentdate);
            this.radGroupBox3.Controls.Add(this.btnDataReadyForSMS);
            this.radGroupBox3.HeaderText = "Find Remaining Due + Surcharge Up to Below date and whenDue > 10000";
            this.radGroupBox3.Location = new System.Drawing.Point(5, 5);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Size = new System.Drawing.Size(409, 606);
            this.radGroupBox3.TabIndex = 7;
            this.radGroupBox3.Text = "Find Remaining Due + Surcharge Up to Below date and whenDue > 10000";
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReport.Location = new System.Drawing.Point(7, 121);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(397, 33);
            this.btnReport.TabIndex = 11;
            this.btnReport.Text = "Report";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnShowDataInGrid
            // 
            this.btnShowDataInGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowDataInGrid.Location = new System.Drawing.Point(7, 82);
            this.btnShowDataInGrid.Name = "btnShowDataInGrid";
            this.btnShowDataInGrid.Size = new System.Drawing.Size(397, 33);
            this.btnShowDataInGrid.TabIndex = 10;
            this.btnShowDataInGrid.Text = "Show Data In Grid";
            this.btnShowDataInGrid.Click += new System.EventHandler(this.btnShowDataInGrid_Click);
            // 
            // dtpcurrentdate
            // 
            this.dtpcurrentdate.CustomFormat = "dd/MM/yyyy";
            this.dtpcurrentdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpcurrentdate.Location = new System.Drawing.Point(8, 21);
            this.dtpcurrentdate.Name = "dtpcurrentdate";
            this.dtpcurrentdate.Size = new System.Drawing.Size(396, 20);
            this.dtpcurrentdate.TabIndex = 9;
            // 
            // btnDataReadyForSMS
            // 
            this.btnDataReadyForSMS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDataReadyForSMS.Location = new System.Drawing.Point(7, 45);
            this.btnDataReadyForSMS.Name = "btnDataReadyForSMS";
            this.btnDataReadyForSMS.Size = new System.Drawing.Size(397, 33);
            this.btnDataReadyForSMS.TabIndex = 8;
            this.btnDataReadyForSMS.Text = "Find Due Remaining and Surcharge";
            this.btnDataReadyForSMS.Click += new System.EventHandler(this.btnDataReadyForSMS_Click);
            // 
            // grdDataReady
            // 
            this.grdDataReady.Location = new System.Drawing.Point(7, 17);
            // 
            // 
            // 
            this.grdDataReady.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdDataReady.Name = "grdDataReady";
            this.grdDataReady.Size = new System.Drawing.Size(449, 581);
            this.grdDataReady.TabIndex = 0;
            this.grdDataReady.Text = "radGridView1";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.grdDataReady);
            this.radGroupBox1.HeaderText = "Data";
            this.radGroupBox1.Location = new System.Drawing.Point(420, 3);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(464, 606);
            this.radGroupBox1.TabIndex = 8;
            this.radGroupBox1.Text = "Data";
            // 
            // frmReminderDuesAndSurcharge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 612);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.radGroupBox3);
            this.Name = "frmReminderDuesAndSurcharge";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmReminderDuesAndSurcharge";
            this.Load += new System.EventHandler(this.frmReminderDuesAndSurcharge_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowDataInGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDataReadyForSMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDataReady.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDataReady)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private Telerik.WinControls.UI.RadButton btnShowDataInGrid;
        private System.Windows.Forms.DateTimePicker dtpcurrentdate;
        private Telerik.WinControls.UI.RadButton btnDataReadyForSMS;
        private Telerik.WinControls.UI.RadGridView grdDataReady;
        private Telerik.WinControls.UI.RadButton btnReport;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    }
}
