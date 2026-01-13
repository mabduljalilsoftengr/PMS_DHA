namespace PeshawarDHASW.Application_Layer.Installment.InstallmentSummary
{
    partial class frmInstallmentSummary
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
            Telerik.WinControls.UI.ColumnGroupsViewDefinition columnGroupsViewDefinition1 = new Telerik.WinControls.UI.ColumnGroupsViewDefinition();
            Telerik.WinControls.UI.GridViewColumnGroup gridViewColumnGroup1 = new Telerik.WinControls.UI.GridViewColumnGroup();
            Telerik.WinControls.UI.GridViewColumnGroupRow gridViewColumnGroupRow1 = new Telerik.WinControls.UI.GridViewColumnGroupRow();
            Telerik.WinControls.UI.GridViewColumnGroup gridViewColumnGroup2 = new Telerik.WinControls.UI.GridViewColumnGroup();
            Telerik.WinControls.UI.GridViewColumnGroupRow gridViewColumnGroupRow2 = new Telerik.WinControls.UI.GridViewColumnGroupRow();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.grdInstallmentTemplate = new Telerik.WinControls.UI.RadGridView();
            this.drpInstallmentTemplate = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.btnexcelexport = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInstallmentTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInstallmentTemplate.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInstallmentTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnexcelexport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.btnexcelexport);
            this.radGroupBox1.Controls.Add(this.grdInstallmentTemplate);
            this.radGroupBox1.Controls.Add(this.drpInstallmentTemplate);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.HeaderText = "Installment Summary";
            this.radGroupBox1.Location = new System.Drawing.Point(5, 1);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(866, 564);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Installment Summary";
            // 
            // grdInstallmentTemplate
            // 
            this.grdInstallmentTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdInstallmentTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grdInstallmentTemplate.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdInstallmentTemplate.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.grdInstallmentTemplate.ForeColor = System.Drawing.Color.Black;
            this.grdInstallmentTemplate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdInstallmentTemplate.Location = new System.Drawing.Point(7, 72);
            // 
            // 
            // 
            this.grdInstallmentTemplate.MasterTemplate.AllowAddNewRow = false;
            this.grdInstallmentTemplate.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "PlanID";
            gridViewTextBoxColumn1.HeaderText = "Plan ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "PlanID";
            gridViewTextBoxColumn1.Width = 10;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "Descp";
            gridViewTextBoxColumn2.HeaderText = "Account Head";
            gridViewTextBoxColumn2.Name = "Descp";
            gridViewTextBoxColumn2.Width = 127;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "Received";
            gridViewTextBoxColumn3.HeaderText = "Received";
            gridViewTextBoxColumn3.Name = "Received";
            gridViewTextBoxColumn3.Width = 70;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "Remaing";
            gridViewTextBoxColumn4.HeaderText = "Remaing";
            gridViewTextBoxColumn4.Name = "Remaing";
            gridViewTextBoxColumn4.Width = 77;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "Receipt";
            gridViewTextBoxColumn5.HeaderText = "Receipt";
            gridViewTextBoxColumn5.Name = "Receipt";
            gridViewTextBoxColumn5.Width = 85;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "AmountFile";
            gridViewTextBoxColumn6.HeaderText = "Amount/File";
            gridViewTextBoxColumn6.Name = "AmountFile";
            gridViewTextBoxColumn6.Width = 203;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "ActualReceived";
            gridViewTextBoxColumn7.HeaderText = "Actual Received";
            gridViewTextBoxColumn7.Name = "ActualReceived";
            gridViewTextBoxColumn7.Width = 137;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "Receivable";
            gridViewTextBoxColumn8.HeaderText = "Receivable";
            gridViewTextBoxColumn8.Name = "Receivable";
            gridViewTextBoxColumn8.Width = 127;
            this.grdInstallmentTemplate.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8});
            this.grdInstallmentTemplate.MasterTemplate.ShowGroupedColumns = true;
            gridViewColumnGroup1.Name = "InstallmentFiles";
            gridViewColumnGroupRow1.ColumnNames.Add("PlanID");
            gridViewColumnGroupRow1.ColumnNames.Add("Descp");
            gridViewColumnGroupRow1.ColumnNames.Add("Received");
            gridViewColumnGroupRow1.ColumnNames.Add("Remaing");
            gridViewColumnGroupRow1.ColumnNames.Add("Receipt");
            gridViewColumnGroup1.Rows.Add(gridViewColumnGroupRow1);
            gridViewColumnGroup1.Text = "Installment Files";
            gridViewColumnGroup2.Name = "AmountReceive";
            gridViewColumnGroupRow2.ColumnNames.Add("AmountFile");
            gridViewColumnGroupRow2.ColumnNames.Add("ActualReceived");
            gridViewColumnGroupRow2.ColumnNames.Add("Receivable");
            gridViewColumnGroup2.Rows.Add(gridViewColumnGroupRow2);
            gridViewColumnGroup2.Text = "Amount";
            columnGroupsViewDefinition1.ColumnGroups.Add(gridViewColumnGroup1);
            columnGroupsViewDefinition1.ColumnGroups.Add(gridViewColumnGroup2);
            this.grdInstallmentTemplate.MasterTemplate.ViewDefinition = columnGroupsViewDefinition1;
            this.grdInstallmentTemplate.Name = "grdInstallmentTemplate";
            this.grdInstallmentTemplate.ReadOnly = true;
            this.grdInstallmentTemplate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grdInstallmentTemplate.Size = new System.Drawing.Size(852, 484);
            this.grdInstallmentTemplate.TabIndex = 2;
            this.grdInstallmentTemplate.Text = "radGridView1";
            // 
            // drpInstallmentTemplate
            // 
            this.drpInstallmentTemplate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drpInstallmentTemplate.Location = new System.Drawing.Point(187, 30);
            this.drpInstallmentTemplate.Name = "drpInstallmentTemplate";
            this.drpInstallmentTemplate.Size = new System.Drawing.Size(580, 27);
            this.drpInstallmentTemplate.TabIndex = 1;
            this.drpInstallmentTemplate.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.drpInstallmentTemplate_SelectedIndexChanged);
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(7, 32);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(160, 25);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Installment Template";
            // 
            // btnexcelexport
            // 
            this.btnexcelexport.Location = new System.Drawing.Point(774, 32);
            this.btnexcelexport.Name = "btnexcelexport";
            this.btnexcelexport.Size = new System.Drawing.Size(85, 24);
            this.btnexcelexport.TabIndex = 3;
            this.btnexcelexport.Text = "Export to Excel";
            this.btnexcelexport.Click += new System.EventHandler(this.btnexcelexport_Click);
            // 
            // frmInstallmentSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 566);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmInstallmentSummary";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Template wise Installment Summary";
            this.Load += new System.EventHandler(this.frmInstallmentSummary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInstallmentTemplate.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInstallmentTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInstallmentTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnexcelexport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView grdInstallmentTemplate;
        private Telerik.WinControls.UI.RadDropDownList drpInstallmentTemplate;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton btnexcelexport;
    }
}
