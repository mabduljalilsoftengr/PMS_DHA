using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Report.TelerikReport
{
    public partial class frmTelerikReport : Telerik.WinControls.UI.RadForm
    {
        public frmTelerikReport()
        {InitializeComponent();
        }

        private void data()
        {
            try
            {
            ReportSample objReport2 = new ReportSample();
            Telerik.Reporting.Table tableItem = ((Telerik.Reporting.Report)objReport2).Items[0].Items[0] as Telerik.Reporting.Table;
            Telerik.Reporting.ObjectDataSource obds = (Telerik.Reporting.ObjectDataSource)tableItem.DataSource;
            obds.DataSource = GetData();
            obds.DataMember = "Sample";
            Telerik.Reporting.InstanceReportSource irs = new Telerik.Reporting.InstanceReportSource();
            irs.ReportDocument = objReport2;
            SampleViewer.ReportSource = irs;
            SampleViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnSampleReport_Click(object sender, EventArgs e)
        {
            data();
        }

        private DataSet GetData()
        {
            SampleTR tr = new SampleTR();
            DataRow dr1 = tr.Sample.NewRow(); dr1["ID"] = 1; dr1["Name"] = "John"; dr1["Gender"] = "Male"; tr.Sample.Rows.Add(dr1);
            DataRow dr2 = tr.Sample.NewRow(); dr2["ID"] =2; dr2["Name"] = "Jalin"; dr2["Gender"] = "Male"; tr.Sample.Rows.Add(dr2);
            DataRow dr3 = tr.Sample.NewRow(); dr3["ID"] = 3; dr3["Name"] = "Atta"; dr3["Gender"] = "Male"; tr.Sample.Rows.Add(dr3);
            return tr;
        }
    }
}
