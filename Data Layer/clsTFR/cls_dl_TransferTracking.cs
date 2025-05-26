using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PeshawarDHASW.Data_Layer.clsTFR
{
    public static class cls_dl_TransferTracking
    {
        public static int TransferTracking_NonQuery(SqlParameter[] prmtr)
        {
            int rslt = SQLHelper.ExecuteNonQuery(clsMostUseVars.Connectionstring,
                                                CommandType.StoredProcedure,
                                                "App.usp_Transfer",
                                                prmtr);
            return rslt;
        }
        public static DataSet TransferTracking_Reader(SqlParameter[] prmtr)
        {
            DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring,
                                                CommandType.StoredProcedure,
                                                "App.usp_Transfer",
                                                prmtr);
            return ds;
        }
    }
}
