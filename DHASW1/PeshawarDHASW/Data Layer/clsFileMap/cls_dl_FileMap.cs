using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using PeshawarDHASW.Helper;
using System.Windows.Forms;

namespace PeshawarDHASW.Data_Layer.clsFileMap
{
    public static class cls_dl_FileMap
    {
        public static DataSet FileMap_Reader(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    //clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.USP_tbl_FileMap",
                                                    parameter
                                                    );
            return ds;
        }

        public static int FileMap_NonQuery(SqlParameter[] parameter)
        {
            int result = 0;
            result = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.USP_tbl_FileMap",
                                                    parameter
                                                    );
            return result;
        }

        public static DataSet Main_FileMap_Reader(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.USP_tbl_FileMap",
                                                    parameter
                                                    );
            return ds;
        }

        public static int Main_FileMap_NonQuery(SqlParameter[] parameter)
        {
            int result = 0;
            result = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.USP_tbl_FileMap",
                                                    parameter
                                                    );
            return result;
        }

        public static SqlCommand Main_FileMap_NonQuery_outparameter(SqlParameter[] parameter)
        {
            SqlCommand result = new SqlCommand();
            try
            {
                string a = "";
                result = SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(),
                                                        CommandType.StoredProcedure,
                                                       "App.USP_tbl_FileMap", "",
                                                        parameter
                                                        );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException);
            }

            return result;
        }

        public static int Main_FileMap_NonQuery_ImageSaving(SqlParameter[] parameter)
        {
            int result = 0;
            result = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.VerifiedImageConnectionstring,
                                                    CommandType.StoredProcedure,
                                                    "dbo.usp_tbl_BuyBackImages",
                                                    parameter
                                                    );
            return result;
        }
        public static DataSet Main_FileMap_Reader_ImageReadng(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.VerifiedImageConnectionstring,
                                                    CommandType.StoredProcedure,
                                                    "dbo.usp_tbl_BuyBackImages",
                                                    parameter
                                                    );
            return ds;
        }

        public static int Main_FileMap_NonQuery_FileCancelImageSaving(SqlParameter[] parameter)
        {
            int result = 0;
            result = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.VerifiedImageConnectionstring,
                                                    CommandType.StoredProcedure,
                                                    "dbo.usp_tbl_FileCancelationImages",
                                                    parameter
                                                    );
            return result;
        }
        public static DataSet Main_FileMap_Reader_FileCancelImageReadng(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.VerifiedImageConnectionstring,
                                                    CommandType.StoredProcedure,
                                                    "dbo.usp_tbl_FileCancelationImages",
                                                    parameter
                                                    );
            return ds;
        }

        #region Fill DropDowns
        public static DataSet Fill_ddlPlot_Buisiness_Type(SqlParameter[] param)
        {
            DataSet ds = new DataSet();
            ds = SQLHelper.ExecuteDataset(
                                          clsMostUseVars.Connectionstring,
                                          CommandType.StoredProcedure,
                                          "App.usp_tbl_PlotBuisiness_Type",
                                          param);
            return ds;
        }
        public static DataSet Fillddl_Transfer_Type(SqlParameter[] par)
        {
            DataSet ds = new DataSet();
            ds = SQLHelper.ExecuteDataset(
                                           clsMostUseVars.Connectionstring,
                                          CommandType.StoredProcedure,
                                          "App.usp_tbl_PurchaseType",
                                          par);
            return ds;
        }

        public static DataSet Fil_ddl_Owner_Category(SqlParameter[] par)
        {
            DataSet ds = new DataSet();
            ds = SQLHelper.ExecuteDataset(
                                           clsMostUseVars.Connectionstring,
                                          CommandType.StoredProcedure,
                                          "App.usp_tbl_Owner_Category",
                                          par);
            return ds;
        }

        public static DataSet Fillddl_PlotType(SqlParameter[] par)
        {
            DataSet ds = new DataSet();
            ds = SQLHelper.ExecuteDataset(
                                           clsMostUseVars.Connectionstring,
                                          CommandType.StoredProcedure,
                                          "App.usp_tbl_TransferType",
                                          par);
            return ds;
        }
        public static DataSet Fillddl_InstallmentTemplate(SqlParameter[] par)
        {
            DataSet ds = new DataSet();
            ds = SQLHelper.ExecuteDataset(
                                           clsMostUseVars.Connectionstring,
                                          CommandType.StoredProcedure,
                                          "App.USP_InstallmentTemplate",
                                          par);
            return ds;
        }
        #endregion


        #region Hint Data

        public static DataSet FileHintData_Retrive(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.usp_tbl_HintData",
                                                    parameter
                                                    );
            return ds;
        }
        public static int FileHintData_NonQuery(SqlParameter[] parameter)
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.usp_tbl_HintData",
                                                    parameter
                                                    );
            return result;
        }
        #endregion

        #region Hint Data

        public static DataSet FileData_Retrive(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.usp_tbl_AllFileNo",
                                                    parameter
                                                    );
            return ds;
        }
        public static int FileData_NonQuery(SqlParameter[] parameter)
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.usp_tbl_AllFileNo",
                                                    parameter
                                                    );
            return result;
        }
        #endregion



        public static DataSet Allotment_Reader(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    //clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "[App].[USP_PlotAllot]",
                                                    parameter
                                                    );
            return ds;
        }
        public static int Allotment_NonQuery(SqlParameter[] parameter)
        {
            int result = 0;
            result = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "[App].[USP_PlotAllot]",
                                                    parameter
                                                    );
            return result;
        }
    }
}
