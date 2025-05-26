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

namespace PeshawarDHASW.Application_Layer.FileMap.FileCancelationProcess
{
    public partial class frmFileCancelationInitial : Telerik.WinControls.UI.RadForm
    {
        public frmFileCancelationInitial()
        {
            InitializeComponent();

            dtpDeduction.Items.Add(new RadListDataItem(text: "0%", value: (int)0));
            dtpDeduction.Items.Add(new RadListDataItem(text: "20%", value: (int)20));
            dtpDeduction.SelectedIndex = 0;

            dtpcancel.Items.Add(new RadListDataItem(text: "Cancel", value: "Cancel"));
          //  dtpcancel.Items.Add(new RadListDataItem(text: "Cancel-Re-Issue", value: "Cancel-Re-Issue"));
            dtpcancel.SelectedIndex = 0;
        }

        private void radTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                radButton1_Click(null, null);
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            try
            {

                SqlParameter param_out_ID = new SqlParameter()
                {
                    ParameterName = "@FileCanceltion",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlParameter[] parameterforsearch =
                   {
                        new SqlParameter("@Task", "MembershipVerificationforRefund"),
                        new SqlParameter("@FileNo", clsPluginHelper.DbNullIfNullOrEmpty(txtFileNo.Text)),
                        param_out_ID
                    };
                DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "usp_tbl_FileCancelation", parameterforsearch);


            if (ds.Tables[0].Rows.Count > 0)
            {

                    if (ds.Tables[0].Rows[0]["Existing"].ToString() != "0")
                    {
                        MessageBox.Show("File Refund is Already in process.");
                        return;
                    }
                    else
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            lblfileno.Text = row["FileNo"].ToString();
                            lblplotno.Text = row["PlotNo"].ToString();
                            lblmsno.Text = row["MembershipNo"].ToString();
                            lblcontact.Text = row["MobileNo"].ToString();
                            lblname.Text = row["Name"].ToString();
                            lblNIC.Text = row["NIC/NICOP"].ToString();
                            lblfilekey.Text = row["FileMapKey"].ToString();
                            lblmsid.Text = row["ID"].ToString();
                        }
                        Acinformation(txtFileNo.Text);
                    }
            }
            else
            {
                Clear();
                MessageBox.Show("1. File No is incorrect. OR \n 2. File No is not Lock. OR \n 3. File No is Cancelled OR \n 4. File No is Category is not Balloting  ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
          }
            catch (Exception ex )
            {
                Clear();
                MessageBox.Show("Invalid FileNo Entered \n or FileNo is Not Exist in your System \n or File No is \n 1.Must be Lock \n 2. File No Must be Active ");
            }
        }

