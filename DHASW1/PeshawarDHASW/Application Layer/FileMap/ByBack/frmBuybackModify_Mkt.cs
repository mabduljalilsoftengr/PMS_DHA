using PeshawarDHASW.Data_Layer.clsFileMap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.FileMap.ByBack
{
    public partial class frmBuybackModify_Mkt : Telerik.WinControls.UI.RadForm
    {
        public frmBuybackModify_Mkt()
        {
            InitializeComponent();
        }
        private int b_id { get; set; }
        private void btnrefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
           SqlParameter[] parameters =
           {
                new SqlParameter("@Task", "Get_FilePendingDataofBuyBack")
            };
            DataSet dst = cls_dl_FileMap.Main_FileMap_Reader(parameters);
            grdbuybackdata.DataSource = dst.Tables[0].DefaultView;
        }

        private void frmBuybackModify_Mkt_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void grdbuybackdata_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                b_id = int.Parse(e.Row.Cells["BID"].Value.ToString());
                string flno = e.Row.Cells["FileNo"].Value.ToString();
                txtfileno.Text = flno;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btncancelprocess_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtfileno.Text))
            {
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","CancelUpdate"),
                new SqlParameter("@FileNo",txtfileno.Text),
                new SqlParameter("@Remarks",txtremarks.Text),
                new SqlParameter("@BID",b_id)
                };
                int rslt = cls_dl_FileMap.Main_FileMap_NonQuery(prm);
                if (rslt > 0)
                {
                    MessageBox.Show("Cancelled Successfully.");
                    txtfileno.Text = "";
                    txtremarks.Text = "";
                    LoadData();
                }
               
            }
            else
            {
                MessageBox.Show("Enter File No.","Attention !",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
           
        }
    }
}
