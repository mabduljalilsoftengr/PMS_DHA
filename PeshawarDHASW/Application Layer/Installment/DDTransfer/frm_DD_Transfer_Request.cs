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

namespace PeshawarDHASW.Application_Layer.Installment.DDTransfer
{
    public partial class frm_DD_Transfer_Request : Telerik.WinControls.UI.RadForm
    {
        private int New_FileKey { get; set; }
        private int New_MemberID { get; set; }
        private int Old_Filekey { get; set; }
        private int Old_MemberID { get; set; }
        public frm_DD_Transfer_Request()
        {
            InitializeComponent();
        }

        private void frm_DD_Transfer_Request_Load(object sender, EventArgs e)
        {
            txtTrxID.Focus();
        }

        private void btn_FindRecord_Click(object sender, EventArgs e)
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","Get_Info_For_DDTransfer"),
                new SqlParameter("@Rece_ID",txtTrxID.Text)
            };
            DataSet dst = cls_dl_InstRece.Inst_Rece_Read(prm);
            if (dst.Tables.Count > 0)
            {
                if (dst.Tables[0].Rows.Count > 0)
                {
                    Old_Filekey = int.Parse(dst.Tables[0].Rows[0]["FileMapKey"].ToString());
                    Old_MemberID = int.Parse(dst.Tables[0].Rows[0]["ID"].ToString());
                    txtFileNo_Old.Text = dst.Tables[0].Rows[0]["FileNo"].ToString();
                    txtOwnerName_Old.Text = dst.Tables[0].Rows[0]["Name"].ToString();
                    txtReceDate_old.Text = dst.Tables[0].Rows[0]["EntryDate"].ToString();
                    txtDDno_old.Text = dst.Tables[0].Rows[0]["DDNo"].ToString();
                    txtAmount_Old.Text = dst.Tables[0].Rows[0]["Amount"].ToString();
                    txtBankOld.Text = dst.Tables[0].Rows[0]["BankName"].ToString();
                    txtBranch_old.Text = dst.Tables[0].Rows[0]["Branch"].ToString();
                }
                else
                {
                    MessageBox.Show("There is no Owner Information Exist.");
                }
            }
            else
            {
                MessageBox.Show("There is no Owner Information Exist.");
            }

        }

        private void btnFileNo_plotSearch_Click(object sender, EventArgs e)
        {
            SqlParameter[] prm = { new SqlParameter("@Task", "Get_Info_For_DDTransfer_New_Owner"), new SqlParameter("@FileNo", Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtFileNo.Text)), new SqlParameter("@PlotNo", Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtPlotNo.Text)) };
            DataSet dst = cls_dl_InstRece.Inst_Rece_Read(prm);
            if (dst.Tables.Count > 0)
            {
                if (dst.Tables[0].Rows.Count > 0)
                {
                    btn_tfr_new_owner.Enabled = true;
                    New_FileKey = int.Parse(dst.Tables[0].Rows[0]["FileMapKey"].ToString());
                    New_MemberID = int.Parse(dst.Tables[0].Rows[0]["ID"].ToString());
                    txtFileNo_New.Text = dst.Tables[0].Rows[0]["FileNo"].ToString();
                    txtOwnerName_New.Text = dst.Tables[0].Rows[0]["Name"].ToString();
                    txtMobileNO_New.Text = dst.Tables[0].Rows[0]["MobileNo"].ToString();
                    txtAddress_New.Text = dst.Tables[0].Rows[0]["PresentAddress"].ToString();
                }
                else
                {
                    MessageBox.Show("There is no New Owner Information Exist.");
                }
            }
            else
            {
                MessageBox.Show("There is no New Owner Information Exist.");
            }

        }
        private void ClearControls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is RadTextBox)
                    c.Text = "";
            }

        }

        private void btn_tfr_new_owner_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRemarks_New.Text.Trim()))
            {
                MessageBox.Show("Please enter remarks to proceed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtFileNo_Old.Text) || string.IsNullOrEmpty(txtFileNo_New.Text))
            {
                MessageBox.Show("Please provide full information to proceed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFileNo_New.Focus();
                return;
            }
            SqlParameter param_out_ID = new SqlParameter()
            {
                ParameterName = "@ChallanIDOutput",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            SqlParameter[] prm = {
                                    new SqlParameter("@Task","Insert_DDTFR_From_OldNewOwner"),
                                    new SqlParameter("@ReceID", txtTrxID.Text),
                                    new SqlParameter("@TfrOld_FileKey", Old_Filekey),
                                    new SqlParameter("@TfrOld_MemberID", Old_MemberID),
                                    new SqlParameter("@TfrNew_FileKey",New_FileKey),
                                    new SqlParameter("@TfrNew_MemberIDnt",New_MemberID),
                                    new SqlParameter("@Remarks_on",txtRemarks_New.Text.Trim()),
                                    new SqlParameter("@userID",Models.clsUser.ID),
                                    new SqlParameter("@Status","Pending"),
                                    new SqlParameter("@ReceDateChangetoApprovalDate", (chkDDReceiveDateChange.CheckState==CheckState.Checked?true:false)),
                                    param_out_ID
                                };
            SqlCommand rslt = cls_dl_InstRece.InstReceExecuteNonQuery(prm);
            if (rslt.Parameters.Count != 0)
            {
                try
                {
                    int ChallanIDOut = int.Parse(rslt.Parameters["@ChallanIDOutput"].Value.ToString());
                    foreach (clsMemberImage row in ImageContainer)
                    {
                        MemoryStream ms = new MemoryStream();
                        row.MemberImage.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                        Byte[] Image = ms.ToArray();
                        SqlParameter[] parameters =
                        {
                                new SqlParameter("@Task", "Insert"),
                                new SqlParameter("@DDTransferID", ChallanIDOut),
                                new SqlParameter("@ImageFile", Image),
                                new SqlParameter("@ImageName", row.ImageName),
                                new SqlParameter("@Description", row.Description),
                                new SqlParameter("@user_ID", clsUser.ID),
                            };
                        int result = cls_dl_InstRece.Image_NonQuery(parameters);

                    }
                    ImageContainer.Clear();
                    ImageSource.DataSource = null;

                }
                catch (Exception rc)
                {
                }

                MessageBox.Show("Request for DD Transfer has been successfully sent.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearControls(radGroupBox2);
                ClearControls(radGroupBox3);
                btn_tfr_new_owner.Enabled = false;
                txtTrxID.Clear();
                txtRemarks_New.Clear();
                txtFileNo.Clear();
                txtPlotNo.Clear();
            }
            else
            {
                MessageBox.Show("Transaction failed. Please contact Technical team.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFileNo_Old_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtTrxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btn_FindRecord_Click(null, null);
            }
        }

        private void txtFileNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnFileNo_plotSearch_Click(null, null);
            }
        }

        private void txtPlotNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnFileNo_plotSearch_Click(null, null);
            }
        }

        private void radPageView1_SelectedPageChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                SqlParameter[] prm = {
                    new SqlParameter("@Task", "GetUserDDTransfer"),
                    new SqlParameter("@userID", Models.clsUser.ID)
                };
                DataSet dst = cls_dl_InstRece.Inst_Rece_Read(prm);
                grdApprovedTransfeer.DataSource = dst.Tables[0].DefaultView;
                foreach (GridViewDataColumn column in grdApprovedTransfeer.Columns)
                {
                    column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
                }
            }
            catch (Exception)
            {
            }
        }

        private void grdApprovedTransfeer_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement.Value != null)
            {
                e.CellElement.ToolTipText = e.CellElement.Value.ToString();
            }
        }

        List<clsMemberImage> ImageContainer = new List<clsMemberImage>();

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

        private void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(grdApprovedTransfeer);
        }
    }
}
