using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PeshawarDHASW.Data_Layer.clsAuthorizeDealer
{
    public static class cls_dl_AuthorizeDealer
    {
        public static DataSet AuthorizeDealer_Local_Reader(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                     clsMostUseVars.Connectionstring,
                                                     CommandType.StoredProcedure,
                                                     "App.USP_tbl_PropertyDealers",
                                                     parameter
                                                     );
            return ds;
        }
        public static int AuthorizeDealer_Local_NonQuery(SqlParameter[] parameter)
        {
            int result = 0;
            try
            {

                result = SQLHelper.ExecuteNonQuery(
                                                        clsMostUseVars.Connectionstring,
                                                        CommandType.StoredProcedure,
                                                        "App.USP_tbl_PropertyDealers",
                                                        parameter
                                                        );
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return result;
        }
        //// ConStringWebsite
        public static DataSet AuthorizeDealer_Web_Reader(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                     clsMostUseVars.ConStringWebsite,
                                                     CommandType.StoredProcedure,
                                                     "App.USP_tbl_PropertyDealers",
                                                     parameter
                                                     );
            return ds;
        }
        public static int AuthorizeDealer_Web_NonQuery(SqlParameter[] parameter)
        {
            int result = 0;
            try
            {

                result = SQLHelper.ExecuteNonQuery(
                                                        clsMostUseVars.ConStringWebsite,
                                                        CommandType.StoredProcedure,
                                                        "App.USP_tbl_PropertyDealers",
                                                        parameter
                                                        );
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return result;
        }
    }
}
