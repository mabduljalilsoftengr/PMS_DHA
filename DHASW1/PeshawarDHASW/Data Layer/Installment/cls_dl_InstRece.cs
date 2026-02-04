using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Data_Layer.Installment
{
    public static class cls_dl_InstRece
    {
        public static DataSet VerifyDD(SqlParameter[] param)
        {
            DataSet ds = new DataSet();
            ds = SQLHelper.ExecuteDataset(
                                          clsMostUseVars.Connectionstring,
                                          CommandType.StoredProcedure,
                                          "App.USP_ReceInst",
                                          param);
            return ds;
        }
        public static DataSet MembershipVerification(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.USP_MemberShipVerifiyication",
                                                    parameter
                                                    );
            return ds;
        }

        #region Receive Installment DML, DRL Functions
        public static DataSet Inst_Rece_Read(SqlParameter[] parameter)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SQLHelper.ExecuteDataset(
                                                       clsMostUseVars.Connectionstring,
                                                       CommandType.StoredProcedure,
                                                       "App.USP_ReceInst",
                                                       parameter
                                                       );
            }
            catch (Exception ex)
            {

            }
            return ds;
        }
        public static DataSet Inst_Rece_Select(SqlParameter[] parameter)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SQLHelper.ExecuteDataset(
                                                       clsMostUseVars.Connectionstring,
                                                       CommandType.StoredProcedure,
                                                       "App.USP_tbl_ReceInst",
                                                       parameter
                                                       );
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        public static DataSet AR_Audit_Read(SqlParameter[] parameter)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SQLHelper.ExecuteDataset(
                                                       clsMostUseVars.Connectionstring,
                                                       CommandType.StoredProcedure,
                                                       "[dbo].[USP_AR_Audit]",
                                                       parameter
                                                       );
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        public static int Inst_Rece_NonQuery(SqlParameter[] parameter)
        {
            int rslt = 0;
            try
            {
                rslt = SQLHelper.ExecuteNonQuery(
                                                       clsMostUseVars.Connectionstring,
                                                       CommandType.StoredProcedure,
                                                       "App.USP_ReceInst",
                                                       parameter
                                                       );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException);
            }
            return rslt;
        }
        public static SqlCommand InstReceExecuteNonQuery(SqlParameter[] parameter)
        {
            SqlCommand result = new SqlCommand();
            try
            {
                result = SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(),
                                                        CommandType.StoredProcedure,
                                                        "App.USP_ReceInst", "",
                                                        parameter
                                                        );
            }
            catch (Exception ex)
            {
            }

            return result;
        }
        public static int DDTransfer_NonQuery(SqlParameter[] parameter)
        {
            int rslt = 0;
            try
            {
                rslt = SQLHelper.ExecuteNonQuery(
                                                       clsMostUseVars.Connectionstring,
                                                       CommandType.StoredProcedure,
                                                       "App.USP_DDTransfer",
                                                       parameter
                                                       );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException);
            }
            return rslt;
        }

        public static SqlCommand InstRece_CommandNonQuery(SqlParameter[] parameter)
        {
            SqlCommand result = new SqlCommand();
            try
            {
                result = SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(),
                                                        CommandType.StoredProcedure,
                                                        "ch.USP_Challan", "",
                                                        parameter
                                                        );
            }
            catch (Exception ex)
            {
            }

            return result;
        }
        public static int Inst_Rece_NonQuery(SqlParameter[] parameter, int totalTime)
        {
            int rslt = 0;
            try
            {
                rslt = SQLHelper.ExecuteNonQuery(
                                                       clsMostUseVars.Connectionstring,
                                                       CommandType.StoredProcedure,
                                                       "App.USP_ReceInst",
                                                       parameter
                                                       );
            }
            catch (Exception ex)
            {

            }
            return rslt;
        }
        public static int InstRece_NonQuery(SqlCommand command)
        {
            int result = 0;
            try
            {

                using (SqlConnection con = SQLHelper.createConnection())
                {
                    SqlCommand cmd = command;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    con.Close();
                    con.Open();
                    result = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }
        #endregion

        #region Saving of Image for Receive Installment
        public static int Insert_DD_Images(SqlParameter[] param)
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                   clsMostUseVars.VerifiedImageConnectionstring,
                                                   CommandType.StoredProcedure,
                                                   "usp_tbl_RecieveInstallmentImages",
                                                   param);
            return result;
        }

        internal static int Image_NonQuery(SqlParameter[] parameters)
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.VerifiedImageConnectionstring,
                                                    CommandType.StoredProcedure,
                                                    "usp_tbl_DDTransferImages",
                                                    parameters
                                                    );
            return result;
        }

        internal static int SurchargeWaiveImage_NonQuery(SqlParameter[] parameters)
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.VerifiedImageConnectionstring,
                                                    CommandType.StoredProcedure,
                                                    "usp_SurchargeWaiverMaster",
                                                    parameters
                                                    );
            return result;
        }

        internal static DataSet SurchargeWaiveImageDataset(SqlParameter[] parameters)
        {
            DataSet result = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.VerifiedImageConnectionstring,
                                                    CommandType.StoredProcedure,
                                                    "usp_SurchargeWaiverMaster",
                                                    parameters
                                                    );
            return result;
        }

        public static int Delete_DD_Images(SqlParameter[] param)
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                   clsMostUseVars.VerifiedImageConnectionstring,
                                                   CommandType.StoredProcedure,
                                                   "usp_tbl_RecieveInstallmentImages",
                                                   param);
            return result;
        }
        public static DataSet ReturnAllIDs(SqlParameter[] param)
        {

            return SQLHelper.ExecuteDataset(
                                          clsMostUseVars.VerifiedImageConnectionstring,
                                          CommandType.StoredProcedure,
                                          "usp_tbl_RecieveInstallmentImages",
                                          param);

        }

        #endregion



    }
}
