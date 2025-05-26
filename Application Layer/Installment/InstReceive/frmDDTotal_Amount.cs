using PeshawarDHASW.Data_Layer.Installment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Installment.InstReceive
{
    public partial class frmDDTotal_Amount : Telerik.WinControls.UI.RadForm
    {
        private string DDNo { get; set; }
        public frmDDTotal_Amount()
        {
            InitializeComponent();
        }
        public frmDDTotal_Amount(string get_DDNo)
        {
            InitializeComponent();
            DDNo = get_DDNo;
            Total_DDAmount(DDNo);
        }
       private void Total_DDAmount(string gt_ddno)
        {
            SqlParameter[] prm =
            {
            new SqlParameter("@Task","Select_DDTotal_Amount"),
            new SqlParameter("@DDNo", gt_ddno)
            };
            DataSet dst = new DataSet();
            dst = cls_dl_InstRece.Inst_Rece_Read(prm);
            grd_TotalAmount.DataSource = dst.Tables[0].DefaultView;
        }
           
}
}
