using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Image_Archiving
{
    public partial class ScannedImagePreview : Telerik.WinControls.UI.RadForm
    {
        public ScannedImagePreview()
        {
            InitializeComponent();
        }
        public ScannedImagePreview(Image get_img)
        {
            InitializeComponent();
            picPreview.Image = get_img;
        }
    }
}
