using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace PeshawarDHASW.Models
{
    public class clsNextofkin
    {
        
        public int ID { get; set; }
        public int AppID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Father { get; set; }
        public string RelationWApplicant { get; set; }
        public string CNIC { get; set; }
        public string DOB { get; set; }
        public string Passport { get; set; }
        public int user_ID { get; set; }
    }
}
