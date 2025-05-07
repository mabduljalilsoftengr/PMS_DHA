using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeshawarDHASW.Data_Layer.Installment
{
  public  class cls_dl_SurchargeWavier_ApplicationStatus
    {
        public static int SurchargeWavier_ApplicationStatus_NonQuery(SqlParameter[] parameter)
        {
            int result = 0;
            try
            {
                result = SQLHelper.ExecuteNonQuery(
                                                 clsMostUseVars.Connectionstring,
                                                 CommandType.StoredProcedure,
                                                 "App.USP_SurchargeWavier_ApplicationStatus",
                                                 parameter
                                                 );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return result;
        }

        public static DataSet SurchargeWavier_ApplicationStatus_Reader(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.USP_SurchargeWavier_ApplicationStatus",
                                                    parameter
                                                    );
            return ds;
        }

         
        //
        public static DataSet SurchargeWavier_ApplicationStatus_Data(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.USP_SurchargeWavier_ApplicationStatus",
                                                    parameter
                                                    );
            return ds;
        }

        //public static DataSet DateTimeSearch(SqlCommand command)
        //{
        //    SqlCommand cmd = command;
        //    SqlDataAdapter dap = new SqlDataAdapter(command);
        //    dap.SelectCommand = command;
        //    DataSet ds = new DataSet();
        //    dap.Fill(ds);
        //    return ds;
        //}
    }
}
