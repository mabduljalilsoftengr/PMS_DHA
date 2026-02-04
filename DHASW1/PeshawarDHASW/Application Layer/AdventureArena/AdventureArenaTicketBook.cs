using Bytescout.BarCode;
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
    public partial class AdventureArenaTicketBook : Telerik.WinControls.UI.RadForm
    {
        public AdventureArenaTicketBook()
        {
            InitializeComponent();
            DataLoadingAdventureHeadTicket();
            DataLoadingAdventureHeadTicketGenerating();
            DataLoadingAdventureBookTicketStatus();
            DataLoadingAdventureTicketBookPrinting();
            DataLoadingCategoryDropDown();
            dptTicketBookStatusList.SelectedIndex = 0;
            btnSaveChanges.Enabled = false;
        }

        private void DataLoadingAdventureHeadTicket()
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Task","TicketBookDataView")
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure
                    , "App.USP_AdventureTicketBookHead", param
                    );
                AdventureTicketBookDataGridView.DataSource = ds.Tables[0].DefaultView;
                gdvTicketBookStatus.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DataLoadingAdventureBookTicketStatus()
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Task","TicketBookStatusUpdate")
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure
                    , "App.USP_AdventureTicketBookHead", param
                    );
                gdvTicketBookStatus.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DataLoadingAdventureHeadTicketGenerating()
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Task","TicketBookGenerationPending")
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure
                    , "App.USP_AdventureTicketBookHead", param
                    );
                dgvGenerateTicket.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataLoadingAdventureTicketBookPrinting()
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Task","TicketBookReadyforPrint")
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure
                    , "App.USP_AdventureTicketBookHead", param
                    );
                dgvTicketBookPrintRequest.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DataLoadingCategoryDropDown()
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Task","ListofTicketbook")
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure
                    , "App.USP_AdventureArenaChallan", param
                    );
                ddTicketDetailList.DataSource = ds.Tables[0].DefaultView;
                ddTicketDetailList.DisplayMember = "TicketDetailTitle";
                ddTicketDetailList.ValueMember = "TicketDetailID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AdventureArenaTicketBook_Load(object sender, EventArgs e)
        {
            btnGenerateTickets.Enabled = false;
            btnSaveChanges.Enabled = false;
        }

        private void btnNewBookRequest_Click(object sender, EventArgs e)
        {
            TicketBookID.Text = "0";
            TicketBookStartFrom.Text = "1";
            TicketBookEndOn.Text = "100";
            BookSize.Enabled = true;
            ddTicketDetailList_SelectedIndexChanged(null, null);
            try
            {
                int PageSize = 0;
                bool PageSizeParse = int.TryParse(BookSize.SelectedItem.Text, out PageSize);
                if (PageSizeParse == true)
                {
                    int TicketStartVal = 0;
                    bool TicketStartvalParse = int.TryParse(TicketBookStartFrom.Text, out TicketStartVal);

                    int TicketEndVal = 0;
                    bool TicketEndValParse = int.TryParse(TicketBookEndOn.Text, out TicketEndVal);

                    decimal TicketFeeVal = 0;
                    bool TicketFeeValParse = decimal.TryParse(lblTicketFee.Text, out TicketFeeVal);

                    TicketEndVal = TicketStartVal + (PageSize - 1);
                    decimal TicketbookFee = 0;
                    TicketbookFee = PageSize * TicketFeeVal;
                    TicketBookEndOn.Text = TicketEndVal.ToString();
                    TicketBookPrice.Text = TicketbookFee.ToString();
                }
                else
                {
                    MessageBox.Show("Invalid Book Size.");
                }
            }
            catch(Exception)
            {

            }
        }

        private void AdventureTicketBookDataGridView_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Row.Cells["TicketBookStatus"].Value.ToString() == "TicketGenerationPending")
                {
                    TicketBookID.Text = e.Row.Cells["TicketBookID"].Value.ToString();
                    int ticketDetailValue = int.Parse(e.Row.Cells["TicketCategoryID"].Value.ToString());
                    Helper.clsPluginHelper.RadDropDownSelectedbyValue(ddTicketDetailList, ticketDetailValue);
                    ddTicketDetailList_SelectedIndexChanged(null, null);
                    TicketBookStartFrom.Text = e.Row.Cells["TicketNoInDigitFrom"].Value.ToString();
                    TicketBookEndOn.Text = e.Row.Cells["TicketNoInDigitTo"].Value.ToString();
                    TicketBookRemarks.Text = e.Row.Cells["Remarks"].Value.ToString();
                    TicketBookPrice.Text = e.Row.Cells["TicketBookPrice"].Value.ToString();
                    BookSize.Enabled = true;
                }
                else
                {
                    TicketBookID.Text = "0";
                    TicketBookStartFrom.Text = "0";
                    TicketBookEndOn.Text = "0";
                    TicketBookRemarks.Text = "0";
                    BookSize.Enabled = false;
                    MessageBox.Show("Ticket Book Information Cannot be Modified Due to Ticket is Generated.");
                }

            }
            catch (Exception)
            {

            }
        }

        private void ddTicketDetailList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Task","SingleofTicket"),
                     new SqlParameter("@TicketDetailID",ddTicketDetailList.SelectedItem.Value),
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure
                    , "App.USP_AdventureArenaChallan", param
                    );

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        // lblticketTitle.Text = ds.Tables[0].Rows[0]["TicketDetailID"].ToString();
                        lblticketTitle.Text = ds.Tables[0].Rows[0]["TicketHeadTitle"].ToString();
                        lblAgeGroup.Text = ds.Tables[0].Rows[0]["Type_AgeGroup"].ToString();
                        TicketCode.Text = ds.Tables[0].Rows[0]["TicketCode"].ToString();
                        lblTicketFee.Text = ds.Tables[0].Rows[0]["Fee"].ToString();

                        int ticketend = 0;
                        bool ticketendval = int.TryParse(ds.Tables[0].Rows[0]["NewStarting"].ToString(), out ticketend);
                        TicketBookStartFrom.Text = ds.Tables[0].Rows[0]["NewStarting"].ToString();
                        TicketBookEndOn.Text = (ticketend + 99).ToString();
                    }
                }

            }
            catch (Exception)
            {

            }
        }

        private void BookSize_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                int PageSize = 0;
                bool PageSizeParse = int.TryParse(BookSize.SelectedItem.Text, out PageSize);
                if (PageSizeParse == true)
                {
                    int TicketStartVal = 0;
                    bool TicketStartvalParse = int.TryParse(TicketBookStartFrom.Text, out TicketStartVal);

                    int TicketEndVal = 0;
                    bool TicketEndValParse = int.TryParse(TicketBookEndOn.Text, out TicketEndVal);

                    decimal TicketFeeVal = 0;
                    bool TicketFeeValParse = decimal.TryParse(lblTicketFee.Text, out TicketFeeVal);

                    TicketEndVal = TicketStartVal + (PageSize - 1);
                    decimal TicketbookFee = 0;
                    TicketbookFee = PageSize * TicketFeeVal;
                    TicketBookEndOn.Text = TicketEndVal.ToString();
                    TicketBookPrice.Text = TicketbookFee.ToString();
                }
                else
                {
                    MessageBox.Show("Invalid Book Size.");
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnSaveBookRequest_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] param =
                {
                        new SqlParameter("@Task","TicketBookNew"),
                        new SqlParameter("@TicketBookID",TicketBookID.Text),
                        new SqlParameter("@TicketNoInDigitFrom",TicketBookStartFrom.Text),
                        new SqlParameter("@TicketNoInDigitTo",TicketBookEndOn.Text),
                        new SqlParameter("@TicketCategoryID",ddTicketDetailList.SelectedItem.Value),
                        new SqlParameter("@TicketCategory",ddTicketDetailList.SelectedItem.Text),
                        new SqlParameter("@TicketGroupLetter",TicketCode.Text.Replace(" ","")),
                        new SqlParameter("@GenerationDate",DateTime.Now),
                        new SqlParameter("@Remarks",TicketBookRemarks.Text),
                        new SqlParameter("@TicketBookStatus","TicketGenerationPending"),
                        new SqlParameter("@InsertBy",clsUser.ID),
                        new SqlParameter("@InsertDate",DateTime.Now),
                        new SqlParameter("@UpdateBy",clsUser.ID),
                        new SqlParameter("@UpdateDate",DateTime.Now),
                        new SqlParameter("@TicketBookPrice",TicketBookPrice.Text)
                };
                int Result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection()
                    , CommandType.StoredProcedure, "App.USP_AdventureTicketBookHead", param);
                if (Result > 0)
                {
                    MessageBox.Show("Successfull.");
                    TicketBookID.Text = "0";
                    TicketBookStartFrom.Text = "0";
                    TicketBookEndOn.Text = "0";
                    TicketBookRemarks.Text = "0";
                    BookSize.Enabled = false;

                }
                else
                {
                    MessageBox.Show("Error Occurs");
                }
                DataLoadingAdventureHeadTicket();
                DataLoadingAdventureHeadTicketGenerating();
                DataLoadingAdventureBookTicketStatus();
                DataLoadingAdventureTicketBookPrinting();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvGenerateTicket_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Row.Cells["TicketBookStatus"].Value.ToString() == "TicketGenerationPending")
                {
                    lblCode.Text = e.Row.Cells["TicketCode"].Value.ToString();
                    lblStart.Text = e.Row.Cells["TicketNoInDigitFrom"].Value.ToString();
                    lblEndDigit.Text = e.Row.Cells["TicketNoInDigitTo"].Value.ToString();

                    lblTicketBookCode.Text = e.Row.Cells["TicketBookID"].Value.ToString();
                    TicketbookTitle.Text = e.Row.Cells["TicketDetailTitle"].Value.ToString();
                    TicketStartFormVal.Text = e.Row.Cells["TicketNoFrom"].Value.ToString();
                    TicketEndFormVal.Text = e.Row.Cells["TicketNoTo"].Value.ToString();
                    btnGenerateTickets.Enabled = true;
                    btnSaveChanges.Enabled = true;
                }
                else
                {
                    btnGenerateTickets.Enabled = false;
                    btnSaveChanges.Enabled = false;
                    MessageBox.Show("Ticket Book is Already Generated. Please Create New Book.");
                }

            }
            catch (Exception)
            {
            }
        }

        private void btnGenerateTickets_Click(object sender, EventArgs e)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@Task","GenerateTicketList"),
                new SqlParameter("@TicketCategory",TicketbookTitle.Text),
                new SqlParameter("@TicketGroupLetter",lblCode.Text),
                new SqlParameter("@TicketNoInDigitFrom",lblStart.Text),
                new SqlParameter("@TicketNoInDigitTo",lblEndDigit.Text)
            };
            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure
                 , "App.USP_AdventureTicketBookHead", param
                 );
            if (string.IsNullOrWhiteSpace(lblCode.Text))
            {
                MessageBox.Show("Intial of Ticket is Not Alloted.");
                return;
            }
            gdvTicketInfo.DataSource = ds.Tables[0].DefaultView;
            btnSaveChanges.Enabled = true;
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, "Please Verify Before Generation of Tickets", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    SqlParameter[] param =
                      {
                    new SqlParameter("@Task","GenerateTicketListandSaved"),
                    new SqlParameter("@TicketBookID",lblTicketBookCode.Text),
                    new SqlParameter("@TicketCategory",TicketbookTitle.Text),
                    new SqlParameter("@TicketGroupLetter",lblCode.Text),
                    new SqlParameter("@TicketNoInDigitFrom",lblStart.Text),
                    new SqlParameter("@TicketNoInDigitTo",lblEndDigit.Text),
                    new SqlParameter("@InsertBy",clsUser.ID),
                    new SqlParameter("@InsertDate",DateTime.Now),
                    };
                    int ds = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure
                         , "App.USP_AdventureTicketBookHead", param
                         );
                    if (ds > 0)
                    {
                        MessageBox.Show("Successfull");
                        lblTicketBookCode.Text = "";
                        TicketbookTitle.Text = "";
                        lblCode.Text = "";
                        lblStart.Text = "";
                        lblEndDigit.Text = "";
                        TicketBookStartFrom.Text = "";
                        TicketBookEndOn.Text = "";
                        gdvTicketInfo.DataSource = null;
                    }
                    else
                    {
                        MessageBox.Show("Ticket Generation Fail.");
                    }
                    DataLoadingAdventureHeadTicket();
                    DataLoadingAdventureHeadTicketGenerating();
                    DataLoadingAdventureBookTicketStatus();
                    DataLoadingAdventureTicketBookPrinting();
                    btnSaveChanges.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gdvTicketBookStatus_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Row.Cells["TicketBookStatus"].Value.ToString() == "Issued" 
                   //|| e.Row.Cells["TicketBookStatus"].Value.ToString() == "PrintRequestIssued"
                   // || e.Row.Cells["TicketBookStatus"].Value.ToString() == ""
                   )
                {
                    MessageBox.Show("Ticket Book is Locked in this Status Cannot be Changed.");
                    return;
                }
                else
                {
                    lblTBSBookNo.Text = e.Row.Cells["TicketBookID"].Value.ToString();
                    lblTBS_Title.Text = e.Row.Cells["TicketDetailTitle"].Value.ToString();
                    lblTBS_Start.Text = e.Row.Cells["TicketNoFrom"].Value.ToString();
                    lblTBS_End.Text = e.Row.Cells["TicketNoTo"].Value.ToString();
                    string StatusVal = e.Row.Cells["TicketBookStatus"].Value.ToString();
                    Helper.clsPluginHelper.RadDropDownSelectByText(ddl_TBS_Status, StatusVal);
                    txtTBSRemarks.Text = e.Row.Cells["Remarks"].Value.ToString();
                }
               
            }
            catch (Exception)
            {

            }
        }

        private void btnTicketStatusBookChange_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] param = 
                {
                    new SqlParameter("@Task","TicketBookStatusUpdate"),
                    new SqlParameter("@TicketBookStatus",ddl_TBS_Status.SelectedItem.Text),
                    new SqlParameter("@TicketBookStatusDate",dtp_TicketBookStatuschangedate.Value.Date),
                    new SqlParameter("@Remarks",txtTBSRemarks.Text),
                    new SqlParameter("@UpdateBy",clsUser.ID),
                    new SqlParameter("@UpdateDate",DateTime.Now),
                    new SqlParameter("@TicketBookID",lblTBSBookNo.Text),
                };
                int result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(),
                        CommandType.StoredProcedure, "App.USP_AdventureTicketBookHead", param
                        );
                if (result > 0)
                {
                    MessageBox.Show("Successfull");
                    lblTBSBookNo.Text = "";
                    lblTBS_Title.Text = "";
                    lblTBS_Start.Text = "";
                    lblTBS_End.Text = "";
                    ddl_TBS_Status.SelectedIndex = 0;
                    txtTBSRemarks.Text = "";
                }
                else
                {
                    MessageBox.Show("Error Occur Status is not Update.");
                }
                DataLoadingAdventureHeadTicket();
                DataLoadingAdventureHeadTicketGenerating();
                DataLoadingAdventureBookTicketStatus();
                DataLoadingAdventureTicketBookPrinting();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBookPrintReportGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                
                Report.AdventureArena.AdventureArenaBookPrintingDs objAABP = new Report.AdventureArena.AdventureArenaBookPrintingDs();
                foreach (var item in dgvTicketBookPrintRequest.Rows)
                {

                    bool? Select = false;
                    Select = item.Cells["Select"].Value as bool?;
                 
   
                    if (Select == true)
                    {
                        int TicketBookID = 0;
                        bool TicketBookIDval = int.TryParse(item.Cells["TicketBookID"].Value.ToString(), out TicketBookID);
                        string TicketDetailTitle = item.Cells["TicketDetailTitle"].Value.ToString();
                        string Type_AgeGroup = item.Cells["Type_AgeGroup"].Value.ToString();
                        string TicketNoFrom = item.Cells["TicketNoFrom"].Value.ToString();
                        string TicketNoTo = item.Cells["TicketNoTo"].Value.ToString();
                        DateTime GenerationDate = DateTime.Parse(item.Cells["GenerationDate"].Value.ToString());
                        byte[] QrCode = BarcodeImage(TicketBookID.ToString() + "," + TicketDetailTitle + "," + Type_AgeGroup + "," + TicketNoFrom + "," + TicketNoTo + "," + GenerationDate.ToString("yyyy-MM-dd"));

                        objAABP.Tables[0].Rows.Add(TicketBookID, TicketDetailTitle, Type_AgeGroup, TicketNoFrom, TicketNoTo, GenerationDate, QrCode);

                    }

                }
                if (objAABP.Tables[0].Rows.Count > 0)
                {
                    AdventureArenaReportViewer objreport = new AdventureArenaReportViewer("AdventureArenaTicketBook", objAABP);
                    objreport.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private byte[] BarcodeImage(string Data)
        {
            Barcode qrc = new Barcode(SymbologyType.QRCode);
            qrc.DrawCaption = false;
            qrc.Value = Data;
            byte[] qrcodeBytes = qrc.GetImageBytesWMF();
            return qrcodeBytes;
        }

        private void btnMarkedasRequestforPrint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure to mark the select as PrintRequestIssued.", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (var item in dgvTicketBookPrintRequest.Rows)
                {

                    bool? Select = false;
                    Select = item.Cells["Select"].Value as bool?;
 
                    if (Select == true)
                    {
                        int TicketBookID = 0;
                        bool TicketBookIDval = int.TryParse(item.Cells["TicketBookID"].Value.ToString(), out TicketBookID);
                        SqlParameter[] param = {
                        new SqlParameter("@Task","UpdateTicketBookStatus"),
                        new SqlParameter("@TicketBookStatus",dptTicketBookStatusList.SelectedItem.Text),
                        new SqlParameter("@TicketBookID",TicketBookID),
                    };
                        int result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(),
                            CommandType.StoredProcedure, "App.USP_AdventureTicketBookHead", param);
                    }
                }
                DataLoadingAdventureHeadTicket();
                DataLoadingAdventureHeadTicketGenerating();
                DataLoadingAdventureBookTicketStatus();
                DataLoadingAdventureTicketBookPrinting();
               
            }
       }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            DataLoadingAdventureHeadTicket();
            DataLoadingAdventureHeadTicketGenerating();
            DataLoadingAdventureBookTicketStatus();
            DataLoadingAdventureTicketBookPrinting();
        }
    }
}
