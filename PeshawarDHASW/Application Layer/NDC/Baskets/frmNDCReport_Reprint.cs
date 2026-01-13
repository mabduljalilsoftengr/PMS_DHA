using PeshawarDHASW.Data_Layer.NDC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    public partial class frmNDCReport_Reprint : Telerik.WinControls.UI.RadForm
    {
        public frmNDCReport_Reprint()
        {
            InitializeComponent();
        }

        private void btnreprintndc_Click(object sender, EventArgs e)
        {
            try
            {
                int NDCNo_ = int.Parse(txtndcno.Text);


                SqlParameter[] prm =
                {
                        new SqlParameter("@Task","CheckNDCForPrint"),
                        new SqlParameter("@NDCNo",NDCNo_)
                    };
                DataSet ds = cls_dl_NDC.NdcRetrival(prm);
                if (ds.Tables[0].Rows[0]["StatusofNDC"].ToString() == "Incomplete")
                {
                    MessageBox.Show("Currently This NDC is not Ready For Print.");
                }
                else 
                {
                    frmNDC_Report chk = new frmNDC_Report(NDCNo_, "CheckListReport","");
                    chk.Show();
                    frmNDC_Report obj = new frmNDC_Report(NDCNo_, "NDCReport","");
                    obj.ShowDialog();

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
