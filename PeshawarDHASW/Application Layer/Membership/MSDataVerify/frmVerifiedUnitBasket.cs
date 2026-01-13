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
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Application_Layer.Membership.MSDataVerify
{
    public partial class frmVerifiedUnitBasket : Telerik.WinControls.UI.RadForm
    {
        public frmVerifiedUnitBasket()
        {
            InitializeComponent();
        }

        private void frmVerifiedUnitBasket_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            verifyready.MasterTemplate.Columns.Add(clsPluginHelper.GdButton("MemberID", "MemberID", "View", "Click"));
            AllEntry();
            dataloadingReadyofrVerification();
            FullVerified();
        }
        private void AllEntry()
        {
            try
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@Task", "DatabasketAllEntry"),
                };
                DataSet ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameters);
                radAllentry.DataSource = ds.Tables[0].DefaultView;
                int raddatabasketnotverify = radAllentry.RowCount;
                lblallcount.Text = raddatabasketnotverify.ToString();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on AllEntry.", ex, "frmVerifiedUnitBasket");
                frmobj.ShowDialog();
            }
           
        }
        private void dataloadingReadyofrVerification()
        {
            try
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@Task", "ReadyforVerification"),
                };
                DataSet ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameters);
                verifyready.DataSource = ds.Tables[0].DefaultView;
                int raddgalldatacount = verifyready.RowCount;
                lblverify.Text = raddgalldatacount.ToString();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on dataloadingReadyofrVerification.", ex, "frmVerifiedUnitBasket");
                frmobj.ShowDialog();
            }
            
        }
        private void FullVerified()
        {
            try
            {
               SqlParameter[] parameters =
               {
                new SqlParameter("@Task", "FullVerified"),
               };
                DataSet ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameters);
                verified.DataSource = ds.Tables[0].DefaultView;
                int raddatabasketnotverify = verified.RowCount;
                lbltotalverify.Text = raddatabasketnotverify.ToString();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on FullVerified.", ex, "frmVerifiedUnitBasket");
                frmobj.ShowDialog();
            }
          
        }
        private void radButton1_Click(object sender, EventArgs e)
        {
            AllEntry();
            dataloadingReadyofrVerification();
            FullVerified();
        }

        private void verifyready_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
               
                if (e.Column.Name == "MemberID")
                {
                    int ID = 0;
                    bool convert = int.TryParse(verifyready.CurrentRow.Cells[0].Value.ToString(), out ID);
                    if (convert)
                    {
                        frmDataVerify obj = new frmDataVerify(ID);
                        obj.ShowDialog();
                        AllEntry();
                        dataloadingReadyofrVerification();
                        FullVerified();
                    }

                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on verifyready_CellClick.", ex, "frmVerifiedUnitBasket");
                frmobj.ShowDialog();
            }
        }

        private void verifyready_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            verifyready_CellClick(null, null);
        }

        private void verifyready_Click(object sender, EventArgs e)
        {

        }



        /*
         * 
         * */
    }
}
