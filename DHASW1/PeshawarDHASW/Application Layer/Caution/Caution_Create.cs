using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.clsCaution;
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

namespace PeshawarDHASW.Application_Layer.Caution
{
    public partial class Caution_Create : Telerik.WinControls.UI.RadForm
    {
        public int FileKey { get; set; }
        public int CautionID { get; set; } = 0;
        private DataSet dst { get; set; }
        public Caution_Create()
        {
            InitializeComponent();
        }

        public Caution_Create(int catnID)
        {
            InitializeComponent();
            CautionID = catnID;
        }
        private void Caution_Create_Load(object sender, EventArgs e)
        {
            lblctnrmrks.Text = "Caution / "+Environment.NewLine+
                               "Remarks for Need" + Environment.NewLine +
                               "To Discuss.";
            lblctnlvl.Text =   "Caution Level / "+Environment.NewLine+
                               "Need To Discuss.";
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            
            if(CautionID > 0)
            {
                btnAddRemarks.Text = "Remove Caution";
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","Select_Caution"),
                new SqlParameter("@CautionID",CautionID)
                };
                dst = cls_dl_Caution.Caution_Reader(prm);
                if(dst.Tables.Count > 0)
                {
                    if(dst.Tables[0].Rows.Count > 0)
                    {
                        txtFilePlotNo.Text = dst.Tables[0].Rows[0]["FileNo"].ToString();
                        txtFilePlotNo.Enabled = false;
                        txtCaution.Text = dst.Tables[0].Rows[0]["Cauction"].ToString(); 
                        txtCautonRemarks.Text = dst.Tables[0].Rows[0]["CauctionRemarks"].ToString();
                        drpCurrentOwner.Text = dst.Tables[0].Rows[0]["Name"].ToString();
                        drpCurrentOwner.Enabled = false;
                        drpCautionLevel.Text = dst.Tables[0].Rows[0]["Caution_Level"].ToString();
                        drpCautionLevel.Enabled = false;

                    }
                }

            }
            else
            {
                LoadCautionLevel();
            }
        }
        private void LoadCautionLevel()
        {
            try
            {
                RadListDataItem Select = new RadListDataItem();
                Select.Value = 0;
                Select.Text = "-- Select --";
                this.drpCautionLevel.Items.Add(Select);
                SqlParameter[] param =
                {
               new SqlParameter("@Task", "Select_CautionLevel")
                };

                foreach (DataRow row in cls_dl_Caution.Caution_Reader(param).Tables[0].Rows)
                {
                    RadListDataItem dataItem = new RadListDataItem();
                    dataItem.Value = row["CautionLevel_ID"].ToString();
                    dataItem.Text = row["Caution_Level"].ToString();
                    this.drpCautionLevel.Items.Add(dataItem);
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LoadCautionLevel.", ex, "Caution_Create");
                frmobj.ShowDialog();

            }


        }

        private void txtFilePlotNo_Leave(object sender, EventArgs e)
        {
            LoadCurrentMembers();
        }
        private void LoadCurrentMembers()
        {
            try
            {
                drpCurrentOwner.Items.Clear();
                RadListDataItem Select = new RadListDataItem();
                Select.Value = 0;
                Select.Text = "-- Select --";
                this.drpCurrentOwner.Items.Add(Select);
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","Select_Current_Owner_against_FileNo"),
                new SqlParameter("@FileNo",txtFilePlotNo.Text)
            };
                DataSet dst = new DataSet();
                dst = cls_dl_Caution.Caution_Reader(prm);
                if (dst.Tables[0].Rows.Count > 0)
                {
                    FileKey = int.Parse(dst.Tables[0].Rows[0]["FileMapKey"].ToString());
                }
                foreach (DataRow row in dst.Tables[0].Rows)
                {
                    RadListDataItem dataItem = new RadListDataItem();
                    dataItem.Value = row["ID"].ToString();
                    dataItem.Text = row["MembershipNo"].ToString();
                    this.drpCurrentOwner.Items.Add(dataItem);
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LoadCurrentMembers.", ex, "Caution_Create");
                frmobj.ShowDialog();

            }

        }

        private void btnAddRemarks_Click(object sender, EventArgs e)
        {
            try
            {
                if(CautionID == 0)
                {
                    #region Addition New Caution
                    if (!string.IsNullOrEmpty(txtFilePlotNo.Text) && drpCurrentOwner.SelectedIndex > 0)
                    {
                        SqlParameter[] prm =
                        {
                            new SqlParameter("@Task","CheckAppliedCaution"),
                            new SqlParameter("@FileNo",txtFilePlotNo.Text)
                        };
                        DataSet dst = cls_dl_Caution.Caution_Reader(prm);
                        if(dst.Tables.Count > 0)
                        {
                            if(dst.Tables[0].Rows.Count > 0)
                            {
                                if(dst.Tables[0].Rows[0]["Remarks"].ToString() == "This File is already Cautioned.")
                                {
                                    MessageBox.Show(dst.Tables[0].Rows[0]["Remarks"].ToString());
                                }
                                else if(dst.Tables[0].Rows[0]["Remarks"].ToString() == "This File need to be Cautioned.")
                                {
                                    #region Code 
                                    SqlParameter[] prmtr =
                                    {
                                      new SqlParameter("@Task","Insert"),
                                      new SqlParameter("@Cauction",txtCaution.Text),
                                      new SqlParameter("@Caution_Level_ID",drpCautionLevel.SelectedValue),
                                      new SqlParameter("@FileKey",FileKey),
                                      new SqlParameter("@MemberID",drpCurrentOwner.SelectedValue),
                                      new SqlParameter("@CauctionRemarks",txtCautonRemarks.Text),
                                      //new SqlParameter("@CauctionDate",DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"))),
                                      new SqlParameter("@userID_Caution_Craete",Models.clsUser.ID),
                                      new SqlParameter("@CauctionStatus","Active")
                                    };
                                    int rslt = cls_dl_Caution.Caution_NonQuery(prmtr);
                                    if (rslt > 0)
                                    {
                                        MessageBox.Show("Insertion is Successfull.");
                                        txtFilePlotNo.Text = null;
                                        txtCaution.Text = null;
                                        txtCautonRemarks.Text = null;
                                        drpCurrentOwner.Items.Clear();
                                        // drpCurrentOwner.DataSource = null;
                                        //drpCautionLevel.DataSource = null;
                                        //this.Close();
                                    }
                                    #endregion
                                }
                            }
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("File Number and Current Owner both are Required");
                    }
                    #endregion
                }
                else
                {
                    #region Update Current Caution
                    SqlParameter[] prmtr =
                    {
                     new SqlParameter("@Task","Remove_Caution"),
                     new SqlParameter("@Cauction",txtCaution.Text),
                     new SqlParameter("@CauctionRemarks",txtCautonRemarks.Text),
                     new SqlParameter("@userID_Caution_Craete",Models.clsUser.ID),
                     new SqlParameter("@CauctionStatus","Remove"),
                     new SqlParameter("@CautionID",CautionID)
                    };
                    int rslt = cls_dl_Caution.Caution_NonQuery(prmtr);
                    if(rslt > 0)
                    {
                        CautionLog();
                        MessageBox.Show("Successfull.");
                        this.Close();
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnAddRemarks_Click.", ex, "Caution_Create");
                frmobj.ShowDialog();
            }
           
        }
        private void CautionLog()
        {
            try
            {

                string OldData =
                "CautionID=" + dst.Tables[0].Rows[0]["CautionID"].ToString() + " , " +
                "Cauction=" + dst.Tables[0].Rows[0]["Cauction"].ToString() + " , " +
                "CauctionStatus=" + dst.Tables[0].Rows[0]["CauctionStatus"].ToString() + " , " +
                "Caution_Level_ID=" + dst.Tables[0].Rows[0]["Caution_Level_ID"].ToString() + " , " +
                "Caution_Level=" + dst.Tables[0].Rows[0]["Caution_Level"].ToString() + " , " +
                "FileNo=" + dst.Tables[0].Rows[0]["FileNo"].ToString() + " , " +
                "MemberID=" + dst.Tables[0].Rows[0]["MemberID"].ToString();
                string newData =
                    "Cauction=" + txtCaution.Text + " , " +
                    "CauctionRemarks=" + txtCautonRemarks.Text + " , " +
                    "userID_Caution_Craete=" + Models.clsUser.ID + " , " +
                    "CauctionStatus=" + "Remove" + " , " +
                    "CautionID=" + CautionID;

                SqlParameter[] prmtr =
                {
                new SqlParameter("@Task","CautionLog"),
                new SqlParameter("@Data","Old Data * " + OldData +"  ###  " + Environment.NewLine + "New Data * " + newData )
                };
                int rslt = cls_dl_Caution.Caution_NonQuery(prmtr);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
