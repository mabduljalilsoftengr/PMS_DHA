using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using PeshawarDHASW.Data_Layer.clsErrorLog;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Data_Layer
{
 public static   class cls_dl_DashBoard
    {
        public static DataSet Dashboard(SqlParameter[] parameter)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SQLHelper.ExecuteDataset(
                                                        clsMostUseVars.Connectionstring,
                                                        CommandType.StoredProcedure,
                                                        "App.usp_DashBoardforMIS",
                                                        parameter
                                                        );
            }
            catch (Exception ex)
            {
                cls_dl_ErrorLog.ErrorLogSAvetoDB(ex, "cls_dl_dash boad");
            }
            return ds;
        }
    }
}
