using PeshawarDHASW.Application_Layer.CustomDialog;
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

namespace PeshawarDHASW.Application_Layer.NDC.NDC_File_BuyerSellerInfo
{
    public partial class frm_NDC_Modify_FileSellerBuyerInfo : Telerik.WinControls.UI.RadForm
    {
        private int SBID_ { get; set; } = 0;
        private string NDCNo { get; set; } = "";
        public frm_NDC_Modify_FileSellerBuyerInfo()
        {
            InitializeComponent();
        }
        public frm_NDC_Modify_FileSellerBuyerInfo(int get_SBID)
        {
            InitializeComponent();
            SBID_ = get_SBID;
        }
        public frm_NDC_Modify_FileSellerBuyerInfo(string get_NDCNo)
        {
            InitializeComponent();
            NDCNo = get_NDCNo;
            txtNDCNo.Text = NDCNo;
            txtType.Text = "Buyer";
            btn_Update.Text = "Create";

        }

        private void frm_NDC_Modify_FileSellerBuyerInfo_Load(object sender, EventArgs e)
        {
            if(SBID_ > 0)
            {
                LoadBuyerSellerInfo(SBID_);
            }
        }
        private void LoadBuyerSellerInfo(int SB_ID)
        {
            try
            {
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","Select_SellerBuyerInfo"),
                new SqlParameter("@SBID",SB_ID)
                };
                DataSet ds = new DataSet();
                ds = cls_dl_NDC.NdcRetrival(prm);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    txtNDCNo.Text = ds.Tables[0].Rows[0]["NDCNo"].ToString();
                    txtType.Text = ds.Tables[0].Rows[0]["Type"].ToString();
                    txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    txtMobileNo.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                    txtF_H_w_Name.Text = ds.Tables[0].Rows[0]["F_H_W_Name"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    txtCNIC.Text = ds.Tables[0].Rows[0]["CNIC"].ToString();
                }
                else
                {
                    MessageBox.Show("There is no Data, Contact with administration.");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LoadBuyerSellerInfo.", ex, "frm_NDC_Modify_FileSellerBuyerInfo");
                frmobj.ShowDialog();
            }
            
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if(NDCNo == "" | NDCNo == null)
            {
                Update_Seller_Buyer_Info();
            }
            else
            {
                Add_Seller_Buyer_Info();
            }
        }
        private void Add_Seller_Buyer_Info()
        {
            try
            {
             SqlParameter[] prm =
             {
             new SqlParameter("@Task","Add_SellerBuyerInfo"),
             new SqlParameter("@NDCNo", txtNDCNo.Text),
             new SqlParameter("@Type",txtType.Text),
             new SqlParameter("@Name",txtName.Text),
             new SqlParameter("@MobileNo",txtMobileNo.Text),
             new SqlParameter("@SB_Address",txtAddress.Text),
             new SqlParameter("@SBCNIC",txtCNIC.Text),
             new SqlParameter("@F_H_W_Name",txtF_H_w_Name.Text)
            };
                int rslt = 0;
                rslt = cls_dl_NDC.NdcNonQuery(prm);
                if (rslt > 0)
                {
                    MessageBox.Show("Successfully Added New Buyer Information.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Contact with Administration.");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Add_Seller_Buyer_Info.", ex, "frm_NDC_Modify_FileSellerBuyerInfo");
                frmobj.ShowDialog();
            }
        }
        private void Update_Seller_Buyer_Info()
        {
            try
            {
                SqlParameter[] prm =
                {
                 new SqlParameter("@Task","Update_SellerBuyerInfo"),
                 new SqlParameter("@SBID",SBID_),
                 new SqlParameter("@NDCNo", txtNDCNo.Text),
                 new SqlParameter("@Type",txtType.Text),
                 new SqlParameter("@Name",txtName.Text),
                 new SqlParameter("@MobileNo",txtMobileNo.Text),
                 new SqlParameter("@F_H_W_Name",txtF_H_w_Name.Text),
                 new SqlParameter("@SB_Address",txtAddress.Text),
                 new SqlParameter("@SBCNIC",txtCNIC.Text)
               };
                int rslt = 0;
                rslt = cls_dl_NDC.NdcNonQuery(prm);
                if (rslt > 0)
                {
                    MessageBox.Show("Successfully Modified.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Contact with Administration.");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Update_Seller_Buyer_Info.", ex, "frm_NDC_Modify_FileSellerBuyerInfo");
                frmobj.ShowDialog();
            }
            
        }
    }
}
