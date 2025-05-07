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
    public partial class frmNDCCheckListSearch : Telerik.WinControls.UI.RadForm
    {
        public frmNDCCheckListSearch()
        {
            InitializeComponent();
        }

        private void frmNDCCheckListSearch_Load(object sender, EventArgs e)
        {
            try
            {
                grdCheckListSearch.VerticalScrollState = ScrollState.AutoHide;
                grdCheckListSearch.HorizontalScrollState = ScrollState.AutoHide;
                SqlParameter[] prmt =
                           {
                new SqlParameter("@Task","Select_CheckList")
            };
                DataSet dst = new DataSet();
                dst = cls_dl_NDC.NdcRetrival(prmt);
                grdCheckListSearch.DataSource = dst.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmNDCCheckListSearch_Load.", ex, "frmNDCChecklistSearch");
                frmobj.ShowDialog();
            }
           
        }

       
    }
}
