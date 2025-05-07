using PeshawarDHASW.Application_Layer.CustomDialog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.AdventureArena
{
    public partial class AdventureArenaMessagebox : Telerik.WinControls.UI.RadForm
    {
        public DateTime MinDateofChallan { get; set; }
        public string status { get; set; }
        public string MSG { get; set; }
        public DateTime Cleardate { get; set; }
        public bool NeedRemarks { get; set; }
        public string Remarks { get; set; }
        public AdventureArenaMessagebox()
        {
            InitializeComponent();
        }

        public AdventureArenaMessagebox(string Msg, bool NeedRemarks = false)
        {
            MSG = Msg;
            InitializeComponent();
            this.NeedRemarks = NeedRemarks;
        }

        public AdventureArenaMessagebox(string Msg, string _Yes, string _No, bool NeedRemarks = false)
        {
            MSG = Msg;
            InitializeComponent();
            btnDiscard.Text = _No;
            btnCancel.Text = _Yes;
            btnApproved.Visible = false;

            this.NeedRemarks = NeedRemarks;
        }


        private void AdventureArenaMessagebox_Load(object sender, EventArgs e)
        {

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

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            status = btnDiscard.Text;
            this.Close();
        }
    }
}
