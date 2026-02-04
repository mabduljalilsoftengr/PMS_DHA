using PeshawarDHASW.Helper;
using PeshawarDHASW.Models;
using PeshawarDHASW.Report.OpenNDC;
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

namespace PeshawarDHASW.Application_Layer.OpenNDC
{
    public partial class frmPreTransferGrid : Telerik.WinControls.UI.RadForm
    {
        public frmPreTransferGrid()
        {
            InitializeComponent();
        }

        private void frmPreTransferGrid_Load(object sender, EventArgs e)
        {
            DataLoading();
        }

        private void DataLoading()
        {
            try
            {
                SqlParameter[] parameter = {
                new SqlParameter("@Task","GetRecords")
            };
                DataSet DataRefund = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_PreTransferRequest", parameter);
                grd_PreTransferRequestInformation.DataSource = DataRefund.Tables[0].DefaultView;


                foreach (GridViewDataColumn column in grd_PreTransferRequestInformation.Columns)
                {
                    column.BestFit();
                }
            }
            catch (Exception ex)
            {

            }


        }

        private void btnNewRequest_Click(object sender, EventArgs e)
        {
            frmPreTransfer obj = new frmPreTransfer();
            obj.ShowDialog();
            DataLoading();
        }

        private void grd_PreTransferRequestInformation_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {


                string PerTransferID = e.Row.Cells["ID"].Value.ToString();
                if (e.Column.Name == "Attachment")
                {
                    SqlParameter[] param =
                            {
                        new SqlParameter("@Task","Select"),
                        new SqlParameter("@PreTransferID",PerTransferID)
                        };
                    DataSet ds = SQLHelper.ExecuteDataset(
                                                         clsMostUseVars.VerifiedImageConnectionstring,
                                                         CommandType.StoredProcedure,
                                                         "usp_tbl_PreTransferRequestImage",
                                                         param
                                                         );

                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Membership.MSImage.frmPhotoViewer obj = new Membership.MSImage.frmPhotoViewer(ds.Tables[0]);
                            obj.Show();
                        }
                        else
                        {
                            MessageBox.Show("No attachment(s) available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                if (e.Column.Name == "btnEdit")
                {
                    if (e.Row.Cells["OpenNDC"].Value.ToString() == "NDCPending")
                    {
                        string PreTransferID = e.Row.Cells["ID"].Value.ToString();
                        string FileNo = e.Row.Cells["FileNo"].Value.ToString();
                        int PropertyDealerID = int.Parse(e.Row.Cells["DealerID"].Value.ToString());
                        frmPreTransferEdit obj = new frmPreTransferEdit(PerTransferID, FileNo, PropertyDealerID);
                        obj.ShowDialog();
                        DataLoading();
                    }
                }
                if (e.Column.Name == "OpenNDC")
                {
                    if (e.Row.Cells["OpenNDC"].Value.ToString() == "NDCPending")
                    {
                        int PreTransferDealId = int.Parse(e.Row.Cells["ID"].Value.ToString());
                        int FileMapKey = int.Parse(e.Row.Cells["FileMapKey"].Value.ToString());
                        string FileNo = e.Row.Cells["FileNo"].Value.ToString();
                        int DealerID = int.Parse(e.Row.Cells["DealerID"].Value.ToString());
                        string DealerName = e.Row.Cells["BussinessTitle"].Value.ToString();

                        OpenNDC_Buyer buyer = new OpenNDC_Buyer();
                        buyer.FileNo = FileNo;
                        buyer.BuyerName = DealerName;
                        buyer.FatherName = e.Row.Cells["DealerName1"].Value.ToString();
                        buyer.NTN = e.Row.Cells["CNICNo1"].Value.ToString();
                        buyer.Address = e.Row.Cells["BussinessAddress"].Value.ToString();
                        buyer.MobileNo = e.Row.Cells["ContactNumber1"].Value.ToString();

                        frmOpenNDCRequest obj = new frmOpenNDCRequest(PreTransferDealId, FileMapKey, FileNo, DealerID, DealerName, true, buyer);
                        obj.ShowDialog();
                        DataLoading();
                    }
                    else
                    {
                        MessageBox.Show("NDC is Already inprogress.");
                    }
                }
                if (e.Column.Name == "btnPrint")
                {
                    int PreTransferDealId = int.Parse(e.Row.Cells["ID"].Value.ToString());
                    frmOpenNDCReport obj = new frmOpenNDCReport(PreTransferDealId);
                    obj.ShowDialog();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnRefreshGrid_Click(object sender, EventArgs e)
        {
            DataLoading();
        }

        private void btnNDCConvert_Click(object sender, EventArgs e)
        {
            OpenNDCConverttoNormal obj = new OpenNDCConverttoNormal();
            obj.ShowDialog();
        }
    }
}
