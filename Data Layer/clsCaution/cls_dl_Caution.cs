using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PeshawarDHASW.Data_Layer.clsCaution
{
    public static   class cls_dl_Caution
    {
        public static DataSet Caution_Reader(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                     clsMostUseVars.Connectionstring,
                                                     CommandType.StoredProcedure,
                                                     "App.usp_tbl_Caution",
                                                     parameter
                                                     );
            return ds;
        }
        public static int Caution_NonQuery(SqlParameter[] parameter)
        {
            int result = 0;
            try
            {

                result = SQLHelper.ExecuteNonQuery(
                                                        clsMostUseVars.Connectionstring,
                                                        CommandType.StoredProcedure,
                                                        "App.usp_tbl_Caution",
                                                        parameter
                                                        );
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return result;
        }
    }
}
