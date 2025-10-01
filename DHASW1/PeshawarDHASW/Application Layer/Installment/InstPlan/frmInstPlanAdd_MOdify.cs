using System;
using System.Data;
using System.Data.SqlClient;
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
        private int instal_Templateid = 0;
        private int PLANID = 0;
        private string fileNo;
        private int oldacctseries_ = 0;
       

        public frmInstPlanAdd_MOdify()
        {
            InitializeComponent();
            
        }

        public frmInstPlanAdd_MOdify(int instalTemplateID, string FileNo)
        {
            instal_Templateid = instalTemplateID;
            fileNo = FileNo;
            InitializeComponent();
        }

        public frmInstPlanAdd_MOdify(int planid, int instal_Template_ID, string FileNo,int oldacctseries)
        {
            PLANID = planid;
            instal_Templateid = instal_Template_ID;
            fileNo = FileNo;
            oldacctseries_ = oldacctseries;
            InitializeComponent();
        }
        
        private void Save_OR_Update()
        {

            try
            {
                if (instal_Templateid > 0)
                {
                    //decimal amount = decimal.Parse(txtamount.Text.Trim()); // for decimals

                    SqlCommand cmd = new SqlCommand("App.USP_InstallmentPlan");

                    if (PLANID > 0) // Update
                    {
                        cmd.Parameters.AddWithValue("@Task", "update");
                        cmd.Parameters.Add("@PlanID", SqlDbType.Int).Value = PLANID;
                        cmd.Parameters.AddWithValue("@FileNo", fileNo);
                        cmd.Parameters.AddWithValue("@OldAccntSeries", oldacctseries_);
                    }
                    else // Insert
                    {
                        cmd.Parameters.AddWithValue("@Task", "insert");
                        cmd.Parameters.AddWithValue("@FileNo", fileNo);
                    }

                    cmd.Parameters.Add("@DueDate", SqlDbType.VarChar, 10).Value = dtpduedate.Value.ToString("yyyy-MM-dd");
                    //cmd.Parameters.Add("@DueDate", SqlDbType.DateTime).Value = DateTime.Parse(dtpduedate.Text);
                    cmd.Parameters.AddWithValue("@InstNo", txtinstlno.Text);
                    cmd.Parameters.Add("@instalTempID", SqlDbType.Int).Value = instal_Templateid;
                    cmd.Parameters.AddWithValue("@Descp", txtdescrip.Text);
                    cmd.Parameters.AddWithValue("@Amount", txtamount.Text);
                    cmd.Parameters.AddWithValue("@Remarks", txtremarks.Text);
                    cmd.Parameters.AddWithValue("@AcctStSeries", txtAcctSeries.Text); //added acctSeries
                    cmd.Parameters.AddWithValue("@InstallmentMode", ddlinstallmentmode.Text);
                    cmd.Parameters.AddWithValue("@CODE", ddlcode.Text);
                    cmd.Parameters.AddWithValue("@userID", Models.clsUser.ID);


                    //new SqlParameter("@InstallmentMode", ddlinstallmentmode.Text),
                    //new SqlParameter("@CODE", ddlcode.Text),
                    int result = cls_dl_instPlan.InstalPlan_NonQuery(cmd);
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

                if (PLANID > 0)
                {
                    SqlParameter[] parameters =
                    {
                        new SqlParameter("@Task", "select"),
                        new SqlParameter("@PlanID", PLANID),

                    };

                    DataSet ds = cls_dl_instPlan.InstalTemplate_Reader(parameters, "App.USP_InstallmentPlan");

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        txtinstlno.Text = row["InstNo"].ToString();
                        txtdescrip.Text = row["Descp"].ToString();
                        txtamount.Text = row["Amount"].ToString();
                        txtremarks.Text = row["Remarks"].ToString();
                        dtpduedate.Value = DateTime.Parse(row["DueDate"].ToString());
                        txtAcctSeries.Text = row["AcctStSeries"].ToString();
                        ddlinstallmentmode.Text = row["InstallmentMode"].ToString();
                        ddlcode.Text = row["Code"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmInstPlanAdd_MOdify_Load.", ex, "frmInstPlanAdd_Modify");
                frmobj.ShowDialog();
            }
        }

        private void txtamount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys (like backspace), digits, and one decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Reject the input
            }

            //// Block second decimal point
            //if (e.KeyChar == '.' && (sender as TextBox).Text.Contains('.'))
            //{
            //    e.Handled = true;
            //}
        }
    }
}
