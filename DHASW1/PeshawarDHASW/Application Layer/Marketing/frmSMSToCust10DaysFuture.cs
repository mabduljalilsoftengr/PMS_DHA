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
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Marketing
{
    public partial class frmSMSToCust10DaysFuture : Telerik.WinControls.UI.RadForm
    {
        public frmSMSToCust10DaysFuture()
        {
            InitializeComponent();
        }
        private DataSet MobileNods { get; set; }
        private DataTable dtbl { get; set; }
        private DataTable dtblupdate = new DataTable();
        private int sendsms { get; set; } = 0;
        private int totalRecord;
        private string Successsmssendingstatus { get; set; } = "";
        private string Failedsmssendingstatus { get; set; } = "";
        private int sendstartbw = 0;
        private string SMS_Mesage { get; set; }
        private void btnmobilenumers_Click(object sender, EventArgs e)
        {
            DataLoading();
        }

        private void DataLoading()
        {
            SqlParameter[] parameter =
            {
                new SqlParameter("@Task","SendSMSCustomerHavingAfter10DaysDue")
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

        private void btnSendSMS_Click(object sender, EventArgs e)
        {
            if (DGVMObileData.RowCount > 0)
            {
                if (MessageBox.Show("Are You Sure, To Send SMS to all Existing Customer (Viewed in Grid.) ?", "Attention !!! ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    lblTotalSMS.Text = totalRecord.ToString();
                    btnSendSMS.Enabled = false;
                    SendSMSBluk.RunWorkerAsync();
                    lblSendSlot.Text = sendstartbw.ToString();
                }
            }
            else
            {
                MessageBox.Show("No Mobile No. Found.");
            }
        }

        private void SendSMSBluk_DoWork(object sender, DoWorkEventArgs e)
        {
            SendSMS();
        }

        private void SendSMSBluk_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Successsmssendingstatus.Contains("SMS Sent Successfully") && !Failedsmssendingstatus.Contains("SMS Sending Failed"))
            {
                MessageBox.Show("SMS Sent Successfully");
                btnSendSMS.Enabled = Enabled;
            }
            else if (!Successsmssendingstatus.Contains("SMS Sent Successfully") && Failedsmssendingstatus.Contains("SMS Sending Failed"))
            {
                MessageBox.Show("SMS Sending Failed");
                btnSendSMS.Enabled = Enabled;
            }
            else if (Successsmssendingstatus.Contains("SMS Sent Successfully") && Failedsmssendingstatus.Contains("SMS Sending Failed"))
            {
                MessageBox.Show("All SMS not Send, Some failed.");
                btnSendSMS.Enabled = Enabled;
            }
            else if (!Successsmssendingstatus.Contains("SMS Sent Successfully") && !Failedsmssendingstatus.Contains("SMS Sending Failed"))
            {
                MessageBox.Show("Try again.");
                btnSendSMS.Enabled = Enabled;
            }
        }
        private void SendSMS()
        {
            try
            {

                //lblSendSlot.Text = sendstart.ToString();
                bool status = false;
                foreach (GridViewRowInfo Row in DGVMObileData.Rows)
                {
                    try
                    {
                        SMS_Mesage = "Dear Customer, Last Date to deposit "+ Row.Cells["InstNo"].Value.ToString() +" of Rs." + Row.Cells["Amount"].Value.ToString() + " is " +
                                           Convert.ToDateTime(Row.Cells["DueDate"].Value.ToString()).ToString("dd/MM/yyyy") + ".Please make timely payment to avoid surcharge." + Environment.NewLine + "Ignore this message if you already made the payment.";

                    }
                    catch (Exception ex)
                    {

                        Helper.LibraryMessage.Log(ex.Message + " Error at Message Prep.");
                    }
                   

                    if (Regex.IsMatch(Row.Cells["MobileNo"].Value.ToString(), MakeCombinedPattern()))
                    {
                        //status = Helper.clsPluginHelper.SMSSEnding( Row.Cells["MobileNo"].Value.ToString(), txtMessage.Text);
                        status = SMSSEndingNEW(Row.Cells["MobileNo"].Value.ToString(), SMS_Mesage, Convert.ToInt32(Row.Cells["PlanID"].Value.ToString()),
                            Convert.ToInt32(Row.Cells["InstalTempID"].Value.ToString()), Row.Cells["FileNo"].Value.ToString()
                            , Row.Cells["Name"].Value.ToString());

                        if (status == true)
                        {
                            sendsms = sendsms + 1;
                            //lblSendSlot.Text = sendsms.ToString();

                            //lblremainingSMS.Text = (totalRecord - sendsms).ToString();
                            try
                            {
                                SqlParameter[] parameter = {
                                new SqlParameter("@Task","SaveHistoryInformationofSending"),
                                //new SqlParameter("@SendID",""),
                                new SqlParameter("@SMSType",txtSMSType.Text),
                                new SqlParameter("@DateofSMS",DateTime.Now.ToString("yyyy-MM-dd")),
                                new SqlParameter("@Message",SMS_Mesage),
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
                                        string data = @"" + Row.Cells["MobileNo"].Value.ToString() + "|" + txtSMSType.Text + "|" + SMS_Mesage + "|" + status.ToString() + "|" + clsUser.Name + DateTime.Now.ToString("dd/MMM/yyyy-hh:MM:ss tt") + "\n";
                                        Helper.LibraryMessage.Log(data);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Helper.LibraryMessage.Log(ex.Message + " Error at Save History.");
                            }
                      


                        }

                    }

                }

                #region Update the Status 

                SqlParameter[] param =
                {
                    new SqlParameter("@Task", "UpdateSMSColumnStatus"),
                    new SqlParameter() { ParameterName = "@tbl_UpdateSMSAlertToCstmrs10DaysDueInstlmnt", SqlDbType = SqlDbType.Structured, SqlValue = dtblupdate }
                };
                int rslt = 0;
                rslt = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(),
                                                                  CommandType.StoredProcedure,
                                                                  "App.tbl_SMSSendingLog",
                                                                  param);
                dtblupdate.Rows.Clear();
                #endregion

                #region Commented Code
                /// Enter Manual Mobile Number Entered
                //if (dtbl.Rows.Count > 0)
                //{
                //    for (int i = 0; i < dtbl.Rows.Count; i++)
                //    {
                //        SqlParameter[] par = {
                //                     new SqlParameter("@Task","InsertManualMobileNoEntered"),
                //                     new SqlParameter("@SMSType",txtSMSType.Text),
                //                     new SqlParameter("@DateofSMS",DateTime.Now.ToString("yyyy-MM-dd")),
                //                     new SqlParameter("@Message",txtMessage.Text),
                //                     new SqlParameter("@Status",status.ToString()),
                //                     new SqlParameter("@MobileNo",dtbl.Rows[i]["MobileNo"].ToString()),
                //                     new SqlParameter("@UserName",clsUser.Name),
                //                     new SqlParameter("@ManualMobNoStatus","ManualMobileNoEntered")
                //                     };
                //        int rslt = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(),
                //                                              CommandType.StoredProcedure,
                //                                              "App.tbl_SMSSendingLog",
                //                                              par);
                //    }
                //}
                #endregion

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.InnerException + " Error at SMSSend Function.");
                string data = ex.Message;
                Helper.LibraryMessage.Log(data + " Error at SMSSend Function.");
            }

        }

       private Uri uri { get; set; }
        public bool SMSSEndingNEW(string MobileNo, string Message,int planid,int insttempid,string fileno,string name)
        {
            string mbNo = MobileNo;
            string checkstring = MobileNo[0].ToString();
            bool SMSStatus = false;
          

            if (checkstring == "0")
            {
                var aStringBuilder = new StringBuilder(MobileNo);
                aStringBuilder.Remove(0, 1);
                aStringBuilder.Insert(0, "92");
                MobileNo = aStringBuilder.ToString();
            }


            try
            {

                string Username = "dhapeshwar@bizsms.pk";//configurationmanager.appsettings["sms.username"];
                string Password = "dh2p3sh1w";//ConfigurationManager.AppSettings["Sms.Password"];
                string SenderNum = MobileNo;//ConfigurationManager.AppSettings["Sms.Sendernum"];
                string ShortCode = "DHAPESHAWAR";



                //string SmsAPILink = @"http://api.bizsms.pk/api-send-branded-sms.aspx?username=" + Username +
                //    "&pass=" + Password + "&" + "text=" + Message + "&" +
                //    "masking=" + ShortCode +
                //    "&destinationnum=" + SenderNum + "&language=English";
                uri = new Uri("http://api.bizsms.pk/api-send-branded-sms.aspx?username=" + Username +
                           "&pass=" + Password + "&" + "text=" + Message + "&" +
                           "masking=" + ShortCode +
                           "&destinationnum=" + SenderNum + "&language=English");

            }
            catch (Exception ex)
            {
                Helper.LibraryMessage.Log(ex.Message + ex.InnerException + " Error at API Hitting.");
                MessageBox.Show(ex.Message + ex.InnerException + " Error at API Hitting.");
            }




            #region Update SMS status
            if (dtblupdate.Columns.Count <= 0)
            {
                dtblupdate.Columns.Add("PlanID");
                dtblupdate.Columns.Add("InstTempID");
                dtblupdate.Columns.Add("FileNo");
                dtblupdate.Columns.Add("MbNo");
                dtblupdate.Columns.Add("Name");
            }
            DataRow dtr = dtblupdate.NewRow();
            dtr["PlanID"] = planid;
            dtr["InstTempID"] = insttempid;
            dtr["FileNo"] = fileno;
            dtr["MbNo"] = mbNo;
            dtr["Name"] = name;
            dtblupdate.Rows.Add(dtr);

            //SqlParameter[] par = {
            //                         new SqlParameter("@Task","UpdateSMSColumnStatus"),
            //                         new SqlParameter("@PlanID",planid),
            //                         new SqlParameter("@InstalTempID",insttempid),
            //                         new SqlParameter("@FileNo",fileno),
            //                         new SqlParameter("@MobileNo",mbNo),
            //                         new SqlParameter("@Name",name)
            //                         };
            //int rslt = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(),
            //                                      CommandType.StoredProcedure,
            //                                      "App.tbl_SMSSendingLog",
            //                                      par);
            #endregion



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
                Helper.LibraryMessage.Log(ex.Message + ex.InnerException + " Error at Json");
                MessageBox.Show(ex.Message + ex.InnerException + " Error at Json");
            }
            return SMSStatus;
        }

    }
}
