using PeshawarDHASW.Data_Layer.clsFileMap;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.FileMap.SvcBenefitFiles
{
    public partial class frmSvcFileModification : Telerik.WinControls.UI.RadForm
    {
        public frmSvcFileModification()
        {
            InitializeComponent();
        }
        public string FileMapkey { get; set; }
        public frmSvcFileModification(string perFileMapkey ,string FileNo,string SizeDetail,
            string ExtraLand,string InvestorName,string PlotSize,string FirstBuyerName,string Remarks)
        {
            InitializeComponent();
            FileMapkey = perFileMapkey;
            lblFileNo.Text = FileNo;
            clsPluginHelper.RadDropDownSelectByText(dpPlotSize, PlotSize);
            txtInvestorName.Text = InvestorName;
            txtFirstBuyerName.Text = FirstBuyerName;
            txtRemarks.Text = Remarks;

            if (string.IsNullOrWhiteSpace(SizeDetail)== true)
            {
                rdbnormal.CheckState = CheckState.Checked;
            }
            else if (SizeDetail == "Over size")
            {
                rdboversize.CheckState = CheckState.Checked;
            }
            else if (SizeDetail == "Under size")
            {
                rdbundersize.CheckState = CheckState.Checked;
            }
            else
            {
                rdbnormal.CheckState = CheckState.Checked;
                txtextralessarea.Text = "";
            }
            txtextralessarea.Text = ExtraLand;
        }

        private void frmSettingOverUnder_Load(object sender, EventArgs e)
        {

        }

        private void btnSavechanges_Click(object sender, EventArgs e)
        {
            string isoversundsz = "";
            if (rdbnormal.IsChecked) { isoversundsz = ""; }
            else if (rdboversize.IsChecked) { isoversundsz = rdboversize.Text; }
            else if (rdbundersize.IsChecked) { isoversundsz = rdbundersize.Text; }

            decimal Sizevalue = 0;
 
                bool val = decimal.TryParse(txtextralessarea.Text, out Sizevalue);
                if (val == false)
                {
                    MessageBox.Show("Invalid Value in Extra Land.");
                    return;
                }
                else
                {
                    if (rdboversize.CheckState == CheckState.Checked)
                    {
                        if(Sizevalue < 0)
                        {
                            MessageBox.Show("Invalid Over Size Value. Value Must be Greater than Zero.");
                            return;
                         }
                    }
                    if (rdbundersize.CheckState == CheckState.Checked)
                    {
                        if (Sizevalue > 0)
                        {
                            MessageBox.Show("Invalid Under Size Value. Value Must be Less than Zero.");
                            return;
                         }
                    }
                    if (rdbnormal.CheckState == CheckState.Checked)
                    {
                        if (!string.IsNullOrWhiteSpace(txtextralessarea.Text))
                        {
                            MessageBox.Show("Invalid Extra Size Value. Must be Blank.");
                            return;
                        }
                    }
                }
            
           

            if (RadMessageBox.Show(this,"Attention","Are you Sure to Save Changes.",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                if (!string.IsNullOrWhiteSpace(lblFileNo.Text))
                {
                    try
                    {
                        SqlParameter[] paramOverSize = {
                                                new SqlParameter("@Task","Update_File_Svc"),
                                                new SqlParameter("@FileMapKey",FileMapkey),
                                                new SqlParameter("@InvestorName", clsPluginHelper.DbNullIfNullOrEmpty(txtInvestorName.Text)),
                                                new SqlParameter("@PlotSize", clsPluginHelper.DbNullIfNullOrEmpty(dpPlotSize.SelectedItem.Text)),
                                                new SqlParameter("@FirstBuyerName", clsPluginHelper.DbNullIfNullOrEmpty(txtFirstBuyerName.Text)),
                                                new SqlParameter("@IsOversizeUndersize",isoversundsz == "Normal" ? null : isoversundsz),
                                                new SqlParameter("@Extra_Less_Area",rdbundersize.IsChecked ?  txtextralessarea.Text : txtextralessarea.Text),
                                                new SqlParameter("@Remarks", clsPluginHelper.DbNullIfNullOrEmpty(txtRemarks.Text)),
                                                new SqlParameter("@userID", clsUser.ID),
                        };
                        cls_dl_FileMap.FileMap_NonQuery(paramOverSize);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Changes are not Saved.");
                    }
                  
                   
                }
            }
           
        }
    }
}
