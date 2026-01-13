using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Data_Layer.NDC
{
    public static class cls_dl_NDC
    {
        public static DataSet NdcMemberVerification(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.USP_tbl_FileMap",
                                                    parameter
                                                    );
            return ds;
        }

        public static DataSet NdcRetrival(SqlParameter[] parameter)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SQLHelper.ExecuteDataset(
                                              clsMostUseVars.Connectionstring,
                                              CommandType.StoredProcedure,
                                              "App.USP_NDC",
                                              parameter
                                                             );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }

        public static int FBR_NonQuery(SqlParameter[] parameter)
        {
            int result = 0;
            try
            {
                result = SQLHelper.ExecuteNonQuery(
                                                 clsMostUseVars.Connectionstring,
                                                 CommandType.StoredProcedure,
                                            //   "[USP.tblComFileSchedule]",
                                            "App.USP_NDC",
                                                 parameter
                                                 );
            }
            catch (Exception ex)
            {
                //  MessageBox.Show("");
            }

            return result;
        }


        public static SqlCommand Refun_outparameter(SqlParameter[] parameter)
        {
            SqlCommand result = new SqlCommand();
            try
            {
                result = SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(),
                                                        CommandType.StoredProcedure,
                                                        "App.usp_tbl_Refund", "",
                                                        parameter
                                                        );
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.InnerException);
            }

            return result;
        }
        public static DataSet RefundRetrival(SqlParameter[] parameter)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SQLHelper.ExecuteDataset(
                                              clsMostUseVars.Connectionstring,
                                              CommandType.StoredProcedure,
                                              "App.usp_tbl_Refund",
                                              parameter
                                                             );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }
        public static int RefundNonQuery(SqlParameter[] parameter)
        {
            int result = 0;
            try
            {

                result = SQLHelper.ExecuteNonQuery(
                                                        clsMostUseVars.Connectionstring,
                                                        CommandType.StoredProcedure,
                                                        "App.usp_tbl_Refund",
                                                        parameter
                                                        );
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return result;
        }
        public static DataSet NdcRetrivalImages(SqlParameter[] prmtr)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SQLHelper.ExecuteDataset(
                                                                    clsMostUseVars.VerifiedImageConnectionstring,
                                                                    CommandType.StoredProcedure,
                                                                    "usp_tbl_NDC_Images",
                                                                    prmtr
                                                                    );
            }
            catch (Exception ex)
            {

            }

            return ds;
        }
        public static int NdcNonQuery(SqlParameter[] parameter)
        {
            int result = 0;
            try
            {

                result = SQLHelper.ExecuteNonQuery(
                                                        clsMostUseVars.Connectionstring,
                                                        CommandType.StoredProcedure,
                                                        "App.USP_NDC",
                                                        parameter
                                                        );
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return result;
        }
        public static int NdcNonQueryImage(SqlParameter[] prmtr)
        {
            int result = 0;
            try
            {
                result = SQLHelper.ExecuteNonQuery(
                                                        clsMostUseVars.VerifiedImageConnectionstring,
                                                        CommandType.StoredProcedure,
                                                        "usp_tbl_NDC_Images",
                                                        prmtr
                                                        );
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return result;
        }
    }
}
