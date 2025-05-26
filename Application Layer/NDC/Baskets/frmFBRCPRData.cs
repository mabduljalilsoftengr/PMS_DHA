using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    public partial class frmFBRCPRData : Telerik.WinControls.UI.RadForm
    {
        public frmFBRCPRData()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SqlParameter[] param = { new SqlParameter("@Task", "NDC_PrintAndNotSigned") };
            grdPrinted_NotSigned.DataSource = SQLHelper.ExecuteDataset(SQLHelper.createConnection(),
                CommandType.StoredProcedure, "App.USP_NDC", param).Tables[0].DefaultView;
        }

        private void frmFBRCPRData_Load(object sender, EventArgs e)
        {
            SqlParameter[] param = { new SqlParameter("@Task", "NDC_PrintAndNotSigned") };
            grdPrinted_NotSigned.DataSource = SQLHelper.ExecuteDataset(SQLHelper.createConnection(),
                CommandType.StoredProcedure, "App.USP_NDC", param).Tables[0].DefaultView;
        }

        private void grdFBRSellerBuyerData_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "CPRUpdate")
            {
                string CPRID = e.Row.Cells["FBRSBCPRID"].Value.ToString();
                string CPRNo = e.Row.Cells["CPRNo"].Value.ToString();
                string NameOwner = e.Row.Cells["CPRName"].Value.ToString();
                string Father = e.Row.Cells["FatherName"].Value.ToString();
                string CPRAmount = e.Row.Cells["CPRAmount"].Value.ToString();
                frmFBRCPRNoUpdate obj = new frmFBRCPRNoUpdate(CPRID, CPRNo, NameOwner, Father, CPRAmount);
                obj.ShowDialog();
            }
        }

        private void grdPrinted_NotSigned_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "Prnt_NotSnd")
            {
                int NDCNo = int.Parse(e.Row.Cells["NDCNo"].Value.ToString());
                SqlParameter[] param = {
                    new SqlParameter("@Task","CPRDataofNDCNo"),
                    new SqlParameter("@NDCNo",NDCNo)
                };

                grdFBRSellerBuyerData.DataSource = SQLHelper.ExecuteDataset(SQLHelper.createConnection(),
                CommandType.StoredProcedure, "App.USP_NDC", param).Tables[0].DefaultView;
            }
        }
    }
}
