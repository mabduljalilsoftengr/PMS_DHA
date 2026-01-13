using PeshawarDHASW.Data_Layer.clsFilePlotBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.FilePlot_Binding
{
    public partial class frmFilePlotBinding_Search : Telerik.WinControls.UI.RadForm
    {
        public frmFilePlotBinding_Search()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadFilePlotData();
        }
        private void LoadFilePlotData()
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","Select"),
                new SqlParameter("@Document_No",txtDocumentNo.Text),
                new SqlParameter("@FileNo",txtFileNo.Text),
                new SqlParameter("@PlotNo",txtPlotNo.Text)
            };
            DataSet dst = new DataSet();
            dst = cls_dl_FilePlotBinding.FilePlotBinding_Reader(prm);
            grd_FilePlotBinding.DataSource = dst.Tables[0].DefaultView;
        }
    }
}
