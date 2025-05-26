using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PeshawarDHASW.Data_Layer.clsAcknowledgment
{
  public static  class cls_dl_Acknowledgment
    {

        public static int Acknowledgment_NonQuery(SqlParameter[] prm)
        {
            int result = 0;
          try
            {
                result = SQLHelper.ExecuteNonQuery(
                                                            clsMostUseVars.Connectionstring,
                                                            CommandType.StoredProcedure,
                                                            "App.usp_tbl_Acknowledgment",
                                                            prm);
            }
            catch(Exception ex)
            {
                MessageBox.Show(""+ex);
            }
              
            
            return result;
        }
        #region  Acknowledgment Read
        public static DataSet AcknowledgementDataRead(SqlParameter[] prm)
        {
            DataSet ds = new DataSet();
            try
            {

                ds = SQLHelper.ExecuteDataset(
                                              clsMostUseVars.Connectionstring,
                                              CommandType.StoredProcedure,
                                              "App.usp_AccountReporting_Member",
                                              prm);
            }
            catch (Exception ex)
            {
                MessageBox.Show("");
            }
            return ds;
        }

        public static DataSet AcknowledgementReader(SqlParameter[] prm)
        {
            DataSet ds = new DataSet();
            try
            {

                ds = SQLHelper.ExecuteDataset(
                                              clsMostUseVars.Connectionstring,
                                              CommandType.StoredProcedure,
                                              "App.usp_tbl_Acknowledgment",
                                              prm);
            }
            catch (Exception ex)
            {
                MessageBox.Show("");
            }
            return ds;
        }

        #endregion
    }
}
