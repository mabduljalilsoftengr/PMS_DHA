using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.clsApplication;
using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PeshawarDHASW.Application_Layer.Application
{
    public partial class frmApplicatonCategories :Telerik.WinControls.UI.RadForm
    {
        public frmApplicatonCategories()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] param =
                {
                  new SqlParameter("@Task","Insert"),
                  new SqlParameter("@category",txtCategory.Text),
                  new SqlParameter("@quota",txtQuota.Text),
                  new SqlParameter("@userid",Models.clsUser.ID)
                };
                int result = 0;
                result = cls_dl_Application.Category_Insert(param);
                if(result > 0)
                {
                    MessageBox.Show("Category Inserted Successfully.");
                    BindCategoryData();
                }
                else
                {
                    MessageBox.Show("Try again Please !!!");
                }
            }
            catch(Exception ex)
            {

                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnSave_Click.", ex, "frmApplicationCategories");
                frmobj.ShowDialog();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindCategoryData();
        }
        private void BindCategoryData()
        {
            try
            {
                this.grdCategoryInfo.Rows.Clear();
                if (txtCategorySearch.Text == string.Empty)
                {
                    SqlParameter[] parm =
                    {
                        new SqlParameter("@Task","CategoryAllData")
                    };
                    DataSet ds = new DataSet();
                    ds = cls_dl_Application.CategoryAllData_Retrieve(parm);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow rw in ds.Tables[0].Rows)
                        {
                            string[] Rows_All = new string[]
                            {
                                rw["ID"].ToString(),
                                rw["Categories"].ToString(),
                                rw["Quota"].ToString()

                            };
                            grdCategoryInfo.Rows.Add(Rows_All);
                        }
                    }
                }
                else
                {
                    SqlParameter[] parm =
                   {
                        new SqlParameter("@Task","CategorySearch_Data"),
                        new SqlParameter("@category",txtCategorySearch.Text)
                    };
                    DataSet ds = new DataSet();
                    ds = cls_dl_Application.CategorySearchData_Retrieve(parm);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow rw in ds.Tables[0].Rows)
                        {
                            string[] Rows_All = new string[]
                            {
                                rw["ID"].ToString(),
                                rw["Categories"].ToString(),
                                rw["Quota"].ToString()

                            };
                            grdCategoryInfo.Rows.Add(Rows_All);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Bind Category Data.", ex, "frmApplicationCategories/BindCategoryData");
                frmobj.ShowDialog();

            }
        }
        private void frmApplicatonCategories_Load(object sender, EventArgs e)
        {
            try
            {
                grdCategoryInfo.MasterTemplate.Columns.Add(clsPluginHelper.GdButton("Modify", "Modify", "Action", "Modify"));//("Field Name","Name","Header Text","Button Text")
                BindCategoryData();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmApplicatonCategories_Load.", ex, "frmApplicationCategoriesn/frmApplicatonCategories_Load");
                frmobj.ShowDialog();

            }

        }

        private void grdCategoryInfo_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = grdCategoryInfo.CurrentCell.RowIndex;
                int columnindex = grdCategoryInfo.CurrentCell.ColumnIndex;
                int CatID = int.Parse(grdCategoryInfo.Rows[rowindex].Cells[0].Value.ToString());
                Application.frmApplicatonCategories_Update obj = new Application.frmApplicatonCategories_Update(CatID);
                obj.ShowDialog();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on grdCategoryInfo_CellClick.", ex, "frmApplicationCategories/grdCategoryInfo_CellClick");
                frmobj.ShowDialog();

            }


        }
    }
}
