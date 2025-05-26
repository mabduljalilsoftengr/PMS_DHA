using PeshawarDHASW.Data_Layer.clsPlot;
using PeshawarDHASW.Data_Layer.clsPlotType;
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

namespace PeshawarDHASW.Application_Layer.Plot
{
    public partial class frmPlot_Create : Telerik.WinControls.UI.RadForm
    {
        public frmPlot_Create()
        {
            InitializeComponent();
        }
        private IEnumerable<DataRow> dtr { get; set; }
        private int plotid { get; set; } = 0;
        public frmPlot_Create(int get_pltid, IEnumerable<DataRow> get_SelectedRow)
        {
            InitializeComponent();
            dtr = get_SelectedRow;
            plotid = get_pltid;
            //BindPlot_Type();
            //BindSectorData();
        }
        private void frmPlot_Create_Load(object sender, EventArgs e)
        {           
            if (plotid == 0)
            {
                BindPlot_Type();
                BindSectorData();
                drp_Status.SelectedIndex = 0;
                //hjhkj
            }
            else
            {
                btnSave.Text = "Update";
                BindPlot_Type();
                BindSectorData();
                foreach(DataRow dr in dtr)
                {
                    #region Sector DropDown Fill from Selected Value
                    int strid = dr.Field<int>("SectorID");
                    Helper.clsPluginHelper.RadDropDownSelectedbyValue(drp_Sector, strid);
                    #endregion
                    #region Plot Type DropDown Fill from Selected Value
                    int strpltt = dr.Field<int>("PlotType");
                    Helper.clsPluginHelper.RadDropDownSelectedbyValue(drp_PlotType, strpltt);
                    #endregion
                    #region Status DropDown Fill from Selected Item
                    Helper.clsPluginHelper.RadDropDownSelectByText(drp_Status, dr.Field<string>("Status"));
                    #endregion
                    txtPlotNo.Text = dr.Field<string>("PlotNo");
                    txtCorner.Text = dr.Field<string>("Conor");
                    txtDocumentNo.Text = dr.Field<string>("DocumentNo");
                    txtKanal.Text = dr.Field<string>("Kanal");
                    txtMarla.Text = dr.Field<string>("Marla");
                    txtNewPlotNo.Text = dr.Field<string>("NewPlotNo");
                    txtOldPlotNumber.Text = dr.Field<string>("OldPlotNo");
                    txtSqFeet.Text = dr.Field<string>("SqFeet");
                    txtSqYard.Text = dr.Field<string>("SqYard");
                    txtStreet.Text = dr.Field<string>("Street");                    
                }
            }
        }
        private void BindSectorData()
        {
            RadListDataItem Select = new RadListDataItem();
            Select.Value = 0;
            Select.Text = "-- Select Sector --";
            this.drp_Sector.Items.Add(Select);
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","Select"),
            };
            foreach (DataRow row in Data_Layer.clsSector.cls_dl_Sector.Sector_Reader(prm).Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["Sector_ID"].ToString();
                dataItem.Text = row["Name"].ToString();
                this.drp_Sector.Items.Add(dataItem);
               
            }
            drp_Sector.SelectedIndex = 0;
            //drp_Sector.DisplayMember = "Name";
            //drp_Sector.ValueMember = "Sector_ID";
        }
        private void BindPlot_Type()
        {
            RadListDataItem Select = new RadListDataItem();
            Select.Value = 0;
            Select.Text = "-- Select Plot Type --";
            this.drp_PlotType.Items.Add(Select);
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","Select"),
            };
            foreach (DataRow row in Data_Layer.clsPlotType.cls_dl_PlotType.PlotType(prm).Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["PlotID"].ToString();
                dataItem.Text = row["Type"].ToString();
                this.drp_PlotType.Items.Add(dataItem);
            }
            drp_PlotType.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(plotid == 0)
            {
                #region Create New 
                SqlParameter[] prmt =
                {
                new SqlParameter("@Task","Insert"),
                new SqlParameter("@PlotNo",txtPlotNo.Text),
                new SqlParameter("@PlotType",drp_PlotType.SelectedValue),
                new SqlParameter("@Kanal",txtKanal.Text),
                new SqlParameter("@Marla",txtMarla.Text),
                new SqlParameter("@SqFeet",txtSqFeet.Text),
                new SqlParameter("@SqYard",txtSqYard.Text),
                new SqlParameter("@Conor",txtCorner.Text),
                new SqlParameter("@Street",txtStreet.Text),
                new SqlParameter("@DocumentNo",txtDocumentNo.Text),
                new SqlParameter("@OldPlotNo",txtOldPlotNumber.Text),
                new SqlParameter("@NewPlotNo",txtNewPlotNo.Text),
                new SqlParameter("@Status",drp_Status.SelectedItem.ToString()),
                new SqlParameter("@SectorID",drp_Sector.SelectedValue),
                new SqlParameter("@userID",Models.clsUser.ID)

            };
                int rslt = Data_Layer.clsPlot.cls_dl_Plot.Plot_NonQuery(prmt);
                if (rslt > 0)
                {
                    MessageBox.Show("Insertion is Successful.");
                    Clear();
                }
                #endregion
            }
            else
            {
                #region Update Record 
                SqlParameter[] prmt =
                {
                new SqlParameter("@Task","Update"),
                new SqlParameter("@PlotNo",txtPlotNo.Text),
                new SqlParameter("@PlotType",drp_PlotType.SelectedValue),
                new SqlParameter("@Kanal",txtKanal.Text),
                new SqlParameter("@Marla",txtMarla.Text),
                new SqlParameter("@SqFeet",txtSqFeet.Text),
                new SqlParameter("@SqYard",txtSqYard.Text),
                new SqlParameter("@Conor",txtCorner.Text),
                new SqlParameter("@Street",txtStreet.Text),
                new SqlParameter("@DocumentNo",txtDocumentNo.Text),
                new SqlParameter("@OldPlotNo",txtOldPlotNumber.Text),
                new SqlParameter("@NewPlotNo",txtNewPlotNo.Text),
                new SqlParameter("@Status",drp_Status.SelectedItem.ToString()),
                new SqlParameter("@SectorID",drp_Sector.SelectedValue),
                new SqlParameter("@userID",Models.clsUser.ID),
                new SqlParameter("@Plot_ID",plotid)
                };
                int rslt = Data_Layer.clsPlot.cls_dl_Plot.Plot_NonQuery(prmt);
                if (rslt > 0)
                {
                    MessageBox.Show("Insertion is Successful.");
                    //Clear();
                    this.Close();
                }
                #endregion
            }

        }
        private void Clear()
        {
            txtCorner.Text = "";
            txtDocumentNo.Text = "";
            txtKanal.Text = "";
            txtMarla.Text = "";
            txtNewPlotNo.Text = "";
            txtOldPlotNumber.Text = "";
            txtPlotNo.Text = "";
            txtSqFeet.Text = "";
            txtSqYard.Text = "";
            txtStreet.Text = "";
        }
    }
}
