using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.clsUser;
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
    public partial class frm_Secret_Code : Telerik.WinControls.UI.RadForm
    {
        public frm_Secret_Code()
        {
            InitializeComponent();
        }

        private void btnSecretCode_Click(object sender, EventArgs e)
        {
            try
            {
                //PeshawarDHASW.Models.clsUser.ID = 9;
                //+++++++++++++++++++++++ Encryption ++++++++++++++++++++++++++
                //Here key is of 128 bit  
                //Key should be either of 128 bit or of 192 bit  
                string encrpt = "";
                if (txtSecretCode.Text != string.Empty)
                {
                    encrpt = cls_dl_User.Encrypt(txtSecretCode.Text, "sblw-3hn8-sqoy19");
                }
                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                SqlParameter[] prmtr =
                {
                new SqlParameter("@Task","Check_Secret_Code"),
                new SqlParameter("@Secret_Code",encrpt),
                new SqlParameter("@ID",PeshawarDHASW.Models.clsUser.ID)
                };
                DataSet dst = cls_dl_User.UserReader(prmtr);
                if (dst.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Your Code is Not Correct, Please try another.");
                }
                else
                {
                    Helper.clsMostUseVars.Drctr_Secret_Code = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnSecretCode_Click.", ex, "frm_Secret_Code");
                frmobj.ShowDialog();
            }
           
        }

        private void frm_Secret_Code_Load(object sender, EventArgs e)
        {

        }
    }
}
