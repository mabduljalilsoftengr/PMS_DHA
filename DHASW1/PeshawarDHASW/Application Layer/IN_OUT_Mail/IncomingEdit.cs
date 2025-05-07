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

namespace PeshawarDHASW.Application_Layer.IN_OUT_Mail
{
    public partial class IncomingEdit : Telerik.WinControls.UI.RadForm
    {
        public IncomingEdit()
        {
            InitializeComponent();
        }
        public IncomingEdit(string DiaryNo)
        {
            InitializeComponent();
            DataViewing(DiaryNo);
        }
        private void IncomingEdit_Load(object sender, EventArgs e)
        {

        }

        private void DataViewing(string DiaryNo)
        {
            SqlParameter[] param = {
                new SqlParameter("@Task","IncomingMailSingle"),
                  new SqlParameter("@DiaryNo",DiaryNo)
            };
            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.Incoming_mail", param);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblDiaryNo.Text = ds.Tables[0].Rows[0]["DiaryNo"].ToString();
                    txtLetterNo.Text = ds.Tables[0].Rows[0]["LtrNo"].ToString();
                    dtpReceiveDate.Value = DateTime.Parse(ds.Tables[0].Rows[0]["ReceivedDate"].ToString());
                    txtLetterName.Text = ds.Tables[0].Rows[0]["Date_FileNo"].ToString();
                    txtFromWhomReceived.Text = ds.Tables[0].Rows[0]["FromWhomReceived"].ToString();
                    txtSubject.Text = ds.Tables[0].Rows[0]["Subj"].ToString();
                    txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                }
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLetterNo.Text))
            {
                MessageBox.Show("Receive Date is Mandatory.");
                return;
            }
            if (dtpReceiveDate.Value.Date == null)
            {
                MessageBox.Show("Receive Date is Mandatory.");
                return;
            }
            SqlParameter[] param = {
                    new SqlParameter("@Task","IncomingMailInsert"),
                    new SqlParameter("@DiaryNo",lblDiaryNo.Text),
                    new SqlParameter("@ReceivedDate",dtpReceiveDate.Value.Date),
                    new SqlParameter("@LtrNo",txtLetterNo.Text),
                    new SqlParameter("@Date_FileNo",txtLetterName.Text),
                    new SqlParameter("@FromWhomReceived",txtFromWhomReceived.Text),
                    new SqlParameter("@Subj",txtSubject.Text),
                    new SqlParameter("@Remarks",txtRemarks.Text),
                    new SqlParameter("@Createdby",clsUser.ID),
                    new SqlParameter("@CreatedDate",DateTime.Now),
                    new SqlParameter("@Status","Active"),
                };
            string IncomingID = Helper.SQLHelper.ExecuteScalar(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.Incoming_mail", param).ToString();

        }
    }
}
