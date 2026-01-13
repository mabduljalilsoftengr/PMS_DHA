using PeshawarDHASW.Data_Layer.Installment;
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

namespace PeshawarDHASW.Application_Layer.Installment.InstReceive
{
    public partial class frmDDBankListSearch : Telerik.WinControls.UI.RadForm
    {
        public frmDDBankListSearch()
        {
            InitializeComponent();
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
        }

        private void btnFindDD_Click(object sender, EventArgs e)
        {
            SqlParameter[] param = {
                            new SqlParameter("@Task","FindDDinBankListAndReceInst"),
                            new SqlParameter("@DDNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtDDNo.Text))
            };
            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_ReceInst", param);
            if (ds.Tables.Count>0)
            {
                DGV_BankListInformation.DataSource = ds.Tables[0].DefaultView;
                foreach (GridViewDataColumn column in DGV_BankListInformation.Columns)
                {
                    column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
                }
                DGV_DDInfor.DataSource = ds.Tables[1].DefaultView;
                foreach (GridViewDataColumn column in DGV_DDInfor.Columns)
                {
                    column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
                }
            }

        }

        private void btnBankListExporttoExcel_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(DGV_BankListInformation);
        }

        private void btnDDExporttoExcel_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(DGV_DDInfor);
        }
    }
}
