using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.TransferSummary
{
    public partial class frmFileExtenededView : Telerik.WinControls.UI.RadForm
    {
        public frmFileExtenededView()
        {
            InitializeComponent();
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
        }
        public string OwnerCategoryID { get; set; }
        public string PlotBusinessTypeID { get; set; }
        public string PlotSize { get; set; }
        public string BusinessCategory { get; set; }
        public frmFileExtenededView(string OwnerCategoryID_,string PlotBusinessTypeID_,string PlotSize_, string businesscategory)
        {
            OwnerCategoryID = OwnerCategoryID_;
            PlotBusinessTypeID = PlotBusinessTypeID_;
            PlotSize = PlotSize_;
            BusinessCategory = businesscategory;
            InitializeComponent();
            GridDataLoading();
        }
        private void GridDataLoading()
        {
            try
            {
                
                    SqlParameter[] param =
                       {
                    new SqlParameter("@Task", "ViewFileDetail10112021"),
                    new SqlParameter("@OwnerCategoryID", OwnerCategoryID),
                     new SqlParameter("@PlotBusinessTypeID", PlotBusinessTypeID),
                      new SqlParameter("@PlotSize", PlotSize),
                    new SqlParameter("@OwnerCategory", BusinessCategory)
                };
                    DataSet ds = Data_Layer.clsTransferSummary.cls_dl_TransferSummary.TransferSumary_Read(param);
                    //Cancelled File
                    grdToalCancelled.DataSource = ds.Tables[0].DefaultView;
                    //Not-Entered File
                    grdNotEntered.DataSource = ds.Tables[1].DefaultView;
                    //Entered File
                    grdTotalEntered.DataSource = ds.Tables[2].DefaultView;
                    //Totall File
                    DGVTotalFiles.DataSource = ds.Tables[3].DefaultView;
                    //PlotAlloted File
                    DGVTotalAlloted.DataSource = ds.Tables[4].DefaultView;
                    //Plot Not Alloted File
                    DGVTotalNoTAlloted.DataSource = ds.Tables[5].DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        public void ApplyTheme(string themeName)
        {
            this.ThemeName = themeName; ThemeResolutionService.ApplyThemeToControlTree(this, themeName);
        }
        private void frmFileExtenededView_Load(object sender, EventArgs e)
        {
            if (clsUser.ThemeName == String.Empty)
            {
                ApplyTheme("TelerikMetro");
            }
            else
            {
                ApplyTheme(clsUser.ThemeName);
            }
        }

        private void GDVNotBinded_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {

                // int rowindex = GDVNotBinded.CurrentCell.RowIndex;
                // int columnindex = GDVNotBinded.CurrentCell.ColumnIndex;
                if (e.Column.Name == "btnBinded")
                {

                    // string FileNo = GDVNotBinded.CurrentRow.Cells["FileNo"].Value.ToString();

                    //if (FileNo != string.Empty )
                    //{
                    //     Application_Layer.Transfer.TFRType.TFRSetting.frmFileMembershipBinding objownerbinding = new Transfer.TFRType.TFRSetting.frmFileMembershipBinding(FileNo);
                    //    objownerbinding.ShowDialog();
                    //    GridDataLoading();
                    //}
                    //else
                    //{
                    //    RadMessageBox.Show("File Type is not exist.", "Warning", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);

                    //}
                }


            }
            catch (Exception ex)
            {
                #region Dangerous Error

                // MessageBox.Show("Search Grid \n Message -> "+ex.Message+"\nSource - > "+ex.Source);

                #endregion
            }
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(DGVTotalFiles);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Software First.\n Error -> \n" + ex.Message);
            }
        }

        private void btnNotBinded_Click(object sender, EventArgs e)
        {
            try
            {
                // Helper.clsPluginHelper.GridViewData_Export_to_Excel(GDVNotBinded);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Software First.\n Error -> \n" + ex.Message);
            }
        }

        private void btnNotEntered_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(grdNotEntered);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Software First.\n Error -> \n" + ex.Message);
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(grdTotalEntered);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Software First.\n Error -> \n" + ex.Message);
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(grdToalCancelled);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Software First.\n Error -> \n" + ex.Message);
            }
        }

        private void radGroupBox5_Click(object sender, EventArgs e)
        {

        }

        private void btnTotalAlloted_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(DGVTotalAlloted);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Software First.\n Error -> \n" + ex.Message);
            }
            
        }

        private void btnTotalNoTAlloted_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(DGVTotalNoTAlloted);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Software First.\n Error -> \n" + ex.Message);
            }

            
        }
    }
}
