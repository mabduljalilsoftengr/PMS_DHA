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
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.AuthorizedDealer
{
    public partial class frmPrpDlr_PaymentDetail : Telerik.WinControls.UI.RadForm
    {
        private DataSet dst { get; set; }
        private DataSet dstW { get; set; }


        public frmPrpDlr_PaymentDetail()
        {
            InitializeComponent();
        }
        public frmPrpDlr_PaymentDetail( DataSet ds, DataSet dsStatus)
        {
            InitializeComponent();
            dst = ds;
            dstW = dsStatus;
        }
        private void frmPrpDlr_PaymentDetail_Load(object sender, EventArgs e)
        {

            if (Convert.ToInt32(dstW.Tables[0].Rows[0]["Web_Active"]) == 1)
            {
                radActive.CheckState = CheckState.Checked;
            }
            else
            {
                radInActive.CheckState = CheckState.Checked;
            }
                


            grdPaymentDetail.DataSource = dst.Tables[0].DefaultView;
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {

            string RegnNo = dst.Tables[0].Rows[0]["RegnNo"].ToString();
            string Status = "0"; 

            if (radActive.IsChecked)
            {
                Status = "1";
            }
            else if (radInActive.IsChecked)
            {
                Status = "0";
            }
            
            using (SqlConnection Objcon = Helper.SQLHelper.createConnection())
            {
                using (SqlTransaction sqlTrans = Objcon.BeginTransaction("UpdateWebStatus"))
                {
                    try
                    {
                        SqlParameter[] prm =
                                    {
                                        new SqlParameter("@Task", "UpdateDealerStatusWeb"),
                                        new SqlParameter("@RegnNo", RegnNo),
                                        new SqlParameter("@Web_Active", Status)
                                    };

                        SqlCommand result = SQLHelper.ExecuteNonQuery(sqlTrans, CommandType.StoredProcedure, "App.USP_tbl_PropertyDealers", "", prm);
                        sqlTrans.Commit();

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message);
                        sqlTrans.Rollback();
                    }

                }
            }
        }
    }
}
