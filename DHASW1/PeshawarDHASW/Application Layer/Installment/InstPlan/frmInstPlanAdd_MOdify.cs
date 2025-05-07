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
using PeshawarDHASW.Models;
using Telerik.WinControls;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.Installment.InstPlan
{
    public partial class frmInstPlanAdd_MOdify : Telerik.WinControls.UI.RadForm
    {
        private string instal_Templateid = "";
        private string PLANID = "";
        public frmInstPlanAdd_MOdify()
        {
            InitializeComponent();
        }

        public frmInstPlanAdd_MOdify( string instalTemplateID)
        {
            instal_Templateid = instalTemplateID;
            InitializeComponent();
        }
        public frmInstPlanAdd_MOdify(string planid, string instal_Template_ID)
        {
            PLANID = planid;
            instal_Templateid = instal_Template_ID;
            InitializeComponent();
        }

        private void Save_OR_Update()
        {
            try
            {
                //must provide Template Plan ID
                if (instal_Templateid != "")
                {
                    //For Update must provide PLANID
                    if (PLANID != "")
                    {
                        SqlCommand cmd = new SqlCommand("App.USP_InstallmentPlan");
                        cmd.Parameters.AddWithValue("@Task", "update");
                        cmd.Parameters.Add("@DueDate", SqlDbType.DateTime).Value = DateTime.Parse(dtpduedate.Text);
                        cmd.Parameters.AddWithValue("@PlanID", PLANID);
                        cmd.Parameters.AddWithValue("@InstNo", txtinstlno.Text);
                        cmd.Parameters.AddWithValue("@instalTempID", instal_Templateid);
                        cmd.Parameters.AddWithValue("@Descp", txtdescrip.Text);
                        cmd.Parameters.AddWithValue("@Amount", txtamount.Text);
                        cmd.Parameters.AddWithValue("@Remarks", txtremarks.Text);
                        cmd.Parameters.AddWithValue("@userID", Models.clsUser.ID);

                        int result = 0;
                        result = cls_dl_instPlan.InstalPlan_NonQuery(cmd);
                        if (result > 0)
                        {
                            this.Close();
                            // MessageBox.Show("Successful");
                        }
                        else
                        {
                            MessageBox.Show("Try Again! or Contact to Admin!");
                        }
                    }
                    //Only Installment Template ID Need
                    else
                    {
                        SqlCommand cmd = new SqlCommand("App.USP_InstallmentPlan");
                        cmd.Parameters.AddWithValue("@Task", "insert");
                        cmd.Parameters.Add("@DueDate", SqlDbType.DateTime).Value = DateTime.Parse(dtpduedate.Text);
                        cmd.Parameters.AddWithValue("@InstNo", txtinstlno.Text);
                        cmd.Parameters.AddWithValue("@instalTempID", instal_Templateid);
                        cmd.Parameters.AddWithValue("@Descp", txtdescrip.Text);
                        cmd.Parameters.AddWithValue("@Amount", txtamount.Text);
                        cmd.Parameters.AddWithValue("@Remarks", txtremarks.Text);
                        cmd.Parameters.AddWithValue("@userID", Models.clsUser.ID);
                        int result = 0;
                        result = cls_dl_instPlan.InstalPlan_NonQuery(cmd);
                        if (result > 0)
                        {
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Try Again! or Contact to Admin!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Save_OR_Update.", ex, "frmInstPlanAdd_Modify");
                frmobj.ShowDialog();
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            Save_OR_Update();
        }

        private void frmInstPlanAdd_MOdify_Load(object sender, EventArgs e)
        {
            try
            {
                this.ThemeName = clsUser.ThemeName;
                ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task", "select"),
                    new SqlParameter("@PlanID", PLANID)
                };
                DataSet ds = cls_dl_instPlan.InstalTemplate_Reader(parameters, "App.USP_InstallmentPlan");
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    txtinstlno.Text = row["InstNo"].ToString();
                    txtdescrip.Text = row["Descp"].ToString();
                    txtamount.Text = row["Amount"].ToString();
                    txtremarks.Text = row["Remarks"].ToString();
                    dtpduedate.Value = DateTime.Parse(row["DueDate"].ToString());
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmInstPlanAdd_MOdify_Load.", ex, "frmInstPlanAdd_Modify");
                frmobj.ShowDialog();

            }
        }
    }
}
