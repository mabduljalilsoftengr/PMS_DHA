using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Data_Layer.clsTFR
{
    class cls_dl_TFR
    { 
        /// <summary>
        /// Search Transfer
        /// </summary>
        /// <param name="parameters"> FileNo and PlotNo</param>
        /// <returns></returns>
        public static DataSet SearchForMembership(SqlParameter[] parameters)
        {
            DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "App.USP_SearchCurrentOwnerofPlot",
                parameters);
            return ds;
        }
        //App.USP_Transfer_SearchNewMSNO

        public static DataSet SearchNewMS(SqlParameter[] parameters)
        {
            DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "App.USP_Transfer_SearchNewMSNO",
                parameters);
            return ds;
        }

        public static DataSet Check_MS_ThatNotuseofAnyTFR(SqlParameter[] parameters)
        {
            DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "App.USP_Check_MS_is_Not_in_use_for_TFR",
                parameters);
            return ds;
        }

        public static DataSet TypeofTFR(SqlParameter[] parameters = null)
        {
            DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "App.USP_Plot_TypeSelect",
                parameters);
            return ds;
        }

        public static DataSet SearchFileNOwithNDC(SqlParameter[] parameters = null)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                 clsMostUseVars.Connectionstring,
                                                 CommandType.StoredProcedure,
                                                 "App.USP_tbl_FileMap",
                                                 parameters);
            return ds;
        }

        public static int TranferSetting(SqlParameter[] parameters = null)
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                 clsMostUseVars.Connectionstring,
                                                 CommandType.StoredProcedure,
                                                 "App.usp_Transfer",
                                                 parameters);
            return result;
        }
        public static DataSet TranferRead(SqlParameter[] parameters = null)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                 clsMostUseVars.Connectionstring,
                                                 CommandType.StoredProcedure,
                                                 "App.usp_Transfer",
                                                 parameters);
            return ds;
        }
    }
}
