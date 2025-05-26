using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Application_Layer.Membership.MSImage;
using PeshawarDHASW.Helper;
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

namespace PeshawarDHASW.Application_Layer.Installment.Surcharge
{
    public partial class frmNewSurchargeWavierApproval : Telerik.WinControls.UI.RadForm
    {
        public frmNewSurchargeWavierApproval()
        {
            InitializeComponent();
            
            clsPluginHelper.Summary_Column_Template_Wise_Search(DGVSruchargeRequestData);
            clsPluginHelper.Summary_Column_Template_Wise_Search(DGVSurchargeWavierApproved);
            clsPluginHelper.Summary_Column_Template_Wise_Search(DGVSurchargeWavierCancelled);
            ApplyTheme(clsUser.ThemeName);
        }

        public void ApplyTheme(string themeName)
        {
            this.ThemeName = themeName; ThemeResolutionService.ApplyThemeToControlTree(this, themeName);
        }
        private void frmNewSurchargeWavierApproval_Load(object sender, EventArgs e)
        {
            LoadingData(txtFileNo.Text, txtPlotNo.Text);
        }

        private void LoadingData(string FileNo, string PlotNo)
        {
            SqlParameter[] param = {
                new SqlParameter("@Task","AllDataLoadingSearchApproveform"),
                new SqlParameter("@FileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(FileNo)),
                new SqlParameter("@PlotNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(PlotNo))
            };
            DataSet ds = new DataSet();

            ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "Surc.USP_tbl_SurchargeWavierMasterRecord", param);
            if (ds.Tables.Count > 0)
            {
                DGVSruchargeRequestData.DataSource = ds.Tables[0].DefaultView;
                DGVSurchargeWavierApproved.DataSource = ds.Tables[1].DefaultView;
                DGVSurchargeWavierCancelled.DataSource = ds.Tables[2].DefaultView;
                clsPluginHelper.GridColumnBestFit(DGVSruchargeRequestData);
                clsPluginHelper.GridColumnBestFit(DGVSurchargeWavierApproved);
                clsPluginHelper.GridColumnBestFit(DGVSurchargeWavierCancelled);
            }

        }

        private void DGVSruchargeRequestData_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {

                int SurMasID = int.Parse(e.Row.Cells["SurMasterID"].Value.ToString()); // ReceID
                if (e.Column.Name == "AttachmentView")
                {
                    try
                    {

                        SqlParameter[] param =
                                   {
                    new SqlParameter("@Task","Select"),//usp_tbl_DDTransferImages
                    new SqlParameter("@SurMasID",SurMasID)
                     };
                        DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "usp_SurchargeWaiverMasterRecord", param);
                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                //Membership.MSImage.frmPhotoViewer obj = new Membership.MSImage.frmPhotoViewer(ds.Tables[0]);
                                //obj.Show();
                                frmSurDocumenViwerPage obj = new frmSurDocumenViwerPage(ds.Tables[0]);
                                obj.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("No attachment(s) available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No attachment(s) available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + ex.InnerException);
                    }
                }
                if (e.Column.Name == "Detail")
                {
                    string FileNo = e.Row.Cells["FileNo"].Value.ToString();
                    string PlotNo = e.Row.Cells["PlotNo"].Value.ToString();
                    string SurStatus = e.Row.Cells["SurStatus"].Value.ToString();
                    frmNewSurchargeWavierFullDetail obj = new frmNewSurchargeWavierFullDetail(SurMasID, SurStatus, FileNo, PlotNo);
                    obj.ShowDialog();
                }
                if (e.Column.Name == "SurStatus")
                {
                    if (e.Row.Cells["SurStatus"].Value.ToString() == "Pending")
                    {
                        CustomizeMessageBox obj = new CustomizeMessageBox("Are Sure to Wavier against this File.\n Do you want to..", true);
                        obj.ShowDialog();
                        if (obj.status != null)
                        {
                            if (obj.status == "Approve")
                            {
                                SqlParameter[] param = {
                                        new SqlParameter("@Task","SurchargeWavierApproved"),
                                        new SqlParameter("@SurMasterID",SurMasID),
                                        new SqlParameter("@ApprovedBy",clsUser.Name),
                                        new SqlParameter("@ApprovedRemarks",obj.Remarks)
                               };
                                int result = Helper.SQLHelper.ExecuteNonQuery(Helper.clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "Surc.USP_tbl_SurchargeWavierMasterRecord", param);
                                if (result > 0)
                                {
                                    MessageBox.Show("Successfully Approved.");
                                    LoadingData(txtFileNo.Text, txtPlotNo.Text);
                                }
                            }
                            else if (obj.status == "Cancel")
                            {
                                SqlParameter[] param = {
                                new SqlParameter("@Task", "CancelRequestofWavier"),
                                new SqlParameter("@SurMasterID",SurMasID),
                                new SqlParameter("@ApprovedBy", clsUser.Name),
                                new SqlParameter("@ApprovedRemarks", obj.Remarks)
                               };
                                int result = Helper.SQLHelper.ExecuteNonQuery(Helper.clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "Surc.USP_tbl_SurchargeWavierMasterRecord", param);
                                if (result > 0)
                                {
                                    MessageBox.Show("Successfully Cancelled.");
                                    LoadingData(txtFileNo.Text, txtPlotNo.Text);
                                }
                            }

                        }   //   MessageBox.Show("Test");
                    }

                }
            }
            catch (Exception)
            {

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadingData(txtFileNo.Text, txtPlotNo.Text);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadingData(txtFileNo.Text, txtPlotNo.Text);
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(DGVSruchargeRequestData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Software First.\n Error -> \n" + ex.Message);
            }
        }

        private void DGVSurchargeWavierApproved_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                int SurMasID = int.Parse(e.Row.Cells["SurMasterID"].Value.ToString()); // ReceID
                if (e.Column.Name == "AttachmentView")
                {
                    try
                    {

                        SqlParameter[] param =
                                   {
                    new SqlParameter("@Task","Select"),//usp_tbl_DDTransferImages
                    new SqlParameter("@SurMasID",SurMasID)
                     };
                        DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "usp_SurchargeWaiverMasterRecord", param);
                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                //frmPhotoViewer obj = new frmPhotoViewer(ds.Tables[0]);
                                //obj.ShowDialog();
                                frmSurDocumenViwerPage obj = new frmSurDocumenViwerPage(ds.Tables[0]);
                                obj.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("No attachment(s) available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No attachment(s) available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + ex.InnerException);
                    }
                }
                if (e.Column.Name == "Detail")
                {
                    string FileNo = e.Row.Cells["FileNo"].Value.ToString();
                    string PlotNo = e.Row.Cells["PlotNo"].Value.ToString();
                    string SurStatus = e.Row.Cells["SurStatus"].Value.ToString();
                    frmNewSurchargeWavierFullDetail obj = new frmNewSurchargeWavierFullDetail(SurMasID, SurStatus, FileNo, PlotNo);
                    obj.ShowDialog();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void DGVSurchargeWavierCancelled_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                int SurMasID = int.Parse(e.Row.Cells["SurMasterID"].Value.ToString()); // ReceID
                if (e.Column.Name == "AttachmentView")
                {
                    try
                    {
                        SqlParameter[] param =
                        {
                        new SqlParameter("@Task","Select"),//usp_tbl_DDTransferImages
                        new SqlParameter("@SurMasID",SurMasID)
                        };
                        DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "usp_SurchargeWaiverMasterRecord", param);
                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                //Membership.MSImage.frmPhotoViewer obj = new Membership.MSImage.frmPhotoViewer(ds.Tables[0]);
                                //obj.ShowDialog();
                                frmSurDocumenViwerPage obj = new frmSurDocumenViwerPage(ds.Tables[0]);
                                obj.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("No attachment(s) available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No attachment(s) available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                if (e.Column.Name == "Detail")
                {
                    string FileNo = e.Row.Cells["FileNo"].Value.ToString();
                    string PlotNo = e.Row.Cells["PlotNo"].Value.ToString();
                    string SurStatus = e.Row.Cells["SurStatus"].Value.ToString();
                    frmNewSurchargeWavierFullDetail obj = new frmNewSurchargeWavierFullDetail(SurMasID, SurStatus, FileNo, PlotNo);
                    obj.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
