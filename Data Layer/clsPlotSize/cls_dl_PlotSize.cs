using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Data_Layer.clsPlotSize
{
   public static class cls_dl_PlotSize
    {
        public static DataSet PlotSize_Reader(SqlParameter[] param)
        {
            DataSet ds = new DataSet();
            ds = SQLHelper.ExecuteDataset(
                                          clsMostUseVars.Connectionstring,
                                          CommandType.StoredProcedure,
                                          "App.usp_tbl_Plot_Size",
                                          param);
            return ds;
        }
        public static int PlotSize_NonQuery(SqlParameter[] param)
        {

            return SQLHelper.ExecuteNonQuery(
                                          clsMostUseVars.Connectionstring,
                                          CommandType.StoredProcedure,
                                          "App.usp_tbl_Plot_Size",
                                          param);

        }
    }
}
