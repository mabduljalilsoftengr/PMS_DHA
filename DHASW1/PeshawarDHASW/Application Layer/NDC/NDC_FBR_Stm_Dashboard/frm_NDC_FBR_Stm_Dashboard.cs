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

namespace PeshawarDHASW.Application_Layer.NDC.NDC_FBR_Stm_Dashboard
{
    public partial class frm_NDC_FBR_Stm_Dashboard : Telerik.WinControls.UI.RadForm
    {
        public frm_NDC_FBR_Stm_Dashboard()
        {
            InitializeComponent();
        }

        private void frm_NDC_FBR_Stm_Dashboard_Load(object sender, EventArgs e)
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","NDC_Stm_FBR_DashBoard")
            };
            DataSet dst = cls_dl_NDC.NdcRetrival(prm);
            grdNDC.DataSource = dst.Tables[0].DefaultView;
            grdStampDuty.DataSource = dst.Tables[1].DefaultView;
            grdFBR.DataSource = dst.Tables[2].DefaultView;
        }
    }
}
