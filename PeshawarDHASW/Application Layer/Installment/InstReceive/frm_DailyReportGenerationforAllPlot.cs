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
    public partial class frm_DailyReportGenerationforAllPlot : Telerik.WinControls.UI.RadForm
    {
        public frm_DailyReportGenerationforAllPlot()
        {
            InitializeComponent();
        }
        public void ApplyTheme(string themeName)
        {
            this.ThemeName = themeName; ThemeResolutionService.ApplyThemeToControlTree(this, themeName);
        }

        private void frm_DailyReportGenerationforAllPlot_Load(object sender, EventArgs e)
        {
            if (clsUser.ThemeName == String.Empty)
            {
                ApplyTheme("TelerikMetro");
            }
            else
            {
                ApplyTheme(clsUser.ThemeName);
            }

            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.Text,
                @"SELECT[OCID], [Category_Name]  FROM[DHAPeshawarDB].[dbo].[tbl_Owner_Category]");
            dpOwnerCategory.DataSource = ds.Tables[0].DefaultView;
            dpOwnerCategory.DisplayMember = "Category_Name";
            dpOwnerCategory.ValueMember = "OCID";
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            SqlParameter[] param =
            {
                 new SqlParameter("@Task", "DailyReportGeneration"),
                  new SqlParameter("@OwnerID",dpOwnerCategory.SelectedValue),
                 new SqlParameter("@DepositeDate_From",dtpfromdate.Value.ToString("yyyy-MM-dd")),
                 new SqlParameter("@DepositeDate_To",dtptodate.Value.ToString("yyyy-MM-dd"))  
            };
           DataSet ds = cls_dl_InstRece.Inst_Rece_Read(param);
            if (ds.Tables.Count>0)
            {
                radgdInstReceive.DataSource = ds.Tables[0].DefaultView;
                foreach (GridViewDataColumn column in radgdInstReceive.Columns)
                {
                    column.BestFit();
                }
            }
            else
            {
                radgdInstReceive.DataSource = null;
            }
          
        }

        private void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(radgdInstReceive);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Software First.\n Error -> \n" + ex.Message);
            }
        }

        private void radgdInstReceive_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            #region This code is use to attach serial no. with grid , but in filtring,reOrdring etc the Serial No. order will be not disturbed
            if (e.CellElement.ColumnInfo.Name == "S.No" && string.IsNullOrEmpty(e.CellElement.Text))
            {
                e.CellElement.Text = (e.CellElement.RowIndex + 1).ToString();
            }
            #endregion
        }
    }
}
