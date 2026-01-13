using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Application_Layer.NDC.Baskets;
using PeshawarDHASW.Data_Layer.clsMemberShip;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Membership
{
    public partial class frmPHP : Form
    {
        public frmPHP()
        {
            InitializeComponent();

            //this.tabPage1 = Text = '';
        }

        string branch = UserHelper.GetUserBranch();
        private void frmPHP_Load(object sender, EventArgs e)
        {
            //LoadPHPDataOnGrid();
        }

        private void LoadPHPDataOnGrid()
        {
            try
            {

                SqlParameter[] param =
                    {
                        new SqlParameter("@Task", "SelectPHPDataToGrid"),
                    };

                DataSet ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(param);
                
                dgvPHP.DataSource = ds.Tables[0].DefaultView;
                dgvPHP.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            LoadSecretForm(sender);
            //try
            //{
            //    SqlParameter[] parameters = new[]
            //    {
            //        new SqlParameter("@Task", "SelectForAddRemoveList"),
            //        new SqlParameter("@FilePlotShopVillaApartmentNo", DbNullIfNullOrEmpty(txtfileno.Text)),
            //        new SqlParameter("@MembershipNo", DbNullIfNullOrEmpty(txtmsno.Text)),
            //    };
            //    DataSet ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameters);
            //    dgvAddRemove.DataSource = ds.Tables[0].DefaultView;

            //    dgvAddRemove.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

            //}
            //catch (Exception ex)
            //{
            //    frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on searchmembership.", ex, "frmMembershipModify");
            //    frmobj.ShowDialog();

            //}


        }
        
        private void SelectLoadData()
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@Task", "SelectForAddRemoveList"),
                    new SqlParameter("@FilePlotShopVillaApartmentNo", DbNullIfNullOrEmpty(txtfileno.Text)),
                    new SqlParameter("@MembershipNo", DbNullIfNullOrEmpty(txtmsno.Text)),
                };
                DataSet ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameters);
                dgvAddRemove.DataSource = ds.Tables[0].DefaultView;

                dgvAddRemove.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

                bool rslt = clsPluginHelper.ApplicationLogSaving(txtfileno.Text, Models.clsUser.ID + "-" + clsUser.Name + "-" + branch, "Before - Modification PHP Record ", ds, "frmPHP - btnSelect", "DataSetTable");

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on searchmembership.", ex, "frmMembershipModify");
                frmobj.ShowDialog();

            }
        }

        private void btnAddToPHP_Click(object sender, EventArgs e)
        {
            try
            {
                string fileNo = txtfileno.Text;
                if (string.IsNullOrWhiteSpace(txtRemark.Text))
                {
                    MessageBox.Show("Please enter a remark before adding to PHP list.",
                                    "Missing Remark", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@Task", "AddToPHPList"),
                    new SqlParameter("@MembershipNo", DbNullIfNullOrEmpty(txtmsno.Text)),
                    new SqlParameter("@ReminderRemarks", txtRemark.Text)
                };

                //cls_dl_Membership.Membership_PersonalInfo_Retrive(parameters); ///Membership_PersonalInfo


                //cls_dl_Membership.Membership_PersonalInfo(parameters); ///Membership_PersonalInfo

                //MessageBox.Show("Member added to PHP list successfully.",
                //                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                int rowsAffected = cls_dl_Membership.Membership_PersonalInfo(parameters);

                if (rowsAffected == 0)
                {
                    MessageBox.Show("This record is already in the PHP list.",
                                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                MessageBox.Show("Member added to PHP list successfully.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                bool rslt = clsPluginHelper.ApplicationLogSaving(fileNo, Models.clsUser.ID + "-" + clsUser.Name + "-" + branch, "After - Modification Added to PHP ", parameters, "frmPHP - btnAddToPHP_Click", "SQLParam");

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Error adding member to PHP list.", ex, "frmMembershipModify");
                frmobj.ShowDialog();
            }
        }

        private void btnRemovePHP_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtRemark.Text))
                {
                    MessageBox.Show("Please enter a remark before removing from PHP list.",
                                    "Missing Remark", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@Task", "RemoveFromPHPList"),
                    new SqlParameter("@MembershipNo", DbNullIfNullOrEmpty(txtmsno.Text)),
                    new SqlParameter("@ReminderRemarks", txtRemark.Text)
                };

                //cls_dl_Membership.Membership_PersonalInfo_Retrive(parameters);

                //MessageBox.Show("Member removed from PHP list successfully.",
                //                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                int rowsAffected = cls_dl_Membership.Membership_PersonalInfo(parameters);

                if (rowsAffected == 0)
                {
                    MessageBox.Show("This record is already removed from the PHP list.",
                                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                MessageBox.Show("Member removed from PHP list successfully.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
                bool rslt = clsPluginHelper.ApplicationLogSaving(txtfileno.Text, clsUser.Name + "-" + Models.clsUser.ID, "After - Modification Removed From PHP ", parameters, "frmPHP - btnAddToPHP_Click", "SQLParam");

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Error removing member from PHP list.", ex, "frmMembershipModify");
                frmobj.ShowDialog();
            }
        }

        public static object DbNullIfNullOrEmpty(string str)
        {
            return !String.IsNullOrEmpty(str) ? str : (object)DBNull.Value;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (tabControl1.SelectedTab == tabPage1)
            //{
            //    dgvPHP.Enabled = false;
            //    //LoadSecretForm(sender);  // Load or refresh tab 1 data
            //    LoadSecretForm(null);
            //}
            dgvPHP.Enabled = false;
        }


        private void LoadSecretForm(object sender) // Accept the sender object
        {

            try
            {
                frm_Secret_Code frm = new frm_Secret_Code();
                frm.ShowDialog();

                if (clsMostUseVars.Drctr_Secret_Code == true)
                {
                    // Check if the sender is btnLoadData OR if the selected tab is tabPage1
                    //if (sender == btnLoadData || tabControl1.SelectedTab == tabPage1)
                    if (sender == btnLoadData)
                    {
                        LoadPHPDataOnGrid();
                        dgvPHP.Enabled = true;
                    }
                    // Check if the sender is btnSelect
                    else if (sender == btnSelect)
                    {
                        SelectLoadData();

                        dgvPHP.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnRemoveCaution_Click.", ex, "Caution_Remove");
                frmobj.ShowDialog();
            }
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            LoadSecretForm(sender);
        }

        //private void LoadSecretForm()
        // {
        //     try
        //     {
        //         frm_Secret_Code frm = new frm_Secret_Code();
        //         frm.ShowDialog();
        //         if (clsMostUseVars.Drctr_Secret_Code == true)
        //         {
        //             //ADDED BY SAHIB BECAUSE AFTER UNLOCK GRID DATA HIDE
        //             LoadPHPDataOnGrid();
        //             ////////////
        //             dgvPHP.Enabled = true;
        //             // btnOK.Enabled = true;
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnRemoveCaution_Click.", ex, "Caution_Remove");
        //         frmobj.ShowDialog();
        //     }
        // }
    }
}