        public void Clear()
        {
            lblfileno.Text = "";
            lblplotno.Text = "";
            lblmsno.Text = "";
            lblcontact.Text = "";
            lblname.Text = "";
            lblNIC.Text = "";
            lblfilekey.Text = "";
            lblmsid.Text = "";
            txtdeducatedamount.Text = "";

            txtrefunded.Text = "";
            lblDueSurcharge.Text = "";
            lblTotalSurcPaid.Text = "";
            lblDueRemaing.Text = "";
            lblTotalDue.Text = "";
            lblTotalSurcharge.Text = "";
            lblTotalReceive.Text = "";
            lblGrandDueTotal.Text = "";
            lblMSCharges.Text = "";
            lblKPKTax.Text = "";
            TotalReceive_Amount_forRefund = 0; 
        }
        public int TotalReceive_Amount_forRefund { get; set; } = 0;
        #region Account Information
        private void Acinformation( string FileNo)
        {

            SqlParameter[] prm =
              {
                new SqlParameter("@Task","Account_Statement_Reading"),
                new SqlParameter("@FileNo",FileNo),
                new SqlParameter("@userID",Models.clsUser.ID),
                new SqlParameter("@ByPassFileLock","ByPassFileLock")
            };
            DataSet dst = new DataSet();
            dst = Data_Layer.Installment.cls_dl_FinanceDashBoard.InstallmentSummary_Reader(prm);

            int MemberShipFee = dst.Tables[0].AsEnumerable().Where(r => r.Field<string>("AccountHead").Contains("Membership"))
                            .Sum(r => r.Field<int>("ReceAdjustAmount"));

            int KPKSaleTax = dst.Tables[0].AsEnumerable().Where(r => r.Field<string>("AccountHead").Contains("KPK") && r.Field<int?>("ReceAdjustAmount") != null)
                            .Sum(r => r.Field<int>("ReceAdjustAmount"));

            int TotalAmount = dst.Tables[0].AsEnumerable().Where(r => r.Field<DateTime>("DueDate") <= DateTime.Now)
                             .Sum(r => r.Field<int>("PlanAdjustAmount"));
            int Surcharge = dst.Tables[0].AsEnumerable().Where(r => r.Field<DateTime>("DueDate") <= DateTime.Now)
                                 .Sum(r => r.Field<int>("Surcharge"));
            int TotalReceive = dst.Tables[0].AsEnumerable().Where(r => r.Field<int?>("ReceAdjustAmount") != null)
                                .Sum(r => r.Field<int>("ReceAdjustAmount"));

            dst.Tables[1].Columns.Add("TotalDueSurcharge", typeof(Int32));
            dst.Tables[1].Columns.Add("TotalDueAmount", typeof(Int32));
            dst.Tables[1].Columns.Add("TotalRecAmount", typeof(Int32));

            dst.Tables[1].Rows[0]["TotalDueSurcharge"] = Surcharge;
            dst.Tables[1].Rows[0]["TotalDueAmount"] = TotalAmount;
            dst.Tables[1].Rows[0]["TotalRecAmount"] = TotalReceive;

            double TotalSurchargePaid = 0;
            double DueRemaingAmount = 0;
            double DueSurchAmount = 0;
            bool res = double.TryParse(dst.Tables[0].Rows[0]["TotalPaidSurcharge"].ToString(), out TotalSurchargePaid);
            DueRemaingAmount = TotalAmount - TotalReceive;
            DueSurchAmount = Surcharge - TotalSurchargePaid;
            int RemainingAmount = TotalReceive - (MemberShipFee + KPKSaleTax);
            
            double refundper = double.Parse( dtpDeduction.SelectedItem.Value.ToString());
            double deducdateamount = RemainingAmount * (refundper ==0?0:refundper/100);
            txtdeducatedamount.Text = string.Format("{0:n0}", deducdateamount);
            double refundamount = RemainingAmount - deducdateamount;
            txtrefunded.Text = string.Format("{0:n0}", refundamount);
            lblDueSurcharge.Text = string.Format("{0:n0}", DueSurchAmount);
            lblTotalSurcPaid.Text = string.Format("{0:n0}", TotalSurchargePaid);
            lblDueRemaing.Text = string.Format("{0:n0}", DueRemaingAmount);

            double GrandTotal = (DueRemaingAmount + DueSurchAmount);

            lblTotalDue.Text = string.Format("{0:n0}", TotalAmount); ;
            lblTotalSurcharge.Text = string.Format("{0:n0}", Surcharge);
            lblTotalReceive.Text = string.Format("{0:n0}", TotalReceive);
            lblGrandDueTotal.Text = string.Format("{0:n0}", GrandTotal);
            lblMSCharges.Text = string.Format("{0:n0}", MemberShipFee);
            lblKPKTax.Text = string.Format("{0:n0}", KPKSaleTax);
            TotalReceive_Amount_forRefund = RemainingAmount;
        }
        #endregion

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

        private void ImageSource_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
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

