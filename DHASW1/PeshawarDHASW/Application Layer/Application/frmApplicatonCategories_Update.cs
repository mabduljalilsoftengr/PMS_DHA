using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.clsApplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Models;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Application
{
    public partial class frmApplicatonCategories_Update : Telerik.WinControls.UI.RadForm
    {
        public frmApplicatonCategories_Update()
        {
            InitializeComponent();
        }
        public int Get_Id { get; set; }
        public frmApplicatonCategories_Update(int getid)
        {
            InitializeComponent();
            Get_Id = getid ;
        }

        private void frmApplicatonCategories_Update_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            BindCategoryDataToGrid();
        }
        private void BindCategoryDataToGrid()
        {
            try
            {
                SqlParameter[] param =
                           {
                new SqlParameter("@Task","CategoryDataRetriveForUpdate"),
                new SqlParameter("@id",Get_Id)
            };
                DataSet ds = new DataSet();
                ds = cls_dl_Application.CategorySearchByID(param);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drw in ds.Tables[0].Rows)
                    {
                        txtCategory.Text = drw["Categories"].ToString();
                        txtQuota.Text = drw["Quota"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on BindCategoryDataToGrid.", ex, "frmApplicationCategories_Update");
                frmobj.ShowDialog();

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveCategory();
        }
        private void SaveCategory()
        {
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@Task","Update"),
                    new SqlParameter("@category",txtCategory.Text),
                    new SqlParameter("@quota",txtQuota.Text),
                    new SqlParameter("@id",Get_Id)
                };
                int result = 0;
                result = cls_dl_Application.UpdateCategory(param);
                if(result > 0)
                {
                    MessageBox.Show("Category Updated Successfully.");
                    this.Close();
                }
                else
                {

                    MessageBox.Show("Try again Please !!!");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on SaveCategory.", ex, "frmApplicationCategories_Update");
                frmobj.ShowDialog();
            }
        }
    }
}
