using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.clsMemberShip;
using PeshawarDHASW.Data_Layer.clsTFR;
using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Application_Layer.Membership.Modify
{
    public partial class frmMembership_All_Info_Modify : Telerik.WinControls.UI.RadForm
    {
        public int NDCNo { get; set; }
        public int MemberID { get; set; }
        public int nextofkinID { get; set; }
        public int IDFamilyID { get; set; }
        public string FileNo { get; set; }
        private int AlreadyExist { get; set; } = 0;
        private int MSNewID_OutPut { get; set; }
        public frmMembership_All_Info_Modify()
        {
            InitializeComponent();
        }
        public frmMembership_All_Info_Modify(int get_NDCNo, int get_MemberID,string get_Fileno)
        {
            NDCNo = get_NDCNo;
            MemberID = get_MemberID;
            FileNo = get_Fileno;
            InitializeComponent();
        }
        public frmMembership_All_Info_Modify(int get_NDCNo, int get_MemberID, string get_Fileno,int get_alreadyExist)
        {
            NDCNo = get_NDCNo;
            MemberID = get_MemberID;
            FileNo = get_Fileno;
            AlreadyExist = get_alreadyExist;
            InitializeComponent();
        }

        private void frmMembership_All_Info_Modify_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            LoadPersonal_Information();
            LoadNextOf_Kin();
            LoadFamilyMemberData();
        }
        private void LoadPersonal_Information()
        {
            #region Load Personal Information
            try
            {
                if (FileNo != "" | FileNo != null)
                {
                    txtFileNo.Enabled = false;
                }
                SqlParameter[] parameter = new[]
                {
                    new SqlParameter("@Task","Select"),
                    new SqlParameter("@ID", MemberID)
                    };
                DataSet ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameter);
                DataTable dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    if (AlreadyExist > 0)
                    {
                        txtmsno.Text = "";
                        txtmsno.BackColor = Color.YellowGreen;
                        txtmsno.Width = 230;
                        txtmsno.Height = 45;
                    }
                    else
                    {
                        txtmsno.Text = row["MembershipNo"].ToString();
                    }
                    object DatOfBirth = row["DoB"].ToString() == null | row["DoB"].ToString() == "" ? clsPluginHelper.DbNullIfNullOrEmpty("01/01/1700") : row["DoB"].ToString();
                    object DatOfMarriage = row["DateofMarriage"].ToString() == null | row["DateofMarriage"].ToString() == "" ? clsPluginHelper.DbNullIfNullOrEmpty("01/01/1700") : row["DateofMarriage"].ToString();

                    txtFileNo.Text = FileNo;
                    txtname.Text = row["Name"].ToString();
                    cmbgender.Text = row["Gender"].ToString();
                    txtfather.Text = row["Father"].ToString();
                    txtnicnicop.Text = @row["NICNICOP"].ToString();
                    txtpassport.Text = row["PassportNo"].ToString();
                    txtreligion.Text = row["Religion"].ToString();
                    txtnationality.Text = row["Nationality"].ToString();
                    txtdob.Value = DateTime.ParseExact(DatOfBirth.ToString(), "dd/MM/yyyy", null);
                    txtplaceofB.Text = row["PlaceofDoB"].ToString();
                    txtpermentaddress.Text = row["PrementAddress"].ToString();
                    txtfaxno.Text = row["FaxNo"].ToString();
                    txtprofession.Text = row["Profession"].ToString();
                    txtfatherprofession.Text = row["FPorfession"].ToString();
                    cmbMarrigeStatus.SelectedIndex = cmbMarrigeStatus.FindString(row["Marital Status"].ToString());//row["Marital Status"].ToString() == "Yes"?0:1;
                    txtDateofMarrige.Value = DateTime.ParseExact(DatOfMarriage.ToString(), "dd/MM/yyyy", null);
                    txtArmSvc.Text = row["Arm/Svc"].ToString();
                    txteducation.Text = @row["Education/Qualification"].ToString();
                    txthwname.Text = @row["Husband/Wife Name"].ToString();
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
                    lblPlotType.Text = row["TypePlot"].ToString();
                    //txtstatus.Text = row["Status"].ToString();

                }
            
                

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LoadPersonal_Information.", ex, "frmMembership_All_Info_Modify");
                frmobj.ShowDialog();

            }
            #endregion
        }
        private void LoadNextOf_Kin()
        {
            #region Load Next Of Kin
            try
            {

                SqlParameter[] parameter = new[] { new SqlParameter("@MID", MemberID) };
                DataSet ds = cl_dl_SerachMembership.MembershipNextofkinDataLoadforView(parameter);

                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        nextofkinID = int.Parse(row["ID"].ToString());
                        txtnokname.Text = row["NameofKin"].ToString();
                        txtnokrelation.Text = row["Relation"].ToString();
                        txtnoknic.Text = row["NIC"].ToString();
                        txtnokpassportno.Text = row["PassportNo"].ToString();
                        txtnokaddress.Text = row["Address"].ToString();
                        txtnokofficetel.Text = row["teloffice"].ToString();
                        txtnoktelRes.Text = row["telnores"].ToString();
                        txtnokMobile.Text = row["MobileNo"].ToString();
                        txtnokemail.Text = row["Email"].ToString();
                        txtnokfaxno.Text = row["FaxNo"].ToString();
                    }
                    //lblRecordstatus.Text = " Found Successfull.";
                }
                else
                {
                    //lblRecordstatus.Text = " Not Found.";
                }

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LoadNextOf_Kin.", ex, "frmMembership_All_Info_Modify");
                frmobj.ShowDialog();
            }
            #endregion
        }
        private void LoadFamilyMemberData()
        {
            #region Load Family Member Data
            try
            {

                SqlParameter[] parameter = new[] { new SqlParameter("@Member_ID", MemberID) };
                DataSet ds = cl_dl_SerachMembership.MembershipFamilyDataLoadforView(parameter);

                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {

                    // lblRecordstatus.Text = " Found Successfull.";
                    foreach (DataRow Row in dt.Rows)
                    {
                        string[] row = new string[] { Row["ID"].ToString(), Row["Name"].ToString(), Row["DOB"].ToString(), Row["NICNO"].ToString(), Row["Relation"].ToString() };
                        FamilyMemberDGV.Rows.Add(row);
                    }
                }
                else
                {
                    // lblRecordstatus.Text = " Not Found.";
                }

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LoadFamilyMemberData.", ex, "frmMembership_All_Info_Modify");
                frmobj.ShowDialog();
            }
            #endregion
        }

        private void FamilyMemberDGV_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = FamilyMemberDGV.CurrentCell.RowIndex;
                // int columnindex = FamilyMemberDGV.CurrentCell.ColumnIndex;

                IDFamilyID = int.Parse(FamilyMemberDGV.Rows[rowindex].Cells[0].Value.ToString());
                txtFamilyname.Text = FamilyMemberDGV.Rows[rowindex].Cells[1].Value.ToString();
                txtFamilyDateOfBirth.Text = FamilyMemberDGV.Rows[rowindex].Cells[2].Value.ToString();
                txtNIC.Text = FamilyMemberDGV.Rows[rowindex].Cells[3].Value.ToString();
                txtrelation.Text = FamilyMemberDGV.Rows[rowindex].Cells[4].Value.ToString();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on FamilyMemberDGV_CellClick.", ex, "frmMembership_All_Info_Modify");
                frmobj.ShowDialog();
            }
           
        }

        private void btnUpdateFamilyData_Click(object sender, EventArgs e)
        {
            #region Update Family Members
            try
            {
                // @ID @Member_ID @Name @DOB @NICNO @Relation @user_ID 
                if (
                   MessageBox.Show(
                       "Are you sure,You want to Modify this record.",
                       "Warning",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Warning)
                       == DialogResult.Yes)
                {
                    SqlParameter[] parameters =
                           {
                            new SqlParameter("@Task","Update"),
                            new SqlParameter("@ID",IDFamilyID),
                            new SqlParameter("@Member_ID", MemberID),
                            new SqlParameter("@Name", txtFamilyname.Text),
                            new SqlParameter("@DOB", txtFamilyDateOfBirth.Text),
                            new SqlParameter("@NICNO", txtNIC.Text),
                            new SqlParameter("@Relation", txtrelation.Text),
                            new SqlParameter("@user_ID", clsUser.ID)
                        };
                    int result = cls_dl_Membership.Membership_FamilyMember_NonQuery(parameters);
                    if (result > 0)
                    {
                        //FamilyMemberDGV.DataSource = null;
                        MessageBox.Show("Updated Succesfully.");
                    }
                    else
                    {
                        MessageBox.Show("Contact with Administration.");
                    }
                }
                clear();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnUpdateFamilyData_Click.", ex, "frmMembership_All_Info_Modify");
                frmobj.ShowDialog();
            }
            #endregion
            #region Load Family Member

            FamilyMemberDGV.Rows.Clear();
            LoadFamilyMemberData();
            #endregion
        }
        private void clear()
        {
            IDFamilyID = 0;
            txtFamilyname.Text = "";
            txtFamilyDateOfBirth.Text = "";
            txtNIC.Text = "";
            txtrelation.Text = "";
        }

        private void btnaddnewfamilymember_Click(object sender, EventArgs e)
        {
            try
            {
                if (
                              MessageBox.Show(
                                  "Are you sure save this record.",
                                  "Warning",
                                  MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Warning)
                                  == DialogResult.Yes)
                {

                    SqlParameter[] parameters = new[]
                           {
                            new SqlParameter("@Task","Insert"),
                            new SqlParameter("@Member_ID", MemberID),
                            new SqlParameter("@Name", txtFamilyname.Text),
                            new SqlParameter("@DOB", txtFamilyDateOfBirth.Text),
                            new SqlParameter("@NICNO", txtNIC.Text),
                            new SqlParameter("@Relation", txtrelation.Text),
                            new SqlParameter("@user_ID", clsUser.ID)
                        };
                    cls_dl_Membership.Membership_FamilyMember_NonQuery(parameters);

                }
                clear();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnaddnewfamilymember_Click.", ex, "frmMembership_All_Info_Modify");
                frmobj.ShowDialog();
            }
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtmsno.Text))
            {
                if (AlreadyExist > 0)
                {
                   if(InsertMembershipPersonalInfo() == true)
                    {
                        this.Close();
                        Update_TFRTrackingStatus();
                    }
                    // InsertFamilyMember();
                }
                else
                {
                    ModifyMembershipInfo();
                }
            }
            else
            {
                MessageBox.Show("Please Enter Membership No.");
            }     
        }
        private void Update_TFRTrackingStatus()
        {
            SqlParameter[] prmt =
            {
                new SqlParameter("@Task","Update_TFRHistory_Status"),
                new SqlParameter("@NDCNo",NDCNo),
                new SqlParameter("@Status","Transfer_Complete")
            };
            int rslt = cls_dl_TFRHistory.TFRHistory_NonQuery(prmt);

        }
        private bool InsertMembershipPersonalInfo()
        {
            bool blvr = false;
            try
            {
                
                if(cmbgender.Text != "" && cmbMarrigeStatus.Text != "")
                {
                    SqlParameter param_out_ID = new SqlParameter()
                    {
                        ParameterName = "@OutIDMS",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };
                    SqlParameter[] parameter1 =
                    {
                        new SqlParameter("@Task", "Insert"),
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
                        new SqlParameter("@FilePlotShopVillaApartmentNo", txtFileNo.Text),
                        new SqlParameter("@TypePlot", lblPlotType.Text),
                        new SqlParameter("@StreetLane_No", txtstreetno.Text),
                        new SqlParameter("@Sector", txtsector.Text),
                        new SqlParameter("@Size", txtsize.Text),
                        new SqlParameter("@DoB", txtdob.Text), /////////////////////////////////////////////////////////////////// Date
                        new SqlParameter("@PlaceofDoB", txtplaceofB.Text),
                        new SqlParameter("@Marital_Status", cmbMarrigeStatus.SelectedItem.ToString()),
                        new SqlParameter("@DateofMarriage", txtDateofMarrige.Text),/////////////////////////////////////////////////////////////////// Date
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
                        new SqlParameter("@FaxNo",txtfaxno.Text),
                        new SqlParameter("@Domicile", txtdomicile.Text),
                        new SqlParameter("@user_ID", PeshawarDHASW.Models.clsUser.ID),
                        param_out_ID,
                        new SqlParameter("@CompteleStatus", "Complete"),
                        new SqlParameter("@NDCNo",NDCNo)
                    };
                    SqlCommand result;
                    result = Data_Layer.clsMemberShip.cls_dl_Membership.Membership_PersonalInfo_outparameter(parameter1);
                    if (result.Parameters.Count != 0)
                    {
                        MSNewID_OutPut = int.Parse(result.Parameters["@OutIDMS"].Value.ToString());
                        //Insertion Of NextOfKin
                        if (MSNewID_OutPut != 0)
                        {
                            blvr = true;
                            InsertNextOfKin();
                            InsertFamilyMember();
                            MessageBox.Show("Membership Detail is Successfully Generated.");
                        }
                    }
                }
                else
                {
                  MessageBox.Show("Please Select Both the Gender and Marriage Status Must.");
                }        
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on InsertMembershipPersonalInfo.", ex, "frmMembership_All_Info_Modify");
                frmobj.ShowDialog();
            }
            return blvr;
        }
        private void InsertNextOfKin()
        {
            try
            {
                SqlParameter[] parameters = new[]
                                              {
                                    new SqlParameter("@Task", "Insert"),
                                    new SqlParameter("@MemberID", MSNewID_OutPut),
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
                                    new SqlParameter("@user_ID", PeshawarDHASW.Models.clsUser.ID)
                                };
                int result = 0;
                result = cls_dl_Membership.Membership_NextofKin_NonQuery(parameters);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on InsertNextOfKin.", ex, "frmMembership_All_Info_Modify");
                frmobj.ShowDialog();
            }
           
        }
        private void InsertFamilyMember()
        {
            try
            {
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
                                new SqlParameter("@Member_ID", MSNewID_OutPut),
                                new SqlParameter("@Name", Name),
                                new SqlParameter("@DOB", Date),
                                new SqlParameter("@NICNO", NIC),
                                new SqlParameter("@Relation", Relation),
                                new SqlParameter("@user_ID", clsUser.ID)
                    };
                    int result = cls_dl_Membership.Membership_FamilyMember_NonQuery(parameters);

                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on InsertFamilyMember.", ex, "frmMembership_All_Info_Modify");
                frmobj.ShowDialog();
            }
         
        }
        private void ModifyMembershipInfo()
        {
            try
            {
                SqlParameter[] parameter1 =
                {
                    new SqlParameter("@Task", "Update_Personal_NextOfkin_Info"),
                     //@@@@@@@@@@@@@@@@@@  Personal Info  @@@@@@@@@@@@@@@@@@@@//
                    new SqlParameter("@ID", MemberID),
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
                    new SqlParameter("@DoB", txtdob.Text),
                    new SqlParameter("@PlaceofDoB", txtplaceofB.Text),
                    new SqlParameter("@Marital_Status", cmbMarrigeStatus.Text),
                    new SqlParameter("@DateofMarriage", txtDateofMarrige.Text),
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
                    //@@@@@@@@@@@@@@@@@@  Next Of Kin  @@@@@@@@@@@@@@@@@@@@//
                    new SqlParameter("@NexOfKinID",nextofkinID),
                    new SqlParameter("@NameofKin", txtnokname.Text),
                    new SqlParameter("@RelationNKin", txtnokrelation.Text),
                    new SqlParameter("@NICNICOPNextOfKin", txtnoknic.Text),
                    new SqlParameter("@PassportNoNK", txtnokpassportno.Text),
                    new SqlParameter("@AddressNK", txtnokaddress.Text),
                    new SqlParameter("@TelNoOfficeNextOfKin", txtnokofficetel.Text),
                    new SqlParameter("@TelNoResNextOfKin", txtnoktelRes.Text),
                    new SqlParameter("@MobileNoNextOfKin", txtnokMobile.Text),
                    new SqlParameter("@EmailNextOfKin", txtnokemail.Text),
                    new SqlParameter("@FaxNoNextOfKin", txtnokfaxno.Text),
                    //@@@@@@@@@@@@@@@@@@  NDCNo  @@@@@@@@@@@@@@@@@@@@//
                    new SqlParameter("@NDCNo",NDCNo)


                };
                int result = cls_dl_Membership.Membership_All_NonQuery(parameter1);
                if (result > 0)
                {
                    MessageBox.Show("Successfull.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Check your Connection OR Contact to Administration.");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on ModifyMembershipInfo.", ex, "frmMembership_All_Info_Modify");
                frmobj.ShowDialog();
            }

        }
    }
}
