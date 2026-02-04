using PeshawarDHASW.Helper;
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

namespace PeshawarDHASW.Application_Layer.Installment.Surcharge
{
    public partial class frmNewSurchargeWavierFullDetail : Telerik.WinControls.UI.RadForm
    {
        public frmNewSurchargeWavierFullDetail()
        {
            InitializeComponent();
        }
        public int SurMaster_ID { get; set; }
        public string Sur_Status { get; set; }
        public frmNewSurchargeWavierFullDetail(int SurMasterID,string SurStatus,string FileNo, string PlotNo)
        {
            SurMaster_ID = SurMasterID;
            Sur_Status = SurStatus;
            InitializeComponent();
            txtFileNo.Text = FileNo;
            txtPlotNo.Text = PlotNo;
        }

        private void WavierDetail(int SurMasterID)
        {
            try
            {
                SqlParameter[] param = { new SqlParameter("@Task", "DetailbyMasterID"), new SqlParameter("@SurMasterID", SurMasterID), new SqlParameter("@StatusofSur", Sur_Status) };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(
                                                            Helper.SQLHelper.createConnection(),
                                                            CommandType.StoredProcedure,
                                                            "Surc.USP_tbl_SurchargeWavierDetailRecord",
                                                            param);
                if (ds.Tables.Count>0)
                {
                    if (ds.Tables[0].Rows.Count>0)
                    {
                        grd_AccountStatment.DataSource = ds.Tables[0].DefaultView;
                        clsPluginHelper.GridColumnBestFit(grd_AccountStatment);
                        //clsPluginHelper.Summary_Column_Template_Wise_Search(grd_AccountStatment);
                    }
                    else
                    {
                        MessageBox.Show("No Record found.");
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Surcharge Wavier Detail is Not Present Error Info: "+ex.Message);
            }
        }
        private void frmNewSurchargeWavierFullDetail_Load(object sender, EventArgs e)
        {
            WavierDetail(SurMaster_ID);
        }

     

    }
}
