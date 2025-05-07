using PeshawarDHASW.Models;
using PMS_Setting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Launching
{
    public partial class FinBankReceiveInfoUploading_OnlineFeeVerification : Telerik.WinControls.UI.RadForm
    {
        public FinBankReceiveInfoUploading_OnlineFeeVerification()
        {
            InitializeComponent();
        }
        private DataSet ds_bankTrxID { get; set; }
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

        private void grdtransactionID_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "Verify")
                {
                    int trxid = Convert.ToInt32(e.Row.Cells["ReciveBankChallan_ID"].Value.ToString());
                    string ChallanNo = e.Row.Cells["ChallanNo"].Value.ToString();
                    SqlParameter[] param =
                    {
                     new SqlParameter("@Task","UpdateClearToVerifiedFromPortal_of_OnlineTable"),
                     new SqlParameter("@ChallanNO", ChallanNo),
                     new SqlParameter("@UserName",clsUser.Name),
                     new SqlParameter("@Status","VerifiedFromPortal")
                    };
                    int Result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "Launching.CommercialLaunching", param);
                    if (Result > 0)
                    {
                        MessageBox.Show("Successful.");
                        btnverify_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Not Verified , Please Contatc with Administration.");
                    }
                    
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ntbOnlinePaymentReconsilation_Click(object sender, EventArgs e)
        {
            try
            {
                //string ChallanNo = ""; //= e.Row.Cells["ChallanNo"].Value.ToString();
                SqlParameter[] param =
                {
                     //new SqlParameter("@ChallanNO", ChallanNo),
                     new SqlParameter("@UserName",clsUser.Name)
                };
                int Result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "Launching.p_Get_Application_Fin_Reconsilation_Online", param);

                MessageBox.Show("Fee Received is Synched Suceessfully in Offline Tables.");

                btnverify_Click(sender, e);
                SyncApplicationStatusOnline();

                //if (Result > 1)
                //{
                //    MessageBox.Show("Successful.");
                //    btnverify_Click(sender, e);
                //}
                //else
                //{
                //    MessageBox.Show("Record Not Synchronized.");
                //}
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            //if (e.Column.Name == "Verify")
            //{
            // int trxid = Convert.ToInt32(e.Row.Cells["ReciveBankChallan_ID"].Value.ToString());
            // }
        }


        public static async void SyncApplicationStatusOnline()
        {
            string strConnStringOffline = MainConnections.ConnectionString_MainServer;
            string strConnStringOnline = MainConnections.ConnectionString_MainServer_DHADB;

            string Counts = "";
            string Result = "";
            try
            {
                DataTable dt = new DataTable();
                #region DatabaseConnection PMS
                using (SqlConnection con = new SqlConnection(strConnStringOffline))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("Launching.p_Synctbl_ApplicationInfo_With_OnlineTbl", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // cmd.Parameters.AddWithValue("@LastSnycData", Data.DateOfSync);
                        SqlDataAdapter dap = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        dap.Fill(ds);
                        #region DataTable Generation
                        dt = ds.Tables[0];// ToDataTable(ds.Tables[0]);
                        #endregion


                    }
                }

                #endregion


                #region DatabaseConnection ONLINE Site
                using (SqlConnection seccon = new SqlConnection(strConnStringOnline))
                {
                    seccon.Open();
                    using (SqlCommand cmd1 = new SqlCommand("USP_Synctbl_ApplicationInfo_With_OnlineTbl", seccon))
                    {
                        cmd1.CommandType = CommandType.StoredProcedure;
                        SqlParameter parameter = new SqlParameter();
                        //The parameter for the SP must be of SqlDbType.Structured
                        parameter.ParameterName = "@OnlineApplicantInfo";
                        parameter.SqlDbType = System.Data.SqlDbType.Structured;
                        parameter.Value = dt;
                        cmd1.Parameters.Add(parameter);
                        SqlDataAdapter dap = new SqlDataAdapter(cmd1);
                        DataSet ds = new DataSet();
                        dap.Fill(ds);
                        Counts = ds.Tables[0].Rows[0]["Counts"].ToString();


                        if (Counts == "9999")
                        {
                            Result = "Online Status Sync Some Error Occures";
                        }
                        else
                        {
                            Result = "Online Status Sync Success with records of " + Counts.ToString();
                        }
                        ////Counting check

                    }
                }
                MessageBox.Show(Result);
                #endregion
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
        private void FinBankReceiveInfoUploading_OnlineFeeVerification_Load(object sender, EventArgs e)
        {

        }
    }
}
