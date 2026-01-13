using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PeshawarDHASW.Data_Layer.clsTransferSummary
{
    public static class cls_dl_TransferSummary
    {
        public static DataSet TransferSumary_Read(SqlParameter[] param)
        {
            DataSet ds = new DataSet();
            try
            {
               
                ds = SQLHelper.ExecuteDataset(
                                              clsMostUseVars.Connectionstring,
                                              CommandType.StoredProcedure,
                                              "App.USP_TransferSummary",
                                              param);
                
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);;
            }
            return ds;
        }
        public static int TransferSummary_NonQuery(SqlParameter[] param)
        {

            return SQLHelper.ExecuteNonQuery(
                                          clsMostUseVars.Connectionstring,
                                          CommandType.StoredProcedure,
                                          "App.USP_TransferSummary",
                                          param);
        }
    }
}
