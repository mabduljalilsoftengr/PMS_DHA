using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Installment.Reminder
{
    public partial class frmReminderDuesAndSurcharge : Telerik.WinControls.UI.RadForm
    {
        public frmReminderDuesAndSurcharge()
        {
            InitializeComponent();
        }
        private  DataSet dst { get; set; }
        private void btnReport_Click(object sender, EventArgs e)
        {
            if(dst.Tables.Count > 0)
            {
                if(dst.Tables[0].Rows.Count > 0)
                {
                    dst.Tables[0].Rows.Clear();
                }
            }
            
            btnShowDataInGrid_Click(sender,e);

            //MessageBox.Show(dst.Tables[0].Rows.Count.ToString());

            if (dst.Tables.Count > 0)
            {
                if (dst.Tables[0].Rows.Count > 0)
                {
                    frmReportViewer frm = new frmReportViewer(dst);
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No data found.");
                }
            }
            else
            {
                MessageBox.Show("No data found.");
            }
          
        }

        private void btnDataReadyForSMS_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] par = {
                                     new SqlParameter("@Task","FineRemDueSurchargeForSMS"),
                                     new SqlParameter("@CurrentDate",dtpcurrentdate.Value.Date),
                                     new SqlParameter("@Is_SMS_Letter","Letter")
                                 };
               DataSet dst = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(),
                                                       CommandType.StoredProcedure,
                                                       "App.tbl_SMSSendingLog2",
                                                       par);
               if(dst.Tables.Count > 0)
               {
                  if(dst.Tables[0].Rows.Count > 0)
                    {
                        if(dst.Tables[0].Rows[0]["Remarks"].ToString() == "Calculation for this Date is already exist.Please Get it from Database.")
                        {
                            MessageBox.Show("Calculation for this Date is already exist.Please Get it from Database.");
                        }
                    }
               }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnShowDataInGrid_Click(object sender, EventArgs e)
        {
            SqlParameter[] par = {
                                     new SqlParameter("@Task","ShowDataInGridForADCLetters"),
                                     // new SqlParameter("@Task","ShowDataInGridForSMS"),
                                     new SqlParameter("@CurrentDate",dtpcurrentdate.Value.Date)
                                 };
            dst = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(),
                                                  CommandType.StoredProcedure,
                                                  "App.tbl_SMSSendingLog",
                                                  par);
            //MessageBox.Show(dst.Tables[0].Rows.Count.ToString());
            grdDataReady.DataSource = dst.Tables[0].DefaultView;
        }

        private void frmReminderDuesAndSurcharge_Load(object sender, EventArgs e)
        {

        }
    }
}
