using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Login
{
    public partial class frmForgotPassword : Telerik.WinControls.UI.RadForm
    {
        public frmForgotPassword()
        {
            InitializeComponent();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your Email is incorrect kindly enter a valid email address");
        }
    }
}
