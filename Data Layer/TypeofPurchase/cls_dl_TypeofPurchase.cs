using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Data_Layer
{
  public static  class cls_dl_TypeofPurchase
    {
        public static DataSet TypeofPurchase_Reader(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                   "App.usp_tbl_PurchaseType",
                                                    parameter
                                                    );
            return ds;
        }
        public static int TypeofPurchase_NonQuery(SqlParameter[] parameter)
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.usp_tbl_TypeofPurchase",
                                                    parameter
                                                    );
            return result;
        }

    }
}
