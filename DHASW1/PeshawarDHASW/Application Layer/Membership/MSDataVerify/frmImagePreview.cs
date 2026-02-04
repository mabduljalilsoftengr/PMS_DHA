using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Membership.MSDataVerify
{
    public partial class frmImagePreview : Telerik.WinControls.UI.RadForm
    {
        public frmImagePreview()
        {
            InitializeComponent();
        }
        public frmImagePreview(Image image)
        {
            InitializeComponent();
            pictureBox1.Image = image;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            System.Drawing.Printing.PrintDocument myPrintDocument1 = new System.Drawing.Printing.PrintDocument();
            PrintDialog myPrinDialog1 = new PrintDialog();
            myPrintDocument1.PrintPage += MyPrintDocument1_PrintPage;
            myPrinDialog1.Document = myPrintDocument1;

            if (myPrinDialog1.ShowDialog() == DialogResult.OK)
            {
                myPrintDocument1.Print();
            }
        }

        private void MyPrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap myBitmap1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(myBitmap1, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            e.Graphics.DrawImage(myBitmap1, 0, 0);
            myBitmap1.Dispose();
        }
    }
}
