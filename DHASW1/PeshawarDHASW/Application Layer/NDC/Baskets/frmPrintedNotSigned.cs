
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
    public partial class frmPrintedNotSigned : Telerik.WinControls.UI.RadForm
    {
        public frmPrintedNotSigned()
        {
            InitializeComponent();
        }

        private void grdPrinted_NotSigned_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
           
            int NDCNo = int.Parse(grdPrinted_NotSigned.CurrentRow.Cells[0].Value.ToString());
            if (e.Column.Name == "Prnt_NotSnd")
            {
                bool grpstatus = false;
                bool AllButtonsVisibilty = true;
                frmPrintNotSigned_NDCCheckListDetail obj = new frmPrintNotSigned_NDCCheckListDetail(NDCNo, grpstatus, AllButtonsVisibilty);
                obj.ShowDialog();
                BasketFilling();
            }
        }
        private void BasketFilling()
        {
            try
            {
                DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.Text,
                               "Select * from tbl_Basket_Queries Where Status Like 'ON'");
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (row["Task_Name"].ToString() == "PrintAndNotSigned")
                    {
                        FillGrid(grdPrinted_NotSigned, row["Query"].ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on BasketFilling.", ex, "frmPrintedNotSigned");
                frmobj.ShowDialog();
            }
           
        }
        private void FillGrid(RadGridView dv, string Query)
        {
            dv.DataSource =
                        SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.Text, Query).Tables[0]
                            .DefaultView;
        }

        private void frmPrintedNotSigned_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            BasketFilling();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            BasketFilling();
        }
    }
}
