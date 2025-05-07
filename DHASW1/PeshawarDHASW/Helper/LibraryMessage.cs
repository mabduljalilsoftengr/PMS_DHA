using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PeshawarDHASW.Helper
{
   public static  class LibraryMessage
    {
        public static void Log(string text)
        {
            try
            {
                if (!Directory.Exists("c:\\DHA\\SMSSendLog"))
                    Directory.CreateDirectory("c:\\DHA\\SMSSendLog");
                using (StreamWriter writer = new StreamWriter("c:\\DHA\\SMSSendLog\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss tt") + " | " + text);
                }
            }
            catch (Exception)
            {

            }
        }


        public static void WriteErrorLog(Exception ex)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter("C:\\DHA\\SMSSendLog\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt", true);
                sw.WriteLine(DateTime.Now.ToString() + ": " + ex.Source.ToString().Trim() + "; " + ex.Message.ToString().Trim());
                sw.Flush();
                sw.Close();
            }
            catch
            {
            }
        }

        public static void WriteErrorLog(string Message)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter("C:\\DHA\\SMSSendLog\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt", true);
                sw.WriteLine(DateTime.Now.ToString() + ": " + Message);
                sw.Flush();
                sw.Close();
            }
            catch
            {
            }
        }
    }
}
