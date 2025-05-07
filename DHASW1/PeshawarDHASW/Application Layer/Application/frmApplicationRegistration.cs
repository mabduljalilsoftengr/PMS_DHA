using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Telerik.WinControls.UI;
using PeshawarDHASW.Data_Layer;
using PeshawarDHASW.Application_Layer;
using PeshawarDHASW.Data_Layer.clsApplication;

using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Helper;
using System.Data.SqlClient;

namespace PeshawarDHASW.Application_Layer
{
    public partial class frmApplicationRegistration : RadForm
    {
        public frmApplicationRegistration()
        {
            InitializeComponent();
        }
        #region seperate string and number  #ABR

        #endregion
        #region fix name and father text boxes.input as "khan" displayed as incorrect value   #ABR

        #endregion
        #region Design Issue , Application form issue    #ABR

        #endregion

        #region correct comboboxes , fill the right values   #ABR
        //  Check if string is empty #ABR start 

        // Check if string is empty #ABR END 
        #endregion
        #region  City and Country textboxes validation  #ABR

        #endregion
        #region  Email format validation (format) #ABR

        #endregion
        #region  Bug : if every field contains invalid data the application crashes #ABR

        #endregion
        #region textboxes ticks doesnt disappear after saving  #ABR

        #endregion
        #region date of birth should not be greater than current date   #ABR

        #endregion
        #region textboxes ticks doesnt disappear after saving  #ABR

        #endregion
        #region form closing automate ,one form should be open at one time   #ABR

        #endregion
        #region office no and phone no validation  #ABR

        #endregion

        private void validatingNumber(TextBox txt, String Message, Regex numberchk)
        {
            if (txtFormNo.Text == string.Empty)
            {
                errorProvider1.SetError(txt, "Please Enter " + Message);
                errorProvider2.SetError(txt, "");
                errorProvider3.SetError(txt, "");
                btnSave.Enabled = false;
            }
          
            else
            {
               

                if (numberchk.IsMatch(txt.Text))
                {
                    errorProvider1.SetError(txt, "");
                    errorProvider2.SetError(txt, "");
                    errorProvider3.SetError(txt, "Correct");
                    btnSave.Enabled = true;
                }
                else
                {
                    errorProvider1.SetError(txt, "");
                    errorProvider2.SetError(txt, "Wrong format");
                    errorProvider3.SetError(txt, "");
                    btnSave.Enabled = false;
                }
                errorProvider1.SetError(txt, "");

            }
        }

        private void txtFormNo_Validating(object sender, CancelEventArgs e)
        {
            Regex numberchk = new Regex(@"^([0-9]*|\d*)$");
            validatingNumber(txtFormNo, "From No.", numberchk);
        }

        private void frmApplicationRegistration_Load(object sender, EventArgs e)
        {
            try
            {
                btnSave.Enabled = false;
                DataSet ds = cls_dl_Application.Category();
                cmbCategoreis.DataSource = ds.Tables[0];
                cmbCategoreis.ValueMember = "ID";
                cmbCategoreis.DisplayMember = "Categories";

                //Combo Boxs
                cmdGender.SelectedIndex = 0;
                nkcmbGender.SelectedIndex = 0;
                cmbReligion.SelectedIndex = 0;
                cmbDDStatus.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Load Method.", ex, "frmApplicationRegistration/frmApplicationRegistration_Load");
                frmobj.ShowDialog();

            }

        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            funcClear();
        }

        private void funcClear()
        {
            //Application Registration
            txtFormNo.Text = "";
            txtName.Text = "";
            txtFather.Text = "";
            txtNIC.Text = "";
            txtPassportNo.Text = "";
            txtMailAddress.Text = "";
            txtpermentAddress.Text = "";
            txtcity.Text = "";
            txtdistrict.Text = "";
            txtcountry.Text = "";
            txtemail.Text = "";
            txtphone.Text = "";
            txtoffice.Text = "";
            txtmobile.Text = "";
            //Next of Kin
            txtnkFather.Text = "";
            txtNKName.Text = "";
            txtNKNIC.Text = "";
            dtpNKDOB.Value = DateTime.Now;
            txtNKRelation.Text = "";
            //Fee Deposite
            txtplotsize.Text = "";
            txtamount.Text = "";
            txtbank.Text = "";
            txtbankcode.Text = "";
            dtpDeposite.Value = DateTime.Now;
            cmdGender.SelectedIndex = 0;
            nkcmbGender.SelectedIndex = 0;
            cmbReligion.SelectedIndex = 0;
            cmbDDStatus.SelectedIndex = 0;
        }


