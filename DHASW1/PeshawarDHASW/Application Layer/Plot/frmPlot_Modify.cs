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
    public partial class frmPlot_Modify : Telerik.WinControls.UI.RadForm
    {
        public frmPlot_Modify()
        {
            InitializeComponent();
        }
        private DataSet dst { get; set; }
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
            dst = new DataSet();
            dst = cls_dl_Plot.Plot_Reader(prm);
            grdPlotDetail.DataSource = dst.Tables[0].DefaultView;
        }

        private void grdPlotDetail_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if(e.Column.Name == "Modify_Plot")
            {
                int pltid = int.Parse(grdPlotDetail.CurrentRow.Cells[0].Value.ToString());
                #region Linq Query , Loop through DataSet using the Selected Row ID
                IEnumerable<DataRow> selected_row = from rowdata in dst.Tables[0].AsEnumerable()
                                                    where rowdata.Field<int>("Plot_ID") == pltid
                                                    select rowdata;
                #endregion
                frmPlot_Create frmobj = new frmPlot_Create(pltid,selected_row);
                frmobj.ShowDialog();
                LoadPlotData();
            }
        }
    }
}
