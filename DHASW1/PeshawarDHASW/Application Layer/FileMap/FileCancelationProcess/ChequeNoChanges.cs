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

namespace PeshawarDHASW.Application_Layer.FileMap.FileCancelationProcess
{
    public partial class ChequeNoChanges : Telerik.WinControls.UI.RadForm
    {
        public ChequeNoChanges()
        {
            InitializeComponent();
        }

        public ChequeNoChanges(string FileCancelID, string ChequeNo, string Bank)
        {
            InitializeComponent();
            lblFileCancelationID.Text = FileCancelID;
            txtChequeNo.Text = ChequeNo;
            txtBank.Text = Bank;
        }

        private void ChequeNoChanges_Load(object sender, EventArgs e)
        {

        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtChequeNo.Text) || string.IsNullOrWhiteSpace(txtBank.Text))
            {
                MessageBox.Show("Cheque No & Bank Fields are Mandatory.");
            }
            else
            {
                SqlParameter param_out_ID = new SqlParameter()
                {
                    ParameterName = "@FileCanceltion",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlParameter[] param = {
                    new SqlParameter("@Task","ChequeNoChanges"),
                    new SqlParameter("@FileCancelationID",lblFileCancelationID.Text),
                    new SqlParameter("@ChequeNumber",txtChequeNo.Text),
                    new SqlParameter("@Bank",txtBank.Text),
                    param_out_ID
                   };
                int result = SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(), CommandType.StoredProcedure, "usp_tbl_FileCancelation", param);

                if (result > 0)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Cheque No or Bank Information.");
                }
            }
        }
    }
}
