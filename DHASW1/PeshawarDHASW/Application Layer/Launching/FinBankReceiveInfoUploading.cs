using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Launching
{


    public partial class FinBankReceiveInfoUploading : Telerik.WinControls.UI.RadForm
    {
        public FinBankReceiveInfoUploading()
        {
            InitializeComponent();
        }
        private DataSet ds_bankTrxID { get; set; }
        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "File (*.CSV;,*.TXT;)|*.CSV;*.TXT;|All files (*.*)|*.*";

                openFileDialog1.Multiselect = true;
                openFileDialog1.Title = "Select Bank Receive Information File";

                DialogResult dr = openFileDialog1.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    lblCurrentFile.Text = openFileDialog1.FileName;
                    if (File.Exists(openFileDialog1.FileName))
                    {
                        txtAllRecordInfo.Text = File.ReadAllText(openFileDialog1.FileName);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnUploadingRecord_Click(object sender, EventArgs e)
        {
            int error = 0;
            List<FinRecordUploadingModel> listdat = new List<FinRecordUploadingModel>();
            try
            {
                if (!string.IsNullOrEmpty(Convert.ToString(txtAllRecordInfo.Text)))
                {
                    string Records = Convert.ToString(txtAllRecordInfo.Text.Trim());
                    string[] totalLines = Regex.Split(Records, "\r\n");
                    foreach (var item in totalLines)
                    {
                        string[] Listinfo = Regex.Split(item, ",");


                        FinRecordUploadingModel obj = new FinRecordUploadingModel();
                        obj.BankTRXID = Listinfo[0];
                        obj.DepositSlipNo = Listinfo[1];
                        obj.PlotSize = Listinfo[2];
                        obj.BankName = Listinfo[3];
                        obj.BranchCode = Listinfo[4];
                        obj.Category = Listinfo[5];
                        obj.ApplicantName = Listinfo[6];
                        obj.CNIC_NICOP = Listinfo[7];
                        obj.MobileNo = Listinfo[8];
                        obj.Amount = Convert.ToDecimal(Listinfo[9]);
                        obj.DatetimeTR = DateTime.Parse(Listinfo[10]).ToString("yyyy-MM-dd");
                        listdat.Add(obj);
                        //lblTotalRecord.Text = "Total Record in List : " + listdat.Count.ToString();
                    }
                 }
            }
            catch (Exception ex)
            {
                error = error + 1;
                MessageBox.Show("Verify the CSV File Data. \n " + ex.Message);
            }
            if (error == 0)
            {
                try
                {
                    DataTable dt = Helper.clsPluginHelper.ToDataTable(listdat);
                    SqlParameter[] param = 
                    {
                    new SqlParameter() { ParameterName= "@BankReceData", SqlDbType=SqlDbType.Structured, Value= dt,Direction = ParameterDirection.Input },
                    new SqlParameter("@UserID",clsUser.Name)
                    };
                   
                    DataSet dst = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "Launching.USP_BankReceUpload", param);
                    Helper.SQLHelper.ExecuteScalar(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "Launching.p_Get_Application_Fin_Reconsilation");
                    if(dst.Tables.Count > 0)
                    {
                        if(dst.Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show("Total Records in List : "+ listdat.Count.ToString() +Environment.NewLine + 
                                            "Total New Records : " + dst.Tables[0].Rows[0]["EffectedRows"].ToString() + 
                                            " are Added to Server.");
                        }
                        else
                        {
                            MessageBox.Show("Total New Records : 0 are Added to Server.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Total New Records : 0 are Added to Server.");
                    }

                    txtAllRecordInfo.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            
            }
        }

      

        private void btnverify_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] prm =
                {
                new SqlParameter("@Bank_Transaction_ID",txtBankTransactionID.Text=="" ? null :txtBankTransactionID.Text)
                };
                ds_bankTrxID = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(),
                             CommandType.StoredProcedure, "Launching.p_Gettbl_ApplicationFeeInfo_Online_Clear", prm);
                grdtransactionID.DataSource = ds_bankTrxID.Tables[0].DefaultView;
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
                //DataTable dt = Helper.clsPluginHelper.ToDataTable(listdat);
                //SqlParameter[] param =
                //{
                //    new SqlParameter() { ParameterName= "@BankReceData", SqlDbType=SqlDbType.Structured, Value= dt,Direction = ParameterDirection.Input },
                //    new SqlParameter("@UserID",clsUser.Name)
                //};

                //string Result = Helper.SQLHelper.ExecuteScalar(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "Launching.USP_BankReceUpload", param).ToString();
                //Helper.SQLHelper.ExecuteScalar(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "Launching.p_Get_Application_Fin_Reconsilation");
                //MessageBox.Show("Total New Records : " + Result + " are Added to Server.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdtransactionID_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "Verify")
                {
                    int trxid = Convert.ToInt32(e.Row.Cells["ReciveBankChallan_ID"].Value.ToString());
                    string ChallanNo = e.Row.Cells["Bank_Transaction_ID"].Value.ToString();
                    SqlParameter[] param =
                    {
                     new SqlParameter("@ChallanNO", ChallanNo),
                     new SqlParameter("@UserName",clsUser.Name)
                    };
                    string Result = Helper.SQLHelper.ExecuteScalar(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "Launching.USP_BankReceUpload_Online", param).ToString();
                    if (Result == "200")
                    {
                        MessageBox.Show("Successful.");
                        btnverify_Click(sender,e);
                    }
                    else
                    {
                        MessageBox.Show("Respective Payment Form Data not Exist Or Waiting For Scrutiny.");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }

    public class FinRecordUploadingModel
    {
        public string BankTRXID { get; set; }
        public string DepositSlipNo { get; set; }
        public string PlotSize { get; set; }
        public string BankName { get; set; }
        public string BranchCode { get; set; }
        public string Category { get; set; }
        public string ApplicantName { get; set; }
        public string CNIC_NICOP { get; set; }
        public string MobileNo { get; set; }
        public decimal Amount { get; set; }
        public string DatetimeTR { get; set; }
    }
}
