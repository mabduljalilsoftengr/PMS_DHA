using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.clsFileMap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Transfer
{
    public partial class frmFileNOVerification : Telerik.WinControls.UI.RadForm
    {
        public frmFileNOVerification()
        {
            InitializeComponent();
        }

        private void txtFileNo_Leave(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] par =
                       {

                new SqlParameter("@Task","select"),
                new SqlParameter("@FileNo",txtFileNo.Text)
            };
                DataSet dst = new DataSet();
                dst = cls_dl_FileMap.FileMap_Reader(par);
                if (dst.Tables[0].Rows.Count > 0)
                {
                    SqlParameter[] parmtr =
                    {
                new SqlParameter("@Task","FileNO_Verification"),
                new SqlParameter("@FileNo",txtFileNo.Text)
            };
                    DataSet ds = new DataSet();
                    ds = cls_dl_FileMap.FileMap_Reader(parmtr);
                    int NumberofPendingOwner = int.Parse(ds.Tables[0].Rows[0]["totalOwner"].ToString());
                    if (NumberofPendingOwner == 0)
                    {
                        this.Hide();
                        frmNDCVerification obj = new frmNDCVerification(txtFileNo.Text);
                        obj.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("This File No is already in use.");
                    }
                }
                else
                {
                    MessageBox.Show("This is not a Valid File No. Please Try Another File No.");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on txtFileNo_Leave.", ex, "frmFileNOVerification");
                frmobj.ShowDialog();
            }
        
        }

        private void frmFileNOVerification_Load(object sender, EventArgs e)
        {

        }
    }
}
