using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using PeshawarDHASW.Data_Layer;
using PeshawarDHASW.Models;
using PeshawarDHASW.Application_Layer.Membership;
using PeshawarDHASW.Data_Layer.clsMemberShip;

using Telerik.WinControls.UI;
using PeshawarDHASW.Application_Layer.CustomDialog;
using System.Globalization;

namespace PeshawarDHASW.Application_Layer.Membership.MSViewInfo
{
    public partial class MSBioInfo : Telerik.WinControls.UI.RadForm
    {
        public MSBioInfo()
        {
            InitializeComponent();
        }

        public int MSID { get; set; }      
        public MSBioInfo(int ID)
        {
            MSID = ID;
            InitializeComponent();
        }


        public MSBioInfo(int ID, bool status = false)
        {
            MSID = ID;
            InitializeComponent();
            radGroupBox1.Enabled = status;
            radGroupBox3.Enabled = status;
        }
        private void MSBioInfo_Load(object sender, EventArgs e)
        {
            try
            {
                this.ThemeName = clsUser.ThemeName;
                ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
                SqlParameter[] parameter = new[]
                {
                    new SqlParameter("@Task","Select"),
                    new SqlParameter("@ID", MSID)
                };
                DataSet ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameter);
                DataTable dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    txtmsno.Text = row["MembershipNo"].ToString();
                    txtname.Text = row["Name"].ToString();
                    cmbgender.Text = row["Gender"].ToString();
                    txtfather.Text = row["Father"].ToString();
                    txtnicnicop.Text = @row["NICNICOP"].ToString();
                    txtpassport.Text = row["PassportNo"].ToString();
                    txtreligion.Text = row["Religion"].ToString();
                    txtnationality.Text = row["Nationality"].ToString();

                  

                    txtplaceofB.Text = row["PlaceofDoB"].ToString();
                    txtpermentaddress.Text = row["PrementAddress"].ToString();
                    txtfaxno.Text = row["FaxNo"].ToString();
                    txtprofession.Text = row["Profession"].ToString();
                    txtfatherprofession.Text = row["FPorfession"].ToString();
                    cmbMarrigeStatus.Text = row["Marital Status"].ToString();
 
                 

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
                    txtstatus.Text = row["Status"].ToString();
                    txtOtherMo.Text = row["OtherNo"].ToString();

                    txtArms.Text = row["Arms"].ToString();
                    txtCasueOfShahadat.Text = row["CauseOfShahadat"].ToString();
                    txtPlaceOfShahadat.Text = row["PlaceOfShahadat"].ToString();
                    txtPartNOK.Text = row["ParticularOfNOK"].ToString();
                    txtDocumentNo.Text = row["DocumentNo"].ToString();

                    //if (!string.IsNullOrEmpty(row["DoB"].ToString()))
                    //    txtdob.Value = DateTime.ParseExact(row["DoB"].ToString(), "dd/MM/yyyy", null);
                    DateTime txtdobdate;
                    bool Flagtxtdob = DateTime.TryParse(row["DoB"].ToString(), out txtdobdate);
                    if (Flagtxtdob == true)
                    {
                        txtdob.Value = txtdobdate.Date;
                    }
                    else
                    {
                        txtdob.NullText = "Date of Birth  . . .";
                        txtdob.SetToNullValue();
                    }

                    txtDateofMarrige.Text = row["DateofMarriage"].ToString();


                    DateTime DateOfShahadatdt;
                    bool FlagDateParse = DateTime.TryParse(row["DateOfShahadat"].ToString(), out DateOfShahadatdt);
                    if (FlagDateParse == true)
                    { dtDateOfShahadat.Value = DateOfShahadatdt.Date; }
                    else
                    {
                        dtDateOfShahadat.NullText = "Shahadat Date . . .";
                        dtDateOfShahadat.SetToNullValue();
                    }


                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on MSBioInfo_Load.", ex, "MSBioInfo");
                frmobj.ShowDialog();

            }
        }

        private void btnMemberSave_Click(object sender, EventArgs e)
        {

        }
    }
}
