namespace PeshawarDHASW.Application_Layer.Installment.InstPlan
{
    partial class frmInstPlanModify
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
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.radgvplan = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.txtFileNo = new Telerik.WinControls.UI.RadTextBox();
            this.radBtnSearch = new Telerik.WinControls.UI.RadButton();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radgvplan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radgvplan.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox2.Controls.Add(this.radgvplan);
            this.radGroupBox2.HeaderText = "Add Plan";
            this.radGroupBox2.Location = new System.Drawing.Point(12, 108);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(1091, 502);
            this.radGroupBox2.TabIndex = 5;
            this.radGroupBox2.Text = "Add Plan";
            this.radGroupBox2.ThemeName = "TelerikMetro";
            // 
            // radgvplan
            // 
            this.radgvplan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radgvplan.Location = new System.Drawing.Point(2, 18);
            // 
            // 
            // 
            this.radgvplan.MasterTemplate.AllowAddNewRow = false;
            this.radgvplan.MasterTemplate.AutoGenerateColumns = false;
            this.radgvplan.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "PlanID";
            gridViewTextBoxColumn1.HeaderText = "PlanID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "PlanID";
            gridViewTextBoxColumn1.VisibleInColumnChooser = false;
            gridViewTextBoxColumn1.Width = 10;
            gridViewTextBoxColumn2.FieldName = "Name";
            gridViewTextBoxColumn2.HeaderText = "Template Name";
            gridViewTextBoxColumn2.Name = "Name";
            gridViewTextBoxColumn2.Width = 157;
            gridViewTextBoxColumn3.FieldName = "InstNo";
            gridViewTextBoxColumn3.HeaderText = "Installment No";
            gridViewTextBoxColumn3.Name = "InstNo";
            gridViewTextBoxColumn3.Width = 148;
            gridViewTextBoxColumn4.FieldName = "Descp";
            gridViewTextBoxColumn4.HeaderText = "Description";
            gridViewTextBoxColumn4.Name = "Descp";
            gridViewTextBoxColumn4.Width = 122;
            gridViewDateTimeColumn1.CustomFormat = "dd-MM-yyyy";
            gridViewDateTimeColumn1.EditorType = Telerik.WinControls.UI.GridViewDateTimeEditorType.DateTimePickerSpinMode;
            gridViewDateTimeColumn1.ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.Custom;
            gridViewDateTimeColumn1.FieldName = "DueDate";
            gridViewDateTimeColumn1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            gridViewDateTimeColumn1.HeaderText = "Due Date";
            gridViewDateTimeColumn1.Name = "DueDate";
            gridViewDateTimeColumn1.Width = 107;
            gridViewTextBoxColumn5.FieldName = "Amount";
            gridViewTextBoxColumn5.HeaderText = "Amount";
            gridViewTextBoxColumn5.Name = "Amount";
            gridViewTextBoxColumn5.Width = 97;
            gridViewTextBoxColumn6.FieldName = "Remarks";
            gridViewTextBoxColumn6.HeaderText = "Remarks";
            gridViewTextBoxColumn6.Name = "Remarks";
            gridViewTextBoxColumn6.Width = 99;
            gridViewTextBoxColumn7.FieldName = "InstalTempID";
            gridViewTextBoxColumn7.HeaderText = "InstalTempID";
            gridViewTextBoxColumn7.IsVisible = false;
            gridViewTextBoxColumn7.Name = "InstalTempID";
            gridViewTextBoxColumn7.Width = 49;
            gridViewTextBoxColumn8.FieldName = "InstallmentMode";
            gridViewTextBoxColumn8.HeaderText = "Installment Mode";
            gridViewTextBoxColumn8.Name = "InstallmentMode";
            gridViewTextBoxColumn8.Width = 145;
            gridViewTextBoxColumn9.FieldName = "CODE";
            gridViewTextBoxColumn9.HeaderText = "Code";
            gridViewTextBoxColumn9.Name = "CODE";
            gridViewTextBoxColumn9.Width = 112;
            gridViewTextBoxColumn10.FieldName = "AcctStSeries";
            gridViewTextBoxColumn10.HeaderText = "AcctStSeries";
            gridViewTextBoxColumn10.Name = "AcctStSeries";
            gridViewTextBoxColumn10.Width = 87;
            this.radgvplan.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewDateTimeColumn1,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10});
            this.radgvplan.MasterTemplate.EnableFiltering = true;
            this.radgvplan.MasterTemplate.EnablePaging = true;
            this.radgvplan.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.radgvplan.MasterTemplate.PageSize = 100;
            this.radgvplan.MasterTemplate.ShowGroupedColumns = true;
            this.radgvplan.MasterTemplate.ShowHeaderCellButtons = true;
            this.radgvplan.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radgvplan.Name = "radgvplan";
            this.radgvplan.ReadOnly = true;
            this.radgvplan.ShowHeaderCellButtons = true;
            this.radgvplan.Size = new System.Drawing.Size(1087, 482);
            this.radgvplan.TabIndex = 0;
            this.radgvplan.Text = "radGridView1";
            this.radgvplan.ThemeName = "TelerikMetro";
            this.radgvplan.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.radgvplan_CellClick);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.txtFileNo);
            this.radGroupBox1.Controls.Add(this.radBtnSearch);
            this.radGroupBox1.Controls.Add(this.btnAdd);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox1.HeaderText = "Template of Installment";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1091, 90);
            this.radGroupBox1.TabIndex = 4;
            this.radGroupBox1.Text = "Template of Installment";
            this.radGroupBox1.ThemeName = "TelerikMetro";
            // 
            // txtFileNo
            // 
            this.txtFileNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileNo.Location = new System.Drawing.Point(90, 32);
            this.txtFileNo.MaxLength = 100;
            this.txtFileNo.Name = "txtFileNo";
            this.txtFileNo.Size = new System.Drawing.Size(206, 27);
            this.txtFileNo.TabIndex = 1;
            // 
            // radBtnSearch
            // 
            this.radBtnSearch.Location = new System.Drawing.Point(312, 32);
            this.radBtnSearch.Name = "radBtnSearch";
            this.radBtnSearch.Size = new System.Drawing.Size(106, 27);
            this.radBtnSearch.TabIndex = 2;
            this.radBtnSearch.Text = "Search";
            this.radBtnSearch.ThemeName = "TelerikMetro";
            this.radBtnSearch.Click += new System.EventHandler(this.radBtnSearch_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(424, 32);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(106, 27);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Insert New Row";
            this.btnAdd.ThemeName = "TelerikMetro";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(21, 32);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(63, 25);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "File No.";
            // 
            // frmInstPlanModify
            // 
            this.AcceptButton = this.radBtnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 622);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmInstPlanModify";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Installment Plan Modify";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.frmInstPlanModify_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radgvplan.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radgvplan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadGridView radgvplan;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton btnAdd;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadTextBox txtFileNo;
        private Telerik.WinControls.UI.RadButton radBtnSearch;
    }
}
