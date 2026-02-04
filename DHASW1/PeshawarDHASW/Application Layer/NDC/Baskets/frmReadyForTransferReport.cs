using PeshawarDHASW.Application_Layer.CustomDialog;
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
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    public partial class frmReadyForTransferReport : Telerik.WinControls.UI.RadForm
    {
        public frmReadyForTransferReport()
        {
            InitializeComponent();
        }

        private void frmReadyForReport_Load(object sender, EventArgs e)
        {
            //LoadDataForBasket();
        }
        private void LoadDataForBasket()
        {
            try
            {
                SqlParameter[] prm =
                {
                    new SqlParameter("@Task","GetDataForTFR_Report"),
                    new SqlParameter("@TransferDate",dtpTransferDate.Value.Date)
                };
                DataSet ds = cls_dl_TFR.TranferRead(prm);
                grd_ReadyForReport.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LoadDataForBasket.", ex, "frmReadyForTransferReport");
                frmobj.ShowDialog();
            }
           
        }
        private void FillDataGrid(RadGridView grd, string qury)
        {
            grd.DataSource =
                SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.Text, qury).Tables[0].DefaultView;
        }

        private void grd_ReadyForReport_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                
                    int rowindex = grd_ReadyForReport.CurrentCell.RowIndex;
                    int ndcno = int.Parse(grd_ReadyForReport.Rows[rowindex].Cells[0].Value.ToString());
                    string fileNo = grd_ReadyForReport.Rows[rowindex].Cells[1].Value.ToString();
                    int TransferNo = int.Parse(grd_ReadyForReport.Rows[rowindex].Cells[2].Value.ToString());
                    int purchasetypeID = int.Parse(grd_ReadyForReport.Rows[rowindex].Cells[3].Value.ToString());
                    string sellerString = grd_ReadyForReport.Rows[rowindex].Cells[4].Value.ToString();
                    string buyerString = grd_ReadyForReport.Rows[rowindex].Cells[5].Value.ToString();
                    if (e.Column.Name == "ReadyForReport")
                    {
                      if( MessageBox.Show("Are You Sure that you Print the Transfer Images ???","Attention !!!",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
                      {
                        frmTransferReport frm = new frmTransferReport(fileNo, ndcno, purchasetypeID, TransferNo);
                        frm.ShowDialog();
                        LoadDataForBasket();
                       }
                    }
                    else if(e.Column.Name == "TFRImagePrint")
                    {
                      frmTransferReportImages frm = new frmTransferReportImages(fileNo, ndcno, purchasetypeID, TransferNo);
                      frm.ShowDialog();
                    }
                    else
                    {

                    }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on grd_ReadyForReport_CellClick.", ex, "frmReadyForTransferReport");
                frmobj.ShowDialog();
            }
           
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dtpTransferDate.Text))
            {
                LoadDataForBasket();
            }
            else
            {
                MessageBox.Show("Please select date.");
            }
           
        }
    }
}
