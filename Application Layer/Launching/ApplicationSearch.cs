using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Launching
{
    public partial class ApplicationSearch : Telerik.WinControls.UI.RadForm
    {
        public ApplicationSearch()
        {
            InitializeComponent();
            DataLoading();
        }
        private void DataLoading()
        {
            try
            {
                SqlParameter[] param = {
                new SqlParameter("@ApplicantName", Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtApplicantName.Text)),
                new SqlParameter("@CNIC_NICOP",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtCNIC.Text)),
                new SqlParameter("@MobileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtMobile.Text)),
                new SqlParameter("@FormNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtFormNo.Text)),
                //new SqlParameter("@City",Helper.clsPluginHelper.DbNullIfNullOrEmpty(ApplicantCity.Text)),
                new SqlParameter("@District",Helper.clsPluginHelper.DbNullIfNullOrEmpty(ApplicantDistrict.Text)),
                new SqlParameter("@Country",Helper.clsPluginHelper.DbNullIfNullOrEmpty(ApplicantCountry.Text)),
                  new SqlParameter("@Gender",Helper.clsPluginHelper.DbNullIfNullOrEmpty(ApplicationGender.Text)),
                  new SqlParameter("@Province",Helper.clsPluginHelper.DbNullIfNullOrEmpty(cbProvince.Text)),
                  new SqlParameter("@Category",Helper.clsPluginHelper.DbNullIfNullOrEmpty(cbCategory.Text))
            };
                DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "Launching.p_Gettbl_ApplicationInfo", param);
                DGV_ApplicantSearch.DataSource = ds.Tables[0].DefaultView;
                foreach (var item in DGV_ApplicantSearch.Columns)
                {
                    item.BestFit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        private void btnSearchRecord_Click(object sender, EventArgs e)
        {
            DataLoading();
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(DGV_ApplicantSearch);
        }

        private void ApplicationSearch_Load(object sender, EventArgs e)
        {

        }
    }
}
