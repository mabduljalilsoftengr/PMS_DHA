using PeshawarDHASW.Data_Layer.Installment;
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
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Installment.InstPlan
{
    public partial class frmReviewPlanAgainstFileNo : Form
    {
        private string fileNo;

       
        public frmReviewPlanAgainstFileNo(string fileNo)
        {
            InitializeComponent();
            this.fileNo = fileNo;
        }

        private void frmReviewPlanAgainstFileNo_Load(object sender, EventArgs e)
        {
            LoadFileDetails(fileNo);
        }
        

        private void LoadFileDetails(string fileNo)
        {
            // Load file data from DB using fileNo and display on the form
            SqlParameter[] param =
             {
                new SqlParameter("@Task", "ReviewFormData"),
                new SqlParameter("@FileNoForReview", fileNo)
            };
            DataSet ds = clsInstallmentTemplate.CreateInsallmentTemplate(param);
            radgplan.DataSource = ds.Tables[0].DefaultView;
            //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //{
            //    radgplan.DataSource = ds.Tables[0].DefaultView;
            //}
            //else
            //{
            //    MessageBox.Show("No data returned for FileNo: " + fileNo);
            //}

        }

        private void radbbtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = RadMessageBox.Show(
                "Do you want to delete this record?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                RadMessageIcon.Question);

            if (result == DialogResult.Yes)
            {
                SqlParameter[] param =
                 {
                    new SqlParameter("@Task", "UpdateTemplateKeyToNull"),
                    new SqlParameter("@FileNoForTemplateKeyToNull", fileNo)
                };
                DataSet ds = clsInstallmentTemplate.CreateInsallmentTemplate(param);
                //radgplan.DataSource = ds.Tables[0].DefaultView;


                RadMessageBox.Show("Record has been deleted successfully.", "Deleted", MessageBoxButtons.OK, RadMessageIcon.Info);

                LoadFileDetails(fileNo);
            }
            else
            {
                RadMessageBox.Show("Delete action was cancelled.", "Cancelled", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
            }
        }

    }
}
