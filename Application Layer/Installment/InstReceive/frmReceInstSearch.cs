using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Application_Layer.Membership.MSViewInfo;
using PeshawarDHASW.Data_Layer.clsChallanRece;
using PeshawarDHASW.Data_Layer.clsMemberShip;
using PeshawarDHASW.Data_Layer.Installment;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Models;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Application_Layer.Installment.InstReceive.ImageRead;
using Telerik.WinControls.Data;
using PeshawarDHASW.Application_Layer.Installment.InstReceive.InstReceiveModify;

namespace PeshawarDHASW.Application_Layer.Installment.InstReceive
{
    public partial class frmReceInstSearch : Telerik.WinControls.UI.RadForm
    {
        private string ChallanNo { get; set; }

        #region  search button of dd recieve  ,exception generated 

        /// <summary>
        ///   An unhandled exception of type 'System.InvalidOperationException' occurred in Telerik.WinControls.GridView.dll

        //  Additional information: A column with the same Name already exists in the collection
        /// </summary>

        #endregion
        public frmReceInstSearch()
        {
            InitializeComponent();
        }
        public frmReceInstSearch(string Get_ChallanNo)
        {
            InitializeComponent();
            ChallanNo = Get_ChallanNo;
           
        }

        #region  DD Information
        private void DGVControls()
        {
            //  radgdInstReceive.MasterTemplate.Columns.Add(clsPluginHelper.GdButton("bDDImageID", "bDDImageID", "DD Image", "View", 80));
            //   radgdInstReceive.MasterTemplate.Columns.Add(clsPluginHelper.GdButton("bID", "bID", "MS Info", "View", 80));
            //   radgdInstReceive.MasterTemplate.Columns.Add(clsPluginHelper.GdButton("DDTotal_Amount", "DDTotal_Amount", "DD Total Amount", "View", 80));
        }

        public DataSet dataset_Installment { get; set; }

