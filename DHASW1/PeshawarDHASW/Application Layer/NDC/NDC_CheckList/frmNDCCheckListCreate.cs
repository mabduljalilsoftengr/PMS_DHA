using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.NDC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.NDC.NDC_CheckList
{
    public partial class frmNDCCheckListCreate : Telerik.WinControls.UI.RadForm
    {
        public string CheckListID { get; set; } = "";
        public frmNDCCheckListCreate()
        {
            InitializeComponent();
        }
        public frmNDCCheckListCreate(string get_CheckListID)
        {
            CheckListID = get_CheckListID;
            InitializeComponent();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            ChecklistAdd_OR_Update();
        }
        private void ChecklistAdd_OR_Update()
        {
            try
            {
                if (CheckListID == "" | CheckListID == null)
                {
                    #region Insertion
                    SqlParameter[] prmt =
                    {
                new SqlParameter("@Task","Insert_CheckList"),
                new SqlParameter("@Category",txtCategory.Text),
                new SqlParameter("@Particular",rtbParticular.Text),
                new SqlParameter("@Remarks_CheckList",txtRemarks.Text),
                new SqlParameter("@Status_Checklist",ddlStatus.Text)
                };
                    int rsl = 0;
                    rsl = cls_dl_NDC.NdcNonQuery(prmt);
                    if (rsl > 0)
                    {
                        MessageBox.Show("Insertion is sucessfull.");
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Error!!!!!!!");
                    }
                    #endregion
                }
                else
                {
                    #region Updation
                    SqlParameter[] prmt =
                     {
                new SqlParameter("@Task","Update_CheckList"),
                new SqlParameter("@NDC_ItemID",CheckListID),
                new SqlParameter("@Category",txtCategory.Text),
                new SqlParameter("@Particular",rtbParticular.Text),
                new SqlParameter("@Remarks_CheckList",txtRemarks.Text),
                new SqlParameter("@Status_Checklist",ddlStatus.Text)
                 };
                    int rsl = 0;
                    rsl = cls_dl_NDC.NdcNonQuery(prmt);
                    if (rsl > 0)
                    {
                        MessageBox.Show("Updation is sucessfull.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error!!!!!!!");
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on ChecklistAdd_OR_Update.", ex, "frmNDCChecklistCreate");
                frmobj.ShowDialog();
            }
           

        }
        private void Clear()
        {
            txtCategory.Text = "";
            rtbParticular.Text = "";
            txtRemarks.Text = "";
            ddlStatus.Text = "";
        }
        private void frmNDCCheckListCreate_Load(object sender, EventArgs e)
        {
            try
            {
                if (CheckListID != "")
                {
                    #region Retrieve Data
                    SqlParameter[] prmt =
                    {
                     new SqlParameter("@Task","Select_CheckList"),
                     new SqlParameter("@NDC_ItemID",Convert.ToInt16(CheckListID)),
                    };
                    DataSet ds = new DataSet();
                    ds = cls_dl_NDC.NdcRetrival(prmt);
                    txtCategory.Text = ds.Tables[0].Rows[0]["Category"].ToString();
                    rtbParticular.Text = ds.Tables[0].Rows[0]["Particular"].ToString();
                    txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                    ddlStatus.SelectedText = ds.Tables[0].Rows[0]["Status"].ToString();
                    #endregion

                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmNDCCheckListCreate_Load.", ex, "frmNDCChecklistCreate");
                frmobj.ShowDialog();
            }
            
        }
    }
    } 
