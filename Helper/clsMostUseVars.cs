using PMS_Setting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PeshawarDHASW.Helper
{
    public static class clsMostUseVars
    {
        public static string Connectionstring = MainConnections.ConnectionString_MainServer;// ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        //public static string Connectionstring = ConfigurationManager.ConnectionStrings["ConnectionStringMain"].ConnectionString;
        public static string VerifiedImageConnectionstring = MainConnections.ConnectionString_VerifiedImageDB; //ConfigurationManager.ConnectionStrings["VerifiedImageConnectionstring"].ConnectionString;
        public static string ConStringWebsite = MainConnections.ConnectionString_WebDatabase;// ConfigurationManager.ConnectionStrings["ConStringWebsite"].ConnectionString;
        //public static string Connectionstring = ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString;

        //public static string VerifiedVerifiedImageConnectionstring = ConfigurationManager.ConnectionStrings["VerifiedVerifiedImageConnectionstring"].ConnectionString;

        public static string applicationstartuppath { get; set; } = Application.StartupPath;
        public static int AppID { get; set; }
        public static bool Drctr_Secret_Code { get; set; } = false;

        public static DateTime ServerDateTime { get; set; } = clsPluginHelper.GetDate(SQLHelper.ExecuteScalar(Helper.SQLHelper.createConnection(), CommandType.Text, "Select Convert(varchar(12),Getdate(),103)").ToString());
        public static DataTable ReportDs { get; set; }
    }

}
