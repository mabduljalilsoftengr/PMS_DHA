using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.clsMemberShip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Membership
{
    public partial class frmMembershipInfo : Telerik.WinControls.UI.RadForm
    {
        public frmMembershipInfo()
        {
            InitializeComponent();
        }

        private void radGroupBox1_Click(object sender, EventArgs e)
        {

        }
        private DataSet funSearch()
        {
            DataSet ds = new DataSet();
            try
            {

                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@Task","Select"),
                    new SqlParameter("@FilePlotShopVillaApartmentNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtfileno.Text)),
                    new SqlParameter("@MembershipNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtmsno.Text)),
                    new SqlParameter("@NICNICOP",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtnic.Text)),
                    new SqlParameter("@Name",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtname.Text)),
                    new SqlParameter("@MobileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtmobile.Text)),
                    new SqlParameter("@PersonalNoSvcPersOnly",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtPANo.Text)),
                    new SqlParameter("@PlotNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtPlotNo.Text))
                };//ddl_ownerCategory.SelectedValue
                ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameters);

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on funSearch.", ex, "frmMembershipSearch");
                //frmobj.ShowDialog();
            }
            return ds;

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet ds = funSearch();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        txtFileNobyUser.Text = row["FileNo"].ToString();
                        PlotNoByUser.Text = row["PlotNo"].ToString();
                        txtmsno.Text = row["MembershipNo"].ToString();
                        txtname.Text = row["Name"].ToString();
                        cmbgender.Text = row["Gender"].ToString();
                        txtfather.Text = row["Father"].ToString();
                        txtnicnicop.Text = @row["NICNICOP"].ToString();
                        txtpermentaddress.Text = row["PrementAddress"].ToString();
                        txtpresentaddress.Text = row["PresentAddress"].ToString();
                        txtmobile.Text = row["MobileNo"].ToString();
                        txtemail.Text = row["Email"].ToString();
                        txtOtherMo.Text = row["OtherNo"].ToString();
                    }
                }
            }

        }
    }
}
