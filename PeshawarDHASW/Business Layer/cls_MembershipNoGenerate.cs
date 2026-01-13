using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PeshawarDHASW.Helper;
using System.Data;

namespace PeshawarDHASW.Business_Layer
{
  public static  class cls_MembershipNoGenerate
    {
      
        public static string MembershipNoGenerator()
        {
            DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "App.USPMemberShipGenerator");
            string PreviousMBNo = ds.Tables[0].Rows[0]["MembershipNo"].ToString();
            string[] number = PreviousMBNo.Split('-').ToArray();

            int newNumber = int.Parse(number[1]);
            string MBNO = "CG-" + (newNumber + 1).ToString();
            return MBNO;
        }
    }
}
