namespace PeshawarDHASW.Application_Layer.CRSection
{
    partial class frmLetterDataInfo
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
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.dgvDataViewLetters = new Telerik.WinControls.UI.RadGridView();
            this.btnExcelExport = new Telerik.WinControls.UI.RadButton();
            this.btnRefresh = new Telerik.WinControls.UI.RadButton();
            this.btnDateWiseSearch = new Telerik.WinControls.UI.RadButton();
            this.dtpfromdate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dtptodate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.AddNewRecord = new Telerik.WinControls.UI.RadButton();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataViewLetters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataViewLetters.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExcelExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDateWiseSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpfromdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtptodate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddNewRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.dgvDataViewLetters);
            this.radGroupBox1.HeaderText = "Letter Information";
            this.radGroupBox1.Location = new System.Drawing.Point(13, 66);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1033, 438);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Letter Information";
            // 
            // dgvDataViewLetters
            // 
            this.dgvDataViewLetters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.dgvDataViewLetters.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvDataViewLetters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDataViewLetters.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dgvDataViewLetters.ForeColor = System.Drawing.Color.Black;
            this.dgvDataViewLetters.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvDataViewLetters.Location = new System.Drawing.Point(2, 18);
            // 
            // 
            // 
            this.dgvDataViewLetters.MasterTemplate.AllowAddNewRow = false;
            this.dgvDataViewLetters.MasterTemplate.AllowSearchRow = true;
            this.dgvDataViewLetters.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "RegNo";
            gridViewTextBoxColumn1.HeaderText = "RegNo";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "RegNo";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "ToCustomer";
            gridViewTextBoxColumn2.HeaderText = "To Customer";
            gridViewTextBoxColumn2.Name = "ToCustomer";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 77;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "Subject";
            gridViewTextBoxColumn3.HeaderText = "Subject";
            gridViewTextBoxColumn3.Name = "Subject";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 77;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "Address";
            gridViewTextBoxColumn4.HeaderText = "Address";
            gridViewTextBoxColumn4.Name = "Address";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 77;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "MobileNo";
            gridViewTextBoxColumn5.HeaderText = "MobileNo";
            gridViewTextBoxColumn5.Name = "MobileNo";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 77;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "DateofDispatch";
            gridViewTextBoxColumn6.HeaderText = "Date of Dispatch";
            gridViewTextBoxColumn6.Name = "DateofDispatch";
            gridViewTextBoxColumn6.ReadOnly = true;
            gridViewTextBoxColumn6.Width = 77;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "BranchCode";
            gridViewTextBoxColumn7.HeaderText = "Branch";
            gridViewTextBoxColumn7.Name = "BranchCode";
            gridViewTextBoxColumn7.ReadOnly = true;
            gridViewTextBoxColumn7.Width = 77;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "CourierComp";
            gridViewTextBoxColumn8.HeaderText = "Courier Comp";
            gridViewTextBoxColumn8.Name = "CourierComp";
            gridViewTextBoxColumn8.ReadOnly = true;
            gridViewTextBoxColumn8.Width = 77;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "Remarks";
            gridViewTextBoxColumn9.HeaderText = "Remarks";
            gridViewTextBoxColumn9.Name = "Remarks";
            gridViewTextBoxColumn9.ReadOnly = true;
            gridViewTextBoxColumn9.Width = 77;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "LStatus";
            gridViewTextBoxColumn10.HeaderText = "Status";
            gridViewTextBoxColumn10.Name = "LStatus";
            gridViewTextBoxColumn10.ReadOnly = true;
            gridViewTextBoxColumn10.Width = 77;
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.FieldName = "LetterType";
            gridViewTextBoxColumn11.HeaderText = "Letter Type";
            gridViewTextBoxColumn11.Name = "LetterType";
            gridViewTextBoxColumn11.ReadOnly = true;
            gridViewTextBoxColumn11.Width = 77;
            gridViewTextBoxColumn12.EnableExpressionEditor = false;
            gridViewTextBoxColumn12.FieldName = "SMS_Status";
            gridViewTextBoxColumn12.HeaderText = "SMS Status";
            gridViewTextBoxColumn12.Name = "SMS_Status";
            gridViewTextBoxColumn12.ReadOnly = true;
            gridViewTextBoxColumn12.Width = 77;
            gridViewTextBoxColumn13.EnableExpressionEditor = false;
            gridViewTextBoxColumn13.FieldName = "Message";
            gridViewTextBoxColumn13.HeaderText = "Message";
            gridViewTextBoxColumn13.Name = "Message";
            gridViewTextBoxColumn13.ReadOnly = true;
            gridViewTextBoxColumn13.Width = 77;
            gridViewCommandColumn1.DefaultText = "Edit";
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.FieldName = "btnEdit";
            gridViewCommandColumn1.HeaderText = "Edit";
            gridViewCommandColumn1.Name = "btnEdit";
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 96;
            this.dgvDataViewLetters.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
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
            gridViewCommandColumn1});
            this.dgvDataViewLetters.MasterTemplate.EnableFiltering = true;
            this.dgvDataViewLetters.MasterTemplate.ShowFilteringRow = false;
            this.dgvDataViewLetters.MasterTemplate.ShowHeaderCellButtons = true;
            this.dgvDataViewLetters.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dgvDataViewLetters.Name = "dgvDataViewLetters";
            this.dgvDataViewLetters.ReadOnly = true;
            this.dgvDataViewLetters.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvDataViewLetters.ShowHeaderCellButtons = true;
            this.dgvDataViewLetters.Size = new System.Drawing.Size(1029, 418);
            this.dgvDataViewLetters.TabIndex = 0;
            this.dgvDataViewLetters.Text = "radGridView1";
            this.dgvDataViewLetters.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dgvDataViewLetters_CellClick);
            // 
            // btnExcelExport
            // 
            this.btnExcelExport.Location = new System.Drawing.Point(327, 9);
            this.btnExcelExport.Name = "btnExcelExport";
            this.btnExcelExport.Size = new System.Drawing.Size(130, 24);
            this.btnExcelExport.TabIndex = 1;
            this.btnExcelExport.Text = "Export to Excel";
            this.btnExcelExport.Click += new System.EventHandler(this.btnExcelExport_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(211, 9);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 24);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDateWiseSearch
            // 
            this.btnDateWiseSearch.Location = new System.Drawing.Point(463, 39);
            this.btnDateWiseSearch.Name = "btnDateWiseSearch";
            this.btnDateWiseSearch.Size = new System.Drawing.Size(149, 24);
            this.btnDateWiseSearch.TabIndex = 3;
            this.btnDateWiseSearch.Text = "Period Wise Search";
            this.btnDateWiseSearch.Click += new System.EventHandler(this.btnDateWiseSearch_Click);
            // 
            // dtpfromdate
            // 
            this.dtpfromdate.CustomFormat = "dd/MM/yyyy";
            this.dtpfromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfromdate.Location = new System.Drawing.Point(80, 40);
            this.dtpfromdate.Name = "dtpfromdate";
            this.dtpfromdate.ShowUpDown = true;
            this.dtpfromdate.Size = new System.Drawing.Size(156, 20);
            this.dtpfromdate.TabIndex = 4;
            this.dtpfromdate.TabStop = false;
            this.dtpfromdate.Text = "25/10/2018";
            this.dtpfromdate.Value = new System.DateTime(2018, 10, 25, 10, 34, 24, 399);
            // 
            // dtptodate
            // 
            this.dtptodate.CustomFormat = "dd/MM/yyyy";
            this.dtptodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtptodate.Location = new System.Drawing.Point(293, 42);
            this.dtptodate.Name = "dtptodate";
            this.dtptodate.Size = new System.Drawing.Size(164, 20);
            this.dtptodate.TabIndex = 5;
            this.dtptodate.TabStop = false;
            this.dtptodate.Text = "25/10/2018";
            this.dtptodate.Value = new System.DateTime(2018, 10, 25, 10, 34, 27, 96);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(15, 39);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(59, 18);
            this.radLabel1.TabIndex = 6;
            this.radLabel1.Text = "From Date";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(242, 43);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(45, 18);
            this.radLabel2.TabIndex = 7;
            this.radLabel2.Text = "To Date";
            // 
            // AddNewRecord
            // 
            this.AddNewRecord.Location = new System.Drawing.Point(15, 9);
            this.AddNewRecord.Name = "AddNewRecord";
            this.AddNewRecord.Size = new System.Drawing.Size(181, 24);
            this.AddNewRecord.TabIndex = 8;
            this.AddNewRecord.Text = "New Entry";
            this.AddNewRecord.Click += new System.EventHandler(this.AddNewRecord_Click);
            // 
            // frmLetterDataInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 516);
            this.Controls.Add(this.AddNewRecord);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.dtptodate);
            this.Controls.Add(this.dtpfromdate);
            this.Controls.Add(this.btnDateWiseSearch);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnExcelExport);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmLetterDataInfo";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmLetterDataInfo";
            this.Load += new System.EventHandler(this.frmLetterDataInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataViewLetters.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataViewLetters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExcelExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDateWiseSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpfromdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtptodate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddNewRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView dgvDataViewLetters;
        private Telerik.WinControls.UI.RadButton btnExcelExport;
        private Telerik.WinControls.UI.RadButton btnRefresh;
        private Telerik.WinControls.UI.RadButton btnDateWiseSearch;
        private Telerik.WinControls.UI.RadDateTimePicker dtpfromdate;
        private Telerik.WinControls.UI.RadDateTimePicker dtptodate;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton AddNewRecord;
        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
    }
}
