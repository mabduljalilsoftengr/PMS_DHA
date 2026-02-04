using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Layouts;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.MainForm
{
    public partial class frmDashBoard : Telerik.WinControls.UI.RadForm
    {
        private LightVisualElement element1;
        private LightVisualElement element2;
        private LightVisualElement element3;
        private LightVisualElement element4;
        private StackLayoutPanel layout;

        public frmDashBoard()
        {
            InitializeComponent();
        }

        private void frmDashBoard_Load(object sender, EventArgs e)
        {

        }
    }
}
