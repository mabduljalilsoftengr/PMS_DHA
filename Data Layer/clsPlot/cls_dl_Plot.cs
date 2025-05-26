using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PeshawarDHASW.Data_Layer.clsPlot
{
    public static class cls_dl_Plot
    {
        public static DataSet Plot_Reader(SqlParameter[] parameters)
        {
            DataSet ds = new DataSet();
            ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring,
                                          CommandType.StoredProcedure,
                                          "App.usp_tbl_Plot",
                                          parameters);
            return ds;
        }

        public static int Plot_NonQuery(SqlParameter[] parameters)
        {
            return SQLHelper.ExecuteNonQuery(clsMostUseVars.Connectionstring,
                                              CommandType.StoredProcedure,
                                              "App.usp_tbl_Plot",
                                              parameters);
        }
    }
}
