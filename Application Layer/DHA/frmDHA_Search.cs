using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.DHA
{
    public partial class frmDHA_Search : Telerik.WinControls.UI.RadForm
    {
        public frmDHA_Search()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","Select"),
                new SqlParameter("@Name",txtName.Text),
                new SqlParameter("@GPSXY",txtGPSXY.Text)
             };
             DataSet ds = Data_Layer.clsDHA.cls_dl_DHA.DHA_Reader(prm);
             grdDHADetail.DataSource = ds.Tables[0].DefaultView;
        }
    }
}
