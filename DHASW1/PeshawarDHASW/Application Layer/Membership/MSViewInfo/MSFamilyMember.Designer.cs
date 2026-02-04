namespace PeshawarDHASW.Application_Layer.Membership.MSViewInfo
{
    partial class MSFamilyMember
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
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.FamilyMemberDGV = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.FamilyMemberDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FamilyMemberDGV.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // FamilyMemberDGV
            // 
            this.FamilyMemberDGV.AutoSizeRows = true;
            this.FamilyMemberDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FamilyMemberDGV.Enabled = false;
            this.FamilyMemberDGV.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.FamilyMemberDGV.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.FamilyMemberDGV.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn1.HeaderText = "Name";
            gridViewTextBoxColumn1.Name = "Name";
            gridViewTextBoxColumn1.Width = 150;
            gridViewTextBoxColumn2.FieldName = "DOB";
            gridViewTextBoxColumn2.HeaderText = "Date Of Birth";
            gridViewTextBoxColumn2.Name = "DOB";
            gridViewTextBoxColumn2.Width = 150;
            gridViewTextBoxColumn3.HeaderText = "NIC No";
            gridViewTextBoxColumn3.Name = "NICNO";
            gridViewTextBoxColumn3.Width = 150;
            gridViewTextBoxColumn4.HeaderText = "Relation";
            gridViewTextBoxColumn4.Name = "Relation";
            gridViewTextBoxColumn4.Width = 150;
            this.FamilyMemberDGV.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            sortDescriptor1.PropertyName = "txtName";
            this.FamilyMemberDGV.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.FamilyMemberDGV.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.FamilyMemberDGV.Name = "FamilyMemberDGV";
            this.FamilyMemberDGV.Size = new System.Drawing.Size(760, 270);
            this.FamilyMemberDGV.TabIndex = 1;
            this.FamilyMemberDGV.Text = "radGridView1";
            this.FamilyMemberDGV.ThemeName = "TelerikMetro";
            // 
            // MSFamilyMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 270);
            this.Controls.Add(this.FamilyMemberDGV);
            this.Name = "MSFamilyMember";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "MSFamilyMember";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.MSFamilyMember_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FamilyMemberDGV.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FamilyMemberDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView FamilyMemberDGV;
    }
}
