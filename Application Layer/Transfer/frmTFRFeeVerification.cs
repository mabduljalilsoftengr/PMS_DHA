using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.Installment;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Transfer
{
    public partial class frmTFRFeeVerification : Telerik.WinControls.UI.RadForm
    {
        public frmTFRFeeVerification()
        {
            InitializeComponent();
        }

        private int passNDC = 0;
        private string passFileNo = "";
        public frmTFRFeeVerification(int ndc,string passfileno)
        {
            passNDC = ndc;
            passFileNo = passfileno;
            InitializeComponent();
        }

        //challan No textBox
        private void radTextBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void radTextBox1_Leave(object sender, EventArgs e)
        {
            try
            {
            
            SqlParameter[] parameters =
             {
                   new SqlParameter("@Task", "ChallanExpire"),
                   new SqlParameter("@ChallanNo",txttfrfeeverification.Text),
             };

                DataSet ds = cls_dl_InstRece.MembershipVerification(parameters);
                if (ds.Tables[0].Rows[0]["Name"].ToString() == "Challan is Expire")
                {
                    btnprocessnext.Visible = false;
                }
                else
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            lblname.Text = row["Name"].ToString() + "  MS No : " + row["MembershipNo"].ToString();
                            lblnic.Text = row["NIC/NICOP"].ToString();
                            lblfileno.Text = row["FileNo"].ToString();
                            lblplotno.Text = row["PlotNo"].ToString();
                            lbldateofreceive.Text = row["DateofRece"].ToString();
                            lbldateofexpire.Text = row["DateofExpire"].ToString();
                            lblamount.Text = row["Amount"].ToString();
                        }
                    btnprocessnext.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnprocessnext_Click(object sender, EventArgs e)
        {
            int challnNO = 0;
            bool parsed = int.TryParse(txttfrfeeverification.Text, out challnNO);
            if (parsed)
            {
                this.Hide();
                frmTFRAppointmentVerification obj = new frmTFRAppointmentVerification(passFileNo, challnNO, passNDC);
                //frmTFRAppointmentVerification obj = new frmTFRAppointmentVerification(passFileNo, challnNO, passNDC);
                obj.ShowDialog();
                this.Close();
            }
        }

        private void frmTFRFeeVerification_Load(object sender, EventArgs e)
        {
            btnprocessnext.Visible = false;
        }
    }
}
