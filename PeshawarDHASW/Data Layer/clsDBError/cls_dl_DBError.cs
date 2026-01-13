using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Data_Layer.clsDBError
{
  public static  class cls_dl_DBError
    {
        public static DataSet DBErrorLogReader(int recordsize)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] parameters =
           {
                new SqlParameter("@Task","Select"),
                new SqlParameter("@RecordSize",recordsize),

            };
                ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring,
                                                        CommandType.StoredProcedure,
                                                        "App.usp_tbl_DB_Error_log",
                                                        parameters
                                                        );

            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message);
            }
            return ds;
        }
    }
}
