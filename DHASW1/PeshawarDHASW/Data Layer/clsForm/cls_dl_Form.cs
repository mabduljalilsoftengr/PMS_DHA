using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Data_Layer.clsForm
{
  public static  class cls_dl_Form
    {
        public static DataSet Form_Reader(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                   "App.usp_tbl_Form",
                                                    parameter
                                                    );
            return ds;
        }
        public static int Form_NonQuery(SqlParameter[] parameter)
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.usp_tbl_Form",
                                                    parameter
                                                    );
            return result;
        }
    }
}
