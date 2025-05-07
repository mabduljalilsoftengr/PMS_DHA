namespace PeshawarDHASW.Application_Layer.Acknowledgement
{
    partial class frm_BulkPrinterofAcknowledgement
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.DGV_Acknowledgement = new Telerik.WinControls.UI.RadGridView();
            this.btnLoadData = new Telerik.WinControls.UI.RadButton();
            this.btnReadyforPrint = new Telerik.WinControls.UI.RadButton();
            this.DataLoadingofAcknowledgement = new System.ComponentModel.BackgroundWorker();
            this.dpRecordSize = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.btnLoadAcknowledgementData = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.dtSummaryDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dtSummaryDateTo = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.btnAckCount = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Acknowledgement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Acknowledgement.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoadData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReadyforPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpRecordSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoadAcknowledgementData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSummaryDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSummaryDateTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAckCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox2.Controls.Add(this.DGV_Acknowledgement);
            this.radGroupBox2.HeaderText = "Acknowledgement Generated Information";
            this.radGroupBox2.Location = new System.Drawing.Point(3, 81);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(1146, 445);
            this.radGroupBox2.TabIndex = 3;
            this.radGroupBox2.Text = "Acknowledgement Generated Information";
            // 
            // DGV_Acknowledgement
            // 
            this.DGV_Acknowledgement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_Acknowledgement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.DGV_Acknowledgement.Cursor = System.Windows.Forms.Cursors.Default;
            this.DGV_Acknowledgement.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.DGV_Acknowledgement.ForeColor = System.Drawing.Color.Black;
            this.DGV_Acknowledgement.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DGV_Acknowledgement.Location = new System.Drawing.Point(5, 21);
            // 
            // 
            // 
            this.DGV_Acknowledgement.MasterTemplate.AllowAddNewRow = false;
            this.DGV_Acknowledgement.MasterTemplate.AllowColumnReorder = false;
            this.DGV_Acknowledgement.MasterTemplate.AllowSearchRow = true;
            this.DGV_Acknowledgement.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "FinAckID";
            gridViewTextBoxColumn1.HeaderText = "FinAckID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "FinAckID";
            gridViewTextBoxColumn1.Width = 10;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "FileMapKey";
            gridViewTextBoxColumn2.HeaderText = "FileMapKey";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "FileMapKey";
            gridViewTextBoxColumn2.Width = 10;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "FileNo";
            gridViewTextBoxColumn3.HeaderText = "FileNo";
            gridViewTextBoxColumn3.Name = "FileNo";
            gridViewTextBoxColumn3.Width = 97;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "PlotNo";
            gridViewTextBoxColumn4.HeaderText = "Plot No";
            gridViewTextBoxColumn4.Name = "PlotNo";
            gridViewTextBoxColumn4.Width = 103;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "Plan_ID";
            gridViewTextBoxColumn5.HeaderText = "Plan_ID";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "Plan_ID";
            gridViewTextBoxColumn5.Width = 10;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "Name";
            gridViewTextBoxColumn6.HeaderText = "Name";
            gridViewTextBoxColumn6.Name = "Name";
            gridViewTextBoxColumn6.Width = 91;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "Mobile";
            gridViewTextBoxColumn7.HeaderText = "Mobile";
            gridViewTextBoxColumn7.Name = "Mobile";
            gridViewTextBoxColumn7.Width = 91;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "PresentAddress";
            gridViewTextBoxColumn8.HeaderText = "PresentAddress";
            gridViewTextBoxColumn8.Multiline = true;
            gridViewTextBoxColumn8.Name = "PresentAddress";
            gridViewTextBoxColumn8.Width = 104;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "DDNo";
            gridViewTextBoxColumn9.HeaderText = "DDNo";
            gridViewTextBoxColumn9.Name = "DDNo";
            gridViewTextBoxColumn9.Width = 91;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "ReceDate";
            gridViewTextBoxColumn10.HeaderText = "Rece Date";
            gridViewTextBoxColumn10.Name = "ReceDate";
            gridViewTextBoxColumn10.Width = 91;
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.FieldName = "Amount";
            gridViewTextBoxColumn11.HeaderText = "Amount";
            gridViewTextBoxColumn11.Name = "Amount";
            gridViewTextBoxColumn11.Width = 91;
            gridViewTextBoxColumn12.EnableExpressionEditor = false;
            gridViewTextBoxColumn12.FieldName = "AmountinWord";
            gridViewTextBoxColumn12.HeaderText = "In Word";
            gridViewTextBoxColumn12.Name = "AmountinWord";
            gridViewTextBoxColumn12.Width = 91;
            gridViewTextBoxColumn13.EnableExpressionEditor = false;
            gridViewTextBoxColumn13.FieldName = "BankName";
            gridViewTextBoxColumn13.HeaderText = "Bank Name";
            gridViewTextBoxColumn13.Name = "BankName";
            gridViewTextBoxColumn13.Width = 91;
            gridViewTextBoxColumn14.EnableExpressionEditor = false;
            gridViewTextBoxColumn14.FieldName = "Branch";
            gridViewTextBoxColumn14.HeaderText = "Branch";
            gridViewTextBoxColumn14.Name = "Branch";
            gridViewTextBoxColumn14.Width = 91;
            gridViewTextBoxColumn15.EnableExpressionEditor = false;
            gridViewTextBoxColumn15.FieldName = "StatusAck";
            gridViewTextBoxColumn15.HeaderText = "Status";
            gridViewTextBoxColumn15.Name = "StatusAck";
            gridViewTextBoxColumn15.Width = 94;
            gridViewTextBoxColumn16.EnableExpressionEditor = false;
            gridViewTextBoxColumn16.FieldName = "Rece_ID";
            gridViewTextBoxColumn16.HeaderText = "Rece_ID";
            gridViewTextBoxColumn16.IsVisible = false;
            gridViewTextBoxColumn16.Name = "Rece_ID";
            gridViewTextBoxColumn16.Width = 10;
            this.DGV_Acknowledgement.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewTextBoxColumn15,
            gridViewTextBoxColumn16});
            this.DGV_Acknowledgement.MasterTemplate.EnableFiltering = true;
            this.DGV_Acknowledgement.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.DGV_Acknowledgement.Name = "DGV_Acknowledgement";
            this.DGV_Acknowledgement.ReadOnly = true;
            this.DGV_Acknowledgement.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DGV_Acknowledgement.Size = new System.Drawing.Size(1136, 419);
            this.DGV_Acknowledgement.TabIndex = 0;
            this.DGV_Acknowledgement.Text = "Load Acknowledgements";
            // 
            // btnLoadData
            // 
            this.btnLoadData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadData.Location = new System.Drawing.Point(834, 532);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(149, 29);
            this.btnLoadData.TabIndex = 4;
            this.btnLoadData.Text = "Load Data";
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // btnReadyforPrint
            // 
            this.btnReadyforPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadyforPrint.Location = new System.Drawing.Point(989, 532);
            this.btnReadyforPrint.Name = "btnReadyforPrint";
            this.btnReadyforPrint.Size = new System.Drawing.Size(160, 29);
            this.btnReadyforPrint.TabIndex = 5;
            this.btnReadyforPrint.Text = "Ready for Print";
            this.btnReadyforPrint.Click += new System.EventHandler(this.btnReadyforPrint_Click);
            // 
            // DataLoadingofAcknowledgement
            // 
            this.DataLoadingofAcknowledgement.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DataLoadingofAcknowledgement_DoWork);
            this.DataLoadingofAcknowledgement.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DataLoadingofAcknowledgement_RunWorkerCompleted);
            // 
            // dpRecordSize
            // 
            this.dpRecordSize.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.dpRecordSize.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radListDataItem1.Text = "200";
            radListDataItem2.Text = "500";
            this.dpRecordSize.Items.Add(radListDataItem1);
            this.dpRecordSize.Items.Add(radListDataItem2);
            this.dpRecordSize.Location = new System.Drawing.Point(78, 27);
            this.dpRecordSize.Name = "dpRecordSize";
            this.dpRecordSize.Size = new System.Drawing.Size(242, 23);
            this.dpRecordSize.TabIndex = 6;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(13, 29);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(59, 18);
            this.radLabel1.TabIndex = 7;
            this.radLabel1.Text = "Select -- >";
            // 
            // btnLoadAcknowledgementData
            // 
            this.btnLoadAcknowledgementData.Location = new System.Drawing.Point(344, 21);
            this.btnLoadAcknowledgementData.Name = "btnLoadAcknowledgementData";
            this.btnLoadAcknowledgementData.Size = new System.Drawing.Size(202, 40);
            this.btnLoadAcknowledgementData.TabIndex = 8;
            this.btnLoadAcknowledgementData.Text = "Load Acknowledgements";
            this.btnLoadAcknowledgementData.Click += new System.EventHandler(this.btnLoadAcknowledgementData_Click);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.btnAckCount);
            this.radGroupBox1.Controls.Add(this.radLabel3);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.dtSummaryDateTo);
            this.radGroupBox1.Controls.Add(this.radButton1);
            this.radGroupBox1.Controls.Add(this.dtSummaryDate);
            this.radGroupBox1.HeaderText = "Summary Report";
            this.radGroupBox1.Location = new System.Drawing.Point(570, 2);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(555, 80);
            this.radGroupBox1.TabIndex = 9;
            this.radGroupBox1.Text = "Summary Report";
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(228, 26);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(147, 33);
            this.radButton1.TabIndex = 1;
            this.radButton1.Text = "Print Summary Report";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // dtSummaryDate
            // 
            this.dtSummaryDate.Location = new System.Drawing.Point(61, 23);
            this.dtSummaryDate.Name = "dtSummaryDate";
            this.dtSummaryDate.Size = new System.Drawing.Size(146, 20);
            this.dtSummaryDate.TabIndex = 0;
            this.dtSummaryDate.TabStop = false;
            this.dtSummaryDate.Value = new System.DateTime(((long)(0)));
            // 
            // dtSummaryDateTo
            // 
            this.dtSummaryDateTo.Location = new System.Drawing.Point(61, 49);
            this.dtSummaryDateTo.Name = "dtSummaryDateTo";
            this.dtSummaryDateTo.Size = new System.Drawing.Size(146, 20);
            this.dtSummaryDateTo.TabIndex = 1;
            this.dtSummaryDateTo.TabStop = false;
            this.dtSummaryDateTo.Value = new System.DateTime(((long)(0)));
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(27, 50);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(19, 18);
            this.radLabel2.TabIndex = 8;
            this.radLabel2.Text = "To";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(14, 25);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(32, 18);
            this.radLabel3.TabIndex = 8;
            this.radLabel3.Text = "From";
            // 
            // btnAckCount
            // 
            this.btnAckCount.Location = new System.Drawing.Point(392, 26);
            this.btnAckCount.Name = "btnAckCount";
            this.btnAckCount.Size = new System.Drawing.Size(147, 33);
            this.btnAckCount.TabIndex = 2;
            this.btnAckCount.Text = "Acknowledgement Count";
            this.btnAckCount.Click += new System.EventHandler(this.btnAckCount_Click);
            // 
            // frm_BulkPrinterofAcknowledgement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 564);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.btnLoadAcknowledgementData);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.dpRecordSize);
            this.Controls.Add(this.btnReadyforPrint);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.radGroupBox2);
            this.Name = "frm_BulkPrinterofAcknowledgement";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frm_BulkPrinterofAcknowledgement";
            this.Load += new System.EventHandler(this.frm_BulkPrinterofAcknowledgement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Acknowledgement.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Acknowledgement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoadData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReadyforPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpRecordSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoadAcknowledgementData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSummaryDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSummaryDateTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAckCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadGridView DGV_Acknowledgement;
        private Telerik.WinControls.UI.RadButton btnLoadData;
        private Telerik.WinControls.UI.RadButton btnReadyforPrint;
        private System.ComponentModel.BackgroundWorker DataLoadingofAcknowledgement;
        private Telerik.WinControls.UI.RadDropDownList dpRecordSize;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton btnLoadAcknowledgementData;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadDateTimePicker dtSummaryDate;
        private Telerik.WinControls.UI.RadDateTimePicker dtSummaryDateTo;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton btnAckCount;
    }
}
