using CrystalDecisions.CrystalReports.Engine;
using PeshawarDHASW.Report.Datasets.TFR_Dataset;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Transfer.TransferReport
{
    public partial class frm_Checklist_Report_Viewer : Telerik.WinControls.UI.RadForm
    {
        public frm_Checklist_Report_Viewer()
        {
            InitializeComponent();
        }
        private DataTable dtbl { get; set; }
        private string strchk { get; set; }
        public frm_Checklist_Report_Viewer(DataTable dt,string str)
        {
            InitializeComponent();
            dtbl = dt;
            strchk = str;
        }

        private void frm_Checklist_Report_Viewer_Load(object sender, EventArgs e)
        {
            if(strchk == "ChecklistReport")
            {
                #region Check List Report
                ReportDocument rptdoc = new ReportDocument();
                TFRChecklistDataSet tfrchkds = new TFRChecklistDataSet();
                tfrchkds.Tables["tblTFRChecklist"].Merge(dtbl, true, MissingSchemaAction.Ignore);
                string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\My_Reports\\TFRChecklistReport.rpt";
                if (!string.IsNullOrEmpty(path))
                {
                    rptdoc.Load(path);
                }
                rptdoc.SetDataSource(tfrchkds);
                crvChecklist.ReportSource = rptdoc;
                crvChecklist.Refresh();
                strchk = "";
                #endregion
            }
            else if(strchk == "TFRSlipReprt")
            {
                try
                {
                    #region TFR Slips Report
                    ReportDocument rptdoc = new ReportDocument();
                TFRChecklistDataSet tfrchkds = new TFRChecklistDataSet();
                tfrchkds.Tables["tblTFRSlips"].Merge(dtbl, true, MissingSchemaAction.Ignore);
                string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\My_Reports\\TFRSlipsReport.rpt";
                if (!string.IsNullOrEmpty(path))
                {
                    rptdoc.Load(path);
                }
                rptdoc.SetDataSource(tfrchkds);
                crvChecklist.ReportSource = rptdoc;
                crvChecklist.Refresh();
                strchk = "";
                #endregion
                }
                    catch (Exception ex)
                {
                
                    MessageBox.Show(ex.Message);
                }
            }
            else if(strchk == "TFRSlipReprtOfficeCopy")
            {
                try
                {
                    #region TFR Slips Report office copy
                    ReportDocument rptdoc1 = new ReportDocument();
                TFRChecklistDataSet tfrchkds_ = new TFRChecklistDataSet();
                tfrchkds_.Tables["tblTFRSlips"].Merge(dtbl, true, MissingSchemaAction.Ignore);
                string path1 = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\My_Reports\\TFRSlipsReport_OfficeCopy.rpt";
                if (!string.IsNullOrEmpty(path1))
                {
                    rptdoc1.Load(path1);
                }
                rptdoc1.SetDataSource(tfrchkds_);
                crvChecklist.ReportSource = rptdoc1;
                crvChecklist.Refresh();
                strchk = "";
                    #endregion
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            else if(strchk == "QuestionareReport")
            {
                try
                {
                    #region TFR Slips Report office copy
                    ReportDocument rptdoc1 = new ReportDocument();
                    TFRChecklistDataSet tfrchkds_ = new TFRChecklistDataSet();
                    tfrchkds_.Tables["tblTFRSlips"].Merge(dtbl, true, MissingSchemaAction.Ignore);
                    string path1 = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\My_Reports\\TFRSlipsReportQuestionare.rpt";
                    if (!string.IsNullOrEmpty(path1))
                    {
                        rptdoc1.Load(path1);
                    }
                    rptdoc1.SetDataSource(tfrchkds_);
                    crvChecklist.ReportSource = rptdoc1;
                    crvChecklist.Refresh();
                    strchk = "";
                    #endregion
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
               
            }

        }
    }
}
