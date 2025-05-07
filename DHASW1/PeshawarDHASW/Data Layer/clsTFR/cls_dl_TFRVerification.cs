using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Data_Layer.clsTFR
{
   public static class cls_dl_TFRVerification
    {
        public static DataSet TFRVerification_Reader(SqlParameter[] parameters)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                  clsMostUseVars.Connectionstring,
                                                  CommandType.StoredProcedure,
                                                  "App.usp_TransferVerification",
                                                  parameters);
            return ds;
        }

        public static int TFRVerification_NonQuery(SqlParameter[] parameters)
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                   clsMostUseVars.Connectionstring,
                                                   CommandType.StoredProcedure,
                                                   "App.usp_TransferVerification",
                                                    parameters);
            return result;
        }
    }
}
