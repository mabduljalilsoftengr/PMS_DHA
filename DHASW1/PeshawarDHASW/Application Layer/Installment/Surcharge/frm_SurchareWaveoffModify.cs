using PeshawarDHASW.Data_Layer.Installment;
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

namespace PeshawarDHASW.Application_Layer.Installment.Surcharge
{
    public partial class frm_SurchareWaveoffModify : Telerik.WinControls.UI.RadForm
    {
        public frm_SurchareWaveoffModify()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            SqlParameter[] param = {
                                    new SqlParameter("@Task","SurchargeSearch"),
                                    new SqlParameter("@FileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtFileNo.Text)),
                                    new SqlParameter("@MembershipNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtMembershipNo.Text)),
                                    new SqlParameter("@PlotNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtPlot.Text))
                                   };
            DataSet ds = cls_dl_Surcharge.Surcharge_Reader(param);
            DGVSurchargeSearch.DataSource = ds.Tables[0].DefaultView;

            #region Summary Columns
            /*GridViewSummaryItem summaryItem = new GridViewSummaryItem();
            summaryItem.Name = "TotalSurcharge";
            summaryItem.Aggregate = GridAggregateFunction.Sum;
            summaryItem.FormatString = "{0:#,###0.00;(#,###0.00);0}";

            GridViewSummaryItem summaryItem1 = new GridViewSummaryItem();
            summaryItem1.Name = "WaveoffAmount";
            summaryItem1.Aggregate = GridAggregateFunction.Sum;
            summaryItem1.FormatString = "{0:#,###0.00;(#,###0.00);0}";

            GridViewSummaryItem summaryItem3 = new GridViewSummaryItem();
            summaryItem3.Name = "TotalDueSurcharge";
            summaryItem3.Aggregate = GridAggregateFunction.Sum;
            summaryItem3.FormatString = "{0:#,###0.00;(#,###0.00);0}";

            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
            summaryRowItem.Add(summaryItem);
            summaryRowItem.Add(summaryItem1);
            summaryRowItem.Add(summaryItem3);

            DGVSurchargeSearch.SummaryRowsBottom.Add(summaryRowItem);*/
            #endregion
        }

        private void DGVSurchargeSearch_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column == null)
                return;
            if (e.Column.Name == "btnView")
            {

                //if (e.Row.Cells["ApprovalStatus"].Value.ToString() == "Approved")
                //{
                //    MessageBox.Show("Modification ");

                //    return;
                //}
                string FileNo = e.Row.Cells["FileNo"].Value.ToString();
                if (filechecker(FileNo) > 0)
                {
                    frm_SurchargeWaveoffModifybyFile obj = new frm_SurchargeWaveoffModifybyFile(FileNo);
                    obj.ShowDialog();
                    btnFind_Click(null, null);
                }
                else
                {
                    MessageBox.Show("FileNo / Plot have no Wavier off exist. Visit to New Surcharge Wavieroff Apply");
                }
            }
        }

        private int filechecker(string FileNo)
        {
            SqlParameter[] parmExisitng = {
                    new SqlParameter("@Task","FileExistChecking"),
                    new SqlParameter("@FileNo",FileNo)
            };

            int counter = 0;
            bool checker = int.TryParse(Helper.SQLHelper.ExecuteScalar(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_SurchargeWaveoff", parmExisitng).ToString(), out counter);
            return counter;
        }

        private void frm_SurchareWaveoffModify_Load(object sender, EventArgs e)
        {

        }

        private void txtFileNo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab || e.KeyData == Keys.Enter)
            {
                btnFind_Click(null, null);
            }
        }
    }
}
