using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsErrorLog;
using PeshawarDHASW.Data_Layer.Installment;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Models;

namespace PeshawarDHASW.Application_Layer.Installment.InstPlan
{
    public partial class frmInstPlanModify : RadForm
    {
        public frmInstPlanModify()
        {
            InitializeComponent();
        }

        private int TemplateID { get; set; }

        private void LoadDefaultData()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("App.USP_InstallmentPlan");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Task", "select");
                DataSet ds = cls_dl_instPlan.InstalPlan_Reader(cmd);
                radgvplan.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception in LoadDefaultData.", ex, "frmInstPlanModify");
                frmobj.ShowDialog();
            }
        }

        private void LoadDefaultData(int InstTemplateNo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("App.USP_InstallmentPlan");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Task", "select");
                cmd.Parameters.AddWithValue("@instalTempID", InstTemplateNo);
                DataSet ds = cls_dl_instPlan.InstalPlan_Reader(cmd);
                radgvplan.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception in LoadDefaultData (with Template).", ex, "frmInstPlanModify");
                frmobj.ShowDialog();
            }
        }

        private void addingControltoGrid()
        {
            GridViewCommandColumn editColumn = new GridViewCommandColumn
            {
                Name = "Edit",
                UseDefaultText = true,
                FieldName = "tPlanID",
                DefaultText = "Edit",
                Width = 80,
                TextAlignment = ContentAlignment.MiddleCenter,
                HeaderText = "Edit"
            };
            radgvplan.MasterTemplate.Columns.Add(editColumn);

            GridViewCommandColumn deleteColumn = new GridViewCommandColumn
            {
                Name = "Delete",
                UseDefaultText = true,
                FieldName = "Delete",
                DefaultText = "Delete",
                Width = 80,
                TextAlignment = ContentAlignment.MiddleCenter,
                HeaderText = "Delete"
            };
            radgvplan.MasterTemplate.Columns.Add(deleteColumn);
        }

        private void frmInstPlanModify_Load(object sender, EventArgs e)
        {
            try
            {
                btnAdd.Visible = false;
                radgvplan.DataSource = null;
                addingControltoGrid();
                //LoadDefaultData();
                txtFileNo.Focus();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception in frmInstPlanModify_Load.", ex, "frmInstPlanModify");
                frmobj.ShowDialog();
            }
        }

        

        private void radgvplan_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = radgvplan.CurrentCell.RowIndex;
                string branch = UserHelper.GetUserBranch();

                if (e.Column.Name == "Edit" && TemplateID > 0)
                {
                    int ID = int.Parse(radgvplan.Rows[rowIndex].Cells[0].Value.ToString());
                    int oldaccntseries = int.Parse(e.Row.Cells["AcctStSeries"].Value.ToString());
                    frmInstPlanAdd_MOdify obj = new frmInstPlanAdd_MOdify(ID, TemplateID, txtFileNo.Text.Trim(), oldaccntseries);
                    obj.ShowDialog();
                    LoadDefaultData(TemplateID); // Refresh grid 
                    //LoadTemplateByFileNo(txtFileNo.Text.Trim()); // Refresh grid
                    RefreshGridByFileNo(txtFileNo.Text.Trim());
                }

                //new change code

                else if (e.Column.Name == "Delete")
                {
                    DialogResult result = RadMessageBox.Show(
                        "Do you want to delete this record?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        RadMessageIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            int planID = int.Parse(e.Row.Cells["PlanID"].Value.ToString());
                            int oldaccntseries = int.Parse(e.Row.Cells["AcctStSeries"].Value.ToString());

                            string connectionString = clsMostUseVars.Connectionstring;
                            using (SqlConnection conn = new SqlConnection(connectionString))
                            {
                                conn.Open();

                                using (SqlCommand cmd = new SqlCommand("App.USP_InstallmentPlan", conn))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    // Add parameters
                                    cmd.Parameters.AddWithValue("@Task", "delete");
                                    cmd.Parameters.AddWithValue("@PlanID", planID);
                                    cmd.Parameters.AddWithValue("@instalTempID", TemplateID);
                                    cmd.Parameters.AddWithValue("@userID", Models.clsUser.ID);
                                    cmd.Parameters.AddWithValue("@FileNo", txtFileNo.Text.Trim());
                                    cmd.Parameters.AddWithValue("@OldAccntSeries", oldaccntseries);

                                    // Add return parameter
                                    SqlParameter returnParam = cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);
                                    returnParam.Direction = ParameterDirection.ReturnValue;

                                    cmd.ExecuteNonQuery();

                                    int returnValue = (int)returnParam.Value;

                                    bool rslt = clsPluginHelper.ApplicationLogSaving(txtFileNo.Text, Models.clsUser.ID + "-" + clsUser.Name + "-" + branch, "Deleted Installment Plan ID : " + planID.ToString(), cmd, "frmInstPlanModify - radgvplan_CellClick", "SQLCommand");

                                    if (returnValue == 1)
                                    {
                                        RadMessageBox.Show("Record deleted successfully",
                                            "Success",
                                            MessageBoxButtons.OK,
                                            RadMessageIcon.Info);

                                        LoadDefaultData(TemplateID);
                                        ReorderAcctStSeries(TemplateID);
                                        RefreshGridByFileNo(txtFileNo.Text.Trim());
                                    }
                                    else if (returnValue == 0)
                                    {
                                        RadMessageBox.Show("No records were deleted",
                                            "Information",
                                            MessageBoxButtons.OK,
                                            RadMessageIcon.Exclamation);
                                    }
                                    else if (returnValue == -1)
                                    {
                                        RadMessageBox.Show("Error occurred during deletion",
                                            "Error",
                                            MessageBoxButtons.OK,
                                            RadMessageIcon.Error);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            RadMessageBox.Show($"Error deleting record: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                RadMessageIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception in radgvplan_CellClick.", ex, "frmInstPlanModify");
                frmobj.ShowDialog();
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                frmInstPlanAdd_MOdify obj = new frmInstPlanAdd_MOdify(TemplateID, txtFileNo.Text.Trim());
                obj.ShowDialog();
                ReorderAcctStSeries(TemplateID);
                //LoadTemplateByFileNo(txtFileNo.Text.Trim());
                RefreshGridByFileNo(txtFileNo.Text.Trim());
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception in btnAdd_Click.", ex, "frmInstPlanModify");
                frmobj.ShowDialog();
            }
        }

        private void radBtnSearch_Click(object sender, EventArgs e)
        {
            RefreshGridByFileNo(txtFileNo.Text.Trim());

        }

        private void RefreshGridByFileNo(string fileNo)
        {
            if (string.IsNullOrWhiteSpace(fileNo))
            {
                MessageBox.Show("Please enter a File No.");
                return;
            }

            LoadTemplateByFileNo(fileNo);

            if (TemplateID > 0)
            {
                try
                {
                    SqlParameter[] param =
                    {
                        new SqlParameter("@Task", "GetPlan"),
                        new SqlParameter("@FileNo", fileNo)
                    };

                    DataSet _ds = cls_dl_instPlan.InstalPlanReader(param);

                    radgvplan.DataSource = _ds.Tables[0].DefaultView;

                    //this.radGridView1.Columns["Amount"].FormatString = "{0:N2}";


                    // Format DueDate column
                    if (radgvplan.Columns.Contains("DueDate")) 
                    {
                        radgvplan.Columns["DueDate"].FormatString = "{0:dd-MM-yyyy}";
                        radgvplan.Columns["DueDate"].FormatInfo = System.Globalization.CultureInfo.InvariantCulture;
                        radgvplan.Columns["DueDate"].TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                    }

                    // Format DueDate column
                    if (radgvplan.Columns.Contains("Amount"))
                    {
                        radgvplan.Columns["Amount"].FormatString = "{0:N2}";
                    }

                    btnAdd.Visible = true;

               // bool rslt = clsPluginHelper.ApplicationLogSaving(fileNo, clsUser.Name + "-" + Models.clsUser.ID, "Before - Modification in Installment Plan ", _ds, "frmInstPlanModify - radgvplan_CellClick", "DataSetTable");

                }
                catch (Exception ex)
                {
                    frmExceptionCatched frmobj = new frmExceptionCatched("Exception in RefreshGridByFileNo.", ex, "frmInstPlanModify");
                    frmobj.ShowDialog();
                }
            }
            else
            {
                radgvplan.DataSource = null;
                btnAdd.Visible = true;
                MessageBox.Show("Template not found for the provided File No.");
            }
        }

        
        private void LoadTemplateByFileNo(string fileNo)
        {
            try
            {
                radgvplan.DataSource = null;

                SqlParameter[] param =
                {
                    new SqlParameter("@Task", "GetTemplateIDByFileNo"),
                    new SqlParameter("@FileNo", fileNo)
                };

                // DataSet ds = clsInstallmentTemplate.CreateInsallmentTemplate(param);
                DataSet ds = cls_dl_instPlan.InstalPlanReader(param);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    //TemplateID = ds.Tables[0].Rows[0]["InstalTempID"].ToString();
                    TemplateID = Convert.ToInt32(ds.Tables[0].Rows[0]["InstalTempID"]);
                    LoadDefaultData(TemplateID);
                }
                else
                {
                    TemplateID = 0;
                    MessageBox.Show("No template found for the provided File No.");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception in LoadTemplateByFileNo.", ex, "frmInstPlanModify");
                frmobj.ShowDialog();
            }
        }



        private void ReorderAcctStSeries(int templateID)
        {
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@Task", "ReorderAcctStSeries"),
                    new SqlParameter("@TemplateID", templateID)
                };

                // This method should return an int if you want to confirm update count
                cls_dl_instPlan.ExecuteNonQuery(param);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception in ReorderAcctStSeries.", ex, "frmInstPlanModify");
                frmobj.ShowDialog();
            }
        }


        

    }
}
