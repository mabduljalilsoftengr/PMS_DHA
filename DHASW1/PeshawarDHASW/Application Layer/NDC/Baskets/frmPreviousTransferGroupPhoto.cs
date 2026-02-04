using CrystalDecisions.CrystalReports.Engine;
using PeshawarDHASW.Report.Datasets.NDC_DataSet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    public partial class frmPreviousTransferGroupPhoto : Telerik.WinControls.UI.RadForm
    {
        private DataTable dtb { get; set; }
        public frmPreviousTransferGroupPhoto()
        {
            InitializeComponent();
        }
        public frmPreviousTransferGroupPhoto( DataTable dtbl)
        {
            InitializeComponent();
            dtb = dtbl;
        }
        private void frmPreviousNDC_TFRLetter_Image_Print_Load(object sender, EventArgs e)
        {
            NDC_DataSet dstndc = new NDC_DataSet();
            dstndc.Tables[3].Merge(dtb, true, MissingSchemaAction.Ignore);
            ReportDocument rdp = new ReportDocument();
            string _path = System.Windows.Forms.Application.StartupPath + "\\Report\\My_Reports\\TFRLetter_GroupImage.rpt";
            rdp.Load(_path);
            rdp.SetDataSource(dstndc.Tables[3]);
            crystalReportViewer1.ReportSource = rdp;
            crystalReportViewer1.Refresh();
        }
    }
}
