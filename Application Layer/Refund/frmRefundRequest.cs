using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Application_Layer.Membership.MSImage;
using PeshawarDHASW.Data_Layer.Installment;
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

namespace PeshawarDHASW.Application_Layer.Refund
{
    public partial class frmRefundRequest : Telerik.WinControls.UI.RadForm
    {
        public frmRefundRequest()
        {
            InitializeComponent();
        }
        private string ChallanNo { get; set; }
        private int ChallanID { get; set; }
        private int NDCNo { get; set; }
        /// <summary>
        /// Surcharge Refund or Transfer to Installment
        /// If Surcharge value is negative than Surcharge Refund will Process
        /// </summary>
        /// <param name="FileNo"></param>

        #region Code for Surcharge Refund Procedure
        private void Select_CurrentOwner_Info_Against_FileNo_(string FileNo)
        {
            // bool blvr = false;
            try
            {

                SqlParameter[] prm =
                {
                new SqlParameter("@Task","DueInformationforRefund"),//Select_CurrentOwner_Info_Against_FileNo_Single
                new SqlParameter("@FileNo",FileNo)
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_Refund", prm);

                SqlParameter[] prmChallan =
               {
                new SqlParameter("@Task","LastPaidSurchargeChallanNo"),//Select_CurrentOwner_Info_Against_FileNo_Single
                new SqlParameter("@FileNo",FileNo)
                };
                string ChallanNo = Helper.SQLHelper.ExecuteScalar(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_Refund", prmChallan).ToString();
                lblChallanNo.Text = ChallanNo;
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Columns.Count > 5) // If the Dues are Remaning
                    {

                        #region Calculation of Dues and Make Report
                        double receamount = double.Parse(ds.Tables[0].Rows[0]["PaidAmount"].ToString());
                        double dueamount = double.Parse(ds.Tables[0].Rows[0]["DueAmount"].ToString());
                        double recSurcharge = double.Parse(ds.Tables[0].Rows[0]["PaidSurcharge"].ToString());
                        double waveOffSurcharge = double.Parse(ds.Tables[0].Rows[0]["SurchargeWaveOff"].ToString());
                        double dueSurcharge = double.Parse(ds.Tables[0].Rows[0]["DueSurcharge"].ToString());
                        double remainInstAmount = double.Parse(ds.Tables[0].Rows[0]["RemainingInstAmount"].ToString());
                        double remainSurcharge = double.Parse(ds.Tables[0].Rows[0]["RemainingSurcharge"].ToString());
                        double TotalDueRemaining = double.Parse(ds.Tables[0].Rows[0]["TotalDueRemaining"].ToString());

                        DataTable dtb = new DataTable();
                        if (dtb.Rows.Count > 0)
                        {
                            dtb.Rows.Clear();
                        }
                        dtb = Installment_Surcharge_Detail_For_Report_Table(dueamount, receamount, remainInstAmount,
                            dueSurcharge, recSurcharge, waveOffSurcharge, remainSurcharge, TotalDueRemaining, FileNo);

                        // }
                        #endregion

                        #region If Dues are Remaining then Retrieve the Current Owner Data 
                        SqlParameter[] prmt =
                        {
                            new SqlParameter("@Task","Current_OwnerAgainstFile_For_Info"),
                            new SqlParameter("@FileNo",FileNo)
                        };
                        DataSet datset = cls_dl_NDC.NdcRetrival(prmt);
                        if (datset.Tables.Count > 0)
                        {
                            gdvOwnerInfo.DataSource = datset.Tables[0].DefaultView;

                            //if (datset.Tables[1].Rows.Count > 0 && datset.Tables[0].Rows.Count > 0)
                            //{
                            //    datset.Tables[0].Merge(datset.Tables[1]);
                            //}
                        }
                        #endregion
                    }

                    else
                    {
                        MessageBox.Show("There is no record for this FileNo. Please check another.");
                    }
                }

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Select_CurrentOwner_Info_Against_FileNo.", ex, "frmNDCCreate");
                frmobj.ShowDialog();
            }


        }
        private DataTable Installment_Surcharge_Detail_For_Report_Table(double get_dueamount, double get_receamount, double get_remainInstAmount,
           double get_dueSurcharge, double get_recSurcharge, double get_waveoffSurcharge, double get_remainSurcharge, double get_TotalDueRemaining, string fileno)
        {
            DataTable InstSurc_Tbl = new DataTable();
            try
            {

                #region Insertion in DataTable

                lblDueAmount.Text = String.Format("{0:n0}", get_dueamount);
                lblReceAmount.Text = String.Format("{0:n0}", get_receamount);
                lblReInstAmount.Text = String.Format("{0:n0}", get_remainInstAmount);
                lblDueSurcharge.Text = String.Format("{0:n0}", get_dueSurcharge);
                lblReceSurcharge.Text = String.Format("{0:n0}", get_recSurcharge);// + get_waveoffSurcharge.ToString();
                lblWavieroffSurcharge.Text = String.Format("{0:n0}", get_waveoffSurcharge);
                //instsur_row["WaveOffSurcharge"] = get_waveoffSurcharge;
                lblRemaingSur.Text = String.Format("{0:n0}", get_remainSurcharge);
                lblTotalDueRemaining.Text = String.Format("{0:n0}", get_TotalDueRemaining);
                #endregion
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on File_Seller_Buyer_Table.", ex, "frmNDCCreate");
                frmobj.ShowDialog();
            }
            return InstSurc_Tbl;
        }

