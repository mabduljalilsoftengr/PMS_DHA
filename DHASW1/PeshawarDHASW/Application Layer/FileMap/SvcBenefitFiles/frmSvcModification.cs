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
    public partial class frmSvcModification : Telerik.WinControls.UI.RadForm
    {
        public frmSvcModification()
        {
            InitializeComponent();
        }
        private void search()
        {
            try
            {
                SqlParameter[] searchparam =
                {
                    new SqlParameter("@Task","select_Svc"),
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
        private void frmSvcModification_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            search();
        }

        private void gdFileMapSearch_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = gdFileMapSearch.CurrentCell.RowIndex;
                int columnindex = gdFileMapSearch.CurrentCell.ColumnIndex;

                if (e.Column.Name == "ModifySize")
                {
                    string FileNo = "";
                    FileNo = gdFileMapSearch.CurrentRow.Cells["FileNo"].Value.ToString();
                    if (!string.IsNullOrWhiteSpace(FileNo))
                    {
                        string FileMapKey = gdFileMapSearch.CurrentRow.Cells["FileMapKey"].Value.ToString();
                        string InvestorName = gdFileMapSearch.CurrentRow.Cells["LandProviderName"].Value.ToString();
                        string PlotSize = gdFileMapSearch.CurrentRow.Cells["PlotSize"].Value.ToString();
                        string FirstBuyerName = gdFileMapSearch.CurrentRow.Cells["FirstBuyerName"].Value.ToString();
                        string IsOverorUnderSize = gdFileMapSearch.CurrentRow.Cells["IsOversizeUndersize"].Value.ToString();
                        string ExtraLand = gdFileMapSearch.CurrentRow.Cells["Extra_Less_Area"].Value.ToString();
                        string Remarks = gdFileMapSearch.CurrentRow.Cells["Remarks"].Value.ToString();
                        frmSvcFileModification obj = new frmSvcFileModification(FileMapKey,FileNo, IsOverorUnderSize, ExtraLand,
                        InvestorName,PlotSize,FirstBuyerName,Remarks);
                        obj.ShowDialog();
                        search();

                    }
                    else
                    {
                        MessageBox.Show("Record Not Found is not exist");
                    }
                }
                if (e.Column.Name == "PrintSchedule")
                {
                    int ID = 0;
                    bool M = int.TryParse(gdFileMapSearch.CurrentRow.Cells["FileMapKey"].Value.ToString(), out ID);
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
                if (e.Column.Name == "AttachementUpload")
                {
                    int ID = 0;
                    bool M = int.TryParse(gdFileMapSearch.CurrentRow.Cells["FileMapKey"].Value.ToString(), out ID);
                    string FileNo = gdFileMapSearch.CurrentRow.Cells["FileNo"].Value.ToString();
                    if (M != false)
                    {
                        frmFileAttachments obj = new frmFileAttachments(ID.ToString(), FileNo);
                        obj.ShowDialog();
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
