namespace PeshawarDHASW.Application_Layer.FileBock
{
    partial class frmFileBlock
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
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFileBlock));
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.FileBlockRecord = new Telerik.WinControls.UI.RadGridView();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtFileNo = new Telerik.WinControls.UI.RadTextBox();
            this.btnFind = new Telerik.WinControls.UI.RadButton();
            this.txtPlotNo = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileBlockRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileBlockRecord.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlotNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.FileBlockRecord);
            this.radGroupBox1.HeaderText = "File Block Information";
            this.radGroupBox1.Location = new System.Drawing.Point(6, 43);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1022, 460);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "File Block Information";
            // 
            // FileBlockRecord
            // 
            this.FileBlockRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.FileBlockRecord.Cursor = System.Windows.Forms.Cursors.Default;
            this.FileBlockRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileBlockRecord.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FileBlockRecord.ForeColor = System.Drawing.Color.Black;
            this.FileBlockRecord.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.FileBlockRecord.Location = new System.Drawing.Point(2, 18);
            // 
            // 
            // 
            this.FileBlockRecord.MasterTemplate.AllowAddNewRow = false;
            this.FileBlockRecord.MasterTemplate.AllowColumnReorder = false;
            this.FileBlockRecord.MasterTemplate.AllowSearchRow = true;
            this.FileBlockRecord.MasterTemplate.AutoGenerateColumns = false;
            this.FileBlockRecord.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "SrNo";
            gridViewTextBoxColumn1.HeaderText = "S.No";
            gridViewTextBoxColumn1.Name = "SrNo";
            gridViewTextBoxColumn1.Width = 104;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "FileMapKey";
            gridViewTextBoxColumn2.HeaderText = "FileMapKey";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "FileMapKey";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 54;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "FileNo";
            gridViewTextBoxColumn3.HeaderText = "File No";
            gridViewTextBoxColumn3.Name = "FileNo";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 100;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "PlotNo";
            gridViewTextBoxColumn4.HeaderText = "Plot No";
            gridViewTextBoxColumn4.Name = "PlotNo";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 100;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "MemberName";
            gridViewTextBoxColumn5.HeaderText = "Name";
            gridViewTextBoxColumn5.Name = "MemberName";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 100;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "Father";
            gridViewTextBoxColumn6.HeaderText = "Father";
            gridViewTextBoxColumn6.Name = "Father";
            gridViewTextBoxColumn6.ReadOnly = true;
            gridViewTextBoxColumn6.Width = 100;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.FieldName = "FileLock";
            gridViewCheckBoxColumn1.HeaderText = "FileLock";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "FileLock";
            gridViewCheckBoxColumn1.ReadOnly = true;
            gridViewCheckBoxColumn1.Width = 100;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "LockDate";
            gridViewTextBoxColumn7.HeaderText = "LockDate";
            gridViewTextBoxColumn7.Name = "LockDate";
            gridViewTextBoxColumn7.ReadOnly = true;
            gridViewTextBoxColumn7.Width = 100;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "LockbyUser";
            gridViewTextBoxColumn8.HeaderText = "LockbyUser";
            gridViewTextBoxColumn8.Name = "LockbyUser";
            gridViewTextBoxColumn8.ReadOnly = true;
            gridViewTextBoxColumn8.Width = 100;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "LockRemarks";
            gridViewTextBoxColumn9.HeaderText = "LockRemarks";
            gridViewTextBoxColumn9.Name = "LockRemarks";
            gridViewTextBoxColumn9.ReadOnly = true;
            gridViewTextBoxColumn9.Width = 100;
            gridViewCommandColumn1.DefaultText = "Edit";
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.FieldName = "Edit";
            gridViewCommandColumn1.HeaderText = "Edit";
            gridViewCommandColumn1.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn1.Image")));
            gridViewCommandColumn1.Name = "Edit";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 102;
            this.FileBlockRecord.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewCommandColumn1});
            this.FileBlockRecord.MasterTemplate.EnableAlternatingRowColor = true;
            this.FileBlockRecord.MasterTemplate.EnableFiltering = true;
            this.FileBlockRecord.MasterTemplate.SearchRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.FileBlockRecord.MasterTemplate.ShowFilteringRow = false;
            this.FileBlockRecord.MasterTemplate.ShowGroupedColumns = true;
            this.FileBlockRecord.MasterTemplate.ShowHeaderCellButtons = true;
            this.FileBlockRecord.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.FileBlockRecord.Name = "FileBlockRecord";
            this.FileBlockRecord.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FileBlockRecord.ShowHeaderCellButtons = true;
            this.FileBlockRecord.Size = new System.Drawing.Size(1018, 440);
            this.FileBlockRecord.TabIndex = 0;
            this.FileBlockRecord.Text = "radGridView1";
            this.FileBlockRecord.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.FileBlockRecord_CellClick);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(12, 12);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(41, 18);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "File No";
            // 
            // txtFileNo
            // 
            this.txtFileNo.Location = new System.Drawing.Point(60, 12);
            this.txtFileNo.Name = "txtFileNo";
            this.txtFileNo.Size = new System.Drawing.Size(225, 20);
            this.txtFileNo.TabIndex = 2;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(570, 14);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(110, 24);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "Find";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtPlotNo
            // 
            this.txtPlotNo.Location = new System.Drawing.Point(339, 15);
            this.txtPlotNo.Name = "txtPlotNo";
            this.txtPlotNo.Size = new System.Drawing.Size(225, 20);
            this.txtPlotNo.TabIndex = 4;
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(291, 15);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(44, 18);
            this.radLabel2.TabIndex = 3;
            this.radLabel2.Text = "Plot No";
            // 
            // frmFileBlock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 508);
            this.Controls.Add(this.txtPlotNo);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.txtFileNo);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmFileBlock";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmFileBlock";
            this.Load += new System.EventHandler(this.frmFileBlock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FileBlockRecord.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileBlockRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlotNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView FileBlockRecord;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtFileNo;
        private Telerik.WinControls.UI.RadButton btnFind;
        private Telerik.WinControls.UI.RadTextBox txtPlotNo;
        private Telerik.WinControls.UI.RadLabel radLabel2;
    }
}
