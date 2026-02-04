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
using Telerik.WinControls.UI;
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Application_Layer.Membership.Modify;

namespace PeshawarDHASW.Application_Layer.Membership
{
    public partial class frmMembershipModify : Telerik.WinControls.UI.RadForm
    {

        #region Membership No. is edited while modifying the data ,duplication of data in database #ABR
        #endregion
        #region   check the Validation and email format  while modifying the data  #ABR

        #endregion
        #region   Family details , if we add a new data the grid should refresh   #ABR

        #endregion
        #region   date of birth constraint should not exceed current date  in Family details    #ABR

        #endregion
        #region   Bug : if gridview is empty in family detail the form closes     #ABR

        #endregion
        #region   Membership No should not be NUll while editing   the data   #ABR

        #endregion
        #region  Design issue : forms are hidden in the background    #ABR

        #endregion
        public frmMembershipModify()
        {
            InitializeComponent();
        }
        public static object DbNullIfNullOrEmpty(string str)
        {
            return !String.IsNullOrEmpty(str) ? str : (object)DBNull.Value;
        }

        private void searchmembership()
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                new SqlParameter("@Task", "Select"),
                new SqlParameter("@FilePlotShopVillaApartmentNo", DbNullIfNullOrEmpty(txtfileno.Text)),
                new SqlParameter("@MembershipNo", DbNullIfNullOrEmpty(txtmsno.Text)),
                new SqlParameter("@NICNICOP", DbNullIfNullOrEmpty(txtnic.Text)),
                new SqlParameter("@Name", DbNullIfNullOrEmpty(txtname.Text)),
                new SqlParameter("@MobileNo", DbNullIfNullOrEmpty(txtmobile.Text))
                };
                DataSet ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameters);
                SearchDGV.DataSource = ds.Tables[0].DefaultView;

                foreach (GridViewDataColumn column in SearchDGV.Columns)
                {
                    column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on searchmembership.", ex, "frmMembershipModify");
                frmobj.ShowDialog();

            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchDGV.DataSource = null;
            searchmembership();
        }

        private void frmMembershipModify_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            DGVControls();
        }

        private void DGVControls()
        {
            try
            {
                GridViewCommandColumn BioInfo = new GridViewCommandColumn();
                BioInfo.Name = "Bioinfo";
                BioInfo.UseDefaultText = true;
                BioInfo.FieldName = "FileNo";
                BioInfo.DefaultText = "View";
                BioInfo.Width = 80;
                BioInfo.TextAlignment = ContentAlignment.MiddleCenter;
                BioInfo.HeaderText = "Bio Info";
                SearchDGV.MasterTemplate.Columns.Add(BioInfo);

                GridViewCommandColumn NextofKin = new GridViewCommandColumn();
                NextofKin.Name = "nexkofkin";
                NextofKin.UseDefaultText = true;
                NextofKin.FieldName = "FileNo";
                NextofKin.DefaultText = "View";
                NextofKin.Width = 100;
                NextofKin.TextAlignment = ContentAlignment.MiddleCenter;
                NextofKin.HeaderText = "Next of Kin";
                SearchDGV.MasterTemplate.Columns.Add(NextofKin);

                GridViewCommandColumn familydetial = new GridViewCommandColumn();
                familydetial.Name = "familyDetail";
                familydetial.UseDefaultText = true;
                familydetial.FieldName = "FileNo";
                familydetial.DefaultText = "View";
                familydetial.HeaderText = "Family Detail";
                familydetial.Width = 100;
                familydetial.TextAlignment = ContentAlignment.MiddleCenter;
                SearchDGV.MasterTemplate.Columns.Add(familydetial);

                searchmembership();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on DGVControls.", ex, "frmMembershipModify");
                frmobj.ShowDialog();
            }
           
        }

        private void SearchDGV_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                
                if (e.Column.Name == "Bioinfo")
                {
                    int ID = int.Parse(e.Row.Cells["ID"].Value.ToString());
                    Modify.frmModifyBioData obj = new Modify.frmModifyBioData(ID);
                    obj.ShowDialog();
                    btnSearch_Click(null,null);
                    
                }
                if (e.Column.Name == "nexkofkin")
                {
                    int ID = int.Parse(e.Row.Cells["ID"].Value.ToString());
                    Modify.frmModifyNextofkin obj = new Modify.frmModifyNextofkin(ID);
                    obj.ShowDialog();
                    btnSearch_Click(null, null);
                 
                }
                if (e.Column.Name == "familyDetail")
                {
                    int ID = int.Parse(e.Row.Cells["ID"].Value.ToString());
                    Modify.frmModifyFamilyMember obj = new Modify.frmModifyFamilyMember(ID);
                    obj.ShowDialog();
                    btnSearch_Click(null, null);
                    
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on SearchDGV_CellClick.", ex, "frmMembershipModify");
                frmobj.ShowDialog();
            }
        }

        private void btnperiodsearch_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@Task","PeriodSearch"),
                new SqlParameter() { ParameterName = "@StartDateSearch", SqlDbType = SqlDbType.Date, SqlValue = dtpstartDate.Text},
                new SqlParameter(){ ParameterName = "@EndDateSearch", SqlDbType = SqlDbType.Date, SqlValue = dtpendDate.Text},
                };
                DataSet ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameters);

                SearchDGV.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnperiodsearch_Click.", ex, "frmMembershipModify");
                frmobj.ShowDialog();
            }
           
        }

        private void txtfileno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSearch_Click(null, null);
            }
        }

        private void btnphp_Click(object sender, EventArgs e)
        {
            if((clsUser.ID == 4126) || (clsUser.ID == 35) || (clsUser.ID == 3))
            {
                PHP p = new PHP();
                p.ShowDialog();
            }
            else
            {
                MessageBox.Show("Access denied.");
            }
        }
    }
}
