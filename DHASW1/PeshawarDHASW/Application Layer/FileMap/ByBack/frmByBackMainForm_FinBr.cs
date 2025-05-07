using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.FileMap.ByBack
{
    public partial class frmByBackMainForm_FinBr : Telerik.WinControls.UI.RadForm
    {
        public frmByBackMainForm_FinBr()
        {
            InitializeComponent();
        }

        private void btnBuybackUpdate_Click(object sender, EventArgs e)
        {
            frmBuyBackProgress frm = new frmBuyBackProgress();
            frm.ShowDialog();
        }

        private void btnFileCancel_Click(object sender, EventArgs e)
        {
            frmFileCancellationApply frm = new frmFileCancellationApply();
            frm.ShowDialog();
        }
    }
}
