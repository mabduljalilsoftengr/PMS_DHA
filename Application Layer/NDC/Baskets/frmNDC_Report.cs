using CrystalDecisions.CrystalReports.Engine;
using PeshawarDHASW.Data_Layer.NDC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Models;
using PeshawarDHASW.Report.Datasets.NDC_DataSet;
using Telerik.WinControls;
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.clsStampDuty;
using Bytescout.BarCode;

namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    public partial class frmNDC_Report : Telerik.WinControls.UI.RadForm
    {
        public int NDCNo { get; set; } = 0;
        public string stringcheck { get; set; }
        private string rdflst { get; set; }
        private DataSet dst_NDC_Bulk_Report { get; set; }
        private DataTable dtbl { get; set; }


        public frmNDC_Report()
        {
            InitializeComponent();
        }
        public frmNDC_Report(DataTable dtb, string getstring, int ndcno)
        {
            InitializeComponent();
            dtbl = dtb;
            stringcheck = getstring;
            NDCNo = ndcno;

        }
        public frmNDC_Report(int get_NDCNo, string getstring, string rdyfrfnlprnt)
        {
            InitializeComponent();
            NDCNo = get_NDCNo;
            stringcheck = getstring;
            rdflst = rdyfrfnlprnt;
        }
        public frmNDC_Report(DataSet dst1, string getstring)
        {
            InitializeComponent();
            stringcheck = getstring;
            dst_NDC_Bulk_Report = dst1;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                frmGoBackRemarks frm = new frmGoBackRemarks();
                frm.ShowDialog();
                string rmksGoBack = clsNDC.goBackRemarks;
                SqlParameter[] prmt =
                {
                new SqlParameter("@Task","Update_NDC_Status"),
                new SqlParameter("@StatusofNDC","Incomplete"),
                new SqlParameter("@NDCNo",NDCNo),
                new SqlParameter("@GoBack_Remarks",rmksGoBack)
                };
                int rslt = 0;
                rslt = cls_dl_NDC.NdcNonQuery(prmt);
                if (rslt > 0)
                {
                    MessageBox.Show("Successfull Back.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnBack_Click.", ex, "frmNDC_Report");
                frmobj.ShowDialog();
            }

        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            try
            {
                if (
                  MessageBox.Show("Are you sure,That you Print the NDC.",
                  "Warning",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    if (rdflst == "ReadyForFinalPrint")
                    {
                        SqlParameter[] prmt =
                         {
                         new SqlParameter("@Task","Update_NDC_Status"),
                         new SqlParameter("@StatusofNDC","ReadyForTFRAppointment"),
                         new SqlParameter("@NDCNo",NDCNo)
                         };
                        int rslt = 0;
                        rslt = cls_dl_NDC.NdcNonQuery(prmt);
                        if (rslt > 0)
                        {
                            MessageBox.Show("Successfull Forwarded.");
                            this.Close();
                        }
                    }
                    else
                    {
                        SqlParameter[] prmt =
                         {
                         new SqlParameter("@Task","Update_NDC_Status"),
                         new SqlParameter("@StatusofNDC","PrintAndNotSigned"),
                         new SqlParameter("@NDCNo",NDCNo)
                         };
                        int rslt = 0;
                        rslt = cls_dl_NDC.NdcNonQuery(prmt);
                        if (rslt > 0)
                        {
                            MessageBox.Show("Successfull Forwarded.");
                            this.Close();
                        }
                    }



                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnForward_Click.", ex, "frmNDC_Report");
                frmobj.ShowDialog();
            }

        }

        private void frmNDC_Report_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);

            GenerateReport();
            NDCPreparedReviewBy();
        }
        private void NDCPreparedReviewBy()
        {
            try
            {
                if (NDCNo != 0)
                {
                    SqlParameter[] parameter =
                    {
                    new SqlParameter("@Task","NDCPreparedReviewedBy"),
                    new SqlParameter("@NDCNo",NDCNo)
                    };
                    DataSet ds = cls_dl_NDC.NdcRetrival(parameter);
                    lblPreparedby.Text = ds.Tables[0].Rows[0]["PreparedByName"].ToString();
                    lblPreparedbyDate.Text = ds.Tables[0].Rows[0]["PreparedByDate"].ToString();
                    lblReviewby.Text = ds.Tables[0].Rows[0]["ReviewedByName"].ToString();
                    lblReviewedbyDate.Text = ds.Tables[0].Rows[0]["ReviewedByDate"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GenerateReport()
        {
            // NDCNo = 13;
            try
            {
                if (stringcheck == "NDCReport")
                {
                    #region NDC Report
                    ReportDocument rptdoc = new ReportDocument();
                    SqlParameter[] parameter =
                    {
                    new SqlParameter("@Task","NDCReport"),
                    new SqlParameter("@NDCNo",NDCNo),
                    new SqlParameter("@string","")
                    };
                    DataSet ds = cls_dl_NDC.NdcRetrival(parameter);
                    NDC_DataSet NDC_ds = new NDC_DataSet();

                    DataTable dt = new DataTable();
                    dt.Merge(ds.Tables[0], true, MissingSchemaAction.Ignore);

                    ds.Tables[0].Columns.Add(new DataColumn("BarcodeImage", typeof(byte[])));
                    ds.Tables[0].Columns.Add(new DataColumn("QRcodeImage", typeof(byte[])));
                    #region Bar Code
                    //////////////  Bar code start //////////////////
                    // create barcode object
                    Barcode bc = new Barcode(SymbologyType.Code128);
                    bc.DrawCaption = false;
                    //bc.NarrowBarWidth = 1;
                    //bc.WideToNarrowRatio = 2;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        // set barcode object's Value property to a value of a field
                        // you want to be used for barcode creation
                        // we use 5 first symbols of product name
                        string str = dr["FilePlotNo"] + "," + dr["NDCNo"];
                        bc.Value = str; //(dr["Name"] as string).Substring(0, 5);

                        // retrieve generated image bytes
                        byte[] barcodeBytes = bc.GetImageBytesWMF();

                        // fill virtual field with generated image bytes
                        dr["BarcodeImage"] = barcodeBytes;
                    }
                    ////////////// Bar code End //////////////////
                    #endregion
                    #region QR Code
                    //////////////  Bar code start //////////////////
                    // create barcode object
                    Barcode qrc = new Barcode(SymbologyType.QRCode);
                    qrc.DrawCaption = false;
                    //bc.NarrowBarWidth = 1;
                    //bc.WideToNarrowRatio = 2;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        // set barcode object's Value property to a value of a field
                        // you want to be used for barcode creation
                        // we use 5 first symbols of product name
                        string str = dr["FilePlotNo"] + "," + dr["NDCNo"];
                        qrc.Value = str; //(dr["Name"] as string).Substring(0, 5);

                        // retrieve generated image bytes
                        byte[] qrcodeBytes = qrc.GetImageBytesWMF();

                        // fill virtual field with generated image bytes
                        dr["QRcodeImage"] = qrcodeBytes;
                    }
                    ////////////// Bar code End //////////////////
                    #endregion

                    //NDC_ds.EnforceConstraints = false;
                    NDC_ds.Tables[0].Merge(ds.Tables[0], true, MissingSchemaAction.Ignore);

                    SqlParameter[] prmStampDutyChallan =
                    {
                        new SqlParameter("@Task","GetStampDutyChallan"),
                        new SqlParameter("@CNIC",""),
                        new SqlParameter("@FileNo",NDC_ds.Tables[0].Rows[0]["FilePlotNo"])
                    };

                    DataSet dstStmpDtyChln = cls_dl_StampDuty.StampDuty_Reader(prmStampDutyChallan);
                    //drpStmpRefNo_.Text = dstStmpDtyChln.Tables[0].Rows[0]["ChalanNo"].ToString();
                    //txtStampDuty_.Text = dstStmpDtyChln.Tables[0].Rows[0]["ChallanAmount"].ToString();

                    NDC_ds.Tables[0].Rows[0]["StampDutyRefNo"] = dstStmpDtyChln.Tables[0].Rows[0]["ChalanNo"].ToString();
                    NDC_ds.Tables[0].Rows[1]["StampDutyRefNo"] = dstStmpDtyChln.Tables[0].Rows[0]["ChalanNo"].ToString();
                    //NDC_ds.Tables[0].Rows[2]["StampDutyRefNo"] = dstStmpDtyChln.Tables[0].Rows[0]["ChalanNo"].ToString();


                    string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\My_Reports\\NDC_Report.rpt";
                    if (!string.IsNullOrEmpty(path))
                    {
                        rptdoc.Load(path);
                    }

                    //NDC_ds.EnforceConstraints = true;
                    rptdoc.SetDataSource(NDC_ds);
                    NDC_ReportViewer.ReportSource = rptdoc;
                    NDC_ReportViewer.Refresh();
                    #endregion
                }
                else if (stringcheck == "CheckListReport")
                {
                    #region Check List Report
                    ReportDocument rptdoc = new ReportDocument();
                    SqlParameter[] parameter =
                    {
                    new SqlParameter("@Task","Calculation_Of_UrgentCharges_ChecklistPrint"),
                    new SqlParameter("@NDCNo",NDCNo)
                    };
                    DataSet ds = cls_dl_NDC.NdcRetrival(parameter);

                    NDC_DataSet NDC_ds = new NDC_DataSet();
                    NDC_ds.Tables[4].Merge(ds.Tables[0], true, MissingSchemaAction.Ignore);


                    string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\My_Reports\\NDC_Checklist_Report.rpt";
                    if (!string.IsNullOrEmpty(path))
                    {
                        rptdoc.Load(path);
                    }

                    NDC_ds.EnforceConstraints = true;
                    rptdoc.SetDataSource(NDC_ds);
                    NDC_ReportViewer.ReportSource = rptdoc;
                    NDC_ReportViewer.Refresh();
                    #endregion
                }
                else if (stringcheck == "NDC_Bulk_Report")
                {
                    #region NDC Bulk Report
                    #region Button Visibility
                    btnBack.Visible = false;
                    btnForward.Visible = false;
                    radLabel1.Visible = false;
                    radLabel4.Visible = false;
                    radLabel3.Visible = false;
                    radLabel5.Visible = false;
                    lblPreparedby.Visible = false;
                    lblPreparedbyDate.Visible = false;
                    lblReviewby.Visible = false;
                    lblReviewedbyDate.Visible = false;
                    #endregion
                    ReportDocument rptdc = new ReportDocument();
                    NDC_DataSet NDC_ds = new NDC_DataSet();
                    NDC_ds.Tables["tbl_NDCReportBulk"].Merge(dst_NDC_Bulk_Report.Tables[0], true, MissingSchemaAction.Ignore);

                    string path1 = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\My_Reports\\NDC_ReportBulk.rpt";
                    if (!string.IsNullOrEmpty(path1))
                    {
                        rptdc.Load(path1);
                    }

                    //NDC_ds.EnforceConstraints = true;
                    rptdc.SetDataSource(NDC_ds);
                    NDC_ReportViewer.ReportSource = rptdc;
                    NDC_ReportViewer.Refresh();
                    #endregion
                }
                else if (stringcheck == "NDC_Refund_String")
                {
                    #region NDC Refund Report
                    #region Button Visibility
                    btnBack.Visible = false;
                    btnForward.Visible = false;
                    radLabel1.Visible = false;
                    radLabel4.Visible = false;
                    radLabel3.Visible = false;
                    radLabel5.Visible = false;
                    lblPreparedby.Visible = false;
                    lblPreparedbyDate.Visible = false;
                    lblReviewby.Visible = false;
                    lblReviewedbyDate.Visible = false;
                    //btnNext.Visible = true;
                    #endregion
                    ReportDocument rptdc = new ReportDocument();
                    NDC_DataSet NDC_ds = new NDC_DataSet();
                    NDC_ds.Tables["tbl_NDC_Refund"].Merge(dtbl, true, MissingSchemaAction.Ignore);

                    string path1 = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\My_Reports\\NDCRefundReprt.rpt";
                    if (!string.IsNullOrEmpty(path1))
                    {
                        rptdc.Load(path1);
                    }

                    //NDC_ds.EnforceConstraints = true;
                    rptdc.SetDataSource(NDC_ds);
                    NDC_ReportViewer.ReportSource = rptdc;
                    NDC_ReportViewer.Refresh();
                    #endregion
                }

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on GenerateReport.", ex, "frmNDC_Report");
                frmobj.ShowDialog();
            }
        }


    }
}
