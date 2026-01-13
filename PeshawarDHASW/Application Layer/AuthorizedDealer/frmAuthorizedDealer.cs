using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.AuthorizedDealer
{
    public partial class frmAuthorizedDealer : Telerik.WinControls.UI.RadForm
    {
       
        public frmAuthorizedDealer()
        {
            InitializeComponent();
        }
        
        private void btnAttachImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter =
                @"Images         (*.BMP;*.JPEG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files (.)|*.*";
            openFileDialog1.Title = "Select Photos";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                Picture.Image = new Bitmap(openFileDialog1.FileName);
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
