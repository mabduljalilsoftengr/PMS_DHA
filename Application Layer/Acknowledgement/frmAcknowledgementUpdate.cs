using PeshawarDHASW.Application_Layer.Installment;
using PeshawarDHASW.Data_Layer.clsAcknowledgment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Acknowledgement
{
    public partial class frmAcknowledgementUpdate : Telerik.WinControls.UI.RadForm
    {
        public frmAcknowledgementUpdate()
        {
            InitializeComponent();
        }

        public string AckFin_ID { get; set; }
        public string Rece_ID { get; set; }
        public frmAcknowledgementUpdate(string AckFinID,string ReceID)
        {
            InitializeComponent();
            AckFin_ID = AckFinID;
            Rece_ID = ReceID;
        }

        private void frmAcknowledgementUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] parameter = {
                new SqlParameter("@Task","SelectInformationofAcknowledgementonbase"),
                new SqlParameter("@AckFinID",AckFin_ID),
                new SqlParameter("@ReceID",Rece_ID)
            };
                ds = cls_Fin_Acknowledgement.Fin_AcknowledgementDataRead(parameter);
                DpInstallmentList.DataSource = ds.Tables[1].DefaultView;
                DpInstallmentList.DisplayMember = "Descp";
                DpInstallmentList.ValueMember = "PlanID";

                lblFileNo.Text = ds.Tables[0].Rows[0]["FileNo"].ToString();
                lblDDno.Text = ds.Tables[0].Rows[0]["DDNo"].ToString();
                 Helper.clsPluginHelper.RadDropDownSelectedbyValue(DpInstallmentList,int.Parse( ds.Tables[0].Rows[0]["Plan_ID"].ToString()));
                int AmountValue = (int)Double.Parse(ds.Tables[0].Rows[0]["Amount"].ToString());
                lblAmount.Text = AmountValue.ToString();
                txtRemark.Text = ds.Tables[0].Rows[0]["Remark"].ToString();
                txtNote.Text = ds.Tables[0].Rows[0]["Note"].ToString();
                AckStatus.Text = ds.Tables[0].Rows[0]["StatusAck"].ToString();
                txtAmountinWords.Text = Helper.clsPluginHelper.Convert_Number_To_Text(AmountValue, false);
                //AckGDV.DataSource = ds.Tables[0].DefaultView;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnGenerateAck_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] parameter =
                                {
                    new SqlParameter("@Task","Update"),
                    new SqlParameter("@AckFinID",AckFin_ID),
                    new SqlParameter("@FileNo",lblFileNo.Text),
                    new SqlParameter("@PlanID",DpInstallmentList.SelectedValue),
                    new SqlParameter("@ReceID",int.Parse(Rece_ID)),
                    new SqlParameter("@userID",Models.clsUser.ID),
                    new SqlParameter("@Remark",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtRemark.Text)),
                    new SqlParameter("@Note",Helper.clsPluginHelper.DbNullIfNullOrEmpty( txtNote.Text)),
                    new SqlParameter("@AmountInword",txtAmountinWords.Text),
                    new SqlParameter("@Status",AckStatus.Text)
                };
                int result = cls_Fin_Acknowledgement.Fin_Acknowledgment_NonQuery(parameter);
                if (result > 0)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }
        }

        private void btnViewStatement_Click(object sender, EventArgs e)
        {
            Installment.frmAccountStatement ob = new frmAccountStatement(lblFileNo.Text);
            ob.ShowDialog();
        }
    }
}
