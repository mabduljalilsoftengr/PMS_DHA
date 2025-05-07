using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.TP_BC
{
    public partial class frmHouseSetting : Telerik.WinControls.UI.RadForm
    {
        public frmHouseSetting()
        {
            InitializeComponent();
            DataView();
        }

        private void DataView()
        {
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@Task","DataView")
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_House", param);
                gdvHousedata.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmHouseSetting_Load(object sender, EventArgs e)
        {

        }

        private void btnNewHouse_Click(object sender, EventArgs e)
        {
            frmNewHouse obj = new frmNewHouse();
            obj.ShowDialog();
            DataView();
        }

        private void gdvHousedata_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name =="Edit")
            {
                string HouseID = e.Row.Cells["HouseID"].Value.ToString();
                frmNewHouse obj = new frmNewHouse(HouseID);
                    obj.ShowDialog();
                DataView();
            }
        }

        private void gdvHousedata_Click(object sender, EventArgs e)
        {

        }
    }
}
