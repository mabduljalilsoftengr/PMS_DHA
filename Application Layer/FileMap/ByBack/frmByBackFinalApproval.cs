using PeshawarDHASW.Data_Layer.clsFileMap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.FileMap.ByBack
{
    public partial class frmByBackFinalApproval : Telerik.WinControls.UI.RadForm
    {
        public frmByBackFinalApproval()
        {
            InitializeComponent();
        }

        private void btnloaddata_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","GetDataForFinallyApprovalBuyBack")
            };
            DataSet dst = cls_dl_FileMap.Main_FileMap_Reader(prm);
            grdapproved.DataSource = dst.Tables[0].DefaultView;
            btnFinallyApprovedData.DataSource = dst.Tables[1].DefaultView;
        }

        private void frmByBackFinalApproval_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void grdpendingdata_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if(e.Column.Name == "btnuploaddocuments")
            {
                int buybackid = int.Parse(e.Row.Cells["BID"].Value.ToString());
                frmBuyBackImage frm = new frmBuyBackImage(buybackid);
                frm.ShowDialog();
                LoadData();

            }
            else if(e.Column.Name == "btnApproved")
            {
                if (MessageBox.Show("Are You Upload the Images ???","Attention !",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
                {
                    int buybackid = int.Parse(e.Row.Cells["BID"].Value.ToString());
                    string fln = e.Row.Cells["FileNo"].Value.ToString(); 
                    SqlParameter[] prm =
                    {
                    new SqlParameter("@Task","UpdateBuyBackStatus"),
                    new SqlParameter("@BID",buybackid),
                    new SqlParameter("@Status","FinallyApproved"),
                    new SqlParameter("@FileNo",fln)
                    };
                    int rsl = cls_dl_FileMap.Main_FileMap_NonQuery(prm);
                    if (rsl > 0)
                    {
                        MessageBox.Show("Success.");
                        LoadData();
                    }
                }
            }
        }

        private void btnFinallyApprovedData_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                int buybackid = int.Parse(e.Row.Cells["BID"].Value.ToString());
                frmImageShow frm = new frmImageShow(buybackid, "BuyBack");
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
