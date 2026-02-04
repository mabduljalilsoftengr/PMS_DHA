using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeshawarDHASW.Models
{
   public static class clsUser
    {
        public static int ID { get; set; } = 3;
        public static string username { get; set; } = "admin";
        public static string password { get; set; }
        public static string Name { get; set; } = "admin";
        public static string Father { get; set; } = "admin";
        public static string Email { get; set; } = "admin@admin.com";
        public static string Mobile { get; set; } = "03339090900";
        public static string Phone { get; set; } = "0915686789";
        public static string Address { get; set; } = "Peshawar";
        public static string Status { get; set; } = "Active";
        public static string Role { get; set; } = "1";
       public static string ThemeName { get; set; } = "TelerikMetro";
    }
}
