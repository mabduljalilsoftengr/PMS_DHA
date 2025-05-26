using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PeshawarDHASW.Data_Layer.Installment
{
    public static class cls_dl_LockDate
    {
        public static DataSet LockDate_Search_Reader(SqlParameter[] param)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SQLHelper.ExecuteDataset(
                                                 clsMostUseVars.Connectionstring,
                                                 CommandType.StoredProcedure,
                                                 "App.USP_tbl_ReceInst_Lock",
                                                 param);
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        public static int LockDate_Create_Update(SqlParameter[] param)
        {
            int rslt = 0;
            rslt = SQLHelper.ExecuteNonQuery(
                                          clsMostUseVars.Connectionstring,
                                          CommandType.StoredProcedure,
                                          "App.USP_tbl_ReceInst_Lock",
                                          param);
            return rslt;
        }
    }
}
