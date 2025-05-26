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
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Installment.Surcharge
{
    public partial class frm_SurchargeWaveoffNew : Telerik.WinControls.UI.RadForm
    {
        public frm_SurchargeWaveoffNew()
        {
            InitializeComponent();
        }

        private void frm_SurchargeWaveoffNew_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Status", typeof(string));
            table.Rows.Add(1, "N/A");
            table.Rows.Add(2,"Wavieroff");
            table.Rows.Add(3,"Cancel");
          

            GridViewComboBoxColumn comboColumn = new GridViewComboBoxColumn();
            //set the FieldName - the column will retrieve the value from "Phone" column in the data table
            comboColumn.FieldName = "Status";
            comboColumn.Name = "SurchargeStatus";
           // comboColumn.ValueMember = "SurchargeStatus";
            comboColumn.DisplayMember = "Status";
            comboColumn.HeaderText = "Status";
            comboColumn.ValueMember = "ID";
            comboColumn.Width = 120;
            comboColumn.DropDownStyle = RadDropDownStyle.DropDownList;
            //add the column to the grid
            comboColumn.DataSource = table.DefaultView;
            DGVSurcharge.Columns.Add(comboColumn);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                if (filechecker() > 0)
                {
                    MessageBox.Show("File is Already Exist. Visit to Modify for Any Update");
                }
                else
                {
                    SqlParameter[] param = {
                new SqlParameter("@Task","SurchargeDataLoadforFreshEntry"),
                new SqlParameter("@FileNo",txtFileNo.Text)
                 };
                    DataSet ds = new DataSet();
                    ds = cls_dl_Surcharge.Surcharge_Reader(param);
                    DGVSurcharge.DataSource = ds.Tables[0].DefaultView;
                    // File Information
                    lblFileNo.Text = ds.Tables[1].Rows[0]["FileNo"].ToString();
                    lblName.Text = ds.Tables[1].Rows[0]["Name"].ToString();
                    lblCNIC.Text = ds.Tables[1].Rows[0]["NIC/NICOP"].ToString();
                    lblMobileno.Text = ds.Tables[1].Rows[0]["MobileNo"].ToString();
                    lblplotsize.Text = ds.Tables[1].Rows[0]["PlotSize"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
        }

        private void DGVSurcharge_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            try
            {
                int RowINdex = DGVSurcharge.CurrentRow.Index;
                string pervalue = DGVSurcharge.Rows[RowINdex].Cells["PerSurchargeWaveoff"].Value.ToString();
                Decimal percentage = 0;
                bool checker = Decimal.TryParse(pervalue, out percentage);
                if (checker == true)
                {
                    if (percentage > -1 && percentage < 101)
                    {
                        btnSaveSurcharge.Enabled = true;
                    }
                    else 
                    {
                        MessageBox.Show("Check your Wavieroff value.");
                        btnSaveSurcharge.Enabled = false;
                    }
                   
                }
                else
                {
                    MessageBox.Show("You Data is in Correct");
                    btnSaveSurcharge.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private int filechecker()
        {
            SqlParameter[] parmExisitng = {
                    new SqlParameter("@Task","FileExistChecking"),
                    new SqlParameter("@FileNo",txtFileNo.Text)
            };
            
            int counter = 0;
            bool checker = int.TryParse( Helper.SQLHelper.ExecuteScalar(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_SurchargeWaveoff", parmExisitng).ToString(),out counter);
            return counter;
        }
        private void btnSaveSurcharge_Click(object sender, EventArgs e)
        {
            if (filechecker() > 0)
            {
                MessageBox.Show("File is Already Exist. Visit to Modify for Update");
            }
            else
            {
                int result = 0;
                for (int i = 0; i < DGVSurcharge.RowCount; i++)
                {
                    GridViewComboBoxColumn comboBoxColumn = DGVSurcharge.Columns["SurchargeStatus"] as GridViewComboBoxColumn;
                    object value = DGVSurcharge.Rows[i].Cells["SurchargeStatus"].Value;
                    string SurchargeStatusText = (string)comboBoxColumn.GetLookupValue(value);
                    SqlParameter[] param = {
                        new SqlParameter("@Task","NewEntryforWaveoff"),
                        new SqlParameter("@FileMapKey",Helper.clsPluginHelper.DbNullIfNullOrEmpty(DGVSurcharge.Rows[i].Cells["FileMapKey"].Value.ToString())),
                        new SqlParameter("@InstallmentPlanID",Helper.clsPluginHelper.DbNullIfNullOrEmpty(DGVSurcharge.Rows[i].Cells["PlanID"].Value.ToString())),
                        new SqlParameter("@WaveoffinPer",Helper.clsPluginHelper.DbNullIfNullOrEmpty(DGVSurcharge.Rows[i].Cells["PerSurchargeWaveoff"].Value.ToString())),
                        new SqlParameter("@SurchargeStatus",Helper.clsPluginHelper.DbNullIfNullOrEmpty(SurchargeStatusText)),
                        new SqlParameter("@Remarks",Helper.clsPluginHelper.DbNullIfNullOrEmpty(DGVSurcharge.Rows[i].Cells["Remarks"].Value.ToString())),
                     };
                    int status = 0;
                    status = cls_dl_Surcharge.Surcharge_NonQuery(param);
                    result = result + status;
                }
                if (result > 0)
                {
                    MessageBox.Show("Successful");
                    DGVSurcharge.DataSource = null;
                }
            }
            
        }
    }
}
