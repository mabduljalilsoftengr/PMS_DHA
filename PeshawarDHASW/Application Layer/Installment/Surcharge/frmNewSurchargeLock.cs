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
    public partial class frmNewSurchargeLock : Telerik.WinControls.UI.RadForm
    {
        public frmNewSurchargeLock()
        {
            InitializeComponent();
            ApplyTheme(clsUser.ThemeName);
        }

        public void ApplyTheme(string themeName)
        {
            this.ThemeName = themeName; ThemeResolutionService.ApplyThemeToControlTree(this, themeName);
        }
        private void LoadingData(string FileNo, string PlotNo)
        {
            SqlParameter[] param = {
                new SqlParameter("@Task","AllDataLoadingSearch"),
                new SqlParameter("@FileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(FileNo)),
                new SqlParameter("@PlotNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(PlotNo))
            };
            DataSet ds = new DataSet();
            ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "Surc.USP_tbl_SurchargeWavierMasterRecord", param);
            DGVSruchargeRequestData.DataSource = ds.Tables[0].DefaultView;
            foreach (var item in DGVSruchargeRequestData.Columns)
            {
                item.BestFit();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadingData(txtFileNo.Text, txtPlotNo.Text);
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
                                Membership.MSImage.frmPhotoViewer obj = new Membership.MSImage.frmPhotoViewer(ds.Tables[0]);
                                obj.Show();
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
                    catch (Exception)
                    {
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
                
            }
        }

        private void MasterTemplate_CellValueChanged(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "LockStatus")
            {
                string SurMasterID = e.Row.Cells["SurMasterID"].Value.ToString();
                string FileNo = e.Row.Cells["FileNo"].Value.ToString();
                bool chk = Convert.ToBoolean(e.Row.Cells["LockStatus"].Value);
               //// if (chk == true)
               // {
                    if (MessageBox.Show("Are you Sure?"," File"+ FileNo + " for Surcharge Wavier . "+ (chk== true?"Lock":" Unlock") ,MessageBoxButtons.YesNo,MessageBoxIcon.Warning)== DialogResult.Yes)
                    {
                        SqlParameter[] param = {
                            new SqlParameter("@Task","LockSetting"),
                            new SqlParameter("@SurMasterID",SurMasterID),
                            new SqlParameter("@UnlockByUser",clsUser.Name)
                        };
                       int ds = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "Surc.USP_tbl_SurchargeWavierMasterRecord", param);
                        if (ds > 0)
                        {
                            MessageBox.Show("Operation Complete Successfull.");
                        }
                    }
                //}
            }
        }

        private void frmNewSurchargeLock_Load(object sender, EventArgs e)
        {
            LoadingData(txtFileNo.Text, txtPlotNo.Text);
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            LoadingData(txtFileNo.Text, txtPlotNo.Text);
        }
    }
}
