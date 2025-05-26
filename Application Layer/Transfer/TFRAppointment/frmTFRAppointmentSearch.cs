using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsTFR;
using PeshawarDHASW.Data_Layer.NDC;
using Telerik.WinControls;
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Application_Layer.Transfer.TFRAppointment
{
    public partial class frmTFRAppointmentSearch : Telerik.WinControls.UI.RadForm
    {
        public frmTFRAppointmentSearch()
        {
            InitializeComponent();
        }

        private void frmTFRAppointmentSearch_Load(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] parameter =
                {
                new SqlParameter("@Task","Select"),
               };
                DataSet ds = cls_dl_TFRAppointment.TFRReader(parameter);
                TFRAppointmentSearch.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        private void btnSearchAppointment_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] parameter =
                {
                new SqlParameter("@Task","Select"),
                new SqlParameter("@FileNo",clsPluginHelper.DbNullIfNullOrEmpty(txtfileno.Text)),
                new SqlParameter("@PlotNo",clsPluginHelper.DbNullIfNullOrEmpty(txtPlotNo.Text)),
                new SqlParameter("@NDCNo",clsPluginHelper.DbNullIfNullOrEmpty(txtNDC.Text) ),
                };
                DataSet ds = cls_dl_TFRAppointment.TFRReader(parameter);
                TFRAppointmentSearch.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnSearchAppointment_Click.", ex, "frmTFRAppointmentSearch");
                frmobj.ShowDialog();
            }
           
        }
    }
}
