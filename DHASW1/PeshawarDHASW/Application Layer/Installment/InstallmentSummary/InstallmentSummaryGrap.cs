using PeshawarDHASW.Data_Layer.Installment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.Charting;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Installment.InstallmentSummary
{
    public partial class InstallmentSummaryGrap : Telerik.WinControls.UI.RadForm
    {
        public InstallmentSummaryGrap()
        {
            InitializeComponent();
        }

        private void drpInstallmentTemplate_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
           
            if (drpInstallmentTemplate.SelectedIndex > 0)
            {
                radChartView1.Series.Clear();
               
                int istallment_id = int.Parse(drpInstallmentTemplate.SelectedValue.ToString());
                SqlParameter[] prm =
                {
                    new SqlParameter("@Task","InstallmentTemplateSummary"),
                    new SqlParameter("@InstallmentTempNo",istallment_id)
                };
                DataSet dst = new DataSet();
                dst = cls_dl_FinanceDashBoard.InstallmentSummary_Reader(prm);
                FastLineSeries series = new FastLineSeries();
                series.LabelDistanceToPoint = 1;
                FastLineSeries series1 = new FastLineSeries();
                foreach (DataRow row in dst.Tables[0].Rows)
                {
                   
                    int count = int.Parse(row["PlanSum"].ToString());
                    int receamount = 0;
                    bool ReceSum = int.TryParse(row["ReceAmount"].ToString(),out receamount);
                    series.DataPoints.Add(new CategoricalDataPoint(count, row["Descp"].ToString()));
                    series1.DataPoints.Add(new CategoricalDataPoint(receamount, row["Descp"].ToString()));

                    series.ShowLabels = true;
                }
                radChartView1.Series.Add(series);
                radChartView1.Series.Add(series1);
            }

            //series.DataSource = ds.Tables[0].DefaultView;
           
            //CartesianArea area = this.radChartView1.GetArea();
            //area.ShowGrid = true;
            //this.drpInstallmentTemplate.SelectedIndex = 0;
            //LinearAxis verticalAcix = new LinearAxis();
            //verticalAcix.AxisType = AxisType.Second;
            //CategoricalAxis horizontalAxis = new CategoricalAxis();
            //PerformanceModel model = new PerformanceModel();
            //for (int i = 0; i < 4; i++)
            //{
            //    BarSeries barSeries = new BarSeries("Performance", "RepresentativeName");
            //    barSeries.Name = "Q" + (i + 1);
            //    barSeries.HorizontalAxis = horizontalAxis;
            //    barSeries.VerticalAxis = verticalAcix;
            //    barSeries.DataSource = model.GetData(i);
            //    this.radChartView1.Series.Add(barSeries);
            //    foreach (DataPointElement pointElement in barSeries.Children)
            //    { pointElement.BorderWidth = 0; }
            //}

        }

        private void InstallmentTemplateBinding()
        {
            RadListDataItem Select = new RadListDataItem();
            Select.Value = 0;
            Select.Text = "-- Select Installment Template --";
            this.drpInstallmentTemplate.Items.Add(Select);

            SqlParameter[] prm =
            {
                new SqlParameter("@Task","select"),
            };
            foreach (DataRow row in clsInstallmentTemplate.InstalTemplate_Reader(prm).Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["InstalTempID"].ToString();
                dataItem.Text = row["TemplateName"].ToString();
                this.drpInstallmentTemplate.Items.Add(dataItem);
            }
            drpInstallmentTemplate.SelectedIndex = 0;
        }

        private void InstallmentSummaryGrap_Load(object sender, EventArgs e)
        {
            InstallmentTemplateBinding();
        }

        private void radChartView1_Click(object sender, EventArgs e)
        {
            }
    }
}
