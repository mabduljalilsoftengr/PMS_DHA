using PeshawarDHASW.Data_Layer.clsStampDuty;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.StampDuty
{
    public partial class frmStampDuty_Search : Telerik.WinControls.UI.RadForm
    {
        public frmStampDuty_Search()
        {
            InitializeComponent();
        }

        private void frmStampDuty_Search_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            SqlParameter[] prm =
            {
              new SqlParameter("@Task","Select_StampDuty_Buyer_Seller"),
              new SqlParameter("@FileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtFileNo.Text)),
              new SqlParameter("@RefNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtReferenceNo.Text)),
              new SqlParameter("@Name",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtName.Text)),
              new SqlParameter("@CNIC",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtCNIC.Text)),
              new SqlParameter("@MembershipNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtMSNo.Text)),
            };
            DataSet dst = new DataSet();
            dst = cls_dl_StampDuty.StampDuty_Reader(prm);
            radGridView2.DataSource = dst.Tables[0].DefaultView;
            gridViewTemplate1.DataSource = dst.Tables[1].DefaultView;
            foreach (var item in radGridView2.Columns)
            {
                item.BestFit();
            }
        }

        private void txtFileNo_Leave(object sender, EventArgs e)
        {
            //LoadData();
        }

        private void btn_Find_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
