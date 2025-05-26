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
    public partial class Incoming_Mail : Telerik.WinControls.UI.RadForm
    {
        public Incoming_Mail()
        {
            InitializeComponent();
        }
        private void Dataloading_IncomingMail()
        {
            SqlParameter[] param = {
                new SqlParameter("@Task","IncomingMailSelect")
            };
            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.Incoming_mail", param);
            RGV_IncomingMail.DataSource = ds.Tables[0].DefaultView;
            foreach (GridViewDataColumn column in RGV_IncomingMail.Columns)
            {
                column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
            }
            
        }
        private void Incoming_Mail_Load(object sender, EventArgs e)
        {
            Dataloading_IncomingMail();
        }

        private void btnIncomingMailNew_Click(object sender, EventArgs e)
        {
            IncomingMailNew obj = new IncomingMailNew();
            obj.ShowDialog();
        }

        private void RGV_IncomingMail_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "btnEdit")
                {
                    string DiaryNo = e.Row.Cells["DiaryNo"].Value.ToString();
                    IncomingEdit obj = new IncomingEdit(DiaryNo);
                    obj.ShowDialog();
                    Dataloading_IncomingMail();
                }
                if (e.Column.Name =="ScanDoc")
                {
                    string DiaryNo = e.Row.Cells["DiaryNo"].Value.ToString();
                    IncomingImageModification obj = new IncomingImageModification(DiaryNo);
                    obj.ShowDialog();
                }
            }
            catch (Exception ex)
            {

            }
            
        }
    }
}
