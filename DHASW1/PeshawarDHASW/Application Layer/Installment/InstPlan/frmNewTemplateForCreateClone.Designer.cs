namespace PeshawarDHASW.Application_Layer.Installment.InstPlan
{
    partial class frmNewTemplateForCreateClone
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
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn1 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn2 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.cmbTempGroup = new System.Windows.Forms.ComboBox();
            this.cbSpecificFilNo = new System.Windows.Forms.CheckBox();
            this.cbCreateClone = new System.Windows.Forms.CheckBox();
            this.txtFileNo = new Telerik.WinControls.UI.RadTextBox();
            this.lblFileNo = new Telerik.WinControls.UI.RadLabel();
            this.btnCreateInstallment = new Telerik.WinControls.UI.RadButton();
            this.grdplandata = new Telerik.WinControls.UI.RadGridView();
            this.txtTemplateName = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFileNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCreateInstallment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdplandata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdplandata.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTemplateName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radLabel3);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.cbStatus);
            this.radGroupBox1.Controls.Add(this.cmbTempGroup);
            this.radGroupBox1.Controls.Add(this.cbSpecificFilNo);
            this.radGroupBox1.Controls.Add(this.cbCreateClone);
            this.radGroupBox1.Controls.Add(this.txtFileNo);
            this.radGroupBox1.Controls.Add(this.lblFileNo);
            this.radGroupBox1.Controls.Add(this.btnCreateInstallment);
            this.radGroupBox1.Controls.Add(this.grdplandata);
            this.radGroupBox1.Controls.Add(this.txtTemplateName);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.HeaderText = "Existing Data";
            this.radGroupBox1.Location = new System.Drawing.Point(8, 4);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(995, 523);
            this.radGroupBox1.TabIndex = 1;
            this.radGroupBox1.Text = "Existing Data";
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(54, 53);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(103, 21);
            this.radLabel3.TabIndex = 2;
            this.radLabel3.Text = "Template Group";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(319, 53);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(43, 21);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "Status";
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(368, 53);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(121, 21);
            this.cbStatus.TabIndex = 19;
            // 
            // cmbTempGroup
            // 
            this.cmbTempGroup.FormattingEnabled = true;
            this.cmbTempGroup.Location = new System.Drawing.Point(163, 53);
            this.cmbTempGroup.Name = "cmbTempGroup";
            this.cmbTempGroup.Size = new System.Drawing.Size(121, 21);
            this.cmbTempGroup.TabIndex = 20;
            // 
            // cbSpecificFilNo
            // 
            this.cbSpecificFilNo.AutoSize = true;
            this.cbSpecificFilNo.Location = new System.Drawing.Point(506, 53);
            this.cbSpecificFilNo.Name = "cbSpecificFilNo";
            this.cbSpecificFilNo.Size = new System.Drawing.Size(233, 17);
            this.cbSpecificFilNo.TabIndex = 18;
            this.cbSpecificFilNo.Text = "Create Schedule plan for specific FileNo ";
            this.cbSpecificFilNo.UseVisualStyleBackColor = true;
            this.cbSpecificFilNo.CheckedChanged += new System.EventHandler(this.cbSpecificFilNo_CheckedChanged);
            // 
            // cbCreateClone
            // 
            this.cbCreateClone.AutoSize = true;
            this.cbCreateClone.Location = new System.Drawing.Point(506, 17);
            this.cbCreateClone.Name = "cbCreateClone";
            this.cbCreateClone.Size = new System.Drawing.Size(194, 17);
            this.cbCreateClone.TabIndex = 17;
            this.cbCreateClone.Text = "Create Schedule plan as a Clone ";
            this.cbCreateClone.UseVisualStyleBackColor = true;
            this.cbCreateClone.CheckedChanged += new System.EventHandler(this.cbCreateClone_CheckedChanged);
            // 
            // txtFileNo
            // 
            this.txtFileNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileNo.Location = new System.Drawing.Point(807, 31);
            this.txtFileNo.MaxLength = 100;
            this.txtFileNo.Name = "txtFileNo";
            this.txtFileNo.Size = new System.Drawing.Size(181, 27);
            this.txtFileNo.TabIndex = 16;
            this.txtFileNo.Leave += new System.EventHandler(this.txtFileNo_Leave);
            // 
            // lblFileNo
            // 
            this.lblFileNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileNo.Location = new System.Drawing.Point(738, 32);
            this.lblFileNo.Name = "lblFileNo";
            this.lblFileNo.Size = new System.Drawing.Size(63, 25);
            this.lblFileNo.TabIndex = 15;
            this.lblFileNo.Text = "File No.";
            // 
            // btnCreateInstallment
            // 
            this.btnCreateInstallment.Location = new System.Drawing.Point(746, 483);
            this.btnCreateInstallment.Name = "btnCreateInstallment";
            this.btnCreateInstallment.Size = new System.Drawing.Size(242, 24);
            this.btnCreateInstallment.TabIndex = 10;
            this.btnCreateInstallment.Text = "Create Template/Plan";
            this.btnCreateInstallment.Click += new System.EventHandler(this.btnCreateInstallmentPlan);
            // 
            // grdplandata
            // 
            this.grdplandata.AutoScroll = true;
            this.grdplandata.BackColor = System.Drawing.SystemColors.Control;
            this.grdplandata.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdplandata.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.grdplandata.ForeColor = System.Drawing.Color.Black;
            this.grdplandata.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdplandata.Location = new System.Drawing.Point(9, 80);
            // 
            // 
            // 
            this.grdplandata.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "PlanID";
            gridViewTextBoxColumn1.HeaderText = "Plan ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "PlanID";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "instalTempID";
            gridViewTextBoxColumn2.HeaderText = "instalTempID";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "instalTempID";
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "InstNo";
            gridViewTextBoxColumn3.HeaderText = "Inst No";
            gridViewTextBoxColumn3.Name = "InstNo";
            gridViewTextBoxColumn3.Width = 192;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "Descp";
            gridViewTextBoxColumn4.HeaderText = "Descp";
            gridViewTextBoxColumn4.Name = "Descp";
            gridViewTextBoxColumn4.Width = 192;
            gridViewDateTimeColumn1.EnableExpressionEditor = false;
            gridViewDateTimeColumn1.FieldName = "gvdt_DueDate";
            gridViewDateTimeColumn1.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            gridViewDateTimeColumn1.HeaderText = "DueDate";
            gridViewDateTimeColumn1.Name = "gvdt_DueDate";
            gridViewDateTimeColumn1.Width = 176;
            gridViewDecimalColumn1.FieldName = "Amount";
            gridViewDecimalColumn1.HeaderText = "Amount";
            gridViewDecimalColumn1.Name = "Amount";
            gridViewDecimalColumn1.Width = 57;
            gridViewComboBoxColumn1.EnableExpressionEditor = false;
            gridViewComboBoxColumn1.FieldName = "gvcb_Installmentmode";
            gridViewComboBoxColumn1.HeaderText = "Install Mode";
            gridViewComboBoxColumn1.Name = "gvcb_Installmentmode";
            gridViewComboBoxColumn1.Width = 176;
            gridViewComboBoxColumn2.EnableExpressionEditor = false;
            gridViewComboBoxColumn2.FieldName = "gvcb_Code";
            gridViewComboBoxColumn2.HeaderText = "Code";
            gridViewComboBoxColumn2.Name = "gvcb_Code";
            gridViewComboBoxColumn2.Width = 75;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "AcctStSeries";
            gridViewTextBoxColumn5.HeaderText = "Series ";
            gridViewTextBoxColumn5.Name = "AcctStSeries";
            gridViewTextBoxColumn5.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending;
            gridViewTextBoxColumn5.Width = 96;
            this.grdplandata.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewDateTimeColumn1,
            gridViewDecimalColumn1,
            gridViewComboBoxColumn1,
            gridViewComboBoxColumn2,
            gridViewTextBoxColumn5});
            sortDescriptor1.PropertyName = "AcctStSeries";
            this.grdplandata.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.grdplandata.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdplandata.Name = "grdplandata";
            this.grdplandata.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grdplandata.Size = new System.Drawing.Size(979, 376);
            this.grdplandata.TabIndex = 2;
            this.grdplandata.Text = "radGridView1";
            // 
            // txtTemplateName
            // 
            this.txtTemplateName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTemplateName.Location = new System.Drawing.Point(162, 16);
            this.txtTemplateName.Name = "txtTemplateName";
            this.txtTemplateName.Size = new System.Drawing.Size(326, 23);
            this.txtTemplateName.TabIndex = 1;
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(16, 17);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(147, 21);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Enter Text For Template";
            // 
            // frmNewTemplateForCreateClone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 528);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmNewTemplateForCreateClone";
            this.Text = "Create New Template For Clone";
            this.Load += new System.EventHandler(this.frmNewTemplateForCreateClone_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFileNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCreateInstallment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdplandata.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdplandata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTemplateName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton btnCreateInstallment;
        private Telerik.WinControls.UI.RadTextBox txtTemplateName;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadGridView grdplandata;
        private System.Windows.Forms.CheckBox cbSpecificFilNo;
        private System.Windows.Forms.CheckBox cbCreateClone;
        private Telerik.WinControls.UI.RadTextBox txtFileNo;
        private Telerik.WinControls.UI.RadLabel lblFileNo;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private System.Windows.Forms.ComboBox cmbTempGroup;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private System.Windows.Forms.ComboBox cbStatus;
    }
}