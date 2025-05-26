using PeshawarDHASW.Data_Layer.Installment;
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

namespace PeshawarDHASW.Application_Layer.Installment.Account_Statement.AdjustmentModule
{
    public partial class frmAdjustment : Telerik.WinControls.UI.RadForm
    {
        public frmAdjustment()
        {
            InitializeComponent();
        }

        private DataSet dst1 = new DataSet();
        private DataSet dst2 = new DataSet();
        private void btnadjust_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are You Sure ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string rdbtrxiddetail = "";
                    if (rdbFulltrxiddeail.IsChecked) { rdbtrxiddetail = "Full"; } else if (rdbPartialtrxiddeail.IsChecked) { rdbtrxiddetail = "Partial"; }
                    SqlParameter[] prm =
                    {
                    new SqlParameter("@Task","InstlToSurgAdjustment_InPendingStatus"),
                    new SqlParameter("@TRXID",txttrxid.Text),
                    new SqlParameter("@FileNoFrm",lblfiletrxiddetail.Text ),
                    new SqlParameter("@MsNoFrm",lblmsnotrxiddetail.Text ),
                    new SqlParameter("@TotalAmountFrm",lbltotalamounttrxiddetail.Text ),
                    new SqlParameter("@DDNo",lblddnotrxiddetail.Text ),
                    new SqlParameter("@FileNoTo",txtfileno.Text ),
                    new SqlParameter("@MsNoTo",txtmembershipno.Text ),
                    new SqlParameter("@AmountAdj",txtadjustedamounttrxiddetail.Text  ),
                    new SqlParameter("@IsFullPartial",rdbtrxiddetail),
                    new SqlParameter("@Status_adj","Pending"),
                    new SqlParameter("@AdjType","InstallmentToSurcharge"),
                    new SqlParameter("@userID",Models.clsUser.ID)
                    };
                    DataSet rslt = cls_dl_FinanceDashBoard.AccountStatement_RecePlanAdjustRetrive(prm);
                    if (rslt.Tables.Count > 0)
                    {
                        if (rslt.Tables[0].Rows.Count > 0)
                        {
                            #region  Images saving 
                            if (grdis.RowCount > 0)
                            {
                                int adjid = int.Parse(rslt.Tables[0].Rows[0]["AdjID"].ToString());
                                for (int i = 0; i < grdis.RowCount; i++)
                                {
                                    Image img = (Image)grdis.Rows[i].Cells["Image"].Value;
                                    MemoryStream ms = new MemoryStream();
                                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    Byte[] Image = ms.ToArray();

                                    SqlParameter[] parameters =
                                    {
                                     new SqlParameter("@Task", "InsertPaymentsAdjustmentImages"),
                                     new SqlParameter("@AdjID", adjid),
                                     new SqlParameter("@Image", Image),
                                     new SqlParameter("@ImageName", grdis.Rows[i].Cells["ImageName"].Value),
                                     new SqlParameter("@Description", grdis.Rows[i].Cells["Description"].Value),
                                     new SqlParameter("@user_ID", clsUser.ID),
                                    };
                                    int result = Helper.SQLHelper.ExecuteNonQuery(
                                                            clsMostUseVars.VerifiedImageConnectionstring,
                                                            CommandType.StoredProcedure,
                                                            "usp_tbl_PaymentsAdjustmentImage",
                                                            parameters
                                                            );

                                }
                            }


                            #endregion
                            MessageBox.Show("Successful.");
                            Clearis();
                        }

                    }
                }
                //SqlParameter[] prm =
                //{
                //new SqlParameter("@Task","InstlToSurgAdjustment"),
                //new SqlParameter("@TRXID",txttrxid.Text),
                //new SqlParameter("@ConvertedToFileNo",txtfileno.Text),
                //new SqlParameter("@ConvertedToDPRNo",txtmembershipno.Text),
                //new SqlParameter("@UserID",Models.clsUser.ID)
                //};
                //int rslt = cls_dl_FinanceDashBoard.AccountStatement_RecePlanAdjust(prm);
                //if (rslt > 0)
                //{
                //    MessageBox.Show("Successful.");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnconvertsurtoistl_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are You Sure ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string rdbtrxiddetail = "";
                    if (rdbfullsti.IsChecked) { rdbtrxiddetail = "Full"; } else if (rdbpartialsti.IsChecked) { rdbtrxiddetail = "Partial"; }
                    SqlParameter[] prm =
                    {
                   new SqlParameter("@Task","SurgToInstalmentAdjustment_InPendingStatus"),
                   new SqlParameter("@FileNoFrm",lblfilenosti.Text ),
                   new SqlParameter("@MsNoFrm",lblmsnosti.Text ),
                   new SqlParameter("@TotalAmountFrm",lbltotalamountsti.Text ),
                   new SqlParameter("@ChallanNo",lblchallannosti.Text ),
                   new SqlParameter("@FileNoTo",txtfilenosurtoistl.Text ),
                   new SqlParameter("@MsNoTo",txtmembershipsurtoistl.Text ),
                   new SqlParameter("@AmountAdj",txtadjustedamountsti.Text  ),
                   new SqlParameter("@IsFullPartial",rdbtrxiddetail),
                   new SqlParameter("@Status_adj","Pending"),
                   new SqlParameter("@AdjType","SurchargeToInstallment"),
                   new SqlParameter("@userID",Models.clsUser.ID)
                   };
                    DataSet rslt = cls_dl_FinanceDashBoard.AccountStatement_RecePlanAdjustRetrive(prm);
                    if (rslt.Tables.Count > 0)
                    {
                        if (rslt.Tables[0].Rows.Count > 0)
                        {
                            #region  Images saving 
                            if (grdsi.RowCount > 0)
                            {
                                int adjid = int.Parse(rslt.Tables[0].Rows[0]["AdjID"].ToString());
                                for (int i = 0; i < grdsi.RowCount; i++)
                                {
                                    Image img = (Image)grdsi.Rows[i].Cells["Image"].Value;
                                    MemoryStream ms = new MemoryStream();
                                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    Byte[] Image = ms.ToArray();

                                    SqlParameter[] parameters =
                                    {
                                     new SqlParameter("@Task", "InsertPaymentsAdjustmentImages"),
                                     new SqlParameter("@AdjID", adjid),
                                     new SqlParameter("@Image", Image),
                                     new SqlParameter("@ImageName", grdsi.Rows[i].Cells["ImageName"].Value),
                                     new SqlParameter("@Description", grdsi.Rows[i].Cells["Description"].Value),
                                     new SqlParameter("@user_ID", clsUser.ID),
                                    };
                                    int result = Helper.SQLHelper.ExecuteNonQuery(
                                                            clsMostUseVars.VerifiedImageConnectionstring,
                                                            CommandType.StoredProcedure,
                                                            "usp_tbl_PaymentsAdjustmentImage",
                                                            parameters
                                                            );

                                }
                            }


                            #endregion
                            MessageBox.Show("Successful.");
                            Clearsi();
                        }
                            
                    }
                }

                //SqlParameter[] prm =
                //{
                //new SqlParameter("@Task","SurgToInstlAdjustment"),
                //new SqlParameter("@ChallanNo",txtchlnsurtoistl.Text),
                //new SqlParameter("@ConvertedToFileNo",txtfilenosurtoistl.Text),
                //new SqlParameter("@ConvertedToDPRNo",txtmembershipsurtoistl.Text),
                //new SqlParameter("@UserID",Models.clsUser.ID)
                //};
                //int rslt = cls_dl_FinanceDashBoard.AccountStatement_RecePlanAdjust(prm);
                //if (rslt > 0)
                //{
                //    MessageBox.Show("Successful.");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Clearsi()
        {
            txtchlnsurtoistl.Text = "";
            lblfilenosti.Text = "#";
            lblmsnosti.Text = "#";
            lbltotalamountsti.Text = "#";
            lblchallannosti.Text = "#";
            txtfilenosurtoistl.Text = "";
            txtmembershipsurtoistl.Text = "";
            txtadjustedamountsti.Text = "";
            rdbfullsti.CheckState = CheckState.Checked;
            rdbpartialsti.CheckState = CheckState.Unchecked;
            grdsi.Rows.Clear();
        }
        private void Clearis()
        {
            txttrxid.Text = "";
            lblfiletrxiddetail.Text = "#";
            lblmsnotrxiddetail.Text = "#";
            lbltotalamounttrxiddetail.Text = "#";
            lblddnotrxiddetail.Text = "#";
            txtfileno.Text = "";
            txtmembershipno.Text = "";
            txtadjustedamounttrxiddetail.Text = "";
            rdbFulltrxiddeail.CheckState = CheckState.Checked;
            rdbPartialtrxiddeail.CheckState = CheckState.Unchecked;
            grdis.Rows.Clear();
        }
        private void Clearss()
        {
            txtchallanno.Text = "";
            lblfilests.Text = "#";
            lblmsnosts.Text = "#";
            lblamountsts.Text = "#";
            lblchallannosts.Text = "#";
            txtfilenoch.Text = "";
            txtmembershipnoch.Text = "";
            txtamountsts.Text = "";
            rdbfullsts.CheckState = CheckState.Checked;
            rdbpartialsts.CheckState = CheckState.Unchecked;
            grdss.Rows.Clear();
        }
        private void btnadjustedch_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are You Sure ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string rdbtrxiddetail = "";
                    if (rdbfullsts.IsChecked) { rdbtrxiddetail = "Full"; } else if (rdbpartialsts.IsChecked) { rdbtrxiddetail = "Partial"; }
                   SqlParameter[] prm =
                   {
                   new SqlParameter("@Task","SurgToSurgAdjustment_InPendingStatus"),
                   new SqlParameter("@FileNoFrm",lblfilests.Text ),
                   new SqlParameter("@MsNoFrm",lblmsnosts.Text ),
                   new SqlParameter("@TotalAmountFrm",lblamountsts.Text ),
                   new SqlParameter("@ChallanNo",lblchallannosts.Text ),
                   new SqlParameter("@FileNoTo",txtfilenoch.Text ),
                   new SqlParameter("@MsNoTo",txtmembershipnoch.Text ),
                   new SqlParameter("@AmountAdj",txtamountsts.Text  ),
                   new SqlParameter("@IsFullPartial",rdbtrxiddetail),
                   new SqlParameter("@Status_adj","Pending"),
                   new SqlParameter("@AdjType","SurchargeToSurcharge"),
                   new SqlParameter("@userID",Models.clsUser.ID)
                   };
                    DataSet rslt = cls_dl_FinanceDashBoard.AccountStatement_RecePlanAdjustRetrive(prm);
                    if (rslt.Tables.Count > 0)
                    {
                        if (rslt.Tables[0].Rows.Count > 0)
                        {
                            #region  Images saving 
                            if (grdss.RowCount > 0)
                            {
                                int adjid = int.Parse(rslt.Tables[0].Rows[0]["AdjID"].ToString());
                                for (int i = 0; i < grdss.RowCount; i++)
                                {
                                    Image img = (Image)grdss.Rows[i].Cells["Image"].Value;
                                    MemoryStream ms = new MemoryStream();
                                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    Byte[] Image = ms.ToArray();

                                    SqlParameter[] parameters =
                                    {
                                     new SqlParameter("@Task", "InsertPaymentsAdjustmentImages"),
                                     new SqlParameter("@AdjID", adjid),
                                     new SqlParameter("@Image", Image),
                                     new SqlParameter("@ImageName", grdss.Rows[i].Cells["ImageName"].Value),
                                     new SqlParameter("@Description", grdss.Rows[i].Cells["Description"].Value),
                                     new SqlParameter("@user_ID", clsUser.ID),
                                    };
                                    int result = Helper.SQLHelper.ExecuteNonQuery(
                                                            clsMostUseVars.VerifiedImageConnectionstring,
                                                            CommandType.StoredProcedure,
                                                            "usp_tbl_PaymentsAdjustmentImage",
                                                            parameters
                                                            );

                                }
                            }


                            #endregion
                            MessageBox.Show("Successful.");
                            Clearss();
                        }

                    }
                }
                //SqlParameter[] prm =
                //{
                //new SqlParameter("@Task","SurToSurofAnotherFile"),
                //new SqlParameter("@ChallanNo_chch",txtchallanno.Text),
                //new SqlParameter("@ConvertedToFileNo_chch",txtfilenoch.Text),
                //new SqlParameter("@ConvertedToDPRNo_chch",txtmembershipnoch.Text),
                //new SqlParameter("@UserID",Models.clsUser.ID)
                //};
                //int rslt = cls_dl_FinanceDashBoard.AccountStatement_RecePlanAdjust(prm);
                //if (rslt > 0)
                //{
                //    MessageBox.Show("Successful.");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnfindtrxiddetail_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] prm =
                {
                  new SqlParameter("@Task","InstlmntToSurFind"),
                  new SqlParameter("@TRXID",txttrxid.Text),
                  new SqlParameter("@UserID",Models.clsUser.ID)
                };
                dst1 = cls_dl_FinanceDashBoard.InstallmentSummary_Reader(prm);
                if (dst1.Tables.Count > 0)
                {
                    if (dst1.Tables[0].Rows.Count > 0)
                    {
                        lblfiletrxiddetail.Text = dst1.Tables[0].Rows[0]["FileNo"].ToString();
                        lblmsnotrxiddetail.Text = dst1.Tables[0].Rows[0]["MsNo"].ToString();
                        lbltotalamounttrxiddetail.Text = dst1.Tables[0].Rows[0]["Amount"].ToString();
                        lblddnotrxiddetail.Text = dst1.Tables[0].Rows[0]["DDNo"].ToString();
                        txtfileno.Text = dst1.Tables[0].Rows[0]["FileNo"].ToString();
                        txtmembershipno.Text = dst1.Tables[0].Rows[0]["MsNo"].ToString();
                        txtadjustedamounttrxiddetail.Text = dst1.Tables[0].Rows[0]["Amount"].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rdbPartialtrxiddeail_CheckStateChanged(object sender, EventArgs e)
        {
            if (rdbPartialtrxiddeail.CheckState == CheckState.Checked)
            {
                txtadjustedamounttrxiddetail.Text = "";
            }
            else
            {
                txtadjustedamounttrxiddetail.Text = dst1.Tables[0].Rows[0]["Amount"].ToString();
            }
        }

        private void btnfindsts_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] prm =
                {
                  new SqlParameter("@Task","Sur_To_Sur_Find"),
                  new SqlParameter("@ChallanNo",txtchallanno.Text)
                };
                dst2 = cls_dl_FinanceDashBoard.InstallmentSummary_Reader(prm);
                if (dst2.Tables.Count > 0)
                {
                    if (dst2.Tables[0].Rows.Count > 0)
                    {
                        lblfilests.Text = dst2.Tables[0].Rows[0]["FileNo"].ToString();
                        lblmsnosts.Text = dst2.Tables[0].Rows[0]["MsNo"].ToString();
                        lblamountsts.Text = dst2.Tables[0].Rows[0]["TotalAmount"].ToString();
                        lblchallannosts.Text = dst2.Tables[0].Rows[0]["ChalanNo"].ToString();
                        //txtfilenoch.Text = dst2.Tables[0].Rows[0]["FileNo"].ToString();
                        //txtmembershipnoch.Text = dst2.Tables[0].Rows[0]["MsNo"].ToString();
                        txtamountsts.Text = dst2.Tables[0].Rows[0]["TotalAmount"].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rdbpartialsts_CheckStateChanged(object sender, EventArgs e)
        {
            if (rdbpartialsts.IsChecked)
            {
                txtamountsts.Text = "";
            }
            else
            {
                txtamountsts.Text = dst2.Tables[0].Rows[0]["TotalAmount"].ToString();
            }
        }

        private void btnfindsti_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] prm =
                {
                  new SqlParameter("@Task","Sur_To_Instl_Find"),
                  new SqlParameter("@ChallanNo",txtchlnsurtoistl.Text)
                };
                dst2 = cls_dl_FinanceDashBoard.InstallmentSummary_Reader(prm);
                if (dst2.Tables.Count > 0)
                {
                    if (dst2.Tables[0].Rows.Count > 0)
                    {
                        lblfilenosti.Text = dst2.Tables[0].Rows[0]["FileNo"].ToString();
                        lblmsnosti.Text = dst2.Tables[0].Rows[0]["MsNo"].ToString();
                        lbltotalamountsti.Text = dst2.Tables[0].Rows[0]["TotalAmount"].ToString();
                        lblchallannosti.Text = dst2.Tables[0].Rows[0]["ChalanNo"].ToString();
                        txtfilenosurtoistl.Text = dst2.Tables[0].Rows[0]["FileNo"].ToString();
                        txtmembershipsurtoistl.Text = dst2.Tables[0].Rows[0]["MsNo"].ToString();
                        txtadjustedamountsti.Text = dst2.Tables[0].Rows[0]["TotalAmount"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnVerification_Click(object sender, EventArgs e)
        {
            frmAddjustment_Process frm = new frmAddjustment_Process();
            frm.Show();
        }

        private void btnuploaddocumentssi_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter =
                @"Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files (.)|*.*";
            openFileDialog1.Title = "Select Photos";

            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                ///////////   Declare Table
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

                grdsi.TableElement.RowHeight = 50;
                grdsi.Columns["Image"].ImageLayout = ImageLayout.Stretch;
                grdsi.DataSource = dt.DefaultView;


            }
        }

        private void btnuploaddocumentsis_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter =
                @"Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files (.)|*.*";
            openFileDialog1.Title = "Select Photos";

            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                ///////////   Declare Table
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

                grdis.TableElement.RowHeight = 50;
                grdis.Columns["Image"].ImageLayout = ImageLayout.Stretch;
                grdis.DataSource = dt.DefaultView;

            }

          }

        private void btnuploaddocumentsss_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter =
                @"Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files (.)|*.*";
            openFileDialog1.Title = "Select Photos";

            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                ///////////   Declare Table
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

                grdss.TableElement.RowHeight = 50;
                grdss.Columns["Image"].ImageLayout = ImageLayout.Stretch;
                grdss.DataSource = dt.DefaultView;

            }
        }
    }
}
