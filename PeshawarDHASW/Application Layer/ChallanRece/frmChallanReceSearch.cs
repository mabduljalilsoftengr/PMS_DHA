using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsChallanRece;
using PeshawarDHASW.Data_Layer.clsChallanType;
using PeshawarDHASW.Data_Layer.clsErrorLog;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Models;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.ChallanRece
{
    public partial class frmChallanReceSearch : Telerik.WinControls.UI.RadForm
    {
        public frmChallanReceSearch()
        {
            InitializeComponent();
        }

        private void frmChallanReceSearch_Load(object sender, EventArgs e)
        {
            try
            {
                this.ThemeName = clsUser.ThemeName;
                ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task", "Select"),
                    new SqlParameter("@Status", "Active"),
                };
               
                typeofchallan.DataSource =
                    cls_dl_ChallanType.Challan_Reader(parameters, "App.USP_tbl_ChallanType").Tables[0].DefaultView;
                typeofchallan.ValueMember = "ChallanID";
                typeofchallan.DisplayMember = "ChallanType";
                typeofchallan.Items.Add(new RadListDataItem("-- Select Challan Type --", "0"));
                typeofchallan.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmChallanReceSearch_Load.", ex, "frmChallanReceSearch");
                frmobj.ShowDialog();

            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task","Select"),
                    new SqlParameter("@ChallanType",(typeofchallan.SelectedValue != "0"? typeofchallan.SelectedValue  :clsPluginHelper.DbNullIfNullOrEmpty(""))),
                    new SqlParameter("@NICNICOP",txtnic.Text),
                    new SqlParameter("@Name",txtname.Text),
                    new SqlParameter("@FileNo",txtfileno.Text),
                    new SqlParameter("@Remarks",txtremarks.Text),
                    new SqlParameter("@Amount",txtamount.Text),
                };
                    DataSet ds = cls_dl_ChallanRece.ChallanRece_Reader(parameters);
                    ChallanReceDg.DataSource = ds.Tables[0].DefaultView;
                
               
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnsearch_Click.", ex, "frmChallanReceSearch");
                frmobj.ShowDialog();
            }
        }
    }
}
