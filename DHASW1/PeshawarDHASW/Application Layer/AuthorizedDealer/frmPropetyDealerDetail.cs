using PeshawarDHASW.Data_Layer.clsAuthorizeDealer;
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

namespace PeshawarDHASW.Application_Layer.AuthorizedDealer
{
    public partial class frmPropetyDealerDetail : Telerik.WinControls.UI.RadForm
    {
        public frmPropetyDealerDetail()
        {
            InitializeComponent();
        }

        private void frmPropetyDealerDetail_Load(object sender, EventArgs e)
        {
            try
            {
                GetPropertyDetail();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnResresh_Click(object sender, EventArgs e)
        {

           try
           {
                GetPropertyDetail();
           }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GetPropertyDetail()
        {
            SqlParameter[] prm =
               {
                  new SqlParameter("@Task","SeletPropertyDealer")
                };
            DataSet dst = cls_dl_AuthorizeDealer.AuthorizeDealer_Local_Reader(prm);
            grdPropertyDealerDetail.DataSource = dst.Tables[0].DefaultView;
        }

        private void grdPropertyDealerDetail_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        { 
            if(e.Column.Name == "btnShowPaymentDetail")
            {
                int id = int.Parse(e.Row.Cells["ID"].Value.ToString());
                string cnic = e.Row.Cells["CNICNo1"].Value.ToString();
                string RegnNo = e.Row.Cells["RegnNo"].Value.ToString();

                SqlParameter[] prmt =
                {
                    new SqlParameter("@Task","GetPaymentDetail"),
                    new SqlParameter("@CNIC",cnic)
                };
                DataSet dst = cls_dl_AuthorizeDealer.AuthorizeDealer_Local_Reader(prmt);
                if(dst.Tables.Count > 0)
                {
                    if(dst.Tables[0].Rows.Count > 0)
                    {

                        SqlParameter[] prmtStatus =
                        {
                            new SqlParameter("@Task","Get_DealerStatusWeb"),
                            new SqlParameter("@RegnNo",RegnNo)
                        };
                        DataSet ds = SQLHelper.ExecuteDataset(
                                                     clsMostUseVars.Connectionstring,
                                                     CommandType.StoredProcedure,
                                                     "App.USP_tbl_PropertyDealers",
                                                     prmtStatus
                                                     );


                        frmPrpDlr_PaymentDetail frm = new frmPrpDlr_PaymentDetail(dst, ds);
                        frm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Data not found.", "Stop !", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    MessageBox.Show("Data not found.","Stop !",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                }
               
            }
        }
    }
}
