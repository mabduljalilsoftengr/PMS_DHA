using PeshawarDHASW.Data_Layer.clsAcknowledgment;
using PeshawarDHASW.Data_Layer.Installment;
using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Installment.InstReceive
{
    public partial class frmClearingListOfDD_ReadyForBankDeposite : Telerik.WinControls.UI.RadForm
    {
        public frmClearingListOfDD_ReadyForBankDeposite()
        {
            InitializeComponent();
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (dtpFromDate.Value.Date != null && dtpToDate.Value.Date != null && drpDDstatus.SelectedIndex > 0 && dtp_clearingDate.Value.Date != null)
            {
                SearchingDD();
                if (radgdInstReceive.RowCount > 0)
                {
                    btn_ClearDDStatus.Enabled = true;
                }
                else
                {
                    btn_ClearDDStatus.Enabled = false;
                }
                //Summary_Column();
            }
            else
            {
                RadMessageBox.Show("Please Fill all the Fields.");
            }
        }
        private void SearchingDD()
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@Task", "List_Of_DD_Acknowledgement"),
                new SqlParameter("@FromDate", dtpFromDate.Value.ToString("yyyy-MM-dd")),
                new SqlParameter("@ToDate", dtpToDate.Value.ToString("yyyy-MM-dd")),
                new SqlParameter("@DDStatus", drpDDstatus.SelectedItem.ToString()),
                //new SqlParameter("@FileNo",txtFileNo.Text)
            };
            DataSet ds = cls_dl_InstRece.Inst_Rece_Read(parameters);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    radgdInstReceive.DataSource = ds.Tables[0].DefaultView;
                }
                else
                {
                    radgdInstReceive.DataSource = null;
                    RadMessageBox.Show("There is no DD exist.", "Warning", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
                }

            }
            else
            {
                MessageBox.Show("There is no Table in DataSet.");
            }
        }

        private string ReceIDs_ListCreation()
        {
            string ReceIDS = "";
            foreach (GridViewRowInfo item in radgdInstReceive.ChildRows)
            {
                ReceIDS += item.Cells["Rece_ID"].Value.ToString() + ",";
            }
            return ReceIDS;
        }

        private void btn_ClearDDStatus_Click(object sender, EventArgs e)
        {
            //  _fun_BulkClearnceofDDs();
            radWaitbar.Visible = true;
            radWaitbar.StartWaiting();
            radgdInstReceive.Enabled = false;
            btnsearch.Enabled = false;
            btn_ClearDDStatus.Enabled = false;
            BulkClearnceofDDs.RunWorkerAsync();

            //if (radWaitbar.IsWaiting)
            //{
            //    radWaitbar.StopWaiting();
            //    btn_ClearDDStatus.Text = "Wait for Process.";
            //}
            //else
            //{
            //    radWaitbar.StartWaiting();
            //    btn_ClearDDStatus.Text = "Clear DDs";
            //}
        }

        #region Bulk Acknowledgement
        private void AcknowledgementGeneration(int ReceID, string FileNo, string DDStatus)
        {
            int totalexist = int.Parse(Helper.SQLHelper.ExecuteScalar(Helper.SQLHelper.createConnection(), CommandType.Text, @"SELECT COUNT(*)
                                FROM [DHAPeshawarDB].[dbo].[tbl_Acknowledgement] WHERE Rece_ID = '" + ReceID.ToString() + "' AND StatusAck LIKE 'Not Printed'").ToString());
            if (totalexist > 0)
            {
                if (DDStatus != "Cleared")
                {
                    SqlParameter[] param =
                    {
                            new SqlParameter("@Task", "CancelAcknowledgement"),
                            new SqlParameter("@ReceID", ReceID.ToString()),
                            new SqlParameter("@userID", clsUser.ID)
                        };
                    int result = cls_Fin_Acknowledgement.Fin_Acknowledgment_NonQuery(param);
                }
            }
            else
            {
                if (DDStatus == "Cleared")
                {
                    SqlParameter[] param =
                    {
                            new SqlParameter("@Task", "GenerateAcknowledgement"),
                            new SqlParameter("@ReceID", ReceID.ToString()),
                            new SqlParameter("@FileNo", FileNo),
                            new SqlParameter("@userID", clsUser.ID)
                        };
                    int result = cls_Fin_Acknowledgement.Fin_Acknowledgment_NonQuery(param);
                }
            }

        }
        #endregion 

        private int _fun_BulkClearnceofDDs()
        {

            int rslt = 0;
            try
            {
                int rowcount = radgdInstReceive.RowCount;
                SqlParameter[] prm =
                {
                    new SqlParameter("@Task","Bulk_Updation_DDStatus"),
                    new SqlParameter("@DDStatus","Cleared"),
                    new SqlParameter("@Rece_IDs",ReceIDs_ListCreation()),
                    new SqlParameter("@ClearingDate", dtp_clearingDate.Value.Date),
                };
                rslt = cls_dl_InstRece.Inst_Rece_NonQuery(prm, rowcount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return rslt;

        }

        private void frmClearingListOfDD_ReadyForBankDeposite_Load(object sender, EventArgs e)
        {

        }

        #region Single Clearing of DD
        private void radgdInstReceive_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "btn_ClearDD")
            {
                int rslt = 0;
                int trxid = int.Parse(radgdInstReceive.ChildRows[radgdInstReceive.CurrentRow.Index].Cells["Rece_ID"].Value.ToString());
                string ClearDate = dtp_clearingDate.Value.ToString("yyyy/MM/dd");
                SqlParameter[] prm =
                {
                    new SqlParameter("@Task","Bulk_Updation_DDStatus_Single"),
                    new SqlParameter("@DDStatus","Cleared"),
                    new SqlParameter("@ClearingDate",DateTime.ParseExact(ClearDate,"yyyy/MM/dd",CultureInfo.InvariantCulture)),
                    new SqlParameter("@Rece_ID",trxid)
                };
                rslt = cls_dl_InstRece.Inst_Rece_NonQuery(prm);
                if (rslt > 0)
                {
                    AcknowledgementGeneration(trxid, radgdInstReceive.ChildRows[radgdInstReceive.CurrentRow.Index].Cells["FileNo"].Value.ToString(), "Cleared");
                    MessageBox.Show("DD's is Cleared Successfully.");
                    btnsearch_Click(null, null);
                }
            }
        }
        #endregion

        public int TotalWorkDoneof_BulkClearnce { get; set; }
        private void BulkClearnceofDDs_DoWork(object sender, DoWorkEventArgs e)
        {

            TotalWorkDoneof_BulkClearnce = _fun_BulkClearnceofDDs();
        }

        private void BulkClearnceofDDs_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Cancelled)
            {
                MessageBox.Show("Operation was canceled");
            }
            else if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                radWaitbar.Visible = false;
                radWaitbar.StopWaiting();
                radgdInstReceive.Enabled = true;
                btnsearch.Enabled = true;
                btn_ClearDDStatus.Enabled = true;
                // MessageBox.Show("All DD's are Cleared Successfully.");
                btnsearch_Click(null, null);
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            frmbulkClearnaceofDDs obj = new frmbulkClearnaceofDDs();
            obj.ShowDialog();
        }
    }
}
