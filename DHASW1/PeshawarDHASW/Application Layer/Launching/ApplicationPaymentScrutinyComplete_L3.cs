using PeshawarDHASW.Helper;
using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Launching
{
    public partial class ApplicationPaymentScrutinyComplete_L3 : Telerik.WinControls.UI.RadForm
    {
        public ApplicationPaymentScrutinyComplete_L3()
        {
            InitializeComponent();
        }
        private string txtSMSType { get; set; }
        private string txtMessage { get; set; }
        private string Successsmssendingstatus { get; set; } = "";
        private string Failedsmssendingstatus { get; set; } = "";
        private string mbNo { get; set; }
        private void btnSearchComplete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] param =
                {
                new SqlParameter("@ApplicantName", Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtApplicantNameCA.Text)),
                new SqlParameter("@CNIC_NICOP",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtCNIC_CA.Text)),
                new SqlParameter("@MobileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtMobileNoCA.Text)),
                new SqlParameter("@FormNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtFormNoCA.Text))
                };
                DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "Launching.p_Gettbl_ApplicationFeeInfo_Complete", param);
                DGV_CompleteForms.DataSource = ds.Tables[0].DefaultView;
                foreach (var item in DGV_CompleteForms.Columns)
                {
                    item.BestFit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DGV_CompleteForms_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                
               if (e.Column.Name == "btnValidForBalloting")
               {

                //if(MessageBox.Show("Are you Sure ?","Attention !",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                    int appid = int.Parse(e.Row.Cells["ApplicationID"].Value.ToString());

                    frmReviewForFinalApproval frm = new frmReviewForFinalApproval(appid, "ScrutinyCompleted");
                    frm.ShowDialog();
                    if((ConfigurationManager.AppSettings["ApplicationFinalScrutiny"]).ToString() == "Valid")
                    {
                        mbNo = e.Row.Cells["MobileNo"].Value.ToString();
                        SqlParameter[] param =
                        {
                         new SqlParameter("@ApplicationID", appid),
                         new SqlParameter("@Name",clsUser.Name),
                         new SqlParameter("@ApplicationStatus","ValidForBalloting")
                        };
                        int rslt = SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(),
                                     CommandType.StoredProcedure, "Launching.p_Updatetbl_ApplInfo_Status",
                                     param);
                        if (rslt > 0)
                        {
                            MessageBox.Show("Scrutiny Completed and Move To Ballot Successfully.", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            UpdateOnlineReordOfAppliant("Documents and Payments Verifed.Valid For Ballot.",
                                e.Row.Cells["FormNo"].Value.ToString(),
                                 e.Row.Cells["CNIC_NICOP"].Value.ToString());

                            txtSMSType = "";
                            txtMessage = "";
                            txtSMSType = "Commercial Launching";
                            txtMessage = "Dear Applicant Your application for DHAP Commercial Launch has been Verified for upcoming Ballot." + Environment.NewLine +
                                         "Please note your Form Number : " + e.Row.Cells["FormNo"].Value.ToString() + " for future reference";
                            SendingSMS();
                            btnSearchComplete_Click(sender, e);
                            ConfigurationManager.AppSettings["ApplicationFinalScrutiny"] = "Not-Valid";
                        }

                    }
                //}
               }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
        private void UpdateOnlineReordOfAppliant(string appst,string farmno ,string cnic)
        {
            SqlParameter[] ApplicantInfodata =
            {
                        new SqlParameter("@FormNo",farmno),
                        new SqlParameter("@CNIC_NICOP",cnic),
                        new SqlParameter("@AppliationStatus",appst)
                    };
            int rsl = SQLHelper.ExecuteNonQuery(
                      SQLHelper.createConnection_DHADB(), CommandType.StoredProcedure,
                      "dbo.p_Update_tbl_ApplicationInfo_DHADB", ApplicantInfodata);
        }
        private void bgwSMSSendingComplete_DoWork(object sender, DoWorkEventArgs e)
        {
            SendSMS();
        }
        private void SendingSMS()
        {
            #region Code for SMS Sending
            bgwSMSSendingComplete.RunWorkerAsync();
            #endregion
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
        private void bgwSMSSendingComplete_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Successsmssendingstatus.Contains("SMS Sent Successfully") && !Failedsmssendingstatus.Contains("SMS Sending Failed"))
            {
                MessageBox.Show("SMS Sent Successfully");
                //btnSendSMS.Enabled = Enabled;
            }
            else if (!Successsmssendingstatus.Contains("SMS Sent Successfully") && Failedsmssendingstatus.Contains("SMS Sending Failed"))
            {
                MessageBox.Show("SMS Sending Failed");
                // btnSendSMS.Enabled = Enabled;
            }
            else if (Successsmssendingstatus.Contains("SMS Sent Successfully") && Failedsmssendingstatus.Contains("SMS Sending Failed"))
            {
                MessageBox.Show("SMS Sent Successfully");
                // btnSendSMS.Enabled = Enabled;
            }
            else if (!Successsmssendingstatus.Contains("SMS Sent Successfully") && !Failedsmssendingstatus.Contains("SMS Sending Failed"))
            {
                MessageBox.Show("Try again.");
                //btnSendSMS.Enabled = Enabled;
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
        private void SendSMS()
        {
            try
            {

                //lblSendSlot.Text = sendstart.ToString();
                bool status = false;
                //foreach (GridViewRowInfo Row in DGVMObileData.Rows)
                //{
                if (Regex.IsMatch(mbNo, MakeCombinedPattern()))
                {
                    //status = Helper.clsPluginHelper.SMSSEnding( Row.Cells["MobileNo"].Value.ToString(), txtMessage.Text);
                    status = SMSSEndingNEW(mbNo, txtMessage);

                    if (status == true)
                    {
                        //sendsms = sendsms + 1;
                        //lblSendSlot.Text = sendsms.ToString();

                        //lblremainingSMS.Text = (totalRecord - sendsms).ToString();

                        SqlParameter[] parameter = {
                         new SqlParameter("@Task","SaveHistoryInformationofSending"),
                         //new SqlParameter("@SendID",""),
                         new SqlParameter("@SMSType",txtSMSType),
                         new SqlParameter("@DateofSMS",DateTime.Now.ToString("yyyy-MM-dd")),
                         new SqlParameter("@Message",txtMessage),
                         new SqlParameter("@Status",status.ToString()),
                         new SqlParameter("@MobileNo",mbNo),
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
                                string data = @"" + mbNo + "|" + txtSMSType + "|" + txtMessage + "|" + status.ToString() + "|" + clsUser.Name + DateTime.Now.ToString("dd/MMM/yyyy-hh:MM:ss tt") + "\n";
                                Helper.LibraryMessage.Log(data);
                            }
                        }
                    }

                }

                // }

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

        private void ApplicationPaymentScrutinyComplete_L3_Load(object sender, EventArgs e)
        {
            btnSearchComplete_Click(sender,e);
        }

        private void btnPaymentReconsilation_Click(object sender, EventArgs e)
        {
            try
            {
                int result = Helper.SQLHelper.ExecuteNonQuery
                           (
                           Helper.SQLHelper.createConnection(),
                           CommandType.StoredProcedure,
                           "Launching.p_Get_Application_Fin_Reconsilation"
                           );
                btnSearchComplete_Click(sender,e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(DGV_CompleteForms);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Software First.\n Error -> \n" + ex.Message);
            }
        }
    }
}
