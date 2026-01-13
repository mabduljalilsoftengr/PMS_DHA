using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.clsTFR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Transfer
{
    public partial class frmTFRAppointmentVerification : Telerik.WinControls.UI.RadForm
    {
        public string FileNO { get; set; }
        public int ChallanNo { get; set; }
        public int NDC { get; set; }
        public int diffDays { get; set; }
        public frmTFRAppointmentVerification(string get_FileNO,int get_ChallanNO,int get_NDC)
        {
            FileNO = get_FileNO;
            ChallanNo = get_ChallanNO;
            NDC = get_NDC;
            InitializeComponent();
        }
        public frmTFRAppointmentVerification()
        {
            InitializeComponent();
        }

        private void btnTFRApp_Click(object sender, EventArgs e)
        {
            try
            {
                int appointmentNo = 0;
                bool appNO = int.TryParse(txtTFRAppointment.Text, out appointmentNo);
                if (appNO)
                {
                    int TFRappNo = int.Parse(txtTFRAppointment.Text);
                    this.Hide();
                    frmSelectTransferType obj = new frmSelectTransferType(FileNO, ChallanNo, NDC, TFRappNo);
                    obj.ShowDialog();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnTFRApp_Click.", ex, "frmTFRAppointmentVerification");
                frmobj.ShowDialog();
            }
          
        }

        private void frmTFRAppointmentVerification_Load(object sender, EventArgs e)
        {
            btnTFRApp.Visible = false;
        }

        private void txtTFRAppointment_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtTFRAppointment.Text != "")
                {
                    int appNo = int.Parse(txtTFRAppointment.Text);
                    SqlParameter[] param =
                    {
                new SqlParameter("@Task","Select"),
                new SqlParameter("@TFRAppoimtmentID",appNo)
            };
                    DataSet ds = new DataSet();
                    ds = cls_dl_TFRAppointment.TFRReader(param);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        diffDays = int.Parse(row["Days"].ToString());
                        lblFileNo.Text = FileNO;
                        lblChallanNo.Text = ChallanNo.ToString();
                        lblNDC.Text = NDC.ToString();
                    }
                    //diffDays = int.Parse(ds.Tables[0].Rows[0]["Days"].ToString());
                    if (diffDays <= 0)
                    {
                        MessageBox.Show("Transfer Appointment is Expire, Please get New Transfer Apointment.");
                    }
                    else
                    {
                        lblFileNo.Visible = true;
                        lblChallanNo.Visible = true;
                        lblNDC.Visible = true;
                        btnTFRApp.Visible = true;

                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Appointment Number.");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on txtTFRAppointment_Leave.", ex, "frmTFRAppointmentVerification");
                frmobj.ShowDialog();
            }
          
        }
    }
}
