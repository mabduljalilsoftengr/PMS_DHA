using PeshawarDHASW.Data_Layer.clsFileMap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.FileMap.ByBack
{
    public partial class frmRegisterNewLandProvider : Telerik.WinControls.UI.RadForm
    {
        public frmRegisterNewLandProvider()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@Task", "Enter_LandProviderData"),
                new SqlParameter("@Name", txtname.Text),
                new SqlParameter("@CNIC", txtcnic.Text),
                new SqlParameter("@FatherName", txtfname.Text),
                new SqlParameter("@MobileNo", txtmobileno.Text),
                new SqlParameter("@Address", txtaddress.Text)
            };
            int rslt = cls_dl_FileMap.Main_FileMap_NonQuery(parameters);
            if (rslt > 0)
            {
                MessageBox.Show("Successfull.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
