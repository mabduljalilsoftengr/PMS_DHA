using PeshawarDHASW.Application_Layer.Transfer.TransferReport;
using PeshawarDHASW.Data_Layer.clsTFR;
using PeshawarDHASW.Data_Layer.NDC;
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
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    public partial class frmReaddyForTFRSlips : Telerik.WinControls.UI.RadForm
    {
        public frmReaddyForTFRSlips()
        {
            InitializeComponent();
        }

        private void grdNDCDetail_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {

            
            if(e.Column.Name == "btntfrslipquestion")
            {
                int ndcno = int.Parse(e.Row.Cells["NDCNo"].Value.ToString());
                int tfrno = int.Parse(e.Row.Cells["TransferNo"].Value.ToString());
                string fileno = e.Row.Cells["FilePlotNo"].Value.ToString();
                int purchasetypeID = int.Parse(e.Row.Cells["PurchaseTypeID"].Value.ToString());
                SqlParameter[] prm =
                {
                    new SqlParameter("@Task","GetNDCSellerBuyerTFR"),
                    new SqlParameter("@NDCNo",ndcno)
                };
                DataSet dst = new DataSet();
                dst = cls_dl_NDC.NdcRetrival(prm);
                frm_Checklist_Report_Viewer frm = new frm_Checklist_Report_Viewer(dst.Tables[0],"TFRSlipReprt");
                frm.ShowDialog();
                frm_Checklist_Report_Viewer frmo = new frm_Checklist_Report_Viewer(dst.Tables[0], "TFRSlipReprtOfficeCopy");
                frmo.ShowDialog();
                frm_Checklist_Report_Viewer frmq = new frm_Checklist_Report_Viewer(dst.Tables[0], "QuestionareReport");
                frmq.ShowDialog();
                frmTransferReport frmtfrrpt = new frmTransferReport(fileno, ndcno, purchasetypeID, tfrno);
                frmtfrrpt.ShowDialog();
            }
            else if (e.Column.Name == "btnNext")
            {
                try
                {
                    if(MessageBox.Show("Are you sure ?","Attention.",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        int ndcno = int.Parse(e.Row.Cells["NDCNo"].Value.ToString());
                        int tfrno = int.Parse(e.Row.Cells["TransferNo"].Value.ToString());
                        SqlParameter[] prm =
                        {
                        new SqlParameter("@Task","NDCUpdateStatus"),
                        new SqlParameter("@NDCNo",ndcno),
                        new SqlParameter("@TransferNo",tfrno)
                        };
                        int rslt = cls_dl_TFR.TranferSetting(prm);
                        if (rslt > 0)
                        {
                            MessageBox.Show("Go for Next step Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GetData();
                        }
                    }
                    
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
               
               }
                else if (e.Column.Name == "btnBack")
                {
                    try
                    {
                        if (MessageBox.Show("Are you sure ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            int ndc = int.Parse(e.Row.Cells["NDCNo"].Value.ToString());
                            int tfr = int.Parse(e.Row.Cells["TransferNo"].Value.ToString());
                            SqlParameter[] prm =
                            {
                        new SqlParameter("@Task","Update_TFR_NDC_StatusDltTFR"),
                        new SqlParameter("@NDCNo",ndc),
                        new SqlParameter("@TransferNo",tfr),
                        new SqlParameter("@NDCStatus","TFRAppGenerated"),
                        };
                            int rslt = cls_dl_TFR.TranferSetting(prm);
                            if (rslt > 0)
                            {
                                MessageBox.Show("Successfull.");
                                GetData();
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void frmReaddyForTFRSlips_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
            try
            {
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","GetNDCReadyForSlips")
                };
                DataSet dst = cls_dl_NDC.NdcRetrival(prm);
                grdNDCDetail.DataSource = dst.Tables[0].DefaultView;

                ConditionalFormattingObject obj = new ConditionalFormattingObject("MyCondition1", ConditionTypes.LessOrEqual, "2", "", true);
                obj.RowBackColor = Color.Red;
                obj.RowForeColor = Color.White;
                this.grdNDCDetail.Columns["RemainingDaysForExpiry"].ConditionalFormattingObjectList.Add(obj);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
