using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PeshawarDHASW.Data_Layer.clsChallan
{
    public class cls_dl_Challan
    {
        public static DataSet Challan_Reader(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "ch.USP_Challan",
                                                    parameter
                                                    );
            return ds;
        }

        
        public static int Challan_ExecuteNonQuery(SqlParameter[] parameter)
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "ch.USP_Challan",
                                                    parameter
                                                    );
            return result;
        }

        public static SqlCommand ChallanExecuteNonQuery(SqlParameter[] parameter)
        {
            SqlCommand result = new SqlCommand();
            try
            {
                result = SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(),
                                                        CommandType.StoredProcedure,
                                                        "ch.USP_Challan", "",
                                                        parameter
                                                        );
            }
            catch (Exception ex)
            { 
            }

            return result;
        }


        //......................   Challan Process .................//
        public static int ChallanPartDetails_NonQuery(SqlParameter[] parameter)
        {
            int result = 0;
            try
            {
                result = SQLHelper.ExecuteNonQuery(
                                                 clsMostUseVars.Connectionstring,
                                                 CommandType.StoredProcedure,
                                                 "[USP_ChallanCRUD]",
                                                 parameter
                                                 );
            }
            catch (Exception ex)
            {
              //  MessageBox.Show("");
            }

            return result;
        }

        public static DataSet Challan_ParticularHeadReader(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "[USP_ChallanCRUD]",
                                                    parameter
                                                    );
            return ds;
        }
        public static DataSet Challan_ParticularDetailsReader(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "[USP_ChallanCRUD]",
                                                    parameter
                                                    );
            return ds;
        }



        //.....................    Schedule  


        public static int Schedule_NonQuery(SqlParameter[] parameter)
        {
            int result = 0;
            try
            {
                result = SQLHelper.ExecuteNonQuery(
                                                 clsMostUseVars.Connectionstring,
                                                 CommandType.StoredProcedure,
                                            //   "[USP.tblComFileSchedule]",
                                            "App.USP_InstallmentPlan",
                                                 parameter
                                                 );
            }
            catch (Exception ex)
            {
                //  MessageBox.Show("");
            }

            return result;
        }

        public static DataSet GetFileCustomerDetail(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                            //   "[USP.tblComFileSchedule]",
                                            "App.USP_InstallmentPlan",
                                                    parameter
                                                    );
            return ds;
        }




        //............... End ....................//
        public static int Challan_NonQuery(SqlCommand command)
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
    }
}
