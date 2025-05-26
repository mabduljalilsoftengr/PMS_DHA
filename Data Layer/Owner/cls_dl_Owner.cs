using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Data_Layer.Owner
{
  public static  class cls_dl_Owner
    {
        public static int Owner_NonQuery(SqlParameter[] param)
        {
            int result = 0;
            try
            {
                result = SQLHelper.ExecuteNonQuery(
                                                      clsMostUseVars.Connectionstring,
                                                      CommandType.StoredProcedure,
                                                      "App.usp_tbl_Owner",
                                                      param);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }

        public static DataSet Owner_Reader(SqlParameter[] param)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SQLHelper.ExecuteDataset(
                                                      clsMostUseVars.Connectionstring,
                                                      CommandType.StoredProcedure,
                                                      "App.usp_tbl_Owner",
                                                      param);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }

        #region Main OWner Entry
        public static int Main_DML_Owner(SqlParameter[] param)
        {
            int result = 0;
            try
            {
                result = SQLHelper.ExecuteNonQuery(
                                                      clsMostUseVars.Connectionstring,
                                                      CommandType.StoredProcedure,
                                                      "App.usp_tbl_Owner",
                                                      param);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }

        public static DataSet Main_Bind_Read(SqlParameter[] param)
        {
            DataSet ds = new DataSet();
            ds = SQLHelper.ExecuteDataset(
                                          clsMostUseVars.Connectionstring,
                                          CommandType.StoredProcedure,
                                          "App.usp_tbl_Owner",
                                          param);
            return ds;
        }
        #endregion
    }
}
