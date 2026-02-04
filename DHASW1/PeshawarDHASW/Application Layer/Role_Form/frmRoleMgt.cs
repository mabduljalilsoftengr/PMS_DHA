using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsRole;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.Role_Form
{
    public partial class frmRoleMgt : Telerik.WinControls.UI.RadForm
    {
        public frmRoleMgt()
        {
            InitializeComponent();
        }

        private void clearfunction()
        {
            txtRoleName.Text = "";
            txtDescription.Text = "";
            dpRoleStatus.SelectedIndex = 0;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@Task","Insert"),
                new SqlParameter("@RoleName",txtRoleName.Text),
                new SqlParameter("@Description",txtDescription.Text),
                new SqlParameter("@status",dpRoleStatus.SelectedItem.ToString()),
                };
                int result = clsRoleMgt.Role_NonQuery(parameters);
                if (result > 0)
                {
                    clearfunction();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnSave_Click.", ex, "frmRoleMgt");
                frmobj.ShowDialog();
            }
           
        }

        private void frmRoleMgt_Load(object sender, EventArgs e)
        {
            radgvSearchRole.DataSource = clsRoleMgt.Role_Reader(new SqlParameter[] {new SqlParameter("@Task", "Select"), }).DefaultView;
            radgvModifyRole.DataSource = clsRoleMgt.Role_Reader(new SqlParameter[] { new SqlParameter("@Task", "Select"), }).DefaultView;
        }

        private void radgvModifyRole_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = radgvModifyRole.CurrentCell.RowIndex;
                int columnindex = radgvModifyRole.CurrentCell.ColumnIndex;

                if (e.Column.Name == "BtnEdit")
                {
                    string ID = radgvModifyRole.Rows[rowindex].Cells[0].Value.ToString();
                    string RoleName = radgvModifyRole.Rows[rowindex].Cells[1].Value.ToString();
                    string Description = radgvModifyRole.Rows[rowindex].Cells[2].Value.ToString();
                    string Status = radgvModifyRole.Rows[rowindex].Cells[3].Value.ToString();
                    SqlParameter[] parameters =
                    {
                    new SqlParameter("@Task","Update"),
                    new SqlParameter("@RoleID",ID),
                    new SqlParameter("@RoleName",RoleName),
                    new SqlParameter("@Description",Description),
                    new SqlParameter("@status",Status),
                };
                    int result = clsRoleMgt.Role_NonQuery(parameters);
                    if (result > 0)
                    {
                        MessageBox.Show("Changes Applied");
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on radgvModifyRole_CellClick.", ex, "frmRoleMgt");
                frmobj.ShowDialog();
            }
           
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearfunction();
        }
    }
}
