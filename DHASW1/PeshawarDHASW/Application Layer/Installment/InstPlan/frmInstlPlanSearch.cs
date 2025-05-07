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
using Telerik.WinControls;
using Telerik.WinControls.UI;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.Installment.InstPlan
{
    public partial class frmInstlPlanSearch : Telerik.WinControls.UI.RadForm
    {
        public frmInstlPlanSearch()
        {
            InitializeComponent();
        }

        private void rad_dropDown_Template_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {

                if (rad_dropDown_Template.SelectedIndex != 0)
                {
                    string str = rad_dropDown_Template.SelectedValue.ToString();
                    var idtemplete = int.Parse(str);
                    SqlParameter[] parameters =
                    {
                        new SqlParameter("@Task", "select"),
                        new SqlParameter("@InstalTempID", str)
                    };
                    DataSet ds = clsInstallmentTemplate.InstalTemplate_Reader(parameters);
                    foreach (DataRow dataRow in ds.Tables[0].Rows)
                    {
                        radstartdate.Text = DateTime.Parse(dataRow["StartDate"].ToString()).ToString("dd-MM-yyyy");
                        radenddate.Text = DateTime.Parse(dataRow["EndDate"].ToString()).ToString("dd-MM-yyyy");
                        raddescrip.Text = dataRow["Descp"].ToString();
                        radplotsize.Text = dataRow["PlotSize"].ToString();
                        radphase.Text = dataRow["Phase"].ToString();
                    }
                    LoadDefaultData(idtemplete.ToString());
                }
                else
                {
                    radstartdate.Text = "";
                    radenddate.Text = "";
                    radplotsize.Text = "";
                    radphase.Text = "";
                    raddescrip.Text = "";
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on rad_dropDown_Template_SelectedIndexChanged.", ex, "frmInstPlanSearch");
                frmobj.ShowDialog();

            }

        }

        private void LoadDefaultData()
        {
            try
            {

                SqlCommand cmd = new SqlCommand("App.USP_InstallmentPlan");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Task", "select");
                DataSet ds = cls_dl_instPlan.InstalPlan_Reader(cmd);
                radgvplan.DataSource = ds.Tables[0].DefaultView;

                //foreach (DataRow Row in ds.Tables[0].Rows)
                //{
                //    object[] row = new object[]
                //    {
                //        Row["PlanID"].ToString(),
                //        Row["Template Name"].ToString(),
                //        Row["Installment No"].ToString(),
                //        Row["Description"].ToString(),
                //        DateTime.Parse(Row["Due Date"].ToString()),
                //        Row["Amount"].ToString(),
                //        Row["Remarks"].ToString()

                //    };
                //    radgvplan.Rows.Add(row);
                //}
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LoadDefaultData.", ex, "frmInstPlanSearch");
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


        private void frmInstlPlanSearch_Load(object sender, EventArgs e)
        {
            try
            {

                RadListDataItem Select = new RadListDataItem();
                Select.Value = 0;
                Select.Text = "-- Select --";
                this.rad_dropDown_Template.Items.Add(Select);
                SqlParameter[] param =
                  {
                    new SqlParameter("@Task", "select")
                };

                foreach (DataRow row in clsInstallmentTemplate.InstalTemplate_Reader(param).Tables[0].Rows)
                {
                    RadListDataItem dataItem = new RadListDataItem();
                    dataItem.Value = row["InstalTempID"].ToString();
                    dataItem.Text = row["TemplateName"].ToString();
                    this.rad_dropDown_Template.Items.Add(dataItem);
                }
                LoadDefaultData();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmInstlPlanSearch_Load.", ex, "frmInstPlanSearch");
                frmobj.ShowDialog();
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.radgvplan.PrintStyle.PrintHeaderOnEachPage = true;
            this.radgvplan.PrintStyle.PrintHiddenRows = false;
            this.radgvplan.PrintStyle.PrintGrouping = true;
            this.radgvplan.PrintStyle.PrintSummaries = true;
            this.radgvplan.PrintStyle.HeaderCellFont = new Font("Arial", 9, FontStyle.Bold);
            this.radgvplan.PrintStyle.HeaderCellBackColor = Color.LightBlue;
            this.radgvplan.PrintStyle.GroupRowFont = new Font("Helvetica", 10, FontStyle.Regular);
            this.radgvplan.PrintStyle.GroupRowBackColor = Color.PaleGoldenrod;
            this.radgvplan.PrintPreview();
        }
    }
}
