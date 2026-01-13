using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.clsNDCChecklist;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.NDC.NDCCheckListMap
{
    public partial class frmNDCCheckListMapSearch : Telerik.WinControls.UI.RadForm
    {
        public int NDCNo { get; set; }
        public int NDC_Against_FileNo { get; set; }
        public int checklistid { get; set; }
        public string FileNo { get; set; }
        public frmNDCCheckListMapSearch()
        {
            InitializeComponent();
        }
        public frmNDCCheckListMapSearch(string get_FileNo)
        {
                FileNo = get_FileNo;
            InitializeComponent();
        }

        private void frmNDCCheckListMapSearch_Load(object sender, EventArgs e)
        {
          
                CheckAndRetrieveCheckList();
        }
        private void CheckAndRetrieveCheckList()
        {
            try
            {
                SqlParameter[] pr_m =
                                {
                  new SqlParameter("@Task","select"),
                  new SqlParameter("@FileNo",FileNo)
                };
                DataSet dst = new DataSet();
                dst = cls_dl_NDCChecklist.NDCCheckListReader(pr_m);
                grdChecklist.DataSource = dst.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on CheckAndRetrieveCheckList.", ex, "frmNDCCheckListMapSearch");
                frmobj.ShowDialog();
            }
               
            
            }

            
    }
}
