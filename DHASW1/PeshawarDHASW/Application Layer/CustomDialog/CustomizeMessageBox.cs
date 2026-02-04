using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.Windows.Documents.Spreadsheet.Model;

namespace PeshawarDHASW.Application_Layer.CustomDialog
{
    public partial class CustomizeMessageBox : Telerik.WinControls.UI.RadForm
    {
        public string status { get; set; }
        public string MSG { get; set; }
        public bool NeedRemarks { get; set; }
        public string Remarks { get; set; }
        public CustomizeMessageBox(string Msg, bool NeedRemarks = false)
        {
            MSG = Msg;
            InitializeComponent();
            this.NeedRemarks = NeedRemarks;
        }

        public CustomizeMessageBox(string Msg, string _Yes, string _No, bool NeedRemarks = false)
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
                frmRemarks obj = new frmRemarks();
                obj.ShowDialog();
                if (string.IsNullOrEmpty(obj.RemarksText))
                    return;
                Remarks = obj.RemarksText;
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
    }
}
