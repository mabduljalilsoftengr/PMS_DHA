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

namespace PeshawarDHASW.Application_Layer.CRSection
{
    public partial class frmLetterDataInfo : Telerik.WinControls.UI.RadForm
    {
        public frmLetterDataInfo()
        {
            InitializeComponent();
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
        }

        private void btnDateWiseSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Task","SelectDateWise"),
                    new SqlParameter("@FromDate",dtpfromdate.Value),
                    new SqlParameter("@ToDate",dtptodate.Value),

            };

                DataSet result = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_CRS_Letter", param);

                dgvDataViewLetters.DataSource = result.Tables[0].DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Check your Internet Connection."+ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Task","SelectRefresh"), 
            };

                DataSet result = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_CRS_Letter", param);

                dgvDataViewLetters.DataSource = result.Tables[0].DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Check your Internet Connection." + ex.Message);
            }
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(dgvDataViewLetters);
        }

        private void frmLetterDataInfo_Load(object sender, EventArgs e)
        {
            btnRefresh_Click(null, null);
           
        }
        public void ApplyTheme(string themeName)
        {
            this.ThemeName = themeName; ThemeResolutionService.ApplyThemeToControlTree(this, themeName);
        }

        private void dgvDataViewLetters_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Row.Cells.Count>0)
            {
                frmLetterDispatch obj = new frmLetterDispatch(e.Row.Cells["RegNo"].Value.ToString());
                obj.ShowDialog();
                btnRefresh_Click(null, null);
            }
        }

        private void AddNewRecord_Click(object sender, EventArgs e)
        {
            frmLetterDispatch obj = new CRSection.frmLetterDispatch();
            obj.ShowDialog();
        }
    }
}
