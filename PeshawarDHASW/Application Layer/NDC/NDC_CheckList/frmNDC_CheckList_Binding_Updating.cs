using PeshawarDHASW.Data_Layer.clsNDCChecklist;
using PeshawarDHASW.Data_Layer.NDC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Models;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Application_Layer.NDC.NDC_CheckList
{
    public partial class frmNDC_CheckList_Binding_Updating : Telerik.WinControls.UI.RadForm
    {
        public int NDCNo { get; set; }
        public int NDC_Against_FileNo { get; set; }
        public int checklistid { get; set; }
        public string FileNo { get; set; }
        public bool NDCTextBoxStatus { get; set; }
        public frmNDC_CheckList_Binding_Updating()
        {
            InitializeComponent();
        }
        public frmNDC_CheckList_Binding_Updating(int getNDCNO,bool get_Status,string fileno)
        {
            InitializeComponent();
            if (getNDCNO != 0 )
            {
                NDCNo = getNDCNO;
                txtNDCNo.Enabled = false;
                radGroupBox2.Enabled = get_Status;
                Find.Enabled = false;
                FileNo = fileno.ToUpper();

            }
        }
       
        private void CheckAndRetrieveCheckList()
        {
            try
            {
                #region If CheckList is Exist Against FileNo/NDCNo
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","Count_CheckListItemStatus_For_NDC"),
                new SqlParameter("@NDCNo",txtNDCNo.Text)
                };
                DataSet ds = new DataSet();
                ds = cls_dl_NDCChecklist.NDCCheckListReader(prm);
                #endregion
                //int.Parse(ds.Tables[0].Rows[0]["TotalStatus"].ToString())
                if (ds.Tables[0].Rows.Count > 0)
                {
                    #region Then Retrieve
                    SqlParameter[] pr_m =
                     {
                     new SqlParameter("@Task","select"),
                     new SqlParameter("@NDCNo",txtNDCNo.Text)
                     };
                    DataSet dst = new DataSet();
                    dst = cls_dl_NDCChecklist.NDCCheckListReader(pr_m);
                    grdChecklist.DataSource = dst.Tables[0].DefaultView;

                    #endregion
                }

                else
                {
                    DataSet dst_ = GetNDCType();
                    string ndctp = dst_.Tables[0].Rows[0]["NDCType"].ToString();
                    //Insert new with "NO" status
                    #region Get CheckListItem ID's
                    SqlParameter[] prmt =
                    {
                    new SqlParameter("@Task","Get_CheckListItemID")
                    };
                    DataSet d_s = new DataSet();
                    d_s = cls_dl_NDCChecklist.NDCCheckListReader(prmt);
                    if (d_s.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in d_s.Tables[0].Rows)
                        {
                            checklistid = int.Parse(row["NDC_ItemID"].ToString());
                            bool flcntn = FileNo.Contains("OLO") || FileNo.Contains("DPQ");
                            /// CheckListNo = 11 is NOC check for OLO Files
                            /// CheckListNo = 1016,1017,1019 are the Checklist for Hiba transfer
                            if ((ndctp == "Hiba" || ndctp == "LegalHeir" || ndctp == "LegalHeirSvc" || ndctp == "LegalHeirCivil") && (flcntn == true))
                            {
                                CheckListInsertion();
                            }
                            else if((ndctp == "Hiba" || ndctp == "LegalHeir" || ndctp == "LegalHeirSvc" || ndctp == "LegalHeirCivil") && (flcntn == false))
                            {
                                if(checklistid != 11)
                                {
                                    CheckListInsertion();
                                }
                            }
                            else if(ndctp == "Normal" && flcntn == true)
                            {
                                if (checklistid != 1016 && checklistid != 1017 && checklistid != 1019)
                                {
                                    CheckListInsertion();
                                }
                            }
                            else if(ndctp == "Normal" && flcntn == false)
                            {
                                if (checklistid != 1016 && checklistid != 1017 && checklistid != 1019 && checklistid != 11)
                                {
                                    CheckListInsertion();
                                }
                            }
                        }
                    }
                    //Then Retrieve
                    #region Retrieve Data For Grid
                    SqlParameter[] pr_m =
                    {
                    new SqlParameter("@Task","select"),
                    new SqlParameter("@NDCNo",int.Parse(txtNDCNo.Text))
                    };
                    DataSet d_st = new DataSet();
                    d_st = cls_dl_NDCChecklist.NDCCheckListReader(pr_m);
                    grdChecklist.DataSource = d_st.Tables[0].DefaultView;
                    #endregion
                    #endregion

                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on CheckAndRetrieveCheckList.", ex, "frmNDC_CheckList_Binding_Updating");
                frmobj.ShowDialog();
            }
           
        }
        private void CheckListInsertion()
        {
            #region Insert New Record
            SqlParameter[] p_r =
            {
             new SqlParameter("@Task","Insert"),
             new SqlParameter("@NDC_ChecklistItemID",checklistid),
             new SqlParameter("@NDCNo",int.Parse(txtNDCNo.Text)),
             new SqlParameter("@CheckListStatus","No")
            };
            int rslt = 0;
            rslt = cls_dl_NDCChecklist.NDCCheckListNonQuery(p_r);
            #endregion
        }
        private DataSet GetNDCType()
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","GetNDCType"),
                new SqlParameter("@NDCNo",txtNDCNo.Text)
            };
            DataSet dts = cls_dl_NDC.NdcRetrival(prm);
            return dts;
        }
        private void frmCheckListFilling_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            GridColumns();           
            if (NDCNo == 0 | NDCNo == 0)
            {
                //CheckAndRetrieveCheckList();
            }
            else
            {
                txtNDCNo.Text = NDCNo.ToString(); 
                CheckAndRetrieveCheckList();

            }
            #region Load Data for Grid
            //SqlParameter[] prmt =
            //{
            //    new SqlParameter("@Task","select")
            //};
            //DataSet dst = new DataSet();
            //dst = cls_dl_NDCChecklist.NDCCheckListReader(prmt);
            //grdChecklist.DataSource = dst.Tables[0].DefaultView;
            #endregion

        }
        private void GridColumns()
        {
            try
            {
                #region Bind Columns With Grid
                GridViewComboBoxColumn comboColumn = new GridViewComboBoxColumn("Status");
                //set the column data source - the possible column values
                comboColumn.DataSource = new String[] { "Yes","N/A"  };
                //set the FieldName - the column will retrieve the value from "Phone" column in the data table
                comboColumn.FieldName = "CheckListStatus";
                comboColumn.Name = "status";
                //add the column to the grid
                grdChecklist.Columns.Add(comboColumn);
                this.grdChecklist.Columns.Move(4, 5); // Move Column "Status" From Index No.4 to Index No.5

                //GridViewTextBoxColumn textDetail = new GridViewTextBoxColumn();
                //textDetail.Name = "txtDetailColumn";
                //textDetail.HeaderText = "Detail";
                //textDetail.FieldName = "Detail";
                //textDetail.Width = 60;
                //textDetail.TextAlignment = ContentAlignment.BottomRight;
                //grdChecklist.MasterTemplate.Columns.Add(textDetail);

                GridViewTextBoxColumn textRemarks = new GridViewTextBoxColumn();
                textRemarks.Name = "txtRemarksColumn";
                textRemarks.HeaderText = "Remarks";
                textRemarks.FieldName = "CheckListRemarks";
                textRemarks.Width = 60;
                textRemarks.TextAlignment = ContentAlignment.BottomRight;
                grdChecklist.MasterTemplate.Columns.Add(textRemarks);
                #endregion
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmCheckListFilling_Load.", ex, "frmNDC_CheckList_Binding_Updating");
                frmobj.ShowDialog();
            }
           
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //int rslt = 0;
            //int gridRowscount = grdChecklist.RowCount;
            //for(int i=0; i < gridRowscount; i++)
            //{
            //    object str = grdChecklist.Rows[i].Cells[5].Value == null ? clsPluginHelper.DbNullIfNullOrEmpty("") : grdChecklist.Rows[i].Cells[5].Value.ToString();
            //    SqlParameter[] prm =
            //    {
               
            //    new SqlParameter("@Task","Update"),
            //    //new SqlParameter("@NDC_ChecklistItemID",grdChecklist.Rows[i].Cells[0].Value.ToString()),
            //    new SqlParameter("@CheckListStatus",clsPluginHelper.DbNullIfNullOrEmpty(grdChecklist.Rows[i].Cells[3].Value.ToString())),
            //    new SqlParameter("@Detail",clsPluginHelper.DbNullIfNullOrEmpty(grdChecklist.Rows[i].Cells[4].Value.ToString())),
            //    new SqlParameter("@CheckListRemarks",str),
            //    //new SqlParameter("@NDCNo",NDC_Against_FileNo)
            //};
            //    rslt = cls_dl_NDCChecklist.NDCCheckListNonQuery(prm);
            //}
            //if (rslt > 0)
            //{
            //    MessageBox.Show("Successfull.");
            //}

        }

        private void Find_Click(object sender, EventArgs e)
        {

        }

        private void grdChecklist_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            try
            {
                int gridRowscount = grdChecklist.CurrentCell.RowIndex;
                string prclr = grdChecklist.Rows[gridRowscount].Cells["Particular"].Value.ToString();
                #region Commented Code
                //if (grdChecklist.Rows[gridRowscount].Cells["Particular"].Value.ToString() == "Advance Tax @ 1% or 2% if sold before 3 years by Seller" 
                //    | grdChecklist.Rows[gridRowscount].Cells["Particular"].Value.ToString() == "Advance Tax @ 2% or 4% by Purchaser" 
                //    && grdChecklist.Rows[gridRowscount].Cells["status"].Value.ToString() == "Yes"
                //    // && grdChecklist.Rows[gridRowscount].Cells["status"].Value.ToString() == "Yes"
                //                                                                                         )
                //{
                //    object cpr_no = grdChecklist.Rows[gridRowscount].Cells["Detail"].Value == null ? clsPluginHelper.DbNullIfNullOrEmpty("-") : grdChecklist.Rows[gridRowscount].Cells["Detail"].Value.ToString();
                //   // string cpr_no = grdChecklist.Rows[gridRowscount].Cells["txtDetailColumn"].Value.ToString();
                //    SqlParameter[] prmt =
                //    {
                //    new SqlParameter("@Task","Check_CPR_Duplicate"),
                //    new SqlParameter("@Detail",cpr_no)
                //};
                //    DataSet dst = new DataSet();
                //    dst = cls_dl_NDCChecklist.NDCCheckListReader(prmt);
                //    if (dst.Tables.Count > 0)
                //    {

                //        //if (dst.Tables[0].Rows[0]["Detail"].ToString() != "")
                //        if (dst.Tables[0].Rows.Count > 0)
                //        {
                //            RadMessageBox.Show("This CPR No is already exist, Please try another.");
                //        }
                //        else
                //        {
                //           object chcklst_remarks = grdChecklist.Rows[gridRowscount].Cells[6].Value == null ? clsPluginHelper.DbNullIfNullOrEmpty("") : grdChecklist.Rows[gridRowscount].Cells[6].Value.ToString();
                //           object detail_cpr =  grdChecklist.Rows[gridRowscount].Cells["Detail"].Value == null ? clsPluginHelper.DbNullIfNullOrEmpty("") : grdChecklist.Rows[gridRowscount].Cells["Detail"].Value.ToString();
                //           SqlParameter[] prm =
                //           {
                //            new SqlParameter("@Task","Update"),
                //            new SqlParameter("@NDCMapID",int.Parse(grdChecklist.Rows[gridRowscount].Cells["NDC_Map_ID"].Value.ToString())),
                //            new SqlParameter("@CheckListStatus",clsPluginHelper.DbNullIfNullOrEmpty(grdChecklist.Rows[gridRowscount].Cells["status"].Value.ToString())),
                //            new SqlParameter("@Detail",detail_cpr),//clsPluginHelper.DbNullIfNullOrEmpty(grdChecklist.Rows[gridRowscount].Cells["txtDetailColumn"].Value.ToString())),
                //            new SqlParameter("@CheckListRemarks",chcklst_remarks),
                //            //new SqlParameter("@NDCNo",NDC_Against_FileNo)
                //            };
                //            int rslt = cls_dl_NDCChecklist.NDCCheckListNonQuery(prm);
                //        }
                //    }
                //}
                //else
                //{
                #endregion
                object chcklst_remarks = grdChecklist.Rows[gridRowscount].Cells[6].Value == null ? clsPluginHelper.DbNullIfNullOrEmpty("") : grdChecklist.Rows[gridRowscount].Cells[6].Value.ToString();
                    object detail_cpr = grdChecklist.Rows[gridRowscount].Cells["Detail"].Value == null ? clsPluginHelper.DbNullIfNullOrEmpty("") : grdChecklist.Rows[gridRowscount].Cells["Detail"].Value.ToString();
                    SqlParameter[] prm =
                     {
                            new SqlParameter("@Task","Update"),
                            new SqlParameter("@NDCMapID",int.Parse(grdChecklist.Rows[gridRowscount].Cells["NDC_Map_ID"].Value.ToString())),
                            new SqlParameter("@CheckListStatus",clsPluginHelper.DbNullIfNullOrEmpty(grdChecklist.Rows[gridRowscount].Cells["status"].Value.ToString())),
                            new SqlParameter("@Detail",detail_cpr),//clsPluginHelper.DbNullIfNullOrEmpty(grdChecklist.Rows[gridRowscount].Cells["txtDetailColumn"].Value.ToString())),
                            new SqlParameter("@CheckListRemarks",chcklst_remarks),
                            //new SqlParameter("@NDCNo",NDC_Against_FileNo)
                            };
                    int rslt = cls_dl_NDCChecklist.NDCCheckListNonQuery(prm);
                //}

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on grdChecklist_CellEndEdit.", ex, "frmNDC_CheckList_Binding_Updating");
                frmobj.ShowDialog();
            }
      
        }
        
        private void txtNDCNo_Leave(object sender, EventArgs e)
        {
            CheckAndRetrieveCheckList();
        }
    }
}
