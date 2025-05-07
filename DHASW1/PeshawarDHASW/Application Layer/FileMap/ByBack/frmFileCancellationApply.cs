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
    public partial class frmFileCancellationApply : Telerik.WinControls.UI.RadForm
    {
        public frmFileCancellationApply()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            SqlParameter[] parameters =
           {
                new SqlParameter("@Task", "Get_FileDataForFileCancellation"),
                new SqlParameter("@FileNo", txtFileNo.Text)
            };
            DataSet dst = cls_dl_FileMap.Main_FileMap_Reader(parameters);
            if (dst.Tables.Count > 0)
            {
                if (dst.Tables[0].Rows.Count > 0)
                {
                    txtname.Text = dst.Tables[0].Rows[0]["Name"].ToString();
                    txtcnic.Text = dst.Tables[0].Rows[0]["CNIC"].ToString();
                    txtmsno.Text = dst.Tables[0].Rows[0]["MembershipNo"].ToString();
                    txttotalreceivedamount.Text = dst.Tables[0].Rows[0]["TotalReceivedAmount"].ToString();
                    txtplotsize.Text = dst.Tables[0].Rows[0]["PlotSize"].ToString();
                }
            }
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

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you Upload the Documents ?", "Attention ! ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string cat = "";
                    if (rdbCancel.IsChecked == true)
                    {
                         cat = "Cancel"; 
                    }
                    else if (rdbcanclreissue.IsChecked == true)
                    {
                        cat = "CancelAndReissue";
                    }
                    #region Code
                    if (!string.IsNullOrEmpty(txtFileNo.Text))
                    {
                        SqlParameter param_out_ID = new SqlParameter()
                        {
                            ParameterName = "@OutFCID",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Output
                        };

                        SqlParameter[] par =
                        {
                           new SqlParameter("@Task", "Enter_FileDataForFileCancellation"),
                           new SqlParameter("@FileNo", txtFileNo.Text),
                           new SqlParameter("@Name", txtname.Text),
                           new SqlParameter("@CNIC", txtcnic.Text),
                           new SqlParameter("@MembershipNo", txtmsno.Text),
                           new SqlParameter("@Amount", txtpaybleamount.Text),
                           new SqlParameter("@CheckNo", txtchequeno.Text),
                           new SqlParameter("@Bank",txtBank.Text),
                           new SqlParameter("@TotalReceivedAmountFromCust",string.IsNullOrEmpty(txttotalreceivedamount.Text) ? "0" : txttotalreceivedamount.Text),
                           new SqlParameter("@Remarks",txtremarks.Text),
                           new SqlParameter("@Date",rdtpdate.Value.Date),
                           new SqlParameter("@Status","Pending"),
                           new SqlParameter("@PlotSize",txtplotsize.Text),
                           new SqlParameter("@UserName",Models.clsUser.Name),
                           new SqlParameter("@FileStatus",cat),
                           param_out_ID
                        };
                        SqlCommand result;
                        result = cls_dl_FileMap.Main_FileMap_NonQuery_outparameter(par);
                        if (result.Parameters.Count != 0)
                        {
                            int CFID = Convert.ToInt32(result.Parameters["@OutFCID"].Value);
                            #region Saving Images
                            for (int i = 0; i < grdimages.RowCount; i++)
                            {
                                Image img = (Image)grdimages.Rows[i].Cells["Image"].Value;
                                MemoryStream ms = new MemoryStream();
                                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                Byte[] Im = ms.ToArray();

                                SqlParameter[] prm =
                                {
                                   new SqlParameter("@Task","SaveFileCancellationImages"),
                                   new SqlParameter("@ImageFile",Im),
                                   new SqlParameter("@ImageName","Image_"+i),
                                   new SqlParameter("@CFID",CFID),
                                   new SqlParameter("@user_ID",Models.clsUser.ID)
                                };
                                int rs = cls_dl_FileMap.Main_FileMap_NonQuery_FileCancelImageSaving(prm);
                                if (rs > 0)
                                {
                                    //MessageBox.Show("Successful.");
                                    //this.Close();
                                }
                            }
                            #endregion


                            MessageBox.Show("Successfull.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Enter File No.");
                    }
                    #endregion
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
