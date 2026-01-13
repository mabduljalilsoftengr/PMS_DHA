using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.clsStampDuty;
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
using System.Globalization;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Application_Layer.StampDuty
{
    public partial class frmStampDuty_Create : Telerik.WinControls.UI.RadForm
    {
        public frmStampDuty_Create()
        {
            InitializeComponent();
        }
        private string GUICode { get; set; }
        private string txtamt { get; set; }
        private void txtFileNo_Leave(object sender, EventArgs e)
        {
           

        }

        private void frmStampDuty_Create_Load(object sender, EventArgs e)
        {
            GridCombobox();
            this.grd_SellerBuyerInfo.Columns.Move(2, 3);
            grpfiledetail.Enabled = false;
            grpuserdetail.Enabled = false;
            btnSave.Enabled = false;
        }
        private void GridCombobox()
        {
            GridViewComboBoxColumn comboColumn = new GridViewComboBoxColumn("Type");
            //set the column data source - the possible column values
            comboColumn.DataSource = new String[] { "Seller", "Buyer" };
            //set the FieldName - the column will retrieve the value from "Phone" column in the data table
            comboColumn.FieldName = "Type";
            comboColumn.Name = "Type";
            //add the column to the grid
            comboColumn.Width = 130;
            grd_SellerBuyerInfo.Columns.Add(comboColumn);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnFindLatestRefNuber_Click(sender,e);

            string slrbyrType = "";
            if (grd_SellerBuyerInfo.RowCount > 0)
            {
                foreach (GridViewRowInfo rw in grd_SellerBuyerInfo.Rows)
                {
                    slrbyrType = rw.Cells["Type"].Value.ToString() + "," + slrbyrType;
                }
                if (slrbyrType.Contains("Buyer") && slrbyrType.Contains("Seller"))
                {
                    #region DataTable Insertion
                    SqlParameter[] parmtr =
                    {
                    new SqlParameter("@Task","Insert_StampDuty_SellerBuyer"),
                    new SqlParameter(){ ParameterName = "@tbl_Stamp_Duty_Data",SqlDbType = SqlDbType.Structured, SqlValue = StampDuty_Table()},
                    new SqlParameter(){ ParameterName = "@tbl_Stamp_Duty_Data_Seller_Buyer",SqlDbType = SqlDbType.Structured, SqlValue = StampDuty_Table_SellerBuyer()}
                    };
                    int rslt = 0;
                    rslt = cls_dl_StampDuty.StampDuty_NonQuery(parmtr);
                    if (rslt > 0)
                    {
                        MessageBox.Show("Insertion is Successful.");
                        Clear();
                    }
                    #endregion
                }
                else
                {
                    MessageBox.Show("Both the Purchaser and Seller record are necessary.", "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seller & Buyer Information is missing. Kindly fill the Table.", "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Clear()
        {
            txtFileNo.Text = "";
            txtRefNo.Text = "";
            txtamount.Text = "";
            txtAmount_in_words.Text = "";
            txtREmarks.Text = "";
            grpfiledetail.Enabled = false;
            grpuserdetail.Enabled = false;
            btnSave.Enabled = false;
            chkEnsureStampDuty.CheckState = CheckState.Unchecked;
            grd_SellerBuyerInfo.DataSource = null;
        }
        private DataTable StampDuty_Table()
        {
            DataTable StampDutyTable = new DataTable();
            try
            {
                #region DataTable_Column Creation
                DataTable_column RefNo = new DataTable_column() { ColmnName = "RefNo", type = typeof(string) };
                DataTable_column Type = new DataTable_column() { ColmnName = "Type", type = typeof(string) };
                DataTable_column Amount = new DataTable_column() { ColmnName = "Amount", type = typeof(Decimal) };
                DataTable_column Amount_In_Words = new DataTable_column() { ColmnName = "Amount_In_Words", type = typeof(string) };
                DataTable_column Remarks = new DataTable_column() { ColmnName = "Remarks", type = typeof(string) };
                DataTable_column Status = new DataTable_column() { ColmnName = "Status", type = typeof(string) };
                DataTable_column GUI = new DataTable_column() { ColmnName = "GUI", type = typeof(string) };
                DataTable_column GenerationDate = new DataTable_column() { ColmnName = "GenerationDate", type = typeof(DateTime) };
                DataTable_column DepositeDate = new DataTable_column() { ColmnName = "DepositeDate", type = typeof(DateTime) };
                DataTable_column Stm_State = new DataTable_column() { ColmnName = "Stm_State", type = typeof(string) };
                DataTable_column userID = new DataTable_column() { ColmnName = "userID", type = typeof(int) };
                DataTable_column FileNo = new DataTable_column() { ColmnName = "FileNo", type = typeof(string) };
                #endregion
                #region Insert DataTabl_Column in List, and Send to Helper to make DataTable
                List<DataTable_column> colmn = new List<DataTable_column>();
                colmn.Add(RefNo);
                colmn.Add(Type);
                colmn.Add(Amount);
                colmn.Add(Amount_In_Words);
                colmn.Add(Remarks);
                colmn.Add(Status);
                colmn.Add(GUI);
                colmn.Add(GenerationDate);
                colmn.Add(DepositeDate);
                colmn.Add(Stm_State);
                colmn.Add(userID);
                colmn.Add(FileNo);
                StampDutyTable = clsPluginHelper.ColmnsCreateinDatatable(colmn);
                #endregion
                #region Insertion in DataTable
                DataRow row = StampDutyTable.NewRow();
                row["RefNo"] = txtRefNo.Text;
                row["Type"] = drp_type.SelectedItem.ToString();
                row["Amount"] = txtamount.Text;
                row["Amount_In_Words"] = txtAmount_in_words.Text;
                row["Remarks"] = txtREmarks.Text;
                row["Status"] = "Pending";
                row["GUI"] = "";
                row["GenerationDate"] = DateTime.Now; 
                row["DepositeDate"] = DateTime.Now ;
                row["Stm_State"] = "Active";
                row["userID"] = PeshawarDHASW.Models.clsUser.ID;
                row["FileNo"] = txtFileNo.Text;
                StampDutyTable.Rows.Add(row);
                #endregion
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on StampDuty_Table.", ex, "frmStampDuty_Create");
                frmobj.ShowDialog();
            }

            return StampDutyTable;
        }
        private DataTable StampDuty_Table_SellerBuyer()
        {
            DataTable StampDutyTable_SellerBuyer = new DataTable();
            try
            {
                #region DataTable_Column Creation
                DataTable_column Type = new DataTable_column() { ColmnName = "Type", type = typeof(string) };
                DataTable_column Name = new DataTable_column() { ColmnName = "Name", type = typeof(string) };
                DataTable_column CNIC = new DataTable_column() { ColmnName = "CNIC", type = typeof(string) };                
                DataTable_column MembershipNo = new DataTable_column() { ColmnName = "MembershipNo", type = typeof(string) };
                #endregion
                #region Insert DataTabl_Column in List, and Send to Helper to make DataTable
                List<DataTable_column> colmn = new List<DataTable_column>();
                colmn.Add(Type);
                colmn.Add(Name);
                colmn.Add(CNIC);                
                colmn.Add(MembershipNo);
                StampDutyTable_SellerBuyer = clsPluginHelper.ColmnsCreateinDatatable(colmn);
                #endregion
                #region Insertion in DataTable
                int rowcount = grd_SellerBuyerInfo.RowCount;
                for(int dr=0; dr < rowcount;dr++)
                {
                    DataRow row = StampDutyTable_SellerBuyer.NewRow();
                    row["Name"] = grd_SellerBuyerInfo.Rows[dr].Cells["Name"].Value.ToString();
                    row["CNIC"] = grd_SellerBuyerInfo.Rows[dr].Cells["NIC/NICOP"].Value.ToString();                   
                    row["MembershipNo"] = grd_SellerBuyerInfo.Rows[dr].Cells["MembershipNo"].Value.ToString();
                    row["Type"] = grd_SellerBuyerInfo.Rows[dr].Cells["Type"].Value.ToString();
                    StampDutyTable_SellerBuyer.Rows.Add(row);
                }              
                #endregion
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on StampDuty_Table_SellerBuyer.", ex, "frmStampDuty_Create");
                frmobj.ShowDialog();
            }

            return StampDutyTable_SellerBuyer;
        }
        
        private void txtamount_Leave(object sender, EventArgs e)
        {
            //txtamt = txtamount.Text;
            //txtAmount_in_words.Text = Convert_Number_To_Text(int.Parse(txtamt), false);
        }
        public static string Convert_Number_To_Text(int number, bool isUK)
        {
            if (number == 0) return "Zero";
            string and = isUK ? "and " : ""; // deals with UK or US numbering
            if (number == -2147483648) return "Minus Two Billion One Hundred " + and +
            "Forty Seven Million Four Hundred " + and + "Eighty Three Thousand " +
            "Six Hundred " + and + "Forty Eight";
            int[] num = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (number < 0)
            {
                sb.Append("Minus ");
                number = -number;
            }
            string[] words0 = { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };
            string[] words1 = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };
            string[] words2 = { "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };
            string[] words3 = { "Thousand ", "Million ", "Billion " };
            num[0] = number % 1000;           // units
            num[1] = number / 1000;
            num[2] = number / 1000000;
            num[1] = num[1] - 1000 * num[2];  // thousands
            num[3] = number / 1000000000;     // billions
            num[2] = num[2] - 1000 * num[3];  // millions
            for (int i = 3; i > 0; i--)
            {
                if (num[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (int i = first; i >= 0; i--)
            {
                if (num[i] == 0) continue;
                u = num[i] % 10;              // ones
                t = num[i] / 10;
                h = num[i] / 100;             // hundreds
                t = t - 10 * h;               // tens
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    if (h > 0 || i < first) sb.Append(and);
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }
            return sb.ToString().TrimEnd();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
               SqlParameter[] prmtr1 =
               {
                    new SqlParameter("@Task","CheckStampDutyDuplicate"),
                    new SqlParameter("@FileNo",txtFileNo.Text)
                };
                DataSet dst2 = cls_dl_StampDuty.StampDuty_Reader(prmtr1);
                if (dst2.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Pending Stamp Duty is already exist against this File No.", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    #region Get Stamp Duty Info
                    SqlParameter[] prm =
                    {
                         new SqlParameter("@Task","File_Info_StampDuty_ReferenceNo_GUI"),
                         new SqlParameter("@FileNo",txtFileNo.Text)
                    };
                    DataSet dst = new DataSet();
                    dst = cls_dl_StampDuty.StampDuty_Reader(prm);
                    if (dst.Tables.Count > 0)
                    {

                        grd_SellerBuyerInfo.DataSource = dst.Tables[0].DefaultView;

                        lblPlotSize.Text = dst.Tables[0].Rows[0]["PlotSize"].ToString();
                        txtRefNo.Text = dst.Tables[1].Rows[0]["ReferenceNo"].ToString();
                        //GUICode = dst.Tables[2].Rows[0]["GUI_Code"].ToString();
                        if (txtFileNo.Text.ToUpper().Contains("A/RES/") || txtFileNo.Text.ToUpper().Contains("OLO/A/RES/"))
                        {
                            txtamount.Text = "48000";
                            txtamt = txtamount.Text;
                            txtAmount_in_words.Text = Convert_Number_To_Text(int.Parse(txtamt), false);
                        }
                        if (txtFileNo.Text.ToUpper().Contains("B/RES/") || txtFileNo.Text.ToUpper().Contains("OLO/B/RES/"))
                        {
                            txtamount.Text = "24000";
                            txtamt = txtamount.Text;
                            txtAmount_in_words.Text = Convert_Number_To_Text(int.Parse(txtamt), false);
                        }
                        else if (txtFileNo.Text.ToUpper().Contains("C/RES/") || txtFileNo.Text.ToUpper().Contains("OLO/C/RES/") || txtFileNo.Text.ToUpper().Contains("C/RES/APS"))
                        {
                            txtamount.Text = "12000";
                            txtamt = txtamount.Text;
                            txtAmount_in_words.Text = Convert_Number_To_Text(int.Parse(txtamt), false);
                        }
                        else if (txtFileNo.Text.ToUpper().Contains("E/RES/") || txtFileNo.Text.ToUpper().Contains("OLO/E/RES/"))
                        {
                            txtamount.Text = "6000";
                            txtamt = txtamount.Text;
                            txtAmount_in_words.Text = Convert_Number_To_Text(int.Parse(txtamt), false);
                        }
                        else if (txtFileNo.Text.ToUpper().Contains("D/RES/") || txtFileNo.Text.ToUpper().Contains("OLO/D/RES/"))
                        {
                            txtamount.Text = "9600";
                            txtamt = txtamount.Text;
                            txtAmount_in_words.Text = Convert_Number_To_Text(int.Parse(txtamt), false);
                        }
                        else if (txtFileNo.Text.ToUpper().Contains("OLO/H/COM/"))
                        {
                            txtamount.Text = "8000";
                            txtamt = txtamount.Text;
                            txtAmount_in_words.Text = Convert_Number_To_Text(int.Parse(txtamt), false);
                        }
                        else if (txtFileNo.Text.ToUpper().Contains("G/COM/"))
                        {
                            txtamount.Text = "16000";
                            txtamt = txtamount.Text;
                            txtAmount_in_words.Text = Convert_Number_To_Text(int.Parse(txtamt), false);
                        }
                        dtpGenDate.Value = DateTime.Now;
                        drp_Status.SelectedIndex = 2;
                        drp_type.SelectedIndex = 1;

                        btnSave.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("There is no Data Found.");
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Enter the File No.","Stop.",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }
        }

        private void grd_SellerBuyerInfo_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "NIC/NICOP")
                {
                    // int rowindex = grdSeller_Buyer.CurrentCell.RowIndex;
                    object typ = e.Row.Cells["Type"].Value.ToString() == null ? clsPluginHelper.DbNullIfNullOrEmpty("") : e.Row.Cells["Type"].Value.ToString();

                    if (typ.ToString() == "Buyer")
                    {
                        string nic = e.Row.Cells["NIC/NICOP"].Value.ToString();
                        SqlParameter[] prm_ =
                        {
                        new SqlParameter("@Task","Select_Stamp_Duty_NotUse"),
                        new SqlParameter("@FileNo",txtFileNo.Text),
                        new SqlParameter("@CNIC",nic)
                        };
                        DataSet dst_ = new DataSet();
                        dst_ = cls_dl_StampDuty.StampDuty_Reader(prm_);
                        if (dst_.Tables.Count > 0)
                        {
                            if (dst_.Tables[0].Rows.Count > 0)
                            {
                                MessageBox.Show("There is already another Stamp Duty in Not-Use State against this FIle No. and Person.");
                                btnSave.Enabled = false;
                            }

                        }
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
          


        }

        private void btnFindLatestRefNuber_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] prmtr1 =
                {
                    new SqlParameter("@Task","CheckStampDutyDuplicate"),
                    new SqlParameter("@FileNo",txtFileNo.Text)
                };
                DataSet dst2 = cls_dl_StampDuty.StampDuty_Reader(prmtr1);
                if (dst2.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Pending Stamp Duty is already exist against this File No.", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    #region Get Stamp Duty Info
                    SqlParameter[] prm =
                    {
                         new SqlParameter("@Task","File_Info_StampDuty_ReferenceNo_GUI"),
                         new SqlParameter("@FileNo",txtFileNo.Text)
                    };
                    DataSet dst = new DataSet();
                    dst = cls_dl_StampDuty.StampDuty_Reader(prm);
                    if (dst.Tables.Count > 0)
                    {

                        //grd_SellerBuyerInfo.DataSource = dst.Tables[0].DefaultView;

                        lblPlotSize.Text = dst.Tables[0].Rows[0]["PlotSize"].ToString();
                        txtRefNo.Text = dst.Tables[1].Rows[0]["ReferenceNo"].ToString();
                        //GUICode = dst.Tables[2].Rows[0]["GUI_Code"].ToString();
                       
                        dtpGenDate.Value = DateTime.Now;
                        drp_Status.SelectedIndex = 2;
                        drp_type.SelectedIndex = 1;

                        btnSave.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("There is no Data Found.");
                        return;
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Enter File No.","Stop.",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }
        }

        private void chkEnsureStampDuty_CheckStateChanged(object sender, EventArgs e)
        {

            if (chkEnsureStampDuty.CheckState == CheckState.Checked)
            {
                grpfiledetail.Enabled = true;
                grpuserdetail.Enabled = true;
                btnSave.Enabled = true;
            }
            else
            {
                grpfiledetail.Enabled = false;
                grpuserdetail.Enabled = false;
                btnSave.Enabled = false;
            }
        }

        private void txtamount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int Amount = 0;
                bool br = int.TryParse(txtamount.Text, out Amount);
                if (br == true)
                {
                    txtAmount_in_words.Text = Convert_Number_To_Text(Amount, false);
                }
            }
            catch (Exception ex)
            {

            }
          
        }

        private void txtFileNo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab || e.KeyData == Keys.Enter)
            {
                    btnFind_Click(null, null);
            }
        }
    }
}
