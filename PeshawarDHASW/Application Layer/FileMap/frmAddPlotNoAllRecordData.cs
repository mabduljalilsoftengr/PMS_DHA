using PeshawarDHASW.Helper;
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

namespace PeshawarDHASW.Application_Layer.FileMap
{
    public partial class frmAddPlotNoAllRecordData : Telerik.WinControls.UI.RadForm
    {
      
        public frmAddPlotNoAllRecordData()
        {
            InitializeComponent();
        }


        private string fileNo;
        public frmAddPlotNoAllRecordData(string FileNo)
        {
            InitializeComponent();
            fileNo = FileNo;
        }

        string branch = UserHelper.GetUserBranch();
        private void btnSavePlotNo_Click(object sender, EventArgs e)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@Task","AddPlotNotoAllDataExist"),
                new SqlParameter("@PlotNo",txtPlotNo.Text),
            };



            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_PlotAllot", param);
            if (ds.Tables.Count>0)
            {
                if (ds.Tables[0].Rows.Count==0)
                {
                    SqlParameter[] paramentry =
                   {
                        new SqlParameter("@Task","AddPlotNotoAllData"),
                        new SqlParameter("@PlotNo",txtPlotNo.Text),
                    };
                    int result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_PlotAllot", paramentry);
                    this.Close();

                    bool rslt = clsPluginHelper.ApplicationLogSaving(fileNo, Models.clsUser.ID + "-" + clsUser.Name + "-" + branch, "Insertion - Insertion in Allotment Table ", paramentry, "frmAddPlotNoAllRecordData - btnSavePlotNo_Click", "SQLParam");
                }

                
            }
            else
            {
                MessageBox.Show("PlotNo is Already Exists in the List.");
            }
           
        }
    }
}
