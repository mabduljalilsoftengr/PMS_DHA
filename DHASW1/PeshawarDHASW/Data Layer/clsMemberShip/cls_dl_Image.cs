using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using PeshawarDHASW.Data_Layer.clsErrorLog;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Data_Layer.clsMemberShip
{
  public static  class cls_dl_Image
    {
        //usp_tbl_MemberImages
        public static int ImageSaving(SqlParameter[] parameter)
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.VerifiedImageConnectionstring,
                                                    CommandType.StoredProcedure,
                                                    "usp_tbl_MemberImages",
                                                    parameter
                                                    );
            return result;
        }

        public static DataSet Image_Retriving(SqlParameter[] parameter)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SQLHelper.ExecuteDataset(
                                                        clsMostUseVars.VerifiedImageConnectionstring,
                                                        CommandType.StoredProcedure,
                                                        "usp_tbl_MemberImages",
                                                        parameter
                                                        );
            }
            catch (Exception ex)
            {
                cls_dl_ErrorLog.ErrorLogSAvetoDB(ex, "cls_dl_Image");
            }
            return ds;
        }
        public static DataSet Reader_FileID_ImagesTable(SqlParameter[] parameter)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SQLHelper.ExecuteDataset(
                                                        clsMostUseVars.VerifiedImageConnectionstring,
                                                        CommandType.StoredProcedure,
                                                        "usp_tbl_MemberImages",
                                                        parameter
                                                        );
            }
            catch (Exception ex)
            {
                cls_dl_ErrorLog.ErrorLogSAvetoDB(ex, "cls_dl_Image");
            }
            return ds;
        }
        public static DataSet Membership_PersonalInfo_Retrive(SqlParameter[] parameter)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SQLHelper.ExecuteDataset(
                                                        clsMostUseVars.VerifiedImageConnectionstring,
                                                        CommandType.StoredProcedure,
                                                        "usp_tbl_MemberImages",
                                                        parameter
                                                        );
            }
            catch (Exception ex)
            {
                cls_dl_ErrorLog.ErrorLogSAvetoDB(ex, "cls_dl_membership");
            }
            return ds;
        }
        public static DataSet File_Info_Retrive(SqlParameter[] parameter)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SQLHelper.ExecuteDataset(
                                                        clsMostUseVars.VerifiedImageConnectionstring,
                                                        CommandType.StoredProcedure,
                                                        "usp_tbl_MemberImages",
                                                        parameter
                                                        );
            }
            catch (Exception ex)
            {
                cls_dl_ErrorLog.ErrorLogSAvetoDB(ex, "cls_dl_membership");
            }
            return ds;
        }
        public static int Membership_PersonalInfo(SqlParameter[] parameter)
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "usp_tbl_MemberImages",
                                                    parameter
                                                    );
            return result;
        }
        #region Member Images
        public static int MainDB_Membership_Image_NonQuery(SqlParameter[] parameter)
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.VerifiedImageConnectionstring,
                                                    CommandType.StoredProcedure,
                                                    "dbo.usp_tbl_MemberImages",
                                                    parameter
                                                    );
            return result;
        }

        public static DataSet MainDB_Membership_Image_Retrive(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.VerifiedImageConnectionstring,
                                                    CommandType.StoredProcedure,
                                                    "dbo.usp_tbl_MemberImages",
                                                    parameter
                                                    );
            return ds;
        }
        #endregion
    }
}
