using PeshawarDHASW.Data_Layer.clsFileMap;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Models;
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

namespace PeshawarDHASW.Application_Layer.FileMap.ByBack
{
    public partial class frmByBackFileWiseEntryADStat : Telerik.WinControls.UI.RadForm
    {
        public frmByBackFileWiseEntryADStat()
        {
            InitializeComponent();
        }

        public frmByBackFileWiseEntryADStat(string refbuyBackID)
        {
            InitializeComponent();
            FetchBuyBackRecord(refbuyBackID);
        }
        public string valbuyBackID { get; set; }
        private void FetchBuyBackRecord(string _buyBackID)
        {
            string FileNo = txtFileNo.Text.ToUpper();
            txtFileNo.Text = FileNo;

            SqlParameter[] parameters =
            {
                new SqlParameter("@Task", "FileNoVerificationADStat"),
                new SqlParameter("@BID", _buyBackID)
            };
            DataSet dst = cls_dl_FileMap.Main_FileMap_Reader(parameters);
            if (dst.Tables.Count > 0)
            {
                if (dst.Tables[0].Rows.Count > 0)
                {
                    valbuyBackID = dst.Tables[0].Rows[0]["BID"].ToString();
                    txtname.Text = dst.Tables[0].Rows[0]["Name"].ToString();
                    txtcnic.Text = dst.Tables[0].Rows[0]["CNIC"].ToString();
                    txtmsno.Text = dst.Tables[0].Rows[0]["MembershipNo"].ToString();
                    txttotalreceivedamount.Text = dst.Tables[0].Rows[0]["TotalReceivedAmountFromCust"].ToString();
                    txtlandprovidername.Text = dst.Tables[0].Rows[0]["InvestorName"].ToString();
                    txtplotsize.Text = dst.Tables[0].Rows[0]["PlotSize"].ToString();
                    txtsqyard.Text = dst.Tables[0].Rows[0]["SQYard"].ToString();
                    lblCategory.Text = dst.Tables[0].Rows[0]["Category"].ToString();
                    lblplotno.Text = dst.Tables[0].Rows[0]["PlotNo"].ToString();
                    txtFileNo.Text = dst.Tables[0].Rows[0]["FileNo"].ToString();
                    txtperfilerate.Text = dst.Tables[0].Rows[0]["PerFileRate"].ToString();
                    txtremarks.Text = dst.Tables[0].Rows[0]["Remarks"].ToString();


                    //if (dst.Tables[0].Rows[0]["Category"].ToString() != "Investors" && dst.Tables[0].Rows[0]["Category"].ToString() != "Svc Benefit")
                    //{
                    //    lbldataentry.Enabled = false;
                    //    MessageBox.Show("This File is not valid for Buyback.Please try another.");
                    //}
                    //else
                    //{
                    //    lbldataentry.Enabled = true;
                    //    if (dst.Tables[0].Rows[0]["Category"].ToString() == "Investors")
                    //    {
                    //        lbllandprovider.Text = "Owner Name";
                    //        txtlandprovidername.Text = dst.Tables[0].Rows[0]["Name"].ToString();
                    //    }
                    //    else if (dst.Tables[0].Rows[0]["Category"].ToString() == "Svc Benefit")
                    //    {
                    //        lbllandprovider.Text = "Land Provider Name";
                    //        txtlandprovidername.Text = dst.Tables[0].Rows[0]["InvestorName"].ToString();
                    //    }
                    //    else
                    //    {

                    //    }
                    //}
                }
                else
                {
                    MessageBox.Show("File No Exists in Backup Module.");
                }
            }
        }
     
