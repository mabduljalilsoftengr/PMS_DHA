using PeshawarDHASW.Data_Layer.clsApplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Models;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Definition
{
    public partial class frmPlotType : Telerik.WinControls.UI.RadForm
    {
        public frmPlotType()
        {
            InitializeComponent();
        }

        private void frmPlotType_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            DataSet ds = cls_dl_Membership_PlotTYpe.PlotTypeAll();
            PlotTypeDG.DataSource = ds.Tables[0];
        }
    }
}
