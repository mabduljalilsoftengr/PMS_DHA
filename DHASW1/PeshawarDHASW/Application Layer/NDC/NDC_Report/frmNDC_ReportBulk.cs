using PeshawarDHASW.Application_Layer.NDC.Baskets;
using PeshawarDHASW.Data_Layer.clsPlotSize;
using PeshawarDHASW.Data_Layer.NDC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.NDC.NDC_Report
{
    public partial class frmNDC_ReportBulk : Telerik.WinControls.UI.RadForm
    {
        private DataSet dst { get; set; }
        public frmNDC_ReportBulk()
        {
            InitializeComponent();
        }

        private void radGroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
               if(dtpFromDate.Text != "" || dtpToDate.Text != "")
                {
                    string pltsize = drpPlotSize.SelectedItem.ToString() == "" || drpPlotSize.SelectedItem.ToString() == "-- Select --" ? null : drpPlotSize.SelectedItem.ToString();
                    string ndcstatus = drpNDCStatus.SelectedItem.ToString() == "" || drpNDCStatus.SelectedItem.ToString() == "-- Select --" ? null : drpNDCStatus.SelectedItem.ToString();
                    string urnr = drpUrgntNrml.Text == "" || drpUrgntNrml.Text == "-- Select Type --" ? null : drpUrgntNrml.SelectedItem.ToString();
                    string hbnm = drpHibaNormal.Text == "" || drpHibaNormal.Text == "-- Select Type --" ? null : drpHibaNormal.SelectedItem.ToString();
                    string Cat_Name = drpownercat.Text == "" || drpownercat.Text == "-- Select Type --" ? null : drpownercat.SelectedItem.ToString();
                    string plttype = ddlplottype.SelectedItem.ToString() == "" || ddlplottype.SelectedItem.ToString() == "-- Select --" ? null : ddlplottype.SelectedItem.ToString();
                    

                    SqlParameter[] prm =
                    {
                    new SqlParameter("@Task","NDCBulkReport"),
                    new SqlParameter("@FromDate",dtpFromDate.Value),
                    new SqlParameter("@ToDate",dtpToDate.Value),
                    new SqlParameter("@PlotSize",pltsize),
                    new SqlParameter("@StatusofNDC",ndcstatus),
                    new SqlParameter("@NDCTypeNormalUrgent",urnr),
                    new SqlParameter("@NDCType",hbnm),
                    new SqlParameter("@FileNo",txtFileNo.Text == "" ?null:txtFileNo.Text),
                    new SqlParameter("@Type",plttype),
                    new SqlParameter("@Category_Name",Cat_Name)
                    };
                    dst = cls_dl_NDC.NdcRetrival(prm);

                    if (dst.Tables[0].Rows.Count > 0)
                    {
                        grdNDCBulkRpt.DataSource = dst.Tables[0].DefaultView;
                    }
                    else
                    {
                        grdNDCBulkRpt.DataSource = null;
                        MessageBox.Show("There is no record for such filter.");
                     
                    }

                }
                else
                {
                    grdNDCBulkRpt.DataSource = null;
                    MessageBox.Show("From Date and To Date both are necessary.");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            


        }

        private void frmNDC_ReportBulk_Load(object sender, EventArgs e)
        {
            LoadPlotSize();
            LoadNDCStatus();
            LoadOwnerCat();
            drpUrgntNrml.SelectedIndex = 0;
            drpHibaNormal.SelectedIndex = 0;
            ddlplottype.SelectedIndex = 0;
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
        private void LoadOwnerCat()
        {
            RadListDataItem Select = new RadListDataItem();
            Select.Value = 0;
            Select.Text = "-- Select Type --";
            this.drpownercat.Items.Add(Select);
            SqlParameter[] prm1 =
            {
                new SqlParameter("@Task","GetOwnerCategory")
            };
            DataSet dst = cls_dl_PlotSize.PlotSize_Reader(prm1);

            foreach (DataRow row in dst.Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["OCID"].ToString();
                dataItem.Text = row["Category_Name"].ToString();
                this.drpownercat.Items.Add(dataItem);
            }
            drpownercat.SelectedIndex = 0;
        }
        private void LoadNDCStatus()
        {
            RadListDataItem Select = new RadListDataItem();
            Select.Value = 0;
            Select.Text = "-- Select --";
            this.drpNDCStatus.Items.Add(Select);
            SqlParameter[] prm1 =
            {
                new SqlParameter("@Task","Select_NDC_Statuses")
            };
            DataSet dst = cls_dl_NDC.NdcRetrival(prm1);

            foreach (DataRow row in dst.Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["NDCNo"].ToString();
                dataItem.Text = row["StatusofNDC"].ToString();
                this.drpNDCStatus.Items.Add(dataItem);
            }
            drpNDCStatus.SelectedIndex = 0;
        }

        private void btnrpt_Click(object sender, EventArgs e)
        {
            if(dst.Tables[0].Rows.Count > 0)
            {
                //dst.Tables[0].Columns.Remove("FromDate");
                //dst.Tables[0].Columns.Remove("ToDate");
                dst.Tables[0].Columns.Add("FromDate", typeof(System.DateTime));
                dst.Tables[0].Columns.Add("ToDate", typeof(System.DateTime));
                #region data table
                DataTable dt = new DataTable();
                dt.Clear();
                dt.Columns.Add("PlotSize");
                #endregion


                foreach (DataRow row in dst.Tables[0].Rows)
                {
                    row["FromDate"] = dtpFromDate.Value.Date;   
                    row["ToDate"] = dtpToDate.Value.Date;

                    DataRow ro = dt.NewRow();
                    ro["PlotSize"] = row["PlotSize"];
                    dt.Rows.Add(ro);
                }

                List<String> orderedJobTitles = dt.AsEnumerable()
                                                .Select(dr => dr.Field<string>("PlotSize"))
                                                .Distinct()
                                                .ToList();

                DataTable dtbl = ConvertListToDataTable(orderedJobTitles);

                if(dtbl.Rows.Count > 1)
                {
                    // Updtae Query For Plot Size
                   // dst.Tables[0].Rows[0]["PlotSize"] = "All";
                    foreach (DataRow ord in dst.Tables[0].Rows)
                    {
                        ord["PlotSize"] = "Consolidated Report";
                    }
                }

                frmNDC_Report frmobj = new frmNDC_Report(dst, "NDC_Bulk_Report");
                frmobj.ShowDialog();
            }
            else
            {
                MessageBox.Show("There is no data for report.");
            }
           
        }

        static DataTable ConvertListToDataTable(List<String> list)
        {
            // New table.
            DataTable table = new DataTable();

            // Get max columns.
            int columns = 0;
            //foreach (var array in list)
            //{
            //    if (array.Length > columns)
            //    {
            columns = 1; // array.Length;
            //    }
            //}

            // Add columns.
            for (int i = 0; i < columns; i++)
            {
                table.Columns.Add();
            }

            // Add rows.
            foreach (var array in list)
            {
                table.Rows.Add(array);
            }

            return table;
        }
    

private void grdNDCBulkRpt_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement.ColumnInfo.Name == "SNo")
            {
                e.CellElement.Text = (e.CellElement.RowIndex + 1).ToString();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(grdNDCBulkRpt);
        }
    }
}
