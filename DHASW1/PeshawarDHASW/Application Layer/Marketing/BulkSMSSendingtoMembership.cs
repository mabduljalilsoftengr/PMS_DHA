using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Marketing
{
    public partial class BulkSMSSendingtoMembership : Telerik.WinControls.UI.RadForm
    {
        public BulkSMSSendingtoMembership()
        {
            InitializeComponent();
        }
        private DataSet MobileNods { get; set; }
        private DataTable dtbl { get; set; }
        private int sendsms { get; set; } = 0;
        private int totalRecord;
        private string Successsmssendingstatus { get; set; } = "";
        private string Failedsmssendingstatus { get; set; } = "";
        private void BulkSMSSendingtoMembership_Load(object sender, EventArgs e)
        {
            
        }
       
        private void DataLoading()
        {
            SqlParameter[] parameter = {
                            new SqlParameter("@Task","MobileNoGettoSendSMS"),
                            new SqlParameter("@SMSType",txtSMSType.Text)
            };
            MobileNods = Helper.SQLHelper.ExecuteDataset(
                                                          Helper.SQLHelper.createConnection(),
                                                          CommandType.StoredProcedure,
                                                          "App.tbl_SMSSendingLog",
                                                          parameter);
            DGVMObileData.DataSource = MobileNods.Tables[0].DefaultView;
            totalRecord = MobileNods.Tables[0].Rows.Count;
            lbltotalcount.Text = MobileNods.Tables[0].Rows.Count.ToString();
        }
        public int SendLimit { get; set; } = 200;
        private int sendstartbw = 0;
        private void btnSendSMS_Click(object sender, EventArgs e)
        { 
            //if(Models.clsUser.ID != 3)
            //{
                #region Code for SMS Sending
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","CheckSMSSendingAccess"),
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(
                                                              Helper.SQLHelper.createConnection(),
                                                              CommandType.StoredProcedure,
                                                              "App.tbl_SMSSendingLog",
                                                              prm);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string msg = ds.Tables[0].Rows[0]["MessageboxMessage"].ToString();
                        string auth = ds.Tables[0].Rows[0]["SMSAuthority"].ToString();
                        if(auth == "No")
                        {
                            MessageBox.Show(msg);
                        }
                        else if (auth == "Yes")
                        {

                            lblTotalSMS.Text = totalRecord.ToString();
                            btnSendSMS.Enabled = false;
                            SendSMSBluk.RunWorkerAsync();
                            lblSendSlot.Text = sendstartbw.ToString();

                        }
                    }
                }
                #endregion
            //}
            //else
            //{
            //    lblTotalSMS.Text = totalRecord.ToString();
            //    btnSendSMS.Enabled = false;
            //    SendSMSBluk.RunWorkerAsync();
            //    lblSendSlot.Text = sendstartbw.ToString();
            //}
            


        }
        private static string[] m_Patterns = new string[] {
                                                            @"^[0-9]{11}$",
                                                            @"^92[0-9]{10}$",
                                                            @"^\+92[0-9]{10}$"
                                                            };
        private static string MakeCombinedPattern()
        {
            return string.Join("|", m_Patterns
              .Select(item => "(" + item + ")"));
        }
        private void SendSMS()
        {
            try
            {

                //lblSendSlot.Text = sendstart.ToString();
                bool status = false;
                foreach (GridViewRowInfo Row in DGVMObileData.Rows)
                {
                    if (Regex.IsMatch(Row.Cells["MobileNo"].Value.ToString(), MakeCombinedPattern()))
                    {
                        //status = Helper.clsPluginHelper.SMSSEnding( Row.Cells["MobileNo"].Value.ToString(), txtMessage.Text);
                        status = SMSSEndingNEW(Row.Cells["MobileNo"].Value.ToString(), txtMessage.Text);

                        if (status == true)
                        {
                         sendsms = sendsms + 1;
                         //lblSendSlot.Text = sendsms.ToString();

                         //lblremainingSMS.Text = (totalRecord - sendsms).ToString();

                         SqlParameter[] parameter = {
                         new SqlParameter("@Task","SaveHistoryInformationofSending"),
                         //new SqlParameter("@SendID",""),
                         new SqlParameter("@SMSType",txtSMSType.Text),
                         new SqlParameter("@DateofSMS",DateTime.Now.ToString("yyyy-MM-dd")),
                         new SqlParameter("@Message",txtMessage.Text),
                         new SqlParameter("@Status",status.ToString()),
                         new SqlParameter("@MobileNo",Row.Cells["MobileNo"].Value.ToString()),
                         new SqlParameter("@UserName",clsUser.Name)
                         };
                            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(),
                                                                  CommandType.StoredProcedure,
                                                                  "App.tbl_SMSSendingLog",
                                                                  parameter);
                            
                            if (ds.Tables.Count > 0)
                            {
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    string data = @"" + Row.Cells["MobileNo"].Value.ToString() + "|" + txtSMSType.Text + "|" + txtMessage.Text + "|" + status.ToString() + "|" + clsUser.Name + DateTime.Now.ToString("dd/MMM/yyyy-hh:MM:ss tt") + "\n";
                                    Helper.LibraryMessage.Log(data);
                                }
                            }
                        }

                    }

                }

                #region
                /// Enter Manual Mobile Number Entered
                if (dtbl.Rows.Count > 0)
                {
                    for (int i = 0; i < dtbl.Rows.Count; i++)
                    {
                        SqlParameter[] par = {
                                     new SqlParameter("@Task","InsertManualMobileNoEntered"),
                                     new SqlParameter("@SMSType",txtSMSType.Text),
                                     new SqlParameter("@DateofSMS",DateTime.Now.ToString("yyyy-MM-dd")),
                                     new SqlParameter("@Message",txtMessage.Text),
                                     new SqlParameter("@Status",status.ToString()),
                                     new SqlParameter("@MobileNo",dtbl.Rows[i]["MobileNo"].ToString()),
                                     new SqlParameter("@UserName",clsUser.Name),
                                     new SqlParameter("@ManualMobNoStatus","ManualMobileNoEntered")
                                     };
                        int rslt = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(),
                                                              CommandType.StoredProcedure,
                                                              "App.tbl_SMSSendingLog",
                                                              par);
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                string data = ex.Message;
                Helper.LibraryMessage.Log(data);
            }

        }

        public bool SMSSEndingNEW(string MobileNo, string Message)
        {
            string checkstring = MobileNo[0].ToString();

            if (checkstring == "0")
            {
                var aStringBuilder = new StringBuilder(MobileNo);
                aStringBuilder.Remove(0, 1);
                aStringBuilder.Insert(0, "92");
                MobileNo = aStringBuilder.ToString();
            }


            bool SMSStatus = false;
            string Username = "dhapeshwar@bizsms.pk";//configurationmanager.appsettings["sms.username"];
            string Password = "dh2p3sh1w";//ConfigurationManager.AppSettings["Sms.Password"];
            string SenderNum = MobileNo;//ConfigurationManager.AppSettings["Sms.Sendernum"];
            string ShortCode = "DHAPESHAWAR";



            //string SmsAPILink = @"http://api.bizsms.pk/api-send-branded-sms.aspx?username=" + Username +
            //    "&pass=" + Password + "&" + "text=" + Message + "&" +
            //    "masking=" + ShortCode +
            //    "&destinationnum=" + SenderNum + "&language=English";
            Uri uri = new Uri("http://api.bizsms.pk/api-send-branded-sms.aspx?username=" + Username +
                       "&pass=" + Password + "&" + "text=" + Message + "&" +
                       "masking=" + ShortCode +
                       "&destinationnum=" + SenderNum + "&language=English");

            var jasonData = "";

            try
            {
                using (var client = new WebClient())
                {
                    

                    jasonData = client.DownloadString(uri);
                    if (jasonData.Contains("SMS Sent Successfully") == true)
                    {
                        SMSStatus = true;
                        jasonData = "SMS Sent Successfully";

                        Successsmssendingstatus = "SMS Sent Successfully";
                    }
                    if (jasonData.Contains("Invalid Number") == true)
                    {
                        SMSStatus = false;
                        jasonData = "Invalid Number";

                        Failedsmssendingstatus = "SMS Sending Failed";
                    }
                    if (jasonData.Contains("Invalid Paramenters") == true)
                    {
                        SMSStatus = false;
                        jasonData = "Invalid Paramenters";

                        Failedsmssendingstatus = "SMS Sending Failed";
                    }
                    if (jasonData.Contains("Invalid Username or Passwor") == true)
                    {
                        SMSStatus = false;
                        jasonData = "Invalid Username or Passwors";

                        Failedsmssendingstatus = "SMS Sending Failed";
                    }
                    if (jasonData.Contains("Invalid Short Code") == true)
                    {
                        SMSStatus = false;
                        jasonData = "Invalid Short Code";

                        Failedsmssendingstatus = "SMS Sending Failed";
                    }
                    if (jasonData.Contains("Your Package Has Been Expire.") == true)
                    {
                        SMSStatus = false;
                        jasonData = "Your Package Has Been Expire.";

                        Failedsmssendingstatus = "SMS Sending Failed";
                    }
                    if (jasonData.Contains("Insufficent Balance") == true)
                    {
                        SMSStatus = false;
                        jasonData = "Insufficent Balance";

                        Failedsmssendingstatus = "SMS Sending Failed";
                    }
                    if (jasonData.Contains("Failed To Send SMS") == true)
                    {
                        SMSStatus = false;
                        jasonData = "Failed To Send SMS";

                        Failedsmssendingstatus = "SMS Sending Failed";
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return SMSStatus;
        }
        private void SendSMSBluk_DoWork(object sender, DoWorkEventArgs e)
        {
            SendSMS();

        }

        private void SendSMSBluk_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(Successsmssendingstatus.Contains("SMS Sent Successfully") &&  !Failedsmssendingstatus.Contains("SMS Sending Failed"))
            {
                MessageBox.Show("SMS Sent Successfully");
                btnSendSMS.Enabled = Enabled;
            }
            else if(!Successsmssendingstatus.Contains("SMS Sent Successfully") && Failedsmssendingstatus.Contains("SMS Sending Failed"))
            {
                MessageBox.Show("SMS Sending Failed");
                btnSendSMS.Enabled = Enabled;
            }
            else if(Successsmssendingstatus.Contains("SMS Sent Successfully") && Failedsmssendingstatus.Contains("SMS Sending Failed"))
            {
                MessageBox.Show("All SMS not Send, Some failed.");
                btnSendSMS.Enabled = Enabled;
            }
            else if(!Successsmssendingstatus.Contains("SMS Sent Successfully") && !Failedsmssendingstatus.Contains("SMS Sending Failed"))
            {
                MessageBox.Show("Try again.");
                btnSendSMS.Enabled = Enabled;
            }
            //if (e.Cancelled)
            //{
            //    MessageBox.Show("Operation was canceled");
            //}
            //else if (e.Error != null)
            //{
            //    MessageBox.Show(e.Error.Message);
            //}
            //else
            //{
            //    MessageBox.Show("SMS Sending is Completed.");
            //    btnSendSMS.Enabled = Enabled;
            //}
        }

        private void btnmobilenumers_Click(object sender, EventArgs e)
        {
            DataLoading();
        }

        private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 35)
            {
                e.Handled = true;
            }
            if (e.KeyChar == 38)
            {
                e.Handled = true;
            }
        }

        private void btncleargrid_Click(object sender, EventArgs e)
        {
            DGVMObileData.DataSource = null;


            lbltotalcount.Text = DGVMObileData.RowCount.ToString();
            totalRecord = DGVMObileData.RowCount;
        }
        
        private void txtaddmobnmbr_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (MobileNo())
                {
                    //var row = DGVMObileData.CurrentRow;
                    //var rowInfo = new GridViewDataRowInfo(this.DGVMObileData.MasterView);
                    //rowInfo.Cells[0].Value = txtaddmobnmbr.Text;
                    //var index = DGVMObileData.Rows.IndexOf(row);
                    //DGVMObileData.Rows.Insert(index + 1, rowInfo);
                    #region
                    // Fill dataTable for record of Manual Entry Mobile Numbers
                    DataTable dttb = new DataTable();
                    dttb.Columns.Add("MobileNo");
                    DataRow dr1 = dttb.NewRow();
                    dr1["MobileNo"] = txtaddmobnmbr.Text;
                    dttb.Rows.Add(dr1);
                    dtbl = dttb;
                    #endregion

                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("MobileNo");
                    // Convert Gridview Datasource to DataTable
                    for (int i = 0; i < DGVMObileData.RowCount; i++)
                    {
                        DataRow dr = dataTable.NewRow();
                        dr["MobileNo"] = DGVMObileData.Rows[i].Cells["MobileNo"].Value;
                        dataTable.Rows.Add(dr);
                    }
                    // Add New Mobile number to DataTable
                    DataRow drToAdd = dataTable.NewRow();
                    drToAdd["MobileNo"] = txtaddmobnmbr.Text;
                    dataTable.Rows.Add(drToAdd);
                    dataTable.AcceptChanges();
                    DGVMObileData.DataSource = dataTable.DefaultView;

                    lbltotalcount.Text = DGVMObileData.RowCount.ToString();
                    totalRecord = DGVMObileData.RowCount;
                    txtaddmobnmbr.Text = "";
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void txtaddmobnmbr_Validating(object sender, CancelEventArgs e)
        {
            MobileNo();
        }
        private bool MobileNo()
        {
            bool bStatus = true;
            if (txtaddmobnmbr.Text == "")
            {
                errorProvider.SetError(txtaddmobnmbr, "Please enter Mobile Number.");
                bStatus = false;
            }
            else
                errorProvider.SetError(txtaddmobnmbr, "");
            return bStatus;
        }
    }
}
