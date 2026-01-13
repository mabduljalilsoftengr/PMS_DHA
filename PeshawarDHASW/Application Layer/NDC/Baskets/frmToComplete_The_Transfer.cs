using PeshawarDHASW.Data_Layer.clsTFR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    public partial class frmToComplete_The_Transfer : Telerik.WinControls.UI.RadForm
    {
        public frmToComplete_The_Transfer()
        {
            InitializeComponent();
        }

        private void grdUploadImage_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "")
            {

                //-----------Upload The Image of Transfer Persons Group Photo----------------------
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter =
                    @"Images (*.JPEG)|*.JPG| All files (.)|*.*";
                openFileDialog1.Title = "Select Photos";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Image objectt = new Bitmap(openFileDialog1.FileName);
                    MemoryStream ms = new MemoryStream();
                    objectt.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    Byte[] Image = ms.ToArray();
                    SqlParameter[] par_mt =
                    {
                  new SqlParameter("@Task","Insert"),
                  new SqlParameter("@Image",Image),
                  new SqlParameter("@TFRInformation","TFR_Report_Document_Image"),
                  new SqlParameter("@CurrentDate",DateTime.Now.ToString("dd/MM/yyyy")),
                  new SqlParameter("@Status","Pending"),
                 // new SqlParameter("@FileKey",FileMapKey)
                   };
                    int rslt = 0;
                    rslt = cls_dl_TFRHistory.TFRHistory_NonQuery(par_mt);

                }
                //------------End Upload Image--------------------
            }
        }

        private void frmToComplete_The_Transfer_Load(object sender, EventArgs e)
        {

        }
    }
}
