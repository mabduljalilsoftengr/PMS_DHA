namespace PeshawarDHASW.Application_Layer.Role_Form
{
    partial class frmUserAccessClone
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
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.Data.GroupDescriptor groupDescriptor1 = new Telerik.WinControls.Data.GroupDescriptor();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.ddCloneAccess = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel17 = new Telerik.WinControls.UI.RadLabel();
            this.ddExistingAccess = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel16 = new Telerik.WinControls.UI.RadLabel();
            this.raddgvControlSetting = new Telerik.WinControls.UI.RadGridView();
            this.btnCloneAccess = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddCloneAccess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddExistingAccess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.raddgvControlSetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.raddgvControlSetting.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloneAccess)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.btnCloneAccess);
            this.radGroupBox2.Controls.Add(this.ddCloneAccess);
            this.radGroupBox2.Controls.Add(this.radLabel17);
            this.radGroupBox2.Controls.Add(this.ddExistingAccess);
            this.radGroupBox2.Controls.Add(this.radLabel16);
            this.radGroupBox2.HeaderText = "User Access";
            this.radGroupBox2.Location = new System.Drawing.Point(6, 12);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(1173, 60);
            this.radGroupBox2.TabIndex = 4;
            this.radGroupBox2.Text = "User Access";
            // 
            // ddCloneAccess
            // 
            this.ddCloneAccess.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddCloneAccess.Location = new System.Drawing.Point(546, 25);
            this.ddCloneAccess.Name = "ddCloneAccess";
            this.ddCloneAccess.Size = new System.Drawing.Size(352, 20);
            this.ddCloneAccess.TabIndex = 3;
            this.ddCloneAccess.Text = "Select User";
            // 
            // radLabel17
            // 
            this.radLabel17.Location = new System.Drawing.Point(473, 25);
            this.radLabel17.Name = "radLabel17";
            this.radLabel17.Size = new System.Drawing.Size(71, 18);
            this.radLabel17.TabIndex = 2;
            this.radLabel17.Text = "Clone Access";
            // 
            // ddExistingAccess
            // 
            this.ddExistingAccess.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddExistingAccess.Location = new System.Drawing.Point(102, 27);
            this.ddExistingAccess.Name = "ddExistingAccess";
            this.ddExistingAccess.Size = new System.Drawing.Size(349, 20);
            this.ddExistingAccess.TabIndex = 1;
            this.ddExistingAccess.Text = "Select User";
            this.ddExistingAccess.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddExistingAccess_SelectedIndexChanged);
            // 
            // radLabel16
            // 
            this.radLabel16.Location = new System.Drawing.Point(15, 27);
            this.radLabel16.Name = "radLabel16";
            this.radLabel16.Size = new System.Drawing.Size(81, 18);
            this.radLabel16.TabIndex = 0;
            this.radLabel16.Text = "Existing Access";
            // 
            // raddgvControlSetting
            // 
            this.raddgvControlSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.raddgvControlSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.raddgvControlSetting.Cursor = System.Windows.Forms.Cursors.Default;
            this.raddgvControlSetting.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.raddgvControlSetting.ForeColor = System.Drawing.Color.Black;
            this.raddgvControlSetting.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.raddgvControlSetting.Location = new System.Drawing.Point(6, 78);
            // 
            // 
            // 
            this.raddgvControlSetting.MasterTemplate.AllowAddNewRow = false;
            this.raddgvControlSetting.MasterTemplate.AllowColumnReorder = false;
            this.raddgvControlSetting.MasterTemplate.AllowSearchRow = true;
            this.raddgvControlSetting.MasterTemplate.AutoExpandGroups = true;
            this.raddgvControlSetting.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "ControlAssignID";
            gridViewTextBoxColumn1.HeaderText = "ControlAssignID";
            gridViewTextBoxColumn1.Name = "ControlAssignID";
            gridViewTextBoxColumn1.Width = 248;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "ControlType";
            gridViewTextBoxColumn2.HeaderText = "ControlType";
            gridViewTextBoxColumn2.Name = "ControlType";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 333;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "ControlName";
            gridViewTextBoxColumn3.HeaderText = "ControlName";
            gridViewTextBoxColumn3.Name = "ControlName";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 253;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "DisplayName";
            gridViewTextBoxColumn4.HeaderText = "DisplayName";
            gridViewTextBoxColumn4.Name = "DisplayName";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 358;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "ControlParent";
            gridViewTextBoxColumn5.HeaderText = "ControlParent";
            gridViewTextBoxColumn5.Name = "ControlParent";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 208;
            gridViewCheckBoxColumn1.EditMode = Telerik.WinControls.UI.EditMode.OnValueChange;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.FieldName = "Status";
            gridViewCheckBoxColumn1.HeaderText = "Status";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "Status";
            gridViewCheckBoxColumn1.Width = 87;
            this.raddgvControlSetting.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewCheckBoxColumn1});
            this.raddgvControlSetting.MasterTemplate.EnableFiltering = true;
            sortDescriptor1.Direction = System.ComponentModel.ListSortDirection.Descending;
            sortDescriptor1.PropertyName = "ControlType";
            groupDescriptor1.GroupNames.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.raddgvControlSetting.MasterTemplate.GroupDescriptors.AddRange(new Telerik.WinControls.Data.GroupDescriptor[] {
            groupDescriptor1});
            this.raddgvControlSetting.MasterTemplate.ShowFilteringRow = false;
            this.raddgvControlSetting.MasterTemplate.ShowHeaderCellButtons = true;
            this.raddgvControlSetting.MasterTemplate.ShowRowHeaderColumn = false;
            this.raddgvControlSetting.MasterTemplate.ShowTotals = true;
            this.raddgvControlSetting.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.raddgvControlSetting.Name = "raddgvControlSetting";
            this.raddgvControlSetting.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.raddgvControlSetting.ShowHeaderCellButtons = true;
            this.raddgvControlSetting.Size = new System.Drawing.Size(1173, 687);
            this.raddgvControlSetting.TabIndex = 3;
            this.raddgvControlSetting.Text = "radGridView1";
            // 
            // btnCloneAccess
            // 
            this.btnCloneAccess.Location = new System.Drawing.Point(923, 21);
            this.btnCloneAccess.Name = "btnCloneAccess";
            this.btnCloneAccess.Size = new System.Drawing.Size(124, 26);
            this.btnCloneAccess.TabIndex = 18;
            this.btnCloneAccess.Text = "Clone Access";
            this.btnCloneAccess.ThemeName = "TelerikMetro";
            this.btnCloneAccess.Click += new System.EventHandler(this.btnCloneAccess_Click);
            // 
            // frmUserAccessClone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 776);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.raddgvControlSetting);
            this.Name = "frmUserAccessClone";
            this.Text = "frmUserAccessClone";
            this.Load += new System.EventHandler(this.frmUserAccessClone_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddCloneAccess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddExistingAccess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.raddgvControlSetting.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.raddgvControlSetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloneAccess)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadDropDownList ddCloneAccess;
        private Telerik.WinControls.UI.RadLabel radLabel17;
        private Telerik.WinControls.UI.RadDropDownList ddExistingAccess;
        private Telerik.WinControls.UI.RadLabel radLabel16;
        private Telerik.WinControls.UI.RadGridView raddgvControlSetting;
        private Telerik.WinControls.UI.RadButton btnCloneAccess;
    }
}