using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Launching
{
    public partial class NewFormNo : Telerik.WinControls.UI.RadForm
    {
        public NewFormNo()
        {
            InitializeComponent();
        }

        public NewFormNo(string FormNo)
        {
            InitializeComponent();
            lblFormNo.Text = FormNo;
        }
        private void NewFormNo_Load(object sender, EventArgs e)
        {

        }
    }
}
