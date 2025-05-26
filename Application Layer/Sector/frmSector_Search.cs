using PeshawarDHASW.Data_Layer.clsSector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Sector
{
    public partial class frmSector_Search : Telerik.WinControls.UI.RadForm
    {
        private DataSet dst { get; set; }
        public frmSector_Search()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadSector_Data();
        }
        private void LoadSector_Data()
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","Select"),
                new SqlParameter("@Name",txtName.Text),
                new SqlParameter("@Remarks",txtRemarks.Text),
                new SqlParameter("@GPSXY",txtGPRSXY.Text)
            };
            dst = cls_dl_Sector.Sector_Reader(prm);
            grdSector.DataSource = dst.Tables[0].DefaultView;
        }
    }
}
