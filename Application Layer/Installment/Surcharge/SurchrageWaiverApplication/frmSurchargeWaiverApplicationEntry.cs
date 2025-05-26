using PeshawarDHASW.Application_Layer.CustomDialog;
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

namespace PeshawarDHASW.Application_Layer.Installment.Surcharge.SurchrageWaiverApplication
{
    public partial class frmSurchargeWaiverApplicationEntry : Telerik.WinControls.UI.RadForm
    {
        public frmSurchargeWaiverApplicationEntry()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtRefrenceNo.Text.Trim()))
                {
                    MessageBox.Show("Please enter Refrence No.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRefrenceNo.Focus();
                    return;
                }
                if (ReceivedDate.Value.Date.Year == 1)
                {
                    MessageBox.Show("Please enter Receive Date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty(txtFileNo.Text.Trim()))
                {
                    MessageBox.Show("Please enter File No.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFileNo.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtPlotNo.Text.Trim()))
                {
                    MessageBox.Show("Please enter Plot No.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPlotNo.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtCNIC.Text.Trim()))
                {
                    MessageBox.Show("CNIC required.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCNIC.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtMemberName.Text.Trim()))
                {
                    MessageBox.Show("MemberName required.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMemberName.Focus();
                    return;
                }
                if (dtpApplicationDate.Value.Date.Year == 1)
                {
                    MessageBox.Show("Please enter Application Date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SqlParameter[] parameters =
               {
                    new SqlParameter("@Task","INSERT_SurchargeWavier_ApplicationStatus"),
                    new SqlParameter("@RefrenceNo", clsPluginHelper.DbNullIfNullOrEmpty(txtRefrenceNo.Text)),
                    new SqlParameter("@FileNo", clsPluginHelper.DbNullIfNullOrEmpty(txtFileNo.Text)),
                    new SqlParameter("@PlotNo",txtPlotNo.Text),
                    new SqlParameter("@ReceivedDate",ReceivedDate.Value.Date),
                    new SqlParameter("@Status", "Pending"),//clsPluginHelper.DbNullIfNullOrEmpty(cmdStatus.SelectedItem.ToString())),
                   //   new SqlParameter("@Approved_DisapprovedDate", ApprovedDisapprovedDate.Value.Date),
                    new SqlParameter("@Remarks", clsPluginHelper.DbNullIfNullOrEmpty(txtRemarks.Text)),
                    new SqlParameter("@CreatedBy", Models.clsUser.ID),
                      new SqlParameter("@MemberName",txtMemberName.Text),
                        new SqlParameter("@CNIC",txtCNIC.Text),
                          new SqlParameter("@Category_Name",txtCategory_Name.Text),
                          new SqlParameter("@SectorExtC",lblSectorCExt.Text),
                          new SqlParameter("@ApplicationDate",dtpApplicationDate.Value.Date)
                    //new SqlParameter("@InstalTempStatus", cbStatus.SelectedValue),
                    //new SqlParameter("@Remarks", clsPluginHelper.DbNullIfNullOrEmpty(txtRemarks.Text)),
                    //new SqlParameter("@PlanGroupID", cmbTempGroup.SelectedValue)
                };
                int result = 0;
                DataSet dss=new DataSet();
                dss = cls_dl_SurchargeWavier_ApplicationStatus.SurchargeWavier_ApplicationStatus_Reader(parameters);
                MessageBox.Show(dss.Tables[0].Rows[0]["RetrunMessage"].ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //{
                //    MessageBox.Show("Record successfully added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clearfunction();
                    FilREFRENCENUMBER();

                //}
                //else
                //{
                //    MessageBox.Show("Unable to save record Please contact to the Administrator!.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through.", ex, "InstTemplateCreate");
                frmobj.ShowDialog();
            }
        }
        private void Clearfunction()
        {
            txtRefrenceNo.Clear();
            txtFileNo.Clear();
            txtPlotNo.Clear();
            txtRemarks.Clear();
            txtMemberName.Clear();
            txtCNIC.Clear();
            txtCategory_Name.Clear();
            ReceivedDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cmdStatus.SelectedIndex = -1;
            //dtpInstalEndDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

        }

        private void frmSurchargeWaiverApplicationEntry_Load(object sender, EventArgs e)
        {
            FilREFRENCENUMBER();
        }

        private void FilREFRENCENUMBER()
        {
            try
            {
                SqlParameter[] prm =
                 {
                new SqlParameter("@Task","GetREFRENCENUMBER"),
                new SqlParameter("@FileNo", null),
                new SqlParameter("@PlotNo", null),


                 };
                DataSet ds = cls_dl_SurchargeWavier_ApplicationStatus.SurchargeWavier_ApplicationStatus_Reader(prm);
                if (ds.Tables.Count > 0)
                {
                    txtRefrenceNo.Text = ds.Tables[0].Rows[0]["RefrenceNo"].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtFileNo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            try
            {
                if (e.KeyData == Keys.Tab || e.KeyData == Keys.Enter)
                {


                    SqlParameter[] prm =
               {
                new SqlParameter("@Task","GetPLOTNUMBER"),
                new SqlParameter("@FileNo", txtFileNo.Text),
                new SqlParameter("@PlotNo", null),

                 };
                    DataSet ds = cls_dl_SurchargeWavier_ApplicationStatus.SurchargeWavier_ApplicationStatus_Reader(prm);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtPlotNo.Text = "";
                        txtMemberName.Text = "";
                        txtCNIC.Text = "";
                        txtCategory_Name.Text = "";
                        txtFileNo.Text = ds.Tables[0].Rows[0]["FileNo"].ToString();
                        txtPlotNo.Text = ds.Tables[0].Rows[0]["PlotNo"].ToString();
                        txtMemberName.Text = ds.Tables[0].Rows[0]["MemberName"].ToString();
                        txtCNIC.Text = ds.Tables[0].Rows[0]["CNIC"].ToString();
                        txtCategory_Name.Text = ds.Tables[0].Rows[0]["Category_Name"].ToString();
                        lblSectorCExt.Text = ds.Tables[0].Rows[0]["SectorExtC"].ToString();
                    }
                    else
                    {
                        Clearfunction();
                        MessageBox.Show("Owner Data not exist");
                        // txtPlotNo.Text = "";
                        // txtPlotNo.Text = "Un-Balloted";//ds.Tables[0].Rows[0]["PlotNo"].ToString();
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtPlotNo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Tab || e.KeyData == Keys.Enter)
                {


                    SqlParameter[] prm =
               {
                new SqlParameter("@Task","GetPLOTNUMBER"),
                new SqlParameter("@FileNo", null),
                new SqlParameter("@PlotNo", txtPlotNo.Text),

                 };
                    DataSet ds = cls_dl_SurchargeWavier_ApplicationStatus.SurchargeWavier_ApplicationStatus_Reader(prm);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtPlotNo.Text = "";
                        txtMemberName.Text = "";
                        txtCNIC.Text = "";
                        txtCategory_Name.Text = "";
                        txtFileNo.Text = ds.Tables[0].Rows[0]["FileNo"].ToString();
                        txtPlotNo.Text = ds.Tables[0].Rows[0]["PlotNo"].ToString();
                        txtMemberName.Text = ds.Tables[0].Rows[0]["MemberName"].ToString();
                        txtCNIC.Text = ds.Tables[0].Rows[0]["CNIC"].ToString();
                        txtCategory_Name.Text = ds.Tables[0].Rows[0]["Category_Name"].ToString();
                        lblSectorCExt.Text = ds.Tables[0].Rows[0]["SectorExtC"].ToString();
                    }
                    else
                    {
                        Clearfunction();
                        MessageBox.Show("Owner Data not exist");
                        // txtPlotNo.Text = "";
                        // txtPlotNo.Text = "Un-Balloted";//ds.Tables[0].Rows[0]["PlotNo"].ToString();
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
