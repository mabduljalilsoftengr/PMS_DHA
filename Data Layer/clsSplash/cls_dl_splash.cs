using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Data_Layer.clsSplash
{
    class cls_dl_splash
    {
        public static DataSet splash_Reader(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.tbl_splash",
                                                    parameter
                                                    );
            return ds;
        }

        public static int splash_NonQuery(SqlParameter[] parameter)
        {
            int result = 0;
            result = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.tbl_splash",
                                                    parameter
                                                    );
            return result;
        }

    }
}
