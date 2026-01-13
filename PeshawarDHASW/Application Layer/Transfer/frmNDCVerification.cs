using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsTFR;
using Telerik.WinControls;
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Application_Layer.Transfer
{
    public partial class frmNDCVerification : Telerik.WinControls.UI.RadForm
    {
        public int days { get; set; }
        public string fileno { get; set; }

        public frmNDCVerification(string get_FileNo)
        {
            fileno = get_FileNo;
            InitializeComponent();
        }
        public frmNDCVerification()
        {
            InitializeComponent();
        }
    
      
        private void btnNDCVerification_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNDCNumber.Text.Trim() != "")
                {
                    SqlParameter[] parameters =
                    {
                    new SqlParameter("@Task", "NDC_TFR_Verfication"),
                    new SqlParameter("@NDCNo", clsPluginHelper.DbNullIfNullOrEmpty(txtNDCNumber.Text)),
                };
                    DataSet ds = cls_dl_NDCVerification.NdcMemberVerification(parameters);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        clearfunction();
                        lblndcexpire.Visible = false;
                        txtfileno.Visible = true;
                        txtmsname.Visible = true;
                        txtdateofissue.Visible = true;
                        txtdateofexpire.Visible = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            txtfileno.Text = "File No : " + fileno.ToString();
                            //  fileno = row["FileNO"].ToString();
                            txtmsname.Text = "Name : " + row["Name"].ToString();
                            txtdateofissue.Text = "Date of Issue : " + row["DateIssue"].ToString();
                            txtdateofexpire.Text = "Date of Expire : " + row["NDCExpireDate"].ToString();
                            days = int.Parse(row["days"].ToString());
                        }
                        if (days > 0)
                        {
                            btnTransfer.Visible = true;
                        }
                    }
                    else
                    {
                        lblndcexpire.Visible = true;
                        txtfileno.Visible = false;
                        txtmsname.Visible = false;
                        txtdateofissue.Visible = false;
                        txtdateofexpire.Visible = false;
                        btnTransfer.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnNDCVerification_Click.", ex, "frmNDCVerification");
                frmobj.ShowDialog();
            }
           
        }

        private void clearfunction()
        {

            txtfileno.Text = "";
            txtmsname.Text = "";
            txtdateofissue.Text = "";
            txtdateofexpire.Text = "";
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                int pass = 0;
                bool parsed = int.TryParse(txtNDCNumber.Text, out pass);
                if (parsed)
                {
                    this.Hide();
                    frmTFRFeeVerification obj = new frmTFRFeeVerification(pass, fileno);
                    obj.ShowDialog();
                    this.Close();
                }
            }
            catch (Exception   ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnTransfer_Click.", ex, "frmNDCVerification");
                frmobj.ShowDialog();
            }
           
        }

        private void frmNDCVerification_Load(object sender, EventArgs e)
        {

        }
    }
}
