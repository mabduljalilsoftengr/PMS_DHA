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
    public partial class frmAcknowledgmentAudit : Telerik.WinControls.UI.RadForm
    {
        private int AckID { get; set; } 
        public frmAcknowledgmentAudit()
        {
            InitializeComponent();
        }
        public frmAcknowledgmentAudit(int ackid)
        {
            InitializeComponent();
            AckID = ackid;
        }

        private void frmAcknowledgmentAudit_Load(object sender, EventArgs e)
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","Select_Audit_Qsr"),
                new SqlParameter("@AckFinID",AckID)
            };
            DataSet dst = cls_Fin_Acknowledgement.Fin_AcknowledgementDataRead(prm);
            grdAudit.DataSource = dst.Tables[0].DefaultView;
            grdQSR.DataSource = dst.Tables[1].DefaultView;

        }
    }
}
