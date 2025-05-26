using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsDBError;
using PeshawarDHASW.Data_Layer.clsErrorLog;
using PeshawarDHASW.Models;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.DBError
{
    public partial class frmDBErrorView : Telerik.WinControls.UI.RadForm
    {
        public frmDBErrorView()
        {
            InitializeComponent();
        }

        private void ddlRecordSize_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            int number = 100;
            bool numberparser = int.TryParse(ddlRecordSize.SelectedItem.Text, out number);
            if (numberparser)
            {
                GVErrorView.DataSource = cls_dl_DBError.DBErrorLogReader(number).Tables[0].DefaultView;
            }
            else
            {
                GVErrorView.DataSource = cls_dl_DBError.DBErrorLogReader(number).Tables[0].DefaultView;
            }
        }

        private void frmDBErrorView_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
        }
    }
}
