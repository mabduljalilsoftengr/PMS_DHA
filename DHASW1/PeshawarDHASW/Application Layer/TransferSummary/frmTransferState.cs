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
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.TransferSummary
{
    public partial class frmTransferState : Telerik.WinControls.UI.RadForm
    {
        public frmTransferState()
        {
            InitializeComponent();
        }
        public string FileType { get; set; }
        public string BusinessType { get; set; }
        public frmTransferState(string filetype, string businesstype)
        {
            FileType = filetype;
            BusinessType = businesstype;
            InitializeComponent();
            LoadingData();


        }
        private void LoadingData()
        {
            SqlParameter[] param =
                          {
                    new SqlParameter("@Task", "ViewFileState"),
                    new SqlParameter("@FileInitial", FileType),
                    new SqlParameter("@OwnerCategory", BusinessType)
                };
            DGVFileState.DataSource = Data_Layer.clsTransferSummary.cls_dl_TransferSummary.TransferSumary_Read(param).Tables[0].DefaultView;

        }

        public void ApplyTheme(string themeName)
        {
            this.ThemeName = themeName; ThemeResolutionService.ApplyThemeToControlTree(this, themeName);
        }
        private void frmTransferState_Load(object sender, EventArgs e)
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

        private void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(DGVFileState);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Software First.\n Error -> \n" + ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            GridPrintStyle style = new GridPrintStyle();
            style.FitWidthMode = PrintFitWidthMode.FitPageWidth;
            style.HeaderCellBackColor = Color.Black;
            style.PrintGrouping = true;
            style.PrintSummaries = false;
            style.PrintHeaderOnEachPage = true;
            style.PrintHiddenColumns = false;
            DGVFileState.PrintStyle = style;
            RadPrintDocument dr = new RadPrintDocument();
            dr.Watermark.Text = "DHA Peshawar";
            dr.Landscape = true;
            dr.MiddleHeader = "DHA Peshawar";
            RadPrintPreviewDialog dialog = new RadPrintPreviewDialog();
            dialog.Document = dr;
            dialog.ShowDialog();
            //.PrintPreview();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadingData();
        }
    }
}
