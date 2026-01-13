using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.OpenTransfer
{
    public partial class frmPDFViewer : Telerik.WinControls.UI.RadForm
    {
        public frmPDFViewer()
        {
            InitializeComponent();
        }

        public frmPDFViewer(string FilePath)
        {
            InitializeComponent();
            radPdfViewer1.LoadDocument(FilePath);
            radPdfViewerNavigator1.AssociatedViewer = radPdfViewer1;
        }
        private void frmPDFViewer_Load(object sender, EventArgs e)
        {

        }
    }
}