        private DataSet SearchingDD()
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@Task", "search"),
                 new SqlParameter("@PANo", clsPluginHelper.DbNullIfNullOrEmpty(txtPANo.Text)),
                new SqlParameter("@FileNo", clsPluginHelper.DbNullIfNullOrEmpty(txtfileno.Text)),
                new SqlParameter("@PlotNo", clsPluginHelper.DbNullIfNullOrEmpty(txtplotno.Text)),
                new SqlParameter("@Date", clsPluginHelper.DbNullIfNullOrEmpty(txtdate.Text)),
                new SqlParameter("@MSNo", clsPluginHelper.DbNullIfNullOrEmpty(txtmsno.Text)),
                new SqlParameter("@NIC", clsPluginHelper.DbNullIfNullOrEmpty(txtnic.Text)),
                new SqlParameter("@Amount", clsPluginHelper.DbNullIfNullOrEmpty(txtamount.Text)),
                new SqlParameter("@Status", clsPluginHelper.DbNullIfNullOrEmpty(txtstatus.Text)),
                new SqlParameter("@DDStatus", clsPluginHelper.DbNullIfNullOrEmpty(txtDDstatus.Text)),
                new SqlParameter("@DDNo", clsPluginHelper.DbNullIfNullOrEmpty(txtDDno.Text)),
                new SqlParameter("@BankName", clsPluginHelper.DbNullIfNullOrEmpty(txtbankname.Text)),
                new SqlParameter("@Branch", clsPluginHelper.DbNullIfNullOrEmpty(txtbranch.Text)),
                new SqlParameter("@Remarks", clsPluginHelper.DbNullIfNullOrEmpty(txtremarks.Text)),
                new SqlParameter("@PaymentMethod",clsPluginHelper.DbNullIfNullOrEmpty(drpPaymentMethod.Text))
            };
            DataSet ds = cls_dl_InstRece.Inst_Rece_Read(parameters);
            return ds;

        }

        private void DataLoadingofInstallment()
        {
            if (radgdInstReceive.InvokeRequired)
            {
                radgdInstReceive.Invoke(new MethodInvoker(() => { radgdInstReceive.DataSource = dataset_Installment.Tables[0].DefaultView; }));//or change here something in the underlay datasource
            }
            else
            {
                radgdInstReceive.DataSource = dataset_Installment.Tables[0].DefaultView;
            }
        }
        private void btnsearch_Click(object sender, EventArgs e)
        {
            btnsearch.Enabled = false;
            waitingbar.Visible = true;
            waitingbar.StartWaiting();
            dataset_Installment = SearchingDD();
            ReceiveInstallmentSearch.RunWorkerAsync();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            txtfileno.Text = "";
            txtplotno.Text = "";
            txtdate.Text = "";
        }

        private void radgdInstReceive_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {

                int rowindex = radgdInstReceive.CurrentCell.RowIndex;
                int columnindex = radgdInstReceive.CurrentCell.ColumnIndex;
                if (e.Column.Name == "Attachment")
                {
                   
                    try
                    {
                        long ReceID = int.Parse(e.Row.Cells["Rece_ID"].Value.ToString()); // ReceID
                        SqlParameter[] param ={
                                                new SqlParameter("@Task","SelectSearch"),//usp_tbl_DDTransferImages
                                                new SqlParameter("@ReceID",ReceID)
                                               };
                        DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "USP_tbl_ReceDDImages", param);
                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                Membership.MSImage.frmPhotoViewer obj = new Membership.MSImage.frmPhotoViewer(ds.Tables[0]);
                                obj.Show();
                            }
                            else
                            {
                                MessageBox.Show("No attachment(s) available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No attachment(s) available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                //if (e.Column.Name == "bDDImageID")
                //{
                //    int irID = 0;
                //    bool M = int.TryParse(radgdInstReceive.CurrentRow.Cells[12].Value.ToString(), out irID);
                //    if (M != false)
                //    {
                //        //MessageBox.Show("DDImage - > " + ddID.ToString());
                //        frmReceInstalImage frm = new frmReceInstalImage(irID, false, 100);
                //        frm.ShowDialog();
                //        SearchingDD();
                //    }
                //    else
                //    {
                //        RadMessageBox.Show("DD is not exist.", "Warning", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);

                //    }
                //}
                //if (e.Column.Name == "bID")
                //{
                //    int ID = 0;
                //    bool M = int.TryParse(radgdInstReceive.CurrentRow.Cells[""].Value.ToString(), out ID);
                //    if (M != false)
                //    {
                //        Membership.MSViewInfo.MSBioInfo obj = new MSBioInfo(ID);
                //        obj.ShowDialog();
                //    }
                //    else
                //    {
                //        MessageBox.Show("Member Ship is not exist");
                //    }

                //}
                if (e.Column.Name == "DDTotal_Amount")
                {
                    string DDNo = e.Row.Cells["DDNo"].Value.ToString();
                    if (DDNo != "")
                    {
                        frmDDTotal_Amount obj = new frmDDTotal_Amount(DDNo);
                        obj.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Demand Droft is not Exist");
                    }
                }

                if (e.Column.Name == "btnViewAudit")
                {
                    int ReceID = int.Parse(e.Row.Cells["Rece_ID"].Value.ToString());
                    SqlParameter[] param =
                    {
                       new SqlParameter("@ReceID",ReceID)
                    };
                    DataSet ds = cls_dl_InstRece.AR_Audit_Read(param);
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            frmDDAudit frm = new frmDDAudit(ds);
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("No record found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No record found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception ex)
            {
                #region Dangerous Error

                // MessageBox.Show("Search Grid \n Message -> "+ex.Message+"\nSource - > "+ex.Source);

                #endregion
            }
        }
        #endregion

        private void frmReceInstSearch_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            //radgdInstReceive.AutoSizeColumnsMode = Telerik.WinControls.UI.BestFitColumnMode.DisplayedDataCells;
            //dataset_Installment = SearchingDD();
            //ReceiveInstallmentSearch.RunWorkerAsync();
        }


       

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(radgdInstReceive);
        }

        private void radgdInstReceive_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement.ColumnInfo.Name == "S.No" && e.CellElement.Value == null)
            {
                e.CellElement.Value = e.CellElement.RowIndex + 1;
            }
        }

        private void radgdInstReceive_FilterPopupRequired(object sender, FilterPopupRequiredEventArgs e)
        {
            //if (e.FilterPopup is RadDateFilterPopup)
            //{
            //    RadDateFilterPopup popup = (RadDateFilterPopup)e.FilterPopup;
            //    popup.ClearCustomMenuItems();
            //    popup.AddCustomMenuItem("today", new DateFilterDescriptor(e.Column.Name, FilterOperator.IsEqualTo, DateTime.Today));
            //}
        }


        private void radgdInstReceive_CellFormatting_1(object sender, CellFormattingEventArgs e)
        {
            /* // Reset the color of the cell.  
             e.CellElement.DrawFill = false;
             // Example column index. Should be the cell you need to check for identical values.  
             int colIndex = 7;

             for (int i = 0; i < this.radgdInstReceive.Rows.Count; i++)
             {
                 GridViewCellInfo celli = this.radgdInstReceive.Rows[i].Cells[colIndex];
                 for (int j = 0; j < this.radgdInstReceive.Rows.Count; j++)
                 {
                     GridViewCellInfo cellj = this.radgdInstReceive.Rows[j].Cells[colIndex];
                     if (celli.Value.ToString() == cellj.Value.ToString() && i != j)
                     {
                         HighlightCell(celli);
                         HighlightCell(cellj);
                     }
                 }
             } */
        }
        private void HighlightCell(GridViewCellInfo cell)
        {

            if (cell.Style != null && cell.Style.DrawFill == false)
            {
                cell.Style.GradientStyle = GradientStyles.Solid;
                cell.Style.BackColor = Color.Red;
                cell.Style.DrawFill = true;
            }
        }

        private void btnExcelExport_Click_1(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(radgdInstReceive);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Software First.\n Error -> \n" + ex.Message);
            }
        }

        #region Enter Control to all Search
        private void txtfileno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnsearch_Click(null, null);
            }
        }

        private void txtplotno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnsearch_Click(null, null);
            }
        }

        private void txtmsno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnsearch_Click(null, null);
            }
        }

        private void txtnic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnsearch_Click(null, null);
            }
        }

        private void txtDDno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnsearch_Click(null, null);
            }
        }

        private void btnsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnsearch_Click(null, null);
            }
        }
        #endregion

        #region Duplicate Entries Finder
        private void radButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] parameters =
           {
                new SqlParameter("@Task", "Find_Duplicate_Entries"),
            };
                DataSet ds = cls_dl_InstRece.Inst_Rece_Read(parameters);
                radgdInstReceive.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Duplicate DD Finder.", ex, "frmReceInstSearch");
                frmobj.ShowDialog();
            }

        }
        #endregion

        private void ReceiveInstallmentSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            DataLoadingofInstallment();
        }

        private void ReceiveInstallmentSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                MessageBox.Show("Operation was canceled");
            else if (e.Error != null)
                MessageBox.Show(e.Error.Message);
            else
            {
                waitingbar.Visible = false;
                waitingbar.StopWaiting();
                btnsearch.Enabled = true;
                foreach (GridViewDataColumn column in radgdInstReceive.Columns)
                {
                    column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
                }
                //Color Changing in Grid
                ConditionalFormattingObject obj = new ConditionalFormattingObject("MyCondition1", ConditionTypes.Equal, "Received", "", true);
               
                obj.RowBackColor = Color.LightGreen;
                obj.RowForeColor = Color.Black;
                this.radgdInstReceive.Columns["DDStatus"].ConditionalFormattingObjectList.Add(obj);

                //ConditionalFormattingObject objr = new ConditionalFormattingObject("MyCondition2", ConditionTypes.Equal, "Cleared", "", true);
                //obj.CellForeColor = Color.White;
                //obj.RowBackColor = Color.Green;
                //this.radgdInstReceive.Columns["DDStatus"].ConditionalFormattingObjectList.Add(objr);

                //ConditionalFormattingObject objc = new ConditionalFormattingObject("MyCondition3", ConditionTypes.Equal, "Cancelled", "", true);
                //obj.CellForeColor = Color.White;
                //obj.RowBackColor = Color.Red;
                //this.radgdInstReceive.Columns["DDStatus"].ConditionalFormattingObjectList.Add(objc);

            }
        }

        #region PA No Search Enter Function
        private void txtPANo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnsearch_Click(null, null);
            }
        }
        #endregion

        private void radPageView1_SelectedPageChanged(object sender, EventArgs e)
        {

        }
    }
}
