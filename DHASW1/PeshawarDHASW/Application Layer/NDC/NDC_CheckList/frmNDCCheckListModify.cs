using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.NDC;
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

namespace PeshawarDHASW.Application_Layer.NDC.NDC_CheckList
{
    public partial class frmNDCCheckListModify : Telerik.WinControls.UI.RadForm
    {
        public frmNDCCheckListModify()
        {
            InitializeComponent();
        }

        private void frmNDCCheckListModify_Load(object sender, EventArgs e)
        {
            GridColumn();
            LoadDataForGrid();
           
        }
        private void LoadDataForGrid()
        {
            try
            {
                grdCheckListModify.VerticalScrollState = ScrollState.AutoHide;
                grdCheckListModify.HorizontalScrollState = ScrollState.AutoHide;
                SqlParameter[] prmt =
                {
                new SqlParameter("@Task","Select_CheckList")
                };
                DataSet dst = new DataSet();
                dst = cls_dl_NDC.NdcRetrival(prmt);
                grdCheckListModify.DataSource = dst.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmNDCCheckListCreate_Load.", ex, "frmNDCChecklistCreate");
                frmobj.ShowDialog();
            }
           
        }
        private void GridColumn()
        {
            try
            {
                GridViewCommandColumn modify = new GridViewCommandColumn();
                modify.Name = "Modify";
                modify.UseDefaultText = true;
                modify.FieldName = "Modify";
                modify.DefaultText = "Modify";
                modify.Width = 80;
                modify.TextAlignment = ContentAlignment.MiddleCenter;
                modify.HeaderText = "Modify";
                grdCheckListModify.MasterTemplate.Columns.Add(modify);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on GridColumn.", ex, "frmNDCChecklistModify");
                frmobj.ShowDialog();
            }
           

        }

        private void grdCheckListSearch_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = grdCheckListModify.CurrentCell.RowIndex;
                int columnindex = grdCheckListModify.CurrentCell.ColumnIndex;
                if (e.Column.Name == "Modify")
                {
                    int CheckListID = int.Parse(grdCheckListModify.Rows[rowindex].Cells[0].Value.ToString());

                    frmNDCCheckListCreate obj = new frmNDCCheckListCreate(CheckListID.ToString());
                    obj.ShowDialog();
                    LoadDataForGrid();
                }
            }
            catch (Exception ex)
            {

                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on grdCheckListSearch_CellClick.", ex, "frmNDCChecklistModify");
                frmobj.ShowDialog();
            }
           
        }
    }
}
