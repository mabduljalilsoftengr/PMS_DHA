using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PeshawarDHASW.Data_Layer.clsSector
{
    public static class cls_dl_Sector
    {
        public static DataSet Sector_Reader(SqlParameter[] parameters)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                  clsMostUseVars.Connectionstring,
                                                  CommandType.StoredProcedure,
                                                  "App.usp_tbl_Sector",
                                                  parameters);
            return ds;
        }
        public static int Sector_NonQuery(SqlParameter[] parameters)
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                   clsMostUseVars.Connectionstring,
                                                   CommandType.StoredProcedure,
                                                   "App.usp_tbl_Sector",
                                                    parameters);
            return result;
        }
    }
}
