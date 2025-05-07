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
using Telerik.WinControls;
using Telerik.WinControls.UI;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.Installment.InstPlan
{
    public partial class frmInstPlanModify : Telerik.WinControls.UI.RadForm
    {
        public frmInstPlanModify()
        {
            InitializeComponent();
        }

        private string TemplateID { get; set; }

        private void SelectIndexChange_InstallmentTemplate()
        {
            try
            {
                radgvplan.DataSource = null;
                if (rad_dropDown_Template.SelectedIndex != 0)
                {
                    string str = rad_dropDown_Template.SelectedValue.ToString();
                    TemplateID = str;
                    var idtemplete = int.Parse(str);
                    SqlParameter[] parameters =
                    {
                    new SqlParameter("@Task", "select"),
                    new SqlParameter("@InstalTempID", str)
                };
                    DataSet ds = clsInstallmentTemplate.InstalTemplate_Reader(parameters);
                    foreach (DataRow dataRow in ds.Tables[0].Rows)
                    {
                        radstartdate.Text = DateTime.Parse(dataRow["StartDate"].ToString()).ToString("dd-MM-yyyy");
                        radenddate.Text = DateTime.Parse(dataRow["EndDate"].ToString()).ToString("dd-MM-yyyy");
                        raddescrip.Text = dataRow["Descp"].ToString();
                        radplotsize.Text = dataRow["PlotSize"].ToString();
                        radphase.Text = dataRow["Phase"].ToString();
                    }
                    LoadDefaultData(idtemplete.ToString());
                    btnSearch.Visible = true;
                }
                else
                {
                    radstartdate.Text = "";
                    radenddate.Text = "";
                    radplotsize.Text = "";
                    radphase.Text = "";
                    raddescrip.Text = "";
                    btnSearch.Visible = false;
                    TemplateID = "";
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on SelectIndexChange_InstallmentTemplate.", ex, "frmInstPlanModify");
                frmobj.ShowDialog();

            }
        }
        private void rad_dropDown_Template_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            SelectIndexChange_InstallmentTemplate();
        }

        private void LoadDefaultData()
        {
            try
            {
                //radgvplan.Rows.Clear();
                SqlCommand cmd = new SqlCommand("App.USP_InstallmentPlan");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Task", "select");
                DataSet ds = cls_dl_instPlan.InstalPlan_Reader(cmd);
                  radgvplan.DataSource = ds.Tables[0].DefaultView;

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LoadDefaultData.", ex, "frmInstPlanModify");
                frmobj.ShowDialog();
            }
        }

        private void LoadDefaultData(string InstTemplateNo)
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
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LoadDefaultData.", ex, "frmInstPlanModify");
                frmobj.ShowDialog();
            }
        }

        private void addingControltoGrid()
        {
            GridViewCommandColumn BioInfo = new GridViewCommandColumn();
            BioInfo.Name = "Edit";
            BioInfo.UseDefaultText = true;
            BioInfo.FieldName = "tPlanID";
            BioInfo.DefaultText = "View";
            BioInfo.Width = 80;
            BioInfo.TextAlignment = ContentAlignment.MiddleCenter;
            BioInfo.HeaderText = "Edit";
            radgvplan.MasterTemplate.Columns.Add(BioInfo);
        }

        private void frmInstPlanModify_Load(object sender, EventArgs e)
        {
            try
            {
                btnSearch.Visible = false;
                radgvplan.DataSource = null;
                RadListDataItem Select = new RadListDataItem();
                Select.Value = 0;
                Select.Text = "-- Select --";
                this.rad_dropDown_Template.Items.Add(Select);
                SqlParameter[] param =
                  {
                    new SqlParameter("@Task", "PlanExist")
                };

                foreach (DataRow row in clsInstallmentTemplate.InstalTemplate_Reader(param).Tables[0].Rows)
                {
                    RadListDataItem dataItem = new RadListDataItem();
                    dataItem.Value = row["InstalTempID"].ToString();
                    dataItem.Text = row["Name"].ToString();
                    this.rad_dropDown_Template.Items.Add(dataItem);
                }
                addingControltoGrid();
                LoadDefaultData();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmInstPlanModify_Load.", ex, "frmInstPlanModify");
                frmobj.ShowDialog();
            }
          
        }

        private void radgvplan_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = radgvplan.CurrentCell.RowIndex;
                int columnindex = radgvplan.CurrentCell.ColumnIndex;
                if (e.Column.Name == "Edit")
                {
                    if (TemplateID != "")
                    {
                        int ID = int.Parse(radgvplan.Rows[rowindex].Cells[0].Value.ToString());
                        frmInstPlanAdd_MOdify obj = new frmInstPlanAdd_MOdify(ID.ToString(), TemplateID);
                        obj.ShowDialog();
                        // SelectIndexChange_InstallmentTemplate();
                    }
                   
                 
                    // Installment.InstTemplate.InstTemplateCreate obj = new InstTemplateCreate(ID.ToString());
                    //  obj.ShowDialog();
                    //  showallData();
                    // MessageBox.Show("BioInfo - > " + SearchDGV.Rows[rowindex].Cells[0].Value.ToString());
                }

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on radgvplan_CellClick.", ex, "frmInstPlanModify");
                frmobj.ShowDialog();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                frmInstPlanAdd_MOdify obj = new frmInstPlanAdd_MOdify(TemplateID);
                obj.ShowDialog();
                SelectIndexChange_InstallmentTemplate();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnSearch_Click.", ex, "frmInstPlanModify");
                frmobj.ShowDialog();
            }
           
        }
    }
}
