using CrystalDecisions.CrystalReports.Engine;
using PeshawarDHASW.Data_Layer.NDC;
using PeshawarDHASW.Report.Datasets.NDC_DataSet;
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
    public partial class frmNDC_Checklist_ReportForm : Telerik.WinControls.UI.RadForm
    {
        private int NDCNo { get; set; }
        public frmNDC_Checklist_ReportForm()
        {
            InitializeComponent();
        }
        public frmNDC_Checklist_ReportForm(int ndcn)
        {
            InitializeComponent();
            NDCNo = ndcn;
        }

        private void frmNDC_Checklist_ReportForm_Load(object sender, EventArgs e)
        {
            GenerateNDCChecklistReport();
        }
        private void GenerateNDCChecklistReport()
        {
            ReportDocument rptdoc = new ReportDocument();
            NDC_DataSet NDC_ds = new NDC_DataSet();
            #region Calculation of Other Charges for Checklist Print
            SqlParameter[] par =
            {
                new SqlParameter("@Task","Calculation_Of_UrgentCharges_ChecklistPrint"),
                new SqlParameter("@NDCNo",NDCNo)
                };
            DataSet ds_ = cls_dl_NDC.NdcRetrival(par);
            NDC_ds.Tables[4].Merge(ds_.Tables[0], true, MissingSchemaAction.Ignore);
            #endregion
            #region Checklist Report
            string path_ = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\My_Reports\\NDC_Checklist_Report.rpt";
            if (!string.IsNullOrEmpty(path_))
            {
                rptdoc.Load(path_);
            }

            rptdoc.SetDataSource(NDC_ds.Tables[4]);
            NDCChecklistReportViwer.ReportSource = rptdoc;
            NDCChecklistReportViwer.Refresh();
            #endregion
        }
    }
}
