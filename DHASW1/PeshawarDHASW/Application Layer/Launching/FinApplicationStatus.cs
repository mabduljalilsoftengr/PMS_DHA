using PeshawarDHASW.Helper;
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

namespace PeshawarDHASW.Application_Layer.Launching
{
    public partial class FinApplicationStatus : Telerik.WinControls.UI.RadForm
    {
        public FinApplicationStatus()
        {
            InitializeComponent();
        }
        private string txtSMSType { get; set; }
        private string txtMessage { get; set; }
        private string Successsmssendingstatus { get; set; } = "";
        private string Failedsmssendingstatus { get; set; } = "";
        private string mbNo { get; set; }
        private void btnSearchRecord_Click(object sender, EventArgs e)
        {
            try
            {
                if(drpstspndobsrv.SelectedIndex > 0)
                {
                    string sts = "";
                    if(drpstspndobsrv.SelectedItem.ToString() == "Under Observation")
                    {
                        sts = "Review";
                    }
                    else if(drpstspndobsrv.SelectedItem.ToString() == "Under Process")
                    {
                        sts = "Pending";
                    }
                    else
                    {
                        sts = drpstspndobsrv.SelectedItem.ToString();
                    }

                    SqlParameter[] param =
                    {
                    new SqlParameter("@ApplicantName", Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtApplicantName.Text)),
                    new SqlParameter("@CNIC_NICOP",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtCNIC.Text)),
                    new SqlParameter("@MobileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtMobile.Text)),
                    new SqlParameter("@FormNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtFormNo.Text)),
                    new SqlParameter("@ApplicationStatus",sts)
                    };
                    DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "Launching.p_Gettbl_ApplicationFeeInfo_Pending", param);
                    DGV_ApplicantSearch.DataSource = ds.Tables[0].DefaultView;
                    foreach (var item in DGV_ApplicantSearch.Columns)
                    {
                        item.BestFit();
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Status.");
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
          
        }

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
                DGV_PayFormRece.DataSource = ds.Tables[0].DefaultView;
                foreach (var item in DGV_PayFormRece.Columns)
                {
                    item.BestFit();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnReceSearch_Click(object sender, EventArgs e)
        {

            try
            {
                SqlParameter[] param = {
                new SqlParameter("@DepositSlipNo", Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtDepositSlipno.Text)),
                new SqlParameter("@ApplicantName",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtApplicantNameRece.Text)),
                new SqlParameter("@MobileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtMObileNORece.Text)),
                new SqlParameter("@CNIC_NICOP",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtCNICReceive.Text))
            };
                DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "Launching.p_Gettbl_ApplicationFeeInfo_NoRecordExist", param);
                DGV_IncompleteForms.DataSource = ds.Tables[0].DefaultView;
                foreach (var item in DGV_IncompleteForms.Columns)
                {
                    item.BestFit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                int result = Helper.SQLHelper.ExecuteNonQuery
                           (
                           Helper.SQLHelper.createConnection(), 
                           CommandType.StoredProcedure, 
                           "Launching.p_Get_Application_Fin_Reconsilation"
                           );
                btnSearchRecord_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
        }

        private void radButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnsearchscrcomp_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] param = 
                {
                new SqlParameter("@ApplicantName", Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtApplicantName.Text)),
                new SqlParameter("@CNIC_NICOP",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtCNIC.Text)),
                new SqlParameter("@MobileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtMobile.Text)),
                new SqlParameter("@FormNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtFormNo.Text))
                };
                DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "Launching.p_Gettbl_ApplicationFeeInfo_ScrutinyCompleted", param);
                grdScrutinyCompleted.DataSource = ds.Tables[0].DefaultView;
                foreach (var item in grdScrutinyCompleted.Columns)
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
            if(e.Column.Name == "btnValidForBalloting")
            {
                int appid = int.Parse(e.Row.Cells["ApplicationID"].Value.ToString());
                mbNo = e.Row.Cells["MobileNo"].Value.ToString();
                SqlParameter[] param =
                {
                   new SqlParameter("@ApplicationID", appid),
                   new SqlParameter("@ApplicationStatus","ValidForBalloting")
                };
                int rslt = SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(),
                             CommandType.StoredProcedure, "Launching.p_Updatetbl_ApplInfo_Status", 
                             param);
                if(rslt > 0)
                {
                    MessageBox.Show("Successful.","Success.",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    //SearchGetComplete_Click();
                    txtSMSType = "";
                    txtMessage = "";
                    txtSMSType = "Commercial Launchig";
                    txtMessage = "Congratulation! Your application for DHAP Commercial Launch has been Shortlisted for Balloting,"+Environment.NewLine+
                                 "Please keep your Token / Form Number : "+ e.Row.Cells["FormNo"].Value.ToString() + " for future references.";
                    SendingSMS();
                }

            }
        }
        private void SearchGetComplete_Click()
        {
            try
            {
                SqlParameter[] param = {
                };
                DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "Launching.p_Gettbl_ApplicationFeeInfo_Complete", param);
                DGV_PayFormRece.DataSource = ds.Tables[0].DefaultView;
                foreach (var item in DGV_PayFormRece.Columns)
                {
                    item.BestFit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
        private void bgwSMSSendingComplete_DoWork(object sender, DoWorkEventArgs e)
        {
            SendSMS();
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
                MessageBox.Show("All SMS not Send, Some failed.");
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

        private void FinApplicationStatus_Load(object sender, EventArgs e)
        {
            RadPageViewPage pageToRemove = this.DGV_PaymentReceivebutApplicationData.Pages["CompleteApplication"];
            this.DGV_PaymentReceivebutApplicationData.Pages.Remove(pageToRemove);
        }

        private void btnValidForBalotingSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] param = {
                new SqlParameter("@ApplicantName", Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtApplicantNameCA.Text)),
                new SqlParameter("@CNIC_NICOP",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtCNIC_CA.Text)),
                new SqlParameter("@MobileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtMobileNoCA.Text)),
                new SqlParameter("@FormNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtFormNoCA.Text))
                };
                DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "Launching.p_Gettbl_ApplicationFeeInfo_ValidForBallotng", param);
                grdValidForBallting.DataSource = ds.Tables[0].DefaultView;
                foreach (var item in DGV_PayFormRece.Columns)
                {
                    item.BestFit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnsearchall_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkDate.CheckState == CheckState.Checked)
                {
                    DataLoadingDate();
                }
                else if (chkDate.CheckState == CheckState.Unchecked)
                {
                    DataLoading();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message+Environment.NewLine+ex.InnerException);
            }
           


           
        }
        private void DataLoadingDate()
        {
            SqlParameter[] param =
            {
                new SqlParameter("@FromDate",dtprfrom.Value.Date),
                new SqlParameter("@ToDate",dtprto.Value.Date)
            };
            DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "Launching.p_Gettbl_ApplicationInfoFilterByDate_All_Data", param);
            grddatasrch.DataSource = ds.Tables[0].DefaultView;
            foreach (var item in DGV_ApplicantSearch.Columns)
            {
                item.BestFit();
            }
        }
        private void DataLoading()
        {
            try
            {
                SqlParameter[] param = {
                new SqlParameter("@ApplicantName", Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtnamesrch.Text)),
                new SqlParameter("@CNIC_NICOP",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txt_cnicsrh.Text)),
                new SqlParameter("@MobileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtmbsrch.Text)),
                new SqlParameter("@FormNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtfrmno.Text)),
                new SqlParameter("@District",Helper.clsPluginHelper.DbNullIfNullOrEmpty(ApplicantDistrict.Text)),
                new SqlParameter("@Country",Helper.clsPluginHelper.DbNullIfNullOrEmpty(ApplicantCountry.Text)),
                new SqlParameter("@Gender",Helper.clsPluginHelper.DbNullIfNullOrEmpty(ApplicationGender.Text)),
                new SqlParameter("@Province",Helper.clsPluginHelper.DbNullIfNullOrEmpty(cbProvince.Text)),
                new SqlParameter("@Category",Helper.clsPluginHelper.DbNullIfNullOrEmpty(cbCategory.Text)),
                new SqlParameter("@ApplicationStatus",Helper.clsPluginHelper.DbNullIfNullOrEmpty(cmbStatus.Text))
                };
                DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "Launching.p_Gettbl_ApplicationFeeInfo_AllSearch", param);
                grddatasrch.DataSource = ds.Tables[0].DefaultView;
                foreach (var item in DGV_ApplicantSearch.Columns)
                {
                    item.BestFit();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void grdValidForBallting_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {

        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(grddatasrch);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Party Software First.\n Error -> \n" + ex.Message);
            }
        }

        private void btnexprt_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(DGV_IncompleteForms);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Party Software First.\n Error -> \n" + ex.Message);
            }
        }

        private void btnexpfp_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(DGV_PayFormRece);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Party Software First.\n Error -> \n" + ex.Message);
            }
        }

        private void btnexpotvb_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(grdValidForBallting);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Party Software First.\n Error -> \n" + ex.Message);
            }
        }

        private void btnexprtpuo_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(DGV_ApplicantSearch);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Party Software First.\n Error -> \n" + ex.Message);
            }
        }

        private void btnexprtavwp_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(grdScrutinyCompleted);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Party Software First.\n Error -> \n" + ex.Message);
            }
        }

        private void grddatasrch_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "btnVerification")
                   {
               
                        int applicaitonID = int.Parse(e.Row.Cells["ApplicationID"].Value.ToString());
                        ApplicationRecordModify obj = new ApplicationRecordModify(applicaitonID, "FinalVerification");
                        obj.ShowDialog();
                        DataLoading();
                
                   }
            }
            catch (Exception)
            {

            }
        }
    }
}
