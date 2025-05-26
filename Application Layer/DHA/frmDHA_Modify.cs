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
    public partial class frmDHA_Modify : Telerik.WinControls.UI.RadForm
    {
        public frmDHA_Modify()
        {
            InitializeComponent();
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            LoadDHA_Data();
        }
        private void LoadDHA_Data()
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
        private void grdDHADetail_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if(e.Column.Name == "btn_Modify")
            {
                int ID = int.Parse(grdDHADetail.CurrentRow.Cells["DHA_ID"].Value.ToString());
                frmDHA_Create frmobj = new frmDHA_Create(ID);
                frmobj.ShowDialog();
                LoadDHA_Data();
                //this.Close();
            }
        }
        private void frmDHA_Modify_Load(object sender, EventArgs e)
        {

        }
    }
}
