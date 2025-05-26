using PeshawarDHASW.Application_Layer.Transfer.TransferReport;
using PeshawarDHASW.Helper;
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

namespace PeshawarDHASW.Application_Layer.OpenTransfer
{
    public partial class OpenTransferCheckList : Telerik.WinControls.UI.RadForm
    {
        public OpenTransferCheckList()
        {
            InitializeComponent();
        }
        public int NDCNo { get; set; }
        public string fileId { get; set; }
        public string pertransferid { get; set; }
        public string fileno { get; set; }
        public DataSet Checklistrecord { get; set; }
        public  DataTable dt_chk { get; set; }
        public OpenTransferCheckList(int NDCNo_,string fileNo_,string fileId_,string pertransferid_,string ownername)
        {
            InitializeComponent();
            fileno = fileNo_;
            lblname.Text = ownername;
            NDCNo = NDCNo_;
            fileId = fileId_;
            pertransferid = pertransferid_;
            
        }

      
        private void OpenTransferCheckList_Load(object sender, EventArgs e)
        {
            try
            {
                int ndcno = NDCNo;
                string filenopr = fileno;
                string fileidpr = fileId;
                string pertransferID = pertransferid;

                SqlParameter[] prm =
                {
                    new SqlParameter("@Task","GetTransferCheckList"),
                    new SqlParameter("@NDCNo",ndcno),
                    new SqlParameter("@PerTransferID",pertransferID),
                    new SqlParameter("@FileNo",filenopr),
                    new SqlParameter("@FileID",fileidpr)
                };
                Checklistrecord = new DataSet();
                Checklistrecord = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.OpentransferReport", prm);
                lblfile_no.Text = Checklistrecord.Tables[0].Rows[0]["FileNo"].ToString();
                lblname.Text = Checklistrecord.Tables[0].Rows[0]["Name"].ToString();
               
                grdTfrChecklist.DataSource = Checklistrecord.Tables[2];

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                int recnt = grdTfrChecklist.Rows.Count;
                if (recnt > 0)
                {
                    #region
                    int inccnt = 0;
                    foreach (GridViewRowInfo row in grdTfrChecklist.Rows)
                    {
                        bool chk = Convert.ToBoolean(row.Cells["chkRecieved"].Value);
                        if (chk)
                        {
                            inccnt = inccnt + 1;
                            //string category = Convert.ToString(row.Cells[1].Value);
                            //string particular = Convert.ToString(row.Cells[2].Value);
                            //string detail = Convert.ToString(row.Cells[3].Value);
                            //string status = Convert.ToString(row.Cells[4].Value);
                        }
                    }
                    if (recnt == inccnt)
                    {
                        if (!Checklistrecord.Tables[2].Columns.Contains("BuyerName") &&
                            !Checklistrecord.Tables[2].Columns.Contains("FileNo")
                          )
                        {
                            dt_chk = Checklistrecord.Tables[2];
                            dt_chk.Columns.Add("BuyerName", typeof(System.String));
                            dt_chk.Columns.Add("DateOfTransfer", typeof(System.DateTime));
                            dt_chk.Columns.Add("FileNo", typeof(System.String));
                            dt_chk.Columns.Add("DateOfAllocation", typeof(System.String));
                            dt_chk.Columns.Add("UserName", typeof(System.String));

                            foreach (DataRow row in dt_chk.Rows)
                            {
                                //need to set value to NewColumn column
                                row["BuyerName"] = lblname.Text;   // or set it to some other value
                                row["DateOfTransfer"] = DateTime.Now.ToString("yyyy-MM-dd");
                                row["FileNo"] = lblfile_no.Text;
                                row["DateOfAllocation"] = "";
                                row["UserName"] = Models.clsUser.Name;
                            }
                        }
                        else
                        {
                            dt_chk.Columns.Remove("BuyerName");
                            dt_chk.Columns.Remove("DateOfTransfer");
                            dt_chk.Columns.Remove("FileNo");
                            dt_chk.Columns.Remove("DateOfAllocation");
                            dt_chk.Columns.Remove("UserName");


                            dt_chk = Checklistrecord.Tables[2];
                            dt_chk.Columns.Add("BuyerName", typeof(System.String));
                            dt_chk.Columns.Add("DateOfTransfer", typeof(System.DateTime));
                            dt_chk.Columns.Add("FileNo", typeof(System.String));
                            dt_chk.Columns.Add("DateOfAllocation", typeof(System.String));
                            dt_chk.Columns.Add("UserName", typeof(System.String));

                            foreach (DataRow row in dt_chk.Rows)
                            {
                                //need to set value to NewColumn column
                                row["BuyerName"] = lblname.Text;   // or set it to some other value
                                row["DateOfTransfer"] = DateTime.Now;
                                row["FileNo"] = lblfile_no.Text;
                                    row["DateOfAllocation"] = "";
                                row["UserName"] = Models.clsUser.Name;
                            }
                        }

                     //   frm_Checklist_Report_Viewer frm = new frm_Checklist_Report_Viewer(dt_chk, "ChecklistReport");
                     ///   frm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Please verify all the documents.", "Stop!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                    OpenTransferReports.TransferCheckListData = dt_chk;
                    this.Close();
                    #endregion
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
    }
}
