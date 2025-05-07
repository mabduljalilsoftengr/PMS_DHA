using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer;
using Telerik.Charting;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.DashBoards
{
    public partial class frmMISAdminDashBoard : Telerik.WinControls.UI.RadForm
    {
        public frmMISAdminDashBoard()
        {
            InitializeComponent();
        }

        private void Userloading()
        {
            
        }

        private void btnProfmanceChecker_Click(object sender, EventArgs e)
        {
            try
            {
                BarSeries series = new BarSeries();
                SqlParameter[] parameters =
                {
                new SqlParameter("@Task","SpeedPerformancePerDay"),
                new SqlParameter("@username",dpuserinfo.SelectedItem.Text),
            };
                DataSet ds = cls_dl_DashBoard.Dashboard(parameters);
                //series.DataSource = ds.Tables[0].DefaultView;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    int count = int.Parse(row["Record"].ToString());
                    series.DataPoints.Add(new CategoricalDataPoint(count, row["Name"].ToString()));

                }
                PerformanceChart.Series.Add(series);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnProfmanceChecker_Click.", ex, "frmMISAdminDashBoard");
                frmobj.ShowDialog();

            }


        }

        private void frmMISAdminDashBoard_Load(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@Task","Userinfodropdown"),
                };
                DataSet ds = cls_dl_DashBoard.Dashboard(parameters);
                dpuserinfo.DataSource = ds.Tables[0].DefaultView;
                dpuserinfo.DataMember = "ID";
                dpuserinfo.ValueMember = "Name";
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmMISAdminDashBoard_Load.", ex, "frmMISAdminDashBoard");
                frmobj.ShowDialog();
            }
            
        }
    }
}
