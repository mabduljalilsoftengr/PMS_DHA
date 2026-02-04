
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

namespace PeshawarDHASW.Application_Layer.Refund
{
    public partial class frmRefundModify : Telerik.WinControls.UI.RadForm
    {
        public frmRefundModify()
        {
            InitializeComponent();
        }

        private void frmRefundModify_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
            SqlParameter[] prmt =
            {
                new SqlParameter("@Task","GetApprovedRefundData")
            };
            DataSet dst = cls_dl_NDC.RefundRetrival(prmt);
            grdrefunddata.DataSource = dst.Tables[0].DefaultView;
            foreach (GridViewDataColumn column in grdrefunddata.Columns)
            {
                column.BestFit();
            }
        }

        private void grdrefunddata_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                #region Code
                if (e.Column.Name == "btnModify")
                {
                    if (MessageBox.Show("Are you sure to modify ?", "Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int RefundID = int.Parse(e.Row.Cells["RefundID"].Value.ToString());
                        int ndc = Convert.ToInt32(e.Row.Cells["NDCNo"].Value.ToString());//e.Row.Cells["NDCNo"].Value == null ? 0 : e.Row.Cells["NDCNo"].Value;
                        //int ndcno = Convert.ToInt32(ndc);
                        string cheqno = e.Row.Cells["chqNumber"].Value.ToString();
                        string vchno = e.Row.Cells["vchNo"].Value.ToString();
                        if (string.IsNullOrWhiteSpace(cheqno) || string.IsNullOrWhiteSpace(vchno))
                        {
                            MessageBox.Show("Cheque and Voucher No is Mandatory");
                        }
                        else
                        {
                            SqlParameter[] prm =
                            {
                                new SqlParameter("@Task","ModifyRefund"),
                                new SqlParameter("@RefundID",RefundID),
                                new SqlParameter("@ChequeNo",cheqno),
                                new SqlParameter("@VoucherNo",vchno),
                                new SqlParameter("@Status","RefundCompleted")
                            };
                            int rslt = cls_dl_NDC.RefundNonQuery(prm);
                            if (rslt > 0)
                            {
                                MessageBox.Show("Modification Succesfull.");
                                GetData();
                                #region Update NDC Status
                                if (ndc > 0)
                                {
                                    SqlParameter[] prtm =
                                    {
                                        new SqlParameter("@Task","UpdateNDC_Sts"),
                                        new SqlParameter("@NDCNo",ndc),
                                        new SqlParameter("@StatusofNDC","RefundComplete")
                                    };
                                    int rsl = cls_dl_NDC.NdcNonQuery(prtm);
                                }
                                #endregion
                            }
                        }
                    }
                }
                if (e.Column.Name == "btnAttachment")
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
                #endregion
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            GetData();
        }
    }
}
