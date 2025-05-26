using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsErrorLog;
using PeshawarDHASW.Data_Layer.Installment;
using PeshawarDHASW.Models;
using Telerik.WinControls;
using PeshawarDHASW.Data_Layer.clsAcknowledgment;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Application_Layer.CustomDialog;
using Telerik.WinControls.UI;
using System.Globalization;

namespace PeshawarDHASW.Application_Layer.Installment.InstReceive.InstReceiveModify
{
    public partial class frmDDModify : Telerik.WinControls.UI.RadForm
    {
        public frmDDModify()
        {
            InitializeComponent();
        }
        public int _ReceID { get; set; }
        public int value { get; set; }
        public DataSet d_st { get; set; }
        public DataSet dst_ { get; set; }
        private string txtamount { get; set; }
        private DataSet ds_dt_for_mdf { get; set; }
        public frmDDModify(int ReceID)
        {
            InitializeComponent();
            _ReceID = ReceID;

            //txtDynamicamount.Enabled = false;
        }

        private void frmDDModify_Load(object sender, EventArgs e)
        {
            try
            {
                this.ThemeName = clsUser.ThemeName;
                ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);

                DateLockLoad();
                searchingdataforupdate(_ReceID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void DateLockLoad()
        {
            try
            {
                SqlParameter[] prm = {
                new SqlParameter("@Task","ActiveMonthforEntry")
            };
                DataSet ds = cls_dl_LockDate.LockDate_Search_Reader(prm);
                LockMonth.DisplayMember = "AllowDate";
                LockMonth.ValueMember = "LockDateID";
                LockMonth.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public DateTime dtRec { get; set; }
        private void searchingdataforupdate(int ReceIDValue)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task", "search"),
                   new SqlParameter("@Rece_ID",ReceIDValue.ToString()),
                };

                ds_dt_for_mdf = cls_dl_InstRece.Inst_Rece_Read(parameters);
                if (ds_dt_for_mdf.Tables.Count > 0)
                {

                    if(clsUser.ID == 3 || clsUser.ID == 35)
                    {
                        ModifyData();
                    }
                    else
                    {
                        if (ds_dt_for_mdf.Tables[0].Rows[0]["DDStatus"].ToString() == "Cleared")
                        {
                            MessageBox.Show("DD is Cleared Modification is not allowed.");
                            this.Close();
                        }
                        else
                        {
                            ModifyData();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on searchingdataforupdate.", ex, "frmDDModify");
                frmobj.ShowDialog();
            }
        }
        private void ModifyData()
        {
            #region Modification Code
            foreach (DataRow row in ds_dt_for_mdf.Tables[0].Rows)
            {
                lblfileno.Text = row["FileNo"].ToString();
                lblplotno.Text = row["PlotNo"].ToString();
                lblmsno.Text = row["MembershipNo"].ToString();
                lblcontact.Text = row["MobileNo"].ToString();
                lblname.Text = row["Name"].ToString();
                lblNIC.Text = row["NIC"].ToString();
                lblRecordNo.Text = row["RecordNo"].ToString();
                lblpassport.Text = row["PassportNo"].ToString();
                lblfilekey.Text = row["FileMapKey"].ToString();
                lblmsid.Text = row["ID"].ToString();
                txtamountInWords.Text = row["AmountInwords"].ToString();

                dtRec = clsPluginHelper.GetDateTime(row["Date"].ToString());
                if (dtRec < txtdate.MinDate)
                {
                    txtdate.MinDate = dtRec;
                    txtdate.Enabled = false;
                }
                else
                {
                    txtdate.Enabled = true;
                }
                if (!string.IsNullOrEmpty(row["Date"].ToString()))
                    txtdate.Value = clsPluginHelper.GetDateTime(row["Date"].ToString());

                txtDDno.Text = row["DDNo"].ToString();
                txtDynamicamount.Text = row["Amount"].ToString();
                if (!string.IsNullOrEmpty(row["DDGenerationDate"].ToString()))
                    dtpDDGenerationDate.Value = clsPluginHelper.GetDateTime(row["DDGenerationDate"].ToString());

                txtbank.Text = row["BankName"].ToString();
                txtbranch.Text = row["Branch"].ToString();
                txtamount = row["Amount"].ToString();
                drpPaymentMethod.Text = row["PaymentMethod"].ToString();
                txtddstatus.Text = row["DDStatus"].ToString();
                txtremarks.Text = row["Remarks"].ToString();
                //txtSurchargeAmount.Text = row["ChallanNo"].ToString();
                //if (!string.IsNullOrEmpty(txtChallanNo.Text))
                //{
                //    ChallanDate();
                //}
                if (!string.IsNullOrEmpty(row["DDClearanceDate"].ToString()))
                    dtpClearnceDate.Value = clsPluginHelper.GetDateTime(row["DDClearanceDate"].ToString());

                string pmntmtd = ds_dt_for_mdf.Tables[0].Rows[0]["PaymentMethod"].ToString();
                foreach (RadListDataItem item in drpPaymentMethod.Items)
                {
                    string strv = item.ToString();
                    if (strv == pmntmtd)
                    {
                        item.Selected = true;
                    }
                }

                string sts = ds_dt_for_mdf.Tables[0].Rows[0]["Status"].ToString();
                foreach (RadListDataItem item in txtstatus.Items)
                {
                    string strv = item.ToString();
                    if (strv == sts)
                    {
                        item.Selected = true;
                    }
                }

            }
            #endregion
        }
        #region Saving of Data of Installment
        private void saveInstallment()
        {
            try
            {
                if (_ReceID != 0)
                {
                    #region Insertion of DD
                    string dtb = dtpDDGenerationDate.Value.ToString("yyyy/MM/dd");
                    string ClearDate = dtpClearnceDate.Value.ToString("yyyy/MM/dd");
                    string ReceDate = txtdate.Value.ToString("yyyy/MM/dd");
                    SqlCommand cmd = new SqlCommand("App.USP_ReceInst");
                    cmd.Parameters.AddWithValue("@Task", "update");
                    //Validition Task Remaining
                    cmd.Parameters.AddWithValue("@Rece_ID", _ReceID.ToString());
                    cmd.Parameters.AddWithValue("@Date", txtdate.Value);
                    cmd.Parameters.AddWithValue("@RecordNo", lblRecordNo.Text);
                    cmd.Parameters.AddWithValue("@Amount", txtDynamicamount.Text.Trim());
                    cmd.Parameters.AddWithValue("@Amountinwords", txtamountInWords.Text);
                    cmd.Parameters.AddWithValue("@DDGenerationDate", dtpDDGenerationDate.Value);
                    cmd.Parameters.AddWithValue("@PaymentMethod", drpPaymentMethod.Text.ToString());
                    cmd.Parameters.AddWithValue("@DDNo", txtDDno.Text);
                    cmd.Parameters.AddWithValue("@BankName", txtbank.Text);
                    cmd.Parameters.AddWithValue("@Branch", txtbranch.Text);
                    cmd.Parameters.AddWithValue("@Status", txtstatus.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@DDStatus", txtddstatus.Text);
                    cmd.Parameters.AddWithValue("@Remarks", txtremarks.Text);
                    cmd.Parameters.AddWithValue("@MemberID", lblmsid.Text);
                    cmd.Parameters.AddWithValue("@FileKeyID", lblfilekey.Text); cmd.Parameters.AddWithValue("@userID", Models.clsUser.ID);
                    cmd.Parameters.AddWithValue("@ClearingDate", string.IsNullOrEmpty(dtpClearnceDate.Text) ? clsPluginHelper.DbNullIfNullOrEmpty("") : dtpClearnceDate.Value);
                  //  cmd.Parameters.AddWithValue("@ChallanNo", string.IsNullOrEmpty(txtChallanNo.Text) ? clsPluginHelper.DbNullIfNullOrEmpty("") : txtChallanNo.Text);

                    int result = 0;
                    result = cls_dl_InstRece.InstRece_NonQuery(cmd);

                    #endregion
                    if (result > 0)
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Try Again! or Contact to Admin!");
                    }
                    this.Close();

                }
                else
                {
                    MessageBox.Show("RecieveInstallmentID is empty.");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on saveInstallment.", ex, "frmDDModify");
                frmobj.ShowDialog();
            }
        }
        #endregion

        #region Adjustment of Receiving of this File
        private void ReceiveAdjustment()
        {
            SqlParameter[] prmt =
                   {
                     new SqlParameter("@Task","Rece_Plan_Adjust"),
                     new SqlParameter("@FileNo",lblfileno.Text)
                    };
            int rsult = Data_Layer.Installment.cls_dl_FinanceDashBoard.AccountStatement_RecePlanAdjust(prmt);

        }
        #endregion

        #region Bulk Acknowledgement
        private void AcknowledgementGeneration()
        {
            int totalexist = int.Parse(Helper.SQLHelper.ExecuteScalar(Helper.SQLHelper.createConnection(), CommandType.Text, @"SELECT COUNT(*)
                                FROM [DHAPeshawarDB].[dbo].[tbl_Acknowledgement] WHERE Rece_ID = '" + _ReceID.ToString() + "' AND StatusAck LIKE 'Not Printed'").ToString());
            if (totalexist > 0)
            {
                if (drpPaymentMethod.Text != "Surcharge")
                {
                    if (txtddstatus.Text != "Cleared")
                    {
                        SqlParameter[] param =
                      {
                    new SqlParameter("@Task","CancelAcknowledgement"),
                    new SqlParameter("@ReceID",_ReceID.ToString()),
                    new SqlParameter("@userID",clsUser.ID)
                    };
                        int result = cls_Fin_Acknowledgement.Fin_Acknowledgment_NonQuery(param);
                    }
                }
            }
            else
            {
                if (drpPaymentMethod.Text != "Surcharge")
                {
                    if (txtddstatus.Text == "Cleared")
                    {

                        SqlParameter[] param =
                        {
                            new SqlParameter("@Task", "GenerateAcknowledgement"),
                            new SqlParameter("@ReceID", _ReceID.ToString()),
                            new SqlParameter("@FileNo", lblfileno.Text),
                            new SqlParameter("@userID", clsUser.ID)
                        };
                        int result = cls_Fin_Acknowledgement.Fin_Acknowledgment_NonQuery(param);

                    }
                }

            }

        }
        #endregion 
        private void btnsave_Click(object sender, EventArgs e)
        {
            //DateTime ReceiveDate = DateTime.Parse(txtdate.Text);
            //DateTime DDGeneration = DateTime.Parse(dtpDDGenerationDate.Value.ToString("dd/MM/yyyy"));
            //if (ReceiveDate <= DateTime.Now && DDGeneration <= DateTime.Now)
            //{
            //    btnsave.Enabled = false;
            //    MessageBox.Show("Your Receive Date & DD Generation Date is Invalid.");
            //}
            //if (ReceiveDate > DateTime.Now.AddDays(-3))
            //{
            //    btnsave.Enabled = false;
            //    MessageBox.Show("Your Receive Date is Invalid ");
            //}
            //else
            //{
            saveInstallment();
            ReceiveAdjustment();
            AcknowledgementGeneration();
            //}


        }

        private void txtDDno_Leave(object sender, EventArgs e)
        {
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
                    MessageBox.Show("DDNo :" + ddno + " is use against the File No :" + fileno);
                }
            }
        }
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

        private void txtDynamicamount_Leave(object sender, EventArgs e)
        {
            if (txtamount != "")
            {
                //System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                //int valueBefore = Int32.Parse(txtDynamicamount.Text, System.Globalization.NumberStyles.AllowThousands);
                //txtamount = String.Format(culture, "{0:N0}", valueBefore);
                //txtamount = String.Format(culture, "{0:N0}", txtDynamicamount.Text);
                txtamount = txtDynamicamount.Text;
                int amount = (int)Double.Parse(txtamount);
                txtamountInWords.Text = Convert_Number_To_Text(amount, false);
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
            if (txtddstatus.SelectedIndex > 0)
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
                else
                {
                    btnsave.Enabled = true;
                }
            }

        }

        private void txtdate_Validating(object sender, CancelEventArgs e)
        {
            //DateTime dt =txtdate.Value;
            //if (dt<=DateTime.Now)
            //{
            //    btnsave.Enabled = false;
            //    MessageBox.Show("Your Receive Date is Invalid.");
            //}
            //if (dt<=DateTime.Now.AddDays(-3))
            //{
            //    btnsave.Enabled = false;
            //    MessageBox.Show("Your Receive Date is Invalid ");
            //}
            //else
            //{
            //    btnsave.Enabled = true;
            //}
        }

        private void dtpDDGenerationDate_Validating(object sender, CancelEventArgs e)
        {
            //    DateTime dt = dtpDDGenerationDate.Value;
            //    if (dt <= DateTime.Now)
            //    {
            //        btnsave.Enabled = false;
            //        MessageBox.Show("Your DD Generation Date is Invalid.");
            //    }
            //    else
            //    {
            //        btnsave.Enabled = true;
            //    }
        }
        public int startingform { get; set; } = 0;
        private void LockMonth_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtdate.MinDate = DateTime.Now.AddYears(-5);
                txtdate.MaxDate = DateTime.Now.AddYears(10);
                string[] dateparts = LockMonth.SelectedItem[0].ToString().Split('/');

                int MonthNo = DateTime.ParseExact(dateparts[0], "MMMM", CultureInfo.CurrentCulture).Month;
                int YearNo = int.Parse(dateparts[1]);
                var DateStarting = new DateTime(YearNo, MonthNo, 1);
                if (MonthNo == DateTime.Now.Month)
                {
                    txtdate.MinDate = DateStarting;
                    txtdate.MaxDate = DateTime.Now;
                }
                else
                {
                    txtdate.MinDate = DateStarting;
                    txtdate.MaxDate = DateStarting.AddMonths(1).AddSeconds(-1);
                }

                if (txtdate.MinDate < dtRec && dtRec.Year > 1900)
                {
                    txtdate.Enabled = true;
                }
                else if (dtRec < txtdate.MinDate && dtRec.Year > 1900)
                {
                    txtdate.MinDate = dtRec;
                    txtdate.Value = dtRec;
                    txtdate.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChkChallanReference_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            
        }
        private void ChallanDate()
        {
           /* SqlParameter[] param = {
                    new SqlParameter("@Task","ChallanSearchforReceInst"),
                    new SqlParameter("@ChalanNo",txtChallanNo.Text)
            };
            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "ch.USP_Challan", param);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    float Amount = float.Parse(ds.Tables[0].Rows[0]["TotalAmount"].ToString());
                    challanAmount.Text = string.Format("{0:n0}", Amount);
                    challanDate.Text = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString()).ToString("dd/MM/yyyy");
                    lblDDNo.Text = ds.Tables[0].Rows[0]["DDNo"].ToString();
                }
            }*/
        }

        private void ChkChallanReference_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                ChallanDate();
            }
        }

        private void btnChallanFind_Click(object sender, EventArgs e)
        {
            ChallanDate();
        }
    }
}
