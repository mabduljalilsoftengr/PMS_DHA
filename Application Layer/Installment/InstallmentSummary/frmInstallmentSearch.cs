using PeshawarDHASW.Data_Layer.clsOwnerType;
using PeshawarDHASW.Data_Layer.Installment;
using PeshawarDHASW.Models;
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

namespace PeshawarDHASW.Application_Layer.Installment.InstallmentSummary
{
    public partial class frmInstallmentSearch : Telerik.WinControls.UI.RadForm
    {
        public frmInstallmentSearch()
        {
            InitializeComponent();
        }

        public void ApplyTheme(string themeName)
        {
            this.ThemeName = themeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, themeName);
        }
        private void themeapplying()
        {
            if (clsUser.ThemeName == String.Empty)
            {
                ApplyTheme("TelerikMetro");
            }
            else
            {
                ApplyTheme(clsUser.ThemeName);
            }
        }

        private void frmInstallmentSearch_Load(object sender, EventArgs e)
        {
            themeapplying();
            radPageView1.Pages.RemoveAt(2);
            drpPlanNo.Enabled = false;
            drpOwnerCategory.Enabled = false;
            btnBindData.Enabled = false;
            drp_plan_PlanWiseSearch.Enabled = false;
            InstallmentTemplateBinding(drpInstallmentTemp);
            InstallmentTemplateBinding(drp_instl_Tmplt);
            InstallmentTemplateBinding(drp_Inst_Tmplt_PlanWiseSearch);
            OwnerCategoryBinding();

        }
        private void OwnerCategoryBinding()
        {
            RadListDataItem select = new RadListDataItem();
            select.Value = 0;
            select.Text = "-- Select Owner Category --";
            this.drpOwnerCategory.Items.Add(select);
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","Select")
            };
            foreach (DataRow row in cls_dl_OwnerType.OwnerType_Reader(prm).Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["OCID"].ToString();
                dataItem.Text = row["Category_Name"].ToString();
                this.drpOwnerCategory.Items.Add(dataItem);
            }
            drpOwnerCategory.SelectedIndex = 0;


        }
        private void InstallmentTemplateBinding(RadDropDownList drp_lst)
        {
            RadListDataItem select = new RadListDataItem();
            select.Value = 0;
            select.Text = "-- Select Installment Template --";
            drp_lst.Items.Add(select);
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","select"),
            };
            foreach (DataRow row in clsInstallmentTemplate.InstalTemplate_Reader(prm).Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["InstalTempID"].ToString();
                dataItem.Text = row["TemplateName"].ToString();
                drp_lst.Items.Add(dataItem);
            }
            drp_lst.SelectedIndex = 0;
        }

        private void drpInstallmentTemp_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (drpInstallmentTemp.SelectedIndex > 0)
            {
                drpPlanNo.Enabled = true;
                if (drpPlanNo.Items.Count > 0)
                {
                    drpPlanNo.Items.Clear();
                }
                int isntTempNo = int.Parse(drpInstallmentTemp.SelectedValue.ToString());
                InstallmentPlanBinding(isntTempNo, drpPlanNo);
            }
        }
        private void InstallmentPlanBinding(int isntTempNo, RadDropDownList drp_lst_plan)
        {
            drp_plan_PlanWiseSearch.Items.Clear();
            RadListDataItem select = new RadListDataItem();
            select.Value = 0;
            select.Text = "-- Select Installment Plan --";
            drp_lst_plan.Items.Add(select);      //drp_Plano_PlanWiseSearch
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","select"),
                new SqlParameter("@instalTempID",isntTempNo)
            };
            foreach (DataRow row in cls_dl_instPlan.InstalPlanReader(prm).Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["PlanID"].ToString();
                dataItem.Text = row["Descp"].ToString();
                drp_lst_plan.Items.Add(dataItem);
            }
            drp_lst_plan.SelectedIndex = 0;
            drp_lst_plan.Enabled = true;
            //if (cls_dl_instPlan.InstalPlanReader(prm).Tables[0].Rows.Count > 0)
            //{
            //    drpOwnerCategory.Enabled = true;
            //}
        }
        private void btnBindData_Click(object sender, EventArgs e)
        {
            int inst_temp_no = int.Parse(drpInstallmentTemp.SelectedValue.ToString());
            int inst_plan_no = int.Parse(drpPlanNo.SelectedValue.ToString());
            int ownr_Category_id = int.Parse(drpOwnerCategory.SelectedValue.ToString());
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","InstallmentWise_Search"),
                new SqlParameter("@InstallmentTempNo",inst_temp_no),
                new SqlParameter("@InstallmentPlanNo",inst_plan_no),
                new SqlParameter("@OwnerCategoryNo",ownr_Category_id)
            };
            DataSet dst = new DataSet();
            dst = cls_dl_FinanceDashBoard.InstallmentWise_Search_Reader(prm);
            grdPaidInstallment.DataSource = dst.Tables.Count > 0 ? dst.Tables[0].DefaultView : null;
            grdNot_PaidInstallment.DataSource = dst.Tables[1].DefaultView;
        }

        private void drpOwnerCategory_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (drpOwnerCategory.SelectedIndex > 0)
            {
                btnBindData.Enabled = true;
            }
        }

        private void btn_Template_Wise_Find_Click(object sender, EventArgs e)
        {
            int inst_temp_no = int.Parse(drp_instl_Tmplt.SelectedValue.ToString());
            //int inst_plan_no = int.Parse(drpPlanNo.SelectedValue.ToString());
            //int ownr_Category_id = int.Parse(drpOwnerCategory.SelectedValue.ToString());
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","Template_Wise_Search"),
                new SqlParameter("@InstallmentTempNo",inst_temp_no),
            };
            DataSet dst = new DataSet();
            dst = cls_dl_FinanceDashBoard.InstallmentWise_Search_Reader(prm);
            grd_Template_wise_search.DataSource = dst.Tables.Count > 0 ? dst.Tables[0].DefaultView : null;
            grd_Template_wise_search.SummaryRowsBottom.Clear();
            Summary_Column_Template_Wise_Search();
        }

        private void drp_Inst_Tmplt_PlanWiseSearch_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            int instno = int.Parse(drp_Inst_Tmplt_PlanWiseSearch.SelectedValue.ToString());
            InstallmentPlanBinding(instno, drp_plan_PlanWiseSearch);
        }

        private void btn_PlanWiseSearch_Click(object sender, EventArgs e)
        {
            int inst_temp_no = int.Parse(drp_Inst_Tmplt_PlanWiseSearch.SelectedValue.ToString());
            int inst_plan_no = int.Parse(drp_plan_PlanWiseSearch.SelectedValue.ToString());
            SqlParameter[] prm =
            {new SqlParameter("@Task","Plan_wise_Search"),
                new SqlParameter("@InstallmentTempNo",inst_temp_no),
                new SqlParameter("@InstallmentPlanNo",inst_plan_no),
                new SqlParameter("@DateFrom",datefromplanwise.Value.Date),
                new SqlParameter("@DateTo",datetoplanwise.Value.Date)
            };
            DataSet dst = new DataSet();
            dst = cls_dl_FinanceDashBoard.InstallmentWise_Search_Reader(prm);
            grd_planWiseSearch.DataSource = dst.Tables.Count > 0 ? dst.Tables[0].DefaultView : null;
            grd_planWiseSearch.SummaryRowsBottom.Clear();
            Summary_Column_Plan_Wise_Search();
        }

        private void Summary_Column_Template_Wise_Search()
        {
            #region Summary Columns
            GridViewSummaryItem summaryItem = new GridViewSummaryItem();
            summaryItem.Name = "TotalDueAmount_t";
            summaryItem.Aggregate = GridAggregateFunction.Sum;
            summaryItem.FormatString = "{0:#,###0.00;(#,###0.00);0}";

            GridViewSummaryItem summaryItem1 = new GridViewSummaryItem();
            summaryItem1.Name = "ReceSum_t";
            summaryItem1.Aggregate = GridAggregateFunction.Sum;
            summaryItem1.FormatString = "{0:#,###0.00;(#,###0.00);0}";

            GridViewSummaryItem summaryItem3 = new GridViewSummaryItem();
            summaryItem3.Name = "RemainngAmount_t";
            summaryItem3.Aggregate = GridAggregateFunction.Sum;
            summaryItem3.FormatString = "{0:#,###0.00;(#,###0.00);0}";

            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
            summaryRowItem.Add(summaryItem);
            summaryRowItem.Add(summaryItem1);
            summaryRowItem.Add(summaryItem3);

            this.grd_Template_wise_search.SummaryRowsBottom.Add(summaryRowItem);
            grd_Template_wise_search.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;
            #endregion

        }
        private void Summary_Column_Plan_Wise_Search()
        {
            #region Summary Columns
            GridViewSummaryItem summaryItem = new GridViewSummaryItem();
            summaryItem.Name = "TotalDueAmount_p";
            summaryItem.Aggregate = GridAggregateFunction.Sum;
            summaryItem.FormatString = "{0:#,###0.00;(#,###0.00);0}";

            GridViewSummaryItem summaryItem1 = new GridViewSummaryItem();
            summaryItem1.Name = "ReceSum_p";
            summaryItem1.Aggregate = GridAggregateFunction.Sum;
            summaryItem1.FormatString = "{0:#,###0.00;(#,###0.00);0}";

            GridViewSummaryItem summaryItem3 = new GridViewSummaryItem();
            summaryItem3.Name = "RemainngAmount_p";
            summaryItem3.Aggregate = GridAggregateFunction.Sum;
            summaryItem3.FormatString = "{0:#,###0.00;(#,###0.00);0}";

            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
            summaryRowItem.Add(summaryItem);
            summaryRowItem.Add(summaryItem1);
            summaryRowItem.Add(summaryItem3);

            this.grd_planWiseSearch.SummaryRowsBottom.Add(summaryRowItem);
            grd_planWiseSearch.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;
            #endregion

        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(grd_planWiseSearch);
        }

        private void btnExcelExportofTemplateWise_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(grd_Template_wise_search);
        }
    }
}
