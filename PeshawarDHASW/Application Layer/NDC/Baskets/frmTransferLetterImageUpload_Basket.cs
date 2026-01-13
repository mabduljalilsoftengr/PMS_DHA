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
    public partial class frmTransferLetterImageUpload_Basket : Telerik.WinControls.UI.RadForm
    {
        public frmTransferLetterImageUpload_Basket()
        {
            InitializeComponent();
        }

        private void frmTransferLetterImageUpload_Basket_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            LoadDataForBasket();
        }
        private void LoadDataForBasket()
        {
            try
            {
                DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.Text,
                               "Select * from tbl_Basket_Queries Where Status Like 'ON'");
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (row["Task_Name"].ToString() == "ReadyForTFRLetterImageUpload")
                    {
                        FillDataGrid(grdTFRLetterImageUpload, row["Query"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LoadDataForBasket.", ex, "frmTransferLetterImageUpload_Basket");
                frmobj.ShowDialog();
            }
           
        }
        private void FillDataGrid(RadGridView grd, string qury)
        {
            grd.DataSource =
                SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.Text, qury).Tables[0].DefaultView;
        }

        private void grdTFRLetterImageUpload_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = grdTFRLetterImageUpload.CurrentCell.RowIndex;
                string FileNo = grdTFRLetterImageUpload.Rows[rowindex].Cells[1].Value.ToString();
                int TFR_No = int.Parse(grdTFRLetterImageUpload.Rows[rowindex].Cells[0].Value.ToString());
                int NDC_No = int.Parse(grdTFRLetterImageUpload.Rows[rowindex].Cells[2].Value.ToString());
                if (e.Column.Name == "TFR_LetterImageUpload")
                {
                    frmTransferLetterImageUpload frm = new frmTransferLetterImageUpload(TFR_No, FileNo, NDC_No);
                    frm.ShowDialog();
                    LoadDataForBasket();
                    //this.Close();
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on grdTFRLetterImageUpload_CellClick.", ex, "frmTransferLetterImageUpload_Basket");
                frmobj.ShowDialog();
            }
           
        }
    }
}
