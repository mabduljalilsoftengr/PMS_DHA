using PeshawarDHASW.Data_Layer.clsImageArchiving;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using WIA;

namespace PeshawarDHASW.Application_Layer.Image_Archiving
{
    public partial class SelectScanner : Telerik.WinControls.UI.RadForm
    {
        public SelectScanner()
        {
            InitializeComponent();
        }

        private void btnScanDocuments_Click(object sender, EventArgs e)
        {

            try
            {
                //get list of devices available
                List<string> devices = WIA_Scanner.GetDevices();

                foreach (string device in devices)
                {
                    lbDevices.Items.Add(device);
                }
                //check if device is not available
                if (lbDevices.Items.Count == 0)
                {
                    MessageBox.Show("You do not have any WIA devices.");
                    this.Close();
                }
                else
                {
                    lbDevices.SelectedIndex = 0;
                }
                //get images from scanner
                List<Image> images = WIA_Scanner.Scan((string)lbDevices.SelectedItem);
                foreach (Image image in images)
                {
                    Scanning_Documents_and_Setting obj = new Scanning_Documents_and_Setting(image);
                    obj.ShowDialog();                    
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnAddImagesToGrid_Click(object sender, EventArgs e)
        {
            #region Add Image to GridView
            List<Image> imgs_Collection = cls_ImageHolder.ImagesContainer;
            //cls_ImageHolder.ImagesContainer.Clear();
            this.Close();
            #endregion
        }
    }
}
