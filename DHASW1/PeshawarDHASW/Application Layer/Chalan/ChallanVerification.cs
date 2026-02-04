using PeshawarDHASW.Application_Layer.CustomDialog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Chalan
{
    public partial class ChallanVerification : Telerik.WinControls.UI.RadForm
    {
        public ChallanVerification()
        {
            InitializeComponent();
        }

        public DateTime MinDateofChallan { get; set; }
        public string status { get; set; }
        public string MSG { get; set; }
        public  DateTime Cleardate { get; set; }
        public bool NeedRemarks { get; set; }
        public string Remarks { get; set; }
        public ChallanVerification(string Msg, bool NeedRemarks = false)
        {
            MSG = Msg;
            InitializeComponent();
            this.NeedRemarks = NeedRemarks;
        }

        public ChallanVerification(string Msg, string _Yes, string _No, bool NeedRemarks = false)
        {
            MSG = Msg;
            InitializeComponent();
            btnDiscard.Text = _No;
            btnCancel.Text = _Yes;
            btnApproved.Visible = false;

            this.NeedRemarks = NeedRemarks;
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            status = btnApproved.Text;
            if (NeedRemarks)
            {
                if (challanVerificationdate.Value.Date <= DateTime.Now.Date)
                {
                    frmRemarks obj = new frmRemarks();
                    obj.ShowDialog();
                    if (string.IsNullOrEmpty(obj.RemarksText))
                        return;
                    Cleardate = challanVerificationdate.Value;
                    Remarks = obj.RemarksText;
                }
                else
                {
                    MessageBox.Show("Please Correct the Clearance Date of Challan.");
                }
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (NeedRemarks)
            {
                frmRemarks obj = new frmRemarks();
                obj.ShowDialog();
                if (string.IsNullOrEmpty(obj.RemarksText))
                    return;
                Remarks = obj.RemarksText;
            }
            status = btnCancel.Text;
            this.Close();
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            status = btnDiscard.Text;
            this.Close();
        }

        private void CustomizeMessageBox_Load(object sender, EventArgs e)
        {
            txtMessage.Text = MSG;
        }

        private void CustomizeMessageBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (!string.IsNullOrEmpty(txtMessage.Text))
            //{
            //    status = btnDiscard.Text;
            //    this.Close();
            //}
            //else
            //{
            //    this.Close();
            //}

        }

        private void CustomizeMessageBox_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        private void ChallanVerification_Load(object sender, EventArgs e)
        {
            if (MinDateofChallan.ToShortDateString() == DateTime.Now.ToShortDateString())
            {
                challanVerificationdate.MaxDate = DateTime.Now.AddDays(1);
                challanVerificationdate.MinDate = MinDateofChallan;
                //challanVerificationdate.Value = DateTime.Now;

            }
            else
            {
                challanVerificationdate.MaxDate = DateTime.Now;
                challanVerificationdate.MinDate = MinDateofChallan;
                //challanVerificationdate.Value = DateTime.Now;
            }

        }
    }
}
