using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Launching
{
    public partial class ApplicaitonModificaiton : Telerik.WinControls.UI.RadForm
    {
        public ApplicaitonModificaiton()
        {
            InitializeComponent();
            DataLoading();
        }

        private void DataLoading()
        {
            SqlParameter[] param = {
                new SqlParameter("@ApplicantName", Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtApplicantName.Text)),
                new SqlParameter("@CNIC_NICOP",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtCNIC.Text)),
                new SqlParameter("@MobileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtMobile.Text)),
                new SqlParameter("@FormNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtFormNo.Text)),
                new SqlParameter("@District",Helper.clsPluginHelper.DbNullIfNullOrEmpty(ApplicantDistrict.Text)),
                new SqlParameter("@Country",Helper.clsPluginHelper.DbNullIfNullOrEmpty(ApplicantCountry.Text)),
                new SqlParameter("@Gender",Helper.clsPluginHelper.DbNullIfNullOrEmpty(ApplicationGender.Text)),
                new SqlParameter("@Province",Helper.clsPluginHelper.DbNullIfNullOrEmpty(cbProvince.Text)),
                new SqlParameter("@Category",Helper.clsPluginHelper.DbNullIfNullOrEmpty(cbCategory.Text))
                
            };
            DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "Launching.p_Gettbl_ApplicationInfo", param);
            DGV_ApplicantSearch.DataSource = ds.Tables[0].DefaultView;
            foreach (var item in DGV_ApplicantSearch.Columns)
            {
                item.BestFit();
            }
        }

        private void DataLoadingDate()
        {
            SqlParameter[] param = 
            {
                new SqlParameter("@FromDate",dtprfrom.Value.Date),
                new SqlParameter("@ToDate",dtprto.Value.Date)
            };
            DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "Launching.p_Gettbl_ApplicationInfoFilterByDate", param);
            DGV_ApplicantSearch.DataSource = ds.Tables[0].DefaultView;
            foreach (var item in DGV_ApplicantSearch.Columns)
            {
                item.BestFit();
            }
        }

        private void btnSearchRecord_Click(object sender, EventArgs e)
        {
            if (chkDate.CheckState == CheckState.Checked)
            {
                DataLoadingDate();
            }
            else if(chkDate.CheckState == CheckState.Unchecked)
            {
                DataLoading();
            }
            
        }

        private void DGV_ApplicantSearch_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "Edit")
                {
                    int applicaitonID = int.Parse(e.Row.Cells["ApplicationID"].Value.ToString());
                    ApplicationRecordModify obj = new ApplicationRecordModify(applicaitonID,"ScrutinyCompleted");
                    obj.ShowDialog();
                    DataLoading();
                }
            }
            catch (Exception)
            {

            }
           
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(DGV_ApplicantSearch);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Software First.\n Error -> \n" + ex.Message);
            }
        }

        private void ApplicaitonModificaiton_Load(object sender, EventArgs e)
        {
            btnProcessforback.Enabled = false;
            btnObservationforback.Enabled = false;
        }

        private void btnsearchforback_Click(object sender, EventArgs e)
        {


            SqlParameter[] param =
            {
                new SqlParameter("@Task","FindFormForSendBack"),
                new SqlParameter("@FormNo",txtformforback.Text)
            };
            DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "Launching.CommercialLaunching", param);
            if(ds.Tables.Count > 0)
            {
                if(ds.Tables[0].Rows.Count > 0)
                {
                    lblforstatusback.Text = ds.Tables[0].Rows[0]["ApplicationStatus"].ToString();


                }
                else
                {
                    lblforstatusback.Text = "";
                }
            }
            else
            {
                lblforstatusback.Text = "";
            }
            
            if (lblforstatusback.Text != "")
            {
                btnProcessforback.Enabled = true;
                btnObservationforback.Enabled = true;

            }


        }

        private void btnProcessforback_Click(object sender, EventArgs e)
        {
            try
            {

            
            if (lblforstatusback.Text != "ValidForBalloting" && lblforstatusback.Text != "Fee-Received")
            {
                SqlParameter[] param =
                {
                new SqlParameter("@Task","UpdateFormStatusForSendBack"),
                new SqlParameter("@FormNo",txtformforback.Text),
                new SqlParameter("@ApplicationStatus","Pending")
                };
                int rslt = SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(), CommandType.StoredProcedure, "Launching.CommercialLaunching", param);
                if (rslt > 0)
                {
                    MessageBox.Show("Successfull.");
                    btnProcessforback.Enabled = false;
                    btnObservationforback.Enabled = false;
                    btnSearchRecord_Click(sender, e);
                    txtformforback.Text = "";
                    lblforstatusback.Text = "#";
                }
            }
            else
            {
                    //int applicaitonID = int.Parse(e.Row.Cells["ApplicationID"].Value.ToString());
                    //ApplicationRecordModify obj = new ApplicationRecordModify(applicaitonID, "ScrutinyCompleted");
                    //obj.ShowDialog();
                    //DataLoading();

                    MessageBox.Show("Sorry ! Synched Data Couldn't be Modified.");
            }
          }
          catch (Exception ex )
          {
              MessageBox.Show(ex.Message);
          }
        }

        private void btnObservationforback_Click(object sender, EventArgs e)
        {
            try
            {


                if (lblforstatusback.Text != "ValidForBalloting" && lblforstatusback.Text != "Fee-Received")
                {

                SqlParameter[] param =
               {
                new SqlParameter("@Task","UpdateFormStatusForSendBack"),
                new SqlParameter("@FormNo",txtformforback.Text),
                new SqlParameter("@ApplicationStatus","Review")
                };
            int rslt = SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(), CommandType.StoredProcedure, "Launching.CommercialLaunching", param);
            if (rslt > 0)
            {
                MessageBox.Show("Successfull.");
                btnProcessforback.Enabled = false;
                btnObservationforback.Enabled = false;
                btnSearchRecord_Click(sender, e);
                txtformforback.Text = "";
                lblforstatusback.Text = "#";
            }
                }
                else
                {
                    MessageBox.Show("Sorry ! Synched Data Couldn't be Modified.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
