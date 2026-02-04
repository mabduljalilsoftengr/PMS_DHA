using PeshawarDHASW.Data_Layer.clsPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Plot
{
    public partial class frmPlot_Search : Telerik.WinControls.UI.RadForm
    {
        public frmPlot_Search()
        {
            InitializeComponent();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadPlotData();
        }
        private void LoadPlotData()
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","Select"),
                new SqlParameter("@Conor",txtCorner.Text),
                new SqlParameter("@DocumentNo",txtDocumentsNo.Text),
                new SqlParameter("@Kanal",txtKanal.Text),
                new SqlParameter("@Marla",txtMarla.Text),
                new SqlParameter("@NewPlotNo",txtNewPlotNo.Text),
                new SqlParameter("@OldPlotNo",txtOldPlotNo.Text),
                new SqlParameter("@PlotNo",txtPlotNumber.Text)
            };
            DataSet dst = new DataSet();
            dst = cls_dl_Plot.Plot_Reader(prm);
            grdPlotDetail.DataSource = dst.Tables[0].DefaultView;
        }
    }
}