        private void btnVerifyFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFileNo.Text))
            {
                MessageBox.Show(this, "Please enter FileNo here..", "Field is Not Fill.");
                txtFileNo.Focus();
                return;
            }
            Select_CurrentOwner_Info_Against_FileNo_(txtFileNo.Text);
            dtpRequestType.SelectedIndex = 0;
            dpPaymentType.SelectedIndex = 0;
            // txtrefundamount.Text = String.Format("{0:n0}", lblRemaingSur.Text); 
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

        private void btnRequestforRefund_Click(object sender, EventArgs e)
        {
            try
            {
                btnRequestforRefund.Enabled = false;
                decimal RemaingSurcharge = 0;
                bool FlagRemaingSurcharge = decimal.TryParse(lblRemaingSur.Text.Replace(",", ""), out RemaingSurcharge);
                if (RemaingSurcharge > -1)
                {
                    MessageBox.Show("Refund Request Cannot Proceed Due to Surcharge Remaining.");
                    return;
                }
                else
                {


                    decimal AbsRemaingSurcharge = Math.Abs(RemaingSurcharge);
                    decimal RefundAmounttoPerson = 0;
                    bool RefundCheck = decimal.TryParse(txtrefundamount.Text.Replace(",", ""), out RefundAmounttoPerson);
                    if (rdPartial.Checked == true)
                    {
                        if (RefundAmounttoPerson < AbsRemaingSurcharge && RefundAmounttoPerson > 0)
                        {
                            decimal remaing = RemaingSurcharge + RefundAmounttoPerson;
                            lblRemaingBalance.Text = remaing.ToString();

                        }
                        else
                        {
                            MessageBox.Show("Amount Must Less the Remaing Surcharge Due to Selected Partial.");
                            return;
                        }
                    }
                    if (rdfull.Checked == true)
                    {
                        if (RefundAmounttoPerson == AbsRemaingSurcharge && RefundAmounttoPerson > 0)
                        {
                            decimal remaing = RemaingSurcharge + RefundAmounttoPerson;
                            lblRemaingBalance.Text = remaing.ToString();
                            btnRequestforRefund.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Invalid Amount Must Equal to Remaing Surcharge.");
                            return;
                        }
                    }


                    if (ImageContainer.Count > 0)
                    {
                        int RefundAmount = 0;
                        bool RefundConvert = int.TryParse(txtrefundamount.Text.Replace(",", ""), out RefundAmount);
                        if (RefundAmount > 0)
                        {
                            SqlParameter[] prmChallan =
                                 {
                                    new SqlParameter("@Task","LastPaidSurchargeChallanNoAmount"),//Select_CurrentOwner_Info_Against_FileNo_Single
                                    new SqlParameter("@FileNo",txtFileNo.Text),
                                     new SqlParameter("@RefundAmount",txtrefundamount.Text)
                                    };
                            string ChallanNo = Helper.SQLHelper.ExecuteScalar(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_Refund", prmChallan).ToString();
                            lblChallanNo.Text = ChallanNo;

                            SqlParameter[] parameter = {
                                new SqlParameter("@Task","NewRefundofSurcharge"),
                                new SqlParameter("@ChequeNo",txtchequeno.Text),
                                new SqlParameter("@Amount_In_Word",clsPluginHelper.Convert_Number_To_Text(Math.Abs(RefundAmount),true)),
                                new SqlParameter("@Requestedby",clsUser.Name),
                                new SqlParameter("@Remarks",txtRemarks_New.Text),
                                new SqlParameter("@ChallanNo",lblChallanNo.Text),
                                new SqlParameter("@ChallanID",0),
                                new SqlParameter("@DateofRefund",dtpRefundDate.Value),
                                new SqlParameter("@FileNo",txtFileNo.Text),
                                //new SqlParameter("@DateofRequest",""),
                                new SqlParameter("@AdjustmentType","Surcharge Refund"),
                                new SqlParameter("@STATUS","Pending"),
                                new SqlParameter("@PaymentType",dpPaymentType.Text),
                                new SqlParameter("@NDCNo",0),
                                new SqlParameter("@TotalAmountTrx",RemaingSurcharge.ToString()),
                                new SqlParameter("@RefundAmount", Math.Abs(RefundAmount).ToString()),
                                new SqlParameter("@RemainingBalance",lblRemaingBalance.Text),
                             };
                            string RefundID = Helper.SQLHelper.ExecuteScalar(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_Refund", parameter).ToString();
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
                                        new SqlParameter("@RefundID", RefundID),
                                        new SqlParameter("@ImageFile", Image),
                                        new SqlParameter("@ImageName", row.ImageName),
                                        new SqlParameter("@Description", row.Description),
                                        new SqlParameter("@user_ID", clsUser.ID),
                                         };
                                    int result = Helper.SQLHelper.ExecuteNonQuery(
                                                            clsMostUseVars.VerifiedImageConnectionstring,
                                                            CommandType.StoredProcedure,
                                                            "usp_tbl_RefundImage",
                                                            parameters
                                                            );

                                }
                                ImageContainer.Clear();
                                ImageSource.DataSource = null;

                            }
                            catch (Exception rc)
                            {
                            }
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Refund Cannot be Process.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Documents are Attach. Please Attach the Documents");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Process is Intercepted by Incomplete Information \n " + ex.Message);
            }

        }

        private void dtpRequestType_Leave(object sender, EventArgs e)
        {
            //if (dtpRequestType.SelectedItem.Text == "Surcharge Adjust")
            //{
            //    dpPaymentType.SelectedIndex = 2;
            //}
            //else
            //{
            //    dpPaymentType.SelectedIndex = 0;
            //}
        }
        #endregion

        #region All Data of Refund Loading
        private void DataLoading()
        {
            try
            {
                SqlParameter[] parameter = {
                new SqlParameter("@Task","AllRefundRecordLoad")
                };
                DataSet DataRefund = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_Refund", parameter);
                grd_RefundBasket.DataSource = DataRefund.Tables[0].DefaultView;
                foreach (GridViewDataColumn column in grd_RefundBasket.Columns)
                {
                    column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
                }
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","GetPendingNDCForRefund")
                };
                DataSet dst = cls_dl_NDC.NdcRetrival(prm);
                grdNDCDeatail.DataSource = dst.Tables[0].DefaultView;


                foreach (GridViewDataColumn column in grdNDCDeatail.Columns)
                {
                    column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Data not exist.");
            }

        }
        #endregion

        #region Refreshing Data or Loading
        private void frmRefundRequest_Load(object sender, EventArgs e)
        {
            DataLoading();
            PerDeduction.Items.Add(new RadListDataItem(text: "0%", value: (decimal)0.0));
            PerDeduction.Items.Add(new RadListDataItem(text: "10%", value: (decimal)0.10m));
            PerDeduction.SelectedIndex = 1;
            dtpRefundNDCChallan.Value = DateTime.Now;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DataLoading();

          
        }
        #endregion

        /// <summary>
        /// Challan of NDC Refund Procedure
        /// 10% Deduct from Total Amount of Challan to Proceed for Refund
        /// </summary>

        #region Code for NDC Challan Refund
        private void btnFindChallanNo_Click(object sender, EventArgs e)
        {
            SqlParameter[] parameter_RefundDuplicate =
           {
                new SqlParameter("@Task","NDCChallanRefundDuplicatePreventation"),
                new SqlParameter("@ChallanNo",txtChallanNo.Text)
            };
            int RefundCount = int.Parse(SQLHelper.ExecuteScalar(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_Refund", parameter_RefundDuplicate).ToString());
            if (RefundCount > 0)
            {
                MessageBox.Show("All Refund Cannot Process for This TRID Againt");
            }

            else
            {
                SqlParameter[] ChallanExistParam = {
                    new SqlParameter("@Task","DuplicateRefundPrevent"),
                    new SqlParameter("@ChallanNo",txtChallanNo.Text)
            };
                int ChallanExist = int.Parse(SQLHelper.ExecuteScalar(SQLHelper.createConnection(), CommandType.StoredProcedure, "ch.RefundChallan ", ChallanExistParam).ToString());
                if (ChallanExist < 1)
                {
                    SqlParameter[] param = {
                    new SqlParameter("@Task","GetDataofChallan"),
                    new SqlParameter("@ChallanNo",txtChallanNo.Text)
                    };
                    DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "ch.RefundChallan ", param);
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            lblFileNo.Text = ds.Tables[0].Rows[0]["FileNo"].ToString();
                            lblCreateDate.Text = ds.Tables[0].Rows[0]["CreateDate"].ToString();
                            lblClearDate.Text = ds.Tables[0].Rows[0]["ClearDate"].ToString();
                            lblName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                            gdChallanInfo.DataSource = ds.Tables[1].DefaultView;

                            decimal DeductionPer = (decimal)PerDeduction.SelectedItem.Value;

                            object sumObject = 0;
                            sumObject = ds.Tables[1].Compute("Sum(Amount)", string.Empty);
                            decimal sumam = decimal.Parse(sumObject.ToString());
                            decimal deduct = decimal.Multiply(sumam, DeductionPer);
                            decimal Remaingamount = sumam - deduct;
                            txtNDCChallanRefundAmount.Text = String.Format("{0:n0}", Remaingamount);
                            dpTypeNDCChallanRefund.SelectedIndex = 0;
                            dpTypePaymentChallanRefund.SelectedIndex = 0;
                            btnChallanRefund.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Challan is not Allow for Refund.");
                            btnChallanRefund.Enabled = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Challan is Already Refund");
                }
            }
        }

        private void btnAttachAddNDC_Click(object sender, EventArgs e)
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
                    GRIDAttachNDC.TableElement.RowHeight = 50;
                    GRIDAttachNDC.Columns["MemberImage"].ImageLayout = ImageLayout.Stretch;
                    GRIDAttachNDC.DataSource = ImageContainer.DefaultIfEmpty();
                    //foreach (GridViewDataColumn column in GRIDAttachNDC.Columns)
                    //{
                    //    column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
                    //}
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnAttachNDC_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "btnRemove")
            {
                try
                {
                    ImageContainer.RemoveAt(e.RowIndex);
                    GRIDAttachNDC.TableElement.RowHeight = 50;
                    GRIDAttachNDC.Columns["MemberImage"].ImageLayout = ImageLayout.Stretch;
                    GRIDAttachNDC.DataSource = ImageContainer.DefaultIfEmpty();
                    if (ImageContainer.Count == 0)
                        GRIDAttachNDC.DataSource = null;

                    //foreach (GridViewDataColumn column in GRIDAttachNDC.Columns)
                    //{
                    //    column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
                    //}
                }
                catch (Exception)
                {
                    GRIDAttachNDC.DataSource = null;
                }
            }
        }

        private void btnChallanRefund_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblFlag.Text == "Challan")
                {
                    decimal scv = Convert.ToDecimal(txtNDCChallanRefundAmount.Text);
                    if (scv > 0)
                    {

                        SqlParameter param_out_ID = new SqlParameter()
                        {
                            ParameterName = "@OutRFID",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Output
                        };


                        SqlParameter[] parameter = {
                      new SqlParameter("@Task","NewRefundEntry"),
                      new SqlParameter("@RefundAmount",Math.Abs(scv)),
                      //new SqlParameter("@ChequeNo",txtChallanChequeNo.Text == ""?null:txtChallanChequeNo.Text),
                      new SqlParameter("@Amount_In_Word",clsPluginHelper.Convert_Number_To_Text(Convert.ToInt32(scv),true)),
                      new SqlParameter("@Requestedby",clsUser.Name),
                      new SqlParameter("@Remarks",txtRefundChallanRemarks.Text),
                      new SqlParameter("@ChallanNo",lblChallanNo_S.Text),
                      new SqlParameter("@ChallanID",ChallanID),
                      new SqlParameter("@DateofRefund",dtpRefundNDCChallan.Value),
                      new SqlParameter("@FileNo",lblFileNo.Text),
                      new SqlParameter("@AdjustmentType","Challan Refund"),
                      new SqlParameter("@STATUS","Pending"),
                      new SqlParameter("@PaymentType",dpTypePaymentChallanRefund.Text),
                      param_out_ID,
                      new SqlParameter("@NDCNo","0")
                     };
                        SqlCommand rest;
                        rest = cls_dl_NDC.Refun_outparameter(parameter);
                        if (rest.Parameters.Count > 0)
                        {
                            #region Challan Detail Saving
                            int RFID = int.Parse(rest.Parameters["@OutRFID"].Value.ToString());
                            for (int i = 0; i < gdChallanInfo.RowCount; i++)
                            {
                                string prt = gdChallanInfo.Rows[i].Cells["Particular"].Value.ToString();
                                decimal amnt = Convert.ToDecimal(gdChallanInfo.Rows[i].Cells["Amount"].Value.ToString());
                                decimal DeductionPer = (decimal)PerDeduction.SelectedItem.Value;

                                decimal RefundedAmount = (amnt * (1.0m - DeductionPer));
                                decimal DHAServiceCharges = (amnt * DeductionPer);
                                SqlParameter[] prm =
                                {
                                new SqlParameter("@Task","NewRefundDetailEntry"),
                                new SqlParameter("@ChallanNo",lblChallanNo_S.Text),
                                new SqlParameter("@ChallanID",ChallanID),
                                new SqlParameter("@RefundID",RFID),
                                new SqlParameter("@Amount",amnt),
                                new SqlParameter("@RefundAmount",RefundedAmount),
                                new SqlParameter("@DHAServiceCharges",DHAServiceCharges),
                                new SqlParameter("@Particular",prt)
                                };
                                int reslt = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(),
                                                                                CommandType.StoredProcedure,
                                                                                "App.usp_tbl_Refund",
                                                                                prm);

                            }


                            #endregion

                            try
                            {

                                #region  Images saving 
                                if (GRIDAttachNDC.RowCount > 0)
                                {
                                    for (int i = 0; i < GRIDAttachNDC.RowCount; i++)
                                    {
                                        Image img = (Image)GRIDAttachNDC.Rows[i].Cells["MemberImage"].Value;
                                        MemoryStream ms = new MemoryStream();
                                        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                        Byte[] Image = ms.ToArray();

                                        SqlParameter[] parameters =
                                        {
                                     new SqlParameter("@Task", "InsertChallanRefund"),
                                     new SqlParameter("@RefundID", RFID), //0),
                                     new SqlParameter("@ChallanNo",lbl_Challan_OR_NDCNo.Text),
                                     new SqlParameter("@ImageFile", Image),
                                     new SqlParameter("@ImageName", GRIDAttachNDC.Rows[i].Cells["ImageName"].Value),
                                     new SqlParameter("@Description", GRIDAttachNDC.Rows[i].Cells["Description"].Value),
                                     new SqlParameter("@user_ID", clsUser.ID),
                                    };
                                        int result = Helper.SQLHelper.ExecuteNonQuery(
                                                                clsMostUseVars.VerifiedImageConnectionstring,
                                                                CommandType.StoredProcedure,
                                                                "usp_tbl_RefundImage",
                                                                parameters
                                                                );

                                    }
                                }





                                GRIDAttachNDC.DataSource = null;
                                DataLoading();
                                //this.Close();
                                Clear();
                                MessageBox.Show("Successful.");
                            }
                            catch (Exception rc)
                            {
                            }
                            #endregion
                        }

                    }
                }

                if (lblFlag.Text == "NDC")
                {
                    if (chkaffidavit.Checked && chkchallan.Checked && chkdbapplicationcopy.Checked && chkndccancelcopy.Checked && chkndcrfundrpt.Checked)
                    {
                        #region code
                        decimal scv = Convert.ToDecimal(txtNDCChallanRefundAmount.Text);
                        if (scv > 0)
                        {

                            SqlParameter param_out_ID = new SqlParameter()
                            {
                                ParameterName = "@OutRFID",
                                SqlDbType = SqlDbType.Int,
                                Direction = ParameterDirection.Output
                            };


                            SqlParameter[] parameter = {
                      new SqlParameter("@Task","NewRefundEntry"),
                      new SqlParameter("@RefundAmount",Math.Abs(scv)),
                      new SqlParameter("@NDCNo",lbl_Challan_OR_NDCNo.Text),
                      //new SqlParameter("@ChequeNo",txtChallanChequeNo.Text == ""?null:txtChallanChequeNo.Text),
                      new SqlParameter("@Amount_In_Word",clsPluginHelper.Convert_Number_To_Text(Convert.ToInt32(scv),true)),
                      new SqlParameter("@Requestedby",clsUser.Name),
                      new SqlParameter("@Remarks",txtRefundChallanRemarks.Text),
                      new SqlParameter("@ChallanNo",ChallanNo),
                      new SqlParameter("@ChallanID",ChallanID),
                      new SqlParameter("@DateofRefund",dtpRefundNDCChallan.Value),
                      new SqlParameter("@FileNo",lblFileNo.Text),
                      new SqlParameter("@AdjustmentType","Challan Refund"),
                      new SqlParameter("@STATUS","Pending"),
                      new SqlParameter("@PaymentType",dpTypePaymentChallanRefund.Text),
                      param_out_ID,
                     };
                            SqlCommand rest;
                            rest = cls_dl_NDC.Refun_outparameter(parameter);
                            if (rest.Parameters.Count > 0)
                            {
                                #region Challan Detail Saving
                                int RFID = int.Parse(rest.Parameters["@OutRFID"].Value.ToString());
                                for (int i = 0; i < gdChallanInfo.RowCount; i++)
                                {
                                    string prt = gdChallanInfo.Rows[i].Cells["Particular"].Value.ToString();
                                    decimal amnt = Convert.ToDecimal(gdChallanInfo.Rows[i].Cells["Amount"].Value.ToString());
                                    //decimal RefundedAmount = (amnt * 90) / 100;
                                    //decimal DHAServiceCharges = (amnt * 10) / 100;
                                    decimal DeductionPer = (decimal)PerDeduction.SelectedItem.Value;
                                    decimal RefundedAmount = (amnt * (1.0m - DeductionPer));
                                    decimal DHAServiceCharges = (amnt * DeductionPer);
                                    SqlParameter[] prm =
                                    {
                                new SqlParameter("@Task","NewRefundDetailEntry"),
                                new SqlParameter("@ChallanNo",ChallanNo),
                                new SqlParameter("@ChallanID",ChallanID),
                                new SqlParameter("@RefundID",RFID),
                                new SqlParameter("@Amount",amnt),
                                new SqlParameter("@RefundAmount",RefundedAmount),
                                new SqlParameter("@DHAServiceCharges",DHAServiceCharges),
                                new SqlParameter("@Particular",prt)
                                };
                                    int reslt = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(),
                                                                                    CommandType.StoredProcedure,
                                                                                    "App.usp_tbl_Refund",
                                                                                    prm);

                                }


                                #endregion

                                try
                                {

                                    #region  Images saving 
                                    if (GRIDAttachNDC.RowCount > 0)
                                    {
                                        for (int i = 0; i < GRIDAttachNDC.RowCount; i++)
                                        {
                                            Image img = (Image)GRIDAttachNDC.Rows[i].Cells["MemberImage"].Value;
                                            MemoryStream ms = new MemoryStream();
                                            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                            Byte[] Image = ms.ToArray();

                                            SqlParameter[] parameters =
                                            {
                                     new SqlParameter("@Task", "InsertNDCRefund"),
                                     new SqlParameter("@RefundID", RFID), //0),
                                     new SqlParameter("@NDCNo",NDCNo),
                                     new SqlParameter("@ImageFile", Image),
                                     new SqlParameter("@ImageName", GRIDAttachNDC.Rows[i].Cells["ImageName"].Value),
                                     new SqlParameter("@Description", GRIDAttachNDC.Rows[i].Cells["Description"].Value),
                                     new SqlParameter("@user_ID", clsUser.ID),
                                    };
                                            int result = Helper.SQLHelper.ExecuteNonQuery(
                                                                    clsMostUseVars.VerifiedImageConnectionstring,
                                                                    CommandType.StoredProcedure,
                                                                    "usp_tbl_RefundImage",
                                                                    parameters
                                                                    );

                                        }
                                    }


                                    #endregion
                                    #region Update the NDC Status
                                    SqlParameter[] prtm =
                                    {
                                    new SqlParameter("@Task","UpdateNDC_Sts"),
                                    new SqlParameter("@NDCNo",NDCNo),
                                    new SqlParameter("@StatusofNDC","RefundPending")
                                    };
                                    int rsl = cls_dl_NDC.NdcNonQuery(prtm);

                                    GRIDAttachNDC.DataSource = null;
                                    DataLoading();
                                    //this.Close();
                                    Clear();
                                    MessageBox.Show("Successful.");
                                }
                                catch (Exception rc)
                                {
                                }
                                #endregion
                            }

                        }
                        //this.Close();

                        //DataLoading();
                        #endregion
                    }
                    else
                    {
                        MessageBox.Show("Please checked all the checkboxes.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Process is Intercepted by Incomplete Information \n " + ex.Message);
            }
        }
        private void Clear()
        {
            lblFileNo.Text = "-";
            lblName.Text = "-";
            lblCreateDate.Text = "-";
            lblClearDate.Text = "-";
            gdChallanInfo.DataSource = null;
            txtChallanChequeNo.Text = "";
            txtNDCChallanRefundAmount.Text = "";
            txtChallanRefundVoucherNo.Text = "";
            txtRefundChallanRemarks.Text = "";
            lblTotalAmount.Text = "-";
            lbl10Per.Text = "-";
            chkaffidavit.CheckState = CheckState.Unchecked;
            chkchallan.CheckState = CheckState.Unchecked;
            chkdbapplicationcopy.CheckState = CheckState.Unchecked;
            chkndccancelcopy.CheckState = CheckState.Unchecked;
            chkndcrfundrpt.CheckState = CheckState.Unchecked;
        }
        private void grd_RefundBasket_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "ImageView")
            {
                try
                {
                    int RefundID = int.Parse(e.Row.Cells["RefundID"].Value.ToString()); // ReceID
                    SqlParameter[] param =
                               {
                    new SqlParameter("@Task","Select"),//usp_tbl_DDTransferImages
                    new SqlParameter("@RefundID",RefundID)
                };
                    DataSet ds = SQLHelper.ExecuteDataset(
                                                        clsMostUseVars.VerifiedImageConnectionstring,
                                                        CommandType.StoredProcedure,
                                                        "usp_tbl_RefundImage",
                                                        param
                                                        );
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
                catch (Exception ex)
                {
                }
            }
        }

        private void txtrefundamount_Leave(object sender, EventArgs e)
        {
            btnRequestforRefund.Enabled = false;
            decimal RemaingSurcharge = 0;
            bool FlagRemaingSurcharge = decimal.TryParse(lblRemaingSur.Text.Replace(",", ""), out RemaingSurcharge);
            if (RemaingSurcharge > -1)
            {
                MessageBox.Show("Refund Request Cannot Proceed Due to Surcharge Remaining.");
                return;
            }
            else
            {

                decimal AbsRemaingSurcharge = Math.Abs(RemaingSurcharge);
                decimal RefundAmounttoPerson = 0;
                bool RefundCheck = decimal.TryParse(txtrefundamount.Text.Replace(",", ""), out RefundAmounttoPerson);
                if (rdPartial.Checked == true)
                {
                    if (RefundAmounttoPerson < AbsRemaingSurcharge && RefundAmounttoPerson > 0)
                    {
                        decimal remaing = RemaingSurcharge + RefundAmounttoPerson;
                        lblRemaingBalance.Text = remaing.ToString();
                        btnRequestforRefund.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Amount Must Less the Remaing Surcharge Due to Selected Partial.");
                        btnRequestforRefund.Enabled = false;
                    }
                }
                if (rdfull.Checked == true)
                {
                    if (RefundAmounttoPerson == AbsRemaingSurcharge && RefundAmounttoPerson > 0)
                    {
                        decimal remaing = RemaingSurcharge + RefundAmounttoPerson;
                        lblRemaingBalance.Text = remaing.ToString();
                        btnRequestforRefund.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Invalid Amount Must Equal to Remaing Surcharge.");
                        btnRequestforRefund.Enabled = false;
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// DD Refund Procedure
        /// </summary>

        #region Code for Refund of DD Procedure
        private int Old_Filekey { get; set; }
        private int Old_MemberID { get; set; }
        private void btn_FindRecord_Click(object sender, EventArgs e)
        {
            SqlParameter[] parameter_RefundDuplicate =
             {
                new SqlParameter("@Task","DDRefundDuplicatePreventation"),
                new SqlParameter("@Rece_ID",txtTrxID.Text)
            };
            int RefundCount = int.Parse(SQLHelper.ExecuteScalar(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_Refund", parameter_RefundDuplicate).ToString());
            if (RefundCount > 0)
            {
                MessageBox.Show("Refund Can't Process for This TRXID Again.");
            }
            else
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
                        DDtxtRefundAmount.Text = dst.Tables[0].Rows[0]["Amount"].ToString();
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
        }

        private void btnDDRefundImage_Click(object sender, EventArgs e)
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
                    GRID_DDRefundImage.TableElement.RowHeight = 50;
                    GRID_DDRefundImage.Columns["MemberImage"].ImageLayout = ImageLayout.Stretch;
                    GRID_DDRefundImage.DataSource = ImageContainer.DefaultIfEmpty();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void GRID_DDRefundImage_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "ImageView")
            {
                try
                {
                    int RefundID = int.Parse(e.Row.Cells["RefundID"].Value.ToString()); // ReceID
                    SqlParameter[] param =
                               {
                    new SqlParameter("@Task","Select"),//usp_tbl_DDTransferImages
                    new SqlParameter("@RefundID",RefundID)
                };
                    DataSet ds = SQLHelper.ExecuteDataset(
                                                        clsMostUseVars.VerifiedImageConnectionstring,
                                                        CommandType.StoredProcedure,
                                                        "usp_tbl_RefundImage",
                                                        param
                                                        );
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
                catch (Exception ex)
                {
                }
            }
        }

        private void btnDDRefundRequest_Click(object sender, EventArgs e)
        {
            try
            {
                decimal DDAmount = 0;
                bool FlagremaingSurcharge = decimal.TryParse(txtAmount_Old.Text.Replace(",", ""), out DDAmount);
                decimal DDRefund = 0;
                bool DDRefundFlage = decimal.TryParse(DDtxtRefundAmount.Text, out DDRefund);
                if (DDRefund < 1)
                {
                    MessageBox.Show("Invalid Amount in DD Refund Field.");
                    btnDDRefundRequest.Enabled = false;
                }
                else if (DDRefund > DDAmount)
                {
                    MessageBox.Show("Refund Amount Must be Less or Equal to Demand Draft Amount.");
                    btnDDRefundRequest.Enabled = false;
                }
                else
                {
                    if (ImageContainer.Count > 0)
                    {
                        decimal RefundAmount = 0;
                        bool RefundConvert = decimal.TryParse(DDtxtRefundAmount.Text.Replace(",", ""), out RefundAmount);

                        int totalRefund_int = int.Parse(RefundAmount.ToString("0.##"));
                        SqlParameter[] parameter = {
                            new SqlParameter("@Task","NewRefundofInstallment"),
                            new SqlParameter("@RefundAmount",Math.Abs(RefundAmount).ToString("0.##")),
                            new SqlParameter("@Amount_In_Word",clsPluginHelper.Convert_Number_To_Text((int)RefundAmount,true)),
                            new SqlParameter("@Requestedby",clsUser.Name),
                            new SqlParameter("@Remarks",txtDDRefundRemarks.Text),
                            new SqlParameter("@ChallanNo",txtDDno_old.Text),
                            new SqlParameter("@DateofRefund",DDRefundDate.Value),
                            new SqlParameter("@FileNo",txtFileNo_Old.Text),
                            //new SqlParameter("@DateofRequest",""),
                            new SqlParameter("@AdjustmentType","DD Refunded"),
                            new SqlParameter("@STATUS","Pending"),
                            new SqlParameter("@PaymentType","Demand Draft"),
                            new SqlParameter("@Rece_ID",txtTrxID.Text),
                            new SqlParameter("@NDCNo",0)
                         };
                        string RefundID = Helper.SQLHelper.ExecuteScalar(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_Refund", parameter).ToString();
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
                                new SqlParameter("@RefundID", RefundID),
                                new SqlParameter("@ImageFile", Image),
                                new SqlParameter("@ImageName", row.ImageName),
                                new SqlParameter("@Description", row.Description),
                                new SqlParameter("@user_ID", clsUser.ID),
                            };
                                int result = Helper.SQLHelper.ExecuteNonQuery(
                                                        clsMostUseVars.VerifiedImageConnectionstring,
                                                        CommandType.StoredProcedure,
                                                        "usp_tbl_RefundImage",
                                                        parameters
                                                        );

                            }
                            ImageContainer.Clear();
                            //GRID_DDRefundImage.DataSource = null;
                            this.Close();
                        }
                        catch (Exception rc)
                        {
                            // MessageBox.Show(rc.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Documents are Attach. Please Attach the Documents");
                    }

                }
                //  DataLoading();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Process is Intercepted by Incomplete Information \n " + ex.Message);
            }

        }
        #endregion

        private void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(grd_RefundBasket);
        }

        private void grdNDCDeatail_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
           
            try
            {
                if (e.Column.Name == "btnRefund")
                {
                    NDCNo = Convert.ToInt32(e.Row.Cells["NDCNo"].Value.ToString());
                    string ChallanNo = e.Row.Cells["ChallanNo"].Value.ToString();
                    lbl_Challan_OR_NDCNo.Text = NDCNo == 0 ? ChallanNo : NDCNo.ToString();


                    if (NDCNo != 0)
                    {

                        SqlParameter[] prmtt = { new SqlParameter("@Task", "NDC_alreadyInUse"), new SqlParameter("@NDCNo", NDCNo) };
                        int ExistNdcNo = int.Parse(Helper.SQLHelper.ExecuteScalar(clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "App.usp_tbl_Refund", prmtt).ToString());

                        if (ExistNdcNo > 0)
                        {
                            MessageBox.Show("NDC No:" + NDCNo.ToString() + " Request is already in process.");
                        }
                        //Challan_OR_NDC_already
                        else
                        {
                            lblFlag.Text = "NDC";
                            
                            string fileno = e.Row.Cells["FilePlotNo"].Value.ToString();
                            SqlParameter[] prmt =
                            {
                            new SqlParameter("@Task","GetDataForCal10Per"),
                            new SqlParameter("@FileNo",fileno),
                            new SqlParameter("@NDCNo",NDCNo)
                            };
                            DataSet dst = cls_dl_NDC.NdcRetrival(prmt);

                            lblFileNo.Text = dst.Tables[0].Rows[0]["FileNo"].ToString();
                            lblCreateDate.Text = dst.Tables[0].Rows[0]["CreateDate"].ToString();
                            lblClearDate.Text = dst.Tables[0].Rows[0]["ClearDate"].ToString();
                            lblName.Text = dst.Tables[0].Rows[0]["Name"].ToString();
                            ChallanNo = dst.Tables[0].Rows[0]["ChalanNo"].ToString();
                            lblChallanNo_S.Text = ChallanNo;
                            ChallanID = Convert.ToInt32(dst.Tables[0].Rows[0]["ChallanID"].ToString());
                            gdChallanInfo.DataSource = dst.Tables[0].DefaultView;
                            decimal amnt = 0;
                            for (int i = 0; i < gdChallanInfo.RowCount; i++)
                            {
                                decimal amn = Convert.ToDecimal(gdChallanInfo.Rows[i].Cells["Amount"].Value.ToString());
                                amnt = amn + amnt;
                            }
                            lblTotalAmount.Text = amnt.ToString();
                            lbl10Per.Text = Convert.ToString((amnt * 10) / 100);
                            txtNDCChallanRefundAmount.Text = Convert.ToString(amnt - ((amnt * 10) / 100));
                        }
                    }
                   else if (ChallanNo != "0")
                    {
                        SqlParameter[] prmtt = { new SqlParameter("@Task", "Challan_alreadyInUse"), new SqlParameter("@ChallanNo", ChallanNo) };
                        int ExistChallanNo = int.Parse(Helper.SQLHelper.ExecuteScalar(clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "App.usp_tbl_Refund", prmtt).ToString());

                        if (ExistChallanNo > 0)
                        {
                            MessageBox.Show("Challan No:" + ChallanNo + " Request is already in process.");
                        }
                        else
                        {

                            lblFlag.Text = "Challan";
                            string fileno = e.Row.Cells["FilePlotNo"].Value.ToString();
                            SqlParameter[] prmt =
                            {
                                new SqlParameter("@Task","ChallanRefundofNoNDC"),
                                new SqlParameter("@FileNo",fileno),
                                new SqlParameter("@ChallanNo",ChallanNo)
                                };
                            DataSet dst = Helper.SQLHelper.ExecuteDataset(
                                                        clsMostUseVars.Connectionstring,
                                                        CommandType.StoredProcedure,
                                                        "App.usp_tbl_Refund",
                                                        prmt
                                                        );

                            lblFileNo.Text = dst.Tables[0].Rows[0]["FileNo"].ToString();
                            lblCreateDate.Text = dst.Tables[0].Rows[0]["CreateDate"].ToString();
                            lblClearDate.Text = dst.Tables[0].Rows[0]["ClearDate"].ToString();
                            lblName.Text = dst.Tables[0].Rows[0]["Name"].ToString();
                            ChallanNo = dst.Tables[0].Rows[0]["ChalanNo"].ToString();
                            lblChallanNo_S.Text = ChallanNo;
                            ChallanID = Convert.ToInt32(dst.Tables[0].Rows[0]["ChallanID"].ToString());
                            gdChallanInfo.DataSource = dst.Tables[0].DefaultView;
                            decimal amnt = 0;
                            for (int i = 0; i < gdChallanInfo.RowCount; i++)
                            {
                                decimal amn = Convert.ToDecimal(gdChallanInfo.Rows[i].Cells["Amount"].Value.ToString());
                                amnt = amn + amnt;
                            }
                            lblTotalAmount.Text = amnt.ToString();
                            lbl10Per.Text = Convert.ToString((amnt * 10) / 100);
                            txtNDCChallanRefundAmount.Text = Convert.ToString(amnt - ((amnt * 10) / 100));
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Selection.");
                    }
                }
                else if (e.Column.Name == "btnImage")
                {
                    try
                    {



                        ImageContainer.Clear();
                        int result = 0;
                        NDCNo = int.Parse(e.Row.Cells["NDCNo"].Value.ToString());
                        string fileno = e.Row.Cells["FilePlotNo"].Value.ToString();
                        string ChallanNo = e.Row.Cells["ChallanNo"].Value.ToString();
                        lbl_Challan_OR_NDCNo.Text = NDCNo == 0 ? ChallanNo : NDCNo.ToString();
                        if (NDCNo != 0)
                        {
                            lblFlag.Text = "NDC";
                        }
                        else
                        {
                            lblFlag.Text = "Challan";
                        }

                        clsMemberImage obj = new clsMemberImage();
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
                            dt.Columns.Add("MemberImage", typeof(Image));
                            dt.Columns.Add("ImageName", typeof(string));
                            dt.Columns.Add("Description", typeof(string));


                            string[] files = openFileDialog1.FileNames;
                            int i = 1;
                            foreach (var pngFile in files)
                            {
                                try
                                {
                                    DataRow _ravi = dt.NewRow();

                                    _ravi["MemberImage"] = Image.FromFile(pngFile);
                                    _ravi["ImageName"] = DateTime.Now.ToString("yyyyMMdd") + "_" + i;
                                    _ravi["Description"] = "Attachments of NDC refund by Finance Branch.";
                                    dt.Rows.Add(_ravi);
                                    i = i + 1;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("This is not an image file");
                                }
                            }

                            GRIDAttachNDC.TableElement.RowHeight = 50;
                            GRIDAttachNDC.Columns["MemberImage"].ImageLayout = ImageLayout.Stretch;
                            GRIDAttachNDC.DataSource = dt.DefaultView;
                            //foreach (GridViewDataColumn column in GRIDAttachNDC.Columns)
                            //{
                            //    column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
                            //}
                            //int i = 1;
                            //foreach (var pngFile in files)
                            //{
                            //    try
                            //    {
                            //        Image objectt = new Bitmap(pngFile);
                            //        MemoryStream ms = new MemoryStream();
                            //        objectt.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            //        Byte[] Imgbyte = ms.ToArray();
                            //        /// Insert NDC Refund Images
                            //        SqlParameter[] prmt =
                            //        {
                            //            new SqlParameter("@Task","InsertNDCRefund"),
                            //            new SqlParameter("@ImageName",DateTime.Now.ToString("yyyyMMdd") + "_" + i),
                            //            new SqlParameter("@Description","Attachments of NDC refund by Finance Branch."),
                            //            new SqlParameter("@ImageFile",Imgbyte),
                            //            new SqlParameter("@NDCNo",NDCNo),
                            //            new SqlParameter("@user_ID",Models.clsUser.ID)
                            //        };
                            //        i = i + 1;
                            //        result = Helper.SQLHelper.ExecuteNonQuery(
                            //                            clsMostUseVars.VerifiedImageConnectionstring,
                            //                            CommandType.StoredProcedure,
                            //                            "usp_tbl_RefundImage",
                            //                            prmt
                            //                            );
                            //    }
                            //    catch
                            //    {
                            //        Console.WriteLine("This is not an image file");
                            //    }
                            //}
                            //if (result > 0)
                            //{
                            //    MessageBox.Show("Successful");
                            //}

                            //GRIDAttachNDC.TableElement.RowHeight = 50;
                            //GRIDAttachNDC.Columns["MemberImage"].ImageLayout = ImageLayout.Stretch;
                            //GRIDAttachNDC.DataSource = ImageContainer.DefaultIfEmpty();
                        }

                    }
                    catch (Exception ex)
                    {
                    }
                }
                else if (e.Column.Name == "btnTFRAttachImageView")
                {
                    NDCNo = int.Parse(e.Row.Cells["NDCNo"].Value.ToString());
                    string fileno = e.Row.Cells["FilePlotNo"].Value.ToString();
                    string ChallanNo = e.Row.Cells["ChallanNo"].Value.ToString();
                    lbl_Challan_OR_NDCNo.Text = NDCNo == 0 ? ChallanNo : NDCNo.ToString();

                    if (NDCNo != 0)
                    {
                        lblFlag.Text = "NDC";
                        SqlParameter[] prm =
                              {
                                    new SqlParameter("@Task","GetRefundImageAgainstNDCNO"),
                                    new SqlParameter("@NDCNo",NDCNo)
                                };

                        DataSet ds = Helper.SQLHelper.ExecuteDataset(
                                                        clsMostUseVars.VerifiedImageConnectionstring,
                                                        CommandType.StoredProcedure,
                                                        "usp_tbl_RefundImage",
                                                        prm
                                                        );
                        frmPhotoViewer frm = new frmPhotoViewer(ds.Tables[0]);
                        frm.ShowDialog();
                    }
                    if (ChallanNo != "0")
                    {
                        lblFlag.Text = "Challan";
                        SqlParameter[] prm =
                              {
                                    new SqlParameter("@Task","GetRefundImageAgainstChallanNO"),
                                    new SqlParameter("@ChallanNo",ChallanNo)
                                };

                        DataSet ds = Helper.SQLHelper.ExecuteDataset(
                                                        clsMostUseVars.VerifiedImageConnectionstring,
                                                        CommandType.StoredProcedure,
                                                        "usp_tbl_RefundImage",
                                                        prm
                                                        );
                        frmPhotoViewer frm = new frmPhotoViewer(ds.Tables[0]);
                        frm.ShowDialog();
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btn_ref_Click(object sender, EventArgs e)
        {
            DataLoading();
        }

        private void btnref1_Click(object sender, EventArgs e)
        {
            DataLoading();
        }

        private void btn_refsh_Click(object sender, EventArgs e)
        {
            DataLoading();
        }

        #region NDC Challan Refund
        private void chkchallan_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkchallan.CheckState == CheckState.Checked)
            {
                chkchallan.BackColor = Color.Green;
            }
            else
            {
                chkchallan.BackColor = Color.Transparent;
            }
        }

        private void chkndcrfundrpt_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkndcrfundrpt.CheckState == CheckState.Checked)
            {
                chkndcrfundrpt.BackColor = Color.Green;
            }
            else
            {
                chkndcrfundrpt.BackColor = Color.Transparent;
            }
        }

        private void chkaffidavit_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkaffidavit.CheckState == CheckState.Checked)
            {
                chkaffidavit.BackColor = Color.Green;
            }
            else
            {
                chkaffidavit.BackColor = Color.Transparent;
            }
        }

        private void chkndccancelcopy_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkndccancelcopy.CheckState == CheckState.Checked)
            {
                chkndccancelcopy.BackColor = Color.Green;
            }
            else
            {
                chkndccancelcopy.BackColor = Color.Transparent;
            }
        }

        private void chkdbapplicationcopy_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkdbapplicationcopy.CheckState == CheckState.Checked)
            {
                chkdbapplicationcopy.BackColor = Color.Green;
            }
            else
            {
                chkdbapplicationcopy.BackColor = Color.Transparent;
            }
        }
        #endregion


        private void radGroupBox3_Click(object sender, EventArgs e)
        {

        }

        private void rdPartial_CheckedChanged(object sender, EventArgs e)
        {
            decimal remaingSurcharge = 0;
            bool FlagremaingSurcharge = decimal.TryParse(lblRemaingSur.Text.Replace(",", ""), out remaingSurcharge);
            if (rdPartial.Checked == true)
            {
                txtrefundamount.ReadOnly = false;
                txtrefundamount.Enabled = true;
            }
            else
            {
                txtrefundamount.Enabled = false;
                txtrefundamount.Text = Math.Abs(remaingSurcharge).ToString();
            }
        }

        private void rdfull_CheckedChanged(object sender, EventArgs e)
        {
            decimal remaingSurcharge = 0;
            bool FlagremaingSurcharge = decimal.TryParse(lblRemaingSur.Text.Replace(",", ""), out remaingSurcharge);
            if (rdfull.Checked == true)
            {
                txtrefundamount.Text = Math.Abs(remaingSurcharge).ToString();
                txtrefundamount.ReadOnly = true;
                txtrefundamount.Enabled = true;
            }
            else
            {
                txtrefundamount.Enabled = true;
                txtrefundamount.ReadOnly = false;
            }
        }

        //private void DDPartialRefund_CheckedChanged(object sender, EventArgs e)
        //{
        //    decimal DDAmount = 0;
        //    bool FlagremaingSurcharge = decimal.TryParse(txtAmount_Old.Text.Replace(",", ""), out DDAmount);
        //    if (DDPartialRefund.Checked == true)
        //    {
        //        txtrefundamount.ReadOnly = false;
        //        txtrefundamount.Enabled = true;
        //    }
        //    else
        //    {
        //        txtrefundamount.Enabled = false;
        //        txtrefundamount.Text = Math.Abs(DDAmount).ToString();
        //    }
        //}

        private void DDFullRefund_CheckedChanged(object sender, EventArgs e)
        {
            decimal DDAmount = 0;
            bool FlagremaingSurcharge = decimal.TryParse(txtAmount_Old.Text.Replace(",", ""), out DDAmount);
            if (DDFullRefund.Checked == true)
            {
                DDtxtRefundAmount.Text = Math.Abs(DDAmount).ToString();
                DDtxtRefundAmount.ReadOnly = true;
                DDtxtRefundAmount.Enabled = true;
            }
            else
            {
                DDtxtRefundAmount.Enabled = true;
                DDtxtRefundAmount.ReadOnly = false;
            }
        }

        private void DDtxtRefundAmount_Leave(object sender, EventArgs e)
        {
            decimal DDAmount = 0;
            bool FlagremaingSurcharge = decimal.TryParse(txtAmount_Old.Text.Replace(",", ""), out DDAmount);
            decimal DDRefund = 0;
            bool DDRefundFlage = decimal.TryParse(DDtxtRefundAmount.Text, out DDRefund);
            if (DDRefund < 1)
            {
                MessageBox.Show("Invalid Amount in DD Refund Field.");
                btnDDRefundRequest.Enabled = false;
            }
            else if (DDRefund > DDAmount)
            {
                MessageBox.Show("Refund Amount Must be Less or Equal to Demand Draft Amount.");
                btnDDRefundRequest.Enabled = false;
            }
            else
            {
                btnDDRefundRequest.Enabled = true;
            }
        }

        private void btnRefundChallan_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] prmt =
                                          {
                                new SqlParameter("@Task","GetChallanforRefund"),
                                new SqlParameter("@ChallanNo",txtChallanNoRefund.Text)
                                };
                DataSet dst = Helper.SQLHelper.ExecuteDataset(
                                            clsMostUseVars.Connectionstring,
                                            CommandType.StoredProcedure,
                                            "App.usp_tbl_Refund",
                                            prmt
                                            );
                if (dst.Tables.Count > 0)
                {
                    if (dst.Tables[0].Rows.Count > 0)
                    {
                        SCRtxtFileNo.Text = dst.Tables[0].Rows[0]["FileNo"].ToString();
                        SCRtxtOwner.Text = dst.Tables[0].Rows[0]["OwnerName"].ToString();
                        SRCtxtReceDate.Text = dst.Tables[0].Rows[0]["ClearDate"].ToString();
                        SRCtxtAmount.Text = dst.Tables[0].Rows[0]["Amount"].ToString();
                        SCRtxtChallanNo.Text = dst.Tables[0].Rows[0]["ChalanNo"].ToString();
                        SCRtxtBank.Text = dst.Tables[0].Rows[0]["BankName"].ToString();
                        SCR_RefundAmount.Text = dst.Tables[0].Rows[0]["Amount"].ToString();
                        SCR_RefundDate.Value = DateTime.Now;
                    }
                    else
                    {
                        MessageBox.Show("Invalid Challan No. / File is Locked.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        List<clsMemberImage> ImageContainerSCR = new List<clsMemberImage>();
        private void SCR_AttachImage_Click(object sender, EventArgs e)
        {
            try
            {
                int imageCount = ImageContainerSCR.Count() + 1;
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
                    ImageContainerSCR.Add(obj);
                    SCR_ImageArch.TableElement.RowHeight = 50;
                    SCR_ImageArch.Columns["MemberImage"].ImageLayout = ImageLayout.Stretch;
                    SCR_ImageArch.DataSource = ImageContainerSCR.DefaultIfEmpty();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void SCR_RequestRefund_Click(object sender, EventArgs e)
        {
            try
            {

            if (ImageContainerSCR.Count > 0)
            {
                double RefundAmount = 0;
                bool RefundConvert = double.TryParse(SCR_RefundAmount.Text.Replace(",", ""), out RefundAmount);
                if (RefundAmount > 0)
                {
                       
                        SqlParameter[] parameter = {
                                new SqlParameter("@Task","NewRefundofInstallment"),
                                new SqlParameter("@ChequeNo",SCR_ChequeNo.Text),
                                new SqlParameter("@Amount_In_Word",clsPluginHelper.Convert_Number_To_Text((int)Math.Abs(RefundAmount),true)),
                                new SqlParameter("@Requestedby",clsUser.Name),
                                new SqlParameter("@Remarks",SCR_Remarks.Text),
                                new SqlParameter("@ChallanNo",SCRtxtChallanNo.Text),
                                new SqlParameter("@ChallanID",0),
                                new SqlParameter("@DateofRefund",SCR_RefundDate.Value),
                                new SqlParameter("@FileNo",SCRtxtFileNo.Text),
                                //new SqlParameter("@DateofRequest",""),
                                new SqlParameter("@AdjustmentType","SR-of-TFR-File"),
                                new SqlParameter("@STATUS","Pending"),
                                new SqlParameter("@PaymentType","Cheque"),
                                new SqlParameter("@NDCNo",0),
                                new SqlParameter("@RefundAmount", Math.Abs(RefundAmount).ToString())
                             };
                    string RefundID = Helper.SQLHelper.ExecuteScalar(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_Refund", parameter).ToString();
                    try
                    {
                        foreach (clsMemberImage row in ImageContainerSCR)
                        {
                            MemoryStream ms = new MemoryStream();
                            row.MemberImage.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                            Byte[] Image = ms.ToArray();
                            SqlParameter[] parameters =
                            {
                                        new SqlParameter("@Task", "Insert"),
                                        new SqlParameter("@RefundID", RefundID),
                                        new SqlParameter("@ImageFile", Image),
                                        new SqlParameter("@ImageName", row.ImageName),
                                        new SqlParameter("@Description", row.Description),
                                        new SqlParameter("@user_ID", clsUser.ID),
                                         };
                            int result = Helper.SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.VerifiedImageConnectionstring,
                                                    CommandType.StoredProcedure,
                                                    "usp_tbl_RefundImage",
                                                    parameters
                                                    );

                        }
                        ImageContainerSCR.Clear();
                        SCR_ImageArch.DataSource = null;

                    }
                    catch (Exception rc)
                    {
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Refund Cannot be Process.");
                }
            }
            else
            {
                MessageBox.Show("No Documents are Attach. Please Attach the Documents");
            }

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PerDeduction_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            string Amt = lblTotalAmount.Text;
            string dedper = lbl10Per.Text;

            decimal TotalAmount = 0;
            bool totalamountflag = decimal.TryParse(lblTotalAmount.Text, out TotalAmount);
            decimal DeductionPer = (decimal)PerDeduction.SelectedItem.Value;



            decimal RefundedAmount = (TotalAmount * (1.0m - DeductionPer));
            decimal DHAServiceCharges = (TotalAmount * DeductionPer);
            lblTotalAmount.Text = TotalAmount.ToString();
            lbl10Per.Text = DHAServiceCharges.ToString();
            decimal RefundAmount = TotalAmount - DHAServiceCharges;
            txtNDCChallanRefundAmount.Text = RefundAmount.ToString();
        }
    }
}
