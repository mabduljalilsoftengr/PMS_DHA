using PeshawarDHASW.Data_Layer.clsFileMap;
using PeshawarDHASW.Data_Layer.clsFilePlotBinding;
using PeshawarDHASW.Data_Layer.clsPlot;
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
    public partial class frmFilePlotBinding_Create : Telerik.WinControls.UI.RadForm
    {
        public frmFilePlotBinding_Create()
        {
            InitializeComponent();
        }

        private void frmFilePlotBinding_Create_Load(object sender, EventArgs e)
        {
            LoadFile();
            LoadPlot();
        }
        private void LoadFile()
        {
            RadListDataItem Select = new RadListDataItem();
            Select.Value = 0;
            Select.Text = "-- Select File --";
            this.drp_FilesData.Items.Add(Select);
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","LoadFilesForBinding")
            };
            DataSet dst = new DataSet();
            dst = cls_dl_FilePlotBinding.FilePlotBinding_Reader(prm);
            foreach(DataRow dr in dst.Tables[0].Rows)
            {
                RadListDataItem item = new RadListDataItem();
                item.Value = dr["FileMapKey"].ToString();
                item.Text = dr["FileNo"].ToString();
                this.drp_FilesData.Items.Add(item);
                drp_FilesData.SelectedIndex = 0;
            }
        }
        private void LoadPlot()
        {
            RadListDataItem Select = new RadListDataItem();
            Select.Value = 0;
            Select.Text = "-- Select Plot --";
            this.drp_PlotData.Items.Add(Select);
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","LoadPlotsForBinding")
            };
            DataSet dst = new DataSet();
            dst = cls_dl_FilePlotBinding.FilePlotBinding_Reader(prm);
            foreach (DataRow dr in dst.Tables[0].Rows)
            {
                RadListDataItem item = new RadListDataItem();
                item.Value = dr["Plot_ID"].ToString();
                item.Text = dr["PlotNo"].ToString();
                this.drp_PlotData.Items.Add(item);               
            }
            drp_PlotData.SelectedIndex = 0;
        }

        private void btnBind_Click(object sender, EventArgs e)
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","Insert"),
                new SqlParameter("@FileMapKey_FK",drp_FilesData.SelectedValue),
                new SqlParameter("@PlotID_FK",drp_PlotData.SelectedValue),
                new SqlParameter("@Status","Current")
            };
            int rslt = cls_dl_FilePlotBinding.FilePlotBinding_NonQuery(prm);
            if(rslt > 0)
            {
                MessageBox.Show("Insertion Successful.");
            }
        }
    }
}
