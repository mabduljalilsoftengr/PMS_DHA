using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsAcknowledgment;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Data_Layer.clsAcknowledgment
{
  public static   class cls_Fin_Acknowledgement
    {
        public static int Fin_Acknowledgment_NonQuery(SqlParameter[] prm)
        {
            int result = 0;
            try
            {
                result = SQLHelper.ExecuteNonQuery(
                                                            clsMostUseVars.Connectionstring,
                                                            CommandType.StoredProcedure,
                                                            "App.USP_Ack",
                                                            prm);
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }


            return result;
        }

        #region  Acknowledgment Read
        public static DataSet Fin_AcknowledgementDataRead(SqlParameter[] prm)
        {
            DataSet ds = new DataSet();
            try
            {

                ds = SQLHelper.ExecuteDataset(
                                              clsMostUseVars.Connectionstring,
                                              CommandType.StoredProcedure,
                                              "App.USP_Ack",
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
