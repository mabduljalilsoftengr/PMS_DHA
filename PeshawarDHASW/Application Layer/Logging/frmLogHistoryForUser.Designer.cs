namespace PeshawarDHASW.Application_Layer.Logging
{
    partial class frmLogHistoryForUser
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
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem4 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.RadListDataItem radListDataItem5 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem6 = new Telerik.WinControls.UI.RadListDataItem();
            this.ddlRecordSize = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.GVErrorView = new Telerik.WinControls.UI.RadGridView();
            this.drpTableName = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.btnFind = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRecordSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVErrorView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVErrorView.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpTableName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlRecordSize
            // 
            this.ddlRecordSize.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlRecordSize.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radListDataItem1.Text = "100";
            radListDataItem2.Text = "500";
            radListDataItem3.Text = "2000";
            radListDataItem4.Text = "All";
            this.ddlRecordSize.Items.Add(radListDataItem1);
            this.ddlRecordSize.Items.Add(radListDataItem2);
            this.ddlRecordSize.Items.Add(radListDataItem3);
            this.ddlRecordSize.Items.Add(radListDataItem4);
            this.ddlRecordSize.Location = new System.Drawing.Point(510, 9);
            this.ddlRecordSize.Name = "ddlRecordSize";
            this.ddlRecordSize.Size = new System.Drawing.Size(169, 25);
            this.ddlRecordSize.TabIndex = 11;
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(361, 8);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(147, 25);
            this.radLabel1.TabIndex = 10;
            this.radLabel1.Text = "Select Records Size";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.GVErrorView);
            this.radGroupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox1.HeaderText = "All System Error";
            this.radGroupBox1.Location = new System.Drawing.Point(4, 33);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1140, 649);
            this.radGroupBox1.TabIndex = 9;
            this.radGroupBox1.Text = "All System Error";
            // 
            // GVErrorView
            // 
            this.GVErrorView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GVErrorView.Location = new System.Drawing.Point(6, 22);
            // 
            // 
            // 
            this.GVErrorView.MasterTemplate.AllowAddNewRow = false;
            this.GVErrorView.MasterTemplate.AllowColumnReorder = false;
            this.GVErrorView.MasterTemplate.AllowSearchRow = true;
            this.GVErrorView.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn1.FieldName = "LogID";
            gridViewTextBoxColumn1.HeaderText = "LogID";
            gridViewTextBoxColumn1.Name = "LogID";
            gridViewTextBoxColumn1.Width = 103;
            gridViewTextBoxColumn2.FieldName = "username";
            gridViewTextBoxColumn2.HeaderText = "Username";
            gridViewTextBoxColumn2.Name = "username";
            gridViewTextBoxColumn2.Width = 87;
            gridViewTextBoxColumn3.FieldName = "DateofEntry";
            gridViewTextBoxColumn3.HeaderText = "DateofEntry";
            gridViewTextBoxColumn3.Name = "DateofEntry";
            gridViewTextBoxColumn3.Width = 95;
            gridViewTextBoxColumn4.FieldName = "Type";
            gridViewTextBoxColumn4.HeaderText = "Type";
            gridViewTextBoxColumn4.Name = "Type";
            gridViewTextBoxColumn4.Width = 95;
            gridViewTextBoxColumn5.FieldName = "TableName";
            gridViewTextBoxColumn5.HeaderText = "TableName";
            gridViewTextBoxColumn5.Name = "TableName";
            gridViewTextBoxColumn5.Width = 95;
            gridViewTextBoxColumn6.FieldName = "ProcedureName";
            gridViewTextBoxColumn6.HeaderText = "ProcedureName";
            gridViewTextBoxColumn6.Name = "ProcedureName";
            gridViewTextBoxColumn6.Width = 95;
            gridViewTextBoxColumn7.FieldName = "DatabaseName";
            gridViewTextBoxColumn7.HeaderText = "DatabaseName";
            gridViewTextBoxColumn7.Name = "DatabaseName";
            gridViewTextBoxColumn7.Width = 96;
            gridViewTextBoxColumn8.FieldName = "Data";
            gridViewTextBoxColumn8.HeaderText = "Data";
            gridViewTextBoxColumn8.Name = "Data";
            gridViewTextBoxColumn8.Width = 449;
            this.GVErrorView.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8});
            this.GVErrorView.MasterTemplate.EnableFiltering = true;
            this.GVErrorView.MasterTemplate.EnablePaging = true;
            this.GVErrorView.MasterTemplate.PageSize = 25;
            this.GVErrorView.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GVErrorView.Name = "GVErrorView";
            this.GVErrorView.ReadOnly = true;
            this.GVErrorView.Size = new System.Drawing.Size(1129, 622);
            this.GVErrorView.TabIndex = 0;
            this.GVErrorView.Text = "GVErrorView";
            // 
            // drpTableName
            // 
            this.drpTableName.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.drpTableName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radListDataItem5.Text = "-- Select --";
            radListDataItem6.Text = "NDC";
            this.drpTableName.Items.Add(radListDataItem5);
            this.drpTableName.Items.Add(radListDataItem6);
            this.drpTableName.Location = new System.Drawing.Point(113, 8);
            this.drpTableName.Name = "drpTableName";
            this.drpTableName.Size = new System.Drawing.Size(217, 25);
            this.drpTableName.TabIndex = 13;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(12, 7);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(95, 25);
            this.radLabel2.TabIndex = 12;
            this.radLabel2.Text = "Select Table";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(718, 5);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(110, 28);
            this.btnFind.TabIndex = 14;
            this.btnFind.Text = "Find";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // frmLogHistoryForUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 685);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.drpTableName);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.ddlRecordSize);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmLogHistoryForUser";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmLogHistory";
            this.Load += new System.EventHandler(this.frmLogHistoryForUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ddlRecordSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GVErrorView.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVErrorView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpTableName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList ddlRecordSize;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView GVErrorView;
        private Telerik.WinControls.UI.RadDropDownList drpTableName;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton btnFind;
    }
}
