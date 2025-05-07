using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsApplication;
using PeshawarDHASW.Data_Layer.clsMemberShip;
using PeshawarDHASW.Models;
using Telerik.WinControls;
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Helper;
using System.Globalization;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Membership.Modify
{
    public partial class frmModifyBioData : Telerik.WinControls.UI.RadForm
    {
        public frmModifyBioData()
        {
            InitializeComponent();
        }

        public int MBSID { get; set; }
        public frmModifyBioData(int ID)
        {
            MBSID = ID;
            InitializeComponent();
        }
        private void frmModifyBioData_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            LoadRanks();
            #region Load Personal Information
            try
            {
                SqlParameter[] parameter = new[]
                {
                    new SqlParameter("@Task","Select"),
                    new SqlParameter("@ID", MBSID)
                };
                DataSet ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameter);
                if (ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    foreach (DataRow row in dt.Rows)
                    {
                        txtmsno.Text = row["MembershipNo"].ToString();
                        txtFileNo.Text = @row["FileNo"].ToString();
                        txtname.Text = row["Name"].ToString();
                        cmbgender.Text = row["Gender"].ToString();
                        txtfather.Text = row["Father"].ToString();
                        txtnicnicop.Text = @row["NICNICOP"].ToString();
                        txtpassport.Text = row["PassportNo"].ToString();
                        txtreligion.Text = row["Religion"].ToString();
                        txtnationality.Text = row["Nationality"].ToString();
                        if (!string.IsNullOrEmpty(row["DoB"].ToString()))
                            txtdob.Value = DateTime.ParseExact(row["DoB"].ToString(), "dd/MM/yyyy", null);
                        txtplaceofB.Text = row["PlaceofDoB"].ToString();
                        txtpermentaddress.Text = row["PrementAddress"].ToString();
                        txtfaxno.Text = row["FaxNo"].ToString();
                        txtprofession.Text = row["Profession"].ToString();
                        txtfatherprofession.Text = row["FPorfession"].ToString();

                        cmbMarrigeStatus.Text = row["Marital Status"].ToString();

                       
                        //cmbMarrigeStatus.Text = row["Marital Status"].ToString();
                        txtDateofMarrige.Text = row["DateofMarriage"].ToString();
                        txtArmSvc.Text = row["Arm/Svc"].ToString();
                        txteducation.Text = @row["Education/Qualification"].ToString();
                        txthwname.Text = @row["HusbandWifeName"].ToString();
                        txthwprofession.Text = @row["H/W Profession"].ToString();
                        txttelnooffice.Text = @row["TelNo(Office)"].ToString();
                        txttelnores.Text = @row["TelNo(Res)"].ToString();
                        txtpresentaddress.Text = row["PresentAddress"].ToString();
                        txtsector.Text = row["Sector"].ToString();
                        txtstreetno.Text = @row["Street/Lane No"].ToString();
                        txtsize.Text = row["Size"].ToString();
                        txtpano.Text = row["PersonalNo(SvcPersOnly)"].ToString();

                        txtrank.Text = row["Rank"].ToString();

                        txtmobile.Text = row["MobileNo"].ToString();
                        txtemail.Text = row["Email"].ToString();
                        txtdomicile.Text = row["Domicile"].ToString();
                        txtOtherNo.Text = row["OtherNo"].ToString();
                        DateTime DateOfShahadatdt;
                        bool FlagDateParse = DateTime.TryParse(row["DateOfShahadat"].ToString(), out DateOfShahadatdt);
                        if (FlagDateParse == true)
                        { dtDateOfShahadat.Value = DateOfShahadatdt.Date; }
                        else
                        { dtDateOfShahadat.NullText = "Shahadat Date . . ."; }

                        txtArms.Text = row["Arms"].ToString();
                        txtCasueOfShahadat.Text = row["CauseOfShahadat"].ToString();
                        txtPlaceOfShahadat.Text = row["PlaceOfShahadat"].ToString();
                        txtPartNOK.Text = row["ParticularOfNOK"].ToString();
                        txtDocumentNo.Text = row["DocumentNo"].ToString();
                        
                        
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmModifyBioData_Load.", ex, "frmModifyBioData");
                frmobj.ShowDialog();
            }
            #endregion
        }

        #region OldTechnique
        private void ModifyBioDataofMS()
        {
            try
            {
                SqlParameter[] parameter1 = {
                                        new SqlParameter("@ID",MBSID),
                                        new SqlParameter("@MembershipNo",txtmsno.Text),
                                        new SqlParameter("@Name",txtname.Text),
                                        new SqlParameter("@Gender",cmbgender.Text),
                                        new SqlParameter("@NICNICOP",txtnicnicop.Text),
                                        new SqlParameter("@PassportNo",txtpassport.Text),
                                        new SqlParameter("@PersonalNoSvcPersOnly",txtpano.Text),
                                        new SqlParameter("@Rank",txtrank.Text),
                                        new SqlParameter("@ArmSvc",txtArmSvc.Text),
                                        new SqlParameter("@EducationQualification",txteducation.Text),
                                        new SqlParameter("@Profession",txtprofession.Text),
                                        new SqlParameter("@Religion",txtreligion.Text),
                                        new SqlParameter("@Nationality",txtnationality.Text),

                                        new SqlParameter("@StreetLaneNo", txtstreetno.Text),
                                        new SqlParameter("@Sector", txtsector.Text),
                                        new SqlParameter("@Size", txtsize.Text),
                                        new SqlParameter("@DoB",txtdob.Text),
                                        new SqlParameter("@PlaceofDoB",txtplaceofB.Text),
                                        new SqlParameter("@MaritalStatus", cmbMarrigeStatus.SelectedText.ToString()),
                                        new SqlParameter("@DateofMarriage",txtDateofMarrige.Text),
                                        new SqlParameter("@Father",txtfather.Text),

                                        new SqlParameter("@FPorfession",txtfatherprofession.Text),
                                        new SqlParameter("@HusbandWifeName", txthwname.Text),
                                        new SqlParameter("@HWProfession", txthwprofession.Text),
                                        new SqlParameter("@PresentAddress",txtpresentaddress.Text),
                                        new SqlParameter("@PrementAddress",txtpermentaddress.Text),
                                        new SqlParameter("@TelNoOffice", txttelnooffice.Text),
                                        new SqlParameter("@TelNoRes", txttelnores.Text),
                                        new SqlParameter("@MobileNo", txtmobile.Text),
                                        new SqlParameter("@Email", txtemail.Text),
                                        new SqlParameter("@Domicile",txtdomicile.Text),
                                         new SqlParameter("@user_ID", PeshawarDHASW.Models.clsUser.ID)
                                        };
                cls_dl_ModifyMembership.Modify_Membership_biodata(parameter1);
                this.Close();

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on ModifyBioDataofMS.", ex, "frmModifyBioData");
                frmobj.ShowDialog();
            }
        }
        #endregion

        private void LoadRanks()
        {

            RadListDataItem Select = new RadListDataItem();
            Select.Value = 0;
            Select.Text = "--Select--";
            this.txtrank.Items.Add(Select);



            SqlParameter[] parameterr =
            {
               new SqlParameter("@Task", "LoadRanks")
            };

            foreach (DataRow row in cls_dl_Membership.Membership_PersonalInfo_Retrive(parameterr).Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["ID"].ToString();
                dataItem.Text = row["TitleRank"].ToString();
                this.txtrank.Items.Add(dataItem);
            }
            txtrank.SelectedIndex = 0;

        }

        private void ModifyMembershipInfo()
        {
            try
            {
                SqlParameter[] parameter1 =
                {
                    new SqlParameter("@Task", "Update"),
                    new SqlParameter("ID", MBSID),
                    new SqlParameter("@MembershipNo", txtmsno.Text),
                    new SqlParameter("@Name", txtname.Text),
                    new SqlParameter("@Gender", cmbgender.Text),
                    new SqlParameter("@NICNICOP", txtnicnicop.Text),
                    new SqlParameter("@PassportNo", txtpassport.Text),
                    new SqlParameter("@PersonalNoSvcPersOnly", txtpano.Text),
                    new SqlParameter("@Rank", txtrank.Text),
                    new SqlParameter("@ArmSvc", txtArmSvc.Text),
                    new SqlParameter("@EducationQualification", txteducation.Text),
                    new SqlParameter("@Profession", txtprofession.Text),
                    new SqlParameter("@Religion", txtreligion.Text),
                    new SqlParameter("@Nationality", txtnationality.Text),
                    new SqlParameter("@FaxNo",txtfaxno.Text),
                    new SqlParameter("@FilePlotShopVillaApartmentNo", txtFileNo.Text),
                    new SqlParameter("@StreetLane_No", txtstreetno.Text),
                    new SqlParameter("@Sector", txtsector.Text),
                    new SqlParameter("@Size", txtsize.Text),
                    new SqlParameter("@DoB", txtdob.Text),  //
                    new SqlParameter("@PlaceofDoB", txtplaceofB.Text),
                    new SqlParameter("@Marital_Status", cmbMarrigeStatus.SelectedItem.ToString()),
                    new SqlParameter("@DateofMarriage", txtDateofMarrige.Text),  //
                    new SqlParameter("@Father", txtfather.Text),
                    new SqlParameter("@FPorfession", txtfatherprofession.Text),
                    new SqlParameter("@HusbandWife_Name", txthwname.Text),
                    new SqlParameter("@HW_Profession", txthwprofession.Text),
                    new SqlParameter("@PresentAddress", txtpresentaddress.Text),
                    new SqlParameter("@PrementAddress", txtpermentaddress.Text),
                    new SqlParameter("@TelNoOffice", txttelnooffice.Text),
                    new SqlParameter("@TelNoRes", txttelnores.Text),
                    new SqlParameter("@MobileNo", txtmobile.Text),
                    new SqlParameter("@Email", txtemail.Text),
                    new SqlParameter("@Domicile", txtdomicile.Text),
                    new SqlParameter("@user_ID", PeshawarDHASW.Models.clsUser.ID),
                    new SqlParameter("@CompteleStatus", "Complete"),
                    new SqlParameter("@OtherNo",txtOtherNo.Text),
                    new SqlParameter("@DateOfShahadat",dtDateOfShahadat.Value.Date),
                    new SqlParameter("@Arms",txtArms.Text),
                    new SqlParameter("@CauseOfShahadat",txtCasueOfShahadat.Text),
                    new SqlParameter("@PlaceOfShahadat",txtPlaceOfShahadat.Text),
                    new SqlParameter("@ParticularOfNOK",txtPartNOK.Text),
                    new SqlParameter("@DocumentNo",txtDocumentNo.Text),
                    new SqlParameter("@NTN",txtnicnicop.Text)
                };
                int result = cls_dl_Membership.Membership_PersonalInfo(parameter1);
                if (result > 0)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Check your Connection OR Contact to Administration.");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on ModifyMembershipInfo.", ex, "frmModifyBioData");
                frmobj.ShowDialog();
            }

        }

        private void btnMemberSave_Click(object sender, EventArgs e)
        {
            ModifyMembershipInfo();
        }

        private void txtmobile_Validating(object sender, CancelEventArgs e)
        {
            btnMemberSave.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtmobile, "03XXXXXXXXX", new Regex("^[0-9]{11}$"));
        }
    }
}
