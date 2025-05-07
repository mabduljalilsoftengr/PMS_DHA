using PeshawarDHASW.Data_Layer.clsMemberShip;
using PeshawarDHASW.Data_Layer.clsTFR;
using PeshawarDHASW.Data_Layer.clsTypeofPruchase;
using PeshawarDHASW.Data_Layer.NDC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsErrorLog;
using PeshawarDHASW.Models;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer;
using PeshawarDHASW.Helper;
using System.Text.RegularExpressions;
using Telerik.WinControls.Primitives;
using System.Net.Http;
using Microsoft.AspNet.SignalR.Client;

namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    public partial class frmGenerateTFRAppointment : Telerik.WinControls.UI.RadForm
    {
        public int FileKey { get; set; }
        public int NDCNo { get; set; }
        public DateTime dt_Issue_NDC { get; set; }
        public DateTime dt_Expire_NDC { get; set; }
        public string FileNo { get; set; }
        public int NDCNo_tfr { get; set; }
        public string SellerMSNOString { get; set; } = "";
        public string BuyerMSNOString { get; set; } = "";
        public int PurchaseTypeID { get; set; }
        public int TFRAppointmentNo { get; set; }
        public DataSet dst1 { get; set; }
        private DataSet dst_ { get; set; }
        private String UserName { get; set; }
        private IHubProxy HubProxy { get; set; }
        const string ServerURI = "http://172.16.0.1:8181/signalr";
        private HubConnection Connection { get; set; }
        public frmGenerateTFRAppointment()
        {
            InitializeComponent();
        }

        private void frmGenerateTFRAppointment_Load(object sender, EventArgs e)
        {
            try
            {
                // Notification -Start
                UserName = "172.16.0.1:8181";
                if (!String.IsNullOrEmpty(UserName))
                {
                    ConnectAsync();
                }
                // Notification -End

                #region Change border color of Groupbox
                //BorderPrimitive border = (BorderPrimitive)grpb_Detail_Creat.GroupBoxElement.Content.Children[1];
                //border.Width = 2;
                //border.BoxStyle = BorderBoxStyle.SingleBorder;
                //border.GradientStyle = GradientStyles.Solid;
                //border.ForeColor = Color.Violet;

                //BorderPrimitive border1 = (BorderPrimitive)grpNextToImage.GroupBoxElement.Content.Children[1];
                //border1.Width = 2;
                //border1.BoxStyle = BorderBoxStyle.SingleBorder;
                //border1.GradientStyle = GradientStyles.Solid;
                //border1.ForeColor = Color.BlueViolet;
                #endregion


                AutoScroll = true;
                this.ThemeName = clsUser.ThemeName;
                ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
                LoadDataForBasket();
                LoadDataForTFRBasket();
                #region TextBoxes/GroupBox Disabled

                txtNDCNo.Enabled = false;
                txtIssueDate.Enabled = false;
                txtExpireDate.Enabled = false;
                //grpb_Detail_Creat.Enabled = false;
                btnTFR_Appointment.Enabled = false;
                #endregion
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmGenerateTFRAppointment_Load.", ex, "frmGenerateTFRAppointment");
                frmobj.ShowDialog();
                //cls_dl_ErrorLog.ErrorLogSAvetoDB(ex, "frmGenerateTFRAppointment Load Event");
                //MessageBox.Show(ex.Message);
            }

        }
        private async void ConnectAsync()
        {
            Connection = new HubConnection(ServerURI);
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
               
                //No connection: Don't enable Send button or show chat UI
                return;
            }

           
        }


      
        private void LoadDataForBasket()
        {
            try
            {
                SqlParameter[] prmt =
                {
                    new SqlParameter("@Task","GetDataForTFRAppointment")
                };
                dst_ = cls_dl_TFRAppointment.TFRReader(prmt);
                grdReady_For_TFRAppointment.DataSource = dst_.Tables[0].DefaultView;
                grdExpireNDCs.DataSource = dst_.Tables[1].DefaultView;
                if(dst_.Tables[2].Rows.Count > 0)
                {
                    grdndclog.DataSource = dst_.Tables[2].DefaultView;
                }
              

                ConditionalFormattingObject obj = new ConditionalFormattingObject("MyCondition1", ConditionTypes.LessOrEqual, 
                                                                                  "2", "", true);
                obj.RowBackColor = Color.Red;
                obj.RowForeColor = Color.White;
                this.grdReady_For_TFRAppointment.Columns["DaysRemainingForExpiry"].ConditionalFormattingObjectList.Add(obj);

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LoadDataForBasket.", ex, "frmGenerateTFRAppointment");
                frmobj.ShowDialog();
            }
        }
        private void LoadDataForTFRBasket()
        {
            try
            {
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","ReadyForTransfer"),
                new SqlParameter("@ExpireDate", string.IsNullOrEmpty(dtpappdate.Text) ? DBNull.Value : (object)dtpappdate.Value.Date)
                };
                DataSet ds = cls_dl_TFRAppointment.TFRReader(prm);
                grdReady_For_Transfer.DataSource = ds.Tables[0].DefaultView;

                ConditionalFormattingObject obj = new ConditionalFormattingObject("MyCondition1", ConditionTypes.LessOrEqual,
                                                                                 "2", "", true);
                obj.RowBackColor = Color.Red;
                obj.RowForeColor = Color.White;
                this.grdReady_For_Transfer.Columns["RemainingDaysForExpiry"].ConditionalFormattingObjectList.Add(obj);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LoadDataForBasket.", ex, "frmReadyForTransfer");
                frmobj.ShowDialog();
            }

        }
        private void FillDataGrid(RadGridView grd, string qury)
        {
            grd.DataSource = 
                SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.Text, qury).Tables[0].DefaultView;
        }
        private void CurrentOwnerDetail_NewOwnerDetail(string get_fileno, int get_ndc_no)
        {
            try
            {
                int NDCNo_ = get_ndc_no;
                string File_No = get_fileno;
                SqlParameter[] prmtr =
                {
                    new SqlParameter("@Task", "Select_Data_For_TFRAppointment"),
                    new SqlParameter("@FileNo_Pass", File_No),
                    new SqlParameter("@NDCNo_Pass", NDCNo_)
                };
                DataSet dst = new DataSet();
                dst = cls_dl_Membership.Membership_PersonalInfo_Retrive(prmtr);
                if (dst.Tables[0].Rows.Count > 0 && dst.Tables[1].Rows.Count > 0 && dst.Tables[2].Rows.Count > 0 &&
                    dst.Tables[3].Rows.Count > 0)
                {
                    grpb_Detail_Creat.Enabled = true;
                    btnTFR_Appointment.Enabled = true;
                    FileKey = int.Parse(dst.Tables[1].Rows[0]["FileMapKey"].ToString());
                    grdCurrent_Members.DataSource = dst.Tables[1].DefaultView;
                    grdNew_Members.DataSource = dst.Tables[2].DefaultView;
                    //@@@@@@@@@@@@@@@@ Bind NDC Information    @@@@@@@@@@@@@@@@@@@@@@
                    txtNDCNo.Text = NDCNo.ToString();
                    DateTime NDCIssue_Date = DateTime.Parse(dst.Tables[3].Rows[0]["DateIssue"].ToString());
                    txtIssueDate.Text = NDCIssue_Date.ToString("dd/MM/yyyy");
                    //txtIssueDate.Text = dst.Tables[0].Rows[0]["DateIssue"].ToString();
                    txtExpireDate.Text = dst.Tables[3].Rows[0]["NDCExpireDate"].ToString();
                    //@#################  END NDC Info ##############################
                    //@@@@@@@@@@@@@@@@@@@ Bind Type Purchase Info @@@@@@@@@@@@@@@@@@2@@@@
                    string tp_Name = dst.Tables[0].Rows[0]["Name"].ToString();
                    lblTypePurchaseName.Text = tp_Name;
                    lblTypePurchaseNo.Text = TypePurchaseID_Get(tp_Name);
                    //#######################  End Type Purchase @############################
                }
                else
                {
                    MessageBox.Show("All the Required Data for TFRAppointment is not Complete.Please check the Previous Data.");
                }

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on CurrentOwnerDetail_NewOwnerDetail.", ex, "frmGenerateTFRAppointment");
                frmobj.ShowDialog();
            }
        }
        static string TypePurchaseID_Get(string t_Purchase_name)
        {
            string tp_id = "";
            SqlParameter[] prmt =
            {
                new SqlParameter("@Task","Select"),
                new SqlParameter("@Name",t_Purchase_name)
            };
            DataSet dts = new DataSet();
            dts = cls_dl_TypeofPurchase.TypeofPurchase_Reader(prmt);
            if (dts.Tables.Count > 0)
            {
                if(dts.Tables[0].Rows.Count > 0)
                {
                    tp_id = dts.Tables[0].Rows[0]["TypeID"].ToString();
                }
            }
            return tp_id;
        }
        private void grdReady_For_TFRAppointment_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
               
                int ndc_no = int.Parse(grdReady_For_TFRAppointment.CurrentRow.Cells["NDCNo"].Value.ToString());
                dt_Issue_NDC = DateTime.Parse(grdReady_For_TFRAppointment.CurrentRow.Cells["DateIssue"].Value.ToString());
                //string test = grdReady_For_TFRAppointment.CurrentRow.Cells[4].Value.ToString();
                dt_Expire_NDC = DateTime.Parse(grdReady_For_TFRAppointment.CurrentRow.Cells["NDCExpireDate"].Value.ToString());
                //DateIssue  ,   NDCExpireDate
                NDCNo = ndc_no;
                string file_no = grdReady_For_TFRAppointment.CurrentRow.Cells["FilePlotNo"].Value.ToString();
                if (e.Column.Name == "CreateTFR")
                {
                    dateofissue.Value = DateTime.Now;
                    DateTime dttim = DateTime.Now.Date;

                    dateofissue.MinDate = DateTime.Now.Date.AddDays(-1);
                    dateofissue.MaxDate = dt_Expire_NDC;
                    dateofexpire.MinDate = DateTime.Now.Date;
                    dateofexpire.MaxDate = dt_Expire_NDC;
                    CurrentOwnerDetail_NewOwnerDetail(file_no, ndc_no);
                    #region  Commented Code
                    //NDCDetail(ndc_no);
                    /*     DateTime dt = DateTime.Parse(DateTime.Now.AddDays(-1).ToShortDateString());
                           int days = int.Parse((dt_Expire_NDC - dt).TotalDays.ToString());


                           DateTime datemax = dt_Expire_NDC;
                           dateofissue.MinDate = dt;
                           dateofexpire.MinDate = dt;
                           if (dt_Expire_NDC < DateTime.Now)
                           {
                               dateofissue.MaxDate = dt.AddDays(days);
                               dateofexpire.MaxDate = dt.AddDays(days);
                           }
                           else
                           {
                               //dateofissue.MaxDate = datemax;
                               //dateofexpire.MaxDate = datemax;
                           }                                     */

                    //NewOwnerDetail(ndc_no);
                    //BindTFR_Types();
                    #endregion
                }
                else if (e.Column.Name == "btnDealCancel")
                {
                    if (MessageBox.Show("Are you sure ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        int NDCNo_ = Convert.ToInt32(e.Row.Cells["NDCNo"].Value.ToString());
                        string FileNo = e.Row.Cells["FilePlotNo"].Value.ToString();
                        SqlParameter[] prm =
                        {
                             new SqlParameter("@Task","UpdateNDCAndExpireDateFin"),
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
                            LoadDataForBasket();
                        }
                    }
                }
                else if (e.Column.Name == "btnBack")
                {
                    try
                    {
                        if (MessageBox.Show("Are you sure ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            int ndc = int.Parse(e.Row.Cells["NDCNo"].Value.ToString());
                            SqlParameter[] prm =
                            {
                                new SqlParameter("@Task","Update_NDC_Sts"),
                                new SqlParameter("@NDCNo",ndc),
                                new SqlParameter("@NDCStatus","Verified"),
                                new SqlParameter("@UserID",clsUser.ID),
                                new SqlParameter("@UserName",clsUser.Name)
                        };
                            int rslt = cls_dl_TFR.TranferSetting(prm);
                            if (rslt > 0)
                            {
                                MessageBox.Show("Successfull.");
                                LoadDataForBasket();
                                LoadDataForTFRBasket();
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on grdReady_For_TFRAppointment_CellClick.", ex, "frmGenerateTFRAppointment");
                frmobj.ShowDialog();
            }
        }
        
        private bool datechecker()
        {
           if (dateofissue.Value < dt_Issue_NDC & dateofissue.Value >= dt_Expire_NDC)
            {
                return false;
            }
            
            else
            {
                return true;
            }
        }

        private void btnTFR_Appointment_Click(object sender, EventArgs e)
        {
            try
            {
                if(dateofexpire.Text != "" && grdCurrent_Members.RowCount > 0 && grdNew_Members.RowCount > 0)
                {
                    #region Code
                    if (datechecker())
                    {
                        #region Check Previous Transfer Appointment
                        SqlParameter[] prmt =
                        {
                        new SqlParameter("@Task", "Check_UnExpired_TFRAppointment"),
                        new SqlParameter("@NDCNo", NDCNo)
                        };
                        DataSet ds = cls_dl_TFRAppointment.TFRReader(prmt);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show("There is another Un-Expired Transfer Appointment against this NDCNo.");
                        }
                        else
                        {
                            if (MessageBox.Show("Are you sure ?", "Atention !", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                            {
                                #region Code

                                DateTime dt_Issue_TFRApp = dateofissue.Value.Date;
                                DateTime dt_Expir_TFRApp = dateofexpire.Value.Date;

                                if ((dt_Issue_TFRApp.Date >= dt_Issue_NDC.Date) && (dt_Expir_TFRApp.Date <= dt_Expire_NDC.Date))
                                {
                                    SqlParameter[] prmtr =
                                    {
                                     new SqlParameter("@Task", "Insert"),
                                     new SqlParameter("@FileMapKey", FileKey),
                                     new SqlParameter("@IssueDate", dateofissue.Value.Date),
                                     new SqlParameter("@ExpireDate", dateofexpire.Value.Date),
                                     new SqlParameter("@Status", "Active"),
                                     new SqlParameter("@NDCNo", NDCNo),
                                     new SqlParameter("@PurchaseTypeID", lblTypePurchaseNo.Text),
                                     new SqlParameter("@UserID",clsUser.ID),
                                     new SqlParameter("@UserName",clsUser.Name)
                                    };
                                    int rslt = 0;
                                    rslt = cls_dl_TFRAppointment.AppointmentNonQuery(prmtr);
                                    if (rslt > 0)
                                    {
                                        if (ForwardNDCToNextStep() == true)
                                        {
                                            //MessageBox.Show("Successfull.");
                                            //ForwardNDCToNextStep();
                                            #region SMS Sending
                                            //SqlParameter[] pr_m =
                                            //{
                                            //    new SqlParameter("@Task","GetDataForSMS"),
                                            //    new SqlParameter("@NDCNo", NDCNo),
                                            //};
                                            //DataSet dst = cls_dl_NDC.NdcRetrival(pr_m);
                                            //foreach (DataRow dr in dst.Tables[0].Rows)
                                            //{
                                            //    string mbno = dr["MobileNo"].ToString();

                                            //    //string resultString = null;
                                            //    try
                                            //    {
                                            //        Regex regexObj = new Regex(@"[^\d]");
                                            //        mbno = regexObj.Replace(mbno, "");
                                            //        Helper.clsPluginHelper.SMSSEnding(mbno, "Dear Customer your appointment date against NDCNo : " + NDCNo + "  is  " + dr["ExpireDate"].ToString());
                                            //    }
                                            //    catch (ArgumentException ex)
                                            //    {
                                            //        MessageBox.Show(ex.Message);
                                            //    }


                                            //   }

                                            #endregion
                                            this.dateofissue.NullableValue = null;
                                            this.dateofissue.SetToNullValue();
                                            this.dateofexpire.NullableValue = null;
                                            this.dateofexpire.SetToNullValue();
                                            Clear();
                                            btnTFR_Appointment.Enabled = false;
                                            LoadDataForBasket();
                                            LoadDataForTFRBasket();
                                            //grpb_Detail_Creat.Enabled = false;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Insertion Failed.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(
                                        "Issue Date of TFR Appointment must be Equall OR Less than Issue Date of NDC,AND Expire Date of TFR Appointment must be Less than OR equall than the Expire Date of NDC.");
                                }

                                #endregion
                            }
                        }

                        #endregion
                    }
                    else
                    {
                        MessageBox.Show("Date of Appointment Issue and Expire must be Greater or Equal to Current Date.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    #endregion
                }
                else
                {
                    MessageBox.Show("Seller , Buyer data and Appointment date must not be Null.","Error.",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                    
                

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnTFR_Appointment_Click.", ex, "frmGenerateTFRAppointment");
                frmobj.ShowDialog();

                //string strforminfo = String.Format("frmGenerateTFRAppointment {0} Event", "btnTFR_Appointment_Click");
                //cls_dl_ErrorLog.ErrorLogSAvetoDB(ex, strforminfo);
                //MessageBox.Show(ex.Message);
            }

        }
       
        private void btnForward_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    SqlParameter[] prm =
            //     {
            //        new SqlParameter("@Task","Update_NDC_Status"),
            //        new SqlParameter("@StatusofNDC","Complete"), // "Complete" mean that it is ReadyForTransfer
            //        new SqlParameter("@NDCNo",NDCNo)

            //        };
            //    int rsl = 0;
            //    rsl = cls_dl_NDC.NdcNonQuery(prm);
            //    if (rsl > 0)
            //    {
            //        MessageBox.Show("Forward to Transfer Successfully.");
            //        Clear();
            //        grpb_Detail_Creat.Enabled = false;
            //        LoadDataForBasket();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Contact with Administration.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnForward_Click.", ex, "frmGenerateTFRAppointment");
            //    frmobj.ShowDialog();
            //}
          
        }
        
        private bool ForwardNDCToNextStep()
        {
            bool vlbr = false;
            try
            {
                SqlParameter[] prm =
                 {
                    new SqlParameter("@Task","Update_NDC_StatusFin"),
                    new SqlParameter("@StatusofNDC","TFRAppGenerated"), // "Complete" mean that it is ReadyForTransfer
                    new SqlParameter("@NDCNo",NDCNo),
                    new SqlParameter("@UserID",clsUser.ID),
                    new SqlParameter("@UserName",clsUser.Name)

                    };
                int rsl = 0;
                rsl = cls_dl_NDC.NdcNonQuery(prm);
                if (rsl > 0)
                {
                    MessageBox.Show("Successfull.");
                    Clear();
                    //grpb_Detail_Creat.Enabled = false;
                    LoadDataForBasket();
                    vlbr = true;
                }
                else
                {
                    MessageBox.Show("Contact with Administration.");
                    vlbr = false;
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnForward_Click.", ex, "frmGenerateTFRAppointment");
                frmobj.ShowDialog();
            }
            return vlbr;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {

                if(NDCNo > 0)
                {
                    frmGoBackRemarks_Wth_Notification frm = new frmGoBackRemarks_Wth_Notification();
                    frm.ShowDialog();
                    //if (MessageBox.Show("Are you sure ?", "Atention !", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    //{
                    if (clsNDC.goBackRemarks.Length > 0)
                    {
                        SqlParameter[] prm =
                        {
                            new SqlParameter("@Task","Update_NDC_StatusFin"),
                            new SqlParameter("@StatusofNDC","Verified"),
                            new SqlParameter("@GoBack_Remarks","request from transfer branch to finance branch for ndc modification :" +
                                                                                             Environment.NewLine +clsNDC.goBackRemarks),
                            new SqlParameter("@NDCNo",NDCNo),
                            new SqlParameter("@UserID",clsUser.ID),
                            new SqlParameter("@UserName",clsUser.Name)

                        };
                        int rsl = cls_dl_NDC.NdcNonQuery(prm);
                        if (rsl > 0)
                        {
                            clsNDC.goBackRemarks = "";
                            LoadDataForBasket();
                            LoadDataForTFRBasket();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Remarks.");
                    }
                }
                else
                {
                    MessageBox.Show("Please Select NDC First.");
                }
              

                //rsl = cls_dl_NDC.NdcNonQuery(prm);
                //if (rsl > 0)
                //{
                //    MessageBox.Show("Back Successfully.");
                //    Clear();
                //    LoadDataForBasket();
                //    //grpb_Detail_Creat.Enabled = false;
                //}
                //else
                //{
                //    MessageBox.Show("Contact with Administration.");
                //}
                //}
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnBack_Click.", ex, "frmGenerateTFRAppointment");
                frmobj.ShowDialog();
                //string strforminfo = String.Format("frmGenerateTFRAppointment {0} Event", "btnBack_Click");
                //cls_dl_ErrorLog.ErrorLogSAvetoDB(ex, strforminfo);
                //MessageBox.Show(ex.Message);
            }
           
        }
      
        
        private void Clear()
        {
            txtNDCNo.Text = "";
            txtExpireDate.Text = "";
            txtIssueDate.Text = "";
            grdCurrent_Members.DataSource = null;
            grdNew_Members.DataSource = null;
            //grdCurrent_Members.Rows.Clear();
            //grdNew_Members.Rows.Clear();
            dateofissue.Value = DateTime.Now;
            dateofexpire.Value = DateTime.Now;
            dateofissue.MinDate = DateTime.Now;
            dateofexpire.MaxDate = DateTime.Now;
            lblTypePurchaseName.Text = "";
            lblTypePurchaseNo.Text = "";
            //dateofissue.SetToNullValue();
            dateofexpire.SetToNullValue();

        }

        private void bnt_Refresh_Click(object sender, EventArgs e)
        {
            LoadDataForBasket();
            LoadDataForTFRBasket();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataForTFRBasket();
            LoadDataForBasket();
        }

        private void chkClear_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkClear.CheckState == CheckState.Checked)
            {
                dtpappdate.SetToNullValue();
            }
        }

        private void grdReady_For_Transfer_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                 if (e.Column.Name == "CreateTFR")
                {
                    dateofexpire.SetToNullValue();
                    dateofissue.SetToNullValue();
                    lblTypePurchaseName.Text = "-";
                    btnTFR_Appointment.Enabled = false;
                    NDCNo_tfr = e.Row.Cells["NDCNo"].Value == null ? 0 : int.Parse(e.Row.Cells["NDCNo"].Value.ToString());
                    NDCNo = e.Row.Cells["NDCNo"].Value == null ? 0 : int.Parse(e.Row.Cells["NDCNo"].Value.ToString());
                    txtNDCNo.Text = e.Row.Cells["NDCNo"].Value.ToString() == null ? "0" : e.Row.Cells["NDCNo"].Value.ToString();
                    txtIssueDate.Text = e.Row.Cells["DateIssue"].Value.ToString();
                    txtExpireDate.Text = e.Row.Cells["NDCExpireDate"].Value.ToString();
                    
                    #region New Members Against NDCNo_tfr
                    SqlParameter[] prm =
                    {
                    new SqlParameter("@Task","Get_Info_For_Transfer"),
                    new SqlParameter("@NDCNo",NDCNo_tfr)
                    };
                    dst1 = cls_dl_NDC.NdcRetrival(prm);
                    if (dst1.Tables[0].Rows.Count > 0)
                    {

                        grdCurrent_Members.DataSource = dst1.Tables[0].DefaultView;
                        grdNew_Members.DataSource = dst1.Tables[1].DefaultView;

                    }
                    #endregion
                }
                else if (e.Column.Name == "btnModifyAppDate")
                {
                    DateTime ndcexp = DateTime.Parse(e.Row.Cells["NDCExpireDate"].Value.ToString());
                    DateTime ndcissue = DateTime.Parse(e.Row.Cells["DateIssue"].Value.ToString());
                    DateTime apptmntdate = DateTime.Parse(e.Row.Cells["ExpireDate"].Value.ToString());
                    if (apptmntdate.Date >= ndcissue.Date && apptmntdate.Date <= ndcexp.Date)
                    {
                        int apptmntID = int.Parse(e.Row.Cells["TFRAppoimtmentID"].Value.ToString());
                        SqlParameter[] prmt =
                        {
                            new SqlParameter("@Task","UpdateAppDateFin"),
                            new SqlParameter("@ExpireDate",apptmntdate),
                            new SqlParameter("@TFRAppoimtmentID",apptmntID),
                            new SqlParameter("@UserID",clsUser.ID),
                            new SqlParameter("@UserName",clsUser.Name)
                        };
                        int rslt = cls_dl_TFRAppointment.AppointmentNonQuery(prmt);
                        if (rslt > 0)
                        {
                            MessageBox.Show("Successful.");
                            LoadDataForBasket();
                            LoadDataForTFRBasket();
                        }
                    }
                    else
                    {
                        MessageBox.Show("The Appointment Date must be Equall Or Greater then " + Environment.NewLine +
                                        "NDC Issue Date,NDC Issue Date,and Equall Or Less " + Environment.NewLine +
                                        "then the NDC Expire Date.", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else if (e.Column.Name == "btnNextToImage")
                {
                    try
                    {


                        if (grdCurrent_Members.RowCount > 0 && grdNew_Members.RowCount > 0)
                        {
                            if (e.Row.Cells["NDCNo"].Value.ToString() == grdNew_Members.Rows[0].Cells["NDCNo"].Value.ToString())
                            {
                            if (MessageBox.Show("Are you sure ,That Transfer Information is Correct !", "Confirmation !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                NDCNo_tfr = e.Row.Cells["NDCNo"].Value == null ? 0 : int.Parse(e.Row.Cells["NDCNo"].Value.ToString());
                                FileNo = e.Row.Cells["FileNo"].Value == null ? "0" : e.Row.Cells["FileNo"].Value.ToString();
                                TFRAppointmentNo = e.Row.Cells["TFRAppoimtmentID"].Value == null ? 0 : int.Parse(e.Row.Cells["TFRAppoimtmentID"].Value.ToString());
                                int filekey = e.Row.Cells["FileMapKey"].Value == null ? 0 : int.Parse(e.Row.Cells["FileMapKey"].Value.ToString());

                                //DataTable Buyer = BuyerGDInfor();
                                DataTable NDCSetting = NDCExpire();
                                DataTable TFRAppoinmentDt = TFRAppointment();
                                DataTable Seller = SellerGDInfor();
                                DataTable tbl_TransferTracking = TransferTracking();
                                SqlParameter[] parameter =
                                {
                             new SqlParameter("@Task","TransferSetting"),
                             new SqlParameter(){ ParameterName = "@NDCTable",SqlDbType = SqlDbType.Structured, SqlValue = NDCSetting},
                             new SqlParameter(){ ParameterName = "@TFRAppointment",SqlDbType = SqlDbType.Structured, SqlValue = TFRAppoinmentDt},
                             //new SqlParameter(){ ParameterName = "@BuyerOwnerTable",SqlDbType = SqlDbType.Structured, SqlValue = Buyer},
                             new SqlParameter(){ ParameterName = "@SellerOWnerTable",SqlDbType = SqlDbType.Structured, SqlValue = Seller},
                             new SqlParameter() { ParameterName = "@TransferTracking",SqlDbType = SqlDbType.Structured, SqlValue = tbl_TransferTracking }
                             };
                                int result = cls_dl_TFR.TranferSetting(parameter);
                                if (result > 0)
                                {
                                    MessageBox.Show("Successfull");
                                    Clear();
                                        //grb_Info.Enabled = false;
                                        LoadDataForBasket();
                                        LoadDataForTFRBasket();
                                        //frmTakeImage obj = new frmTakeImage(FileNo, NDCNo, PurchaseTypeID, SellerMSNOString, BuyerMSNOString);
                                        //obj.ShowDialog();
                                        //MessageBox.Show(result.ToString()+"\t successfull");
                                    }
                            }
                        }
                            else
                            {
                                MessageBox.Show("You are attempting for another NDC.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("There is no Seller and Buyer record in Table.","Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }

                    }
                    catch (Exception ex)
                    {
                        frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnSave_Click.", ex, "frmReadyForTransfer");
                        frmobj.ShowDialog();
                    }

                 }
                 else if(e.Column.Name == "btnDealCancel")
                 {
                    if (MessageBox.Show("Are you sure ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        int NDCNo_ = Convert.ToInt32(e.Row.Cells["NDCNo"].Value.ToString());
                        string FileNo = e.Row.Cells["FileNo"].Value.ToString();
                        SqlParameter[] prm =
                        {
                             new SqlParameter("@Task","UpdateNDCAndExpireDateFin"),
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
                            LoadDataForBasket();
                            LoadDataForTFRBasket();
                        }
                    }
                }
                else if (e.Column.Name == "btnBack")
                {
                    try
                    {
                        if (MessageBox.Show("Are you sure ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            int ndc = int.Parse(e.Row.Cells["NDCNo"].Value.ToString());
                            SqlParameter[] prm =
                            {
                        new SqlParameter("@Task","Update_NDC_Sts"),
                        new SqlParameter("@NDCNo",ndc),
                        new SqlParameter("@NDCStatus","ReadyForTFRAppointment"),
                        new SqlParameter("@UserID",clsUser.ID),
                        new SqlParameter("@UserName",clsUser.Name)
                        };
                            int rslt = cls_dl_TFR.TranferSetting(prm);
                            if (rslt > 0)
                            {
                                MessageBox.Show("Successfull.");
                                LoadDataForBasket();
                                LoadDataForTFRBasket();
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }

                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on grdReady_For_Transfer_CellClick.", ex, "frmReadyForTransfer");
                frmobj.ShowDialog();
            }
        }
        private DataTable SellerGDInfor()
        {
            DataTable Seller = new DataTable();
            DataTable_column OwnerID = new DataTable_column() { ColmnName = "OwnerID", type = typeof(int) };
            DataTable_column RateofSale = new DataTable_column() { ColmnName = "RateofSale", type = typeof(string) };
            DataTable_column DateofSell = new DataTable_column() { ColmnName = "DateofSell", type = typeof(string) };
            DataTable_column userID = new DataTable_column() { ColmnName = "userID", type = typeof(int) }; //PurchaseTypeID
            DataTable_column PurchaseType_ID = new DataTable_column() { ColmnName = "PurchaseType_ID", type = typeof(int) };

            List<DataTable_column> cols = new List<DataTable_column>();
            cols.Add(OwnerID);
            cols.Add(userID);
            cols.Add(RateofSale);
            cols.Add(DateofSell);
            cols.Add(PurchaseType_ID);
            Seller = clsPluginHelper.ColmnsCreateinDatatable(cols);
            if (grdNew_Members.Rows.Count > 0)
            {
                SellerMSNOString = "";
                int count_Seller = grdCurrent_Members.Rows.Count;
                int result = 0;
                for (int i = 0; i < count_Seller; i++)
                {
                    #region +++++++++++++++++++++++  Generate Sellers String  +++++++++++++++++++++++++++++++++++
                    SellerMSNOString = grdCurrent_Members.Rows[i].Cells["MembershipNo"].Value.ToString() + "," + SellerMSNOString;

                    //int id = grdNew_Members.Rows[i].Cells[3].Value;

                    if (i == 0)
                    {
                        PurchaseTypeID = int.Parse(grdNew_Members.Rows[i].Cells["PurchaseTypeID"].Value.ToString());
                    }
                    #endregion
                    string dateOfSale = DateTime.Now.ToString("dd/MM/yyyy");
                    int Owner_ID = int.Parse(grdCurrent_Members.Rows[i].Cells["OwnerID"].Value.ToString());
                    object RateofSell = grdCurrent_Members.Rows[i].Cells["RateofSale"].Value == null ? clsPluginHelper.DbNullIfNullOrEmpty("0") : grdCurrent_Members.Rows[i].Cells["RateofSale"].Value.ToString();
                    // OwnerID  |  UserID         |  RateofSell | DateofSale
                    int typePurchaseID = PurchaseTypeID;
                    Seller.Rows.Add(Owner_ID, Models.clsUser.ID, RateofSell, dateOfSale, typePurchaseID);
                }
                return Seller;  //DataTable with Data  
            }
            else
            {
                return Seller; //Empty DataTable 
            }
        }
        private DataTable NDCExpire()
        {
            DataTable NDCSetting = new DataTable();
            try
            {
                DataTable_column _NDCNo = new DataTable_column() { ColmnName = "NDCNo", type = typeof(int) };
                DataTable_column NDCStatus = new DataTable_column() { ColmnName = "NDCStatus", type = typeof(string) };
                DataTable_column userID = new DataTable_column() { ColmnName = "userID", type = typeof(int) };
                List<DataTable_column> cols = new List<DataTable_column>();
                cols.Add(_NDCNo);
                cols.Add(NDCStatus);
                cols.Add(userID);
                NDCSetting = clsPluginHelper.ColmnsCreateinDatatable(cols);
                DataRow row = NDCSetting.NewRow();
                row["NDCNo"] = NDCNo_tfr;
                row["userID"] = clsUser.ID;
                row["NDCStatus"] = "Use_For_Transfer";
                NDCSetting.Rows.Add(row);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on NDCExpire.", ex, "frmReadyForTransfer");
                frmobj.ShowDialog();
            }

            return NDCSetting;

        }
        private DataTable TFRAppointment()
        {
            DataTable TFRAppointmentDS = new DataTable();
            try
            {
                DataTable_column TFRAppoimtmentID = new DataTable_column() { ColmnName = "TFRAppoimtmentID", type = typeof(int) };
                DataTable_column ExpireDate = new DataTable_column() { ColmnName = "ExpireDate", type = typeof(string) };
                DataTable_column Status = new DataTable_column() { ColmnName = "Status", type = typeof(string) };
                DataTable_column userID = new DataTable_column() { ColmnName = "userID", type = typeof(int) };
                List<DataTable_column> cols = new List<DataTable_column>();
                cols.Add(TFRAppoimtmentID);
                cols.Add(ExpireDate);
                cols.Add(Status);
                cols.Add(userID);
                TFRAppointmentDS = clsPluginHelper.ColmnsCreateinDatatable(cols);
                DataRow row = TFRAppointmentDS.NewRow();
                row["TFRAppoimtmentID"] = TFRAppointmentNo;
                row["ExpireDate"] = DateTime.Now.ToString("MM/dd/yyyy");
                row["userID"] = clsUser.ID;
                row["Status"] = "Expire";
                TFRAppointmentDS.Rows.Add(row);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on TFRAppointment.", ex, "frmReadyForTransfer");
                frmobj.ShowDialog();
            }

            return TFRAppointmentDS;

        }
        private DataTable TransferTracking()
        {
            BuyerMSNOString = "";
            int count_Buyer = grdNew_Members.Rows.Count;
            for (int i = 0; i < count_Buyer; i++)
            {
                //object str = grdNew_Members.Rows[i].Cells[8].Value == null ? clsPluginHelper.DbNullIfNullOrEmpty("") : grdNew_Members.Rows[i].Cells[8].Value.ToString();
                #region ++++++++++++++++++++++  Creat "BuyerMSNOString(BuyersNameString)"  +++++++++++++++++++++++
                BuyerMSNOString = grdNew_Members.Rows[i].Cells["Name"].Value.ToString() + "," + BuyerMSNOString;
                //PurchaseTypeID = int.Parse(grdNew_Members.Rows[i].Cells["TypeID"].Value.ToString());
                #endregion
            }
            DataTable tbl_TransferTracking = new DataTable();
            try
            {
                DataTable_column TFR_Status = new DataTable_column() { ColmnName = "TFR_Status", type = typeof(string) };
                DataTable_column SellerMS_String = new DataTable_column() { ColmnName = "SellerMS_String", type = typeof(string) };
                DataTable_column BuyerMS_String = new DataTable_column() { ColmnName = "BuyerMS_String", type = typeof(string) };
                DataTable_column NDCNo_col = new DataTable_column() { ColmnName = "NDCNo", type = typeof(int) };
                DataTable_column File_No = new DataTable_column() { ColmnName = "FileNo", type = typeof(string) };
                DataTable_column Purchase_TypeID = new DataTable_column() { ColmnName = "PurchaseTypeID", type = typeof(int) };
                DataTable_column TransferDate = new DataTable_column() { ColmnName = "TransferDate", type = typeof(DateTime) };
                List<DataTable_column> cols = new List<DataTable_column>();
                cols.Add(TFR_Status);
                cols.Add(SellerMS_String);
                cols.Add(BuyerMS_String);
                cols.Add(NDCNo_col);
                cols.Add(File_No);
                cols.Add(Purchase_TypeID);
                cols.Add(TransferDate);
                tbl_TransferTracking = clsPluginHelper.ColmnsCreateinDatatable(cols);
                DataRow row = tbl_TransferTracking.NewRow();
                row["TFR_Status"] = "ReadyForPicture";
                row["SellerMS_String"] = SellerMSNOString.Remove(SellerMSNOString.Length - 1);
                row["BuyerMS_String"] = BuyerMSNOString.Remove(BuyerMSNOString.Length - 1);
                row["NDCNo"] = NDCNo_tfr;
                row["FileNo"] = FileNo;
                row["PurchaseTypeID"] = PurchaseTypeID;
                row["TransferDate"] = clsPluginHelper.DbNullIfNullOrEmpty("");
                tbl_TransferTracking.Rows.Add(row);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on TransferTracking.", ex, "frmReadyForTransfer");
                frmobj.ShowDialog();
            }

            return tbl_TransferTracking;

        }

        private void grdReady_For_TFRAppointment_CellFormatting(object sender, CellFormattingEventArgs e)
        {

        }

        private void grdExpireNDCs_CellClick(object sender, GridViewCellEventArgs e)
        {
            if(e.Column.Name == "btnSendToFinance")
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
                        MessageBox.Show("NDC is sended to Finance branch successfully.");
                        LoadDataForBasket();
                    }
                }
                
            }
            else if (e.Column.Name == "btnDealCancel")
            {
                if (MessageBox.Show("Are you sure ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int NDCNo_ = Convert.ToInt32(e.Row.Cells["NDCNo"].Value.ToString());
                    string FileNo = e.Row.Cells["FilePlotNo"].Value.ToString();
                    SqlParameter[] prm =
                    {
                             new SqlParameter("@Task","UpdateNDCAndExpireDateFin"),
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
                        LoadDataForBasket();
                    }
                }
            }
        }

        private void chkCLear_chk_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkCLear_chk.Checked)
            {
                if(MessageBox.Show("Are you sure ?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    txtNDCNo.Text = "";
                    txtIssueDate.Text = "";
                    txtExpireDate.Text = "";
                    NDCNo = 0;
                    grdCurrent_Members.DataSource = null;
                    grdNew_Members.DataSource = null;
                }
            }
        }

        private void grdExpireNDCs_Click(object sender, EventArgs e)
        {

        }
    }
}
