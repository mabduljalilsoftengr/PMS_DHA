using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.NDC
{
    public partial class frmNDCTrail : Telerik.WinControls.UI.RadForm
    {
        public frmNDCTrail()
        {
            InitializeComponent();
            StatusofNDC_DDL();
        }
        public frmNDCTrail(string NDCNo)
        {
            InitializeComponent();
            if (!string.IsNullOrWhiteSpace(NDCNo))
            {
                StatusofNDC_DDL();
                StatusofNDCdp.Enabled = false;
                dtpFromDate.Enabled = false;
                dtpToDate.Enabled = false;
                btnSearch.Enabled = false;
                DataLoadintNDC(NDCNo);
            }
            
        }

        private void StatusofNDC_DDL()
        {
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@Task","NDCStatusVal")
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(
                     Helper.SQLHelper.createConnection()
                    , CommandType.StoredProcedure, "App.NDC_Trail", param);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        StatusofNDCdp.DataSource = ds.Tables[0].DefaultView;
                        StatusofNDCdp.DisplayMember = "StatusofNDC";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataLoadintNDC(string NDCNo)
        {
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@Task","NDCTrailDataSingleNDC"),
                    new SqlParameter("@NDCNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(NDCNo))
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(
                     Helper.SQLHelper.createConnection()
                    , CommandType.StoredProcedure, "App.NDC_Trail", param);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        rgvNDCTrailData.DataSource = ds.Tables[0].DefaultView;
                        foreach (var item in rgvNDCTrailData.Columns)
                        {
                            item.BestFit();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void DataLoadint(DateTime fromdate,DateTime ToDate,string StatusofNDC, string NDCNo)
        {
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@Task","NDCTrailData"),
                    new SqlParameter("@FromDate",fromdate.Date),
                    new SqlParameter("@ToDate",ToDate.Date),
                    new SqlParameter("@StatusofNDC",Helper.clsPluginHelper.DbNullIfNullOrEmpty(StatusofNDC)),
                    new SqlParameter("@NDCNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(NDCNo))
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(
                     Helper.SQLHelper.createConnection()
                    , CommandType.StoredProcedure, "App.NDC_Trail", param);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        rgvNDCTrailData.DataSource = ds.Tables[0].DefaultView;
                        foreach (var item in rgvNDCTrailData.Columns)
                        {
                            item.BestFit();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string NDCNo = "";
            DataLoadint(dtpFromDate.Value, dtpToDate.Value, StatusofNDCdp.Text,NDCNo);
        }

        private void frmNDCTrail_Load(object sender, EventArgs e)
        {

        }
    }
}
