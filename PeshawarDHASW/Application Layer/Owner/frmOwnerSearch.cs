using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.Owner;
using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Owner
{
    public partial class frmOwnerSearch : Telerik.WinControls.UI.RadForm
    {
        public frmOwnerSearch()
        {
            InitializeComponent();
        }

        private void frmOwnerSearch_Load(object sender, EventArgs e)
        {
            SearchOwnerData();
        }
       
        private void SearchOwnerData()
        {
            try
            {
                SqlParameter[] param =
                {
                new SqlParameter("@Task","Select"),
                new SqlParameter("@EntryStatus","New"),
                new SqlParameter("@Fileno",clsPluginHelper.DbNullIfNullOrEmpty(txtFileNo.Text)),
                new SqlParameter("@MSNO",clsPluginHelper.DbNullIfNullOrEmpty(txtMSNo.Text)),
                new SqlParameter("@RateofSale",clsPluginHelper.DbNullIfNullOrEmpty(txtRateOfSale.Text))
                };
                DataSet ds = new DataSet();
                ds = cls_dl_Owner.Owner_Reader(param);
                grdOwnerdata.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on SearchOwnerData.", ex, "frmOwnerSearch");
                frmobj.ShowDialog();
            }
           
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            SearchOwnerData();
        }
    }
}
