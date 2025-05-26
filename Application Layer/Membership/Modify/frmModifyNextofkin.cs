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
    public partial class frmModifyNextofkin : Telerik.WinControls.UI.RadForm
    {
        public frmModifyNextofkin()
        {
            InitializeComponent();
        }

        public int MBSID { get; set; }

        public frmModifyNextofkin(int ID)
        {
            MBSID = ID;
            InitializeComponent();
        }

        private int nextofkinID = 0;
        private void frmModifyNextofkin_Load(object sender, EventArgs e)
        {
            #region Load Next Of Kin
            try
            {
                this.ThemeName = clsUser.ThemeName;
                ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
                SqlParameter[] parameter = new[] { new SqlParameter("@MID", MBSID) };
                DataSet ds = cl_dl_SerachMembership.MembershipNextofkinDataLoadforView(parameter);

                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        nextofkinID = int.Parse(row["ID"].ToString());
                        txtnokname.Text = row["NameofKin"].ToString();
                        txtnokrelation.Text = row["Relation"].ToString();
                        txtnoknic.Text = row["NIC"].ToString();
                        txtnokpassportno.Text = row["PassportNo"].ToString();
                        txtnokaddress.Text = row["Address"].ToString();
                        txtnokofficetel.Text = row["teloffice"].ToString();
                        txtnoktelRes.Text = row["telnores"].ToString();
                        txtnokMobile.Text = row["MobileNo"].ToString();
                        txtnokemail.Text = row["Email"].ToString();
                        txtnokfaxno.Text = row["FaxNo"].ToString();
                    }
                    lblRecordstatus.Text = " Found Successfull.";
                }
                else
                {
                    lblRecordstatus.Text = " Not Found.";
                }

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmModifyNextofkin_Load.", ex, "frmModifyNextOfKin");
                frmobj.ShowDialog();
            }
            #endregion
        }

        private void btnSavechangesnextofkin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] parameters = new[]
                                {
                                new SqlParameter("@ID",nextofkinID),
                                new SqlParameter("@MemberID", MBSID),
                                new SqlParameter("@NameofKin", txtnokname.Text),
                                new SqlParameter("@Relation", txtnokrelation.Text),
                                new SqlParameter("@NICNICOP", txtnoknic.Text),
                                new SqlParameter("@PassportNo", txtnokpassportno.Text),
                                new SqlParameter("@Address", txtnokaddress.Text),
                                new SqlParameter("@TelNoOffice", txtnokofficetel.Text),
                                new SqlParameter("@TelNoRes", txtnoktelRes.Text),
                                new SqlParameter("@MobileNo", txtnokMobile.Text),
                                new SqlParameter("@Email", txtnokemail.Text),
                                new SqlParameter("@FaxNo", txtnokfaxno.Text),
                                new SqlParameter("@user_ID", Models.clsUser.ID)
                            };
                cls_dl_ModifyMembership.Modify_Membership_nextofkin(parameters);
                this.Close();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnSavechangesnextofkin_Click.", ex, "frmModifyNextOfKin");
                frmobj.ShowDialog();
            }
        }
    }
}
