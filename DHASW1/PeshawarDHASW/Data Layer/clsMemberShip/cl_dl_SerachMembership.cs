using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Data_Layer.clsMemberShip
{
   public static class cl_dl_SerachMembership
    {
        //Not in use any more
       public static DataSet SearchForMembership(SqlParameter[] parameters)
       {
           DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "App.USP_SearchMembership",
               parameters);
           return ds;
       } 
        // not in use any more
        public static DataSet MembershipDataLoad()
        {
            DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "App.USP_LoadMemberShipData");
            return ds;
        }
        
        public static DataSet MembershipDataLoadforView(SqlParameter[] parameters)
       {
           DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "App.USP_ViewDataofMS",
               parameters);
           return ds;
       }

        public static DataSet MembershipNextofkinDataLoadforView(SqlParameter[] parameters)
        {
            DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "App.USP_ViewDataNextofkin",
                parameters);
            return ds;
        }

        public static DataSet MembershipFamilyDataLoadforView(SqlParameter[] parameters)
        {
            DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "App.USP_ViewDataofFamilyMembers",
                parameters);
            return ds;
        }


        //------------------------------- From Main Step Database----------------------------------------------//
        public static DataSet SearchForMembershipMain(SqlParameter[] parameters)
        {
            DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "App.USP_SearchMembership",
                parameters);
            return ds;
        }
    }
}
