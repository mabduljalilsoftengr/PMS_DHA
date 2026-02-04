using PeshawarDHASW.Application_Layer.Acknowledgement;
using PeshawarDHASW.Application_Layer.CustomDialog;
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

namespace PeshawarDHASW.Application_Layer.Installment.AcknowledgmentSearch
{
    public partial class frmAcknowledgementDispatch : Telerik.WinControls.UI.RadForm
    {
        public frmAcknowledgementDispatch()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Task","Search"),
                    new SqlParameter("@FileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtFileNo.Text)),
                    new SqlParameter("@DDNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtDDno.Text)),
                     new SqlParameter("@AckFinID",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtAckNo.Text))
                    
            };
                DataSet ds = new DataSet();
                ds = cls_Fin_Acknowledgement.Fin_AcknowledgementDataRead(param);
                DGV_Acknowledgement.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DGV_Acknowledgement_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {

                if (e.Column.Name == "Edit")
                {
                    int AckID = int.Parse(DGV_Acknowledgement.CurrentRow.Cells[0].Value.ToString());
                    int ReceID = int.Parse(DGV_Acknowledgement.CurrentRow.Cells[1].Value.ToString());
                   // Application_Layer.Acknowledgement.frmAcknowledgementUpdate fromobjAckDisptach = new frmAcknowledgementUpdate(AckID.ToString(), ReceID.ToString());
                 //   fromobjAckDisptach.ShowDialog();
                    //  DDNoLoading();
                }

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on SearchDGV_CellClick.", ex, "Acknowledgement Modification");
                //frmobj.ShowDialog();
            }
        }
    }
}
