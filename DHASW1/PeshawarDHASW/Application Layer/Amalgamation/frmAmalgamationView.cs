using PeshawarDHASW.Application_Layer.Chalan;
using PeshawarDHASW.Data_Layer.clsChallan;
using PeshawarDHASW.Report.Challan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Amalgamation
{
    public partial class frmAmalgamationView : Telerik.WinControls.UI.RadForm
    {
        public frmAmalgamationView()
        {
            InitializeComponent();
        }

        private void frmAmalgamationView_Load(object sender, EventArgs e)
        {
            Dataloading();
        }

        private void btnNewRequestAmalgamation_Click(object sender, EventArgs e)
        {
            frmNewEntryAmalgamation obj = new frmNewEntryAmalgamation();
            obj.ShowDialog();
            Dataloading();
        }

        private void AmalgamationViewDGV_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "ChallanCopy")
            {
                string ChallanIDOut = e.Row.Cells["ChallanID"].Value.ToString();
                SqlParameter[] prm3 =
                   {
                                new SqlParameter("@Task","GetChallReportDetail"),
                                new SqlParameter("@ChallanID",ChallanIDOut)
                            };

                DataSet ds = cls_dl_Challan.Challan_Reader(prm3);
                ChallanDataset _ds = new ChallanDataset();

                _ds.Tables["tblChallan"].Merge(ds.Tables[0], true, MissingSchemaAction.Ignore);
                _ds.Tables["tblChallanDetail"].Merge(ds.Tables[1], true, MissingSchemaAction.Ignore);
                ds = null;
                frmChallanReportViewer obj = new frmChallanReportViewer(_ds);
                obj.ShowDialog();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Dataloading();
        }

        private void Dataloading()
        {
            SqlParameter[] paramAmalgamation =
                  {
                        new SqlParameter("@Task","AmalgamationView")
                    };
            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_tbl_Amalgamation", paramAmalgamation);

            AmalgamationViewDGV.DataSource = ds.Tables[0].DefaultView;
            foreach (var item in AmalgamationViewDGV.Columns)
            {
                item.BestFit();
            }
        }
    }
}
