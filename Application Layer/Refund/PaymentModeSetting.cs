using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Refund
{
    public partial class PaymentModeSetting : Telerik.WinControls.UI.RadForm
    {
        public PaymentModeSetting()
        {
            InitializeComponent();
        }

        public PaymentModeSetting(string RefundNo,string ChequeNo)
        {

            InitializeComponent();
            lblRefundtrx.Text = RefundNo;
            txtchequeNo.Text = ChequeNo;
        }

        private void PaymentModeSetting_Load(object sender, EventArgs e)
        {

        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtchequeNo.Text))
                {
                    SqlParameter[] param = {
                                            new SqlParameter("@Task","PaymentModeChanges"),
                                            new SqlParameter("@RefundID",lblRefundtrx.Text),
                                            new SqlParameter("@ChequeNo",txtchequeNo.Text),
                                        };
                    int result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_Refund", param);
                    if (result > 0)
                    {
                        MessageBox.Show("Changes Save Successfull.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Something is Missing.");
                    }
                }
                else
                {
                    MessageBox.Show("Cheque No is Mandatory.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occur: "+ex.Message);
            }
        }
    }
}
