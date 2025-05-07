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

namespace PeshawarDHASW.Application_Layer.Membership.MSViewInfo
{
    public partial class frmMSFormRecordChecking : Telerik.WinControls.UI.RadForm
    {
        public frmMSFormRecordChecking()
        {
            InitializeComponent();
        }

        private void btncheck_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtchallanno.Text))
            {
                DataSet ds = LoadData();
                int cnt = int.Parse(ds.Tables[0].Rows[0]["RecordCount"].ToString());
                if (cnt > 0)
                {
                    lblmessage.BackColor = Color.Red;
                    lblmessage.Text = "Membership Form is already delivered.";
                    grdmsrecord.DataSource = ds.Tables[1].DefaultView;
                }
                else
                {
                    lblmessage.BackColor = Color.Green;
                    lblmessage.Text = "Please deliver Membership Form.";
                    SqlParameter[] prmt =
                    {
                    new SqlParameter("@Task","InsertMSFormRecord"),
                    new SqlParameter("@ChallanNo",txtchallanno.Text),
                    new SqlParameter("@UserName",Models.clsUser.Name)
                };
                    int rslt = cls_dl_Membership.Membership_All_NonQuery(prmt);
                    grdmsrecord.DataSource = ds.Tables[1].DefaultView;
                }
            }
            else
            {
                MessageBox.Show("Please Enter Challan No.");
            }
           
        }

        private void frmMSFormRecordChecking_Load(object sender, EventArgs e)
        {
            if(LoadData().Tables[1].Rows.Count > 0)
            {
                grdmsrecord.DataSource = LoadData().Tables[1].DefaultView;
            }
        }
        private DataSet LoadData()
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","GetMSFormRecord"),
                new SqlParameter("@ChallanNo",txtchallanno.Text)
            };
            DataSet ds = cls_dl_Membership.Membership_All_Retrive(prm);
            return ds;
        }
    }
}
