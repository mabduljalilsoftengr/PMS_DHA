using PeshawarDHASW.Application_Layer.NDC.Baskets;
using PeshawarDHASW.Data_Layer.NDC;
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

namespace PeshawarDHASW.Application_Layer.OpenTransfer
{
    public partial class frmOpenTransfer : Telerik.WinControls.UI.RadForm
    {
        public frmOpenTransfer()
        {
            InitializeComponent();
        }

        private void frmOpenTransfer_Load(object sender, EventArgs e)
        {
            DataLoading();
            addingControltoGrid();
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

        private void grd_PreTransferRequestInformation_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name == "btnPrint")
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
            if (e.Column.Name == "Attachment")
            {
                string FileNo = e.Row.Cells["FileNo"].Value.ToString();
                string FileID = e.Row.Cells["FileMapKey"].Value.ToString();
                string NDCNo = e.Row.Cells["NDCNo"].Value.ToString();
                string PreTransferID = e.Row.Cells["ID"].Value.ToString();
                frmTransferDocUpload obj = new frmTransferDocUpload(FileID, NDCNo, FileNo, PreTransferID);
                obj.ShowDialog();
                DataLoading();
            }

           

            if (e.Column.Name == "btndealcancel") 
            {
                if (MessageBox.Show("Are you sure ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int NDCNo_ = Convert.ToInt32(e.Row.Cells["NDCNo"].Value.ToString());
                    string FileNo = e.Row.Cells["FileNo"].Value.ToString();

                    SqlParameter[] prm =
                    {
                        new SqlParameter("@Task","UpdateNDCAndExpireDateByFinance"),
                        new SqlParameter("@NDCNo",NDCNo_),
                        new SqlParameter("@StatusofNDC","Cancel"),
                        new SqlParameter("@FileNo",FileNo),
                        new SqlParameter("@UserID",clsUser.ID),
                        new SqlParameter("@UserName",clsUser.Name)
                    };

                    int rsl = cls_dl_NDC.NdcNonQuery(prm);
                    if (rsl > 0)
                    {
                        MessageBox.Show("Deal Cancelled Successfully.");
                        DataLoading(); // Refresh grid
                        
                    }
                }
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


        private void addingControltoGrid()
        {

            GridViewCommandColumn cencelColumn = new GridViewCommandColumn
            {
                Name = "btndealcancel",
                UseDefaultText = true,
                FieldName = "btndealcancel",
                DefaultText = "Deal Cancel",
                Width = 80,
                TextAlignment = ContentAlignment.MiddleCenter,
                HeaderText = "Deal Cancel"
            };
            //grd_PreTransferRequestInformation.MasterTemplate.Columns.Add(cencelColumn);
            grd_PreTransferRequestInformation.MasterTemplate.Columns.Insert(4, cencelColumn);

        }



    }
}
