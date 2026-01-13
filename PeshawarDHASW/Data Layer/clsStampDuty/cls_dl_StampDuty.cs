using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PeshawarDHASW.Data_Layer.clsStampDuty
{
    public static class cls_dl_StampDuty
    {
        public static DataSet StampDuty_Reader(SqlParameter[] parameters)
        {
            DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.StoredProcedure,
                                                  "App.Usp_tbl_StampDuty",
                                                  parameters);
            return ds;
        }
        public static int StampDuty_NonQuery(SqlParameter[] parameters)
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                 clsMostUseVars.Connectionstring,
                                                 CommandType.StoredProcedure,
                                                 "App.Usp_tbl_StampDuty",
                                                 parameters);
            return result;
        }
    }
}
