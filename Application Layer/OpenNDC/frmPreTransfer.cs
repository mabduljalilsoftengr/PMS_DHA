using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.clsCaution;
using PeshawarDHASW.Data_Layer.NDC;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.OpenNDC
{
    public partial class frmPreTransfer : Telerik.WinControls.UI.RadForm
    {
        public frmPreTransfer()
        {
            InitializeComponent();
            BindDealerListWithDropDown();
            Clearfunction();
        }

        private void Clearfunction()
        {
            FileMapKey.Text = "";
            lblFileNo.Text = "";
            lblPlotNo.Text = "";
            lblPlotSize.Text = "";
            lblOwnerName.Text = "";
            lblNIC.Text = "";
        }

        private void BindDealerListWithDropDown()
        {
            ///////////////////Start//// Remove All items from DropDown
            while (drpDealerList.Items.Count > 0)
                drpDealerList.Items.RemoveAt(0);
            drpDealerList.Text = "";
            //////////////////END////Remove All items from DropDown
            drpDealerList.DataSource = null;
            RadListDataItem dlrlst = new RadListDataItem();
            dlrlst.Value = 0;
            dlrlst.Text = "-- Select --";
            this.drpDealerList.Items.Add(dlrlst);
            SqlParameter[] param =
            {
               new SqlParameter("@Task", "Get_Dealer")
            };
            DataSet ds = new DataSet();
            ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_NDC", param );
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["ID"].ToString();
                dataItem.Text = row["BussinessTitle"].ToString();
                this.drpDealerList.Items.Add(dataItem);
            }
            drpDealerList.SelectedIndex = 0;

        }
        private void FileVerify_Click(object sender, EventArgs e)
        {
            try
            {


                if (CheckCaution_() == true && FileActiveNotBlock() == true)
                {

                
                Clearfunction();
                SqlParameter[] paramcheck = {
                    new SqlParameter("@Task","PreventionDoubleApply"),
                    new SqlParameter("@FileNo",FileNo.Text)
                };

                DataSet dsprevent = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_PreTransferRequest", paramcheck);

                if (dsprevent.Tables[0].Rows.Count>0)
                {
                    int NDCPending = int.Parse(dsprevent.Tables[0].Rows[0]["NDCPending"].ToString());
                    int NDCInprogress = int.Parse(dsprevent.Tables[0].Rows[0]["NDCInprogress"].ToString());
                    if (NDCPending>0)
                    {
                        MessageBox.Show("Deal is Already Inprogress. Please Contact for Detail to Finance Branch.");
                        GenerateRequestforPreTransfer.Enabled = false;
                    }
                    if (NDCInprogress>0)
                    {
                        MessageBox.Show("NDC is Already Inprogress. Please Contact for Detail to Finance Branch.");
                        GenerateRequestforPreTransfer.Enabled = false;
                    }

                    if (NDCPending ==0 && NDCInprogress ==0)
                    {
                        SqlParameter[] param = {
                               new SqlParameter("@FileNo",FileNo.Text)
                            };
                        DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.PerTransferModule_FileNoVerification", param);
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            FileMapKey.Text = item["FileMapKey"].ToString();
                            lblFileNo.Text = item["FileNo"].ToString();
                            lblPlotNo.Text = item["PlotNo"].ToString();
                            lblPlotSize.Text = item["PlotSize"].ToString();
                            lblOwnerName.Text = item["OwnerName"].ToString();
                            lblNIC.Text = item["NIC"].ToString();
                            lblMobileNo.Text = item["MobileNo"].ToString();
                            lblFBRStatus.Text = item["FBRStatus"].ToString();
                        }
                        GenerateRequestforPreTransfer.Enabled = true;
                    }
                }

                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private bool CheckCaution_()
        {
            bool bol = false;
            try
            {
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","Check_Caution"),
                new SqlParameter("@FileNo",FileNo.Text)
                };
                DataSet ds = cls_dl_Caution.Caution_Reader(prm);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GenerateRequestforPreTransfer.Enabled = false;
                    bol = false;
                    MessageBox.Show("This File No. is temporarily blocked.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                   
                }
                else
                {
                    GenerateRequestforPreTransfer.Enabled = true;
                    bol = true;
                }

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on CheckCaution.", ex, "frmPreTransfe");
                frmobj.ShowDialog();
                bol = false;
            }
            return bol;
        }

        private bool FileActiveNotBlock()
        {
            bool fanl = false;
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","FileActiveNotBlockStatus"),
                new SqlParameter("@FileNo",FileNo.Text)
            };
            DataSet dst = cls_dl_NDC.NdcRetrival(prm);
            if (dst.Tables.Count > 0)
            {
                if (dst.Tables[0].Rows.Count > 0)
                {
                    fanl = true;
                    GenerateRequestforPreTransfer.Enabled = true;
                }
                else
                {
                    MessageBox.Show("This File No. is Cancel OR Block.");
                    fanl = false;
                    GenerateRequestforPreTransfer.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("This File No. is Cancel OR Block.");
                fanl = false;
                GenerateRequestforPreTransfer.Enabled = false;
            }
            return fanl;
        }
        private void frmPreTransfer_Load(object sender, EventArgs e)
        {

        }

        private void drpDealerList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                var dealerID = drpDealerList.SelectedItem.Value;
                SqlParameter[] param = { new SqlParameter("@DealerID", dealerID) };
                DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(),
                    CommandType.StoredProcedure,
                    "App.PerTransferModule_DealerVerification", param);

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    RegnNo.Text = item["RegnNo"].ToString();
                    DealerID.Text = item["ID"].ToString();
                    BussinessTitle.Text = item["BussinessTitle"].ToString();
                    BussinessAddress.Text = item["BussinessAddress"].ToString();
                    DealerName1.Text = item["DealerName1"].ToString();
                    CNICNo1.Text = item["CNICNo1"].ToString();
                    ContactNumber1.Text = item["ContactNumber1"].ToString();
                    RegistrationDate.Text = item["RegistrationDate"].ToString();
                    lblFBRStatus.Text = item["FileStatus"].ToString();
                    FBRCPR.CheckState = (item["CPRAttach"].ToString() == "1" ? CheckState.Checked : CheckState.Unchecked);
                }

            }
            catch (Exception)
            {

            }
        }
        List<clsMemberImage> ImageContainer = new List<clsMemberImage>();
        private void btnBrowseforSingleimage_Click(object sender, EventArgs e)
        {
            try
            {
                int imageCount = ImageContainer.Count() + 1;
                clsMemberImage obj = new clsMemberImage();
                obj.ImageName = DateTime.Now.ToString("yyyyMMdd") + "_" + imageCount;
                obj.Description = "Attachment with DD Transfer.";

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter =
                    @"Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files (.)|*.*";
                openFileDialog1.Title = "Select Photos";

                DialogResult dr = openFileDialog1.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {

                    string[] files = openFileDialog1.FileNames;
                    foreach (var pngFile in files)
                    {
                        try
                        {
                            obj.MemberImage = Image.FromFile(pngFile);
                        }
                        catch
                        {
                            Console.WriteLine("This is not an image file");
                        }
                    }
                    ImageContainer.Add(obj);
                    ImageSource.TableElement.RowHeight = 50;
                    ImageSource.Columns["MemberImage"].ImageLayout = ImageLayout.Stretch;
                    ImageSource.DataSource = ImageContainer.DefaultIfEmpty();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void ImageSource_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name == "btnRemove")
            {
                try
                {
                    ImageContainer.RemoveAt(e.RowIndex);
                    ImageSource.TableElement.RowHeight = 50;
                    ImageSource.Columns["MemberImage"].ImageLayout = ImageLayout.Stretch;
                    ImageSource.DataSource = ImageContainer.DefaultIfEmpty();
                    if (ImageContainer.Count == 0)
                        ImageSource.DataSource = null;
                }
                catch (Exception)
                {
                    ImageSource.DataSource = null;
                }
            }
        }

        private void GenerateRequestforPreTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                if (FBRCPR.CheckState == CheckState.Checked)
                {
                    SqlParameter[] param =
                    {
                      new SqlParameter("@Task","NewRequest")
                    , new SqlParameter("@DealDate",DateTime.UtcNow)
                    , new SqlParameter("@FileMapKey",FileMapKey.Text)
                    , new SqlParameter("@FileNo",lblFileNo.Text)
                    , new SqlParameter("@OwnerName",lblOwnerName.Text)
                    , new SqlParameter("@NIC",lblNIC.Text)
                    , new SqlParameter("@MobileNo",lblMobileNo.Text)
                    , new SqlParameter("@PlotSize",lblPlotSize.Text)
                    , new SqlParameter("@PlotNo",lblPlotNo.Text)
                    , new SqlParameter("@DealerID",DealerID.Text)
                    , new SqlParameter("@BussinessTitle",BussinessTitle.Text)
                    , new SqlParameter("@BussinessAddress",BussinessAddress.Text)
                    , new SqlParameter("@RegnNo",RegnNo.Text)
                    , new SqlParameter("@DealerName1",DealerName1.Text)
                    , new SqlParameter("@CNICNo1",CNICNo1.Text)
                    , new SqlParameter("@ContactNumber1",ContactNumber1.Text)
                     , new SqlParameter("@TransferStatus","NDCPending")
                    , new SqlParameter("@RegistrationDate", DateTime.Parse(DateTime.UtcNow.ToString()))   // RegistrationDate.Text
                    , new SqlParameter("@IsActive",true)
                    , new SqlParameter("@CreatedBy",clsUser.ID)
                    , new SqlParameter("@FilerStatus",lblFBRStatus.Text)
                    , new SqlParameter("@CPRAttach",FBRCPR.CheckState == CheckState.Checked ? true:false)
                };
                    int PerTransferRequestId = int.Parse(SQLHelper.ExecuteScalar(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_PreTransferRequest", param).ToString());
                    if (PerTransferRequestId > 0)
                    {
                        foreach (clsMemberImage row in ImageContainer)
                        {
                            MemoryStream ms = new MemoryStream();
                            row.MemberImage.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                            Byte[] Image = ms.ToArray();
                            SqlParameter[] parameters =
                            {
                                        new SqlParameter("@Task", "Insert"),
                                        new SqlParameter("@PreTransferID", PerTransferRequestId),
                                        new SqlParameter("@ImageFile", Image),
                                        new SqlParameter("@ImageName", row.ImageName),
                                        new SqlParameter("@Description", row.Description),
                                        new SqlParameter("@user_ID", clsUser.ID),
                                         };
                            int result = Helper.SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.VerifiedImageConnectionstring,
                                                    CommandType.StoredProcedure,
                                                    "usp_tbl_PreTransferRequestImage",
                                                    parameters
                                                    );

                        }
                        ImageContainer.Clear();
                        ImageSource.DataSource = null;
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("CPR Document is Missing. Please Attach the CPR Document before Generating Request.");
                }
            }
            catch (Exception rc)
            {
            }
        }
    }
}
