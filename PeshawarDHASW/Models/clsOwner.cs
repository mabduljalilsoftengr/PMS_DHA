using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeshawarDHASW.Models
{
   public class clsOwner
    {
       public int FileID { get; set; }
        public string FileNO { get; set; }
        public int MemberID { get; set; }
        public string MembershipNO { get; set; }
        public string MemberName { get; set; }
        public string Status { get; set; }
        public int TypePurchaseID { get; set; }
        public string TypePurchaseName { get; set; }
        public int UserID { get; set; }
        public string RateofSale { get; set; }
        public string DateOfPurchase { get; set; }
        public string DateOfSale { get; set; }
    }
}
