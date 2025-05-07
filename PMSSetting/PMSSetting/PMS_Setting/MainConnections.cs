using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS_Setting
{
    public static class MainConnections
    {




        //public static string ConnectionString_MainServer { get; set; } = "Server=172.16.0.1; Database=DHAPeshawarDB;   user Id=sa; Password=!#bU+Ue9;";
        //public static string ConnectionString_MainServer_DHADB { get; set; } = "Server=172.16.0.1; Database=DHADB;   user Id=sa; Password=!#bU+Ue9;";
        ////public static string ConnectionString_MainServer_DHADB { get; set; } = "Server=sql7004.site4now.net; Database=DB_A430E8_APITest16;   user Id=DB_A430E8_APITest16_admin; Password=Samsung@831;";
        //public static string ConnectionString_VerifiedImageDB { get; set; } = "Server=172.16.0.1; Database=VerifiedDbMembershipImages; user Id=sa; Password=!#bU+Ue9;";
        //public static string ConnectionString_WebDatabase { get; set; } = "Server=sql7004.site4now.net; Database=DB_A430E8_LvWEBdB;  user Id=DB_A430E8_LvWEBdB_admin; Password=lDHA@WeBdB_Ms*19;";
        //public static string ConnectionString_ImageArchive { get; set; } = "Server=172.16.0.1; Database=ImageArchiveDB; Integrated Security=true;";
        //public static string ConnectionString_ComplaintMgt { get; set; } = "Server=172.16.0.1; Database=ComplaintMgtDB; user Id=sa; Password=abcd@1234;";// Integrated Security=true;";



        ////////////   Main 1    
        ////////////   Main 1 

        public static string ConnectionString_MainServer { get; set; } = "Server=172.16.0.1,1433;Database=DHAPeshawarDB;User Id=sa;Password=!#bU+Ue9;TrustServerCertificate=True;";

        public static string ConnectionString_MainServer_DHADB { get; set; } = "Server=172.16.0.1; Database=DHADB;   user Id=sa; Password=!#bU+Ue9;";
        //public static string ConnectionString_MainServer_DHADB { get; set; } = "Server=sql7004.site4now.net; Database=DB_A430E8_APITest16;   user Id=DB_A430E8_APITest16_admin; Password=Samsung@831;";
        public static string ConnectionString_VerifiedImageDB { get; set; } = "Server=172.16.0.1; Database=VerifiedDbMembershipImages; user Id=sa; Password=!#bU+Ue9;";
        public static string ConnectionString_WebDatabase { get; set; } = "Server=sql7004.site4now.net; Database=DB_A430E8_LvWEBdB;  user Id=DB_A430E8_LvWEBdB_admin; Password=lDHA@WeBdB_Ms*19;";
        public static string ConnectionString_ImageArchive { get; set; } = "Server=172.16.0.1; Database=ImageArchiveDB; Integrated Security=true;";
        public static string ConnectionString_ComplaintMgt { get; set; } = "Server=172.16.0.1; Database=ComplaintMgtDB; user Id=sa; Password=abcd@1234;";// Integrated Security=true;";


        ////public static string ConnectionString_MainServer { get; set; } = "Server=172.16.0.7; Database=DHAPeshawarDB;   user Id=sa; Password=!#bU+Ue9;";
        //public static string ConnectionString_MainServer_DHADB { get; set; } = "Server=172.16.0.7; Database=DHADB;   user Id=sa; Password=!#bU+Ue9;";
        ////public static string ConnectionString_MainServer_DHADB { get; set; } = "Server=sql7004.site4now.net; Database=DB_A430E8_APITest16;   user Id=DB_A430E8_APITest16_admin; Password=Samsung@831;";
        //public static string ConnectionString_VerifiedImageDB { get; set; } = "Server=172.16.0.7; Database=VerifiedDbMembershipImages; user Id=sa; Password=!#bU+Ue9;";
        //public static string ConnectionString_WebDatabase { get; set; } = "Server=sql7004.site4now.net; Database=DB_A430E8_LvWEBdB;  user Id=DB_A430E8_LvWEBdB_admin; Password=lDHA@WeBdB_Ms*19;";
        //public static string ConnectionString_ImageArchive { get; set; } = "Server=172.16.0.7; Database=ImageArchiveDB; Integrated Security=true;";
        //public static string ConnectionString_ComplaintMgt { get; set; } = "Server=172.16.0.7; Database=ComplaintMgtDB; user Id=sa; Password=abcd@1234;";// Integrated Security=true;";


        ///////////   Testing 2    
        //public static string ConnectionString_MainServer { get; set; } = "Server=172.16.0.6; Database=DHAPeshawarDB;   user Id=sa; Password=abcd@1234;";
        ////public static string ConnectionString_MainServer_DHADB { get; set; } = "Server=172.16.0.127; Database=DHADB;   user Id=sa; Password=!#bU+Ue9;";
        //public static string ConnectionString_VerifiedImageDB { get; set; } = "Server=172.16.0.6; Database=VerifiedDbMembershipImages; user Id=sa; Password=abcd@1234;";
        //public static string ConnectionString_WebDatabase { get; set; } = "Server=sql7004.site4now.net; Database=DB_A430E8_LvWEBdB;  user Id=DB_A430E8_LvWEBdB_admin; Password=lDHA@WeBdB_Ms*19;";
        //public static string ConnectionString_MainServer_DHADB { get; set; } = "Server=sql7004.site4now.net; Database=DB_A430E8_APITest16;   user Id=DB_A430E8_APITest16_admin; Password=Samsung@831;";
        //public static string ConnectionString_ImageArchive { get; set; } = "Server=172.16.0.6; Failover Partner=172.16.0.7; Initial Catalog=ImageArchiveDB; user Id=sa; Password=!#bU+Ue9;";
        //public static string ConnectionString_ComplaintMgt { get; set; } = "Server=172.16.0.6; Database=ComplaintMgtDB; user Id=sa; Password=abcd@1234;";

        ////////////    Local  Testing
        //public static string ConnectionString_MainServer { get; set; } = "Server=172.16.0.24; Database=DHAPeshawarDB; user Id=sa; Password=abcd@1234;";// Integrated Security=true;";
        //public static string ConnectionString_VerifiedImageDB { get; set; } = "Server=172.16.0.24; Database=VerifiedDbMembershipImages; user Id=sa; Password=abcd@1234;";//Integrated Security=true;";
        //public static string ConnectionString_ImageArchive { get; set; } = "Server=172.16.0.24; Database=ImageArchiveDB; user Id=sa; Password=abcd@1234;";//Integrated Security=true;";
        //public static string ConnectionString_WebDatabase { get; set; } = "Server=sql7004.site4now.net; Database=DB_A430E8_LvWEBdB;  user Id=DB_A430E8_LvWEBdB_admin; Password=lDHA@WeBdB_Ms*19;";
        //public static string ConnectionString_MainServer_DHADB { get; set; } = "Server=sql7001.site4now.net; Database=DB_A430E8_DHADB;  user Id=DB_A430E8_DHADB_admin; Password=Samsung@831;";
        //public static string ConnectionString_ComplaintMgt { get; set; } = "Server=172.16.0.6; Database=ComplaintMgtDB; user Id=sa; Password=abcd@1234;";// Integrated Security=true;";

        ////////////    Local Own Pc
        //public static string ConnectionString_MainServer { get; set; } = "Data Source=DESKTOP-8G7UDJT/SQL19;Initial Catalog=DHAPeshawarDB;Integrated Security=True";
        //public static string ConnectionString_MainServer_DHADB { get; set; } = "Server=DESKTOP-8G7UDJT/SQL19; Database=DHADB; Integrated Security=True";
        //public static string ConnectionString_VerifiedImageDB { get; set; } = "Server=DESKTOP-8G7UDJT/SQL19; Database=VerifiedDbMembershipImages; Integrated Security=True";
        //public static string ConnectionString_ImageArchive { get; set; } = "Server=DESKTOP-8G7UDJT/SQL19; Database=ImageArchiveDB; Integrated Security=true;";
        //public static string ConnectionString_WebDatabase { get; set; } = "Server=sql7004.site4now.net; Database=DB_A430E8_LvWEBdB; Integrated Security=True";
        //public static string ConnectionString_ComplaintMgt { get; set; } = "Server=DESKTOP-8G7UDJT/SQL19; Database=ComplaintMgtDB; Integrated Security=True";// Integrated Security=true;";
    }
}
