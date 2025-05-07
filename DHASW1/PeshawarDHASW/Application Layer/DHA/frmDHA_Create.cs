using PeshawarDHASW.Data_Layer.clsDHA;
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

namespace PeshawarDHASW.Application_Layer.DHA
{
    public partial class frmDHA_Create : Telerik.WinControls.UI.RadForm
    {
        private int DHAID { get; set; } = 0;
        public frmDHA_Create()
        {
            InitializeComponent();
        }
        public frmDHA_Create(int get_ID)
        {
            InitializeComponent();
            DHAID = get_ID;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(DHAID == 0)
            {
                #region INSERTION
                DateTime dtm = (dtpStartDate.DateTimePickerElement.Calendar.SelectedDate) == DateTime.Parse("01/01/0001 12:00:00 AM") ? DateTime.Now : (dtpStartDate.DateTimePickerElement.Calendar.SelectedDate);
                byte[] imgbyt = ImageToByteArray(pcbDHA.Image);
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","Insert"),
                new SqlParameter("@Name",txtName.Text),
                new SqlParameter("@StartingDate",dtm),
                new SqlParameter("@LocationMap",imgbyt),
                new SqlParameter("@GPSXY",txtGPSXY.Text),
                new SqlParameter("@userID",Models.clsUser.ID)
                };
                int rslt = Data_Layer.clsDHA.cls_dl_DHA.DHA_NonQuery(prm);
                if (rslt > 0)
                {
                    MessageBox.Show("Insertion Successfull.");
                    Clear();
                }
                #endregion
            }
            else
            {
                #region UPDATION
                DateTime dtm = (dtpStartDate.DateTimePickerElement.Calendar.SelectedDate) == DateTime.Parse("01/01/0001 12:00:00 AM") ? DateTime.Now : (dtpStartDate.DateTimePickerElement.Calendar.SelectedDate);
                byte[] imgbyt = ImageToByteArray(pcbDHA.Image);
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","Update"),
                new SqlParameter("@Name",txtName.Text),
                new SqlParameter("@StartingDate",dtm),
                new SqlParameter("@LocationMap",imgbyt),
                new SqlParameter("@GPSXY",txtGPSXY.Text),
                new SqlParameter("@userID",Models.clsUser.ID),
                new SqlParameter("@DHA_ID",DHAID)
                };
                int rslt = Data_Layer.clsDHA.cls_dl_DHA.DHA_NonQuery(prm);
                if (rslt > 0)
                {
                    MessageBox.Show("Updation Successfull.");
                    Clear();
                    this.Close();
                }
                #endregion
            }

        }
        private Byte[] ImageToByteArray(Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            Byte[] bytimg = ms.ToArray();
            return bytimg;
        }
        private void btnImageBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter =@"Images(*.BMP;*.JPEG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files (.)|*.*";
            openFileDialog1.Title = "Select Photos";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                pcbDHA.Image = new Bitmap(openFileDialog1.FileName);
            }

        }
        private void Clear()
        {
            txtGPSXY.Text = "";
            txtName.Text = "";
            dtpStartDate.DateTimePickerElement.Calendar.SelectedDate = DateTime.Now;
            pcbDHA.Image = null;
        }
        private void frmDHA_Create_Load(object sender, EventArgs e)
        {
            if(DHAID != 0)
            {
                btnSave.Text = "Update";
                #region Get Data
                SqlParameter[] prmt =
                {
                    new SqlParameter("@Task","Select"),
                    new SqlParameter("@DHA_ID",DHAID)
                };
                DataSet ds = cls_dl_DHA.DHA_Reader(prmt);
                txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                txtGPSXY.Text = ds.Tables[0].Rows[0]["GPSXY"].ToString();
                dtpStartDate.Value = DateTime.Parse(ds.Tables[0].Rows[0]["StartingDate"].ToString());
                pcbDHA.Image = ImageRetrive(ds.Tables[0], "LocationMap");
                #endregion
            }           
        }
        private Image ImageRetrive(DataTable table, string fieldName)
        {
            byte[] imgData = (byte[])table.Rows[0][fieldName];
            MemoryStream ms = new MemoryStream(imgData);
            ms.Position = 0;
            return Image.FromStream(ms);
        }
    }
}
