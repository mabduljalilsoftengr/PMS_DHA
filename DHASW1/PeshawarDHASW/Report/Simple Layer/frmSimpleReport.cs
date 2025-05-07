using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using PeshawarDHASW.Data_Layer.clsMemberShip;
using System.Drawing;
using System.IO;
using PeshawarDHASW.Data_Layer.clsFileMap;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Report.Datasets.Sample;
using PeshawarDHASW.Data_Layer.clsTFR;
using CrystalDecisions.Windows.Forms;
using System.Drawing.Printing;

namespace PeshawarDHASW.Report.Simple_Layer
{
    public partial class frmSimpleReport : Telerik.WinControls.UI.RadForm
    {
        
        public string FileNo { get; set; }
        public int NDCNo { get; set; }
        public int PurchaseTypeID { get; set; }
        public int TransferNo { get; set; }
        public frmSimpleReport(string get_FileNo, int get_NDCNo, int get_PurchaseID,int get_TransferNo)
        {
            FileNo = get_FileNo;
            NDCNo = get_NDCNo;
            PurchaseTypeID = get_PurchaseID;
            TransferNo = get_TransferNo;
            InitializeComponent();
        }
        public frmSimpleReport()
        {
            InitializeComponent();
        }

        private void frmSimpleReport_Load(object sender, EventArgs e)
        {
            //crystalReportViewer1.ShowPrintButton = false;


        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] parameter =
                {
                new SqlParameter("@Task","Select")
                };
                DataSet ds = cls_dl_FileMap.FileHintData_Retrive(parameter);
                ReportDocument rptdoc = new ReportDocument();
                string path = Application.StartupPath + "\\Report\\ReportFile\\CrystalReport1.rpt";
                rptdoc.Load(path);
                rptdoc.SetDataSource(ds.Tables[0]);


                crystalReportViewer1.ReportSource = rptdoc;
                crystalReportViewer1.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {

            try
            {
                SqlParameter[] parameter =
            {
                new SqlParameter("@Task","Select")
            };
                DataSet ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameter);
                ReportDocument rptdoc = new ReportDocument();
                string path = Application.StartupPath + "\\Report\\ReportFile\\CrystalReport2.rpt";
                rptdoc.Load(path);
                rptdoc.SetDataSource(ds.Tables[0]);


                crystalReportViewer1.ReportSource = rptdoc;
                crystalReportViewer1.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHintData_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] parameter =
            {
                new SqlParameter("@Task","Select")
            };
                DataSet ds = cls_dl_FileMap.FileHintData_Retrive(parameter);
                ReportDocument rptdoc = new ReportDocument();
                string path = Application.StartupPath + "\\Report\\ReportFile\\CrystalReportHintData.rpt";
                rptdoc.Load(path);
                rptdoc.SetDataSource(ds.Tables[0]);

                crystalReportViewer1.ReportSource = rptdoc;
                crystalReportViewer1.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnuserinfo_Click(object sender, EventArgs e)
        {
            try
            {

                
                ReportDocument rptdoc = new ReportDocument();
                string path = Application.StartupPath + "\\Report\\ReportFile\\CrystalReportUserInfo.rpt";
                rptdoc.Load(path);
                DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.Text,
                    "Select * from tbl_user");
                DataSet ds1 = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.Text,
                   "SELECT *  FROM [DvDbMembershipImages].[dbo].[tbl_MemberImages] WHERE ID = 35");
             //   ImageConverter(ds1);
                rptdoc.Database.Tables[0].SetDataSource(ds.Tables[0]);
               // rptdoc.Database.Tables[1].SetDataSource(ds1.Tables[0]);
                rptdoc.Database.Tables[1].SetDataSource(ImageConverter(ds1));
                crystalReportViewer1.ReportSource = rptdoc;
                
                crystalReportViewer1.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ImageConvert()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Image ImageConverter(DataSet ds)
        {
            //foreach (DataRow row in ds.Tables[0].Rows)
            //{
                
                byte[] imgData = (byte[])ds.Tables[0].Rows[0]["ImageFile"];
                MemoryStream ms = new MemoryStream(imgData);
                ms.Position = 0;
                return Image.FromStream(ms);

           // }
        }

