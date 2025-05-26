using PeshawarDHASW.Data_Layer.clsFileMap;
using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.FileMap.ByBack
{
    public partial class frmBuyBackProgress : Form
    {
        public frmBuyBackProgress()
        {
            InitializeComponent();
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            grdbuybackdata.AutoGenerateColumns = false;
        }

        private void frmBuyBackProgress_Load(object sender, EventArgs e)
        {
            try
            {

                LoadReportData();
                LoadData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadReportData()
        {
            try { 
                  SqlParameter[] prm =
                  {
                      new SqlParameter("@Task","BuyBackReport")
                  };
                  DataSet rslt = cls_dl_FileMap.Main_FileMap_Reader(prm);
                  //grdreportdata.DataSource = rslt.Tables[0].DefaultView;
                  
                  RadListDataItem Select = new RadListDataItem();
                  Select.Value = 0;
                  Select.Text = "-- Select --";
                  this.rdpstatus.Items.Add(Select);
                  
                  foreach (DataRow row in rslt.Tables[1].Rows)
                  {
                      RadListDataItem dataItem = new RadListDataItem();
                      dataItem.Value = 0;
                      dataItem.Text = row["Status"].ToString();
                      this.rdpstatus.Items.Add(dataItem);
                  }
                  rdpstatus.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadData()
        {
            DateTime? dateFrom = null;
            DateTime? dateTo = null;

            if (dtpfrom.Value.Date.Year == 1)
                dateFrom = null;
            else
            {
                dateFrom = dtpfrom.Value.Date;
                if (dtpto.Value.Date.Year == 1)
                    dateTo = DateTime.Now.Date;
                else
                    dateTo = dtpto.Value.Date;
            }

            SqlParameter[] param = 
            {
                    new SqlParameter("@Task","GetPendingBuyBackData"),
                    new SqlParameter("@Status", rdpstatus.SelectedItem.ToString() == "-- Select --" ? null :  rdpstatus.SelectedItem.ToString()),
                    new SqlParameter("@InvestorName",txtname.Text),
                    new SqlParameter("@FromDate",dateFrom),
                    new SqlParameter("@ToDate", dateTo  )
            };
            DataSet ds = cls_dl_FileMap.Main_FileMap_Reader(param);
            grdbuybackdata.DataSource = ds.Tables[0].DefaultView;
            grdpendingdata.DataSource = ds.Tables[1].DefaultView;
        }
        

        private void grdbuybackdata_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (grdbuybackdata.Columns[e.ColumnIndex].Name == "btnModify")
            {
                int bid = Convert.ToInt32(grdbuybackdata.Rows[e.RowIndex].Cells["BID"].Value.ToString());
                decimal prflrt = Convert.ToDecimal(grdbuybackdata.Rows[e.RowIndex].Cells["PerFileRate"].Value.ToString());
                decimal amont = Convert.ToDecimal(e.Row.Cells["Amount"].Value.ToString());
                string ckno = e.Row.Cells["CheckNo"].Value.ToString();
                string pmtdt = e.Row.Cells["PaymentDate"].Value.ToString();
                //string FileNo = grdbuybackdata.Rows[e.RowIndex].Cells["FileNo"].Value.ToString();
                //string Status = grdbuybackdata.Rows[e.RowIndex].Cells["Status"].Value.ToString();
                //string InvestorName = grdbuybackdata.Rows[e.RowIndex].Cells["InvestorName"].Value.ToString();
                //string PlotSize = grdbuybackdata.Rows[e.RowIndex].Cells["PlotSize"].Value.ToString();
                //string SQYard = grdbuybackdata.Rows[e.RowIndex].Cells["SQYard"].Value.ToString();

                frmBuyBackModify frmobj = new frmBuyBackModify(bid, prflrt, amont, ckno, pmtdt);
                frmobj.ShowDialog();
                LoadData();
            }
            else if (grdbuybackdata.Columns[e.ColumnIndex].Name == "btn_DataModify")
            {
                if (MessageBox.Show("Are you want to Modify the data ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    int bid = Convert.ToInt32(grdbuybackdata.Rows[e.RowIndex].Cells["BID"].Value.ToString());
                    string chqno = grdbuybackdata.Rows[e.RowIndex].Cells["CheckNo"].Value.ToString();
                    decimal amnt = Convert.ToDecimal(grdbuybackdata.Rows[e.RowIndex].Cells["Amount"].Value.ToString());
                    SqlParameter[] param =
                    {
                       new SqlParameter("@Task","UpdateBuyBackDataChqAmnt"),
                       new SqlParameter("@BID",bid),
                       new SqlParameter("@CheckNo",chqno),
                       new SqlParameter("@Amount",amnt)
                    };
                    int rslt = cls_dl_FileMap.Main_FileMap_NonQuery(param);
                    if (rslt > 0)
                    {
                        MessageBox.Show("Successful.");
                        LoadData();
                    }
                }
            }
            else if (grdbuybackdata.Columns[e.ColumnIndex].Name == "btnApprove")
            {
                if (MessageBox.Show("Are You Sure To Proceed ?","Attention!",MessageBoxButtons.YesNo,MessageBoxIcon.Information)== DialogResult.Yes)
                {

                int bid = Convert.ToInt32(grdbuybackdata.Rows[e.RowIndex].Cells["BID"].Value.ToString());
                SqlParameter[] param =
                {
                    new SqlParameter("@Task","UpdateBuyBackDataStatus"),
                    new SqlParameter("@BID",bid),
                    new SqlParameter("@userID",clsUser.ID),
                    new SqlParameter("@Status","ReadyForApproval")
                };
                int rslt = cls_dl_FileMap.Main_FileMap_NonQuery(param);
                if (rslt > 0)
                {
                    MessageBox.Show("Successful.");
                    LoadData();
                }
                }
            }
            else if (grdbuybackdata.Columns[e.ColumnIndex].Name == "btnuploaddocuments")
            {
                try
                {
                    //if (MessageBox.Show("Are You Sure To Proceed ?", "Attention!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    //{
                        int bid = Convert.ToInt32(grdbuybackdata.Rows[e.RowIndex].Cells["BID"].Value.ToString());
                        frmBuyBackImage frm = new frmBuyBackImage(bid);
                        frm.ShowDialog();
                        LoadData();
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else if(e.Column.Name == "btnView")
            {
                try
                {
                    if (MessageBox.Show("Are You Sure To Proceed ?", "Attention!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        int buybackid = int.Parse(e.Row.Cells["BID"].Value.ToString());
                        frmImageShow frm = new frmImageShow(buybackid, "BuyBackFin");
                        frm.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnrefresh_Click(null, null);
        }

        private void btnUpdtae_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtchequeno.Text))
            {
                MessageBox.Show("Cheque No is Missing");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtamount.Text))
            {
                MessageBox.Show("txtamount is Missing");
                return;
            }
            else
            {
                decimal amuont = Convert.ToDecimal(txtamount.Text);
                if (amuont < 1 )
                {
                    MessageBox.Show("Amount is Invalid");
                    return;
                }
            }
            if (string.IsNullOrWhiteSpace(rdbpaymentdate.Value.Date.ToString()))
            {
                MessageBox.Show("Payment Date is Missing");
                return;
            }
            bool SuccessFlag = false;
            foreach (var item in VerifiedListDorward)
            {
                if (item.PerFileRate == Convert.ToDecimal(txtamount.Text))
                {
                    SqlParameter[] param =
                    {
                        new SqlParameter("@Task","UpdateBuyBackData"),
                        new SqlParameter("@BID",item.BuyBackID),
                        new SqlParameter("@CheckNo",txtchequeno.Text),
                        new SqlParameter("@Amount",txtamount.Text),
                        new SqlParameter("@PaymentDate",rdbpaymentdate.Value.Date)
                        };
                    int rslt = cls_dl_FileMap.Main_FileMap_NonQuery(param);
                    if (rslt > 0)
                    {
                        SuccessFlag = true;
                    }
                    else
                    {
                        SuccessFlag = false;
                    }
                }
                else
                {
                    MessageBox.Show("Amount Does't match  with Per File Rate.", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (SuccessFlag==true)
            {
                MessageBox.Show("Successful.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Fail.");
            }
           


        }

        private void FileRateUpdatE(int b_ID,string ChequeNo,decimal Amount,string DateTimeVal)
        {
            //if (PerFlRt == Convert.ToDecimal(txtamount.Text))
            //{
            //    SqlParameter[] param =
            //    {
            //        new SqlParameter("@Task","UpdateBuyBackData"),
            //        new SqlParameter("@BID",b_ID),
            //        new SqlParameter("@CheckNo",txtchequeno.Text),
            //        new SqlParameter("@Amount",txtamount.Text),
            //        new SqlParameter("@PaymentDate",rdbpaymentdate.Value.Date)
            //        };
            //    int rslt = cls_dl_FileMap.Main_FileMap_NonQuery(param);
            //    if (rslt > 0)
            //    {
            //        MessageBox.Show("Successful.");
            //        this.Close();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Amount Does't match  with Per File Rate.", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        public List<FileList> VerifiedListDorward { get; set; }
      

        private void grdbuybackdata_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            try
            {
                bool status = (bool)e.Row.Cells["chkBuyBackField"].Value;
                if (status)
                {
                    btnUpdtae.Enabled = false;
                }

            }
            catch (Exception)
            {
            }
        }

        private void btnFileVerification_Click(object sender, EventArgs e)
        {
            try
            {
                   List<FileList> FileListofUpdate = new List<FileList>();
                   FileList FirstFileSelectionValue = new FileList();
                   int count = 0;
                    if (grdbuybackdata.RowCount>0)
                    {
                        foreach (GridViewRowInfo rows in grdbuybackdata.Rows)
                        {

                            int bid = Convert.ToInt32(rows.Cells["BID"].Value.ToString());
                            decimal prflrt = Convert.ToDecimal(rows.Cells["PerFileRate"].Value.ToString());
                            decimal amont = Convert.ToDecimal(rows.Cells["Amount"].Value.ToString());
                            string ckno = rows.Cells["CheckNo"].Value.ToString();
                            string InvestorName = rows.Cells["InvestorName"].Value.ToString();
                             string EntryDate = rows.Cells["EntryDate"].Value.ToString();
                           bool status = (bool)(rows.Cells["chkBuyBackField"].Value != null? rows.Cells["chkBuyBackField"].Value:false);
                            if (status==true)
                            {
                                if (status == true && count == 0)
                                {

                                    FirstFileSelectionValue.BuyBackID = bid;
                                    FirstFileSelectionValue.PerFileRate = prflrt;
                                    FirstFileSelectionValue.DateofEntry = EntryDate;
                                    FirstFileSelectionValue.InvestorName = InvestorName;
                                    FileListofUpdate.Add(FirstFileSelectionValue);
                                    count = count + 1;
                                }
                                else
                                {
                                    FileList obj = new FileList();
                                    obj.BuyBackID = bid;
                                    obj.PerFileRate = prflrt;
                                    obj.DateofEntry = EntryDate;
                                    obj.InvestorName = InvestorName;
                                    FileListofUpdate.Add(obj);
                                }
                            }
                        }
                        bool RecordFlag = false;
                        foreach (FileList item in FileListofUpdate)
                        {
                            if (FirstFileSelectionValue.PerFileRate == item.PerFileRate
                            && FirstFileSelectionValue.InvestorName == item.InvestorName 
                            && FirstFileSelectionValue.DateofEntry == item.DateofEntry)
                            {
                                RecordFlag = true;
                            }
                            else
                            {
                                RecordFlag = false;
                            }
                        }
                        
                        if (RecordFlag==true)
                        {
                            btnUpdtae.Enabled = true;
                            VerifiedListDorward = FileListofUpdate;
                        }
                        else
                        {
                            btnUpdtae.Enabled = false;
                            MessageBox.Show("Selected Files Investor Name, DateofEntry and PerFileRate is Not Match.");
                            VerifiedListDorward = null;
                        }
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void MasterTemplate_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name == "bntImagShow")
            {
                if (e.Row.Cells["Status"].Value.ToString() == "ReadyForApproval")
                {
                    int bbid = int.Parse(e.Row.Cells["BID"].Value.ToString());
                    frmImageShow frm = new frmImageShow(bbid, "BuyBackFin");
                    frm.ShowDialog();
                }
                else
                {
                    int bbid = int.Parse(e.Row.Cells["BID"].Value.ToString());
                    frmImageShow frm = new frmImageShow(bbid, "BuyBack");
                    frm.ShowDialog();
                }
               
            }
        }
    }



    public class FileList
    {
        public int BuyBackID { get; set; }
        public string InvestorName { get; set; }
        public decimal PerFileRate { get; set; }
        public string DateofEntry { get; set; }
    }
}
