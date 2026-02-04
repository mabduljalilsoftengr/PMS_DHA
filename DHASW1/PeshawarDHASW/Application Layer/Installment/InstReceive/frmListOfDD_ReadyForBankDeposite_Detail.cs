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
    public partial class frmListOfDD_ReadyForBankDeposite_Detail : Telerik.WinControls.UI.RadForm
    {
        private int Blh_ID { get; set; }
        public frmListOfDD_ReadyForBankDeposite_Detail()
        {
            InitializeComponent();
        }
        public frmListOfDD_ReadyForBankDeposite_Detail(int get_blhid)
        {
            InitializeComponent();
            Blh_ID = get_blhid;
        }
        private void Loaddata()
        {
            SqlParameter[] prm = { new SqlParameter("@Task", "Load_Specific_ListDetail"), new SqlParameter("@Blh_ID", Blh_ID) };
            DataSet dst = cls_dl_InstRece.Inst_Rece_Read(prm);
            grd_BankListDetail.DataSource = dst.Tables[0].DefaultView;
        }

        private void frmListOfDD_ReadyForBankDeposite_Detail_Load(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(grd_BankListDetail);
        }
    }
}
