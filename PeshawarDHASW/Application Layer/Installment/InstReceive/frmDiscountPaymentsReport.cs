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
    public partial class frmDiscountPaymentsReport : Telerik.WinControls.UI.RadForm
    {
        public frmDiscountPaymentsReport()
        {
            InitializeComponent();
        }

        private void frmDiscountPaymentsReport_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
            SqlParameter[] prm =
                                  {
                                    new SqlParameter("@Task","GetDiscountData")
            };
            DataSet dst = cls_dl_InstRece.Inst_Rece_Select(prm);
            grddiscountdata.DataSource = dst.Tables[0].DefaultView;
        }

        private void btngetdata_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnexcelexport_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(grddiscountdata);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Contact with System Administrator." + ex.Message);
            }
        }
    }
}
