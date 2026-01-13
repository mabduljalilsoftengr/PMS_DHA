using CrystalDecisions.CrystalReports.Engine;
using PeshawarDHASW.Report.Datasets.Posession_DataSet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.PlotsPosession
{
    public partial class frrmRepot_DuesRemainingUptoPosesion : Telerik.WinControls.UI.RadForm
    {
        private DataTable dtbl { get; set; }
        public frrmRepot_DuesRemainingUptoPosesion()
        {
            InitializeComponent();
        }
        public frrmRepot_DuesRemainingUptoPosesion(DataTable dbl)
        {
            InitializeComponent();
            dtbl = dbl;

        }

        private void frrmRepot_DuesRemainingUptoPosesion_Load(object sender, EventArgs e)
        {
            ReportDocument rptdoc = new ReportDocument();
            Posession_Dataset POS_ds = new Posession_Dataset();
            POS_ds.Tables["tbl_UptoPosessionDueRemaining"].Merge(dtbl, true, MissingSchemaAction.Ignore);

            string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\My_Reports\\PosessionReport\\DuesReaminingUptPosessionApply.rpt";
            if (!string.IsNullOrEmpty(path))
            {
                rptdoc.Load(path);
            }

            //NDC_ds.EnforceConstraints = true;
            rptdoc.SetDataSource(POS_ds);
            crpvPosessionReport.ReportSource = rptdoc;
            crpvPosessionReport.Refresh();
        }
    }
}
