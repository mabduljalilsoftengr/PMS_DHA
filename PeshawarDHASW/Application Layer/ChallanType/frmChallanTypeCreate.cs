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
using PeshawarDHASW.Models;
using Telerik.WinControls;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.ChallanType
{
    public partial class frmChallanTypeCreate : Telerik.WinControls.UI.RadForm
    {
        public frmChallanTypeCreate()
        {
            InitializeComponent();
        }

        public int passID { get; set; } = 0;
        public frmChallanTypeCreate(int ID)
        {
            passID = ID;
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (passID == 0)
                {
                    SqlParameter[] parameters =
                    {
                        new SqlParameter("@Task", "Insert"),
                        new SqlParameter("@ChallanType", txttype.Text),
                        new SqlParameter("@Description", txtdescp.Text),
                        new SqlParameter("@Remarks", txtremarks.Text),
                        new SqlParameter("@Status", dpstatus.Text),
                    };
                    int result = cls_dl_ChallanType.Challan_NonQuery(parameters, "App.USP_tbl_ChallanType");
                    if (result > 0)
                    {
                        clearfunction();
                    }
                    else
                    {
                        MessageBox.Show("Contact to Administrator");
                    }
                }
                if (passID > 0)
                {
                    SqlParameter[] parameters =
                    {
                        new SqlParameter("@Task", "Update"),
                        new SqlParameter("@ChallanID",passID), 
                        new SqlParameter("@ChallanType", txttype.Text),
                        new SqlParameter("@Description", txtdescp.Text),
                        new SqlParameter("@Remarks", txtremarks.Text),
                        new SqlParameter("@Status", dpstatus.Text),
                    };
                    int result = cls_dl_ChallanType.Challan_NonQuery(parameters, "App.USP_tbl_ChallanType");
                    if (result > 0)
                    {
                        clearfunction();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Contact to Administrator");
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnsave_Click.", ex, "frmChallanTypeCreate");
                frmobj.ShowDialog();
            }
        }

        private void clearfunction()
        {
            txttype.Text = "";
            txtdescp.Text = "";
            txtremarks.Text = "";
            dpstatus.SelectedIndex = 0;
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            clearfunction();
        }

        private void frmChallanTypeCreate_Load(object sender, EventArgs e)
        {
            try
            {
                this.ThemeName = clsUser.ThemeName;
                ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
                if (passID>0)
                {
                    SqlParameter[] parameters =
                    {
                        new SqlParameter("@Task", "Select"),
                        new SqlParameter("@ChallanID", passID),
                    };
                    DataSet ds = cls_dl_ChallanType.Challan_Reader(parameters, "App.USP_tbl_ChallanType");
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        txttype.Text = row["ChallanType"].ToString();
                        txtdescp.Text = row["Description"].ToString();
                        txtremarks.Text = row["Remarks"].ToString();
                        dpstatus.Text = row["Status"].ToString();
                    }
                }
                
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmChallanTypeCreate_Load.", ex, "frmChallanTypeCreate");
                frmobj.ShowDialog();
            }
            
        }
    }
}