        private void btntfrreport_Click(object sender, EventArgs e)
        {
            //FileNo = "OLO/B/RES/1001";
            try
            {
                SqlParameter[] prm =
                {
                    new SqlParameter("@Task","Select_Report_Data"),
                    new SqlParameter("@FileNo",FileNo),
                    new SqlParameter("@PurchaseTypeID",PurchaseTypeID),
                    new SqlParameter("@NDCNo",NDCNo)
                };
                DataSet ds = cls_dl_TFRHistory.TFRReport_Reader(prm);
                  //= SQLHelper.ExecuteDataset(
                  //                                clsMostUseVars.Connectionstring,
                  //                                CommandType.Text,
                  //  @"Select * FROM [dbo].[VW_TFR_Report]  WHERE FileNo LIKE"+FileNo);
                TransferReportDS dstfr = new TransferReportDS();
                dstfr.Tables[0].Merge(ds.Tables[0]);
                ReportDocument rd = new ReportDocument();
                string path = Application.StartupPath + "\\Report\\ReportFile\\TransferReport.rpt";
                rd.Load(path);
                //rd.SetDataSource((DataTable) dstfr.);
                crystalReportViewer1.ReportSource = rd;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
    }

        private void btnAccountStatment_Click(object sender, EventArgs e)
        {
            try
            {
                #region Sample Ackn Code
                //SqlParameter[] parameters =
                //{
                //    new SqlParameter("@Task","AccountStatment_Acknowledgement"),
                //    new SqlParameter("@FileNo","OLO/B/RES/1001"),  
                //};
                //DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.StoredProcedure,
                //   "App.usp_AccountReporting_Member", parameters);
                //AcknowledgementReport Ack = new AcknowledgementReport(); 
                //Ack.Tables[0].Constraints.Clear();
                //Ack.Tables[0].Merge(ds.Tables[0]);


                //ReportDocument rd = new ReportDocument();

                //string path = Application.StartupPath + "\\Report\\ReportFile\\AcknowledgementReport.rpt";
                //rd.Load(path);

                //rd.SetDataSource((DataTable)Ack.VW_AccountStatment_Acknowledgement);
                //crystalReportViewer1.ReportSource = rd;
                //crystalReportViewer1.Refresh();
                #endregion


                Report.Datasets.Sample.AcknowledgementReport dsAck = new Report.Datasets.Sample.AcknowledgementReport();
                SqlParameter[] parmtr =
                     {
                    new SqlParameter("@Task","Select_Report"),
                    new SqlParameter("@NumberParameter",2)
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
                    DataSet ReportDs = SQLHelper.ExecuteDataset(
                                                    clsMostUseVars.Connectionstring,
                                                    CommandType.StoredProcedure,
                                                    "App.usp_AccountReporting_Member",
                                                    prmt);
                    dsAck.VW_AccountStatment_Acknowledgement.Constraints.Clear();
                    dsAck.VW_AccountStatment_Acknowledgement.Merge(ReportDs.Tables[0],true,MissingSchemaAction.Error);
                  
                }
                ReportDocument rd = new ReportDocument();
                string path = Application.StartupPath + "\\Report\\ReportFile\\AcknowledgementReport.rpt";
                rd.Load(path);
                rd.SetDataSource(dsAck);
                crystalReportViewer1.ReportSource = rd;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private ReportDocument reportDocument;
        private PrintDocument printDocument;
        private CrystalReportViewer crystalViewer;
        

        private void btn_Print_Click(object sender, EventArgs e)
        {
            printing();
            this.Close();
        }

        private void printing()
        {
            try
            {
                //show Print Dialog
                PrintDialog printDialog = new PrintDialog();
                DialogResult dr = printDialog.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    ReportDocument crReportDocument = (ReportDocument)crystalReportViewer1.ReportSource;
                    System.Drawing.Printing.PrintDocument printDocument1 = new System.Drawing.Printing.PrintDocument();
                    //Get the Copy times
                    int nCopy = printDocument1.PrinterSettings.Copies;
                    //Get the number of Start Page
                    int sPage = printDocument1.PrinterSettings.FromPage;
                    //Get the number of End Page
                    int ePage = printDocument1.PrinterSettings.ToPage;
                    crReportDocument.PrintOptions.PrinterName = printDocument1.PrinterSettings.PrinterName;
                    //Start the printing process.  Provide details of the print job
                    DialogResult rdr = MessageBox.Show("Are you Sure","Printing the Transfer Report.",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (rdr == DialogResult.Yes)
                    {
                        crReportDocument.PrintToPrinter(nCopy, false, sPage, ePage);
                        #region Update TransferTracking Status to "ReadyForVerification"
                        SqlParameter[] prmt_r =
                        {
                        new SqlParameter("@Task","Update_TransferTracking_Status"),
                        new SqlParameter("@TFR_Status","ReadyForTFRVerification"),
                        new SqlParameter("@TransferNo",TransferNo)
                    };
                        int rslt = cls_dl_TransferTracking.TransferTracking_NonQuery(prmt_r);
                        if(rslt > 0)
                        {

                        }
                        else
                        {
                            MessageBox.Show("Transfer Tracking Status is not Updated.");
                        }
                        #endregion
                    }
                    else
                    {
                        MessageBox.Show("There is no Data for Print.");
                    }
                    //Form_Printerd = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
      


    }
}
