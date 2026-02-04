using PeshawarDHASW.Data_Layer.clsStampDuty;
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

namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    public partial class frmCompleteTransfer : Telerik.WinControls.UI.RadForm
    {
        public frmCompleteTransfer()
        {
            InitializeComponent();
        }
        private int NDCNo { get; set; }
        List<clsMemberImage> ImageContainer = new List<clsMemberImage>();
        private void frmCompleteTransfer_Load(object sender, EventArgs e)
        {
            try
            {
                GetApprovedNDC();
                GetExpiredNDC();
                GetCancelledNDC();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GetCancelledNDC()
        {
            SqlParameter[] prmt =
            {
                 new SqlParameter("@Task","GetNDCData_ForBaskets")
            };
            DataSet dst = cls_dl_NDC.NdcRetrival(prmt);
            grdCancelNDC.DataSource = dst.Tables[2].DefaultView;
        }
        private void GetApprovedNDC()
        {
            SqlParameter[] prm =
            {
             new SqlParameter("@Task","GetApprovedNDC")
            };
            DataSet dst = cls_dl_NDC.NdcRetrival(prm);
            grdTransferComplete.DataSource = dst.Tables[0].DefaultView;
        }
        private void GetExpiredNDC()
        {
            try
            {
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","GetExpireNDC_ThatNotCompleteTheTransfer")
                };
                DataSet dst = cls_dl_NDC.NdcRetrival(prm);
                grdExpireNDCData.DataSource = dst.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void grdTransferComplete_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            { 
            if(e.Column.Name == "TransferComplete")
            {
                if (MessageBox.Show("Are you sure ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int rowindex = grdTransferComplete.CurrentCell.RowIndex;
                    int NDCNo = int.Parse(grdTransferComplete.Rows[rowindex].Cells["NDCNo"].Value.ToString());
                    SqlParameter[] prm =
                    {
                    new SqlParameter("@Task","UpdateNDCAndExpireDate"),
                    new SqlParameter("@NDCNo",NDCNo),
                    new SqlParameter("@StatusofNDC","FileTransferCompleted")
                    };
                    int rsl = cls_dl_NDC.NdcNonQuery(prm);
                    if (rsl > 0)
                    {
                        MessageBox.Show("NDC is Updated Successfully.");
                        frmCompleteTransfer_Load(null, null);
                    }
                }
            }
            else if(e.Column.Name == "btnCancelDeal")
            {
                if (MessageBox.Show("Are you sure ?","Attention !",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int NDCNo = int.Parse(e.Row.Cells["NDCNo"].Value.ToString());
                    string FileNo = e.Row.Cells["FilePlotNo"].Value.ToString();
                    SqlParameter[] prm =
                    {
                    new SqlParameter("@Task","UpdateNDCAndExpireDate"),
                    new SqlParameter("@NDCNo",NDCNo),
                    new SqlParameter("@StatusofNDC","Cancel"),
                    new SqlParameter("@FileNo",FileNo)
                    };
                    int rsl = cls_dl_NDC.NdcNonQuery(prm);
                    if (rsl > 0)
                    {
                        //ActiveFBRAgain(NDCNo);
                        MessageBox.Show("NDC is Cancelled Successfully.");
                        frmCompleteTransfer_Load(null, null);
                            #region Update the Seller CPR Status to Cancel
                            SqlParameter[] prmtr1 =
                            {
                            new SqlParameter("@Task","UpdateFBRCPRStatus"),
                            new SqlParameter("@NDCNo",NDCNo),
                            new SqlParameter("@Status","DealCancel")
                            };
                            int rslt = cls_dl_NDC.NdcNonQuery(prmtr1);
                            #endregion
                        }
                    }
               
            }
            else if(e.Column.Name == "btnViewDetail")
            {
                    int NDCNo = Convert.ToInt32(e.Row.Cells["NDCNo"].Value.ToString());
                    frmNDCSearch frmobj = new frmNDCSearch(NDCNo);
                    frmobj.Show();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ActiveFBRAgain(int ndcno)
        {
            SqlParameter[] prm =
            {
             new SqlParameter("@Task","UpdateFBRStatus"),
             new SqlParameter("@NDCNo",ndcno),
             new SqlParameter("@Status","Active")
             };
            int rsl = cls_dl_NDC.NdcNonQuery(prm);
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frmCompleteTransfer_Load(null, null);
        }

        private void grdExpireNDCData_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            { 
               if (e.Column.Name == "btnCancelNDC")
               {
                   if (MessageBox.Show("Are you sure ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                   {
                       int NDCNo = Convert.ToInt32(e.Row.Cells["NDCNo"].Value.ToString());
                       string FileNo = e.Row.Cells["FilePlotNo"].Value.ToString();
                       SqlParameter[] prm =
                       {
                       new SqlParameter("@Task","UpdateNDCButNotExpireDate"),
                       new SqlParameter("@NDCNo",NDCNo),
                       new SqlParameter("@StatusofNDC","ExpiredCancel"),
                       new SqlParameter("@FileNo",FileNo)
                       };
                       int rsl = cls_dl_NDC.NdcNonQuery(prm);
                       if (rsl > 0)
                       {
                           //UpdateStampDutyStatus(NDCNo);
                           MessageBox.Show("NDC is sended to Finance branch successfully.");
                           frmCompleteTransfer_Load(null, null);
                       }
                   }
               }
               else if (e.Column.Name == "btnCancelDeal")
               {
                       if (MessageBox.Show("Are you sure ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                       {
                           int NDCNo = Convert.ToInt32(e.Row.Cells["NDCNo"].Value.ToString());
                           string FileNo = e.Row.Cells["FilePlotNo"].Value.ToString();
                           SqlParameter[] prm =
                           {
                             new SqlParameter("@Task","UpdateNDCAndExpireDate"),
                             new SqlParameter("@NDCNo",NDCNo),
                             new SqlParameter("@StatusofNDC","Cancel"),
                             new SqlParameter("@FileNo",FileNo)
                           };
                           int rsl = cls_dl_NDC.NdcNonQuery(prm);
                           if (rsl > 0)
                           {
                               //ActiveFBRAgain(NDCNo);
                               MessageBox.Show("NDC Cancelled Successfully.");
                               frmCompleteTransfer_Load(null, null);
                           }
                       }
               
                }
                else if (e.Column.Name == "TransferComplete")
                {
                    if (MessageBox.Show("Are you sure ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        int rowindex = grdExpireNDCData.CurrentCell.RowIndex;
                        int NDCNo = int.Parse(grdExpireNDCData.Rows[rowindex].Cells["NDCNo"].Value.ToString());
                        SqlParameter[] prm =
                        {
                        new SqlParameter("@Task","UpdateNDCAndExpireDate"),
                        new SqlParameter("@NDCNo",NDCNo),
                        new SqlParameter("@StatusofNDC","FileTransferCompleted")
                        };
                        int rsl = cls_dl_NDC.NdcNonQuery(prm);
                        if (rsl > 0)
                        {
                            MessageBox.Show("NDC is Updated Successfully.");
                            frmCompleteTransfer_Load(null, null);
                        }
                    }
                }
            }
               catch (Exception)
               {
               
                   throw;
               }
        }
        private void UpdateStampDutyStatus(int NDCNo)
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","Update_StampDuty_Status"),
                new SqlParameter("@NDCNo",NDCNo),
                new SqlParameter("@Status","Not-Use")
            };
            int rsl = cls_dl_StampDuty.StampDuty_NonQuery(prm);
        }
        private void grdCancelNDC_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {



                if (e.Column.Name == "btnRefund")
                {
                    int NDCNo = int.Parse(e.Row.Cells["NDCNo"].Value.ToString());
                    string fileno = e.Row.Cells["FilePlotNo"].Value.ToString();
                    SqlParameter[] prm =
                    {
                    new SqlParameter("@Task","GetDataForCal10Per"),
                    new SqlParameter("@FileNo",fileno),
                    new SqlParameter("@NDCNo",NDCNo)
                    };
                    DataSet dst = new DataSet();
                    dst = cls_dl_NDC.NdcRetrival(prm);
                    // Create Table-1
                    var dt = new System.Data.DataTable("tblCalData");

                    // Create fields in Table-1
                    dt.Columns.Add("ID", typeof(int));
                    dt.Columns.Add("ChalanNo", typeof(string));
                    dt.Columns.Add("Particular", typeof(string));
                    dt.Columns.Add("Amount", typeof(decimal));
                    dt.Columns.Add("Amount10Per", typeof(decimal));


                    for (int i = 0; i < dst.Tables[0].Rows.Count; i++)
                    {
                        string chno = dst.Tables[0].Rows[i]["ChalanNo"].ToString();
                        string prtclr = Convert.ToString(dst.Tables[0].Rows[i]["Particular"].ToString());
                        decimal amount = Convert.ToDecimal(dst.Tables[0].Rows[i]["Amount"].ToString());
                        decimal amount10per = (amount * 10) / 100;

                        // insert row values in Table-1
                        dt.Rows.Add(new Object[]{
                    i+1,
                    chno,
                    prtclr,
                    amount,
                    amount10per
                    });
                    }
                    object sumAmount;
                    sumAmount = dt.Compute("Sum(Amount)", string.Empty);
                    object sumAmountPer;
                    sumAmountPer = dt.Compute("Sum(Amount10Per)", string.Empty);

                    // Create Table-2 for Sum
                    var dt1 = new System.Data.DataTable("tblCalData1");
                    // Create fields in Table-2
                    dt1.Columns.Add("ID", typeof(int));
                    dt1.Columns.Add("SumAmount", typeof(decimal));
                    dt1.Columns.Add("SumAmount10Per", typeof(decimal));
                    dt1.Columns.Add("NDCNo", typeof(int));
                    dt1.Columns.Add("FileNo", typeof(string));
                    //Insert Data in Table-2
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        dt1.Rows.Add(new Object[]{
                    i+1,
                    sumAmount,
                    sumAmountPer,
                    NDCNo,
                    fileno
                    });
                    }
                    DataTable dtb = dt;
                    DataTable dtb1 = dt1;
                    // Join the Two Tables
                    var JoinResult = (from p in dt.AsEnumerable()
                                      join t in dt1.AsEnumerable()
                                      on p.Field<int>("ID") equals t.Field<int>("ID") into tempJoin
                                      from innerJoin in tempJoin.DefaultIfEmpty()
                                      select new
                                      {
                                          ID = p.Field<int>("ID"),
                                          ChalanNo = p.Field<string>("ChalanNo"),
                                          Particular = p.Field<string>("Particular"),
                                          Amount = p.Field<decimal>("Amount"),
                                          SumAmount = innerJoin == null ? 0 : innerJoin.Field<decimal>("SumAmount"),
                                          SumAmount10Per = innerJoin == null ? 0 : innerJoin.Field<decimal>("SumAmount10Per"),
                                          NDCNo = innerJoin == null ? 0 : innerJoin.Field<int>("NDCNo"),
                                          fileno = innerJoin == null ? "" : innerJoin.Field<string>("fileno"),
                                      }).ToList();
                    DataTable dbtl = Helper.clsPluginHelper.ToDataTable(JoinResult);
                    frmNDC_Report frm = new frmNDC_Report(dbtl, "NDC_Refund_String", NDCNo);
                    frm.ShowDialog();

                }
                else if (e.Column.Name == "btnAttachments")
                {
                    try
                    {
                        int result = 0;
                        NDCNo = int.Parse(e.Row.Cells["NDCNo"].Value.ToString());
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
                                    _ravi["Description"] = "Attachments of NDC refund by Transfer Branch.";
                                    dt.Rows.Add(_ravi);
                                    i = i + 1;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("This is not an image file");
                                }
                            }

                            grdImagePreview.TableElement.RowHeight = 50;
                            grdImagePreview.Columns["MemberImage"].ImageLayout = ImageLayout.Stretch;
                            grdImagePreview.DataSource = dt.DefaultView;

                           


                            //GRIDAttachNDC.TableElement.RowHeight = 50;
                            //GRIDAttachNDC.Columns["MemberImage"].ImageLayout = ImageLayout.Stretch;
                            //GRIDAttachNDC.DataSource = ImageContainer.DefaultIfEmpty();
                        }
                        
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int rlst = 0, result =0;
            if (grdImagePreview.RowCount > 0)
            {
                if (MessageBox.Show("Are you print the refund detail report ?" + Environment.NewLine +
                                    "Are you want to save and go next.", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    #region Save Image Detail
                    try
                    {
                        for (int i = 0; i < grdImagePreview.RowCount; i++)
                        {
                            Image img = (Image)grdImagePreview.Rows[i].Cells["MemberImage"].Value;
                            MemoryStream ms = new MemoryStream();
                            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            Byte[] Image = ms.ToArray();

                            SqlParameter[] parameters =
                            {
                                     new SqlParameter("@Task", "InsertNDCRefund"),
                                     new SqlParameter("@RefundID", 0),
                                     new SqlParameter("@NDCNo",NDCNo),
                                     new SqlParameter("@ImageFile", Image),
                                     new SqlParameter("@ImageName", grdImagePreview.Rows[i].Cells["ImageName"].Value),
                                     new SqlParameter("@Description", grdImagePreview.Rows[i].Cells["Description"].Value),
                                     new SqlParameter("@user_ID", clsUser.ID),
                             };
                             result = Helper.SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.VerifiedImageConnectionstring,
                                                    CommandType.StoredProcedure,
                                                    "usp_tbl_RefundImage",
                                                    parameters
                                                    );

                        }
                    }
                    catch
                    {
                        Console.WriteLine("This is not an image file");
                    }
                    #endregion
                    #region Update NDC Status
                    SqlParameter[] prm =
                    {
                         new SqlParameter("@Task","UpdateNDC_Sts"),
                         new SqlParameter("@StatusofNDC","RefundRequest"),
                         new SqlParameter("@NDCNo",NDCNo)
                         };
                     rlst = cls_dl_NDC.NdcNonQuery(prm);
                    if (rlst > 0 && result > 0)
                    {
                        MessageBox.Show("Successfull.", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnRefresh_Click(sender, e);
                        grdImagePreview.DataSource = null;
                    }
                    #endregion
                }
            }
            else
            {
                MessageBox.Show("Please Attach the Documents.");
            } 
            }
        
    }
}
