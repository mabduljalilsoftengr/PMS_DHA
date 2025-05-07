using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS_Setting
{
    public static class MainConnections
    {
        //////////////   Testing 1
        //public static string ConnectionString_MainServer { get; set; } = "Server=172.16.0.22; Database=DHAPeshawarDB;   user Id=sqluser; Password=Abc@1234;";
        //public static string ConnectionString_MainServer_DHADB { get; set; } = "Server=172.16.0.127; Database=DHADB;   user Id=sa; Password=!#bU+Ue9;";
        ////public static string ConnectionString_MainServer_DHADB { get; set; } = "Server=sql7004.site4now.net; Database=DB_A430E8_APITest16;   user Id=DB_A430E8_APITest16_admin; Password=Samsung@831;";
        //public static string ConnectionString_VerifiedImageDB { get; set; } = "Server=172.16.0.22; Database=VerifiedDbMembershipImages; user Id=sqluser; Password=Abc@1234;";
        //public static string ConnectionString_WebDatabase { get; set; } = "Server=sql7004.site4now.net; Database=DB_A430E8_LvWEBdB;  user Id=DB_A430E8_LvWEBdB_admin; Password=lDHA@WeBdB_Ms*19;";

        //////////////     Main
        public static string ConnectionString_MainServer { get; set; } = "Server=172.16.0.1; Database=DHAPeshawarDB;   user Id=sa; Password=!#bU+Ue9;";
        public static string ConnectionString_VerifiedImageDB { get; set; } = "Server=172.16.0.1; Database=VerifiedDbMembershipImages; user Id=sa; Password=!#bU+Ue9;";
        public static string ConnectionString_WebDatabase { get; set; } = "Server=sql7004.site4now.net; Database=DB_A430E8_LvWEBdB;  user Id=DB_A430E8_LvWEBdB_admin; Password=lDHA@WeBdB_Ms*19;";
        public static string ConnectionString_MainServer_DHADB { get; set; } = "Server=sql7001.site4now.net; Database=DB_A430E8_DHADB;  user Id=DB_A430E8_DHADB_admin; Password=Samsung@831;";


        ///////////////   Testing 2
        //public static string ConnectionString_MainServer { get; set; } = "Server=172.16.0.127; Database=DHAPeshawarDB;   user Id=sa; Password=!#bU+Ue9;";
        ////public static string ConnectionString_MainServer_DHADB { get; set; } = "Server=172.16.0.127; Database=DHADB;   user Id=sa; Password=!#bU+Ue9;";
        //public static string ConnectionString_MainServer_DHADB { get; set; } = "Server=sql7004.site4now.net; Database=DB_A430E8_APITest16;   user Id=DB_A430E8_APITest16_admin; Password=Samsung@831;";
        //public static string ConnectionString_VerifiedImageDB { get; set; } = "Server=172.16.0.127; Database=VerifiedDbMembershipImages; user Id=sa; Password=!#bU+Ue9;";
        //public static string ConnectionString_WebDatabase { get; set; } = "Server=sql7004.site4now.net; Database=DB_A430E8_LvWEBdB;  user Id=DB_A430E8_LvWEBdB_admin; Password=lDHA@WeBdB_Ms*19;";


        ////////////      Local
        //public static string ConnectionString_MainServer { get; set; } = "Server=.; Database=DHAPeshawarDB;   Integrated Security=true;";
        //public static string ConnectionString_VerifiedImageDB { get; set; } = "Server=.; Database=VerifiedDbMembershipImages; Integrated Security=true;";
        //public static string ConnectionString_WebDatabase { get; set; } = "Server=sql7004.site4now.net; Database=DB_A430E8_LvWEBdB;  user Id=DB_A430E8_LvWEBdB_admin; Password=lDHA@WeBdB_Ms*19;";
        //public static string ConnectionString_MainServer_DHADB { get; set; } = "Server=sql7001.site4now.net; Database=DB_A430E8_DHADB;  user Id=DB_A430E8_DHADB_admin; Password=Samsung@831;";

    }
}
