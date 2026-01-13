using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.FileMap.ByBack
{
    public partial class frmLandProviderQuoaDetail_Specific : Telerik.WinControls.UI.RadForm
    {
        public frmLandProviderQuoaDetail_Specific()
        {
            InitializeComponent();
        }
        private DataSet dst { get; set; }
        public frmLandProviderQuoaDetail_Specific( DataSet ds)
        {
            InitializeComponent();
            dst = ds;
            grddata.DataSource = dst.Tables[0].DefaultView;
        }
        private void frmLandProviderQuoaDetail_Specific_Load(object sender, EventArgs e)
        {
            #region Summary Row
            GridViewSummaryItem summaryItem1 = new GridViewSummaryItem();
            summaryItem1.Name = "ByBackQuota";
            summaryItem1.Aggregate = GridAggregateFunction.Sum;
            //summaryItem1.FormatString = "{0:#,###0.00;(#,###0.00);0}";

            GridViewSummaryItem summaryItem = new GridViewSummaryItem();
            summaryItem.Name = "TotalReceivedAmountFromCust";
            summaryItem.Aggregate = GridAggregateFunction.Sum;
            //summaryItem.FormatString = "{0:#,###0.00;(#,###0.00);0}";
            
            GridViewSummaryItem summaryItem2 = new GridViewSummaryItem();
            summaryItem2.Name = "Amount";
            summaryItem2.Aggregate = GridAggregateFunction.Sum;
            //summaryItem1.FormatString = "{0:#,###0.00;(#,###0.00);0}";

            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
            summaryRowItem.Add(summaryItem);
            summaryRowItem.Add(summaryItem1);
            summaryRowItem.Add(summaryItem2);
            this.grddata.SummaryRowsBottom.Add(summaryRowItem);
            #endregion
            //lbltotalquota.Text = dst.Tables[1].Rows[0]["TotalNewQuotaAdded"].ToString();
            //lblbybackquota.Text = dst.Tables[1].Rows[0]["TotalByBackQuota"].ToString();
            //lblremainigquota.Text = dst.Tables[1].Rows[0]["RemainingQUota"].ToString();
        }
    }
}
