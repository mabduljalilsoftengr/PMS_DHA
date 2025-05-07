using PeshawarDHASW.Data_Layer.Installment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Installment.InstReceive
{
    public partial class frmListOfDD_ReadyForBankDeposite_Head : Telerik.WinControls.UI.RadForm
    {
        public frmListOfDD_ReadyForBankDeposite_Head()
        {
            InitializeComponent();
        }

        private void frmListOfDD_ReadyForBankDeposite_Head_Load(object sender, EventArgs e)
        {
            LoadData();    
            //test
        }
        private void LoadData()
        {
            try
            {
                SqlParameter[] prm = {
                                    new SqlParameter("@task", "Select_BankList"),
                                    new SqlParameter("@List_No",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtListNo.Text))
                                };
                DataSet dst = cls_dl_InstRece.Inst_Rece_Read(prm);
                grd_DDBankListHead.DataSource = dst.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void grd_DDBankListHead_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if(e.Column.Name == "btn_LoadDetail")
            {
                int blhid = int.Parse(grd_DDBankListHead.Rows[grd_DDBankListHead.CurrentCell.RowIndex].Cells["Blh_ID"].Value.ToString() );
                frmListOfDD_ReadyForBankDeposite_Detail frmobj = new frmListOfDD_ReadyForBankDeposite_Detail(blhid);
                frmobj.ShowDialog();

            }
            //Report Changes
            if (e.Column.Name == "Report")
            {
                string ListNo = grd_DDBankListHead.Rows[grd_DDBankListHead.CurrentCell.RowIndex].Cells["List_No"].Value.ToString();
                DataSet dst = new DataSet();
                SqlParameter[] param = {
                    new SqlParameter("@Task","BankListDuplicateReport"),
                    new SqlParameter("@List_No",ListNo)
                };
                dst = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_tbl_ReceInst", param);



                frmListOfDD_ReadyForBankDeposite_ReportViewer frmobj = new frmListOfDD_ReadyForBankDeposite_ReportViewer(dst);
                frmobj.ShowDialog();

            }
        }

        private void btn_Find_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(grd_DDBankListHead);
        }

        private void btnBL_byDate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] prm = {
                                    new SqlParameter("@task", "Select_byBLDate"),
                                    new SqlParameter("@StartDate",ListStartDate.Value),
                                     new SqlParameter("@EndDate",ListEndDate.Value)
                                };
                DataSet dst = cls_dl_InstRece.Inst_Rece_Read(prm);
                grd_DDBankListHead.DataSource = dst.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           

        }
    }
}
