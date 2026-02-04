using PeshawarDHASW.Data_Layer.NDC;
using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    public partial class frmGoBackRemarks : Telerik.WinControls.UI.RadForm
    {
        public frmGoBackRemarks()
        {
            InitializeComponent();
        }
        private void frmGoBackRemarks_Load(object sender, EventArgs e)
        { 

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsNDC.goBackRemarks = txtRemarks.Text;
            this.Close();
        }
    }
}
