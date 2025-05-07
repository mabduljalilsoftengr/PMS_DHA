using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Data_Layer.clsDataLogging
{
   public static class cls_dl_DataLogging
    {
        public static DataSet DataLogReader(string recordsize)
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
                                                        "App.usp_tbl_Logging",
                                                        parameters
                                                        );

            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message);
            }
            return ds;
        }
        public static DataSet DataLogHistoryReader(string  tablename,string recordsize)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] parameters =
           {
                new SqlParameter("@Task","Select_History"),
                new SqlParameter("@RecordSize",recordsize),
                new SqlParameter("@TableName",tablename)

            };
                ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring,
                                                        CommandType.StoredProcedure,
                                                        "App.usp_tbl_Logging",
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
