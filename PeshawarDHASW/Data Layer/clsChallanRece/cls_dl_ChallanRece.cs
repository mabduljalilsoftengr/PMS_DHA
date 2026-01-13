using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Data_Layer.clsChallanRece
{
   public static class cls_dl_ChallanRece
    {
        public static DataSet ChallanRece_Reader(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.USP_tbl_ChallanRece",
                                                    parameter
                                                    );
            return ds;
        }
        public static int ChallanRece_NonQuery(SqlParameter[] parameter)
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.USP_tbl_ChallanRece",
                                                    parameter
                                                    );
            return result;
        }
        public static int ChallanRece_NonQuery(SqlCommand command)
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

        public static int Challan_Dispose(SqlParameter[] param)
        {

            return SQLHelper.ExecuteNonQuery(
                                          clsMostUseVars.VerifiedImageConnectionstring,
                                          CommandType.StoredProcedure,
                                          "usp_tbl_RecieveOtherImages",
                                          param);

        }
        #region Saving And Retrive  Image Other Receive 
        public static int DML_Challan_Images(SqlParameter[] param)
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                              clsMostUseVars.VerifiedImageConnectionstring,
                                                              CommandType.StoredProcedure,
                                                              "usp_tbl_RecieveOtherImages",
                                                              param);
            return result;
        }
        public static DataSet OtherRece_Image_Retrive(SqlParameter[] param)
        {

            return SQLHelper.ExecuteDataset(
                                          clsMostUseVars.VerifiedImageConnectionstring,
                                          CommandType.StoredProcedure,
                                          "usp_tbl_RecieveOtherImages",
                                          param);

        }
        #endregion
    }
}
