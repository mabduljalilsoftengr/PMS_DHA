using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsErrorLog;
using PeshawarDHASW.Data_Layer.clsTFR;
using Telerik.WinControls;
using System.Globalization;
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Application_Layer.Transfer.TFRAppointment
{
    public partial class frmAppointmentCreate : Telerik.WinControls.UI.RadForm
    {
        public frmAppointmentCreate()
        {
            InitializeComponent();
        }

        private string filekey { get; set; }
        private  string NDCNO { get; set; }
        private void btnNDCVerification_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@Task","NDCVerification"),
                new SqlParameter("@FileNo",clsPluginHelper.DbNullIfNullOrEmpty(txtfileno.Text)),
                new SqlParameter("@PlotNo",clsPluginHelper.DbNullIfNullOrEmpty(txtPlotNo.Text)),
                new SqlParameter("@NDCNo",clsPluginHelper.DbNullIfNullOrEmpty(txtNDC.Text)),
                };

                DataSet NDCVerificationds = cls_dl_TFRAppointment.NDCVerfication(parameters);
                if (NDCVerificationds.Tables[0].Rows.Count > 0)
                {
                    int NDCDays = int.Parse(NDCVerificationds.Tables[0].Rows[0]["Days"].ToString());
                    NDCNO = NDCVerificationds.Tables[0].Rows[0]["NDCNo"].ToString();
                    filekey = NDCVerificationds.Tables[0].Rows[0]["FileMapKey"].ToString();
                    lblremainDays.Text = NDCDays.ToString();
                    if (NDCDays > 0)
                    {
                        lblappointmentExist.ForeColor = Color.Green;
                        lblappointmentExist.Text = "NDC is Not Expiry ";

                        SqlParameter[] parametersNDCAndAppointment =
                        {
                            new SqlParameter("@Task", "NDCVerificationAndAppointment"),
                            new SqlParameter("@FileNo", clsPluginHelper.DbNullIfNullOrEmpty(txtfileno.Text)),
                            new SqlParameter("@PlotNo", clsPluginHelper.DbNullIfNullOrEmpty(txtPlotNo.Text)),
                            new SqlParameter("@NDCNo", clsPluginHelper.DbNullIfNullOrEmpty(txtNDC.Text)),
                        };
                        DataSet NDCAppointmentAndVerfication =cls_dl_TFRAppointment.NDCVerfication(parametersNDCAndAppointment);
                        if (NDCAppointmentAndVerfication.Tables[0].Rows.Count > 0)
                        {
                            int AppointmentDays =  int.Parse(NDCAppointmentAndVerfication.Tables[0].Rows[0]["AppointmentDays"].ToString());
                            if (AppointmentDays > 0)
                            {
                                lblappointmentExist.ForeColor = Color.Green;
                                lblappointmentExist.Text = "NDC is Not Expire And One Appointment is Exist. ";
                                AppointmentGB.Enabled = false;
                            }

                        }
                        else
                        {
                            lblappointmentExist.ForeColor = Color.Orange;
                            lblappointmentExist.Text = "NDC is Not Expiry Can Give New Appointment.";
                            AppointmentGB.Enabled = true;
                        }

                    }
                    else
                    {
                        lblappointmentExist.ForeColor = Color.Red;
                        lblappointmentExist.Text = "NDC is Expiry Go for Renew NDC";
                        AppointmentGB.Enabled = false;
                    }
                }
                else
                {
                    lblappointmentExist.ForeColor = Color.Red;
                    lblappointmentExist.Text = "No NDC is Issue for this file. Kindly Apply for NDC!";
                    AppointmentGB.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnNDCVerification_Click.", ex, "frmAppointmentCreate");
                frmobj.ShowDialog();

            }

        }

        private void frmAppointmentCreate_Load(object sender, EventArgs e)
        {
            dateofissue.Text = DateTime.Now.ToString();
            dateofexpire.Text = DateTime.Now.AddMonths(1).ToString();
        }

        private void clearfunction()
        {
            lblappointmentExist.Text = "";
            lblremainDays.Text = "";
            txtfileno.Text = "";
            txtNDC.Text = "";
            txtPlotNo.Text = "";
        }

        private void btnCreateAppointment_Click(object sender, EventArgs e)
        {
            try {

                SqlCommand cmd = new SqlCommand("App.usp_tbl_TFRAppointment");
                cmd.Parameters.AddWithValue("@Task", "Insert");
                cmd.Parameters.Add("@IssueDate", SqlDbType.DateTime).SqlValue = DateTime.ParseExact(dateofissue.Text, "dd/MM/yyyy", null);
                cmd.Parameters.Add("@ExpireDate", SqlDbType.DateTime).SqlValue = DateTime.ParseExact(dateofexpire.Text, "dd/MM/yyyy", null);
                cmd.Parameters.AddWithValue("@NDCNo", NDCNO);
                cmd.Parameters.AddWithValue("@FileMapKey", filekey);
                cmd.Parameters.AddWithValue("@Status", "Active");
                int result = cls_dl_TFRAppointment.Appointment_NonQuery(cmd);
                if (result > 0)
                {
                    clearfunction();
                }
            }
            catch (Exception ex)
            {

                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnCreateAppointment_Click.", ex, "frmAppointmentCreate");
                frmobj.ShowDialog();
            }

        }
    }
}
