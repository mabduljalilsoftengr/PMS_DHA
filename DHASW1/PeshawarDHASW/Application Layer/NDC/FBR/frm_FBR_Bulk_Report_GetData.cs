using CrystalDecisions.CrystalReports.Engine;
using PeshawarDHASW.Application_Layer.NDC.Baskets;
using PeshawarDHASW.Data_Layer.clsFileMap;
using PeshawarDHASW.Data_Layer.clsPlotSize;
using PeshawarDHASW.Data_Layer.NDC;
using PeshawarDHASW.Report.Datasets.FBR_DataSet;
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

namespace PeshawarDHASW.Application_Layer.NDC.FBR
{
    public partial class frm_FBR_Bulk_Report_GetData : Telerik.WinControls.UI.RadForm
    {
        private DataSet dst1 { get; set; }
        public frm_FBR_Bulk_Report_GetData()
        {
            InitializeComponent();
        }

        private void frm_FBR_Bulk_Report_Load(object sender, EventArgs e)
        {
            if(Models.clsUser.ID == 3 || Models.clsUser.ID == 35)
            {
                btnReportDir.Enabled = true;
            }
            else
            {
                btnReportDir.Enabled = false;
            }

            LoadPlotSize();
            LoadCategory();
        }
        private void LoadCategory()
        {
            RadListDataItem Select = new RadListDataItem();
            Select.Value = 0;
            Select.Text = "-- Select --";
            this.drpCategory.Items.Add(Select);
            SqlParameter[] prm1 =
            {
                new SqlParameter("@Task","Select")
            };
            DataSet dst = cls_dl_FileMap.Fil_ddl_Owner_Category(prm1);

            foreach (DataRow row in dst.Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["OCID"].ToString();
                dataItem.Text = row["Category_Name"].ToString();
                this.drpCategory.Items.Add(dataItem);
            }
            drpCategory.SelectedIndex = 0;
        }
        private void LoadPlotSize()
        {
            RadListDataItem Select = new RadListDataItem();
            Select.Value = 0;
            Select.Text = "-- Select --";
            this.drpPlotSize.Items.Add(Select);
            SqlParameter[] prm1 =
            {
                new SqlParameter("@Task","Select")
            };
            DataSet dst = cls_dl_PlotSize.PlotSize_Reader(prm1);

            foreach (DataRow row in dst.Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["ID"].ToString();
                dataItem.Text = row["PlotSize"].ToString();
                this.drpPlotSize.Items.Add(dataItem);
            }
            drpPlotSize.SelectedIndex = 0;
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (dtpFromDate.Text != "" || dtpToDate.Text != "")
            {
                string pltsize = drpPlotSize.SelectedItem.ToString() == "" || drpPlotSize.SelectedItem.ToString() == "-- Select --" ? null : drpPlotSize.SelectedItem.ToString();
                string category = drpCategory.SelectedItem.ToString() == "" || drpCategory.SelectedItem.ToString() == "-- Select --" ? null : drpCategory.SelectedItem.ToString();
                string stat = drpstatus.Text == "" | drpstatus.Text == "-- Select Status --" ? null : drpstatus.Text;
                SqlParameter[] prm =
                {
                    new SqlParameter("@Task","FBR_Bulk_Report"),
                    new SqlParameter("@FromDate",dtpFromDate.Value),
                    new SqlParameter("@ToDate",dtpToDate.Value),
                    new SqlParameter("@PlotSize",pltsize),
                    new SqlParameter("@FileNo",txtFileNo.Text=="" ? null :txtFileNo.Text),
                    new SqlParameter("@Category",category),
                    new SqlParameter("@Status",stat)
                };
                dst1 = cls_dl_NDC.NdcRetrival(prm);
                grdFBRReportData.DataSource = dst1.Tables[0].DefaultView;
            }
            else
            {
                MessageBox.Show("From Date and To Date both are necessary.");
            }
        }

        private void btnReportDir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dst1.Tables[0].Rows.Count > 0)
                {
                    frm_FBR_Bulk_Report frmobj = new frm_FBR_Bulk_Report(dst1, "FBR_Bulk_Report_Dir");
                    frmobj.ShowDialog();
                }
                else
                {
                    MessageBox.Show("There is no record for report.");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dst1.Tables[0].Rows.Count > 0)
                {
                    dst1.Tables[0].Columns.Add("FromDate", typeof(System.DateTime));
                    dst1.Tables[0].Columns.Add("ToDate", typeof(System.DateTime));
                    foreach (DataRow row in dst1.Tables[0].Rows)
                    {
                        row["FromDate"] = dtpFromDate.Value.Date;
                        row["ToDate"] = dtpToDate.Value.Date;
                    }
                    frm_FBR_Bulk_Report frmobj = new frm_FBR_Bulk_Report(dst1, "FBR_Bulk_Report");
                    frmobj.ShowDialog();
                }
                else
                {
                    MessageBox.Show("There is no record for report.");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void grdFBRReportData_CellFormatting(object sender, CellFormattingEventArgs e)
        {

            if (e.CellElement.ColumnInfo.Name == "SNo")
            {
                e.CellElement.Text = (e.CellElement.RowIndex + 1).ToString();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(grdFBRReportData);
        }
    }
}
