using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.Installment;
using PeshawarDHASW.Helper;
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
    public partial class frmFileWise_Summary : Telerik.WinControls.UI.RadForm
    {
        public frmFileWise_Summary()
        {
            InitializeComponent();
            themeapplying();
        }

        private void frmFileWise_Summary_Load(object sender, EventArgs e)
        {
            InstallmentTemplateBinding(drp_instl_Tmplt);
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
        private void InstallmentTemplateBinding(RadDropDownList drp_lst)
        {
            RadListDataItem select = new RadListDataItem();
            select.Value = 0;
            select.Text = "-- Select Installment Template --";
            drp_lst.Items.Add(select);
            DataSet ds = new DataSet();
            ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.Text, "Select [PlanGroupID],[Name] as GroupName from dbo.tbl_InstallmentTemplateGroup");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["PlanGroupID"].ToString();
                dataItem.Text = row["GroupName"].ToString();
                drp_lst.Items.Add(dataItem);
            }
            drp_lst.SelectedIndex = 0;
        }

        private void btn_Template_Wise_Find_Click(object sender, EventArgs e)
        {
            int inst_temp_no = int.Parse(drp_instl_Tmplt.SelectedValue.ToString());
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","File_Wise_Search"),
                new SqlParameter("@PlanGroupID",inst_temp_no),
            };
            DataSet dst = new DataSet();
            dst = cls_dl_FinanceDashBoard.InstallmentWise_Search_Reader(prm);
            grd_Template_wise_search.DataSource = dst.Tables.Count> 0 ? dst.Tables[0].DefaultView: null;
            grd_Template_wise_search.SummaryRowsBottom.Clear();
            Summary_Column_Template_Wise_Search();
            LoadingData_ColumnBestFit();
        }
        private void LoadingData_ColumnBestFit()
        {
            foreach (GridViewDataColumn column in grd_Template_wise_search.Columns)
            {
                column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
            }
            //  // richTextBox1.Text += "I was doing some work in the background.";
        }
        private void Summary_Column_Template_Wise_Search()
        {
            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
            foreach (GridViewDataColumn item in grd_Template_wise_search.Columns)
            {
                GridViewSummaryItem summaryItem = new GridViewSummaryItem();
                summaryItem.Name = item.Name;
                summaryItem.Aggregate = GridAggregateFunction.Sum;
                summaryItem.FormatString = "{0:#,###0.00;(#,###0.00);0}";
                summaryRowItem.Add(summaryItem);
            }
            #region Summary Columns
            this.grd_Template_wise_search.SummaryRowsBottom.Add(summaryRowItem);
            grd_Template_wise_search.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;
            #endregion

        }

        private void drp_instl_Tmplt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btn_Template_Wise_Find_Click(null, null);
            }
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(grd_Template_wise_search);
        }

        private void grd_Template_wise_search_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            try
            {

               string FileNo = grd_Template_wise_search.ChildRows[grd_Template_wise_search.CurrentRow.Index].Cells["FileNo"].Value.ToString();
                if (! string.IsNullOrEmpty( FileNo))
                {
                    frmAccountStatement obj = new frmAccountStatement(FileNo);
                    obj.ShowDialog();
                }
                
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on SearchDGV_CellClick.", ex, "frmMembershipSearch");
                //frmobj.ShowDialog();
            }
        }
    }
}
