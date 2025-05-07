using PeshawarDHASW.Data_Layer.clsApplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Telerik.WinControls;
//-------------------------------------------//
using PeshawarDHASW.Data_Layer;
using PeshawarDHASW.Data_Layer.clsErrorLog;
using PeshawarDHASW.Data_Layer.clsFileMap;
using PeshawarDHASW.Data_Layer.clsMemberShip;

using PeshawarDHASW.Models;
using Telerik.WinControls.UI;
using PeshawarDHASW.Data_Layer.NDC;
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.Owner;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Application_Layer.Membership
{
    public partial class frmMembership : Telerik.WinControls.UI.RadForm
    {
        public int NDCNo { get; set; }
        public int MemberID { get; set; }
        public string CNIC { get; set; }


        public frmMembership()
        {
            InitializeComponent();
        }
        public frmMembership(int get_NDCNo, int get_MemberID, string get_cnic)
        {
            NDCNo = get_NDCNo;
            MemberID = get_MemberID;
            CNIC = get_cnic;
            InitializeComponent();
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            //bool varrr = cmbMarrigeStatus.Text == "Yes" ? false  : true;
            //txtfather.Enabled = varrr;
            //txtfatherprofession.Enabled = varrr;
            //if (varrr == false)
            //{
            //    txtfather.Text  = "";
            //    txtfatherprofession.Text = "";
            //    txtfather.NullText = "Entry Not Alowed";
            //    txtfatherprofession.NullText = "Entry Not Alowed";
            //}
            //else
            //{
            //    txtfather.NullText = "";
            //    txtfatherprofession.NullText = "";
            //    txtfather.Text = "";
            //    txtfatherprofession.Text = "";
            //}
        }

        private void frmMembership_Load(object sender, EventArgs e)
        {
            dateOfPurchase.Value = DateTime.Now;
            dateOfSale.Value = DateTime.Now;
            try
            {
                this.ThemeName = clsUser.ThemeName;
                ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);

                DataSet ds = cls_dl_Membership_PlotTYpe.PlotType();
                cbplot_type.DataSource = ds.Tables[0];
                cbplot_type.ValueMember = "PlotID";
                cbplot_type.DisplayMember = "Type";
                cmbgender.SelectedIndex = 0;
                txtreligion.SelectedIndex = 0;

                LoadRanks();

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmMembership_Load.", ex, "frmMembership");
                frmobj.ShowDialog();

            }

        }
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
    //private void Get_MemberShip_All_Data(int getMemberid)
    //{
    //    SqlParameter[] prmt =
    //    {
    //        new SqlParameter("@Task","Get_AllMSInfo_Against_MemberID"),
    //        new SqlParameter("@MemberID",getMemberid)
    //    };
    //    DataSet ds_t = cls_dl_Membership.Membership_All_Retrive(prmt);
    //    #region Personal Information
    //    txtmbno.Text = ds_t.Tables[0].Rows[0]["MembershipNo"].ToString();
    //    txtname.Text = ds_t.Tables[0].Rows[0]["Name"].ToString();
    //    cmbgender.Text = ds_t.Tables[0].Rows[0]["Gender"].ToString(); 
    //    //txtnicnicop.Text = ds_t.Tables[0].Rows[0]["NICNICOP"].ToString();
    //    txtnicnicop.Text = CNIC;
    //    txtpassport.Text = ds_t.Tables[0].Rows[0]["PassportNo"].ToString();
    //    txtpano.Text = ds_t.Tables[0].Rows[0]["PersonalNo(SvcPersOnly)"].ToString();
    //    txtrank.Text = ds_t.Tables[0].Rows[0]["Rank"].ToString();
    //    txtArmSvc.Text = ds_t.Tables[0].Rows[0]["Arm/Svc"].ToString();
    //    txteducation.Text = ds_t.Tables[0].Rows[0]["Education/Qualification"].ToString();
    //    ds_t.Tables[0].Rows[0]["Profession"].ToString();
    //    ds_t.Tables[0].Rows[0]["Religion"].ToString();
    //    ds_t.Tables[0].Rows[0]["Nationality"].ToString();
    //    ds_t.Tables[0].Rows[0]["FaxNo"].ToString();

    //    ds_t.Tables[0].Rows[0]["TypePlot"].ToString();
    //    ds_t.Tables[0].Rows[0]["Street/Lane No"].ToString();
    //    ds_t.Tables[0].Rows[0]["Sector"].ToString();
    //    ds_t.Tables[0].Rows[0]["Size"].ToString();
    //    ds_t.Tables[0].Rows[0]["DoB"].ToString();
    //    ds_t.Tables[0].Rows[0]["PlaceofDoB"].ToString();
    //    ds_t.Tables[0].Rows[0]["Marital Status"].ToString();
    //    ds_t.Tables[0].Rows[0]["DateofMarriage"].ToString();
    //    ds_t.Tables[0].Rows[0]["Father"].ToString();

    //    ds_t.Tables[0].Rows[0]["FPorfession"].ToString();
    //    ds_t.Tables[0].Rows[0]["Husband/Wife Name"].ToString();
    //    ds_t.Tables[0].Rows[0]["H/W Profession"].ToString();
    //    ds_t.Tables[0].Rows[0]["PresentAddress"].ToString();
    //    ds_t.Tables[0].Rows[0]["PrementAddress"].ToString();
    //    ds_t.Tables[0].Rows[0]["TelNo(Office)"].ToString();
    //    ds_t.Tables[0].Rows[0]["TelNo(Res)"].ToString();

    //    ds_t.Tables[0].Rows[0]["MobileNo"].ToString();
    //    ds_t.Tables[0].Rows[0]["Email"].ToString();
    //    ds_t.Tables[0].Rows[0]["Domicile"].ToString();
    //    ds_t.Tables[0].Rows[0]["Status"].ToString();
    //    ds_t.Tables[0].Rows[0]["user_ID"].ToString();
    //    ds_t.Tables[0].Rows[0]["DataStatus"].ToString();
    //    ds_t.Tables[0].Rows[0]["CompteleStatus"].ToString();
    //    ds_t.Tables[0].Rows[0]["VerifyStatus"].ToString();
    //    #endregion
    //}
    private void btnPlotTypeView_Click(object sender, EventArgs e)
        {
            Definition.frmPlotType obj = new Definition.frmPlotType();
            obj.ShowDialog();
        }

        private void btnMBSNO_Click(object sender, EventArgs e)
        {
            txtmbno.Text = Business_Layer.cls_MembershipNoGenerate.MembershipNoGenerator();
        }

        #region Membership Personal Info Save  
        private void MembershipPersonalInfo()
        {
            try
            {
                if (MemberShipChecker("memberCounter", txtmbno.Text))
                {
                    SqlParameter param_out_ID = new SqlParameter()
                    {
                        ParameterName = "@OutIDMS",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };
                    int plottype = Convert.ToInt32(cbplot_type.SelectedItem = cbplot_type.SelectedItem == "Residential" ? 1 : 2);
                    string marriagestatus = Convert.ToString(cmbMarrigeStatus.SelectedItem = cmbMarrigeStatus.SelectedItem == "Married" ? "Married" : "DummyText");
                    string gender = Convert.ToString(cmbgender.SelectedItem = cmbgender.SelectedItem == "Male" ? "Male" : "DummyText");
                    string religion = Convert.ToString(txtreligion.SelectedItem = txtreligion.SelectedItem == "Muslim" ? "Muslim" : "DummyText");

                    SqlParameter[] parameter1 =
                    {
                        new SqlParameter("@Task", "Insert"),
                        new SqlParameter("@MembershipNo", txtmbno.Text),
                        new SqlParameter("@Name", txtname.Text),
                        new SqlParameter("@Gender", gender),/// Gender status combobox
                        new SqlParameter("@NICNICOP", txtnicnicop.Text),
                        new SqlParameter("@PassportNo", txtpassport.Text),
                        new SqlParameter("@PersonalNoSvcPersOnly", txtpano.Text),
                        new SqlParameter("@Rank", txtrank.Text),
                        new SqlParameter("@ArmSvc", txtArmSvc.Text),
                        new SqlParameter("@EducationQualification", txteducation.Text),
                        new SqlParameter("@Profession", txtprofession.Text),
                        new SqlParameter("@Religion", religion),//// Religion status Combobox
                        new SqlParameter("@Nationality", txtnationality.Text),
                        new SqlParameter("@FilePlotShopVillaApartmentNo", txtfileno.Text),
                        new SqlParameter("@TypePlot", plottype), /// Plot Type Combobox
                        new SqlParameter("@StreetLane_No", txtstreetno.Text),
                        new SqlParameter("@Sector", txtsector.Text),
                        new SqlParameter("@Size", txtsize.Text),
                        new SqlParameter("@DoB", txtdob.Text),
                        new SqlParameter("@PlaceofDoB", txtplaceofB.Text),
                        new SqlParameter("@Marital_Status", marriagestatus), /// Marriage status Combobox
                        new SqlParameter("@DateofMarriage", txtDateofMarrige.Text),
                        new SqlParameter("@Father", txtfather.Text),
                        new SqlParameter("@FPorfession", txtfatherprofession.Text),
                        new SqlParameter("@HusbandWife_Name", txthwname.Text),
                        new SqlParameter("@HW_Profession", txthwprofession.Text),
                        new SqlParameter("@PresentAddress",txtpresentaddress.Text),
                        new SqlParameter("@PrementAddress", txtpermentaddress.Text),
                        new SqlParameter("@TelNoOffice", txttelnooffice.Text),
                        new SqlParameter("@TelNoRes", txttelnores.Text),
                        new SqlParameter("@MobileNo", txtmobile.Text),
                        new SqlParameter("@Email", txtemail.Text),
                        new SqlParameter("@FaxNo",txtFaxNo.Text),
                        new SqlParameter("@Domicile", txtdomicile.Text),
                        new SqlParameter("@user_ID", PeshawarDHASW.Models.clsUser.ID),
                        new SqlParameter("@OtherNo",txtOtherNo.Text),

                        new SqlParameter("@DateOfShahadat",dtDateOfShahadat.Value.Date),
                        new SqlParameter("@Arms",txtArms.Text),
                        new SqlParameter("@CauseOfShahadat",txtCasueOfShahadat.Text),
                        new SqlParameter("@PlaceOfShahadat",txtPlaceOfShahadat.Text),
                        new SqlParameter("@ParticularOfNOK",txtPartNOK.Text),
                        new SqlParameter("@DocumentNo",txtDocumentNo.Text),

                        param_out_ID,

                        new SqlParameter("@CompteleStatus", "Complete"),
                        new SqlParameter("@NDCNo",NDCNo),
                        new SqlParameter("@NTN",txtnicnicop.Text)
                    };
                    SqlCommand result;
                    result = Data_Layer.clsMemberShip.cls_dl_Membership.Membership_PersonalInfo_outparameter(parameter1);
                    if (result.Parameters.Count != 0)
                    {
                        //if (NDCNo == 0)
                        //{

                        //}
                        //else
                        //{
                        //    int MSNewID = int.Parse(result.Parameters["@OutIDMS"].Value.ToString());
                        //    SqlParameter[] prmtr =
                        //    {
                        //    new SqlParameter("@Task","Update_NDCNo"),
                        //    new SqlParameter("@ID",MSNewID),
                        //    new SqlParameter("@NDCNo",NDCNo)
                        //};
                        //    int rslt = cls_dl_Membership.Membership_PersonalInfo(prmtr);
                        //}

                        lblstatusPersonal.Text = "Successful";
                        tabControl1.SelectedTab = nextofkininfo;
                    }
                    else
                    {
                        //MessageBox.Show("Not Successful Check Your Data");
                        lblstatusPersonal.Text = "Unsuccessful";
                    }
                }
                else
                {
                    MemberVerification();
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on MembershipPersonalInfo.", ex, "frmMembership");
                frmobj.ShowDialog();
            }
        }
        private void btnMemberSave_Click(object sender, EventArgs e)
        {
            if (txtmbno.Text != string.Empty)
            {
                if (txtfileno.Text != string.Empty)
                {
                    MembershipPersonalInfo();
                }
                else
                {
                    MessageBox.Show("Enter File No");
                }
            }
            else
            {
                MessageBox.Show("Enter Membership No");
            }
        }
        #endregion
        #region Next of Kin
        private void MembershipNextofKin()
        {
            try
            {
                if (MemberShipChecker("nextofkinCounter", txtmbno.Text))
                {
                    if (txtmbno.Text != string.Empty)
                    {
                        //Membership ID Finder
                        SqlParameter[] searchparam =
                        {
                            new SqlParameter("@Task", "Select"),
                            new SqlParameter("@MembershipNo", txtmbno.Text)
                        };
                        DataSet ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(searchparam);
                        int MembershipID = 0;
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            MembershipID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());

                            //@MemberID, @NameofKin, @Relation, @NICNICOP, @PassportNo, @Address, @TelNoOffice, 
                            //@TelNoRes, @MobileNo, @Email, @FaxNo, @user_ID
                            if (MembershipID != 0)
                            {
                                SqlParameter[] parameters = new[]
                                {
                                    new SqlParameter("@Task", "Insert"),
                                    new SqlParameter("@MemberID", MembershipID),
                                    new SqlParameter("@NameofKin", txtnokname.Text),
                                    new SqlParameter("@Relation", txtnokrelation.Text),
                                    new SqlParameter("@NICNICOP", txtnoknic.Text),
                                    new SqlParameter("@PassportNo", txtnokpassportno.Text),
                                    new SqlParameter("@Address", txtnokaddress.Text),
                                    new SqlParameter("@TelNoOffice", txtnokofficetel.Text),
                                    new SqlParameter("@TelNoRes", txttelnores.Text),
                                    new SqlParameter("@MobileNo", txtnokMobile.Text),
                                    new SqlParameter("@Email", txtnokemail.Text),
                                    new SqlParameter("@FaxNo", txtnokfaxno.Text),
                                    new SqlParameter("@user_ID", clsUser.ID)
                                };
                                int result = 0;
                                result = cls_dl_Membership.Membership_NextofKin_NonQuery(parameters);
                                if (result > 0)
                                {
                                    lblnextofkinstatus.Text = "Successfull";
                                    tabControl1.SelectedTab = familymember;
                                }
                                else
                                {
                                    lblnextofkinstatus.Text = "Unsuccessfull";
                                }
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Membership No Field Must be Filled.", "Attention", MessageBoxButtons.OK,
                            MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    MemberVerification();
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on MembershipNextofKin.", ex, "frmMembership");
                frmobj.ShowDialog();
            }

        }
        #region NextofKin Save
        private void btnNextofKin_Click(object sender, EventArgs e)
        {
            MembershipNextofKin();
        }
        #endregion
        #endregion

        #region Verfication of Membership
        private void btnMmbverify_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] parameter =
                           {
                new SqlParameter("@MemberNo", txtmbnoverify.Text),
                new SqlParameter("@NIC", txtnicverify.Text)
            };
                DataSet ds = cls_dl_Membership.Membership_Verify(parameter);
                int found = int.Parse(ds.Tables[0].Rows[0]["Present"].ToString());
                if (found > 0)
                {
                    lblnokistatus.Text = "Found Go to Next Step";
                    tabControl1.SelectedTab = familymember;
                }
                else
                {
                    lblnokistatus.Text = "Not Found Enter Record.";
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnMmbverify_Click.", ex, "frmMembership");
                frmobj.ShowDialog();
            }

        }
        #endregion

        #region Family Data Saving
        private void bttnFamilyDataSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MemberShipChecker("familyCounter", txtmbno.Text))
                {
                    SqlParameter[] searchparam =
                    {
                        new SqlParameter("@Task", "Select"),
                        new SqlParameter("@MembershipNo", txtmbno.Text)
                    };
                    DataSet ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(searchparam);
                    int MembershipID = 0;
                    int result = 0;
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MembershipID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                        int row = FamilyMemberDGV.Rows.Count;
                        for (int i = 0; i < row; i++)
                        {
                            string Name = FamilyMemberDGV.Rows[i].Cells[0].Value.ToString();
                            string Date = FamilyMemberDGV.Rows[i].Cells[1].Value.ToString();
                            string NIC = FamilyMemberDGV.Rows[i].Cells[2].Value.ToString();
                            string Relation = FamilyMemberDGV.Rows[i].Cells[3].Value.ToString();
                            SqlParameter[] parameters = new[]
                            {
                                new SqlParameter("@Task", "Insert"),
                                new SqlParameter("@Member_ID", MembershipID),
                                new SqlParameter("@Name", Name),
                                new SqlParameter("@DOB", Date),
                                new SqlParameter("@NICNO", NIC),
                                new SqlParameter("@Relation", Relation),
                                new SqlParameter("@user_ID", clsUser.ID)
                            };
                            result = cls_dl_Membership.Membership_FamilyMember_NonQuery(parameters);

                        }
                        if (result > 0)
                        {
                            tabControl1.SelectedTab = finalstep;
                            FamilyMemberDGV.DataSource = null;
                            lblfamilydatastatus.Text = "Successful";
                            this.Close();
                        }
                        else
                        {
                            lblfamilydatastatus.Text = "Unsuccessful";
                        }
                    }
                }
                else
                {
                    MemberVerification();
                }

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on bttnFamilyDataSave_Click.", ex, "frmMembership");
                frmobj.ShowDialog();
            }


        }
        #endregion

        private void Clear()
        {
            #region Verify
            txtmbno.Text = "";
            txtfileno.Text = "";
            cbplot_type.SelectedIndex = -1;
            txtmbnoverify.Text = "";
            txtnicverify.Text = "";
            lblnokistatus.Text = "";
            txtOtherNo.Text = "";
            #endregion
            #region  Personal Inforamtion
            txtname.Text = "";
            cmbgender.SelectedIndex = 0;
            txtfather.Text = "";
            txtnicnicop.Text = "";
            txtpassport.Text = "";
            txtreligion.Text = "Islam";
            txtdob.Text = DateTime.Now.ToString("yy-mm-dd/MM/yyyy");
            txtplaceofB.Text = "";
            txtpermentaddress.Text = "";
            txtprofession.Text = "";
            txtfather.Text = "";
            cmbMarrigeStatus.SelectedIndex = 0;
            txtDateofMarrige.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtArmSvc.Text = "";
            txteducation.Text = "";
            txthwname.Text = "";
            txthwprofession.Text = "";
            txttelnooffice.Text = "";
            txttelnores.Text = "";
            txtsector.Text = "";
            txtstreetno.Text = "";
            txtsize.Text = "";
            txtpano.Text = "";
            txtrank.Text = "";
            txtmobile.Text = "";
            txtemail.Text = "";
            txtdomicile.Text = "";
            txtFaxNo.Text = "";
            #endregion

            #region Next of Kin
            txtnokname.Text = "";
            txtnokrelation.Text = "";
            txtnoknic.Text = "";
            txtnokpassportno.Text = "";
            txtnokaddress.Text = "";
            txtnoktelRes.Text = "";
            txtnokofficetel.Text = "";
            txtnokMobile.Text = "";
            txtnokemail.Text = "";
            txtnokfaxno.Text = "";
            #endregion

            #region Family Member
            FamilyMemberDGV.Rows.Clear();
            #endregion
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        //Family Member Verify
        #region Family Member Verify
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] parameter =
                {
                    new SqlParameter("@Task", "checkFamilyDataexist"),
                    new SqlParameter("@MSNo", clsPluginHelper.DbNullIfNullOrEmpty(txtfamilyMSNO.Text)),
                    new SqlParameter("@NIC", clsPluginHelper.DbNullIfNullOrEmpty(txtfamilyNIC.Text))
                };
                DataSet ds = cls_dl_Membership.Membership_FamilyMember_Retrive(parameter);
                int found = int.Parse(ds.Tables[0].Rows[0]["Present"].ToString());
                if (found > 0)
                {
                    txtfamilystatus.Text = "Found Go to Next Step";
                    tabControl1.SelectedTab = tabimages;
                }
                else
                {
                    txtfamilystatus.Text = "Not Found Enter Record.";
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on button1_Click.", ex, "frmMembership");
                frmobj.ShowDialog();
            }
        }
        #endregion

        private void radListView1_SelectedItemChanged(object sender, EventArgs e)
        {

        }


        #region Image Browse
        ImageList imageList = new ImageList();
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = @"Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files (.)|*.*";

                openFileDialog1.Multiselect = true;
                openFileDialog1.Title = "Select Photos";

                DialogResult dr = openFileDialog1.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {

                    string[] files = openFileDialog1.FileNames;
                    // Clear imageList and imageListView
                    this.imageListView.Items.Clear();
                    // Read all files in directory
                    foreach (var pngFile in files)
                    {
                        try
                        {
                            imageList.Images.Add(Image.FromFile(pngFile));
                        }
                        catch
                        {
                            Console.WriteLine("This is not an image file");
                        }
                    }

                    imageList.ImageSize = new Size(256, 256);

                    //this.imageListView.View = View.LargeIcon;

                    for (int counter = 0; counter < imageList.Images.Count; counter++)
                    {
                        ListViewItem item = new ListViewItem();
                        item.ImageIndex = counter;
                        item.Text = counter.ToString();
                        item.SubItems.Add("Name");
                        this.imageListView.Items.Add(item);
                    }

                    this.imageListView.LargeImageList = imageList;


                }

                imageListView.Refresh();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnBrowse_Click.", ex, "frmMembership");
                frmobj.ShowDialog();
            }


        }
        #endregion

        //Here we verify the member for that purpose that if this member is exist then bind his record 
        //with the Label, to upload the accurate Images of the Member
        public string memberID { get; set; } = "0";
        #region Member Verify
        private void memberverify()
        {
            ImageContainer.Clear();
            try
            {
                if (txtmsno.Text != "" || txtnic.Text != "")
                {
                    SqlParameter[] parameter =
                    {
                        new SqlParameter("@Task", "VerifyMember"),
                        new SqlParameter("@MembershipNo", clsPluginHelper.DbNullIfNullOrEmpty(txtmsno.Text)),
                        new SqlParameter("@NICNICOP", clsPluginHelper.DbNullIfNullOrEmpty(txtnic.Text)),
                    };
                    DataSet ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameter);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            memberID = row["ID"].ToString();
                            lblname.Text = row["Name"].ToString();
                            LBLFATHERNAME.Text = row["Father"].ToString();
                            lblmsnumber.Text = row["MembershipNo"].ToString();
                            lblmobilenumber.Text = row["MobileNo"].ToString();
                            lblcnic.Text = row["NIC/NICOP"].ToString();
                        }
                        btnSave.Visible = true;
                        gbimage.Visible = true;
                        ImageSource.Visible = true;
                    }
                    else
                    {
                        btnSave.Visible = false;
                        gbimage.Visible = false;
                        ImageSource.Visible = false;

                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on memberverify.", ex, "frmMembership");
                frmobj.ShowDialog();
            }
        }
        #endregion

        private void clearfunction()
        {
            lblname.Text = "";
            LBLFATHERNAME.Text = "";
            lblmsnumber.Text = "";
            lblmobilenumber.Text = "";
            lblcnic.Text = "";

            ImageSource.DataSource = null;
            ImageContainer.Clear();
        }

        private void txtmsno_Leave(object sender, EventArgs e)
        {
            clearfunction();
            memberverify();
        }

        private void txtnic_Leave(object sender, EventArgs e)
        {
            clearfunction();
            memberverify();
        }

        #region Validations
        private void txtname_Validating(object sender, CancelEventArgs e)
        {
            btnMemberSave.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtname, "", new Regex("^[a-zA-Z0-9_ ]{3,50}$"));
        }

        private void txtprofession_Validating(object sender, CancelEventArgs e)
        {
            btnMemberSave.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtprofession, "", new Regex("^[a-zA-Z_ ]{1,50}$"));
        }

        private void txtpassport_Validating(object sender, CancelEventArgs e)
        {
            btnMemberSave.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtpassport, "", new Regex("^([a-zA-Z0-9]{3,10})|([N/A])|([NA])$"));
        }

        private void txtpano_Validating(object sender, CancelEventArgs e)
        {
            btnMemberSave.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtpano, "", new Regex("^([0-9]{1,50})|([N/A])|([NA])$"));

        }

        private void txtArmSvc_Validating(object sender, CancelEventArgs e)
        {
            btnMemberSave.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtArmSvc, "", new Regex("^([a-zA-Z0-9_ ]{3,50})|([N/A])|([NA])$"));

        }

        private void txtrank_Validating(object sender, CancelEventArgs e)
        {
            btnMemberSave.Enabled = clsPluginHelper.RadformatValidatorDropDownList(Warning, Correct, Wrong, txtrank, "--Select--", new Regex("^([a-zA-Z0-9_ ]{1,50})|([N/A])|([NA])$"));

        }

        private void txteducation_Validating(object sender, CancelEventArgs e)
        {
            btnMemberSave.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txteducation, "", new Regex("^([a-zA-Z0-9_ ]{1,50})|([N/A])|([NA])$"));

        }

        private void txtnationality_Validating(object sender, CancelEventArgs e)
        {
            btnMemberSave.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtnationality, "", new Regex("^[a-zA-Z_ ]{1,200}$"));

        }

        private void txtsector_Validating(object sender, CancelEventArgs e)
        {
            btnMemberSave.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtsector, "", new Regex("^([a-zA-Z0-9]{1,30})|([N/A])|([NA])$"));

        }

        private void txtstreetno_Validating(object sender, CancelEventArgs e)
        {
            btnMemberSave.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtstreetno, "", new Regex("^([a-zA-Z0-9_ ,]{3,20})|([N/A])|([NA])$"));

        }

        private void txtsize_Validating(object sender, CancelEventArgs e)
        {
            btnMemberSave.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtsize, "", new Regex("^([0-9]{3,20})|([N/A])|([NA])$"));

        }

        private void txtplaceofB_Validating(object sender, CancelEventArgs e)
        {
            btnMemberSave.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtplaceofB, "", new Regex("^([a-zA-Z0-9_ ]{1,50})|([N/A])|([NA])$"));

        }

        private void txtfather_Validating(object sender, CancelEventArgs e)
        {

            btnMemberSave.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtfather, "", new Regex("^[a-zA-Z_ ]{2,30}$"));

        }

        private void txtfatherprofession_Validating(object sender, CancelEventArgs e)
        {
            btnMemberSave.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtfatherprofession, "", new Regex("^([a-zA-Z_ ]{2,30})|([N/A])|([NA])$"));

        }

        private void txthwname_Validating(object sender, CancelEventArgs e)
        {
            btnMemberSave.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txthwname, "", new Regex("^([a-zA-Z]{1,30})|([N/A])|([NA])$"));

        }

        private void txthwprofession_Validating(object sender, CancelEventArgs e)
        {
            btnMemberSave.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txthwprofession, "", new Regex("^([a-zA-Z_ ]{3,30})|([N/A])|([NA])$"));

        }



        private void txttelnooffice_Validating(object sender, CancelEventArgs e)
        {
            btnMemberSave.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txttelnooffice, "", new Regex("^([0-9_+-]{3,30})|([N/A])|([NA])$"));

        }

        private void txttelnores_Validating(object sender, CancelEventArgs e)
        {
            btnMemberSave.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txttelnores, "", new Regex("^([0-9_+-]{3,30})|([N/A])|([NA])$"));

        }

        private void txtmobile_Validating(object sender, CancelEventArgs e)
        {
            btnMemberSave.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtmobile, "03XXXXXXXXX", new Regex("^[0-9]{11}$"));

        }

        private void txtemail_Validating(object sender, CancelEventArgs e)
        {
            btnMemberSave.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtemail, "", new Regex(@"^(([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+))|([N/A])|([NA])$"));
        }

        private void txtdomicile_Validating(object sender, CancelEventArgs e)
        {
            btnMemberSave.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtdomicile, "", new Regex("^([a-zA-Z_ ]{3,80})|([N/A])|([NA])$"));

        }

        private void txtmbnoverify_Validating(object sender, CancelEventArgs e)
        {
            btnNextofKin.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtmbnoverify, "", new Regex("^([a-zA-Z0-9_-]{3,40})|([N/A])|([NA])$"));

        }

        private void txtnicverify_Validating(object sender, CancelEventArgs e)
        {
            btnNextofKin.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtnicverify, "", new Regex("^[0-9_ -]{15}$"));

        }

        private void txtnokname_Validating(object sender, CancelEventArgs e)
        {
            btnNextofKin.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtnokname, "", new Regex("^[a-zA-Z_ ]{3,40}$"));

        }

        private void txtnokrelation_Validating(object sender, CancelEventArgs e)
        {
            btnNextofKin.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtnokrelation, "", new Regex("^[a-zA-Z_ ]{3,40}$"));

        }

        private void txtnoknic_Validating(object sender, CancelEventArgs e)
        {
            btnNextofKin.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtnoknic, "", new Regex("^([0-9]{5}-[0-9]{7}-[0-9]{1})|([0-9]{6}[-][0-9]{6}[-][0-9]{1})$"));

        }

        private void txtnokpassportno_Validating(object sender, CancelEventArgs e)
        {
            btnNextofKin.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtnokpassportno, "", new Regex("^([a-zA-Z0-9]{3,40})|([N/A])|([NA])$"));

        }

        private void txtnokaddress_Validating(object sender, CancelEventArgs e)
        {
            // btnNextofKin.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtnokaddress, "", new Regex("^([a-zA-Z0-9_ ,]{3,80})|([N/A])|([NA])$"));

        }

        private void txtnokofficetel_Validating(object sender, CancelEventArgs e)
        {
            btnNextofKin.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtnokofficetel, "", new Regex("^([0-9_+-]{7,20})|([N/A])|([NA])$"));

        }

        private void txtnoktelRes_Validating(object sender, CancelEventArgs e)
        {
            btnNextofKin.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtnoktelRes, "", new Regex("^([0-9_+-]{7,20})|([N/A])|([NA])$"));

        }

        private void txtnokMobile_Validating(object sender, CancelEventArgs e)
        {
            btnNextofKin.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtnokMobile, "", new Regex("^([0-9_+-]{11,20})|([N/A])|([NA])$"));

        }

        private void txtnokemail_Validating(object sender, CancelEventArgs e)
        {
            btnNextofKin.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtnokemail, "", new Regex(@"^(([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+))|([N/A])|([NA])$"));

        }

        private void txtnokfaxno_Validating(object sender, CancelEventArgs e)
        {
            btnNextofKin.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtnokfaxno, "", new Regex("^([0-9]{5,80})|([N/A])$"));

        }

        private void txtfamilyMSNO_Validating(object sender, CancelEventArgs e)
        {
            bttnFamilyDataSave.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtfamilyMSNO, "", new Regex("^[A-Za-z0-9_-]{3,80}$"));

        }

        private void txtfamilyNIC_Validating(object sender, CancelEventArgs e)
        {
            bttnFamilyDataSave.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtfamilyNIC, "", new Regex("^([0-9_ -]{15})|([N/A])|([NA])$"));

        }
        #endregion

        #region Image Saving to DAtabase
        List<clsMemberImage> ImageContainer = new List<clsMemberImage>();

        #region Browse Single image
        private void btnBrowseforSingleimage_Click(object sender, EventArgs e)
        {
            //if (txtimageDescription.Text != "")
            //{

            //ImageName Adding
            try
            {
                clsMemberImage obj = new clsMemberImage();
                obj.ImageName = comboBox1.SelectedItem.ToString();
                obj.Description = txtimageDescription.Text;

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter =
                    @"Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;.JPEG;*.GIF;*.PNG;*.TIFF| All files (.)|*.*";
                openFileDialog1.Title = "Select Photos";

                DialogResult dr = openFileDialog1.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {

                    string[] files = openFileDialog1.FileNames;
                    foreach (var pngFile in files)
                    {
                        try
                        {
                            obj.MemberImage = Image.FromFile(pngFile);
                        }
                        catch
                        {
                            Console.WriteLine("This is not an image file");
                        }
                    }
                }
                ImageContainer.Add(obj);
                ImageSource.TableElement.RowHeight = 100;
                ImageSource.Columns["MemberImage"].ImageLayout = ImageLayout.Stretch;
                ImageSource.DataSource = ImageContainer.DefaultIfEmpty();
                //}
                //else
                //{
                //    MessageBox.Show("Please Enter the Image Description.");
                //}

                comboBox1.Text = "";
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnBrowseforSingleimage_Click.", ex, "frmMembership");
                frmobj.ShowDialog();
            }


        }
        #endregion
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MemberShipChecker("imagecounter", txtmbno.Text))
                {
                    if (memberID != "0")
                    {
                        foreach (clsMemberImage row in ImageContainer)
                        {
                            MemoryStream ms = new MemoryStream();
                            row.MemberImage.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                            Byte[] Image = ms.ToArray();
                            SqlParameter[] parameters =
                            {
                                new SqlParameter("@Task", "Insert"),
                                new SqlParameter("@MemberID", memberID),
                                new SqlParameter("@ImageFile", Image),
                                new SqlParameter("@ImageName", row.ImageName),
                                new SqlParameter("@Description", row.Description),
                                new SqlParameter("@user_ID", clsUser.ID),
                            };
                            int result = cls_dl_Membership.Membership_Image_NonQuery(parameters);
                            if (result > 0)
                            {
                                lblstatusofimage.Text = "Sucessful";
                                tabControl1.SelectedTab = pinfo;
                            }
                            else
                            {
                                lblstatusofimage.Text = "Unsucessful";
                            }
                        }
                        ImageContainer.Clear();
                        ImageSource.DataSource = ImageContainer.DefaultIfEmpty();

                    }
                }
                else
                {
                    MemberVerification();
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnSave_Click.", ex, "frmMembership");
                frmobj.ShowDialog();
            }
            //txtmemberimagename.Text = "";
            txtimageDescription.Text = "";
        }

        #endregion



        #region Validation
        private void txtnic_Validating(object sender, CancelEventArgs e)
        {
            bool abc = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtnic, "", new Regex("^[0-9_ -]{15}$"));
        }

        private void txtnicnicop_Validating(object sender, CancelEventArgs e)
        {
            if(cmbgender.SelectedItem.ToString() != "Corporate")
            {
                btnMemberSave.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong,
                txtnicnicop, "", new Regex("^([0-9]{5}-[0-9]{7}-[0-9]{1})|([0-9]{6}[-][0-9]{6}[-][0-9]{1})$"));
            }

        }

        private void txtmsno_Validating(object sender, CancelEventArgs e)
        {
            bool abcxyz = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtnicnicop, "", new Regex("^[A-Za-z0-9_-]{3,80}$"));

        }

        private void txtmemberimagename_Validating(object sender, CancelEventArgs e)
        {
            //btnBrowseforSingleimage.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtmemberimagename, "", new Regex("^[A-Za-z0-9_ ]{3,80}$"));

        }

        private void txtimageDescription_Validating(object sender, CancelEventArgs e)
        {
            btnBrowseforSingleimage.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtimageDescription, "", new Regex("^[A-Za-z0-9_ ]{3,80}$"));
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txthwprofession_TextChanged(object sender, EventArgs e)
        {

        }

        private void radGridView1_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            ////if (txtimageDescription.Text != "")
            ////{
            //cmbimagetype.SelectedIndex = 0;
            ////ImageName Adding
            //string var = cmbimagetype.Text;
            //clsFileImages objf = new clsFileImages();
            //objf.ImageName = txtimagename.Text;
            //objf.ImageType = var;

            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.Filter =
            //    @"Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files (.)|*.*";
            //openFileDialog1.Title = "Select Photos";

            //DialogResult dr = openFileDialog1.ShowDialog();
            //if (dr == System.Windows.Forms.DialogResult.OK)
            //{

            //    string[] files = openFileDialog1.FileNames;
            //    foreach (var pngFile in files)
            //    {
            //        try
            //        { 
            //            objf.MemberImage = Image.FromFile(pngFile);
            //        }
            //        catch
            //        {
            //            Console.WriteLine("This is not an image file");
            //        }
            //    }
            //}
            //ImageContainer.Add(objf);
            //ImageSource.TableElement.RowHeight = 100;
            //ImageSource.Columns["MemberImage"].ImageLayout = ImageLayout.Stretch;
            //ImageSource.DataSource = ImageContainer.DefaultIfEmpty();
            ////}
            ////else
            ////{
            ////    MessageBox.Show("Please Enter the Image Description.");
            ////}

            //comboBox1.Text = "";
            //txtimageDescription.Text = "";
        }


        private bool MemberShipChecker(string Task, string MembershipNo)
        {
            DataSet personalds = new DataSet();
            try
            {
                SqlParameter[] personal =
                   {
                    new SqlParameter("@Task",Task),
                    new SqlParameter("@MembershipNo",MembershipNo),
                };
                personalds = cls_dl_Membership.Membership_PersonalInfo_Retrive(personal);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on MemberShipChecker.", ex, "frmMembership");
                frmobj.ShowDialog();
            }

            if (personalds.Tables[0].Rows.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void MemberVerification()
        {
            try
            {
                if (txtmbno.Text != "")
                {
                    #region Member Verify in AllMembership Exist
                    SqlParameter[] VerifyMembership =
                    {
                        new SqlParameter("@Task", "VerifyMembership"),
                        new SqlParameter("@MembershipNo", txtmbno.Text),
                    };
                    DataSet datasetVerifyMembership = cls_dl_Membership.Membership_PersonalInfo_Retrive(VerifyMembership);

                    if (datasetVerifyMembership.Tables[0].Rows.Count > 0)
                    {
                        SqlParameter[] personal =
                        {
                            new SqlParameter("@Task", "memberCounter"),
                            new SqlParameter("@MembershipNo", txtmbno.Text),
                        };
                        DataSet personalds = cls_dl_Membership.Membership_PersonalInfo_Retrive(personal);
                        if (personalds.Tables[0].Rows.Count == 0)
                        {
                            tabControl1.Visible = true;
                            tabControl1.SelectedTab = pinfo;
                        }
                        else
                        {
                            #region Next of Kin

                            tabControl1.Visible = true;
                            SqlParameter[] Next =
                            {
                                new SqlParameter("@Task", "nextofkinCounter"),
                                new SqlParameter("@MembershipNo", txtmbno.Text),
                            };
                            DataSet nextofkinds = cls_dl_Membership.Membership_PersonalInfo_Retrive(Next);
                            if (nextofkinds.Tables[0].Rows.Count == 0)
                            {
                                tabControl1.SelectedTab = nextofkininfo;
                            }
                            else
                            {
                                #region Family Member

                                SqlParameter[] family =
                                {
                                    new SqlParameter("@Task", "familyCounter"),
                                    new SqlParameter("@MembershipNo", clsPluginHelper.DbNullIfNullOrEmpty(txtmbno.Text)),
                                };
                                DataSet familyds = cls_dl_Membership.Membership_PersonalInfo_Retrive(family);
                                if (familyds.Tables[0].Rows.Count == 0)
                                {
                                    tabControl1.SelectedTab = familymember;
                                }
                                else
                                {
                                    var datafound = SQLHelper.ExecuteScalar(SQLHelper.createConnection(), CommandType.Text, "Select Count(*) as DataFound from dbo.tbl_Owner o where o.MemberID =  (Select ID from dbo.tbl_Membership m where m.MembershipNo like '" + txtmbno.Text + "')");
                                    int a = (int)datafound;
                                    if (a == 0)
                                    {
                                        tabControl1.SelectedTab = finalstep;
                                    }
                                    else
                                    {
                                        #region Images

                                        SqlParameter[] Image =
                                        {
                                        new SqlParameter("@Task", "imagecounter"),
                                        new SqlParameter("@MembershipNo", txtmbno.Text),
                                    };
                                        DataSet imageds = cls_dl_Membership.Membership_PersonalInfo_Retrive(Image);
                                        if (imageds.Tables[0].Rows.Count == 0)
                                        {
                                            tabControl1.SelectedTab = tabimages;
                                        }
                                        else
                                        {
                                            tabControl1.Visible = false;
                                            //Next Final Step ----
                                        }
                                    }

                                    #endregion
                                }

                                #endregion
                            }

                            #endregion
                        }
                    }
                    else
                    {
                        tabControl1.Visible = false;
                    }
                    #endregion
                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on MemberVerification.", ex, "frmMembership");
                frmobj.ShowDialog();
            }
        }

        private void txtmbno_Leave(object sender, EventArgs e)
        {
            MemberVerification();
        }

        private void btnSaveImg_Click(object sender, EventArgs e)
        {

        }

        #region File No On Leave Checking
        private void txtfileno_Leave(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] parameters =
                           {
                new SqlParameter("@Task","FileNoVerification"),
                new SqlParameter("@FileNo",txtfileno.Text),
            };
                DataSet ds = cls_dl_FileMap.FileMap_Reader(parameters);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtFileNoFinal.Text = txtfileno.Text;
                    tabControl1.Visible = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtfileno, "",
                        new Regex(
                                  "^([A-Z]{3}/[A-Z]{1}/[A-Z]{3}/[0-9]{4})" +//OLO/B/RES/1234
                                  "|([A-Z]{1}/[A-Z]{3}/[0-9]{4})" + //B/RES/1234
                                  "|([A-Z]{1}/[A-Z]{3}/[A-Z]{3}/[0-9]{4})$"));//B/RES/APS/1234
                }
                else
                {
                    MessageBox.Show("File No is not in List Please Check the File No.");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on txtfileno_Leave.", ex, "frmMembership");
                frmobj.ShowDialog();
            }

        }
        #endregion

        #region Present, Perment Address
        //present address
        private void txtpresentaddress_Validating(object sender, CancelEventArgs e)
        {
            //btnMemberSave.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtpresentaddress, "", new Regex(@"^[A-Za-z0-9_ ,/#:()]{5,220}$"));
        }
        //permanent Address
        private void txtpermentaddress_Validating(object sender, CancelEventArgs e)
        {
            //btnMemberSave.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtpermentaddress, "", new Regex("^[a-zA-Z0-9_ ,]{1,220}$"));

        }
        #endregion

        #region Add to Family= List CNIC, Relation, Name Check
        private void btnAdToList_Click(object sender, EventArgs e)
        {
            if (txt_name.Text != "" & txt_cnic.Text != "" & txt_relation.Text != "")
            {
                DataAddToList();
                txt_name.Focus();
            }
            else
            {
                MessageBox.Show("Fill All the Fields");
            }

        }
        List<clsFamilyMember_Membership> list = new List<clsFamilyMember_Membership>();
        private void DataAddToList()
        {
            try
            {
                clsFamilyMember_Membership obj1 = new clsFamilyMember_Membership();
                obj1.Name = txt_name.Text;
                obj1.DOB = dtp_DOB.Text;
                obj1.NICNO = txt_cnic.Text;
                obj1.Relation = txt_relation.Text;
                list.Add(obj1);
                FamilyMemberDGV.DataSource = list.DefaultIfEmpty();
                // Clear All the Texboxes
                txt_name.Text = "";
                txt_cnic.Text = "";
                dtp_DOB.Text = "";
                txt_relation.Text = "";
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on DataAddToList.", ex, "frmMembership");
                frmobj.ShowDialog();
            }

        }
        #endregion

        #region CNIC, Name, Relation, MembershipNo,DOB, DateofMarrage, FaxNo Validation
        private void txt_cnic_Validating(object sender, CancelEventArgs e)
        {
            //btnAdToList.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong,
            //     txt_cnic, "", new Regex("^([0-9]{5}-[0-9]{7}-[0-9]{1})|([0-9]{6}[-][0-9]{6}[-][0-9]{1})|(N/A)$"));
        }

        private void txt_name_Validating(object sender, CancelEventArgs e)
        {
            btnAdToList.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txt_name, "", new Regex("^[a-zA-Z_ ]{3,50}$"));
        }

        private void txt_relation_Validating(object sender, CancelEventArgs e)
        {
            btnAdToList.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txt_relation, "", new Regex("^[a-zA-Z_ ]{3,50}$"));
        }

        private void txtmbno_Validating(object sender, CancelEventArgs e)
        {
            btnSave.Visible = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtmbno, "",
                new Regex("^[A-Z]{3}-[0-9]{4,7}$"));
        }

        private void dtp_DOB_Validating(object sender, CancelEventArgs e)
        {
            btnAdToList.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, dtp_DOB, "", new Regex(@"^((0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d)|([N/A])|([NA])$"));
        }

        private void txtDateofMarrige_Validating(object sender, CancelEventArgs e)
        {
            //
            btnMemberSave.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtDateofMarrige, "", new Regex(@"^((0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d)|([N/A])|([NA])$"));

        }

        private void txtFaxNo_Validating(object sender, CancelEventArgs e)
        {
            //Validation REmaining
        }
        #endregion



        public void LoadOwnerInformation(string FileKey)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task", "TransferSetting"),
                    new SqlParameter("@FileMapID", FileKey),
                };
                DataSet TransferSetting = cls_dl_Owner.Owner_Reader(parameters);
                OwnerGridInformation.DataSource = TransferSetting.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LoadOwnerInformation.", ex, "frmTransferSetting");
                frmobj.ShowDialog();
            }
        }


        private void btnOwnerFind_Click(object sender, EventArgs e)
        {
            if (txtFileNoFinal.Text != string.Empty && txtMembership.Text != string.Empty)
            {
                try
                {
                    if (MessageBox.Show("Please Confrim the Membership and FileNo.", "Attention : " + Models.clsUser.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SqlParameter[] param = {
                            new SqlParameter("@Task","DataSearchinOwner"),
                            new SqlParameter("@FileNo", txtFileNoFinal.Text),
                            new SqlParameter("@MSNo",txtMembership.Text)
                        };
                        var datafound = SQLHelper.ExecuteScalar(SQLHelper.createConnection(),
                                        CommandType.StoredProcedure, "App.usp_tbl_Owner", param);
                        int a = (int)datafound;
                        if (a > 0)
                        {
                            SqlParameter[] paramFileID = { new SqlParameter("@Task","FileSearchOwner"),new SqlParameter("@FileNo", txtFileNoFinal.Text) };
                            var FileMapID = SQLHelper.ExecuteScalar(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_Owner", paramFileID);
                            string filemapidconvert = FileMapID.ToString();
                            LoadOwnerInformation(filemapidconvert);
                        }
                        else
                        {
                            if (txtfileno.Text == txtFileNoFinal.Text && txtMembership.Text != string.Empty)
                            {
                                SqlParameter[] param_FileID = { new SqlParameter("@Task", "FileSearchOwner"),new SqlParameter("@FileNo", txtFileNoFinal.Text) };
                                var FileMapID = SQLHelper.ExecuteScalar(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_Owner", param_FileID);
                                SqlParameter[] param_MemberID = { new SqlParameter("@Task", "MemberIDSearch"),new SqlParameter("@MembershipNo", txtMembership.Text) };
                                var MembershipID = SQLHelper.ExecuteScalar(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_Owner", param_MemberID);
                                SqlParameter[] prm =
                               {
                                     new SqlParameter("@Task","Insert"),
                                     new SqlParameter("@FileMapID",FileMapID),
                                     new SqlParameter("@MemberID",MembershipID),
                                     new SqlParameter("@Status","Current"),
                                     new SqlParameter("@TypePurchaseID",1),
                                     new SqlParameter("@userID",Models.clsUser.ID),
                                     new SqlParameter("@RateofSale","0"),
                                     new SqlParameter("@DateofPurchase",dateOfPurchase.Value),
                                     new SqlParameter("@DateofSell",dateOfSale.Value),
                                     new SqlParameter("@EntryStatus","New")
                               };
                                int rslt = cls_dl_Owner.Owner_NonQuery(prm);
                                string filemapidconvert = FileMapID.ToString();
                                LoadOwnerInformation(filemapidconvert);
                            }
                            else
                            {
                                MessageBox.Show("FileNo and MembershipNo is must be Filled.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("FileNo and MembershipNo is must be Filled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtFileNoFinal_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFileNoFinal.Text.Trim()) && !string.IsNullOrEmpty(txtMembership.Text.Trim()))
                btnOwnerFind_Click(null, null);
        }



        public int OwnerMemberID { get; set; }
        public int OwnerID { get; set; }

        private void btnFind_Click(object sender, EventArgs e)
        {

        }

        private void btnOwnerSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] prm =
                  {
                  new SqlParameter("@Task","Update_OwnerBinding"),
                  new SqlParameter("@Status", txtOwnerStatus.Text),
                  new SqlParameter("@RateofSale",clsPluginHelper.DbNullIfNullOrEmpty("")),
                  new SqlParameter("@DateofPurchase", dateOfPurchase.Value),
                  new SqlParameter("@DateofSell",dateOfSale.Value),
                  new SqlParameter("@OwnerID",clsPluginHelper.DbNullIfNullOrEmpty(OwnerID.ToString())),
                  new SqlParameter("@EntryStatus","Complete")
                };
                int rslt = 0;
                rslt = cls_dl_Owner.Owner_NonQuery(prm);
                txtFileNoFinal_Leave(null, null);
            }
            catch (Exception w)
            {

            }
        }

        private void OwnerGridInformation_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex > -1)
                {
                    // int rowindex = OwnerGridInformation.CurrentRow.ViewInfo.CurrentIndex;
                    txtOwnerFileno.Text = e.Row.Cells["FileNo"].Value.ToString();
                    txtOwnerMembership.Text = e.Row.Cells["MembershipNo"].Value.ToString();
                    OwnerMemberID = int.Parse(e.Row.Cells["ID"].Value.ToString());
                    OwnerID = int.Parse(e.Row.Cells["OwnerID"].Value.ToString());
                    dateOfPurchase.Text = e.Row.Cells["DateofPurchase"].Value.ToString();
                    dateOfSale.Text = e.Row.Cells["DateofSell"].Value.ToString();
                    txtOwnerStatus.Text = e.Row.Cells["Ownerstatus"].Value.ToString();
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void txtMembership_Validating(object sender, CancelEventArgs e)
        {
            btnOwnerFind.Visible = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong, txtmbno, "",
                new Regex("^[A-Z]{3}-[0-9]{4,7}$"));
        }
    }
}
