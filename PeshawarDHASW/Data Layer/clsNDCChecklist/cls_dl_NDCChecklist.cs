using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PeshawarDHASW.Data_Layer.clsNDCChecklist
{
   public static class cls_dl_NDCChecklist
    {
        public static DataSet NDCCheckListReader(SqlParameter[] parameter)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SQLHelper.ExecuteDataset(
                                                   clsMostUseVars.Connectionstring,
                                                   CommandType.StoredProcedure,
                                                   "App.USP_NDC_Checklist",
                                                   parameter
                                                   );
            }
            catch(Exception ex) { }
            return ds;
        }
        public static int NDCCheckListNonQuery(SqlParameter[] parameter)
        {
            int reslt = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.USP_NDC_Checklist",
                                                    parameter
                                                    );
            return reslt;
        }
    }
}
