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

namespace PeshawarDHASW.Application_Layer.AdventureArena
{
    public partial class AdventureTicketChallan : Telerik.WinControls.UI.RadForm
    {
        public AdventureTicketChallan()
        {
            InitializeComponent();
            DataLoadingContractorGroupDropDown();
            DataLoadingTicketInformationGroupDropDown();
            lblInvoiceNo.Text = "0";
        }


        public AdventureTicketChallan(string ChallanID)
        {
            InitializeComponent();
            DataLoadingContractorGroupDropDown();
            DataLoadingTicketInformationGroupDropDown();
            DataLoadingTicketInformation(ChallanID);
        }
        private void DataLoadingTicketInformation(string TicketGeneratedID)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Task","GetSingleTransInfo"),
                    new SqlParameter("@TicketGenerateID",TicketGeneratedID)
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure
                    , "App.USP_AdventureChallan", param
                    );
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int ContractorID = int.Parse(ds.Tables[0].Rows[0]["ContractorID"].ToString());
                        Helper.clsPluginHelper.RadDropDownSelectedbyValue(ddlContractorList, ContractorID);
                        lblInvoiceNo.Text = ds.Tables[0].Rows[0]["TicketGenerateID"].ToString();
                        lblcontractorname.Text = ds.Tables[0].Rows[0]["BuyerName"].ToString();
                        llbcontractorCNIC.Text = ds.Tables[0].Rows[0]["BuyerCNIC"].ToString();
                        txtChequeNo.Text = ds.Tables[0].Rows[0]["ChequeNo"].ToString();
                        txtChequeAmount.Text = ds.Tables[0].Rows[0]["ChequeAmount"].ToString();
                        dtpReceiveDate.Value = DateTime.Parse(ds.Tables[0].Rows[0]["ChequeReceiveDate"].ToString());
                        txtAmtTotalFee.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
                        txtDHAPShares.Text = ds.Tables[0].Rows[0]["DHAPShares"].ToString();
                        //= ds.Tables[0].Rows[0][""].ToString();
                        //= ds.Tables[0].Rows[0][""].ToString();

                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        gdvTicketBookList.DataSource = ds.Tables[1].DefaultView;
                    }
                }
                //dgvChallanInformation.DataSource = ds.Tables[0].DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DataLoadingContractorGroupDropDown()
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Task","ContractorList")
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure
                    , "App.USP_AdventureContractor", param
                    );
                ddlContractorList.DataSource = ds.Tables[0].DefaultView;
                ddlContractorList.DisplayMember = "ContractorName";
                ddlContractorList.ValueMember = "ContractorID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DataLoadingTicketInformationGroupDropDown()
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Task","ListofTicketbook")
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure
                    , "App.USP_AdventureArenaChallan", param
                    );
                ddlTicketDetail.DataSource = ds.Tables[0].DefaultView;
                ddlTicketDetail.DisplayMember = "TicketDetailTitle";
                ddlTicketDetail.ValueMember = "TicketDetailID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataLoadingContractorInfo()
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Task","ContractorDetail"),
                    new SqlParameter("@ContractorID",ddlContractorList.SelectedItem.Value)
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure
                    , "App.USP_AdventureContractor", param
                    );
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblcontractorname.Text = ds.Tables[0].Rows[0]["ContractorName"].ToString();
                        llbcontractorCNIC.Text = ds.Tables[0].Rows[0]["ContractorCNIC"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

        }
        private void AdventureTicketChallan_Load(object sender, EventArgs e)
        {

        }

        private void ddlTicketDetail_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Task","ListofTicketReadyofIssue"),
                     new SqlParameter("@TicketDetailID",ddlTicketDetail.SelectedItem.Value),
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure
                    , "App.USP_AdventureArenaChallan", param
                    );

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlTicketBookList.DataSource = ds.Tables[0].DefaultView;
                        ddlTicketBookList.DisplayMember = "TicketBook";
                        ddlTicketBookList.ValueMember = "TicketBookID";
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }
        private void btnAddBooktoList_Click(object sender, EventArgs e)
        {
            //Duplicate Prevention
            foreach (var item in gdvTicketBookList.Rows)
            {
                if (ddlTicketBookList.SelectedItem.Value.ToString() == item.Cells["TicketBookID"].Value.ToString())
                {
                    MessageBox.Show(ddlTicketBookList.SelectedItem.Text.ToString() + " is already in the List.");
                    return;
                }
            }

            SqlParameter[] param = {
                    new SqlParameter("@Task","GetSingleBookofTicketReadyofIssue"),
                     new SqlParameter("@TicketBookID",ddlTicketBookList.SelectedItem.Value),
                };
            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure
                , "App.USP_AdventureArenaChallan", param
                );
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gdvTicketBookList.Rows.Add(
                    ds.Tables[0].Rows[0]["TicketBookID"].ToString(),
                    ds.Tables[0].Rows[0]["TicketBook"].ToString(),
                    ds.Tables[0].Rows[0]["TicketBookPrice"].ToString(),
                    ds.Tables[0].Rows[0]["TicketDetailID"].ToString(),
                    ds.Tables[0].Rows[0]["DHAPShares"].ToString(),
                    ds.Tables[0].Rows[0]["TicketChallanDetailID"].ToString()
                    );
                }

            }
            decimal TicketBookPriceAmount = 0;
            decimal DHAPSharesAmount = 0;
            foreach (var item in gdvTicketBookList.Rows)
            {
                decimal TicketBookPrice = 0;
                bool TicketBookPricebool = decimal.TryParse(item.Cells["TicketBookPrice"].Value.ToString(), out TicketBookPrice);
                TicketBookPriceAmount = TicketBookPriceAmount + TicketBookPrice;
                decimal DHAPShares = 0;
                bool DHAPSharesbool = decimal.TryParse(item.Cells["DHAPShares"].Value.ToString(), out DHAPShares);
                DHAPSharesAmount = DHAPSharesAmount + DHAPShares;

            }
            txtAmtTotalFee.Text = TicketBookPriceAmount.ToString();
            txtDHAPShares.Text = DHAPSharesAmount.ToString();

        }
        private void MasterTemplate_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "DeleteColumn")
                {
                    string invoice = lblInvoiceNo.Text;
                    if (invoice != "0")
                    {
                        if (MessageBox.Show(this, "Are you sure you want to remove this fee from list. ", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            SqlParameter[] param =
                            {
                            new SqlParameter("@Task","TicketBookRemove"),
                            new SqlParameter("@TicketBookID",e.Row.Cells["TicketBookID"].Value.ToString()),
                            new SqlParameter("@TicketChallanDetailID",e.Row.Cells["TicketChallanDetailID"].Value.ToString()),
                            };
                            int result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_AdventureTicketChallanDetail", param);
                            if (result > 0)
                            {
                                gdvTicketBookList.Rows.Remove(e.Row);
                            }
                        }
                    }
                    else
                    {
                            gdvTicketBookList.Rows.Remove(e.Row);
                    }

                    decimal TicketBookPriceAmount = 0;
                    decimal DHAPSharesAmount = 0;
                    foreach (var item in gdvTicketBookList.Rows)
                    {
                        decimal TicketBookPrice = 0;
                        bool TicketBookPricebool = decimal.TryParse(item.Cells["TicketBookPrice"].Value.ToString(), out TicketBookPrice);
                        TicketBookPriceAmount = TicketBookPriceAmount + TicketBookPrice;
                        decimal DHAPShares = 0;
                        bool DHAPSharesbool = decimal.TryParse(item.Cells["DHAPShares"].Value.ToString(), out DHAPShares);
                        DHAPSharesAmount = DHAPSharesAmount + DHAPShares;

                    }
                    txtAmtTotalFee.Text = decimal.ToInt64(TicketBookPriceAmount).ToString();
                    txtDHAPShares.Text = decimal.ToInt64(DHAPSharesAmount).ToString();
                }
            }
            catch (Exception)
            {

            }
        }
        private void txtChequeAmount_TextChanged(object sender, EventArgs e)
        {
            int amount = 0;
            bool amountval = int.TryParse(txtChequeAmount.Text, out amount);
            string AmountinWords = Helper.clsPluginHelper.Convert_Number_To_Text(amount, false);
            txtAmountinWords.Text = AmountinWords;
        }
        private void ddlContractorList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            DataLoadingContractorInfo();
        }
        private void btnSaveTicket_Click(object sender, EventArgs e)
        {
            int chequeamount = 0;
            bool chequeamountbool = int.TryParse(txtChequeAmount.Text, out chequeamount); 
             if (string.IsNullOrWhiteSpace(txtChequeNo.Text))
            {
                MessageBox.Show("Cheque No is Missing");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtChequeAmount.Text))
            {
                MessageBox.Show("Cheque Amount is Missing");
                return;
            }
            if (chequeamountbool == false)
            {
                MessageBox.Show("Cheque Amount is Invalid");
                return;
            }
            using (SqlConnection Objcon = Helper.SQLHelper.createConnection())
            {

                using (SqlTransaction sqlTrans = Objcon.BeginTransaction("TicketProcess"))
                {
                    decimal AmtTotalFee = decimal.Parse(txtAmtTotalFee.Text);
                    decimal DHAPShares = decimal.Parse(txtDHAPShares.Text);
                    try
                    {
                        SqlParameter[] paramAmalHead = {
                         new SqlParameter("@Task","NewChallanAdventure")
                        ,new SqlParameter("@TicketGenerateID",lblInvoiceNo.Text)
                        ,new SqlParameter("@ContractorID",ddlContractorList.SelectedItem.Value)
                        , new SqlParameter("@BuyerName",lblcontractorname.Text)
                        , new SqlParameter("@BuyerCNIC",llbcontractorCNIC.Text)
                        , new SqlParameter("@TrxID","0")
                        , new SqlParameter("@ChequeNo",txtChequeNo.Text)
                        , new SqlParameter("@ChequeAmount",txtChequeAmount.Text)
                        , new SqlParameter("@ChequeReceiveDate",dtpReceiveDate.Value.Date)
                        , new SqlParameter("@GenerationDate",DateTime.Now)
                        , new SqlParameter("@Quantity",1)
                        , new SqlParameter("@TotalAmount",AmtTotalFee)
                        , new SqlParameter("@DHAPShares",DHAPShares)
                        , new SqlParameter("@StatusofChallan","Pending")
                        , new SqlParameter("@VerifiedStatus","NA")
                        , new SqlParameter("@Insertby",clsUser.ID)
                        , new SqlParameter("@InsertDate",DateTime.Now)
                        , new SqlParameter("@Updateby",clsUser.ID)
                        , new SqlParameter("@Updatedate",DateTime.Now)
                         };
                        string InvoiceID = "0";
                        InvoiceID = Helper.SQLHelper.ExecuteScalar(sqlTrans, CommandType.StoredProcedure, "App.USP_AdventureChallan", paramAmalHead).ToString();
                        
                        if (!string.IsNullOrWhiteSpace(InvoiceID))
                        {

                            foreach (var item in gdvTicketBookList.Rows)
                            {

                                SqlParameter[] paramdetail = {
                                    new SqlParameter("@Task","TicketDetailSave"),
                                    new SqlParameter("@TicketChallanDetailID",item.Cells["TicketChallanDetailID"].Value.ToString()),
                                    new SqlParameter("@TicketChallanHeadID",InvoiceID),
                                    new SqlParameter("@Particular",item.Cells["TicketBook"].Value.ToString()),
                                    new SqlParameter("@TicketBookID",item.Cells["TicketBookID"].Value.ToString()),
                                    new SqlParameter("@TicketDetailID",item.Cells["TicketDetailID"].Value.ToString()),
                                    new SqlParameter("@TotalAmountofTicket",item.Cells["TicketBookPrice"].Value.ToString()),
                                    new SqlParameter("@DHAPShares",item.Cells["DHAPShares"].Value.ToString()),
                                    };
                                int result = Helper.SQLHelper.ExecuteNonQuery(sqlTrans, CommandType.StoredProcedure, "App.USP_AdventureTicketChallanDetail", paramdetail);
                            }
                            sqlTrans.Commit();
                        }

                        MessageBox.Show("Successfull.");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        sqlTrans.Rollback();
                        MessageBox.Show("Error Occur Record not Save:- " + ex.Message);
                    }
                }
            }

        }


    }
}
