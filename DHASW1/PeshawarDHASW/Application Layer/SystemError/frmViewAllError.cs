using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsErrorLog;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.SystemError
{
    public partial class frmViewAllError : Telerik.WinControls.UI.RadForm
    {
        public frmViewAllError()
        {
            InitializeComponent();
        }

        private void frmViewAllError_Load(object sender, EventArgs e)
        {

        }

        private void ddlRecordSize_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            int number = 100;
            bool numberparser = int.TryParse(ddlRecordSize.SelectedItem.Text, out number);
            if (numberparser)
            {
                GVErrorView.DataSource = cls_dl_ErrorLog.ErrorLogReader(number).Tables[0].DefaultView;
            }
            else
            {
                GVErrorView.DataSource = cls_dl_ErrorLog.ErrorLogReader(number).Tables[0].DefaultView;
            }
        }
    }
}
