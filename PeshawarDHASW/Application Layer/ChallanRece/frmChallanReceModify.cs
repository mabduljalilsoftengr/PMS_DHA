using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Application_Layer.ChallanType;
using PeshawarDHASW.Application_Layer.Installment.InstReceive;
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
    public partial class frmChallanReceModify : Telerik.WinControls.UI.RadForm
    {
        public frmChallanReceModify()
        {
            InitializeComponent();
        }

        private void search()
        {
            try
            {

                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task","Select"),
                    new SqlParameter("@ChallanType",(typeofchallan.SelectedValue != "0"? typeofchallan.SelectedValue  :clsPluginHelper.DbNullIfNullOrEmpty(""))),
                    new SqlParameter("@NICNICOP",clsPluginHelper.DbNullIfNullOrEmpty( txtnic.Text)),
                    new SqlParameter("@Name",clsPluginHelper.DbNullIfNullOrEmpty( txtname.Text)),
                    new SqlParameter("@ChallanNo",clsPluginHelper.DbNullIfNullOrEmpty(txtChallanNo.Text)), 
                    new SqlParameter("@FileNo",clsPluginHelper.DbNullIfNullOrEmpty( txtfileno.Text)),
                    new SqlParameter("@Remarks",clsPluginHelper.DbNullIfNullOrEmpty( txtremarks.Text)),
                    new SqlParameter("@Amount",clsPluginHelper.DbNullIfNullOrEmpty( txtamount.Text)),
                };
                DataSet ds = cls_dl_ChallanRece.ChallanRece_Reader(parameters);
                ChallanReceDg.DataSource = ds.Tables[0].DefaultView;


            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on search.", ex, "frmChallanReceModify");
                frmobj.ShowDialog();

            }
        }
        private void btnsearch_Click(object sender, EventArgs e)
        {
            search();
        }

        private void frmChallanReceModify_Load(object sender, EventArgs e)
        {
            try
            {
                this.ThemeName = clsUser.ThemeName;
                ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
                ChallanReceDg.MasterTemplate.Columns.Add(clsPluginHelper.GdButton("Challan", "Challan", "Modify", "View", 80));
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
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmChallanReceModify_Load.", ex, "frmChallanReceModify");
                frmobj.ShowDialog();
            }
        }

        private void ChallanReceDg_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
               

                if (e.Column.Name == "Challan")
                {
                    int ID = 0;
                    bool M = int.TryParse(ChallanReceDg.CurrentRow.Cells[0].Value.ToString(), out ID);
                    if (M != false)
                    {
                        frmRecePayment obj = new frmRecePayment(0,ID);
                        obj.ShowDialog();                      
                        search();
                        //MessageBox.Show("ReceID - > " + ID.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Rece is not exist");
                    }
                }


            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on ChallanReceDg_CellClick.", ex, "frmChallanReceModify");
                frmobj.ShowDialog();
            }
        }
    }
}
