using PeshawarDHASW.Data_Layer.clsDataLogging;
using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Logging
{
    public partial class frmLogHistoryForUser : Telerik.WinControls.UI.RadForm
    {
        public frmLogHistoryForUser()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                string number = ddlRecordSize.SelectedItem.ToString();
                number = number == "All" ? "*" : number;
                string table = drpTableName.SelectedItem.ToString();

                GVErrorView.DataSource = cls_dl_DataLogging.DataLogHistoryReader(table, number).Tables[0].DefaultView;
                foreach (GridViewDataColumn column in GVErrorView.Columns)
                {
                    column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void frmLogHistoryForUser_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
        }
    }
}
