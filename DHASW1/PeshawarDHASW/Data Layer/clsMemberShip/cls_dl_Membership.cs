using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsErrorLog;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Data_Layer.clsMemberShip
{
    public static class cls_dl_Membership
    {

        #region Membership Personal Info
        public static int Membership_PersonalInfo(SqlParameter[] parameter)
        {
            int result = 0;
            try
            {
                result = SQLHelper.ExecuteNonQuery(
                                                                   clsMostUseVars.Connectionstring,
                                                                   CommandType.StoredProcedure,
                                                                    "App.usp_tbl_Membership",
                                                                   parameter
                                                                   );
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return result;
        }
        public static SqlCommand Membership_PersonalInfo_outparameter(SqlParameter[] parameter)
        {
            SqlCommand result = new SqlCommand();
            try
            {
                string a = "";
                result = SQLHelper.ExecuteNonQuery(     SQLHelper.createConnection(),
                                                        CommandType.StoredProcedure,
                                                        "App.usp_tbl_Membership", "",
                                                        parameter
                                                        );
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message+ex.InnerException);
            }
           
            return result;
        }

        public static DataSet Membership_PersonalInfo_Retrive(SqlParameter[] parameter)
        {
            DataSet ds = new DataSet();
            try
            {           
            ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.usp_tbl_Membership",
                                                    parameter
                                                    );
            }
            catch (Exception ex)
            {
                cls_dl_ErrorLog.ErrorLogSAvetoDB(ex, "cls_dl_membership");
            }
            return ds;
        }
        public static int Membership_Family_NonQuery(SqlCommand command)
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
        #endregion

        #region Membership Next of Kin

        public static DataSet Membership_NextofKin_Retrive(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.usp_tbl_MemberShipNextofKin ",
                                                    parameter
                                                    );
            return ds;
        }
        public static int Membership_NextofKin_NonQuery(SqlParameter[] parameter)
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.usp_tbl_MemberShipNextofKin ",
                                                    parameter
                                                    );
            return result;
        }
        #endregion

        #region Family Member
        public static int Membership_FamilyMember_NonQuery(SqlParameter[] parameter)
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.usp_tbl_FamilMember",
                                                    parameter
                                                    );
            return result;
        }

        public static DataSet Membership_FamilyMember_Retrive(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.usp_tbl_FamilMember",
                                                    parameter
                                                    );
            return ds;
        }
        #endregion

        #region Member Images
        public static int Membership_Image_NonQuery(SqlParameter[] parameter)
        {
            int result = 0;
            try
            {
                 result = SQLHelper.ExecuteNonQuery(
                                                                    clsMostUseVars.VerifiedImageConnectionstring,
                                                                    CommandType.StoredProcedure,
                                                                    "usp_tbl_MemberImages",
                                                                    parameter
                                                                    );
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.InnerException);
            }
            
            return result;
        }

        public static DataSet Membership_Image_Retrive(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.VerifiedImageConnectionstring,
                                                    CommandType.StoredProcedure,
                                                    "usp_tbl_MemberImages",
                                                    parameter
                                                    );
            return ds;
        }
        #endregion

        #region Membership Verification
        public static DataSet Membership_Verify(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.USP_VerifyMBNoforNoK",
                                                    parameter
                                                    );
            return ds;
        }


        public static DataSet Membership_VerifyforFamilyMember(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.USP_VerifyMBNoforfamilyMember",
                                                    parameter
                                                    );
            return ds;
        }

        /// <summary>
        /// Membership ID find in Membership on the base of membership no
        /// </summary>
        /// <param name="parameter"> Sql Parameter Array by Ref</param>
        /// <returns>dataset which contain one Field which [ID]</returns>
        public static DataSet MembershipID_Finder(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.USP_MemberIDFinder",
                                                    parameter
                                                    );
            return ds;
        }
        #endregion

        //Main  Database
        #region Main Membership Personal Info
        public static int MainDB_Membership_PersonalInfo(SqlParameter[] parameter)
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.usp_tbl_Membership",
                                                    parameter
                                                    );
            return result;
        }

        public static DataSet MainDB_Membership_PersonalInfo_Retrive(SqlParameter[] parameter)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SQLHelper.ExecuteDataset(
                                                        clsMostUseVars.Connectionstring,
                                                        CommandType.StoredProcedure,
                                                        "App.usp_tbl_Membership",
                                                        parameter
                                                        );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               // cls_dl_ErrorLog.ErrorLogSAvetoDB(ex, "cls_dl_membership");
            }
            return ds;
        }
        public static int MainDB_Membership_Family_NonQuery(SqlCommand command)
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
        #endregion

        #region Main Membership Next of Kin

        public static DataSet MainDB_Membership_NextofKin_Retrive(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.usp_tbl_MemberShipNextofKin ",
                                                    parameter
                                                    );
            return ds;
        }
        public static int MainDB_Membership_NextofKin_NonQuery(SqlParameter[] parameter)
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.usp_tbl_MemberShipNextofKin ",
                                                    parameter
                                                    );
            return result;
        }
        #endregion

        #region Main Family Member
        public static int MainDB_Membership_FamilyMember_NonQuery(SqlParameter[] parameter)
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.usp_tbl_FamilMember",
                                                    parameter
                                                    );
            return result;
        }

        public static int MainDB_Membership_FamilyMember_NonQuery(SqlCommand command)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(clsMostUseVars.Connectionstring))
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
        public static DataSet MainDB_Membership_FamilyMember_Retrive(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.usp_tbl_FamilMember",
                                                    parameter
                                                    );
            return ds;
        }
        #endregion

        #region Membership  ALL Info
        public static int Membership_All_NonQuery(SqlParameter[] parameter)
        {
            int rslt = 0;
            try
            {
                rslt = SQLHelper.ExecuteNonQuery(
                                                        clsMostUseVars.Connectionstring,
                                                        CommandType.StoredProcedure,
                                                        "App.usp_tbl_Membership",
                                                        parameter
                                                        );
            }
            catch (Exception ex)
            {
                cls_dl_ErrorLog.ErrorLogSAvetoDB(ex, "cls_dl_membership");
            }
            return rslt;
        }
        public static DataSet Membership_All_Retrive(SqlParameter[] parameter)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SQLHelper.ExecuteDataset(
                                                        clsMostUseVars.Connectionstring,
                                                        CommandType.StoredProcedure,
                                                        "App.usp_tbl_Membership",
                                                        parameter
                                                        );
            }
            catch (Exception ex)
            {
                cls_dl_ErrorLog.ErrorLogSAvetoDB(ex, "cls_dl_membership");
            }
            return ds;
        }
        #endregion



        //Admin Basket Control DML
        public static DataSet executeQuery(string Connection,string Query)
        {
            return SQLHelper.ExecuteDataset(Connection, CommandType.Text, Query);
        }
    }
}
