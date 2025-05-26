namespace PeshawarDHASW.Application_Layer.DBError
{
    partial class frmDBErrorView
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
            this.ddlRecordSize = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.GVErrorView = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRecordSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVErrorView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVErrorView.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlRecordSize
            // 
            this.ddlRecordSize.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlRecordSize.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radListDataItem1.Text = "100";
            radListDataItem2.Text = "250";
            radListDataItem3.Text = "500";
            radListDataItem4.Text = "1000";
            this.ddlRecordSize.Items.Add(radListDataItem1);
            this.ddlRecordSize.Items.Add(radListDataItem2);
            this.ddlRecordSize.Items.Add(radListDataItem3);
            this.ddlRecordSize.Items.Add(radListDataItem4);
            this.ddlRecordSize.Location = new System.Drawing.Point(158, 5);
            this.ddlRecordSize.Name = "ddlRecordSize";
            this.ddlRecordSize.Size = new System.Drawing.Size(169, 25);
            this.ddlRecordSize.TabIndex = 5;
            this.ddlRecordSize.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddlRecordSize_SelectedIndexChanged);
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(9, 4);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(147, 25);
            this.radLabel1.TabIndex = 4;
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
            this.radGroupBox1.Location = new System.Drawing.Point(3, 35);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1140, 649);
            this.radGroupBox1.TabIndex = 3;
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
            this.GVErrorView.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "ErrorNo";
            gridViewTextBoxColumn1.HeaderText = "ErrorNo";
            gridViewTextBoxColumn1.Name = "ErrorNo";
            gridViewTextBoxColumn1.Width = 139;
            gridViewTextBoxColumn2.FieldName = "ErrorNumber";
            gridViewTextBoxColumn2.HeaderText = "ErrorNumber";
            gridViewTextBoxColumn2.Name = "ErrorNumber";
            gridViewTextBoxColumn2.Width = 139;
            gridViewTextBoxColumn3.FieldName = "ErrorSeverity";
            gridViewTextBoxColumn3.HeaderText = "ErrorSeverity";
            gridViewTextBoxColumn3.Name = "ErrorSeverity";
            gridViewTextBoxColumn3.Width = 139;
            gridViewTextBoxColumn4.FieldName = "ErrorState";
            gridViewTextBoxColumn4.HeaderText = "ErrorState";
            gridViewTextBoxColumn4.Name = "ErrorState";
            gridViewTextBoxColumn4.Width = 139;
            gridViewTextBoxColumn5.FieldName = "ErrorProcedure";
            gridViewTextBoxColumn5.HeaderText = "ErrorProcedure";
            gridViewTextBoxColumn5.Name = "ErrorProcedure";
            gridViewTextBoxColumn5.Width = 139;
            gridViewTextBoxColumn6.FieldName = "ErrorLine";
            gridViewTextBoxColumn6.HeaderText = "ErrorLine";
            gridViewTextBoxColumn6.Name = "ErrorLine";
            gridViewTextBoxColumn6.Width = 139;
            gridViewTextBoxColumn7.FieldName = "ErrorMessage";
            gridViewTextBoxColumn7.HeaderText = "ErrorMessage";
            gridViewTextBoxColumn7.Name = "ErrorMessage";
            gridViewTextBoxColumn7.Width = 139;
            gridViewTextBoxColumn8.DataType = typeof(System.DateTime);
            gridViewTextBoxColumn8.FieldName = "TimeofOccurances";
            gridViewTextBoxColumn8.HeaderText = "TimeofOccurances";
            gridViewTextBoxColumn8.Name = "TimeofOccurances";
            gridViewTextBoxColumn8.Width = 142;
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
            // frmDBErrorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 688);
            this.Controls.Add(this.ddlRecordSize);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmDBErrorView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmDBErrorView";
            this.Load += new System.EventHandler(this.frmDBErrorView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ddlRecordSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GVErrorView.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVErrorView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList ddlRecordSize;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView GVErrorView;
    }
}
