using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Application_Layer.Installment.InstReceive.ImageRead;
using PeshawarDHASW.Data_Layer.clsChallanRece;
using PeshawarDHASW.Data_Layer.Installment;
using PeshawarDHASW.Helper;
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

namespace PeshawarDHASW.Application_Layer.Installment.InstReceive
{
    public partial class frmDDChallanImagesVerify_Dispose : Telerik.WinControls.UI.RadForm
    {
        public frmDDChallanImagesVerify_Dispose()
        {
            InitializeComponent();
        }

        private void btnChallanSearch_Click(object sender, EventArgs e)
        {
           
        }
        private void Get_Claimed_DD()
        {
            try
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@Task", "Get_ClaimedDD"),
                new SqlParameter("@FileNo", clsPluginHelper.DbNullIfNullOrEmpty(txtfileno.Text)),
                new SqlParameter("@PlotNo", clsPluginHelper.DbNullIfNullOrEmpty(txtplotno.Text)),
                new SqlParameter("@Date", clsPluginHelper.DbNullIfNullOrEmpty(txtdate.Text)),
                new SqlParameter("@MSNo", clsPluginHelper.DbNullIfNullOrEmpty(txtmsno.Text)),
                new SqlParameter("@NIC", clsPluginHelper.DbNullIfNullOrEmpty(txtnic.Text)),
                new SqlParameter("@Amount", clsPluginHelper.DbNullIfNullOrEmpty(txtamount.Text)),
                new SqlParameter("@Status", clsPluginHelper.DbNullIfNullOrEmpty(txtstatus.Text)),
                new SqlParameter("@DDStatus", clsPluginHelper.DbNullIfNullOrEmpty(txtDDstatus.Text)),
                new SqlParameter("@DDNo", clsPluginHelper.DbNullIfNullOrEmpty(txtDDno.Text)),
                new SqlParameter("@BankName", clsPluginHelper.DbNullIfNullOrEmpty(txtbankname.Text)),
                new SqlParameter("@Branch", clsPluginHelper.DbNullIfNullOrEmpty(txtbranch.Text)),
                new SqlParameter("@Remarks", clsPluginHelper.DbNullIfNullOrEmpty(txtremarks.Text))
               };
                DataSet ds = cls_dl_InstRece.Inst_Rece_Read(parameters);
                //foreach (DataRow Row in ds.Tables[0].Rows)
                //{
                //    string[] ddchallan = new string[] { Row["FileNo"].ToString(), Row["Name"].ToString(), Row["RecordNo"].ToString(), Row["Date"].ToString(), Row["Amount"].ToString(), Row["DDNo"].ToString(), Row["BankName"].ToString(), Row["Branch"].ToString(), Row["Status"].ToString(), Row["Remarks"].ToString(), Row["DDStatus"].ToString(), Row["Transferree"].ToString(), Row["Rece_ID"].ToString(), Row["FileMapKey"].ToString(), Row["DDImageID"].ToString(), Row["ID"].ToString() };
                radgdInstReceive.DataSource = ds.Tables[0].DefaultView;
                //    radgdInstReceive.Rows.Add(ddchallan);
                //}
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Get_Claimed_DD().", ex, "frmDDChallanImageVerify_Dispose");
                frmobj.ShowDialog();
            }
        }
        private void Get_OtherRece_ClaimedData()
        {
            try
            {
                SqlParameter[] parameters = 
                {
                new SqlParameter("@Task", "Select")
                };
                DataSet ds = cls_dl_ChallanRece.ChallanRece_Reader(parameters);
                grdChallanImages.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on BindAllDataWithGrid_OtherRece.", ex, "frmDDChallanImageUpload");
                frmobj.ShowDialog();
            }
        }
        private void DD_DGVControls()
        {
            try
            {
                GridViewCommandColumn verifyImage = new GridViewCommandColumn();
                verifyImage.Name = "DDVerify";
                verifyImage.UseDefaultText = true;
                verifyImage.FieldName = "DDVerify";
                verifyImage.DefaultText = "Verify";
                verifyImage.Width = 160;
                verifyImage.TextAlignment = ContentAlignment.MiddleCenter;
                verifyImage.HeaderText = "Verify Images";
                radgdInstReceive.MasterTemplate.Columns.Add(verifyImage);

                GridViewCommandColumn disposeImage = new GridViewCommandColumn();
                disposeImage.Name = "DDImageDispose";
                disposeImage.UseDefaultText = true;
                disposeImage.FieldName = "DDImageDispose";
                disposeImage.DefaultText = "Dispose";
                disposeImage.Width = 160;
                disposeImage.TextAlignment = ContentAlignment.MiddleCenter;
                disposeImage.HeaderText = "Dispose Images";
                radgdInstReceive.MasterTemplate.Columns.Add(disposeImage);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on DD_DGVControls().", ex, "frmDDChallanImageVerify_Dispose");
                frmobj.ShowDialog();
            }
        }
        private void Challan_DGVControls()
        {
            try
            {
                GridViewCommandColumn cllnVerify = new GridViewCommandColumn();
                cllnVerify.Name = "CllanVerify";
                cllnVerify.UseDefaultText = true;
                cllnVerify.FieldName = "CllanVerify";
                cllnVerify.DefaultText = "Verify";
                cllnVerify.Width = 160;
                cllnVerify.TextAlignment = ContentAlignment.MiddleCenter;
                cllnVerify.HeaderText = "Challan Verify";
                grdChallanImages.MasterTemplate.Columns.Add(cllnVerify);

                GridViewCommandColumn challanDispose = new GridViewCommandColumn();
                challanDispose.Name = "cllanDispose";
                challanDispose.UseDefaultText = true;
                challanDispose.FieldName = "cllanDispose";
                challanDispose.DefaultText = "Dispose";
                challanDispose.Width = 160;
                challanDispose.TextAlignment = ContentAlignment.MiddleCenter;
                challanDispose.HeaderText = "Challan Dispose";
                grdChallanImages.MasterTemplate.Columns.Add(challanDispose);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Challan_DGVControls.", ex, "frmDDChallanImageUpload");
                frmobj.ShowDialog();
            }


        }
        private void btnsearch_Click(object sender, EventArgs e)
        {
            Get_Claimed_DD();
            Get_OtherRece_ClaimedData();
        }

        private void frmDDChallanImagesVerify_Dispose_Load(object sender, EventArgs e)
        {
            #region DD Detail
            DD_DGVControls();
            Get_Claimed_DD();
            #endregion
            #region Challan/Other Recieve
            Challan_DGVControls();
            Get_OtherRece_ClaimedData();
            #endregion
        }

        private void radgdInstReceive_CellClick(object sender, GridViewCellEventArgs e)
        {
            int receInstID = 0;
            if (e.Column.Name == "DDVerify")
            {
                receInstID = int.Parse(radgdInstReceive.CurrentRow.Cells[12].Value.ToString());
                frmReceInstalImage frm = new frmReceInstalImage(receInstID,false,100);
                frm.ShowDialog();
            }
            else if (e.Column.Name == "DDImageDispose")
            {
                DialogResult dresult = MessageBox.Show("Are you Sure To Delete Images ?","Confirm !",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                if (dresult == DialogResult.Yes)
                {
                    receInstID = int.Parse(radgdInstReceive.CurrentRow.Cells[12].Value.ToString());
                    SqlParameter[] prm =
                    {
                    new SqlParameter("@Task","Dispose_DD_Image"),
                    new SqlParameter("@ReceInstallmentID",receInstID)
                    };
                    int rslt = cls_dl_InstRece.Delete_DD_Images(prm);
                    if (rslt > 0)
                    {
                        MessageBox.Show("Images are Successfully Deleted.");
                    }
                    else
                    {
                        MessageBox.Show("There is no Image to Delete.");
                    }
                }
               
            }
        }

        private void grdChallanImages_CellClick(object sender, GridViewCellEventArgs e)
        {
            int challanID = 0;
            challanID = int.Parse(grdChallanImages.CurrentRow.Cells[11].Value.ToString());
            if (e.Column.Name == "CllanVerify")
            {
                
                frmOtherReceImage frm = new frmOtherReceImage(challanID,false,100);
                frm.ShowDialog();
            }
            else if (e.Column.Name == "cllanDispose")
            {
                DialogResult result = MessageBox.Show("Are You Sure To Delete the Image ?","Confirm !",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    SqlParameter[] prmt =
                    {
                    new SqlParameter("@Task","Challn_Dispose"),
                    new SqlParameter("@Challan_ReceID",challanID)
                    };
                    int rslt = cls_dl_ChallanRece.Challan_Dispose(prmt);
                    if (rslt > 0)
                    {
                        MessageBox.Show("Challan is Successfully Deleted.");
                    }
                    else
                    {
                        MessageBox.Show("There is no Image to Delete.");
                    }
                }
               
            }
        }
    }
}
