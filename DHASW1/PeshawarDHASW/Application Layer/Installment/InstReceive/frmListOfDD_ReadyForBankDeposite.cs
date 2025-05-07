using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.Installment;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Installment.InstReceive
{
    public partial class frmListOfDD_ReadyForBankDeposite : Telerik.WinControls.UI.RadForm
    {
        public frmListOfDD_ReadyForBankDeposite()
        {
            InitializeComponent();
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
        }
        private DataSet ds { get; set; }
        private DataTable dt_b { get; set; }
        private DataTable dtb_Specific { get; set; }
        private DataTable dtb_l { get; set; }
        private void btnsearch_Click(object sender, EventArgs e)
        {
            #region
            if (dtpFromDate.Value.Date != null && dtpToDate.Value.Date != null)
            {
                SearchingDD();
                foreach (GridViewDataColumn column in radgdInstReceive.Columns)
                {
                    column.BestFit();
                }
                Summary_Column();
            }
            else
            {
                RadMessageBox.Show("Please Fill all the Fields.", "Information", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
            }
            #endregion
        }
        private void Summary_Column()
        {
            this.radgdInstReceive.SummaryRowsBottom.Clear();
            GridViewSummaryItem summaryItem = new GridViewSummaryItem();
            summaryItem.Name = "Amount";
            summaryItem.Aggregate = GridAggregateFunction.Sum;
            summaryItem.FormatString = "{0:#,###0.00;(#,###0.00);0}";

            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
            summaryRowItem.Add(summaryItem);

            this.radgdInstReceive.SummaryRowsBottom.Add(summaryRowItem);

        }
        private void SearchingDD()
        {
            string ddstatus = string.Empty;
            if (drpDDstatus.SelectedIndex > 0)
            {
                ddstatus = drpDDstatus.SelectedItem.ToString();
            }
            //object ddstatus = drpDDstatus.SelectedItem.ToString() == null ? clsPluginHelper.DbNullIfNullOrEmpty("") : drpDDstatus.SelectedItem.ToString();
            SqlParameter[] parameters =
            {
                new SqlParameter("@Task", "List_Of_DD_ReadyForBank"),
                new SqlParameter("@FromDate",dtpFromDate.Value.ToString("yyyy-MM-dd")),
                new SqlParameter("@ToDate",dtpToDate.Value.ToString("yyyy-MM-dd")),
                new SqlParameter("@DDStatus",clsPluginHelper.DbNullIfNullOrEmpty(ddstatus)),
                new SqlParameter("@FileNo",txtFileNo.Text)
            };
            ds = cls_dl_InstRece.Inst_Rece_Read(parameters);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    radgdInstReceive.DataSource = ds.Tables[0].DefaultView;

                }
                else
                {
                    MessageBox.Show("Check The Date Field.", "Warning", MessageBoxButtons.OK);
                }

            }
            else
            {
                MessageBox.Show("Their is no Data in These Dates.");
            }
        }

        private DataTable Bank_Detail_Table()
        {
            DataTable tbl_BankDetail = new DataTable();
            try
            {
                DataTable_column ListNo = new DataTable_column() { ColmnName = "ListNo", type = typeof(string) };
                DataTable_column Bank = new DataTable_column() { ColmnName = "Bank", type = typeof(string) };
                DataTable_column BankAccNo = new DataTable_column() { ColmnName = "BankAccNo", type = typeof(string) };
                List<DataTable_column> colmn = new List<DataTable_column>();
                colmn.Add(ListNo);
                colmn.Add(Bank);
                colmn.Add(BankAccNo);
                tbl_BankDetail = clsPluginHelper.ColmnsCreateinDatatable(colmn);
                DataRow row = tbl_BankDetail.NewRow();
                row["ListNo"] = txtListNo.Text;
                row["Bank"] = txtBankName.Text;
                row["BankAccNo"] = txtBankAccntNo.Text;

                tbl_BankDetail.Rows.Add(row);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Transfer_Tracking.", ex, "frmTransferVerification");
                frmobj.ShowDialog();
            }

            return tbl_BankDetail;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                #region MyRegion

                if (txtSnoFrom.Text != string.Empty && txtSnoTo.Text != string.Empty && txtBankName.Text != "" && txtBankAccntNo.Text != "" && txtListNo.Text != "")
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataSet dst = new DataSet();
                            DataTable _Grid_selection_data = GridSelectedData_Table();
                            dst.Merge(_Grid_selection_data);

                            DataTable _bank_detial_Table_dtbl = Bank_Detail_Table();
                            dst.Merge(_bank_detial_Table_dtbl);

                            if (MessageBox.Show("Are you Sure you want to Generate the List ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                #region Insertion Of Bank List Report Detail
                                #region Make List from
                                //List<object> lstReceID = new List<object>();
                                //for (int i = 0; i < this.radgdInstReceive.ChildRows.Count; i++)
                                //{
                                //    lstReceID.Add(int.Parse(radgdInstReceive.ChildRows[i].Cells["Rece_ID"].Value.ToString()));
                                //}

                                #endregion
                                dt_b = clsPluginHelper.Convert_Grid_To_DataTable(radgdInstReceive);
                                dtb_Specific = new DataTable();
                                dtb_l = new DataTable();

                                #region Old Method




                                //    int Sno_from = int.Parse(txtSnoFrom.Text);
                                //    int Sno_To = int.Parse(txtSnoTo.Text);
                                //    for (int rwc = Sno_from - 1; rwc <= Sno_To - 1; rwc++)
                                //    {
                                //        IEnumerable<DataRow> query = from row in dt_b.AsEnumerable()
                                //                                     where row.Field<string>("Rece_ID") == radgdInstReceive.ChildRows[rwc].Cells["Rece_ID"].Value.ToString()
                                //                                     select row; //returns IEnumerable<DataRow>
                                //        dtb_Specific = query.CopyToDataTable<DataRow>();
                                //        dtb_l.Merge(dtb_Specific);
                                //    }
                                //    SqlParameter[] parmtr =
                                //    {
                                // new SqlParameter(){ ParameterName = "@tbl_banklistdetail",SqlDbType = SqlDbType.Structured, SqlValue = dtb_l},
                                // new SqlParameter(){ ParameterName = "@tbl_banklisthead",SqlDbType = SqlDbType.Structured, SqlValue = _bank_detial_Table_dtbl}
                                //};

                                int rslt = 0;
                                //rslt = cls_dl_InstRece.Inst_Rece_NonQuery(parmtr);
                                #endregion

                                #region Witout Table Value Parameter

                                if (Insert_HeadDetail())
                                {
                                    if (Insert_GridDetail())
                                    {
                                        frmListOfDD_ReadyForBankDeposite_ReportViewer frmobj = new frmListOfDD_ReadyForBankDeposite_ReportViewer(dst);
                                        frmobj.ShowDialog();
                                        txtListNo.Text = "";
                                    }
                                    else
                                    {
                                        if (DeletePreviousBankListHead())
                                        {
                                            MessageBox.Show("DD Bank List Does't Save.");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Error is Occured, Please Contact with Administration.");
                                        }


                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Bank List Head Detail Insertion Issue.");
                                }

                                #endregion

                                #endregion
                                #region Make Report
                                //if (rslt > 0)
                                //{
                                //    frmListOfDD_ReadyForBankDeposite_ReportViewer frmobj = new frmListOfDD_ReadyForBankDeposite_ReportViewer(dst);
                                //    frmobj.ShowDialog();
                                //    txtListNo.Text = "";
                                //}
                                //else
                                //{
                                //    MessageBox.Show("DD Bank List Does't Save.");
                                //}
                                #endregion

                            }
                        }
                        else
                        {
                            RadMessageBox.Show("There is no Data(Rows) in Table.");
                        }
                    }
                    else
                    {
                        RadMessageBox.Show("There is no Table in DataSet");
                    }
                }
                else
                {
                    RadMessageBox.Show("You must Fill All the Fields.");
                }

                #endregion
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.InnerException);
            }

        }

        private bool DeletePreviousBankListHead()
        {
            bool bl = false;
            SqlParameter[] parmtr =
            {
                new SqlParameter("@Task","Delete_Previous_BankList_Head")
            };
            int rslt = cls_dl_InstRece.Inst_Rece_NonQuery(parmtr);
            if (rslt > 0)
            {
                bl = true;
            }
            return bl;
        }
        private bool Insert_HeadDetail()
        {
            bool bl = false;
            SqlParameter[] parmtr =
            {
            new SqlParameter("@Task","Enter_BankList_Head"),
            new SqlParameter("@List_No", txtListNo.Text),
            new SqlParameter("@BankName", txtBankName.Text),
            new SqlParameter("@BankAccNo", txtBankAccntNo.Text)
        };
            int rslt = cls_dl_InstRece.Inst_Rece_NonQuery(parmtr);
            if (rslt > 0)
            {
                bl = true;
            }
            else
            {
                bl = false;
            }

            return bl;
        }

        private bool Insert_GridDetail()
        {
            bool bl = false;
            try
            {

                #region New Method
                int Sno_from = int.Parse(txtSnoFrom.Text);
                int Sno_To = int.Parse(txtSnoTo.Text);
                int rslt_ = 0;
                for (int rwc = Sno_from - 1; rwc <= Sno_To - 1; rwc++)
                {
                    IEnumerable<DataRow> query = from row in dt_b.AsEnumerable()
                                                 where row.Field<string>("Rece_ID") == radgdInstReceive.ChildRows[rwc].Cells["Rece_ID"].Value.ToString()
                                                 select row; //returns IEnumerable<DataRow>
                    dtb_Specific = query.CopyToDataTable<DataRow>();



                    //int intr = int.Parse(dtb_Specific.Rows[0]["S.No"].ToString()==""?"0": dtb_Specific.Rows[0]["S.No"].ToString());
                    //string dtr = dtb_Specific.Rows[0]["FileNo"].ToString();
                    //string dtr1 = dtb_Specific.Rows[0]["PlotNo"].ToString();
                    //DateTime dtr2 = Helper.clsPluginHelper.GetDateTime(dtb_Specific.Rows[0]["Date"].ToString());
                    //string dtr3 = dtb_Specific.Rows[0]["MSName"].ToString();
                    //string dtr4 = dtb_Specific.Rows[0]["DDNo"].ToString();
                    //DateTime dtr5 = Helper.clsPluginHelper.GetDateTime(dtb_Specific.Rows[0]["DDGenerationDate"].ToString());
                    //string dtr6 = dtb_Specific.Rows[0]["Amount"].ToString();
                    //string dtr7 = dtb_Specific.Rows[0]["AmountInWords"].ToString();
                    //string dtr8 = dtb_Specific.Rows[0]["BankName"].ToString();
                    //string dtr9 = dtb_Specific.Rows[0]["DDStatus"].ToString();
                    //int dtr10 = int.Parse(dtb_Specific.Rows[0]["Rece_ID"].ToString());
                    //string dt11r = dtb_Specific.Rows[0]["Remarks"].ToString();
                    //int dtr12 = int.Parse(dtb_Specific.Rows[0]["FileMapKey"].ToString());
                    //int dtr13 = int.Parse(dtb_Specific.Rows[0]["DDImageID"].ToString()==""?"0": dtb_Specific.Rows[0]["DDImageID"].ToString());
                    //int dtr14 = int.Parse(dtb_Specific.Rows[0]["ID"].ToString());
                    //string dtr15 = dtb_Specific.Rows[0]["PaymentMethod"].ToString();
                    //string dtr16 = dtb_Specific.Rows[0]["PlotSize"].ToString();
                    //string dtr17 = dtb_Specific.Rows[0]["Username"].ToString();
                    //int dtr18 = int.Parse(dtb_Specific.Rows[0]["Blh_ID"].ToString());

                   // int str = int.Parse(dtb_Specific.Rows[0]["DDImageID"].ToString() == "" ? "0" : dtb_Specific.Rows[0]["DDImageID"].ToString());
                   // MessageBox.Show(str.ToString());

                    SqlParameter[] prmtr =
                        {
                            new SqlParameter("@Task","Enter_BankList_Detail"),
                            new SqlParameter("@S_No",int.Parse((dtb_Specific.Rows[0]["S.No"].ToString()))),
                            new SqlParameter("@FileNo",dtb_Specific.Rows[0]["FileNo"].ToString()),
                            new SqlParameter("@PlotNo",dtb_Specific.Rows[0]["PlotNo"].ToString()),
                            new SqlParameter("@Date",Helper.clsPluginHelper.GetDateTime(dtb_Specific.Rows[0]["Date"].ToString())),
                            new SqlParameter("@Name",dtb_Specific.Rows[0]["MSName"].ToString()),
                            new SqlParameter("@DDNo",dtb_Specific.Rows[0]["DDNo"].ToString()),
                            new SqlParameter("@DDGenerationDate",Helper.clsPluginHelper.GetDateTime(dtb_Specific.Rows[0]["DDGenerationDate"].ToString())),
                            new SqlParameter("@Amount",dtb_Specific.Rows[0]["Amount"].ToString()),
                            new SqlParameter("@AmountInWords",dtb_Specific.Rows[0]["AmountInWords"].ToString()),
                            new SqlParameter("@BankName",dtb_Specific.Rows[0]["BankName"].ToString()),
                            new SqlParameter("@Branch",dtb_Specific.Rows[0]["Branch"].ToString()),
                            new SqlParameter("@DDStatus",dtb_Specific.Rows[0]["DDStatus"].ToString()),
                            new SqlParameter("@TRX_ReceID",int.Parse(dtb_Specific.Rows[0]["Rece_ID"].ToString())),
                            new SqlParameter("@Remarks",dtb_Specific.Rows[0]["Remarks"].ToString()),
                            new SqlParameter("@FileKeyID",int.Parse(dtb_Specific.Rows[0]["FileMapKey"].ToString())),
                            new SqlParameter("@DDImageID",0),
                            new SqlParameter("@ID",int.Parse(dtb_Specific.Rows[0]["ID"].ToString())),
                            new SqlParameter("@PaymentMethod",dtb_Specific.Rows[0]["PaymentMethod"].ToString()),
                            new SqlParameter("@PlotSize",dtb_Specific.Rows[0]["PlotSize"].ToString()),
                            new SqlParameter("@Username",dtb_Specific.Rows[0]["Username"].ToString()),
                    //new SqlParameter("@banklistHeaderID",int.Parse(dtb_Specific.Rows[0]["Blh_ID"].ToString())),
                     };
                    rslt_ = cls_dl_InstRece.Inst_Rece_NonQuery(prmtr);
                    //dtb_l.Merge(dtb_Specific);
                }


                if (rslt_ > 0)
                {
                    bl = true;
                }
                #endregion
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.InnerException);
            }

            return bl;


        }
        #region Make Data Table
        private DataTable GridSelectedData_Table()
        {
            DataTable GridSelectedTbl = new DataTable();
            try
            {
                #region DataTable_Column Creation
                DataTable_column Rece_ID = new DataTable_column() { ColmnName = "Rece_ID", type = typeof(int) };
                DataTable_column Date = new DataTable_column() { ColmnName = "Date", type = typeof(DateTime) };
                DataTable_column Amount = new DataTable_column() { ColmnName = "Amount", type = typeof(decimal) };
                DataTable_column DDNo = new DataTable_column() { ColmnName = "DDNo", type = typeof(string) };
                DataTable_column BankName = new DataTable_column() { ColmnName = "BankName", type = typeof(string) };
                DataTable_column Branch = new DataTable_column() { ColmnName = "Branch", type = typeof(string) };
                DataTable_column DDImageID = new DataTable_column() { ColmnName = "DDImageID", type = typeof(int) };
                DataTable_column Status = new DataTable_column() { ColmnName = "Status", type = typeof(string) };
                DataTable_column Remarks = new DataTable_column() { ColmnName = "Remarks", type = typeof(string) };
                DataTable_column DDStatus = new DataTable_column() { ColmnName = "DDStatus", type = typeof(string) };
                DataTable_column AmountInwords = new DataTable_column() { ColmnName = "AmountInwords", type = typeof(string) };
                DataTable_column DDGenerationDate = new DataTable_column() { ColmnName = "DDGenerationDate", type = typeof(DateTime) };
                DataTable_column FileMapKey = new DataTable_column() { ColmnName = "FileMapKey", type = typeof(int) };
                DataTable_column FileNo = new DataTable_column() { ColmnName = "FileNo", type = typeof(string) };
                DataTable_column ID = new DataTable_column() { ColmnName = "ID", type = typeof(int) };
                DataTable_column Name = new DataTable_column() { ColmnName = "Name", type = typeof(string) };
                DataTable_column Transferree = new DataTable_column() { ColmnName = "Transferree", type = typeof(string) };
                DataTable_column PlotSize = new DataTable_column() { ColmnName = "PlotSize", type = typeof(string) };
                //DataTable_column PaymentMethodMode = new DataTable_column() { ColmnName = "PaymentMethod", type = typeof(string) };
                ///////////////////////////////
                //DataTable_column Bank = new DataTable_column() { ColmnName = "Bank", type = typeof(string) };
                //DataTable_column BankAccNo = new DataTable_column() { ColmnName = "BankAccNo", type = typeof(string) };
                //DataTable_column ListNo = new DataTable_column() { ColmnName = "ListNo", type = typeof(string) };
                #endregion
                #region Insert DataTabl_Column in List, and Send to Helper to make DataTable
                List<DataTable_column> colmn = new List<DataTable_column>();
                colmn.Add(Rece_ID);
                colmn.Add(Date);
                colmn.Add(Amount);
                colmn.Add(DDNo);
                colmn.Add(BankName);
                colmn.Add(Branch);
                colmn.Add(DDImageID);
                colmn.Add(Status);
                colmn.Add(Remarks);
                colmn.Add(DDStatus);
                colmn.Add(AmountInwords);
                colmn.Add(DDGenerationDate);
                colmn.Add(FileMapKey);
                colmn.Add(FileNo);
                colmn.Add(ID);
                colmn.Add(Name);
                colmn.Add(Transferree);
                colmn.Add(PlotSize);
                //colmn.Add(PaymentMethodMode);
                //////////////////////////////////////
                //colmn.Add(Bank);
                //colmn.Add(BankAccNo);
                //colmn.Add(ListNo);
                //////////////////////////////////////////////////
                GridSelectedTbl = clsPluginHelper.ColmnsCreateinDatatable(colmn);
                #endregion
                #region Insertion in DataTable
                int rowcount = radgdInstReceive.ChildRows.Count;
                int Sno_from = int.Parse(txtSnoFrom.Text);
                int Sno_To = int.Parse(txtSnoTo.Text);
                //for(int rwc = 0; rwc < rowcount; rwc++)
                for (int rwc = Sno_from - 1; rwc <= Sno_To - 1; rwc++)
                {
                    string ddimageid = radgdInstReceive.ChildRows[rwc].Cells["DDImageID"].Value.ToString() == "" ? "0" : radgdInstReceive.Rows[rwc].Cells["DDImageID"].Value.ToString();
                    int? id = null;
                    if (!string.IsNullOrEmpty(radgdInstReceive.ChildRows[rwc].Cells["ID"].Value.ToString()))
                        id = int.Parse(radgdInstReceive.ChildRows[rwc].Cells["ID"].Value.ToString());
                    //   object id = radgdInstReceive.ChildRows[rwc].Cells["ID"].Value.ToString() == "" ? DBNull.Value : radgdInstReceive.ChildRows[rwc].Cells["ID"].Value;
                    string rmks = radgdInstReceive.ChildRows[rwc].Cells["Remarks"].Value.ToString() == "" ? "-" : radgdInstReceive.ChildRows[rwc].Cells["Remarks"].Value.ToString();
                    string ddstats = radgdInstReceive.ChildRows[rwc].Cells["DDStatus"].Value.ToString() == "" ? "" : radgdInstReceive.ChildRows[rwc].Cells["DDStatus"].Value.ToString();
                    string amountinword = radgdInstReceive.ChildRows[rwc].Cells["AmountInwords"].Value.ToString() == "" ? "" : radgdInstReceive.ChildRows[rwc].Cells["AmountInwords"].Value.ToString();
                    //string ddgenerationdate = radgdInstReceive.ChildRows[rwc].Cells["DDGenerationDate"].Value.ToString() == "" ? "01/12/1900" : radgdInstReceive.ChildRows[rwc].Cells["DDGenerationDate"].Value.ToString();
                    string bankname = radgdInstReceive.ChildRows[rwc].Cells["BankName"].Value.ToString() == "" ? "" : radgdInstReceive.ChildRows[rwc].Cells["BankName"].Value.ToString();
                    string brac = radgdInstReceive.ChildRows[rwc].Cells["Branch"].Value.ToString() == "" ? "" : radgdInstReceive.ChildRows[rwc].Cells["Branch"].Value.ToString();
                    string pltsize = radgdInstReceive.ChildRows[rwc].Cells["PlotSize"].Value.ToString() == "" ? "" : radgdInstReceive.ChildRows[rwc].Cells["PlotSize"].Value.ToString();
                    string filen = radgdInstReceive.ChildRows[rwc].Cells["FileNo"].Value.ToString() == "" ? "" : radgdInstReceive.ChildRows[rwc].Cells["FileNo"].Value.ToString();
                    string filky = radgdInstReceive.ChildRows[rwc].Cells["FileMapKey"].Value.ToString() == "" ? "" : radgdInstReceive.ChildRows[rwc].Cells["FileMapKey"].Value.ToString();
                    // string date = radgdInstReceive.ChildRows[rwc].Cells["Date"].Value.ToString() == "" ? DateTime.Now.ToString("dd/MM/yyyy") : radgdInstReceive.ChildRows[rwc].Cells["Date"].Value.ToString();
                    string MSName = radgdInstReceive.ChildRows[rwc].Cells["MSName"].Value.ToString();
                    DataRow row = GridSelectedTbl.NewRow();
                    //row["Rece_ID"] = int.Parse(radgdInstReceive.ChildRows[rwc].Cells[14].Value.ToString());

                    //DateTime dateTime = DateTime.ParseExact(dateString,"yyyy/MM/dd",CultureInfo.InvariantCulture);


                    row["Rece_ID"] = int.Parse(radgdInstReceive.ChildRows[rwc].Cells["Rece_ID"].Value.ToString());
                    try
                    {
                        row["Date"] = radgdInstReceive.ChildRows[rwc].Cells["Date"].Value;
                    }
                    catch (Exception)
                    {
                    }
                    row["Amount"] = Convert.ToDecimal(radgdInstReceive.ChildRows[rwc].Cells["Amount"].Value.ToString());
                    row["DDNo"] = radgdInstReceive.ChildRows[rwc].Cells["DDNo"].Value.ToString();
                    row["BankName"] = bankname;
                    row["Branch"] = brac;
                    row["DDImageID"] = int.Parse(ddimageid);
                    row["Status"] = "";//radgdInstReceive.ChildRows[rwc].Cells["Status"].Value.ToString();
                    row["Remarks"] = rmks;
                    row["DDStatus"] = ddstats;
                    row["AmountInwords"] = amountinword;
                    try
                    {
                        row["DDGenerationDate"] = radgdInstReceive.ChildRows[rwc].Cells["DDGenerationDate"].Value;
                    }
                    catch (Exception)
                    {
                    }

                    row["FileMapKey"] = int.Parse(filky);
                    row["FileNo"] = filen;
                    row["ID"] = id == null ? DBNull.Value : (object)id;
                    row["Name"] = string.IsNullOrEmpty(MSName) ? DBNull.Value : (object)radgdInstReceive.ChildRows[rwc].Cells["MSName"].Value.ToString();
                    row["Transferree"] = ""; //radgdInstReceive.ChildRows[rwc].Cells["Transferree"].Value.ToString(); 
                    row["PlotSize"] = pltsize;
                    GridSelectedTbl.Rows.Add(row);
                }
                //DataRow row1 = GridSelectedTbl.NewRow();
                //row1["Bank"] = txtBankName.Text;
                //row1["BankAccNo"] = txtBankAccntNo.Text;
                //row1["ListNo"] = txtListNo.Text;
                //GridSelectedTbl.Rows.Add(row1);
                #endregion
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Bank List.", ex, "frmNDCCreate");
                frmobj.ShowDialog();
            }

            return GridSelectedTbl;
        }
        #endregion
        private void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(radgdInstReceive);
        }
        public DataSet BankAccountInfo { get; set; }
        private void frmListOfDD_ReadyForBankDeposite_Load(object sender, EventArgs e)
        {
            Excel_Like_Filtring();
            //Bank Name Add to Combobox
            BankAccountInfo = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_tbl_BankAccount", new SqlParameter("@Task", "BankAccountList_Show"));

            txtBankName.DataSource = BankAccountInfo.Tables[0];
            txtBankName.DisplayMember = "BankName";
            txtBankName.ValueMember = "AccountNo";
            txtBankAccntNo.Text = "";
        }
        private void Get_ListNumber()
        {
            if (txtBankName.SelectedIndex > 0)
            {
                SqlParameter[] prmt =
                {
                    new SqlParameter("@Task","Get_NewListNo"),
                    new SqlParameter("@BankAccNo",txtBankName.SelectedValue)
                };
                DataSet dst = cls_dl_InstRece.Inst_Rece_Read(prmt);
                txtListNo.Text = dst.Tables[0].Rows[0]["ListNo"].ToString();
            }
            else
            {
                RadMessageBox.Show("Please select Bank Name first.", "Information", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                txtBankName.ShowDropDown();
            }

        }
        private void Excel_Like_Filtring()
        {
            this.radgdInstReceive.EnableFiltering = true;
            this.radgdInstReceive.MasterTemplate.ShowHeaderCellButtons = true;
            this.radgdInstReceive.MasterTemplate.ShowFilteringRow = false;
        }
        // Add Serial No. to RadGridview
        //Step-1 : First add Decimal Column to the RadGridview 
        //Step-2 : Add CellFormatting Event to the RadGridView and write this code
        private void radgdInstReceive_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            #region This code is use to attach serial no. with grid , but in filtring,reOrdring etc the Serial No. order is disturbed
            // It is use to 
            //if (e.CellElement.ColumnInfo.Name == "S.No" && e.CellElement.Value == null)
            //{
            //    e.CellElement.Value = e.CellElement.RowIndex + 1;
            //}
            #endregion
            #region This code is use to attach serial no. with grid , but in filtring,reOrdring etc the Serial No. order will be not disturbed
            if (e.CellElement.ColumnInfo.Name == "S.No" && string.IsNullOrEmpty(e.CellElement.Text))
            {
                e.CellElement.Text = (e.CellElement.RowIndex + 1).ToString();
            }
            #endregion
        }

        private void txtBankName_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

            txtBankAccntNo.Text = txtBankName.SelectedValue.ToString();

        }

        private void DataLoading_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void DataLoading_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void btn_GenerateListNo_Click(object sender, EventArgs e)
        {
            Get_ListNumber();
        }
    }
}
