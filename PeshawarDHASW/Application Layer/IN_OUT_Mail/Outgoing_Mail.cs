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

namespace PeshawarDHASW.Application_Layer.IN_OUT_Mail
{
    public partial class Outgoing_Mail : Telerik.WinControls.UI.RadForm
    {
        public Outgoing_Mail()
        {
            InitializeComponent();
        }

        private void Outgoing_Mail_Load(object sender, EventArgs e)
        {
            SqlParameter[] param = {
                new SqlParameter("@Task","SelectAllRecord")
            };
            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_Outgoing_mail", param);
            RGV_OutgoingMail.DataSource = ds.Tables[0].DefaultView;
            foreach (GridViewDataColumn column in RGV_OutgoingMail.Columns)
            {
                column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
            }
        }

        private void RGV_OutgoingMail_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "btnEdit")
                {
                    string DiaryNo = e.Row.Cells["DiaryNo"].Value.ToString();
                    IncomingEdit obj = new IncomingEdit(DiaryNo);
                    obj.ShowDialog();
                    Outgoing_Mail_Load(null, null);
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void btnOutgoingMailNew_Click(object sender, EventArgs e)
        {
            OutgoingMailNew obj = new OutgoingMailNew();
            obj.ShowDialog();
        }
    }
}
