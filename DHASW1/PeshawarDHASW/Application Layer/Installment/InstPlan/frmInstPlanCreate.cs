using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsErrorLog;
using PeshawarDHASW.Data_Layer.Installment;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Models;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.Installment.InstPlan
{
    public partial class frmInstPlanCreate : Telerik.WinControls.UI.RadForm
    {
        #region   Bug : have to put a check button on save so that installment plan is saved against a template     #ABR  


        #endregion

        public frmInstPlanCreate()
        {
            InitializeComponent();
        }



        private void frmInstPlanCreate_Load(object sender, EventArgs e)
        {
            try
            {
                radgvplan.DataSource = null;

                SqlParameter[] param =
                {
                    new SqlParameter("@Task", "NoPlanExist")
                };
                DataSet _dsPhase = clsInstallmentTemplate.InstalTemplate_Reader(param);
                if (_dsPhase.Tables.Count > 0)
                {
                    cmbNewInstallTemp.DataSource = _dsPhase.Tables[0];
                    cmbNewInstallTemp.ValueMember = "InstalTempID";
                    cmbNewInstallTemp.DisplayMember = "Name";
                    cmbNewInstallTemp.SelectedIndex = -1;
                }

                SqlParameter[] parameters =
                {
                   new SqlParameter("@Task", "select")
                };

                #region Template 
                DataSet ds = clsInstallmentTemplate.InstalTemplate_Reader(parameters);
                cmbExistInstTemp.DataSource = ds.Tables[0];
                cmbExistInstTemp.ValueMember = "InstalTempID";
                cmbExistInstTemp.DisplayMember = "TemplateName";

                //SqlParameter[] param1 =
                //{
                //    new SqlParameter("@Task", "PlanExist")
                //};
                //DataSet _dsPhase1 = clsInstallmentTemplate.InstalTemplate_Reader(param1);
                //if (_dsPhase.Tables.Count > 0)
                //{
                //    cmbExistInstTemp.DataSource = _dsPhase1.Tables[0];
                //    cmbExistInstTemp.ValueMember = "InstalTempID";
                //    cmbExistInstTemp.DisplayMember = "Name";
                //}
                dtpStartDate.Value = DateTime.Now;
                //cmbNewInstallTemp.SelectedIndex = -1;
                cmbExistInstTemp.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmInstPlanCreate_Load.", ex, "frmInstPlanCreate");
                frmobj.ShowDialog();

            }

        }

        public static int idtemplete = 0;
        private void rad_dropDown_Template_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                //if (cmbNewInstallTemp.SelectedIndex > 0)
                //{
                //    string str = cmbNewInstallTemp.SelectedValue.ToString();
                //    idtemplete = int.Parse(str);
                //    SqlParameter[] parameters =
                //    {
                //        new SqlParameter("@Task", "select")
                //    };

                    
                //    DataSet ds = clsInstallmentTemplate.InstalTemplate_Reader(parameters);
                //    cmbExistInstTemp.DataSource = ds.Tables[0];
                //    cmbExistInstTemp.ValueMember = "InstalTempID";
                //    cmbExistInstTemp.DisplayMember = "TemplateName";

                    //cmbExistInstTemp.DataSource=ds.Tables[0];
                    //foreach (DataRow dataRow in ds.Tables[0].Rows)
                    //{
                        //dtpStartDate.Value = DateTime.Parse(dataRow["StartDate"].ToString());
                        //dtpStartDate.ReadOnly = true;
                        //radenddate.Text = DateTime.Parse(dataRow["EndDate"].ToString()).ToString("dd-MM-yyyy");
                        //raddescrip.Text = dataRow["Descp"].ToString();
                        //radplotsize.Text = dataRow["PlotSize"].ToString();
                        //radphase.Text = dataRow["Phase"].ToString();
                        
                   // }
                    //DataSet dataSetInstallment = cls_dl_instPlan.InstalTemplate_Reader(parameters, "App.USP_InstallmentPlan");
                    //if (dataSetInstallment.Tables[0].Rows.Count > 0)
                    //{
                    //    radgvplan.ReadOnly = true;
                    //    MessageBox.Show("Selected Plan have already Exist Go to Modify Option for Changes");
                    //}
                    //else
                    //{
                    //    radgvplan.ReadOnly = false;
                    //}
                    

               // }
                //else
                //{
                //    radstartdate.Text = "";
                //    radenddate.Text = "";
                //    radplotsize.Text = "";
                //    radphase.Text = "";
                //    raddescrip.Text = "";
                //}
            }
            catch (Exception ex)
            {
                //frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on rad_dropDown_Template_SelectedIndexChanged.", ex, "frmInstPlanCreate");
                //frmobj.ShowDialog();
            }


            // MessageBox.Show(str);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

          

            if (cmbNewInstallTemp.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select Template for Installment Plan.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbNewInstallTemp.ShowDropDown();
                return;
            }

            else if (cmbExistInstTemp.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select Existing Template for Installment Plan.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbExistInstTemp.ShowDropDown();
                return;
            }

            else if (string.IsNullOrEmpty(txtMonthInt.Text.Trim()))
            {
                MessageBox.Show("Please Enter Month Interval for Installment Plan.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMonthInt.Focus();
                return;
            }

            else if (dtpStartDate.Value.Date.Year == 1)
            {
                MessageBox.Show("Please Select start date for Installment Plan.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SqlParameter[] param =
            {
                new SqlParameter("@Task", "CreateNewTempTemplate"),
                new SqlParameter("@FromPlanID", cmbExistInstTemp.SelectedValue),
                new SqlParameter("@ToPlanID", cmbNewInstallTemp.SelectedValue),
                new SqlParameter("@GapInterval", txtMonthInt.Text),
                new SqlParameter("@StarDate", dtpStartDate.Value.Date),
            };

            DataSet _dsPhase = clsInstallmentTemplate.CreateInsallmentTemplate(param);

            if (_dsPhase.Tables.Count > 0 && _dsPhase.Tables[0].Rows.Count > 0)
            {
                DataTable dt = _dsPhase.Tables[0];

                // Add SrNo column if it doesn't already exist
                if (!dt.Columns.Contains("SrNo"))
                {
                    dt.Columns.Add("SrNo", typeof(int));
                }

                // Assign auto-incremented values
                int sr = 1;
                foreach (DataRow row in dt.Rows)
                {
                    row["SrNo"] = sr++;
                }

                // Optional: Place the SrNo column as the first column in the grid
                if (!radgvplan.Columns.Contains("SrNo"))
                {
                    GridViewTextBoxColumn srNoColumn = new GridViewTextBoxColumn("SrNo");
                    srNoColumn.HeaderText = "Sr No";
                    srNoColumn.ReadOnly = true;
                    srNoColumn.Width = 60;
                    radgvplan.Columns.Insert(0, srNoColumn);
                }

                radgvplan.DataSource = dt;
            }
            else
            {
                radgvplan.DataSource = null;
            }


            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message);
            }

        }





        private DateTime DateChecker(RadLabel rd)
        {

            DateTime startdate;
            if (rd.Text != "-" || rd.Text != "")
            {
                startdate = DateTime.Parse(rd.Text);
            }
            else
            {
                startdate = DateTime.Parse(DateTime.Now.ToString("dd-MM-yyyy"));
            }
            return startdate;

        }

        private void radgvplan_CellValidated(object sender, CellValidatedEventArgs e)
        {
            try
            {
                //var currentRow = radgvplan.CurrentRow;

                //GridDataCellElement cell = this.radgvplan.CurrentCell;

                ////var cell = e.Row.Cells[e.ColumnIndex];
                //#region Due Date
                //if (radgvplan.Columns[e.ColumnIndex].Name == "dtpduedate")
                //{
                //    DateTime startdate = DateChecker(radstartdate);
                //    DateTime endDate = DateChecker(radenddate);
                //    DateTime EnteredDate = DateTime.Parse(cell.Text);
                //    if (EnteredDate.Date >= startdate.Date)
                //    {
                //        if (EnteredDate.Date <= endDate.Date)
                //        {
                //            cell.BorderColor = Color.DarkGreen;
                //        }
                //    }
                //    else
                //    {
                //        MessageBox.Show("Check Due Date Which is Incorrect");
                //        cell.Value = startdate.ToString("dd-MM-yyyy");
                //    }
                //    //MessageBox.Show(cell.Text);
                //}
                //else
                //{

                //}
                //#endregion

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on radgvplan_CellValidated.", ex, "frmInstPlanCreate");
                frmobj.ShowDialog();
            }

        }

        private void radbbtnsave_Click(object sender, EventArgs e)
        {
            try
            {
                //if (idtemplete != 0)
                //{
                //    int row = radgvplan.Rows.Count;
                //    if (row > 0)
                //    {
                //        for (int i = 0; i < row; i++)
                //        {
                //            #region
                //            string instno = radgvplan.Rows[i].Cells[0].Value.ToString();
                //            string Descrp = radgvplan.Rows[i].Cells[1].Value.ToString();
                //            string DueDate = radgvplan.Rows[i].Cells[2].Value.ToString();
                //            string Amount = radgvplan.Rows[i].Cells[3].Value.ToString();
                //            string Remarks = radgvplan.Rows[i].Cells[4].Value.ToString();
                //            SqlCommand cmd = new SqlCommand("App.USP_InstallmentPlan");
                //            cmd.Parameters.AddWithValue("@Task", "insert");
                //            cmd.Parameters.Add("@DueDate", SqlDbType.DateTime).Value = DueDate;
                //            cmd.Parameters.AddWithValue("@InstNo", instno);
                //            cmd.Parameters.AddWithValue("@instalTempID", idtemplete);
                //            cmd.Parameters.AddWithValue("@Descp", Descrp);
                //            cmd.Parameters.AddWithValue("@Amount", Amount);
                //            cmd.Parameters.AddWithValue("@Remarks", Remarks);
                //            cmd.Parameters.AddWithValue("@userID", Models.clsUser.ID);

                //            int result = 0;
                //            result = cls_dl_instPlan.InstalPlan_NonQuery(cmd);
                //            if (result > 0)
                //            {
                //                // MessageBox.Show("Successful");
                //            }
                //            else
                //            {
                //                MessageBox.Show("Try Again! or Contact to Admin!");
                //            }
                //            #endregion
                //        }
                //    }
                //    else
                //    {
                //        MessageBox.Show("Please Enter Installment Plan.");
                //    }

                //}
                //else
                //{
                //    MessageBox.Show("Select a Template Name.");
                //}
                if (cmbNewInstallTemp.SelectedIndex == -1)
                {
                    MessageBox.Show("Please Select Template for Installment Plan.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbNewInstallTemp.ShowDropDown();
                    return;
                }

                else if (cmbExistInstTemp.SelectedIndex == -1)
                {
                    MessageBox.Show("Please Select Existing Template for Installment Plan.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbExistInstTemp.ShowDropDown();
                    return;
                }

                else if (string.IsNullOrEmpty(txtMonthInt.Text.Trim()))
                {
                    MessageBox.Show("Please Enter Month Interval for Installment Plan.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMonthInt.Focus();
                    return;
                }
                //new file no
                else if (string.IsNullOrEmpty(txtFileNo.Text.Trim()))
                {
                    MessageBox.Show("Please Enter File No for Installment Plan.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFileNo.Focus();
                    return;
                }

                else if (dtpStartDate.Value.Date.Year == 1)
                {
                    MessageBox.Show("Please Select start date for Installment Plan.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    SqlParameter[] param =
                    {
                        new SqlParameter("@Task", "InsertTemplate"),
                        new SqlParameter("@FromPlanID", cmbExistInstTemp.SelectedValue),
                        new SqlParameter("@ToPlanID", cmbNewInstallTemp.SelectedValue),
                        //new SqlParameter("@GapInterval", txtMonthInt.Text),
                        new SqlParameter("@FileNo", txtFileNo.Text),
                        new SqlParameter("@StarDate", dtpStartDate.Value.Date),
                    };
                    DataSet _dsPhase = clsInstallmentTemplate.CreateInsallmentTemplate(param);
                    if (_dsPhase.Tables.Count > 0)
                    {
                        if (_dsPhase.Tables[0].Rows.Count > 0) 
                        {
                            MessageBox.Show("New Installment Plan successfully Created.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //this.radgvplan.PrintStyle.FitWidthMode = PrintFitWidthMode.NoFitCentered;
                            this.radgvplan.PrintStyle.PrintHeaderOnEachPage = true;
                            this.radgvplan.PrintStyle.PrintHiddenRows = false;
                            this.radgvplan.PrintStyle.PrintGrouping = true;
                            this.radgvplan.PrintStyle.PrintSummaries = true;
                            this.radgvplan.PrintStyle.HeaderCellFont = new Font("Arial", 9, FontStyle.Bold);
                            this.radgvplan.PrintStyle.HeaderCellBackColor = Color.LightBlue;
                            this.radgvplan.PrintStyle.GroupRowFont = new Font("Helvetica", 10, FontStyle.Regular);
                            this.radgvplan.PrintStyle.GroupRowBackColor = Color.PaleGoldenrod;
                            
                            this.radgvplan.PrintPreview();
                            cmbNewInstallTemp.SelectedIndex = -1;
                            cmbExistInstTemp.SelectedIndex = -1;
                            frmInstPlanCreate_Load(null, null);
                        }
                        else
                        {
                            MessageBox.Show("New Installment Plan Failed. Please contact support.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmInstPlanCreate_Load(null, null);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on radbbtnsave_Click.\n" + ex.Message, ex, "frmInstPlanCreate");
                frmobj.ShowDialog();
            }
            // radgvplan.Rows.Clear();
        }

        private void txtInstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnCornerPlotCharges_Click(object sender, EventArgs e)
        {
            frmInstPlanAddNewRow frm = new frmInstPlanAddNewRow();
            frm.Show();
        }

        //Clone from DropDown
        private void cmbExistInstTemp_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cmbExistInstTemp.SelectedIndex > 0)
            {
                string cmbExistInstTempDD = cmbExistInstTemp.SelectedValue.ToString();
                SqlParameter[] param =
                {
                    new SqlParameter("@Task", "selectTemplateClone"),
                    new SqlParameter("@FromPlanID", cmbExistInstTempDD)

                };
                DataSet _dsPhase = clsInstallmentTemplate.CreateInsallmentTemplate(param);
                radgvplan.DataSource = _dsPhase.Tables[0].DefaultView;


            }
        }

        private void cmbExistInstTemp_VisualListItemFormatting(object sender, VisualItemFormattingEventArgs args)
        {
            //args.VisualItem.Font = new System.Drawing.Font("Segoe UI", 8, System.Drawing.FontStyle.Regular);

        }

        private void txtMonthInt_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
#endregion