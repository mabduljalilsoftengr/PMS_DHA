using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Data_Layer.clsTFR
{
   public static class cls_dl_TFRAppointment
    {
     

        public static DataSet NDCVerfication(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.USP_NDC",
                                                    parameter
                                                    );
            return ds;
        }


        public static DataSet TFRReader(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.usp_tbl_TFRAppointment",
                                                    parameter
                                                    );
            return ds;
        }


        public static int Appointment_NonQuery(SqlCommand command)
        {
            int result = 0;
            using (SqlConnection con = SQLHelper.createConnection())
            {
                SqlCommand cmd = command;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                con.Close();
                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();
            }
            return result;
        }
        public static int AppointmentNonQuery(SqlParameter[] prmtr)
        {
            int result = 0;
            result = SQLHelper.ExecuteNonQuery(
                                               clsMostUseVars.Connectionstring,
                                               CommandType.StoredProcedure,
                                               "App.usp_tbl_TFRAppointment",
                                               prmtr
                                               );
            return result;
        }
    }
}
