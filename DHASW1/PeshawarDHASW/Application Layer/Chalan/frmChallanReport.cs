using PeshawarDHASW.Data_Layer.clsChallan;
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

namespace PeshawarDHASW.Application_Layer.Chalan
{
    public partial class frmChallanReport : Telerik.WinControls.UI.RadForm
    {
        public frmChallanReport()
        {
            InitializeComponent();
        }

        private void frmChallanReport_Load(object sender, EventArgs e)
        {
            ChallanTypeBinding(cmbChallanType);
            ChallanHeaderBinding(cmbChallanHeader);
            //PlotSizeBinding(cmbPlotSize);
            //OwnerCategoryBinding(cmbOwnerCategory);

        }

        private void ChallanTypeBinding(RadDropDownList drp_lst)
        {
            RadListDataItem select = new RadListDataItem();
            select.Value = 0;
            select.Text = "-- Select Challan Type --";
            drp_lst.Items.Add(select);
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","select"),
            };
            foreach (DataRow row in cls_dl_Challan.Challan_Reader(prm).Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["ChallanTypeID"].ToString();
                dataItem.Text = row["ChallanType"].ToString();
                drp_lst.Items.Add(dataItem);
            }
            drp_lst.SelectedIndex = -1;
        }


        private void ChallanHeaderBinding(RadDropDownList drp_lst)
        {
            RadListDataItem select = new RadListDataItem();
            drp_lst.Items.Clear();
            //select.Value = 0;
            //select.Text = "-- Select Challan Type --";
            //drp_lst.Items.Add(select);
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","fillChallanHeader"),
            };
            foreach (DataRow row in cls_dl_Challan.Challan_Reader(prm).Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["ChlnParHeadID"].ToString();
                dataItem.Text = row["ParticularName"].ToString();
                drp_lst.Items.Add(dataItem);
            }
            drp_lst.SelectedIndex = -1;
        }


        private void ChallanHeaderDetailsBinding(RadDropDownList drp_lst)
        {
            drp_lst.Items.Clear();
            RadListDataItem select = new RadListDataItem();
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","fillChallanHeaderData"),
                new SqlParameter("@FileMapKey", cmbChallanHeader.SelectedValue),
            };
            foreach (DataRow row in cls_dl_Challan.Challan_Reader(prm).Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["ParDetID"].ToString();
                dataItem.Text = row["ChallanParticlar"].ToString();
                dataItem.Tag = row["Amount"].ToString();
                drp_lst.Items.Add(dataItem);
            }
            drp_lst.SelectedIndex = -1;
        }

        private void cmbChallanHeader_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            ChallanHeaderDetailsBinding(cmbChallanHeDetail);
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime? dateFrom = null;
                DateTime? dateTo = null;

                if (dtpFromDate.Value.Date.Year == 1)
                    dateFrom = null;
                else
                {
                    dateFrom = dtpFromDate.Value.Date;
                    if (dtpToDate.Value.Date.Year == 1)
                        dateTo = DateTime.Now.Date;
                    else
                        dateTo = dtpToDate.Value.Date;
                }

                string ChallanType = null;
                if (cmbChallanType.Text == "Installment")
                    ChallanType = "0";
                else if (cmbChallanType.Text == "Nomination Fee")
                    ChallanType = "-1";
                else if (cmbChallanType.Text == "Registration Of Property Dealers")
                    ChallanType = "-2";
                else if (cmbChallanType.Text == "Renewal Fee for Registration Of Property Dealers")
                    ChallanType = "-3";
                else
                    ChallanType = null;

                SqlParameter[] prm =
                {
                    new SqlParameter("@Task", "GetChallanReportDetails"),
                    new SqlParameter("@FileNo", string.IsNullOrEmpty(txtFileNo.Text.Trim()) ? null : txtFileNo.Text.Trim()),
                    new SqlParameter("@ChalanNo", string.IsNullOrEmpty(txtChallanNo.Text.Trim()) ? null : txtChallanNo.Text.Trim()),
                    new SqlParameter("@Status", string.IsNullOrEmpty(drpDDstatus.Text.Trim())? null : drpDDstatus.Text.Trim()),
                    new SqlParameter("@FromDate", dateFrom),
                    new SqlParameter("@ToDate", dateTo),
                    new SqlParameter("@ParticularID", cmbChallanHeDetail.SelectedValue),
                    new SqlParameter("@ChallanType",ChallanType ),
                    new SqlParameter("@ChallanCategory",drpChallanCategory.Text == "" ? null  : drpChallanCategory.Text)
                };
                DataSet ds = cls_dl_Challan.Challan_Reader(prm);
                if (ds.Tables.Count > 0)
                {
                    dgChallanReport.DataSource = ds.Tables[0].DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(dgChallanReport);
        }

        private void cmbChallanType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cmbChallanType.Text == "Other")
            {
                cmbChallanHeDetail.SelectedIndex = -1;
                cmbChallanHeader.SelectedIndex = -1;
                cmbChallanHeader.Enabled = true;
                cmbChallanHeDetail.Enabled = true;
            }
            else
            {
                cmbChallanHeDetail.SelectedIndex = -1;
                cmbChallanHeader.SelectedIndex = -1;
                cmbChallanHeader.Enabled = false;
                cmbChallanHeDetail.Enabled = false;
            }

        }

        private void txtFileNo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnsearch_Click(null, null);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbChallanType.SelectedIndex = -1;
            cmbChallanHeader.SelectedIndex = -1;
            cmbChallanHeDetail.SelectedIndex = -1;

            txtChallanNo.Clear();
            txtFileNo.Clear();

            dtpFromDate.Text = "";
            dtpToDate.Text = "";
            drpDDstatus.SelectedIndex = -1;

            dgChallanReport.DataSource = null;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime? dateFrom = null;
                DateTime? dateTo = null;

                if (dtpFromDate.Value.Date.Year == 1)
                    dateFrom = null;
                else
                {
                    dateFrom = dtpFromDate.Value.Date;
                    if (dtpToDate.Value.Date.Year == 1)
                        dateTo = DateTime.Now.Date;
                    else
                        dateTo = dtpToDate.Value.Date;
                }

                string ChallanType = null;
                if (cmbChallanType.Text == "Installment")
                    ChallanType = "0";
                else if (cmbChallanType.Text == "Nomination Fee")
                    ChallanType = "-1";
                else if (cmbChallanType.Text == "Registration Of Property Dealers")
                    ChallanType = "-2";
                else if (cmbChallanType.Text == "Renewal Fee for Registration Of Property Dealers")
                    ChallanType = "-3";
                else
                    ChallanType = null;

                SqlParameter[] prm =
                {
                    new SqlParameter("@Task", "GetChallanReport"),
                    new SqlParameter("@FileNo", string.IsNullOrEmpty(txtFileNo.Text.Trim()) ? null : txtFileNo.Text.Trim()),
                    new SqlParameter("@ChalanNo", string.IsNullOrEmpty(txtChallanNo.Text.Trim()) ? null : txtChallanNo.Text.Trim()),
                    new SqlParameter("@Status", string.IsNullOrEmpty(drpDDstatus.Text.Trim())? null : drpDDstatus.Text.Trim()),
                    new SqlParameter("@FromDate", dateFrom),
                    new SqlParameter("@ToDate", dateTo),
                    new SqlParameter("@ParticularID", cmbChallanHeDetail.SelectedValue),
                    new SqlParameter("@ChallanType",ChallanType ),
                    new SqlParameter("@ChallanCategory",drpChallanCategory.Text == "" ? null  : drpChallanCategory.Text)
                };
                DataSet ds = cls_dl_Challan.Challan_Reader(prm);
                if (ds.Tables.Count > 0)
                {
                    frmChallanReportWindow frm = new frmChallanReportWindow(ds);
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
