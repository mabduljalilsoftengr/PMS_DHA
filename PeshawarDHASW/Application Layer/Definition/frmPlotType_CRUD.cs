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
    public partial class frmPlotType_CRUD : Telerik.WinControls.UI.RadForm
    {
        public frmPlotType_CRUD()
        {
            InitializeComponent();
        }

        private void frmPlotType_CRUD_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
        }
    }
}
