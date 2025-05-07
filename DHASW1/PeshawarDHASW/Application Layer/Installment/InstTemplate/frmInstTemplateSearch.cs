using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsErrorLog;
using PeshawarDHASW.Data_Layer.Installment;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Models;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.Installment.InstTemplate
{
    public partial class frmInstTemplateSearch : Telerik.WinControls.UI.RadForm
    {
        #region   Search is not right (check search functionality)    #ABR

        #endregion
        #region   Bug : start date functionality when button is pressed displays No mapping exists from object type System.Format.exception to a known managed provider nature     #ABR


        #endregion
        #region   Bug : when search is pressed  exception : Cannot clear this list    #ABR


        #endregion
        #region   Bug : search installment template   --- press search --- press search install template  --- exception : object reference not set to an instance of an object    #ABR  


        #endregion
        #region   Bug : search installment template   --- press search --- press search install template  --- exception : object reference not set to an instance of an object    #ABR  


        #endregion

        public frmInstTemplateSearch()
        {
            InitializeComponent();
        }

        private int inst_template_ID = 0;
       
        private void SearchclsInstallmentTemplate()
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task", "select"),
                    new SqlParameter("@Name", clsPluginHelper.DbNullIfNullOrEmpty(txtInstName.Text)),
                    new SqlParameter("@Descp", clsPluginHelper.DbNullIfNullOrEmpty(txtInstDescp.Text)),
                    new SqlParameter("@Phase", cmdPhase.SelectedValue),
                    new SqlParameter("@PlotSize", clsPluginHelper.DbNullIfNullOrEmpty(CMbPlotSize.Text)),
                    new SqlParameter("@InstallmentTemplateStatus", cbStatus.Text)
                };

                DataSet dt = clsInstallmentTemplate.InstalTemplate_Reader(parameters);
                radGDInstallmentPlan.DataSource = dt.Tables.Count > 0 ? dt.Tables[0].DefaultView : null;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on SavingclsInstallmentTemplate.", ex, "InstTemplateModify");
                frmobj.ShowDialog();
            }

        }

        private void btnInstalTemplateSearch_Click(object sender, EventArgs e)
        {
           // radGDInstallmentPlan.DataSource = null;
            SearchclsInstallmentTemplate();
        }

        private void radDateSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdStart.Checked == true)
                {

                    SqlCommand cmd = new SqlCommand("App.USP_InstallmentTemplate");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = SQLHelper.createConnection();
                    cmd.Parameters.AddWithValue("@Task", "selectstartdate");
                    cmd.Parameters.Add(new SqlParameter("@StartDate", dtpStartDate.Value.Date));
                    cmd.Parameters.Add(new SqlParameter("@EndDate", dtpEndDate.Value.Date));
                    DataSet dt = clsInstallmentTemplate.DateTimeSearch(cmd);
                    radGDInstallmentPlan.DataSource = dt.Tables.Count > 0 ? dt.Tables[0].DefaultView : null;
                     
                }
                if (rdEnd.Checked == true)
                {
                    SqlCommand cmd = new SqlCommand("App.USP_InstallmentTemplate");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = SQLHelper.createConnection();
                    cmd.Parameters.AddWithValue("@Task", "selectenddate");
                    cmd.Parameters.Add(new SqlParameter("@StartDate", dtpStartDate.Value.Date));
                    cmd.Parameters.Add(new SqlParameter("@EndDate", dtpEndDate.Value.Date));
                    DataSet dt = clsInstallmentTemplate.DateTimeSearch(cmd);
                    radGDInstallmentPlan.DataSource = dt.Tables.Count > 0 ? dt.Tables[0].DefaultView : null;
                     
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on radDateSearch_Click.", ex, "frmInstTemplateSearch");
                frmobj.ShowDialog();
            }
        }

        private void frmInstTemplateSearch_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            #region Gridview
            try
            {
                if (inst_template_ID != 0)
                {
                   // gbtemplateperiod.Enabled = false;
                    gbtemplatesearch.Enabled = false;

                }
                else
                {

                    SqlParameter[] param =
                    {
                        new SqlParameter("@Task", "select")
                    };
                    DataSet _dsPhase = clsInstallmentTemplate.PhaseData(param);
                    if (_dsPhase.Tables.Count > 0)
                    {
                        cmdPhase.DataSource = _dsPhase.Tables[0];
                        cmdPhase.ValueMember = "Phase_ID";
                        cmdPhase.DisplayMember = "Name";
                    }

                    DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.Text, "SELECT [InstallmentTemplateStatusID] ,[InstallmentTemplateStatus]  FROM [dbo].[tbl_InstallmentTemplateStatusType]");
                    if (ds.Tables.Count > 0)
                    {
                        cbStatus.DataSource = ds.Tables[0];
                        cbStatus.ValueMember = "InstallmentTemplateStatusID";
                        cbStatus.DisplayMember = "InstallmentTemplateStatus";
                    }


                    //select * from tbl_Plot_Size
                    DataSet _ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.Text, "select * from tbl_Plot_Size");
                    if (_ds.Tables.Count > 0)
                    {
                        CMbPlotSize.DataSource = _ds.Tables[0];
                        CMbPlotSize.ValueMember = "ID";
                        CMbPlotSize.DisplayMember = "PlotSize";
                    }
                    showallData();
                }
                CMbPlotSize.SelectedIndex = -1;
                cmdPhase.SelectedIndex = -1;
                cbStatus.SelectedIndex = -1;
                
                // radGDInstallmentPlan.DataSource = result.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmInstTemplateSearch_Load.", ex, "frmInstTemplateSearch");
                frmobj.ShowDialog();
            }
           
            #endregion
        }

        private void showallData()
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task", "selectall"),
                };
                DataSet dt = clsInstallmentTemplate.InstalTemplate_Reader(parameters);
                radGDInstallmentPlan.DataSource = dt.Tables.Count > 0 ? dt.Tables[0].DefaultView : null;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on showallData.", ex, "frmInstTemplateSearch");
                frmobj.ShowDialog();
            }
          
          
        }
    }
}
