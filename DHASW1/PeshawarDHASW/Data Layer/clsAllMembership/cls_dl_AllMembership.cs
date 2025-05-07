using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Data_Layer.clsAllMembership
{
  public static  class cls_dl_AllMembership
    {

        public static DataTable AllMembership_Reader(SqlParameter[] parameters)
        {
            DataSet ds = new System.Data.DataSet();
            try
            {
                ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, 
                         CommandType.StoredProcedure,
                         "App.USP_AllMembership",
                         parameters);

            }
            catch
                (Exception ex)
            {
                RadMessageBox.Show(ex.Message + "" + ex.InnerException + "" + ex.StackTrace);
            }

            return ds.Tables[0];
        }

        public static int AllMembership_NonQuery(SqlParameter[] parameters)
        {
            int result = 0;
            try
            {
                result = SQLHelper.ExecuteNonQuery(clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "App.USP_AllMembership",
                parameters);

            }
            catch
                (Exception ex)
            {
                RadMessageBox.Show(ex.Message + "" + ex.InnerException + "" + ex.StackTrace);
            }

            return result;
        }
    }
}
