using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.clsFileMap;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Models;
using PeshawarDHASW.Report.ScheuldeCopy;
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

namespace PeshawarDHASW.Application_Layer.FileMap.SvcBenefitFiles
{
    public partial class frmSvcSearch : Telerik.WinControls.UI.RadForm
    {
        public frmSvcSearch()
        {
            InitializeComponent();
        }

        private void search()
        {
            try
            {
                SqlParameter[] searchparam =
                {
                    new SqlParameter("@Task","select"),
                    new SqlParameter("@FileNo", clsPluginHelper.DbNullIfNullOrEmpty(txtfileno.Text)),
                    new SqlParameter("@PlotNo", clsPluginHelper.DbNullIfNullOrEmpty(txtplotno.Text)),
                    new SqlParameter("@Status", clsPluginHelper.DbNullIfNullOrEmpty(ddstatus.Text)),
                };
                DataSet ds = cls_dl_FileMap.FileMap_Reader(searchparam);
                gdFileMapSearch.DataSource = ds.Tables[0].DefaultView;
                foreach (GridViewDataColumn column in gdFileMapSearch.Columns)
                {
                    column.BestFit();
                }

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on search.", ex, "frmModifyFileInformation");
                frmobj.ShowDialog();
            }

        }
        private void frmSvcSearch_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            search();
        }

        private void gdFileMapSearch_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = gdFileMapSearch.CurrentCell.RowIndex;
                int columnindex = gdFileMapSearch.CurrentCell.ColumnIndex;

                //if (e.Column.Name == "binsttemp")
                //{
                //    int ID = 0;
                //    bool M = int.TryParse(gdFileMapSearch.CurrentRow.Cells[0].Value.ToString(), out ID);
                //    if (M != false)
                //    {
                //        frmCreateFileNoRPlot obj = new frmCreateFileNoRPlot(ID);
                //        obj.ShowDialog();
                //        search();

                //    }
                //    else
                //    {
                //        MessageBox.Show("Record Not Found is not exist");
                //    }
                //}
                if (e.Column.Name == "PrintSchedule")
                {
                    int ID = 0;
                    bool M = int.TryParse(gdFileMapSearch.CurrentRow.Cells[0].Value.ToString(), out ID);
                    if (M != false)
                    {
                        frmSchedulePrint obj = new frmSchedulePrint(ID, "");
                        obj.ShowDialog();
                        search();

                    }
                    else
                    {
                        MessageBox.Show("Record Not Found is not exist");
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on gdFileMapSearch_CellClick.", ex, "frmModifyFileInformation");
                //frmobj.ShowDialog();

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        private void txtfileno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                search();
            }
        }

        private void txtplotno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                search();
            }
        }
    }
}
