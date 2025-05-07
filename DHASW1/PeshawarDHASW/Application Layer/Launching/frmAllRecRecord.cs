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
    public partial class frmAllRecRecord : Telerik.WinControls.UI.RadForm
    {
        public frmAllRecRecord()
        {
            InitializeComponent();
        }

        private void btnSearchComplete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] param = {
                new SqlParameter("@ApplicantName", Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtApplicantNameCA.Text)),
                new SqlParameter("@CNIC_NICOP",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtCNIC_CA.Text)),
                new SqlParameter("@MobileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtMobileNoCA.Text)),
                new SqlParameter("@FormNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtFormNoCA.Text)),
                new SqlParameter("@ApplyMode",rdpapplymode.Text == "All" ? null : rdpapplymode.Text)
            };
                DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "Launching.p_Gettbl_AllRecordofRece", param);
                dgrapplicantinfo.DataSource = ds.Tables[0].DefaultView;
                foreach (var item in dgrapplicantinfo.Columns)
                {
                    item.BestFit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmAllRecRecord_Load(object sender, EventArgs e)
        {
            rdpapplymode.SelectedIndex = 0;
        }

        private void btnExceExport_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(dgrapplicantinfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Party Software First.\n Error -> \n" + ex.Message);
            }
        }
    }
}
