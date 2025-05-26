using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.FileMap.FileReissueProcess
{
    public partial class FileReissueRequest : Telerik.WinControls.UI.RadForm
    {
        public FileReissueRequest()
        {
            InitializeComponent();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlParameter[] param = {
                new SqlParameter("@Task","FindDataofFile"),
                new SqlParameter("@FileNo",txtFileNoSearch.Text)
            };
            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.FileReIssueProcess", param);
            if (ds.Tables.Count>0)
            {
                if (ds.Tables[0].Rows.Count>0)
                {
                    OldFileNo.Text = ds.Tables[0].Rows[0]["FileNo"].ToString();
                    OldPlotNo.Text = ds.Tables[0].Rows[0]["PlotNo"].ToString();
                    OldMSNo.Text = ds.Tables[0].Rows[0]["FileNo"].ToString();
                    OldMemberName.Text = ds.Tables[0].Rows[0]["FileNo"].ToString();
                    OldMemberCNIC.Text = ds.Tables[0].Rows[0]["FileNo"].ToString();
                }
            }
        }
    }
}
