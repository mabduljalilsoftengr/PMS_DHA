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
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.FilePlot_Binding
{
    public partial class frmFilePlotBinding_Modify : Telerik.WinControls.UI.RadForm
    {
        public frmFilePlotBinding_Modify()
        {
            InitializeComponent();
        }
        private void frmFilePlotBinding_Modify_Load(object sender, EventArgs e)
        {
            BindGridViewControls();
            grd_FilePlotBinding.ReadOnly = true;
        }
        private void BindGridViewControls()
        {
            #region Bind DropDown List To Grid
            GridViewComboBoxColumn comboColumn = new GridViewComboBoxColumn("Status");
            //set the column data source - the possible column values
            comboColumn.DataSource = new String[] { "Current", "Cancelled", "Replaced" };
            //set the FieldName - the column will retrieve the value from "Phone" column in the data table
            comboColumn.FieldName = "Status";
            comboColumn.Name = "Status";
            comboColumn.Width = 80;
            comboColumn.TextAlignment = ContentAlignment.MiddleCenter;
            //add the column to the grid
            grd_FilePlotBinding.Columns.Add(comboColumn);
            #endregion
            #region Bind Button Control with Grid
            GridViewCommandColumn modify = new GridViewCommandColumn();
            modify.Name = "Modify";
            modify.UseDefaultText = true;
            modify.FieldName = "Modify";
            modify.DefaultText = "Modify";
            modify.Width = 80;
            modify.TextAlignment = ContentAlignment.MiddleCenter;
            modify.HeaderText = "Modify";
            grd_FilePlotBinding.MasterTemplate.Columns.Add(modify);
            #endregion
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadFilePlotData();
            grd_FilePlotBinding.ReadOnly = false;
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

        private void grd_FilePlotBinding_CellClick(object sender, GridViewCellEventArgs e)
        {
            if(e.Column.Name == "Modify")
            {
                int fpbid = int.Parse(grd_FilePlotBinding.CurrentRow.Cells[0].Value.ToString());
                int fileid = int.Parse(grd_FilePlotBinding.CurrentRow.Cells[1].Value.ToString());
                string fileno = grd_FilePlotBinding.CurrentRow.Cells[2].Value.ToString();
                int pltid = int.Parse(grd_FilePlotBinding.CurrentRow.Cells[3].Value.ToString());
                string plotno = grd_FilePlotBinding.CurrentRow.Cells[4].Value.ToString();
                string docno =  grd_FilePlotBinding.CurrentRow.Cells[5].Value.ToString();
                string remarks =  grd_FilePlotBinding.CurrentRow.Cells[6].Value.ToString();
                string sts = grd_FilePlotBinding.CurrentRow.Cells[7].Value.ToString();
                SqlParameter[] prm =
                {
                    new SqlParameter("@Task","Update"),
                    new SqlParameter("@FileMapKey_FK",fileid),
                    new SqlParameter("@PlotID_FK",pltid),
                    new SqlParameter("@Document_No",docno),
                    new SqlParameter("@Remarks",remarks),
                    new SqlParameter("@Status",sts),
                    new SqlParameter("@FP_MapID",fpbid),
                };
                int rslt = cls_dl_FilePlotBinding.FilePlotBinding_NonQuery(prm);
                if(rslt > 0)
                {
                    MessageBox.Show("Updation is Successful.");
                    LoadFilePlotData();
                }
            }
        }
    }
}