        private void funcSave()
        {
            try
            {
                #region Applicant
                Models.clsApplicant objapp = new Models.clsApplicant();
                objapp.ID = 0;
                objapp.FormNo = Convert.ToInt32(txtFormNo.Text);
                objapp.Name = txtName.Text;
                objapp.Gender = cmdGender.Text;
                objapp.Catergories = int.Parse(cmbCategoreis.SelectedValue.ToString());
                objapp.Father = txtFather.Text;
                objapp.CNIC = txtNIC.Text;
                objapp.Religion = cmbReligion.Text;
                objapp.PassportNo = txtPassportNo.Text;
                objapp.MailAddress = txtMailAddress.Text;
                objapp.PermentAddress = txtpermentAddress.Text;
                objapp.City = txtcity.Text;
                objapp.District = txtdistrict.Text;
                objapp.Country = txtcountry.Text;
                objapp.Email = txtemail.Text;
                objapp.Phone = txtphone.Text;
                objapp.Office = txtoffice.Text;
                objapp.Mobile = txtoffice.Text;
                //Call User Model
                objapp.user_ID = Models.clsUser.ID;
                #endregion

                #region Next of Kin
                Models.clsNextofkin objnk = new Models.clsNextofkin();
                objnk.AppID = 0;
                objnk.Name = txtNKName.Text;
                objnk.Gender = nkcmbGender.Text;
                objnk.Father = txtnkFather.Text;
                objnk.CNIC = txtNKNIC.Text;
                objnk.DOB = dtpNKDOB.Text;
                objnk.RelationWApplicant = txtNKRelation.Text;
                objnk.Passport = txtnkpassport.Text;
                //Call User Model
                objnk.user_ID = Models.clsUser.ID;
                #endregion

                #region Fee Deposite
                Models.clsDeposite objds = new Models.clsDeposite();
                objds.AppID = 0;
                objds.PlotSize = txtplotsize.Text;
                objds.Amount = txtamount.Text;
                objds.BankName = txtbank.Text;
                objds.BranchCode = txtbankcode.Text;
                objds.DateofDeposite = dtpDeposite.Text;
                objds.Status = cmbDDStatus.Text;
                //Call User Model
                objds.user_ID = Models.clsUser.ID;

                int result = 0;
                result = Data_Layer.clsApplication.cls_dl_Application.ApplicationData(objApp: objapp, objnk: objnk, objd: objds);
                if (result > 0)
                {
                    funcClear();
                }
                else
                {
                    MessageBox.Show("Record is Not Save Kindly Check.");
                }
                #endregion
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Applicant Registration is failed.",ex,"frmApplicationRegistration/funSave");
                frmobj.ShowDialog(); 
            }
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            funcSave();
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            Regex numberchk = new Regex(@"^[A-Za-z_ ]{3,50}$");
            validatingNumber(txtName, "Name.", numberchk);
        }

        private void txtFather_Validating(object sender, CancelEventArgs e)
        {
            Regex numberchk = new Regex(@"^[A-Za-z_ ]{3,50}$");   
            btnSave.Enabled = clsPluginHelper.formatValidator(errorProvider1, errorProvider3, errorProvider2, txtFather, " Father Name", numberchk) ? true : false;
        }

        private void txtNIC_Validating(object sender, CancelEventArgs e)
        {
        }

        private void txtNIC_Validating_1(object sender, CancelEventArgs e)
        {
            Regex numberchk = new Regex(@"^([0-9]{5}-[0-9]{7}-[0-9]{1})|([0-9]{6}-[0-9]{6}-[0-9]{1})$");
            btnSave.Enabled = clsPluginHelper.formatValidator(errorProvider1, errorProvider3, errorProvider2, txtNIC, " NIC | NICOP ", numberchk) ? true : false;
        }

        private void txtFormNo_Leave(object sender, EventArgs e)
        {
            if(cmbformtype.SelectedItem.ToString() == "Online Form")
            {
                SqlParameter[] prm =
                {
                    new SqlParameter("@Task","FetchFormData"),
                    new SqlParameter("@FormNo",txtFormNo.Text)
                };
                DataSet dst = new DataSet();
                dst = cls_dl_Application.Applicant_Info_Retrive(prm);

            }
        }
    }
}
