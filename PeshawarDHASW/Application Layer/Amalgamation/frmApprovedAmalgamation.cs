using PeshawarDHASW.Helper;
using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;


namespace PeshawarDHASW.Application_Layer.Amalgamation
{
    public partial class frmApprovedAmalgamation : Form
    {
        public frmApprovedAmalgamation()
        {
            InitializeComponent();
            this.radGridView1.CommandCellClick += radGridView1_CommandCellClick;

        }

        string branch = UserHelper.GetUserBranch();
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
               
                SqlParameter[] param =
                   {
                        new SqlParameter("@Task", "FindData"),
                        new SqlParameter("@FileNo",txtFileNo.Text),
                
                        new SqlParameter("@PlotNo",txtPlotNo.Text)
                    };
                    DataSet ds = Helper.SQLHelper.ExecuteDataset(
                        Helper.SQLHelper.createConnection(),
                        CommandType.StoredProcedure,
                        "App.USP_tbl_Amalgamation",
                        param
                    );

                radGridView1.AutoGenerateColumns = true;
                radGridView1.DataSource = ds.Tables[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    
        private void frmApprovedAmalgamation_Load(object sender, EventArgs e)
        {
            this.radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            radGridView1.Columns["ChallanID"].IsVisible = false;

            LoadData();
        }
        
        private void radGridView1_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name != "btnApproved")
                return;

            if (e.Row == null)
                return;

            int challanId = Convert.ToInt32(e.Row.Cells["ChallanID"].Value);
            string fileNo = Convert.ToString(e.Row.Cells["FileNo"].Value);
            int approvedBy = Models.clsUser.ID;
            //string remarks = "Approved from PMS";
            DateTime approvedDate = DateTime.Now;

            DialogResult result = MessageBox.Show(
                "Are you sure you want to approve amalgamation?",
                "Confirm Approval",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@Task", "AmalgamationChallanVerification"),
                    new SqlParameter("@ChallanID_Approval", challanId),
                    new SqlParameter("@ApprovedBy", approvedBy),
                   // new SqlParameter("@ApprovedRemarks", remarks),
                    new SqlParameter("@ApprovedDate", approvedDate)
                };

                Helper.SQLHelper.ExecuteNonQuery(
                    Helper.SQLHelper.createConnection(),
                    CommandType.StoredProcedure,
                    "App.USP_tbl_Amalgamation",
                    param
                );

                MessageBox.Show(
                    "Amalgamation approved successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                bool rslt = clsPluginHelper.ApplicationLogSaving(fileNo, Models.clsUser.ID + "-" + clsUser.Name + "-" + branch, "After - Modification of Recorcds", param, "frmApprovedAmalgamation - btnApproved", " SQLParam");

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            // Load Amalgamation data from DB and display on the form
            SqlParameter[] param =
             {
                new SqlParameter("@Task", "LoadAmalgDataOnGrid"),
            };

            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_tbl_Amalgamation", param);
            
            this.radGridView1.DataSource = ds.Tables[0].DefaultView;
           

            radGridView1.AutoGenerateColumns = true;
            radGridView1.DataSource = ds.Tables[0];

            // 🔹 Remove if already exists (avoid duplicate button)
            if (radGridView1.Columns.Contains("btnApproved"))
                radGridView1.Columns.Remove("btnApproved");

            // 🔹 Create button column
            GridViewCommandColumn btnApprove = new GridViewCommandColumn();
            btnApprove.Name = "btnApproved";
            btnApprove.HeaderText = "Action";
            btnApprove.UseDefaultText = true;
            btnApprove.DefaultText = "Approve";
            btnApprove.TextAlignment = ContentAlignment.MiddleCenter;

            radGridView1.Columns.Add(btnApprove);
        }

        
    }
}
