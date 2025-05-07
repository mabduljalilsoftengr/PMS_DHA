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
    public partial class frm_SurchargeWaveoffSearch : Telerik.WinControls.UI.RadForm
    {
        public frm_SurchargeWaveoffSearch()
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
        }

        private void frm_SurchargeWaveoffSearch_Load(object sender, EventArgs e)
        {
            #region Summary Columns
            GridViewSummaryItem summaryItem = new GridViewSummaryItem();
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

            DGVSurchargeSearch.SummaryRowsBottom.Add(summaryRowItem);
            #endregion
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
