using PeshawarDHASW.Data_Layer.Installment;
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
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Installment.InstReceive
{
    public partial class frm_NatureOfDDAmount : Telerik.WinControls.UI.RadForm
    {
        public frm_NatureOfDDAmount()
        {
            InitializeComponent();
        }

        private void CreateAutoGenerateHierarchy()
        {
            using (this.grd_ReceInstallment.DeferRefresh())
            {
                this.grd_ReceInstallment.MasterTemplate.Reset();
                this.grd_ReceInstallment.TableElement.RowHeight = 20;
                this.grd_ReceInstallment.DataMember = "Customers";

                this.grd_ReceInstallment.AutoGenerateHierarchy = true;
                // SetupMasterForAutoGenerateHierarchy();
            }
        }
        private void SearchingDD()
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@Task", "search_DD_Nature"),
                //new SqlParameter("@PANo", clsPluginHelper.DbNullIfNullOrEmpty(txtPANo.Text)),
                //new SqlParameter("@FileNo", clsPluginHelper.DbNullIfNullOrEmpty(txtfileno.Text)),
                //new SqlParameter("@PlotNo", clsPluginHelper.DbNullIfNullOrEmpty(txtplotno.Text)),
                //new SqlParameter("@Date", clsPluginHelper.DbNullIfNullOrEmpty(txtdate.Text)),
                //new SqlParameter("@MSNo", clsPluginHelper.DbNullIfNullOrEmpty(txtmsno.Text)),
                //new SqlParameter("@NIC", clsPluginHelper.DbNullIfNullOrEmpty(txtnic.Text)),
                //new SqlParameter("@Amount", clsPluginHelper.DbNullIfNullOrEmpty(txtamount.Text)),
                //new SqlParameter("@Status", clsPluginHelper.DbNullIfNullOrEmpty(txtstatus.Text)),
                //new SqlParameter("@DDStatus", clsPluginHelper.DbNullIfNullOrEmpty(txtDDstatus.Text)),
                //new SqlParameter("@DDNo", clsPluginHelper.DbNullIfNullOrEmpty(txtDDno.Text)),
                //new SqlParameter("@BankName", clsPluginHelper.DbNullIfNullOrEmpty(txtbankname.Text)),
                //new SqlParameter("@Branch", clsPluginHelper.DbNullIfNullOrEmpty(txtbranch.Text)),
                //new SqlParameter("@Remarks", clsPluginHelper.DbNullIfNullOrEmpty(txtremarks.Text))
            };
            try
            {
                DataSet ds = cls_dl_InstRece.Inst_Rece_Read(parameters);
                grd_ReceInstallment.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.InnerException);
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            SearchingDD();
        }

        private void frm_NatureOfDDAmount_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);

            DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.Text, "select Blh_ID,List_No from tbl_BankList_Head order by 1 desc");
            if (ds.Tables.Count > 0)
            {
                cmbList.DataSource = ds.Tables[0];
                cmbList.ValueMember = "Blh_ID";
                cmbList.DisplayMember = "List_No";
            }

            //SearchingDD();
        }

        private void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(MasterTemplate);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Software First.\n Error -> \n" + ex.Message);
            }
        }

        private void grd_ReceInstallment_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement.ColumnInfo.Name == "SNo" && string.IsNullOrEmpty(e.CellElement.Text))
            {
                e.CellElement.Text = (e.CellElement.RowIndex + 1).ToString();
            }
        }

        private void radRadioButton1_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (radDate.CheckState == CheckState.Checked)
                grp1.Enabled = true;
            else
                grp1.Enabled = false;
        }

        private void radRadioButton3_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (radList.CheckState == CheckState.Checked)
                grp2.Enabled = true;
            else
                grp2.Enabled = false;
        }

        private void btnsearch_Click_1(object sender, EventArgs e)
        {
            if (radList.IsChecked)
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task", "search_DD_Nature"),
                    new SqlParameter("@Blh_ID", cmbList.SelectedValue), 
                };
                try
                {
                    DataSet ds = cls_dl_InstRece.Inst_Rece_Read(parameters);
                    //grd_ReceInstallment.DataSource = ds.Tables[0].DefaultView;
                    MasterTemplate.DataSource = ds.Tables[0].DefaultView;
                    clsPluginHelper.GridColumnBestFit(MasterTemplate);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.InnerException);
                }
            }
            else if (radDate.IsChecked)
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task", "search_DD_Nature"),
                    new SqlParameter("@Status",  clsPluginHelper.DbNullIfNullOrEmpty(cmbDdStatus.Text)),
                    new SqlParameter("@FromDate",dtpFromDate.Value.Date),
                    new SqlParameter("@ToDate", dtpToDate.Value.Date),
                };
                try
                {
                    DataSet ds = cls_dl_InstRece.Inst_Rece_Read(parameters);
                    MasterTemplate.DataSource = ds.Tables[0].DefaultView;
                    clsPluginHelper.GridColumnBestFit(MasterTemplate);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.InnerException);
                }
            }

            
        }

        private void radButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
