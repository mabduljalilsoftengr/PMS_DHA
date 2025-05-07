using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.Installment;
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

namespace PeshawarDHASW.Application_Layer.FileMap.FilePlanAttachment
{
    public partial class frmPlanAttach : Telerik.WinControls.UI.RadForm
    {
        public frmPlanAttach()
        {
            InitializeComponent();
        }
        public string FileMapID { get; set; }
        public frmPlanAttach(string FileNo,string Category,string Date,string fileKey)
        {
            InitializeComponent();
            lblCategory.Text = Category;
            lblFileNo.Text = FileNo;
            lblDate.Text = Date;
            FileMapID = fileKey;
        }

        private void frmPlanAttach_Load(object sender, EventArgs e)
        {
            try
            {

                RadListDataItem Select = new RadListDataItem();
                Select.Value = 0;
                Select.Text = "-- Select --";
                this.rad_dropDown_Template.Items.Add(Select);
                SqlParameter[] param =
                  {
                    new SqlParameter("@Task", "select")
                };

                foreach (DataRow row in clsInstallmentTemplate.InstalTemplate_Reader(param).Tables[0].Rows)
                {
                    RadListDataItem dataItem = new RadListDataItem();
                    dataItem.Value = row["InstalTempID"].ToString();
                    dataItem.Text = row["TemplateName"].ToString();
                    this.rad_dropDown_Template.Items.Add(dataItem);
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmInstlPlanSearch_Load.", ex, "frmInstPlanSearch");
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
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LoadDefaultData.", ex, "frmInstPlanSearch");
                frmobj.ShowDialog();
            }
        }
        public string TemplateSelectedPlan { get; set; } = "0";
        private void rad_dropDown_Template_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            string val = rad_dropDown_Template.SelectedItem.Value.ToString();
            TemplateSelectedPlan = val;
            LoadDefaultData(val);
        }

        private void btnAttachPlan_Click(object sender, EventArgs e)
        {
            if (TemplateSelectedPlan == "0")
            {
                MessageBox.Show("Select the Plan from Plan List");
            }
            else
            {

            }
        }
    }
}
