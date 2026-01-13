using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PeshawarDHASW.Data_Layer.Installment
{
    public static class cls_dl_Surcharge
    {
        public static int Surcharge_NonQuery(SqlParameter[] parameter)
        {
            int result = 0;
            try
            {
                result = SQLHelper.ExecuteNonQuery(
                                                 clsMostUseVars.Connectionstring,
                                                 CommandType.StoredProcedure,
                                                 "App.USP_SurchargeWaveoff",
                                                 parameter
                                                 );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in  Surcharge Module -> \n"+ex.Message);
            }

            return result;
        }

        public static DataSet Surcharge_Reader(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.USP_SurchargeWaveoff",
                                                    parameter
                                                    );
            return ds;
        }
    }
}
