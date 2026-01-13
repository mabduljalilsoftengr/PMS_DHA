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

namespace PeshawarDHASW.Application_Layer.Membership.Modify
{
    public partial class PHP : Form
    {
        public PHP()
        {
            InitializeComponent();
        }

        private void txtfndbtn_Click(object sender, EventArgs e)
         {

            SqlParameter[] parameter1 =
            {
                        new SqlParameter("@Task", "SelectDPRData"),
                        new SqlParameter("@MembershipNo", txtmembershipno.Text)
            };
            DataSet dst = Data_Layer.clsMemberShip.cls_dl_Membership.Membership_PersonalInfo_Retrive(parameter1);
            if(dst.Tables.Count > 0)
            {
                if(dst.Tables[0].Rows.Count > 0)
                {
                    string sts = dst.Tables[0].Rows[0]["ReminderStatus"].ToString();
                    if (sts == "False")
                    {
                        lbldetail.Text = "Not in PHP list";
                        btnadd.Enabled = true;
                        btnremove.Enabled = false;
                    }
                    else if(sts == "True")
                    {
                        lbldetail.Text = "Already exist in PHP list";
                        btnadd.Enabled = false;
                        btnremove.Enabled = true;
                    }

                    lblstatus.Text = dst.Tables[0].Rows[0]["Status"].ToString(); 
                }
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
           SqlParameter[] parameter1 =
           {
                        new SqlParameter("@Task", "AddToPHPList"),
                        new SqlParameter("@MembershipNo", txtmembershipno.Text)
            };

            int rslt = Data_Layer.clsMemberShip.cls_dl_Membership.Membership_PersonalInfo(parameter1);
            if(rslt > 0)
            {
                MessageBox.Show("Successfully added to PHP list");
                lblrslt.Text = "Successfully added to PHP list";
                btnadd.Enabled = false;
                btnremove.Enabled = true;
            }
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            SqlParameter[] parameter1 =
            {
                        new SqlParameter("@Task", "RemoveFromPHPList"),
                        new SqlParameter("@MembershipNo", txtmembershipno.Text)
            };
            int rslt = Data_Layer.clsMemberShip.cls_dl_Membership.Membership_PersonalInfo(parameter1);
            if (rslt > 0)
            {
                MessageBox.Show("Successfully removed from PHP list");
                lblrslt.Text = "Successfully removed from PHP list";
                btnadd.Enabled = true;
                btnremove.Enabled = false;
            }
        }
    }
}
