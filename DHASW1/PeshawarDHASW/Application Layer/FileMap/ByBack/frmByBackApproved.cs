using PeshawarDHASW.Data_Layer.clsFileMap;
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

namespace PeshawarDHASW.Application_Layer.FileMap.ByBack
{
    public partial class frmByBackApproved : Telerik.WinControls.UI.RadForm
    {
        public frmByBackApproved()
        {
            InitializeComponent();
        }
        private void btndatafind_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","GetAllByBackData")
            };
            DataSet dst = cls_dl_FileMap.Main_FileMap_Reader(prm);
            grdpendingdata.DataSource = dst.Tables[0].DefaultView;
            grdapproveddata.DataSource = dst.Tables[1].DefaultView;
            //grdfinallyapproved.DataSource = dst.Tables[2].DefaultView;
        }

        private void grdpendingdata_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if(e.Column.Name == "btnApproved")
            {
                int bbid = int.Parse(e.Row.Cells["BID"].Value.ToString());
                string flno = e.Row.Cells["FileNo"].Value.ToString();
                if(MessageBox.Show("Are you sure ?","Attention !",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    SqlParameter[] prm =
                    {
                      new SqlParameter("@Task","UpdateByBackData"),
                      new SqlParameter("@BID",bbid),
                      new SqlParameter("@FileNo",flno),
                      new SqlParameter("@userID",clsUser.ID)
                    };
                    int rslt = cls_dl_FileMap.Main_FileMap_NonQuery(prm);
                    if (rslt > 0)
                    {
                        MessageBox.Show("Update Successfully.", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
              
            }
            else if(e.Column.Name == "btnDocumentsView")
            {
                try
                {
                    int buybackid = int.Parse(e.Row.Cells["BID"].Value.ToString());
                    frmImageShow frm = new frmImageShow(buybackid,"BuyBack");
                    frm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private void frmByBackApproved_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                LoadDataFileCancel();
                LoadReportData();

                GridViewSummaryItem summaryItem = new GridViewSummaryItem("PerFileRate", "Total={0}", GridAggregateFunction.Sum);
                GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
                summaryRowItem.Add(summaryItem);
                this.grdreportdata.SummaryRowsBottom.Add(summaryRowItem);
                this.grdreportdata.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void LoadReportData()
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","BuyBackReport")
            };
            DataSet rslt = cls_dl_FileMap.Main_FileMap_Reader(prm);
            grdreportdata.DataSource = rslt.Tables[0].DefaultView;

            RadListDataItem Select = new RadListDataItem();
            Select.Value = 0;
            Select.Text = "-- Select --";
            this.rdpstatus.Items.Add(Select);

            foreach (DataRow row in rslt.Tables[1].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = 0;
                dataItem.Text = row["Status"].ToString();
                this.rdpstatus.Items.Add(dataItem);
            }
            rdpstatus.SelectedIndex = 0;
        }
       
        private void grdfinallyapproved_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if(e.Column.Name == "btnviewdocuments")
                {
                    int buybackid = int.Parse(e.Row.Cells["BID"].Value.ToString());
                    frmImageShow frm = new frmImageShow(buybackid, "BuyBack");
                    frm.ShowDialog();
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnperiodsearch_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(grdapproveddata);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnFIndFileCancelData_Click(object sender, EventArgs e)
        {
            LoadDataFileCancel();
        }
        private void LoadDataFileCancel()
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","GetAllFilaCancelData")
            };
            DataSet dst = cls_dl_FileMap.Main_FileMap_Reader(prm);
            grdPendingfilecancellationdata.DataSource = dst.Tables[0].DefaultView;
            grdApprovedfilecancellationdata.DataSource = dst.Tables[1].DefaultView;
            //grdapproveddata.DataSource = dst.Tables[1].DefaultView;
            // grdfinallyapproved.DataSource = dst.Tables[2].DefaultView;
        }

        private void grdPendingfilecancellationdata_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if(e.Column.Name == "btnDocumentsView")
            {
                int cf_id = int.Parse(e.Row.Cells["CFID"].Value.ToString());
                frmImageShow frm = new frmImageShow(cf_id, "FileCancel");
                frm.ShowDialog();
            }
            else if (e.Column.Name == "btnApproved")
            {
                int cf_id = int.Parse(e.Row.Cells["CFID"].Value.ToString());
                string fno = e.Row.Cells["FileNo"].Value.ToString();
                string fsts= e.Row.Cells["FileStatus"].Value.ToString(); 

                SqlParameter[] prm =
                {
                  new SqlParameter("@Task","UpdateFileCancelStatus"),
                  new SqlParameter("@Status","Approved"),
                  new SqlParameter("@FileNo",fno),
                  new SqlParameter("@CFID",cf_id),
                  new SqlParameter("@UserName",Models.clsUser.Name),
                  new SqlParameter("@FileStatus",fsts)
                };
                int rslt = cls_dl_FileMap.Main_FileMap_NonQuery(prm);
                if(rslt > 0)
                {
                    LoadDataFileCancel();
                    MessageBox.Show("Updated Sucessfully.");
                }
            }
        }

        private void grdApprovedfilecancellationdata_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            int cf_id = int.Parse(e.Row.Cells["CFID"].Value.ToString());
            frmImageShow frm = new frmImageShow(cf_id, "FileCancel");
            frm.ShowDialog();
        }

        private void grdapproveddata_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "btnviewdocuments")
                {
                    int buybackid = int.Parse(e.Row.Cells["BID"].Value.ToString());
                    frmImageShow frm = new frmImageShow(buybackid, "BuyBack");
                    frm.ShowDialog();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            LoadDataFileCancel();
            LoadReportData();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            DateTime? dateFrom = null;
            DateTime? dateTo = null;

            if (dtpfrom.Value.Date.Year == 1)
                dateFrom = null;
            else
            {
                dateFrom = dtpfrom.Value.Date;
                if (dtpto.Value.Date.Year == 1)
                    dateTo = DateTime.Now.Date;
                else
                    dateTo = dtpto.Value.Date;
            }


           SqlParameter[] prm =
           {
                    new SqlParameter("@Task","BuyBackReport"),
                    new SqlParameter("@Status", rdpstatus.SelectedItem.ToString() == "-- Select --" ? null :  rdpstatus.SelectedItem.ToString()),
                    new SqlParameter("@InvestorName",txtname.Text),
                    new SqlParameter("@FromDate",dateFrom),
                    new SqlParameter("@ToDate", dateTo  )
            };
            DataSet rslt = cls_dl_FileMap.Main_FileMap_Reader(prm);
            grdreportdata.DataSource = rslt.Tables[0].DefaultView;
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(grdapproveddata);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
