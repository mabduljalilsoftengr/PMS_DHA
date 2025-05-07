using PeshawarDHASW.Data_Layer.clsFileMap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.FileMap.Add_File_In_AllFile_Table
{
    public partial class frmCreateFile : Telerik.WinControls.UI.RadForm
    {
        public frmCreateFile()
        {
            InitializeComponent();
        }
        private void clear()
        {
            txtFileNo.Text = "";
            drpOwnerType.SelectedIndex = 0;
            drpPlotType.SelectedIndex = 0;
            drpSize.SelectedIndex = 0;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","Insert"),
                new SqlParameter("@FileNo",txtFileNo.Text),
                new SqlParameter("@OwnerType",drpOwnerType.SelectedItem.ToString()),
                new SqlParameter("@PlotType",drpPlotType.SelectedItem.ToString()),
                new SqlParameter("@Size",drpSize.SelectedItem.ToString())
            };
            int rslt = cls_dl_AllFiles.AllFileNo_NonQuery(prm);
            if(rslt > 0)
            {
                clear();
            }           
        }
    }
}
