using PeshawarDHASW.Application_Layer.CustomDialog;
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

namespace PeshawarDHASW.Application_Layer.FileMap.SvcBenefitFiles
{
    public partial class frmSvcCreateFile : Telerik.WinControls.UI.RadForm
    {



        private string SqYard { get; set; }
        private string Kanal { get; set; }
        private string Marla { get; set; }

        public frmSvcCreateFile()
        {
            InitializeComponent();
            btnSaveandprinttheschedule.Enabled = false;
            rdbnormal.CheckState = CheckState.Checked;
            txtextralessarea.Text = "";
        }

        public int FileMapKey { get; set; }
        public frmSvcCreateFile(int FileMapkey)
        {
            FileMapKey = FileMapkey;
            InitializeComponent();
            loadfill(FileMapKey);
        }

        private void frmSvcCreateFile_Load(object sender, EventArgs e)
        {
            // radGroupBox1.Enabled = false;
            Filddl_ownerCategory();
            Filddl_Sector();
            //        OwnerCategory.SelectedItem.Text = "Investors";
            Fill_ddlplotbuisinesstype();
            dpPlotSize.SelectedIndex = 0;
            //      ddlplotbuisinesstype.SelectedItem.Text = "Residential";
            //LandBrIssueDate.Enabled = false;
            string date = SQLHelper.ExecuteScalar(SQLHelper.createConnection(), CommandType.Text, "Select GetDate()").ToString();
            LandBrIssueDate.Value = DateTime.Parse(date);
            clsPluginHelper.RadDropDownSelectByText(ownerCategory, "Svc Benefit");
            //ownerCategory.Enabled = false;
            clsPluginHelper.RadDropDownSelectByText(ddlplotbuisinesstype, "Residential");
            //ownerCategory.Enabled = false;
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
                ownerCategory.DataSource = ds.Tables[0].DefaultView;
                ownerCategory.ValueMember = "OCID";
                ownerCategory.DisplayMember = "Category_Name";
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Filddl_ownerCategory.", ex, "frmCreateFileNoRPlot");
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
        /// <summary>
        /// Group Template Selection on the base of Plot Size and File Category (Investor, Ballot, Svc Benefit)
        /// </summary>
        /// <returns>TemplateGroupKey</returns>
        public DataSet InstTempandTemplateGroupIDs { get; set; }
        private DataSet InstallmentPlanGroupGroupKeyValue()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection()
                                                 , CommandType.Text
                                                 , @"SELECT TOP 1 it.InstalTempID,itg.PlanGroupID
                                                     FROM dbo.tbl_InstallmentTemplate AS it
                                                     INNER JOIN DHAPeshawarDB.dbo.tbl_InstallmentTemplateGroup AS itg ON it.PlanGroupID = itg.PlanGroupID
                                                     WHERE itg.Category LIKE '" + ownerCategory.Text +
                                                    "' AND itg.PlotSize LIKE '" + dpPlotSize.Text + "' and itg.PlotType like '" + ddlplotbuisinesstype.Text + "' and it.InstalTempStatus = 1 ORDER BY it.InstalTempID asc");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;

        }
        /// <summary>
        /// Creating a New Template using Default FileNo and User Name Attached
        /// These Plan have 45 days Gap to Start.
        /// This is will use for Plan Generation
        /// </summary>
        /// <returns>TemplateKey</returns>
        private string SavingclsInstallmentTemplate()
        {
            try
            {
                DateTime StartDate = LandBrIssueDate.Value;

                string TemplateName = "Schedule is Attach with FileNo : " + txtfileno.Text + "by UserName=" + Models.clsUser.Name + "Issue:" + DateTime.Now.ToString("ddMMyyyyhhmmss");
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task","insert"),
                    new SqlParameter("@Name", clsPluginHelper.DbNullIfNullOrEmpty(TemplateName)),
                    new SqlParameter("@Descp", clsPluginHelper.DbNullIfNullOrEmpty(TemplateName)),
                    new SqlParameter("@StartDate",StartDate.AddDays(30).ToString("yyyy-MM-dd")),
                    new SqlParameter("@Phase", clsPluginHelper.DbNullIfNullOrEmpty("1")),
                    new SqlParameter("@PlotSize", clsPluginHelper.DbNullIfNullOrEmpty(dpPlotSize.Text)),
                    new SqlParameter("@userID", Models.clsUser.ID),
                    new SqlParameter("@PlanGroupID", InstTempandTemplateGroupIDs.Tables[0].Rows[0]["PlanGroupID"].ToString())
                };
                int result = 0;
                result = clsInstallmentTemplate.InstalTemplate_NonQuery(parameters);
                if (result > 0)
                {
                    SqlParameter[] parameterID =
                 {
                        new SqlParameter("@Task", "PlanKey"), // Get the New Generated Installment Template Key
                        new SqlParameter("@Name", clsPluginHelper.DbNullIfNullOrEmpty(TemplateName)),
                    };
                    //if Save than Return Value
                    DataSet dt = clsInstallmentTemplate.InstalTemplate_Reader(parameterID);
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



        private void PlanGenerationData()
        {
            #region Check and Insert Plan
            InstTempandTemplateGroupIDs = InstallmentPlanGroupGroupKeyValue(); //Get the Old InstallmentTemplate(Made From) Key
            string Templatekey = SavingclsInstallmentTemplate(); //Get the New Generated Installment Template Key
            //Default 6 Months
            int monthGap = 6;

            SqlParameter[] param =
            {
                new SqlParameter("@Task", "InsertTemplate"),
                new SqlParameter("@FromPlanID", InstTempandTemplateGroupIDs.Tables[0].Rows[0]["InstalTempID"].ToString()),
                new SqlParameter("@ToPlanID", Templatekey),
                new SqlParameter("@GapInterval", monthGap),
                new SqlParameter("@StarDate",DateTime.Now.AddDays(30)),

            };
            DataSet _dsPhase = clsInstallmentTemplate.CreateInsallmentTemplate(param);

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
            result = cls_dl_instPlan.InstalPlan_NonQuery(param1, "App.USP_InstallmentTemplate");
            if (_dsPhase.Tables.Count > 0)
            {
                if (_dsPhase.Tables[0].Rows.Count > 0)
                {

                    //MessageBox.Show("New Installment Plan successfully Created.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("New Installment Plan Failed. Please contact support.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            #endregion
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

                    //  ddlInstallmentTemplate.SelectedValue = instmentID;
                    ddlplotbuisinesstype.SelectedValue = int.Parse(row["PBTID"].ToString());
                    ownerCategory.SelectedValue = int.Parse(row["OCID"].ToString());

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
        private void btnSaveandprinttheschedule_Click(object sender, EventArgs e)
        {
            try
            {

           
            DataSet ds = InstallmentPlanGroupGroupKeyValue();

            string PlotNo = string.IsNullOrWhiteSpace(txtplotno.Text)?"": txtplotno.Text.Substring(5, 1);
            string Sector = ddlSector.SelectedItem.Text;

            //if (Sector.Contains(PlotNo) == false)
            //{
            //    MessageBox.Show("Please select the correct Sector No.");
            //    return;
            //}



           if (1==1) //ds.Tables.Count > 0)
            {
                if (1==1) //)
                {
                        try
                        {
                            #region Saving File
                            //File No Verification
                            //SqlParameter[] searchparamFile =
                            //              {
                            //new SqlParameter("@Task","select"),
                            //new SqlParameter("@FileNo", clsPluginHelper.DbNullIfNullOrEmpty(txtfileno.Text)),

                            //              };
                            //DataSet dsFile = cls_dl_FileMap.FileMap_Reader(searchparamFile);
                            //if (dsFile.Tables[0].Rows.Count == 0)
                            //{
                            string isoversundsz = "";
                            if (rdbnormal.IsChecked) { isoversundsz = rdbnormal.Text; }
                            else if (rdboversize.IsChecked) { isoversundsz = rdboversize.Text; }
                            else if (rdbundersize.IsChecked) { isoversundsz = rdbundersize.Text; }
                            clsPluginHelper.RadDropDownSelectByText(ownerCategory, "Svc Benefit");  //  ownerCategory.SelectedValue.ToString()); // 

                            if (dpPlotSize.Text == "10 Marla") { SqYard = "250"; Kanal = "0"; Marla = dpPlotSize.Text; }
                            else if (dpPlotSize.Text == "8 Marla") { SqYard = "200"; Kanal = "0"; Marla = dpPlotSize.Text; }
                            else if (dpPlotSize.Text == "5 Marla") { SqYard = "125"; Kanal = "0"; Marla = dpPlotSize.Text; }
                            else if (dpPlotSize.Text == "4 Marla") { SqYard = "100"; Kanal = "0"; Marla = dpPlotSize.Text; }
                            else if (dpPlotSize.Text == "1 Kanal") { SqYard = "500"; Kanal = dpPlotSize.Text; Marla = "0"; }
                            else if (dpPlotSize.Text == "2 Kanal") { SqYard = "1000"; Kanal = dpPlotSize.Text; Marla = "0"; }
                            else if (dpPlotSize.Text == "10 Marla") { SqYard = "250"; Kanal = "0"; Marla = dpPlotSize.Text; }
                            else { }

                            SqlParameter[] parameters =
                                {
                                 //   new SqlParameter("@Task", "insert"),//Task ---  insertwithAllotment  -- insertion with Allotment 
                                    new SqlParameter("@Task", "insertwithAllotment"),//Task ---  insertwithAllotment  -- insertion with Allotment
                                    new SqlParameter("@FileNo", clsPluginHelper.DbNullIfNullOrEmpty(txtfileno.Text)),
                                    new SqlParameter("@PlotNo", clsPluginHelper.DbNullIfNullOrEmpty(txtplotno.Text)),
                                    new SqlParameter("@Remarks", clsPluginHelper.DbNullIfNullOrEmpty(txtremarks.Text)),
                                    new SqlParameter("@PlotSize", clsPluginHelper.DbNullIfNullOrEmpty(dpPlotSize.Text)),
                                    new SqlParameter("@Status", clsPluginHelper.DbNullIfNullOrEmpty("Active")),
                                    new SqlParameter("@PlotBusinessTypeID",ddlplotbuisinesstype.SelectedValue),
                                    new SqlParameter("@TFRTypeID",1),
                                    new SqlParameter("@OwnerCategoryID",ownerCategory.SelectedValue),
                                    new SqlParameter("@userID",Models.clsUser.ID),
                                    new SqlParameter("@InvestorName",clsPluginHelper.DbNullIfNullOrEmpty(LandProviderName.Text)),
                                    new SqlParameter("@FirstBuyerName",clsPluginHelper.DbNullIfNullOrEmpty(txtFirstBuyerName.Text)),
                                    new SqlParameter("@LandBrIssueDate",LandBrIssueDate.Value),
                                    new SqlParameter("@LandProviderName",clsPluginHelper.DbNullIfNullOrEmpty(LandProviderName.Text)),
                                    new SqlParameter("@Sector_ID",ddlSector.SelectedValue),
                                    new SqlParameter("@SqYard",SqYard),
                                    new SqlParameter("@Kanal",Kanal),
                                    new SqlParameter("@Marla",Marla),
                                    new SqlParameter("@IsOversizeUndersize",isoversundsz == "Normal" ? null : isoversundsz),
                                    new SqlParameter("@Extra_Less_Area",rdbundersize.IsChecked ? "-"+ txtextralessarea.Text : txtextralessarea.Text),

                             };

                            // int result = 0;
                            //   result = cls_dl_FileMap.FileMap_NonQuery(parameters);
                            DataSet ds_allot = cls_dl_FileMap.FileMap_Reader(parameters);
                            if (!string.IsNullOrWhiteSpace(txtfileno.Text))
                            {
                                SqlParameter[] paramOverSize = {
                                                            new SqlParameter("@Task","OverSizeandUnderSize"),
                                                            new SqlParameter("@FileNo", clsPluginHelper.DbNullIfNullOrEmpty(txtfileno.Text)),
                                                            new SqlParameter("@IsOversizeUndersize",isoversundsz == "Normal" ? null : isoversundsz),
                                                            new SqlParameter("@Extra_Less_Area",rdbundersize.IsChecked ? "-"+ txtextralessarea.Text : txtextralessarea.Text),
                                                            };
                                cls_dl_FileMap.FileMap_NonQuery(paramOverSize);
                            }
                            


                            string allotmsg = ds_allot.Tables[0].Rows[0]["Message"].ToString();
                            string Conditionform = ds_allot.Tables[0].Rows[0]["ConditionalDetail"].ToString();
                            string AttachRemarks = ds_allot.Tables[0].Rows[0]["AttachRemarks"].ToString();


                        foreach (DataRow row in ds_allot.Tables[0].Rows)
                        {
                          int AllotmentID = int.Parse(row["AllotmentID"].ToString());
                           string FileNo = row["FileNo"].ToString();
                            string AllotmentDate = row["AllotmentDate"].ToString();
                            string Status = row["Status"].ToString();
                            string Remarks =  row["Remarks"].ToString();
                        }


                       if (allotmsg.Contains(" is already alotted to File No.") || allotmsg.Contains("Invalid Allotment.") && Conditionform.Contains("OpenForm"))
                        {
                        if (Conditionform.Contains("OpenForm"))
                        {
                            MessageBox.Show(ds_allot.Tables[0].Rows[0]["Message"].ToString());
                            frmfileplotallotment frm_plotallot = new frmfileplotallotment(txtfileno.Text, txtplotno.Text, dpPlotSize.Text
                                 , Convert.ToInt32(ddlplotbuisinesstype.SelectedValue), Convert.ToInt32(ddlSector.SelectedValue), Convert.ToString(LandBrIssueDate.Value), txtremarks.Text, AttachRemarks,ds_allot);
                                frm_plotallot.ShowDialog();
                            }
                            else
                            {

                                MessageBox.Show(ds_allot.Tables[0].Rows[0]["Message"].ToString());
                                //TemplateCreationforFile
                               
                            }


                            SqlParameter[] prm1 =
                            {
                             new SqlParameter("@Task", "CheckForExistingPlan"),
                             new SqlParameter("@FileNo",  txtfileno.Text)
                            
                            };
                            DataSet dsPh = clsInstallmentTemplate.InstalTemplate_Reader(prm1);
                            bool suspended = false;
                            if (dsPh.Tables.Count > 0)
                            {
                                if (dsPh.Tables[0].Rows.Count > 0)
                                {
                                    int tempkey = int.Parse(dsPh.Tables[0].Rows[0]["TemplateInstKey"].ToString());
                                    if (tempkey == 0)
                                    {
                                        if (suspended == true)//this line and if condition is added for temprory schedual print suspension, the line will be removed after once done
                                        {
                                            PlanGenerationData();
                                        }
                                    }
                                }
                            }
                            //Plan Generation
                       
                            if (suspended == true)//this line and if condition is added for temprory schedual print suspension, the line will be removed after once done
                            {
                                Report.ScheuldeCopy.frmSchedulePrint obj = new Report.ScheuldeCopy.frmSchedulePrint(0, txtfileno.Text);
                                obj.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Schedual Attachment is temporary suspended");//this line and if condition is added for temprory schedual print suspension, the line will be removed after once done
                            }
                            this.Close();
                        //if (result > 0)
                        //{
                        //    //TemplateCreationforFile
                        //    PlanGenerationData();
                        //    //Plan Generation
                        //    Report.ScheuldeCopy.frmSchedulePrint obj = new Report.ScheuldeCopy.frmSchedulePrint(0, txtfileno.Text);
                        //    obj.ShowDialog();



                        //    //frmfileplotallotment frm_plotallot = new frmfileplotallotment(txtfileno.Text, txtplotno.Text, dpPlotSize.Text
                        //    //  ,Convert.ToInt32(ddlplotbuisinesstype.SelectedValue), Convert.ToInt32(ddlSector.SelectedValue));
                        //    //frm_plotallot.Show();



                        //    this.Close();
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Fail Contact to Administrator.");
                        //}


                        //}
                        //else
                        //{
                        //    if (MessageBox.Show("If you want to generate Plan press (Yes) not than press No.", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        //    {
                        //        PlanGenerationData();
                        //        //Plan Generation
                        //        Report.ScheuldeCopy.frmSchedulePrint obj = new Report.ScheuldeCopy.frmSchedulePrint(0, txtfileno.Text);
                        //        obj.ShowDialog();
                        //        this.Close();
                        //    }
                        }
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnsavefile_Click.", ex, "frmCreateFileNoRPlot");
                        frmobj.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Plan Generation cannot be processed due to No Template Plan. Contact to Finance Br.");
                }
            }
            else
            {
                MessageBox.Show("Plan Generation cannot be processed due to No Template Plan. or Check your Input Fields.");
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

                if (dsFile.Tables[0].Rows[0]["IsOversizeUndersize"].ToString() == "" || dsFile.Tables[0].Rows[0]["IsOversizeUndersize"].ToString() == null)
                {
                    rdbnormal.CheckState = CheckState.Checked;
                    rdboversize.CheckState = CheckState.Unchecked;
                    rdbundersize.CheckState = CheckState.Unchecked;
                }
                else if (dsFile.Tables[0].Rows[0]["IsOversizeUndersize"].ToString() == "Over size")
                {
                    rdbnormal.CheckState = CheckState.Unchecked;
                    rdboversize.CheckState = CheckState.Checked;
                    rdbundersize.CheckState = CheckState.Unchecked;
                }
                else if (dsFile.Tables[0].Rows[0]["IsOversizeUndersize"].ToString() == "Under size")
                {
                    rdbnormal.CheckState = CheckState.Unchecked;
                    rdboversize.CheckState = CheckState.Unchecked;
                    rdbundersize.CheckState = CheckState.Checked;
                }
                else
                {

                }
                txtextralessarea.Text = dsFile.Tables[0].Rows[0]["Extra_Less_Area"].ToString();
            }

            string FileNo = txtfileno.Text.ToUpper();
            if (FileNo.Contains("OLO/A/RES"))
            {
                dpPlotSize.SelectedItem.Text = "2 Kanal";
                ddlplotbuisinesstype.SelectedItem.Text = "Residential";
                btnSaveandprinttheschedule.Enabled = true;
            }
            else if (FileNo.Contains("OLO/B/RES"))
            {
                dpPlotSize.SelectedItem.Text = "1 Kanal";
                ddlplotbuisinesstype.SelectedItem.Text = "Residential";
                btnSaveandprinttheschedule.Enabled = true;
            }
            else if (FileNo.Contains("OLO/C/RES"))
            {
                dpPlotSize.SelectedItem.Text = "10 Marla";
                ddlplotbuisinesstype.SelectedItem.Text = "Residential";
                btnSaveandprinttheschedule.Enabled = true;
            }
            else if (FileNo.Contains("OLO/D/RES"))
            {
                dpPlotSize.SelectedItem.Text = "8 Marla";
                ddlplotbuisinesstype.SelectedItem.Text = "Residential";
                btnSaveandprinttheschedule.Enabled = true;
            }
            else if (FileNo.Contains("OLO/G/COM"))
            {
                dpPlotSize.SelectedItem.Text = "8 Marla";
                ddlplotbuisinesstype.SelectedItem.Text = "Commerical";
                btnSaveandprinttheschedule.Enabled = true;
            }
            else if (FileNo.Contains("OLO/V/COM"))
            {
                dpPlotSize.SelectedItem.Text = "10 Marla";
                ddlplotbuisinesstype.SelectedItem.Text = "Commerical";
                btnSaveandprinttheschedule.Enabled = true;
            }
            else if (FileNo.Contains("OLO/E/RES"))
            {
                dpPlotSize.SelectedItem.Text = "5 Marla";
                ddlplotbuisinesstype.SelectedItem.Text = "Residential";
                btnSaveandprinttheschedule.Enabled = true;
            }
            else if (FileNo.Contains("OLO/H/COM"))
            {
                dpPlotSize.SelectedItem.Text = "4 Marla";
                ddlplotbuisinesstype.SelectedItem.Text = "Commerical";
                btnSaveandprinttheschedule.Enabled = true;
            }
            else if (FileNo.Contains("C/RES/APS"))
            {
                dpPlotSize.SelectedItem.Text = "10 Marla";
                ddlplotbuisinesstype.SelectedItem.Text = "Residential";
                btnSaveandprinttheschedule.Enabled = true;
            }
            else if (FileNo.Contains("C/RES"))
            {
                dpPlotSize.SelectedItem.Text = "10 Marla";
                ddlplotbuisinesstype.SelectedItem.Text = "Residential";
                btnSaveandprinttheschedule.Enabled = true;
            }
            else if (FileNo.Contains("B/RES"))
            {
                dpPlotSize.SelectedItem.Text = "1 Kanal";
                ddlplotbuisinesstype.SelectedItem.Text = "Residential";
                btnSaveandprinttheschedule.Enabled = true;
            }
            else if (FileNo.Contains("E/RES"))
            {
                dpPlotSize.SelectedItem.Text = "5 Marla";
                ddlplotbuisinesstype.SelectedItem.Text = "Residential";
                btnSaveandprinttheschedule.Enabled = true;
            }
            else if (FileNo.Contains("G/COM"))
            {
                dpPlotSize.SelectedItem.Text = "8 Marla";
                ddlplotbuisinesstype.SelectedItem.Text = "Commerical";
                btnSaveandprinttheschedule.Enabled = true;
            }
            else if (FileNo.Contains("H/COM"))
            {
                dpPlotSize.SelectedItem.Text = "4 Marla";
                ddlplotbuisinesstype.SelectedItem.Text = "Commerical";
                btnSaveandprinttheschedule.Enabled = true;
            }
        
            else
            {
                btnSaveandprinttheschedule.Enabled = false;
                MessageBox.Show("Select a Valid Plot Size and Category According to File No.");
            }
            txtfileno.Text = FileNo;
        }

        private void ddlSector_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {

                if (!string.IsNullOrWhiteSpace(txtplotno.Text))
                {
                    string PlotNo = txtplotno.Text.Substring(5, 1);
                    string Sector = ddlSector.SelectedItem.Text;

                    if (Sector.Contains(PlotNo) == false)
                    {
                        MessageBox.Show("Plot Name and Sector Name not matching.");
                        return;
                    }
                }
           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rdbnormal_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rdbnormal.CheckState == CheckState.Checked)
            {
                txtextralessarea.Text = "";
            }
        }

        private void dpPlotSize_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void ownerCategory_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }
    }
}
