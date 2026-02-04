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
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Application_Layer.NDC
{
    public partial class frmNDCModify : Telerik.WinControls.UI.RadForm
    {
       private int ndcno { get; set; }
        public frmNDCModify()
        {
            InitializeComponent();
        }
      
        private void DataLoadForModification()
        {
            try
            {
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","NDCSearch"),
                clsPluginHelper.SqlparameterAttachtext("@FileNo",txtFileNo.Text),
                clsPluginHelper.SqlparameterAttachtext("@NDCNo",txtNDCNo.Text),
                clsPluginHelper.SqlparameterAttachtext("@string","")
                };
                DataSet ds = new DataSet();
                ds = cls_dl_NDC.NdcRetrival(prm);
                grdModify.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on DataLoadForModification.", ex, "frmNDCModify");
                frmobj.ShowDialog();
            }
           
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataLoadForModification();
        }

        private void frmNDCModify_Load(object sender, EventArgs e)
        {
            DataLoadForModification();
            GridView_Columns();
        }
        private void GridView_Columns()
        {
            try
            {
                GridViewCommandColumn NDCInfo = new GridViewCommandColumn();
                NDCInfo.Name = "NDCinfo";
                NDCInfo.UseDefaultText = true;
                NDCInfo.FieldName = "NDCNo";
                NDCInfo.DefaultText = "NDC Modify";
                NDCInfo.Width = 80;
                NDCInfo.TextAlignment = ContentAlignment.MiddleCenter;
                NDCInfo.HeaderText = "NDC Modify";
                grdModify.MasterTemplate.Columns.Add(NDCInfo);

                GridViewCommandColumn NDCCheckListInfo = new GridViewCommandColumn();
                NDCCheckListInfo.Name = "NDCCheckListinfo";
                NDCCheckListInfo.UseDefaultText = true;
                NDCCheckListInfo.FieldName = "NDCCheckListinfo";
                NDCCheckListInfo.DefaultText = "CheckList Modify";
                NDCCheckListInfo.Width = 80;
                NDCCheckListInfo.TextAlignment = ContentAlignment.MiddleCenter;
                NDCCheckListInfo.HeaderText = "CheckList Modify";
                grdModify.MasterTemplate.Columns.Add(NDCCheckListInfo);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on GridView_Columns.", ex, "frmNDCModify");
                frmobj.ShowDialog();
            }
            
        }

        private void grdModify_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = grdModify.CurrentCell.RowIndex;
                int columnindex = grdModify.CurrentCell.ColumnIndex;
                if (e.Column.Name == "NDCinfo")
                {

                    ndcno = int.Parse(grdModify.Rows[rowindex].Cells[3].Value.ToString());
                    DataTable dt = CheckForNDCPrintedStatus();
                   // if(dt.Rows.Count > 0)
                   // {
                        frmNDCCreate obj = new frmNDCCreate(ndcno, true);
                        obj.ShowDialog();
                        DataLoadForModification();
                   // }
                   // else
                   // {
                    //    MessageBox.Show("This NDC is already Printed, So you Can't modify it now.");
                   // }
                   
                }
                if (e.Column.Name == "NDCCheckListinfo")
                {
                    ndcno = int.Parse(grdModify.Rows[rowindex].Cells[3].Value.ToString());
                    bool Status = true;
                    DataTable dt = CheckForNDCPrintedStatus();
                    if (dt.Rows.Count > 0)
                    {
                    NDC.NDC_CheckList.frmNDC_CheckList_Binding_Updating obj = new NDC_CheckList.frmNDC_CheckList_Binding_Updating(ndcno, Status, txtFileNo.Text);
                    obj.ShowDialog();
                    DataLoadForModification();
                    }
                    else
                    {
                        MessageBox.Show("This NDC is already Printed, So you Can't modify it now.");
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on grdModify_CellClick.", ex, "frmNDCModify");
                frmobj.ShowDialog();
            }
           
        }

       private DataTable CheckForNDCPrintedStatus()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","CheckForNDCPrintedStatus"),
                 new SqlParameter("@NDCNo",ndcno)
                };
                
                ds = cls_dl_NDC.NdcRetrival(prm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds.Tables[0];
        }
    }
}
