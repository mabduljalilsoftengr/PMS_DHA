using PeshawarDHASW.Data_Layer.clsFileMap;
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
    public partial class frmBuyBackReportForm : Telerik.WinControls.UI.RadForm
    {
        public frmBuyBackReportForm()
        {
            InitializeComponent();
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(grdreportdata);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmBuyBackReportForm_Load(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

         }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] prm =
                {
                    new SqlParameter("@Task","BuyBackReport"),
                    new SqlParameter("@Status", rdpstatus.SelectedItem.ToString() == "-- Select --" ? null :  rdpstatus.SelectedItem.ToString())
                };
            DataSet rslt = cls_dl_FileMap.Main_FileMap_Reader(prm);
            grdreportdata.DataSource = rslt.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdreportdata_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if(e.Column.Name == "btnview")
                {
                    int bbid = int.Parse(e.Row.Cells["BID"].Value.ToString());
                    frmImageShow frm = new frmImageShow(bbid, "BuyBack");
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
