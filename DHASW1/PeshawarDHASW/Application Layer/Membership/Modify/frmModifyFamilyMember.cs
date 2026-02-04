using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsMemberShip;
using PeshawarDHASW.Models;
using Telerik.WinControls;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.Membership.Modify
{
    public partial class frmModifyFamilyMember : Telerik.WinControls.UI.RadForm
    {
        public frmModifyFamilyMember()
        {
            InitializeComponent();
        }
        public int MBSID { get; set; }
        public frmModifyFamilyMember(int ID)
        {
            MBSID = ID;
            InitializeComponent();
        }

        private void frmModifyFamilyMember_Load(object sender, EventArgs e)
        {
            #region Load Family Member Data
            try
            {
                clear();
                SqlParameter[] parameter = new[] { new SqlParameter("@Member_ID", MBSID) };
                DataSet ds = cl_dl_SerachMembership.MembershipFamilyDataLoadforView(parameter);

                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    FamilyMemberDGV.DataSource = dt.DefaultView;

                    // lblRecordstatus.Text = " Found Successfull.";
                    //foreach (DataRow Row in dt.Rows)
                    //{
                    //    string[] row = new string[] { Row["ID"].ToString(), Row["Name"].ToString(), Row["DOB"].ToString(), Row["NICNO"].ToString(), Row["Relation"].ToString() };
                    //    FamilyMemberDGV.Rows.Add(row);
                    //}
                }
                else
                {
                    // lblRecordstatus.Text = " Not Found.";
                }

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmModifyFamilyMember_Load.", ex, "frmModifyFamilyMember");
                frmobj.ShowDialog();

            }
            #endregion
        }

        private void FamilyMemberDGV_SelectionChanged(object sender, EventArgs e)
        {

        }

        private int IDFamilyID = 0;
        private void FamilyMemberDGV_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = FamilyMemberDGV.CurrentCell.RowIndex;
                // int columnindex = FamilyMemberDGV.CurrentCell.ColumnIndex;

                IDFamilyID = int.Parse(FamilyMemberDGV.Rows[rowindex].Cells[0].Value.ToString());
                txtname.Text = FamilyMemberDGV.Rows[rowindex].Cells[1].Value.ToString();
                txtDoB.Text = FamilyMemberDGV.Rows[rowindex].Cells[2].Value.ToString();
                txtNIC.Text = FamilyMemberDGV.Rows[rowindex].Cells[3].Value.ToString();
                txtrelation.Text = FamilyMemberDGV.Rows[rowindex].Cells[4].Value.ToString();
                btnUpdateFamilyData.Text = "Update";
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on FamilyMemberDGV_CellClick.", ex, "frmModifyFamilyMember");
                frmobj.ShowDialog();
            }


        }

        private void clear()
        {
            IDFamilyID = 0;
            txtname.Text = "";
            txtDoB.Text = "";
            txtNIC.Text = "";
            txtrelation.Text = "";
            btnUpdateFamilyData.Text = "Save Changes";
        }


        private void btnUpdateFamilyData_Click(object sender, EventArgs e)
        {
            #region Update Family Members
            try
            {

                if (IDFamilyID == 0)
                {
                    if (
                        MessageBox.Show(
                            "Are you sure save this record.",
                            "Warning",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning)
                            == DialogResult.Yes)
                    {

                        SqlParameter[] parameters = new[]
                               {
                            new SqlParameter("@Task","Insert"),
                            new SqlParameter("@Member_ID", MBSID),
                            new SqlParameter("@Name", txtname.Text),
                            new SqlParameter("@DOB", txtDoB.Text),
                            new SqlParameter("@NICNO", txtNIC.Text),
                            new SqlParameter("@Relation", txtrelation.Text),
                            new SqlParameter("@user_ID", clsUser.ID)
                        };
                        int result = cls_dl_Membership.Membership_FamilyMember_NonQuery(parameters);
                        if (result > 0)
                        {
                            MessageBox.Show("Record insert succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clear();
                            frmModifyFamilyMember_Load(null, null);
                        }
                        else
                        {
                            MessageBox.Show("Contact with Administration.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    if (
                       MessageBox.Show(
                           "Are you sure,You want to Modify this record.",
                           "Warning",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Warning)
                           == DialogResult.Yes)
                    {
                        SqlParameter[] parameters =
                               {
                            new SqlParameter("@Task","Update"),
                            new SqlParameter("@ID",IDFamilyID),
                            new SqlParameter("@Member_ID", MBSID),
                            new SqlParameter("@Name", txtname.Text),
                            new SqlParameter("@DOB", txtDoB.Text),
                            new SqlParameter("@NICNO", txtNIC.Text),
                            new SqlParameter("@Relation", txtrelation.Text),
                            new SqlParameter("@user_ID", Models.clsUser.ID)
                        };
                        int result = cls_dl_Membership.Membership_FamilyMember_NonQuery(parameters);
                        if (result > 0)
                        {
                            MessageBox.Show("Updated Succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clear();
                            frmModifyFamilyMember_Load(null, null);
                        }
                        else
                        {
                            MessageBox.Show("Contact with Administration.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnUpdateFamilyData_Click.", ex, "frmModifyFamilyMember");
                frmobj.ShowDialog();
            }
            #endregion
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
