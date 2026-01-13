
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
    public partial class frmBasketNDCVerification : Telerik.WinControls.UI.RadForm
    {
        public frmBasketNDCVerification()
        {
            InitializeComponent();
        }

        private void frmBasketVerification_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            LoadDataForBasket();
        }
        private void LoadDataForBasket()
        {
            try
            {
                DataSet dst = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.Text,
                "Select * from tbl_Basket_Queries Where Status Like 'ON'");
                foreach (DataRow row in dst.Tables[0].Rows)
                {
                    if (row["Task_Name"].ToString() == "ReadyForNDCVerification")
                    {
                        FillTheGridViews(grdReady_For_Verification, row["Query"].ToString());
                    }
                    //if (row["Task_Name"].ToString() == "ReadyForPrint")
                    //{
                    //    FillTheGridViews(grdReady_For_Print, row["Query"].ToString());
                    //}
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LoadDataForBasket.", ex, "frmBasketNDCVerification");
                frmobj.ShowDialog();

            }

        }
        private void FillTheGridViews(RadGridView grdv,string qry)
        {
            grdv.DataSource = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.Text, qry).Tables[0].DefaultView;

        }

        private void grdReady_For_Verification_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = grdReady_For_Verification.CurrentCell.RowIndex;
                if (e.Column.Name == "Redy_Verfcton")
                {
                    int ndcno = int.Parse(grdReady_For_Verification.Rows[rowindex].Cells[0].Value.ToString());
                    bool grp = false;
                    frm_NDC_CheckList_Detail obj = new frm_NDC_CheckList_Detail(ndcno, grp);
                    obj.ShowDialog();
                    LoadDataForBasket();
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on grdReady_For_Verification_CellClick.", ex, "frmBasketNDCVerification");
                frmobj.ShowDialog();
            }
           
        }

        private void grdReady_For_Print_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = grdReady_For_Print.CurrentCell.RowIndex;
                if (e.Column.Name == "Redy_Print_Report")
                {
                    int ndcno = int.Parse(grdReady_For_Print.Rows[rowindex].Cells[0].Value.ToString());
                    frmNDC_Report obj = new frmNDC_Report(ndcno,"","");
                    obj.ShowDialog();
                    LoadDataForBasket();
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on grdReady_For_Print_CellClick.", ex, "frmBasketNDCVerification");
                frmobj.ShowDialog();
            }
          
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            LoadDataForBasket();
        }
    }
}
