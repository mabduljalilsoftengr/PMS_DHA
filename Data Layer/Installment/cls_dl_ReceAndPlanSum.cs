using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Data_Layer.Installment
{
   public static class cls_dl_ReceAndPlanSum
    {
        public static DataSet ReceAndPlanSumReader(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.USP_AdjustSummaryofReceandPLan",
                                                    parameter
                                                    );
            return ds;
        }
    }
}
