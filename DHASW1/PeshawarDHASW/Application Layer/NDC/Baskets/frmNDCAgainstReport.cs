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
    public partial class frmNDCAgainstReport : Telerik.WinControls.UI.RadForm
    {
        public frmNDCAgainstReport()
        {
            InitializeComponent();
        }

        private void frmNDCAgainstReport_Load(object sender, EventArgs e)
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
                    grdFBRSellerBuyerData.DataSource = dst.Tables[1].DefaultView;
                    grdFBRCPRData.DataSource = dst.Tables[2].DefaultView;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
    }
}
