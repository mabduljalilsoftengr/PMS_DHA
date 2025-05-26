using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Application_Layer.FileMap.ByBack;
using PeshawarDHASW.Application_Layer.FileMap.SvcBenefitFiles;
using PeshawarDHASW.Application_Layer.FileMap.TradeOff;
using PeshawarDHASW.Data_Layer.clsFileMap;
using PeshawarDHASW.Data_Layer.clsSector;
using PeshawarDHASW.Data_Layer.Installment;
using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.FileMap.LandBrFile
{
    public partial class frmLandBrFileCreate : Telerik.WinControls.UI.RadForm
    {
        public frmLandBrFileCreate()
        {
            InitializeComponent();
        }
        public int FileMapKey { get; set; }
        public frmLandBrFileCreate(int FileMapkey)
        {
            FileMapKey = FileMapkey;
            InitializeComponent();
            loadfill(FileMapKey);
        }


        private void frmLandBrFileCreate_Load(object sender, EventArgs e)
        {
            txtAmalgamationFileNo.Enabled = false;
            // radGroupBox1.Enabled = false;
            Filddl_ownerCategory();
            PlotSizeLoad();

            //   OwnerCategory.SelectedItem.Text = "Investors";
            Fill_ddlplotbuisinesstype();
            Fill_ddlInvestorList();
            Filddl_subownerCategory();
            Filddl_Sector();
            dpPlotSize.SelectedIndex = 0;
            //  ddlplotbuisinesstype.SelectedItem.Text = "Residential";
            filestatus.SelectedIndex = 0;

            LandBrIssueDate.MinDate = DateTime.Now.AddYears(-3);
            LandBrIssueDate.Value = clsMostUseVars.ServerDateTime;
            LandBrIssueDate.MaxDate = clsMostUseVars.ServerDateTime;
            clsPluginHelper.RadDropDownSelectByText(OwnerCategory, "Investors");
            clsPluginHelper.RadDropDownSelectByText(ddlplotbuisinesstype, "Residential");
            clsPluginHelper.RadDropDownSelectByText(rdd_SubCategory, "Normal");
            //OwnerCategory.SelectedIndex = 0;
            //ddlplotbuisinesstype.SelectedIndex = 0;
        }

        /// <summary>
        /// Group Template Selection on the base of Plot Size and File Category (Investor, Ballot, Svc Benefit)
        /// </summary>
        /// <returns>TemplateGroupKey</returns>
        public DataSet InstTempandTemplateGroupIDs { get; set; }
        private DataSet InstallmentPlanGroupGroupKeyValue(SqlTransaction sqltrans)
        {
            DataSet ds = null;
            if (dpPlotSize.Text=="5 Marla")
            {
                ds = SQLHelper.ExecuteDataset(sqltrans
                                     , CommandType.Text
                                     , @"SELECT TOP 1 it.InstalTempID,itg.PlanGroupID
                                         FROM dbo.tbl_InstallmentTemplate AS it
                                         INNER JOIN dbo.tbl_InstallmentTemplateGroup AS itg ON it.PlanGroupID = itg.PlanGroupID
                                         WHERE itg.Category LIKE '" + OwnerCategory.Text + "' AND itg.PlotSize LIKE '" + dpPlotSize.Text + "' AND it.Name LIKE'5 Marla Investor Plan' ORDER BY it.InstalTempID asc");
            }
            else
            {
                ds = SQLHelper.ExecuteDataset(sqltrans
                        , CommandType.Text
                        , @"SELECT TOP 1 it.InstalTempID,itg.PlanGroupID
                                        FROM dbo.tbl_InstallmentTemplate AS it
                                        INNER JOIN dbo.tbl_InstallmentTemplateGroup AS itg ON it.PlanGroupID = itg.PlanGroupID
                                        WHERE itg.Category LIKE '" + OwnerCategory.Text + "' AND itg.PlotSize LIKE '" + dpPlotSize.Text + "' ORDER BY it.InstalTempID asc");
            }

            return ds;
        }
        /// <summary>
        /// Creating a New Template using Default FileNo and User Name Attached
        /// These Plan have 45 days Gap to Start.
        /// This is will use for Plan Generation
        /// </summary>
        /// <returns>TemplateKey</returns>
        private string SavingclsInstallmentTemplate(SqlTransaction sqltrans)
        {
            try
            {
                DateTime ScheduleDate = LandBrIssueDate.Value.AddDays(45);

                string TemplateName = " Schedule is Attach with FileNo : " + txtfileno.Text + "by UserName=" + Models.clsUser.Name + " Issue:" + DateTime.Now.ToString("ddMMyyyyhhmmss");
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task","insert"),
                    new SqlParameter("@Name", clsPluginHelper.DbNullIfNullOrEmpty(TemplateName)),
                    new SqlParameter("@Descp", clsPluginHelper.DbNullIfNullOrEmpty(TemplateName)),
                    new SqlParameter("@StartDate",ScheduleDate),
                    new SqlParameter("@Phase", clsPluginHelper.DbNullIfNullOrEmpty("1")),
                    new SqlParameter("@PlotSize", clsPluginHelper.DbNullIfNullOrEmpty(dpPlotSize.Text)),
                    new SqlParameter("@userID", Models.clsUser.ID),
                    new SqlParameter("@PlanGroupID", InstTempandTemplateGroupIDs.Tables[0].Rows[0]["PlanGroupID"].ToString())
                };
                int result = 0;
                result = SQLHelper.ExecuteNonQuery(
                                                sqltrans,
                                                 CommandType.StoredProcedure,
                                                 "App.USP_InstallmentTemplate",
                                                 parameters
                                                 );
                //clsInstallmentTemplate.InstalTemplate_NonQuery(parameters);
                if (result > 0)
                {
                    SqlParameter[] parameterID =
                    {
                       new SqlParameter("@Task", "PlanKey"), // Get the New Generated Installment Template Key
                       new SqlParameter("@Name", clsPluginHelper.DbNullIfNullOrEmpty(TemplateName)),
                    };
                    //if Save than Return Value
                    DataSet dt = SQLHelper.ExecuteDataset(
                                                   sqltrans,
                                                    CommandType.StoredProcedure,
                                                    "App.USP_InstallmentTemplate",
                                                    parameterID
                                                    );
                    // clsInstallmentTemplate.InstalTemplate_Reader(parameterID);
                    return dt.Tables[0].Rows[0]["InstalTempID"].ToString();
                }
                else
                {
                    MessageBox.Show("Unable to save record Please contact to the Administrator!.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on SavingclsInstallmentTemplate.", ex, "InstTemplateCreate");
                frmobj.ShowDialog();
            }
            return "";
        }



        private void PlanGenerationData(SqlTransaction sqlTrans)
        {
            try
            {

                InstTempandTemplateGroupIDs = InstallmentPlanGroupGroupKeyValue(sqlTrans); //Get the Old InstallmentTemplate(Made From) Key
                string Templatekey = SavingclsInstallmentTemplate(sqlTrans); //Get the New Generated Installment Template Key
                int monthGap = 3;
                // if (OwnerCategory.Text == "Investors")
                // {
                //     monthGap = 3;
                // }
                //else if (OwnerCategory.Text == "Ballot")
                // {
                //     monthGap = 3;
                // }
                DateTime StartingDate = LandBrIssueDate.Value.AddDays(45);

                SqlParameter[] param =
                {
                            new SqlParameter("@Task", "InsertTemplate"),
                            new SqlParameter("@FromPlanID", InstTempandTemplateGroupIDs.Tables[0].Rows[0]["InstalTempID"].ToString()),
                            new SqlParameter("@ToPlanID", Templatekey),
                            new SqlParameter("@GapInterval", monthGap),
                            //DateTime Var  LandBrIssueDate.Value
                            new SqlParameter("@StarDate",StartingDate),
                        };
                DataSet _dsPhase = SQLHelper.ExecuteDataset(
                                           sqlTrans,
                                            CommandType.StoredProcedure,
                                            "App.USP_CreateInstallmentPlan",
                                            param
                                            ); //clsInstallmentTemplate.CreateInsallmentTemplate(param);

                SqlParameter[] param1 =
                {
                         new SqlParameter("@Task","AttachPlantoFile"),
                        //new SqlParameter("@FileMapKey",Helper.clsPluginHelper.DbNullIfNullOrEmpty( FileMapKey.ToString())),
                        new SqlParameter("@FileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty( txtfileno.Text)),
                        new SqlParameter("@InstalTempID", Templatekey),
                        new SqlParameter("@userID", Models.clsUser.ID),
                     //   new SqlParameter("@TemplateInstKey",ddlInstallmentTemplate.SelectedValue), 

                        };
                int result = 0;
                result = SQLHelper.ExecuteNonQuery(
                                            sqlTrans,
                                            CommandType.StoredProcedure,
                                            "App.USP_InstallmentTemplate",
                                            param1
                                            );
                //cls_dl_instPlan.InstalPlan_NonQuery(param1, "App.USP_InstallmentTemplate");
                if (_dsPhase.Tables.Count > 0)
                {
                    if (_dsPhase.Tables[0].Rows.Count > 0)
                    {

                        //  MessageBox.Show("New Installment Plan successfully Created.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("New Installment Plan Failed. Please contact support.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                sqlTrans.Rollback();
                MessageBox.Show(ex.Message);
            }
        }
        private void loadfill(int ID)
        {
            try
            {


                SqlParameter[] searchparam =
                {
                    new SqlParameter("@Task", "select"),
                    new SqlParameter("@FileMapKey", ID.ToString())
                };
                DataSet ds = cls_dl_FileMap.FileMap_Reader(searchparam);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    txtfileno.Text = row["FileNo"].ToString();

                    txtplotno.Text = row["PlotNo"].ToString();
                    txtremarks.Text = row["Remarks"].ToString();
                    dpPlotSize.Text = row["PlotSize"].ToString();
                    //dpPlotSize.SelectedIndex = str == "10 Marla" ? 0 : -1;
                    filestatus.SelectedIndex = row["Status"].ToString() == "Active" ? 0 : 1;

                    //  ddlInstallmentTemplate.SelectedValue = instmentID;
                    ddlplotbuisinesstype.SelectedValue = int.Parse(row["PBTID"].ToString());
                    OwnerCategory.SelectedValue = int.Parse(row["OCID"].ToString());

                    ///////////////PLAN ATTACHEMENT//////////////////////
                    LandProviderName.Text = row["InvestorName"].ToString();
                    txtFirstBuyerName.Text = row["FirstBuyerName"].ToString();
                    if (!string.IsNullOrEmpty(row["LandBrIssueDate"].ToString()))
                    {
                        LandBrIssueDate.Value = DateTime.Parse(row["LandBrIssueDate"].ToString());
                    }
                    LandProviderName.Text = row["LandProviderName"].ToString();
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on loadfill.", ex, "frmCreateFileNoRPlot");
                frmobj.ShowDialog();
            }
        }
        private void Filddl_subownerCategory()
        {
            try
            {
                SqlParameter[] par =
                {
                new SqlParameter("@Task","SubCategoryData"),
                };
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_tbl_FileMap", par);
                rdd_SubCategory.DataSource = ds.Tables[0].DefaultView;
                rdd_SubCategory.ValueMember = "OwnerSubCategoryID";
                rdd_SubCategory.DisplayMember = "SubCategoryName";
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Filddl_ownerCategory.", ex, "frmCreateFileNoRPlot");
                frmobj.ShowDialog();
            }
        }
        private void Filddl_ownerCategory()
        {
            try
            {
                SqlParameter[] par =
                {
                new SqlParameter("@Task","Select"),
                };
                DataSet ds = new DataSet();
                ds = cls_dl_FileMap.Fil_ddl_Owner_Category(par);
                OwnerCategory.DataSource = ds.Tables[0].DefaultView;
                OwnerCategory.ValueMember = "OCID";
                OwnerCategory.DisplayMember = "Category_Name";
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Filddl_ownerCategory.", ex, "frmCreateFileNoRPlot");
                frmobj.ShowDialog();
            }


        }
        private void PlotSizeLoad()
        {
            try
            {
                SqlParameter[] par =
                {
                new SqlParameter("@Task","SelectPlotSize"),
                };
                DataSet ds = new DataSet();
                ds = cls_dl_FileMap.Fil_ddl_Owner_Category(par);
                dpPlotSize.DataSource = ds.Tables[0].DefaultView;
                dpPlotSize.ValueMember = "ID";
                dpPlotSize.DisplayMember = "PlotSize";
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Filddl_ownerCategory.", ex, "frmCreateFileNoRPlot");
                frmobj.ShowDialog();
            }
        }
        private void Fill_ddlInvestorList()
        {
            try
            {
                SqlParameter[] par =
                {
                new SqlParameter("@Task","InvestorList"),
                };
                DataSet ds = cls_dl_FileMap.FileMap_Reader(par);
                InvestorNameList.ValueMember = "LPID";
                InvestorNameList.DisplayMember = "LandProviderName";
                InvestorNameList.DataSource = ds.Tables[0].DefaultView;

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LandProviderList.", ex, "frmCreateFileNoRPlot");
                frmobj.ShowDialog();
            }

        }
        private void Fill_ddlplotbuisinesstype()
        {
            try
            {
                SqlParameter[] par =
           {
             new SqlParameter("@Task","Select"),
            };
                DataSet ds = new DataSet();
                //ddlplotbuisinesstype.Items.Insert(0, new RadListDataItem("Select"));
                ddlplotbuisinesstype.DataSource = cls_dl_FileMap.Fill_ddlPlot_Buisiness_Type(par).Tables[0].DefaultView;
                ddlplotbuisinesstype.ValueMember = "PBTID";
                ddlplotbuisinesstype.DisplayMember = "TypeName";

                // ddlplotbuisinesstype.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Fill_ddlplotbuisinesstype.", ex, "frmCreateFileNoRPlot");
                frmobj.ShowDialog();
            }

        }
        private void Filddl_Sector()
        {
            try
            {
                SqlParameter[] par =
                {
                new SqlParameter("@Task","SelectSector"),
                };
                DataSet ds = new DataSet();
                ds = cls_dl_Sector.Sector_Reader(par);
                ddlSector.DataSource = ds.Tables[0].DefaultView;
                ddlSector.ValueMember = "Sector_ID";
                ddlSector.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Filddl_Sector.", ex, "frmCreateFileNoRPlot");
                frmobj.ShowDialog();
            }


        }

        private void btnSaveandprinttheschedule_Click(object sender, EventArgs e)
        {
            string ownerCategory = OwnerCategory.SelectedItem.Text;//.SelectedItem.Text;
            string plottype = ddlplotbuisinesstype.SelectedItem.Text;//.SelectedItem.Text;
            string PlotSize = dpPlotSize.SelectedItem.Text;
            bool suspended = false;///this will be removed once schedual is done.

            if (string.IsNullOrWhiteSpace(txtfileno.Text))
            {
                MessageBox.Show("FileNo is Missing. Please Enter File No.");
                txtfileno.Focus();
                return;
            }

            if (rdIsAmalgamation.CheckState == CheckState.Checked && string.IsNullOrWhiteSpace(txtAmalgamationFileNo.Text))
            {
                MessageBox.Show("Amalgamation Parent File is Missing Please Enter Amalgamation File No.");
                txtAmalgamationFileNo.Focus();
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtplotno.Text))
            {
                int Index1st = txtplotno.Text.IndexOf('/') + 1;
                string PlotNoNewSet = txtplotno.Text.Replace(txtplotno.Text.Substring(0, Index1st), "");
                int LastIndex = PlotNoNewSet.IndexOf('/');
                int lengthofArry = txtplotno.Text.Length - (Index1st + LastIndex);
                string repl = PlotNoNewSet.Substring(LastIndex, lengthofArry);
                string LastPlotNo = PlotNoNewSet.Replace(repl, "").ToUpper();
                string Sector = ddlSector.SelectedItem.Text.ToUpper();

                if (Sector.Contains(LastPlotNo) == false)
                {
                    MessageBox.Show("Sector Selection is Not Match with Plot No.");
                    return;
                }
            }

            //if (string.IsNullOrWhiteSpace(LandProviderName.Text))
            //{
            //    MessageBox.Show("Land Provider Name is Missing. Please Enter File No.");
            //    return;
            //}
            //if (string.IsNullOrWhiteSpace(LandProviderFather.Text))
            //{
            //    MessageBox.Show("Land Provider Father is Missing. Please Enter File No.");
            //    return;
            //}
            //if (txtfileno.Text.ToUpper().Contains("COM") == true && (ownerCategory=="Investors" || plottype == "Residential"))
            //{
            //    MessageBox.Show("Please Change the Owner Category of File.");
            //    return;
            //}

            using (SqlConnection Objcon = Helper.SQLHelper.createConnection())
            {

                using (SqlTransaction sqlTrans = Objcon.BeginTransaction("LandBrFileSaving"))
                {
                    try
                    {
                        if (string.IsNullOrWhiteSpace(txtfileno.Text))
                        {
                            MessageBox.Show("FileNo is Missing. Please Enter File No.");
                            txtfileno.Focus();
                            return;
                        }
                        //if (txtfileno.Text.ToUpper().Contains("COM") == true && rdbnodirectsale.CheckState == CheckState.Checked)
                        //{
                        //    MessageBox.Show("Please Change the Sale Option of File.");
                        //    return;
                        //}

                        //File No Verification
                        SqlParameter[] searchparamFile ={  new SqlParameter("@Task","select"),
                                 new SqlParameter("@FileNo", clsPluginHelper.DbNullIfNullOrEmpty(txtfileno.Text)) };
                        DataSet dsFile = SQLHelper.ExecuteDataset(sqlTrans,
                                                    CommandType.StoredProcedure,
                                                    "App.USP_tbl_FileMap",
                                                    searchparamFile
                                                    );
                        #region File Existing Checked
                        if (dsFile.Tables[0].Rows.Count == 0)
                        {
                            //  btnSaveandprinttheschedule.Enabled = true;
                            string isoversundsz = "";
                            if (rdbnormal.IsChecked) { isoversundsz = rdbnormal.Text; }
                            else if (rdboversize.IsChecked) { isoversundsz = rdboversize.Text; }
                            else if (rdbundersize.IsChecked) { isoversundsz = rdbundersize.Text; }
                            string isdirectsale = rdbnodirectsale.IsChecked ? "No" : "Yes";
                            SqlParameter[] parameters =
                            {
                                new SqlParameter("@Task", "insert"),
                                new SqlParameter("@FileNo", clsPluginHelper.DbNullIfNullOrEmpty( txtfileno.Text)),
                                new SqlParameter("@PlotNo", clsPluginHelper.DbNullIfNullOrEmpty( txtplotno.Text)),
                                new SqlParameter("@Remarks", clsPluginHelper.DbNullIfNullOrEmpty( txtremarks.Text)),
                                new SqlParameter("@PlotSize", clsPluginHelper.DbNullIfNullOrEmpty( dpPlotSize.Text)),
                                new SqlParameter("@Status", clsPluginHelper.DbNullIfNullOrEmpty( filestatus.Text)),
                                new SqlParameter("@PlotBusinessTypeID",ddlplotbuisinesstype.SelectedValue),
                                new SqlParameter("@TFRTypeID",1),
                                new SqlParameter("@OwnerCategoryID",OwnerCategory.SelectedValue),
                                new SqlParameter("@userID",Models.clsUser.ID),
                                new SqlParameter("@InvestorName",clsPluginHelper.DbNullIfNullOrEmpty( InvestorNameList.SelectedItem.Text)),
                                new SqlParameter("@FirstBuyerName",clsPluginHelper.DbNullIfNullOrEmpty( txtFirstBuyerName.Text)),
                                new SqlParameter("@LandBrIssueDate",LandBrIssueDate.Value),
                                new SqlParameter("@LandProviderName",clsPluginHelper.DbNullIfNullOrEmpty(LandProviderName.Text)),
                                new SqlParameter("@IsOversizeUndersize",isoversundsz == "Normal" ? null : isoversundsz),
                                new SqlParameter("@Extra_Less_Area",rdbundersize.IsChecked ? "-"+ txtextralessarea.Text : txtextralessarea.Text),
                                new SqlParameter("@IsDirectSale",isdirectsale),
                                new SqlParameter("@Addresss",FirstOwnerAddress.Text),
                                new SqlParameter("@MobileNos",FirstOwnerMobile.Text),
                                new SqlParameter("@InvestorFathers",LandProviderFather.Text),
                                new SqlParameter("@CNICNos",FirstOwnerCNIC.Text),
                                new SqlParameter("@MultipleOwner", chkMultiOwnercheck.CheckState== CheckState.Checked? 1 :0),
                                new SqlParameter("@Phase1Ex",rdph1Extension.IsChecked ==  true? 1 : 0),
                                //new SqlParameter("@IsExchangeSwapOver",rdIsSwapOver_Exchange.IsChecked ==  true? 1 : 0),
                               // new SqlParameter("@IsExchange",rdIsExchange.IsChecked ==  true? 1 : 0),
                                new SqlParameter("@IsAmalgamation",rdIsAmalgamation.IsChecked ==  true? 1 : 0),
                                new SqlParameter("@Amal_ParentFileNo",txtAmalgamationFileNo.Text),
                                new SqlParameter("@SubOwnerCategory", rdd_SubCategory.Text),
                                 new SqlParameter("@Sector_ID",ddlSector.SelectedValue.ToString()),
                        };

                            DataSet result = SQLHelper.ExecuteDataset(sqlTrans, CommandType.StoredProcedure, "App.USP_tbl_FileMap", parameters);

                            #region Allotment and Plot Saving of File
                            if (result.Tables[1].Rows.Count > 0)
                            {
                                string allotmsg = result.Tables[1].Rows[0]["Message"].ToString();
                                string Conditionform = result.Tables[1].Rows[0]["ConditionalDetail"].ToString();
                                string AttachRemarks = result.Tables[1].Rows[0]["AttachRemarks"].ToString();

                                if (!string.IsNullOrWhiteSpace(txtplotno.Text))
                                {

                                    if (Conditionform.Contains("OpenForm"))
                                    {
                                        //Verification required
                                        MessageBox.Show(result.Tables[1].Rows[0]["Message"].ToString());
                                        DataSet ds = new DataSet();
                                        DataTable dt = new DataTable();
                                        dt = result.Tables[1];
                                        result.Tables.Remove(result.Tables[1]);
                                        ds.Tables.Add(dt);
                                        frmfileplotallotment frm_plotallot = new frmfileplotallotment(
                                            txtfileno.Text, txtplotno.Text, dpPlotSize.Text
                                             , Convert.ToInt32(ddlplotbuisinesstype.SelectedValue)
                                             , Convert.ToInt32(ddlSector.SelectedValue)
                                             , Convert.ToString(LandBrIssueDate.Value)
                                             , txtremarks.Text, AttachRemarks, ds);

                                        frm_plotallot.ShowDialog();
                                    }
                                    else
                                    {
                                        MessageBox.Show(result.Tables[1].Rows[0]["Message"].ToString());
                                        //TemplateCreationforFile
                                    }
                                }
                            }
                            #endregion
                          
                            if (result.Tables[0].Rows.Count > 0)
                            {
                                if (txtfileno.Text.ToUpper().Contains("COM") != true && ownerCategory == "Investors"
                                    && plottype == "Residential" && (PlotSize == "1 Kanal" || PlotSize == "5 Marla")
                                    )
                                {
                                    if (rdbnodirectsale.CheckState == CheckState.Checked)
                                    {
                                        sqlTrans.Commit(); //this line and if condition is added for temprory schedual print suspension, the line will be removed after once done
                                        if (suspended == true)  //this line and if condition is added for temprory schedual print suspension, the line will be removed after once done
                                        {
                                            PlanGenerationData(sqlTrans);
                                            sqlTrans.Commit();
                                            //Plan Generation
                                            Report.ScheuldeCopy.frmSchedulePrint obj = new Report.ScheuldeCopy.frmSchedulePrint(0, txtfileno.Text);
                                            obj.ShowDialog();
                                        }
                                        else //this line and if condition is added for temprory schedual print suspension, the line will be removed after once done
                                        {
                                            MessageBox.Show("Schedual Attachment is temporary suspended by IT br"); //this line and if condition is added for temprory schedual print suspension, the line will be removed after once done
                                        }

                                     
                                     
                                   
                                    }
                                }

                                // for Only Phase One Extension
                                else if (rdph1Extension.IsChecked)
                                {
                                    txtfileno.Text = result.Tables[0].Rows[0]["FileNo"].ToString();
                                    sqlTrans.Commit();//this line and if condition is added for temprory schedual print suspension, the line will be removed after once done
                                    if (suspended == true)  //this line and if condition is added for temprory schedual print suspension, the line will be removed after once done
                                    {
                                        PlanGenerationData(sqlTrans);
                                        sqlTrans.Commit();
                                        Report.ScheuldeCopy.frmSchedulePrint obj = new Report.ScheuldeCopy.frmSchedulePrint(0, txtfileno.Text);
                                        obj.ShowDialog();
                                        //Acknowledgement.IntimationReport objreport = new Acknowledgement.IntimationReport(txtfileno.Text); //this lin will be uncommented
                                        //objreport.ShowDialog(); //this lin will be uncommented
                                    }
                                    else //this line and if condition is added for temprory schedual print suspension, the line will be removed after once done
                                    {
                                        MessageBox.Show("Schedual Attachment is temporary suspended by IT br"); //this line and if condition is added for temprory schedual print suspension, the line will be removed after once done
                                    }
                                    Acknowledgement.IntimationReport objreport = new Acknowledgement.IntimationReport(txtfileno.Text); //this line and if condition is added for temprory schedual print suspension, the line will be removed after once done
                                    objreport.ShowDialog();//this line and if condition is added for temprory schedual print suspension, the line will be removed after once done
                                }
                                else
                                {
                                    sqlTrans.Commit();
                                }

                                MessageBox.Show("File Saved Successfully.");
                                this.Close();
                            }
                            else
                            {
                                sqlTrans.Rollback();
                                MessageBox.Show("Fail Contact to Administrator.");
                                return;
                            }

                        }
                        #endregion

                        #region Generate Schedule for Existing File
                        else
                        {
                            if (txtfileno.Text.ToUpper().Contains("COM") != true && ownerCategory == "Investors" && plottype == "Residential")
                            {
                                if (!string.IsNullOrEmpty(dsFile.Tables[0].Rows[0]["InstallmentPlan"].ToString()))
                                {
                                    sqlTrans.Commit();
                                    MessageBox.Show("Schedule is Already Attach with this File.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    Report.ScheuldeCopy.frmSchedulePrint obj = new Report.ScheuldeCopy.frmSchedulePrint(0, txtfileno.Text);
                                    obj.ShowDialog();
                                    this.Close();
                                }
                                else
                                {
                                    if (MessageBox.Show("If you want to generate Plan then press (Yes) button otherwise press No.", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                    {
                                        sqlTrans.Commit();//this line will be removed
                                        if (suspended == true) //this line and if condition is added for temprory schedual print suspension, the line will be removed after once done
                                        { 
                                            PlanGenerationData(sqlTrans);
                                        sqlTrans.Commit();
                                        //Plan Generation
                                        Report.ScheuldeCopy.frmSchedulePrint obj = new Report.ScheuldeCopy.frmSchedulePrint(0, txtfileno.Text);
                                        obj.ShowDialog();
                                        //this.Close();
                                    }
                                        else//this line and if condition is added for temprory schedual print suspension, the line will be removed after once done
                                        {
                                            MessageBox.Show("Schedual Attachment is temporary suspended by IT br");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show(this, "Schedule is not Attached FileNo : " + txtfileno.Text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                        #endregion


                    }
                    catch (Exception ex)
                    {
                        sqlTrans.Rollback();
                        frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnsavefile_Click.", ex, "frmCreateFileNoRPlot");
                        frmobj.ShowDialog();
                    }
                }
            }
        }

        private void txtfileno_Leave(object sender, EventArgs e)
        {

            SqlParameter[] searchparamFile =
            {
                new SqlParameter("@Task", "select"),
                new SqlParameter("@FileNo", clsPluginHelper.DbNullIfNullOrEmpty(txtfileno.Text))
                };
            DataSet dsFile = cls_dl_FileMap.FileMap_Reader(searchparamFile);
            if (dsFile.Tables[0].Rows.Count == 0)
            {
                btnSaveandprinttheschedule.Enabled = true;
            }
            else
            {
                MessageBox.Show("File Number Already Exist.");
                //btnSaveandprinttheschedule.Enabled = false;

            }
        }
        private void btnadnewplotcategory_Click(object sender, EventArgs e)
        {
            frmaddnewPlotSizeCtegory frmobj = new frmaddnewPlotSizeCtegory();
            frmobj.ShowDialog();
            PlotSizeLoad();
        }
        private void txtfileno_TextChanged(object sender, EventArgs e)
        {

        }
        private void rdph1Extension_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (args.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                SqlParameter[] searchparamFile = { new SqlParameter("@Task", "GetPh1ExtFileNo") };
                string result = SQLHelper.ExecuteScalar(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_tbl_FileMap", searchparamFile).ToString();
                if (!string.IsNullOrWhiteSpace(result))
                {
                    txtfileno.Text = result;
                    btnSaveandprinttheschedule.Enabled = true;

                    clsPluginHelper.RadDropDownSelectByText(dpPlotSize, "1 Kanal");
                }
                else
                {
                    MessageBox.Show("File Number is Invalid.");
                    btnSaveandprinttheschedule.Enabled = false;

                }
            }
            else
            {
                txtfileno.Text = "";
            }

        }
        private void txtAmalgamationFileNo_Leave(object sender, EventArgs e)
        {
            if (txtAmalgamationFileNo.Text != txtfileno.Text)
            {

                SqlParameter[] searchparamFile =
                {
                new SqlParameter("@Task", "select"),
                new SqlParameter("@FileNo", clsPluginHelper.DbNullIfNullOrEmpty(txtAmalgamationFileNo.Text))
                };
                DataSet dsFile = cls_dl_FileMap.FileMap_Reader(searchparamFile);
                if (dsFile.Tables[0].Rows.Count == 0)
                {
                    btnSaveandprinttheschedule.Enabled = false;
                    MessageBox.Show("File Number not Exist.");
                }
                else
                {
                    btnSaveandprinttheschedule.Enabled = true;

                }

            }
        }
        private void rdIsAmalgamation_CheckStateChanged(object sender, EventArgs e)
        {
            if (rdIsAmalgamation.CheckState == CheckState.Checked)
            {
                txtAmalgamationFileNo.Enabled = true;
            }
            else
            {
                txtAmalgamationFileNo.Enabled = false;
            }
        }
        private void btnLandProvider_Click(object sender, EventArgs e)
        {
            frmRegisterNewLandProvider obj = new frmRegisterNewLandProvider();
            obj.ShowDialog();
            Fill_ddlInvestorList();
        }
        private void LandProviderList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            //try
            //{
            //    if (LandProviderList.SelectedItem.Text == "NA")
            //    {
            //        LandProviderName.Enabled = true;
            //        LandProviderFather.Enabled = true;
            //    }
            //    else
            //    {
            //        SqlParameter[] searchparamFile =
            //        {
            //    new SqlParameter("@Task", "InvestorInfo"),
            //    new SqlParameter("@LPID", clsPluginHelper.DbNullIfNullOrEmpty(LandProviderList.SelectedItem.Value.ToString()))
            //    };
            //        DataSet dsFile = cls_dl_FileMap.FileMap_Reader(searchparamFile);
            //        if (dsFile.Tables.Count > 0)
            //        {
            //            if (dsFile.Tables[0].Rows.Count > 0)
            //            {
            //                LandProviderName.Text = dsFile.Tables[0].Rows[0]["LandProviderName"].ToString();
            //                LandProviderFather.Text = dsFile.Tables[0].Rows[0]["FatherName"].ToString();
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex )
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }
        private void btnAddPlotAllData_Click(object sender, EventArgs e)
        {
            frmAddPlotNoAllRecordData obj = new frmAddPlotNoAllRecordData();
            obj.ShowDialog();
            txtplotno_Leave(null, null);
        }
        private void txtplotno_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtplotno.Text))
            {
                SqlParameter[] param =
                          {
                new SqlParameter("@Task","AddPlotNotoAllDataExist"),
                new SqlParameter("@PlotNo",txtplotno.Text),
            };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_PlotAllot", param);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        btnSaveandprinttheschedule.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Plot No is not Exists. \n Please Add to PlotNo");
                        btnSaveandprinttheschedule.Enabled = false;
                    }
                }
                else
                {
                    btnSaveandprinttheschedule.Enabled = false;
                }
            }
        }

        private void btntradeoff_Click(object sender, EventArgs e)
        {
            frmTradeOffDataView frm = new frmTradeOffDataView();
            frm.ShowDialog();
        }
    }
}
