using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Chalan
{
    public partial class frmChallanReportWindow : Telerik.WinControls.UI.RadForm
    {
        public frmChallanReportWindow()
        {
            InitializeComponent();
        }
        private DataSet dst { get; set; }
        public frmChallanReportWindow(DataSet ds)
        {
            InitializeComponent();
            dst = ds;
        }

        private void frmChallanReportWindow_Load(object sender, EventArgs e)
        {
            grdChallanData.DataSource = dst.Tables[0].DefaultView;
        }

        private void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(grdChallanData);
        }
    }
}
