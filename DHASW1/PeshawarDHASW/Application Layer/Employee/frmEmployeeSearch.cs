using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsEmployee;
using PeshawarDHASW.Models;
using Telerik.WinControls;
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Application_Layer.Employee
{
    public partial class frmEmployeeSearch : Telerik.WinControls.UI.RadForm
    {
        public frmEmployeeSearch()
        {
            InitializeComponent();
        }

        private void btnemployeesearch_Click(object sender, EventArgs e)
        {
            BindDataWithGrid();
        }
        private void BindDataWithGrid()
        {
            try
            {
                SqlParameter[] parameters =
                         {
                clsPluginHelper.SqlparameterAttachtext("@EmpNo",txt_e_empno.Text),
                clsPluginHelper.SqlparameterAttachtext("@Name",txt_e_name.Text),
                clsPluginHelper.SqlparameterAttachtext("@Email",txt_e_email.Text),
                clsPluginHelper.SqlparameterAttachtext("@Mobile",txt_e_mobile.Text),
                clsPluginHelper.SqlparameterAttachtext("@SOS",txt_e_sos.Text),
                clsPluginHelper.SqlparameterAttachtext("@Speclization",txt_e_special.Text),
                new SqlParameter("@Task","Select"),
            };
                DataSet ds = cls_dl_Employee.Employee_Reader(parameters, "App.usp_tbl_Employee");
                gvSearchEmployee.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on BindDataWithGrid.", ex, "frmEmployeeSearch");
                frmobj.ShowDialog();

            }

        }

        private void frmEmployeeSearch_Load(object sender, EventArgs e)
        {

        }
    }
}
