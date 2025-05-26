using PeshawarDHASW.Application_Layer.CustomDialog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.NDC
{
    public partial class Caution_Info_Prompt : Telerik.WinControls.UI.RadForm
    {
        public DataSet dst { get; set; }
        public Caution_Info_Prompt()
        {
            InitializeComponent();
        }
        public Caution_Info_Prompt(DataSet get_ds)
        {
            dst = get_ds;
            InitializeComponent();
        }

        private void Caution_Info_Prompt_Load(object sender, EventArgs e)
        {
            try
            {
                grdMessageBox.DataSource = dst.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Caution_Info_Prompt_Load.", ex, "Caution_Info_Prompt");
                frmobj.ShowDialog();

            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
