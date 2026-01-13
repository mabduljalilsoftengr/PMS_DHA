using PeshawarDHASW.Data_Layer.clsChallan;
using PeshawarDHASW.Data_Layer.clsMemberShip;
using PeshawarDHASW.Data_Layer.clsTFR;
using PeshawarDHASW.Data_Layer.NDC;
using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    public partial class frmReadyForMemberShipAfterTransfer : Telerik.WinControls.UI.RadForm
    {
        private int ndcNo { get; set; }
        private string MSNo { get; set; }
        private string FileNo { get; set; }
        private DataSet ds_MSNo { get; set; }
        private DataSet ds_getChallanData { get; set; }
        public frmReadyForMemberShipAfterTransfer()
        {
            InitializeComponent();
        }

        private void frmReadyForMemberShipAfterTransfer_Load(object sender, EventArgs e)
        {
            dpOwnerCategory.SelectedIndex = 0;
            grp_membership.Enabled = false;
            membership_infogroupBox.Enabled = false;
            getDataForGrid();
            grpsvc.Enabled = false;
            //DataSet dsOwnerCategory = new DataSet();
            //dsOwnerCategory = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.Text, "Select OCID,Category_Name from dbo.tbl_Owner_Category where OCID in (2,3)");
            //dpOwnerCategory.DataSource = dsOwnerCategory.Tables[0].DefaultView;
            //dpOwnerCategory.ValueMember = "OCID";
            //dpOwnerCategory.DisplayMember = "Category_Name";
        }
        private void getDataForGrid()
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","Get_Seller_Buyer_ofNDC"),
                new SqlParameter("@NDCStatus","TFRImageUploadCompleted")
            };
            DataSet ds = new DataSet();
            ds = cls_dl_TFR.TranferRead(prm);
            grdReady_For_Membership.DataSource = ds.Tables[0].DefaultView;
            grdlatestdpr.DataSource = ds.Tables[1].DefaultView;

        }
        private void grdReady_For_Membership_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "Rady_Membr_Forward")
                {

                    dpOwnerCategory.SelectedIndex = 1;
                    gpCNICandFeeVerification.Enabled = true;
                    membership_infogroupBox.Enabled = false;
                    ndcNo = int.Parse(e.Row.Cells["NDCNo"].Value.ToString());
                    txtCNIC.Text = e.Row.Cells["CNIC"].Value.ToString();
                    txtCNICNo.Text = e.Row.Cells["CNIC"].Value.ToString();
                    txtFileNo.Text = e.Row.Cells["FileNo"].Value.ToString();
                    FileNo = e.Row.Cells["FileNo"].Value.ToString();
                    txtName.Text = e.Row.Cells["Name"].Value.ToString();
                    txtFatherName.Text = e.Row.Cells["Father"].Value.ToString();

                    if (!string.IsNullOrEmpty(txtCNIC.Text))
                    {
                        grp_membership.Enabled = true;
                    }
                }
                else if (e.Column.Name == "btnBack")
                {
                    if (MessageBox.Show("Are you sure to go in Back Step.", "Confirmation !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        ndcNo = int.Parse(e.Row.Cells["NDCNo"].Value.ToString());
                        SqlParameter[] prm =
                        {
                         new SqlParameter("@Task","UpdateNDC_Sts"),
                         new SqlParameter("@StatusofNDC","TFRImagesCaptured"),
                         new SqlParameter("@NDCNo",ndcNo)
                        };
                        int rslt = cls_dl_NDC.NdcNonQuery(prm);
                        if (rslt > 0)
                        {
                            MessageBox.Show("Successfully Go to Back Step.", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            getDataForGrid();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btn_CheckCNICNo_Click(object sender, EventArgs e)
        {
            try
            {
                // ndcNo
                #region Code
                //membership_infogroupBox.Enabled = false;
                if (dpOwnerCategory.SelectedItem.Text == "Transfer")
                {
                    #region Transfer
                    SqlParameter[] prm =
                    {
                    new SqlParameter("@Task","Get_NDC_Buyer_MemebershipFee"),
                    new SqlParameter("@CNIC",txtCNIC.Text),
                    new SqlParameter("@FileNo",FileNo),
                    new SqlParameter("@NDCNo",ndcNo)
                    };
                    ds_getChallanData = cls_dl_Challan.Challan_Reader(prm);



                    if (ds_getChallanData.Tables.Count > 0)
                    {
                        if (ds_getChallanData.Tables[0].Rows.Count > 0)
                        {
                            //MessageBox.Show(ds_getChallanData.Tables[0].Rows[0]["Particular"].ToString());
                            membership_infogroupBox.Enabled = true;
                            txtchallanNo.Text = ds_getChallanData.Tables[0].Rows[0]["ChalanNo"].ToString();
                            if (ds_getChallanData.Tables[0].Rows[0]["Particular"].ToString().ToLower() == "Membership Fee".ToLower() ||
                                ds_getChallanData.Tables[0].Rows[0]["Particular"].ToString().ToLower() == "Membership Fee (Com)".ToLower() ||
                                ds_getChallanData.Tables[0].Rows[0]["Particular"].ToString().ToLower() == "Membership Fee (Corporate)".ToLower() ||
                                ds_getChallanData.Tables[0].Rows[0]["Particular"].ToString().ToLower() == "Membership Fee Corporate (Com)".ToLower()
                                )
                            {
                                //membership_infogroupBox.Enabled = true;
                                //txtchallanNo.Text = ds_getChallanData.Tables[0].Rows[0]["ChalanNo"].ToString();
                                // if (string.IsNullOrEmpty(txtMembershipNo.Text))
                                //{
                                /// %%%%%%%% Start %%%%% Get the New Membership No
                                SqlParameter[] param =
                                {
                                      new SqlParameter("@Task","Generate_New_MembershipNo")
                                    };
                                DataSet dst = new DataSet();
                                dst = cls_dl_TFR.TranferRead(param);
                                txtMembershipNo.Text = dst.Tables[0].Rows[0]["MembershipNo"].ToString();
                                /// %%%%%%%% End %%%%% Get the New Membership No
                                //}
                            }
                            //else if (ds_getChallanData.Tables[0].Rows[0]["Particular"].ToString() == "Membership Fee (Com)")
                            //{

                            //    //if (string.IsNullOrEmpty(txtMembershipNo.Text))
                            //    //{
                            //        /// %%%%%%%% Start %%%%% Get the New Membership No
                            //        SqlParameter[] param =
                            //        {
                            //          new SqlParameter("@Task","Generate_New_MembershipNo")
                            //        };
                            //        DataSet dst = new DataSet();
                            //        dst = cls_dl_TFR.TranferRead(param);
                            //        txtMembershipNo.Text = dst.Tables[0].Rows[0]["MembershipNo"].ToString();
                            //        /// %%%%%%%% End %%%%% Get the New Membership No
                            //    //}
                            //}
                            else if (ds_getChallanData.Tables[0].Rows[0]["Particular"].ToString().ToLower() == "Dual Membership Fee".ToLower() ||
                                ds_getChallanData.Tables[0].Rows[0]["Particular"].ToString().ToLower() == "Dual Membership Fee (Com)".ToLower() ||
                                ds_getChallanData.Tables[0].Rows[0]["Particular"].ToString().ToLower() == "Dual Membership Fee (Corporate)".ToLower() ||
                                ds_getChallanData.Tables[0].Rows[0]["Particular"].ToString().ToLower() == "Dual Membership Fee Corporate (Com)".ToLower())
                            {

                                /// %%%%%%%% Start %%%%% Get the New Membership No
                                SqlParameter[] param =
                                {
                                      new SqlParameter("@Task","Generate_New_MembershipNo")
                                };
                                DataSet dst = new DataSet();
                                dst = cls_dl_TFR.TranferRead(param);
                                txtMembershipNo.Text = dst.Tables[0].Rows[0]["MembershipNo"].ToString();
                                /// %%%%%%%% End %%%%% Get the New Membership No
                                /// Get 2nd Membership No


                                SqlParameter[] paramd =
                                {
                                      new SqlParameter("@Task","Generate_New_MembershipNo_Dual")
                                };
                                DataSet dstd = new DataSet();
                                dstd = cls_dl_TFR.TranferRead(paramd);
                                txtMembershipNoDual.Text = dstd.Tables[0].Rows[0]["MembershipNo"].ToString();

                                SqlParameter[] prm1 =
                                {
                                  new SqlParameter("@Task","Get_Only_Buyer_of_NDC"),
                                  new SqlParameter("@NDCStatus","TFRImageUploadCompleted"),
                                  new SqlParameter("@NDCNo",ndcNo)
                                };
                                DataSet ds = new DataSet();
                                ds = cls_dl_TFR.TranferRead(prm1);
                                txtCNICNoDual.Text = ds.Tables[0].Rows[1]["CNIC"].ToString();
                                txtNameDual.Text = ds.Tables[0].Rows[1]["Name"].ToString();
                                txtFatherNameDual.Text = ds.Tables[0].Rows[1]["Father"].ToString();



                            }
                            else if (ds_getChallanData.Tables[0].Rows[0]["Particular"].ToString().ToLower() == "Triple Membership Fee".ToLower() ||
                                ds_getChallanData.Tables[0].Rows[0]["Particular"].ToString().ToLower() == "Triple Membership Fee (Com)".ToLower() ||
                                ds_getChallanData.Tables[0].Rows[0]["Particular"].ToString().ToLower() == "Triple Membership Fee (Corporate)".ToLower() ||
                                ds_getChallanData.Tables[0].Rows[0]["Particular"].ToString().ToLower() == "Triple Membership Fee Corporate (Com)".ToLower())
                            {
                                /// %%%%%%%% Start %%%%% Get the New Membership No
                                SqlParameter[] param =
                                {
                                      new SqlParameter("@Task","Generate_New_MembershipNo")
                                };
                                DataSet dst = new DataSet();
                                dst = cls_dl_TFR.TranferRead(param);
                                txtMembershipNo.Text = dst.Tables[0].Rows[0]["MembershipNo"].ToString();
                                /// %%%%%%%% End %%%%% Get the New Membership No

                                /// Get 2nd Membership No
                                SqlParameter[] paramd =
                                {
                                      new SqlParameter("@Task","Generate_New_MembershipNo_Dual")
                                };
                                DataSet dstd = new DataSet();
                                dstd = cls_dl_TFR.TranferRead(paramd);
                                txtMembershipNoDual.Text = dstd.Tables[0].Rows[0]["MembershipNo"].ToString();

                                /// Get 3rd Membership No
                                SqlParameter[] paramt =
                                {
                                      new SqlParameter("@Task","Generate_New_MembershipNo_Triple")
                                };
                                DataSet dstt = new DataSet();
                                dstt = cls_dl_TFR.TranferRead(paramt);
                                txtMembershipNoTriple.Text = dstt.Tables[0].Rows[0]["MembershipNo"].ToString();

                                SqlParameter[] prm1 =
                               {
                                  new SqlParameter("@Task","Get_Only_Buyer_of_NDC"),
                                  new SqlParameter("@NDCStatus","TFRImageUploadCompleted"),
                                  new SqlParameter("@NDCNo",ndcNo)
                                };
                                DataSet ds = new DataSet();
                                ds = cls_dl_TFR.TranferRead(prm1);
                                txtCNICNoDual.Text = ds.Tables[0].Rows[1]["CNIC"].ToString();
                                txtNameDual.Text = ds.Tables[0].Rows[1]["Name"].ToString();
                                txtFatherNameDual.Text = ds.Tables[0].Rows[1]["Father"].ToString();

                                txtCNICNoTriple.Text = ds.Tables[0].Rows[2]["CNIC"].ToString();
                                txtNameTriple.Text = ds.Tables[0].Rows[2]["Name"].ToString();
                                txtFatherNameTriple.Text = ds.Tables[0].Rows[2]["Father"].ToString();


                            }
                            else if (ds_getChallanData.Tables[0].Rows[0]["Particular"].ToString().ToLower() == "Quad Membership Fee".ToLower() ||
                                     ds_getChallanData.Tables[0].Rows[0]["Particular"].ToString().ToLower() == "Quad Membership Fee (Com)".ToLower() ||
                                ds_getChallanData.Tables[0].Rows[0]["Particular"].ToString().ToLower() == "Quad Membership Fee (Corporate)".ToLower() ||
                                ds_getChallanData.Tables[0].Rows[0]["Particular"].ToString().ToLower() == "Quad Membership Fee Corporate (Com)".ToLower())
                            {

                                /// %%%%%%%% Start %%%%% Get the New Membership No
                                SqlParameter[] param =
                                {
                                      new SqlParameter("@Task","Generate_New_MembershipNo")
                                };
                                DataSet dst = new DataSet();
                                dst = cls_dl_TFR.TranferRead(param);
                                txtMembershipNo.Text = dst.Tables[0].Rows[0]["MembershipNo"].ToString();
                                /// %%%%%%%% End %%%%% Get the New Membership No

                                /// Get 2nd Membership No
                                SqlParameter[] paramd =
                                {
                                      new SqlParameter("@Task","Generate_New_MembershipNo_Dual")
                                };
                                DataSet dstd = new DataSet();
                                dstd = cls_dl_TFR.TranferRead(paramd);
                                txtMembershipNoDual.Text = dstd.Tables[0].Rows[0]["MembershipNo"].ToString();

                                /// Get 3rd Membership No
                                SqlParameter[] paramt =
                                {
                                      new SqlParameter("@Task","Generate_New_MembershipNo_Triple")
                                };
                                DataSet dstt = new DataSet();
                                dstt = cls_dl_TFR.TranferRead(paramt);
                                txtMembershipNoTriple.Text = dstt.Tables[0].Rows[0]["MembershipNo"].ToString();

                                /// Get 3rd Membership No
                                SqlParameter[] paramtq =
                                {
                                      new SqlParameter("@Task","Generate_New_MembershipNo_Quad")
                                };
                                DataSet dsttq = new DataSet();
                                dsttq = cls_dl_TFR.TranferRead(paramtq);
                                txtMembershipNoQuad.Text = dsttq.Tables[0].Rows[0]["MembershipNo"].ToString();


                                SqlParameter[] prm1 =
                                {
                                  new SqlParameter("@Task","Get_Only_Buyer_of_NDC"),
                                  new SqlParameter("@NDCStatus","TFRImageUploadCompleted"),
                                  new SqlParameter("@NDCNo",ndcNo)
                                };
                                DataSet ds = new DataSet();
                                ds = cls_dl_TFR.TranferRead(prm1);
                                txtCNICNoDual.Text = ds.Tables[0].Rows[1]["CNIC"].ToString();
                                txtNameDual.Text = ds.Tables[0].Rows[1]["Name"].ToString();
                                txtFatherNameDual.Text = ds.Tables[0].Rows[1]["Father"].ToString();

                                txtCNICNoTriple.Text = ds.Tables[0].Rows[2]["CNIC"].ToString();
                                txtNameTriple.Text = ds.Tables[0].Rows[2]["Name"].ToString();
                                txtFatherNameTriple.Text = ds.Tables[0].Rows[2]["Father"].ToString();

                                txtCNICNoQuad.Text = ds.Tables[0].Rows[3]["CNIC"].ToString();
                                txtNameQuad.Text = ds.Tables[0].Rows[3]["Name"].ToString();
                                txtFatherNameQuad.Text = ds.Tables[0].Rows[3]["Father"].ToString();



                            }
                            else
                            {
                                membership_infogroupBox.Enabled = true;
                                SqlParameter[] param =
                                {
                                      new SqlParameter("@Task","Generate_New_MembershipNo")
                                };
                                DataSet dst = new DataSet();
                                dst = cls_dl_TFR.TranferRead(param);
                                txtMembershipNo.Text = dst.Tables[0].Rows[0]["MembershipNo"].ToString();
                            }


                        }
                        else if (ds_getChallanData.Tables[1].Rows[0]["NDCType"].ToString() == "LegalHeirSvc")
                        {
                            membership_infogroupBox.Enabled = true;
                            SqlParameter[] param =
                            {
                                      new SqlParameter("@Task","Generate_New_MembershipNo")
                            };
                            DataSet dst = new DataSet();
                            dst = cls_dl_TFR.TranferRead(param);
                            txtMembershipNo.Text = dst.Tables[0].Rows[0]["MembershipNo"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Please Submit the Membership Fee.");
                            membership_infogroupBox.Enabled = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Submit the Membership Fee.");
                        membership_infogroupBox.Enabled = false;
                    }
                    #endregion
                }
                else if (dpOwnerCategory.SelectedItem.Text == "Allocation")
                {
                    #region Allocation
                    if (rdbchhalan.IsChecked)
                    {
                        SqlParameter[] prm =
                        {
                        new SqlParameter("@Task","Get_NDC_Buyer_MemebershipFeeAllocation"),
                        new SqlParameter("@ChalanNo",txtx_chalanno.Text)
                        };
                        ds_MSNo = cls_dl_Challan.Challan_Reader(prm);
                    }
                    else if (rdbDDNo.IsChecked)
                    {
                        SqlParameter[] prm =
                        {
                        new SqlParameter("@Task","Get_Buyer_MemebershipFeeAllocation"),
                        new SqlParameter("@DDNo",txtx_chalanno.Text)
                        };
                        ds_MSNo = cls_dl_Challan.Challan_Reader(prm);
                    }


                    if (ds_MSNo.Tables.Count > 0)
                    {
                        if (ds_MSNo.Tables[0].Rows.Count > 0)
                        {
                            membership_infogroupBox.Enabled = true;
                            if (rdbchhalan.IsChecked)
                            {
                                txtchallanNo.Text = ds_MSNo.Tables[0].Rows[0]["ChalanNo"].ToString();
                            }
                            else if (rdbDDNo.IsChecked)
                            {
                                txtchallanNo.Text = ds_MSNo.Tables[0].Rows[0]["DDno"].ToString();
                            }

                            if (ds_MSNo.Tables[0].Rows[0]["Particular"].ToString() == "Membership Fee" ||
                                ds_MSNo.Tables[0].Rows[0]["Particular"].ToString() == "Membership Fee (Com)" ||
                                ds_MSNo.Tables[0].Rows[0]["Particular"].ToString() == "Membership Fee (Corporate)" ||
                                ds_MSNo.Tables[0].Rows[0]["Particular"].ToString() == "Membership Fee Corporate (Com)"
                            )
                            {
                                /// %%%%%%%% Start %%%%% Get the New Membership No
                                SqlParameter[] param =
                                {
                                        new SqlParameter("@Task","Generate_New_MembershipNo")
                                    };
                                DataSet dst = new DataSet();
                                dst = cls_dl_TFR.TranferRead(param);
                                txtMembershipNo.Text = dst.Tables[0].Rows[0]["MembershipNo"].ToString();
                                /// %%%%%%%% End %%%%% Get the New Membership No
                            }
                            else if (ds_MSNo.Tables[0].Rows[0]["Particular"].ToString() == "Dual Membership Fee" ||
                                     ds_MSNo.Tables[0].Rows[0]["Particular"].ToString() == "Dual Membership Fee (Com)" ||
                                     ds_MSNo.Tables[0].Rows[0]["Particular"].ToString() == "Dual Membership Fee (Corporate)" ||
                                     ds_MSNo.Tables[0].Rows[0]["Particular"].ToString() == "Dual Membership Fee Corporate (Com)")
                            {

                                /// %%%%%%%% Start %%%%% Get the New Membership No
                                SqlParameter[] param =
                                {
                                      new SqlParameter("@Task","Generate_New_MembershipNo")
                                    };
                                DataSet dst = new DataSet();
                                dst = cls_dl_TFR.TranferRead(param);
                                txtMembershipNo.Text = dst.Tables[0].Rows[0]["MembershipNo"].ToString();
                                /// %%%%%%%% End %%%%% Get the New Membership No
                                /// Get 2nd Membership No


                                SqlParameter[] paramd =
                                {
                                      new SqlParameter("@Task","Generate_New_MembershipNo_Dual")
                                    };
                                DataSet dstd = new DataSet();
                                dstd = cls_dl_TFR.TranferRead(paramd);
                                txtMembershipNoDual.Text = dstd.Tables[0].Rows[0]["MembershipNo"].ToString();

                            }
                            else if (ds_MSNo.Tables[0].Rows[0]["Particular"].ToString() == "Triple Membership Fee" ||
                                     ds_MSNo.Tables[0].Rows[0]["Particular"].ToString() == "Triple Membership Fee (Com)" ||
                                     ds_MSNo.Tables[0].Rows[0]["Particular"].ToString() == "Triple Membership Fee (Corporate)" ||
                                     ds_MSNo.Tables[0].Rows[0]["Particular"].ToString() == "Triple Membership Fee Corporate (Com)")
                            {
                                /// %%%%%%%% Start %%%%% Get the New Membership No
                                SqlParameter[] param =
                                {
                                      new SqlParameter("@Task","Generate_New_MembershipNo")
                                };
                                DataSet dst = new DataSet();
                                dst = cls_dl_TFR.TranferRead(param);
                                txtMembershipNo.Text = dst.Tables[0].Rows[0]["MembershipNo"].ToString();
                                /// %%%%%%%% End %%%%% Get the New Membership No

                                /// Get 2nd Membership No
                                SqlParameter[] paramd =
                                {
                                      new SqlParameter("@Task","Generate_New_MembershipNo_Dual")
                                };
                                DataSet dstd = new DataSet();
                                dstd = cls_dl_TFR.TranferRead(paramd);
                                txtMembershipNoDual.Text = dstd.Tables[0].Rows[0]["MembershipNo"].ToString();

                                /// Get 3rd Membership No
                                SqlParameter[] paramt =
                                {
                                      new SqlParameter("@Task","Generate_New_MembershipNo_Triple")
                                };
                                DataSet dstt = new DataSet();
                                dstt = cls_dl_TFR.TranferRead(paramt);
                                txtMembershipNoTriple.Text = dstt.Tables[0].Rows[0]["MembershipNo"].ToString();
                            }

                            else
                            {
                                MessageBox.Show("Please Submit the Membership Fee.");
                                membership_infogroupBox.Enabled = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Submit the Membership Fee.");
                            membership_infogroupBox.Enabled = false;
                        }
                        #endregion
                    }
                    else if (dpOwnerCategory.SelectedItem.Text == "Svc Benifit")
                    {
                        #region Svc Benifit

                        #endregion
                    }
                    else
                    {
                        MessageBox.Show("Please Select at Least One Radio Button.");
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frmReadyForMemberShipAfterTransfer_Load(null, null);
        }

        private void btnMembershipNo_Click(object sender, EventArgs e)
        {
            try
            {

                #region Check File No. is Exist Or Not in Database

                SqlParameter[] prm_f =
                {
                    new SqlParameter("@Task","CheckFileNo"),
                    new SqlParameter("@FileNo",txtFileNo.Text)
                };
                DataSet dst = cls_dl_Membership.Membership_All_Retrive(prm_f);
                if (dst.Tables.Count > 0)
                {
                    if (dst.Tables[0].Rows.Count > 0)
                    {
                        #region Code
                        if (!string.IsNullOrEmpty(txtMembershipNo.Text) || !string.IsNullOrEmpty(txtMembershipNoDual.Text) || !string.IsNullOrEmpty(txtMembershipNoTriple.Text))
                        {
                            #region Code
                            string txt = "";
                            if (dpOwnerCategory.SelectedItem.ToString() == "Transfer")
                            {
                                txt = "Transfer";
                            }
                            else if (dpOwnerCategory.SelectedItem.ToString() == "Allocation" || dpOwnerCategory.SelectedItem.ToString() == "Svc Benifit")
                            {
                                txt = "Investor_SvcBenifit";
                            }
                            else if (dpOwnerCategory.SelectedItem.ToString() == "Com Files" || dpOwnerCategory.SelectedItem.ToString() == "Direct Selling")
                            {
                                txt = "Com Files";
                            }

                            if (dpOwnerCategory.SelectedItem.ToString() == "Transfer")
                            {
                                #region
                                if (ds_getChallanData.Tables.Count > 0)
                                {

                                    if (ds_getChallanData.Tables[0].Rows.Count > 0)
                                    {
                                        if (ds_getChallanData.Tables[0].Rows[0]["Particular"].ToString().ToLower() == "Membership Fee".ToLower() ||
                                             ds_getChallanData.Tables[0].Rows[0]["Particular"].ToString().ToLower() == "Membership Fee (Com)".ToLower() ||
                                             ds_getChallanData.Tables[0].Rows[0]["Particular"].ToString().ToLower() == "Membership Fee (Corporate)".ToLower() ||
                                             ds_getChallanData.Tables[0].Rows[0]["Particular"].ToString().ToLower() == "Membership Fee Corporate (Com)".ToLower()
                                           )
                                        {
                                            #region
                                            SqlParameter[] prm =
                                             {
                                                   new SqlParameter("@Task","InsertNewDPR_UpdateCurrentToTransferee"),
                                                   new SqlParameter("@NICNICOP",txtCNIC.Text),
                                                   new SqlParameter("@MembershipNo", txtMembershipNo.Text),
                                                   new SqlParameter("@FilePlotShopVillaApartmentNo",txtFileNo.Text),
                                                   new SqlParameter("@Name",txtName.Text),
                                                   new SqlParameter("@Father",txtFatherName.Text),
                                                   new SqlParameter("@HusbandWife_Name",txtHusbandName.Text),
                                                   new SqlParameter("@NDCNo",ndcNo),
                                                   new SqlParameter("@user_ID",Models.clsUser.ID),
                                                   new SqlParameter("@text",txt)
                                             };
                                            int rslt = cls_dl_Membership.Membership_All_NonQuery(prm);
                                            if (rslt > 0)
                                            {
                                                MessageBox.Show("Successfull.");
                                                frmReadyForMemberShipAfterTransfer_Load(null, null);
                                                grp_membership.Enabled = false;
                                                Clear();
                                            }
                                            #endregion
                                        }
                                        else if (ds_getChallanData.Tables[0].Rows[0]["Particular"].ToString().ToLower() == "Dual Membership Fee".ToLower() ||
                                                 ds_getChallanData.Tables[0].Rows[0]["Particular"].ToString().ToLower() == "Dual Membership Fee (Corporate)".ToLower() ||
                                                 ds_getChallanData.Tables[0].Rows[0]["Particular"].ToString().ToLower() == "Dual Membership Fee (Com)".ToLower() ||
                                                 ds_getChallanData.Tables[0].Rows[0]["Particular"].ToString().ToLower() == "Dual Membership Fee Corporate (Com)".ToLower())
                                        {
                                            #region
                                            SqlParameter[] prm =
                                            {
                                                    new SqlParameter("@Task","InsertNewDPR_UpdateCurrentToTransferee"),
                                                    new SqlParameter("@NICNICOP",txtCNIC.Text),
                                                    new SqlParameter("@MembershipNo", txtMembershipNo.Text),
                                                    new SqlParameter("@FilePlotShopVillaApartmentNo",txtFileNo.Text),
                                                    new SqlParameter("@Name",txtName.Text),
                                                    new SqlParameter("@Father",txtFatherName.Text),
                                                    new SqlParameter("@HusbandWife_Name",txtHusbandName.Text),
                                                    new SqlParameter("@NDCNo",ndcNo),
                                                    new SqlParameter("@user_ID",Models.clsUser.ID),
                                                    new SqlParameter("@text",txt)
                                            };
                                            int rslt = cls_dl_Membership.Membership_All_NonQuery(prm);
                                            //if (rslt > 0)
                                            //{
                                            //    MessageBox.Show("Successfull.");
                                            //    frmReadyForMemberShipAfterTransfer_Load(null, null);
                                            //    grp_membership.Enabled = false;
                                            //    Clear();
                                            //}


                                            SqlParameter[] prm1 =
                                            {
                                                    new SqlParameter("@Task","InsertNewDPR_UpdateCurrentToTransferee"),
                                                    new SqlParameter("@NICNICOP",txtCNICNoDual.Text),
                                                    new SqlParameter("@MembershipNo", txtMembershipNoDual.Text),
                                                    new SqlParameter("@FilePlotShopVillaApartmentNo",txtFileNo.Text),
                                                    new SqlParameter("@Name",txtNameDual.Text),
                                                    new SqlParameter("@Father",txtFatherNameDual.Text),
                                                    new SqlParameter("@HusbandWife_Name",txtHusbandNameDual.Text),
                                                    new SqlParameter("@NDCNo",ndcNo),
                                                    new SqlParameter("@user_ID",Models.clsUser.ID),
                                                    new SqlParameter("@text",txt)
                                            };
                                            int rslt1 = cls_dl_Membership.Membership_All_NonQuery(prm1);
                                            if (rslt1 > 0)
                                            {
                                                MessageBox.Show("Successfull.");
                                                frmReadyForMemberShipAfterTransfer_Load(null, null);
                                                grp_membership.Enabled = false;
                                                Clear();
                                            }
                                            #endregion
                                        }
                                        else if (ds_getChallanData.Tables[0].Rows[0]["Particular"].ToString().ToLower() == "Triple Membership Fee".ToLower() ||
                                                 ds_getChallanData.Tables[0].Rows[0]["Particular"].ToString().ToLower() == "Triple Membership Fee (Corporate)".ToLower() ||
                                                 ds_getChallanData.Tables[0].Rows[0]["Particular"].ToString().ToLower() == "Triple Membership Fee (Com)".ToLower() ||
                                                 ds_getChallanData.Tables[0].Rows[0]["Particular"].ToString().ToLower() == "Triple Membership Fee Corporate (Com)".ToLower())
                                        {
                                            #region
                                            SqlParameter[] prm =
                                            {
                                                    new SqlParameter("@Task","InsertNewDPR_UpdateCurrentToTransferee"),
                                                    new SqlParameter("@NICNICOP",txtCNIC.Text),
                                                    new SqlParameter("@MembershipNo", txtMembershipNo.Text),
                                                    new SqlParameter("@FilePlotShopVillaApartmentNo",txtFileNo.Text),
                                                    new SqlParameter("@Name",txtName.Text),
                                                    new SqlParameter("@Father",txtFatherName.Text),
                                                    new SqlParameter("@HusbandWife_Name",txtHusbandName.Text),
                                                    new SqlParameter("@NDCNo",ndcNo),
                                                    new SqlParameter("@user_ID",Models.clsUser.ID),
                                                    new SqlParameter("@text",txt)
                                            };
                                            int rslt = cls_dl_Membership.Membership_All_NonQuery(prm);
                                            //if (rslt > 0)
                                            //{
                                            //    MessageBox.Show("Successfull.");
                                            //    frmReadyForMemberShipAfterTransfer_Load(null, null);
                                            //    grp_membership.Enabled = false;
                                            //    Clear();
                                            //}


                                            SqlParameter[] prm1 =
                                            {
                                                     new SqlParameter("@Task","InsertNewDPR_UpdateCurrentToTransferee"),
                                                     new SqlParameter("@NICNICOP",txtCNICNoDual.Text),
                                                     new SqlParameter("@MembershipNo", txtMembershipNoDual.Text),
                                                     new SqlParameter("@FilePlotShopVillaApartmentNo",txtFileNo.Text),
                                                     new SqlParameter("@Name",txtNameDual.Text),
                                                     new SqlParameter("@Father",txtFatherNameDual.Text),
                                                     new SqlParameter("@HusbandWife_Name",txtHusbandNameDual.Text),
                                                     new SqlParameter("@NDCNo",ndcNo),
                                                     new SqlParameter("@user_ID",Models.clsUser.ID),
                                                     new SqlParameter("@text",txt)
                                            };
                                            int rslt1 = cls_dl_Membership.Membership_All_NonQuery(prm1);
                                            //if (rslt1 > 0)
                                            //{
                                            //    MessageBox.Show("Successfull.");
                                            //    frmReadyForMemberShipAfterTransfer_Load(null, null);
                                            //    grp_membership.Enabled = false;
                                            //    Clear();
                                            //}

                                            SqlParameter[] prm2 =
                                            {
                                                     new SqlParameter("@Task","InsertNewDPR_UpdateCurrentToTransferee"),
                                                     new SqlParameter("@NICNICOP",txtCNICNoTriple.Text),
                                                     new SqlParameter("@MembershipNo", txtMembershipNoTriple.Text),
                                                     new SqlParameter("@FilePlotShopVillaApartmentNo",txtFileNo.Text),
                                                     new SqlParameter("@Name",txtNameTriple.Text),
                                                     new SqlParameter("@Father",txtFatherNameTriple.Text),
                                                     new SqlParameter("@HusbandWife_Name",txtHusbandNameTriple.Text),
                                                     new SqlParameter("@NDCNo",ndcNo),
                                                     new SqlParameter("@user_ID",Models.clsUser.ID),
                                                     new SqlParameter("@text",txt)
                                            };
                                            int rslt2 = cls_dl_Membership.Membership_All_NonQuery(prm2);
                                            if (rslt2 > 0)
                                            {
                                                MessageBox.Show("Successfull.");
                                                frmReadyForMemberShipAfterTransfer_Load(null, null);
                                                grp_membership.Enabled = false;
                                                Clear();
                                            }
                                            #endregion
                                        }


                                        else if (ds_getChallanData.Tables[0].Rows[0]["Particular"].ToString().ToLower() == "Quad Membership Fee".ToLower() ||
                                             ds_getChallanData.Tables[0].Rows[0]["Particular"].ToString().ToLower() == "Quad Membership Fee (Com)".ToLower())
                                        {
                                            #region
                                            SqlParameter[] prm =
                                            {
                                                    new SqlParameter("@Task","InsertNewDPR_UpdateCurrentToTransferee"),
                                                    new SqlParameter("@NICNICOP",txtCNIC.Text),
                                                    new SqlParameter("@MembershipNo", txtMembershipNo.Text),
                                                    new SqlParameter("@FilePlotShopVillaApartmentNo",txtFileNo.Text),
                                                    new SqlParameter("@Name",txtName.Text),
                                                    new SqlParameter("@Father",txtFatherName.Text),
                                                    new SqlParameter("@HusbandWife_Name",txtHusbandName.Text),
                                                    new SqlParameter("@NDCNo",ndcNo),
                                                    new SqlParameter("@user_ID",Models.clsUser.ID),
                                                    new SqlParameter("@text",txt)
                                            };
                                            int rslt = cls_dl_Membership.Membership_All_NonQuery(prm);
                                            //if (rslt > 0)
                                            //{
                                            //    MessageBox.Show("Successfull.");
                                            //    frmReadyForMemberShipAfterTransfer_Load(null, null);
                                            //    grp_membership.Enabled = false;
                                            //    Clear();
                                            //}


                                            SqlParameter[] prm1 =
                                            {
                                                   new SqlParameter("@Task","InsertNewDPR_UpdateCurrentToTransferee"),
                                                   new SqlParameter("@NICNICOP",txtCNICNoDual.Text),
                                                   new SqlParameter("@MembershipNo", txtMembershipNoDual.Text),
                                                   new SqlParameter("@FilePlotShopVillaApartmentNo",txtFileNo.Text),
                                                   new SqlParameter("@Name",txtNameDual.Text),
                                                   new SqlParameter("@Father",txtFatherNameDual.Text),
                                                   new SqlParameter("@HusbandWife_Name",txtHusbandNameDual.Text),
                                                   new SqlParameter("@NDCNo",ndcNo),
                                                   new SqlParameter("@user_ID",Models.clsUser.ID),
                                                   new SqlParameter("@text",txt)
                                            };
                                            int rslt1 = cls_dl_Membership.Membership_All_NonQuery(prm1);
                                            //if (rslt1 > 0)
                                            //{
                                            //    MessageBox.Show("Successfull.");
                                            //    frmReadyForMemberShipAfterTransfer_Load(null, null);
                                            //    grp_membership.Enabled = false;
                                            //    Clear();
                                            //}

                                            SqlParameter[] prm2 =
                                            {
                                                  new SqlParameter("@Task","InsertNewDPR_UpdateCurrentToTransferee"),
                                                  new SqlParameter("@NICNICOP",txtCNICNoTriple.Text),
                                                  new SqlParameter("@MembershipNo", txtMembershipNoTriple.Text),
                                                  new SqlParameter("@FilePlotShopVillaApartmentNo",txtFileNo.Text),
                                                  new SqlParameter("@Name",txtNameTriple.Text),
                                                  new SqlParameter("@Father",txtFatherNameTriple.Text),
                                                  new SqlParameter("@HusbandWife_Name",txtHusbandNameTriple.Text),
                                                  new SqlParameter("@NDCNo",ndcNo),
                                                  new SqlParameter("@user_ID",Models.clsUser.ID),
                                                  new SqlParameter("@text",txt)
                                            };
                                            int rslt2 = cls_dl_Membership.Membership_All_NonQuery(prm2);


                                            SqlParameter[] prm3 =
                                            {
                                                  new SqlParameter("@Task","InsertNewDPR_UpdateCurrentToTransferee"),
                                                  new SqlParameter("@NICNICOP",txtCNICNoQuad.Text),
                                                  new SqlParameter("@MembershipNo", txtMembershipNoQuad.Text),
                                                  new SqlParameter("@FilePlotShopVillaApartmentNo",txtFileNo.Text),
                                                  new SqlParameter("@Name",txtNameQuad.Text),
                                                  new SqlParameter("@Father",txtFatherNameQuad.Text),
                                                  new SqlParameter("@HusbandWife_Name",txtHusbandNameQuad.Text),
                                                  new SqlParameter("@NDCNo",ndcNo),
                                                  new SqlParameter("@user_ID",Models.clsUser.ID),
                                                  new SqlParameter("@text",txt)
                                           };
                                            int rslt3 = cls_dl_Membership.Membership_All_NonQuery(prm3);
                                            if (rslt3 > 0)
                                            {
                                                MessageBox.Show("Successfull.");
                                                frmReadyForMemberShipAfterTransfer_Load(null, null);
                                                grp_membership.Enabled = false;
                                                Clear();
                                            }
                                            #endregion
                                        }

                                    }
                                    else if (ds_getChallanData.Tables[1].Rows.Count > 0)
                                    {
                                        if (ds_getChallanData.Tables[1].Rows[0]["NDCType"].ToString() == "LegalHeirSvc")
                                        {
                                            #region
                                            SqlParameter[] prm =
                                            {
                                                new SqlParameter("@Task","InsertNewDPR_UpdateCurrentToTransferee"),
                                                new SqlParameter("@NICNICOP",txtCNIC.Text),
                                                new SqlParameter("@MembershipNo", txtMembershipNo.Text),
                                                new SqlParameter("@FilePlotShopVillaApartmentNo",txtFileNo.Text),
                                                new SqlParameter("@Name",txtName.Text),
                                                new SqlParameter("@Father",txtFatherName.Text),
                                                new SqlParameter("@HusbandWife_Name",txtHusbandName.Text),
                                                new SqlParameter("@NDCNo",ndcNo),
                                                new SqlParameter("@user_ID",Models.clsUser.ID),
                                                new SqlParameter("@text",txt)
                                            };
                                            int rslt = cls_dl_Membership.Membership_All_NonQuery(prm);
                                            if (rslt > 0)
                                            {
                                                MessageBox.Show("Successfull.");
                                                frmReadyForMemberShipAfterTransfer_Load(null, null);
                                                grp_membership.Enabled = false;
                                                Clear();
                                            }
                                            #endregion
                                        }
                                    }




                                }


                                #endregion
                            }

                            else if (dpOwnerCategory.SelectedItem.ToString() == "Svc Benifit")
                            {
                                #region 

                                if (rdb1.CheckState == CheckState.Checked)
                                {

                                    SqlParameter[] prm =
                                    {
                                   new SqlParameter("@Task","InsertNewDPR_UpdateCurrentToTransferee"),
                                   new SqlParameter("@NICNICOP",txtCNICNo.Text),
                                   new SqlParameter("@MembershipNo", txtMembershipNo.Text),
                                   new SqlParameter("@FilePlotShopVillaApartmentNo",txtFileNo.Text),
                                   new SqlParameter("@Name",txtName.Text),
                                   new SqlParameter("@Father",txtFatherName.Text),
                                   new SqlParameter("@HusbandWife_Name",txtHusbandName.Text),
                                   new SqlParameter("@NDCNo",ndcNo),
                                   new SqlParameter("@user_ID",Models.clsUser.ID),
                                   new SqlParameter("@text",txt)
                                   };
                                    int rslt = cls_dl_Membership.Membership_All_NonQuery(prm);
                                    if (rslt > 0)
                                    {
                                        MessageBox.Show("Successfull.");
                                        frmReadyForMemberShipAfterTransfer_Load(null, null);
                                        grp_membership.Enabled = false;
                                        Clear();
                                    }
                                }
                                else if (rdb2.CheckState == CheckState.Checked)
                                {
                                    SqlParameter[] prm =
                                     {
                                    new SqlParameter("@Task","InsertNewDPR_UpdateCurrentToTransferee"),
                                    new SqlParameter("@NICNICOP",txtCNICNo.Text),
                                    new SqlParameter("@MembershipNo", txtMembershipNo.Text),
                                    new SqlParameter("@FilePlotShopVillaApartmentNo",txtFileNo.Text),
                                    new SqlParameter("@Name",txtName.Text),
                                    new SqlParameter("@Father",txtFatherName.Text),
                                    new SqlParameter("@HusbandWife_Name",txtHusbandName.Text),
                                    new SqlParameter("@NDCNo",ndcNo),
                                    new SqlParameter("@user_ID",Models.clsUser.ID),
                                    new SqlParameter("@text",txt)
                                    };
                                    int rslt = cls_dl_Membership.Membership_All_NonQuery(prm);
                                    if (rslt > 0)
                                    {
                                        /// %%%%%%%% Start %%%%% Get the New Membership No
                                        SqlParameter[] param =
                                        {
                                         new SqlParameter("@Task","Generate_New_MembershipNo")
                                         };
                                        DataSet dst0 = new DataSet();
                                        dst0 = cls_dl_TFR.TranferRead(param);
                                        txtMembershipNo.Text = dst0.Tables[0].Rows[0]["MembershipNo"].ToString();
                                        /// %%%%%%%% End %%%%% Get the New Membership No
                                        /// 

                                        SqlParameter[] prm1 =
                                        {
                                        new SqlParameter("@Task","InsertNewDPR_UpdateCurrentToTransferee"),
                                        new SqlParameter("@MembershipNo", txtMembershipNoDual.Text),
                                        new SqlParameter("@NICNICOP",txtCNICNoDual.Text),
                                        new SqlParameter("@FilePlotShopVillaApartmentNo",txtFileNo.Text),
                                        new SqlParameter("@Name",txtNameDual.Text),
                                        new SqlParameter("@Father",txtFatherNameDual.Text),
                                        new SqlParameter("@HusbandWife_Name",txtHusbandNameDual.Text),
                                        new SqlParameter("@NDCNo",ndcNo),
                                        new SqlParameter("@user_ID",Models.clsUser.ID),
                                        new SqlParameter("@text",txt)
                                        };
                                        int rslt1 = cls_dl_Membership.Membership_All_NonQuery(prm1);
                                        if (rslt1 > 0)
                                        {
                                            MessageBox.Show("Successfull.");
                                            frmReadyForMemberShipAfterTransfer_Load(null, null);
                                            grp_membership.Enabled = false;
                                            Clear();
                                        }

                                    }
                                }
                                else if (rdb3.CheckState == CheckState.Checked)
                                {
                                    SqlParameter[] prm =
                                   {
                                    new SqlParameter("@Task","InsertNewDPR_UpdateCurrentToTransferee"),
                                    new SqlParameter("@NICNICOP",txtCNICNo.Text),
                                    new SqlParameter("@MembershipNo", txtMembershipNo.Text),
                                    new SqlParameter("@FilePlotShopVillaApartmentNo",txtFileNo.Text),
                                    new SqlParameter("@Name",txtName.Text),
                                    new SqlParameter("@Father",txtFatherName.Text),
                                    new SqlParameter("@NDCNo",ndcNo),
                                    new SqlParameter("@user_ID",Models.clsUser.ID),
                                    new SqlParameter("@text",txt)
                                    };
                                    int rslt = cls_dl_Membership.Membership_All_NonQuery(prm);
                                    if (rslt > 0)
                                    {
                                        /// %%%%%%%% Start %%%%% Get the New Membership No
                                        SqlParameter[] param =
                                        {
                                        new SqlParameter("@Task","Generate_New_MembershipNo")
                                        };
                                        DataSet dst1 = new DataSet();
                                        dst1 = cls_dl_TFR.TranferRead(param);
                                        txtMembershipNo.Text = dst1.Tables[0].Rows[0]["MembershipNo"].ToString();
                                        /// %%%%%%%% End %%%%% Get the New Membership No
                                        /// 

                                        SqlParameter[] prm1 =
                                        {
                                          new SqlParameter("@Task","InsertNewDPR_UpdateCurrentToTransferee"),
                                          new SqlParameter("@MembershipNo", txtMembershipNoDual.Text),
                                          new SqlParameter("@NICNICOP",txtCNICNoDual.Text),
                                          new SqlParameter("@FilePlotShopVillaApartmentNo",txtFileNo.Text),
                                          new SqlParameter("@Name",txtNameDual.Text),
                                          new SqlParameter("@Father",txtFatherNameDual.Text),
                                          new SqlParameter("@HusbandWife_Name",txtHusbandNameDual.Text),
                                          new SqlParameter("@NDCNo",ndcNo),
                                          new SqlParameter("@user_ID",Models.clsUser.ID),
                                          new SqlParameter("@text",txt)
                                        };
                                        int rslt1 = cls_dl_Membership.Membership_All_NonQuery(prm);
                                        DataSet dst2 = new DataSet();
                                        if (rslt1 > 0)
                                        {
                                            /// %%%%%%%% Start %%%%% Get the New Membership No
                                            SqlParameter[] param1 =
                                            {
                                              new SqlParameter("@Task","Generate_New_MembershipNo")
                                            };

                                            dst2 = cls_dl_TFR.TranferRead(param1);
                                            txtMembershipNo.Text = dst2.Tables[0].Rows[0]["MembershipNo"].ToString();
                                            /// %%%%%%%% End %%%%% Get the New Membership No
                                            /// 

                                        }
                                        SqlParameter[] prm2 =
                                        {
                                          new SqlParameter("@Task","InsertNewDPR_UpdateCurrentToTransferee"),
                                          new SqlParameter("@MembershipNo", dst2.Tables[0].Rows[0]["MembershipNo"].ToString()),
                                          new SqlParameter("@NICNICOP",txtCNICNoTriple.Text),
                                          new SqlParameter("@FilePlotShopVillaApartmentNo",txtFileNo.Text),
                                          new SqlParameter("@Name",txtNameTriple.Text),
                                          new SqlParameter("@Father",txtFatherNameTriple.Text),
                                          new SqlParameter("@HusbandWife_Name",txtHusbandNameTriple.Text),
                                          new SqlParameter("@NDCNo",ndcNo),
                                          new SqlParameter("@user_ID",Models.clsUser.ID),
                                          new SqlParameter("@text",txt)
                                        };
                                        int rslt2 = cls_dl_Membership.Membership_All_NonQuery(prm);
                                        if (rslt2 > 0)
                                        {
                                            MessageBox.Show("Successfull.");
                                            frmReadyForMemberShipAfterTransfer_Load(null, null);
                                            grp_membership.Enabled = false;
                                            Clear();
                                        }
                                    }
                                }
                                #endregion
                            }
                            else if (dpOwnerCategory.SelectedItem.ToString() == "Com Files" || dpOwnerCategory.SelectedItem.ToString() == "Direct Selling")
                            {
                                #region Com Files
                                SqlParameter[] prm =
                                {
                                       new SqlParameter("@Task","InsertNewDPR_UpdateCurrentToTransferee"),
                                       new SqlParameter("@NICNICOP",txtCNIC.Text),
                                       new SqlParameter("@MembershipNo", txtMembershipNo.Text),
                                       new SqlParameter("@FilePlotShopVillaApartmentNo",txtFileNo.Text),
                                       new SqlParameter("@Name",txtName.Text),
                                       new SqlParameter("@Father",txtFatherName.Text),
                                       new SqlParameter("@HusbandWife_Name",txtHusbandName.Text),
                                       new SqlParameter("@NDCNo",ndcNo),
                                       new SqlParameter("@user_ID",Models.clsUser.ID),
                                       new SqlParameter("@text",txt)
                                };
                                int rslt = cls_dl_Membership.Membership_All_NonQuery(prm);
                                if (rslt > 0)
                                {
                                    MessageBox.Show("Successfull.");
                                    frmReadyForMemberShipAfterTransfer_Load(null, null);
                                    grp_membership.Enabled = false;
                                    Clear();
                                }
                                #endregion
                            }
                            else if (dpOwnerCategory.SelectedItem.ToString() == "Allocation")
                            {
                                #region for Allocation Files
                                string prt = ds_MSNo.Tables[0].Rows[0]["Particular"].ToString();
                                if (prt == "Membership Fee" || prt == "Membership Fee (Corporate)")
                                {

                                    SqlParameter[] prm =
                                    {
                                    new SqlParameter("@Task","InsertNewDPR_UpdateCurrentToTransferee"),
                                    new SqlParameter("@NICNICOP",txtCNICNo.Text),
                                    new SqlParameter("@MembershipNo", txtMembershipNo.Text),
                                    new SqlParameter("@FilePlotShopVillaApartmentNo",txtFileNo.Text),
                                    new SqlParameter("@Name",txtName.Text),
                                    new SqlParameter("@Father",txtFatherName.Text),
                                    new SqlParameter("@HusbandWife_Name",txtHusbandName.Text),
                                    new SqlParameter("@NDCNo",ndcNo),
                                    new SqlParameter("@user_ID",Models.clsUser.ID),
                                    new SqlParameter("@text",txt),
                                    new SqlParameter("@ChalanNo",txtx_chalanno.Text)
                                    };
                                    int rslt = cls_dl_Membership.Membership_All_NonQuery(prm);
                                    if (rslt > 0)
                                    {
                                        MessageBox.Show("Successfull.");
                                        frmReadyForMemberShipAfterTransfer_Load(null, null);
                                        grp_membership.Enabled = false;
                                        Clear();
                                    }
                                }
                                else if (prt == "Dual Membership Fee" || prt == "Dual Membership Fee (Corporate)")
                                {
                                    SqlParameter[] prm =
                                    {
                                    new SqlParameter("@Task","InsertNewDPR_UpdateCurrentToTransferee"),
                                    new SqlParameter("@NICNICOP",txtCNICNo.Text),
                                    new SqlParameter("@MembershipNo", txtMembershipNo.Text),
                                    new SqlParameter("@FilePlotShopVillaApartmentNo",txtFileNo.Text),
                                    new SqlParameter("@Name",txtName.Text),
                                    new SqlParameter("@Father",txtFatherName.Text),
                                    new SqlParameter("@HusbandWife_Name",txtHusbandName.Text),
                                    new SqlParameter("@NDCNo",ndcNo),
                                    new SqlParameter("@user_ID",Models.clsUser.ID),
                                    new SqlParameter("@text",txt),
                                    new SqlParameter("@ChalanNo",txtx_chalanno.Text)
                                    };
                                    int rslt = cls_dl_Membership.Membership_All_NonQuery(prm);
                                    if (rslt > 0)
                                    {
                                        /// %%%%%%%% Start %%%%% Get the New Membership No
                                        SqlParameter[] param =
                                        {
                                         new SqlParameter("@Task","Generate_New_MembershipNo")
                                         };
                                        DataSet dst0 = new DataSet();
                                        dst0 = cls_dl_TFR.TranferRead(param);
                                        txtMembershipNo.Text = dst0.Tables[0].Rows[0]["MembershipNo"].ToString();
                                        /// %%%%%%%% End %%%%% Get the New Membership No
                                        /// 

                                        SqlParameter[] prm1 =
                                        {
                                        new SqlParameter("@Task","InsertNewDPR_UpdateCurrentToTransferee"),
                                        new SqlParameter("@MembershipNo", txtMembershipNoDual.Text),
                                        new SqlParameter("@NICNICOP",txtCNICNoDual.Text),
                                        new SqlParameter("@FilePlotShopVillaApartmentNo",txtFileNo.Text),
                                        new SqlParameter("@Name",txtNameDual.Text),
                                        new SqlParameter("@Father",txtFatherNameDual.Text),
                                        new SqlParameter("@HusbandWife_Name",txtHusbandNameDual.Text),
                                        new SqlParameter("@NDCNo",ndcNo),
                                        new SqlParameter("@user_ID",Models.clsUser.ID),
                                        new SqlParameter("@text",txt),
                                        new SqlParameter("@ChalanNo",txtx_chalanno.Text)
                                        };
                                        int rslt1 = cls_dl_Membership.Membership_All_NonQuery(prm);
                                        if (rslt1 > 0)
                                        {
                                            MessageBox.Show("Successfull.");
                                            frmReadyForMemberShipAfterTransfer_Load(null, null);
                                            grp_membership.Enabled = false;
                                            Clear();
                                        }

                                    }
                                }
                                else if (prt == "Triple Membership Fee" || prt == "Triple Membership Fee (Corporate)")
                                {
                                    SqlParameter[] prm =
                                    {
                                    new SqlParameter("@Task","InsertNewDPR_UpdateCurrentToTransferee"),
                                    new SqlParameter("@NICNICOP",txtCNICNo.Text),
                                    new SqlParameter("@MembershipNo", txtMembershipNo.Text),
                                    new SqlParameter("@FilePlotShopVillaApartmentNo",txtFileNo.Text),
                                    new SqlParameter("@Name",txtName.Text),
                                    new SqlParameter("@Father",txtFatherName.Text),
                                    new SqlParameter("@NDCNo",ndcNo),
                                    new SqlParameter("@user_ID",Models.clsUser.ID),
                                    new SqlParameter("@text",txt),
                                    new SqlParameter("@ChalanNo",txtx_chalanno.Text)
                                    };
                                    int rslt = cls_dl_Membership.Membership_All_NonQuery(prm);
                                    if (rslt > 0)
                                    {
                                        /// %%%%%%%% Start %%%%% Get the New Membership No
                                        SqlParameter[] param =
                                        {
                                        new SqlParameter("@Task","Generate_New_MembershipNo")
                                        };
                                        DataSet dst1 = new DataSet();
                                        dst1 = cls_dl_TFR.TranferRead(param);
                                        txtMembershipNo.Text = dst1.Tables[0].Rows[0]["MembershipNo"].ToString();
                                        /// %%%%%%%% End %%%%% Get the New Membership No
                                        /// 

                                        SqlParameter[] prm1 =
                                        {
                                        new SqlParameter("@Task","InsertNewDPR_UpdateCurrentToTransferee"),
                                        new SqlParameter("@MembershipNo", txtMembershipNoDual.Text),
                                        new SqlParameter("@NICNICOP",txtCNICNoDual.Text),
                                        new SqlParameter("@FilePlotShopVillaApartmentNo",txtFileNo.Text),
                                        new SqlParameter("@Name",txtNameDual.Text),
                                        new SqlParameter("@Father",txtFatherNameDual.Text),
                                        new SqlParameter("@HusbandWife_Name",txtHusbandNameDual.Text),
                                        new SqlParameter("@NDCNo",ndcNo),
                                        new SqlParameter("@user_ID",Models.clsUser.ID),
                                        new SqlParameter("@text",txt),
                                        new SqlParameter("@ChalanNo",txtx_chalanno.Text)
                                        };
                                        int rslt1 = cls_dl_Membership.Membership_All_NonQuery(prm);
                                        DataSet dst2 = new DataSet();
                                        if (rslt1 > 0)
                                        {
                                            /// %%%%%%%% Start %%%%% Get the New Membership No
                                            SqlParameter[] param1 =
                                            {
                                            new SqlParameter("@Task","Generate_New_MembershipNo")
                                            };

                                            dst2 = cls_dl_TFR.TranferRead(param1);
                                            txtMembershipNo.Text = dst2.Tables[0].Rows[0]["MembershipNo"].ToString();
                                            /// %%%%%%%% End %%%%% Get the New Membership No
                                            /// 

                                        }
                                        SqlParameter[] prm2 =
                                        {
                                        new SqlParameter("@Task","InsertNewDPR_UpdateCurrentToTransferee"),
                                        new SqlParameter("@MembershipNo", dst2.Tables[0].Rows[0]["MembershipNo"].ToString()),
                                        new SqlParameter("@NICNICOP",txtCNICNoTriple.Text),
                                        new SqlParameter("@FilePlotShopVillaApartmentNo",txtFileNo.Text),
                                        new SqlParameter("@Name",txtNameTriple.Text),
                                        new SqlParameter("@Father",txtFatherNameTriple.Text),
                                        new SqlParameter("@HusbandWife_Name",txtHusbandNameTriple.Text),
                                        new SqlParameter("@NDCNo",ndcNo),
                                        new SqlParameter("@user_ID",Models.clsUser.ID),
                                        new SqlParameter("@text",txt),
                                        new SqlParameter("@ChalanNo",txtx_chalanno.Text)
                                        };
                                        int rslt2 = cls_dl_Membership.Membership_All_NonQuery(prm);
                                        if (rslt2 > 0)
                                        {
                                            MessageBox.Show("Successfull.");
                                            frmReadyForMemberShipAfterTransfer_Load(null, null);
                                            grp_membership.Enabled = false;
                                            Clear();
                                        }
                                    }
                                }
                                #endregion
                            }

                            #endregion
                        }
                        else
                        {
                            MessageBox.Show("Membership No. is Missing.");
                        }
                        #endregion

                    }
                    else
                    {
                        MessageBox.Show("File No." + txtFileNo.Text + " is not Exist in Database." + Environment.NewLine +
                            "Please Enter File No. First.");
                    }
                }
                else
                {
                    MessageBox.Show("File No." + txtFileNo.Text + " is not Exist in Database." + Environment.NewLine +
                            "Please Enter File No. First.");
                }
                #endregion


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Clear()
        {
            txtx_chalanno.Text = "";
            txtFileNo.Text = "";

            txtMembershipNo.Text = "";
            txtMembershipNoDual.Text = "";
            txtMembershipNoTriple.Text = "";
            txtMembershipNoQuad.Text = "";

            txtCNICNo.Text = "";
            txtCNICNoDual.Text = "";
            txtCNICNoTriple.Text = "";
            txtCNICNoQuad.Text = "";

            txtName.Text = "";
            txtNameDual.Text = "";
            txtNameTriple.Text = "";
            txtNameQuad.Text = "";

            txtFatherName.Text = "";
            txtFatherNameDual.Text = "";
            txtFatherNameTriple.Text = "";
            txtFatherNameQuad.Text = "";

            txtHusbandName.Text = "";
            txtHusbandNameDual.Text = "";
            txtHusbandNameTriple.Text = "";
            txtHusbandNameQuad.Text = "";

        }
        private void btnAddNewMembershipforOther_Click(object sender, EventArgs e)
        {
            grp_membership.Enabled = true;
            gpCNICandFeeVerification.Enabled = false;
            membership_infogroupBox.Enabled = false;
            dpOwnerCategory.SelectedIndex = 0;
            dpOwnerCategory_SelectedIndexChanged(null, null);
            //  membership_infogroupBox.Enabled = true;
        }

        private void dpOwnerCategory_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (dpOwnerCategory.SelectedIndex == -1) // --- Select Category Text ---
            {
                gpCNICandFeeVerification.Enabled = false;
                membership_infogroupBox.Enabled = false;
                Clear();
            }
            else if (dpOwnerCategory.SelectedIndex == 1)   // Transfer
            {
                gpCNICandFeeVerification.Enabled = true;
                membership_infogroupBox.Enabled = false;
                txtCNIC.Enabled = true;
                txtx_chalanno.Enabled = false;
            }
            else if (dpOwnerCategory.SelectedIndex == 2) // Allocation
            {
                Clear();
                /// %%%%%%%% Start %%%%% Get the New Membership No
                SqlParameter[] param =
                {
                   new SqlParameter("@Task","Generate_New_MembershipNo")
                };
                DataSet dst = new DataSet();
                dst = cls_dl_TFR.TranferRead(param);
                txtMembershipNo.Text = dst.Tables[0].Rows[0]["MembershipNo"].ToString();
                /// %%%%%%%% End %%%%% Get the New Membership No
                gpCNICandFeeVerification.Enabled = true;
                membership_infogroupBox.Enabled = false;
                txtCNIC.Enabled = false;
                txtx_chalanno.Enabled = true;

            }
            else if (dpOwnerCategory.SelectedIndex == 3) // Svc Benefit
            {
                Clear();
                grpsvc.Enabled = true;
                gpCNICandFeeVerification.Enabled = false;
                membership_infogroupBox.Enabled = true;
                /// %%%%%%%% Start %%%%% Get the New Membership No
                SqlParameter[] param =
                {
                   new SqlParameter("@Task","Generate_New_MembershipNo")
                };
                DataSet dst = new DataSet();
                dst = cls_dl_TFR.TranferRead(param);
                txtMembershipNo.Text = dst.Tables[0].Rows[0]["MembershipNo"].ToString();
                /// %%%%%%%% End %%%%% Get the New Membership No
                txtCNIC.Enabled = false;
                txtx_chalanno.Enabled = true;
            }
            else if (dpOwnerCategory.SelectedIndex == 4) // Commercial Files
            {
                Clear();
                gpCNICandFeeVerification.Enabled = true;
                membership_infogroupBox.Enabled = true;
                /// %%%%%%%% Start %%%%% Get the New Membership No
                SqlParameter[] param =
                {
                   new SqlParameter("@Task","Generate_New_MembershipNo")
                };
                DataSet dst = new DataSet();
                dst = cls_dl_TFR.TranferRead(param);
                txtMembershipNo.Text = dst.Tables[0].Rows[0]["MembershipNo"].ToString();
                /// %%%%%%%% End %%%%% Get the New Membership No
                txtCNIC.Enabled = true;
                txtx_chalanno.Enabled = false;
            }
            else if (dpOwnerCategory.SelectedIndex == 5)  // Direct Selling Files
            {
                Clear();
                gpCNICandFeeVerification.Enabled = true;
                membership_infogroupBox.Enabled = true;
                /// %%%%%%%% Start %%%%% Get the New Membership No
                SqlParameter[] param =
                {
                   new SqlParameter("@Task","Generate_New_MembershipNo")
                };
                DataSet dst = new DataSet();
                dst = cls_dl_TFR.TranferRead(param);
                txtMembershipNo.Text = dst.Tables[0].Rows[0]["MembershipNo"].ToString();
                /// %%%%%%%% End %%%%% Get the New Membership No
                txtCNIC.Enabled = false;
                txtx_chalanno.Enabled = false;
                btnMembershipNo.Enabled = true;
                btn_CheckCNICNo.Enabled = false;
            }
        }

        private void txtCNIC_Validating(object sender, CancelEventArgs e)
        {
            btn_CheckCNICNo.Enabled = clsPluginHelper.RadformatValidator(Warning, Correct, Wrong,
             txtCNIC, "", new Regex("^([0-9]{5}-[0-9]{7}-[0-9]{1})|([0-9]{6}[-][0-9]{6}[-][0-9]{1})$"));
        }

        private void chkcnicclear_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkcnicclear.Checked)
            {
                txtCNIC.Text = "";
            }
        }

        private void chkchallannoclear_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkchallannoclear.Checked)
            {
                txtx_chalanno.Text = "";
            }
        }

        private void rdb2_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void rdb2_CheckStateChanged(object sender, EventArgs e)
        {
            if (rdb2.CheckState == CheckState.Checked)
            {
                if (!string.IsNullOrWhiteSpace(txtMembershipNo.Text))
                {
                    string firstMembershipNo = txtMembershipNo.Text;
                    string[] firstMembershipNoStrs = firstMembershipNo.Split('-');
                    string fistMembershipNoFirstPart = firstMembershipNoStrs.First();
                    int fistMembershipNoLastPart = Convert.ToInt32(firstMembershipNoStrs.Last());
                    int secondMembshipNoLastpart = fistMembershipNoLastPart + 1;
                    string secondMembershipNo = fistMembershipNoFirstPart + "-" + secondMembshipNoLastpart;

                    txtMembershipNoDual.Text = secondMembershipNo;

                    txtMembershipNoTriple.Clear();
                    txtMembershipNoQuad.Clear();
                }
            }
            if (rdb1.CheckState == CheckState.Checked)
            {
                txtMembershipNoDual.Clear();
                txtMembershipNoTriple.Clear();
                txtMembershipNoQuad.Clear();
            }
            if (rdb3.CheckState == CheckState.Checked)
            {
                if (!string.IsNullOrWhiteSpace(txtMembershipNo.Text))
                {
                    string firstMembershipNo = txtMembershipNo.Text;
                    string[] firstMembershipNoStrs = firstMembershipNo.Split('-');
                    string fistMembershipNoFirstPart = firstMembershipNoStrs.First();
                    int fistMembershipNoLastPart = Convert.ToInt32(firstMembershipNoStrs.Last());
                    int secondMembshipNoLastPart = fistMembershipNoLastPart + 1;
                    string secondMembershipNo = fistMembershipNoFirstPart + "-" + secondMembshipNoLastPart;
                    int thirdMembershpNoLastPart = fistMembershipNoLastPart + 2;
                    string thirdMembershipNo = fistMembershipNoFirstPart + "-" + thirdMembershpNoLastPart;

                    txtMembershipNoDual.Text = secondMembershipNo;
                    txtMembershipNoTriple.Text = thirdMembershipNo;

                    txtMembershipNoQuad.Clear();
                }
            }
            if (rdb4.CheckState == CheckState.Checked)
            {
                if (!string.IsNullOrWhiteSpace(txtMembershipNo.Text))
                {
                    string firstMembershipNo = txtMembershipNo.Text;
                    string[] firstMembershipNoStrs = firstMembershipNo.Split('-');
                    string fistMembershipNoFirstPart = firstMembershipNoStrs.First();
                    int fistMembershipNoLastPart = Convert.ToInt32(firstMembershipNoStrs.Last());
                    int secondMembshipNoLastPart = fistMembershipNoLastPart + 1;
                    string secondMembershipNo = fistMembershipNoFirstPart + "-" + secondMembshipNoLastPart;
                    int thirdMembershpNoLastPart = fistMembershipNoLastPart + 2;
                    string thirdMembershipNo = fistMembershipNoFirstPart + "-" + thirdMembershpNoLastPart;
                    int forthMembershipNoLastPart = fistMembershipNoLastPart + 3;
                    string forthMembershipNo = fistMembershipNoFirstPart + "-" + forthMembershipNoLastPart;

                    txtMembershipNoDual.Text = secondMembershipNo;
                    txtMembershipNoTriple.Text = thirdMembershipNo;
                    txtMembershipNoQuad.Text = forthMembershipNo;
                }
            }
        }

        private void rdb3_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rdb2.CheckState == CheckState.Checked)
            {
                if (!string.IsNullOrWhiteSpace(txtMembershipNo.Text))
                {
                    string firstMembershipNo = txtMembershipNo.Text;
                    string[] firstMembershipNoStrs = firstMembershipNo.Split('-');
                    string fistMembershipNoFirstPart = firstMembershipNoStrs.First();
                    int fistMembershipNoLastPart = Convert.ToInt32(firstMembershipNoStrs.Last());
                    int secondMembshipNoLastpart = fistMembershipNoLastPart + 1;
                    string secondMembershipNo = fistMembershipNoFirstPart + "-" + secondMembshipNoLastpart;

                    txtMembershipNoDual.Text = secondMembershipNo;

                    txtMembershipNoTriple.Clear();
                    txtMembershipNoQuad.Clear();
                }
            }
            if (rdb1.CheckState == CheckState.Checked)
            {
                txtMembershipNoDual.Clear();
                txtMembershipNoTriple.Clear();
                txtMembershipNoQuad.Clear();
            }
            if (rdb3.CheckState == CheckState.Checked)
            {
                if (!string.IsNullOrWhiteSpace(txtMembershipNo.Text))
                {
                    string firstMembershipNo = txtMembershipNo.Text;
                    string[] firstMembershipNoStrs = firstMembershipNo.Split('-');
                    string fistMembershipNoFirstPart = firstMembershipNoStrs.First();
                    int fistMembershipNoLastPart = Convert.ToInt32(firstMembershipNoStrs.Last());
                    int secondMembshipNoLastPart = fistMembershipNoLastPart + 1;
                    string secondMembershipNo = fistMembershipNoFirstPart + "-" + secondMembshipNoLastPart;
                    int thirdMembershpNoLastPart = fistMembershipNoLastPart + 2;
                    string thirdMembershipNo = fistMembershipNoFirstPart + "-" + thirdMembershpNoLastPart;

                    txtMembershipNoDual.Text = secondMembershipNo;
                    txtMembershipNoTriple.Text = thirdMembershipNo;

                    txtMembershipNoQuad.Clear();
                }
            }
            if (rdb4.CheckState == CheckState.Checked)
            {
                if (!string.IsNullOrWhiteSpace(txtMembershipNo.Text))
                {
                    string firstMembershipNo = txtMembershipNo.Text;
                    string[] firstMembershipNoStrs = firstMembershipNo.Split('-');
                    string fistMembershipNoFirstPart = firstMembershipNoStrs.First();
                    int fistMembershipNoLastPart = Convert.ToInt32(firstMembershipNoStrs.Last());
                    int secondMembshipNoLastPart = fistMembershipNoLastPart + 1;
                    string secondMembershipNo = fistMembershipNoFirstPart + "-" + secondMembshipNoLastPart;
                    int thirdMembershpNoLastPart = fistMembershipNoLastPart + 2;
                    string thirdMembershipNo = fistMembershipNoFirstPart + "-" + thirdMembershpNoLastPart;
                    int forthMembershipNoLastPart = fistMembershipNoLastPart + 3;
                    string forthMembershipNo = fistMembershipNoFirstPart + "-" + forthMembershipNoLastPart;

                    txtMembershipNoDual.Text = secondMembershipNo;
                    txtMembershipNoTriple.Text = thirdMembershipNo;
                    txtMembershipNoQuad.Text = forthMembershipNo;
                }
            }
        }

        private void rdb4_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rdb2.CheckState == CheckState.Checked)
            {
                if (!string.IsNullOrWhiteSpace(txtMembershipNo.Text))
                {
                    string firstMembershipNo = txtMembershipNo.Text;
                    string[] firstMembershipNoStrs = firstMembershipNo.Split('-');
                    string fistMembershipNoFirstPart = firstMembershipNoStrs.First();
                    int fistMembershipNoLastPart = Convert.ToInt32(firstMembershipNoStrs.Last());
                    int secondMembshipNoLastpart = fistMembershipNoLastPart + 1;
                    string secondMembershipNo = fistMembershipNoFirstPart + "-" + secondMembshipNoLastpart;

                    txtMembershipNoDual.Text = secondMembershipNo;

                    txtMembershipNoTriple.Clear();
                    txtMembershipNoQuad.Clear();
                }
            }
            if (rdb1.CheckState == CheckState.Checked)
            {
                txtMembershipNoDual.Clear();
                txtMembershipNoTriple.Clear();
                txtMembershipNoQuad.Clear();
            }
            if (rdb3.CheckState == CheckState.Checked)
            {
                if (!string.IsNullOrWhiteSpace(txtMembershipNo.Text))
                {
                    string firstMembershipNo = txtMembershipNo.Text;
                    string[] firstMembershipNoStrs = firstMembershipNo.Split('-');
                    string fistMembershipNoFirstPart = firstMembershipNoStrs.First();
                    int fistMembershipNoLastPart = Convert.ToInt32(firstMembershipNoStrs.Last());
                    int secondMembshipNoLastPart = fistMembershipNoLastPart + 1;
                    string secondMembershipNo = fistMembershipNoFirstPart + "-" + secondMembshipNoLastPart;
                    int thirdMembershpNoLastPart = fistMembershipNoLastPart + 2;
                    string thirdMembershipNo = fistMembershipNoFirstPart + "-" + thirdMembershpNoLastPart;

                    txtMembershipNoDual.Text = secondMembershipNo;
                    txtMembershipNoTriple.Text = thirdMembershipNo;

                    txtMembershipNoQuad.Clear();
                }
            }
            if (rdb4.CheckState == CheckState.Checked)
            {
                if (!string.IsNullOrWhiteSpace(txtMembershipNo.Text))
                {
                    string firstMembershipNo = txtMembershipNo.Text;
                    string[] firstMembershipNoStrs = firstMembershipNo.Split('-');
                    string fistMembershipNoFirstPart = firstMembershipNoStrs.First();
                    int fistMembershipNoLastPart = Convert.ToInt32(firstMembershipNoStrs.Last());
                    int secondMembshipNoLastPart = fistMembershipNoLastPart + 1;
                    string secondMembershipNo = fistMembershipNoFirstPart + "-" + secondMembshipNoLastPart;
                    int thirdMembershpNoLastPart = fistMembershipNoLastPart + 2;
                    string thirdMembershipNo = fistMembershipNoFirstPart + "-" + thirdMembershpNoLastPart;
                    int forthMembershipNoLastPart = fistMembershipNoLastPart + 3;
                    string forthMembershipNo = fistMembershipNoFirstPart + "-" + forthMembershipNoLastPart;

                    txtMembershipNoDual.Text = secondMembershipNo;
                    txtMembershipNoTriple.Text = thirdMembershipNo;
                    txtMembershipNoQuad.Text = forthMembershipNo;
                }
            }
        }

        private void rdb2_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rdb2.CheckState == CheckState.Checked)
            {
                if (!string.IsNullOrWhiteSpace(txtMembershipNo.Text))
                {
                    string firstMembershipNo = txtMembershipNo.Text;
                    string[] firstMembershipNoStrs = firstMembershipNo.Split('-');
                    string fistMembershipNoFirstPart = firstMembershipNoStrs.First();
                    int fistMembershipNoLastPart = Convert.ToInt32(firstMembershipNoStrs.Last());
                    int secondMembshipNoLastpart = fistMembershipNoLastPart + 1;
                    string secondMembershipNo = fistMembershipNoFirstPart + "-" + secondMembshipNoLastpart;

                    txtMembershipNoDual.Text = secondMembershipNo;

                    txtMembershipNoTriple.Clear();
                    txtMembershipNoQuad.Clear();
                }
            }
            if (rdb1.CheckState == CheckState.Checked)
            {
                txtMembershipNoDual.Clear();
                txtMembershipNoTriple.Clear();
                txtMembershipNoQuad.Clear();
            }
            if (rdb3.CheckState == CheckState.Checked)
            {
                if (!string.IsNullOrWhiteSpace(txtMembershipNo.Text))
                {
                    string firstMembershipNo = txtMembershipNo.Text;
                    string[] firstMembershipNoStrs = firstMembershipNo.Split('-');
                    string fistMembershipNoFirstPart = firstMembershipNoStrs.First();
                    int fistMembershipNoLastPart = Convert.ToInt32(firstMembershipNoStrs.Last());
                    int secondMembshipNoLastPart = fistMembershipNoLastPart + 1;
                    string secondMembershipNo = fistMembershipNoFirstPart + "-" + secondMembshipNoLastPart;
                    int thirdMembershpNoLastPart = fistMembershipNoLastPart + 2;
                    string thirdMembershipNo = fistMembershipNoFirstPart + "-" + thirdMembershpNoLastPart;

                    txtMembershipNoDual.Text = secondMembershipNo;
                    txtMembershipNoTriple.Text = thirdMembershipNo;

                    txtMembershipNoQuad.Clear();
                }
            }
            if (rdb4.CheckState == CheckState.Checked)
            {
                if (!string.IsNullOrWhiteSpace(txtMembershipNo.Text))
                {
                    string firstMembershipNo = txtMembershipNo.Text;
                    string[] firstMembershipNoStrs = firstMembershipNo.Split('-');
                    string fistMembershipNoFirstPart = firstMembershipNoStrs.First();
                    int fistMembershipNoLastPart = Convert.ToInt32(firstMembershipNoStrs.Last());
                    int secondMembshipNoLastPart = fistMembershipNoLastPart + 1;
                    string secondMembershipNo = fistMembershipNoFirstPart + "-" + secondMembshipNoLastPart;
                    int thirdMembershpNoLastPart = fistMembershipNoLastPart + 2;
                    string thirdMembershipNo = fistMembershipNoFirstPart + "-" + thirdMembershpNoLastPart;
                    int forthMembershipNoLastPart = fistMembershipNoLastPart + 3;
                    string forthMembershipNo = fistMembershipNoFirstPart + "-" + forthMembershipNoLastPart;

                    txtMembershipNoDual.Text = secondMembershipNo;
                    txtMembershipNoTriple.Text = thirdMembershipNo;
                    txtMembershipNoQuad.Text = forthMembershipNo;
                }
            }
        }

        private void rdb1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rdb2.CheckState == CheckState.Checked)
            {
                if (!string.IsNullOrWhiteSpace(txtMembershipNo.Text))
                {
                    string firstMembershipNo = txtMembershipNo.Text;
                    string[] firstMembershipNoStrs = firstMembershipNo.Split('-');
                    string fistMembershipNoFirstPart = firstMembershipNoStrs.First();
                    int fistMembershipNoLastPart = Convert.ToInt32(firstMembershipNoStrs.Last());
                    int secondMembshipNoLastpart = fistMembershipNoLastPart + 1;
                    string secondMembershipNo = fistMembershipNoFirstPart + "-" + secondMembshipNoLastpart;

                    txtMembershipNoDual.Text = secondMembershipNo;

                    txtMembershipNoTriple.Clear();
                    txtMembershipNoQuad.Clear();
                }
            }
            if (rdb1.CheckState == CheckState.Checked)
            {
                txtMembershipNoDual.Clear();
                txtMembershipNoTriple.Clear();
                txtMembershipNoQuad.Clear();
            }
            if (rdb3.CheckState == CheckState.Checked)
            {
                if (!string.IsNullOrWhiteSpace(txtMembershipNo.Text))
                {
                    string firstMembershipNo = txtMembershipNo.Text;
                    string[] firstMembershipNoStrs = firstMembershipNo.Split('-');
                    string fistMembershipNoFirstPart = firstMembershipNoStrs.First();
                    int fistMembershipNoLastPart = Convert.ToInt32(firstMembershipNoStrs.Last());
                    int secondMembshipNoLastPart = fistMembershipNoLastPart + 1;
                    string secondMembershipNo = fistMembershipNoFirstPart + "-" + secondMembshipNoLastPart;
                    int thirdMembershpNoLastPart = fistMembershipNoLastPart + 2;
                    string thirdMembershipNo = fistMembershipNoFirstPart + "-" + thirdMembershpNoLastPart;

                    txtMembershipNoDual.Text = secondMembershipNo;
                    txtMembershipNoTriple.Text = thirdMembershipNo;

                    txtMembershipNoQuad.Clear();
                }
            }
            if (rdb4.CheckState == CheckState.Checked)
            {
                if (!string.IsNullOrWhiteSpace(txtMembershipNo.Text))
                {
                    string firstMembershipNo = txtMembershipNo.Text;
                    string[] firstMembershipNoStrs = firstMembershipNo.Split('-');
                    string fistMembershipNoFirstPart = firstMembershipNoStrs.First();
                    int fistMembershipNoLastPart = Convert.ToInt32(firstMembershipNoStrs.Last());
                    int secondMembshipNoLastPart = fistMembershipNoLastPart + 1;
                    string secondMembershipNo = fistMembershipNoFirstPart + "-" + secondMembshipNoLastPart;
                    int thirdMembershpNoLastPart = fistMembershipNoLastPart + 2;
                    string thirdMembershipNo = fistMembershipNoFirstPart + "-" + thirdMembershpNoLastPart;
                    int forthMembershipNoLastPart = fistMembershipNoLastPart + 3;
                    string forthMembershipNo = fistMembershipNoFirstPart + "-" + forthMembershipNoLastPart;

                    txtMembershipNoDual.Text = secondMembershipNo;
                    txtMembershipNoTriple.Text = thirdMembershipNo;
                    txtMembershipNoQuad.Text = forthMembershipNo;
                }
            }
        }
    }
}
