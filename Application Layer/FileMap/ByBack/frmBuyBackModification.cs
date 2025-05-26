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
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.FileMap.ByBack
{
    public partial class frmBuyBackModification : Telerik.WinControls.UI.RadForm
    {
        public frmBuyBackModification()
        {
            InitializeComponent();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] prm =
                {
                    new SqlParameter("@Task","BuyBackReport")
                   // ,new SqlParameter("@Status", "Pending")
                };
                DataSet rslt = cls_dl_FileMap.Main_FileMap_Reader(prm);
                grdreportdata.DataSource = rslt.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmBuyBackModification_Load(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] prm =
                {
                    new SqlParameter("@Task","BuyBackReport")
                    //, new SqlParameter("@Status", "Pending")
                };
                DataSet rslt = cls_dl_FileMap.Main_FileMap_Reader(prm);
                grdreportdata.DataSource = rslt.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdreportdata_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "btnview")
                {
                    int bbid = int.Parse(e.Row.Cells["BID"].Value.ToString());
                    frmImageShow frm = new frmImageShow(bbid, "BuyBack");
                    frm.ShowDialog();
                }
                if (e.Column.Name== "btnBuyBackModification")
                {
                    
                        string BID = e.Row.Cells["BID"].Value.ToString();
                        frmByBackFileWiseEntryADStat obj = new frmByBackFileWiseEntryADStat(BID);
                        obj.ShowDialog();
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
