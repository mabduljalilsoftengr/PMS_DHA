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

namespace PeshawarDHASW.Application_Layer.Acknowledgement
{
    public partial class frm_AcknowledgementSetting : Telerik.WinControls.UI.RadForm
    {
        public frm_AcknowledgementSetting()
        {
            InitializeComponent();
        }

        private void btnNewLockEntry_Click(object sender, EventArgs e)
        {
            frm_NewAckEntry obj = new frm_NewAckEntry();
            obj.ShowDialog();
            btnSearch_Click(null, null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlParameter[] param = {
                new SqlParameter("@Task","Select"),
                new SqlParameter("@FileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtFileNo.Text)),
                new SqlParameter("@PlotNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtPlotNo.Text))
            };
            DataSet ds = new DataSet();
            ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_AcknowledgmentSetting", param);
            if (ds.Tables.Count > 0)
            {
                rgv_AcknowledgementSetting.DataSource = ds.Tables[0].DefaultView;
                foreach (GridViewDataColumn column in rgv_AcknowledgementSetting.Columns)
                {
                    column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
                }
            }
        }

        private void MasterTemplate_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "Edit")
                {
                    int AckLockID = int.Parse(e.Row.Cells["AckLockID"].Value.ToString());
                    frm_NewAckEntry obj = new frm_NewAckEntry(AckLockID);
                    obj.Show();
                }
            }
            catch (Exception)
            {

            }
            
        }
    }
}
