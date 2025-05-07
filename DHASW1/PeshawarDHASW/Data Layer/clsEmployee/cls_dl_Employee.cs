using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Data_Layer.clsEmployee
{
   public static class cls_dl_Employee
    {
        public static DataSet Employee_Reader(SqlParameter[] parameter, string procedure)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    procedure,
                                                    parameter
                                                    );
            return ds;
        }
        public static int Employee_NonQuery(SqlParameter[] parameter, string procedure)
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    procedure,
                                                    parameter
                                                    );
            return result;
        }
        public static SqlCommand Employee_PersonalInfo_outparameter(SqlParameter[] parameter)
        {
            SqlCommand result = new SqlCommand();
            try
            {
                string a = "";
                result = SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(),
                                                        CommandType.StoredProcedure,
                                                        "App.usp_tbl_Employee", "",
                                                        parameter
                                                        );
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.InnerException);
            }

            return result;
        }

    }
}
