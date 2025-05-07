using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeshawarDHASW.Models
{
   public class clsDeposite
    {
        
        public int ID { get; set; }
        public int AppID { get; set; }
        public string PlotSize { get; set; }
        public string Amount { get; set; }
        public string BankName { get; set; }
        public string BranchCode { get; set; }
        public string DateofDeposite { get; set; }
        public string Status { get; set; }
        public int user_ID { get; set; }
    }
}
