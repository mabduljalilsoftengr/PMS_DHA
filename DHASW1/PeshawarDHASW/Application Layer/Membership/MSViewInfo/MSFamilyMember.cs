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

namespace PeshawarDHASW.Application_Layer.Membership.MSViewInfo
{
    public partial class MSFamilyMember : Telerik.WinControls.UI.RadForm
    {
        public MSFamilyMember()
        {
            InitializeComponent();
        }

        public int MBSID { get; set; }
        public MSFamilyMember(int ID)
        {
            MBSID = ID;
            InitializeComponent();
        }

        private void MSFamilyMember_Load(object sender, EventArgs e)
        {
            try
            {
                this.ThemeName = clsUser.ThemeName;
                ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
                SqlParameter[] parameter = new[] { new SqlParameter("@Member_ID", MBSID) };
                DataSet ds = cl_dl_SerachMembership.MembershipFamilyDataLoadforView(parameter);

                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    // lblRecordstatus.Text = " Found Successfull.";
                    foreach (DataRow Row in dt.Rows)
                    {
                        string[] row = new string[] { Row["Name"].ToString(), Row["DOB"].ToString(), Row["NICNO"].ToString(), Row["Relation"].ToString()};
                        FamilyMemberDGV.Rows.Add(row);
                    }
                }
                else
                {
                   // lblRecordstatus.Text = " Not Found.";
                }

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on MSFamilyMember_Load.", ex, "MSFamilyMember");
                frmobj.ShowDialog();
            }
        }
    }
}
