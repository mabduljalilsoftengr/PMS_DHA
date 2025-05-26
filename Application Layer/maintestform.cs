using PeshawarDHASW.Application_Layer.Marketing;
using PeshawarDHASW.Application_Layer.PlotsPosession;
using PeshawarDHASW.Application_Layer.Transfer.PlotsPosession;
using PeshawarDHASW.Data_Layer.NDC;
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

namespace PeshawarDHASW.Application_Layer
{
    public partial class maintestform : Telerik.WinControls.UI.RadForm
    {
        public maintestform()
        {
            InitializeComponent();
        }
        private DataSet MobileNods { get; set; }
        private DataTable dtbl { get; set; }
        private int sendsms { get; set; } = 0;
        private int totalRecord;
        private string Successsmssendingstatus { get; set; } = "";
        private string Failedsmssendingstatus { get; set; } = "";
        private int sendstartbw = 0;
        private string SMS_Mesage { get; set; }
        private void radButton1_Click(object sender, EventArgs e)
        {
            frmSMSPakageOfMarketing frm = new frmSMSPakageOfMarketing();
            frm.ShowDialog();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            frmPosessionVerificationbyTFR frm = new frmPosessionVerificationbyTFR();
            frm.ShowDialog();
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            if (DateTime.Now >= Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 12:00:00 PM"))
            {
                MessageBox.Show(DateTime.Now.ToString());
                
            }
            else
            {
                MessageBox.Show(DateTime.Now.ToShortDateString()  + " 12:00:00 PM");
            }
            //frmPosessionRcievedByFinanceBr frm = new frmPosessionRcievedByFinanceBr();
            //frm.ShowDialog();
            //System.Diagnostics.Process.Start("C:\\Users\\ASUS\\Desktop\\SignalR\\SignalRServer.exe");
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            clsTableWatcher tw = new clsTableWatcher();
            tw.WatchTable();
            tw.StartTableWatcher();

            SqlParameter[] prm =
            {
            new SqlParameter("@Task","Update_NDC_For_Test"),
            new SqlParameter("@NDCNo",2010),
            new SqlParameter("@StatusofNDC","FileTransferCompleted")
            };
            int rslt = cls_dl_NDC.NdcNonQuery(prm);
            
        }

        private void radButton5_Click(object sender, EventArgs e)
        {
            frmSMSToCust10DaysFuture frmobj = new frmSMSToCust10DaysFuture();
            frmobj.ShowDialog();
            //SqlParameter[] parameter =
            //{
            //    new SqlParameter("@Task","GetDuesof10DaysFuture"),
            //    new SqlParameter("@SMSType","Alert SMS to those having Installment Due in 10 Days Future.")
            //};
            //MobileNods = Helper.SQLHelper.ExecuteDataset(
            //                                              Helper.SQLHelper.createConnection(),
            //                                              CommandType.StoredProcedure,
            //                                              "App.tbl_SMSSendingLog",
            //                                              parameter);
            ////string mbno = MobileNods.Tables[0].Rows[0]["MobileNo"].ToString();
            ////string fno = MobileNods.Tables[0].Rows[0]["FileNo"].ToString();
            ////string instno = MobileNods.Tables[0].Rows[0]["InstNo"].ToString();
            ////string ddt = MobileNods.Tables[0].Rows[0]["DueDate"].ToString();
            ////string amnt = MobileNods.Tables[0].Rows[0]["Amount"].ToString();


            //SendSMSBluk.RunWorkerAsync();


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
                // btnSendSMS.Enabled = Enabled;
            }
            else if (!Successsmssendingstatus.Contains("SMS Sent Successfully") && Failedsmssendingstatus.Contains("SMS Sending Failed"))
            {
                MessageBox.Show("SMS Sending Failed");
                // btnSendSMS.Enabled = Enabled;
            }
            else if (Successsmssendingstatus.Contains("SMS Sent Successfully") && Failedsmssendingstatus.Contains("SMS Sending Failed"))
            {
                MessageBox.Show("All SMS not Send, Some failed.");
                // btnSendSMS.Enabled = Enabled;
            }
            else if (!Successsmssendingstatus.Contains("SMS Sent Successfully") && !Failedsmssendingstatus.Contains("SMS Sending Failed"))
            {
                MessageBox.Show("Try again.");
                // btnSendSMS.Enabled = Enabled;
            }
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
                foreach (DataRow Row in MobileNods.Tables[0].Rows)
                {
                    
                    //string fno = MobileNods.Tables[0].Rows[0]["FileNo"].ToString();
                    //string instno = MobileNods.Tables[0].Rows[0]["InstNo"].ToString();
                    //string ddt = MobileNods.Tables[0].Rows[0]["DueDate"].ToString();
                    //string amnt = MobileNods.Tables[0].Rows[0]["Amount"].ToString();



                    SMS_Mesage = "Dear Customer, " + " Your File No." + Row["FileNo"].ToString() + " , Installment No." +
                    Row["InstNo"].ToString() + " , Due Date" + Row["DueDate"].ToString() +
                    "  and Amount." + Row["Amount"].ToString();
                    if (Regex.IsMatch(Row["MobileNo"].ToString(), MakeCombinedPattern()))
                    {
                        //status = Helper.clsPluginHelper.SMSSEnding( Row.Cells["MobileNo"].Value.ToString(), txtMessage.Text);
                        status = SMSSEndingNEW(Row["MobileNo"].ToString(), SMS_Mesage);

                        if (status == true)
                        {
                            sendsms = sendsms + 1;
                            //lblSendSlot.Text = sendsms.ToString();

                            //lblremainingSMS.Text = (totalRecord - sendsms).ToString();

                        SqlParameter[] parameter = {
                         new SqlParameter("@Task","SaveHistoryInformationofSending"),
                         //new SqlParameter("@SendID",""),
                         new SqlParameter("@SMSType","Alert SMS to those having Installment Due in 10 Days Future."),
                         new SqlParameter("@DateofSMS",DateTime.Now.ToString("yyyy-MM-dd")),
                         new SqlParameter("@Message",SMS_Mesage),
                         new SqlParameter("@Status",status.ToString()),
                         new SqlParameter("@MobileNo",Row["MobileNo"].ToString()),
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
                                    string data = @"" + Row["MobileNo"].ToString() + "|" + "Alert SMS to those having Installment Due in 10 Days Future." + "|" + SMS_Mesage + "|" + status.ToString() + "|" + clsUser.Name + DateTime.Now.ToString("dd/MMM/yyyy-hh:MM:ss tt") + "\n";
                                    Helper.LibraryMessage.Log(data);
                                }
                            }
                        }

                    }

                }

                #region Code
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

        private void maintestform_Load(object sender, EventArgs e)
        {



            lblname.Text = DateTime.Now.ToLongDateString() + "Time:" + DateTime.Now.ToLongTimeString();
            MessageBox.Show(DateTime.Now.ToLongDateString() + "Time:" + DateTime.Now.ToLongTimeString());
            //Convert.ToDateTime(DateTime.Now.Date.ToString("dd/MM/yyyy") + " 05:50 AM").ToString();
            radLabel1.Text  = Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy/MM/dd") + " 12:50 PM").ToString();
        }
    }
}