        private void btnFind_Click(object sender, EventArgs e)
        {
           
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you Upload the Documents ?", "Attention ! ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    #region Buy Back Entry
                    if (!string.IsNullOrEmpty(txtlandprovidername.Text) && !string.IsNullOrEmpty(txtsqyard.Text) 
                        && !string.IsNullOrEmpty(txtFileNo.Text) && !string.IsNullOrEmpty(txtperfilerate.Text))
                    {
                        

                        SqlParameter[] par =
                        {
                           new SqlParameter("@Task", "UpdateBuyBackRecord"),
                           new SqlParameter("@BID", valbuyBackID),
                           new SqlParameter("@TotalReceivedAmountFromCust",string.IsNullOrEmpty(txttotalreceivedamount.Text) ? "0" : txttotalreceivedamount.Text),
                           new SqlParameter("@Remarks",txtremarks.Text),
                           new SqlParameter("@PerFileRate",txtperfilerate.Text),
                           new SqlParameter("@MinuteSheetNo",txtMinuteSheet.Text),
                           new SqlParameter("@userID",clsUser.ID),
                           new SqlParameter("@UserName",clsUser.Name),
                        };
                   
                      int  result = SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(),CommandType.StoredProcedure,"App.USP_tbl_FileMap",par);

                        if (!string.IsNullOrWhiteSpace(valbuyBackID))
                        {
                            int BID = Convert.ToInt32(valbuyBackID);
                            #region Saving Images
                            for (int i = 0; i < grdimages.RowCount; i++)
                            {
                                Image img = (Image)grdimages.Rows[i].Cells["Image"].Value;
                                MemoryStream ms = new MemoryStream();
                                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                Byte[] Im = ms.ToArray();

                                SqlParameter[] prm =
                                {
                                   new SqlParameter("@Task","SaveBuyBackImages"),
                                   new SqlParameter("@ImageFile",Im),
                                   new SqlParameter("@ImageName","Image_"+i),
                                   new SqlParameter("@BuyBackID",BID),
                                   new SqlParameter("@user_ID",Models.clsUser.ID)
                                };
                                int rs = cls_dl_FileMap.Main_FileMap_NonQuery_ImageSaving(prm);
                                if (rs > 0)
                                {
                                    //MessageBox.Show("Successful.");
                                    //this.Close();
                                }
                            }
                            #endregion


                            MessageBox.Show("Successfull.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                            this.Close();
                         }
                       }
                       else
                       {
                           MessageBox.Show("Please Enter Investor Name, SQYard, File No. and PerFileRate.");
                       }
                    #endregion
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Clear()
        {
            lblplotno.Text = "#";
            txtFileNo.Text = "";
            lblCategory.Text = "#";
            txtlandprovidername.Text = "";
            txtplotsize.Text = "";
            txtsqyard.Text = "";
            txtname.Text = "";
            txtcnic.Text = "";
            txtmsno.Text = "";
            txttotalreceivedamount.Text = "0";
            txtperfilerate.Text = "";
            txtremarks.Text = "";
            for (int i = 0; i < grdimages.Rows.Count; i++)
            {
                grdimages.Rows.RemoveAt(i);
             }
        }
        private void frmByBackFileWiseEntry_Load(object sender, EventArgs e)
        {
            //rdtpdate.Value = DateTime.Now;


            RadListDataItem Select = new RadListDataItem();
            Select.Value = 0;
            Select.Text = "-- Select --";
            this.ddlLandProviders.Items.Add(Select);
            SqlParameter[] param =
            {
               new SqlParameter("@Task", "LoadAllLandProviders")
            };

            foreach (DataRow row in cls_dl_FileMap.Main_FileMap_Reader(param).Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["LPID"].ToString();
                dataItem.Text = row["Name"].ToString();
                this.ddlLandProviders.Items.Add(dataItem);
            }
            ddlLandProviders.SelectedIndex = 0;

        }

        private void txtFileNo_Leave(object sender, EventArgs e)
        {
            //SqlParameter[] parameters =
            //{
            //    new SqlParameter("@Task", "CheckForAlreadyAppliedByBack"),
            //    new SqlParameter("@FileNo", txtFileNo.Text.ToUpper())
            //};
            //DataSet dst = cls_dl_FileMap.Main_FileMap_Reader(parameters);
            //if (dst.Tables.Count > 0)
            //{
            //    if (dst.Tables[0].Rows.Count > 0)
            //    {
            //        int tc = int.Parse(dst.Tables[0].Rows[0]["TotalCount"].ToString());
            //        if (tc > 0)
            //        {
            //            MessageBox.Show("This File No. is already ByBacked.");
            //            btnsave.Enabled = false;
            //        }
            //        else
            //        {
            //            btnsave.Enabled = true;
            //        }
            //    }
            //}
        }

        private void btnuploadimageupload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter =
            @"Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|
            All files (.)|*.*";
            openFileDialog1.Title = "Select Photos";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                /////////// Declare Table
                DataTable dt = new DataTable();
                dt.Clear();
                dt.Columns.Add("Image", typeof(Image));
                dt.Columns.Add("ImageName", typeof(string));
                dt.Columns.Add("Description", typeof(string));
                string[] files = openFileDialog1.FileNames;
                int i = 1;
                foreach (var pngFile in files)
                {
                    try
                    {
                        DataRow _ravi = dt.NewRow();
                        _ravi["Image"] = Image.FromFile(pngFile);
                        _ravi["ImageName"] = DateTime.Now.ToString("yyyyMMdd") + "_" + i;
                        _ravi["Description"] = "Documents.";
                        dt.Rows.Add(_ravi);
                        i = i + 1;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("This is not an image file");
                    }
                }
                grdimages.TableElement.RowHeight = 50;
                grdimages.Columns["Image"].ImageLayout = ImageLayout.Stretch;
                grdimages.DataSource = dt.DefaultView;
            }
        }

        private void txtperfilerate_TextChanged(object sender, EventArgs e)
        {
            int Number = 0;
            bool Numberflag = int.TryParse(txtperfilerate.Text, out Number);
            if (Numberflag == true)
            {
                lblAmountInWords.Text = Helper.clsPluginHelper.Convert_Number_To_Text(Number, false);
            }
        }
    }
}
