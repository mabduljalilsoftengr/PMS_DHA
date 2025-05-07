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
    public partial class frmLandProviderQuoaDetail : Telerik.WinControls.UI.RadForm
    {
        public frmLandProviderQuoaDetail()
        {
            InitializeComponent();
        }

        private void frmLandProviderQuoaDetail_Load(object sender, EventArgs e)
        {
            QuotaDetail();
        }
        private void QuotaDetail()
        {
           SqlParameter[] par =
           {
                new SqlParameter("@Task", "GetQuotaDetail")
            };
            DataSet dst = cls_dl_FileMap.Main_FileMap_Reader(par);
            grddatadetail.DataSource = dst.Tables[0].DefaultView;
        }

        private void btnloaddata_Click(object sender, EventArgs e)
        {
            QuotaDetail();
        }

        private void grddatadetail_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if(e.Column.Name == "btnDetail")
            {
                //int lpid = int.Parse(e.Row.Cells["LPID"].Value.ToString());
                string cnic = e.Row.Cells["CNIC"].Value.ToString();
                SqlParameter[] par =
                {
                  new SqlParameter("@Task", "Specific_GetQuotaDetail"),
                  new SqlParameter("@CNIC",cnic)
                };
                DataSet dst = cls_dl_FileMap.Main_FileMap_Reader(par);
                frmLandProviderQuoaDetail_Specific frm = new frmLandProviderQuoaDetail_Specific(dst);
                frm.ShowDialog();
            }
        }
    }
}
