using PeshawarDHASW.Application_Layer.Chalan;
using PeshawarDHASW.Data_Layer.clsChallan;
using PeshawarDHASW.Models;
using PeshawarDHASW.Report.Challan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Amalgamation
{
    public partial class frmNewEntryAmalgamation : Telerik.WinControls.UI.RadForm
    {
        public frmNewEntryAmalgamation()
        {
            InitializeComponent();
        }


        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {

           
            decimal TotalSizeMarla = 0;
            if (string.IsNullOrWhiteSpace(txtFileNo.Text) && string.IsNullOrWhiteSpace(txtPlotNo.Text))
            {
                MessageBox.Show("FileNo and Plot is Mandatory.");
                return;
            }
            foreach (var item in radGridView1.Rows)
            {

                if (!string.IsNullOrWhiteSpace(txtFileNo.Text) && item.Cells["FileNo"].Value.ToString().Contains(txtFileNo.Text) == true)
                {
                    MessageBox.Show("File No is already in the list.");
                    return;
                }
                if (!string.IsNullOrWhiteSpace(txtPlotNo.Text) && item.Cells["PlotNo"].Value.ToString().Contains(txtPlotNo.Text) == true)
                {
                    MessageBox.Show("Plot No is already in the list.");
                    return;
                }
            }
            txtAmalgamationPlotSize.Text = TotalSizeMarla.ToString();

            SqlParameter[] param = {
                    new SqlParameter("@Task","AmalgamtionRecord"),
                    new SqlParameter("@FileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtFileNo.Text)),
                    new SqlParameter("@PlotNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtPlotNo.Text))
            };
            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_tbl_Amalgamation", param);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        if (item["FileNo"].ToString().Contains("RES"))
                        {
                            lblBusinessType.Text = "RES";
                        }
                        if (item["FileNo"].ToString().Contains("COM"))
                        {
                            lblBusinessType.Text = "COM";
                        }
                        radGridView1.Rows.Add(item["FileNo"].ToString(), item["PlotNo"].ToString()
                            , item["PlotSize"].ToString(), item["ActualSize"].ToString(), item["MembershipNo"].ToString()
                            , item["CurrentOwner"].ToString() , item["CNIC"].ToString(),item["FileMapKey"].ToString(),item["MemberID"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("File/Plot No is not Exist Or Invalid.");
                }
            }

            ActualSizeCalc();
            LoadAmalgamationFeeStructure(lblBusinessType.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ActualSizeCalc()
        {
            try
            {
                if (radGridView1.RowCount ==0)
                {
                    txtAmalgamationPlotSize.Text = "0";
                    return;
                }
                List<AmalgamationCollection> lstAmalg = new List<AmalgamationCollection>();
                foreach (var item in radGridView1.Rows)
                {
                    string PlotSize = item.Cells["ActualSize"].Value.ToString().Replace(" Marla", "");
                    decimal plotSizeval = 0;
                    bool br = decimal.TryParse(PlotSize, out plotSizeval);
                    //TotalSizeMarla += plotSizeval;
                    AmalgamationCollection obj = new AmalgamationCollection();
                    obj.FileNo = item.Cells["FileNo"].Value.ToString();
                    obj.PlotNo = item.Cells["PlotNo"].Value.ToString();
                    obj.PlotSize = item.Cells["PlotSize"].Value.ToString();
                    obj.ActualSize = plotSizeval;
                    lstAmalg.Add(obj);
                }
                //  var lst = lstAmalg.Distinct().ToList();
                List<AmalgamationCollection> lst = lstAmalg.GroupBy(x => x.FileNo).Select(x => x.First()).ToList<AmalgamationCollection>();
                //for Amalgmation RES upto 1K=10000 and 2k above 250000
                if (lblBusinessType.Text=="RES")
                {
                    decimal ActualPlotSizeval = lst.Max(x => Convert.ToDecimal(x.ActualSize));
                    txtAmalgamationPlotSize.Text = ActualPlotSizeval.ToString();
                }
                //for Amalgamation COM Rate is Different
                else
                {
                    decimal ActualPlotSizeval = lst.Sum(x => Convert.ToDecimal(x.ActualSize));
                    txtAmalgamationPlotSize.Text = ActualPlotSizeval.ToString();
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void radGridView1_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "Remove")
                {
                    //string SelectedFileNo = e.Row.Cells["FileNo"].Value.ToString();
                    radGridView1.Rows.Remove(e.Row);
                    ActualSizeCalc();
                    DataTable ds = new DataTable();
                    dgvChallanDetails.DataSource = ds.DefaultView;
                }
            }
            catch (Exception)
            {

            }
          
        }


        private void LoadAmalgamationFeeStructure(string BusinessType)
        {
            cmbChallanHeDetail.Items.Clear();
            SqlParameter[] prm =
             {
                new SqlParameter("@Task","ChallanList"),
                new SqlParameter("@BusinessType",BusinessType),
            };
            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_tbl_Amalgamation", prm);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["ID"].ToString();
                dataItem.Text = row["Particulars"].ToString();
                dataItem.Tag = row["Amount"].ToString();
                cmbChallanHeDetail.Items.Add(dataItem);
            }
            cmbChallanHeDetail.SelectedIndex = -1;
        }

        private void frmNewEntryAmalgamation_Load(object sender, EventArgs e)
        {
            #region Get Max Challan No
            SqlParameter[] prm1 =
            {
                new SqlParameter("@Task","GetMaxChallanNo"),
            };
            DataSet ds1 = cls_dl_Challan.Challan_Reader(prm1);
            if (ds1.Tables.Count > 0 && string.IsNullOrEmpty(lblChallanNo.Text))
            {
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    lblChallanNo.Text = ds1.Tables[0].Rows[0][0].ToString();
                }
            }
            #endregion
        }

        private void cmbChallanHeDetail_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
           
        }

        private void dgvChallanDetails_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name == "DeleteColumn")
            {
                dgvChallanDetails.Rows.Remove(e.Row);
            }
        }

        private void btnAddchallanFee_Click(object sender, EventArgs e)
        {
            //Without File/Plot Selection Prevention
            if (radGridView1.RowCount == 0)
            {
                MessageBox.Show("Please Add File/Plot to Above Table Before Adding Fee.");
                return;
            }
            //Duplicate Prevention
            foreach (var item in dgvChallanDetails.Rows)
            {
                if (cmbChallanHeDetail.SelectedItem.Text.ToString() == item.Cells["Particulars"].Value.ToString())
                {
                    MessageBox.Show(cmbChallanHeDetail.SelectedItem.Text.ToString() + " is already in the Challan List.");
                    return;
                }
            }
            //Plot Size in Marla
            decimal Size = 0;
            decimal.TryParse(txtAmalgamationPlotSize.Text, out Size);

            //Amalgamation Calculation Per Marla Only 
            if (lblBusinessType.Text.Contains("COM"))
            {
                if (radGridView1.RowCount > 1)
                {
                    decimal Amount = decimal.Parse(cmbChallanHeDetail.SelectedItem.Tag.ToString());
                    decimal TotalValAmaglamtion = Size * Amount;
                    dgvChallanDetails.Rows.Add(cmbChallanHeDetail.SelectedItem.Value.ToString(), cmbChallanHeDetail.SelectedItem.Text.ToString(), TotalValAmaglamtion);
                }
               
                //else if (cmbChallanHeDetail.SelectedItem.Text.Contains("Per Marla"))
                //{
                //    decimal Amount = decimal.Parse(cmbChallanHeDetail.SelectedItem.Tag.ToString());
                //    decimal TotalDesign = Size * Amount;
                //    dgvChallanDetails.Rows.Add(cmbChallanHeDetail.SelectedItem.Value.ToString(), cmbChallanHeDetail.SelectedItem.Text.ToString(), TotalDesign);
                //}
                else
                {
                    MessageBox.Show("Fee Allow for more than two File/Plot.");
                }

            }
            else
            {
                decimal Amount = decimal.Parse(cmbChallanHeDetail.SelectedItem.Tag.ToString());
                dgvChallanDetails.Rows.Add(cmbChallanHeDetail.SelectedItem.Value.ToString(), cmbChallanHeDetail.SelectedItem.Text.ToString(), Amount);
            }
            //if (cmbChallanHeDetail.SelectedItem.Text.Contains("Amalgamation Per Marla"))
            //{
            //    if (radGridView1.RowCount > 1)
            //    {
            //        decimal Amount = decimal.Parse(cmbChallanHeDetail.SelectedItem.Tag.ToString());
            //        decimal TotalValAmaglamtion = Size * Amount;
            //        dgvChallanDetails.Rows.Add(cmbChallanHeDetail.SelectedItem.Value.ToString(), cmbChallanHeDetail.SelectedItem.Text.ToString(), TotalValAmaglamtion);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Amalgamation Fee Allow for more than two File/Plot.");
            //    }
            //}

        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
           


            #region List Generation
            List<FileInformation> lstFile = new List<FileInformation>();
            foreach (var item in radGridView1.Rows)
            {
              
                FileInformation obj = new FileInformation();
                obj.FileNo = item.Cells["FileNo"].Value.ToString();
                obj.PlotNo = item.Cells["PlotNo"].Value.ToString();
                obj.PlotSize = item.Cells["PlotSize"].Value.ToString();
                obj.ActualSize = item.Cells["ActualSize"].Value.ToString();
                obj.CurrentOwner = item.Cells["OwnerName"].Value.ToString();
                obj.NIC = item.Cells["CNIC"].Value.ToString();
                obj.MembershipNo= item.Cells["MembershipNo"].Value.ToString();
                lstFile.Add(obj);
            }
            List<ChallanInfo> lstChallanInfo = new List<ChallanInfo>();
            foreach (var item in dgvChallanDetails.Rows)
            {

                ChallanInfo obj = new ChallanInfo();
                obj.ParticularID =int.Parse(item.Cells["ParticularID"].Value.ToString());
                obj.ChallanParticular = item.Cells["Particulars"].Value.ToString();
                obj.ChallanAmount = int.Parse(item.Cells["Amount"].Value.ToString());
                lstChallanInfo.Add(obj);
            }
            #endregion

            if ((from std in lstFile select std.FileNo).Distinct().ToList().Count < 2)
            {
                MessageBox.Show("Please Add Two File/Plot No for Amalgamation.");
                return;
            }


            decimal ChallanTotalAmount = 0;
            if (lstChallanInfo.Count>0)
            {
                ChallanTotalAmount = (decimal)lstChallanInfo.Sum(x => x.ChallanAmount);
            }

            if (lstFile.Count==0 || lstChallanInfo.Count==0)
            {
                MessageBox.Show("File/Plot Information is Missing OR Fee of Challan is not Selected");
                return;
            }
            using (SqlConnection Objcon = Helper.SQLHelper.createConnection())
            {
              
                using (SqlTransaction sqlTrans = Objcon.BeginTransaction("AmalgamationProcess"))
                {
                    try
                    {

                   
                    SqlParameter[] paramAmalHead = {
                     new SqlParameter("@Task","AmalgamationHead")
                    ,new SqlParameter("@DateofRequest",DateTime.Now.ToString("yyyy-MM-dd"))
                    ,new SqlParameter("@UserID",clsUser.ID)
                    ,new SqlParameter("@TotalMarlaSize",txtAmalgamationPlotSize.Text)
                    ,new SqlParameter("@TotalChallanFee",ChallanTotalAmount)
                    ,new SqlParameter("@Remarks","")
                    ,new SqlParameter("@STATUS","Pending")
                        };
                    string AmalgHeadVal = Helper.SQLHelper.ExecuteScalar(sqlTrans, CommandType.StoredProcedure, "App.USP_tbl_Amalgamation", paramAmalHead).ToString();
                    string FileNoList = "", OwnerNameList = "", CNICList = "";
                    if (!string.IsNullOrWhiteSpace(AmalgHeadVal))
                    {
                        FileNoList = string.Join(",", (from std in lstFile select std.FileNo).Distinct().ToList());
                        foreach (FileInformation FileObject in lstFile)
                        {
                            //FileNoList = FileNoList + FileObject.FileNo + ",";
                            OwnerNameList = OwnerNameList + FileObject.CurrentOwner + ",";
                            CNICList = CNICList + FileObject.NIC + ",";

                            SqlParameter[] FileObjParam = {
                             new SqlParameter("@Task","AmalgamationDetail")
                             ,new SqlParameter("@AmalHead_ID",AmalgHeadVal)
                             ,new SqlParameter("@FileNo",FileObject.FileNo)
                             ,new SqlParameter("@PlotNo",FileObject.PlotNo)
                             ,new SqlParameter("@MembershipNo",FileObject.MembershipNo)
                             ,new SqlParameter("@NAME",FileObject.CurrentOwner)
                             ,new SqlParameter("@CNIC",FileObject.NIC)
                             ,new SqlParameter("@ActualSize",FileObject.ActualSize)
                             };
                            int ExecuteResult = Helper.SQLHelper.ExecuteNonQuery(sqlTrans, CommandType.StoredProcedure, "App.USP_tbl_Amalgamation", FileObjParam);
                        }

                        string FileMapKey = radGridView1.Rows[0].Cells["FileMapKey"].Value.ToString();
                        string MemberID = radGridView1.Rows[0].Cells["MemberID"].Value.ToString();
                        string ChallanIDOut = "";
                        string amount_in_word = Helper.clsPluginHelper.Convert_Number_To_Text((int)ChallanTotalAmount, false);
                        SqlParameter param_out_ID = new SqlParameter()
                        {
                            ParameterName = "@ChallanIDOutput",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Output
                        };

                        SqlParameter[] prm ={
                        new SqlParameter("@Task", "SaveChallan"),
                        new SqlParameter("@FileMapKey", FileMapKey),
                        new SqlParameter("@MemberID", MemberID),
                        new SqlParameter("@Name", OwnerNameList.Trim()),
                        new SqlParameter("@ChalanNo", lblChallanNo.Text.Trim()),
                        new SqlParameter("@ClearDate", DateTime.Now.Date),
                        new SqlParameter("@BankAccount", "0040100581377"),
                        new SqlParameter("@BankName", "Askari Bank Limited"),
                        new SqlParameter("@TotalAmount", ChallanTotalAmount),
                        new SqlParameter("@AmountInWord", amount_in_word),
                        new SqlParameter("@UserID", Models.clsUser.ID),
                        new SqlParameter("@ChallanType", "Other"),
                        new SqlParameter("@Status", null),
                        new SqlParameter("@RefNo", null),
                        new SqlParameter("@CNIC",CNICList),
                        new SqlParameter("@Description",FileNoList),
                        new SqlParameter("@PropertyDealerID",  null),
                        param_out_ID
                        };

                        SqlCommand result = Helper.SQLHelper.ExecuteNonQuery(sqlTrans,CommandType.StoredProcedure, "ch.USP_Challan","",prm);

                        if (result.Parameters.Count != 0)
                        {
                            ChallanIDOut = result.Parameters["@ChallanIDOutput"].Value.ToString();

                            SqlParameter[] paramchallanUpdateAmalgamation =
                            {
                            new SqlParameter("@Task","UpdateChallanIDAgainstAmalgRequest"),
                            new SqlParameter("@ChallanID",ChallanIDOut),
                            new SqlParameter("@AmalHead_ID",AmalgHeadVal),
                                 };
                            int ExecuteResult = Helper.SQLHelper.ExecuteNonQuery(sqlTrans, CommandType.StoredProcedure, "App.USP_tbl_Amalgamation", paramchallanUpdateAmalgamation);

                            int SerialNo = 1;
                            foreach (ChallanInfo item in lstChallanInfo)
                            {
                                SqlParameter[] prm2 =
                                     {
                                    new SqlParameter("@Task","SaveChallanDetail"),
                                    new SqlParameter("@ChallanID", ChallanIDOut),
                                    new SqlParameter("@ParticularID", item.ParticularID),
                                    new SqlParameter("@ParticularAmount", item.ChallanAmount),
                                    new SqlParameter("@UserID", Models.clsUser.ID),
                                    new SqlParameter("@SerialNo", SerialNo),
                                    new SqlParameter("@Particular",item.ChallanParticular),
                                    new SqlParameter("@ChallanType","Other" )
                                    //ChallanType
                                };
                                SerialNo = SerialNo + 1;
                                int resulte = Helper.SQLHelper.ExecuteNonQuery(
                                                    sqlTrans,
                                                    CommandType.StoredProcedure,
                                                    "ch.USP_Challan",
                                                    prm2
                                                    );
                            }
                            DataSet ds = new DataSet();
                            SqlParameter[] prm3 =
                            {
                                new SqlParameter("@Task","GetChallReportDetail"),
                                new SqlParameter("@ChallanID",ChallanIDOut)
                            };

                            ds = Helper.SQLHelper.ExecuteDataset(sqlTrans,CommandType.StoredProcedure,"ch.USP_Challan",prm3);
                            ChallanDataset _ds = new ChallanDataset();

                            _ds.Tables["tblChallan"].Merge(ds.Tables[0], true, MissingSchemaAction.Ignore);
                            _ds.Tables["tblChallanDetail"].Merge(ds.Tables[1], true, MissingSchemaAction.Ignore);
                            ds = null;
                            frmChallanReportViewer obj = new frmChallanReportViewer(_ds);
                            obj.ShowDialog();
                        }
                    }

                    sqlTrans.Commit();
                    }
                    catch (Exception ex)
                    {
                        sqlTrans.Rollback();
                        MessageBox.Show("Transaction is Roll Back Please Retry:->"+ex.Message);
                    }
                    this.Close();
                    Objcon.Dispose();
                }
            }
         }

        private void txtFileNo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //e.KeyData == Keys.Tab ||
            if ( e.KeyData == Keys.Enter)
            {
                btnFind_Click(null, null);
            }
        }

        private void txtPlotNo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnFind_Click(null, null);
            }
        }
    }

    public class AmalgamationCollection
    {
        public string FileNo { get; set; }
        public string PlotNo { get; set; }
        public string PlotSize { get; set; }
        public decimal ActualSize { get; set; }

    }
    public class FileInformation
    {
        public string PlotNo { get; set; }
        public string FileNo { get; set; }
        public string PlotSize { get; set; }
        public string MembershipNo { get; set; }
        public string CurrentOwner { get; set; }
        public string NIC { get; set; }
        public string ActualSize { get; set; }
    }
    public class ChallanInfo
    {
        public  int ParticularID { get; set; }
        public string ChallanParticular { get; set; }
        public int ChallanAmount { get; set; }
    }
}
