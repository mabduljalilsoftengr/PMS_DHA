using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.NDC;
using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    public partial class frm_BasketVerificationExpireCancelTFRComplete : Telerik.WinControls.UI.RadForm
    {
        public frm_BasketVerificationExpireCancelTFRComplete()
        {
            InitializeComponent();
        }

        private void frm_BasketVerificationExpireCancelTFRComplete_Load(object sender, EventArgs e)
        {
            BasketFilling();
            GetExpirNDC();

        }
        private void BasketFilling()
        {
            try
            {
                SqlParameter[] prmt =
                {
                    new SqlParameter("@Task","GetNDCData_ForBaskets")
                };
                DataSet dst = cls_dl_NDC.NdcRetrival(prmt);
                //grdIncomplete.DataSource = dst.Tables[0].DefaultView;
                grdExpiredNDCs.DataSource = dst.Tables[1].DefaultView;
                grdCancelNDC.DataSource = dst.Tables[2].DefaultView;
                DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.Text,
                               "Select * from tbl_Basket_Queries Where Status Like 'ON'");
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    //if (row["Task_Name"].ToString() == "Incomplete")
                    //{
                    //    FillGrid(grdIncomplete, row["Query"].ToString());
                    //}
                    //if (row["Task_Name"].ToString() == "RequestForPrint")
                    //{
                    //    FillGrid(grdRequestForPrint, row["Query"].ToString());
                    //}
                    //if (row["Task_Name"].ToString() == "ReadyForPrint")
                    //{
                    //    FillGrid(grdReady_For_Print, row["Query"].ToString());
                    //}
                    if (row["Task_Name"].ToString() == "PrintAndNotSigned")
                    {
                        FillGrid(grdPrinted_NotSigned, row["Query"].ToString());
                    }
                    //if (row["Task_Name"].ToString() == "Verified")
                    //{
                    //    FillGrid(grdShowVerifiedNDCS, row["Query"].ToString());
                    //}
                    //if (row["Task_Name"].ToString() == "SignedAndNotIssued") 
                    //{
                    //    FillGrid(grdSigned_NotIssued, row["Query"].ToString());
                    //}
                    //if (row["Task_Name"].ToString() == "IssueAndImageUploaded")
                    //{
                    //    FillGrid(grdIssued_ImageUpload, row["Query"].ToString());
                    //}
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on BasketFilling.", ex, "frmBasketIncomplete");
                frmobj.ShowDialog();
            }

        }
        private void GetExpirNDC()
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
        private void FillGrid(RadGridView dv, string Query)
        {
            try
            {
                dv.DataSource =
                                SQLHelper.ExecuteDataset(
                                    clsMostUseVars.Connectionstring, CommandType.Text, Query).Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on FillGrid.", ex, "frmBasketIncomplete");
                frmobj.ShowDialog();
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BasketFilling();
            GetExpirNDC();
        }

        private void grdPrinted_NotSigned_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;
                if (rowindex >= 0)
                {
                    int NDCNo = int.Parse(grdPrinted_NotSigned.Rows[rowindex].Cells[0].Value.ToString());
                    if (e.Column.Name == "Prnt_NotSnd")
                    {
                        bool grpstatus = false;
                        bool AllButtonsVisibilty = false;
                        frmPrintNotSigned_NDCCheckListDetail obj = new frmPrintNotSigned_NDCCheckListDetail(NDCNo, grpstatus, AllButtonsVisibilty);
                        obj.ShowDialog();
                        BasketFilling();
                    }
                }


            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on grdPrinted_NotSigned_CellClick.", ex, "frmBasketIncomplete");
                frmobj.ShowDialog();
            }
        }

        private void grdExpireNDCData_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "btnCancel")
                {
                    if (MessageBox.Show("Are You Sure ?","Attention !",MessageBoxButtons.YesNo,MessageBoxIcon.Information)== DialogResult.Yes)
                    {
                        int ndcn = int.Parse(e.Row.Cells["NDCNo"].Value.ToString());  // Cancel
                                                                                      //string rms = e.Row.Cells["txtRemarks"].Value.ToString();
                        string FileNo = e.Row.Cells["FilePlotNo"].Value.ToString();
                        SqlParameter[] prm =
                        {
                             new SqlParameter("@Task","UpdateNDCAndExpireDate"),
                             new SqlParameter("@NDCNo",ndcn),
                             new SqlParameter("@StatusofNDC","Cancel"),
                             new SqlParameter("@FileNo",FileNo)
                        };
                        int rsl = cls_dl_NDC.NdcNonQuery(prm);
                        if (rsl > 0)
                        {
                            MessageBox.Show("Deal Cancelled Successfully.");
                            btnRefresh_Click(sender, e);
                        }
                    }
                    

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
