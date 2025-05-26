using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PeshawarDHASW.Data_Layer.clsPhase
{
    public static class cls_dl_Phase
    {
        public static DataSet Phase_Reader(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.usp_tbl_Phase",
                                                    parameter
                                                    );
            return ds;
        }
        public static int Phase_NonQuery(SqlParameter[] parameter)
        {
            int rslt = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.usp_tbl_Phase",
                                                    parameter
                                                    );
            return rslt;
        }
    }
}
