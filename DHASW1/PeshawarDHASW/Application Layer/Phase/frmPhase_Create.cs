using PeshawarDHASW.Data_Layer.clsPhase;
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

namespace PeshawarDHASW.Application_Layer.Phase
{
    public partial class frmPhase_Create : Telerik.WinControls.UI.RadForm
    {
        private int Phase_ID { get; set; } = 0;
        private IEnumerable<DataRow> row { get; set; }
        public frmPhase_Create()
        {
            InitializeComponent();
        }
        public frmPhase_Create(int get_PhsID, IEnumerable<DataRow> get_query)
        {
            InitializeComponent();
            Phase_ID = get_PhsID;
            row = get_query;
        }      
        private void frmPhase_Create_Load(object sender, EventArgs e)
        {
            if(Phase_ID == 0)
            {
                BindDHA_To_DropDown();
            }
            else
            {
                BindDHA_To_DropDown();
                foreach (DataRow p in row)
                {
                    Helper.clsPluginHelper.RadDropDownSelectedbyValue(drpdDHA,p.Field<int>("DHA_ID"));
                    txtPhaseName.Text = p.Field<string>("Name");
                    txtRemarks.Text = p.Field<string>("Remarks");
                    txtGPSXY.Text = p.Field<string>("GPSXY");
                    pcbPhase.Image = byteArrayToImage(p.Field<byte[]>("LocationMap"));
                    
                }
                //txtPhaseName.Text = row[0][""].ToString();
                //txtRemarks.Text = lst[2].ToString();
                //txtGPSXY.Text = lst[3].ToString();
                //pcbPhase.Image = byteArrayToImage(byt);
            }
        }
        private void BindDHA_To_DropDown()
        {
            #region DropDown DHA         
            RadListDataItem Select = new RadListDataItem();
            Select.Value = 0;
            Select.Text = "-- Select DHA Name --";
            this.drpdDHA.Items.Add(Select);
            SqlParameter[] param =
            {
                new SqlParameter("@Task", "Select")
                };
            foreach (DataRow row in Data_Layer.clsDHA.cls_dl_DHA.DHA_Reader(param).Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["DHA_ID"].ToString();
                dataItem.Text = row["Name"].ToString();
                this.drpdDHA.Items.Add(dataItem);
            }
            drpdDHA.SelectedIndex = 0;
            #endregion
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Phase_ID == 0)
            {
                #region INSERTION
                if (drpdDHA.SelectedIndex >= 1)
                {
                byte[] imgbyt = ImageToByteArray(pcbPhase.Image);                
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","Insert"),
                new SqlParameter("@Name",txtPhaseName.Text),
                new SqlParameter("@DHA_ID",drpdDHA.SelectedValue),
                new SqlParameter("@LocationMap",imgbyt),
                new SqlParameter("@GPSXY",txtGPSXY.Text),
                new SqlParameter("@Remarks",txtRemarks.Text),
                new SqlParameter("@userID",Models.clsUser.ID)
                };
                    int rslt = Data_Layer.clsPhase.cls_dl_Phase.Phase_NonQuery(prm);
                    if (rslt > 0)
                    {
                        MessageBox.Show("Insertion Successfull.");
                        Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Please Select DHA Name.");
                }
                #endregion
            }
            else
            {
                #region UPDATION                
                if(drpdDHA.SelectedIndex >= 1)
                {
                   byte[] imgbyt = ImageToByteArray(pcbPhase.Image);
                   SqlParameter[] prm =
                   {
                   new SqlParameter("@Task","Update"),
                   new SqlParameter("@Name",txtPhaseName.Text),
                   new SqlParameter("@DHA_ID",drpdDHA.SelectedValue),
                   new SqlParameter("@LocationMap",imgbyt),
                   new SqlParameter("@GPSXY",txtGPSXY.Text),
                   new SqlParameter("@Remarks",txtRemarks.Text),
                   new SqlParameter("@userID",Models.clsUser.ID),
                   new SqlParameter("@Phase_ID",Phase_ID)
                   };
                    int rslt = Data_Layer.clsPhase.cls_dl_Phase.Phase_NonQuery(prm);
                    if (rslt > 0)
                    {
                        MessageBox.Show("Updation Successfull.");
                        Clear();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Please Select DHA Name.");
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
            openFileDialog1.Filter = @"Images(*.BMP;*.JPEG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files (.)|*.*";
            openFileDialog1.Title = "Select Photos";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                pcbPhase.Image = new Bitmap(openFileDialog1.FileName);
            }
        }
        private void Clear()
        {
            txtRemarks.Text = "";
            txtPhaseName.Text = "";
            txtGPSXY.Text = "";
            drpdDHA.DataSource = null;
            pcbPhase.Image = null;
        }
    }
}

