using PeshawarDHASW.Data_Layer.NDC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.NDC.FBR
{
    public partial class frm_FBR_View : Telerik.WinControls.UI.RadForm
    {
        private bool sellerrCheckFiler { get; set; } = false;
        private bool sellerrCheckNonFiler { get; set; } = false;
        private bool buyerCheckFiler { get; set; } = false;
        private bool buyerCheckNonFiler { get; set; } = false;
        private decimal txtTaxCAmountSeller { get; set; } = 0;
        private decimal txtTaxKAmountBuyer { get; set; } = 0;
        private decimal CalculatedTaxSeller { get; set; }
        private string CalculatedTaxSellerFBROwnerType { get; set; }
        private string FileOwnerType { get; set; }
        private decimal CalculatedTaxBuyer { get; set; }
        private string CalculatedTaxBuyerFBROwnerType { get; set; }
        private string CPRString_ { get; set; } = "";
        private DataSet dst_ { get; set; }
        private int NDCNo { get; set; }
        private string FileNo { get; set; }
        public frm_FBR_View()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] prm =
                {
                    new SqlParameter("@Task","GetFBRDetailForView"),
                    new SqlParameter("@FileNo",txtFileNo.Text)
                };
                dst_ = cls_dl_NDC.NdcRetrival(prm);
                grdFBRView.DataSource = dst_.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void grdFBRView_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "btnview")
                {
                    #region FBR Data Retrieving
                    sellerrCheckFiler = false;
                    sellerrCheckNonFiler = false;
                    buyerCheckFiler = false;
                    buyerCheckNonFiler = false;
                    int FBRID = int.Parse(e.Row.Cells["FBRID"].Value.ToString());
                    SqlParameter[] prm =
                    {
                    new SqlParameter("@Task","GetFBRDetailByFBRID"),
                    new SqlParameter("@FBRID",FBRID)
                };
                    dst_ = cls_dl_NDC.NdcRetrival(prm);
                    if (dst_.Tables.Count > 0)
                    {
                        if (dst_.Tables[0].Rows.Count > 0)
                        {
                            string dltp = dst_.Tables[0].Rows[0]["DealType"].ToString();
                            int lblFBRID = int.Parse(dst_.Tables[0].Rows[0]["FBRID"].ToString());
                            if (dltp == "FBR") { rdbFBR.CheckState = CheckState.Checked; } else { FBROther.CheckState = CheckState.Checked; }
                            txtDealValue.Text = dst_.Tables[0].Rows[0]["Deal_Amount"].ToString();
                            grdCPRData.DataSource = dst_.Tables[3].DefaultView;
                        }
                        else
                        {
                            txtDealValue.Text = null;
                            rdbFBR.CheckState = CheckState.Unchecked;
                            FBROther.CheckState = CheckState.Unchecked;
                            grdCPRData.DataSource = null;
                            MessageBox.Show("There is no FBR Record in Database against this File No. " + Environment.NewLine +
                                            "and NDCNo , So please First Enter FBR Detail.");




                            this.Close();
                        }
                    }
                    
                    #endregion
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
