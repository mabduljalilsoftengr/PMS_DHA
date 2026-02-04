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
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Application
{
    public partial class frmApplicartionModify : RadForm
    {
        public frmApplicartionModify()
        {
            InitializeComponent();
        }
        #region no functionality present  for modify form  #ABR
        #endregion region

        #region design issue , the ^ button hides part of the form #ABR
        #endregion

        private void frmApplicartionModify_Load(object sender, EventArgs e)
        {
            try
            {
                radgdApplicant.MasterTemplate.Columns.Add(clsPluginHelper.GdButton("btnPersonal", "Personal_data", "Personal", "View"));//("Field Name","Name","Header Text","Button Text")
                radgdApplicant.MasterTemplate.Columns.Add(clsPluginHelper.GdButton("btnNextofKin", "NextofKin_data", "NextofKin", "View"));//("Field Name","Name","Header Text","Button Text")
                radgdApplicant.MasterTemplate.Columns.Add(clsPluginHelper.GdButton("btnDeposite", "Deposite_data", "Deposite", "View"));//("Field Name","Name","Header Text","Button Text")
                                                                                                                                               //radgdApplicant.MasterTemplate.Columns.Add(Helper.clsPluginHelper.GdButton("Category", "Category", "Category", "View"));//("Field Name","Name","Header Text","Button Text")
                BindApplicantInfoWithradGridView();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Load Method.", ex, "frmApplicationModify/frmApplicartionModify_Load");
                frmobj.ShowDialog();
            }

        }
       
        public static object DbNullIfNullOrEmpty(string str)
        {
            return !String.IsNullOrEmpty(str) ? str : (object)DBNull.Value;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindApplicantInfoWithradGridView();
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
                        string[] allrows = new string[] {Row["ID"].ToString(), Row["Name"].ToString(), Row["CNIC"].ToString(),Row["PassportNo"].ToString() , Row["PermentAddress"].ToString(), Row["Office"].ToString(), Row["Mobile"].ToString() };
                        radgdApplicant.Rows.Add(allrows);
                    }
                }
                else { 
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
                        //Clear The TextBoxes
                    //txtname.Text = "";
                    //txtnic.Text = "";
                    //txtoffice.Text = "";
                    //txtpassportno.Text = "";
                    //txtmobileno.Text = "";
                    //txtaddress.Text = "";
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
                frmExceptionCatched frmobj = new frmExceptionCatched("Binding of Applicant information with Gridview is failed.", ex, "frmApplicationModify/BindApplicantInfoWithradGridView");
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
                frmExceptionCatched frmobj = new frmExceptionCatched("Bind Applicant Info On DateS earch is failed.", ex, "frmApplicationModify/BindApplicantInfoOnDateSearch");
                frmobj.ShowDialog();

            }
        }

        private void radgdApplicant_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = radgdApplicant.CurrentCell.RowIndex;
                int columnindex = radgdApplicant.CurrentCell.ColumnIndex;
                if (e.Column.Name == "btnPersonal")
                {
                    int ID = int.Parse(radgdApplicant.Rows[rowindex].Cells[0].Value.ToString());
                    Application_Modify.frmModifyApplicantPersonal obj = new Application_Modify.frmModifyApplicantPersonal(ID);
                    obj.ShowDialog();
                    btnSearch_Click(null,null);

                    //radgdApplicant.DataSource = null;
                    // MessageBox.Show("BioInfo - > " + SearchDGV.Rows[rowindex].Cells[0].Value.ToString());
                }
                if (e.Column.Name == "btnNextofKin")
                {
                    int ID = int.Parse(radgdApplicant.Rows[rowindex].Cells[0].Value.ToString());
                    Application_Modify.frmModifyApplicant_NextOfKin obj = new Application_Modify.frmModifyApplicant_NextOfKin(ID);
                    obj.ShowDialog();
                    btnSearch_Click(null, null);
                    //radgdApplicant.DataSource = null;
                    // MessageBox.Show("Next of Kin - > " + SearchDGV.Rows[rowindex].Cells[0].Value.ToString());
                }
                if (e.Column.Name == "btnDeposite")
                {
                    int ID = int.Parse(radgdApplicant.Rows[rowindex].Cells[0].Value.ToString());
                    Application_Modify.frmModifyDeposite_Applicant obj = new Application_Modify.frmModifyDeposite_Applicant(ID);
                    obj.ShowDialog();
                    btnSearch_Click(null, null);
                    //MessageBox.Show("Family Detaill - > " + SearchDGV.Rows[rowindex].Cells[0].Value.ToString());
                }
                //if (e.Column.Name == "Category")
                //{
                //    int ID = int.Parse(radgdApplicant.Rows[rowindex].Cells[0].Value.ToString());
                //    //MSViewInfo.MSFamilyMember obj = new MSFamilyMember(ID);
                //    // obj.ShowDialog();
                //    //MessageBox.Show("Family Detaill - > " + SearchDGV.Rows[rowindex].Cells[0].Value.ToString());
                //}
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on radgdApplicant_CellClick.", ex, "frmApplicationModify/radgdApplicant_CellClick");
                frmobj.ShowDialog();

            }
        }
    }
}
