using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PeshawarDHASW.Data_Layer.clsTFR
{
  public static  class cls_dl_TFRHistory
    {
        public static int TFRHistory_NonQuery(SqlParameter[] prmtr)
        {
            int result = 0;
            try
            {
                 result = SQLHelper.ExecuteNonQuery(
                                          clsMostUseVars.Connectionstring,
                                          CommandType.StoredProcedure, 
                                          "App.usp_tbl_TFRHistory",
                                          prmtr);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            return result;
        }
        public static DataSet TFRHistory_Reader(SqlParameter[] pam)
        {
            DataSet ds = new DataSet();
            ds = SQLHelper.ExecuteDataset(
                                          clsMostUseVars.Connectionstring,
                                          CommandType.StoredProcedure,
                                          "App.usp_tbl_TFRHistory",
                                          pam);
            return ds;
        }
        public static DataSet TFRReport_Reader(SqlParameter[] pam)
        {
            DataSet ds = new DataSet();
            try
            {
               
                ds = SQLHelper.ExecuteDataset(
                                              clsMostUseVars.Connectionstring,
                                              CommandType.StoredProcedure,
                                              "App.USP_tbl_TFRReport",
                                              pam);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
            return ds;
        }
    }
}
