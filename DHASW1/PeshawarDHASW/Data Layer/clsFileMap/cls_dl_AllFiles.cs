using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PeshawarDHASW.Data_Layer.clsFileMap
{
    public static class cls_dl_AllFiles
    {
        public static DataSet AllFile_Reader(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    //clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.USP_AllFileNo",
                                                    parameter
                                                    );
            return ds;
        }
        public static int AllFileNo_NonQuery(SqlParameter[] parameter)
        {
            int result = 0;
            result = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.USP_AllFileNo",
                                                    parameter
                                                    );
            return result;
        }
    }
}
