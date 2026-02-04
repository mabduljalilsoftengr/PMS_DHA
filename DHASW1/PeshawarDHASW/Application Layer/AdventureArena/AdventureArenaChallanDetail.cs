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
    public partial class AdventureArenaChallanDetail : Telerik.WinControls.UI.RadForm
    {
        public AdventureArenaChallanDetail()
        {
            InitializeComponent();
        }

        public AdventureArenaChallanDetail(string TicketGeneratedID)
        {
            InitializeComponent();
            DataLoadingTicketInformation(TicketGeneratedID);
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
                if (ds.Tables.Count>0)
                {
                    if (ds.Tables[0].Rows.Count>0)
                    {
                        lblInvoiceNo.Text = ds.Tables[0].Rows[0]["TicketGenerateID"].ToString();
                        lblContractorName.Text= ds.Tables[0].Rows[0]["BuyerName"].ToString();
                        lblContractorCNIC.Text= ds.Tables[0].Rows[0]["BuyerCNIC"].ToString();
                        txtChequeNo.Text = ds.Tables[0].Rows[0]["ChequeNo"].ToString();
                        txtChequeAmount.Text = ds.Tables[0].Rows[0]["ChequeAmount"].ToString();
                        dtpReceiveDate.Value = DateTime.Parse(ds.Tables[0].Rows[0]["ChequeReceiveDate"].ToString());
                        txtAmtTotalFee.Text  = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
                        txtDHAPShares.Text  = ds.Tables[0].Rows[0]["DHAPShares"].ToString();
                          //= ds.Tables[0].Rows[0][""].ToString();
                          //= ds.Tables[0].Rows[0][""].ToString();

                    }
                    if (ds.Tables[1].Rows.Count>0)
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

        private void AdventureArenaChallanDetail_Load(object sender, EventArgs e)
        {

        }
    }
}
