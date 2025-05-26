using CrystalDecisions.CrystalReports.Engine;
using PeshawarDHASW.Data_Layer.NDC;
using PeshawarDHASW.Report.Datasets.NDC_DataSet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    public partial class frmShowAllNDC_and_TransferLetter : Telerik.WinControls.UI.RadForm
    {
        private DataSet ds { get; set; }
        public frmShowAllNDC_and_TransferLetter()
        {
            InitializeComponent();
        }

        private void txtTfrNoNDCNo_Leave(object sender, EventArgs e)
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","GetNDCTFRImage"),
                new SqlParameter("@NDCNo",txtTfrNoNDCNo.Text)
            };
            ds = cls_dl_NDC.NdcRetrivalImages(prm);
            grdNDCNo.DataSource = ds.Tables[0].DefaultView;
            grdTFRLetter.DataSource = ds.Tables[1].DefaultView;
        }

        private void frmShowAllNDC_and_TransferLetter_Load(object sender, EventArgs e)
        {

        }

        private void grdNDCNo_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "btn_View")
                {
                    int imgid = int.Parse(e.Row.Cells["Img_ID"].Value.ToString());
                    int ndcno = int.Parse(e.Row.Cells["NDCNo"].Value.ToString());
                    Byte[] imgbyt = (Byte[])e.Row.Cells["NDC_Image"].Value;

                    NDC_DataSet dstndc = new NDC_DataSet();
                    DataTable dtbl = dstndc.tbl_NDC_Image; //Table 1
                    DataRow ravi = dtbl.NewRow();
                    ravi["Image"] = imgbyt;
                    dtbl.Rows.Add(ravi);
                    ReportDocument rd = new ReportDocument();
                    string path = System.Windows.Forms.Application.StartupPath + "\\Report\\My_Reports\\NDCImageDuplicate.rpt";
                    rd.Load(path);
                    rd.SetDataSource(dstndc.Tables[1]);
                    crystalReportViewer1.ReportSource = rd;
                    crystalReportViewer1.Refresh();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void grdTFRLetter_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "btnView")
                {
                    int TFRHid = int.Parse(e.Row.Cells["TFRH_ID"].Value.ToString());
                    int ndcno = int.Parse(e.Row.Cells["NDCNo"].Value.ToString());
                    int tfrno = int.Parse(e.Row.Cells["TransferNo_tblTFRTracking"].Value.ToString());
                    Byte[] imgbyt = (Byte[])e.Row.Cells["Image"].Value;
                    NDC_DataSet dstndc = new NDC_DataSet();
                    //**************** Transfer Letter Image Table *******************
                    DataTable dtbl = dstndc.tbl_Transfer_Letter_Image; //Table 2
                    DataRow ravi = dtbl.NewRow();
                    ravi["Image"] = imgbyt;
                    dtbl.Rows.Add(ravi);
                    //**************** Transfer Group Pictures Table ******************
                    dstndc.Tables[3].Merge(ds.Tables[2], true, MissingSchemaAction.Ignore);

                    //@@@@@@@@@@@@@@@ 
                    ReportDocument rd = new ReportDocument();
                    string path = System.Windows.Forms.Application.StartupPath + "\\Report\\My_Reports\\NDCImageDuplicate.rpt";
                    rd.Load(path);
                    rd.SetDataSource(dstndc.Tables[2]);
                    crystalReportViewer1.ReportSource = rd;
                    crystalReportViewer1.Refresh();

                    //&&&&&&&&&&&&&&&&
                    frmPreviousTransferGroupPhoto frm = new frmPreviousTransferGroupPhoto(ds.Tables[2]);
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
