using PeshawarDHASW.Models;
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

namespace PeshawarDHASW.Application_Layer.CRSection
{
    public partial class frmLetterDispatch : Telerik.WinControls.UI.RadForm
    {
        public frmLetterDispatch()
        {
            InitializeComponent();
            lblRegno.Text = "0";
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
        }
       
        public frmLetterDispatch(string RegNo)
        {
            InitializeComponent();
            lblRegno.Text = RegNo;
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            btnReset.Enabled = false;
        }
        public void ApplyTheme(string themeName)
        {
            this.ThemeName = themeName; ThemeResolutionService.ApplyThemeToControlTree(this, themeName);
        }
        private void ClearForm()
        {
            ToCustomer.Text = "";
            Subject.Text = "";
            AddressReceiver.Text = "";
            dpCourierComp.SelectedIndex = 0;
            txtRemarks.Text = "";
            dpLetterType.SelectedIndex = 0;
            dpBranch.SelectedIndex = 0;
            dpLetterType.SelectedIndex = 0;
            txtmobileno.Text = "";

        }


        private void btnLetterRecordSaving_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] param = {
                     new SqlParameter("@Task","SaveChanges"),
                     new SqlParameter("@ToCustomer",Helper.clsPluginHelper.DbNullIfNullOrEmpty(ToCustomer.Text)),
                     new SqlParameter("@Subject",Helper.clsPluginHelper.DbNullIfNullOrEmpty(Subject.Text)),
                     new SqlParameter("@Address",Helper.clsPluginHelper.DbNullIfNullOrEmpty(AddressReceiver.Text)),
                     new SqlParameter("@DateofDispatch",dtpDispatchDate.Value),
                     new SqlParameter("@CourierComp",Helper.clsPluginHelper.DbNullIfNullOrEmpty(dpCourierComp.Text)),
                     new SqlParameter("@Remarks",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtRemarks.Text)),
                     new SqlParameter("@LStatus",Helper.clsPluginHelper.DbNullIfNullOrEmpty(CourierStatus.Text)),
                     new SqlParameter("@BranchCode",Helper.clsPluginHelper.DbNullIfNullOrEmpty(dpBranch.Text)),
                     new SqlParameter("@LetterType",Helper.clsPluginHelper.DbNullIfNullOrEmpty(dpLetterType.Text)),
                     new SqlParameter("@MobileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtmobileno.Text)),
                     new SqlParameter("@RegNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(lblRegno.Text)),
                     new SqlParameter("@userID",clsUser.ID)
            };

                int result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_CRS_Letter", param);
                if (lblRegno.Text=="0")
                {
                    ClearForm();
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
        }


        private static string[] m_Patterns = new string[] {
                                                            @"^[0-9]{11}$",
                                                            @"^0092[0-9]{10}$",
                                                            @"^\+92[0-9]{10}$"
                                                            };
        private static string MakeCombinedPattern()
        {
            return string.Join("|", m_Patterns
              .Select(item => "(" + item + ")"));
        }

        private void frmLetterDispatch_Load(object sender, EventArgs e)
        {
            SqlParameter[] param = {
                     new SqlParameter("@Task","SelectbyRegNo"),
                     new SqlParameter("@RegNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(lblRegno.Text))
            };
            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_CRS_Letter", param);
            if (ds.Tables.Count>0)
            {
                if (ds.Tables[0].Rows.Count>0)
                {
                    ToCustomer.Text = ds.Tables[0].Rows[0]["ToCustomer"].ToString();
                    Subject.Text = ds.Tables[0].Rows[0]["Subject"].ToString();
                    AddressReceiver.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    dtpDispatchDate.Value = DateTime.Parse(ds.Tables[0].Rows[0]["DateofDispatch"].ToString());
                    dpCourierComp.Text = ds.Tables[0].Rows[0]["CourierComp"].ToString();
                    txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                    dpLetterType.Text = ds.Tables[0].Rows[0]["LetterType"].ToString();
                    dpBranch.Text = ds.Tables[0].Rows[0]["BranchCode"].ToString();
                   
                    txtmobileno.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                    CourierStatus.Text = ds.Tables[0].Rows[0]["LStatus"].ToString();
                }   
            }
        }

        private void dpLetterType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (dpLetterType.SelectedItem.Text != "Documents" | dpLetterType.SelectedItem.Text!="Others")
            {
                txtFileNo.Enabled = false;
            }
            else
            {
                txtFileNo.Enabled = true;
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            SqlParameter[] param = {
                new SqlParameter("@Task","FileInfoforLetter"),
                new SqlParameter("@FileNo",txtFileNo.Text)
            };
            DataSet ds = Data_Layer.clsFileMap.cls_dl_FileMap.FileMap_Reader(param);
            if (ds.Tables.Count>0)
            {
                ToCustomer.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                txtmobileno.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                AddressReceiver.Text = ds.Tables[0].Rows[0]["PresentAddress"].ToString();
            }
            else
            {
                MessageBox.Show("File No is not found.");
            }
            
        }
    }
}
