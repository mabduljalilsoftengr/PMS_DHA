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
    public partial class frmAcknowledgement_UserBase : Telerik.WinControls.UI.RadForm
    {
        public frmAcknowledgement_UserBase()
        {
            InitializeComponent();
        }

        private void DDNoLoading()
        {
            DataSet ds = new DataSet();
            SqlParameter[] parameter = {
                new SqlParameter("@Task","DDNoAcknowledgementNotGenerateYet")
            };
            ds = cls_Fin_Acknowledgement.Fin_AcknowledgementDataRead(parameter);
            AckGDV.DataSource = ds.Tables[0].DefaultView;
        }
        private void frmAcknowledgement_UserBase_Load(object sender, EventArgs e)
        {
            DDNoLoading();
        }

        private void AckGDV_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {

                if (e.Column.Name == "btnCreate")
                {
                    int ID = int.Parse(AckGDV.CurrentRow.Cells["Rece_ID"].Value.ToString());
                    Application_Layer.Acknowledgement.frmGenerateAcknowledgement rd = new frmGenerateAcknowledgement(ID);
                    rd.ShowDialog();
                    DDNoLoading();
                }
               
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on SearchDGV_CellClick.", ex, "frmMembershipSearch");
                //frmobj.ShowDialog();
            }
        }
    }
}
