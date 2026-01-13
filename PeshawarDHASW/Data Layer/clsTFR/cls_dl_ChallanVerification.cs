using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Data_Layer.clsTFR
{
  public static class cls_dl_ChallanVerification
    {
        public static DataSet Verif  (SqlParameter[] parameters)
        {
            DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "App.USP_MemberShipVerifiyication",
                parameters);
            return ds;
        }
    }
}
