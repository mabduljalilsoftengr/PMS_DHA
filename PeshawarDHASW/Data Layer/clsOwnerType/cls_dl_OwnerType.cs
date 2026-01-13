using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Data_Layer.clsOwnerType
{
    public static class cls_dl_OwnerType
    {
        public static DataSet OwnerType_Reader(SqlParameter[] param)
        {
            DataSet ds = new DataSet();
            ds = SQLHelper.ExecuteDataset(
                                          clsMostUseVars.Connectionstring,
                                          CommandType.StoredProcedure,
                                          "App.usp_tbl_Owner_Category",
                                          param);
            return ds;
        }
        public static int OwnerType_NonQuery(SqlParameter[] param)
        {

            return  SQLHelper.ExecuteNonQuery(
                                          clsMostUseVars.Connectionstring,
                                          CommandType.StoredProcedure,
                                          "App.usp_tbl_Owner_Category",
                                          param);
          
        }
    }
}
