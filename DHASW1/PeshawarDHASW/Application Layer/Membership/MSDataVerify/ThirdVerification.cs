using PeshawarDHASW.Data_Layer.clsOwnerType;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsApplication;
using PeshawarDHASW.Data_Layer.clsFileMap;
using PeshawarDHASW.Data_Layer.clsMemberShip;
using PeshawarDHASW.Data_Layer.clsPlotSize;
using Telerik.WinControls;
using System.IO;
using PeshawarDHASW.Data_Layer.clsErrorLog;
using PeshawarDHASW.Data_Layer.Owner;

using PeshawarDHASW.Models;
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Application_Layer.Membership.MSDataVerify
{
    public partial class ThirdVerification : Telerik.WinControls.UI.RadForm
    {
        public ThirdVerification()
        {
            InitializeComponent();
        }
        public int passMemberID { get; set; }
        public int TotalImage { get; set; }
        public string FileNo { get; set; }
        public ThirdVerification(int MemberID)
        {
            ///////////////////////////
            passMemberID = MemberID;
            InitializeComponent();
        }

        #region Image Retriving

        private DataSet IMageLoading(int memberID)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task", "Select"),
                    new SqlParameter("@MemberID", memberID),
                };
                ds = cls_dl_Image.Membership_PersonalInfo_Retrive(parameters);
                TotalImage = ds.Tables[0].Rows.Count;

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on IMageLoading.", ex, "ThirdVerification");
                frmobj.ShowDialog();
            }
            return ds;
        }

        private DataSet dsImage { get; set; }
        private Image ImageRetrive(int imageindex)
        {
            // Transfer everything to the Image property of the picture box....
            byte[] imgData = (byte[]) dsImage.Tables[0].Rows[imageindex]["ImageFile"];
            MemoryStream ms = new MemoryStream(imgData);
            ms.Position = 0;
            return Image.FromStream(ms);
        }

        private int imageindex = 0;
        private void btnpreciousimage_Click(object sender, EventArgs e)
        {
            try
            {
                if (imageindex != 0)
                {
                    imageindex = imageindex - 1;
                    pictureBox1.Image = ImageRetrive(imageindex);
                }
                else
                {

                    pictureBox1.Image = ImageRetrive(imageindex);
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnpreciousimage_Click.", ex, "ThirdVerification");
                frmobj.ShowDialog();
            }
            

        }
        private void btnnextimage_Click(object sender, EventArgs e)
        {
            try
            {
                if (imageindex != TotalImage - 1)
                {
                    imageindex = imageindex + 1;
                    pictureBox1.Image = ImageRetrive(imageindex);
                }
                else
                {

                    pictureBox1.Image = ImageRetrive(imageindex);

                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnnextimage_Click.", ex, "ThirdVerification");
                frmobj.ShowDialog();
            }
           
        }
        #endregion

        #region DropDownList Filling
        private void Filddl_ownerCategory()
        {
            try
            {
                SqlParameter[] par =
                                     {
             new SqlParameter("@Task","Select"),
            };
                DataSet ds = new DataSet();
                ds = cls_dl_OwnerType.OwnerType_Reader(par);
                ddl_ownerCategory.DataSource = ds.Tables[0].DefaultView;
                ddl_ownerCategory.ValueMember = "OCID";
                ddl_ownerCategory.DisplayMember = "Category_Name";
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Filddl_ownerCategory.", ex, "ThirdVerification");
                frmobj.ShowDialog();
            }
           

        }
        private void PlotType()
        {
            try
            {
                DataSet ds = cls_dl_Membership_PlotTYpe.PlotType();
                cmbtypeplot.DataSource = ds.Tables[0];
                cmbtypeplot.ValueMember = "PlotID";
                cmbtypeplot.DisplayMember = "Type";

                ddlplotbuisinesstype.DataSource = ds.Tables[0];
                ddlplotbuisinesstype.ValueMember = "PlotID";
                ddlplotbuisinesstype.DisplayMember = "Type";
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on PlotType.", ex, "ThirdVerification");
                frmobj.ShowDialog();
            }
           
        }

        private void fileinformaitonload()
        {
            try
            {
                SqlParameter[] parameters =
                           {
                new SqlParameter("@Task","Select"),
                new SqlParameter("@FileNo",FileNo),
            };
                DataSet ds = cls_dl_FileMap.FileData_Retrive(parameters);
                BlblFileNo.Text = FileNo;
                clsPluginHelper.RadDropDownSelectByText(ddlplotbuisinesstype, ds.Tables[0].Rows[0]["PlotType"].ToString().Trim());
                clsPluginHelper.RadDropDownSelectByText(ddl_ownerCategory, ds.Tables[0].Rows[0]["OwnerType"].ToString());
                clsPluginHelper.RadDropDownSelectByText(dpPlotSize, ds.Tables[0].Rows[0]["Size"].ToString());
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on fileinformaitonload.", ex, "ThirdVerification");
                frmobj.ShowDialog();
            }
           
        }
        private void Fillddl_PlotSize()
        {
            try
            {
                SqlParameter[] par =
                                       {
             new SqlParameter("@Task","Select"),
            };
                DataSet ds = new DataSet();
                ds = cls_dl_PlotSize.PlotSize_Reader(par);
                dpPlotSize.DataSource = ds.Tables[0].DefaultView;
                dpPlotSize.ValueMember = "ID";
                dpPlotSize.DisplayMember = "PlotSize";
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Fillddl_PlotSize.", ex, "ThirdVerification");
                frmobj.ShowDialog();
            }
            

        }
        private void Fill_ddlplotbuisinesstype()
        {
            try
            {
                SqlParameter[] par =
               {
             new SqlParameter("@Task","FillddlPlotBuisinessType"),
               };
                DataSet ds = cls_dl_FileMap.FileMap_Reader(par);
                //ddlplotbuisinesstype.Items.Insert(0, new RadListDataItem("Select"));
                ddlplotbuisinesstype.DataSource = ds.Tables[0].DefaultView;
                ddlplotbuisinesstype.ValueMember = "PBTID";
                ddlplotbuisinesstype.DisplayMember = "TypeName";

                // ddlplotbuisinesstype.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Fill_ddlplotbuisinesstype.", ex, "ThirdVerification");
                frmobj.ShowDialog();
            }
           
        }
        #endregion

        #region Form Load
        private void frmDataVerify_Load(object sender, EventArgs e)
        {
            try
            {
                this.ThemeName = clsUser.ThemeName;
                ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
                //Fillddl_transfertype();
                //  Fill_ddlplotbuisinesstype();
                Filddl_ownerCategory();
                Fillddl_PlotSize();
                PlotType();

                // cmbtypeplot.SelectedIndex = 1;
                // int a = int.Parse( cmbtypeplot.SelectedValue.ToString());

                PersonalINformationLoad(passMemberID);
                NexkofKinInforamtionLoad(passMemberID);
                FamilyMember(passMemberID);
                dsImage = IMageLoading(passMemberID);
                if (dsImage.Tables[0].Rows.Count > 0)
                {
                    pictureBox1.Image = ImageRetrive(imageindex);
                }
                else
                {
                    MessageBox.Show("Their is  No Image Attached with Document");
                    this.Close();
                }
                FileHintLoading();
                fileinformaitonload();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmDataVerify_Load.", ex, "ThirdVerification");
                frmobj.ShowDialog();
            }
          
        }
        #endregion

        #region Load Information


        private void PersonalINformationLoad(int MemberID)
        {
            try
            {
                SqlParameter[] parameter = new[]
                {
                    new SqlParameter("@Task", "Select"),
                    new SqlParameter("@ID", MemberID)
                };
                DataSet ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameter);
                DataTable dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    txtmsno.Text = row["MembershipNo"].ToString();
                    txtFileNo.Text = row["FileNo"].ToString();
                    FileNo = txtFileNo.Text;
                    cmbtypeplot.Text = row["TypePlot"].ToString();
                    txtname.Text = row["Name"].ToString();
                    cmbgender.Text = row["Gender"].ToString();
                    txtfather.Text = row["Father"].ToString();
                    txtnicnicop.Text = row["NICNICOP"].ToString();
                    txtpassport.Text = row["PassportNo"].ToString();
                    txtreligion.Text = row["Religion"].ToString();
                    txtnationality.Text = row["Nationality"].ToString();
                    txtdob.Text = row["DoB"].ToString();
                    txtplaceofB.Text = row["PlaceofDoB"].ToString();
                    txtpermentaddress.Text = row["PrementAddress"].ToString();
                    txtprofession.Text = row["Profession"].ToString();
                    txtfatherprofession.Text = row["FPorfession"].ToString();
                    cmbMarrigeStatus.Text = row["Marital Status"].ToString();
                    txtDateofMarrige.Text = row["DateofMarriage"].ToString();
                    txtArmSvc.Text = row["Arm/Svc"].ToString();
                    txteducation.Text = row["Education/Qualification"].ToString();
                    txthwname.Text = row["Husband/Wife Name"].ToString();
                    txthwprofession.Text = row["H/W Profession"].ToString();
                    txttelnooffice.Text = row["TelNo(Office)"].ToString();
                    txttelnores.Text = row["TelNo(Res)"].ToString();
                    txtpresentaddress.Text = row["PresentAddress"].ToString();
                    txtfaxno.Text = row["FaxNo"].ToString();
                    txtsector.Text = row["Sector"].ToString();
                    txtstreetno.Text = row["Street/Lane No"].ToString();
                    txtsize.Text = row["Size"].ToString();
                    txtpano.Text = row["PersonalNo(SvcPersOnly)"].ToString();
                    txtrank.Text = row["Rank"].ToString();
                    txtmobile.Text = row["MobileNo"].ToString();
                    txtemail.Text = row["Email"].ToString();
                    txtdomicile.Text = row["Domicile"].ToString();
                    txtstatus.Text = row["Status"].ToString();
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on PersonalINformationLoad.", ex, "ThirdVerification");
                frmobj.ShowDialog();
                ///  cls_dl_ErrorLog.ErrorLogSAvetoDB(ex, "Personal frm Data Verify");
            }
            try
            {    
                ///EnteredbyUserInformation
                SqlParameter[] parameterUser = new[]
              {
                    new SqlParameter("@Task", "EnteredbyUserInformation"),
                    new SqlParameter("@ID", MemberID)
                };
                DataSet dsuserinfo = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameterUser);
                //lbluserinfo.Text = dsuserinfo.Tables[0].Rows[0]["Recordinfo"].ToString();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on PersonalINformationLoad.", ex, "ThirdVerification");
                frmobj.ShowDialog();
                // cls_dl_ErrorLog.ErrorLogSAvetoDB(ex, "Personal frm Data Verify");
            }
        }

        public string NextofkinID { get; set; }
        private void NexkofKinInforamtionLoad(int MemberID)
        {
            try
            {

                SqlParameter[] parameter = new[]
                {
                    new SqlParameter("@Task", "Select"),
                    new SqlParameter("@MemberID", MemberID)
                };
                DataSet ds = cls_dl_Membership.Membership_NextofKin_Retrive(parameter);

                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        NextofkinID = row["ID"].ToString();
                        txtnokname.Text = row["NameofKin"].ToString();
                        txtnokrelation.Text = row["Relation"].ToString();
                        txtnoknic.Text = row["NIC/NICOP"].ToString();
                        txtnokpassportno.Text = row["PassportNo"].ToString();
                        txtnokaddress.Text = row["Address"].ToString();
                        txtnokofficetel.Text = row["TelNo(Office)"].ToString();
                        txtnoktelRes.Text = row["TelNo(Res)"].ToString();
                        txtnokMobile.Text = row["MobileNo"].ToString();
                        txtnokemail.Text = row["Email"].ToString();
                        txtnokfaxno.Text = row["FaxNo"].ToString();
                    }

                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on NexkofKinInforamtionLoad.", ex, "ThirdVerification");
                frmobj.ShowDialog();
            }
        }

        private void FamilyMember(int MemberID)
        {
            try
            {
                SqlParameter[] parameter = new[]
                {
                    new SqlParameter("@Task","Select"), 
                    new SqlParameter("@Member_ID", MemberID)
                };
                DataSet ds = cls_dl_Membership.Membership_FamilyMember_Retrive(parameter);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    FamilyMemberDGV.DataSource = ds.Tables[0].DefaultView;
                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on FamilyMember.", ex, "ThirdVerification");
                frmobj.ShowDialog();
            }
        }

        private void FileHintLoading()
        {
            try
            {
                SqlParameter[] parameters =
                           {
                new SqlParameter("@Task","Select"),
                new SqlParameter("@FileNo",FileNo),
            };
                DataSet ds = cls_dl_FileMap.FileHintData_Retrive(parameters);
                gvHindata.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on FileHintLoading.", ex, "ThirdVerification");
                frmobj.ShowDialog();
            }
           
        }
        #endregion

        #region Saving 
        private void PersonalInformaiton()
        {
            try
            {
                SqlParameter[] parameter1 =
                {
                    new SqlParameter("@Task", "Update"),
                    new SqlParameter("@ID",passMemberID), 
                    new SqlParameter("@MembershipNo", txtmsno.Text),
                    new SqlParameter("@Name", txtname.Text),
                    new SqlParameter("@Gender", cmbgender.SelectedItem.ToString()),
                    new SqlParameter("@NICNICOP", txtnicnicop.Text),
                    new SqlParameter("@PassportNo", txtpassport.Text),
                    new SqlParameter("@PersonalNoSvcPersOnly", txtpano.Text),
                    new SqlParameter("@Rank", txtrank.Text),
                    new SqlParameter("@ArmSvc", txtArmSvc.Text),
                    new SqlParameter("@EducationQualification", txteducation.Text),
                    new SqlParameter("@Profession", txtprofession.Text),
                    new SqlParameter("@Religion", txtreligion.Text),
                    new SqlParameter("@Nationality", txtnationality.Text),
                    new SqlParameter("@FilePlotShopVillaApartmentNo",txtFileNo.Text) ,
                    new SqlParameter("@TypePlot",int.Parse( cmbtypeplot.SelectedValue.ToString())),
                    new SqlParameter("@StreetLane_No", txtstreetno.Text),
                    new SqlParameter("@Sector", txtsector.Text),
                    new SqlParameter("@Size", txtsize.Text),
                    new SqlParameter("@DoB", txtdob.Text),
                    new SqlParameter("@PlaceofDoB", txtplaceofB.Text),
                    new SqlParameter("@Marital_Status", cmbMarrigeStatus.SelectedItem.ToString()),
                    new SqlParameter("@DateofMarriage", txtDateofMarrige.Text),
                    new SqlParameter("@Father", txtfather.Text),
                    new SqlParameter("@FaxNo",txtfaxno.Text), 
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
                    new SqlParameter("@Status", txtstatus.Text),
                    new SqlParameter("@user_ID", PeshawarDHASW.Models.clsUser.ID),
                    new SqlParameter("@CompteleStatus", "Complete"),
                    new SqlParameter("@VerifyStatus", "Verified"),
                };
                cls_dl_Membership.MainDB_Membership_PersonalInfo(parameter1);


            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on PersonalInformaiton.", ex, "ThirdVerification");
                frmobj.ShowDialog();
            }
        }
        private string MemberID()
        {
            string Memberid = "";
            try
            {
                SqlParameter[] parameter1 =
                {
                    new SqlParameter("@Task", "Select"),
                    new SqlParameter("@MembershipNo", txtmsno.Text),
                };
                DataSet ds = cls_dl_Membership.MainDB_Membership_PersonalInfo_Retrive(parameter1);
                Memberid = ds.Tables[0].Rows[0]["ID"].ToString();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on MemberID.", ex, "ThirdVerification");
                frmobj.ShowDialog();
            }
            return Memberid;
        }
        private void NexkofKinInformation(int MemberID)
        {
            try
            {
                if (MemberID != 0)
                {
                    SqlParameter[] parameters = new[]
                    {
                            new SqlParameter("@Task", "Update"),
                            new SqlParameter("@ID",NextofkinID), 
                            new SqlParameter("@MemberID", MemberID),
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
                            new SqlParameter("@user_ID", Models.clsUser.ID)
                        };
                    int result = 0;
                    result = cls_dl_Membership.MainDB_Membership_NextofKin_NonQuery(parameters);
                    if (result > 0)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Contact to Administration");
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on NexkofKinInformation.", ex, "ThirdVerification");
                frmobj.ShowDialog();
            }
        }
        private void FamilyMemberInformation(int MemberID)
        {
            try
            {
                int row = FamilyMemberDGV.RowCount;
                for (int i = 0; i < row; i++)
                {
                    string ID = FamilyMemberDGV.Rows[i].Cells[0].Value.ToString();
                    string Name = FamilyMemberDGV.Rows[i].Cells[2].Value.ToString();
                    string Date = FamilyMemberDGV.Rows[i].Cells[3].Value.ToString();
                    string NIC = FamilyMemberDGV.Rows[i].Cells[4].Value.ToString();
                    string Relation = FamilyMemberDGV.Rows[i].Cells[5].Value.ToString();

                    SqlParameter[] parameters = new[]
                    {
                        new SqlParameter("@Task", "Update"),
                        new SqlParameter("@ID",ID), 
                        new SqlParameter("@Member_ID", MemberID),
                        new SqlParameter("@Name", Name),
                        new SqlParameter("@DOB", Date),
                        new SqlParameter("@NICNO", NIC),
                        new SqlParameter("@Relation", Relation),
                        new SqlParameter("@user_ID", Models.clsUser.ID)
                    };
                    try
                    {
                        int result = cls_dl_Membership.MainDB_Membership_FamilyMember_NonQuery(parameters);
                        if (result > 0)
                        {
                            // FamilyMemberDGV.DataSource = null;
                        }
                        else
                        {
                            MessageBox.Show("Contact to Administrator");
                        }
                    }
                    catch (Exception ex)
                    {
                        frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on FamilyMemberInformation.", ex, "ThirdVerification");
                        frmobj.ShowDialog();
                    }
                   
                }

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on FamilyMemberInformation.", ex, "ThirdVerification");
                frmobj.ShowDialog();
            }

        }
        private void FileCreation()
        {
            try
            {
                SqlParameter[] parametersFileNo =
           {
                new SqlParameter("@Task","select"),
                new SqlParameter("@FileNo",txtFileNo.Text),
            };
                DataSet ds = cls_dl_FileMap.Main_FileMap_Reader(parametersFileNo);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    try
                    {
                        SqlParameter[] parameters =
                        {
                            new SqlParameter("@Task", "insert"),
                            new SqlParameter("@FileNo", txtFileNo.Text),
                            new SqlParameter("@TransferStatus", "Current"),
                            new SqlParameter("@userID", Models.clsUser.ID),
                            new SqlParameter("@PlotBusinessTypeID", ddlplotbuisinesstype.SelectedValue.ToString()),
                            new SqlParameter("@TFRTypeID", "1"),
                            new SqlParameter("@OwnerCategoryID", ddl_ownerCategory.SelectedValue.ToString()),
                            new SqlParameter("@PlotSize", dpPlotSize.SelectedItem.ToString())
                        };
                        int result = 0;
                        result = cls_dl_FileMap.Main_FileMap_NonQuery(parameters);
                        if (result > 0)
                        {

                        }
                       
                    }
                    catch (Exception ex)
                    {
                        frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on FileCreation.", ex, "ThirdVerification");
                        frmobj.ShowDialog();
                    }
                  
                }
                else
                {
                    MessageBox.Show("File No is Already present in List");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on FileCreation.", ex, "ThirdVerification");
                frmobj.ShowDialog();
            }
           
        }
        private void OwnerCreation()
        {
            try
            {
                SqlParameter[] fileKeyIDparameter =
            {
                new SqlParameter("@Task","select"),
                new SqlParameter("@FileNo",BtxtFileNo.Text),
            };
                DataSet ds = cls_dl_FileMap.Main_FileMap_Reader(fileKeyIDparameter);
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string FileMapKey = ds.Tables[0].Rows[0]["FileMapKey"].ToString();

                        SqlParameter[] parameters =
                        {
                            new SqlParameter("@Task", "insert"),
                            new SqlParameter("@FileMapID", FileMapKey),
                            new SqlParameter("@MemberID", passMemberID),
                            new SqlParameter("@Status", "Current"),
                            new SqlParameter("@TypePurchaseID", "1"),
                            new SqlParameter("@userID", Models.clsUser.ID),
                        };
                        int result = 0;
                        result = cls_dl_Owner.Main_DML_Owner(parameters);
                        if (result > 0)
                        {

                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    }
                }
                catch (Exception ex)
                {
                    frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on OwnerCreation.", ex, "ThirdVerification");
                    frmobj.ShowDialog();
                }
               
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on OwnerCreation.", ex, "ThirdVerification");
                frmobj.ShowDialog();
            }
            
          
        }

        private bool FileNoandMembershipChecking()
        {
            bool fo = false;
            try
            {
                string str = @"SELECT tm.[ID],tm.[MembershipNo],tfm.[FileNo]  FROM [dbo].[tbl_Membership] tm
                            INNER JOIN	 [dbo].[tbl_Owner] tow ON tm.ID = tow.MemberID	
                            INNER Join [dbo].[tbl_FileMap] tfm ON tow.FileMapID	= tfm.FileMapKey	
                            WHERE tm.MembershipNo	LIKE '" + BtxtMembershipno.Text + "' AND tfm.FileNo	LIKE '" + BtxtFileNo.Text + "'";
                DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.Text, str);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return fo;
                }
                else
                {
                    fo = true;
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on FileNoandMembershipChecking.", ex, "ThirdVerification");
                frmobj.ShowDialog();
            }
            return fo;
        }
        #endregion

        private void btnVerified_Click(object sender, EventArgs e)
        {
            try
            {
                if (
                               MessageBox.Show("Are you Sure that Data is Correct", "Attention", MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (FileNoandMembershipChecking())
                    {
                        PersonalInformaiton();
                        int MID = 0;
                        MID = int.Parse(MemberID());
                        if (MID != 0)
                        {
                            NexkofKinInformation(MID);
                            FamilyMemberInformation(MID);
                            FileCreation();
                            OwnerCreation();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Membership  No " + BtxtMembershipno.Text + " is Binded to already.");
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnVerified_Click.", ex, "ThirdVerification");
                frmobj.ShowDialog();
            }
           

        }


        #region Family DGV
        private void FamilyMemberDGV_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

            }

        }

        private void FamilyMemberDGV_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

            }
        }
        #endregion

     

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnskip.Text = "Skip \n " + txtmsno.Text;

                BtxtFileNo.Text = txtFileNo.Text;
                BtxtMembershipno.Text = txtmsno.Text;
                Btxtfullname.Text = txtname.Text;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on tabControl1_SelectedIndexChanged.", ex, "ThirdVerification");
                frmobj.ShowDialog();
            }
           
        }

        private void btnskip_Click(object sender, EventArgs e)
        {
            gpskipremarks.Visible = true;
            btnskip.Visible = false;
            btnVerified.Visible = false;
        }
        private void btnskiped_Click(object sender, EventArgs e)
        {
            try
            {
                if (Btxtremarks.Text != "")
                {
                    string str = @"INSERT INTO [dbo].[tbl_DPR_Review]
                 ([MemberID],[Remarks],[ReviewStatus])
                  VALUES('" + passMemberID + "','" + Btxtremarks.Text + "','Wrong')";
                    int result = SQLHelper.ExecuteNonQuery(clsMostUseVars.Connectionstring, CommandType.Text, str);
                    if (result > 0)
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Contact to Administration");
                    }
                }
                else
                {
                    MessageBox.Show("Remarks Field Cannot be Empty.");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnskiped_Click.", ex, "ThirdVerification");
                frmobj.ShowDialog();
            }
            
        }
    }
}
