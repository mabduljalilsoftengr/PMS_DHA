using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PeshawarDHASW.Data_Layer.clsApplication
{
   static class cls_dl_Membership_PlotTYpe
    {
        public static DataSet PlotType()
        {
            DataSet dt = new DataSet();
            dt = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "App.USP_PlotType");
            return dt;
        }

        public static DataSet PlotTypeAll()
        {
            DataSet dt = new DataSet();
            dt = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "App.USP_PlotTypeAll");
            return dt;
        }
    }
}
