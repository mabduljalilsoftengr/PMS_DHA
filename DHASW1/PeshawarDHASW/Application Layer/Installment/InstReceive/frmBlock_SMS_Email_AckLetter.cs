using PeshawarDHASW.Data_Layer.clsAcknowledgment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Installment.InstReceive
{
    public partial class frmBlock_SMS_Email_AckLetter : Telerik.WinControls.UI.RadForm
    {
        private int TrxNo { get; set; }
        public frmBlock_SMS_Email_AckLetter()
        {
            InitializeComponent();
        }
        public frmBlock_SMS_Email_AckLetter( int trxno)
        {
            InitializeComponent();
            TrxNo = trxno;
            GetAckDetaail(TrxNo);
        }
        private void GetAckDetaail(int Trx_No)
        {
            try
            {
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","GetAckDetail"),
                new SqlParameter("@ReceID",Trx_No)
                };
                DataSet dst = cls_Fin_Acknowledgement.Fin_AcknowledgementDataRead(prm);
                lblackstatus.Text = dst.Tables[0].Rows[0]["StatusAck"].ToString();
                lblsmsstatus.Text = dst.Tables[0].Rows[0]["SmsStatus"].ToString();
                lblemailstatus.Text = dst.Tables[0].Rows[0]["EmailStatus"].ToString();
                lblDDStatus.Text = dst.Tables[0].Rows[0]["DDStatus"].ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void frmBlock_SMS_Email_AckLetter_Load(object sender, EventArgs e)
        {
            //--Email = Delivered  SMS = Delivered  StatusAck = Printed
            //-- Then No Work Needed
            // ----------------------------------------------------------
            // --Email = Pending  SMS = Pending  StatusAck = Not Printed
            //-- Then
            //-- Email / SMS = Cancel
            //-- StatusAck = Cancel
            EnabledButtonStatus();
        }
        private void EnabledButtonStatus()
        {
            if (lblackstatus.Text == "Printed" || lblackstatus.Text == "Cancel")
            {
                btnblcokack.Enabled = false;
            }
            else
            {
                btnblcokack.Enabled = true;
            }

            if (lblsmsstatus.Text == "Delivered" || lblsmsstatus.Text == "Cancel")
            {
                btnblocksms.Enabled = false;
            }
            else
            {
                btnblocksms.Enabled = true;
            }
            if (lblemailstatus.Text == "Delivered" || lblemailstatus.Text == "Cancel")
            {
                btnEmailBlock.Enabled = false;
            }
            else
            {
                btnEmailBlock.Enabled = true;
            }
            if (lblDDStatus.Text == "Received")
            {
                btnModifyDDStatus.Enabled = false;
            }
            else
            {
                btnModifyDDStatus.Enabled = true;
            }
        }
        private void btnblcok_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you Sure ?","Confirm !",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    //    if (lblackstatus.Text != "Printed" && lblsmsstatus.Text != "Delivered" && lblemailstatus.Text != "Delivered")
                    //    {
                    SqlParameter[] prm =
                    {
                        new SqlParameter("@Task","BlockAckLetter"),
                        new SqlParameter("@ReceID",TrxNo)
                        };
                    int rslt = cls_Fin_Acknowledgement.Fin_Acknowledgment_NonQuery(prm);
                    if (rslt > 0)
                    {
                        MessageBox.Show("Bloked Successfuly.");
                        GetAckDetaail(TrxNo);
                        EnabledButtonStatus();
                    }
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Not Possible, Because Everything is Delivered.");
                    //    }
                }
                
           }
           catch (Exception ex)
           {

               MessageBox.Show(ex.Message);
           }

}

        private void btnblocksms_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you Sure ?", "Confirm !", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    //    if (lblackstatus.Text != "Printed" && lblsmsstatus.Text != "Delivered" && lblemailstatus.Text != "Delivered")
                    //    {
                    SqlParameter[] prm =
                    {
                        new SqlParameter("@Task","BlockSMS"),
                        new SqlParameter("@ReceID",TrxNo)
                        };
                    int rslt = cls_Fin_Acknowledgement.Fin_Acknowledgment_NonQuery(prm);
                    if (rslt > 0)
                    {
                        MessageBox.Show("Bloked Successfuly.");
                        GetAckDetaail(TrxNo);
                        EnabledButtonStatus();
                    }
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Not Possible, Because Everything is Delivered.");
                    //    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnEmailBlock_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you Sure ?", "Confirm !", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    SqlParameter[] prm =
                    {
                        new SqlParameter("@Task","BlockEmail"),
                        new SqlParameter("@ReceID",TrxNo)
                        };
                    int rslt = cls_Fin_Acknowledgement.Fin_Acknowledgment_NonQuery(prm);
                    if (rslt > 0)
                    {
                        MessageBox.Show("Bloked Successfuly.");
                        GetAckDetaail(TrxNo);
                        EnabledButtonStatus();
                    }
                   
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnModifyDDStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you Sure ?", "Confirm !", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    SqlParameter[] prm =
                    {
                        new SqlParameter("@Task","ModifyDDStatus"),
                        new SqlParameter("@ReceID",TrxNo)
                        };
                    int rslt = cls_Fin_Acknowledgement.Fin_Acknowledgment_NonQuery(prm);
                    if (rslt > 0)
                    {
                        MessageBox.Show("DD Status is Modified Successfuly.");
                        GetAckDetaail(TrxNo);
                        EnabledButtonStatus();
                    }

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
