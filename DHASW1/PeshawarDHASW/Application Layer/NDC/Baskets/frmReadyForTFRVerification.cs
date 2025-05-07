using PeshawarDHASW.Application_Layer.Transfer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Models;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    public partial class frmReadyForTFRVerification : Telerik.WinControls.UI.RadForm
    {
        public frmReadyForTFRVerification()
        {
            InitializeComponent();
        }
        private void LoadDataForBasket()
        {
            try
            {
                DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.Text,
                               "Select * from tbl_Basket_Queries Where Status Like 'ON'");
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (row["Task_Name"].ToString() == "ReadyForTFRVerification")
                    {
                        FillDataGrid(grdReadyForVerification, row["Query"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LoadDataForBasket.", ex, "frmReadyForTFRVerification");
                frmobj.ShowDialog();
            }
           
        }
        private void FillDataGrid(RadGridView grd, string qury)
        {
            grd.DataSource =
                SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.Text, qury).Tables[0].DefaultView;
        }
       

        private void frmReadyForVerification_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            LoadDataForBasket();
        }

        private void grdReadyForVerification_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = grdReadyForVerification.CurrentCell.RowIndex;
                int ndcno = int.Parse(grdReadyForVerification.Rows[rowindex].Cells[0].Value.ToString());
                int tfr_no = int.Parse(grdReadyForVerification.Rows[rowindex].Cells[2].Value.ToString());
                bool txtNDCNoStatus = false;
                if (e.Column.Name == "ReadyForVerification")
                {
                    frmTransferVerification frm = new frmTransferVerification(ndcno, tfr_no, txtNDCNoStatus);
                    frm.ShowDialog();
                    LoadDataForBasket();

                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on grdReadyForVerification_CellClick.", ex, "frmReadyForTFRVerification");
                frmobj.ShowDialog();
            }
           
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            //Refresh the Grid
            LoadDataForBasket();
        }
    }
}
