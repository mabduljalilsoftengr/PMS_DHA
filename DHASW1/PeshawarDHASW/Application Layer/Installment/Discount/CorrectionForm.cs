using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Installment.Discount
{
    public partial class CorrectionForm : Telerik.WinControls.UI.RadForm
    {
        public CorrectionForm()
        {
            InitializeComponent();
        }
        public string DiscountRqID_ { get; set; }
        public CorrectionForm(string DiscountRqID)
        {
            InitializeComponent();
            DiscountRqID_ = DiscountRqID;
        }

        private void CorrectionForm_Load(object sender, EventArgs e)
        {

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SqlParameter[] param = {
                                new SqlParameter("@Task","CancelWrongTask"),
                                new SqlParameter("@DiscountStatus","Cancelled"),
                                new SqlParameter("@ApprovedBy",clsUser.ID),
                                new SqlParameter("@ApprovedDate",DateTime.Now.ToString("yyyy/MM/dd")),
                                new SqlParameter("@ApprovedRemarksa","Cancelled for Correction := "+txtremarks.Text),
                                new SqlParameter("@DiscountRqID",DiscountRqID_),
                            };
                int result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_tbl_ReceDiscount", param);
                if (result != 0)
                {
                    MessageBox.Show("Discount has been Cancelled successfully for Correction", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }
    }
}
