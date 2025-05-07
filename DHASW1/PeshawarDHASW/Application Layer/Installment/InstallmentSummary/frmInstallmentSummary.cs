using PeshawarDHASW.Data_Layer.Installment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Installment.InstallmentSummary
{
    public partial class frmInstallmentSummary : Telerik.WinControls.UI.RadForm
    {
        public frmInstallmentSummary()
        {
            InitializeComponent();
        }
        private void drpInstallmentTemplate_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {   if(drpInstallmentTemplate.SelectedIndex > 0)
            {
               if( this.grdInstallmentTemplate.SummaryRowsBottom.Count > 0)
                {
                    this.grdInstallmentTemplate.SummaryRowsBottom.Clear();
                }
                int istallment_id = int.Parse(drpInstallmentTemplate.SelectedValue.ToString());
                SqlParameter[] prm =
                {
                    new SqlParameter("@Task","FinanceSummary"),
                    new SqlParameter("@InstallmentTempNo",istallment_id)
                };
                DataSet dst = new DataSet();                
                dst = Data_Layer.Installment.cls_dl_FinanceDashBoard.InstallmentSummary_Reader(prm);
                grdInstallmentTemplate.DataSource = dst.Tables[0].DefaultView;
                /////////////////////////////////////////// Total Sum ////////////////////////////

                //GridViewSummaryItem summaryItem = new GridViewSummaryItem();
                //summaryItem.Name = "PlanSum";
                //summaryItem.Aggregate = GridAggregateFunction.Sum;

                //GridViewSummaryItem summaryItem1 = new GridViewSummaryItem();
                //summaryItem1.Name = "ReceAmount";
                //summaryItem1.Aggregate = GridAggregateFunction.Sum;

                //GridViewSummaryItem summaryItem2 = new GridViewSummaryItem();
                //summaryItem2.Name = "NotReceive";
                //summaryItem2.Aggregate = GridAggregateFunction.Sum;

                //GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
                //summaryRowItem.Add(summaryItem);
                //summaryRowItem.Add(summaryItem1);
                //summaryRowItem.Add(summaryItem2);

                //this.grdInstallmentTemplate.SummaryRowsBottom.Add(summaryRowItem);


                /////////////////////////////////////////
                //GridViewSummaryItem summaryPlanTotal = new GridViewSummaryItem("PlanSum", " Plan Sum : {0} ", GridAggregateFunction.Sum);
                //this.grdInstallmentTemplate.MasterTemplate.SummaryRowsBottom.Add(new GridViewSummaryRowItem(new GridViewSummaryItem[] { summaryPlanTotal }));

                //GridViewSummaryItem summaryRecieveTotal = new GridViewSummaryItem("ReceAmount", " Recieve Sum : {0} ", GridAggregateFunction.Sum);
                //this.grdInstallmentTemplate.MasterTemplate.SummaryRowsBottom.Add(new GridViewSummaryRowItem(new GridViewSummaryItem[] { summaryRecieveTotal }));

                //GridViewSummaryItem summaryNotRecieveTotal = new GridViewSummaryItem("NotReceive", " Not-Receive Sum : {0} ", GridAggregateFunction.Sum);
                //this.grdInstallmentTemplate.MasterTemplate.SummaryRowsBottom.Add(new GridViewSummaryRowItem(new GridViewSummaryItem[] { summaryNotRecieveTotal }));

                ///////////////////////////////////////// Count //////////////////////////////////

                //GridViewSummaryItem summary = new GridViewSummaryItem("Country", " Count: {0} ", GridAggregateFunction.Count);
                //this.grdInstallmentTemplate.MasterTemplate.SummaryRowGroupHeaders.Add( new GridViewSummaryRowItem(new GridViewSummaryItem[] { summary }));

            }
        }
        private void frmInstallmentSummary_Load(object sender, EventArgs e)
        {
            InstallmentTemplateBinding();
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

        private void grdInstallmentTemplate_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement.RowInfo is GridViewSummaryRowInfo && e.CellElement.ColumnIndex == 3)
            {
                e.CellElement.DrawFill = true;
                e.CellElement.GradientStyle = GradientStyles.Solid;
                e.CellElement.BackColor = Color.CadetBlue;
                e.CellElement.Font = new Font(e.CellElement.Font, FontStyle.Bold);
            }

            if (e.CellElement.RowInfo is GridViewSummaryRowInfo && e.CellElement.ColumnIndex == 4)
            {
                e.CellElement.DrawFill = true;
                e.CellElement.GradientStyle = GradientStyles.Solid;
                e.CellElement.BackColor = Color.BurlyWood;
                e.CellElement.Font = new Font(e.CellElement.Font, FontStyle.Bold);
            }

            if (e.CellElement.RowInfo is GridViewSummaryRowInfo && e.CellElement.ColumnIndex == 5)
            {
                e.CellElement.DrawFill = true;
                e.CellElement.GradientStyle = GradientStyles.Solid;
                e.CellElement.BackColor = Color.Chartreuse;
                e.CellElement.Font = new Font(e.CellElement.Font, FontStyle.Bold);
            }
        }

        private void btnexcelexport_Click(object sender, EventArgs e)
        {
           Helper.clsPluginHelper.GridViewData_Export_to_Excel(grdInstallmentTemplate);
        }

      
    }
}

