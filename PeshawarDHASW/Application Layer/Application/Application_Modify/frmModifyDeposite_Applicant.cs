using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using PeshawarDHASW.Data_Layer.clsApplication;

using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.Application.Application_Modify
{
    public partial class frmModifyDeposite_Applicant : Telerik.WinControls.UI.RadForm
    {
        public frmModifyDeposite_Applicant()
        {
            InitializeComponent();
        }
        public int appID_Get { get; set; }
        public frmModifyDeposite_Applicant(int appid_get)
        {
            appID_Get = appid_get ;
            InitializeComponent();
        }

        private void frmModifyDeposite_Applicant_Load(object sender, EventArgs e)
        {
            BindDepositeData_Applicant();
        }
        public int depost_ID { get; set;}
        private void BindDepositeData_Applicant()
        {
            try
            {
                SqlParameter[] param =
                  {
                    new SqlParameter("@Task","ModifyDeposite_Applicant"),
                    new SqlParameter("@appid",appID_Get)
                  };
                DataSet ds = Data_Layer.clsApplication.cls_dl_Application.RetrieveDepositData_Applicant(param);
                if(ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        depost_ID = int.Parse(row["ID"].ToString());
                        txtplotsize.Text = row["PlotSize"].ToString();
                        txtamount.Text = row["Amount"].ToString();
                        txtbank.Text = row["BankName"].ToString();
                        dtpDeposite.Text = row["DateofDeposite"].ToString();
                        cmbDDStatus.Text = row["Status"].ToString();
                        txtbankcode.Text = row["BranchCode"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("There is no Deposit Record for this Applicant");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on BindDepositeData_Applicant.", ex, "frmModifyDeposite_Applicant");
                frmobj.ShowDialog();

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] parm =
                  {
                    new SqlParameter("@Task","UpdateDeposit_Applicant"),
                    new SqlParameter("@ID",depost_ID),
                    new SqlParameter("@appid",appID_Get),
                    new SqlParameter("@plotsize",txtplotsize.Text),
                    new SqlParameter("@amount",txtamount.Text),
                    new SqlParameter("@bankname",txtbank.Text),
                    new SqlParameter("@branchcode",txtbankcode.Text),
                    new SqlParameter("@dateofdeposite",dtpDeposite.Text),
                    new SqlParameter("@status",cmbDDStatus.SelectedItem),
                    new SqlParameter("@user_ID",Models.clsUser.ID)
                   };
                int result = 0;
                result = cls_dl_Application.UpdateDeposit_Applicant(parm);
                if(result > 0)
                {
                    MessageBox.Show("Deposit Data Updated Successfully.");
                    this.Close();
                }
            }
            catch
            (Exception ex)
            {

                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnSave_Click.", ex, "frmModifyDeposite_Applicant");
                frmobj.ShowDialog();
            }
        }
    }
}
