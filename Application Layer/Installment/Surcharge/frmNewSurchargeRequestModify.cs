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
    public partial class frmNewSurchargeRequestModify : Telerik.WinControls.UI.RadForm
    {
        public frmNewSurchargeRequestModify()
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
            clsPluginHelper.GridColumnBestFit(DGVSruchargeRequestData);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadingData(txtFileNo.Text, txtPlotNo.Text);
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            LoadingData(null,null);
        }

        private void DGVSruchargeRequestData_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            string SurMasterID = e.Row.Cells["SurMasterID"].Value.ToString();
            string SurStatus = e.Row.Cells["SurStatus"].Value.ToString();
            if (e.Column.Name == "SurStatus" & e.Row.Cells["SurStatus"].Value.ToString()=="Pending")
            {
                //MessageBox.Show(SurMasterID);
                Modification.frmSurchargeWavier obj = new Modification.frmSurchargeWavier(SurMasterID, SurStatus);
                obj.ShowDialog();
            }
        }

        private void frmNewSurchargeRequestModify_Load(object sender, EventArgs e)
        {
            LoadingData(txtFileNo.Text, txtPlotNo.Text);
        }
    }
}
