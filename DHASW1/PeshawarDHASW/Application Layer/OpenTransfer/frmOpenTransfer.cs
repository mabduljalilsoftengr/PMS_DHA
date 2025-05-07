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

namespace PeshawarDHASW.Application_Layer.OpenTransfer
{
    public partial class frmOpenTransfer : Telerik.WinControls.UI.RadForm
    {
        public frmOpenTransfer()
        {
            InitializeComponent();
        }

        private void DataLoading()
        {
            try
            {
                SqlParameter[] parameter = {
                  new SqlParameter("@Task","GetRecordTransferBranch")
                 };
                DataSet DataSeller = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_PreTransferRequest", parameter);
                grd_PreTransferRequestInformation.DataSource = DataSeller.Tables[0].DefaultView;


                foreach (GridViewDataColumn column in grd_PreTransferRequestInformation.Columns)
                {
                    column.BestFit();
                }

                SqlParameter[] parameterbuyer = {
                  new SqlParameter("@Task","GetRecordTransferBranchBuyer")
                 };
                DataSet DataBuyer = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_PreTransferRequest", parameterbuyer);
                gdvOpenTransferBuyer.DataSource = DataBuyer.Tables[0].DefaultView;
                foreach (GridViewDataColumn column in gdvOpenTransferBuyer.Columns)
                {
                    column.BestFit();
                }

            }
            catch (Exception ex)
            {

            }


        }

        private void frmOpenTransfer_Load(object sender, EventArgs e)
        {
            DataLoading();
        }

        private void grd_PreTransferRequestInformation_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name== "btnPrint")
            {
                string FileNo = e.Row.Cells["FileNo"].Value.ToString();
                string FileID = e.Row.Cells["FileMapKey"].Value.ToString();
                string NDCNo = e.Row.Cells["NDCNo"].Value.ToString();
                string PreTransferID = e.Row.Cells["ID"].Value.ToString();
                OpenTransferReports obj = new OpenTransferReports(NDCNo, FileNo, FileID, PreTransferID);
                obj.ShowDialog();
            }

            if (e.Column.Name == "btnTRFDate")
            {
                string FileNo = e.Row.Cells["FileNo"].Value.ToString();
                string FileID = e.Row.Cells["FileMapKey"].Value.ToString();
                string NDCNo = e.Row.Cells["NDCNo"].Value.ToString();
                string PreTransferID = e.Row.Cells["ID"].Value.ToString();
                Enter_Transfer_Date obj = new Enter_Transfer_Date(NDCNo, FileNo, FileID, PreTransferID);
                obj.ShowDialog();
            }
            if (e.Column.Name== "Attachment")
            {
                string FileNo = e.Row.Cells["FileNo"].Value.ToString();
                string FileID = e.Row.Cells["FileMapKey"].Value.ToString();
                string NDCNo = e.Row.Cells["NDCNo"].Value.ToString();
                string PreTransferID = e.Row.Cells["ID"].Value.ToString();
                frmTransferDocUpload obj = new frmTransferDocUpload(FileID,NDCNo,FileNo,PreTransferID);
                obj.ShowDialog();
                DataLoading();
            }
        }

        private void gdvOpenTransferBuyer_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name == "BuyerReport")
            {
                string FileNo = e.Row.Cells["FileNo"].Value.ToString();
                string FileID = e.Row.Cells["FileMapKey"].Value.ToString();
                string NDCNo = e.Row.Cells["NDCNo"].Value.ToString();
                string PreTransferID = e.Row.Cells["ID"].Value.ToString();
                frmOpenTransferBuyerReport obj = new frmOpenTransferBuyerReport(NDCNo, FileNo, FileID, PreTransferID);
                obj.ShowDialog();
            }
        }
    }
}
