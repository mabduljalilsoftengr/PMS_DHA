using PeshawarDHASW.Data_Layer.clsPhase;
using PeshawarDHASW.Data_Layer.clsSector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Sector
{
    public partial class frmSector_Modify : Telerik.WinControls.UI.RadForm
    {
        public frmSector_Modify()
        {
            InitializeComponent();
        }
        private DataSet dst { get; set; }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadSector_Data();
        }
        private void LoadSector_Data()
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","Select"),
                new SqlParameter("@Name",txtName.Text),
                new SqlParameter("@Remarks",txtRemarks.Text),
                new SqlParameter("@GPSXY",txtGPRSXY.Text)
            };
            dst = cls_dl_Sector.Sector_Reader(prm);
            grdSector.DataSource = dst.Tables[0].DefaultView;
        }

        private void grdSector_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "Modify_Sector")
            {
                int sectorID = int.Parse(grdSector.CurrentRow.Cells[0].Value.ToString());
                #region Linq Query , Loop through DataSet using the Selected Row ID
                IEnumerable<DataRow> selected_row = from rowdata in dst.Tables[0].AsEnumerable()
                                                    where rowdata.Field<int>("Sector_ID") == sectorID
                                                    select rowdata;
                #endregion
                frmSector_Create frmob = new frmSector_Create(sectorID, selected_row);
                frmob.ShowDialog();
                LoadSector_Data();
                //this.Close();

            }
        }

        private void frmSector_Modify_Load(object sender, EventArgs e)
        {

        }
    }
}
