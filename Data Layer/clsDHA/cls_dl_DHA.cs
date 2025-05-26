using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
namespace PeshawarDHASW.Data_Layer.clsDHA
{
    public static class cls_dl_DHA
    {
        public static DataSet DHA_Reader(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.usp_tbl_DHA",
                                                    parameter
                                                    );
            return ds;
        }
        public static int DHA_NonQuery(SqlParameter[] parameter)
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.usp_tbl_DHA",
                                                    parameter
                                                    );
            return result;
        }
    }
}
