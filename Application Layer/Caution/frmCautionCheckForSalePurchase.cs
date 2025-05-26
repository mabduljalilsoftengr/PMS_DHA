using PeshawarDHASW.Data_Layer.clsCaution;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Caution
{
    public partial class frmCautionCheckForSalePurchase : Telerik.WinControls.UI.RadForm
    {
        public frmCautionCheckForSalePurchase()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            try
            {
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","Check_Caution"),
                new SqlParameter("@FileNo",txtFileNo.Text)
                };
                DataSet ds = cls_dl_Caution.Caution_Reader(prm);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Text = "Currently File No : " + ds.Tables[0].Rows[0]["FileNo"].ToString() + " is Not Available";
                }
                else
                {
                    lblMessage.Text = "File is Available";
                }
            }
            catch
            {

            }
        }
    }
}
