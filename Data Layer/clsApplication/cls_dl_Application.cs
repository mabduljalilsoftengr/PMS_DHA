using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data.SqlClient;
using PeshawarDHASW.Models;
using System.Data;
using PeshawarDHASW.Data_Layer.clsErrorLog;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Data_Layer.clsApplication
{
    public static class cls_dl_Application
    {
        public static DataSet Category()
        {
            DataSet dt = new DataSet();
            dt = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "App.USP_ApplicantCategories");
            return dt;
        }
        //  static SQLHelper sqlhelper = new SQLHelper();
        #region Save Applicant Data
        public static int ApplicationData(clsApplicant objApp, clsNextofkin objnk, clsDeposite objd )
        {
            int result = 0;
            try
            {
                #region Parameter
                //SqlParameter[] parameter = {
               //         //Registration Application
               //         new SqlParameter("@FormNo",objApp.FormNo),
               //         new SqlParameter("@Catergories",objApp.Catergories),
               //         new SqlParameter("@AppName",objApp.Name),
               //         new SqlParameter("@AppGender",objApp.Gender),
               //         new SqlParameter("@AppFather",objApp.Father),
               //         new SqlParameter("@CNIC",objApp.CNIC),
               //         new SqlParameter("@Religion",objApp.Religion),
               //         new SqlParameter("@PassportNo",objApp.PassportNo),
               //         new SqlParameter("@MailAddress",objApp.MailAddress),
               //         new SqlParameter("@PermentAddress",objApp.PermentAddress),
               //         new SqlParameter("@City",objApp.City),
               //         new SqlParameter("@District",objApp.District),
               //         new SqlParameter("@Country",objApp.Country),
               //         new SqlParameter("@Email",objApp.Email),
               //         new SqlParameter("@Phone",objApp.Phone),
               //         new SqlParameter("@Office",objApp.Office),
               //         new SqlParameter("@Mobile",objApp.Mobile),
               //        //Next of Kin
               //         new SqlParameter("@Name",objnk.Name),
               //         new SqlParameter("@Gender",objnk.Gender),
               //         new SqlParameter("@Father",objnk.Father),
               //         new SqlParameter("@NKNIC",objnk.CNIC),
               //         new SqlParameter("@RelationWApplicant",objnk.RelationWApplicant),
               //         new SqlParameter("@DOB",objnk.DOB),
               //         new SqlParameter("@Passport",objnk.Passport),
               //         new SqlParameter("@user_ID",objnk.user_ID.ToString()),
               //         //Deposite
               //         new SqlParameter("@PlotSize",objd.PlotSize),
               //         new SqlParameter("@Amount",objd.Amount),
               //         new SqlParameter("@BankName",objd.BankName),
               //         new SqlParameter("@BranchCode",objd.BranchCode),
               //         new SqlParameter("@DateofDeposite",objd.DateofDeposite),
               //         new SqlParameter("@Status",objd.Status),
                //         };
                #endregion

                using (SqlConnection con = new SqlConnection(clsMostUseVars.Connectionstring))
               {
                   con.Open();
                   SqlCommand cmd = new SqlCommand("App.USPApplicationReg", con);
                   cmd.CommandType = CommandType.StoredProcedure;
                    //-------------------- Application Registration
                   cmd.Parameters.AddWithValue("@FormNo", objApp.FormNo);
                   cmd.Parameters.AddWithValue("@Catergories",objApp.Catergories);
                   cmd.Parameters.AddWithValue("@AppName",objApp.Name);
                   cmd.Parameters.AddWithValue("@AppGender",objApp.Gender);
                   cmd.Parameters.AddWithValue("@AppFather",objApp.Father);
                   cmd.Parameters.AddWithValue("@CNIC",objApp.CNIC);
                   cmd.Parameters.AddWithValue("@Religion",objApp.Religion);;
                   cmd.Parameters.AddWithValue("@PassportNo",objApp.PassportNo);
                   cmd.Parameters.AddWithValue("@MailAddress",objApp.MailAddress);
                   cmd.Parameters.AddWithValue ("@PermentAddress",objApp.PermentAddress);
                   cmd.Parameters.AddWithValue("@City",objApp.City);
                   cmd.Parameters.AddWithValue("@District",objApp.District);
                   cmd.Parameters.AddWithValue("@Country",objApp.Country);
                   cmd.Parameters.AddWithValue("@Email",objApp.Email);
                   cmd.Parameters.AddWithValue("@Phone",objApp.Phone);
                   cmd.Parameters.AddWithValue("@Office",objApp.Office);
                   cmd.Parameters.AddWithValue("@Mobile",objApp.Mobile);
                   //--------------------Next Of Kin----------
                   cmd.Parameters.AddWithValue("@Name",objnk.Name);
                   cmd.Parameters.AddWithValue("@Gender",objnk.Gender);
                   cmd.Parameters.AddWithValue("@Father",objnk.Father);
                   cmd.Parameters.AddWithValue("@NKNIC",objnk.CNIC);
                   cmd.Parameters.AddWithValue("@RelationWApplicant",objnk.RelationWApplicant);
                   cmd.Parameters.AddWithValue("@DOB",objnk.DOB);
                   cmd.Parameters.AddWithValue("@NkPassportNo", objnk.Passport);
                   cmd.Parameters.AddWithValue("@user_ID",objnk.user_ID.ToString());
                   //-------------------Deposite ------------
                   cmd.Parameters.AddWithValue("@PlotSize",objd.PlotSize);
                   cmd.Parameters.AddWithValue("@Amount",objd.Amount);
                   cmd.Parameters.AddWithValue("@BankName",objd.BankName);
                   cmd.Parameters.AddWithValue("@BranchCode",objd.BranchCode);
                   cmd.Parameters.AddWithValue("@DateofDeposite",objd.DateofDeposite);
                   cmd.Parameters.AddWithValue("@Status",objd.Status);
                   result = cmd.ExecuteNonQuery();
               }
             //result =   SQLHelper.ExecuteNonQuery(
             //      connectionString: clsMostUseVars.Connectionstring,
             //      commandType: CommandType.StoredProcedure,
             //      commandText: "App.USPApplicationReg",
             //      commandParameters : parameter);
 
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message+"\n"+ ex.Source+"\n"+ ex.StackTrace);
            }
            
            return result;
        }
        #endregion

        #region Next of Kin
        public static DataSet NextofKinData_Retrive(SqlParameter[] param)
        {
            DataSet ds = new DataSet();
            ds = SQLHelper.ExecuteDataset(
                                          clsMostUseVars.Connectionstring,
                                          CommandType.StoredProcedure,
                                          "App.usp_tbl_Applicant",
                                          param);
            return ds;
        }
        public static int NextOfKinUpdate(SqlParameter[] parameter)
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.usp_tbl_NextOfKinApplicant",
                                                    parameter);
            return result;
        }
        public static int NextofKinData(clsNextofkin obj)
        {
            int result = 0;
            try
            {
                //@AppID,@Name,@Gender,@Father,@RelationWApplicant,@CNIC,@DOB,@Passport,@user_ID
                SqlParameter[] parameter = {
                        new SqlParameter("@ID",obj.ID),
                        new SqlParameter("@AppID",obj.AppID), 
                        new SqlParameter("@Name",obj.Name),
                        new SqlParameter("@Gender",obj.Gender),
                        new SqlParameter("@Father",obj.Father),
                        new SqlParameter("@CNIC",obj.CNIC),
                        new SqlParameter("@RelationWApplicant",obj.RelationWApplicant),
                        new SqlParameter("@DOB",obj.DOB),
                        new SqlParameter("@Passport",obj.Passport),
                        new SqlParameter("@user_ID",obj.user_ID)
                        };
                result = SQLHelper.ExecuteNonQuery(
                      connectionString: clsMostUseVars.Connectionstring,
                      commandType: CommandType.StoredProcedure,
                      commandText: "App.USP_NextofKin",
                      commandParameters: parameter);

            }
            catch (Exception ex)
            {

            }
            return result;
        }
        #endregion

        #region Category
        public static int Category_Insert(SqlParameter[] param) 
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                   clsMostUseVars.Connectionstring,
                                                   CommandType.StoredProcedure,
                                                   "App.usp_tbl_Category",
                                                   param
                                                   );
            return result;
        }
        public static DataSet CategoryAllData_Retrieve(SqlParameter[] parameter)
        {
            DataSet ds = new DataSet();
            ds = SQLHelper.ExecuteDataset(
                                          clsMostUseVars.Connectionstring,
                                          CommandType.StoredProcedure,
                                          "App.usp_tbl_Category",
                                          parameter);
            return ds;
        }
        public static DataSet CategorySearchData_Retrieve(SqlParameter[] param)
        {
            DataSet ds = new DataSet();
            ds = SQLHelper.ExecuteDataset(
                                          clsMostUseVars.Connectionstring,
                                          CommandType.StoredProcedure,
                                          "App.usp_tbl_Category",
                                          param);
            return ds;
        }
        public static DataSet CategorySearchByID(SqlParameter[] param)
        {
            DataSet ds = new DataSet();
            ds = SQLHelper.ExecuteDataset(
                                          clsMostUseVars.Connectionstring,
                                          CommandType.StoredProcedure,
                                          "App.usp_tbl_Category",
                                          param);
            return ds;
        }
        public static int UpdateCategory(SqlParameter[] prm)
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                   clsMostUseVars.Connectionstring,
                                                   CommandType.StoredProcedure,
                                                   "App.usp_tbl_Category",
                                                   prm);
            return result; 

        }
        #endregion
        #region Deposite
        public static DataSet RetrieveDepositData_Applicant(SqlParameter[] parametr)
        {
            DataSet ds = new DataSet();
            ds = SQLHelper.ExecuteDataset(
                                           clsMostUseVars.Connectionstring,
                                           CommandType.StoredProcedure,
                                           "App.usp_tbl_Deposite",
                                           parametr);
            return ds;
        }
        public static int UpdateDeposit_Applicant(SqlParameter[] prmtr)
        {
            int reslt = SQLHelper.ExecuteNonQuery(
                                                  clsMostUseVars.Connectionstring,
                                                  CommandType.StoredProcedure,
                                                  "App.usp_tbl_Deposite",
                                                  prmtr);
                return reslt;
        }
        public static int Deposite(clsDeposite obj)
        {
            int result = 0;
            try
            {
                //@AppID,@PlotSize,@Amount,@BankName,@BranchCode,@DateofDeposite,@Status,@user_ID
                SqlParameter[] parameter = {
                        new SqlParameter("@ID",obj.ID),
                        new SqlParameter("@AppID",obj.AppID), 
                        new SqlParameter("@PlotSize",obj.PlotSize),
                        new SqlParameter("@Amount",obj.Amount),
                        new SqlParameter("@BankName",obj.BankName),
                        new SqlParameter("@BranchCode",obj.BranchCode),
                        new SqlParameter("@DateofDeposite",obj.DateofDeposite),
                        new SqlParameter("@Status",obj.Status),
                        new SqlParameter("@user_ID",obj.user_ID)
                        };
                result = SQLHelper.ExecuteNonQuery(
                      connectionString: clsMostUseVars.Connectionstring,
                      commandType: CommandType.StoredProcedure,
                      commandText: "App.USP_Deposite",
                      commandParameters: parameter);

            }
            catch (Exception ex)
            {

            }
            return result;
        }
        #endregion
        #region Applicant Personal Info
        public static DataSet Applicant_Info_Retrive(SqlParameter[] parameter)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SQLHelper.ExecuteDataset(
                                                        clsMostUseVars.Connectionstring,
                                                        CommandType.StoredProcedure,
                                                        "App.usp_tbl_Applicant",
                                                        parameter
                                                        );
            }
            catch (Exception ex)
            {
                cls_dl_ErrorLog.ErrorLogSAvetoDB(ex, "cls_dl_membership");
            }
            return ds;
        }
        public static DataSet ApplicantInfoAllDataRetrive(SqlParameter[] parameter)
        {
            DataSet ds = new DataSet();
            ds = SQLHelper.ExecuteDataset(
                                          clsMostUseVars.Connectionstring,
                                          CommandType.StoredProcedure,
                                          "App.usp_tbl_Applicant",
                                          parameter);
            return ds;
        }
        public static int ApplicantInfoUpdate(SqlParameter[] parameter)
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.usp_tbl_Applicant",
                                                    parameter
                                                    );
            return result;
        }
        public static DataSet ApplicantDataRetrive()
        {
            DataSet dt = new DataSet();
            dt = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "App.USP_AllData");
            return dt;
        }
        #endregion
    }
}
