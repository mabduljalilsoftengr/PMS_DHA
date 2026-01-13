using PeshawarDHASW.Data_Layer.clsFileMap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.FileMap.ByBack
{
    public partial class frmQuotaAddofAll_And_ByBackRawLandWise : Telerik.WinControls.UI.RadForm
    {
        public frmQuotaAddofAll_And_ByBackRawLandWise()
        {
            InitializeComponent();
        }

        private void frmQuotaAddofAll_And_ByBackRawLandWise_Load(object sender, EventArgs e)
        {
            GetLandProviders();
            txtcheckno.Enabled = false;
            txtamount.Enabled = false;
            txtcheckno.Text = "0";
            txtamount.Text = "0";
        }
        private void GetLandProviders()
        {
            RadListDataItem Select = new RadListDataItem();
            Select.Value = 0;
            Select.Text = "-- Select --";
            this.ddlLandProviders.Items.Add(Select);
            SqlParameter[] param =
            {
               new SqlParameter("@Task", "LoadAllLandProviders")
            };

            foreach (DataRow row in cls_dl_FileMap.Main_FileMap_Reader(param).Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["LPID"].ToString();
                dataItem.Text = row["Name"].ToString();
                this.ddlLandProviders.Items.Add(dataItem);
            }
            ddlLandProviders.SelectedIndex = 0;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string isnwwqtabyback = rdbnewquota.IsChecked ? rdbnewquota.Text : rdbbyback.Text;
            string flisurwlnd = rdbrawland.IsChecked ? rdbrawland.Text : rdbfileissuedland.Text;
            string sts = rdbnewquota.IsChecked ? "Approved" : "Pending";
            decimal nwqfiles = 0; decimal bybck = 0;
            if (rdbnewquota.IsChecked)
            {
                nwqfiles = decimal.Parse(txttotalfiles.Text);
                bybck = 0;
            }
            else if (rdbbyback.IsChecked)
            {
                bybck = decimal.Parse(txttotalfiles.Text);
                nwqfiles = 0;
            }
            SqlParameter[] par =
            {
                new SqlParameter("@Task", "Enter_RawFileDataForByBack"),
                new SqlParameter("@NewQuotaAdded",nwqfiles),
                new SqlParameter("@ByBackQuota",bybck),
                //new SqlParameter("@FileNo", txtFileNo.Text),
                //new SqlParameter("@Name", txtname.Text),
                //new SqlParameter("@CNIC", txtcnic.Text),
                //new SqlParameter("@MembershipNo", txtmsno.Text),
                new SqlParameter("@Amount", txtamount.Text),
                new SqlParameter("@CheckNo", txtcheckno.Text),
                new SqlParameter("@Remarks",txtremarks.Text),
                new SqlParameter("@LPID",ddlLandProviders.SelectedValue),
                new SqlParameter("@IsByBack_NewQuotaAdded",isnwwqtabyback),
                new SqlParameter("@Date",dtpdate.Value.Date),
                new SqlParameter("@Status",sts),
                new SqlParameter("@IsFilesIssued_RawLand",flisurwlnd)
            };
            int rslt = cls_dl_FileMap.Main_FileMap_NonQuery(par);
            if (rslt > 0)
            {
                MessageBox.Show("Successfull.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void rdbnewquota_CheckStateChanged(object sender, EventArgs e)
        {
            if (rdbnewquota.IsChecked)
            {
                txtcheckno.Enabled = false;
                txtamount.Enabled = false;
                txtcheckno.Text = "0";
                txtamount.Text = "0";
            }
            else if (rdbbyback.IsChecked)
            {
                txtcheckno.Enabled = true;
                txtamount.Enabled = true;
            }
        }

        private void rdbbyback_CheckStateChanged(object sender, EventArgs e)
        {
            
            if (rdbbyback.IsChecked)
            {
                txtcheckno.Enabled = true;
                txtamount.Enabled = true;
            }
            else if(rdbnewquota.IsChecked)
            {
                txtcheckno.Enabled = false;
                txtamount.Enabled = false;
                txtcheckno.Text = "0";
                txtamount.Text = "0";
            }
        }
    }
}
