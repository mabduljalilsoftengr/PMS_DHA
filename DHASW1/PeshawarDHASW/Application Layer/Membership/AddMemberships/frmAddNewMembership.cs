using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Membership.AddMemberships
{
    public partial class frmAddNewMembership : Telerik.WinControls.UI.RadForm
    {
        public frmAddNewMembership()
        {
            InitializeComponent();
        }

        private void btnNewMS_Click(object sender, EventArgs e)
        {
            SqlParameter[] para = {
                new SqlParameter("@Task","Insert"),
                new SqlParameter("@MSNO",txtNewMS.Text)
            };
            // DataTable ds = Data_Layer.clsAllMembership.cls_dl_AllMembership.AllMembership_Reader(para);
            int result = Data_Layer.clsAllMembership.cls_dl_AllMembership.AllMembership_NonQuery(para);
            if (result !=0)
            {
                RadMessageBox.Show("Successfully added");
                txtNewMS.Text = ""; 
            }
            else
            {
                RadMessageBox.Show("Error Not added");
            }
        }

        private void txtNewMS_TextChanged(object sender, EventArgs e)
        {
            SqlParameter[] param =
                       {
                           new SqlParameter("@Task","Select"),
                           new SqlParameter("@MSNO",txtNewMS.Text)
                        };
            DataTable dt = Data_Layer.clsAllMembership.cls_dl_AllMembership.AllMembership_Reader(param);
            //Data_Layer.clsAllMembership.cls_dl_AllMembership.AllMembership_Reader(param);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Membership Already Exist.");
            }
        }
    }
}
