using PeshawarDHASW.Data_Layer.Installment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Installment.InstPlan
{
    public partial class frmInstPlanAddNewRow : Telerik.WinControls.UI.RadForm
    {
        public frmInstPlanAddNewRow()
        {
            InitializeComponent();
        }

        private void btnget_Click(object sender, EventArgs e)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@Task", "GetExistingPlan"),
                new SqlParameter("@FileNo", txtFileNo.Text)

            };
            DataSet _ds = cls_dl_instPlan.InstalPlanReader(param);
            grdplandata.DataSource = _ds.Tables[0].DefaultView;
        }

        private void btnCreateInstallment_Click(object sender, EventArgs e)
        {
           SqlParameter[] param =
           {
                new SqlParameter("@Task", "GenerateNewInstallment"),
                new SqlParameter("@InstNo", txtinstl.Text),
                new SqlParameter("@Descp", txtdesc.Text),
                new SqlParameter("@DueDate", dtpduedate.Value.Date),
                new SqlParameter("@Amount", txtamount.Text),
                new SqlParameter("@InstallmentMode", ddlinstallmentmode.Text),
                new SqlParameter("@CODE", ddlcode.Text),
                new SqlParameter("@userID",Models.clsUser.ID),
                new SqlParameter("@FileNo", txtFileNo.Text), 
                new SqlParameter("@AccntSeries", txtseries.Text)
            };
            int rslt = cls_dl_instPlan.InstalPlanNonQuery(param);
            if(rslt > 0)
            {
                MessageBox.Show("Successfull.");
                btnget_Click(sender, e);
            }
        }
    }
}
