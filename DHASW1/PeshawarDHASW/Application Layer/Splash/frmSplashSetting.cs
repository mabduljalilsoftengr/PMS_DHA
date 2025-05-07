using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsSplash;
using PeshawarDHASW.Helper;
using Telerik.WinControls;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.Splash
{
    public partial class frmSplashSetting : Telerik.WinControls.UI.RadForm
    {
        public frmSplashSetting()
        {
            InitializeComponent();
        }

        private void btnNotificationSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtQuote.Text != "")
                {
                    SqlParameter[] parameters =
                    {
                        clsPluginHelper.SqlparameterAttachtext("@ID", "0"),
                        clsPluginHelper.SqlparameterAttachtext("@Task", "Insert_or_Update"),
                        clsPluginHelper.SqlparameterAttachtext("@Type", "Quote"),
                        clsPluginHelper.SqlparameterAttachtext("@Quotes", txtQuote.Text),
                        clsPluginHelper.SqlparameterAttachtext("@Status", "Disable")
                    };
                    cls_dl_splash.splash_NonQuery(parameters);
                    txtQuote.Text = "";
                }
                else
                {
                    MessageBox.Show("Fill the Quote Text Field.");

                }
                
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnNotificationSave_Click.", ex, "frmSplashSetting");
                frmobj.ShowDialog();

            }
        }

        private void Notification_data_loading()
        {
            try
            {
                #region Notification Data Load
                SqlParameter[] param =
                {
                    new SqlParameter("@Task", "Select_Quote_Reader"),
                };
                DataTable dt = cls_dl_splash.splash_Reader(param).Tables[0];
                gdsearchNotification.DataSource = dt.DefaultView;
                dgModiftyNotification.DataSource = dt.DefaultView;
                #endregion
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Notification_data_loading.", ex, "frmSplashSetting");
                frmobj.ShowDialog();
            }
        }
        private void Notification_Image_loading()
        {
            try
            {
                #region Notification Data Load
                SqlParameter[] param =
                {
                    new SqlParameter("@Task", "Select_Image_Reader"),
                };
                DataTable dt = cls_dl_splash.splash_Reader(param).Tables[0];
                gdImageSearch.DataSource = dt.DefaultView;
                //dgModiftyNotification.DataSource = dt.DefaultView;
                #endregion
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Notification_Image_loading.", ex, "frmSplashSetting");
                frmobj.ShowDialog();
            }
        }

        private void frmSplashSetting_Load(object sender, EventArgs e)
        {

            Notification_data_loading();
            Notification_Image_loading();

        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            Notification_data_loading();
            Notification_Image_loading();
        }

        private void dgModiftyNotification_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                int gridRowscount = dgModiftyNotification.CurrentCell.RowIndex;

                SqlParameter[] prm =
                {
                    new SqlParameter("@Task", "Insert_or_Update"),
                    new SqlParameter("@ID", dgModiftyNotification.Rows[gridRowscount].Cells[0].Value.ToString()),
                    new SqlParameter("@Type", "Quote"),
                    // new SqlParameter("@Image",System.DBNull.Value), 
                    new SqlParameter("@Quotes",
                        clsPluginHelper.DbNullIfNullOrEmpty(
                            dgModiftyNotification.Rows[gridRowscount].Cells[2].Value.ToString())),
                    new SqlParameter("@Status",
                        clsPluginHelper.DbNullIfNullOrEmpty(
                            dgModiftyNotification.Rows[gridRowscount].Cells[3].Value.ToString())),
                };
                int rslt = cls_dl_splash.splash_NonQuery(prm);
                Notification_data_loading();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on dgModiftyNotification_CellEndEdit.", ex, "frmSplashSetting");
                frmobj.ShowDialog();
            }
           
        }

        private void btnBrowseimage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter =
                    @"Images (*.BMP;*.JPG,*.PNG)|*.BMP;*.JPG;*.PNG| All files (.)|*.*";
                openFileDialog1.Title = "Select Photos";

                DialogResult dr = openFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {

                    string[] files = openFileDialog1.FileNames;
                    foreach (var pngFile in files)
                    {
                        try
                        {
                            splashScreenImage.Image = Image.FromFile(pngFile);
                        }
                        catch
                        {
                            Console.WriteLine("This is not an image file");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnBrowseimage_Click.", ex, "frmSplashSetting");
                frmobj.ShowDialog();
            }
           
        }
      
        private void btnImageSave_Click(object sender, EventArgs e)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                splashScreenImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                Byte[] Image = ms.ToArray();
                SqlParameter[] parameters =
                       {
                        clsPluginHelper.SqlparameterAttachtext("@ID", "0"),
                        clsPluginHelper.SqlparameterAttachtext("@Task", "Insert_or_Update"),
                        clsPluginHelper.SqlparameterAttachtext("@Type", "Image"),
                        clsPluginHelper.SqlparameterAttachtext("@Quotes",txtimagetitle.Text),
                        new SqlParameter("@Image", Image),
                        clsPluginHelper.SqlparameterAttachtext("@Status", "Disable")
                    };
            int res =    cls_dl_splash.splash_NonQuery(parameters);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnImageSave_Click.", ex, "frmSplashSetting");
                frmobj.ShowDialog();
            }
            
        }

        private void browseImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter =
                    @"Images (*.BMP;*.JPG,*.PNG)|*.BMP;*.JPG;*.PNG| All files (.)|*.*";
                openFileDialog1.Title = "Select Photos";

                DialogResult dr = openFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {

                    string[] files = openFileDialog1.FileNames;
                    foreach (var pngFile in files)
                    {
                        try
                        {
                            changeimage.Image = Image.FromFile(pngFile);
                        }
                        catch
                        {
                            Console.WriteLine("This is not an image file");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on browseImage_Click.", ex, "frmSplashSetting");
                frmobj.ShowDialog();
            }
           
        }

        private void btnsavechanges_Click(object sender, EventArgs e)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                changeimage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                Byte[] Image = ms.ToArray();
                int ID = 0;
                bool at = int.TryParse(txtImageID.Text, out ID);
                if (at)
                {
                    SqlParameter[] parameters =
                   {
                        clsPluginHelper.SqlparameterAttachtext("@ID",ID.ToString() ),
                        clsPluginHelper.SqlparameterAttachtext("@Task", "Insert_or_Update"),
                        clsPluginHelper.SqlparameterAttachtext("@Type", "Image"),
                        clsPluginHelper.SqlparameterAttachtext("@Quotes",txtimagetitle.Text),
                        new SqlParameter("@Image", Image),
                        clsPluginHelper.SqlparameterAttachtext("@Status", dpstatus.SelectedItem.ToString())
                    };
                    int res = cls_dl_splash.splash_NonQuery(parameters);
                }
                else
                {
                    MessageBox.Show("Please Enter Correct ID from Image Grid");
                }
            
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnsavechanges_Click.", ex, "frmSplashSetting");
                frmobj.ShowDialog();
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = 0;
                bool at = int.TryParse(txtImageID.Text, out ID);
                if (at)
                {
                    SqlParameter[] parameter =
                    {
                    new SqlParameter("@Task", "Select_Image"),
                    new SqlParameter("@ID",ID ),
                };
                    DataSet ds = cls_dl_splash.splash_Reader(parameter);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtimagetitle.Text = ds.Tables[0].Rows[0]["Quotes"].ToString();
                        byte[] imgData = (byte[])ds.Tables[0].Rows[0]["Image"];
                        changeimage.Image = clsImageHelper.byteArrayToImage(imgData);
                        clsPluginHelper.RadDropDownSelectByText(dpstatus, ds.Tables[0].Rows[0]["Status"].ToString());
                    }
                    else
                    {
                        MessageBox.Show("No Record Exist");
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnFind_Click.", ex, "frmSplashSetting");
                frmobj.ShowDialog();
            }
          
        }

        //private Image ImageRetrive(byte[] imgdata)
        //{
        //    MemoryStream ms = new MemoryStream(imgdata);
        //    ms.Position = 0;
        //    return Image.FromStream(ms);
        //}
    }
}
