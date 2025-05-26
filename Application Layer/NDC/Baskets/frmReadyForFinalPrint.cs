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

namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    public partial class frmReadyForFinalPrint : Telerik.WinControls.UI.RadForm
    {
        public frmReadyForFinalPrint()
        {
            InitializeComponent();
        }

        private void frmReadyForFinalPrint_Load(object sender, EventArgs e)
        {
            LoadData();

        }
        private void LoadData()
        {
            SqlParameter[] prmt =
            {
                 new SqlParameter("@Task","GetNDCData_ForFinalPrint")
            };
            DataSet dst = cls_dl_NDC.NdcRetrival(prmt);
            grdShowVerifiedNDCS.DataSource = dst.Tables[0].DefaultView;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void grdShowVerifiedNDCS_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if(e.Column.Name == "btnprint")
            {
                int ndcno = int.Parse(e.Row.Cells["NDCNo"].Value.ToString());

                frmNDC_Report chk = new frmNDC_Report(ndcno, "CheckListReport","ReadyForFinalPrint");
                chk.Show();
                frmNDC_Report obj = new frmNDC_Report(ndcno, "NDCReport", "ReadyForFinalPrint");
                obj.ShowDialog();
                LoadData();
               
            }
            else if(e.Column.Name == "btnBack")
            {
                if(MessageBox.Show("Are you go back ?","Attention !",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    int ndcno = int.Parse(e.Row.Cells["NDCNo"].Value.ToString());
                    // Verified
                    SqlParameter[] prmt =
                             {
                         new SqlParameter("@Task","Update_NDC_Status"),
                         new SqlParameter("@StatusofNDC","Verified"),
                         new SqlParameter("@NDCNo",ndcno)
                         };
                    int rslt = cls_dl_NDC.NdcNonQuery(prmt);
                    if (rslt > 0)
                    {
                        MessageBox.Show("NDC status updated successfully.");
                        LoadData();
                    }
                }
                
            }
        }
    }
}
