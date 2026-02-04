using CrystalDecisions.CrystalReports.Engine;
using PeshawarDHASW.Data_Layer.NDC;
using PeshawarDHASW.Models;
using PeshawarDHASW.Report.Datasets.NDC_DataSet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.NDC
{
    public partial class frm_SurchargInstallmentInfoDetailReport_ForNDC : Telerik.WinControls.UI.RadForm
    {
        private DataSet dst { get; set; }
        public frm_SurchargInstallmentInfoDetailReport_ForNDC()
        {
            InitializeComponent();
        }
        public frm_SurchargInstallmentInfoDetailReport_ForNDC(DataSet ds)
        {
            InitializeComponent();
            dst = ds;
        }

        private void frm_SurchargInstallmentInfoDetailReport_ForNDC_Load(object sender, EventArgs e)
        {
            try
            {
                #region Get Current Owners From FileNo
                string sellerNameString = "";
                string fileno = dst.Tables[0].Rows[0]["FileNo"].ToString();
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","GetCurrentOwnerAgainstFileNo"),
                new SqlParameter("@FileNo",fileno)
            };
                DataSet tsd = cls_dl_NDC.NdcRetrival(prm);
                foreach (DataRow dr in tsd.Tables[0].Rows)
                {
                    sellerNameString = dr["Name"].ToString() + "," + sellerNameString;
                }
                // Delete the Last Character from the String
                while (sellerNameString.EndsWith(","))
                    sellerNameString = sellerNameString.Substring(0, sellerNameString.Length - 1);

                DataTable dtb = new DataTable();
                dtb.Clear();
                dtb.Columns.Add("SellerNameString");
                dtb.Columns.Add("UserName");
                DataRow dr1 = dtb.NewRow();
                dr1["SellerNameString"] = sellerNameString;
                dr1["UserName"] = clsUser.Name.ToUpper();
                dtb.Rows.Add(dr1);
                #endregion
                SurchargInstallmentInfoDetailReport_ForNDC_DataSet ds_t = new SurchargInstallmentInfoDetailReport_ForNDC_DataSet();
                ds_t.Tables[0].Merge(dst.Tables[0], true, MissingSchemaAction.Ignore);
                ds_t.Tables[1].Merge(dtb, true, MissingSchemaAction.Ignore);
                //dstfr.Tables[0].Merge(ds.Tables[0], true, MissingSchemaAction.Ignore);
                //ds.EnforceConstraints = true;
                ReportDocument rd = new ReportDocument();
                string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\My_Reports\\SurchargeInstallmentInfoDetailReport_report.rpt";
                rd.Load(path);
                rd.SetDataSource(ds_t);
                //rd.SetDataSource(ds_t.Tables[1]);
                crprtv_instsurchage.ReportSource = rd;
                crprtv_instsurchage.Refresh();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void crprtv_instsurchage_Load(object sender, EventArgs e)
        {

        }
    }
}
