using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.Configuration;
using PeshawarDHASW.Application_Layer.Splash;
using PeshawarDHASW.Data_Layer.clsRole;
using PeshawarDHASW.Models;
using PeshawarDHASW.Application_Layer.Download;
using PeshawarDHASW.Helper;
using System.Globalization;
using PMS_Setting;

namespace PeshawarDHASW
{
    public partial class FrmLogin : RadForm
    {
        public FrmLogin()
        {
            InitializeComponent();
        }



        private void btnlogin_Click(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(MainConnections.ConnectionString_MainServer))
                {
                    SqlCommand cmd = new SqlCommand("App.USP_UsERLogin", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@username", txtusername.Text);
                    cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                    SqlDataAdapter dap = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    dap.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                       clsUser.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                       clsUser.username = dt.Rows[0]["username"].ToString();
                       clsUser.Name = dt.Rows[0]["Name"].ToString();
                       clsUser.Father = dt.Rows[0]["Father"].ToString();
                       clsUser.Email = dt.Rows[0]["Email"].ToString();
                       clsUser.Mobile = dt.Rows[0]["Mobile"].ToString();
                       clsUser.Role = dt.Rows[0]["Role"].ToString();
                       clsUser.Status = dt.Rows[0]["status"].ToString();
                       clsUser.ThemeName = dt.Rows[0]["ThemeName"].ToString();
                        
                        if (clsUser.Status == "Active")
                        {
                            this.Hide();
                            Application_Layer.Splash.splashscreen obj = new splashscreen();
                            obj.ShowDialog();

                        }

                        if (clsUser.Status == "Suspended")
                        {
                            this.Hide();
                            PeshawarDHASW.Application_Layer.Login.frmLoginDisable obj = new Application_Layer.Login.frmLoginDisable();
                            obj.ShowDialog();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Incorrect username or password", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("System is not Connected to the Server Kindly Check your network.\n" + ex.Message);
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.Text = "PMS Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            
//            try
//            {
//                string[] fmts ={"MM/dd/yyyy","MM/dd/yyyy",};

                

//                DateTime dt ;
//                if (DateTime.TryParseExact(DateTime.Now.Date.ToShortDateString(), fmts.ToArray(), CultureInfo.CurrentCulture, DateTimeStyles.None, out dt))
//                {
//                    dt = DateTime.Now;
//                     //.ToString(outputFormat);.ToString("dd-MMM-yy hh:mm:ss tt +00:00")
//                }
//                else
//                {
//                    throw new NotImplementedException("No appropriate method find to translate " + dt + " into date format.");
//                }


//                //clsPluginHelper.GetDateTimeChecking(DateTime.Now.Date.ToShortDateString());
//            }
//            catch (Exception ex)
//            {

//                MessageBox.Show(@"Your System Date Format is Invalid Kindly Convert to the System Date Formats Like 
//(M/d/yyyy):4/13/2018
//(dd/MM/yyyy):13/04/2018
//(MM/dd/yyyy):04/13/2018
//(yyyy-MM-dd):2018:/04/13
//(dd-MMM-yy):13/Apr/2018
//Application will shutdown.", "Unsupported System Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
//                Application.Exit();
//            }





            this.BeginInvoke((MethodInvoker)delegate
            {
                #region [Check for New version]
                try
                {
                    string Connected = System.Configuration.ConfigurationManager.AppSettings["DownloadLink"];

                    var CurrentVer = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                    System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)
                        System.Net.WebRequest.Create(Connected + "/MISDHAVersion.txt");
                    System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)req.GetResponse();
                    System.IO.Stream reciveStream = response.GetResponseStream();
                    System.IO.StreamReader readStream = new System.IO.StreamReader(reciveStream, Encoding.UTF8);
                    string s = readStream.ReadToEnd();
                    var version1 = new Version(s);
                    var version2 = new Version(CurrentVer);

                    var result = version1.CompareTo(version2);
                    if (result > 0)
                    {
                        string UpdateString = "";
                        req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(Connected + "/Update.txt");
                        response = (System.Net.HttpWebResponse)req.GetResponse();
                        reciveStream = response.GetResponseStream();
                        readStream = new System.IO.StreamReader(reciveStream, Encoding.UTF8);
                        UpdateString = readStream.ReadToEnd();
                        response.Close();

                        frmDownload frm = new frmDownload(UpdateString, s, Connected);
                        this.ShowInTaskbar = false;
                        frm.ShowDialog();
                        this.ShowInTaskbar = true;
                        if (frm.IsDownload)
                            return;
                    }
                    response.Close();
                }
                catch (Exception)
                {

                }
                #endregion

            });
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnforgotpwd_Click(object sender, EventArgs e)
        {
            Application_Layer.Login.frmForgotPassword ob = new Application_Layer.Login.frmForgotPassword();
            ob.ShowDialog();

        }

        private void FrmLogin_Shown(object sender, EventArgs e)
        {

        }
    }
}
