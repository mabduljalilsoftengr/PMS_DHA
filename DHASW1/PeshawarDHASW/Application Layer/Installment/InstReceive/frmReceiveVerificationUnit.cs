using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Application_Layer.Installment.InstReceive.ImageRead;
using PeshawarDHASW.Data_Layer.clsChallanRece;
using PeshawarDHASW.Data_Layer.Installment;
using PeshawarDHASW.Models;
using Telerik.WinControls;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.Installment.InstReceive
{
    public partial class frmReceiveVerificationUnit : Telerik.WinControls.UI.RadForm
    {
        public frmReceiveVerificationUnit()
        {
            InitializeComponent();
        }

        private void DGVControls()
        {
            
           // gvChallan.MasterTemplate.Columns.Add(clsPluginHelper.GdButton("btnVerify", "ChallanIDD", "Verify", "Verify", 80));
        }

        private void SearchingDD()
        {
            try
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
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on SearchingDD.", ex, "frmReceiveVerificationUnit");
                frmobj.ShowDialog();
            }
           
        }

        private void ChallanSearch()
        {
            try
            {
                SqlParameter[] parameters =
                            {
                new SqlParameter("@Task","Select"),
                new SqlParameter( "@FileNo", clsPluginHelper.DbNullIfNullOrEmpty(txtchallanFileno.Text)),
                new SqlParameter("@NICNICOP",clsPluginHelper.DbNullIfNullOrEmpty(txtchallanNIC.Text)),
                new SqlParameter("@Name",clsPluginHelper.DbNullIfNullOrEmpty(txtchallanName.Text)),
                new SqlParameter("@ChallanNo",clsPluginHelper.DbNullIfNullOrEmpty(txtchallanNo.Text)),
                new SqlParameter() {ParameterName = "@DateofRece",SqlDbType = SqlDbType.DateTime, SqlValue = clsPluginHelper.DbNullIfNullOrEmpty(txtchallandate.Text)},
            };
                DataSet ds = cls_dl_ChallanRece.ChallanRece_Reader(parameters);
                gvChallan.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on ChallanSearch.", ex, "frmReceiveVerificationUnit");
                frmobj.ShowDialog();
            }

        }
        private void frmReceiveVerificationUnit_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            DGVControls();
            SearchingDD();
            ChallanSearch();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            SearchingDD();
        }
        #region Installment Receive
        private void radgdInstReceive_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = radgdInstReceive.CurrentCell.RowIndex;
                int columnindex = radgdInstReceive.CurrentCell.ColumnIndex;
               
                if (e.Column.Name == "btnVerify")
                {
                    int ID = 0;
                    //Rece_ID
                    bool M = int.TryParse(radgdInstReceive.CurrentRow.Cells[12].Value.ToString(), out ID);
                    if (M != false)
                    {
                        frmReceInstalImage objFrmReceInstalImage = new frmReceInstalImage(ID);
                        objFrmReceInstalImage.ShowDialog();
                        // MessageBox.Show("DDImage - > " + ID.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Image is not exist");
                    }
                }
        
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on radgdInstReceive_CellClick.", ex, "frmReceiveVerificationUnit");
                frmobj.ShowDialog();
            }
        }
        #endregion

        #region Other Receive
        private void gvChallan_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = gvChallan.CurrentCell.RowIndex;
                int columnindex = gvChallan.CurrentCell.ColumnIndex;
               
                if (e.Column.Name == "btnVerify")
                {
                    int ID = 0;
                    bool M = int.TryParse(gvChallan.CurrentRow.Cells[0].Value.ToString(), out ID);
                    if (M != false)
                    {
                        frmOtherReceImage objFrmOtherReceImage = new frmOtherReceImage(ID);
                        objFrmOtherReceImage.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Image is not exist");
                    }
                }

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on gvChallan_CellClick.", ex, "frmReceiveVerificationUnit");
                frmobj.ShowDialog();
            }
        }
        #endregion

        private void btnChallanSearch_Click(object sender, EventArgs e)
        {
            ChallanSearch();
        }
    }
}
