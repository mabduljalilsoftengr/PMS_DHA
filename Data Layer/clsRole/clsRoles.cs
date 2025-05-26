using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Models;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Data_Layer.clsRole
{
    public static class clsRoles
    {
        public static DataTable RolebaseDataRetrive(SqlParameter[] parameters)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "App.USP_RolebaseControlActive",
                parameters);

            }
            catch
                (Exception ex)
            {
                MessageBox.Show(ex.Message + "" + ex.InnerException + "" + ex.StackTrace);
            }

            return ds.Tables[0];
        }

        public static DataTable UserBaseControl(SqlParameter[] parameters)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "App.USP_UserBaseControl",
                parameters);

            }
            catch
                (Exception ex)
            {
                MessageBox.Show(ex.Message + "" + ex.InnerException + "" + ex.StackTrace);
            }

            return ds.Tables[0];
        }
    }
}
