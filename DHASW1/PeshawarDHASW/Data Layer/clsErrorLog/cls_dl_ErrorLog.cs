using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Models;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Data_Layer.clsErrorLog
{
    class cls_dl_ErrorLog
    {

        public static int ErrorLogSAvetoDB(Exception ex, string FormName)
        {
            int result = 0;
            try
            {
                SqlParameter[] parameters =
           {
                new SqlParameter("@Task","Insert"),
                new SqlParameter("@Message",ex.Message),
                //new SqlParameter("@Data",ex.Data),
               // new SqlParameter("@TargetSite",ex.TargetSite), 
                new SqlParameter("@HelpLink",ex.HelpLink),
                new SqlParameter("InnerException",ex.InnerException),
                new SqlParameter("Source",ex.Source),
               new SqlParameter("StackTrace",ex.StackTrace),
                new SqlParameter("@FormName",FormName),
                new SqlParameter("@userName","Name : "+Models.clsUser.Name+" > UserID = "+Models.clsUser.ID),
            };
                result = SQLHelper.ExecuteNonQuery(
                                                        clsMostUseVars.Connectionstring,
                                                        CommandType.StoredProcedure,
                                                        "App.USP_ErrorLog",
                                                        parameters
                                                        );
                
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message);
            }
            return result;
        }

        public static DataSet ErrorLogReader(int recordsize)
        {
           DataSet ds = new DataSet();
            try
            {
                SqlParameter[] parameters =
           {
                new SqlParameter("@Task","SelectError"),
                new SqlParameter("@RecordSize",recordsize), 
                
            };
                ds = SQLHelper.ExecuteDataset( clsMostUseVars.Connectionstring,
                                                        CommandType.StoredProcedure,
                                                        "App.USP_ErrorLog",
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
