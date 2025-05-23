using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsErrorLog;
using PeshawarDHASW.Data_Layer.clsFileMap;
using PeshawarDHASW.Helper;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.Installment;

namespace PeshawarDHASW.Application_Layer.FileMap
{
    public partial class frmCreateFileNoRPlot : Telerik.WinControls.UI.RadForm
    {
        public frmCreateFileNoRPlot()
        {
            InitializeComponent();
            Fill_ddlplotbuisinesstype();
            Fillddl_transfertype();
            Filddl_ownerCategory();
            Fillddl_InstallmentTemplate();
        }

        private int filekeyid { get; set; } = 0;

        public frmCreateFileNoRPlot(int FileKeyID)
        {
            filekeyid = FileKeyID;
            InitializeComponent();
            Fill_ddlplotbuisinesstype();
            Fillddl_transfertype();
            Filddl_ownerCategory();
            Fillddl_InstallmentTemplate();
            loadfill(filekeyid);
        }

        private void clearfunction()
        {
            txtfileno.Text = "";
            txtplotno.Text = "";
            txtrecordno.Text = "";
            txtremarks.Text = "";
            filestatus.SelectedIndex = 0;
        }



        private void btnsavefile_Click(object sender, EventArgs e)
        {
            try
            {
                //Saving
                if (filekeyid == 0)
                {
                    #region Saving File
                    //File No Verification
                    SqlParameter[] searchparamFile =
                                  {
                    new SqlParameter("@Task","select"),
                    new SqlParameter("@FileNo", clsPluginHelper.DbNullIfNullOrEmpty(txtfileno.Text)),

                                  };
                    DataSet dsFile = cls_dl_FileMap.FileMap_Reader(searchparamFile);
                    if (dsFile.Tables[0].Rows.Count == 0)
                    {
                        //SqlParameter[] searchparamPlot =
                        //          {
                        //           new SqlParameter("@Task","select"),
                        //           new SqlParameter("@PlotNo", clsPluginHelper.DbNullIfNullOrEmpty(txtplotno.Text)),
                        //          };
                        //DataSet dsPlot = cls_dl_FileMap.FileMap_Reader(searchparamPlot);
                        //if (dsPlot.Tables[0].Rows.Count == 0)
                        //{
                        SqlParameter[] parameters =
                        {
                                new SqlParameter("@Task", "insert"),
                                new SqlParameter("@FileNo", clsPluginHelper.DbNullIfNullOrEmpty( txtfileno.Text)),
                                new SqlParameter("@PlotNo", clsPluginHelper.DbNullIfNullOrEmpty( txtplotno.Text)),
                                new SqlParameter("@RecordNo", clsPluginHelper.DbNullIfNullOrEmpty( txtrecordno.Text)),
                                new SqlParameter("@Remarks", clsPluginHelper.DbNullIfNullOrEmpty( txtremarks.Text)),
                                new SqlParameter("@PlotSize", clsPluginHelper.DbNullIfNullOrEmpty( dpPlotSize.Text)),
                                new SqlParameter("@Status", clsPluginHelper.DbNullIfNullOrEmpty( filestatus.Text)),
                                new SqlParameter("@PlotBusinessTypeID",ddlplotbuisinesstype.SelectedValue),
                                new SqlParameter("@TFRTypeID",ddl_transfertype.SelectedValue),
                                new SqlParameter("@OwnerCategoryID",ddl_ownerCategory.SelectedValue),
                               // new SqlParameter("@TemplateInstKey",ddlInstallmentTemplate.SelectedValue),
                                new SqlParameter("@userID",Models.clsUser.ID),
                                new SqlParameter("@FileIssueDate",dtpDateofIssue.Value),
                                new SqlParameter("@LetterType",clsPluginHelper.DbNullIfNullOrEmpty( dlLetterType.Text)),
                                new SqlParameter("@InvestorName",clsPluginHelper.DbNullIfNullOrEmpty( txtLandProviderName.Text)),
                                new SqlParameter("@FirstBuyerName",clsPluginHelper.DbNullIfNullOrEmpty( txtFirstBuyerName.Text)),
                                new SqlParameter("@LandBrIssueDate",LandBrIssueDate.Value),
                                new SqlParameter("@LandProviderName",clsPluginHelper.DbNullIfNullOrEmpty(txtLandProviderName.Text))
                            };
                        int result = 0;
                        result = cls_dl_FileMap.FileMap_NonQuery(parameters);
                        if (result > 0)
                        {
                            lblFileNo.Text = txtfileno.Text;
                            lblDate.Text = dtpDateofIssue.Text;
                            lblCategory.Text = ddl_ownerCategory.SelectedItem.Text;
                            clearfunction();
                            this.radPageView1.SelectedPage = this.pageScheduleInfo;

                        }
                        else
                        {
                            MessageBox.Show("Fail Contact to Administrator.");
                        }
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Plot Number is Already Issue");
                        //}
                    }
                    else
                    {
                        MessageBox.Show("File Number Already Exist.");
                    }
                    #endregion
                }
                else
                {
                    #region Update File
                    SqlParameter[] parameters =
                    {
                        new SqlParameter("@Task","update"),
                        new SqlParameter("@FileMapKey",filekeyid.ToString()),
                        new SqlParameter("@FileNo", txtfileno.Text),
                        new SqlParameter("@PlotNo", txtplotno.Text),
                        new SqlParameter("@RecordNo", txtrecordno.Text),
                     //   new SqlParameter("@TemplateInstKey",ddlInstallmentTemplate.SelectedValue), 
                        new SqlParameter("@Remarks", txtremarks.Text),
                        new SqlParameter("@Status", filestatus.Text),
                        new SqlParameter("@PlotBusinessTypeID",ddlplotbuisinesstype.SelectedValue),
                        new SqlParameter("@TFRTypeID",ddl_transfertype.SelectedValue),
                        new SqlParameter("@OwnerCategoryID",ddl_ownerCategory.SelectedValue),
                        new SqlParameter("@PlotSize",dpPlotSize.Text),
                        new SqlParameter("@userID", Models.clsUser.ID),
                        new SqlParameter("@FileIssueDate",dtpDateofIssue.Value),
                        new SqlParameter("@LetterType",dlLetterType.Text),
                        new SqlParameter("@InvestorName",clsPluginHelper.DbNullIfNullOrEmpty( txtLandProviderName.Text)),
                        new SqlParameter("@FirstBuyerName",clsPluginHelper.DbNullIfNullOrEmpty( txtFirstBuyerName.Text)),
                        new SqlParameter("@LandBrIssueDate",LandBrIssueDate.Value),
                        new SqlParameter("@LandProviderName",clsPluginHelper.DbNullIfNullOrEmpty(txtLandProviderName.Text))
                    };
                    int result = 0;
                    result = cls_dl_FileMap.FileMap_NonQuery(parameters);
                    if (result > 0)
                    {
                        lblFileNo.Text = txtfileno.Text;
                        lblDate.Text = dtpDateofIssue.Text;
                        lblCategory.Text = ddl_ownerCategory.SelectedItem.Text;
                        this.radPageView1.SelectedPage = this.pageScheduleInfo;
                        Helper.clsPluginHelper.RadDropDownSelectedbyValue(rad_dropDown_Template, InstallmentTemplateID);
                    }
                    else
                    {
                        MessageBox.Show("Failed, Contact to Administrator.");
                    }
                    #endregion
                }

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnsavefile_Click.", ex, "frmCreateFileNoRPlot");
                frmobj.ShowDialog();

            }
        }

