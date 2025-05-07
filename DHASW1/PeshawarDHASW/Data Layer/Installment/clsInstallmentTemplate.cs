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
    public static class clsInstallmentTemplate
    {
        #region Images
        public static int DDImagesSave(SqlParameter[] par)
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                   clsMostUseVars.Connectionstring,
                                                   CommandType.StoredProcedure,
                                                   "dbo.usp_tbl_DDImages",
                                                   par);
            return result;
        }
        public static int ChallanImagesSave(SqlParameter[] paramtr)
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                   clsMostUseVars.Connectionstring,
                                                   CommandType.StoredProcedure,
                                                   "dbo.usp_tbl_ChallanImages",
                                                   paramtr);
            return result;
        }
        #endregion
        public static int InstalTemplate_NonQuery(SqlParameter[] parameter)
        {
            int result = 0;
            try
            {
                result = SQLHelper.ExecuteNonQuery(
                                                 clsMostUseVars.Connectionstring,
                                                 CommandType.StoredProcedure,
                                                 "App.USP_InstallmentTemplate",
                                                 parameter
                                                 );
            }
            catch (Exception ex)
            {
                MessageBox.Show("");
            }

            return result;
        }

        public static DataSet InstalTemplate_Reader(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.USP_InstallmentTemplate",
                                                    parameter
                                                    );
            return ds;
        }

        public static DataSet CreateInsallmentTemplate(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.USP_CreateInstallmentPlan",
                                                    parameter
                                                    );
            return ds;
        }
        //
        public static DataSet PhaseData(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.USP_Phase",
                                                    parameter
                                                    );
            return ds;
        }

        public static DataSet DateTimeSearch(SqlCommand command)
        {
            SqlCommand cmd = command;
            SqlDataAdapter dap = new SqlDataAdapter(command);
            dap.SelectCommand = command;
            DataSet ds = new DataSet();
            dap.Fill(ds);
            return ds;
        }
    }
}
