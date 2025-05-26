using PeshawarDHASW.Data_Layer.clsFileMap;
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

namespace PeshawarDHASW.Application_Layer.Installment.InstallmentSummary
{
    public partial class Recalculation_Files_For_Statement : Telerik.WinControls.UI.RadForm
    {
        public Recalculation_Files_For_Statement()
        {
            InitializeComponent();
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
        }

        private void btn_LoadFiles_Click(object sender, EventArgs e)
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","Select_All_FileNo")
            };
            DataSet dst = new DataSet();
            dst = cls_dl_FileMap.FileMap_Reader(prm);
            grd_Files.DataSource = dst.Tables[0].DefaultView;
        }

        private void btn_RecalculationOfReceAdjustment_Click(object sender, EventArgs e)
        {
            ReCalBar.Maximum = 100;
            ReCalBar.Minimum = 0;
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","Truncate_3_Tables")
            };
            int rslt = 0;
            rslt = cls_dl_FileMap.FileMap_NonQuery(prm);
            if(rslt == -1)
            {
                #region Fire the Rece and Plan Adjust Query
                int filenos_count = grd_Files.RowCount;
                for (int i = 0; i < filenos_count; i++)
                {
                    ReCalBar.Value1 = (i / filenos_count) * 100;
                    string fileno = grd_Files.Rows[i].Cells["FileNo"].Value.ToString();
                    SqlParameter[] prmt =
                    {
                     new SqlParameter("@Task","Rece_Plan_Adjust"),
                     new SqlParameter("@FileNo",fileno)
                    };
                    int rsult = Data_Layer.Installment.cls_dl_FinanceDashBoard.AccountStatement_RecePlanAdjust(prmt);
                    if (rsult > 0)
                    {
                        lblmessage.Text = "File No. " + fileno + " Re-Calculation is Completed.";
                    }
                }

                #endregion
            }


        }

        private void Recalculation_Files_For_Statement_Load(object sender, EventArgs e)
        {

        }
    }
}
