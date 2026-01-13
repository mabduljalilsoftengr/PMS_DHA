using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using PeshawarDHASW.Data_Layer.clsAcknowledgment;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.Acknowledgement
{
    public partial class frmGenerateAcknowledgement : Telerik.WinControls.UI.RadForm
    {
        public frmGenerateAcknowledgement()
        {
            InitializeComponent();
        }
        public int rece_Id { get; set; }
        public frmGenerateAcknowledgement(int ReceID)
        {
            rece_Id = ReceID;
            InitializeComponent();
        }

        private void frmGenerateAcknowledgement_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlParameter[] parameter = {
                new SqlParameter("@Task","DDNoAcknowledgementGetInformation"),
                new SqlParameter("@ReceID",rece_Id.ToString())
            };
            ds = cls_Fin_Acknowledgement.Fin_AcknowledgementDataRead(parameter);
            lblFileNo.Text = ds.Tables[0].Rows[0]["FileNo"].ToString();
            lblDDno.Text = ds.Tables[0].Rows[0]["DDNo"].ToString();
            int AmountValue = (int)Double.Parse(ds.Tables[0].Rows[0]["Amount"].ToString());
            lblAmount.Text = AmountValue.ToString();
            txtAmountinWords.Text = Helper.clsPluginHelper.Convert_Number_To_Text(AmountValue, false);
            //AckGDV.DataSource = ds.Tables[0].DefaultView;
            DpInstallmentList.DataSource = ds.Tables[1].DefaultView;
            DpInstallmentList.DisplayMember = "Descp";
            DpInstallmentList.ValueMember = "PlanID";
        }

        private void btnGenerateAck_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] parameter =
                                {
                    new SqlParameter("@Task","GenerateAcknowledgement"),
                    new SqlParameter("@FileNo",lblFileNo.Text),
                    new SqlParameter("@ReceID",int.Parse(rece_Id.ToString()))
                    //new SqlParameter("@PlanID",DpInstallmentList.SelectedValue),
                    //new SqlParameter("@DDNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(lblDDno.Text)),
                    //new SqlParameter("@Status","Remaining"),
                    ,
                    //new SqlParameter("@userID",Models.clsUser.ID),
                    //new SqlParameter("@Remark",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtRemark.Text)),
                    //new SqlParameter("@Note",Helper.clsPluginHelper.DbNullIfNullOrEmpty( txtNote.Text)),
                    //new SqlParameter("@AmountInword",txtAmountinWords.Text)
                };
                int result = cls_Fin_Acknowledgement.Fin_Acknowledgment_NonQuery(parameter);
                if (result>0)
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
            Installment.frmAccountStatement objAck = new Installment.frmAccountStatement(lblFileNo.Text);
            objAck.ShowDialog();
        }
    }
}
