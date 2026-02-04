using Bytescout.BarCode;
using CrystalDecisions.CrystalReports.Engine;
using PeshawarDHASW.Models;
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
    public partial class IntimationReport : Telerik.WinControls.UI.RadForm
    {
        public IntimationReport()
        {
            InitializeComponent();
        }
        public IntimationReport(string param_FileNo)
        {
            InitializeComponent();
            PrintReport(param_FileNo);
        }

        private void btnFileIntimationSearch_Click(object sender, EventArgs e)
        {
           
        }
        private void PrintReport(string FileNo)
        {
            if (!string.IsNullOrEmpty(FileNo))
            {
                SqlParameter[] param = { new SqlParameter("@FileNo", Helper.clsPluginHelper.DbNullIfNullOrEmpty(FileNo)), new SqlParameter("@UserID", clsUser.ID) };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_Intimation", param);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        Barcode qrc = new Barcode(SymbologyType.QRCode);
                        qrc.DrawCaption = false;

                        // set barcode object's Value property to a value of a field
                        // you want to be used for barcode creation
                        // we use 5 first symbols of product name

                        string str = ds.Tables[0].Rows[0]["FileMapKey"].ToString()
                            + "|" + ds.Tables[0].Rows[0]["FileNo"].ToString()
                            + "|" + ds.Tables[0].Rows[0]["FirstBuyerName"].ToString()
                            + "|" + ds.Tables[0].Rows[0]["CNICNos"].ToString()
                            + "|" + ds.Tables[0].Rows[0]["PlotSize"].ToString()
                            + "|" + ds.Tables[0].Rows[0]["FileIssueDate"].ToString()
                            + "|" + ds.Tables[0].Rows[0]["LandProviderName"].ToString()
                            + "|" + ds.Tables[0].Rows[0]["InvestorFathers"].ToString()
                            + "|" + ds.Tables[0].Rows[0]["LandBrIssueDate"].ToString()
                            + "|" + ds.Tables[0].Rows[0]["Addresss"].ToString()
                            + "|" + ds.Tables[0].Rows[0]["MobileNos"].ToString();



                        qrc.Value = str; //(dr["Name"] as string).Substring(0, 5);

                        // retrieve generated image bytes
                        byte[] qrcodeBytes = qrc.GetImageBytesWMF();

                        // fill virtual field with generated image bytes
                        ds.Tables[0].Rows[0]["QRCode"] = qrcodeBytes;



                        Report.IntimationReport.IntimationDS obj = new Report.IntimationReport.IntimationDS();

                        //DataSet ds = Data_Layer.Installment.clsInstallmentTemplate.InstalTemplate_Reader(searchparam);
                        //Report.ScheuldeCopy.ScheudleCopyDs dstrpt = new Report.ScheuldeCopy.ScheudleCopyDs();
                        obj.FileInfo.Merge(ds.Tables[0], true, MissingSchemaAction.Ignore);
                        //obj.FeeData.Merge(ds.Tables[1], true, MissingSchemaAction.Ignore);
                        ReportDocument rptdoc = new ReportDocument();
                        string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\IntimationReport\\RptIntimationReport.rpt";
                        rptdoc.Load(path);
                        rptdoc.SetDataSource(obj);
                        ReportViewerIntimation.ReportSource = rptdoc;
                        ReportViewerIntimation.Refresh();
                    }
                }
            }
        }
        private void IntimationReport_Load(object sender, EventArgs e)
        {

        }
    }
}
