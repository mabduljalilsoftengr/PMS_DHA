using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeshawarDHASW.Data_Layer.clsPlanEdit
{
    public class planEdit
    {
        public static DataSet getplantoEdit(SqlParameter[] parameter)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "USP_PlanEdit",
                                                    parameter
                                                    );
            return ds;
        }
    }
}
