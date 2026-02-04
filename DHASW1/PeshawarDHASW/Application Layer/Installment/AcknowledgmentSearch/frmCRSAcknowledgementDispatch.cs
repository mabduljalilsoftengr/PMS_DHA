using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Installment.AcknowledgmentSearch
{
    public partial class frmCRSAcknowledgementDispatch : Telerik.WinControls.UI.RadForm
    {
        public frmCRSAcknowledgementDispatch()
        {
            InitializeComponent();
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
        }
        public void ApplyTheme(string themeName)
        {
            this.ThemeName = themeName; ThemeResolutionService.ApplyThemeToControlTree(this, themeName);
        }
        private void Clear()
        {
            txtAckNo.Text="";
            dateofdispatch.Value= DateTime.Now;
            txtCourierCom.SelectedIndex=-1;
            DispatchStatus.SelectedIndex=-1;
            txtRemarks.Text="";
            txtName.Text = "";
            txtMobileNo.Text = "";
            SMSGroup.Enabled = false;
            
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
        private void btnSaveRecord_Click(object sender, EventArgs e)
        {
            string SMSSendStatus = "Pending";
            try
            {
                SqlParameter[] paramSMS = {
                    new SqlParameter("@Task","DataofSMS"),
                    new SqlParameter("@FinAckID",txtAckNo.Text)
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_QSRDispatchInfo", paramSMS);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string Message = "Dear Customer,\n Your Ack ltr No : " +ds.Tables[0].Rows[0]["FinAckID"].ToString() + "\n has been dispatched"
                        +" on your given address. If you do not receive your letter within 7 days of this SMS. Please Contact (091-7259155 ext(128)) \n";
                    string MobileNo = ds.Tables[0].Rows[0]["Mobile"].ToString().Replace("-","");
                    
                    if (Regex.IsMatch(MobileNo, MakeCombinedPattern()))
                    {
                        
                        bool SMSStatus = Helper.clsPluginHelper.SMSSEnding(MobileNo, Message);
                        if (SMSStatus == true)
                        {
                            lblSMSStatus.Text = "SMS is Sended";
                            lblSMSStatus.ForeColor = Color.Green;
                            SMSSendStatus = "Sended";
                           
                        }
                        else
                        {
                            lblSMSStatus.Text = "SMS is Fail";
                            lblSMSStatus.ForeColor = Color.Red;
                            SMSSendStatus = "Pending";
                            txtRemarks.Text = txtRemarks.Text + "Invalid Mobile No.";
                        }
                        SqlParameter[] paramok = {
                                    new SqlParameter("@Task","NewRecordSaving"),
                                    new SqlParameter("@FinAckID",Helper.clsPluginHelper.DbNullIfNullOrEmpty( txtAckNo.Text)),
                                    new SqlParameter("@DateofDispatch",dateofdispatch.Value),
                                    new SqlParameter("@CourierCom",Helper.clsPluginHelper.DbNullIfNullOrEmpty( txtCourierCom.Text)),
                                    new SqlParameter("@Status",Helper.clsPluginHelper.DbNullIfNullOrEmpty( SMSSendStatus)),
                                    new SqlParameter("@Remark",Helper.clsPluginHelper.DbNullIfNullOrEmpty( txtRemarks.Text)),
                                    new SqlParameter("@userID",clsUser.ID),
                                    new SqlParameter("@Message",Helper.clsPluginHelper.DbNullIfNullOrEmpty( Message)),
                                    new SqlParameter("@MobileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty( txtMobileNo.Text))
                                      };
                        int resultok = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_QSRDispatchInfo", paramok);
                        Clear();
                    }
                    else
                    {
                        
                        MessageBox.Show("SMS Sending is Fail Kindly Check your Internet Connection. Or Invalid Mobile No", "Check Internet Connection", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                        SqlParameter[] param = {
                                    new SqlParameter("@Task","NewRecordSaving"),
                                    new SqlParameter("@FinAckID",Helper.clsPluginHelper.DbNullIfNullOrEmpty( txtAckNo.Text)),
                                    new SqlParameter("@DateofDispatch",dateofdispatch.Value),
                                    new SqlParameter("@CourierCom",Helper.clsPluginHelper.DbNullIfNullOrEmpty( txtCourierCom.Text)),
                                    new SqlParameter("@Status",Helper.clsPluginHelper.DbNullIfNullOrEmpty( SMSSendStatus)),
                                    new SqlParameter("@Remark",Helper.clsPluginHelper.DbNullIfNullOrEmpty( txtRemarks.Text)),
                                    new SqlParameter("@userID",clsUser.ID),
                                    new SqlParameter("@Message",Helper.clsPluginHelper.DbNullIfNullOrEmpty( Message)),
                                    new SqlParameter("@MobileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty( txtMobileNo.Text))
                                      };
                        int result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_QSRDispatchInfo", param);
                }


            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SqlParameter[] param = {
                new SqlParameter("@Task","Select"),
            };
            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_QSRDispatchInfo", param);
            QSRInfoGDV.DataSource = ds.Tables[0].DefaultView;
            foreach (GridViewDataColumn column in QSRInfoGDV.Columns)
            {
                column.BestFit();
            }
        }

        private void txtAckNo_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAckNo.Text))
            {
                try
                {
                    SqlParameter[] paramSMSSendedorNot = { new SqlParameter("@Task","CheckAlreadySMSSend"),
                    new SqlParameter("@FinAckID",txtAckNo.Text) };
                    int Cont = (int)Helper.SQLHelper.ExecuteScalar(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_QSRDispatchInfo", paramSMSSendedorNot);
                    if (Cont > 0)
                    {
                        MessageBox.Show("Message is Already Sended.");
                    }
                    else
                    {
                        SqlParameter[] paramSMS = {
                                                new SqlParameter("@Task","DataofSMS"),
                                                new SqlParameter("@FinAckID",txtAckNo.Text)
                                                  };
                        DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_QSRDispatchInfo", paramSMS);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            SMSGroup.Enabled = true;
                            txtMobileNo.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                            txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                        }
                        else
                        {
                            SMSGroup.Enabled = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    SMSGroup.Enabled = false;
                }
            }
        }

        private void frmCRSAcknowledgementDispatch_Load(object sender, EventArgs e)
        {
          
            SMSGroup.Enabled = false;
            btnRefresh_Click(null, null);
        }

        private void radButton1_Click(object sender, EventArgs e)
        {

        }

        private void txtAckNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtAckNo_Leave(null, null);
            }
        }
    }
}
