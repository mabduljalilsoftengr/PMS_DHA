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

namespace PeshawarDHASW.Application_Layer.DashBoards.frm_DashBoardDetail
{
    public partial class frm_SectorDetail : Telerik.WinControls.UI.RadForm
    {
        public frm_SectorDetail()
        {
            InitializeComponent();
        }
        public frm_SectorDetail(int SectorID, string PlotSize)
        {
            InitializeComponent();
            SqlParameter[] parameterdp = {
                new SqlParameter("@Task", "SectorWiseCompleteDetail"),
                new SqlParameter("@SectorID",Helper.clsPluginHelper.DbNullIfNullOrEmpty(SectorID.ToString())),
                new SqlParameter("@PlotSize",Helper.clsPluginHelper.DbNullIfNullOrEmpty(PlotSize))

            };
            DataSet dst = PeshawarDHASW.Data_Layer.Installment.cls_dl_FinanceDashBoard.InstallmentSummary_Reader(parameterdp);

            DGVSectorInformation.DataSource = dst.Tables[0].DefaultView;
            foreach (GridViewDataColumn column in DGVSectorInformation.Columns)
            {
                column.BestFit();
            }
        }

        private void frm_SectorDetail_Load(object sender, EventArgs e)
        {

        }

        private void DGVSectorInformation_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            #region This code is use to attach serial no. with grid , but in filtring,reOrdring etc the Serial No. order will be not disturbed
            if (e.CellElement.ColumnInfo.Name == "S.No" && string.IsNullOrEmpty(e.CellElement.Text))
            {
                e.CellElement.Text = (e.CellElement.RowIndex + 1).ToString();
            }
            #endregion
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(DGVSectorInformation);
        }
    }
}
