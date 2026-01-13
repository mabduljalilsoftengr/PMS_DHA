using PeshawarDHASW.Data_Layer.Installment;
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

namespace PeshawarDHASW.Application_Layer.Installment.Surcharge
{
    public partial class frm_SurchargeWaveoffModifybyFile : Telerik.WinControls.UI.RadForm
    {
        public frm_SurchargeWaveoffModifybyFile()
        {
            InitializeComponent();
        }
        public string File_No { get; set; }
        public string SurWayOffMasID { get; set; }
        public frm_SurchargeWaveoffModifybyFile(string FileNo)
        {
            File_No = FileNo;
            InitializeComponent();
        }

        public frm_SurchargeWaveoffModifybyFile(string FileNo, bool isReadOnly, bool isEditable = false, string SurWayOffMasID = null)
        {
            File_No = FileNo;
            InitializeComponent();
            this.SurWayOffMasID = SurWayOffMasID;
            if (isEditable == false)
            {
                btnSaveSurcharge.Visible = false;
                btnBrowseforSingleimage.Visible = false;
                DGVSurcharge.ReadOnly = true;
                txtRemarks.ReadOnly = true;
                ImageSource.ReadOnly = true;
            }
        }

        private int filechecker(string FileNo)
        {
            SqlParameter[] parmExisitng = {
                    new SqlParameter("@Task","FileExistChecking"),
                    new SqlParameter("@FileNo",FileNo)
            };

            int counter = 0;
            bool checker = int.TryParse(Helper.SQLHelper.ExecuteScalar(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_SurchargeWaveoff", parmExisitng).ToString(), out counter);
            return counter;
        }

        private void frm_SurchargeWaveoffModifybyFile_Load(object sender, EventArgs e)
        {
            //GridViewComboBoxColumn comboColumn = new GridViewComboBoxColumn("SurchargeStatus");
            //comboColumn.DataSource = new String[] { "N/A", "Wavieroff", "Cancel" };
            //comboColumn.FieldName = "SurchargeStatus";
            //comboColumn.ReadOnly = false;
            //comboColumn.Width = 120;
            //DGVSurcharge.Columns.Add(comboColumn);

            try
            {
                SqlParameter[] param = {
                                            new SqlParameter("@Task","SearchonSurchargeWaveoff"),
                                            new SqlParameter("@FileNo",File_No)
                                        };
                DataSet ds = new DataSet();
                ds = cls_dl_Surcharge.Surcharge_Reader(param);
                DGVSurcharge.DataSource = ds.Tables[0].DefaultView;
                // File Information
                lblFileNo.Text = ds.Tables[1].Rows[0]["FileNo"].ToString();
                lblName.Text = ds.Tables[1].Rows[0]["Name"].ToString();
                lblCNIC.Text = ds.Tables[1].Rows[0]["NIC/NICOP"].ToString();
                lblMobileno.Text = ds.Tables[1].Rows[0]["MobileNo"].ToString();
                lblplotsize.Text = ds.Tables[1].Rows[0]["PlotSize"].ToString();
                if (ds.Tables[2].Rows.Count > 0)
                {
                    txtRemarks.Text = ds.Tables[2].Rows[0]["RequestRemarks"].ToString();
                    SurWayOffMasID = ds.Tables[2].Rows[0]["SurWayOffMasID"].ToString();
                }
                //Color Changing in Grid
                ConditionalFormattingObject obj = new ConditionalFormattingObject("MyCondition", ConditionTypes.Equal, "Pending", "", true);
                obj.CellForeColor = Color.Red;
                obj.RowBackColor = Color.SkyBlue;
                this.DGVSurcharge.Columns["SurchargeStatus"].ConditionalFormattingObjectList.Add(obj);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (SurWayOffMasID != null)
            {
                try
                {
                    SqlParameter[] param = {
                                            new SqlParameter("@Task","Select"),
                                            new SqlParameter("@SurWayOffMasID", SurWayOffMasID)
                                        };
                    DataSet ds = new DataSet();
                    ds = cls_dl_InstRece.SurchargeWaiveImageDataset(param);

                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow item in ds.Tables[0].Rows)
                            {
                                clsMemberImage obj = new clsMemberImage();
                                obj.ImageName = item["ImageName"].ToString();
                                obj.Description = item["Description"].ToString();
                                byte[] bytes = Encoding.ASCII.GetBytes(item["ImageFile"].ToString());

                                System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
                                
                                Image img = ImageRetrive((byte[]) item["ImageFile"]);
                                obj.MemberImage = img;
                                 

                                ImageContainer.Add(obj);

                                ImageSource.TableElement.RowHeight = 50;
                                ImageSource.Columns["MemberImage"].ImageLayout = ImageLayout.Stretch;
                                ImageSource.DataSource = ImageContainer.DefaultIfEmpty();
                            }
                        }
                    }


                }
                catch (Exception ex )
                {
                }
            }
        }
        private Image ImageRetrive(byte[] imgdata)
        {
            MemoryStream ms = new MemoryStream(imgdata);
            ms.Position = 0;
            return Image.FromStream(ms);
        }
        private void btnSaveSurcharge_Click(object sender, EventArgs e)
        {


            string SurchargeStauts = "Pending";
            DataView _row = (DataView)DGVSurcharge.DataSource;
            DataTable dt = _row.ToTable();
            DataRow[] _dRow = dt.Select("SurchargeStatus = 'Pending'");
            if (_dRow.Length == 0)
            {
                this.Close();
                return;
            }
            DataRow[] _Count = dt.Select("SurchargeStatus = 'Pending' and SurWayOffMasID is not null");
            if (_Count.Length == 0)
            {
                if (string.IsNullOrEmpty(txtRemarks.Text.Trim()) || txtRemarks.Text.Trim().Length < 10)
                {
                    MessageBox.Show("Please enter a proper remarks. Remarks must be atleast 10 character.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                SqlParameter[] param1 = {
                                        new SqlParameter("@Task","InsertSurchargeWaiverMaster"),
                                        new SqlParameter("@SurWayOffMasID",string.IsNullOrEmpty(SurWayOffMasID) ? null : SurWayOffMasID),
                                        new SqlParameter("@RequestRemarks",txtRemarks.Text),
                                        new SqlParameter("@RequestedBy",clsUser.ID),
                                        new SqlParameter("@FileMapKey",Helper.clsPluginHelper.DbNullIfNullOrEmpty(DGVSurcharge.Rows[0].Cells["FileMapKey"].Value.ToString())),
                                    };
                DataSet _ds = new DataSet();
                _ds = cls_dl_Surcharge.Surcharge_Reader(param1);
                SurWayOffMasID = _ds.Tables[0].Rows[0]["SurWayOffMasID"].ToString();
                try
                {
                    foreach (clsMemberImage row in ImageContainer)
                    {
                        MemoryStream ms = new MemoryStream();
                        row.MemberImage.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                        Byte[] Image = ms.ToArray();
                        SqlParameter[] parameters =
                        {
                            new SqlParameter("@Task", "Insert"),
                            new SqlParameter("@SurWayOffMasID", SurWayOffMasID),
                            new SqlParameter("@ImageFile", Image),
                            new SqlParameter("@ImageName", row.ImageName),
                            new SqlParameter("@Description", row.Description),
                            new SqlParameter("@user_ID", clsUser.ID),
                        };
                        int re = cls_dl_InstRece.SurchargeWaiveImage_NonQuery(parameters);

                    }
                    ImageContainer.Clear();
                    ImageSource.DataSource = null;

                }
                catch (Exception rc)
                {
                }

                MessageBox.Show("Request for Surcharge WaiveOff has been successfully sent.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SurWayOffMasID = _Count[0]["SurWayOffMasID"].ToString();
                try
                {
                    SqlParameter[] param =
                     {
                        new SqlParameter("@Task", "DeleteImages"),
                        new SqlParameter("@SurWayOffMasID", SurWayOffMasID),
                    };

                    int res = cls_dl_InstRece.SurchargeWaiveImage_NonQuery(param);
                    foreach (clsMemberImage row in ImageContainer)
                    {
                        MemoryStream ms = new MemoryStream();
                        row.MemberImage.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                        Byte[] Image = ms.ToArray();
                        SqlParameter[] parameters =
                        {
                            new SqlParameter("@Task", "Insert"),
                            new SqlParameter("@SurWayOffMasID", SurWayOffMasID),
                            new SqlParameter("@ImageFile", Image),
                            new SqlParameter("@ImageName", row.ImageName),
                            new SqlParameter("@Description", row.Description),
                            new SqlParameter("@user_ID", clsUser.ID),
                        };
                        int re = cls_dl_InstRece.SurchargeWaiveImage_NonQuery(parameters);

                    }
                    ImageContainer.Clear();
                    ImageSource.DataSource = null;

                }
                catch (Exception rc)
                {
                }
            }
            int result = 0;
            foreach (DataRow item in _dRow)
            {
                SqlParameter[] param = {
                        new SqlParameter("@Task","UpdateEntryforWaveoff"),
                        new SqlParameter("@SurchargeWayOffID",Helper.clsPluginHelper.DbNullIfNullOrEmpty(item["SurchargeWayOffID"].ToString())),
                        new SqlParameter("@FileMapKey",Helper.clsPluginHelper.DbNullIfNullOrEmpty(item["FileMapKey"].ToString())),
                        new SqlParameter("@InstallmentPlanID",Helper.clsPluginHelper.DbNullIfNullOrEmpty(item["PlanID"].ToString())),
                        new SqlParameter("@WaveoffinPer",Helper.clsPluginHelper.DbNullIfNullOrEmpty(item["WaveoffinPer"].ToString())),
                        new SqlParameter("@SurchargeStatus",   SurchargeStauts ),
                        new SqlParameter("@SurWayOffMasID",string.IsNullOrEmpty(SurWayOffMasID) ? null : SurWayOffMasID),
                        new SqlParameter("@Remarks",txtRemarks.Text),
                     };
                int status = 0;
                status = cls_dl_Surcharge.Surcharge_NonQuery(param);
                result = result + status;
            }
            if (result > 0)
            {
                //MessageBox.Show("Record save successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        Decimal _preval = 0;
        private void DGVSurcharge_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            try
            {
                // int RowINdex = DGVSurcharge.CurrentRow.Index;

                if (true)
                {//
                    try
                    {
                        string curentSur = e.Row.Cells["CurrentSurcharge"].Value.ToString();  //DGVSurcharge.Rows[RowINdex].Cells["WaveoffinPer"].Value.ToString();
                        if (!string.IsNullOrEmpty(curentSur))
                        {

                            string pervalue1 = e.Row.Cells["WaveoffinPer"].Value.ToString();  //DGVSurcharge.Rows[RowINdex].Cells["WaveoffinPer"].Value.ToString();
                            Decimal percentage1 = 0;
                            bool checker1 = Decimal.TryParse(pervalue1, out percentage1);
                            if (_preval == percentage1)
                                return;
                            if (double.Parse(curentSur) <= 0)
                            {
                                MessageBox.Show("Surcharge doest not exist against this record.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                e.Row.Cells["WaveoffinPer"].Value = _preval;
                                DGVSurcharge.Refresh();
                                return;
                            }
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
                if (_preval >= 100 && e.Row.Cells["SurchargeStatus"].Value.ToString() != "Pending")
                {
                    MessageBox.Show("Surcharge is already Waive-off 100%. Can't be changed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Row.Cells["WaveoffinPer"].Value = _preval;
                    DGVSurcharge.Refresh();
                    return;
                }

                string pervalue = e.Row.Cells["WaveoffinPer"].Value.ToString();  //DGVSurcharge.Rows[RowINdex].Cells["WaveoffinPer"].Value.ToString();
                Decimal percentage = 0;
                bool checker = Decimal.TryParse(pervalue, out percentage);
                if (percentage == 0)
                {
                    return;
                }
                if (percentage < _preval && e.Row.Cells["SurchargeStatus"].Value.ToString() == "Wavieroff")
                {
                    MessageBox.Show("Surchage Waive-off Percent must be greater than previous value.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Row.Cells["WaveoffinPer"].Value = _preval;
                    DGVSurcharge.Refresh();
                    return;
                }
                if (checker == true)
                {
                    if (percentage > -1 && percentage < 101)
                    {
                        btnSaveSurcharge.Enabled = true;
                        try
                        {
                            Decimal currentSurch = 0;
                            if (!string.IsNullOrEmpty(e.Row.Cells["CurrentSurcharge"].Value.ToString()))
                                currentSurch = Decimal.Parse(e.Row.Cells["CurrentSurcharge"].Value.ToString());

                            Decimal TotalWav = currentSurch * percentage / 100;
                            Decimal RemaingSurch = currentSurch - TotalWav;
                            e.Row.Cells["Wavieroff"].Value = TotalWav;
                            e.Row.Cells["DueSurcharge"].Value = RemaingSurch;
                            e.Row.Cells["SurchargeStatus"].Value = "Pending";
                            e.Row.Cells["SurWayOffMasID"].Value = null;
                            SurWayOffMasID = null;
                            DGVSurcharge.Refresh();
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    else
                    {
                        MessageBox.Show("Check your Wavieroff value.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnSaveSurcharge.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("You Data is in Correct");
                    btnSaveSurcharge.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void MasterTemplate_CellEditorInitialized(object sender, GridViewCellEventArgs e)
        {
            string Precval = e.Row.Cells["WaveoffinPer"].Value.ToString();
            bool checker = Decimal.TryParse(Precval, out _preval);
            //{
            //    MessageBox.Show("Modification ");

            //    return;
            //}
        }
        List<clsMemberImage> ImageContainer = new List<clsMemberImage>();

        private void btnBrowseforSingleimage_Click(object sender, EventArgs e)
        {
            try
            {
                int imageCount = ImageContainer.Count() + 1;
                clsMemberImage obj = new clsMemberImage();
                obj.ImageName = DateTime.Now.ToString("yyyyMMdd") + "_" + imageCount;
                obj.Description = "Attachment with Surcharge Waiver.";

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
                    if (e.Row == null)
                        return;
                    ImageContainer.RemoveAt(e.RowIndex);
                    ImageSource.TableElement.RowHeight = 50;
                    ImageSource.Columns["MemberImage"].ImageLayout = ImageLayout.Stretch;
                    ImageSource.DataSource = ImageContainer;
                    if (ImageContainer.Count == 0)
                        ImageSource.DataSource = null;
                }
                catch (Exception)
                {
                    ImageSource.DataSource = null;
                }
            }
        }

        private void DGVSurcharge_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (SurWayOffMasID == null)
                return;
            if (!(e.Row is GridViewNewRowInfo) && e.Row.Cells["SurWayOffMasID"].Value.ToString() != SurWayOffMasID)
            {
                e.Cancel = true;
            }
        }
    }
}
