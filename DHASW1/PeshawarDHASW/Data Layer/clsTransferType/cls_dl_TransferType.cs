using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Data_Layer.clsTypeofPruchase
{
     public static   class cls_dl_TransferType
    {
        public static DataSet TypeofTansfer_Reader(SqlParameter[] param)
        {
            DataSet ds = new DataSet();
            ds = SQLHelper.ExecuteDataset(
                                          clsMostUseVars.Connectionstring,
                                          CommandType.StoredProcedure,
                                          "App.usp_tbl_TransferType",
                                          param);
            return ds;
        }
        public static int TransferType_NonQuery(SqlParameter[] param)
        {

            return SQLHelper.ExecuteNonQuery(
                                          clsMostUseVars.Connectionstring,
                                          CommandType.StoredProcedure,
                                          "App.usp_tbl_TransferType",
                                          param);
        }
        public static DataSet TypeofPurchase_Reader(SqlParameter[] param)
        {
            DataSet ds = new DataSet();
            ds = SQLHelper.ExecuteDataset(
                                          clsMostUseVars.Connectionstring,
                                          CommandType.StoredProcedure,
                                          "App.usp_tbl_PurchaseType",
                                          param);
            return ds;
        }
    }
}
