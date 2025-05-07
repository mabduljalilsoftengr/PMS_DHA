using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Application_Layer.Installment.InstReceive.InstReceiveModify;
using PeshawarDHASW.Application_Layer.Membership.MSViewInfo;
using PeshawarDHASW.Data_Layer.Installment;
using PeshawarDHASW.Helper;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using PeshawarDHASW.Data_Layer.clsChallanRece;
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Application_Layer.Installment.InstReceive.ImageRead;
using Telerik.WinControls.Data;
using PeshawarDHASW.Models;

namespace PeshawarDHASW.Application_Layer.Installment.InstReceive
{
    public partial class frmReceInstModify : Telerik.WinControls.UI.RadForm
    {
        public frmReceInstModify()
        {
            InitializeComponent();
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
        }

        #region  DD Information


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
                   new SqlParameter("@Remarks", clsPluginHelper.DbNullIfNullOrEmpty(txtremarks.Text)),
                   new SqlParameter("@PaymentMethod",clsPluginHelper.DbNullIfNullOrEmpty(drpPaymentMethod.Text))
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
            Summary_Column();
        }
        private void Summary_Column()
        {
            radgdInstReceive.SummaryRowsBottom.Clear();
            GridViewSummaryItem summaryItem = new GridViewSummaryItem();
            summaryItem.Name = "Amount";
            summaryItem.Aggregate = GridAggregateFunction.Sum;
            summaryItem.FormatString = "{0:#,###0.00;(#,###0.00);0}";

            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
            summaryRowItem.Add(summaryItem);
            this.radgdInstReceive.SummaryRowsBottom.Add(summaryRowItem);

        }

        private void radgdInstReceive_CellClick_1(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;
                int columnindex = e.ColumnIndex;

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
                if (e.Column.Name == "Attachments")
                {

                    int ID = 0;
                    bool M = int.TryParse(radgdInstReceive.ChildRows[rowindex].Cells["Rece_ID"].Value.ToString(), out ID);

                    if (M != false)
                    {
                        frmDDScanImageModify obj = new frmDDScanImageModify(ID.ToString());
                        obj.ShowDialog();
                        //Image ID is get
                        //MessageBox.Show("DDImage - > " + ID.ToString());
                        //frmReceInstalImage objFrmReceInstalImage = new frmReceInstalImage(ID, false);
                        //objFrmReceInstalImage.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("No Attachment Exist againts this Transaction No.");
                    }
                }
                if (e.Column.Name == "bID")
                {
                    int ID = 0;
                    bool M = int.TryParse(radgdInstReceive.ChildRows[rowindex].Cells["ID"].Value.ToString(), out ID);
                    if (M != false)
                    {
                        Membership.MSViewInfo.MSBioInfo obj = new MSBioInfo(ID);
                        obj.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Member Ship does not exist");
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
        #endregion
        private void frmReceInstModify_Load(object sender, EventArgs e)
        {
        }
        private void Excel_Like_Filtring()
        {
            this.radgdInstReceive.EnableFiltering = true;
            this.radgdInstReceive.MasterTemplate.ShowHeaderCellButtons = true;
            this.radgdInstReceive.MasterTemplate.ShowFilteringRow = false;
        }
        private void radgdInstReceive_FilterPopupRequired(object sender, FilterPopupRequiredEventArgs e)
        {
            if (e.Column.Name == "Date")
            {
                e.FilterPopup = new RadDateFilterPopup(e.Column);
            }
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(radgdInstReceive);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Software First.\n Error -> \n" + ex.Message);
            }

        }

        private void txtfileno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnsearch_Click(null, null);
            }
        }

        private void txtplotno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnsearch_Click(null, null);
            }
        }

        private void txtmsno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnsearch_Click(null, null);
            }
        }

        private void txtnic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnsearch_Click(null, null);
            }
        }

        private void txtDDno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnsearch_Click(null, null);
            }
        }

        private void txtPANo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnsearch_Click(null, null);
            }
        }

        private void btnddclearmis_Click(object sender, EventArgs e)
        {
            int trno = Convert.ToInt32(txtTransactionNo.Text);
            frmBlock_SMS_Email_AckLetter frm = new frmBlock_SMS_Email_AckLetter(trno);
            frm.ShowDialog();
        }
    }
}
