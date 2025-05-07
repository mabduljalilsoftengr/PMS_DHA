using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PeshawarDHASW.Data_Layer.clsFilePlotBinding
{
    public static class cls_dl_FilePlotBinding
    {
        public static int FilePlotBinding_NonQuery(SqlParameter[] parameter)
        {
            int result = 0;
            result = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.usp_tbl_FilePlotBinding",
                                                    parameter
                                                    );
            return result;
        }
        public static DataSet FilePlotBinding_Reader(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.usp_tbl_FilePlotBinding",
                                                    parameter
                                                    );
            return ds;
        }
    }
}
