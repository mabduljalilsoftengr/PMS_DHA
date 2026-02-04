namespace PeshawarDHASW.Application_Layer.Membership.Modify
{
    partial class frmModifyFamilyMember
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
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.FamilyMemberDGV = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.txtrelation = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.txtNIC = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txtDoB = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtname = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.btnUpdateFamilyData = new Telerik.WinControls.UI.RadButton();
            this.btnClear = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.FamilyMemberDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FamilyMemberDGV.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtrelation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNIC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDoB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateFamilyData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // FamilyMemberDGV
            // 
            this.FamilyMemberDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FamilyMemberDGV.AutoSizeRows = true;
            this.FamilyMemberDGV.BackColor = System.Drawing.Color.White;
            this.FamilyMemberDGV.Cursor = System.Windows.Forms.Cursors.Default;
            this.FamilyMemberDGV.EnableAnalytics = false;
            this.FamilyMemberDGV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FamilyMemberDGV.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FamilyMemberDGV.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.FamilyMemberDGV.Location = new System.Drawing.Point(8, 8);
            // 
            // 
            // 
            this.FamilyMemberDGV.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.FamilyMemberDGV.MasterTemplate.AllowAddNewRow = false;
            this.FamilyMemberDGV.MasterTemplate.AllowColumnReorder = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "ID";
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "ID";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "Name";
            gridViewTextBoxColumn2.HeaderText = "Name";
            gridViewTextBoxColumn2.Name = "Name";
            gridViewTextBoxColumn2.Width = 150;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "DOB";
            gridViewTextBoxColumn3.HeaderText = "Date of Birth";
            gridViewTextBoxColumn3.Name = "DOB";
            gridViewTextBoxColumn3.Width = 150;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "NICNO";
            gridViewTextBoxColumn4.HeaderText = "NIC No";
            gridViewTextBoxColumn4.Name = "NICNO";
            gridViewTextBoxColumn4.Width = 150;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "Relation";
            gridViewTextBoxColumn5.HeaderText = "Relation";
            gridViewTextBoxColumn5.Name = "Relation";
            gridViewTextBoxColumn5.Width = 150;
            this.FamilyMemberDGV.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.FamilyMemberDGV.MasterTemplate.EnableGrouping = false;
            sortDescriptor1.PropertyName = "txtName";
            this.FamilyMemberDGV.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.FamilyMemberDGV.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.FamilyMemberDGV.Name = "FamilyMemberDGV";
            this.FamilyMemberDGV.ReadOnly = true;
            this.FamilyMemberDGV.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FamilyMemberDGV.Size = new System.Drawing.Size(625, 271);
            this.FamilyMemberDGV.TabIndex = 2;
            this.FamilyMemberDGV.Text = "radGridView1";
            this.FamilyMemberDGV.ThemeName = "TelerikMetro";
            this.FamilyMemberDGV.SelectionChanged += new System.EventHandler(this.FamilyMemberDGV_SelectionChanged);
            this.FamilyMemberDGV.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.FamilyMemberDGV_CellClick);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.txtrelation);
            this.radGroupBox1.Controls.Add(this.radLabel4);
            this.radGroupBox1.Controls.Add(this.txtNIC);
            this.radGroupBox1.Controls.Add(this.radLabel3);
            this.radGroupBox1.Controls.Add(this.txtDoB);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.txtname);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.HeaderText = "Family Member Info";
            this.radGroupBox1.Location = new System.Drawing.Point(640, 12);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(330, 168);
            this.radGroupBox1.TabIndex = 3;
            this.radGroupBox1.Text = "Family Member Info";
            this.radGroupBox1.ThemeName = "TelerikMetro";
            // 
            // txtrelation
            // 
            this.txtrelation.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrelation.Location = new System.Drawing.Point(113, 132);
            this.txtrelation.Name = "txtrelation";
            this.txtrelation.Size = new System.Drawing.Size(200, 27);
            this.txtrelation.TabIndex = 3;
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(15, 132);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(67, 25);
            this.radLabel4.TabIndex = 2;
            this.radLabel4.Text = "Relation";
            // 
            // txtNIC
            // 
            this.txtNIC.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNIC.Location = new System.Drawing.Point(113, 99);
            this.txtNIC.Name = "txtNIC";
            this.txtNIC.Size = new System.Drawing.Size(200, 27);
            this.txtNIC.TabIndex = 3;
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(15, 99);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(61, 25);
            this.radLabel3.TabIndex = 2;
            this.radLabel3.Text = "NIC No";
            // 
            // txtDoB
            // 
            this.txtDoB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoB.Location = new System.Drawing.Point(113, 66);
            this.txtDoB.Name = "txtDoB";
            this.txtDoB.Size = new System.Drawing.Size(200, 27);
            this.txtDoB.TabIndex = 3;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(15, 66);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(100, 25);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "Date of Birth";
            // 
            // txtname
            // 
            this.txtname.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtname.Location = new System.Drawing.Point(113, 33);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(200, 27);
            this.txtname.TabIndex = 1;
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(15, 33);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(51, 25);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Name";
            // 
            // btnUpdateFamilyData
            // 
            this.btnUpdateFamilyData.Location = new System.Drawing.Point(640, 187);
            this.btnUpdateFamilyData.Name = "btnUpdateFamilyData";
            this.btnUpdateFamilyData.Size = new System.Drawing.Size(330, 43);
            this.btnUpdateFamilyData.TabIndex = 4;
            this.btnUpdateFamilyData.Text = "Save Changes";
            this.btnUpdateFamilyData.ThemeName = "TelerikMetro";
            this.btnUpdateFamilyData.Click += new System.EventHandler(this.btnUpdateFamilyData_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(640, 236);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(330, 43);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.ThemeName = "TelerikMetro";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmModifyFamilyMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 303);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpdateFamilyData);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.FamilyMemberDGV);
            this.Name = "frmModifyFamilyMember";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modify Family Member";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.frmModifyFamilyMember_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FamilyMemberDGV.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FamilyMemberDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtrelation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNIC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDoB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateFamilyData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadGridView FamilyMemberDGV;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton btnUpdateFamilyData;
        private Telerik.WinControls.UI.RadTextBox txtrelation;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadTextBox txtNIC;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox txtDoB;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox txtname;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton btnClear;
    }
}
