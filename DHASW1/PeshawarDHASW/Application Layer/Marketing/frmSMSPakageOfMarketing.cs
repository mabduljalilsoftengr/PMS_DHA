using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Marketing
{
    public partial class frmSMSPakageOfMarketing : Telerik.WinControls.UI.RadForm
    {
        public frmSMSPakageOfMarketing()
        {
            InitializeComponent();
        }

        private void btnSMSSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtmessage.Text) && !string.IsNullOrEmpty(txttotalsmsinpakage.Text))
                {
                    SqlParameter[] prm =
                    {
                    new SqlParameter("@Task","SMSNewPakageEntry"),
                    new SqlParameter("@MessageboxMessage",txtmessage.Text),
                    new SqlParameter("@PakagaeName",txtpakagename.Text),
                    new SqlParameter("@TotalSMSInPakage",txttotalsmsinpakage.Text),
                    new SqlParameter("@CurrentDate",dtpcurrentdate.Value.Date),
                    new SqlParameter("@SMSAuthority",txtstatus.Text),
                    };
                    int rslt = Helper.SQLHelper.ExecuteNonQuery(
                                                                  Helper.SQLHelper.createConnection(),
                                                                  CommandType.StoredProcedure,
                                                                  "App.tbl_SMSSendingLog",
                                                                  prm);
                    if (rslt > 0)
                    {
                        MessageBox.Show("Successfully inserted.", "Succes.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Message and Total Number of SMS in pakage.");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
         
        }

        private void frmSMSPakageOfMarketing_Load(object sender, EventArgs e)
        {
            dtpcurrentdate.Value = DateTime.Now;
            Getpakagename();
        }

        private void txttotalsmsinpakage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
                e.Handled = true;
        }
        private void Getpakagename()
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","GetPakageName")
            };
            DataSet dst = Helper.SQLHelper.ExecuteDataset(
                                                              Helper.SQLHelper.createConnection(),
                                                              CommandType.StoredProcedure,
                                                              "App.tbl_SMSSendingLog",
                                                              prm);
            if(dst.Tables.Count > 0)
            {
                if(dst.Tables[0].Rows.Count > 0)
                {
                   string pkgnm = dst.Tables[0].Rows[0]["PakagaeName"].ToString();
                   txtpakagename.Text = pkgnm;
                    
                }
            }
        }
    }
}
