using PeshawarDHASW.Data_Layer.clsFileMap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeshawarDHASW.Application_Layer.FileMap.ByBack
{
    public partial class frmBuyBackModify : Form
    {
        public frmBuyBackModify()
        {
            InitializeComponent();
        }
        private int b_ID  {get;set;}
        private decimal PerFlRt { get; set; }
        public frmBuyBackModify(int bid,decimal prflrt,decimal amont,string ckno,string pmtdt)
        {
            InitializeComponent();
            b_ID = bid;
            PerFlRt = prflrt;

            txtchequeno.Text = ckno;
            txtamount.Text = amont.ToString();
            if (!string.IsNullOrEmpty(pmtdt))
            {
                rdbpaymentdate.Value = Convert.ToDateTime(pmtdt);
            }
        }

        private void btnUpdtae_Click(object sender, EventArgs e)
        {
            try
            {
                if(PerFlRt == Convert.ToDecimal(txtamount.Text))
                {
                    SqlParameter[] param =
                    {
                    new SqlParameter("@Task","UpdateBuyBackData"),
                    new SqlParameter("@BID",b_ID),
                    new SqlParameter("@CheckNo",txtchequeno.Text),
                    new SqlParameter("@Amount",txtamount.Text),
                    new SqlParameter("@PaymentDate",rdbpaymentdate.Value.Date)
                    };
                    int rslt = cls_dl_FileMap.Main_FileMap_NonQuery(param);
                    if (rslt > 0)
                    {
                        MessageBox.Show("Successful.");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Amount Does't match  with Per File Rate.","Error !",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
