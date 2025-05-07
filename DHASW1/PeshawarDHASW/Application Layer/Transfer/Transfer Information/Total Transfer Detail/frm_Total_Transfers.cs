using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Helper;
using Telerik.WinControls;
using System.Data.SqlClient;
using Telerik.WinControls.Data;
using PeshawarDHASW.Models;
using Telerik.WinControls.UI;
using Telerik.Windows.Documents.Spreadsheet.Model;
using Telerik.Windows.Documents.Spreadsheet.PropertySystem;

namespace PeshawarDHASW.Application_Layer.Transfer.Transfer_Information.Total_Transfer_Detail
{
    public partial class frm_Total_Transfers : Telerik.WinControls.UI.RadForm
    {
        public frm_Total_Transfers()
        {
            InitializeComponent();
        }
        private string flst { get; set; } = "";
        public void ApplyTheme(string themeName)
        {
            this.ThemeName = themeName; ThemeResolutionService.ApplyThemeToControlTree(this, themeName);
        }

        private void frm_Total_Transfers_Load(object sender, EventArgs e)
        {

            #region 
            //this.drpFileNo.ShowCheckBox = true;
            //this.MultiSelectionComboBox1.DisplayMode = DisplayMode.DelimiterMode;
            //for (int i = 0; i < 10; ++i)
            //{
            //    RadListBoxItem item = new RadListBoxItem();
            //    RadCheckBoxElement checkBox = new RadCheckBoxElement();
            //    checkBox.Text = "Item " + i;
            //    checkBox.ToggleState = i % 2 == 0 ? Telerik.WinControls.Enumerations.ToggleState.On : Telerik.WinControls.Enumerations.ToggleState.Off;
            //    //remove this line if you dont want to close popup on checkbox checked
            //    checkBox.ToggleStateChanged += new StateChangedEventHandler(checkBox_ToggleStateChanged);
            //    item.Children.Add(checkBox);

            //    this.radComboBox1.Items.Add(item);
            //}
            #endregion

            if (clsUser.ThemeName == String.Empty)
            {
                ApplyTheme("TelerikMetro");
            }
            else
            {
                ApplyTheme(clsUser.ThemeName);
            }
            //    DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.Text,@"SELECT FileNo, COUNT(FileNo) FROM dbo.tbl_FileMap f
            //    INNER JOIN dbo.tbl_Owner o ON f.FileMapKey = o.FileMapID
            //    INNER JOIN dbo.tbl_Membership m ON  o.MemberID = m.ID
            //    GROUP BY FileNo HAVING COUNT(FileNo) > 1");

            DataSet Plot_Size = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.Text, @"SELECT  [ID],[PlotSize]  FROM [DHAPeshawarDB].[dbo].[tbl_Plot_Size]");
            ddl_PlotSize.DataSource = Plot_Size.Tables[0].DefaultView;
            ddl_PlotSize.DataMember = "ID";
            ddl_PlotSize.DisplayMember = "PlotSize";

            DataSet File_Type = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.Text, @"SELECT  OCID,Category_Name  FROM [DHAPeshawarDB].[dbo].tbl_Owner_Category");
            ddl_FileType.DataSource = File_Type.Tables[0].DefaultView;
            ddl_FileType.DataMember = "OCID";
            ddl_FileType.DisplayMember = "Category_Name";

            DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "dash.Transfer_Summaries",
                new SqlParameter[] {
                    new SqlParameter("@Task", "Total_Transfers_List"),
                    new SqlParameter("@File_Type",clsPluginHelper.DbNullIfNullOrEmpty( "")),
                    new SqlParameter("@PlotSize",clsPluginHelper.DbNullIfNullOrEmpty("")),
                      }

                );
            if (ds.Tables.Count > 0)
            {
                try
                {
                    AllTransfersRecords perds = new AllTransfersRecords();
                    perds.Tables[0].Merge(ds.Tables[0],true, MissingSchemaAction.Ignore);
                    perds.Tables[1].Merge(ds.Tables[1], true, MissingSchemaAction.Ignore);
                    dgv_Data.DataSource = perds.Tables[0];
                    gridViewTemplate1.DataSource = perds.Tables[1];
                    foreach (GridViewDataColumn column in gridViewTemplate1.Columns)
                    {
                        column.BestFit();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Kindly Check your Connection with Server.", "Attention");
            }
        }

       
        private void btnfind_Click(object sender, EventArgs e)
        {
            DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "dash.Transfer_Summaries",
               new SqlParameter[] {
                    new SqlParameter("@Task", "Total_Transfers_List"),
                    new SqlParameter("@File_Type",clsPluginHelper.DbNullIfNullOrEmpty( ddl_FileType.SelectedItem.Text)),
                    new SqlParameter("@PlotSize",clsPluginHelper.DbNullIfNullOrEmpty(ddl_PlotSize.SelectedItem.Text)),
                    new SqlParameter("@Sector",txtsector.Text),
                    new SqlParameter("@froms",txtfrom.Text),
                    new SqlParameter("@tos",txtto.Text),
                    new SqlParameter("@FileNo",flst)
                     }

               );
            if (ds.Tables.Count > 0)
            {
                AllTransfersRecords perds = new AllTransfersRecords();
                perds.Tables[0].Merge(ds.Tables[0], true, MissingSchemaAction.Ignore);
                perds.Tables[1].Merge(ds.Tables[1], true, MissingSchemaAction.Ignore);
                dgv_Data.DataSource = perds.Tables[0];
                gridViewTemplate1.DataSource = perds.Tables[1];
                foreach (GridViewDataColumn column in gridViewTemplate1.Columns)
                {
                    column.BestFit();
                }
            }
            else
            {
                MessageBox.Show("Kindly Check your Connection with Server.", "Attention");
            }

        }

        #region All Transfer Records
        private void btnAll_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "dash.Transfer_Summaries",
                          new SqlParameter[] {
                    new SqlParameter("@Task", "Total_Transfers_List"),
                                }
                          );
                if (ds.Tables.Count > 0)
                {
                    AllTransfersRecords perds = new AllTransfersRecords();
                    perds.EnforceConstraints = false;
                    perds.Tables[0].Merge(ds.Tables[0], true, MissingSchemaAction.Ignore);
                    perds.Tables[1].Merge(ds.Tables[1], true, MissingSchemaAction.Ignore);
                    
                    dgv_Data.DataSource = perds.Tables[0];
                    gridViewTemplate1.DataSource = perds.Tables[1];

                    foreach (GridViewDataColumn column in gridViewTemplate1.Columns)
                    {
                        column.BestFit();
                    }
                }
                else
                {
                    MessageBox.Show("Kindly Check your Connection with Server.", "Attention");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
         
        }
        #endregion

        #region Export to Excel
        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(dgv_Data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Software First.\n Error -> \n" + ex.Message);
            }
        }
        #endregion

        private void btnGridPrint_Click(object sender, EventArgs e)
        {

            GridPrintStyle style = new GridPrintStyle();
            style.PrintHierarchy = true;
            dgv_Data.PrintStyle = style;
            this.dgv_Data.PrintStyle.FitWidthMode = PrintFitWidthMode.FitPageWidth;

          //  Now we can choose whether to print the header cells on each page to make it easier to understand the data that is printed:
            this.dgv_Data.PrintStyle.PrintHeaderOnEachPage = true;

            //Next, we can choose which rows to print:
            this.dgv_Data.PrintStyle.PrintHiddenRows = false;
            this.dgv_Data.PrintStyle.PrintGrouping = true;
            this.dgv_Data.PrintStyle.PrintSummaries = true;
            dgv_Data.PrintPreview();
        }

        private void btnCrystalREport_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgv_Data.DataSource;
            DataTable dtc = (DataTable)gridViewTemplate1.DataSource;

            //    DataTable dtf = ToDataTable(dgv_Data);
            //    DataTable dtcf = ToDataTableonTemplate(gridViewTemplate1,dtf);
            TotalTransferReportViewer obj = new TotalTransferReportViewer(dt, dtc);
            obj.ShowDialog();

        }
        
        private void cmbFilenoCat_ItemCheckedChanged(object sender, RadCheckedListDataItemEventArgs e)
        {
           
            RadCheckedListDataItem checkeditem = e.Item;
            if (checkeditem.Checked == true)
            {
                flst = checkeditem.Text ;
                //flst = checkeditem.Text + ","+ flst;
                //if (checkeditem.Text == "OLO/A/RES")
                //{

                //}
                //if (checkeditem.Value == null)
                //    return;
            }
        }
        //private DataTable ToDataTable(RadGridView dataGridView)
        //{
        //    var dt = new DataTable();
        //    foreach (var dataGridViewColumn in dataGridView.Columns)
        //    {
        //            dt.Columns.Add(dataGridViewColumn.Name.ToString(),typeof(string));
        //    }
        //    var cell = new object[dataGridView.Columns.Count];
        //    foreach (var dataGridViewRow in dataGridView.ChildRows)
        //    {
        //        for (int i = 0; i < dataGridViewRow.Cells.Count; i++)
        //        {
        //            cell[i] = dataGridViewRow.Cells[i].Value;
        //        }
        //        dt.Rows.Add(cell);
        //    }
        //    return dt;
        //}



        //private DataTable ToDataTableonTemplate(GridViewTemplate dataGridView,DataTable FileInfo)
        //{
        //    var dt = new DataTable();
        //    foreach (var dataGridViewColumn in dataGridView.Columns)
        //    {
        //        dt.Columns.Add(dataGridViewColumn.Name.ToString(), typeof(string));
        //    }
        //    var cell = new object[dataGridView.Columns.Count];
        //    foreach (DataRow item in FileInfo.Rows)
        //    {
        //        foreach (var dataGridViewRow in dataGridView.Rows)
        //        {
        //            if (dataGridViewRow.Cells["FileNo"].Value ==item["FileNo"].ToString())
        //            {
        //                for (int i = 0; i < dataGridViewRow.Cells.Count; i++)
        //                {
        //                    cell[i] = dataGridViewRow.Cells[i].Value;
        //                }
        //                dt.Rows.Add(cell);
        //            }

        //        }
        //    }

        //    return dt;
        //}
    }


}
