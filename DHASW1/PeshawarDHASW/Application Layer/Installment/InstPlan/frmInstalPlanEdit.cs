using PeshawarDHASW.Data_Layer.clsPlanEdit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Installment.InstPlan
{
    public partial class frmInstalPlanEdit : Telerik.WinControls.UI.RadForm
    {
        public frmInstalPlanEdit()
        {
            InitializeComponent();
        }

        private void FillDataGrid()
        {
            try
            {
                SqlParameter[] prm =
                {
                //new SqlParameter("@Task","GetInsPlanSearch"),
                new SqlParameter("@FileNo", "B/RES/7698"),


                };
                DataSet ds = planEdit.getplantoEdit(prm);
                if (ds.Tables.Count > 0)
                {
                 
                    planEditGridView.DataSource = ds.Tables[0];
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_viewPlan_Click(object sender, EventArgs e)
        {
            FillDataGrid();
        }

       
    }
}
