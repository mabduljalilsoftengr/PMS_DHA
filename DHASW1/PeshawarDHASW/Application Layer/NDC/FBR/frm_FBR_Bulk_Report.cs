using CrystalDecisions.CrystalReports.Engine;
using PeshawarDHASW.Report.Datasets.FBR_DataSet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.NDC.FBR
{
    public partial class frm_FBR_Bulk_Report : Telerik.WinControls.UI.RadForm
    {
        private DataSet dst { get; set; }
        private string srng { get; set; }
        public frm_FBR_Bulk_Report()
        {
            InitializeComponent();
        }
        public frm_FBR_Bulk_Report(DataSet ds,string str)
        {
            InitializeComponent();
            dst = ds;
            srng = str;
        }
       
        private void frm_FBR_Bulk_Report_Load(object sender, EventArgs e)
        {
            #region FBR Bulk Report 
            if(srng == "FBR_Bulk_Report_Dir")
            {
                ReportDocument rptdc = new ReportDocument();
                FBR_DataSet_dst FBR_ds = new FBR_DataSet_dst();
                FBR_ds.Tables["tbl_FBR_Bulk_Report"].Merge(dst.Tables[0], true, MissingSchemaAction.Ignore);

                string path1 = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\My_Reports\\FBR_Bulk_ReportDir.rpt";
                if (!string.IsNullOrEmpty(path1))
                {
                    rptdc.Load(path1);
                }

                FBR_ds.EnforceConstraints = true;
                rptdc.SetDataSource(FBR_ds);
                crvNDC.ReportSource = rptdc;
                crvNDC.Refresh();
            }
            else if (srng == "FBR_Bulk_Report")
            {
                ReportDocument rptdc = new ReportDocument();
                FBR_DataSet_dst FBR_ds = new FBR_DataSet_dst();
                FBR_ds.Tables["tbl_FBR_Bulk_Report"].Merge(dst.Tables[0], true, MissingSchemaAction.Ignore);

                string path1 = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\My_Reports\\FBR_Bulk_Report.rpt";
                if (!string.IsNullOrEmpty(path1))
                {
                    rptdc.Load(path1);
                }

                FBR_ds.EnforceConstraints = true;
                rptdc.SetDataSource(FBR_ds);
                crvNDC.ReportSource = rptdc;
                crvNDC.Refresh();
            }


            #endregion
        }
    }
}
