using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsRole;
using PeshawarDHASW.Data_Layer.clsRolePermission;
using PeshawarDHASW.Helper;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.Role_Form
{
    public partial class PermissionAssigningtoRole : Telerik.WinControls.UI.RadForm
    {
        public PermissionAssigningtoRole()
        {
            InitializeComponent();
        }

        private void PermissionAssigningtoRole_Load(object sender, EventArgs e)
        {
            try
            {
                GridViewComboBoxColumn comboColumn = new GridViewComboBoxColumn("Status");

                //set the column data source - the possible column values
                comboColumn.DataSource = new String[] { "Active", "Disable" };
                //set the FieldName - the column will retrieve the value from "Phone" column in the data table
                comboColumn.FieldName = "status";
                comboColumn.Name = "status";
                //add the column to the grid
                gvPermissionAssigning.Columns.Add(comboColumn);
                SetUpGrid();
                OnLoad();
                OnLoadSearch();
                OnLoadSearchNotPresent();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on PermissionAssigningtoRole_Load.", ex, "PermissionAssigningtoRole");
                frmobj.ShowDialog();
            }
           
        }

        protected void OnLoad()
        {
            try
            {
                cmbRoleName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmbRoleName.DataSource =
                    clsRoleMgt.Role_Reader(new SqlParameter[] { new SqlParameter("@Task", "RoleNotCreateYet"), }).DefaultView;
                foreach (GridViewDataColumn column in
                    this.cmbRoleName.MultiColumnComboBoxElement.Columns)
                {
                    if (column.Name == "RoleID")
                    {
                        column.IsVisible = false;
                    }
                    column.BestFit();
                }
            }
            catch (Exception ex) 
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on OnLoad.", ex, "PermissionAssigningtoRole");
                frmobj.ShowDialog();
            }
           
        }

        void SetUpGrid()
        {
            try
            {
                RadGridView gridViewControl = this.cmbRoleName.EditorControl;
                gridViewControl.MasterTemplate.AutoGenerateColumns = false;
                gridViewControl.Columns.Add(new GridViewTextBoxColumn("RoleID"));
                gridViewControl.Columns.Add(new GridViewTextBoxColumn("RoleName"));
                gridViewControl.Columns.Add(new GridViewTextBoxColumn("Description"));
                gridViewControl.Columns.Add(new GridViewTextBoxColumn("Status"));

                RadGridView gridViewControlsearch = this.radMCCRole.EditorControl;
                gridViewControlsearch.MasterTemplate.AutoGenerateColumns = false;
                gridViewControlsearch.Columns.Add(new GridViewTextBoxColumn("RoleID"));
                gridViewControlsearch.Columns.Add(new GridViewTextBoxColumn("RoleName"));
                gridViewControlsearch.Columns.Add(new GridViewTextBoxColumn("Description"));
                gridViewControlsearch.Columns.Add(new GridViewTextBoxColumn("Status"));

                RadGridView gridViewControlNotPresent = this.cbrolenamenotpresent.EditorControl;
                gridViewControlsearch.MasterTemplate.AutoGenerateColumns = false;
                gridViewControlsearch.Columns.Add(new GridViewTextBoxColumn("RoleID"));
                gridViewControlsearch.Columns.Add(new GridViewTextBoxColumn("RoleName"));
                gridViewControlsearch.Columns.Add(new GridViewTextBoxColumn("Description"));
                gridViewControlsearch.Columns.Add(new GridViewTextBoxColumn("Status"));
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on SetUpGrid.", ex, "PermissionAssigningtoRole");
                frmobj.ShowDialog();
            }
            
        }


        protected void OnLoadSearch()
        {

            try
            {
                radMCCRole.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.radMCCRole.DataSource =
                    clsRoleMgt.Role_Reader(new SqlParameter[] { new SqlParameter("@Task", "Select"), }).DefaultView;
                foreach (GridViewDataColumn column in
                    this.radMCCRole.MultiColumnComboBoxElement.Columns)
                {
                    if (column.Name == "RoleID")
                    {
                        column.IsVisible = false;
                    }
                    column.BestFit();
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on OnLoadSearch.", ex, "PermissionAssigningtoRole");
                frmobj.ShowDialog();
            }
        }

        protected void OnLoadSearchNotPresent()
        {
            try
            {
                cbrolenamenotpresent.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cbrolenamenotpresent.DataSource =
                    clsRoleMgt.Role_Reader(new SqlParameter[] { new SqlParameter("@Task", "Select"), }).DefaultView;
                foreach (GridViewDataColumn column in
                    this.cbrolenamenotpresent.MultiColumnComboBoxElement.Columns)
                {
                    if (column.Name == "RoleID")
                    {
                        column.IsVisible = false;
                    }
                    column.BestFit();
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on OnLoadSearchNotPresent.", ex, "PermissionAssigningtoRole");
                frmobj.ShowDialog();
            }
           
        }

        private void btnPermissionAssgining_Click(object sender, EventArgs e)
        {
            try
            {
                int Rowindex = cmbRoleName.SelectedIndex;
                RadMultiColumnComboBoxElement a = cmbRoleName.MultiColumnComboBoxElement;
                string RoleID = a.Rows[Rowindex].Cells[0].Value.ToString();
                // MessageBox.Show(aa);
                SqlParameter[] parameter =
                {
                new SqlParameter("@Task","PermissionAssigning"),
                new SqlParameter("@RoleID",RoleID),
                };
                int result = cls_dl_RolePermission.RolePermission_NonQuery(parameter);
                if (result > 0)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnPermissionAssgining_Click.", ex, "PermissionAssigningtoRole");
                frmobj.ShowDialog();
            }
          
        }

        private void radMultiColumnComboBox1_Leave(object sender, EventArgs e)
        {
           
        }

        private void radMCCRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int Rowindex = radMCCRole.SelectedIndex;
                RadMultiColumnComboBoxElement a = radMCCRole.MultiColumnComboBoxElement;
                string RoleID = a.Rows[Rowindex].Cells[0].Value.ToString();
                // MessageBox.Show(aa);
                SqlParameter[] parameter =
                {
                new SqlParameter("@Task","PermissionUpdateLoad"),
                new SqlParameter("@RoleID",RoleID),
            };
                gvPermissionAssigning.DataSource = cls_dl_RolePermission.RolePermission_Reader(parameter).DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on radMCCRole_SelectedIndexChanged.", ex, "PermissionAssigningtoRole");
                frmobj.ShowDialog();
            }
            
        }

 

        private void gvPermissionAssigning_CurrentCellChanged(object sender, CurrentCellChangedEventArgs e)
        {

        }

        private void gvPermissionAssigning_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            try
            {
              
                string ID = gvPermissionAssigning.CurrentRow.Cells[0].Value.ToString();
                string RoleID = gvPermissionAssigning.CurrentRow.Cells[1].Value.ToString();
                string FormID = gvPermissionAssigning.CurrentRow.Cells[2].Value.ToString();
                string Description = gvPermissionAssigning.CurrentRow.Cells[5].Value.ToString();
                string Status = gvPermissionAssigning.CurrentRow.Cells[6].Value.ToString();
                SqlParameter[] parameter =
                {
                    new SqlParameter("@Task", "Update"),
                    new SqlParameter("@ID", ID),
                    new SqlParameter("@RoleID", RoleID),
                    new SqlParameter("@FormID", FormID),
                    new SqlParameter("@Description", Description),
                    new SqlParameter("@status", Status),
                };
                int result =0;
                 result = cls_dl_RolePermission.RolePermission_NonQuery(parameter);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on gvPermissionAssigning_CellEndEdit.", ex, "PermissionAssigningtoRole");
                frmobj.ShowDialog();
            }


        }

        public string RoleIDPass { get; set; } = "0";
        private void cbrolenamenotpresent_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int Rowindex = cbrolenamenotpresent.SelectedIndex;
                RadMultiColumnComboBoxElement a = cbrolenamenotpresent.MultiColumnComboBoxElement;
                string RoleID = a.Rows[Rowindex].Cells[0].Value.ToString();
                RoleIDPass = RoleID;
                // MessageBox.Show(aa);
                SqlParameter[] parameter =
                {
                new SqlParameter("@Task","ControlNotContain"),
                new SqlParameter("@RoleID",RoleID),
            };
                radgvRolePermissionnotPResent.DataSource = cls_dl_RolePermission.RolePermission_Reader(parameter).DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on cbrolenamenotpresent_SelectedIndexChanged.", ex, "PermissionAssigningtoRole");
                frmobj.ShowDialog();
            }
           
        }

        private void btnControlsAdd_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] parameters =
                           {
                new SqlParameter("@Task","AddControlNotPresent"),
                new SqlParameter("@RoleID",RoleIDPass),
            };
                int result = cls_dl_RolePermission.RolePermission_NonQuery(parameters);
                if (result > 0)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Some Error.");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnControlsAdd_Click.", ex, "PermissionAssigningtoRole");
                frmobj.ShowDialog();
            }
           
        }

        private void cmbRoleName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radLabel1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
