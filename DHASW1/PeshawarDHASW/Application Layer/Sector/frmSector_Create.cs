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
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Sector
{
    public partial class frmSector_Create : Telerik.WinControls.UI.RadForm
    {
        private IEnumerable<DataRow> dtr { get; set; }
        public frmSector_Create()
        {
            InitializeComponent();
        }
        public frmSector_Create(int get_sectorid , IEnumerable<DataRow> get_selectedRow)
        {
            InitializeComponent();
            dtr = get_selectedRow;
            Sector_ID = get_sectorid;
        }
        private int Sector_ID { get; set; } = 0;
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Sector_ID == 0)
            {
                #region INSERTION
                if (drpdPhase.SelectedIndex >= 1)
                {
                byte[] imgbyt = ImageToByteArray(pcbSector.Image);
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","Insert"),
                new SqlParameter("@Name",txtSectorName.Text),
                new SqlParameter("@Phase_ID",drpdPhase.SelectedValue),
                new SqlParameter("@LocationMap",imgbyt),
                new SqlParameter("@GPSXY",txtGPSXY.Text),
                new SqlParameter("@Remarks",txtRemarks.Text),
                new SqlParameter("@userID",Models.clsUser.ID)
                };
                    int rslt = Data_Layer.clsSector.cls_dl_Sector.Sector_NonQuery(prm);
                    if (rslt > 0)
                    {
                        MessageBox.Show("Insertion Successfull.");
                        Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Phase Name.");
                }
                #endregion
            }
            else
            {
                #region UPDATION                
                if (drpdPhase.SelectedIndex >= 1)
                {
                   byte[] imgbyt = ImageToByteArray(pcbSector.Image);
                   SqlParameter[] prm =
                   {
                   new SqlParameter("@Task","Update"),
                   new SqlParameter("@Name",txtSectorName.Text),
                   new SqlParameter("@Phase_ID",drpdPhase.SelectedValue),
                   new SqlParameter("@LocationMap",imgbyt),
                   new SqlParameter("@GPSXY",txtGPSXY.Text),
                   new SqlParameter("@Remarks",txtRemarks.Text),
                   new SqlParameter("@userID",Models.clsUser.ID),
                   new SqlParameter("@Sector_ID",Sector_ID)
                   };
                    int rslt = Data_Layer.clsSector.cls_dl_Sector.Sector_NonQuery(prm);
                    if (rslt > 0)
                    {
                        MessageBox.Show("Updation Successfull.");
                        Clear();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Phase Name.");
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
        private void BindPhase_To_DropDown()
        {
            #region DropDown Phase         
            RadListDataItem Select = new RadListDataItem();
            Select.Value = 0;
            Select.Text = "-- Select --";
            this.drpdPhase.Items.Add(Select);
            SqlParameter[] param =
            {
               new SqlParameter("@Task", "Select")
            };
            foreach (DataRow row in Data_Layer.clsPhase.cls_dl_Phase.Phase_Reader(param).Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["Phase_ID"].ToString();
                dataItem.Text = row["Name"].ToString();
                this.drpdPhase.Items.Add(dataItem);
            }
            #endregion
        }
        private void frmSector_Create_Load(object sender, EventArgs e)
        {
            if (Sector_ID == 0)
            {
                BindPhase_To_DropDown();               
            }
            else
            {
                btnSave.Text = "Update";
                BindPhase_To_DropDown();
                foreach (DataRow dt in dtr)
                {
                    Helper.clsPluginHelper.RadDropDownSelectedbyValue(drpdPhase,dt.Field<int>("Phase_ID"));
                    txtSectorName.Text = dt.Field<string>("Name");
                    txtRemarks.Text = dt.Field<string>("Remarks");
                    txtGPSXY.Text = dt.Field<string>("GPSXY");
                    pcbSector.Image = byteArrayToImage(dt.Field<byte[]>("LocationMap"));
                }
            }           
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        private void Clear()
        {
            txtSectorName.Text = "";
            txtRemarks.Text = "";
            txtGPSXY.Text = "";
            pcbSector.Image = null;
        }
        private void btnImageBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = @"Images(*.BMP;*.JPEG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files (.)|*.*";
            openFileDialog1.Title = "Select Photos";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                pcbSector.Image = new Bitmap(openFileDialog1.FileName);
            }
        }
    }
}
