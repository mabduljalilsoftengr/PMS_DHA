using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.NDC;
using Telerik.WinControls;
using PeshawarDHASW.Data_Layer.clsNDCChecklist;
using Telerik.WinControls.UI;
using PeshawarDHASW.Application_Layer.NDC.NDCCheckListMap;
using PeshawarDHASW.Application_Layer.NDC.NDC_CheckList;
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Application_Layer.NDC
{
    public partial class frmNDCSearch : Telerik.WinControls.UI.RadForm
    {
        private int NDCNo  {get;set;}
        public frmNDCSearch()
        {
            InitializeComponent();
        }
        public frmNDCSearch(int ndcno)
        {
            InitializeComponent();
            NDCNo = ndcno;
            txtNDCNo.Text = NDCNo.ToString();
            DataLoadForSearch();
        }
        private void frmNDCSearch_Load(object sender, EventArgs e)
        {
            //GridColumn();
            DataLoadForSearch();
          //  SqlParameter[] parameter =
          //{
          //      new SqlParameter("@Task","NDCSearch"),
          //  };
          //  DataSet ds = cls_dl_NDC.NdcRetrival(parameter);
          //  grdSearch.DataSource = ds.Tables[0].DefaultView;
        }
        private void GridColumn()
        {
            try
            {
                GridViewCommandColumn NDCInfo = new GridViewCommandColumn();
                NDCInfo.Name = "NDCinfo";
                NDCInfo.UseDefaultText = true;
                NDCInfo.FieldName = "NDCNo";
                NDCInfo.DefaultText = "NDC Search";
                NDCInfo.Width = 80;
                NDCInfo.TextAlignment = ContentAlignment.MiddleCenter;
                NDCInfo.HeaderText = "NDC Search";
                grdSearch.MasterTemplate.Columns.Add(NDCInfo);


                GridViewCommandColumn NDCCheckListInfo = new GridViewCommandColumn();
                NDCCheckListInfo.Name = "NDCCheckListinfo";
                NDCCheckListInfo.UseDefaultText = true;
                NDCCheckListInfo.FieldName = "NDCCheckListinfo";
                NDCCheckListInfo.DefaultText = "CheckList Search";
                NDCCheckListInfo.Width = 80;
                NDCCheckListInfo.TextAlignment = ContentAlignment.MiddleCenter;
                NDCCheckListInfo.HeaderText = "CheckList Search";
                grdSearch.MasterTemplate.Columns.Add(NDCCheckListInfo);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on GridColumn.", ex, "frmNDCSearch");
                frmobj.ShowDialog();
            }
           
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataLoadForSearch();
        }
        private void DataLoadForSearch()
        {
            try
            {
                SqlParameter[] prm =
                          {
                new SqlParameter("@Task","NDCSearch"),
                new SqlParameter("@FileNo",clsPluginHelper.DbNullIfNullOrEmpty(txtFileNo.Text)),
                new SqlParameter("@NDCNo",clsPluginHelper.DbNullIfNullOrEmpty(txtNDCNo.Text)), 
                new SqlParameter("@string","")
            };
                DataSet d_s = new DataSet();
                d_s = cls_dl_NDC.NdcRetrival(prm);
                grdSearch.DataSource = d_s.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on DataLoadForSearch.", ex, "frmNDCSearch");
                frmobj.ShowDialog();
            }
           
        }

        private void grdSearch_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "NDCCheckListinfo")
                {
                    int NDCID = int.Parse(grdSearch.CurrentRow.Cells[3].Value.ToString());
                    bool status = false;
                    frmNDC_CheckList_Binding_Updating obj = new frmNDC_CheckList_Binding_Updating(NDCID, status, txtFileNo.Text);
                    obj.ShowDialog();
                }
                if (e.Column.Name == "NDCinfo")
                {
                    int NDCID =int.Parse(grdSearch.CurrentRow.Cells[3].Value.ToString());
                    frmNDCCreate obj = new frmNDCCreate(NDCID, false);
                    obj.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on grdSearch_CellClick.", ex, "frmNDCSearch");
                frmobj.ShowDialog();
            }
            
          
        }
    }
}
