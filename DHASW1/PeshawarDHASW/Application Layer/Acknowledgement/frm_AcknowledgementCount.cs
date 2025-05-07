using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Acknowledgement
{
    public partial class frm_AcknowledgementCount : Telerik.WinControls.UI.RadForm
    {
        public DataTable _dt { get; set; }
        public frm_AcknowledgementCount(DataTable dt)
        {
            InitializeComponent();
            _dt = dt;
        }

        private void frm_AcknowledgementCount_Load(object sender, EventArgs e)
        {
            dgAckCount.DataSource = _dt.DefaultView;
        }

        private void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(dgAckCount);
        }
    }
}
