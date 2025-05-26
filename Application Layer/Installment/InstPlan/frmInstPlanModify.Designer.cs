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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.radgvplan = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radphase = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radplotsize = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.btnSearch = new Telerik.WinControls.UI.RadButton();
            this.raddescrip = new Telerik.WinControls.UI.RadLabel();
            this.radenddate = new Telerik.WinControls.UI.RadLabel();
            this.radstartdate = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.rad_dropDown_Template = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radgvplan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radgvplan.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radphase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radplotsize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.raddescrip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radenddate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radstartdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rad_dropDown_Template)).BeginInit();
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
            this.radGroupBox2.Location = new System.Drawing.Point(12, 135);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(1091, 475);
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
            gridViewTextBoxColumn2.Width = 179;
            gridViewTextBoxColumn3.FieldName = "InstNo";
            gridViewTextBoxColumn3.HeaderText = "Installment No";
            gridViewTextBoxColumn3.Name = "InstNo";
            gridViewTextBoxColumn3.Width = 158;
            gridViewTextBoxColumn4.FieldName = "Descp";
            gridViewTextBoxColumn4.HeaderText = "Description";
            gridViewTextBoxColumn4.Name = "Descp";
            gridViewTextBoxColumn4.Width = 158;
            gridViewDateTimeColumn1.CustomFormat = "dd-MM-yyyy";
            gridViewDateTimeColumn1.EditorType = Telerik.WinControls.UI.GridViewDateTimeEditorType.DateTimePickerSpinMode;
            gridViewDateTimeColumn1.ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.Custom;
            gridViewDateTimeColumn1.FieldName = "DueDate";
            gridViewDateTimeColumn1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            gridViewDateTimeColumn1.HeaderText = "Due Date";
            gridViewDateTimeColumn1.Name = "DueDate";
            gridViewDateTimeColumn1.Width = 205;
            gridViewTextBoxColumn5.FieldName = "Amount";
            gridViewTextBoxColumn5.HeaderText = "Amount";
            gridViewTextBoxColumn5.Name = "Amount";
            gridViewTextBoxColumn5.Width = 130;
            gridViewTextBoxColumn6.FieldName = "Remarks";
            gridViewTextBoxColumn6.HeaderText = "Remarks";
            gridViewTextBoxColumn6.Name = "Remarks";
            gridViewTextBoxColumn6.Width = 241;
            this.radgvplan.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewDateTimeColumn1,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.radgvplan.MasterTemplate.EnableFiltering = true;
            this.radgvplan.MasterTemplate.EnablePaging = true;
            this.radgvplan.MasterTemplate.PageSize = 40;
            this.radgvplan.MasterTemplate.ShowGroupedColumns = true;
            this.radgvplan.MasterTemplate.ShowHeaderCellButtons = true;
            this.radgvplan.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radgvplan.Name = "radgvplan";
            this.radgvplan.ReadOnly = true;
            this.radgvplan.ShowHeaderCellButtons = true;
            this.radgvplan.Size = new System.Drawing.Size(1087, 455);
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
            this.radGroupBox1.Controls.Add(this.radLabel6);
            this.radGroupBox1.Controls.Add(this.radphase);
            this.radGroupBox1.Controls.Add(this.radLabel5);
            this.radGroupBox1.Controls.Add(this.radplotsize);
            this.radGroupBox1.Controls.Add(this.radLabel4);
            this.radGroupBox1.Controls.Add(this.btnSearch);
            this.radGroupBox1.Controls.Add(this.raddescrip);
            this.radGroupBox1.Controls.Add(this.radenddate);
            this.radGroupBox1.Controls.Add(this.radstartdate);
            this.radGroupBox1.Controls.Add(this.radLabel3);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.rad_dropDown_Template);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox1.HeaderText = "Template of Installment";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1091, 117);
            this.radGroupBox1.TabIndex = 4;
            this.radGroupBox1.Text = "Template of Installment";
            this.radGroupBox1.ThemeName = "TelerikMetro";
            // 
            // radLabel6
            // 
            this.radLabel6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel6.Location = new System.Drawing.Point(627, 32);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(50, 25);
            this.radLabel6.TabIndex = 9;
            this.radLabel6.Text = "Phase";
            // 
            // radphase
            // 
            this.radphase.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radphase.Location = new System.Drawing.Point(683, 32);
            this.radphase.Name = "radphase";
            this.radphase.Size = new System.Drawing.Size(14, 25);
            this.radphase.TabIndex = 8;
            this.radphase.Text = "-";
            // 
            // radLabel5
            // 
            this.radLabel5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel5.Location = new System.Drawing.Point(772, 32);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(70, 25);
            this.radLabel5.TabIndex = 7;
            this.radLabel5.Text = "Plot Size";
            // 
            // radplotsize
            // 
            this.radplotsize.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radplotsize.Location = new System.Drawing.Point(848, 32);
            this.radplotsize.Name = "radplotsize";
            this.radplotsize.Size = new System.Drawing.Size(14, 25);
            this.radplotsize.TabIndex = 6;
            this.radplotsize.Text = "-";
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(471, 73);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(91, 25);
            this.radLabel4.TabIndex = 5;
            this.radLabel4.Text = "Description";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(943, 32);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(106, 66);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Add";
            this.btnSearch.ThemeName = "TelerikMetro";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // raddescrip
            // 
            this.raddescrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raddescrip.Location = new System.Drawing.Point(591, 73);
            this.raddescrip.Name = "raddescrip";
            this.raddescrip.Size = new System.Drawing.Size(14, 25);
            this.raddescrip.TabIndex = 4;
            this.raddescrip.Text = "-";
            // 
            // radenddate
            // 
            this.radenddate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radenddate.Location = new System.Drawing.Point(347, 73);
            this.radenddate.Name = "radenddate";
            this.radenddate.Size = new System.Drawing.Size(14, 25);
            this.radenddate.TabIndex = 3;
            this.radenddate.Text = "-";
            // 
            // radstartdate
            // 
            this.radstartdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radstartdate.Location = new System.Drawing.Point(124, 73);
            this.radstartdate.Name = "radstartdate";
            this.radstartdate.Size = new System.Drawing.Size(14, 25);
            this.radstartdate.TabIndex = 3;
            this.radstartdate.Text = "-";
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(251, 73);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(74, 25);
            this.radLabel3.TabIndex = 2;
            this.radLabel3.Text = "End Date";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(21, 73);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(81, 25);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "Start Date";
            // 
            // rad_dropDown_Template
            // 
            this.rad_dropDown_Template.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.rad_dropDown_Template.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad_dropDown_Template.Location = new System.Drawing.Point(283, 32);
            this.rad_dropDown_Template.Name = "rad_dropDown_Template";
            this.rad_dropDown_Template.Size = new System.Drawing.Size(322, 30);
            this.rad_dropDown_Template.TabIndex = 1;
            this.rad_dropDown_Template.ThemeName = "TelerikMetro";
            this.rad_dropDown_Template.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.rad_dropDown_Template_SelectedIndexChanged);
            ((Telerik.WinControls.UI.RadDropDownListElement)(this.rad_dropDown_Template.GetChildAt(0))).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            ((Telerik.WinControls.UI.RadDropDownListEditableAreaElement)(this.rad_dropDown_Template.GetChildAt(0).GetChildAt(2).GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(21, 32);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(256, 25);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Select Installment Template Name";
            // 
            // frmInstPlanModify
            // 
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
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radphase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radplotsize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.raddescrip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radenddate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radstartdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rad_dropDown_Template)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadGridView radgvplan;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel radphase;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadLabel radplotsize;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadButton btnSearch;
        private Telerik.WinControls.UI.RadLabel raddescrip;
        private Telerik.WinControls.UI.RadLabel radenddate;
        private Telerik.WinControls.UI.RadLabel radstartdate;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadDropDownList rad_dropDown_Template;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
    }
}
