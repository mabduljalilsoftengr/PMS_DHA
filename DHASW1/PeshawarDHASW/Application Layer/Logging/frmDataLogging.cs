using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsDataLogging;
using PeshawarDHASW.Models;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Logging
{
    public partial class frmDataLogging : Telerik.WinControls.UI.RadForm
    {
        public frmDataLogging()
        {
            InitializeComponent();
        }

        private void ddlRecordSize_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            string number = ddlRecordSize.SelectedItem.ToString();
            number = number == "All" ? "*" : number;
            GVErrorView.DataSource = cls_dl_DataLogging.DataLogReader(number).Tables[0].DefaultView;
            
        }

        private void frmDataLogging_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
        }
    }
}
