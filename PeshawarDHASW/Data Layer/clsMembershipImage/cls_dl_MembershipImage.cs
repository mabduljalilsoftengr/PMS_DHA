using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PeshawarDHASW.Data_Layer.clsErrorLog;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Data_Layer.clsMembershipImage
{
  public static  class cls_dl_MembershipImage
    {
        public static int ImageSaving(SqlParameter[] parameter)
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.USP_MembershipImageView",
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
                                                        clsMostUseVars.Connectionstring,
                                                        CommandType.StoredProcedure,
                                                        "App.USP_MembershipImageView",
                                                        parameter
                                                        );
            }
            catch (Exception ex)
            {
                cls_dl_ErrorLog.ErrorLogSAvetoDB(ex, "App.USP_MembershipImageView");
            }
            return ds;
        }

        public static DataSet DDTransferImage_Retriving(SqlParameter[] parameter)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SQLHelper.ExecuteDataset(
                                                        clsMostUseVars.VerifiedImageConnectionstring,
                                                        CommandType.StoredProcedure,
                                                        "usp_tbl_DDTransferImages",
                                                        parameter
                                                        );
            }
            catch (Exception ex)
            {
                cls_dl_ErrorLog.ErrorLogSAvetoDB(ex, "App.usp_tbl_DDTransferImages");
            }
            return ds;
        }

        public static DataSet SurchargeWaiveOffImage_Retriving(SqlParameter[] parameter)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SQLHelper.ExecuteDataset(
                                                        clsMostUseVars.VerifiedImageConnectionstring,
                                                        CommandType.StoredProcedure,
                                                        "usp_SurchargeWaiverMaster",
                                                        parameter
                                                        );
            }
            catch (Exception ex)
            {
                cls_dl_ErrorLog.ErrorLogSAvetoDB(ex, "App.[usp_SurchargeWaiverMaster]");
            }
            return ds;
        }

    }
}
