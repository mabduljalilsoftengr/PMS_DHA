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
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.FileMap.Add_File_In_AllFile_Table
{
    public partial class frmModifyFile : Telerik.WinControls.UI.RadForm
    {
        public frmModifyFile()
        {
            InitializeComponent();
        }

        private void frmModifyFile_Load(object sender, EventArgs e)
        {
            RadGridColumnsAttach();
            LoadFileData();
            radgrdAllFileNo.Columns.Move(2, 5);
        }
        private void RadGridColumnsAttach()
        {
            GridViewComboBoxColumn comboColumn = new GridViewComboBoxColumn("PlotType");
            //set the column data source - the possible column values
            comboColumn.DataSource = new String[] { "Residential", "Commercial" };
            comboColumn.Width = 140;
            //set the FieldName - the column will retrieve the value from "Phone" column in the data table
            comboColumn.FieldName = "PlotType";
            comboColumn.Name = "PlotType";
            //add the column to the grid
            radgrdAllFileNo.Columns.Add(comboColumn);
            //----------------------------------------------------------------------------------------------
            GridViewComboBoxColumn comboColum = new GridViewComboBoxColumn("OwnerType");
            //set the column data source - the possible column values
            comboColum.DataSource = new String[] { "Balloting", "Svc Benefit" , "Investors" };
            comboColum.Width = 140;
            //set the FieldName - the column will retrieve the value from "Phone" column in the data table
            comboColum.FieldName = "OwnerType";
            comboColum.Name = "OwnerType";
            //add the column to the grid
            radgrdAllFileNo.Columns.Add(comboColum);
            //----------------------------------------------------------------------------------------------
            GridViewComboBoxColumn combo_Colum = new GridViewComboBoxColumn("Size");
            //set the column data source - the possible column values
            combo_Colum.DataSource = new String[] { "1 Kanal", "10 Marla" };
            combo_Colum.Width = 140;
            //set the FieldName - the column will retrieve the value from "Phone" column in the data table
            combo_Colum.FieldName = "Size";
            combo_Colum.Name = "Size";
            //add the column to the grid
            radgrdAllFileNo.Columns.Add(combo_Colum);

        }
        private void LoadFileData()
        {
           
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","Select")
            };
            DataSet dst = new DataSet();
            dst = cls_dl_AllFiles.AllFile_Reader(prm);
            radgrdAllFileNo.DataSource = dst.Tables[0].DefaultView;
           
        }

        private void radgrdAllFileNo_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if(e.Column.Name == "modify_file")
            {
                int rowindex = radgrdAllFileNo.CurrentRow.Index;
                int fileID = int.Parse(radgrdAllFileNo.Rows[rowindex].Cells["ID"].Value.ToString());
                string fileno = radgrdAllFileNo.Rows[rowindex].Cells["FileNo"].Value.ToString();
                string Plot_type = radgrdAllFileNo.Rows[rowindex].Cells["PlotType"].Value.ToString();
                string owner_type = radgrdAllFileNo.Rows[rowindex].Cells["OwnerType"].Value.ToString();
                string Size = radgrdAllFileNo.Rows[rowindex].Cells["Size"].Value.ToString();
                SqlParameter[] prm =
                {
                    new SqlParameter("@Task","Update"),
                    new SqlParameter("@ID",fileID),
                    new SqlParameter("@FileNo",fileno),
                    new SqlParameter("@PlotType",Plot_type),
                    new SqlParameter("@OwnerType",owner_type),
                    new SqlParameter("@Size",Size)
                };
                int rslt = cls_dl_AllFiles.AllFileNo_NonQuery(prm);
                if(rslt > 0)
                {
                    RadMessageBox.Show("Updation Successfull.");
                    LoadFileData();
                }
            }
        }
    }
}
