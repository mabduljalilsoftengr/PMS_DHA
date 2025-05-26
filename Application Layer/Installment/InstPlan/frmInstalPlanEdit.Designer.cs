namespace PeshawarDHASW.Application_Layer.Installment.InstPlan
{
    partial class frmInstalPlanEdit
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.label1 = new System.Windows.Forms.Label();
            this.dS_planEdit1 = new PeshawarDHASW.Application_Layer.Installment.InstPlan.DS_planEdit();
            this.textBoxFileNo = new System.Windows.Forms.TextBox();
            this.btn_viewPlan = new System.Windows.Forms.Button();
            this.cachedTotalTransferReport1 = new PeshawarDHASW.Application_Layer.Transfer.Transfer_Information.Total_Transfer_Detail.CachedTotalTransferReport();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.planEditGridView = new Telerik.WinControls.UI.RadGridView();
            this.InstallmentPlan = new Telerik.WinControls.UI.GridViewTemplate();
            this.btnUpdateInstallment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dS_planEdit1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planEditGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planEditGridView.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstallmentPlan)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "FileNo :";
            // 
            // dS_planEdit1
            // 
            this.dS_planEdit1.DataSetName = "DS_planEdit";
            this.dS_planEdit1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBoxFileNo
            // 
            this.textBoxFileNo.Location = new System.Drawing.Point(64, 19);
            this.textBoxFileNo.Name = "textBoxFileNo";
            this.textBoxFileNo.Size = new System.Drawing.Size(153, 20);
            this.textBoxFileNo.TabIndex = 12;
            // 
            // btn_viewPlan
            // 
            this.btn_viewPlan.BackColor = System.Drawing.Color.AliceBlue;
            this.btn_viewPlan.Location = new System.Drawing.Point(228, 13);
            this.btn_viewPlan.Name = "btn_viewPlan";
            this.btn_viewPlan.Size = new System.Drawing.Size(153, 31);
            this.btn_viewPlan.TabIndex = 11;
            this.btn_viewPlan.Text = "View Plan";
            this.btn_viewPlan.UseVisualStyleBackColor = false;
            this.btn_viewPlan.Click += new System.EventHandler(this.btn_viewPlan_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.planEditGridView);
            this.groupBox1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.groupBox1.Location = new System.Drawing.Point(-4, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1161, 674);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "InstallmentPlan";
            // 
            // planEditGridView
            // 
            this.planEditGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.planEditGridView.BackColor = System.Drawing.Color.White;
            this.planEditGridView.Cursor = System.Windows.Forms.Cursors.Default;
            this.planEditGridView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.planEditGridView.ForeColor = System.Drawing.SystemColors.ControlText;
            this.planEditGridView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.planEditGridView.Location = new System.Drawing.Point(3, 18);
            // 
            // 
            // 
            this.planEditGridView.MasterTemplate.AllowAddNewRow = false;
            this.planEditGridView.MasterTemplate.AutoGenerateColumns = false;
            this.planEditGridView.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "PlanID";
            gridViewTextBoxColumn1.HeaderText = "PlanID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "PlanID";
            gridViewTextBoxColumn1.Width = 95;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "Name";
            gridViewTextBoxColumn2.HeaderText = "Template Name";
            gridViewTextBoxColumn2.Name = "Name";
            gridViewTextBoxColumn2.VisibleInColumnChooser = false;
            gridViewTextBoxColumn2.Width = 177;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "InstNo";
            gridViewTextBoxColumn3.HeaderText = "Installment No";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "InstNo";
            gridViewTextBoxColumn3.Width = 150;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "Descp";
            gridViewTextBoxColumn4.HeaderText = "Description";
            gridViewTextBoxColumn4.Name = "Descp";
            gridViewTextBoxColumn4.Width = 229;
            gridViewDateTimeColumn1.CustomFormat = "dd-MM-yyyy";
            gridViewDateTimeColumn1.EditorType = Telerik.WinControls.UI.GridViewDateTimeEditorType.DateTimePickerSpinMode;
            gridViewDateTimeColumn1.EnableExpressionEditor = false;
            gridViewDateTimeColumn1.ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.Custom;
            gridViewDateTimeColumn1.FieldName = "DueDate";
            gridViewDateTimeColumn1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            gridViewDateTimeColumn1.FormatString = "{0:dd/MMM/yyyy}";
            gridViewDateTimeColumn1.HeaderText = "Due Date";
            gridViewDateTimeColumn1.Name = "DueDate";
            gridViewDateTimeColumn1.Width = 235;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "Amount";
            gridViewTextBoxColumn5.HeaderText = "Amount";
            gridViewTextBoxColumn5.Name = "Amount";
            gridViewTextBoxColumn5.Width = 127;
            gridViewTextBoxColumn6.FieldName = "InstallmentMode";
            gridViewTextBoxColumn6.HeaderText = "InstallmentMode";
            gridViewTextBoxColumn6.Name = "InstallmentMode";
            gridViewTextBoxColumn6.Width = 203;
            gridViewTextBoxColumn7.FieldName = "CODE";
            gridViewTextBoxColumn7.HeaderText = "Code";
            gridViewTextBoxColumn7.Name = "CODE";
            gridViewTextBoxColumn7.Width = 100;
            gridViewTextBoxColumn8.FieldName = "AcctStSeries";
            gridViewTextBoxColumn8.HeaderText = "Acct St Series";
            gridViewTextBoxColumn8.Name = "AcctStSeries";
            gridViewTextBoxColumn8.Width = 48;
            gridViewTextBoxColumn9.FieldName = "instalTempID";
            gridViewTextBoxColumn9.HeaderText = "InstalTempID";
            gridViewTextBoxColumn9.IsVisible = false;
            gridViewTextBoxColumn9.Name = "instalTempID";
            gridViewTextBoxColumn9.Width = 221;
            this.planEditGridView.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewDateTimeColumn1,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9});
            this.planEditGridView.MasterTemplate.EnableFiltering = true;
            this.planEditGridView.MasterTemplate.EnablePaging = true;
            this.planEditGridView.MasterTemplate.PageSize = 40;
            this.planEditGridView.MasterTemplate.ShowGroupedColumns = true;
            this.planEditGridView.MasterTemplate.ShowHeaderCellButtons = true;
            this.planEditGridView.MasterTemplate.Templates.AddRange(new Telerik.WinControls.UI.GridViewTemplate[] {
            this.InstallmentPlan});
            this.planEditGridView.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.planEditGridView.Name = "planEditGridView";
            this.planEditGridView.ReadOnly = true;
            this.planEditGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.planEditGridView.ShowHeaderCellButtons = true;
            this.planEditGridView.Size = new System.Drawing.Size(1155, 653);
            this.planEditGridView.TabIndex = 1;
            this.planEditGridView.Text = "radGridView1";
            this.planEditGridView.ThemeName = "TelerikMetro";
            this.planEditGridView.Click += new System.EventHandler(this.planEditGridView_Click);
            // 
            // InstallmentPlan
            // 
            gridViewTextBoxColumn10.FieldName = "PlanID";
            gridViewTextBoxColumn10.HeaderText = "PlanID";
            gridViewTextBoxColumn10.Name = "Plan ID";
            gridViewTextBoxColumn11.HeaderText = "instal Temp ID";
            gridViewTextBoxColumn11.Name = "instalTempID";
            this.InstallmentPlan.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11});
            this.InstallmentPlan.ViewDefinition = tableViewDefinition1;
            // 
            // btnUpdateInstallment
            // 
            this.btnUpdateInstallment.BackColor = System.Drawing.Color.AliceBlue;
            this.btnUpdateInstallment.Location = new System.Drawing.Point(387, 13);
            this.btnUpdateInstallment.Name = "btnUpdateInstallment";
            this.btnUpdateInstallment.Size = new System.Drawing.Size(153, 31);
            this.btnUpdateInstallment.TabIndex = 15;
            this.btnUpdateInstallment.Text = "Update";
            this.btnUpdateInstallment.UseVisualStyleBackColor = false;
            this.btnUpdateInstallment.Click += new System.EventHandler(this.btnUpdateInstallment_Click);
            // 
            // frmInstalPlanEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 749);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFileNo);
            this.Controls.Add(this.btn_viewPlan);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnUpdateInstallment);
            this.Name = "frmInstalPlanEdit";
            this.Text = "InstallmentPlanAdjustment";
            this.Load += new System.EventHandler(this.frmInstalPlanEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dS_planEdit1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.planEditGridView.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planEditGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstallmentPlan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DS_planEdit dS_planEdit1;
        private System.Windows.Forms.TextBox textBoxFileNo;
        private System.Windows.Forms.Button btn_viewPlan;
        private Transfer.Transfer_Information.Total_Transfer_Detail.CachedTotalTransferReport cachedTotalTransferReport1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadGridView planEditGridView;
        private Telerik.WinControls.UI.GridViewTemplate InstallmentPlan;
        private System.Windows.Forms.Button btnUpdateInstallment;
    }
}