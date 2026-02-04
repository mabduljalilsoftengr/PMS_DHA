using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsChallanType;
using PeshawarDHASW.Data_Layer.clsErrorLog;
using Telerik.WinControls;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.ChallanType
{
    public partial class frmChallanTypeSearch : Telerik.WinControls.UI.RadForm
    {
        public frmChallanTypeSearch()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task", "Select"),
                    new SqlParameter("@ChallanType", txttype.Text),
                    new SqlParameter("@Description", txtdescp.Text),
                    new SqlParameter("@Remarks", txtremarks.Text),
                    new SqlParameter("@Status", dpstatus.Text),
                };
                DataSet ds = cls_dl_ChallanType.Challan_Reader(parameters, "App.USP_tbl_ChallanType");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    radchallan.DataSource = ds.Tables[0].DefaultView;
                }
                else
                {
                    MessageBox.Show("Contact to Administrator");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnSearch_Click.", ex, "frmChallanTypeSearch");
                frmobj.ShowDialog();
            }
        }

        private void frmChallanTypeSearch_Load(object sender, EventArgs e)
        {

        }
    }
}
