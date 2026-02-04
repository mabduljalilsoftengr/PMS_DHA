using PeshawarDHASW.Data_Layer.clsFileMap;
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

namespace PeshawarDHASW.Application_Layer.FileMap.ByBack
{
    public partial class frmImageShow : Telerik.WinControls.UI.RadForm
    {
        public frmImageShow()
        {
            InitializeComponent();
        }
        private int BID { get; set; }
        private string dstr { get; set; }
        public frmImageShow(int bid_,string str)
        {
            InitializeComponent();
            BID = bid_;
            dstr = str;
        }
        public string FormAccess { get; set; }
        private void frmImageShow_Load(object sender, EventArgs e)
        {
            try
            {
                btnDeleteDoc.Visible = false;
                btnDeleteDoc.Enabled = false;
                if(dstr == "BuyBack")
                {
                    SqlParameter[] prm =
                    {
                    new SqlParameter("@Task","ShowBuyBackImages"),
                    new SqlParameter("@BuyBackID",BID)
                    };
                    DataSet dst = cls_dl_FileMap.Main_FileMap_Reader_ImageReadng(prm);
                    grdimage.DataSource = dst.Tables[0].DefaultView;
                }
                else if(dstr == "FileCancel")
                {
                   SqlParameter[] prm =
                   {
                    new SqlParameter("@Task","Select"),
                    new SqlParameter("@CFID",BID)
                    };
                    DataSet dst = cls_dl_FileMap.Main_FileMap_Reader_FileCancelImageReadng(prm);
                    grdimage.DataSource = dst.Tables[0].DefaultView;
                }
                else if (dstr == "BuyBackFin")
                {
                    FormAccess = "BuyBackFin";
                    SqlParameter[] prm =
                    {
                    new SqlParameter("@Task","ShowBuyBackImages"),
                    new SqlParameter("@BuyBackID",BID)
                    };
                    DataSet dst = cls_dl_FileMap.Main_FileMap_Reader_ImageReadng(prm);
                    grdimage.DataSource = dst.Tables[0].DefaultView;
                    btnDeleteDoc.Visible = true;
                    btnDeleteDoc.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        public string BuyBackImageVal { get; set; }
        private void grdimage_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (FormAccess== "BuyBackFin")
                {
                    BuyBackImageVal = e.Row.Cells["ID"].Value.ToString();
                    lblImage.Text = BuyBackImageVal;
                }
               
                Byte[] img = (Byte[])e.Row.Cells["ImageFile"].Value;
                MemoryStream ms = new MemoryStream(img);
                pcbbuybackimage.Image = Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnDeleteDoc_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(lblImage.Text))
            {
                int ID = 0;
                bool val = int.TryParse(lblImage.Text, out ID);

                if (ID >0)
                {
                    SqlParameter[] prm =
                                   {
                    new SqlParameter("@Task","DeleteImagefromBuyBack"),
                    new SqlParameter("@ID",ID)
                };
                    int result = cls_dl_FileMap.Main_FileMap_NonQuery_ImageSaving(prm);
                    if (result>0)
                    {
                        MessageBox.Show("Selected Image is Deleted Successfully.");
                        SqlParameter[] pram =
                        {
                             new SqlParameter("@Task","ShowBuyBackImages"),
                             new SqlParameter("@BuyBackID",BID)
                         };
                        DataSet dst = cls_dl_FileMap.Main_FileMap_Reader_ImageReadng(pram);
                        grdimage.DataSource = dst.Tables[0].DefaultView;
                        btnDeleteDoc.Visible = true;
                        btnDeleteDoc.Enabled = true;
                    }
                }

               
            }
        }
    }
}
