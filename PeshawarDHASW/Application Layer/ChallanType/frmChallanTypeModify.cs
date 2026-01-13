using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsChallanType;
using PeshawarDHASW.Data_Layer.clsErrorLog;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Models;
using Telerik.WinControls;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.ChallanType
{
    public partial class frmChallanTypeModify : Telerik.WinControls.UI.RadForm
    {
        public frmChallanTypeModify()
        {
            InitializeComponent();
        }

        private void frmChallanTypeModify_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            radmodify.MasterTemplate.Columns.Add( clsPluginHelper.GdButton("Challan", "Challan", "Modify", "View", 80));
        }

        private void searchingchallantype()
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task", "Select"),
                    new SqlParameter("@ChallanType", txttype.Text),
                    new SqlParameter("@Description", txtdescp.Text),
                    new SqlParameter("@Remarks", txtremarks.Text),
                    new SqlParameter("@Status", dpstatus.Text),
                };
                DataSet ds = cls_dl_ChallanType.Challan_Reader(parameters, "App.USP_tbl_ChallanType");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    radmodify.DataSource = ds.Tables[0].DefaultView;
                }
                else
                {
                    MessageBox.Show("Contact to Administrator");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on searchingchallantype.", ex, "frmChallanTypeModify");
                frmobj.ShowDialog();
            }
        }
  
        private void btnsearch_Click(object sender, EventArgs e)
        {
            searchingchallantype();
        }

        private void radmodify_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {

                if (e.Column.Name == "Challan")
                {
                    int ID = 0;
                    bool M = int.TryParse(radmodify.CurrentRow.Cells[0].Value.ToString(), out ID);
                    if (M != false)
                    {
                        frmChallanTypeCreate obj = new frmChallanTypeCreate(ID);
                        obj.ShowDialog();
                        searchingchallantype();
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
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on radmodify_CellClick.", ex, "frmChallanTypeModify");
                frmobj.ShowDialog();
            }
        }
    }
}
