using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Application_Layer.Transfer;
using PeshawarDHASW.Data_Layer.clsTFR;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Report.Simple_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    public partial class frmReadyForPicturePrint : Telerik.WinControls.UI.RadForm
    {
        private int TransferNo { get; set; }
        private int ndcno { get; set; }
        private int purchasetypeID { get; set; }
        private string fileNo { get; set; }
        private int TFRAppoimtmentID { get; set; }
        public frmReadyForPicturePrint()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataForBasket();
        }
        private void LoadDataForBasket()
        {
            try
            {
                SqlParameter[] prm =
                {
                    new SqlParameter("@Task","GetDateForTransferPicPrint")
                };
                DataSet ds = cls_dl_TFR.TranferRead(prm);
                grdReadyForPicture.DataSource = ds.Tables[0];

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LoadDataForBasket.", ex, "frmReadyForPicture");
                frmobj.ShowDialog();
            }

        }

        private void grdReadyForPicture_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = grdReadyForPicture.CurrentCell.RowIndex;
                ndcno = int.Parse(grdReadyForPicture.Rows[rowindex].Cells[0].Value.ToString());
                purchasetypeID = int.Parse(grdReadyForPicture.Rows[rowindex].Cells[3].Value.ToString());
                TransferNo = int.Parse(grdReadyForPicture.Rows[rowindex].Cells[2].Value.ToString());
                fileNo = grdReadyForPicture.Rows[rowindex].Cells[1].Value.ToString();
                TFRAppoimtmentID = int.Parse(e.Row.Cells["TFRAppoimtmentID"].Value.ToString());
                string sellerString = grdReadyForPicture.Rows[rowindex].Cells[4].Value.ToString();
                string buyerString = grdReadyForPicture.Rows[rowindex].Cells[5].Value.ToString();

                if (e.Column.Name == "btnImageReport")
                {
                    frmTransferReportImages frm = new frmTransferReportImages(fileNo, ndcno, purchasetypeID, TransferNo);
                    frm.ShowDialog();
                }
                else if (e.Column.Name == "btnNext")
                {
                    if (MessageBox.Show("Are you sure ?", "Attention!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        Updation_Of_All_NDC_RelatedData();
                        LoadDataForBasket();
                    }
                }
                else if (e.Column.Name == "btnBack")
                {
                    try
                    {
                        if (MessageBox.Show("Are you sure ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            int ndc = int.Parse(e.Row.Cells["NDCNo"].Value.ToString());
                            int tfr = int.Parse(e.Row.Cells["TransferNo"].Value.ToString());
                            SqlParameter[] prm =
                            {
                        new SqlParameter("@Task","Update_TFR_NDC_StatusDltImg"),
                        new SqlParameter("@NDCNo",ndc),
                        new SqlParameter("@TransferNo",tfr),
                        new SqlParameter("@NDCStatus","ReadyForPicture"),
                        new SqlParameter("@TFR_Status","ReadyForPicture")
                        };
                            int rslt = cls_dl_TFR.TranferSetting(prm);
                            if (rslt > 0)
                            {
                                MessageBox.Show("Successfull.");
                                LoadDataForBasket();
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on grdReadyForPicture_CellClick.", ex, "frmReadyForPicture");
                frmobj.ShowDialog();
            }
        }
        private bool Updation_Of_All_NDC_RelatedData()
        {
            bool blvr = false;
            DataTable File = FileMap();
            DataTable tbl_TFRTracking = Transfer_Tracking();
            DataTable tbl_Transfer_History_Image = Transfer_History_Image();
            SqlParameter[] parmtr =
            {
                      new SqlParameter("@Task","Update"),
                      new SqlParameter("@TFRAppoID",TFRAppoimtmentID),
                      new SqlParameter(){ ParameterName = "@tbl_FileMap",SqlDbType = SqlDbType.Structured, SqlValue = File},
                      new SqlParameter(){ ParameterName = "@tbl_TransferTracking",SqlDbType = SqlDbType.Structured, SqlValue = tbl_TFRTracking},
                      new SqlParameter() { ParameterName = "@tbl_TransferHistoryImage",SqlDbType = SqlDbType.Structured,SqlValue = tbl_Transfer_History_Image },  //()
             };
            int result = 0;
            result = cls_dl_TFRVerification.TFRVerification_NonQuery(parmtr);
            if (result > 0)
            {
                MessageBox.Show("Transfer Completed Successfully.");
                //Helper.clsMostUseVars.Drctr_Secret_Code = false;
                //this.Close();
                //LoadReportData();
                //Clear();
                blvr = true;
            }
            else
            {
                blvr = false;
            }
            return blvr;
        }
        private DataTable FileMap()
        {
            DataTable tbl_FileMap = new DataTable();
            try
            {
                DataTable_column TFRTypeID = new DataTable_column() { ColmnName = "TFRTypeID", type = typeof(int) };
                DataTable_column NDCNo = new DataTable_column() { ColmnName = "NDCNo", type = typeof(int) };
                List<DataTable_column> colmn = new List<DataTable_column>();
                colmn.Add(TFRTypeID);
                colmn.Add(NDCNo);
                tbl_FileMap = clsPluginHelper.ColmnsCreateinDatatable(colmn);
                DataRow row = tbl_FileMap.NewRow();
                row["TFRTypeID"] = purchasetypeID;
                row["NDCNo"] = ndcno;
                tbl_FileMap.Rows.Add(row);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on FileMap.", ex, "frmTransferVerification");
                frmobj.ShowDialog();
            }
            return tbl_FileMap;
        }
        private DataTable Transfer_Tracking()
        {
            DataTable tbl_TFR_Tracking = new DataTable();
            try
            {
                DataTable_column TFRNocol = new DataTable_column() { ColmnName = "TFRNo", type = typeof(int) };
                DataTable_column TFRTrackingStatus = new DataTable_column() { ColmnName = "TFRTrackingStatus", type = typeof(string) };
                DataTable_column NDCNo = new DataTable_column() { ColmnName = "NDCNo", type = typeof(int) };
                List<DataTable_column> colmn = new List<DataTable_column>();
                colmn.Add(TFRNocol);
                colmn.Add(TFRTrackingStatus);
                colmn.Add(NDCNo);
                tbl_TFR_Tracking = clsPluginHelper.ColmnsCreateinDatatable(colmn);
                DataRow row = tbl_TFR_Tracking.NewRow();
                row["TFRNo"] = TransferNo;
                row["TFRTrackingStatus"] = "TFRImageUploadCompleted";
                row["NDCNo"] = ndcno;
                tbl_TFR_Tracking.Rows.Add(row);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Transfer_Tracking.", ex, "frmTransferVerification");
                frmobj.ShowDialog();
            }

            return tbl_TFR_Tracking;
        }
        private DataTable Transfer_History_Image()
        {
            DataTable tbl_TFR_History_Image = new DataTable();
            try
            {
                DataTable_column TFRHistoryImage_Status = new DataTable_column() { ColmnName = "TFRHistoryImage_Status", type = typeof(string) };
                DataTable_column TFRNo_col = new DataTable_column() { ColmnName = "TFRNo_col", type = typeof(int) };
                List<DataTable_column> colmn = new List<DataTable_column>();
                colmn.Add(TFRHistoryImage_Status);
                colmn.Add(TFRNo_col);
                tbl_TFR_History_Image = clsPluginHelper.ColmnsCreateinDatatable(colmn);

                DataRow row = tbl_TFR_History_Image.NewRow();
                row["TFRHistoryImage_Status"] = "Verified";
                row["TFRNo_col"] = TransferNo;
                tbl_TFR_History_Image.Rows.Add(row);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Transfer_History_Image.", ex, "frmTransferVerification");
                frmobj.ShowDialog();
            }

            return tbl_TFR_History_Image;
        }

        private void frmReadyForPicturePrint_Load(object sender, EventArgs e)
        {
            LoadDataForBasket();
        }
    }
}
