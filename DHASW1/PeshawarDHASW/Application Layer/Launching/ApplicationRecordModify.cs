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
    public partial class ApplicationRecordModify : Telerik.WinControls.UI.RadForm
    {
        public ApplicationRecordModify()
        {
            InitializeComponent();
        }
        private string txtSMSType { get; set; }
        private string txtMessage { get; set; }
        private string Successsmssendingstatus { get; set; } = "";
        private string Failedsmssendingstatus { get; set; } = "";
        private string mbNo { get; set; }
        public int Application_ID { get; set; }
        private DataSet ds { get; set; }
        private string ApplictnSts { get; set; }
        public ApplicationRecordModify(int ApplicationID,string appstatus)
        {
            InitializeComponent();
            Application_ID = ApplicationID;
            ApplictnSts = appstatus;
        }
        private void ApplicationRecordModify_Load(object sender, EventArgs e)
        {
            try
            {
                string storproc = "";
                if(ApplictnSts == "ScrutinyCompleted")
                {
                    storproc = "Launching.p_Gettbl_ApplicationInfo";
                    btnFInalVerification.Enabled = false;
                }
                else if (ApplictnSts == "Pending")
                {
                    storproc = "Launching.p_Gettbl_ApplicationInfoForObservation";
                    btnSave.Text = "Send To Scrutiny";
                    btnSendtoObservation.Text = "Still in Observation";
                    btnFInalVerification.Enabled = false;
                }
                else if (ApplictnSts == "FinalVerification")
                {
                    storproc = "Launching.p_GetApplicationInfoFinalApproval";
                    ApplicantCNIC.Enabled = false;
                    PlotSize.Enabled = false;
                    DepositAmount.Enabled = false;
                    btnSave.Enabled = false;
                    btnSendtoObservation.Enabled = false;
                }

                SqlParameter[] param = {  new SqlParameter("@ApplicationID", Application_ID)  };
                ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, storproc, param);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //foreach (DataRow item in ds.Tables[0].Rows[0])
                        //{
                        //Application Info
                        if(ds.Tables[0].Rows[0]["DateRetd"].ToString() == "")
                        {
                            dtpdateofretd.SetToNullValue();
                        }
                        else
                        {
                            dtpdateofretd.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["DateRetd"].ToString());
                        }
                            
                           // ) ? DateTime.Parse(ds.Tables[0].Rows[0]["DateRetd"].ToString()) : DateTime.Now;



                            lblFormNo.Text = ds.Tables[0].Rows[0]["FormNo"].ToString();
                            ApplicationCategory.Text = ds.Tables[0].Rows[0]["Catergory"].ToString();
                            
                            PlotSize.SelectedIndex = PlotSize.FindString(ds.Tables[0].Rows[0]["PlotSize"].ToString());
                            BankName.SelectedIndex = BankName.FindString(ds.Tables[0].Rows[0]["BankName"].ToString());
                            //PlotSize.Text = ds.Tables[0].Rows[0]["PlotSize"].ToString();
                            ApplicantName.Text = ds.Tables[0].Rows[0]["ApplicantName"].ToString();
                            ApplicantGender.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
                            ApplicantFather.Text = ds.Tables[0].Rows[0]["FatherSODOWO"].ToString();
                            ApplicantCNIC.Text = ds.Tables[0].Rows[0]["CNIC_NICOP"].ToString();  
                            ApplicantPassport.Text = ds.Tables[0].Rows[0]["PassportNo"].ToString();
                            ApplicantDOB.DateTimePickerElement.Value = DateTime.Parse(ds.Tables[0].Rows[0]["DoB"].ToString());
                            txtPANo.Text = ds.Tables[0].Rows[0]["PANo"].ToString();
                            txtRank.Text = ds.Tables[0].Rows[0]["ArmRank"].ToString();
                            //dtpdateofretd.DateTimePickerElement.Value = !string.IsNullOrWhiteSpace(ds.Tables[0].Rows[0]["DateRetd"].ToString())? DateTime.Parse(ds.Tables[0].Rows[0]["DateRetd"].ToString()):DateTime.Now;
                            ApplicantPresentAddress.Text = ds.Tables[0].Rows[0]["PresentAddress"].ToString();
                            ApplicantPermanentAddress.Text = ds.Tables[0].Rows[0]["PermanentAddress"].ToString();
                            ApplicantCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
                            cbProvince.Text = ds.Tables[0].Rows[0]["Province"].ToString();
                            ApplicantDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                            ApplicantCountry.Text = ds.Tables[0].Rows[0]["Country"].ToString();
                            ApplicantEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                            ApplicantMobileNo.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                            // Bank Slip Info
                            DepositSlipNo.Text = ds.Tables[0].Rows[0]["DepositSlipNo"].ToString();
                            BankName.Text = ds.Tables[0].Rows[0]["BankName"].ToString();
                            Branch.Text = ds.Tables[0].Rows[0]["BranchCode"].ToString();
                            DepositAmount.Text = ds.Tables[0].Rows[0]["Amount"].ToString();
                            ApplicantConnectionType.Text = ds.Tables[0].Rows[0]["ConnectionType"].ToString(); 
                            // Nok info
                            NOKApplicantName.Text = ds.Tables[0].Rows[0]["NOKName"].ToString();
                            NOKApplicantFather.Text = ds.Tables[0].Rows[0]["NOKSODOWO"].ToString();
                            NOKCNIC.Text = ds.Tables[0].Rows[0]["CNICorNICOP"].ToString();
                            NOKMobileNo.Text = ds.Tables[0].Rows[0]["NOKMobile"].ToString();
                            //NOKDoB.DateTimePickerElement.Value = DateTime.Parse(item["NOKDob"].ToString());
                            txtFormHistory.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                            
                            if (Convert.ToBoolean(ds.Tables[0].Rows[0]["Form"].ToString()))
                            { ckform.CheckState = CheckState.Checked;}
                            else { ckform.CheckState = CheckState.Unchecked; }
                            if (Convert.ToBoolean(ds.Tables[0].Rows[0]["CNICCopy"].ToString()))
                            { chkCNIC.CheckState = CheckState.Checked; }
                            else { chkCNIC.CheckState = CheckState.Unchecked;  }
                            if (Convert.ToBoolean(ds.Tables[0].Rows[0]["PassportCopy"].ToString())) { chkPassport.CheckState = CheckState.Checked; }
                            else { chkPassport.CheckState = CheckState.Unchecked;  }
                            if (Convert.ToBoolean(ds.Tables[0].Rows[0]["NicopCopy"].ToString())) { chkNICOP.CheckState = CheckState.Checked; }
                            else { chkNICOP.CheckState = CheckState.Unchecked;  }
                            if (Convert.ToBoolean(ds.Tables[0].Rows[0]["DischargeBookOrRetirementOrder"].ToString())) { chkDischargeorRetirement.CheckState = CheckState.Checked; }
                            else { chkDischargeorRetirement.CheckState = CheckState.Unchecked;  }
                           if (Convert.ToBoolean(ds.Tables[0].Rows[0]["EligibilityCertificateForCat2Army"].ToString())) { chkEligibilityCriteria.CheckState = CheckState.Checked; }
                           else { chkEligibilityCriteria.CheckState = CheckState.Unchecked;  }
                        //ckform.Enabled = false; chkCNIC.Enabled = false; chkPassport.Enabled = false;
                        //chkNICOP.Enabled = false; chkDischargeorRetirement.Enabled = false; chkEligibilityCriteria.Enabled = false;
                        //if (Convert.ToBoolean(item["CategoryForArmyOffcr"].ToString())) { chkEligibilityCriteria.CheckState = CheckState.Checked; }
                        //else { chkEligibilityCriteria.CheckState = CheckState.Unchecked; }

                        if (ds.Tables[0].Rows[0]["Catergory"].ToString() == "Retired Army Officers 10%")
                        {
                            grpEligibilityCriteria.Enabled = true;

                            if (ds.Tables[0].Rows[0]["CategoryForArmyOffcr"].ToString() == "Category1" || ds.Tables[0].Rows[0]["CategoryForArmyOffcr"].ToString() == "Category 1")
                            {
                                rdbCate1.CheckState = CheckState.Checked;
                            }
                            else if (ds.Tables[0].Rows[0]["CategoryForArmyOffcr"].ToString() == "Category2" || ds.Tables[0].Rows[0]["CategoryForArmyOffcr"].ToString() == "Category 2")
                            {
                                rdbCate2.CheckState = CheckState.Checked;
                            }
                        }
                        else
                        {
                            grpEligibilityCriteria.Enabled = false;
                        }

                    }
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Are You Sure ?","Attention!",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    #region Code
                    string strcat;
                    if (rdbCate1.IsChecked) { strcat = "Category 1"; } else if (rdbCate2.IsChecked) { strcat = "Category 2"; } else { strcat = null; }

                    DateTime? rtddate;
                    if (dtpdateofretd.Text == "")
                    {
                        rtddate = null;
                    }
                    else
                    {
                        rtddate = dtpdateofretd.Value.Date;
                    }


                    SqlParameter[] ApplicantInfo =
                    {
                    new SqlParameter("@ApplicationID",Application_ID),
                    new SqlParameter("@FormNo",lblFormNo.Text),
                    new SqlParameter("@Catergory",ApplicationCategory.Text),
                    new SqlParameter("@PlotSize",PlotSize.Text),
                    new SqlParameter("@ApplicantName",ApplicantName.Text),
                    new SqlParameter("@Gender",ApplicantGender.Text),
                    new SqlParameter("@FatherSODOWO",ApplicantFather.Text),
                    new SqlParameter("@CNIC_NICOP",ApplicantCNIC.Text),
                    new SqlParameter("@DoB",ApplicantDOB.DateTimePickerElement.Value),
                    new SqlParameter("@PresentAddress",ApplicantPresentAddress.Text),
                    new SqlParameter("@PermanentAddress",ApplicantPermanentAddress.Text),
                    new SqlParameter("@City",ApplicantCity.Text),
                    new SqlParameter("@District",ApplicantDistrict.Text),
                    new SqlParameter("@Country",ApplicantCountry.Text),
                    new SqlParameter("@Email",ApplicantEmail.Text),
                    new SqlParameter("@MobileNo",ApplicantMobileNo.Text),
                    new SqlParameter("@DepositSlipNo",DepositSlipNo.Text),
                    new SqlParameter("@BankName",BankName.SelectedItem.ToString()),
                    new SqlParameter("@BranchCode",Branch.Text),
                    new SqlParameter("@PassportNo",ApplicantPassport.Text),
                    new SqlParameter("@Amount",DepositAmount.Text),
                    new SqlParameter("@ConnectionType",ApplicantConnectionType.Text),
                    new SqlParameter("@ApplicationStatus",ApplictnSts),
                    new SqlParameter("@Remarks", txtRemarks.Text == "" ? txtFormHistory.Text : txtFormHistory.Text + Environment.NewLine
                                               + clsUser.Name+" ("+DateTime.Now+")-:-" + txtRemarks.Text),
                    new SqlParameter("@NOKName",NOKApplicantName.Text),
                    new SqlParameter("@NOKSODOWO",NOKApplicantFather.Text),
                    new SqlParameter("@CNICorNICOP",NOKCNIC.Text),
                    new SqlParameter("@NOKMobile",NOKMobileNo.Text),
                    new SqlParameter("@NOKDob",NOKDoB.DateTimePickerElement.Value),
                    new SqlParameter("@PANo",txtPANo.Text),
                    new SqlParameter("@ArmRank",txtRank.Text),
                    new SqlParameter("@Province",cbProvince.Text),
                    new SqlParameter("@DateRetd",rtddate),
                    //new SqlParameter("@InsertTime",),
                    new SqlParameter("@UpdateBy",clsUser.Name),
                    new SqlParameter("@UpdateTime",DateTime.Now)
                   ,new SqlParameter("@Form",ckform.CheckState == CheckState.Checked? true : false)
                   ,new SqlParameter("@CNICCopy",chkCNIC.CheckState == CheckState.Checked? true : false)
                   ,new SqlParameter("@PassportCopy",chkPassport.CheckState == CheckState.Checked? true : false)
                   ,new SqlParameter("@NicopCopy",chkNICOP.CheckState == CheckState.Checked? true : false)
                   //,new SqlParameter("@ServiceCertificateCopy",chkServiceCertificate.CheckState == CheckState.Checked? true : false)
                   ,new SqlParameter("@DischargeBookOrRetirementOrder",chkDischargeorRetirement.CheckState == CheckState.Checked? true : false)
                   ,new SqlParameter("@EligibilityCertificateForCat2Army",chkEligibilityCriteria.CheckState == CheckState.Checked? true : false)
                   ,new SqlParameter("@CategoryForArmyOffcr",strcat)

                   };
                    int Result = SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(), CommandType.StoredProcedure, "Launching.p_Savetbl_ApplicationInfo", ApplicantInfo);
                    if (Result > 0)
                    {

                        if (ApplictnSts == "ScrutinyCompleted")
                        {
                            MessageBox.Show("Succesfully Moved For Payment Verification.");
                            UpdateOnlineReordOfAppliant("All Documents Verified Successfully.Waiting For Payment Verifiation");
                        }
                        else if (ApplictnSts == "Pending")
                        {
                            MessageBox.Show("Moved to Scrutiny Successfully.");
                            UpdateOnlineReordOfAppliant("Under Proess.");
                        }
                    }
                    this.Close();
                    #endregion
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdateOnlineReordOfAppliant(string appsts)
        {
            SqlParameter[] ApplicantInfodata =
            {
                        new SqlParameter("@FormNo",lblFormNo.Text),
                        new SqlParameter("@CNIC_NICOP",ApplicantCNIC.Text),
                        new SqlParameter("@AppliationStatus",appsts)
                    };
            int rsl = SQLHelper.ExecuteNonQuery(
                      SQLHelper.createConnection_DHADB(), CommandType.StoredProcedure,
                      "dbo.p_Update_tbl_ApplicationInfo_DHADB", ApplicantInfodata);
        }
        
        private void btnSendtoObservation_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are You Sure ?", "Attention!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string strcat;
                    if (rdbCate1.IsChecked) { strcat = "Category 1"; } else if (rdbCate2.IsChecked) { strcat = "Category 2"; } else { strcat = null; }

                    DateTime? rtddate;
                    if (dtpdateofretd.Text == "")
                    {
                        rtddate = null;
                    }
                    else
                    {
                        rtddate = dtpdateofretd.Value.Date;
                    }

                    SqlParameter[] ApplicantInfo =
                    {
                    new SqlParameter("@ApplicationID",Application_ID),
                    new SqlParameter("@FormNo",lblFormNo.Text),
                    new SqlParameter("@Catergory",ApplicationCategory.Text),
                    new SqlParameter("@PlotSize",PlotSize.Text),
                    new SqlParameter("@ApplicantName",ApplicantName.Text),
                    new SqlParameter("@Gender",ApplicantGender.Text),
                    new SqlParameter("@FatherSODOWO",ApplicantFather.Text),
                    new SqlParameter("@CNIC_NICOP",ApplicantCNIC.Text),
                    new SqlParameter("@DoB",ApplicantDOB.DateTimePickerElement.Value),
                    new SqlParameter("@PresentAddress",ApplicantPresentAddress.Text),
                    new SqlParameter("@PermanentAddress",ApplicantPermanentAddress.Text),
                    new SqlParameter("@City",ApplicantCity.Text),
                    new SqlParameter("@District",ApplicantDistrict.Text),
                    new SqlParameter("@Country",ApplicantCountry.Text),
                    new SqlParameter("@Email",ApplicantEmail.Text),
                    new SqlParameter("@MobileNo",ApplicantMobileNo.Text),
                    new SqlParameter("@DepositSlipNo",DepositSlipNo.Text),
                    new SqlParameter("@BankName",BankName.Text),
                    new SqlParameter("@BranchCode",Branch.Text),
                    new SqlParameter("@PassportNo",ApplicantPassport.Text),
                    new SqlParameter("@Amount",DepositAmount.Text),
                    new SqlParameter("@ConnectionType",ApplicantConnectionType.Text),
                    new SqlParameter("@ApplicationStatus","Review"),
                    new SqlParameter("@Remarks",txtRemarks.Text == "" ? txtFormHistory.Text : txtFormHistory.Text + Environment.NewLine
                                               + clsUser.Name+" ("+DateTime.Now+")-:-" + txtRemarks.Text),
                    new SqlParameter("@NOKName",NOKApplicantName.Text),
                    new SqlParameter("@NOKSODOWO",NOKApplicantFather.Text),
                    new SqlParameter("@CNICorNICOP",NOKCNIC.Text),
                    new SqlParameter("@NOKMobile",NOKMobileNo.Text),
                    new SqlParameter("@NOKDob",NOKDoB.DateTimePickerElement.Value),
                    new SqlParameter("@PANo",txtPANo.Text),
                    new SqlParameter("@ArmRank",txtRank.Text),
                    new SqlParameter("@Province",cbProvince.Text),
                    new SqlParameter("@DateRetd",rtddate),
                    //new SqlParameter("@InsertTime",),
                    new SqlParameter("@UpdateBy",clsUser.Name),
                    new SqlParameter("@UpdateTime",DateTime.Now)
                   ,new SqlParameter("@Form",ckform.CheckState == CheckState.Checked? true : false)
                   ,new SqlParameter("@CNICCopy",chkCNIC.CheckState == CheckState.Checked? true : false)
                   ,new SqlParameter("@PassportCopy",chkPassport.CheckState == CheckState.Checked? true : false)
                   ,new SqlParameter("@NicopCopy",chkNICOP.CheckState == CheckState.Checked? true : false)
                   //,new SqlParameter("@ServiceCertificateCopy",chkServiceCertificate.CheckState == CheckState.Checked? true : false)
                   ,new SqlParameter("@DischargeBookOrRetirementOrder",chkDischargeorRetirement.CheckState == CheckState.Checked? true : false)
                   ,new SqlParameter("@EligibilityCertificateForCat2Army",chkEligibilityCriteria.CheckState == CheckState.Checked? true : false)
                   ,new SqlParameter("@CategoryForArmyOffcr",strcat) 
                   //new SqlParameter("@DeleteBy",),
                   //new SqlParameter("@Deletetime",),
                   //new SqlParameter("@ApplicationFeeID",),
                   //new SqlParameter("@ResultCode",)
                    };
                    int Result = SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(), CommandType.StoredProcedure,
                                 "Launching.p_Updatetbl_ApplInfo_Detail", ApplicantInfo);
                    if (Result > 0)
                    {
                        MessageBox.Show("Successfull.");
                        UpdateOnlineReordOfAppliant("Under Observation");
                        txtSMSType = "";
                        txtMessage = "";
                        txtSMSType = "Commercial Launchig";
                        txtMessage = "Dear Applicant,Your Application for DHAP Commercial Launch has been received which has some discrepancies. " +
                                        "Please Contact at 03338118902 or 091-9223172 (9:00 AM To 05:00 PM)";
                        mbNo = ApplicantMobileNo.Text;
                        SendingSMS();
                    }
                    this.Close();
                }
            }
            catch ( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SendingSMS()
        {
            #region Code for SMS Sending
            bgwObservation.RunWorkerAsync();
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
        private void ApplicationCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ApplicationCategory.SelectedItem.ToString() == "General Public 85%")
            {
                    grpEligibilityCriteria.Enabled = false;
                    AbroadAddress.Enabled = false;
                    rdbCate1.CheckState = CheckState.Unchecked;
                    rdbCate2.CheckState = CheckState.Unchecked;

                    ckform.Enabled = true;
                    chkCNIC.Enabled = true;

                    ckform.ForeColor = Color.Red;
                    chkCNIC.ForeColor = Color.Red;

                    chkDischargeorRetirement.Enabled = false;
                    chkEligibilityCriteria.Enabled = false;
                    chkPassport.Enabled = false;
                    chkNICOP.Enabled = false;





                txtPANo.Enabled = false;
                txtRank.Enabled = false;
                ApplicantPassport.Enabled = false;
               // txtAbroadAddress.Enabled = false;
                dtpdateofretd.Enabled = false;
                lblpakabrd.Text = "";
                txtPANo.Text = "NA";
                txtRank.Text = "NA";
                ApplicantPassport.Text = "NA";
                //ApplicantCNIC.Mask = "00000-0000000-0";
                //nokcnic.Mask = "00000-0000000-0";
                ///txtcnic_bankdetail.Mask = "00000-0000000-0";

            }
            else if (ApplicationCategory.SelectedItem.ToString() == "Retired Army Officers 10%")
            {
                ckform.Enabled = true;
                chkCNIC.Enabled = true;
                AbroadAddress.Enabled = false;
                chkDischargeorRetirement.Enabled = true;
                chkPassport.Enabled = false;
                chkNICOP.Enabled = false;
                chkEligibilityCriteria.Enabled = true;
                grpEligibilityCriteria.Enabled = true;
                rdbCate1.CheckState = CheckState.Checked;


                ckform.ForeColor = Color.Red;
                chkCNIC.ForeColor = Color.Red;
                chkDischargeorRetirement.ForeColor = Color.Red;
                chkEligibilityCriteria.ForeColor = Color.Red;



                txtPANo.Enabled = true;
                txtRank.Enabled = true;
                ApplicantPassport.Enabled = false;
                //txtAbroadAddress.Enabled = false;
                dtpdateofretd.Enabled = true;
                lblpakabrd.Text = "";
                ApplicantPassport.Text = "NA";
                txtPANo.Text = "";
                txtRank.Text = "";

            }
            else if (ApplicationCategory.SelectedItem.ToString() == "Overseas Pakistanis 5%")
            {
                ckform.Enabled = true;
                chkCNIC.Enabled = true;
                chkPassport.Enabled = true;
                chkNICOP.Enabled = true;
                chkDischargeorRetirement.Enabled = false;
                chkEligibilityCriteria.Enabled = false;
                grpEligibilityCriteria.Enabled = false;
                AbroadAddress.Enabled = true;

                rdbCate1.CheckState = CheckState.Unchecked;
                rdbCate2.CheckState = CheckState.Unchecked;

                ckform.ForeColor = Color.Red;
                chkCNIC.ForeColor = Color.Red;
                chkPassport.ForeColor = Color.Red;
                chkNICOP.ForeColor = Color.Red;

                txtPANo.Enabled = false;
                txtRank.Enabled = false;
                ApplicantPassport.Enabled = true;
                //txtAbroadAddress.Enabled = true;
                dtpdateofretd.Enabled = true;
                lblpakabrd.Text = "(Pakistan/Abroad)";
                txtPANo.Text = "NA";
                txtRank.Text = "NA";
                ApplicantPassport.Text = "";
            }
        }

        private void bgwObservation_DoWork(object sender, DoWorkEventArgs e)
        {
            SendSMS();
        }

        private void bgwObservation_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void PlotSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(PlotSize.SelectedItem.ToString() == "4 Marla")
            {
                DepositAmount.Text = "20000";
            }
            else if (PlotSize.SelectedItem.ToString() == "8 Marla")
            {
                DepositAmount.Text = "30000";
            }
        }

        private void btnFInalVerification_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are You Sure ?", "Attention!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    #region Code
                    string strcat;
                    if (rdbCate1.IsChecked) { strcat = "Category 1"; } else if (rdbCate2.IsChecked) { strcat = "Category 2"; } else { strcat = null; }

                    DateTime? rtddate;
                    if (dtpdateofretd.Text == "")
                    {
                        rtddate = null;
                    }
                    else
                    {
                        rtddate = dtpdateofretd.Value.Date;
                    }


                    SqlParameter[] ApplicantInfo =
                    {
                    new SqlParameter("@ApplicationID",Application_ID),
                    new SqlParameter("@FormNo",lblFormNo.Text),
                    new SqlParameter("@Catergory",ApplicationCategory.Text),
                    new SqlParameter("@PlotSize",PlotSize.Text),
                    new SqlParameter("@ApplicantName",ApplicantName.Text),
                    new SqlParameter("@Gender",ApplicantGender.Text),
                    new SqlParameter("@FatherSODOWO",ApplicantFather.Text),
                    new SqlParameter("@CNIC_NICOP",ApplicantCNIC.Text),
                    new SqlParameter("@DoB",ApplicantDOB.DateTimePickerElement.Value),
                    new SqlParameter("@PresentAddress",ApplicantPresentAddress.Text),
                    new SqlParameter("@PermanentAddress",ApplicantPermanentAddress.Text),
                    new SqlParameter("@City",ApplicantCity.Text),
                    new SqlParameter("@District",ApplicantDistrict.Text),
                    new SqlParameter("@Country",ApplicantCountry.Text),
                    new SqlParameter("@Email",ApplicantEmail.Text),
                    new SqlParameter("@MobileNo",ApplicantMobileNo.Text),
                    new SqlParameter("@DepositSlipNo",DepositSlipNo.Text),
                    new SqlParameter("@BankName",BankName.SelectedItem.ToString()),
                    new SqlParameter("@BranchCode",Branch.Text),
                    new SqlParameter("@PassportNo",ApplicantPassport.Text),
                    new SqlParameter("@Amount",DepositAmount.Text),
                    new SqlParameter("@ConnectionType",ApplicantConnectionType.Text),
                    //new SqlParameter("@ApplicationStatus",ApplictnSts),
                    new SqlParameter("@Remarks", txtRemarks.Text == "" ? txtFormHistory.Text : txtFormHistory.Text + Environment.NewLine
                                               + clsUser.Name+" ("+DateTime.Now+")-:-" + txtRemarks.Text),
                    new SqlParameter("@NOKName",NOKApplicantName.Text),
                    new SqlParameter("@NOKSODOWO",NOKApplicantFather.Text),
                    new SqlParameter("@CNICorNICOP",NOKCNIC.Text),
                    new SqlParameter("@NOKMobile",NOKMobileNo.Text),
                    new SqlParameter("@NOKDob",NOKDoB.DateTimePickerElement.Value),
                    new SqlParameter("@PANo",txtPANo.Text),
                    new SqlParameter("@ArmRank",txtRank.Text),
                    new SqlParameter("@Province",cbProvince.Text),
                    new SqlParameter("@DateRetd",rtddate),
                    //new SqlParameter("@InsertTime",),
                    new SqlParameter("@UpdateBy",clsUser.Name),
                    new SqlParameter("@UpdateTime",DateTime.Now)
                   ,new SqlParameter("@Form",ckform.CheckState == CheckState.Checked? true : false)
                   ,new SqlParameter("@CNICCopy",chkCNIC.CheckState == CheckState.Checked? true : false)
                   ,new SqlParameter("@PassportCopy",chkPassport.CheckState == CheckState.Checked? true : false)
                   ,new SqlParameter("@NicopCopy",chkNICOP.CheckState == CheckState.Checked? true : false)
                   //,new SqlParameter("@ServiceCertificateCopy",chkServiceCertificate.CheckState == CheckState.Checked? true : false)
                   ,new SqlParameter("@DischargeBookOrRetirementOrder",chkDischargeorRetirement.CheckState == CheckState.Checked? true : false)
                   ,new SqlParameter("@EligibilityCertificateForCat2Army",chkEligibilityCriteria.CheckState == CheckState.Checked? true : false)
                   ,new SqlParameter("@CategoryForArmyOffcr",strcat)

                   };
                    int Result = SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(), CommandType.StoredProcedure, "Launching.p_Savetbl_ApplicationInfo_ForFInalVerification", ApplicantInfo);
                    if (Result > 0)
                    {
                            MessageBox.Show("Succesfully Verified.");
                    }
                    this.Close();
                    #endregion
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
