using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.XPath;
using PeshawarDHASW.Data_Layer.clsChallanRece;
using PeshawarDHASW.Data_Layer.clsChallanType;
using PeshawarDHASW.Data_Layer.clsErrorLog;
using PeshawarDHASW.Data_Layer.Installment;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Models;
using Telerik.WinControls;
using PeshawarDHASW.Application_Layer.CustomDialog;
using System.Text.RegularExpressions;
using Telerik.WinControls.UI;
using System.Globalization;
using PeshawarDHASW.Data_Layer.clsAcknowledgment;
using PeshawarDHASW.Application_Layer.NDC.Baskets;
using PeshawarDHASW.Data_Layer.NDC;

namespace PeshawarDHASW.Application_Layer.Installment.InstReceive
{
    public partial class frmRecePayment : Telerik.WinControls.UI.RadForm
    {

        public DateTime dtt { get; set; }
        public frmRecePayment()
        {
            InitializeComponent();
            txtbank.SelectedIndex = 0;
            txtdate.Value = DateTime.Now;
            dtpDDGenerationDate.Value = DateTime.Now;
            drpPaymentMethod.SelectedIndex = 0;
            txtstatus.SelectedIndex = 0;
            txtddstatus.SelectedIndex = 0;
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
        }

        private int Rece_ID = 0;
        public int ChallanID { get; set; }
        private string txtamount { get; set; }
        public frmRecePayment(int receid = 0, int challanID = 0)
        {
            Rece_ID = receid;
            ChallanID = challanID;
            InitializeComponent();
        }

