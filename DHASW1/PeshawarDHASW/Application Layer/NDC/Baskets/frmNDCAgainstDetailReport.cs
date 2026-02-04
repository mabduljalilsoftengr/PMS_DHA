using PeshawarDHASW.Data_Layer.NDC;
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
    public partial class frmNDCAgainstDetailReport : Telerik.WinControls.UI.RadForm
    {
        public frmNDCAgainstDetailReport()
        {
            InitializeComponent();
        }
        

        private void frmNDCAgainstDetailReport_Load(object sender, EventArgs e)
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","GetAllNDCs")
            };
            DataSet dst = cls_dl_NDC.NdcRetrival(prm);
            grdNDCData.DataSource = dst.Tables[0].DefaultView;
        }

        private void grdNDCData_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "btnDetail")
                {
                    int rowindex = grdNDCData.CurrentCell.RowIndex;
                    int NDCNo = int.Parse(grdNDCData.Rows[rowindex].Cells["NDCNo"].Value.ToString());
                    SqlParameter[] prmtr =
                    {
                    new SqlParameter("@Task","NDCDetailReport"),
                    new SqlParameter("@NDCNo",NDCNo)
                    };
                    DataSet dst = cls_dl_NDC.NdcRetrival(prmtr);
                    txtDealValue.Text = dst.Tables[0].Rows[0]["Deal_Amount"].ToString();
                    if (dst.Tables[0].Rows[0]["DealType"].ToString() == "FBR")
                        rdbFBR.CheckState = CheckState.Checked;
                    else
                        FBROther.CheckState = CheckState.Checked;
                    grdFBRSellerBuyerData.DataSource = dst.Tables[1].DefaultView;
                    grdFBRCPRData.DataSource = dst.Tables[2].DefaultView;

                    txtCalculatedTax.Text = dst.Tables[3].Rows[1]["CalculatedTaxOnDealAmount"].ToString();
                    txtOwnerType.Text = dst.Tables[3].Rows[1]["FBROwnerType"].ToString();

                    grdStampDuty.DataSource = dst.Tables[4].DefaultView;
                    grdStampDutySellerBuyer.DataSource = dst.Tables[5].DefaultView;

                }
                else if (e.Column.Name == "Report")
                {
                    int NDCNo = int.Parse(e.Row.Cells["NDCNo"].Value.ToString());
                    SqlParameter[] prmtr =
                    {
                    new SqlParameter("@Task","NDCDetailReport_rpt"),
                    new SqlParameter("@NDCNo",NDCNo)
                    };
                    DataSet dst = cls_dl_NDC.NdcRetrival(prmtr);
                    frmFBRReport frm = new frmFBRReport(dst);
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
