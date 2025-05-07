using PeshawarDHASW.Data_Layer.NDC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    public partial class frmUrgentNDCTFR_Charges : Telerik.WinControls.UI.RadForm
    {
        public frmUrgentNDCTFR_Charges()
        {
            InitializeComponent();
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","GetUrgentNDCChallan"),
                new SqlParameter("@RequiredDate",dtpcurrentdate.Value.Date)
            };
            DataSet dst = cls_dl_NDC.NdcRetrival(prm);
            grdurgentchallans.DataSource = dst.Tables[0].DefaultView;
        }

        private void btnexcelexport_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(grdurgentchallans);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Software First.\n Error -> \n" + ex.Message);
            }
        }
    }
}
