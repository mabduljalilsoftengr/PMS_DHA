using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using PeshawarDHASW.Data_Layer;
using PeshawarDHASW.Models;
using PeshawarDHASW.Application_Layer.Membership;
using PeshawarDHASW.Data_Layer.clsMemberShip;
 
using Telerik.WinControls.UI;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.Membership.MSViewInfo
{
    public partial class MSNextofkininfo : Telerik.WinControls.UI.RadForm
    {
        public MSNextofkininfo()
        {
            InitializeComponent();
        }

        public int MBSID { get; set; }
        public MSNextofkininfo(int id)
        {
            MBSID = id;
            InitializeComponent();
        }

        private void MSNextofkininfo_Load(object sender, EventArgs e)
        {
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
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on MSNextofkininfo_Load.", ex, "MSNextOfKininfo");
                frmobj.ShowDialog();
            }
        }
    }
}
