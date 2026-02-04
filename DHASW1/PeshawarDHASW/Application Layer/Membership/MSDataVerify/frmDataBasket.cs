using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsMemberShip;

using Telerik.WinControls;
using Telerik.WinControls.UI;
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Application_Layer.Membership.MSDataVerify
{
    public partial class frmDataBasket : Telerik.WinControls.UI.RadForm
    {
        public frmDataBasket()
        {
            InitializeComponent();
        }
        //Function return data to "radAllentry" radGridView
        private void dataloadingNotverify()
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task", "DatabasketAllEntry"),
                };
                DataSet ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameters);
                radAllentry.DataSource = ds.Tables[0].DefaultView;
                int raddatabasketnotverify = radAllentry.RowCount;
                lblallcount.Text = raddatabasketnotverify.ToString();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on dataloadingNotverify.", ex, "frmDataBasket");
                frmobj.ShowDialog();
            }
        }

        private void Incomplete()
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task", "Incomplete"),
                };
                DataSet ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameters);
                gdincomplete.DataSource = ds.Tables[0].DefaultView;
                int raddatabasketnotverify = gdincomplete.RowCount;
                lblincomplete.Text = raddatabasketnotverify.ToString();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Incomplete.", ex, "frmDataBasket");
                frmobj.ShowDialog();
            }
        }

        private void dataloadingAll()
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task", "DailyEntry"),
                };
                DataSet ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameters);
                raddailyentry.DataSource = ds.Tables[0].DefaultView;
                int raddgalldatacount = raddailyentry.RowCount;
                lbldialy.Text = raddgalldatacount.ToString();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on dataloadingAll.", ex, "frmDataBasket");
                frmobj.ShowDialog();
            }
        }


        private void VerificationTotalEntry()
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task", "dailyVerification"),
                };
                DataSet ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameters);
                Verification.DataSource = ds.Tables[0].DefaultView;
                int raddgalldatacount = Verification.RowCount;
                lbldialy.Text = raddgalldatacount.ToString();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on VerificationTotalEntry.", ex, "frmDataBasket");
                frmobj.ShowDialog();
            }
        }

        private void dataloadingImageReady()
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task", "ReadyforImage"),
                };
                DataSet ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameters);
                imageready.DataSource = ds.Tables[0].DefaultView;
                int raddgalldatacount = imageready.RowCount;
                lblimageupload.Text = raddgalldatacount.ToString();
            }

            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on dataloadingImageReady.", ex, "frmDataBasket");
                frmobj.ShowDialog();
            }
        }

        private void dataloadingReadyofrVerification()
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task", "ReadyforVerification"),
                };
                DataSet ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameters);
                verifyready.DataSource = ds.Tables[0].DefaultView;
                int raddgalldatacount = verifyready.RowCount;
                lblverify.Text = raddgalldatacount.ToString();
            }

            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on dataloadingReadyofrVerification.", ex, "frmDataBasket");
                frmobj.ShowDialog();
            }
        }

        private void FullVerified()
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task", "FullVerified"),
                };
                DataSet ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameters);
                verified.DataSource = ds.Tables[0].DefaultView;
                int raddatabasketnotverify = verified.RowCount;
                lbltotalverify.Text = raddatabasketnotverify.ToString();
            }

            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on FullVerified.", ex, "frmDataBasket");
                frmobj.ShowDialog();
            }
        }

        private void frmDataBasket_Load(object sender, EventArgs e)
        {
            SelectDatabase.SelectedIndex = 0;
            // imageready.MasterTemplate.Columns.Add(clsPluginHelper.GdButton("MemberID","MemberID","Upload","Click"));
            // verifyready.MasterTemplate.Columns.Add(clsPluginHelper.GdButton("MemberID", "MemberID", "View", "Click"));
            dataloadingNotverify();
            dataloadingAll();
            dataloadingImageReady();
            dataloadingReadyofrVerification();
            Incomplete();
            FullVerified();
            VerificationTotalEntry();
        }

        private void imageready_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = imageready.CurrentCell.RowIndex;
                int columnindex = imageready.CurrentCell.ColumnIndex;
                if (e.Column.Name == "MemberID")
                {
                    string ID = imageready.Rows[rowindex].Cells[1].Value.ToString();
                    frmAddImagesTo_Membership obj = new frmAddImagesTo_Membership(ID);
                    obj.ShowDialog();
                    // MessageBox.Show("BioInfo - > " + SearchDGV.Rows[rowindex].Cells[0].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on imageready_CellClick.", ex, "frmDataBasket");
                frmobj.ShowDialog();
            }
        }

        private void verifyready_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = verifyready.CurrentCell.RowIndex;
                int columnindex = verifyready.CurrentCell.ColumnIndex;
                if (e.Column.Name == "MemberID")
                {
                    int ID = int.Parse(verifyready.Rows[rowindex].Cells[0].Value.ToString());
                    MessageBox.Show(ID.ToString());
                    frmDataVerify obj = new frmDataVerify(ID);
                    obj.ShowDialog();
                    btnRefresh_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on verifyready_CellClick.", ex, "frmDataBasket");
                frmobj.ShowDialog();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataloadingNotverify();
            dataloadingAll();
            dataloadingReadyofrVerification();
            Incomplete();
            FullVerified();
            VerificationTotalEntry();
            dataloadingImageReady();
        }

        private void btnreverse_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectDatabase.SelectedItem.ToString() == "FirstStep Database")
                {
                    SqlParameter[] parameterFirststep =
                    {
                    new SqlParameter("@Task","ReverseEntry"),
                    new SqlParameter("@MembershipNo",txtmembershipno.Text)
                };
                    int result = cls_dl_Membership.Membership_PersonalInfo(parameterFirststep);
                    if (result > 0)
                    {
                        MessageBox.Show("Successfull");
                    }
                    else
                    {
                        MessageBox.Show("Fail");
                    }
                }
                else if (SelectDatabase.SelectedItem.ToString() == "Main Database")
                {
                    SqlParameter[] parameterFirststep =
                    {
                    new SqlParameter("@Task","ReverseEntry"),
                    new SqlParameter("@MembershipNo",txtmembershipno.Text)
                };
                    int result = cls_dl_Membership.MainDB_Membership_PersonalInfo(parameterFirststep);
                    if (result > 0)
                    {
                        MessageBox.Show("Successfull");
                    }
                    else
                    {
                        MessageBox.Show("Fail");
                    }
                }
                else
                {
                    MessageBox.Show("Select the Database");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnreverse_Click.", ex, "frmDataBasket");
                frmobj.ShowDialog();
            }
           
        }

        private void rdpersonal_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            try
            {
                txtquery.Text = "";
                txtquery.Text =
                    @"SELECT [ID], [MembershipNo], [Name], [Gender], [NIC/NICOP], [PassportNo], [PersonalNo(SvcPersOnly)], [Rank], [Arm/Svc],
     [Education/Qualification], [Profession], [Religion], [Nationality], [File/Plot/Shop/Villa/ApartmentNo],
	  [TypePlot], [Street/Lane No], [Sector], [Size], [DoB], [PlaceofDoB], [Marital Status], [DateofMarriage], [Father]
	  , [FPorfession], [Husband/Wife Name], [H/W Profession],[PresentAddress], [PrementAddress], [TelNo(Office)], [TelNo(Res)]
	  , [MobileNo], [Email], [Domicile], [Status], [user_ID], [DataStatus], [CompteleStatus], [VerifyStatus]
        FROM [dbo].[tbl_Membership]";
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on rdpersonal_ToggleStateChanged.", ex, "frmDataBasket");
                frmobj.ShowDialog();
            }
           
        }

        private void radnextofkin_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            try
            {
                txtquery.Text = "";
                txtquery.Text = @"SELECT b. [ID],b.[MemberID],b.[NameofKin],b.[Relation],b.[NIC/NICOP],b.[PassportNo] ,b.[Address],b.[TelNo(Office)],b.[TelNo(Res)],b.[MobileNo],b.[Email],b.[FaxNo],b.[user_ID] FROM [dbo].[tbl_Membership] a  inner join   [dbo].[tbl_MemberShipNextofKin] b on a.ID = b.MemberID";
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on radnextofkin_ToggleStateChanged.", ex, "frmDataBasket");
                frmobj.ShowDialog();
            }
        }

        private void radfamily_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            try
            {
                txtquery.Text = "";
                txtquery.Text = @"SELECT  b.MembershipNo, a.* FROM   dbo.tbl_FamilMember a INNER JOIN  dbo.tbl_Membership b ON a.Member_ID = b.ID";
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on radfamily_ToggleStateChanged.", ex, "frmDataBasket");
                frmobj.ShowDialog();
            }
           
        }

        private void btnexceutequery_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectDatabase.SelectedItem.ToString() == "FirstStep Database")
                {
                    try
                    {

                        if (radimageinfo.IsChecked)
                        {
                            Resultdg.DataSource = null;
                            Resultdg.MasterTemplate.Columns.Add(clsPluginHelper.GdButton("btnViewer", "ImageViewer", "ImageViewer1"));
                            Resultdg.DataSource =
                            cls_dl_Membership.executeQuery(clsMostUseVars.VerifiedImageConnectionstring, txtquery.Text).Tables[0]
                                .DefaultView;
                        }
                        else
                        {
                            Resultdg.DataSource =
                            cls_dl_Membership.executeQuery(clsMostUseVars.Connectionstring, txtquery.Text).Tables[0]
                                .DefaultView;
                        }
                    }
                    catch (Exception ex)
                    {
                        frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnexceutequery_Click.", ex, "frmDataBasket");
                        frmobj.ShowDialog();
                    }
                }
                else if (SelectDatabase.SelectedItem.ToString() == "Main Database")
                {
                    try
                    {

                        if (radimageinfo.IsChecked)
                        {
                            Resultdg.DataSource = null;
                            Resultdg.MasterTemplate.Columns.Add(clsPluginHelper.GdButton("btnViewer", "ImageViewer", "ImageViewer1"));
                            Resultdg.DataSource =
                                cls_dl_Membership.executeQuery(clsMostUseVars.VerifiedImageConnectionstring, txtquery.Text)
                                    .Tables[0]
                                    .DefaultView;
                        }
                        else
                        {
                            Resultdg.DataSource =
                            cls_dl_Membership.executeQuery(clsMostUseVars.Connectionstring, txtquery.Text).Tables[0]
                                .DefaultView;
                        }
                    }
                    catch (Exception ex)
                    {
                        frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnexceutequery_Click.", ex, "frmDataBasket");
                        frmobj.ShowDialog();
                    }

                }
                else
                {
                    MessageBox.Show("Select the Database Name");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnexceutequery_Click.", ex, "frmDataBasket");
                frmobj.ShowDialog();
            }
            
        }

        private void radimageinfo_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            try
            {
                txtquery.Text = "";
                txtquery.Text = @"SELECT a.[ID],b.[MembershipNo],a.[MemberID],a.[ImageName],a.[Description],a.[ImageFile],a.[user_ID] FROM [VerifiedDbMembershipImages].[dbo].[tbl_MemberImages] a inner join DvDHAPeshawarDB.dbo.tbl_Membership b on a.MemberID = b.ID";
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on radimageinfo_ToggleStateChanged.", ex, "frmDataBasket");
                frmobj.ShowDialog();
            }
       }

        private void Resultdg_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {

                int rowindex = Resultdg.CurrentCell.RowIndex;
                int columnindex = Resultdg.CurrentCell.ColumnIndex;
                if (e.Column.Name == "btnViewer")
                {
                    int indexofimage = 0;
                    bool imageindexer = int.TryParse(txtimageindex.Text, out indexofimage);
                    if (imageindexer)
                    {
                        Image img = ImageRetrive((byte[]) Resultdg.Rows[rowindex].Cells[6].Value);
                        frmImagePreview obj = new frmImagePreview(img);
                        obj.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Field");
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Resultdg_CellClick.", ex, "frmDataBasket");
                frmobj.ShowDialog();
            }
        }

        private Image ImageRetrive(byte[] imgdata)
        {
            MemoryStream ms = new MemoryStream(imgdata);
            ms.Position = 0;
            return Image.FromStream(ms);
        }
    }
}