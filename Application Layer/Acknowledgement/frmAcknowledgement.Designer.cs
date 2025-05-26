namespace PeshawarDHASW.Application_Layer.Acknowledgement
{
    partial class frmAcknowledgement
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
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem4 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem5 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem6 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem7 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem8 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem9 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.drpPrinted_NotPrinted = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.btnGenerate = new Telerik.WinControls.UI.RadButton();
            this.btnView = new Telerik.WinControls.UI.RadButton();
            this.drpPrintNumber = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.grdReportInfo = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpPrinted_NotPrinted)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenerate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpPrintNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdReportInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReportInfo.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.drpPrinted_NotPrinted);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.btnGenerate);
            this.radGroupBox1.Controls.Add(this.btnView);
            this.radGroupBox1.Controls.Add(this.drpPrintNumber);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.HeaderText = "Select";
            this.radGroupBox1.Location = new System.Drawing.Point(2, -2);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(938, 86);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Select";
            // 
            // drpPrinted_NotPrinted
            // 
            this.drpPrinted_NotPrinted.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radListDataItem1.Text = "--Select--";
            radListDataItem2.Text = "Not-Printed";
            radListDataItem3.Text = "Printed";
            this.drpPrinted_NotPrinted.Items.Add(radListDataItem1);
            this.drpPrinted_NotPrinted.Items.Add(radListDataItem2);
            this.drpPrinted_NotPrinted.Items.Add(radListDataItem3);
            this.drpPrinted_NotPrinted.Location = new System.Drawing.Point(153, 34);
            this.drpPrinted_NotPrinted.Name = "drpPrinted_NotPrinted";
            this.drpPrinted_NotPrinted.Size = new System.Drawing.Size(211, 27);
            this.drpPrinted_NotPrinted.TabIndex = 5;
            this.drpPrinted_NotPrinted.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.drpPrinted_NotPrinted_SelectedIndexChanged);
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(5, 36);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(153, 25);
            this.radLabel2.TabIndex = 4;
            this.radLabel2.Text = "Printed/Not-Printed";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(815, 28);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(110, 37);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Location = new System.Drawing.Point(699, 28);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(110, 37);
            this.btnView.TabIndex = 2;
            this.btnView.Text = "View";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // drpPrintNumber
            // 
            this.drpPrintNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radListDataItem4.Text = "-- Select Total Prints --";
            radListDataItem5.Text = "100";
            radListDataItem6.Text = "200";
            radListDataItem7.Text = "300";
            radListDataItem8.Text = "400";
            radListDataItem9.Text = "500";
            this.drpPrintNumber.Items.Add(radListDataItem4);
            this.drpPrintNumber.Items.Add(radListDataItem5);
            this.drpPrintNumber.Items.Add(radListDataItem6);
            this.drpPrintNumber.Items.Add(radListDataItem7);
            this.drpPrintNumber.Items.Add(radListDataItem8);
            this.drpPrintNumber.Items.Add(radListDataItem9);
            this.drpPrintNumber.Location = new System.Drawing.Point(482, 34);
            this.drpPrintNumber.Name = "drpPrintNumber";
            this.drpPrintNumber.Size = new System.Drawing.Size(211, 27);
            this.drpPrintNumber.TabIndex = 1;
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(370, 34);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(117, 25);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Select For Print";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.grdReportInfo);
            this.radGroupBox2.HeaderText = "Report Info";
            this.radGroupBox2.Location = new System.Drawing.Point(2, 86);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(938, 413);
            this.radGroupBox2.TabIndex = 1;
            this.radGroupBox2.Text = "Report Info";
            // 
            // grdReportInfo
            // 
            this.grdReportInfo.Location = new System.Drawing.Point(10, 21);
            // 
            // 
            // 
            this.grdReportInfo.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdReportInfo.Name = "grdReportInfo";
            this.grdReportInfo.Size = new System.Drawing.Size(923, 387);
            this.grdReportInfo.TabIndex = 0;
            this.grdReportInfo.Text = "radGridView1";
            // 
            // frmAcknowledgement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 508);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmAcknowledgement";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmAcknowledgement";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.frmAcknowledgement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpPrinted_NotPrinted)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenerate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpPrintNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdReportInfo.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReportInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton btnGenerate;
        private Telerik.WinControls.UI.RadButton btnView;
        private Telerik.WinControls.UI.RadDropDownList drpPrintNumber;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadGridView grdReportInfo;
        private Telerik.WinControls.UI.RadDropDownList drpPrinted_NotPrinted;
        private Telerik.WinControls.UI.RadLabel radLabel2;
    }
}
