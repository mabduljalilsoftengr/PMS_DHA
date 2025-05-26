using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Application_Layer.Installment.InstReceive.InstReceiveModify;
using PeshawarDHASW.Data_Layer.Installment;
using Telerik.WinControls;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.Installment.InstReceive.ImageRead
{
    public partial class frmReceInstalImage : Telerik.WinControls.UI.RadForm
    {
        public frmReceInstalImage()
        {
            InitializeComponent();
        }

        public frmReceInstalImage(int _Rece_ID, bool GBShow = true)
        {
            Rece_ID = _Rece_ID;
            InitializeComponent();
            radgbcontrols.Visible = GBShow;
        }
        public frmReceInstalImage(int get_ddID,bool get_fls,int get_int)
        {
            InitializeComponent();
            Rece_ID = get_ddID;
            radgbcontrols.Visible = get_fls;
        }
        private int imageindex { get; set; } = 0;
        private int TotalImage { get; set; } = 0;
        private DataSet dsImage { get; set; }
        private int Rece_ID { get; set; } 
        private int ImageID { get; set; }

        #region Form Load of form Installment Rece Image 
        private void frmReceInstalImage_Load(object sender, EventArgs e)
        {
            Data_Retrive_for_Rece_Installment(Rece_ID);
        }
        #endregion

        private void Data_Retrive_for_Rece_Installment(int _ReceID)
        {
            try
            {
                inforviewofReceInst(_ReceID);
                dsImage = IMageLoading(_ReceID);
                if (dsImage.Tables[0].Rows.Count > 0)
                {
                    pictureBox1.Image = ImageRetrive(imageindex);
                }
                else
                {
                    MessageBox.Show("There is  No Image Attached with Document");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Data_Retrive_for_Rece_Installment.", ex, "frmReceInstalImage");
                frmobj.ShowDialog();

            }

        }

        #region Image loading from database on the of DDImageID
        private DataSet IMageLoading(int DDImageID)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task", "Select"),
                    new SqlParameter("@DDImageID", DDImageID),
                };
                ds = cls_dl_InstRece.ReturnAllIDs(parameters);
                TotalImage = ds.Tables[0].Rows.Count;

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on IMageLoading.", ex, "frmReceInstalImage");
                frmobj.ShowDialog();
            }
            return ds;
        }
        #endregion

        #region Image Retrive Function on the base of Index from Dataset
        private Image ImageRetrive(int imageindex)
        {
            MemoryStream ms = new MemoryStream();
            try
            {
                // Transfer everything to the Image property of the picture box....
                ImageID = int.Parse(dsImage.Tables[0].Rows[imageindex]["ID"].ToString());
                byte[] imgData = (byte[])dsImage.Tables[0].Rows[imageindex]["Image"];
                ms = new MemoryStream(imgData);
                ms.Position = 0;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on ImageRetrive.", ex, "frmReceInstalImage");
                frmobj.ShowDialog();
            }
          
            return Image.FromStream(ms);
        }
        #endregion

        #region Information View of Receive Installment
        private void inforviewofReceInst(int ReceID)
        {
            try
            {
                SqlParameter[] parameters =
                         {
                new SqlParameter("@Task","search"),
                new SqlParameter("@Rece_ID",ReceID),
            };
                DataSet ds = cls_dl_InstRece.Inst_Rece_Read(parameters);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Rece_ID = int.Parse(row["Rece_ID"].ToString());
                    lblfileno.Text = row["FileNo"].ToString();
                    lblplotno.Text = row["PlotNo"].ToString();
                    lblRecordNo.Text = row["RecordNo"].ToString();
                    lblmsno.Text = row["MembershipNo"].ToString();
                    lblNIC.Text = row["NIC"].ToString();
                    lblpassport.Text = row["PassportNo"].ToString();
                    lblname.Text = row["Name"].ToString();
                    lblcontact.Text = row["MobileNo"].ToString();
                    lblDateofRece.Text = DateTime.Parse(row["Date"].ToString()).ToString("dd/MM/yyyy");
                    lblremarks.Text = row["Remarks"].ToString();
                    lblchallanDDno.Text = row["DDNo"].ToString();
                    lblAmount.Text = row["Amount"].ToString();
                    lblbank.Text = row["BankName"].ToString();
                    lblbranch.Text = row["Branch"].ToString();
                    lblstatus.Text = row["Status"].ToString();
                    lblDDstatus.Text = row["DDStatus"].ToString();
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on inforviewofReceInst.", ex, "frmReceInstalImage");
                frmobj.ShowDialog();
            }
         
        }
        #endregion

        #region Precious Image
        private void btnpreciousimage_Click(object sender, EventArgs e)
        {
            try
            {
                if (imageindex != 0)
                {
                    imageindex = imageindex - 1;
                    pictureBox1.Image = ImageRetrive(imageindex);
                }
                else
                {
                    pictureBox1.Image = ImageRetrive(imageindex);
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnpreciousimage_Click.", ex, "frmReceInstalImage");
                frmobj.ShowDialog();
            }
           
        }
        #endregion

        #region Next Image
        private void btnnextimage_Click(object sender, EventArgs e)
        {
            try
            {
                if (imageindex != TotalImage - 1)
                {
                    imageindex = imageindex + 1;
                    pictureBox1.Image = ImageRetrive(imageindex);
                }
                else
                {
                    pictureBox1.Image = ImageRetrive(imageindex);
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnnextimage_Click.", ex, "frmReceInstalImage");
                frmobj.ShowDialog();
            }
           
        }
        #endregion

        private void btnInformationModifcation_Click(object sender, EventArgs e)
        {
            frmDDModify  objDdModify = new frmDDModify(Rece_ID);
            objDdModify.ShowDialog();
            Data_Retrive_for_Rece_Installment(Rece_ID);
        }

        private void btnImageModification_Click(object sender, EventArgs e)
        {
            DDImageUpload objDdImageUpload = new DDImageUpload(ImageID, Rece_ID, "");
            objDdImageUpload.ShowDialog();
        }
    }
}
