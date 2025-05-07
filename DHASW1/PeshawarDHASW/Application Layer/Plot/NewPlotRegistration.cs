using PeshawarDHASW.Helper;
using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Plot
{
    public partial class NewPlotRegistration : Telerik.WinControls.UI.RadForm
    {
        public NewPlotRegistration()
        {
            InitializeComponent();
        }

        private void PhaseDataLoading()
        {
            DataSet ds = new DataSet();
            ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.Text, "SELECT Phase_ID,Name AS PhaseName FROM dbo.tbl_Phase");
            drp_Phase.ValueMember = "Phase_ID";
            drp_Phase.DisplayMember = "PhaseName";
            drp_Phase.DataSource = ds.Tables[0].DefaultView;

        }
        private void SectorDataLoading()
        {
            DataSet ds = new DataSet();
            ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.Text, "SELECT Sector_ID,Name AS SectorName FROM dbo.tbl_Sector");
            drp_Sector.ValueMember = "Sector_ID";
            drp_Sector.DisplayMember = "SectorName";
            drp_Sector.DataSource = ds.Tables[0].DefaultView;
        }

        private void PlotTypeDataLoading()
        {
            DataSet ds = new DataSet();
            ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.Text, "SELECT PlotID,Type AS PlotType FROM dbo.tbl_Plot_Type");
            drp_PlotType.ValueMember = "PlotID";
            drp_PlotType.DisplayMember = "PlotType";
            drp_PlotType.DataSource = ds.Tables[0].DefaultView;
        }
        private void NewPlotRegistration_Load(object sender, EventArgs e)
        {
            PhaseDataLoading();
            SectorDataLoading();
            PlotTypeDataLoading();
        }

        List<clsMemberImage> ImageContainer = new List<clsMemberImage>();
        private void btnBrowseforSingleimage_Click(object sender, EventArgs e)
        {
            try
            {
                int imageCount = ImageContainer.Count() + 1;
                clsMemberImage obj = new clsMemberImage();
                obj.ImageName = DateTime.Now.ToString("yyyyMMdd") + "_" + imageCount;
                obj.Description = "Attachment with DD Transfer.";

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter =
                    @"Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files (.)|*.*";
                openFileDialog1.Title = "Select Photos";

                DialogResult dr = openFileDialog1.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {

                    string[] files = openFileDialog1.FileNames;
                    foreach (var pngFile in files)
                    {
                        try
                        {
                            obj.MemberImage = Image.FromFile(pngFile);
                        }
                        catch
                        {
                            Console.WriteLine("This is not an image file");
                        }
                    }
                    ImageContainer.Add(obj);
                    ImageSource.TableElement.RowHeight = 50;
                    ImageSource.Columns["MemberImage"].ImageLayout = ImageLayout.Stretch;
                    ImageSource.DataSource = ImageContainer.DefaultIfEmpty();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void ImageSource_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {

            if (e.Column.Name == "btnRemove")
            {
                try
                {
                    ImageContainer.RemoveAt(e.RowIndex);
                    ImageSource.TableElement.RowHeight = 50;
                    ImageSource.Columns["MemberImage"].ImageLayout = ImageLayout.Stretch;
                    ImageSource.DataSource = ImageContainer.DefaultIfEmpty();
                    if (ImageContainer.Count == 0)
                        ImageSource.DataSource = null;
                }
                catch (Exception)
                {
                    ImageSource.DataSource = null;
                }
            }
        }

        private void txtFileNoVerification_Click(object sender, EventArgs e)
        {
            SqlParameter[] param = {
                new SqlParameter("@Task","AllotmentFileVerification"),
                new SqlParameter("@FileNo",txtFileNo.Text)
            };
            DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_PlotAllot", param);
        }
    }
}
