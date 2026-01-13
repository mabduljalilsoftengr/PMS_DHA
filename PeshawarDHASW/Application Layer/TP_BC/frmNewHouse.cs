using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.TP_BC
{
    public partial class frmNewHouse : Telerik.WinControls.UI.RadForm
    {
        public frmNewHouse()
        {
            InitializeComponent();
        }

        public frmNewHouse(string HouseID)
        {
            InitializeComponent();
            txtFileNo.Enabled = false;
            txtPlotNo.Enabled = false;
            btnFind.Enabled = false;
            GetDatabyHouseID(HouseID);
        }

        private void GetDatabyHouseID(string HouseID )
        {
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@Task","GetSinglebHouseID"),
                    new SqlParameter("@HouseID",HouseID)
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(),
                    CommandType.StoredProcedure, "App.USP_House", param);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblHouseID.Text = ds.Tables[0].Rows[0]["HouseID"].ToString();
                        lblFileMapKey.Text = ds.Tables[0].Rows[0]["FileMapKey"].ToString();
                        lblFileNo.Text = ds.Tables[0].Rows[0]["FileNo"].ToString();
                        lblPlotID.Text = ds.Tables[0].Rows[0]["PlotID"].ToString();
                        lblPlotNo.Text = ds.Tables[0].Rows[0]["PlotNo"].ToString();
                        lblSector.Text = ds.Tables[0].Rows[0]["Sector"].ToString();
                        lblPhase.Text = ds.Tables[0].Rows[0]["Phase"].ToString();
                        txtStreet.Text = ds.Tables[0].Rows[0]["Street"].ToString();
                        DateTime startDate = DateTime.Now;
                        bool StartDateParse = DateTime.TryParse(ds.Tables[0].Rows[0]["StartDateofConst"].ToString(), out startDate);
                        DateTime EndDate = DateTime.Now;
                        bool EndDateParse = DateTime.TryParse(ds.Tables[0].Rows[0]["EndDateofConst"].ToString(), out EndDate);
                        dtpconstStart.Value = startDate.Date;
                        dtpconstEnddate.Value = EndDate.Date;
                       // ConstStatus.Text = ds.Tables[0].Rows[0]["Status"].ToString();
                        Helper.clsPluginHelper.RadDropDownSelectByText(ConstStatus, ds.Tables[0].Rows[0]["Status"].ToString());
                        Helper.clsPluginHelper.RadDropDownSelectByText(cbFileStatus, ds.Tables[0].Rows[0]["FileStatus"].ToString());
                        //cbFileStatus.Text = ds.Tables[0].Rows[0]["FileStatus"].ToString();
                        txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("FileNo | Plot No is Invalid. ");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] duplicateparam =
              {
                    new SqlParameter("@Task","FilePlotDuplicateFind"),
                    new SqlParameter("@FileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtFileNo.Text)),
                    new SqlParameter("@PlotNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtPlotNo.Text))
                };
                DataSet dsDuplicate = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(),
                    CommandType.StoredProcedure, "App.USP_House", duplicateparam);
                if (dsDuplicate.Tables.Count > 0)
                {
                    if (dsDuplicate.Tables[0].Rows.Count > 0)
                    {
                        string ExistRecord = dsDuplicate.Tables[0].Rows[0]["ExistRecord"].ToString();
                        int Count = int.Parse(ExistRecord);
                        if (Count>0)
                        {
                            MessageBox.Show("File | Plot House Record is Already Exist.");
                            return;
                        }
                        else
                        {
                            SqlParameter[] param =
                             {
                                    new SqlParameter("@Task","NewRecordSearch"),
                                    new SqlParameter("@FileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtFileNo.Text)),
                                    new SqlParameter("@PlotNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtPlotNo.Text))
                                };
                            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_House", param);
                            if (ds.Tables.Count > 0)
                            {
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    lblFileMapKey.Text = ds.Tables[0].Rows[0]["FileMapKey"].ToString();
                                    lblFileNo.Text = ds.Tables[0].Rows[0]["FileNo"].ToString();
                                    lblPlotID.Text = ds.Tables[0].Rows[0]["PlotID"].ToString();
                                    lblPlotNo.Text = ds.Tables[0].Rows[0]["PlotNo"].ToString();
                                    lblSector.Text = ds.Tables[0].Rows[0]["Sector"].ToString();
                                    lblPhase.Text = ds.Tables[0].Rows[0]["Phase"].ToString();
                                }
                                else
                                {
                                    MessageBox.Show("FileNo | Plot No is Invalid. ");
                                }
                            }
                        }
                    }
                }


              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSavechanges_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblFileNo.Text == "-" || string.IsNullOrWhiteSpace(lblFileNo.Text))
                {
                    MessageBox.Show("FileNo | Plot No is Invalid");
                    return;
                }

   

                SqlParameter[] param =
                {
                    new SqlParameter("@Task","NewRecord"),
                    new SqlParameter("@HouseID",lblHouseID.Text),
                    new SqlParameter("@FileMapKey",lblFileMapKey.Text),
                    new SqlParameter("@FileNo",lblFileNo.Text),
                    new SqlParameter("@PlotID",lblPlotID.Text),
                    new SqlParameter("@PlotNo",lblPlotNo.Text),
                    new SqlParameter("@Sector",lblSector.Text),
                    new SqlParameter("@Phase",lblPhase.Text),
                    new SqlParameter("@Street",txtStreet.Text),
                    new SqlParameter("@StartDateofConst",dtpconstStart.Value.Date),
                    new SqlParameter("@EndDateofConst",string.IsNullOrWhiteSpace(dtpconstEnddate.Text)? Helper.clsPluginHelper.DbNullIfNullOrEmpty(""): dtpconstEnddate.Value.Date.ToString("yyyy-MM-dd")),
                    new SqlParameter("@STATUS",ConstStatus.SelectedItem.Text),
                    new SqlParameter("@FileStatus",cbFileStatus.SelectedItem.Text),
                    new SqlParameter("@Remarks",txtRemarks.Text),
                    new SqlParameter("@InsertBy",clsUser.ID),
                    new SqlParameter("@InsertDate",DateTime.Now.Date),
                    new SqlParameter("@UpdateBy",clsUser.ID),
                    new SqlParameter("@UpdateDate",DateTime.Now.Date)
                };
                int result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(),
                    CommandType.StoredProcedure, "App.USP_House", param);
                if (result>0)
                {
                    MessageBox.Show("Save Changes Successfull");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please Contact to IT Branch.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmNewHouse_Load(object sender, EventArgs e)
        {

        }
    }
}
