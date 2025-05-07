using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.clsChallan;
using PeshawarDHASW.Data_Layer.Installment;
using PeshawarDHASW.Report.Challan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Chalan
{
    public partial class frmChallanVerification : Telerik.WinControls.UI.RadForm
    {
        public frmChallanVerification()
        {
            InitializeComponent();
        }

        private void dgChallanSearch_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "Edit")
                {
                    if (e.Row.Cells["ReceivedRow"].Value.ToString() == "Pending")
                    {
                        frmCreateChallan frm = new frmCreateChallan(e.Row.Cells["ChallanID"].Value.ToString());
                        frm.ShowDialog();
                        btnSearch_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Unable to modify Recieved Challan.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (e.Column.Name == "ReceivedRow")
                {
                    if (e.Row.Cells["ReceivedRow"].Value.ToString() == "Pending")
                    {
                      
                        ChallanVerification obj = new ChallanVerification("Challan Details will never be modified after update.\n Do you want..", true);
                        DateTime date = DateTime.Parse(e.Row.Cells["GenerationDate"].Value.ToString());
                        obj.MinDateofChallan = date;
                        obj.ShowDialog();
                        if (obj.status != null)
                        {
                            if (obj.status == "Approve")
                            {
                                try
                                {
                                    // Automate Installment Saving from Backend in SQL Server
                                    if (obj.Cleardate >= date)
                                    {
                                        #region Installment Amount. Head
                                        SqlParameter[] prm =
                                        {
                                            new SqlParameter("@Task","GetInstallmentChallan"),
                                            new SqlParameter("@ChallanID",e.Row.Cells["ChallanID"].Value),
                                            new SqlParameter("@Status", "Received"),
                                            new SqlParameter("@ClearDate",obj.Cleardate),
                                            // NDC Use Only
                                            new SqlParameter("@StatusForNDC","Received"),
                                            new SqlParameter("@Remarks", obj.Remarks ),
                                            new SqlParameter("@UserIDApproved", Models.clsUser.ID),
                                        };
                                        int result = cls_dl_Challan.Challan_ExecuteNonQuery(prm);
                                        if (result > 0)
                                        {
                                            MessageBox.Show("Recieved successfuly.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            btnReset_Click(null, null);
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        MessageBox.Show("Clear Date of Challan Must Equal to Challan Generation Date or Greater.");
                                    }

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                         
                            }
                            else if (obj.status == "Cancel")
                            {
                                SqlParameter[] prm2 =
                                   {
                                        new SqlParameter("@Task","UpdateChallan"),
                                        new SqlParameter("@ChallanID", e.Row.Cells["ChallanID"].Value),
                                        new SqlParameter("@Status", "Cancelled"),
                                        new SqlParameter("@StatusForNDC","Cancelled"),
                                        new SqlParameter("@Remarks", obj.Remarks ),
                                        new SqlParameter("@UserID", Models.clsUser.ID),
                                    };
                                int resulte = cls_dl_Challan.Challan_ExecuteNonQuery(prm2);
                                if (resulte > 0)
                                {
                                    MessageBox.Show("Cancelled successfuly.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    btnReset_Click(null, null);
                                }
                            }
                            else
                            {
                                //do something else
                            }
                        }
                    }

                }
                else if (e.Column.Name == "PrintPreview")
                {
                    DataSet ds = new DataSet();
                    SqlParameter[] prm3 =
                    {
                        new SqlParameter("@Task","GetChallReportDetail"),
                        new SqlParameter("@ChallanID",e.Row.Cells[0].Value)
                    };

                    ds = cls_dl_Challan.Challan_Reader(prm3);
                    ChallanDataset _ds = new ChallanDataset();

                    _ds.Tables["tblChallan"].Merge(ds.Tables[0], true, MissingSchemaAction.Ignore);
                    _ds.Tables["tblChallanDetail"].Merge(ds.Tables[1], true, MissingSchemaAction.Ignore);
                    ds = null;
                    frmChallanReportViewer obj = new frmChallanReportViewer(_ds);
                    obj.ShowDialog();
                }
            }
            catch (Exception  ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime? dt = null;
            if (string.IsNullOrEmpty(ChallanDate.Text))
                dt = null;
            else
                dt = ChallanDate.Value.Date;
            FillDataGrid(dt);
        }

        private void FillDataGrid(DateTime? dt)
        {
            try
            {
                SqlParameter[] prm =
                 {
                new SqlParameter("@Task","GetChallanDetailSearch"),
                new SqlParameter("@FileNo", string.IsNullOrEmpty(txtFileNo.Text.Trim())? null : txtFileNo.Text.Trim()),
                new SqlParameter("@ChalanNo", string.IsNullOrEmpty(txtChallanNo.Text.Trim())? null : txtChallanNo.Text.Trim()),
                new SqlParameter("@ClearDate", dt),

                 };
                DataSet ds = cls_dl_Challan.Challan_Reader(prm);
                if (ds.Tables.Count > 0)
                {
                    ChallanDetailDS _ds = new ChallanDetailDS();
                    _ds.Tables[0].Merge(ds.Tables[0]);
                    _ds.Tables[1].Merge(ds.Tables[1]);
                    dgChallanSearch.DataSource = _ds.Tables[0];
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DateTime? dt = null;
            if (string.IsNullOrEmpty(ChallanDate.Text))
                dt = null;
            else
                dt = ChallanDate.Value.Date;
            FillDataGrid(dt);
        }

        private void frmChallanVerification_Load(object sender, EventArgs e)
        {

        }
    }
}
