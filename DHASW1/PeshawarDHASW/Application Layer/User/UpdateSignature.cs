using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.User
{
    public partial class UpdateSignature : Telerik.WinControls.UI.RadForm
    {
        public UpdateSignature()
        {
            InitializeComponent();
        }
        public int UserID { get; set; }
        public UpdateSignature(int ID,string UserName)
        {
            InitializeComponent();
            UserID = ID;
            lblUserName.Text = UserName;
        }
        
        private void btnbrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter =
                @"Images (*.BMP;*.JPG;*.JPEG;*.PNG)|*.BMP;*.JPG;*.JPEG;*.PNG| All files (.)|*.*";
            openFileDialog1.Title = "Select Photos";

            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                lblfileName.Text = openFileDialog1.FileName;
                picImage.ImageLocation = lblfileName.Text;
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                picImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                Byte[] Image = ms.ToArray();
                SqlParameter[] param = {
                        new SqlParameter("@Task","UserUpdateSignature"),
                        new SqlParameter("@signatureImage",Image),
                        new SqlParameter("@ID",UserID)
                };
                Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_UserInfo", param);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
