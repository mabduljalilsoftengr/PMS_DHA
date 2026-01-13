using PeshawarDHASW.Data_Layer.NDC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    public partial class frm_AddDummyBuyer : Telerik.WinControls.UI.RadForm
    {
        private string FieNo { get; set; }
        private string CNIC { get; set; }
        private string strg { get; set; }
        private DataSet dst { get; set; }
        public frm_AddDummyBuyer()
        {
            InitializeComponent();
        }
        public frm_AddDummyBuyer(string file, string cnic,string str)
        {
            InitializeComponent();
            FieNo = file;
            CNIC = cnic;
            strg = str;
            btnSave.Text = "Modify";
            GetBuyerData(file, cnic);
        }
        public frm_AddDummyBuyer(string fileno,bool sc,string str)
        {
            InitializeComponent();
            FieNo = fileno;
            lblFileNo.Text = FieNo;
            strg = str;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                
                

                if (strg == "Save")
                {
                    SqlParameter[] prm =
                    {
                new SqlParameter("@Task","InsertDummyBuyer"),
                new SqlParameter("@Name",txtname.Text),
                new SqlParameter("@F_H_W_Name",txtxFatherName.Text),
                new SqlParameter("@SB_Address","---"),
                new SqlParameter("@SBCNIC",txtCNIC.Text),
                new SqlParameter("@NTN",txtCNIC.Text),
                new SqlParameter("@FileNo",lblFileNo.Text),
                new SqlParameter("@MobileNo",txtmobileno.Text),
                new SqlParameter("@Status","Active"),
                new SqlParameter("@Type","Buyer"),
                new SqlParameter("@UserID",Models.clsUser.ID)
                };
                    int rslt = cls_dl_NDC.NdcNonQuery(prm);
                    strg = "";
                    this.Close();
                }
                else if (strg == "Modify")
                {
                    SqlParameter[] prm =
                    {
                   new SqlParameter("@Task","UpdateDummyBuyer"),
                   new SqlParameter("@Name",txtname.Text),
                   new SqlParameter("@F_H_W_Name",txtxFatherName.Text),
                   new SqlParameter("@SB_Address","---"),
                   new SqlParameter("@SBCNIC",txtCNIC.Text),
                   new SqlParameter("@NTN",txtCNIC.Text),
                   new SqlParameter("@FileNo",lblFileNo.Text),
                   new SqlParameter("@MobileNo",txtmobileno.Text),
                   new SqlParameter("@DummyID",int.Parse(dst.Tables[0].Rows[0]["DummyID"].ToString())),
                   new SqlParameter("@UserID",Models.clsUser.ID)
                  };
                    int rslt = cls_dl_NDC.NdcNonQuery(prm);
                    if (rslt > 0)
                    {
                        MessageBox.Show("Record Updated Successfully.");
                        strg = "";
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void  GetBuyerData(string file,string cnic)
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","GetDummyBuyerData"),
                new SqlParameter("@FileNo",file),
                new SqlParameter("@SBCNIC",cnic)
            };
            dst = cls_dl_NDC.NdcRetrival(prm);
            lblFileNo.Text = dst.Tables[0].Rows[0]["FileNo"].ToString();
            txtname.Text = dst.Tables[0].Rows[0]["Name"].ToString();
            txtxFatherName.Text = dst.Tables[0].Rows[0]["FatherName"].ToString();
            txtmobileno.Text = dst.Tables[0].Rows[0]["MobileNo"].ToString();
            txtCNIC.Text = dst.Tables[0].Rows[0]["CNIC"].ToString();
            //txtNTNNumber.Text = dst.Tables[0].Rows[0]["NTN"].ToString();

        }

        private void frm_AddDummyBuyer_Load(object sender, EventArgs e)
        {

        }

       

        private void txtmobileno_Leave(object sender, EventArgs e)
        {
            string mobile = txtmobileno.Text.Trim();

            // Validate Mobile (Format: 03XXXXXXXXX)
            if (!Regex.IsMatch(mobile, @"^03[0-9]{9}$"))
            {
                MessageBox.Show("Invalid Mobile No. Use format: 03XXXXXXXXX", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmobileno.Focus();
                return;
            }
        }

        //private void txtCNIC_Leave(object sender, EventArgs e)
        //{
        //    string cnic = txtCNIC.Text.Trim();

        //    // Validate CNIC (Format: 42101-1234567-1)
        //    if (!Regex.IsMatch(cnic, @"^\d{5}-\d{7}-\d{1}$"))
        //    {
        //        MessageBox.Show("Invalid CNIC format. Use format: 11111-1111111-1", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        txtCNIC.Focus();
        //        return;
        //    }
        //}


        private void txtCNIC_Leave(object sender, EventArgs e)
        {
            string value = txtCNIC.Text.Trim();

            // CNIC: 42101-1234567-1
            string cnicPattern = @"^\d{5}-\d{7}-\d{1}$";

            // NTN: 4229635-8
            string ntnPattern = @"^\d{7}-\d{1}$";

            if (!Regex.IsMatch(value, cnicPattern) && !Regex.IsMatch(value, ntnPattern))
            {
                MessageBox.Show("Invalid CNIC/NTN format.\n\nValid Formats:\nCNIC: 11111-1111111-1\nNTN: 1234567-1",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtCNIC.Focus();
                return;
            }
        }

    }
}
