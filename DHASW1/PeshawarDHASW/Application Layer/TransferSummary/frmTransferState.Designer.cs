namespace PeshawarDHASW.Application_Layer.TransferSummary
{
    partial class frmTransferState
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.DGVFileState = new Telerik.WinControls.UI.RadGridView();
            this.btnExporttoExcel = new Telerik.WinControls.UI.RadButton();
            this.btnPrint = new Telerik.WinControls.UI.RadButton();
            this.btnRefresh = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVFileState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVFileState.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExporttoExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.DGVFileState);
            this.radGroupBox1.HeaderText = "File State";
            this.radGroupBox1.Location = new System.Drawing.Point(3, 30);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1003, 450);
            this.radGroupBox1.TabIndex = 1;
            this.radGroupBox1.Text = "File State";
            // 
            // DGVFileState
            // 
            this.DGVFileState.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVFileState.Location = new System.Drawing.Point(6, 21);
            // 
            // 
            // 
            this.DGVFileState.MasterTemplate.AllowAddNewRow = false;
            this.DGVFileState.MasterTemplate.AllowColumnReorder = false;
            this.DGVFileState.MasterTemplate.AllowSearchRow = true;
            this.DGVFileState.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "ID";
            gridViewTextBoxColumn1.HeaderText = "S No.";
            gridViewTextBoxColumn1.Name = "ID";
            gridViewTextBoxColumn1.Width = 72;
            gridViewTextBoxColumn2.FieldName = "FileType";
            gridViewTextBoxColumn2.HeaderText = "File Type";
            gridViewTextBoxColumn2.Name = "FileType";
            gridViewTextBoxColumn2.Width = 161;
            gridViewTextBoxColumn3.FieldName = "BusinessCategory";
            gridViewTextBoxColumn3.HeaderText = "Business Type";
            gridViewTextBoxColumn3.Name = "BusinessCategory";
            gridViewTextBoxColumn3.Width = 161;
            gridViewTextBoxColumn4.FieldName = "CompleteFile";
            gridViewTextBoxColumn4.HeaderText = "Complete File Information";
            gridViewTextBoxColumn4.Name = "CompleteFile";
            gridViewTextBoxColumn4.Width = 196;
            gridViewTextBoxColumn5.FieldName = "NotEntered";
            gridViewTextBoxColumn5.HeaderText = "Not Entered";
            gridViewTextBoxColumn5.Name = "NotEntered";
            gridViewTextBoxColumn5.Width = 186;
            gridViewTextBoxColumn6.FieldName = "NotBinded";
            gridViewTextBoxColumn6.HeaderText = "Not Binded";
            gridViewTextBoxColumn6.Name = "NotBinded";
            gridViewTextBoxColumn6.Width = 200;
            this.DGVFileState.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.DGVFileState.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.DGVFileState.Name = "DGVFileState";
            this.DGVFileState.ReadOnly = true;
            this.DGVFileState.ShowGroupPanel = false;
            this.DGVFileState.Size = new System.Drawing.Size(992, 424);
            this.DGVFileState.TabIndex = 0;
            this.DGVFileState.Text = "radGridView1";
            // 
            // btnExporttoExcel
            // 
            this.btnExporttoExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExporttoExcel.Location = new System.Drawing.Point(848, 489);
            this.btnExporttoExcel.Name = "btnExporttoExcel";
            this.btnExporttoExcel.Size = new System.Drawing.Size(158, 24);
            this.btnExporttoExcel.TabIndex = 1;
            this.btnExporttoExcel.Text = "Export to Excel";
            this.btnExporttoExcel.Click += new System.EventHandler(this.btnExporttoExcel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(677, 489);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(165, 24);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(839, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(165, 31);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmTransferState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 513);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnExporttoExcel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmTransferState";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmTransferState";
            this.Load += new System.EventHandler(this.frmTransferState_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVFileState.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVFileState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExporttoExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView DGVFileState;
        private Telerik.WinControls.UI.RadButton btnPrint;
        private Telerik.WinControls.UI.RadButton btnExporttoExcel;
        private Telerik.WinControls.UI.RadButton btnRefresh;
    }
}
