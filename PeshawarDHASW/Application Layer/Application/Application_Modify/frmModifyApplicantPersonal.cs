using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.clsApplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Application.Application_Modify
{
    public partial class frmModifyApplicantPersonal : Telerik.WinControls.UI.RadForm
    {
        public frmModifyApplicantPersonal()
        {
            InitializeComponent();
        }
        public int appId_get { get; set; }
        public frmModifyApplicantPersonal(int appid)
        {
            appId_get = appid;
            InitializeComponent();
        }

        private void frmModifyApplicantPersonal_Load(object sender, EventArgs e)
        {
            try
            {
                BindPersonalInfo(appId_get);
                //btnSave.Enabled = false;
                DataSet ds = cls_dl_Application.Category();
                cmbCategoreis.DataSource = ds.Tables[0];
                cmbCategoreis.ValueMember = "ID";
                cmbCategoreis.DisplayMember = "Categories";
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmModifyApplicantPersonal_Load.", ex, "frmModifyApplicantPersonal");
                frmobj.ShowDialog();

            }

        }
        private void BindPersonalInfo(int AppID_Get)
        {
            try
            {
                SqlParameter[] param =
                  {
                    new SqlParameter("Task","Select_Personal"),
                    new SqlParameter("@ID",AppID_Get)
                  };
                DataSet ds = cls_dl_Application.Applicant_Info_Retrive(param);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    txtFormNo.Text = row["FormNo"].ToString();
                    cmbCategoreis.SelectedItem = row["Catergories"].ToString();
                    txtName.Text = row["Name"].ToString();
                    cmbGender.SelectedItem = row["Gender"].ToString();
                    txtFather.Text = row["Father(S/O,D/O,W/O)"].ToString();
                    txtNIC.Text = row["CNIC"].ToString();
                    cmbReligion.SelectedItem = row["Religion"].ToString();
                    txtPassportNo.Text = row["PassportNo"].ToString();
                    txtMailAddress.Text = row["MailAddress"].ToString();
                    txtpermentAddress.Text = row["PermentAddress"].ToString();
                    txtcity.Text = row["City"].ToString();
                    txtdistrict.Text = row["District"].ToString();
                    txtcountry.Text = row["Country"].ToString();
                    txtemail.Text = row["Email"].ToString();
                    txtphone.Text = row["Phone"].ToString();
                    txtoffice.Text = row["Office"].ToString();
                    txtmobile.Text = row["Mobile"].ToString();

                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on BindPersonalInfo.", ex, "frmModifyApplicantPersonal");
                frmobj.ShowDialog();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdatePersonalInfo(appId_get);
        }
        private void UpdatePersonalInfo(int AppID_Get)
        {
            try { 
         SqlParameter[] param = new[]
            {
            new SqlParameter ("@Task","UpdatePersonalInfo"),
            new SqlParameter ("@ID",AppID_Get.ToString()),
            new SqlParameter("@FormNo", int.Parse(txtFormNo.Text)),
            new SqlParameter("@Catergories", int.Parse(cmbCategoreis.SelectedValue.ToString())),
            new SqlParameter("@Name", txtName.Text),
            new SqlParameter("@Gender", cmbGender.SelectedItem.ToString()),
            new SqlParameter("@Father", txtFather.Text),
            new SqlParameter("@NIC", txtNIC.Text),
            new SqlParameter("@Religion", cmbReligion.SelectedItem.ToString()),
            new SqlParameter("@PassportNo", txtPassportNo.Text ),
            new SqlParameter("@MailAddress", txtMailAddress.Text),
            new SqlParameter("@Address", txtpermentAddress.Text),
            new SqlParameter("@City", txtcity.Text),
            new SqlParameter("@District", txtdistrict.Text),
            new SqlParameter("@Country", txtcountry.Text),
            new SqlParameter("@Email", txtemail.Text),
            new SqlParameter("@Phone", txtphone.Text),
            new SqlParameter("@OfficeNo", txtoffice.Text),
            new SqlParameter("@Mobile", txtmobile.Text),
            new SqlParameter("@user_ID",Models.clsUser.ID)
        };
            int result = 0;
            result = cls_dl_Application.ApplicantInfoUpdate(param);
            if(result > 0)
            {
                MessageBox.Show("Applicant Data Updated Successfully !");
                    this.Close();
            }
            else
            {
                MessageBox.Show("Contact with Administration");
            }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on UpdatePersonalInfo.", ex, "frmModifyApplicantPersonal");
                frmobj.ShowDialog();
            }

    }
    }
}
