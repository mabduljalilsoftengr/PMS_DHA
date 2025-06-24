using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Data_Layer.Installment
{
    public static class cls_dl_instPlan
    {
        //"App.USP_InstallmentTemplate"
        public static DataSet InstalTemplate_Reader(SqlParameter[] parameter,string procedure)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    procedure,
                                                    parameter
                                                    );
            return ds;
        }

        public static DataSet InstalPlan_Reader(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.USP_InstallmentTemplate",
                                                    parameter
                                                    );
            return ds;
        }
        public static DataSet InstalPlanReader(SqlParameter[] parameter)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SQLHelper.ExecuteDataset(
                                                                   clsMostUseVars.Connectionstring,
                                                                   CommandType.StoredProcedure,
                                                                   "App.USP_InstallmentPlan",
                                                                   parameter
                                                                   );
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message+ex.InnerException);
            }
           
            return ds;
        }

        public static int InstalPlanNonQuery(SqlParameter[] parameter)
        {
            int rslt = 0;
            try
            {
                rslt = SQLHelper.ExecuteNonQuery(
                                                                   clsMostUseVars.Connectionstring,
                                                                   CommandType.StoredProcedure,
                                                                   "App.USP_InstallmentPlan",
                                                                   parameter
                                                                   );
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + ex.InnerException);
            }

            return rslt;
        }

        //New created
        public static int InstalPlan_NonQuery(SqlParameter[] parameter)
        {
            int rslt = 0;
            try
            {
                 rslt = SQLHelper.ExecuteNonQuery(
                                                        clsMostUseVars.Connectionstring,
                                                        CommandType.StoredProcedure,
                                                        "App.USP_CreateInstallTemplateAndPlan",
                                                        parameter
                                                    );
                //MessageBox.Show("Result: " + rslt);  // Even if it's -1, SP might have worked

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + ex.InnerException);
            }

            return rslt;
        }

        //New created BulkInsertInstallments
        public static int BulkInsertInstallments(DataTable installmentData, string fileNo, string planStatus,
                                        string templateStatus, string templateName, int userId)
        {
            using (SqlConnection connection = new SqlConnection(clsMostUseVars.Connectionstring))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("usp_InsertInstallmentPlan", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add table-valued parameter
                    SqlParameter tvpParam = command.Parameters.AddWithValue("@Installments", installmentData);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "dbo.InstallmentTableType";

                    // Add other parameters
                    command.Parameters.Add("@FileNo", SqlDbType.VarChar).Value = fileNo;
                    command.Parameters.Add("@PlanStatus", SqlDbType.VarChar).Value = planStatus;
                    command.Parameters.Add("@TemplateStatus", SqlDbType.VarChar).Value = templateStatus;
                    command.Parameters.Add("@TemplateName", SqlDbType.VarChar).Value = templateName;
                    command.Parameters.Add("@UserId", SqlDbType.Int).Value = Models.clsUser.ID;

                    return command.ExecuteNonQuery();
                }
            }
        }

        public static int InstalPlan_NonQuery(SqlParameter[] parameter, string procedure)
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    procedure,
                                                    parameter
                                                    );
            return result;
        }

        public static int InstalPlan_NonQuery(SqlCommand command)
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

        public static DataSet InstalPlan_Reader(SqlCommand command)
        {
            using (SqlConnection con = SQLHelper.createConnection())
            {
                SqlCommand cmd = command;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dap.Fill(ds);
                return ds;

            }
            
        }
    }
}
