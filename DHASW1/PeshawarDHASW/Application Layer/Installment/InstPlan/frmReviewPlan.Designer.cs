namespace PeshawarDHASW.Application_Layer.Installment.InstPlan
{
    partial class frmReviewPlanAgainstFileNo
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
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewSummaryItem gridViewSummaryItem1 = new Telerik.WinControls.UI.GridViewSummaryItem();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.radgplan = new Telerik.WinControls.UI.RadGridView();
            this.radbbtnDelete = new Telerik.WinControls.UI.RadButton();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radgplan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radgplan.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radbbtnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox2.Controls.Add(this.radgplan);
            this.radGroupBox2.HeaderText = "Plan Details";
            this.radGroupBox2.Location = new System.Drawing.Point(12, 66);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(1110, 509);
            this.radGroupBox2.TabIndex = 3;
            this.radGroupBox2.Text = "Plan Details";
            this.radGroupBox2.ThemeName = "TelerikMetro";
            // 
            // radgplan
            // 
            this.radgplan.BackColor = System.Drawing.Color.White;
            this.radgplan.Cursor = System.Windows.Forms.Cursors.Default;
            this.radgplan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radgplan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.radgplan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radgplan.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radgplan.Location = new System.Drawing.Point(2, 18);
            // 
            // 
            // 
            this.radgplan.MasterTemplate.AllowAddNewRow = false;
            this.radgplan.MasterTemplate.AllowColumnReorder = false;
            this.radgplan.MasterTemplate.AutoGenerateColumns = false;
            this.radgplan.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "Descp";
            gridViewTextBoxColumn1.HeaderText = "Account Head";
            gridViewTextBoxColumn1.Name = "Descp";
            gridViewTextBoxColumn1.Width = 260;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "InstNo";
            gridViewTextBoxColumn2.HeaderText = "Installment No.";
            gridViewTextBoxColumn2.Name = "InstNo";
            gridViewTextBoxColumn2.Width = 260;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "Amount";
            gridViewTextBoxColumn3.FormatString = "{0:#,###0.00;(#,###0.00);0}";
            gridViewTextBoxColumn3.HeaderText = "Amount";
            gridViewTextBoxColumn3.Name = "Amount";
            gridViewTextBoxColumn3.Width = 262;
            gridViewDateTimeColumn1.CustomFormat = "dd-MM-yyyy";
            gridViewDateTimeColumn1.EditorType = Telerik.WinControls.UI.GridViewDateTimeEditorType.DateTimePickerSpinMode;
            gridViewDateTimeColumn1.EnableExpressionEditor = false;
            gridViewDateTimeColumn1.ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.Custom;
            gridViewDateTimeColumn1.FieldName = "DueDate";
            gridViewDateTimeColumn1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            gridViewDateTimeColumn1.FormatString = "{0:dd-MMM-yyyy}";
            gridViewDateTimeColumn1.HeaderText = "Due Date";
            gridViewDateTimeColumn1.Name = "DueDate";
            gridViewDateTimeColumn1.Width = 211;
            gridViewTextBoxColumn4.FieldName = "AcctStSeries";
            gridViewTextBoxColumn4.HeaderText = "Acct Series";
            gridViewTextBoxColumn4.Name = "AcctStSeries";
            gridViewTextBoxColumn4.Width = 96;
            this.radgplan.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewDateTimeColumn1,
            gridViewTextBoxColumn4});
            gridViewSummaryItem1.Aggregate = Telerik.WinControls.UI.GridAggregateFunction.Sum;
            gridViewSummaryItem1.AggregateExpression = null;
            gridViewSummaryItem1.FormatString = "{0:#,###0.00;(#,###0.00);0}";
            gridViewSummaryItem1.Name = "Amount";
            this.radgplan.MasterTemplate.SummaryRowsBottom.Add(new Telerik.WinControls.UI.GridViewSummaryRowItem(new Telerik.WinControls.UI.GridViewSummaryItem[] {
                gridViewSummaryItem1}));
            this.radgplan.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radgplan.Name = "radgplan";
            this.radgplan.ReadOnly = true;
            this.radgplan.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radgplan.ShowGroupPanel = false;
            this.radgplan.ShowGroupPanelScrollbars = false;
            this.radgplan.Size = new System.Drawing.Size(1106, 489);
            this.radgplan.TabIndex = 0;
            this.radgplan.Text = "radGridView1";
            this.radgplan.ThemeName = "TelerikMetro";
            // 
            // radbbtnDelete
            // 
            this.radbbtnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radbbtnDelete.Location = new System.Drawing.Point(934, 593);
            this.radbbtnDelete.Name = "radbbtnDelete";
            this.radbbtnDelete.Size = new System.Drawing.Size(188, 29);
            this.radbbtnDelete.TabIndex = 7;
            this.radbbtnDelete.Text = "Do you want to remove this plan";
            this.radbbtnDelete.ThemeName = "TelerikMetro";
            this.radbbtnDelete.Click += new System.EventHandler(this.radbbtnDelete_Click);
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(14, 23);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(541, 25);
            this.radLabel3.TabIndex = 8;
            this.radLabel3.Text = "Please review the data and confirm whether you want to bind or delete it.";
            // 
            // frmReviewPlanAgainstFileNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 644);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radbbtnDelete);
            this.Controls.Add(this.radGroupBox2);
            this.Name = "frmReviewPlanAgainstFileNo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReviewPlan";
            this.Load += new System.EventHandler(this.frmReviewPlanAgainstFileNo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radgplan.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radgplan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radbbtnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadGridView radgplan;
        private Telerik.WinControls.UI.RadButton radbbtnDelete;
        private Telerik.WinControls.UI.RadLabel radLabel3;
    }
}