using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Data_Layer.clsRole
{
  public static  class clsRoleMgt
    {
        public static DataTable Role_Reader(SqlParameter[] parameters)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "App.usp_tbl_Roles",
                parameters);

            }
            catch
                (Exception ex)
            {
                MessageBox.Show(ex.Message + "" + ex.InnerException + "" + ex.StackTrace);
            }

            return ds.Tables[0];
        }

        public static int Role_NonQuery(SqlParameter[] parameters)
        {
            int result = 0;
            try
            {
                result = SQLHelper.ExecuteNonQuery(clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "App.usp_tbl_Roles",
                parameters);

            }
            catch
                (Exception ex)
            {
                MessageBox.Show(ex.Message + "" + ex.InnerException + "" + ex.StackTrace);
            }

            return result;
        }
    }
}

