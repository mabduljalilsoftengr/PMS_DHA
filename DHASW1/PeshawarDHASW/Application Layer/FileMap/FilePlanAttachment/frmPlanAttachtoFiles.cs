using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.FileMap.FilePlanAttachment
{
    public partial class frmPlanAttachtoFiles : Telerik.WinControls.UI.RadForm
    {
        public frmPlanAttachtoFiles()
        {
            InitializeComponent();
        }

        private void FilehavenoPlanAttach()
        {
            SqlParameter[] param = {
                    new SqlParameter("@Task","FilehaveNoPlanAttached")
            };
            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(),CommandType.StoredProcedure, "dash.Transfer_Summaries", param);
            dgvNoPlanFiles.DataSource = ds.Tables[0].DefaultView;
        }
        private void FilehavePlanAttach()
        {
            SqlParameter[] param = {
                    new SqlParameter("@Task","FilehaveAttached")
            };
            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "dash.Transfer_Summaries", param);
            dgvFilehaveAttached.DataSource = ds.Tables[0].DefaultView;
        }


        private void frmPlanAttachtoFiles_Load(object sender, EventArgs e)
        {
            FilehavenoPlanAttach();
            FilehavePlanAttach();
        }

        private void dgvNoPlanFiles_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name=="AttachPlan")
            {
                string FileMapKey = e.Row.Cells["FileMapKey"].Value.ToString();
                string FileNo = e.Row.Cells["FileNo"].Value.ToString();
                string Category = e.Row.Cells["Category_Name"].Value.ToString();
                string Date = e.Row.Cells["DateofPurchase"].Value.ToString();
                frmPlanAttach obj = new frmPlanAttach(FileNo,Category,Date, FileMapKey);
                obj.ShowDialog();
            }
        }
    }
}
