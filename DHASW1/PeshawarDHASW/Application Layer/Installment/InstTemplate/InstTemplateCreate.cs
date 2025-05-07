using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using PeshawarDHASW.Application_Layer;
//using PeshawarDHASW.Business_Layer;
using PeshawarDHASW.Data_Layer;
using PeshawarDHASW.Data_Layer.clsErrorLog;
using PeshawarDHASW.Data_Layer.Installment;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Models;
using Telerik.WinControls.UI;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.Installment.InstTemplate
{
    public partial class InstTemplateCreate : Telerik.WinControls.UI.RadForm
    {
        #region   Date Constraint on installment template (Check)   #ABR

        #endregion
        #region   Format of the selection tab should be in the right format    #ABR

        #endregion

        public InstTemplateCreate()
        {
            InitializeComponent();
        }

        public int InstalID = 0;

        public InstTemplateCreate(string ID)
        {
            InitializeComponent();
            bool a = int.TryParse(ID.ToString(), out InstalID);
        }

        #region Load Form

        private void InstTemplateCreate_Load(object sender, EventArgs e)
        {
            try
            {
                this.ThemeName = clsUser.ThemeName;
                ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
                #region Load Phase Data
                SqlParameter[] param =
                {
                    new SqlParameter("@Task", "select")
                };
                //RadListDataItem Select = new RadListDataItem();
                //Select.Value = 0;
                //Select.Text = "-- Select --";
                //this.cmbPhase.Items.Add(Select);


                DataSet _dsPhase = clsInstallmentTemplate.PhaseData(param);
                if (_dsPhase.Tables.Count > 0)
                {
                    cmbPhase.DataSource = _dsPhase.Tables[0];
                    cmbPhase.ValueMember = "Phase_ID";
                    cmbPhase.DisplayMember = "Name";
                }
                #endregion

                DataSet _ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.Text, "select * from tbl_Plot_Size");
                if (_ds.Tables.Count > 0)
                {
                    cmdPlotSize.DataSource = _ds.Tables[0];
                    cmdPlotSize.ValueMember = "ID";
                    cmdPlotSize.DisplayMember = "PlotSize";
                }

                DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.Text, "SELECT [InstallmentTemplateStatusID] ,[InstallmentTemplateStatus]  FROM [dbo].[tbl_InstallmentTemplateStatusType]");
                if (ds.Tables.Count > 0)
                {
                    cbStatus.DataSource = ds.Tables[0];
                    cbStatus.ValueMember = "InstallmentTemplateStatusID";
                    cbStatus.DisplayMember = "InstallmentTemplateStatus";
                }

                DataSet dsTempGroup = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.Text, "select PlanGroupID,Name from tbl_InstallmentTemplateGroup");
                if (dsTempGroup.Tables.Count > 0)
                {
                    cmbTempGroup.DataSource = dsTempGroup.Tables[0];
                    cmbTempGroup.ValueMember = "PlanGroupID";
                    cmbTempGroup.DisplayMember = "Name";
                }

                #region Load Data for Update
                Clearfunction();
                if (InstalID != 0)
                {
                    SqlParameter[] paramsql =
                    {
                        new SqlParameter("@Task", "select"),
                        new SqlParameter("@InstalTempID",InstalID.ToString()),
                    };
                    DataSet dst = clsInstallmentTemplate.InstalTemplate_Reader(paramsql);
                    foreach (DataRow row in dst.Tables[0].Rows)
                    {
                        txtinstalName.Text = row["TemplateName"].ToString();
                        txtInstDescp.Text = row["Descp"].ToString();
                        dtpInstStartDate.Value = Helper.clsPluginHelper.GetDateTime(row["StartDate"].ToString());
                        dtpInstalEndDate.Value = Helper.clsPluginHelper.GetDateTime(row["EndDate"].ToString());
                        cmbPhase.SelectedValue = string.IsNullOrEmpty(row["Phase"].ToString()) ? -1 : Convert.ToInt32(row["Phase"].ToString());
                        cmdPlotSize.Text = row["PlotSize"].ToString();
                        cbStatus.SelectedValue = string.IsNullOrEmpty(row["InstalTempStatus"].ToString()) ? -1 : Convert.ToInt32(row["InstalTempStatus"].ToString());
                        txtRemarks.Text = row["Remarks"].ToString();
                        cmbTempGroup.SelectedValue = string.IsNullOrEmpty(row["PlanGroupID"].ToString()) ? -1 : Convert.ToInt32(row["PlanGroupID"].ToString());
                    }
                }

                #endregion

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on InstTemplateCreate_Load.", ex, "InstTemplateCreate");
                frmobj.ShowDialog();

            }

        }

        #endregion

        #region Clear Function

        private void Clearfunction()
        {
            txtinstalName.Clear();
            txtInstDescp.Clear();
            txtRemarks.Clear();
            //dtpInstStartDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //dtpInstalEndDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cmbPhase.SelectedIndex = -1;
            cmdPlotSize.SelectedIndex = -1;
            cmbTempGroup.SelectedIndex = -1;
        }

        #endregion

        #region Clear Event

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clearfunction();
        }

        #endregion

        private void radbtnCreateTemplateInst_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtinstalName.Text.Trim()))
                {
                    MessageBox.Show("Please enter name for Installment Template.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtinstalName.Focus();
                    return;
                }
                if (dtpInstStartDate.Value.Date.Year == 1)
                {
                    MessageBox.Show("Please enter Start Date for Installment Template.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (dtpInstalEndDate.Value.Date.Year == 1)
                {
                    MessageBox.Show("Please enter End Date for Installment Template.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cmbPhase.SelectedIndex > -1)
                {
                    if (!string.IsNullOrEmpty(cmdPlotSize.Text))
                    {
                        if (cmbTempGroup.SelectedIndex > -1)
                        {
                            object cc = cmbTempGroup.SelectedValue;

                            if (InstalID != 0)
                            {
                                #region Update Instalmment Template
                                UpdatingclsInstallmentTemplate();

                                #endregion
                            }
                            else
                            {
                                #region Saving InstallmentTemplate

                                SavingclsInstallmentTemplate();

                                #endregion
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select correct Template group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmbTempGroup.ShowDropDown();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select correct Plot Size.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmdPlotSize.ShowDropDown();
                    }
                }
                else
                {
                    MessageBox.Show("Please select correct Phase Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbPhase.ShowDropDown();
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on radbtnCreateTemplateInst_Click.", ex, "InstTemplateCreate");
                frmobj.ShowDialog();
            }

        }



        private void SavingclsInstallmentTemplate()
        {
            try
            {

                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task","insert"),
                    new SqlParameter("@Name", clsPluginHelper.DbNullIfNullOrEmpty(txtinstalName.Text)),
                    new SqlParameter("@Descp", clsPluginHelper.DbNullIfNullOrEmpty(txtInstDescp.Text)),
                    new SqlParameter("@StartDate",dtpInstStartDate.Value.Date),
                    new SqlParameter("@EndDate",dtpInstalEndDate.Value.Date),
                    new SqlParameter("@Phase", clsPluginHelper.DbNullIfNullOrEmpty(cmbPhase.SelectedValue.ToString())),
                    new SqlParameter("@PlotSize", clsPluginHelper.DbNullIfNullOrEmpty(cmdPlotSize.Text)),
                    new SqlParameter("@userID", Models.clsUser.ID),
                    new SqlParameter("@InstalTempStatus", cbStatus.SelectedValue),
                    new SqlParameter("@Remarks", clsPluginHelper.DbNullIfNullOrEmpty(txtRemarks.Text)),
                    new SqlParameter("@PlanGroupID", cmbTempGroup.SelectedValue)
                };
                int result = 0;
                result = clsInstallmentTemplate.InstalTemplate_NonQuery(parameters);
                if (result > 0)
                {
                    MessageBox.Show("Record successfully added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clearfunction();
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
        }

        private void UpdatingclsInstallmentTemplate()
        {
            try
            {

                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task", "update"),
                    new SqlParameter("@InstalTempID", InstalID),
                    new SqlParameter("@Name", clsPluginHelper.DbNullIfNullOrEmpty(txtinstalName.Text)),
                    new SqlParameter("@Descp", clsPluginHelper.DbNullIfNullOrEmpty(txtInstDescp.Text)),
                    new SqlParameter("@StartDate", clsPluginHelper.GetDateTime(dtpInstStartDate.Value.ToString())),
                    new SqlParameter("@EndDate", clsPluginHelper.GetDateTime(dtpInstalEndDate.Value.ToString())),
                    new SqlParameter("@Phase", clsPluginHelper.DbNullIfNullOrEmpty(cmbPhase.SelectedValue.ToString())),
                    new SqlParameter("@PlotSize", clsPluginHelper.DbNullIfNullOrEmpty(cmdPlotSize.Text)),
                    new SqlParameter("@userID", Models.clsUser.ID),
                    new SqlParameter("@InstalTempStatus", cbStatus.SelectedValue),
                    new SqlParameter("@Remarks", clsPluginHelper.DbNullIfNullOrEmpty(txtRemarks.Text)),
                    new SqlParameter("@PlanGroupID", cmbTempGroup.SelectedValue)
                };
                int result = 0;
                result = clsInstallmentTemplate.InstalTemplate_NonQuery(parameters);
                if (result > 0)
                {
                    MessageBox.Show("Record updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clearfunction();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("An Error Occured. Please contant support.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on UpdatingclsInstallmentTemplate.", ex, "InstTemplateCreate");
                frmobj.ShowDialog();
            }

        }
    }
}
