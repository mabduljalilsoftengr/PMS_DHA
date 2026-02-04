using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Telerik.WinControls;
using PeshawarDHASW.Data_Layer.Installment;
using PeshawarDHASW.Helper;


namespace PeshawarDHASW.Application_Layer.Installment.InstReceive
{
    public partial class frmAccountStatementSearch : Telerik.WinControls.UI.RadForm
    {
        public frmAccountStatementSearch()
        {
            InitializeComponent();
        }

        private void SearchingDD()
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@Task", "search"),
                new SqlParameter("@FileNo", clsPluginHelper.DbNullIfNullOrEmpty(txtfileno.Text)),
                new SqlParameter("@PlotNo", clsPluginHelper.DbNullIfNullOrEmpty(txtplotno.Text)),
                new SqlParameter("@Date", clsPluginHelper.DbNullIfNullOrEmpty(txtdate.Text)),
                new SqlParameter("@MSNo", clsPluginHelper.DbNullIfNullOrEmpty(txtmsno.Text)),
                new SqlParameter("@NIC", clsPluginHelper.DbNullIfNullOrEmpty(txtnic.Text)),
                new SqlParameter("@Amount", clsPluginHelper.DbNullIfNullOrEmpty(txtamount.Text)),
                new SqlParameter("@Status", clsPluginHelper.DbNullIfNullOrEmpty(txtstatus.Text)),
                new SqlParameter("@DDStatus", clsPluginHelper.DbNullIfNullOrEmpty(txtDDstatus.Text)),
                new SqlParameter("@DDNo", clsPluginHelper.DbNullIfNullOrEmpty(txtDDno.Text)),
                new SqlParameter("@BankName", clsPluginHelper.DbNullIfNullOrEmpty(txtbankname.Text)),
                new SqlParameter("@Branch", clsPluginHelper.DbNullIfNullOrEmpty(txtbranch.Text)),
                new SqlParameter("@Remarks", clsPluginHelper.DbNullIfNullOrEmpty(txtremarks.Text))
            };
            DataSet ds = cls_dl_InstRece.Inst_Rece_Read(parameters);
            radgdInstReceive.DataSource = ds.Tables[0].DefaultView;
            if (ds.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                RadMessageBox.Show("DD is not exist.", "Warning", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
            }
        }
        private void btnsearch_Click(object sender, EventArgs e)
        {
            SearchingDD();
        }
    }
}
