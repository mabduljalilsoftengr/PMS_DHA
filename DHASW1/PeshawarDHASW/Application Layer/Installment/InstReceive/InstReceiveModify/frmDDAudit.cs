using PeshawarDHASW.Data_Layer.Installment;
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

namespace PeshawarDHASW.Application_Layer.Installment.InstReceive.InstReceiveModify
{
    public partial class frmDDAudit : Telerik.WinControls.UI.RadForm
    {
        public int ReceID { get; set; }
        DataSet ds { get; set; }
        public frmDDAudit(DataSet ds)
        {
            InitializeComponent();
            this.ds = ds;
        }

        private void frmDDAudit_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            if (ds.Tables.Count > 0)
            {
                radgdInstReceive.DataSource = ds.Tables[0].DefaultView;
                //foreach (GridViewDataColumn column in radgdInstReceive.Columns)
                //{
                //    column.BestFit();
                //}
            }
            else
            {
                radgdInstReceive.DataSource = null;
            }

        }
        //ToolTip
        private void MasterTemplate_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement.Value != null)
            {
                e.CellElement.ToolTipText = e.CellElement.Value.ToString();
            }
        }
    }
}
