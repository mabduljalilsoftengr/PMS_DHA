using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Application_Layer.Installment.InstReceive.InstReceiveModify;
using PeshawarDHASW.Data_Layer.Installment;
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
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Installment.InstReceive
{
    public partial class frmReceReview : Telerik.WinControls.UI.RadForm
    {
        public frmReceReview()
        {
            InitializeComponent();
        }

        private void SearchingDD()
        {
            try
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@Task", "ModifySearch"),
                 new SqlParameter("@PANo", clsPluginHelper.DbNullIfNullOrEmpty(txtPANo.Text)),
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
                if (ds.Tables[0].Rows.Count > 0)
                {
                    radgdInstReceive.DataSource = ds.Tables[0].DefaultView;
                    foreach (GridViewDataColumn column in radgdInstReceive.Columns)
                    {
                        column.BestFit();
                    }
                }
                else
                {
                    MessageBox.Show("Data not Found Retry Again.");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on SearchingDD.", ex, "frmReceInstModify");
                // frmobj.ShowDialog();
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            SearchingDD();
        }

        private void radgdInstReceive_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = radgdInstReceive.CurrentCell.RowIndex;
                int columnindex = radgdInstReceive.CurrentCell.ColumnIndex;

                if (e.Column.Name == "bmodify")
                {
                    int ID = 0;
                    bool M = int.TryParse(radgdInstReceive.ChildRows[rowindex].Cells["Rece_ID"].Value.ToString(), out ID);
                    if (M != false)
                    {
                        InstReceiveModify.frmDDModify obj = new frmDDModify(ID);
                        obj.ShowDialog();
                        SearchingDD();
                    }
                    else
                    {
                        MessageBox.Show("Restart the Application");
                    }
                }

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on radgdInstReceive_CellClick_1.", ex, "frmReceInstModify");
                // frmobj.ShowDialog();
                // MessageBox.Show("Kindly Select DD Status.");
            }
        }
    }
}
