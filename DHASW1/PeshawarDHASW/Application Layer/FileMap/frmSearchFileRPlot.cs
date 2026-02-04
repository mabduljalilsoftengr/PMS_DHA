using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsFileMap;
using PeshawarDHASW.Helper;
using Telerik.WinControls;
using PeshawarDHASW.Application_Layer.CustomDialog;
using Telerik.WinControls.UI;
using PeshawarDHASW.Report.ScheuldeCopy;

namespace PeshawarDHASW.Application_Layer.FileMap
{
    public partial class frmSearchFileRPlot : Telerik.WinControls.UI.RadForm
    {
        public frmSearchFileRPlot()
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
                    new SqlParameter("@RecordNo", clsPluginHelper.DbNullIfNullOrEmpty(txtrecordno.Text)),
                    new SqlParameter("@Remarks", clsPluginHelper.DbNullIfNullOrEmpty(txtremarks.Text)),
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

 
        private void btnSearch_Click(object sender, EventArgs e)
        {
            search();
        }

      

        private void frmSearchFileRPlot_Load(object sender, EventArgs e)
        {
           search();
        }

        private void gdFileMapSearch_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = gdFileMapSearch.CurrentCell.RowIndex;
                int columnindex = gdFileMapSearch.CurrentCell.ColumnIndex;

             
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
    }
}