        public int InstallmentTemplateID { get; set; }
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
                    txtrecordno.Text = row["RecordNo"].ToString();
                    txtremarks.Text = row["Remarks"].ToString();
                    dpPlotSize.Text = row["PlotSize"].ToString();
                    //dpPlotSize.SelectedIndex = str == "10 Marla" ? 0 : -1;
                    filestatus.SelectedIndex = row["Status"].ToString() == "Active" ? 0 : 1;
                    int instmentID = 0;
                    bool insttempParse = int.TryParse(row["InstalTempID"].ToString(), out instmentID);
                    InstallmentTemplateID = instmentID;
                    //  ddlInstallmentTemplate.SelectedValue = instmentID;
                    ddlplotbuisinesstype.SelectedValue = int.Parse(row["PBTID"].ToString());
                    ddl_ownerCategory.SelectedValue = int.Parse(row["OCID"].ToString());
                    ddl_transfertype.SelectedValue = int.Parse(row["TrfTID"].ToString());
                    if (!string.IsNullOrEmpty(row["FileIssueDate"].ToString()))
                    {
                        dtpDateofIssue.Value = DateTime.Parse(row["FileIssueDate"].ToString());
                        lblDate.Text = dtpDateofIssue.Text;
                    }
                    dlLetterType.Text = row["LetterType"].ToString();
                    ///////////////PLAN ATTACHEMENT//////////////////////
                    lblFileNo.Text = txtfileno.Text;
                    lblCategory.Text = ddl_ownerCategory.Text;
                    txtLandProviderName.Text = row["InvestorName"].ToString();
                    txtFirstBuyerName.Text = row["FirstBuyerName"].ToString();
                    if (!string.IsNullOrEmpty(row["LandBrIssueDate"].ToString()))
                    {
                        LandBrIssueDate.Value = DateTime.Parse( row["LandBrIssueDate"].ToString());
                    }
                    txtLandProviderName.Text = row["LandProviderName"].ToString();
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on loadfill.", ex, "frmCreateFileNoRPlot");
                frmobj.ShowDialog();
            }
        }
        private void frmCreateFileNoRPlot_Load(object sender, EventArgs e)
        {

        }
        private void Fillddl_InstallmentTemplate()
        {
            try
            {
                SqlParameter[] par =
                {
                    new SqlParameter("@Task","OnlyDropDownwhichOpen"),
                };
                DataSet ds = new DataSet();
                ds = cls_dl_FileMap.Fillddl_InstallmentTemplate(par);

                rad_dropDown_Template.DataSource = ds.Tables[0].DefaultView;
                rad_dropDown_Template.ValueMember = "InstalTempID";
                rad_dropDown_Template.DisplayMember = "TemplateName";

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Fillddl_InstallmentTemplate.", ex, "frmCreateFileNoRPlot");
                frmobj.ShowDialog();
            }

        }
        private void Fillddl_transfertype()
        {
            try
            {
                SqlParameter[] par =
                      {
             new SqlParameter("@Task","Select"),
            };
                DataSet ds = new DataSet();
                ds = cls_dl_FileMap.Fillddl_Transfer_Type(par);
                ddl_transfertype.DataSource = ds.Tables[0].DefaultView;
                ddl_transfertype.ValueMember = "TypeID";
                ddl_transfertype.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Fillddl_transfertype.", ex, "frmCreateFileNoRPlot");
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
                ddl_ownerCategory.DataSource = ds.Tables[0].DefaultView;
                ddl_ownerCategory.ValueMember = "OCID";
                ddl_ownerCategory.DisplayMember = "Category_Name";
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Filddl_ownerCategory.", ex, "frmCreateFileNoRPlot");
                frmobj.ShowDialog();
            }


        }

        private void rad_dropDown_Template_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                string templatekey = rad_dropDown_Template.SelectedValue.ToString();

                if (rad_dropDown_Template.SelectedIndex != 0)
                {

                    LoadDefaultData(templatekey);
                }
                else
                {
                    DataRowView data = (DataRowView)rad_dropDown_Template.SelectedItems[0].Value;
                    //string dataa = data[0].ToString();
                    //string ve = data[1].ToString();
                    LoadDefaultData(data[0].ToString());

                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on rad_dropDown_Template_SelectedIndexChanged.", ex, "frmInstPlanSearch");
                frmobj.ShowDialog();

            }

        }
        private void LoadDefaultData(string InstTemplateNo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("App.USP_InstallmentPlan");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Task", "select");
                cmd.Parameters.AddWithValue("@instalTempID", InstTemplateNo);
                DataSet ds = cls_dl_instPlan.InstalPlan_Reader(cmd);
                radgvplan.DataSource = ds.Tables[0].DefaultView;

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LoadDefaultData.", ex, "frmInstPlanSearch");
                frmobj.ShowDialog();
            }
        }

        private void btnAttachPlan_Click(object sender, EventArgs e)
        {
            SqlParameter[] param =
            {
                 new SqlParameter("@Task","AttachPlantoFile"),
                        new SqlParameter("@FileMapKey",Helper.clsPluginHelper.DbNullIfNullOrEmpty( filekeyid.ToString())),
                        new SqlParameter("@FileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty( lblFileNo.Text)),
                        new SqlParameter("@InstalTempID", rad_dropDown_Template.SelectedItem.Value),
                        new SqlParameter("@userID", Models.clsUser.ID),
                     //   new SqlParameter("@TemplateInstKey",ddlInstallmentTemplate.SelectedValue), 

            };
            int result = 0;
            result = cls_dl_instPlan.InstalPlan_NonQuery(param, "App.USP_InstallmentTemplate");
            if (result > 0)
            {
                SqlParameter[] paramReport = {
                    new SqlParameter("@Task","PlanPrintCopy"),
                    new SqlParameter("@FileMapKey",filekeyid)
                };
                DataSet ds = cls_dl_instPlan.InstalTemplate_Reader(param, "App.USP_InstallmentTemplate");
                MessageBox.Show("Plan Attach Successfully.");
            }
            else
            {
                MessageBox.Show("Their is Some Error.");
            }
        }

        private void txtfileno_Leave(object sender, EventArgs e)
        {
            SqlParameter[] param = {
                new SqlParameter("@Task","DuplicateFileNo"),
                new SqlParameter("@FileNo",txtfileno.Text),
            };
            DataSet ds = cls_dl_FileMap.Main_FileMap_Reader(param);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["FileValidation"].ToString() == "File is Exist")
                    {
                        btnsavefile.Enabled = false;
                        MessageBox.Show(this, "File is Already Exist.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        btnsavefile.Enabled = true;
                    }
                }
            }
        }
    }
}
