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
    public partial class EnterNewApplication : Telerik.WinControls.UI.RadForm
    {
        private string mbNo { get; set; }
        private string MobileNoOline { get; set; }
        public EnterNewApplication()
        {
            InitializeComponent();
        }
        private string Category { get; set; }
        private string SubCategory { get; set; }
        private bool gpb { get; set; }
        private bool osp { get; set; }
        private bool rao { get; set; }
        private string Successsmssendingstatus { get; set; } = "";
        private string Failedsmssendingstatus { get; set; } = "";
        private string txtSMSType { get; set; }
        private string txtSMSType_onlinesctn { get; set; }
        private string txtSMSType_onlineobs { get; set; }
        private string txtMessage { get; set; }
        private string txtSMSType_ob { get; set; }
        private string txtMessage_ob { get; set; }
        private string txtMessage_onlinesctn { get; set; }
        private string txtMessage_onlineobs { get; set; }

        /*             
     * rdGeneralPublic = General Public 60%
     * rdServingArmedForcesPersons =Serving Armed Forces Persons 5%
     * rdRetdArmedForcesPersons = Retd  Armed Forces Persons 5%
     * rdDisabledPersons =Disabled Persons 2%
     * rdOverseasPakistanis =Overseas Pakistanis 3%
     * rdGovtEmployees =Govt Employees 5%
     * rdSeniorCitizens =Senior Citizens(above 65 Years of age) 5%
     * rdCiviliansPaidOutDefenceEstimates= Civilians Paid Out Defence Estimates 10%
     */

        private string CatgeorySelected()
        {
            if (rdGeneralPublic.CheckState == CheckState.Checked)
            {
                return rdGeneralPublic.Text;
            }
            else if (rdServingArmedForcesPersons.CheckState == CheckState.Checked)
            {
                return rdServingArmedForcesPersons.Text;
            }
            else if (rdOverseasPakistanis.CheckState == CheckState.Checked)
            {
                return rdOverseasPakistanis.Text;
            }
            else
            {
                return "Others";
            }
        }

        private string PlotSize()
        {
            if (rd4MarlaCom.CheckState == CheckState.Checked)
            {
                return rd4MarlaCom.Text;
            }
            else
            {
                return rd8MarlaCom.Text;
            }
        }
        private void EnterNewApplication_Load(object sender, EventArgs e)
        {
            rd4MarlaCom.CheckState = CheckState.Checked;
            rd4MarlaCom_ToggleStateChanged(null, null);
            cbgender.SelectedIndex = 0;
            ApplicantCountry.SelectedIndex = 0;
            //ApplicantDistrict.SelectedIndex = 0;
            ApplicantMobileNo.Mask = "00000000000";
            nokMobile.Mask = "00000000000";
            txtcnic_bankdetail.Mask = "00000-0000000-0";
            EnabledFalseOfCheckboxes();
            grpEligibilityCriteria.Enabled = false;
            cbProvince.SelectedIndex = 0;
            BankName.SelectedIndex = 0;
            txtAbroadAddress.Enabled = false;
            //BindProvincesData();
        }
        private void BindProvincesData()
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@Task","Province")
            };
            cbProvince.DataSource = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), 
                                    CommandType.StoredProcedure, "dbo.USP_tbl_DistrictAgainstProvince", 
                                    parameters);
            //cbProvince.DataSource = cls_dl_ChallanType.Challan_Reader(parameters, "App.USP_tbl_ChallanType").Tables[0].DefaultView;
            cbProvince.ValueMember = "Province";
            cbProvince.DisplayMember = "Province";

            //cbProvince.SelectedIndex = 0;

        }
    private void EnabledFalseOfCheckboxes()
        {
            chkoform.Enabled = false;
            chkocnic.Enabled = false;
            chkopassport.Enabled = false;
            chkonicop.Enabled = false;
            chkodischargebook.Enabled = false;
            btnOnlineSave.Enabled = false;
            btnSendToObservation.Enabled = false;
            chkeligibilitycero.Enabled = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(ApplicantDOB.Text != "")
            {

               if (ValidateBank() && ValidateMobileNo() && ValidateAppName() && ValidateAppFName() &&  ValidateAppCNIC() && ValidateMailAddress())
               {
                   mbNo = ApplicantMobileNo.Text;
                   SaveData("Pending");
               }

            }
            else
            {
                MessageBox.Show("Please Selcet Applicant Date of Birth.");
            }
        }
        private void SaveData(string strstatus)
        {
            #region Code
            try
            {
                if (ApplicantCNIC.Text == txtcnic_bankdetail.Text)
                {
                    ApplicantCNIC.BackColor = Color.White;
                    txtcnic_bankdetail.BackColor = Color.White;

                    string strcat;
                    if (rdbCate1.IsChecked) { strcat = "Category1"; } else if (rdbCate2.IsChecked) { strcat = "Category2"; } else { strcat = null; }
                    DateTime? rtddate;
                    if (dtpdateofretd.Text == "")
                    {
                        rtddate = null;
                    }
                    else
                    {
                        rtddate = dtpdateofretd.Value.Date;
                    }
                SqlParameter[] ApplicantInfo = {
                // new SqlParameter("@FormNo",),
                new SqlParameter("@Catergory",CatgeorySelected()),
                new SqlParameter("@PlotSize",PlotSize()),
                new SqlParameter("@ApplicantName",ApplicantName.Text),
                new SqlParameter("@Gender",cbgender.SelectedItem.ToString()),
                new SqlParameter("@FatherSODOWO",ApplicantFather.Text),
                new SqlParameter("@CNIC_NICOP",ApplicantCNIC.Text),
                new SqlParameter("@DoB",ApplicantDOB.DateTimePickerElement.Value),
                new SqlParameter("@PresentAddress",ApplicantPresentAddress.Text),
                new SqlParameter("@PermanentAddress",null),
                new SqlParameter("@AbroadAddress",txtAbroadAddress.Text),
                new SqlParameter("@City",ApplicantCity.Text),
                new SqlParameter("@District",ApplicantDistrict.Text == "" ? null : ApplicantDistrict.Text),
                new SqlParameter("@Country",ApplicantCountry.Text),
                new SqlParameter("@Email",ApplicantEmail.Text),
                new SqlParameter("@MobileNo",ApplicantMobileNo.Text),
                new SqlParameter("@DepositSlipNo",DepositSlipNo.Text),
                new SqlParameter("@BankName",BankName.SelectedItem.ToString()), 
                new SqlParameter("@BranchCode",Branch.Text),
                new SqlParameter("@PassportNo",ApplicantPassport.Text),
                new SqlParameter("@Amount",DepositAmount.Text),
                new SqlParameter("@ConnectionType",null),
                new SqlParameter("@ApplicationStatus",strstatus),
                new SqlParameter("@Remarks",  txtremarks.Text == "" ? "Form Entered by "+  clsUser.Name+" ("+DateTime.Now+") " : "Form Entered by "+  clsUser.Name+" ("+DateTime.Now+") " + Environment.NewLine +clsUser.Name+" ( "+DateTime.Now+" )-:-"+txtremarks.Text),
                new SqlParameter("@Insertby",clsUser.Name),
                new SqlParameter("@PANo",txtPANo.Text),
                new SqlParameter("@ArmRank",txtRank.Text),
                new SqlParameter("@Form",ckform.CheckState == CheckState.Checked? true : false)
                ,new SqlParameter("@CNICCopy",chkCNIC.CheckState == CheckState.Checked? true : false)
                ,new SqlParameter("@PassportCopy",chkPassport.CheckState == CheckState.Checked? true : false)
                ,new SqlParameter("@NicopCopy",chkNICOP.CheckState == CheckState.Checked? true : false)
                ,new SqlParameter("@ServiceCertificateCopy",chkServiceCertificate.CheckState == CheckState.Checked? true : false)
                ,new SqlParameter("@DischargeBookOrRetirementOrder",chkDischargeorRetirement.CheckState == CheckState.Checked? true : false)
                ,new SqlParameter("@DisableCerificate",chkDisabledPersons.CheckState == CheckState.Checked? true : false)
                ,new SqlParameter("@EligibilityCertificateForCat2Army",chkEligibilityCertificate.CheckState == CheckState.Checked? true : false)
                ,new SqlParameter("@Province",cbProvince.Text == "" ? null :cbProvince.Text )
                ,new SqlParameter("@DateRetd", rtddate )
                ,new SqlParameter("@NOKName",nokName.Text)
                ,new SqlParameter("@NOKSODOWO",drpnokrelation.SelectedItem.ToString())
                ,new SqlParameter("@CNICorNICOP",nokcnic.Text)
                ,new SqlParameter("@NOKMobile",nokMobile.Text)
                ,new SqlParameter("@NOKDob",dtpNOKDoB.Value.Date)
                ,new SqlParameter("@CategoryForArmyOffcr",strcat)
                //new SqlParameter("@InsertTime",),
                //new SqlParameter("@UpdateBy",),
                //new SqlParameter("@UpdateTime",),
                //new SqlParameter("@DeleteBy",),
                //new SqlParameter("@Deletetime",),
                //new SqlParameter("@ApplicationFeeID",),
                //new SqlParameter("@ResultCode",)
               };
                    DataSet Result = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "Launching.p_Savetbl_ApplicationInfo", ApplicantInfo);
                    if (Result.Tables.Count > 0)
                    {
                        if (Result.Tables[0].Rows.Count > 0)
                        {
                            //NewFormNo obj = new NewFormNo(Result.Tables[0].Rows[0]["Form_No"].ToString());
                            //obj.ShowDialog();
                            MessageBox.Show("Form Entered Successfully.Please write Form No. on Documents");

                           

                            lblFormNo.Text = Result.Tables[0].Rows[0]["Form_No"].ToString();
                            if(lblFormNo.Text != "#")
                            {
                                rgrpManualForm.Enabled = false;
                            }
                            if (strstatus == "Pending")
                            {
                                #region Send Message
                                txtSMSType = "";
                                txtMessage = "";
                                txtSMSType = "Commercial Launchig";
                                txtMessage = "Dear Applicant, Your application for DHAP Commercial Launch has been received and under process";
                                SendingSMS();
                                #endregion


                                #region save online
                                SaveDataOnline(Result.Tables[0].Rows[0]["Form_No"].ToString(),
                                         CatgeorySelected(),
                                         PlotSize(),
                                         ApplicantName.Text,
                                         ApplicantCNIC.Text,
                                         Convert.ToDateTime(ApplicantDOB.DateTimePickerElement.Value.ToString()),
                                         "Offline",
                                         "Under Process");
                                #endregion

                                ClearForm();
                            }
                            else if(strstatus == "Review")
                            {
                                #region Send Message
                                txtSMSType_ob = "";
                                txtMessage_ob = "";
                                txtSMSType_ob = "Commercial Launchig";
                                txtMessage_ob = "Dear Applicant,Your Application for DHAP Commercial Launch has been received, which has some discrepancies. " +
                                    "Please Contact at 03338118902 or 091-9223172 (9:00 AM To 05:00 PM)";
                                SendingSMS_Observation();
                                #endregion


                                #region save online
                                SaveDataOnline(Result.Tables[0].Rows[0]["Form_No"].ToString(),
                                         CatgeorySelected(),
                                         PlotSize(),
                                         ApplicantName.Text,
                                         ApplicantCNIC.Text,
                                         Convert.ToDateTime(ApplicantDOB.DateTimePickerElement.Value.ToString()),
                                         "Offline",
                                         "Under Observation");
                                #endregion

                                ClearForm();
                            }


                           

                        }  }else      {         }
                } else  {
                    MessageBox.Show("Your CNIC Does't Matched.");
                    ApplicantCNIC.BackColor = Color.Red;
                    txtcnic_bankdetail.BackColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion

        }
        private void SaveDataOnline(string farmno, string category, string plotsize,string name,
                                    string cnic,DateTime dob,string applystatus,string appliationstatus)
        {

            SqlParameter[] ApplicantInfoData =
                {
                // new SqlParameter("@FormNo",),
                new SqlParameter("@Catergory",category),
                new SqlParameter("@PlotSize",plotsize),
                new SqlParameter("@ApplicantName",name),
                new SqlParameter("@CNIC_NICOP",cnic),
                new SqlParameter("@DoB",dob),
                new SqlParameter("@FarmNo",farmno),
                new SqlParameter("@ApplyStatus",applystatus),
                new SqlParameter("@AppliationStatus",appliationstatus)
                };
            int Result = SQLHelper.ExecuteNonQuery
                            (SQLHelper.createConnection_DHADB(), CommandType.StoredProcedure,
                            "dbo.p_Savetbl_ApplicationInfo_DHADB", ApplicantInfoData);
            MessageBox.Show("Appliant Status is Updated Online.");


        }
        private void ClearForm()
        {
            //ApplicationCategory.SelectedIndex = 0;
           // PlotSize.SelectedIndex = 0;
            ApplicantName.Text = "";
           // ApplicantGender.SelectedIndex = 0;
            ApplicantFather.Text = "";
            ApplicantCNIC.Text = "";
            ApplicantDOB.DateTimePickerElement.Value = DateTime.Now;
            txtPANo.Text = "";
            txtRank.Text = "";
            ApplicantPassport.Text = "";
            ApplicantPresentAddress.Text = "";
          //  ApplicantPermanentAddress.Text = "";
            ApplicantCity.Text = "";
            ApplicantDistrict.Text = "";
            ApplicantCountry.SelectedIndex = 0;
            ApplicantEmail.Text = "";
            ApplicantMobileNo.Text = "";
            DepositSlipNo.Text = "";
            Branch.Text = "";
           
            // ApplicantConnectionType.SelectedIndex = 0;
            ///////////// NOK /////////////////
            nokName.Text = "";
            nokcnic.Text = "";
            nokMobile.Text = "";
            ///////////// Bank Detail ////////////////
            txtcnic_bankdetail.Text = "";
            Branch.Text = "";
            DepositSlipNo.Text = "";
           
            //////////////////////////////////////////
            cbProvince.SelectedIndex = 0;
            drpnokrelation.SelectedIndex = 0;
            BankName.SelectedIndex = 0;
            //NOKApplicantName.Text = "";
            //  NOKApplicantFather.Text = "";
            //  NOKCNIC.Text = "";
            //  NOKMobileNo.Text = "";
            // NOKDoB.DateTimePickerElement.Value = DateTime.Now;
            txtremarks.Text = "";

            ckform.CheckState = CheckState.Unchecked;
            chkCNIC.CheckState = CheckState.Unchecked;
            chkPassport.CheckState = CheckState.Unchecked;
            chkNICOP.CheckState = CheckState.Unchecked;
            chkDischargeorRetirement.CheckState = CheckState.Unchecked;
            chkEligibilityCertificate.CheckState = CheckState.Unchecked;


            rdGeneralPublic.CheckState = CheckState.Checked;
            rd4MarlaCom.CheckState = CheckState.Checked;
        }

        private void SendingSMS()
        {
            #region Code for SMS Sending
            SendSMSBluk.RunWorkerAsync();
            #endregion
        }
        private void SendingSMS_Observation()
        {
            #region Code for SMS Sending
            bgwForObservation.RunWorkerAsync();
            #endregion
        }


        private static string[] m_Patterns = new string[] {
                                                            @"^[0-9]{11}$",
                                                            @"^92[0-9]{10}$",
                                                            @"^\+92[0-9]{10}$"
                                                            };
        private static string[] m_Patterns_Observation = new string[] {
                                                            @"^[0-9]{11}$",
                                                            @"^92[0-9]{10}$",
                                                            @"^\+92[0-9]{10}$"
                                                            };
        private static string[] m_Patterns_onlinesctn = new string[] {
                                                            @"^[0-9]{11}$",
                                                            @"^92[0-9]{10}$",
                                                            @"^\+92[0-9]{10}$"
                                                            };
        private static string[] m_Patterns_onlineobs = new string[] {
                                                            @"^[0-9]{11}$",
                                                            @"^92[0-9]{10}$",
                                                            @"^\+92[0-9]{10}$"
                                                            };
        private static string MakeCombinedPattern()
        {
            return string.Join("|", m_Patterns
              .Select(item => "(" + item + ")"));
        }

        private static string MakeCombinedPattern_onlinesctn()
        {
            return string.Join("|", m_Patterns_onlinesctn
              .Select(item => "(" + item + ")"));
        }
        private static string MakeCombinedPattern_Observation()
        {
            return string.Join("|", m_Patterns_Observation
              .Select(item => "(" + item + ")"));
        }

        private static string MakeCombinedPattern_onlineobs()
        {
            return string.Join("|", m_Patterns_onlineobs
              .Select(item => "(" + item + ")"));
        }

        //private void SendSMS_Observation()
        //{
        //    try
        //    {

        //        //lblSendSlot.Text = sendstart.ToString();
        //        bool status = false;
        //        //foreach (GridViewRowInfo Row in DGVMObileData.Rows)
        //        //{
        //        if (Regex.IsMatch(mbNo, MakeCombinedPattern_Observation()))
        //        {
        //            //status = Helper.clsPluginHelper.SMSSEnding( Row.Cells["MobileNo"].Value.ToString(), txtMessage.Text);
        //            status = SMSSEndingNEW_Observation(mbNo, txtMessage_ob);

        //            if (status == true)
        //            {
        //                //sendsms = sendsms + 1;
        //                //lblSendSlot.Text = sendsms.ToString();

        //                //lblremainingSMS.Text = (totalRecord - sendsms).ToString();

        //                SqlParameter[] parameter = {
        //                 new SqlParameter("@Task","SaveHistoryInformationofSending"),
        //                 //new SqlParameter("@SendID",""),
        //                 new SqlParameter("@SMSType",txtSMSType),
        //                 new SqlParameter("@DateofSMS",DateTime.Now.ToString("yyyy-MM-dd")),
        //                 new SqlParameter("@Message",txtMessage),
        //                 new SqlParameter("@Status",status.ToString()),
        //                 new SqlParameter("@MobileNo",mbNo),
        //                 new SqlParameter("@UserName",clsUser.Name)
        //                 };
        //                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(),
        //                                                      CommandType.StoredProcedure,
        //                                                      "App.tbl_SMSSendingLog",
        //                                                      parameter);

        //                if (ds.Tables.Count > 0)
        //                {
        //                    if (ds.Tables[0].Rows.Count > 0)
        //                    {
        //                        string data = @"" + mbNo + "|" + txtSMSType_ob + "|" + txtMessage_ob + "|" + status.ToString() + "|" + clsUser.Name + DateTime.Now.ToString("dd/MMM/yyyy-hh:MM:ss tt") + "\n";
        //                        Helper.LibraryMessage.Log(data);
        //                    }
        //                }
        //            }

        //        }

        //        // }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        string data = ex.Message;
        //        Helper.LibraryMessage.Log(data);
        //    }

        //}


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

        private void SendSMS_Observation()
        {
            try
            {

                //lblSendSlot.Text = sendstart.ToString();
                bool status = false;
                //foreach (GridViewRowInfo Row in DGVMObileData.Rows)
                //{
                if (Regex.IsMatch(mbNo, MakeCombinedPattern_Observation()))
                {
                    //status = Helper.clsPluginHelper.SMSSEnding( Row.Cells["MobileNo"].Value.ToString(), txtMessage.Text);
                    status = SMSSEndingNEW_Observation(mbNo, txtMessage_ob);

                    if (status == true)
                    {
                        //sendsms = sendsms + 1;
                        //lblSendSlot.Text = sendsms.ToString();

                        //lblremainingSMS.Text = (totalRecord - sendsms).ToString();

                        SqlParameter[] parameter = {
                         new SqlParameter("@Task","SaveHistoryInformationofSending"),
                         //new SqlParameter("@SendID",""),
                         new SqlParameter("@SMSType",txtSMSType_ob),
                         new SqlParameter("@DateofSMS",DateTime.Now.ToString("yyyy-MM-dd")),
                         new SqlParameter("@Message",txtMessage_ob),
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
                                string data = @"" + mbNo + "|" + txtSMSType_ob + "|" + txtMessage_ob + "|" + status.ToString() + "|" + clsUser.Name + DateTime.Now.ToString("dd/MMM/yyyy-hh:MM:ss tt") + "\n";
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

        public bool SMSSEndingNEW_Observation(string MobileNo, string Message)
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


        private void rd4MarlaCom_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rd4MarlaCom.CheckState == CheckState.Checked)
            {
                DepositAmount.Text = "20000";
            }
        }

        private void rd8MarlaCom_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rd8MarlaCom.CheckState == CheckState.Checked)
            {
                DepositAmount.Text = "30000";
            }
        }

        public bool form { get; set; }
        public bool CNIC { get; set; }
        public bool DischargeorRetirement { get; set; }
        public bool NICOP { get; set; }
        public bool Passport { get; set; }
        public bool ServiceCertificate { get; set; }
        public bool Dischargeor_Retirement { get; set; }

        private void ChkDocumentControl()
        {

            /*
             * rdGeneralPublic
             * rdServingArmedForcesPersons
             * rdRetdArmedForcesPersons
             * rdDisabledPersons
             * rdOverseasPakistanis
             * rdGovtEmployees
             * rdSeniorCitizens
             * rdCiviliansPaidOutDefenceEstimates
             */
            if (rdDisabledPersons.CheckState == CheckState.Checked)
            {
                form = true;
                CNIC = true;
                chkCNIC.Enabled = true;
                chkDisabledPersons.Enabled = true;
                chkDischargeorRetirement.Enabled = false;
                chkNICOP.Enabled = false;
                chkPassport.Enabled = false;
                chkServiceCertificate.Enabled = false;
                chkDischargeorRetirement.Enabled = false;
            }
          else if (rdGeneralPublic.CheckState  == CheckState.Checked)
           {
                form = true;
                CNIC = true;

                chkCNIC.Enabled = true;
                chkDisabledPersons.Enabled = false;
                chkDischargeorRetirement.Enabled = false;
                chkNICOP.Enabled = false;
                chkPassport.Enabled = false;
                chkServiceCertificate.Enabled = false;
                chkDischargeorRetirement.Enabled = false;

            }
            else if (rdOverseasPakistanis.CheckState == CheckState.Checked)
            {
                form = true;
                NICOP = true;
                Passport = true;

                chkCNIC.Enabled = false;
                chkDisabledPersons.Enabled = false;
                chkDischargeorRetirement.Enabled = false;
                chkNICOP.Enabled = true;
                chkPassport.Enabled = true;
                chkServiceCertificate.Enabled = false;
                chkDischargeorRetirement.Enabled = false;
            }
            else if (rdServingArmedForcesPersons.CheckState == CheckState.Checked | rdRetdArmedForcesPersons.CheckState == CheckState.Checked)
            {
                form = true;
                CNIC = true;
                // ServiceCertificate = true;

                chkCNIC.Enabled = true;
                chkDisabledPersons.Enabled = false;
                chkDischargeorRetirement.Enabled = true;
                chkNICOP.Enabled = false;
                chkPassport.Enabled = false;
                chkServiceCertificate.Enabled = true;
                chkDischargeorRetirement.Enabled = false;
            }
            else if (rdGovtEmployees.CheckState == CheckState.Checked)
            {
                form = true;
                CNIC = true;
                ServiceCertificate = true;

                chkCNIC.Enabled = true;
                chkDisabledPersons.Enabled = false;
                chkDischargeorRetirement.Enabled = false;
                chkNICOP.Enabled = false;
                chkPassport.Enabled = false;
                chkServiceCertificate.Enabled = true;
                chkDischargeorRetirement.Enabled = false;
            }
            else if (rdCiviliansPaidOutDefenceEstimates.CheckState == CheckState.Checked)
            {
                form = true;
                CNIC = true;
                Dischargeor_Retirement = true;

                chkCNIC.Enabled = true;
                chkDisabledPersons.Enabled = false;
                chkDischargeorRetirement.Enabled = false;
                chkNICOP.Enabled = false;
                chkPassport.Enabled = false;
                chkServiceCertificate.Enabled = false;
                chkDischargeorRetirement.Enabled = true;
            }
            else if (rdSeniorCitizens.CheckState == CheckState.Checked)
            {
                form = true;
                CNIC = true;

                chkCNIC.Enabled = true;
                chkDisabledPersons.Enabled = false;
                chkDischargeorRetirement.Enabled = false;
                chkNICOP.Enabled = false;
                chkPassport.Enabled = false;
                chkServiceCertificate.Enabled = false;
                chkDischargeorRetirement.Enabled = false;
            }
            else
            {
                MessageBox.Show("Invalid Category");
            }
        }

        private void rdGeneralPublic_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            ChkDocumentControl();
        }

        private void rdServingArmedForcesPersons_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            ChkDocumentControl();
        }

        private void rdRetdArmedForcesPersons_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            ChkDocumentControl();
        }

        private void rdDisabledPersons_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            ChkDocumentControl();
        }

        private void rdOverseasPakistanis_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            ChkDocumentControl();
        }

        private void rdGovtEmployees_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            ChkDocumentControl();
        }

        private void rdSeniorCitizens_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            ChkDocumentControl();
        }

        private void rdCiviliansPaidOutDefenceEstimates_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            ChkDocumentControl();
        }

        private void rdGeneralPublic_CheckStateChanged(object sender, EventArgs e)
        {
            if (rdGeneralPublic.IsChecked)
            {
                txtPANo.Enabled = false;
                txtRank.Enabled = false;
                ApplicantPassport.Enabled = false;
                txtAbroadAddress.Enabled = false;
                dtpdateofretd.Enabled = false;
                lblpakabrd.Text = "";
                txtPANo.Text = "NA";
                txtRank.Text = "NA";
                ApplicantPassport.Text = "NA";
                ApplicantCNIC.Mask = "00000-0000000-0";
                nokcnic.Mask = "00000-0000000-0";
                txtcnic_bankdetail.Mask = "00000-0000000-0";

                ckform.Enabled = true;
                chkCNIC.Enabled = true;
                ckform.ForeColor = Color.Red;
                chkCNIC.ForeColor = Color.Red;

                chkDischargeorRetirement.Enabled = false;
                chkPassport.Enabled = false;
                chkNICOP.Enabled = false;
                chkEligibilityCertificate.Enabled = false;

                grpEligibilityCriteria.Enabled = false;
                rdbCate1.CheckState = CheckState.Unchecked;
                rdbCate2.CheckState = CheckState.Unchecked;
                ApplicantMobileNo.Mask = "00000000000";



            }
            
        }

        private void rdServingArmedForcesPersons_CheckStateChanged(object sender, EventArgs e)
        {
            if (rdServingArmedForcesPersons.IsChecked)
            {
                grpEligibilityCriteria.Enabled = true;
                rdbCate1.CheckState = CheckState.Checked;
                txtPANo.Enabled = true;
                txtRank.Enabled = true;
                ApplicantPassport.Enabled = false;
                txtAbroadAddress.Enabled = false;
                dtpdateofretd.Enabled = true;
                lblpakabrd.Text = "";
                ApplicantPassport.Text = "NA";
                txtPANo.Text = "";
                txtRank.Text = "";
                ApplicantCNIC.Mask = "00000-0000000-0";
                nokcnic.Mask = "00000-0000000-0";
                txtcnic_bankdetail.Mask = "00000-0000000-0";

                ckform.Enabled = true;
                chkCNIC.Enabled = true;
                chkDischargeorRetirement.Enabled = true;
                chkEligibilityCertificate.Enabled = true;

                ckform.ForeColor = Color.Red;
                chkCNIC.ForeColor = Color.Red;
                chkDischargeorRetirement.ForeColor = Color.Red;
                chkEligibilityCertificate.ForeColor = Color.Red;

                chkPassport.Enabled = false;
                chkNICOP.Enabled = false;
                ApplicantMobileNo.Mask = "00000000000";
                //chkEligibilityCertificate.Enabled = false;
            }
            
        }

        private void rdOverseasPakistanis_CheckStateChanged(object sender, EventArgs e)
        {
            if (rdOverseasPakistanis.IsChecked)
            {
                txtPANo.Enabled = false;
                txtRank.Enabled = false;
                ApplicantPassport.Enabled = true;
                txtAbroadAddress.Enabled = true;
                dtpdateofretd.Enabled = true;
                lblpakabrd.Text = "(Pakistan/Abroad)";
                txtPANo.Text = "NA";
                txtRank.Text = "NA";
                ApplicantPassport.Text = "";
                ApplicantCNIC.Mask = "000000-000000-0";
                nokcnic.Mask = "000000-000000-0";
                txtcnic_bankdetail.Mask = "000000-000000-0";
                ApplicantMobileNo.Mask = null;

                ckform.Enabled = true;
                chkCNIC.Enabled = true;
                chkPassport.Enabled = true;
                chkNICOP.Enabled = true;

                ckform.ForeColor = Color.Red;
                chkCNIC.ForeColor = Color.Red;
                chkPassport.ForeColor = Color.Red;
                chkNICOP.ForeColor = Color.Red;

                chkDischargeorRetirement.Enabled = false;
                chkEligibilityCertificate.Enabled = false;

                grpEligibilityCriteria.Enabled = false;
                rdbCate1.CheckState = CheckState.Unchecked;
                rdbCate2.CheckState = CheckState.Unchecked;

               
            }
           
        }

        private void btnOnlineSave_Click(object sender, EventArgs e)
        {
            MobileNoOline = txtmbn.Text.Trim();
            SendToScrutiny("Pending");
        }
        private void SendSMS_OnlineSctn()
        {
            try
            {

                //lblSendSlot.Text = sendstart.ToString();
                bool status = false;
                //foreach (GridViewRowInfo Row in DGVMObileData.Rows)
                //{
                if (Regex.IsMatch(MobileNoOline, MakeCombinedPattern_onlinesctn()))
                {
                    //status = Helper.clsPluginHelper.SMSSEnding( Row.Cells["MobileNo"].Value.ToString(), txtMessage.Text);
                    status = SMSSEndingNEW_onlinsctn(MobileNoOline, txtMessage_onlinesctn);

                    if (status == true)
                    {
                        //sendsms = sendsms + 1;
                        //lblSendSlot.Text = sendsms.ToString();

                        //lblremainingSMS.Text = (totalRecord - sendsms).ToString();

                        SqlParameter[] parameter = {
                         new SqlParameter("@Task","SaveHistoryInformationofSending"),
                         //new SqlParameter("@SendID",""),
                         new SqlParameter("@SMSType",txtSMSType_onlinesctn),
                         new SqlParameter("@DateofSMS",DateTime.Now.ToString("yyyy-MM-dd")),
                         new SqlParameter("@Message",txtMessage_onlinesctn),
                         new SqlParameter("@Status",status.ToString()),
                         new SqlParameter("@MobileNo",MobileNoOline),
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
                                string data = @"" + MobileNoOline + "|" + txtSMSType_onlinesctn + "|" + txtMessage_onlinesctn + "|" + status.ToString() + "|" + clsUser.Name + DateTime.Now.ToString("dd/MMM/yyyy-hh:MM:ss tt") + "\n";
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
        public bool SMSSEndingNEW_onlinsctn(string MobileNo, string Message)
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
        private void SendToScrutiny(string status)
        {
            try
            {
                SqlParameter[] ApplicantInfo =
                {
                    new SqlParameter("@FormNo",txtOnlineFormNo.Text.Trim()),
                    new SqlParameter("@Form",chkoform.CheckState == CheckState.Checked? true : false),
                    new SqlParameter("@CNICCopy",chkocnic.CheckState == CheckState.Checked? true : false),
                    new SqlParameter("@PassportCopy",chkopassport.CheckState == CheckState.Checked? true : false),
                    new SqlParameter("@NicopCopy",chkonicop.CheckState == CheckState.Checked? true : false),
                    new SqlParameter("@DischargeBookOrRetirementOrder",chkodischargebook.CheckState == CheckState.Checked? true : false),
                    new SqlParameter("@EligibilityCertificateForCat2Army",chkeligibilitycero.CheckState == CheckState.Checked? true : false),
                    new SqlParameter("@ApplicationStatus",status),
                    new SqlParameter("@Remarks", txtremarksapp.Text == "" ? "Form Entered by "+  clsUser.Name+" ("+DateTime.Now+") " : "Form Entered by "+  clsUser.Name+" ("+DateTime.Now+") " + Environment.NewLine +clsUser.Name+" ( "+DateTime.Now+" )-:-"+txtremarksapp.Text),//txtremarksapp.Text)
                    new SqlParameter("@Insertby",clsUser.Name)
                };
                int Result = SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(),
                    CommandType.StoredProcedure, "Launching.p_Savetbl_ApplicationInfo_From_OnlineTbl",
                    ApplicantInfo);
                if (Result > 0)
                {
                    if(status == "Pending")
                    {
                        MessageBox.Show("Online Form Downloaded and Moved to Scrutiny.");
                        #region save online
                        SaveDataOnline(txtOnlineFormNo.Text.Trim(),
                                 lblocategory.Text,
                                 txtplts.Text,
                                 txtnameapp.Text,
                                 txtocnic.Text,
                                 Convert.ToDateTime(txtdob.Text),
                                 "Online",
                                 "Under Process");
                        #endregion

                        txtSMSType_onlinesctn = "";
                        txtMessage_onlinesctn = "";
                        txtSMSType_onlinesctn = "Commercial Launching";
                        txtMessage_onlinesctn = "Dear Applicant, Your application for DHAP Commercial Launch has been received and under process";

                        SendingSMS_Onl_Sctn();
                        //Send.SMS();
                    }
                    else if (status == "Review")
                    {
                        MessageBox.Show("Online Form Downloaded and Moved To Observation.");

                        #region save online
                        SaveDataOnline(txtOnlineFormNo.Text.Trim(),
                                 lblocategory.Text,
                                 txtplts.Text,
                                 txtnameapp.Text,
                                 txtocnic.Text,
                                 Convert.ToDateTime(txtdob.Text),
                                 "Online",
                                 "Under Observation");
                        #endregion

                        txtSMSType_onlineobs = "";
                        txtMessage_onlineobs = "";
                        txtSMSType_onlineobs = "Commercial Launchig";
                        txtMessage_onlineobs = "Dear Applicant,Your Application for DHAP Commercial Launch has been received, which has some discrepancies. " +
                            "Please Contact at 03338118902 or 091-9223172 (9:00 AM To 05:00 PM)";
                        SendingSMS_Onl_Obs();
                        //Send.SMS();
                    }
                    btnOnlineSave.Enabled = false;
                    txtOnlineFormNo.Text = "";
                    txtnameapp.Text = "";
                    txtocnic.Text = "";
                    lblocategory.Text = ".";
                    lblsubcat.Text = ".";
                    txtonlinechallanno.Text = "";
                    txtplts.Text = "";
                    txtfsw.Text = "";
                    txtmbn.Text = "";
                    txtdob.Text = "";
                    txtpanoapp.Text = "";
                    txtarmrank.Text = "";
                    txtdtrtd.Text = "";
                    txtpassport.Text = "";
                    txtremarksapp.Text = "";
                    txtBankName.Text = "";
                    txtcnicbank.Text = "";
                    Amountbank.Text = "";
                    txtacountno.Text = "";
                    txtbranchcode.Text = "";
                    txtpaymntmode.Text = "";

                    chkoform.CheckState = CheckState.Unchecked;
                    chkocnic.CheckState = CheckState.Unchecked;
                    chkopassport.CheckState = CheckState.Unchecked;
                    chkonicop.CheckState = CheckState.Unchecked;
                    chkodischargebook.CheckState = CheckState.Unchecked;
                    chkeligibilitycero.CheckState = CheckState.Unchecked;




                }
                else
                {
                    MessageBox.Show("Form is already Saved OR Error in Insertion.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SendingSMS_Onl_Sctn()
        {
            #region Code for SMS Sending
            bgwOnlineSctn.RunWorkerAsync();
            #endregion
        }
        private void SendingSMS_Onl_Obs()
        {
            #region Code for SMS Sending
            bgwOnlineObservation.RunWorkerAsync();
            #endregion
        }
        private void btnVerifyonlineata_Click(object sender, EventArgs e)
        {
            SqlParameter[] ApplicantInfo =
            {
              new SqlParameter("@FormNo",txtOnlineFormNo.Text.Trim()),
              new SqlParameter("@ChallanNo",txtonlinechallanno.Text.Trim())
            };
            DataSet dst = SQLHelper.ExecuteDataset(
                                   SQLHelper.createConnection(),
                                   CommandType.StoredProcedure, "Launching.p_Gettbl_ApplicationInfo_tbl_Online",
                                   ApplicantInfo);
            if(dst.Tables.Count > 0)
            {
                if(dst.Tables[0].Rows.Count > 0)
                {
                    Category = dst.Tables[0].Rows[0]["Catergory"].ToString();
                    SubCategory = dst.Tables[0].Rows[0]["EligibilityCategoryForRetiredArmyOff"].ToString();
                    lblocategory.Text = Category;
                    lblsubcat.Text = SubCategory;

                    txtnameapp.Text = dst.Tables[0].Rows[0]["ApplicantName"].ToString();
                    txtocnic.Text =  dst.Tables[0].Rows[0]["CNIC_NICOP"].ToString();
                    txtplts.Text = dst.Tables[0].Rows[0]["PlotSize"].ToString();
                    txtfsw.Text = dst.Tables[0].Rows[0]["FatherSODOWO"].ToString();
                    txtmbn.Text = dst.Tables[0].Rows[0]["MobileNo"].ToString();
                    txtdob.Text = dst.Tables[0].Rows[0]["DoB"].ToString();
                    txtpanoapp.Text = dst.Tables[0].Rows[0]["PA_Number"].ToString();
                    txtarmrank.Text = dst.Tables[0].Rows[0]["Arm_Rank"].ToString();
                    txtdtrtd.Text = dst.Tables[0].Rows[0]["DoR"].ToString();
                    txtpassport.Text = dst.Tables[0].Rows[0]["PassportNo"].ToString();


                    txtBankName.Text = dst.Tables[0].Rows[0]["BankName"].ToString();
                    txtcnicbank.Text = dst.Tables[0].Rows[0]["CNIC"].ToString();
                    Amountbank.Text = dst.Tables[0].Rows[0]["BankAmount"].ToString();
                    txtacountno.Text = dst.Tables[0].Rows[0]["AccountNo"].ToString();
                    txtbranchcode.Text = dst.Tables[0].Rows[0]["BranchCode"].ToString();
                    txtpaymntmode.Text = dst.Tables[0].Rows[0]["PaymentMode"].ToString();

                    if (Category == "General Public")
                    {
                        chkoform.Enabled = true;
                        chkocnic.Enabled = true;

                        chkoform.ForeColor = Color.Red;
                        chkocnic.ForeColor = Color.Red;

                        chkopassport.Enabled = false;
                        chkonicop.Enabled = false;
                        chkodischargebook.Enabled = false;
                        chkeligibilitycero.Enabled = false;


                    }
                    else if(Category == "Retired Army Officers" )
                    {
                        chkoform.Enabled = true;
                        chkocnic.Enabled = true;
                        chkopassport.Enabled = false;
                        chkonicop.Enabled = false;
                        chkodischargebook.Enabled = true;
                        chkeligibilitycero.Enabled = true;


                        chkoform.ForeColor = Color.Red;
                        chkocnic.ForeColor = Color.Red;
                        chkodischargebook.ForeColor = Color.Red;
                        chkeligibilitycero.ForeColor = Color.Red;


                    }
                    //else if (Category == "Retired Army Officers" && SubCategory == "Category1")
                    //{
                    //    chkoform.Enabled = true;
                    //    chkocnic.Enabled = true;
                    //    chkopassport.Enabled = false;
                    //    chkonicop.Enabled = false;
                    //    chkodischargebook.Enabled = true;
                    //    chkeligibilitycero.Enabled = false;
                    //}
                    else if(Category == "Overseas Pakistanis")
                    {
                        chkoform.Enabled = true;
                        chkocnic.Enabled = true;
                        chkopassport.Enabled = true;
                        chkonicop.Enabled = true;
                        chkodischargebook.Enabled = false;
                        chkeligibilitycero.Enabled = false;

                        chkoform.ForeColor = Color.Red;
                        chkocnic.ForeColor = Color.Red;
                        chkopassport.ForeColor = Color.Red;
                        chkonicop.ForeColor = Color.Red;


                    }
                    btnOnlineSave.Enabled = true;
                    btnSendToObservation.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Data Not Found.");
                    EnabledFalseOfCheckboxes();
                }
            }
            else
            {
                MessageBox.Show("Data Not Found.");
                EnabledFalseOfCheckboxes();
            }

        }

        private void chkDischargeorRetirement_CheckedChanged(object sender, EventArgs e)
        {

        }

      

        private void txtcnic_bankdetail_Leave(object sender, EventArgs e)
        {
            if(ApplicantCNIC.Text != txtcnic_bankdetail.Text)
            {
                MessageBox.Show("Your CNIC Does't Matched.");
                btnSave.Enabled = false;
                btnSentToObservation.Enabled = false;
                ApplicantCNIC.BackColor = Color.Red;
                txtcnic_bankdetail.BackColor = Color.Red;
            }
            else
            {
                ApplicantCNIC.BackColor = Color.White;
                txtcnic_bankdetail.BackColor = Color.White;
                btnSave.Enabled = true;
                btnSentToObservation.Enabled = true;
            }
           
        }

        private void rdbCate2_CheckStateChanged(object sender, EventArgs e)
        {
            //if(rdbCate2.CheckState == CheckState.Checked)
            //{
            //    chkEligibilityCertificate.Enabled = true;
            //}
            //else
            //{
            //    chkEligibilityCertificate.Enabled = false;
            //}
        }

        private void rdbCate1_CheckStateChanged(object sender, EventArgs e)
        {
            //if (rdbCate1.CheckState == CheckState.Checked)
            //{
            //    chkEligibilityCertificate.Enabled = false;
            //}
        }

        private void btnSentToObservation_Click(object sender, EventArgs e)
        {
            if(ApplicantDOB.Text != "")
            {

                if (ValidateBank() && ValidateMobileNo() && ValidateAppName() && ValidateAppFName() && ValidateAppCNIC() && ValidateMailAddress())
                {
                    mbNo = ApplicantMobileNo.Text;
                    SaveData("Review");
                }
            }

            else
            {
                MessageBox.Show("Please Selcet Applicant Date of Birth.");
            }
}

        private void ApplicantMobileNo_Validating(object sender, CancelEventArgs e)
        {
            ValidateMobileNo();
        }
        private bool ValidateMobileNo()
        {
            
            bool bStatus = true;
            if(rdOverseasPakistanis.CheckState == CheckState.Unchecked)
            {
                if (ApplicantMobileNo.Text == "" || ApplicantMobileNo.Text.Length != 11)
                {
                    erpforApplicants.SetError(ApplicantMobileNo, "Please Enter Valid Mobile No.");
                    bStatus = false;
                }
                else
                    erpforApplicants.SetError(ApplicantMobileNo, "");
                bStatus = true;
            }
            else
            {
                bStatus = true;
            }
            return bStatus;
        }

        private void bgwForObservation_DoWork(object sender, DoWorkEventArgs e)
        {
            SendSMS_Observation();
        }

        private void bgwForObservation_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

        private void chkFormNo_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkFormNo.CheckState == CheckState.Checked)
            {
                lblFormNo.Text = "#";
                rgrpManualForm.Enabled = true;
                chkFormNo.CheckState = CheckState.Unchecked;
            }
        }

        private void ApplicantName_Validating(object sender, CancelEventArgs e)
        {
            ValidateAppName();
        }
        private bool ValidateAppName()
        {
            bool bStatus = true;
            if (ApplicantName.Text == "" || ApplicantName.Text.Length < 3)
            {
                erpforApplicants.SetError(ApplicantName, "Please Enter Applicant Name.");
                bStatus = false;
            }
            else
                erpforApplicants.SetError(ApplicantName, "");
            return bStatus;
        }

        private void ApplicantFather_Validating(object sender, CancelEventArgs e)
        {
            ValidateAppFName();
        }
        private bool ValidateAppFName()
        {
            bool bStatus = true;
            if (ApplicantFather.Text == "" || ApplicantFather.Text.Length < 3)
            {
                erpforApplicants.SetError(ApplicantFather, "Please Enter Applicant Father Name.");
                bStatus = false;
            }
            else
                erpforApplicants.SetError(ApplicantFather, "");
            return bStatus;
        }

        private void ApplicantCNIC_Validating(object sender, CancelEventArgs e)
        {
            ValidateAppCNIC();
        }
        private bool ValidateAppCNIC()
        {
            bool bStatus = true;
            if (ApplicantCNIC.Text == "" || ApplicantCNIC.Text.Length < 15)
            {
                erpforApplicants.SetError(ApplicantCNIC, "Please Enter Valid CNIC / NICOP.");
                bStatus = false;
            }
            else
                erpforApplicants.SetError(ApplicantCNIC, "");
            return bStatus;
        }

        private void ApplicantPresentAddress_Validating(object sender, CancelEventArgs e)
        {
            ValidateMailAddress();
        }

        private bool ValidateMailAddress()
        {
            bool bStatus = true;
            if (ApplicantPresentAddress.Text == "" )
            {
                erpforApplicants.SetError(ApplicantPresentAddress, "Please Enter Mailling Address.");
                bStatus = false;
            }
            else
                erpforApplicants.SetError(ApplicantPresentAddress, "");
            return bStatus;
        }

        private void cbProvince_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

            try
            {
                if (ApplicantDistrict.Items.Count > 0)
                {
                    ApplicantDistrict.Items.Clear();
                }
                RadListDataItem Select = new RadListDataItem();
                Select.Value = 0;
                Select.Text = "-- Select --";
                this.ApplicantDistrict.Items.Add(Select);
                SqlParameter[] param =
                {
                new SqlParameter("@Task", "District"),
                new SqlParameter("@Province",cbProvince.SelectedItem.ToString())
                };
                DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(),
                                        CommandType.StoredProcedure, "dbo.USP_tbl_DistrictAgainstProvince",
                                        param);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    RadListDataItem dataItem = new RadListDataItem();
                    dataItem.Value = row["Sr_No"].ToString();
                    dataItem.Text = row["District"].ToString();
                    this.ApplicantDistrict.Items.Add(dataItem);
                }
                ApplicantDistrict.SelectedIndex = 0;



                //SqlParameter[] parameters =
                //{
                //new SqlParameter("@Task","District"),
                //new SqlParameter("@Province",cbProvince.SelectedItem.ToString())
                //};
                //ApplicantDistrict.DataSource = SQLHelper.ExecuteDataset(SQLHelper.createConnection(),
                //                        CommandType.StoredProcedure, "dbo.USP_tbl_DistrictAgainstProvince",
                //                        parameters);
                //ApplicantDistrict.ValueMember = "District"; 
                //ApplicantDistrict.DisplayMember = "Sr_No";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void BankName_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            ValidateBank();
        }
        private bool ValidateBank()
        {
            bool boolFormValid = true;
            if (BankName.SelectedItem.ToString() == "")
            {
                erpforApplicants.SetError(BankName, "Please Select Bank Name.");
                boolFormValid = false;
                
            }
            else
            {
                erpforApplicants.SetError(BankName, "");
                boolFormValid = true;
            }
            return boolFormValid;
        }

        private void txtcnic_bankdetail_Validating(object sender, CancelEventArgs e)
        {
            ValidateCNICApplicantDeposit();
        }
        private bool ValidateCNICApplicantDeposit()
        {
            bool boolFormValid = true;
            if (txtcnic_bankdetail.Text == "")
            {
                erpforApplicants.SetError(txtcnic_bankdetail, "Please Enter CNIC.");
                boolFormValid = false;

            }
            else
            {
                erpforApplicants.SetError(txtcnic_bankdetail, "");
                boolFormValid = true;
            }
            return boolFormValid;
        }

        private void btnSendToObservation_Click(object sender, EventArgs e)
        {
            MobileNoOline = txtmbn.Text.Trim();
            SendToScrutiny("Review");
        }

        private void bgwOnlineSctn_DoWork(object sender, DoWorkEventArgs e)
        {
            SendSMS_OnlineSctn();
        }

        private void bgwOnlineSctn_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

        private void bgwOnlineObservation_DoWork(object sender, DoWorkEventArgs e)
        {
            SendSMS_OnlineObs();
        }

        private void bgwOnlineObservation_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
        private void SendSMS_OnlineObs()
        {
            try
            {

                //lblSendSlot.Text = sendstart.ToString();
                bool status = false;
                //foreach (GridViewRowInfo Row in DGVMObileData.Rows)
                //{
                if (Regex.IsMatch(MobileNoOline, MakeCombinedPattern_onlineobs()))
                {
                    //status = Helper.clsPluginHelper.SMSSEnding( Row.Cells["MobileNo"].Value.ToString(), txtMessage.Text);
                    status = SMSSEndingNEW_onlineobs(MobileNoOline, txtMessage_onlineobs);

                    if (status == true)
                    {
                        //sendsms = sendsms + 1;
                        //lblSendSlot.Text = sendsms.ToString();

                        //lblremainingSMS.Text = (totalRecord - sendsms).ToString();

                        SqlParameter[] parameter = {
                         new SqlParameter("@Task","SaveHistoryInformationofSending"),
                         //new SqlParameter("@SendID",""),
                         new SqlParameter("@SMSType",txtSMSType_onlineobs),
                         new SqlParameter("@DateofSMS",DateTime.Now.ToString("yyyy-MM-dd")),
                         new SqlParameter("@Message",txtMessage_onlineobs),
                         new SqlParameter("@Status",status.ToString()),
                         new SqlParameter("@MobileNo",MobileNoOline),
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
                                string data = @"" + MobileNoOline + "|" + txtSMSType_onlineobs + "|" + txtMessage_onlineobs + "|" + status.ToString() + "|" + clsUser.Name + DateTime.Now.ToString("dd/MMM/yyyy-hh:MM:ss tt") + "\n";
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

        public bool SMSSEndingNEW_onlineobs(string MobileNo, string Message)
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
        /*    private bool FileValid()
{
bool status = false;
if (rdDisabledPersons.CheckState == CheckState.Checked)
{
if (form == true & CNIC == true)
{

}
}
if (rdGeneralPublic.CheckState == CheckState.Checked)
{
if (form == true & CNIC == true)
status = true;
}
else if (rdOverseasPakistanis.CheckState == CheckState.Checked)
{
if (form == true & NICOP == true & Passport == true)
status = true;
}
else if (rdServingArmedForcesPersons.CheckState == CheckState.Checked | rdRetdArmedForcesPersons.CheckState == CheckState.Checked)
{
if (form == true | CNIC == true | ServiceCertificate == true)
status = true;
}
else if (rdGovtEmployees.CheckState == CheckState.Checked)
{
if (form == true | CNIC == true | ServiceCertificate == true)
status = true;
}
else if (rdCiviliansPaidOutDefenceEstimates.CheckState == CheckState.Checked)
{
if (form == true | CNIC == true | Dischargeor_Retirement == true)
status = true;
}
else if (rdSeniorCitizens.CheckState == CheckState.Checked)
{
if (form == true | CNIC == true)
status = true;
}
else
{
status = false;
}
return status;
}*/
    }
}
