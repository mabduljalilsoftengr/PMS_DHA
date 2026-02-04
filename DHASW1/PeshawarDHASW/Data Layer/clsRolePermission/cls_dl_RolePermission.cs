using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsErrorLog;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Data_Layer.clsRolePermission
{
    public static class cls_dl_RolePermission
    {
        public static DataTable RolePermission_Reader(SqlParameter[] parameters)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "App.usp_tbl_RoleCreate",
                parameters);

            }
            catch
                (Exception ex)
            {
                cls_dl_ErrorLog.ErrorLogSAvetoDB(ex, " tbl_RoleCreate_PermissionSetting_Reader");
           }

            return ds.Tables[0];
        }

        public static int RolePermission_NonQuery(SqlParameter[] parameters)
        {
            int result = 0;
            try
            {
                result = SQLHelper.ExecuteNonQuery(clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "App.usp_tbl_RoleCreate",
                parameters);

            }
            catch
                (Exception ex)
            {
                cls_dl_ErrorLog.ErrorLogSAvetoDB(ex, "tbl_RoleCreate_PermissionSetting_NonQuery");
            }

            return result;
        }
    }
}
