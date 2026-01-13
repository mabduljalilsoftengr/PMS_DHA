using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Data_Layer.clsPlotType
{
  public static  class cls_dl_PlotType
    {
        public static DataSet PlotType(SqlParameter[] parameters)
        {
            DataSet ds = new DataSet();
            ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, 
                                          CommandType.StoredProcedure,
                                          "App.usp_tbl_Plot_Type",
                                          parameters);
            return ds;
        }

        public static int PlotTypeAll(SqlParameter[] parameters)
        {
            return  SQLHelper.ExecuteNonQuery(clsMostUseVars.Connectionstring, 
                                              CommandType.StoredProcedure,
                                              "App.usp_tbl_Plot_Type", 
                                              parameters); 
        }
    }
}
