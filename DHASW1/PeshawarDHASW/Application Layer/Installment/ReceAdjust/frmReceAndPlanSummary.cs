using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.Installment;
using PeshawarDHASW.Models;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Installment.ReceAdjust
{
    public partial class frmReceAndPlanSummary : Telerik.WinControls.UI.RadForm
    {
        public frmReceAndPlanSummary()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            
            SqlParameter[] parameters =
            {
                new SqlParameter("@Task","PlanInfo"),
                new SqlParameter("@FileNo",txtfileno.Text),  
            };
            DataSet dsPlaninfo = cls_dl_ReceAndPlanSum.ReceAndPlanSumReader(parameters);
            radPlanInfo.DataSource = dsPlaninfo.Tables[0].DefaultView;

            SqlParameter[] parametersReceInfo =
            {
                new SqlParameter("@Task","ReceInfo"),
                new SqlParameter("@FileNo",txtfileno.Text),
            };
            DataSet dsReceInfo = cls_dl_ReceAndPlanSum.ReceAndPlanSumReader(parametersReceInfo);
            radReceInfo.DataSource = dsReceInfo.Tables[0].DefaultView;

            SqlParameter[] parametersSurchargeSum =
            {
                new SqlParameter("@Task","SurchargeSum"),
                new SqlParameter("@FileNo",txtfileno.Text),
            };
            DataSet dsSurchargeSum = cls_dl_ReceAndPlanSum.ReceAndPlanSumReader(parametersSurchargeSum);
            Double SurchargeSumvar = Double.Parse(dsSurchargeSum.Tables[0].Rows[0]["SurchargeSum"].ToString());
            txtsurchargeamout.Text = SurchargeSumvar.ToString();

            SqlParameter[] parametersReceSum =
           {
                new SqlParameter("@Task","ReceSum"),
                new SqlParameter("@FileNo",txtfileno.Text),
            };
            DataSet dsReceSum = cls_dl_ReceAndPlanSum.ReceAndPlanSumReader(parametersReceSum);
            Double ReceeSumvar = Double.Parse(dsReceSum.Tables[0].Rows[0]["ReceSum"].ToString());
            txtreceamount.Text = ReceeSumvar.ToString();
            SqlParameter[] parametersInstallmentSum =
         {
                new SqlParameter("@Task","InstallmentSum"),
                new SqlParameter("@FileNo",txtfileno.Text),
            };
            DataSet dsInstallmentSum = cls_dl_ReceAndPlanSum.ReceAndPlanSumReader(parametersInstallmentSum);
            Double InstalSumvar = Double.Parse(dsInstallmentSum.Tables[0].Rows[0]["InstallmentSum"].ToString());
            txtinstallmentamount.Text = InstalSumvar.ToString();

            Double Result = (ReceeSumvar - InstalSumvar) - SurchargeSumvar;
            txtextrabalance.Text = Result.ToString();
        }

        private void frmReceAndPlanSummary_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
        }
    }
}
