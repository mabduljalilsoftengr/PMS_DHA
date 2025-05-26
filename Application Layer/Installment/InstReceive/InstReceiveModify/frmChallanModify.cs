using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsChallanRece;
using PeshawarDHASW.Data_Layer.clsChallanType;
using PeshawarDHASW.Data_Layer.clsErrorLog;
using PeshawarDHASW.Data_Layer.Installment;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Models;
using Telerik.WinControls;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.Installment.InstReceive.InstReceiveModify
{
    public partial class frmChallanModify : Telerik.WinControls.UI.RadForm
    {
        public frmChallanModify()
        {
            InitializeComponent();
        }

        public int CRID { get; set; }
        public frmChallanModify(int crid)
        {
            CRID = crid;
            
            InitializeComponent();
        }

        private void searchingChallandataforupdate(int ReceIDValue)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task", "ChallanVerfication"),
                   new SqlParameter("@ChallanID",ReceIDValue.ToString()),
                };

                DataSet ds = cls_dl_InstRece.MembershipVerification(parameters);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    lblfileno.Text = row["FileNo"].ToString();
                    lblplotno.Text = row["PlotNo"].ToString();
                    lblmsno.Text = row["MembershipNo"].ToString();
                    lblcontact.Text = row["MobileNo"].ToString();
                    lblname.Text = row["Name"].ToString();
                    lblNIC.Text = row["NIC/NICOP"].ToString();
                    lblRecordNo.Text = row["RecordNo"].ToString();
                    lblpassport.Text = row["PassportNo"].ToString();
                    lblfilekey.Text = row["FileMapKey"].ToString();
                    lblmsid.Text = row["ID"].ToString();
                    //int indexvalue = 0;
                   // bool M = int.TryParse(row["ChallanID"].ToString(), out indexvalue);
                    clsPluginHelper.RadDropDownSelectByText(typeofChallan,
                        row["ChallanType"].ToString());
                    if (!string.IsNullOrEmpty(row["DateofRece"].ToString()))
                        txtchallandate.Value = clsPluginHelper.GetDateTime(row["DateofRece"].ToString());

                    //txtchallandate.Text = DateTime.Parse(row["DateofRece"].ToString()).ToString();
                    txtchallanNo.Text = row["ChallanNo"].ToString();
                    txtchallanamount.Text = row["Amount"].ToString();
                    dpchallanbank.Text = row["Bank"].ToString();
                    txtchallanbranch.Text = row["Branch"].ToString();
                    txtchallanreferenceno.Text = row["RefNo"].ToString();
                    dpchallanstatus.Text = row["Status"].ToString();
                    // txtddstatus.Text = row["DDStatus"].ToString();
                    txtchallanremarks.Text = row["Remarks"].ToString();
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on searchingChallandataforupdate.", ex, "frmChallanModify");
                frmobj.ShowDialog();

            }
        }

        private void frmChallanModify_Load(object sender, EventArgs e)
        {
            try
            {
                this.ThemeName = clsUser.ThemeName;
                ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
                SqlParameter[] parameters =
                {
                new SqlParameter("@Task","Select"),
                new SqlParameter("@Status","Active"),
            };
                typeofChallan.DataSource = cls_dl_ChallanType.Challan_Reader(parameters, "App.USP_tbl_ChallanType").Tables[0].DefaultView;
                typeofChallan.ValueMember = "ChallanID";
                typeofChallan.DisplayMember = "ChallanType";
                searchingChallandataforupdate(CRID);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmChallanModify_Load.", ex, "frmChallanModify");
                frmobj.ShowDialog();
            }
            
        }

        private void UpdateChallanRece(int cchallanID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("App.USP_tbl_ChallanRece");
                cmd.Parameters.AddWithValue("@Task", "Update");
                //Validition Task Remaining
                cmd.Parameters.AddWithValue("@DateofRece", Helper.clsPluginHelper.GetDateTime(txtchallandate.Value.ToString()));
                int type = 0;
                bool a = int.TryParse(typeofChallan.SelectedValue.ToString(), out type);
                cmd.Parameters.AddWithValue("@CRID", cchallanID);
                cmd.Parameters.AddWithValue("@ChallanID", type);
                cmd.Parameters.AddWithValue("@Amount", txtchallanamount.Text);
                cmd.Parameters.AddWithValue("@ChallanNo", txtchallanNo.Text);
                cmd.Parameters.AddWithValue("@Bank", clsPluginHelper.DbNullIfNullOrEmpty(dpchallanbank.Text));
                cmd.Parameters.AddWithValue("@Branch", txtchallanbranch.Text);
                cmd.Parameters.AddWithValue("@RefNo", txtchallanreferenceno.Text);
                cmd.Parameters.AddWithValue("@Status", dpchallanstatus.Text);
                cmd.Parameters.AddWithValue("@Remarks", txtchallanremarks.Text);
                cmd.Parameters.AddWithValue("@MemberID", lblmsid.Text);
                cmd.Parameters.AddWithValue("@FileMapKey", lblfilekey.Text);
                cmd.Parameters.AddWithValue("@userId", Models.clsUser.ID);
                int result = cls_dl_ChallanRece.ChallanRece_NonQuery(cmd);
                if (result > 0)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Contact to Administrator");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on UpdateChallanRece.", ex, "frmChallanModify");
                frmobj.ShowDialog();
            }
        }
        private void btnchallanSave_Click(object sender, EventArgs e)
        {
            UpdateChallanRece(CRID);
        }
    }
}
