using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsApplication;
using PeshawarDHASW.Data_Layer.clsErrorLog;
using PeshawarDHASW.Data_Layer.clsFileMap;
using PeshawarDHASW.Data_Layer.clsMemberShip;
using PeshawarDHASW.Data_Layer.clsOwnerType;
using PeshawarDHASW.Data_Layer.clsPlotSize;
using PeshawarDHASW.Models;
using Telerik.WinControls;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.Membership.MSDataVerify
{
    public partial class frmDataVerify : Telerik.WinControls.UI.RadForm
    {
        public frmDataVerify()
        {
            InitializeComponent();
        }

        public int passMemberID { get; set; }
        public int TotalImage { get; set; }

        public frmDataVerify(int MemberID)
        {
            ///////////////////////////
            passMemberID = MemberID;
            InitializeComponent();
        }

        #region Image Retriving

        private DataSet IMageLoading(int memberID)
        {
            DataSet ds= new DataSet();
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task", "Select"),
                    new SqlParameter("@MemberID", memberID),
                };
                 ds = cls_dl_Image.Image_Retriving(parameters);
                TotalImage = ds.Tables[0].Rows.Count;
                
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on IMageLoading.", ex, "frmDataVerify");
                frmobj.ShowDialog();
            }
            return ds;
        }

        private DataSet dsImage = new DataSet();


       
      
        private void PlotType()
        {
            try
            {

                DataSet ds = cls_dl_Membership_PlotTYpe.PlotType();
                cmbtypeplot.DataSource = ds.Tables[0];
                cmbtypeplot.ValueMember = "PlotID";
                cmbtypeplot.DisplayMember = "Type";
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on PlotType.", ex, "frmDataVerify");
                frmobj.ShowDialog();
            }
        }
        private void frmDataVerify_Load(object sender, EventArgs e)
        {
            try
            {
                PlotType();
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
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on PlotType.", ex, "frmDataVerify");
                frmobj.ShowDialog();
            }
           
        }

        private Image ImageRetrive(int imageindex)
        {
            MemoryStream ms = new MemoryStream();
            try
            {
                byte[] imgData = (byte[])dsImage.Tables[0].Rows[imageindex]["ImageFile"];
                ms = new MemoryStream(imgData);
                ms.Position = 0;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on ImageRetrive.", ex, "frmDataVerify");
                frmobj.ShowDialog();
            }
            // Transfer everything to the Image property of the picture box....
           
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
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnpreciousimage_Click.", ex, "frmDataVerify");
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
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnnextimage_Click.", ex, "frmDataVerify");
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
                    cmbtypeplot.SelectedValue = short.Parse(row["TypePlot"].ToString());
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
                    txtFaxNo.Text = row["FaxNo"].ToString();
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
                ///EnteredbyUserInformation
                  SqlParameter[] parameterUser = new[]
                {
                    new SqlParameter("@Task", "EnteredbyUserInformation"),
                    new SqlParameter("@ID", MemberID)
                };
                DataSet dsuserinfo = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameterUser);
                lbluserinfo.Text = dsuserinfo.Tables[0].Rows[0]["Recordinfo"].ToString();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on PersonalINformationLoad.", ex, "frmDataVerify");
                frmobj.ShowDialog();
            }
        }

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
                        //nextofkinID = int.Parse(row["ID"].ToString());
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
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on NexkofKinInforamtionLoad.", ex, "frmDataVerify");
                frmobj.ShowDialog();
            }
        }

        private void FamilyMember(int MemberID)
        {
            try
            {
                SqlParameter[] parameter = new[] {new SqlParameter("@Member_ID", MemberID)};
                DataSet ds = cl_dl_SerachMembership.MembershipFamilyDataLoadforView(parameter);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    FamilyMemberDGV.DataSource = dt.DefaultView;
                }
                else
                {
                 
                }

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on FamilyMember.", ex, "frmDataVerify");
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
                    new SqlParameter("@Task", "Insert"),
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
                    new SqlParameter("@FaxNo",txtFaxNo.Text), 
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
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on PersonalInformaiton.", ex, "frmDataVerify");
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
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on MemberID.", ex, "frmDataVerify");
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
                            new SqlParameter("@Task", "Insert"),
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
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on NexkofKinInformation.", ex, "frmDataVerify");
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
                    string Name = FamilyMemberDGV.Rows[i].Cells[0].Value.ToString();
                    string Date = FamilyMemberDGV.Rows[i].Cells[1].Value.ToString();
                    string NIC = FamilyMemberDGV.Rows[i].Cells[2].Value.ToString();
                    string Relation = FamilyMemberDGV.Rows[i].Cells[3].Value.ToString();

                    SqlParameter[] parameters = new[]
                    {
                        new SqlParameter("@Task", "Insert"),
                        new SqlParameter("@Member_ID", MemberID),
                        new SqlParameter("@Name", Name),
                        new SqlParameter("@DOB", Date),
                        new SqlParameter("@NICNO", NIC),
                        new SqlParameter("@Relation", Relation),
                        new SqlParameter("@user_ID", Models.clsUser.ID)
                    };

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

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on FamilyMemberInformation.", ex, "frmDataVerify");
                frmobj.ShowDialog();
            }

        }

        private void VerifiedImage(int MemberID)
        {
            try
            {

                foreach (DataRow row in dsImage.Tables[0].Rows)
                {

                    SqlParameter[] parameters =
                    {
                        new SqlParameter("@Task", "Insert"),
                        new SqlParameter("@MemberID", MemberID),
                        new SqlParameter("@ImageFile", row["ImageFile"]),
                        new SqlParameter("@ImageName", row["ImageName"]),
                        new SqlParameter("@Description", row["Description"]),
                        new SqlParameter("@user_ID", Models.clsUser.ID),
                    };
                    int result = cls_dl_Image.MainDB_Membership_Image_NonQuery(parameters);
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
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on VerifiedImage.", ex, "frmDataVerify");
                frmobj.ShowDialog();
            }
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
                    PersonalInformaiton();
                    int MID = 0;
                    MID = int.Parse(MemberID());
                    if (MID != 0)
                    {
                        NexkofKinInformation(MID);
                        FamilyMemberInformation(MID);
                        VerifiedImage(MID);
                        this.Close();
                    }

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnVerified_Click.", ex, "frmDataVerify");
                frmobj.ShowDialog();
            }
            

        }

       

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
    }
}