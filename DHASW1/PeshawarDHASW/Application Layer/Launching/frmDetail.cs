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
    public partial class frmDetail : Telerik.WinControls.UI.RadForm
    {
        public frmDetail()
        {
            InitializeComponent();
        }

        private void frmDetail_Load(object sender, EventArgs e)
        {
          
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] ApplicantInfo =
                {
                   new SqlParameter("@InsertTime",dtprequireddate.Value.Date)
                };


                DataSet dst = SQLHelper.ExecuteDataset(
                                                SQLHelper.createConnection(),
                                                CommandType.StoredProcedure, "Launching.p_Gettbl_TotalOnlineAndOfflineRecord",
                                                ApplicantInfo);

                lblTotalOfflineForms.Text = dst.Tables[0].Rows[0]["TotalOfflineForms"].ToString();
                lblOfflineFormPayReceived.Text = dst.Tables[1].Rows[0]["OfflineFormPayReceived"].ToString();
                lblOfflineFormExistPayNotExist.Text = dst.Tables[2].Rows[0]["OfflineFormExistPayNotExist"].ToString();

                lbltotalofflinePayments.Text = dst.Tables[3].Rows[0]["TotalOfflinePayments"].ToString();
                lblOfflinePayAndFormExist.Text = dst.Tables[4].Rows[0]["OfflinePayAndFormExist"].ToString();
                lblOfflinePayExistButFormNotExist.Text = dst.Tables[5].Rows[0]["OfflinePayExistButFormNotExist"].ToString();

                lblTotalOnlinePayments.Text = dst.Tables[6].Rows[0]["TotalOnlinePayments"].ToString();
                lblOnlinePayAndHardFormExist.Text = dst.Tables[7].Rows[0]["OnlinePayAndHardFormExist"].ToString();
                lblOnlinPaymentExistButHardFormNotExist.Text = dst.Tables[8].Rows[0]["OnlinPaymentExistButHardFormNotExist"].ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnLoadDataCount_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] ApplicantInfo =
                           {
                new SqlParameter("@Task","UserFormsEntryCount"),
                new SqlParameter("@InsertTime",dtpdateofcurrent.Value.Date),
                new SqlParameter("@UserName",drpusername.SelectedItem.ToString())
                };


                DataSet dst = SQLHelper.ExecuteDataset(
                                                SQLHelper.createConnection(),
                                                CommandType.StoredProcedure, "Launching.CommercialLaunching",
                                                ApplicantInfo);
                grdDataShow.DataSource = dst.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
