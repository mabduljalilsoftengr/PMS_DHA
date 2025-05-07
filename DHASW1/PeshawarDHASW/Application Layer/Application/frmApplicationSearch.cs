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
    public partial class frmApplicationSearch : Telerik.WinControls.UI.RadForm
    {
        #region Nofunctionality in Search Form  #ABR

        #endregion

        public frmApplicationSearch()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindApplicantInfoWithradGridView();
        }
        public static object DbNullIfNullOrEmpty(string str)
        {
            return !String.IsNullOrEmpty(str) ? str : (object)DBNull.Value;
        }
        private void BindApplicantInfoWithradGridView()
        {
            try
            {
                this.radgdApplicant.Rows.Clear();
                if (txtname.Text == string.Empty & txtnic.Text == string.Empty & txtoffice.Text == string.Empty & txtaddress.Text == string.Empty & txtpassportno.Text == string.Empty & txtmobileno.Text == string.Empty)
                {
                    SqlParameter[] param =
                    {
                        new SqlParameter("@Task","ApplicantAllDataRetrieve")
                    };
                    DataSet ds = cls_dl_Application.ApplicantInfoAllDataRetrive(param);
                    DataTable dt = ds.Tables[0];
                    foreach (DataRow Row in dt.Rows)
                    {
                        string[] allrows = new string[] { Row["ID"].ToString(), Row["Name"].ToString(), Row["CNIC"].ToString(), Row["PassportNo"].ToString(), Row["PermentAddress"].ToString(), Row["Office"].ToString(), Row["Mobile"].ToString() };
                        radgdApplicant.Rows.Add(allrows);
                    }
                }
                else
                {
                    SqlParameter[] parameter = new[]
                        {
                        new SqlParameter("@Task", "ApplicantSearch"),
                        new SqlParameter("@Name", DbNullIfNullOrEmpty(txtname.Text)),
                        new SqlParameter("@NIC", DbNullIfNullOrEmpty(txtnic.Text)),
                        new SqlParameter("@OfficeNo",DbNullIfNullOrEmpty(txtoffice.Text)),
                        new SqlParameter("@Address", DbNullIfNullOrEmpty(txtaddress.Text)),
                        new SqlParameter("@PassportNo", DbNullIfNullOrEmpty(txtpassportno.Text)),
                        new SqlParameter("@Mobile", DbNullIfNullOrEmpty(txtmobileno.Text)),
                    };
                    DataSet ds = cls_dl_Application.Applicant_Info_Retrive(parameter);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow Row in ds.Tables[0].Rows)
                        {
                            string[] allrows = new string[] { Row["ID"].ToString(), Row["Name"].ToString(), Row["CNIC"].ToString(), Row["PassportNo"].ToString(), Row["PermentAddress"].ToString(), Row["Office"].ToString(), Row["Mobile"].ToString() };
                            radgdApplicant.Rows.Add(allrows);
                        }
                    }
                    else
                    {
                        //btnSave.Visible = false;
                        //gbimage.Visible = false;
                        //ImageSource.Visible = false;

                    }
                }
            }
            catch (Exception ex)
            {

                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Bind Applicant Info With radGridView.", ex, "frmApplicationSearch/BindApplicantInfoWithradGridView");
                frmobj.ShowDialog();
            }
        }

        private void btndatesearch_Click(object sender, EventArgs e)
        {
            BindApplicantInfoOnDateSearch();
        }
        private void BindApplicantInfoOnDateSearch()
        {
            try
            {
                this.radgdApplicant.Rows.Clear();

                SqlParameter[] parameter =
                {
                        new SqlParameter("@Task", "ApplicantSearchOnDate"),
                        new SqlParameter("@FromDate", clsPluginHelper.DbNullIfNullOrEmpty(dtpFromDate.Text)),
                        new SqlParameter("@ToDate", clsPluginHelper.DbNullIfNullOrEmpty(dtpToDate.Text))
                    };
                DataSet ds = cls_dl_Application.Applicant_Info_Retrive(parameter);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow Row in ds.Tables[0].Rows)
                    {
                        string[] allrows = new string[] { Row["ID"].ToString(), Row["Name"].ToString(), Row["CNIC"].ToString(), Row["PassportNo"].ToString(), Row["PermentAddress"].ToString(), Row["Office"].ToString(), Row["Mobile"].ToString() };
                        radgdApplicant.Rows.Add(allrows);
                    }
                }
                else
                {
                    //btnSave.Visible = false;
                    //gbimage.Visible = false;
                    //ImageSource.Visible = false;

                }

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Bind Applicant Info On Date Search.", ex, "frmApplicationSearch/BindApplicantInfoOnDateSearch");
                frmobj.ShowDialog();

            }
        }

        private void frmApplicationSearch_Load(object sender, EventArgs e)
        {
            BindApplicantInfoWithradGridView();
        }

        private void frmApplicationSearch_Load_1(object sender, EventArgs e)
        {

        }
    }
}
