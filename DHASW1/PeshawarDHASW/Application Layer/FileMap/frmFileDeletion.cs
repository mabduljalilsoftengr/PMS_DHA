using PeshawarDHASW.Data_Layer.clsFileMap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.FileMap
{
    public partial class frmFileDeletion : Telerik.WinControls.UI.RadForm
    {
        public frmFileDeletion()
        {
            InitializeComponent();
        }
        private string PlotSize { get; set; }
        private int FileMapKey { get; set; }
        private void txtFileNo_Leave(object sender, EventArgs e)
        {
            SqlParameter[] prmtr =
            {
                new SqlParameter("@Task","Select_FileDetail"),
                new SqlParameter("@FileNo",txtFileNo.Text),
            };
            DataSet dst = new DataSet();
            dst = cls_dl_FileMap.FileMap_Reader(prmtr);
            PlotSize = dst.Tables[0].Rows[0]["PlotSize"].ToString();
            FileMapKey = Convert.ToInt32(dst.Tables[0].Rows[0]["FileMapKey"].ToString());
            grdFileDetails.DataSource = dst.Tables[0].DefaultView;
            grdReceInstallment.DataSource = dst.Tables[1].DefaultView;
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            if (UpdateFileStatus_Cancel())
            {
                InsertFileDeletionHistory();
                Clear();
            }
        }
        private bool UpdateFileStatus_Cancel()
        {
            SqlParameter[] prmtr =
            {
                new SqlParameter("@Task","Update_FileStatus"),
                new SqlParameter("@FileMapKey",FileMapKey),
                new SqlParameter("@Status","Cancel"),
            };
            bool rslt = Convert.ToBoolean(cls_dl_FileMap.FileMap_NonQuery(prmtr));
            return rslt;
        }
        private void InsertFileDeletionHistory()
        {
            string entryDate =  dtpDateEntry.Text;
            DateTime Entry_Date = DateTime.ParseExact(entryDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            SqlParameter[] prmtr =
            {
               new SqlParameter("@Task","Insert_FileDeleteHistory"),
               new SqlParameter("@FileNo",txtFileNo.Text),
               new SqlParameter("@PlotSize",PlotSize),
               new SqlParameter("@DeletionDate",Entry_Date),//DateTime Picker
               new SqlParameter("@ION_No",txtIONNo.Text),
               new SqlParameter("@Branch_No",txtBranchno.Text),
               new SqlParameter("@ByAuthority",txtAuthority.Text),
               new SqlParameter("@Status",txtStatus.Text),
               new SqlParameter("@Remarks",txtRemarks.Text),
               new SqlParameter("@FileMapKey",FileMapKey),
            };
            int rslt =cls_dl_FileMap.FileMap_NonQuery(prmtr);
        }
        private void Clear()
        {
            txtFileNo.Text = "";
            txtAuthority.Text = "";
            txtBranchno.Text = "";
            txtIONNo.Text = "";
            txtRemarks.Text = "";
            txtStatus.Text = "";
            grdFileDetails.DataSource = null;
            grdReceInstallment.DataSource = null;
        }
    }
}
