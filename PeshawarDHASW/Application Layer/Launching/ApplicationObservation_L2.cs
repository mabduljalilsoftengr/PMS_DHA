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
    public partial class ApplicationObservation_L2 : Telerik.WinControls.UI.RadForm
    {
        public ApplicationObservation_L2()
        {
            InitializeComponent();
            DataLoading();
        }

        private void btnSearchRecord_Click(object sender, EventArgs e)
        {
            DataLoading();
        }
        private void DataLoading()
        {
            SqlParameter[] param = {
                new SqlParameter("@ApplicantName", Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtApplicantName.Text)),
                new SqlParameter("@CNIC_NICOP",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtCNIC.Text)),
                new SqlParameter("@MobileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtMobile.Text)),
                new SqlParameter("@FormNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtFormNo.Text)),
                new SqlParameter("@District",Helper.clsPluginHelper.DbNullIfNullOrEmpty(ApplicantDistrict.Text)),
                new SqlParameter("@Country",Helper.clsPluginHelper.DbNullIfNullOrEmpty(ApplicantCountry.Text)),
                new SqlParameter("@Gender",Helper.clsPluginHelper.DbNullIfNullOrEmpty(ApplicationGender.Text)),
                new SqlParameter("@Province",Helper.clsPluginHelper.DbNullIfNullOrEmpty(cbProvince.Text)),
                new SqlParameter("@Category",Helper.clsPluginHelper.DbNullIfNullOrEmpty(cbCategory.Text))
            };
            DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "Launching.p_Gettbl_ApplicationInfoForObservation", param);
            DGV_ApplicantSearch.DataSource = ds.Tables[0].DefaultView;
            foreach (var item in DGV_ApplicantSearch.Columns)
            {
                item.BestFit();
            }
        }

        private void DGV_ApplicantSearch_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "Edit")
                {
                    int applicaitonID = int.Parse(e.Row.Cells["ApplicationID"].Value.ToString());
                    ApplicationRecordModify obj = new ApplicationRecordModify(applicaitonID, "Pending");
                    obj.ShowDialog();
                    DataLoading();
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(DGV_ApplicantSearch);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Software First.\n Error -> \n" + ex.Message);
            }
        }

        private void ApplicationObservation_L2_Load(object sender, EventArgs e)
        {

        }
    }
}
