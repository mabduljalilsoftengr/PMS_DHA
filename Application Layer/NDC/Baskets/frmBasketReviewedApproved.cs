using PeshawarDHASW.Application_Layer.NDC.NDC_CheckList;
using PeshawarDHASW.Data_Layer.NDC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Models;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.clsMemberShip;
using PeshawarDHASW.Helper;
using Microsoft.AspNet.SignalR.Client;
using System.Net.Http;

namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    public partial class frmBasketReviewedApproved : Telerik.WinControls.UI.RadForm
    {
        public frmBasketReviewedApproved()
        {
            InitializeComponent();
        }
        private int ndcno { get; set; }
        private int MSNewID_OutPut { get; set; }
        private String UserName { get; set; }
        private IHubProxy HubProxy { get; set; }
        const string ServerURI = "http://172.16.0.1:8181/signalr";
        private HubConnection Connection { get; set; }
        private string rfrString { get; set; }
        private void FillGrid(RadGridView dv,string Query)
        {
            try
            {
                dv.DataSource =
                                SQLHelper.ExecuteDataset(
                                    clsMostUseVars.Connectionstring, CommandType.Text, Query).Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on FillGrid.", ex, "frmBasketIncomplete");
                frmobj.ShowDialog();
            }
           
        }
        private void BasketFilling()
        {
            try
            {
                rfrString = "AllRefresh";
                SqlParameter[] prmt =
                {
                    new SqlParameter("@Task","GetNDCData_ForBaskets")
                    //new SqlParameter("@DateIssue", dtpgenate.Text == "" ? null : dtpgenate.Value.Date.ToString())
                };
                
                DataSet dst = cls_dl_NDC.NdcRetrival(prmt);
                grdIncomplete.DataSource = dst.Tables[0].DefaultView;
                grdunderobservation.DataSource = dst.Tables[3].DefaultView;
                grddealcancellation.DataSource = dst.Tables[4].DefaultView;
                //grdExpiredNDCs.DataSource = dst.Tables[1].DefaultView;
                //grdCancelNDC.DataSource = dst.Tables[2].DefaultView;
                DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.Text,
                               "Select * from tbl_Basket_Queries Where Status Like 'ON'");
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    //if (row["Task_Name"].ToString() == "Incomplete")
                    //{
                    //    FillGrid(grdIncomplete, row["Query"].ToString());
                    //}
                    //if (row["Task_Name"].ToString() == "RequestForPrint")
                    //{
                    //    FillGrid(grdRequestForPrint, row["Query"].ToString());
                    //}
                    //if (row["Task_Name"].ToString() == "ReadyForPrint")
                    //{
                    //    FillGrid(grdReady_For_Print, row["Query"].ToString());
                    //}
                    //if (row["Task_Name"].ToString() == "PrintAndNotSigned")
                    //{
                    //    FillGrid(grdPrinted_NotSigned, row["Query"].ToString());
                    //}
                    if (row["Task_Name"].ToString() == "Verified")
                    {
                        FillGrid(grdShowVerifiedNDCS, row["Query"].ToString());
                    }
                    //if (row["Task_Name"].ToString() == "SignedAndNotIssued") 
                    //{
                    //    FillGrid(grdSigned_NotIssued, row["Query"].ToString());
                    //}
                    if (row["Task_Name"].ToString() == "IssueAndImageUploaded")
                    {
                        FillGrid(grdIssued_ImageUpload, row["Query"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on BasketFilling.", ex, "frmBasketIncomplete");
                frmobj.ShowDialog();
            }
           
        }
        private void frmBasketIncomplete_Load(object sender, EventArgs e)
        {

            // Notification Start
            UserName = "172.16.0.1:8181";
            if (!String.IsNullOrEmpty(UserName))
            {
                StatusText.Visible = true;
                StatusText.Text = "Con ...";
                ConnectAsync();
            }
            // Notification End

            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            BindComboColumntoApprovedGrid();
            BasketFilling();
            //LoadDataForBaskets();
            #region Bind Button With Grid by "clsPluginHelper"
            //GridViewCommandColumn Incomplete = clsPluginHelper.GdButton("IncompleteInfo", "IncompleteInfo", "abc", "abc", 100);
            //grdIncomplete.MasterTemplate.Columns.Add(Incomplete);
            #endregion
        }
        private async void ConnectAsync()
        {
            Connection = new HubConnection(ServerURI);
            Connection.Closed += Connection_Closed;
            HubProxy = Connection.CreateHubProxy("MyChatHub");
            //Handle incoming event from server: use Invoke to write to console from SignalR's thread
            HubProxy.On<string, string>("AddMessage", (name, message) =>
                this.Invoke((Action)(() =>
                    RichTextBoxConsole.AppendText(message + Environment.NewLine)
                ))
            );
            try
            {
                await Connection.Start();
            }
            catch (HttpRequestException)
            {
                StatusText.Text = "Con = No";
                //No connection: Don't enable Send button or show chat UI
                return;
            }

            //Activate UI
            ButtonSend.Enabled = true;
            TextBoxMessage.Enabled = true;
            TextBoxMessage.Focus();
            //TextBoxUsername.Enabled = false;
            //ButtonConnect.Enabled = false;
            //RichTextBoxConsole.AppendText("Con = Ok");
            StatusText.Text = "Con = Ok";
        }


        private void Connection_Closed()
        {
            //Deactivate chat UI; show login UI. 
            this.Invoke((Action)(() => ButtonSend.Enabled = false));
            this.Invoke((Action)(() => StatusText.Text = "You have been disconnected."));
        }
        private void BindComboColumntoApprovedGrid()
        {
            /////////////////////// Drop Down Column//////////////////////////
            GridViewComboBoxColumn cmbColumn = new GridViewComboBoxColumn("Status");
            cmbColumn.DataSource = new String[] { "ReadyForFinalPrint", "Cancel" };
            //cmbColumn.ValueMember = "Type";
            //cmbColumn.DisplayMember = "Type";
            cmbColumn.FieldName = "Status";
            cmbColumn.Name = "Status";
            cmbColumn.HeaderText = "Status";
            cmbColumn.Width = 90;
            grdShowVerifiedNDCS.Columns.Add(cmbColumn);
            this.grdShowVerifiedNDCS.Columns.Move(6, 7);
            this.grdShowVerifiedNDCS.Columns.Move(5, 6);
        }
        private void grdIncomplete_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;
                bool grpb_Status = true;
                if (e.Column.Name == "NDC_Modify")
                {
                    int NDCNo_ = int.Parse(grdIncomplete.Rows[rowindex].Cells[0].Value.ToString());
                    frmNDCCreate obj = new frmNDCCreate(NDCNo_, grpb_Status);
                    obj.ShowDialog();
                    if(rfrString == "AllRefresh")
                    {
                        BasketFilling();
                    }
                    else if(rfrString == "GenerationDateRefresh")
                    {
                        GenDateDataGet();
                    }

                }
                if (e.Column.Name == "CheckList_Modify")
                {
                    int NDCNo_ = int.Parse(grdIncomplete.Rows[rowindex].Cells["NDCNo"].Value.ToString());
                    string fileno = grdIncomplete.Rows[rowindex].Cells["FilePlotNo"].Value.ToString();
                    bool Status = true;
                    frmNDC_CheckList_Binding_Updating obj = new frmNDC_CheckList_Binding_Updating(NDCNo_, Status, fileno);
                    obj.ShowDialog();
                    UpdateNDCStatus();

                    if (rfrString == "AllRefresh")
                    {
                        BasketFilling();
                    }
                    else if (rfrString == "GenerationDateRefresh")
                    {
                        GenDateDataGet();
                    }

                }
                if (e.Column.Name == "btnPrint")
                {
                    int NDCNo_ = int.Parse(grdIncomplete.Rows[rowindex].Cells[0].Value.ToString());
                    SqlParameter[] prm =
                    {
                        new SqlParameter("@Task","CheckNDCForPrint"),
                        new SqlParameter("@NDCNo",NDCNo_)
                    };
                    DataSet ds = cls_dl_NDC.NdcRetrival(prm);
                    if(ds.Tables[0].Rows[0]["StatusofNDC"].ToString() == "Incomplete")
                    {
                        MessageBox.Show("Please Complete all the Documents.");
                    }
                    else if(ds.Tables[0].Rows[0]["StatusofNDC"].ToString() == "ReadyForPrint")
                    {
                        frmNDC_Report chk = new frmNDC_Report(NDCNo_, "CheckListReport","");
                        chk.Show();
                        frmNDC_Report obj = new frmNDC_Report(NDCNo_,"NDCReport","");
                        obj.ShowDialog();
                        //BasketFilling();
                        if (rfrString == "AllRefresh")
                        {
                            BasketFilling();
                        }
                        else if (rfrString == "GenerationDateRefresh")
                        {
                            GenDateDataGet();
                        }
                    }
                   
                }
                if(e.Column.Name == "btnObsrvation")
                {
                    int NDCNo_ = int.Parse(grdIncomplete.Rows[rowindex].Cells["NDCNo"].Value.ToString());
                    SqlParameter[] prm =
                    {
                        new SqlParameter("@Task","UpdateNDCStatusForUnderObs"),
                        new SqlParameter("@NDCNo",NDCNo_),
                        new SqlParameter("@StatusofNDC","UnderObservation")
                    };
                    int rslt = cls_dl_NDC.NdcNonQuery(prm);
                    if(rslt > 0)
                    {
                        MessageBox.Show("Successful.");
                        BasketFilling();
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on grdIncomplete_CellClick.", ex, "frmBasketIncomplete");
                frmobj.ShowDialog();
            }
        }
        private void UpdateNDCStatus()
        {
            SqlParameter[] prmt =
            {
                new SqlParameter("@Task","UpdateToReadyForPrint"),
                new SqlParameter("@userID",Models.clsUser.ID)
            };
            int rslt = cls_dl_NDC.NdcNonQuery(prmt);
        }
        private void grdRequestForPrint_CellClick(object sender, GridViewCellEventArgs e)
        {

        }
        
        private void grdSigned_NotIssued_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = grdSigned_NotIssued.CurrentCell.RowIndex;
                int NDCNo_ = int.Parse(grdSigned_NotIssued.Rows[rowindex].Cells[0].Value.ToString());
                if (e.Column.Name == "Snd_NotIssd_Forward")
                {
                    #region Check that Image is exist OR Not against this NDCNo
                    SqlParameter[] pr =
                    {
                    new SqlParameter("@Task","Select"),
                    new SqlParameter("@NDCNo",NDCNo_)
                    };
                    DataSet ds = new DataSet();
                    ds = cls_dl_NDC.NdcRetrivalImages(pr);

                    if(ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show("Image is already Uploaded against this NDCNo.");
                        }
                        else
                        {
                            frm_NDC_ImageUpload frm = new frm_NDC_ImageUpload(NDCNo_);
                            frm.ShowDialog();
                            BasketFilling();
                        }
                    }
                   


                    #endregion

                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on grdSigned_NotIssued_CellClick.", ex, "frmBasketIncomplete");
                frmobj.ShowDialog();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BasketFilling();
        }

        private void grdIssued_ImageUpload_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = grdIssued_ImageUpload.CurrentCell.RowIndex;
                ndcno = int.Parse(grdIssued_ImageUpload.Rows[rowindex].Cells[0].Value.ToString());
                if (e.Column.Name == "Issue_ImageUpload_Next")
                {
                    if (
                        MessageBox.Show("Are you sure,You want to Move NDC to the Next Stage.",
                        "Warning",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                        Update_NDC_Status();
                        //#region Count the Total Buyers of NDC
                        //SqlParameter[] prm =
                        //{
                        //    new SqlParameter("@Task","CountTotalBuyerNDC"),
                        //    new SqlParameter("@NDCNo",ndcno)
                        //};
                        //DataSet ds = cls_dl_NDC.NdcRetrival(prm);
                        //if(ds.Tables.Count > 0)
                        //{
                        //   int cnt =  int.Parse(ds.Tables[0].Rows[0]["TotalBuyers"].ToString());
                        //   for (int i = 0; i < cnt; i++)
                        //   {
                        //        if (InsertMembershipPersonalInfo() == true)
                        //        {
                        //            Update_NDC_Status();
                        //        }
                        //        else
                        //        {
                        //            MessageBox.Show("Dummy Membership Dos't Generated.");
                        //        }
                        //   }
                        //}
                        //#endregion

                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on grdIssued_ImageUpload_CellClick.", ex, "frmBasketIncomplete");
                frmobj.ShowDialog();
            }
           
        }
        private void Update_NDC_Status()
        {
            SqlParameter[] prm =
                       {
                        new SqlParameter("@Task","Update_NDC_Status"),
                        new SqlParameter("@StatusofNDC","ReadyForTFRAppointment"), //ReadyForMembership
                        new SqlParameter("@NDCNo",ndcno)
                        };
            int rslt = cls_dl_NDC.NdcNonQuery(prm);
            if (rslt > 0)
            {
                MessageBox.Show("Successfull.");
                BasketFilling();
                //this.Close();
            }
        }
        private bool InsertMembershipPersonalInfo()
        {
            bool abc = false;
            try
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
                        new SqlParameter("@MembershipNo", "NDC-"+ndcno),
                        new SqlParameter("@Name", "name"),
                        new SqlParameter("@Gender", ""),
                        new SqlParameter("@NICNICOP", "nicnicop"),
                        new SqlParameter("@PassportNo", "passportno"),
                        new SqlParameter("@PersonalNoSvcPersOnly", "pano"),
                        new SqlParameter("@Rank", "rank"),
                        new SqlParameter("@ArmSvc", "ArmSvc"),
                        new SqlParameter("@EducationQualification", "education"),
                        new SqlParameter("@Profession", "profession"),
                        new SqlParameter("@Religion", "religion"),
                        new SqlParameter("@Nationality", "nationality"),
                        new SqlParameter("@FilePlotShopVillaApartmentNo", "FileNo"),
                        new SqlParameter("@TypePlot", 1),
                        new SqlParameter("@StreetLane_No", "streetno"),
                        new SqlParameter("@Sector", "sector"),
                        new SqlParameter("@Size", "size"),
                        new SqlParameter("@DoB", "12/12/2000"), /////////////////////////////////////////////////////////////////// Date
                        new SqlParameter("@PlaceofDoB", "placeofB"),
                        new SqlParameter("@Marital_Status", ""),
                        new SqlParameter("@DateofMarriage", "12/12/2000"),/////////////////////////////////////////////////////////////////// Date
                        new SqlParameter("@Father", "father"),
                        new SqlParameter("@FPorfession", "fatherprofession"),
                        new SqlParameter("@HusbandWife_Name", "hwname"),
                        new SqlParameter("@HW_Profession", "hwprofession"),
                        new SqlParameter("@PresentAddress","presentaddress"),
                        new SqlParameter("@PrementAddress", "permentaddress"),
                        new SqlParameter("@TelNoOffice", "telnooffice"),
                        new SqlParameter("@TelNoRes", "telnores"),
                        new SqlParameter("@MobileNo", "mobile"),
                        new SqlParameter("@Email", "email"),
                        new SqlParameter("@FaxNo","faxno"),
                        new SqlParameter("@Domicile", "domicile"),
                        new SqlParameter("@user_ID", PeshawarDHASW.Models.clsUser.ID),
                        param_out_ID,
                        new SqlParameter("@CompteleStatus", "Complete"),
                        new SqlParameter("@NDCNo",ndcno)
                    };
                SqlCommand result;
                result = Data_Layer.clsMemberShip.cls_dl_Membership.Membership_PersonalInfo_outparameter(parameter1);
                if (result.Parameters.Count != 0)
                {
                    MSNewID_OutPut = int.Parse(result.Parameters["@OutIDMS"].Value.ToString());
                    //Insertion Of NextOfKin
                    if (MSNewID_OutPut != 0)
                    {
                        InsertNextOfKin();
                        InsertFamilyMember();
                        //MessageBox.Show("Membership Detail is Successfully Generated.");
                    }
                    abc = true;
                }
                else
                { abc = false; }

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is throw on InsertMembershipPersonalInfo.", ex, "frmMembership_All_Info_Modify");
                frmobj.ShowDialog();
            }
            return abc;
        }
        private void InsertNextOfKin()
        {
            try
            {
                SqlParameter[] parameters = new[]
                                              {
                                    new SqlParameter("@Task", "Insert"),
                                    new SqlParameter("@MemberID", MSNewID_OutPut),
                                    new SqlParameter("@NameofKin", "name"),
                                    new SqlParameter("@Relation", "nokrelation"),
                                    new SqlParameter("@NICNICOP", "noknic"),
                                    new SqlParameter("@PassportNo", "nokpassportno"),
                                    new SqlParameter("@Address", "nokaddress"),
                                    new SqlParameter("@TelNoOffice", "nokofficetel"),
                                    new SqlParameter("@TelNoRes", "telnores"),
                                    new SqlParameter("@MobileNo", "nokMobile"),
                                    new SqlParameter("@Email", "nokemail"),
                                    new SqlParameter("@FaxNo", "nokfaxno"),
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
                    SqlParameter[] parameters = new[]
                    {
                                new SqlParameter("@Task", "Insert"),
                                new SqlParameter("@Member_ID", MSNewID_OutPut),
                                new SqlParameter("@Name", "familymembername"),
                                new SqlParameter("@DOB", "12/12/2000"),
                                new SqlParameter("@NICNO", "nic"),
                                new SqlParameter("@Relation", "Relation"),
                                new SqlParameter("@user_ID", clsUser.ID)
                            };
                    int result = cls_dl_Membership.Membership_FamilyMember_NonQuery(parameters);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on InsertFamilyMember.", ex, "frmMembership_All_Info_Modify");
                frmobj.ShowDialog();
            }

        }
        private void radGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void grdReady_For_Print_CellClick(object sender, GridViewCellEventArgs e)
        {

        }

        private void grdShowVerifiedNDCS_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "Prnt_NotSnd")
                {
                    DateTime dtp = (DateTime)e.Row.Cells["dtpApprovedDate"].Value;
                    if (dtp < DateTime.Today.AddDays(-3) || dtp > DateTime.Today)
                    {
                        MessageBox.Show("Your Date must not be less then 3 days of the current date,"+Environment.NewLine+
                            "and must not be greater then current date.");
                    }
                    else
                    {

                    int rowindex = e.RowIndex;
                    int NDCNo = int.Parse(grdShowVerifiedNDCS.Rows[rowindex].Cells["NDCNo"].Value.ToString());
                    string rmks = grdShowVerifiedNDCS.Rows[rowindex].Cells["AppCacRemarks"].Value.ToString() == "" ? "" : grdShowVerifiedNDCS.Rows[rowindex].Cells["AppCacRemarks"].Value.ToString();
                    string ndcStatus = grdShowVerifiedNDCS.Rows[rowindex].Cells["Status"].Value.ToString() == "" ? "" : grdShowVerifiedNDCS.Rows[rowindex].Cells["Status"].Value.ToString();
                    

                        if (!string.IsNullOrEmpty(ndcStatus) && !string.IsNullOrEmpty(rmks))
                         {
                        if (
                                              MessageBox.Show("Are you sure,You want to Approve/Cancel.",
                                              "Warning",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Warning) == DialogResult.Yes)
                        {

                            SqlParameter[] prmtr =
                            {
                            new SqlParameter("@Task","UpdateNDCStatusAndRemarks"),
                            new SqlParameter("@NDCNo",NDCNo),
                            new SqlParameter("@AppCacRemarks",rmks),
                            new SqlParameter("@StatusofNDC",ndcStatus),
                            new SqlParameter("@userID",Models.clsUser.ID),
                            new SqlParameter("@ApprovedByDate",dtp)
                            };
                            int rslt = cls_dl_NDC.NdcNonQuery(prmtr);
                            if (rslt > 0)
                            {
                                MessageBox.Show(ndcStatus + "Successfully.");
                                btnRefresh_Click(sender,e);
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select the Status and Enter Remarks.");
                    }


                }


                }
                else if (e.Column.Name == "btnBack")
                {
                    try
                    {
                        frmGoBackRemarks frm = new frmGoBackRemarks();
                        frm.ShowDialog();

                        string rmksGoBack = clsNDC.goBackRemarks;
                        if (!string.IsNullOrEmpty(rmksGoBack))
                        {
                            int NDCID = int.Parse(e.Row.Cells["NDCNo"].Value.ToString());
                            SqlParameter[] prmt =
                            {
                            new SqlParameter("@Task","Update_NDC_Status"),
                            new SqlParameter("@StatusofNDC","PrintAndNotSigned"),
                            new SqlParameter("@NDCNo",NDCID),
                            new SqlParameter("@GoBack_Remarks",rmksGoBack)
                            };
                            int rslt = 0;
                            rslt = cls_dl_NDC.NdcNonQuery(prmt);
                            if (rslt > 0)
                            {
                                MessageBox.Show("Successfull.");
                                btnRefresh_Click(sender, e);
                            }
                        }
                        else { MessageBox.Show("Please Enter back remarks."); }


                    }
                    catch (Exception ex)
                    {
                        frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btn_Back_Click.", ex, "frmPrintNotSigned_NDCCheckListDetail");
                        frmobj.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBoxMessage.Text))
            {
                HubProxy.Invoke("Send", UserName, TextBoxMessage.Text);
                TextBoxMessage.Text = String.Empty;
                TextBoxMessage.Focus();
            }
            else
            {
                MessageBox.Show("Please Write Message.");
            }
           
        }

        private void btnfind_Click(object sender, EventArgs e)
        {
            GenDateDataGet();
        }
        private void GenDateDataGet()
        {
            try
            {
                rfrString = "GenerationDateRefresh";
                SqlParameter[] prmt =
                {
                    new SqlParameter("@Task","GetNDCData_ForBaskets_Gendate"),
                    new SqlParameter("@DateIssue",dtpgenate.Value.Date)
                };
                DataSet dst = cls_dl_NDC.NdcRetrival(prmt);
                grdIncomplete.DataSource = dst.Tables[0].DefaultView;
                //grdExpiredNDCs.DataSource = dst.Tables[1].DefaultView;
                //grdCancelNDC.DataSource = dst.Tables[2].DefaultView;
                DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.Text,
                               "Select * from tbl_Basket_Queries Where Status Like 'ON'");
                foreach (DataRow row in ds.Tables[0].Rows)
                {

                    if (row["Task_Name"].ToString() == "Verified")
                    {
                        FillGrid(grdShowVerifiedNDCS, row["Query"].ToString());
                    }
                    if (row["Task_Name"].ToString() == "IssueAndImageUploaded")
                    {
                        FillGrid(grdIssued_ImageUpload, row["Query"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on BasketFilling.", ex, "frmBasketIncomplete");
                frmobj.ShowDialog();
            }
        }

        private void grdunderobservation_CellClick(object sender, GridViewCellEventArgs e)
        {
            if(e.Column.Name == "btnclearobservation")
            {
                int NDCNo_ = int.Parse(e.Row.Cells["NDCNo"].Value.ToString());
                SqlParameter[] prm =
                {
                   new SqlParameter("@Task","UpdateNDCStatusForUnderObs"),
                   new SqlParameter("@NDCNo",NDCNo_),
                   new SqlParameter("@StatusofNDC","Incomplete")
                };
                int rslt = cls_dl_NDC.NdcNonQuery(prm);
                if (rslt > 0)
                {
                    MessageBox.Show("Successful.");
                    BasketFilling();
                }
            }
            
        }

        private void grddealcancellation_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "btndealcancel")
                {
                    if (MessageBox.Show("Are you sure ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        int NDCNo_ = Convert.ToInt32(e.Row.Cells["NDCNo"].Value.ToString());
                        string FileNo = e.Row.Cells["FilePlotNo"].Value.ToString();
                        SqlParameter[] prm =
                        {
                             new SqlParameter("@Task","UpdateNDCAndExpireDateByFinance"),
                             new SqlParameter("@NDCNo",NDCNo_),
                             new SqlParameter("@StatusofNDC","Cancel"),
                             new SqlParameter("@FileNo",FileNo),
                             new SqlParameter("@UserID",clsUser.ID),
                             new SqlParameter("@UserName",clsUser.Name)
                        };
                        int rsl = cls_dl_NDC.NdcNonQuery(prm);
                        if (rsl > 0)
                        {
                            MessageBox.Show("Deal Cancelled Successfully.");
                            BasketFilling();
                        }
                    }
                }
                else if(e.Column.Name == "btnprint")
                {
                    int NDCNo_ = int.Parse(e.Row.Cells["NDCNo"].Value.ToString());
                    //SqlParameter[] prm =
                    //{
                    //    new SqlParameter("@Task","CheckNDCForPrint"),
                    //    new SqlParameter("@NDCNo",NDCNo_)
                    //};
                    //DataSet ds = cls_dl_NDC.NdcRetrival(prm);
                    //if (ds.Tables[0].Rows[0]["StatusofNDC"].ToString() == "Incomplete")
                    //{
                    //    MessageBox.Show("Please Complete all the Documents.");
                    //}
                    //else if (ds.Tables[0].Rows[0]["StatusofNDC"].ToString() == "ReadyForPrint")
                    //{
                        frmNDC_Report chk = new frmNDC_Report(NDCNo_, "CheckListReport", "");
                        chk.Show();
                        frmNDC_Report obj = new frmNDC_Report(NDCNo_, "NDCReport", "");
                        obj.ShowDialog();
                        //BasketFilling();
                        if (rfrString == "AllRefresh")
                        {
                            BasketFilling();
                        }
                        else if (rfrString == "GenerationDateRefresh")
                        {
                            GenDateDataGet();
                        }
                    //}
                }
                else if(e.Column.Name == "btnexpcncl")
                {
                    if (MessageBox.Show("Are you sure ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        int NDCNo_ = Convert.ToInt32(e.Row.Cells["NDCNo"].Value.ToString());
                        string FileNo = e.Row.Cells["FilePlotNo"].Value.ToString();
                        SqlParameter[] prm =
                        {
                           new SqlParameter("@Task","UpdateNDCAndExpireDateFin"),
                           new SqlParameter("@NDCNo",NDCNo_),
                           new SqlParameter("@StatusofNDC","ExpiredCancel"),
                           new SqlParameter("@FileNo",FileNo),
                           new SqlParameter("@UserID",clsUser.ID),
                           new SqlParameter("@UserName",clsUser.Name)
                        };
                        int rsl = cls_dl_NDC.NdcNonQuery(prm);
                        if (rsl > 0)
                        {
                            MessageBox.Show("NDC cancelled successfully.");
                            if (rfrString == "AllRefresh")
                            {
                                BasketFilling();
                            }
                            else if (rfrString == "GenerationDateRefresh")
                            {
                                GenDateDataGet();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
