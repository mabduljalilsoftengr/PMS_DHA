using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsSplash;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Models;

using Telerik.WinControls;
using Resources = PeshawarDHASW.Properties.Resources;

namespace PeshawarDHASW.Application_Layer.Splash
{
    public partial class splashscreen : Telerik.WinControls.UI.RadForm
    {
        public splashscreen()
        {
            InitializeComponent();
            radProgressBar1.SeparatorWidth = 6;
            radProgressBar1.SweepAngle = 210;
            radProgressBar1.StepWidth = 12;
            LoaddatatoSplash();
        }

       

        private void LoaddatatoSplash()
        {
            try
            {
                SqlParameter[] parameters_Quote =
                {
                new SqlParameter("@Task","Select_Quote"),
                };
                DataSet data_quote = cls_dl_splash.splash_Reader(parameters_Quote);
                notificationtext.Text = data_quote.Tables[0].Rows[0]["Quotes"].ToString();
                lbluserinfo.Text = "Assalam - o - Alaikum ! " + clsUser.Name ;

                SqlParameter[] parameters_Image =
                {
                  new SqlParameter("@Task","Select_Image"),
                };
                DataSet ds = cls_dl_splash.splash_Reader(parameters_Image);
                if (ds.Tables[0].Rows.Count >0)
                {
                    splashmainpicture.Image = clsPluginHelper.ImageRetrive((byte[])ds.Tables[0].Rows[0]["Image"]);
                }
                else
                {
                    splashmainpicture.Image = Resources.studio;
                }
                // image
                
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException);
            }
           
        }
        int ticks = 0;
        private void splashtimer_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("hh:mm:ss tt");
            ticks++;
          
            if (ticks == 20)
            {
                radProgressBar1.Value1 = 0;
                radProgressBar1.Value2 = 0;
                //splashtimer.Enabled = false;
                splashtimer.Enabled = false;
                this.Hide();
                MainRibbonForm ojb = new MainRibbonForm();
                ojb.ShowDialog();
                ticks = 0;
            }
            else
            {
                int result = ticks/2;
                radProgressBar1.Value1 = result;
                radProgressBar1.Value2 = result;
                radProgressBar1.Text = result.ToString() + "%";
            }
        }
    }
}
