using PeshawarDHASW.Data_Layer.Installment;
using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Installment.Surcharge.SurchrageWaiverApplication
{
    public partial class frmSurWaiverAppProgressBasket : Telerik.WinControls.UI.RadForm
    {
        public frmSurWaiverAppProgressBasket()
        {
            InitializeComponent();
        }
        private string FileNo { get; set; }
        private void frmSurWaiverAppProgressBasket_Load(object sender, EventArgs e)
        {
            FillDataGrid(null);
            FillSurchargeWavierMasterRecordDataGrid(null);
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            FillDataGrid(null);
            FillSurchargeWavierMasterRecordDataGrid(null);
        }

        private void FillDataGrid(DateTime? dt)
        {
            try
            {
                SqlParameter[] prm =
                 {
                new SqlParameter("@Task","GetAppData"),
                new SqlParameter("@FileNo", null),
                new SqlParameter("@PlotNo", null),


                 };
                DataSet ds = cls_dl_SurchargeWavier_ApplicationStatus.SurchargeWavier_ApplicationStatus_Reader(prm);
                if (ds.Tables.Count > 0)
                {
                    GVAppReceived.DataSource = ds.Tables[0].DefaultView;
                    foreach (GridViewDataColumn column in GVAppReceived.Columns)
                    {
                        column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
                    }
                    //  GVApproved.DataSource = ds.Tables[1].DefaultView;
                    //  GVNotApproved.DataSource = ds.Tables[2].DefaultView;
                    //GVNotApproved.DataSource = ds.Tables[2].DefaultView;
                    //ChallanDetailDS _ds = new ChallanDetailDS();
                    //_ds.Tables[0].Merge(ds.Tables[0]);
                    //_ds.Tables[1].Merge(ds.Tables[1]);
                    //dgChallanSearch.DataSource = _ds.Tables[0];
                    //gridViewTemplate1.DataSource = _ds.Tables[1];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillSurchargeWavierMasterRecordDataGrid(DateTime? dt)
        {
            try
            {
                SqlParameter[] prm =
                 {
                new SqlParameter("@Task","GetSurchargeWavierMasterRecord"),
                new SqlParameter("@FileNo", null),
                new SqlParameter("@PlotNo", null),


                 };
                DataSet ds = cls_dl_SurchargeWavier_ApplicationStatus.SurchargeWavier_ApplicationStatus_Reader(prm);
                if (ds.Tables.Count > 0)
                {
                    GGetSurchargeWavierMasterRecord.DataSource = ds.Tables[0].DefaultView;
                    foreach (GridViewDataColumn column in GGetSurchargeWavierMasterRecord.Columns)
                    {
                        column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
                    }
                    //  GVApproved.DataSource = ds.Tables[1].DefaultView;
                    //  GVNotApproved.DataSource = ds.Tables[2].DefaultView;
                    //GVNotApproved.DataSource = ds.Tables[2].DefaultView;
                    //ChallanDetailDS _ds = new ChallanDetailDS();
                    //_ds.Tables[0].Merge(ds.Tables[0]);
                    //_ds.Tables[1].Merge(ds.Tables[1]);
                    //dgChallanSearch.DataSource = _ds.Tables[0];
                    //gridViewTemplate1.DataSource = _ds.Tables[1];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GVAppReceived_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {


            try
            {
                int SWA_ID = 0;
                if (e.Column.Name == "btnmodify")
                {
                    string CheckStatus = e.Row.Cells["Status"].Value.ToString();
                    string SectorCExt = e.Row.Cells["SectorCExt"].Value.ToString();
                    if (CheckStatus == "Pending")
                    {
                        frmSurWvrAppStatus frm = new frmSurWvrAppStatus(SectorCExt);
                        frm.ShowDialog();
                        SWA_ID = int.Parse(e.Row.Cells["SWA_ID"].Value.ToString());
                        FileNo = e.Row.Cells["FileNo"].Value.ToString();
                        string Status = ConfigurationManager.AppSettings["SurWvrApp"].ToString();
                        string SurWvrAppWaivedOff = ConfigurationManager.AppSettings["SurWvrAppWaivedoffPer"].ToString();
                        string SurWvrAppPrint = ConfigurationManager.AppSettings["SurWvrAppPrint"].ToString();
                        string Remarks = ConfigurationManager.AppSettings["SurWvrAppRemarks"].ToString();

                        int result = 0;
                        SqlParameter[] prm =
                       {
                        new SqlParameter("@Task","UPDATE_STATUS_OF_SurchargeWavier_ApplicationStatus"),
                      //new SqlParameter("@RefrenceNo", clsPluginHelper.DbNullIfNullOrEmpty(txtRefrenceNo.Text)),
                        new SqlParameter("@SWA_ID", SWA_ID),
                        new SqlParameter("@Status", Status),//clsPluginHelper.DbNullIfNullOrEmpty(cmdStatus.SelectedItem.ToString())),
                      //new SqlParameter("@Approved_DisapprovedDate", ApprovedDisapprovedDate.Value.Date),
                        new SqlParameter("@Remarks", Remarks),
                        new SqlParameter("@UpdateBy", Models.clsUser.ID),
                         new SqlParameter("@WaivedOffPer", clsPluginHelper.DbNullIfNullOrEmpty(SurWvrAppWaivedOff)),
                          new SqlParameter("@PrintStatus", SurWvrAppPrint),
                     };

                        if (SWA_ID != 0 && Status != "" && Remarks != "")
                        {
                            result = cls_dl_SurchargeWavier_ApplicationStatus.SurchargeWavier_ApplicationStatus_NonQuery(prm);
                        }
                        else
                        {
                            //  MessageBox.Show("Please checked and fill all required fields.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            return;
                        }
                        if (result > 0 && Status =="Approved")
                        {
                            FillDataGrid(null);
                            ConfigurationManager.AppSettings["SurWvrApp"] = "";
                            ConfigurationManager.AppSettings["SurWvrAppRemarks"] = "";
                            ConfigurationManager.AppSettings["SurWvrAppPrint"] = "";
                            ConfigurationManager.AppSettings["SurWvrAppWaivedoffPer"] = "";
                            string SWA_IDFor_Reference = e.Row.Cells["SWA_ID"].ToString();
                            MessageBox.Show("Record Updated Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmNewSurchargeRequest frmobj = new frmNewSurchargeRequest(FileNo, "GoFromWvrApp");
                            frmobj.ShowDialog();
                         }
                        if (result > 0 && Status != "Approved")
                        {
                            FillDataGrid(null);
                            ConfigurationManager.AppSettings["SurWvrApp"] = "";
                            ConfigurationManager.AppSettings["SurWvrAppRemarks"] = "";
                            ConfigurationManager.AppSettings["SurWvrAppPrint"] = "";
                            ConfigurationManager.AppSettings["SurWvrAppWaivedoffPer"] = "";
                            MessageBox.Show("Record Updated Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Some Error Occurred.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Status already " + CheckStatus, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnperiodsearchsp_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(GVAppReceived);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
