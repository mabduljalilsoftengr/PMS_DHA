using PeshawarDHASW.Data_Layer.clsPosession;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.PlotsPosession
{
    public partial class frmPosessionRcievedByFinanceBr : Telerik.WinControls.UI.RadForm
    {
        public frmPosessionRcievedByFinanceBr()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetDataForPayment();
        }
        private void GetDataForPayment()
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","GetPosessionDetailForPayment")
            };
            DataSet dst = cls_dl_posession.Posession_Reader(prm);
            grdPosession.DataSource = dst.Tables[0].DefaultView;
            grdPosessiondetailExpired.DataSource = dst.Tables[1].DefaultView;
        }

        private void grdPosession_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            int PFormNo = int.Parse(e.Row.Cells["PFormNo"].Value.ToString());
            if(e.Column.Name == "btnGenerateChallan")
            {
                frmPossessionChallan frm = new frmPossessionChallan(PFormNo);
                frm.ShowDialog();
            }
        }

        private void frmPosessionRcievedByFinanceBr_Load(object sender, EventArgs e)
        {
            GetDataForPayment();
        }
    }
}
