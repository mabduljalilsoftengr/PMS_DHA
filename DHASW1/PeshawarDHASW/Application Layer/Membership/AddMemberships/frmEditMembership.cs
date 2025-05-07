using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Membership.AddMemberships
{
    public partial class frmEditMembership : Telerik.WinControls.UI.RadForm
    {
        public frmEditMembership()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SqlParameter[] param = {
                new SqlParameter("@Task","Select")
            };
            DataTable dt = Data_Layer.clsAllMembership.cls_dl_AllMembership.AllMembership_Reader(param);
            MSDataView.DataSource = dt.DefaultView;
        }

        private void MSDataView_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "Edit")
            {
                int ID = int.Parse(MSDataView.CurrentRow.Cells[0].Value.ToString());
                string MSvalue = MSDataView.CurrentRow.Cells[1].Value.ToString();
                
                //    SqlParameter[] param =
                //        {
                //           new SqlParameter("@Task","Select"),
                //           new SqlParameter("@MSNO",MSvalue)
                //        };
                //DataTable dt = null;
                ////Data_Layer.clsAllMembership.cls_dl_AllMembership.AllMembership_Reader(param);
                //if (dt.Rows.Count > 0)
                //{
                //    MessageBox.Show("Membership Already Exist.");
                //}
                //else
                //{
                   SqlParameter[] para =
                   {
                        new SqlParameter("@Task","Update"),
                        new SqlParameter("@ID",ID),
                        new SqlParameter("@MSNO",MSvalue)
                    };
                    // DataTable ds = Data_Layer.clsAllMembership.cls_dl_AllMembership.AllMembership_Reader(para);
                    int result = 0;
                    result = Data_Layer.clsAllMembership.cls_dl_AllMembership.AllMembership_NonQuery(para);
                    if (result != 0)
                    {
                        btnRefresh_Click(null, null);
                    }
                    else
                    {
                        RadMessageBox.Show("Error Not added");
                    }
                //}
               

            }
        }
    }
}
