using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Application_Layer.Membership.MSDataVerify;
using PeshawarDHASW.Data_Layer.clsMemberShip;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Models;
using Telerik.WinControls;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.Basket
{
    public partial class frmBindingBasket : Telerik.WinControls.UI.RadForm
    {
        public frmBindingBasket()
        {
            InitializeComponent();
        }
        private void dataloadingNotverify()
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
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on dataloadingNotverify.", ex, "frmBindingBasket");
                frmobj.ShowDialog();

            }
        }
        private void dataloadingAll()
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task", "DailyEntry"),
                };
                DataSet ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameters);
                raddailyentry.DataSource = ds.Tables[0].DefaultView;
                int raddgalldatacount = raddailyentry.RowCount;
               // lbldialy.Text = raddgalldatacount.ToString();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on dataloadingAll.", ex, "frmBindingBasket");
                frmobj.ShowDialog();
            }
        }

        private void Incomplete()
        {
            
                try
                {
                    string str =
                        @"Select ID,MembershipNo,Name from dbo.tbl_Membership where ID  not in (Select MemberID from dbo.tbl_MemberShipNextofKin)
                    Union
                    Select ID,MembershipNo,Name from dbo.tbl_Membership where ID  in ( Select MemberID from dbo.tbl_MemberShipNextofKin Where MemberID not in (Select Member_ID from dbo.tbl_FamilMember))";
                    DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.Text, str);
                    gdincomplete.DataSource = ds.Tables[0].DefaultView;
                    int raddatabasketnotverify = gdincomplete.RowCount;
                    lblincomplete.Text = raddatabasketnotverify.ToString();
                }
                catch (Exception ex)
                {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Incomplete.", ex, "frmBindingBasket");
                frmobj.ShowDialog();
            }
            
        }

        private void NotBindedOwner()
        {
            try
            {
                string str =
                    @"SELECT tm.ID,tm.MembershipNo FROM dbo.tbl_Membership tm	
                    WHERE ID NOT IN (SELECT[MemberID] FROM [dbo].[tbl_Owner] tow WHERE tow.FileMapID IN (SELECT tfm.FileMapKey FROM dbo.tbl_FileMap tfm ))
                    AND ID NOT in (SELECT [MemberID]  FROM [dbo].[tbl_DPR_Review])
                    AND ID IN(SELECT n.MemberID FROM tbl_MemberShipNextofKin n) 
                    AND ID IN(SELECT f.Member_ID FROM tbl_FamilMember f)
                    AND ID IN (SELECT img.MemberID FROM DvMainDbMembershipImages.dbo.tbl_MemberImages img)";
                DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.Text, str);  //Connectionstring
                gvNotBindOwner.DataSource = ds.Tables[0].DefaultView;
                int raddatabasketnotverify = gvNotBindOwner.RowCount;
                lblnotbindowner.Text = raddatabasketnotverify.ToString();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on NotBindedOwner.", ex, "frmBindingBasket");
                frmobj.ShowDialog();
            }
        }

        private void BindedOwner()
        {
            try
            {
                string str =
                    @"SELECT tm.ID,tm.MembershipNo FROM dbo.tbl_Membership tm	
  WHERE ID  IN (SELECT[MemberID] FROM [dbo].[tbl_Owner] tow WHERE tow.FileMapID IN (SELECT tfm.FileMapKey FROM dbo.tbl_FileMap tfm ))
  AND ID NOT in (SELECT [MemberID]  FROM [dbo].[tbl_DPR_Review])";
                DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.Text, str);  // Connectionstring
                gvBindOwner.DataSource = ds.Tables[0].DefaultView;
                int raddatabasketnotverify = gvBindOwner.RowCount;
                lblbindowner.Text = raddatabasketnotverify.ToString();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on BindedOwner.", ex, "frmBindingBasket");
                frmobj.ShowDialog();
            }
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataloadingNotverify();
            dataloadingAll();
            Incomplete();
            NotBindedOwner();
            BindedOwner();
        }

        private void gvNotBindOwner_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
               
                if (e.Column.Name == "Bind")
                {
                    int ID = 0;
                    bool convert = int.TryParse(gvNotBindOwner.CurrentRow.Cells[0].Value.ToString(), out ID);
                    if (convert)
                    {
                        ThirdVerification objThirdVerification = new ThirdVerification(ID);
                        objThirdVerification.ShowDialog();
                        btnRefresh_Click(null, null);
                    }

                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on gvNotBindOwner_CellClick.", ex, "frmBindingBasket");
                frmobj.ShowDialog();
            }
        }

        private void frmBindingBasket_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            btnRefresh_Click(null, null);
        }
    }
}
