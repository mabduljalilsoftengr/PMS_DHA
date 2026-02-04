using PeshawarDHASW.Data_Layer.clsPhase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Phase
{
    public partial class frmPhase_Search : Telerik.WinControls.UI.RadForm
    {
        public frmPhase_Search()
        {
            InitializeComponent();
        }
        private void frmPhase_Search_Load(object sender, EventArgs e)
        {

        }
        private DataSet dst { get; set; }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadPhase_Data();
        }
        private void LoadPhase_Data()
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","Select"),
                new SqlParameter("@Name",txtName.Text),
                new SqlParameter("@Remarks",txtRemarks.Text),
                new SqlParameter("@GPSXY",txtGPRSXY.Text)
            };
            dst = cls_dl_Phase.Phase_Reader(prm);
            grdPhase.DataSource = dst.Tables[0].DefaultView;
        }
    }
}
