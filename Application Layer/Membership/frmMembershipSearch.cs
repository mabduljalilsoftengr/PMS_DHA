using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
//------------------------------------------
using PeshawarDHASW.Data_Layer;
using PeshawarDHASW.Models;
using PeshawarDHASW.Application_Layer.Membership;
using PeshawarDHASW.Application_Layer.Membership.MSViewInfo;
using PeshawarDHASW.Data_Layer.clsMemberShip;

using Telerik.WinControls.UI;
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.clsFileMap;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Application_Layer.Membership
{
    public partial class frmMembershipSearch : Telerik.WinControls.UI.RadForm
    {

        public frmMembershipSearch()
        {
            InitializeComponent();
        }

        public string MSNO { get; set; }
        public frmMembershipSearch(string MSNo)
        {
            InitializeComponent();
            MSNO = MSNo;
        }
        public DataSet dataset { get; set; }
        public DataSet dataset_sp { get; set; }


        private DataSet funSearch()
        {
            DataSet ds = new DataSet();
            string plotnotempty = "";
            try
            {
                if(!string.IsNullOrEmpty(txtPlotNo.Text))
                {
                    SqlParameter[] param = new[]
                    {
                     new SqlParameter("@Task","SelectFileNoFormPlotNo"),
                     new SqlParameter("@PlotNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtPlotNo.Text))
                    };
                    DataSet dst_ = cls_dl_Membership.Membership_PersonalInfo_Retrive(param);
                    if(dst_.Tables.Count > 0)
                    {
                        if (dst_.Tables[0].Rows.Count > 0)
                        {
                            txtfileno.Text = dst_.Tables[0].Rows[0]["FileNo"].ToString();
                        }
                        else
                        {
                            txtfileno.Text = "";
                            plotnotempty = Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtPlotNo.Text).ToString();
                        }
                    }
                    else
                    {
                        txtfileno.Text = "";
                        plotnotempty = Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtPlotNo.Text).ToString();
                    }
                    

                }

                this.SearchDGV.DataSource = null;
                int? OwnerCat = null;
                if (ddl_ownerCategory.SelectedIndex != -1)
                {
                    OwnerCat = (int)ddl_ownerCategory.SelectedValue;
                }




                if (string.IsNullOrEmpty((plotnotempty)))
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
                       // new SqlParameter("@PlotNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtPlotNo.Text)),
                       new SqlParameter("@OwnerCat",OwnerCat)
                    }; //ddl_ownerCategory.SelectedValue
                    ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameters);
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                        }
                        else
                        {
                            this.SearchDGV.DataSource = null;
                            MessageBox.Show("Data not found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }

                    }
                    else
                    {
                        this.SearchDGV.DataSource = null;
                        MessageBox.Show("Data not found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }


                }
                else
                {
                    MessageBox.Show("Data not found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }



            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on funSearch.", ex, "frmMembershipSearch");
                //frmobj.ShowDialog();
            }
            return ds;

        }

        private DataSet funSearchsp()
        {
            DataSet ds = new DataSet();
            try
            {
                this.SearchDGVsp.DataSource = null;
                int? OwnerCat = null;
                if (ddl_ownerCategorysp.SelectedIndex != -1)
                {
                    OwnerCat = (int)ddl_ownerCategorysp.SelectedValue;
                }
                SqlParameter[] paramete = new[]
                {
                    new SqlParameter("@Task","Select_sp"),
                    new SqlParameter("@FilePlotShopVillaApartmentNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtfilenosp.Text)),
                    new SqlParameter("@MembershipNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtmsnosp.Text)),
                    new SqlParameter("@NICNICOP",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtnicsp.Text)),
                    new SqlParameter("@Name",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtnamesp.Text)),
                    new SqlParameter("@MobileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtmobilesp.Text)),
                    new SqlParameter("@PersonalNoSvcPersOnly",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtPANosp.Text)),
                    new SqlParameter("@PlotNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtPlotNosp.Text)),
                    new SqlParameter("@OwnerCat",OwnerCat)
                };//ddl_ownerCategory.SelectedValue
                ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(paramete);

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on funSearch.", ex, "frmMembershipSearch");
                //frmobj.ShowDialog();
            }
            return ds;

        }
       

        private void DataLoadingtoGrid(DataSet ds,DataSet ds_sp)
        {

            if (SearchDGV.InvokeRequired && ds.Tables.Count > 0)
            {
                if(ds.Tables[0].Rows.Count > 0)
                {
                    SearchDGV.Invoke(new MethodInvoker(() => { SearchDGV.DataSource = ds.Tables[0].DefaultView; }));//or change here something in the underlay datasource
                }

            }
            else
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        SearchDGV.DataSource = ds.Tables[0].DefaultView;
                    }
                }
            }
            ////////////////////////////////////////////////////////////////
            if (SearchDGVsp.InvokeRequired && ds_sp.Tables.Count > 0)
            {
                if (ds_sp.Tables[0].Rows.Count > 0)
                {
                    SearchDGVsp.Invoke(new MethodInvoker(() => { SearchDGVsp.DataSource = ds_sp.Tables[0].DefaultView; }));//or change here something in the underlay datasource
                }
            }
            else
            {
                if (ds_sp.Tables.Count > 0)
                {
                    if (ds_sp.Tables[0].Rows.Count > 0)
                    {
                        SearchDGVsp.DataSource = ds_sp.Tables[0].DefaultView;
                    }
                }
               
            }

            //SearchDGV.BeginUpdate();
            //SearchDGV.DataSource = ds.Tables[0].DefaultView;
            //SearchDGV.EndUpdate();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //DataLoadingbar.Visible = true;
            //DataLoadingbar.StartWaiting();
            btnSearch.Enabled = false;
            dataset = funSearch();
            LoadingData.RunWorkerAsync();

        }
        private void Filddl_ownerCategory()
        {
            try
            {
                SqlParameter[] par =
                {
                new SqlParameter("@Task","Select"),
                };
                DataSet ds = new DataSet();
                ds = cls_dl_FileMap.Fil_ddl_Owner_Category(par);
                ////////////// Bind Data With  ddl_ownerCategory
                ddl_ownerCategory.DataSource = ds.Tables[0].DefaultView;
                ddl_ownerCategory.ValueMember = "OCID";
                ddl_ownerCategory.DisplayMember = "Category_Name";
                ddl_ownerCategory.SelectedIndex = -1;
                ////////////// Bind Data With  ddl_ownerCategorysp
                ddl_ownerCategorysp.DataSource = ds.Tables[0].DefaultView;
                ddl_ownerCategorysp.ValueMember = "OCID";
                ddl_ownerCategorysp.DisplayMember = "Category_Name";
                ddl_ownerCategorysp.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Filddl_ownerCategory.", ex, "frmCreateFileNoRPlot");
                frmobj.ShowDialog();
            }


        }

        private void frmMembershipSearch_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            if(clsUser.ID != 3 && clsUser.ID != 35)
            {
                tabcntrlMembershipData.TabPages.Remove(tabHighAuthorityPurpose);
            }
            //DataLoadingbar.Visible = true;
            //DataLoadingbar.StartWaiting();
            dataset = funSearch();
            dataset_sp = funSearchsp();
            Filddl_ownerCategory();
            LoadingData.RunWorkerAsync();
        }

        private void SearchDGV_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {

                if (e.Column.Name == "Bioinfo")
                {
                    int ID = int.Parse(e.Row.Cells["ID"].Value.ToString());
                    MSViewInfo.MSBioInfo obj = new MSViewInfo.MSBioInfo(ID, false);
                    obj.Show();

                }
                if (e.Column.Name == "nexkofkin")
                {
                    int ID = int.Parse(e.Row.Cells["ID"].Value.ToString());
                    MSViewInfo.MSNextofkininfo obj = new MSNextofkininfo(ID);
                    obj.Show();

                }
                if (e.Column.Name == "familyDetail")
                {
                    int ID = int.Parse(e.Row.Cells["ID"].Value.ToString());
                    MSViewInfo.MSFamilyMember obj = new MSFamilyMember(ID);
                    obj.Show();

                }
                if (e.Column.Name == "ImageView")
                {
                    int ID = int.Parse(e.Row.Cells["ID"].Value.ToString());
                    MSImage.frmMSImage obj = new MSImage.frmMSImage(ID);
                    obj.Show();
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on SearchDGV_CellClick.", ex, "frmMembershipSearch");
                //frmobj.ShowDialog();
            }
        }

        #region Date Wise Search
        private void DateWiseSearch()
        {
            //    try
            //    {
            //        SqlParameter[] parameters =
            //                   {
            //        new SqlParameter("@Task","PeriodSearch"),
            //        new SqlParameter("@StartDateSearch",dtpstartDate.Value.Date) ,
            //        new SqlParameter("@EndDateSearch",dtpendDate.Value.Date),
            //    };
            //        DataSet ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameters);

            //        SearchDGV.DataSource = ds.Tables[0].DefaultView;
            //    }
            //    catch (Exception ex)
            //    {
            //        frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnperiodsearch_Click.", ex, "frmMembershipSearch");
            //        frmobj.ShowDialog();
            //    }
        }
        #endregion

        private void btnperiodsearch_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Helper.clsPluginHelper.GridViewData_Export_to_Excel(SearchDGV);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Kindly Install the Third Software First.\n Error -> \n" + ex.Message);
            //}

        }

        private void LoadingData_DoWork(object sender, DoWorkEventArgs e)
        {
            DataSet nulldst = new DataSet();
            DataLoadingtoGrid(dataset, nulldst);
            DataLoadingtoGrid(nulldst,dataset_sp);
        }

        private void LoadingData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                MessageBox.Show("Operation was canceled");
            else if (e.Error != null)
                MessageBox.Show(e.Error.Message);
            else
            {
                //DataLoadingbar.Visible = false;
                //DataLoadingbar.StopWaiting();
                btnSearch.Enabled = true;
                btnSearchsp.Enabled = true;
                clsPluginHelper.GridColumnBestFit(SearchDGV);
                clsPluginHelper.GridColumnBestFit(SearchDGVsp);

            }
            //  // richTextBox1.Text += "I was doing some work in the background.";
        }

        private void txtfileno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSearch_Click(null, null);
            }
        }

        private void btnSearchsp_Click(object sender, EventArgs e)
        {
            //DataLoadingbar.Visible = true;
            //DataLoadingbar.StartWaiting();
            btnSearchsp.Enabled = false;
            dataset_sp = funSearchsp();
            LoadingData.RunWorkerAsync();
        }

        private void btnperiodsearchsp_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(SearchDGVsp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void frmMembershipSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }

        private void txtPlotNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSearch.PerformClick();
            }
        }

        private void txtPANo_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13)
            {
                btnSearch.PerformClick();
            }
        }

        private void txtmobile_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13)
            {
                btnSearch.PerformClick();
            }
        }

        private void txtmsno_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13)
            {
                btnSearch.PerformClick();
            }
        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13)
            {
                btnSearch.PerformClick();
            }
        }

        private void txtnic_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13)
            {
                btnSearch.PerformClick();
            }
        }
    }
}
