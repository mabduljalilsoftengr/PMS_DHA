using PeshawarDHASW.Data_Layer.clsCaution;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Caution
{
    public partial class frmBankLoanFiles_Create : Telerik.WinControls.UI.RadForm
    {
        private dynamic VaildationFieldName { get; set; } 
        private dynamic FieldName { get; set; }
        public frmBankLoanFiles_Create()
        {
            InitializeComponent();
        }

        private void frmBankLoanFiles_Create_Load(object sender, EventArgs e)
        {
            CausionFilesBinding(drp_fileNo);
        }
        private void CausionFilesBinding(RadDropDownList drp_FNL)
        {
            RadListDataItem select = new RadListDataItem();
            drp_FNL.Items.Clear();
            select.Value = 0;
            select.Text = "-- Select Particular Head --";
            drp_FNL.Items.Add(select);
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","CautionFileReader"),
            };
            foreach (DataRow row in cls_dl_Caution.Caution_Reader(prm).Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["CautionID"].ToString();
                dataItem.Text = row["FileNo"].ToString();
                drp_FNL.Items.Add(dataItem);
            }
            drp_FNL.SelectedIndex = -1;
        }

        private void btn_bnkLoadFile_Click(object sender, EventArgs e)
        {
            try
            {
               
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task","Cau_FileCreate"),
                    new SqlParameter("@CautionID",  drp_fileNo.SelectedValue),
                    new SqlParameter("@FileNo", drp_fileNo.SelectedItem.Text),
                    new SqlParameter("@MembershipNo", txt_memberNo.Text),
                    new SqlParameter("@PlotNo", txt_plotNo.Text),
                    new SqlParameter("@PlotOwnerName", txt_ptOwnerName.Text),
                    new SqlParameter("@CNICNo", txt_cnicNo.Text),
                    new SqlParameter("@MobNo", txt_mobNo.Text),
                    new SqlParameter("@MailingAddress", txt_mailingAddress.Text),
                    new SqlParameter("@BankName", txt_bnkName.Text),
                    new SqlParameter("@BranchName", txt_brhName.Text),
                    new SqlParameter("@BranchCode", txt_brhCode.Text),
                    new SqlParameter("@NocNecPermissionDate", dtp_nnPermDate.Text),
                    new SqlParameter("@NocNecExpiryDate", dtp_nnExpDate.Text),
                };

                int result = 0;
                result = cls_dl_Caution.Caution_NonQuery(parameters);
                if (result > 0)
                {
                    MessageBox.Show("Record successfully added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearDetailsfunction();
                }
                else
                {
                    MessageBox.Show("Unable to save record Please contact to the Administrator!.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

            }
        }


        private void ClearDetailsfunction()
        {
            drp_fileNo.SelectedIndex = -1;
            txt_memberNo.Text = "";
            txt_plotNo.Text = "";
            txt_ptOwnerName.Text = "";
            txt_cnicNo.Text = "";
            txt_mobNo.Text = "";
            txt_mailingAddress.Text = "";
            txt_bnkName.Text = "";
            txt_brhName.Text = "";
            txt_brhCode.Text = "";

        }
        private void drp_fileNo_Validating(object sender, CancelEventArgs e)
        {         
            ValidateAppName();
        }

        private void txt_plotNo_Validating(object sender, CancelEventArgs e)
        {
            
            VaildationFieldName = txt_plotNo.Text;
            FieldName = "txt_plotNo";
            Validate(VaildationFieldName, FieldName);

        }


        private void txt_cnicNo_Validating(object sender, CancelEventArgs e)
        {
            VaildationFieldName = txt_cnicNo.Text;
            FieldName = "txt_cnicNo";
            Validate(VaildationFieldName, FieldName);
        }

        private void txt_bnkName_Validating(object sender, CancelEventArgs e)
        {
            VaildationFieldName = txt_bnkName.Text;
            FieldName = "txt_bnkName";
            Validate(VaildationFieldName, FieldName);
        }
        private void txt_mobNo_Validating(object sender, CancelEventArgs e)
        {
            VaildationFieldName = txt_mobNo.Text;
            FieldName = "txt_mobNo";
            Validate(VaildationFieldName, FieldName);
        }
        private void txt_ptOwnerName_Validating(object sender, CancelEventArgs e)
        {
            VaildationFieldName = txt_ptOwnerName.Text;
            FieldName = "txt_ptOwnerName";
            Validate(VaildationFieldName, FieldName);
        }
        private void txt_mailingAddress_Validating(object sender, CancelEventArgs e)
        {
            VaildationFieldName = txt_mailingAddress.Text;
            FieldName = "txt_mailingAddress";
            Validate(VaildationFieldName, FieldName);
        }
        private bool ValidateAppName()
        {
            bool bStatus = true;
            if (drp_fileNo.SelectedIndex == -1 || drp_fileNo.SelectedIndex == 0)
            {
                errorFrmBankFile.SetError(drp_fileNo, "Please Enter Applicant Name.");
                bStatus = false;
            }
            else
                errorFrmBankFile.SetError(drp_fileNo, "");
            return bStatus;
        }
        private bool Validate(string name,string FieldName)
        {
 
                bool bStatus = true;
                if (string.IsNullOrWhiteSpace(name))
                 {
                if (FieldName == "txt_plotNo")
                {
                    errorFrmBankFile.SetError(txt_plotNo, "Please Enter Plot No.");
                }
               else if (FieldName == "txt_cnicNo")
                {
                    errorFrmBankFile.SetError(txt_cnicNo, "Please Enter CNIC No.");
                }
                else if (FieldName == "txt_bnkName")
                {
                    errorFrmBankFile.SetError(txt_bnkName, "Please Enter Bank Name.");
                }
                else if (FieldName == "txt_mobNo")
                {
                    errorFrmBankFile.SetError(txt_mobNo, "Please Enter Mobile No.");
                }
                else if (FieldName == "txt_ptOwnerName")
                {
                    errorFrmBankFile.SetError(txt_ptOwnerName, "Please Enter Plot Owner Name.");
                }
                else if (FieldName == "txt_mailingAddress")
                {
                    errorFrmBankFile.SetError(txt_mailingAddress, "Please Enter Address.");
                }
                bStatus = false;
            }
            else
                 if (FieldName == "txt_plotNo")
            {
                errorFrmBankFile.SetError(txt_plotNo, "");
            }
             else if (FieldName == "txt_cnicNo")
            {
                errorFrmBankFile.SetError(txt_cnicNo, "");
            }
            else if (FieldName == "txt_bnkName")
            {
                errorFrmBankFile.SetError(txt_bnkName, "");
            }
            else if (FieldName == "txt_mobNo")
            {
                errorFrmBankFile.SetError(txt_mobNo, "");
            }
            else if (FieldName == "txt_ptOwnerName")
            {
                errorFrmBankFile.SetError(txt_ptOwnerName, "");
            }
            else if (FieldName == "txt_mailingAddress")
            {
                errorFrmBankFile.SetError(txt_mailingAddress, "");
            }
            return bStatus;
        }

       
    }
}
