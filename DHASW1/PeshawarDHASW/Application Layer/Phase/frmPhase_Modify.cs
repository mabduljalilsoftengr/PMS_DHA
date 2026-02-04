using PeshawarDHASW.Data_Layer.clsPhase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Phase
{
    public partial class frmPhase_Modify : Telerik.WinControls.UI.RadForm
    {
        public frmPhase_Modify()
        {
            InitializeComponent();
        }
        private DataSet dst { get; set; }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadPhase_Data();
        }
        private void LoadPhase_Data()
        {
           SqlParameter[] prm =
           {
                new SqlParameter("@Task","Select"),
                new SqlParameter("@Name",txtName.Text),
                new SqlParameter("@Remarks",txtRemarks.Text),
                new SqlParameter("@GPSXY",txtGPRSXY.Text)
            };
            dst = cls_dl_Phase.Phase_Reader(prm);
            grdPhase.DataSource = dst.Tables[0].DefaultView;
        }
        private void grdPhase_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if(e.Column.Name == "Modify_Phase")
            {
                int phsID = int.Parse(grdPhase.CurrentRow.Cells[0].Value.ToString());
                #region Linq Query , Loop through DataSet using the Selected Row ID
                IEnumerable<DataRow> selected_row = from rowdata in dst.Tables[0].AsEnumerable()
                                             where rowdata.Field<int>("Phase_ID") == phsID
                                             select rowdata;
                #endregion
                frmPhase_Create frmobj = new frmPhase_Create(phsID, selected_row);
                frmobj.ShowDialog();
                LoadPhase_Data();
                //this.Close();
            }
        }
    }
}
