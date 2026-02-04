using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PeshawarDHASW.Data_Layer.Installment
{
    public static class cls_dl_FinanceDashBoard
    {
        public static DataSet InstallmentWise_Search_Reader(SqlParameter[] param)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SQLHelper.ExecuteDataset(
                                                 clsMostUseVars.Connectionstring,
                                                 CommandType.StoredProcedure,
                                                 "App.USP_FinanceDashBoard",
                                                 param);
            }
            catch (Exception ex)
            {
                
            }
            return ds;
        }

        public static DataSet InstallmentSummary_Reader(SqlParameter[] parameter)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                   "App.USP_FinanceDashBoard",
                                                    parameter
                                                    );
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message+ex.InnerException);
            }
           
            return ds;
        }


        public static DataSet Filestatus_Reader(SqlParameter[] parameter)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                   "App.USP_FileLock",
                                                    parameter
                                                    );
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + ex.InnerException);
            }

            return ds;
        }

        public static int AccountStatement_RecePlanAdjust(SqlParameter[] param)
        {
            int rslt = 0;

            rslt = SQLHelper.ExecuteNonQuery(
                                          clsMostUseVars.Connectionstring,
                                          CommandType.StoredProcedure,
                                          "App.USP_FinanceDashBoard",
                                          param);

            return rslt;
        }

        public static DataSet AccountStatement_RecePlanAdjustRetrive(SqlParameter[] param)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SQLHelper.ExecuteDataset(
                                          clsMostUseVars.Connectionstring,
                                          CommandType.StoredProcedure,
                                          "App.USP_FinanceDashBoard",
                                          param);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + ex.InnerException);
            }

            return ds;
        }
    }
}
