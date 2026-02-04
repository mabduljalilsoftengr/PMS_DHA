using PeshawarDHASW.Data_Layer.clsMemberShip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Membership.Modify
{
    public partial class frm_DirTransferDashBoard : Telerik.WinControls.UI.RadForm
    {
        public frm_DirTransferDashBoard()
        {
            InitializeComponent();
        }

        private void frm_DirTransferDashBoard_Load(object sender, EventArgs e)
        {
            LoadIncompleteMembershipRecord();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadIncompleteMembershipRecord();
        }
        private void LoadIncompleteMembershipRecord()
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","LoadIncompleteMembership")
            };
            DataSet dst = new DataSet();
            dst = cls_dl_Membership.Membership_All_Retrive(prm);
            if(dst.Tables.Count > 0)
            {
                if(dst.Tables[0].Rows.Count > 0)
                {
                   lbltotalentries.Text = dst.Tables[0].Rows.Count.ToString();
                   grdIncompleteMembership.DataSource = dst.Tables[0].DefaultView;
                }          
            }
           
        }
    }
}
