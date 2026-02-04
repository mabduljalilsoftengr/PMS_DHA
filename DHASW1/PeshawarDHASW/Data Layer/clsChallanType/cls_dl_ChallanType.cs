using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Data_Layer.clsChallanType
{
   public static class cls_dl_ChallanType
    {
        public static DataSet Challan_Reader(SqlParameter[] parameter, string procedure)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    procedure,
                                                    parameter
                                                    );
            return ds;
        }
        public static int Challan_NonQuery(SqlParameter[] parameter, string procedure)
        {
            int result = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    procedure,
                                                    parameter
                                                    );
            return result;
        }

    }
}
