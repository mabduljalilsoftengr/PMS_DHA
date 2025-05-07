using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Application_Layer.Membership.Modify;
using PeshawarDHASW.Data_Layer.clsErrorLog;
using PeshawarDHASW.Data_Layer.Installment;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Models;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.Installment.InstTemplate
{
    public partial class InstTemplateModify : Telerik.WinControls.UI.RadForm
    {
        public InstTemplateModify()
        {
            InitializeComponent();



        }
        private void SavingclsInstallmentTemplate()
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
                    new SqlParameter("@InstallmentTemplateStatus", clsPluginHelper.DbNullIfNullOrEmpty(cbStatus.Text))
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
            // radGDInstallmentPlan.Rows.Clear();
            SavingclsInstallmentTemplate();
        }

        #region Installment Modifcation Form Load
        private void InstTemplateModify_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            #region Gridview
            try
            {
                // radGDInstallmentPlan.Rows.Clear();

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

                // radGDInstallmentPlan.DataSource = result.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on InstTemplateModify_Load.", ex, "InstTemplateModify");
                frmobj.ShowDialog();
            }

            #endregion
            CMbPlotSize.SelectedIndex = -1;
            cmdPhase.SelectedIndex = -1;
            cbStatus.SelectedIndex = -1;

            addingControltoGrid();
        }
        #endregion

        #region Show All Data
        private void showallData()
        {
            try
            {
                // radGDInstallmentPlan.Rows.Clear();
                SqlParameter[] parameters =
               {
                    new SqlParameter("@Task", "selectall"),
                };
                DataSet dt = clsInstallmentTemplate.InstalTemplate_Reader(parameters);
                radGDInstallmentPlan.DataSource = dt.Tables.Count > 0 ? dt.Tables[0].DefaultView : null;
                
                //foreach (DataRow Row in dt.Tables[0].Rows)
                //{
                //    string[] row = new string[] { Row["InstalTempID"].ToString(), Row["Name"].ToString(), Row["Descp"].ToString(), Row["StartDate"].ToString(), Row["EndDate"].ToString(), Row["Phase"].ToString(), Row["PlotSize"].ToString() };
                //    radGDInstallmentPlan.Rows.Add(row);
                //}
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on showallData.", ex, "InstTemplateModify");
                frmobj.ShowDialog();
            }

        }
        #endregion

        private void addingControltoGrid()
        {
            try
            {
                GridViewCommandColumn BioInfo = new GridViewCommandColumn();
                BioInfo.Name = "Edit";
                BioInfo.UseDefaultText = true;
                BioInfo.FieldName = "InstalTempID";
                BioInfo.DefaultText = "Edit";
                BioInfo.Width = 80;
                BioInfo.TextAlignment = ContentAlignment.MiddleCenter;
                BioInfo.HeaderText = "Action";
                radGDInstallmentPlan.MasterTemplate.Columns.Add(BioInfo);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on addingControltoGrid.", ex, "InstTemplateModify");
                frmobj.ShowDialog();
            }

        }

        private void radDateSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // radGDInstallmentPlan.Rows.Clear();
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

                    //foreach (DataRow Row in dt.Tables[0].Rows)
                    //{
                    //    string[] row = new string[]
                    //    {
                    //        Row["InstalTempID"].ToString(), Row["Name"].ToString(), Row["Descp"].ToString(),
                    //        Row["StartDate"].ToString(), Row["EndDate"].ToString(), Row["Phase"].ToString(),
                    //        Row["PlotSize"].ToString()
                    //    };
                    //    radGDInstallmentPlan.Rows.Add(row);
                    //}
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

                    //foreach (DataRow Row in dt.Tables[0].Rows)
                    //{
                    //    string[] row = new string[]
                    //    {
                    //        Row["InstalTempID"].ToString(), Row["Name"].ToString(), Row["Descp"].ToString(),
                    //        Row["StartDate"].ToString(), Row["EndDate"].ToString(), Row["Phase"].ToString(),
                    //        Row["PlotSize"].ToString()
                    //    };
                    //    radGDInstallmentPlan.Rows.Add(row);
                    //}
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on radDateSearch_Click.", ex, "InstTemplateModify");
                frmobj.ShowDialog();
            }
        }

        private void radGDInstallmentPlan_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = radGDInstallmentPlan.CurrentCell.RowIndex;
                int columnindex = radGDInstallmentPlan.CurrentCell.ColumnIndex;
                if (e.Column.Name == "Edit")
                {
                    int ID = int.Parse(radGDInstallmentPlan.CurrentRow.Cells[1].Value.ToString());
                    Installment.InstTemplate.InstTemplateCreate obj = new InstTemplateCreate(ID.ToString());
                    obj.ShowDialog();
                    showallData();

                }

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on radGDInstallmentPlan_CellClick.", ex, "InstTemplateModify");
                //  frmobj.ShowDialog();
            }
        }
    }
}
