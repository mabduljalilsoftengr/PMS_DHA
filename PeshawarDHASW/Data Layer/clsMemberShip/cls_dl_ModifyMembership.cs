using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Data_Layer.clsMemberShip
{
   public static class cls_dl_ModifyMembership
    {
       public static void Modify_Membership_biodata(SqlParameter[] parameters)
       {
           int result = SQLHelper.ExecuteNonQuery(clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "App.USP_ModifyMSBioData",
               parameters);
       }

        public static void Modify_Membership_nextofkin(SqlParameter[] parameters)
        {
            try
            {
                int result = SQLHelper.ExecuteNonQuery(clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "App.USP_NextofkinModify",
                               parameters);
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
           
        }

        public static void Modify_Membership_familymember(SqlParameter[] parameters)
        {
            int result = SQLHelper.ExecuteNonQuery(clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "App.USP_FamilyMemberUpdate",
                parameters);
        }
    }
}
