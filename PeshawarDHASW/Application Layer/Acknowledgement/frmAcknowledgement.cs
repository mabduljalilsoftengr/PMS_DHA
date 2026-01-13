using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.clsAcknowledgment;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Report.Simple_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Acknowledgement
{
    public partial class frmAcknowledgement : Telerik.WinControls.UI.RadForm
    {
        public frmAcknowledgement()
        {
            InitializeComponent();
        }

        Report.Datasets.Sample.AcknowledgementReport dsAck = new Report.Datasets.Sample.AcknowledgementReport();
        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                int Number = 0;
                bool number = int.TryParse(drpPrintNumber.SelectedItem.ToString(), out Number);
                string printstatus = drpPrinted_NotPrinted.SelectedItem.ToString();
                SqlParameter[] parmtr =
                     {
                    new SqlParameter("@Task","Select_Report"),
                    new SqlParameter("@NumberParameter",Number),
                    new SqlParameter("@PrintStatus",printstatus)
                    //new SqlParameter("@FileNo",FileNo),
                };

                DataSet ds = SQLHelper.ExecuteDataset(
                                                      clsMostUseVars.Connectionstring,
                                                      CommandType.StoredProcedure,
                                                      "App.usp_AccountReporting_Member",
                                                      parmtr);

                grdReportInfo.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnView_Click.", ex, "frmAcknowledgment");
                frmobj.ShowDialog();

            }


        }


        private DataSet DataCollectionGEneration()
        {
            Report.Datasets.Sample.AcknowledgementReport dsAck = new Report.Datasets.Sample.AcknowledgementReport();
            int Number = 0;
            bool number = int.TryParse(drpPrintNumber.SelectedItem.ToString(), out Number);
            SqlParameter[] parmtr =
                 {
                     
                    new SqlParameter("@Task","Select_Report"),
                    new SqlParameter("@NumberParameter", number?Number:0 )
                    //new SqlParameter("@FileNo",FileNo),
                };

            DataSet ds = SQLHelper.ExecuteDataset(
                                                  clsMostUseVars.Connectionstring,
                                                  CommandType.StoredProcedure,
                                                  "App.usp_AccountReporting_Member",
                                                  parmtr);
            dsAck.VW_Acknowledgment_Header.Merge(ds.Tables[0]);
            // radGridView1.DataSource = ds.Tables[0].DefaultView;

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                SqlParameter[] prmt =
                {
                    new SqlParameter("@Task","Report_Generate_Acknowledgement"),
                    new SqlParameter("@Ack_ID",row["AckID"].ToString())
                };
                //update one by one ack
                DataSet ReportDs = SQLHelper.ExecuteDataset(
                                                clsMostUseVars.Connectionstring,
                                                CommandType.StoredProcedure,
                                                "App.usp_AccountReporting_Member",
                                                prmt);
                dsAck.VW_AccountStatment_Acknowledgement.Constraints.Clear();
                dsAck.VW_AccountStatment_Acknowledgement.Merge(ReportDs.Tables[0], true, MissingSchemaAction.Error);
                //update query
                SqlParameter[] prmtr =
                {
                    new SqlParameter("@Task","Update_Acknowldgment"),
                    new SqlParameter("@Ack_ID",row["AckID"].ToString()),
                    new SqlParameter("@DateOfPrint",DateTime.Now.ToString()),
                    new SqlParameter("@Status","Printed")
                };
                int reslt = 0;
                reslt = cls_dl_Acknowledgment.Acknowledgment_NonQuery(prmtr);
            }
            return dsAck;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {

            frmAcknowledgementReportViewer frm_obj = new frmAcknowledgementReportViewer(DataCollectionGEneration());
            frm_obj.ShowDialog();

        }

        private void drpPrinted_NotPrinted_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if(drpPrinted_NotPrinted.Text == "Printed")
            {
                btnGenerate.Visible = false;
            }
            else
            {
                btnGenerate.Visible = true;
            }
        }

        private void frmAcknowledgement_Load(object sender, EventArgs e)
        {

        }
    }
}