        #region Seach File No and MemberShip
        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileActiveNotBlock() == true)
                {
                    #region code
                    if (txtfileno.Text != "" || txtplotno.Text != "" || txtmsno.Text != "" || txtnic.Text != "" || txtplotno.Text != "")
                    {
                        SqlParameter[] parameterforsearch =
                        {
                        new SqlParameter("@Task", "VerficationofMembership"),
                        new SqlParameter("@FileNo", clsPluginHelper.DbNullIfNullOrEmpty(txtfileno.Text)),
                        new SqlParameter("@PlotNo", clsPluginHelper.DbNullIfNullOrEmpty(txtplotno.Text)),
                        new SqlParameter("@MembershipNo", clsPluginHelper.DbNullIfNullOrEmpty(txtmsno.Text)),
                        new SqlParameter("@NIC", clsPluginHelper.DbNullIfNullOrEmpty(txtnic.Text)),
                    };
                        DataSet ds = Data_Layer.Installment.cls_dl_InstRece.MembershipVerification(parameterforsearch);
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                lblfileno.Text = row["FileNo"].ToString();
                                lblplotno.Text = row["PlotNo"].ToString();
                                lblmsno.Text = row["MembershipNo"].ToString();
                                lblcontact.Text = row["MobileNo"].ToString();
                                lblname.Text = row["Name"].ToString();
                                lblNIC.Text = row["NIC/NICOP"].ToString();

                                lblfilekey.Text = row["FileMapKey"].ToString();
                                lblmsid.Text = row["ID"].ToString();
                            }
                        }
                        else
                        {
                            Clear();
                            MessageBox.Show("Their is no Information found in our System.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }


                    }
                    else
                    {
                        MessageBox.Show("Filter on the base of Search field Kindly use one of the field must.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnsearch_Click.", ex, "frmRecePayment");
                //   frmobj.ShowDialog();
                MessageBox.Show("Check the Search Fileds which is empty or fill from incorrect data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Clear Function
        private void Clear()
        {
            // txtdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtamountInWords.Text = "";
            dtpDDGenerationDate.Value = DateTime.Now;
            txtDDno.Text = "";
            txtfileno.Text = "";
            txtmsno.Text = "";
            txtplotno.Text = "";
            txtnic.Text = "";
            lblfileno.Text = "";
            lblplotno.Text = "";
            lblmsno.Text = "";
            lblcontact.Text = "";
            lblname.Text = "";
            lblNIC.Text = "";

            lblfilekey.Text = "";
            lblmsid.Text = "";
            //-------------------
            txtdate.Value = DateTime.Now;
            txtDynamicamount.Text = "";
            txtbank.SelectedIndex = 0;
            txtbank.Text = "";
            drpPaymentMethod.SelectedIndex = 0;
            txtstatus.SelectedIndex = 1;
            txtddstatus.SelectedIndex = 1;
            txtremarks.Text = "";
            txtbranch.Text = "";
            //txtaccountno.Text = "";
            txtSurchargeAmount.Text = "0";
            rdDeductotherChargesfromDD.CheckState = CheckState.Unchecked;
            lblTotalRemainingSurcharge.Text = "";
        }
        #endregion


        private void frmRecePayment_Load(object sender, EventArgs e)
        {
            try
            {

                txtdate.MaxDate = DateTime.Now; txtstatus.SelectedIndex = 1;
                txtDynamicamount.Enabled = false;
                
                dtt = clsMostUseVars.ServerDateTime;
                txtdate.MinDate = dtt.AddDays(-5);
                txtdate.MaxDate = dtt;
                dtpDDGenerationDate.MaxDate = dtt;
                txtdate.Value = dtt;
                gpDeductOtherAmount.Enabled = false;
                //referencechallangp.Enabled = false;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmRecePayment_Load.", ex, "frmRecePayment");
                frmobj.ShowDialog();
            }
            drpPaymentMethod.SelectedIndex = 0;
            txtstatus.SelectedIndex = 1;
            txtddstatus.SelectedIndex = 1;
        }

       


        private void saveInstallment(string get_strng)
        {
            try
            {
                if (get_strng == "OtherMode")
                {
                    if (Rece_ID == 0)
                    {

                        bool checkStatus = rdDeductotherChargesfromDD.CheckState == CheckState.Checked ? true : false;

                        SqlParameter[] param =
                        {
                            new SqlParameter("@Task", "insert"),
                            new SqlParameter("@Date",txtdate.Value.Date),
                            new SqlParameter("@DDGenerationDate", dtpDDGenerationDate.Value.Date),
                            new SqlParameter("@Amountinwords", txtamountInWords.Text),
                            new SqlParameter("@PaymentMethod", drpPaymentMethod.SelectedItem.ToString()),
                            new SqlParameter("@Amount", txtamount),
                            new SqlParameter("@DDNo", txtDDno.Text),
                            new SqlParameter("@BankName", txtbank.Text),
                            new SqlParameter("@Branch", txtbranch.Text),
                            new SqlParameter("@Status", txtstatus.Text),
                            new SqlParameter("@DDStatus", txtddstatus.Text),
                            new SqlParameter("@Remarks", txtremarks.Text),
                            new SqlParameter("@MemberID", lblmsid.Text),
                            new SqlParameter("@FileKeyID", lblfilekey.Text),
                            new SqlParameter("@userID", Models.clsUser.ID),
                            new SqlParameter("@SurchargePAid",checkStatus),
                            new SqlParameter("@SurchargeAmount",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtSurchargeAmount.Text))
                       };

                        // string ReceID = SQLHelper.ExecuteScalar(clsMostUseVars.Connectionstring,CommandType.StoredProcedure,"App.USP_ReceInst",param).ToString();
                      //  DataSet abc = new DataSet();
                        long ReceID =Convert.ToInt64( SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "App.USP_ReceInst", param).Tables[0].Rows[0]["ReceID"].ToString());
                      //  if (!string.IsNullOrEmpty(ReceID))
                            if (ReceID > 0)
                            {
                            InstReceiveModify.frmDDScanImagesUpload obj = new InstReceiveModify.frmDDScanImagesUpload(ReceID);
                            obj.ShowDialog();
                            Clear();
                        }
                        else
                        {
                            MessageBox.Show("Try Again! or Contact to Admin!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else if (get_strng == "Cleared")
                {
                    if (Rece_ID == 0)
                    {
                        SqlParameter[] param =
                        {
                        new SqlParameter("@Task", "insert"),
                        new SqlParameter("@Date",txtdate.Value.Date),
                        new SqlParameter("@DDGenerationDate", dtpDDGenerationDate.Value.Date),
                        new SqlParameter("@Amountinwords", txtamountInWords.Text),
                        new SqlParameter("@PaymentMethod", drpPaymentMethod.SelectedItem.ToString()),
                        //new SqlParameter("@RecordNo", lblRecordNo.Text),
                        new SqlParameter("@Amount", txtamount),
                        new SqlParameter("@DDNo", txtDDno.Text),
                        new SqlParameter("@BankName", txtbank.Text),
                        new SqlParameter("@Branch", txtbranch.Text),
                        new SqlParameter("@Status", txtstatus.Text),
                        new SqlParameter("@DDStatus", "Cleared"),
                        new SqlParameter("@Remarks", txtremarks.Text),
                        new SqlParameter("@MemberID", lblmsid.Text),
                        new SqlParameter("@FileKeyID", lblfilekey.Text),
                        new SqlParameter("@userID", Models.clsUser.ID),
                            new SqlParameter("@SurchargePAid",rdDeductotherChargesfromDD.CheckState == CheckState.Checked? true:false),
                            new SqlParameter("@SurchargeAmount",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtSurchargeAmount.Text))
                        };
                        // string ReceID = SQLHelper.ExecuteScalar(clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "App.USP_ReceInst", param).ToString();
                        long ReceID = Convert.ToInt64(SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "App.USP_ReceInst", param).Tables[0].Rows[0]["ReceID"].ToString());
                        if (ReceID>0)
                        {
                            InstReceiveModify.frmDDScanImagesUpload obj = new InstReceiveModify.frmDDScanImagesUpload(Convert.ToInt64(ReceID));
                            obj.ShowDialog();
                            Clear();
                        }
                        else
                        {
                            MessageBox.Show("Try Again! or Contact to Admin!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on saveInstallment.", ex, "frmRecePayment");
                frmobj.ShowDialog();
            }
        }

        #region Save Rece Installment
        private void btnsave_Click(object sender, EventArgs e)
        {
            string dattm = txtdate.Value.ToString();
            DateTime recedate = Helper.clsPluginHelper.GetDateTime(dattm);

            string dat_tm = dtpDDGenerationDate.Value.ToString();
            DateTime ddgendate = Helper.clsPluginHelper.GetDateTime(dat_tm);

            string dat_tm_ = dtt.ToString("dd/MM/yyyy");
            DateTime getdate = Helper.clsPluginHelper.GetDateTime(dat_tm_);


            if (drpPaymentMethod.SelectedItem.ToString() != "Discount")
            {
                // Entry Restriction
                if (txtDDno.Text != string.Empty && txtamountInWords.Text != string.Empty && txtbranch.Text != string.Empty)
                {
                    #region bank Check
                    if (txtbank.Text != "-- Select Bank --")
                    {
                        if (MessageBox.Show("Do you want to Save", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            //  MessageBox.Show(txtamount);
                            decimal surAmount = 0;
                            bool surConvert = decimal.TryParse(txtSurchargeAmount.Text, out surAmount);
                            decimal DDAmount = 0;
                            bool DDAmountbool = decimal.TryParse(txtamount, out DDAmount);
                            decimal result = 0;
                            if (DDAmount >= surAmount)
                            {
                                result = (DDAmount - surAmount);
                                int result_to_int = int.Parse(result.ToString());
                                txtDynamicamount.Text = result.ToString();
                                txtamountInWords.Text = Convert_Number_To_Text(result_to_int, false);
                                txtamount = result.ToString();

                                saveInstallment("OtherMode");
                                #region Rece Adjust
                                SqlParameter[] prmt =
                                {
                                          new SqlParameter("@Task","Rece_Plan_Adjust"),
                                          new SqlParameter("@FileNo",lblfileno.Text)
                                        };
                                int rsult = Data_Layer.Installment.cls_dl_FinanceDashBoard.AccountStatement_RecePlanAdjust(prmt);
                                #endregion
                            }
                            else
                            {
                                MessageBox.Show("Surcharge Amount is Invalid. Check DD Amount and Surcharge Amount.");
                            }

                           
                        }
                    }
                    else
                    {
                        MessageBox.Show("Select the Bank Name Must.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    #endregion
                }
                else
                {
                    MessageBox.Show("Check the all the Required Fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Entry Restriction
                if (txtDDno.Text != string.Empty && txtamountInWords.Text != string.Empty && txtbranch.Text != string.Empty)
                {
                    #region bank Check
                    if (txtbank.Text != "-- Select Bank --")
                    {

                        frm_Secret_Code frmob = new frm_Secret_Code();
                        frmob.ShowDialog();
                        if (Helper.clsMostUseVars.Drctr_Secret_Code == true)
                        {
                            if (MessageBox.Show("Do you want to Save", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                saveInstallment("Cleared");

                                #region Rece Adjust
                                SqlParameter[] prmt =
                                {
                                    new SqlParameter("@Task","Rece_Plan_Adjust"),
                                    new SqlParameter("@FileNo",lblfileno.Text)
                                };
                                int rsult = Data_Layer.Installment.cls_dl_FinanceDashBoard.AccountStatement_RecePlanAdjust(prmt);
                                #endregion
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sorry! You are not allowed to Enter Discount Amount.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Select the Bank Name Must.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    #endregion
                }
                else
                {
                    MessageBox.Show("Check the all the Require Fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        #endregion
        public static string Convert_Number_To_Text(int number, bool isUK)
        {
            if (number == 0) return "Zero";
            string and = isUK ? "and " : ""; // deals with UK or US numbering
            if (number == -2147483648) return "Minus Two Billion One Hundred " + and +
            "Forty Seven Million Four Hundred " + and + "Eighty Three Thousand " +
            "Six Hundred " + and + "Forty Eight";
            int[] num = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (number < 0)
            {
                sb.Append("Minus ");
                number = -number;
            }
            string[] words0 = { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };
            string[] words1 = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };
            string[] words2 = { "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };
            string[] words3 = { "Thousand ", "Million ", "Billion " };
            num[0] = number % 1000;           // units
            num[1] = number / 1000;
            num[2] = number / 1000000;
            num[1] = num[1] - 1000 * num[2];  // thousands
            num[3] = number / 1000000000;     // billions
            num[2] = num[2] - 1000 * num[3];  // millions
            for (int i = 3; i > 0; i--)
            {
                if (num[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (int i = first; i >= 0; i--)
            {
                if (num[i] == 0) continue;
                u = num[i] % 10;              // ones
                t = num[i] / 10;
                h = num[i] / 100;             // hundreds
                t = t - 10 * h;               // tens
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    if (h > 0 || i < first) sb.Append(and);
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }
            return sb.ToString().TrimEnd();
        }
        private void drpStaticAmount_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (drpStaticAmount.SelectedIndex > 0)
            {
                txtDynamicamount.Enabled = false;
                txtamountInWords.Enabled = false;
                txtamount = drpStaticAmount.SelectedItem.ToString();
                txtamountInWords.Text = Convert_Number_To_Text(int.Parse(txtamount), false);

            }
            else
            {
                txtDynamicamount.Enabled = true;
                txtamountInWords.Text = "";
                txtamountInWords.Enabled = false;
            }
        }
        private void txtDynamicamount_Leave(object sender, EventArgs e)
        {

            txtamount = txtDynamicamount.Text;
            if (txtamount == string.Empty)
            {
                txtamount = "0";
                txtamountInWords.Text = Convert_Number_To_Text(int.Parse(txtamount), false);
            }
            else
            {
                txtamountInWords.Text = Convert_Number_To_Text(int.Parse(txtamount), false);
            }
        }
        private void txtDDno_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDDno.Text.Trim()))
                return;
            SqlParameter[] pr =
            {
                new SqlParameter("@Task","Find_Duplicate_DD"),
                new SqlParameter("@DDNo",txtDDno.Text)
            };
            DataSet dst = new DataSet();
            dst = cls_dl_InstRece.Inst_Rece_Read(pr);
            if (dst.Tables.Count > 0)
            {
                if (dst.Tables[0].Rows.Count > 0)
                {
                    string ddno = dst.Tables[0].Rows[0]["DDNo"].ToString();
                    string fileno = dst.Tables[0].Rows[0]["FileNo"].ToString();
                    MessageBox.Show("DDNo : " + ddno + " is use against the File No : " + fileno + ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }


        }
        private void txtddstatus_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (txtddstatus.SelectedItem.ToString() == "Refund" | txtddstatus.SelectedItem.ToString() == "Return")
            {
                RadMessageBox.Show("You must Enter minimum 20 Characters of Remarks For Refunding / Returning of DD.");
                btnsave.Enabled = false;
            }
            else
            {
                btnsave.Enabled = true;
            }
        }
        private void txtremarks_Leave(object sender, EventArgs e)
        {
            if (txtddstatus.SelectedItem.ToString() == "Refund" | txtddstatus.SelectedItem.ToString() == "Return")
            {
                if (txtremarks.TextLength > 20)
                {
                    btnsave.Enabled = true;
                }
                else
                {
                    MessageBox.Show("You must Enter minimum 20 Characters for Remarks.");
                }
            }

        }
        private void txtDDno_Validating(object sender, CancelEventArgs e)
        {
            btnsave.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtDDno, "", new Regex("^[a-zA-Z0-9_ ]{1,50}$"));
        }
        private void txtDynamicamount_Validating(object sender, CancelEventArgs e)
        {
            btnsave.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtDynamicamount, "", new Regex("^[0-9_ -]{1,50}$"));
        }
        private void txtbranch_Validating(object sender, CancelEventArgs e)
        {
            btnsave.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtbranch, "", new Regex("^[a-zA-Z0-9_ ]{3,50}$"));
        }
        private void txtbank_Validating(object sender, CancelEventArgs e)
        {
            if (txtbank.Text != "-- Select Bank --")
            {

            }
            else
            {
                RadTextBox txt = new RadTextBox();
                txt.Text = "abc";
                btnsave.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txt, "", new Regex("^[0-9]{1,50}$"));
            }
        }
        private void btnsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnsearch_Click(null, null);
            }
        }
        private void txtfileno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if(FileActiveNotBlock() == true)
                {
                    btnsearch_Click(null, null);
                }
                
            }
        }
        private bool FileActiveNotBlock()
        {
            bool fanl = false;
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","FileActiveNotBlockStatus_Payment"),
                new SqlParameter("@FileNo",txtfileno.Text)
            };
            DataSet dst = cls_dl_NDC.NdcRetrival(prm);
            if (dst.Tables.Count > 0)
            {
                if (dst.Tables[0].Rows.Count > 0)
                {
                    fanl = true;
                    btnsave.Enabled = true;
                }
                else
                {
                    MessageBox.Show("This File No. is Cancel.");
                    fanl = false;
                    btnsave.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("This File No. is Cancel.");
                fanl = false;
                btnsave.Enabled = false;
            }
            return fanl;
        }
        private void txtmsno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnsearch_Click(null, null);
            }
        }
        private void txtnic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnsearch_Click(null, null);
            }
        }
        private void btnsave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnsave_Click(null, null);
            }

        }
        private void txtdate_Leave(object sender, EventArgs e)
        {
            //if (txtdate.Value.Date <= txtdate.MinDate)
            //{
            //    RadMessageBox.Show("Receive Date is Invalid and Change to Grace time period","Receive Date Warning");
            //}
        }
        private void dtpDDGenerationDate_Leave(object sender, EventArgs e)
        {
            //if (dtpDDGenerationDate.Value.Date <= dtpDDGenerationDate.MaxDate)
            //{
            //    RadMessageBox.Show("DD Generation Date must be less than or equal to Current Date", "DD Generation Date Warning");
            //}
        }
       

        private void ChallanDate()
        {
           /* SqlParameter[] param = {
                    new SqlParameter("@Task","ChallanSearchforReceInst"),
                    new SqlParameter("@ChalanNo",txtChallanNo.Text)
            };
            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "ch.USP_Challan", param);
            if (ds.Tables.Count>0)
            {
                if (ds.Tables[0].Rows.Count>0)
                {
                    float Amount = float.Parse(ds.Tables[0].Rows[0]["TotalAmount"].ToString());
                    //challanAmount.Text = string.Format("{0:n0}", Amount) ;
                    //challanDate.Text = DateTime.Parse( ds.Tables[0].Rows[0]["CreateDate"].ToString()).ToString("dd/MM/yyyy");
                    //lblDDNo.Text = ds.Tables[0].Rows[0]["DDNo"].ToString();
                }
            }*/
        }
        private void txtChallanNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                ChallanDate();
            }
        }
        private void btnChallanFind_Click(object sender, EventArgs e)
        {
            
        }
        public decimal SurchargeValue { get; set; }

        private void rdDeductotherChargesfromDD_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (args.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                gpDeductOtherAmount.Enabled = true;
                if (!string.IsNullOrEmpty(lblfileno.Text) && lblfileno.Text != ".")
                {
                    SqlParameter[] parameter = {
                                                new SqlParameter("@Task","AccountSummary"),
                                                new SqlParameter("@FileNo",lblfileno.Text)
                                              };
                    DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.AccountStatementSummary", parameter);
                    if (ds.Tables.Count>0)
                    {
                        if (ds.Tables[0].Rows.Count>0)
                        {
                            SurchargeValue = decimal.Parse(ds.Tables[0].Rows[0]["Remaing_Surcharge"].ToString());
                            txtSurchargeAmount.Text = SurchargeValue.ToString();
                            lblTotalRemainingSurcharge.Text = string.Format("{0:n0}",SurchargeValue);
                        }
                    }
                    else
                    {
                        RadMessageBox.Show("For Surcharge Please Provide Above Field Must.");
                    }
                   
                }

            }
            else
            {
                gpDeductOtherAmount.Enabled = false;
                btnsave.Enabled = true;
                txtSurchargeAmount.Text = "0";
            }
        }

        private void txtSurchargeAmount_Leave(object sender, EventArgs e)
        {
          //  txtamount = txtDynamicamount.Text;
            if (txtSurchargeAmount.Text == string.Empty)
            {
                txtSurchargeAmount.Text = "0";
            }
            else
            {
                decimal surAmount = 0;
                bool surConvert = decimal.TryParse(txtSurchargeAmount.Text, out surAmount);
                decimal DDAmount = 0;
                bool DDAmountbool = decimal.TryParse(txtamount, out DDAmount);
               
                if (surConvert== true)
                {
                    if (surAmount<0)
                    {
                        txtSurchargeAmount.Text = SurchargeValue.ToString();
                        MessageBox.Show("Please valided Surcharge Amount Change!", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        btnsave.Enabled = false;
                        return;
                    }
                  else if (surAmount > DDAmount)
                    {

                        txtSurchargeAmount.Text = surAmount.ToString();
                        MessageBox.Show("Surcharge Amount is less than DD Amount Please Change Amount!","Attention",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                        btnsave.Enabled = false;
                        return;
                    }

                    else
                    {
                        lblSurAmount.Text = txtSurchargeAmount.Text;

                        lblInstallmentAmount.Text = (DDAmount-surAmount).ToString();
                        lblTotalDDAmount.Text = DDAmount.ToString();
                        btnsave.Enabled = true;
                    }
                }
                else
                {
                   
                    MessageBox.Show("Please valided Surcharge Amount!", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    btnsave.Enabled = false;
                }
               
            }
        }
    }
}