        private void btnFileCancellation_Click(object sender, EventArgs e)
        {
            if (ImageSource.RowCount > 0)
            {
                if (string.IsNullOrEmpty( txtrefunded.Text) || string.IsNullOrEmpty(txtdeducatedamount.Text) || string.IsNullOrEmpty(CancelationRemarks.Text))
                {
                    MessageBox.Show("Please Fill all mandatory", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                SqlParameter param_out_ID = new SqlParameter()
                {
                    ParameterName = "@FileCanceltion",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlParameter[] param = {
                new SqlParameter("@Task","NewCancelationRequest"),
                new SqlParameter("@FileMapKey",lblfilekey.Text),
                new SqlParameter("@TotalReceiveAmount",lblTotalReceive.Text.Replace(",","")),
                new SqlParameter("@RefundedAmount",txtrefunded.Text.Replace(",","")),
                new SqlParameter("@DeducatedAmount",txtdeducatedamount.Text.Replace(",","")),
                new SqlParameter("@DateofCancelation",dtpCancelation.Value),
                new SqlParameter("@Remarks",CancelationRemarks.Text),
                new SqlParameter("@RequestedbyUser",clsUser.ID),
                new SqlParameter("@Bank",txtBank.Text),
                new SqlParameter("@ChequeNumber",txtChequeNumber.Text),
                new SqlParameter("@DeductionPer",dtpDeduction.SelectedItem.Value.ToString()),
                new SqlParameter("@TypeCancelation",dtpcancel.SelectedItem.Value.ToString()),
                new SqlParameter("@MemberID",lblmsid.Text),
                new SqlParameter("@Status","Pending"),
              param_out_ID
            };

                SqlCommand cmd = new SqlCommand();
                cmd = SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(), CommandType.StoredProcedure, "usp_tbl_FileCancelation", "", param);
                if (cmd.Parameters.Count != 0)
                {
                    try
                    {
                        int FileCanncelationID = int.Parse(cmd.Parameters["@FileCanceltion"].Value.ToString());
                        foreach (clsMemberImage row in ImageContainer)
                        {
                            MemoryStream ms = new MemoryStream();
                            row.MemberImage.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                            Byte[] Image = ms.ToArray();
                            SqlParameter[] parameters =
                            {
                                new SqlParameter("@Task", "SaveFileCancellationImages"),
                                new SqlParameter("@FileMapKey", lblfilekey.Text),
                                new SqlParameter("@ImageFile", Image),
                                new SqlParameter("@ImageName", row.ImageName),
                                new SqlParameter("@Description", row.Description),
                                new SqlParameter("@user_ID", clsUser.ID),
                                new SqlParameter("@CFID",FileCanncelationID)
                            };
                            int result = SQLHelper.ExecuteNonQuery(clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "usp_tbl_FileCancelationImages", parameters);
                            if (result>0)
                            {
                                txtrefunded.Text = string.Empty;
                                txtdeducatedamount.Text = string.Empty;
                                CancelationRemarks.Text = string.Empty;
                                txtFileNo.Text = string.Empty;
                            }
                        }
                        ImageContainer.Clear();
                        ImageSource.DataSource = null;
                        this.Close();
                    }

                    catch (Exception)
                    {

                    }
                }
            }
            else
            {
                MessageBox.Show("Please Attach the Images","Attention No Image is Attached.",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }
        }

        public void ApplyTheme(string themeName)
        {
            this.ThemeName = themeName; ThemeResolutionService.ApplyThemeToControlTree(this, themeName);
        }

        private void frmFileCancelationInitial_Load(object sender, EventArgs e)
        {
            if (clsUser.ThemeName == String.Empty)
            {
                ApplyTheme("TelerikMetro");
            }
            else
            {
                ApplyTheme(clsUser.ThemeName);
            }

            dtpCancelation.Value = DateTime.Now;
            Loading();
        }

        private void Loading()
        {
            SqlParameter param_out_ID = new SqlParameter()
            {
                ParameterName = "@FileCanceltion",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            SqlParameter[] parameters =
                           {
                                new SqlParameter("@Task", "SelectInformation_Pending_Cancel_Approved"),

                               param_out_ID
                            };
            DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "usp_tbl_FileCancelation", parameters);
            DataTable allds = new DataTable();
            allds.Merge(ds.Tables[0]);
            allds.Merge(ds.Tables[1]);
            allds.Merge(ds.Tables[2]);
            grd_AllRequests.DataSource = allds.DefaultView;
        }

        private void grd_AllRequests_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "Attachement")
            {
                try
                {
                    int TDDI_ID = int.Parse(e.Row.Cells["FileCancelationID"].Value.ToString()); // ReceID
                    SqlParameter[] param =
                               {
                    new SqlParameter("@Task","Select"),//usp_tbl_DDTransferImages
                    new SqlParameter("@CFID",TDDI_ID)
                     };
                    DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "usp_tbl_FileCancelationImages", param);
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Membership.MSImage.frmPhotoViewer obj = new Membership.MSImage.frmPhotoViewer(ds.Tables[0]);
                            obj.Show();
                        }
                        else
                        {
                            MessageBox.Show("No attachment(s) available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No attachment(s) available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                }
            }
            if (e.Column.Name== "btnCheque")
            {
                string FileCancel = e.Row.Cells["FileCancelationID"].Value.ToString();
                string ChequeNo = e.Row.Cells["ChequeNumber"].Value.ToString();
                string Bank = e.Row.Cells["Bank"].Value.ToString();
                ChequeNoChanges obj = new ChequeNoChanges(FileCancel,ChequeNo,Bank);
                    obj.ShowDialog();
                Loading();
            }
        }

        private void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(grd_AllRequests);
        }

        private void dtpDeduction_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
                double refundper = double.Parse(dtpDeduction.SelectedItem.Value.ToString());
                double deducdateamount = TotalReceive_Amount_forRefund * (refundper == 0 ? 0 : refundper / 100);
                txtdeducatedamount.Text = string.Format("{0:n0}", deducdateamount);
                double refundamount = TotalReceive_Amount_forRefund - deducdateamount;
                txtrefunded.Text = string.Format("{0:n0}", refundamount);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Loading();
        }
    }
}
