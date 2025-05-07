using PeshawarDHASW.Data_Layer.clsChallan;
using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Chalan
{
    public partial class frmchallancrud : Telerik.WinControls.UI.RadForm
    {

        public frmchallancrud()
        {
            InitializeComponent();
        }
        
        private DataTable ChalHD = new DataTable();
        List<int> ParticularDetailslist = new List<int>();
        
        private void DataLoading_ParticularHead()
        {
            SqlParameter[] param =
            {
                new SqlParameter("@Task","ParticularHeadSelect")
            };
            DataSet ds = Helper.SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_ChallanCRUD", param);
            dgChallanParticularHead.DataSource = ds.Tables[0].DefaultView;
        }

        private void DataLoading_ParticularDetail()
        {
            SqlParameter[] param =
            {
                new SqlParameter("@Task","ParticularDetailSelect")
            };
            DataSet ds = Helper.SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_ChallanCRUD", param);
            dgParticularDetail.DataSource = ds.Tables[0].DefaultView;
        }

        private void DataLoading_PH_PD_List()
        {
            SqlParameter[] param =
            {
                new SqlParameter("@Task","ChallanParticulaHeadAndDetailMap")
            };
            DataSet ds = Helper.SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_ChallanCRUD", param);
            dgPH_PDList.DataSource = ds.Tables[0].DefaultView;
        }

        private void DataLoading_PH_PD_PlotSize_List()
        {
            SqlParameter[] param =
            {
                new SqlParameter("@Task","PlotSizeParticularBinding")
            };
            DataSet ds = Helper.SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_ChallanCRUD", param);
            dgPlotBindingData.DataSource = ds.Tables[0].DefaultView;
        }

        private void frmchallancrud_Load(object sender, EventArgs e)
        {
            DataLoading_ParticularHead();
            DataLoading_ParticularDetail();
            DataLoading_PH_PD_List();
            DataLoading_PH_PD_PlotSize_List();
            ParticularHeadBinding();
            ParticularDetailsBinding();
            ParticularPlotSizeBinding();
            PlotSizeBinding(drp_PlotSize);
        }

        #region ......................  Challan Particular Head 
        private void btn_particularHead_Click(object sender, EventArgs e)
        {
            SavingclsParicularHead();
            DataLoading_ParticularHead();
            ParticularHeadBinding();

        }
        private void SavingclsParicularHead()
        {
            try
            {
                if (string.IsNullOrEmpty(txt_particularHead.Text.Trim()))
                {
                    errorChallan.SetError(txt_particularHead, "Please Enter Particular Head.");
                    return;
                }
                    bool PHStatus = PartHeadStatus.Checked ? true : false;
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task","ParticularHeadinsert"),
                    new SqlParameter("@ChlnParHeadID", txtChlnParHeadID.Text),
                    new SqlParameter("@ParticularHeadName", txt_particularHead.Text),
                    new SqlParameter("@PartHeadDescription", txt_particularHeadDescp.Text),
                    new SqlParameter("@BusinessType", dpBusinessType.Text),
                    new SqlParameter("@ChlnType", dpChallanType.Text),
                    new SqlParameter("@PartHeadStatus", PHStatus),
                };
                int result = 0;
                result = Helper.SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_ChallanCRUD", parameters);
                if (result > 0)
                {
                    MessageBox.Show("Record successfully added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clearfunction();
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
        private void Clearfunction()
        {
            errorChallan.SetError(txt_particularHead, "");
            txt_particularHead.Clear();
            txt_particularHeadDescp.Clear();
        }

        #endregion

        #region .........................  Challan particular Details

        private void btn_particularDetails_Click(object sender, EventArgs e)
        {
            SavingclsParicularDetails();
            DataLoading_ParticularDetail();
            ParticularDetailsBinding();
        }
        private void SavingclsParicularDetails()
        {
            try
            {
                if (string.IsNullOrEmpty(txt_particularDetails.Text.Trim()))
                {                   
                    errorChallan.SetError(txt_particularDetails, "Please Enter Particular Details.");
                    return;
                }
                bool PDStatus = PartDetailStatus.Checked ? true : false;
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task","CH_DetailInsert"),
                    new SqlParameter("@ParDetID",ParDetID.Text),
                    new SqlParameter("@PartDetailName", clsPluginHelper.DbNullIfNullOrEmpty(txt_particularDetails.Text)),
                    new SqlParameter("@PartDetailDescription", clsPluginHelper.DbNullIfNullOrEmpty(txt_particularDetailDesp.Text)),
                    new SqlParameter("@PartDetailStatus", PDStatus),
                    new SqlParameter("@FeeType",clsPluginHelper.DbNullIfNullOrEmpty(dpFeeType.Text)),
                    new SqlParameter("@CalculationType",clsPluginHelper.DbNullIfNullOrEmpty(dpCalculationType.Text)),
                    new SqlParameter("@FromSize",clsPluginHelper.DbNullIfNullOrEmpty(fromSize.Text)),
                    new SqlParameter("@ToSize",clsPluginHelper.DbNullIfNullOrEmpty(ToSize.Text)),
                    new SqlParameter("@TypeSize",clsPluginHelper.DbNullIfNullOrEmpty(dpTypeSize.Text)),
                    new SqlParameter("@CDAmount",clsPluginHelper.DbNullIfNullOrEmpty(txtCDAmount.Text)),
                    new SqlParameter("@Other",clsPluginHelper.DbNullIfNullOrEmpty(txtOther.Text))

                };
                int result = 0;
                result = Helper.SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_ChallanCRUD", parameters);
                if (result > 0)
                {
                    MessageBox.Show("Record successfully added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnPaticularDetailNew_Click(null,null);
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

        #endregion

        private void ParticularHeadBinding()
        {
            dp_ParticularHead.DataSource = null;
            RadListDataItem select = new RadListDataItem();
            select.Value = 0;
            select.Text = "-- Select Particular Head --";
            dp_ParticularHead.Items.Add(select);
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","CH_PartHeadReader"),
            };
            foreach (DataRow row in cls_dl_Challan.Challan_ParticularHeadReader(prm).Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["ChlnParHeadID"].ToString();
                dataItem.Text = row["ParticularName"].ToString();

                dp_ParticularHead.Items.Add(dataItem);
            }
            dp_ParticularHead.SelectedIndex = -1;
        }
        private void ParticularDetailsBinding()
        {
            dp_ParticularDetail.DataSource = null;
            RadListDataItem select = new RadListDataItem();
            select.Value = 0;
            select.Text = "-- Select Particular Details --";
            dp_ParticularDetail.Items.Add(select);
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","CH_PartDetailsReader"),
            };
            foreach (DataRow row in Helper.SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_ChallanCRUD", prm).Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["ParDetID"].ToString();
                dataItem.Text = row["Particular"].ToString();
                dp_ParticularDetail.Items.Add(dataItem);
            }
            dp_ParticularDetail.SelectedIndex = -1;
        }
        private void ParticularPlotSizeBinding()
        {
            dp_PlotSizeMap.DataSource = null;
            RadListDataItem select = new RadListDataItem();
            select.Value = 0;
            select.Text = "-- Select Particular Details --";
            dp_ParticularDetail.Items.Add(select);
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","PlotSizeParticularBindList"),
            };
            foreach (DataRow row in Helper.SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_ChallanCRUD", prm).Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["ParHe_ParDet_MapID"].ToString();
                dataItem.Text = row["Particular"].ToString();
                dp_PlotSizeMap.Items.Add(dataItem);
            }
            dp_PlotSizeMap.SelectedIndex = -1;
        }
        private void PlotSizeBinding(RadDropDownList plotSize)
        {
            RadListDataItem select = new RadListDataItem();
            plotSize.Items.Clear();
            select.Value = 0;
            select.Text = "-- Select Plot Size --";
            plotSize.Items.Add(select);
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","CH_PlotSizeReader"),
            };
            foreach (DataRow row in Helper.SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_ChallanCRUD", prm).Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["ID"].ToString();
                dataItem.Text = row["PlotSize"].ToString();
                plotSize.Items.Add(dataItem);
            }
            plotSize.SelectedIndex = -1;
        }
        private void btn_saveHD_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] parameters =
                               {
                    new SqlParameter("@Task","PlotSizeMapInsert"),
                    new SqlParameter("@P_POMapID",P_POMapID.Text),
                    new SqlParameter("@ParHe_ParDet_MapID",llbMapCode_PB.Text),
                    new SqlParameter("@PlotSizeID",drp_PlotSize.SelectedItem.Value),
                    new SqlParameter("@PMAmount",txt_Amount.Text)
                };
                int result = Helper.SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_ChallanCRUD", parameters);
                if (result > 0)
                {
                    MessageBox.Show("Record successfully added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataLoading_PH_PD_PlotSize_List();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
               
        }
        private void drop_partDetails_ItemCheckedChanged(object sender, RadCheckedListDataItemEventArgs e)
        {
           
            RadCheckedListDataItem checkeditem = e.Item;
            if (checkeditem.Checked == true)
            {
                // Add more items to List  
                ParticularDetailslist.Add(int.Parse(checkeditem.Value.ToString()));
            }
        }
        private void btnChallanParticularHeadNew_Click(object sender, EventArgs e)
        {
            txtChlnParHeadID.Text = "0";
            txt_particularHead.Text = "";
            txt_particularHeadDescp.Text = "";
            dpBusinessType.SelectedIndex = 0;
            dpChallanType.SelectedIndex = 0;
            PartHeadStatus.CheckState = CheckState.Checked;
        }
        private void dgChallanParticularHead_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                txtChlnParHeadID.Text = e.Row.Cells["ChlnParHeadID"].Value.ToString();
                txt_particularHead.Text = e.Row.Cells["ParticularName"].Value.ToString();
                txt_particularHeadDescp.Text = e.Row.Cells["PartDescription"].Value.ToString();
                Helper.clsPluginHelper.RadDropDownSelectByText(  dpBusinessType, e.Row.Cells["BusinessType"].Value.ToString());
                Helper.clsPluginHelper.RadDropDownSelectByText(dpChallanType,e.Row.Cells["ChlnType"].Value.ToString());
                PartHeadStatus.CheckState = e.Row.Cells["Status"].Value.ToString() == "True" ? CheckState.Checked : CheckState.Unchecked;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }
        private void dgParticularDetail_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                ParDetID.Text = e.Row.Cells["ParDetID"].Value.ToString();
                Helper.clsPluginHelper.RadDropDownSelectByText(dpFeeType, e.Row.Cells["FeeType"].Value.ToString());
                txt_particularDetails.Text = e.Row.Cells["Particular"].Value.ToString();
                txt_particularDetailDesp.Text= e.Row.Cells["Description"].Value.ToString();
                Helper.clsPluginHelper.RadDropDownSelectByText(dpCalculationType, e.Row.Cells["CalculationType"].Value.ToString());
                Helper.clsPluginHelper.RadDropDownSelectByText(dpTypeSize, e.Row.Cells["TypeSize"].Value.ToString());
                fromSize.Text = e.Row.Cells["FromSize"].Value.ToString();
                ToSize.Text = e.Row.Cells["ToSize"].Value.ToString();
                txtCDAmount.Text = e.Row.Cells["CDAmount"].Value.ToString();
                txtOther.Text = e.Row.Cells["Other"].Value.ToString();
                PartDetailStatus.CheckState = e.Row.Cells["pdstatus"].Value.ToString() == "True" ? CheckState.Checked : CheckState.Unchecked;
            }
            catch (Exception ex)
            {
            }
        }
        private void btnPaticularDetailNew_Click(object sender, EventArgs e)
        {
            ParDetID.Text = "0";
            dpFeeType.SelectedIndex = 0;
            txt_particularDetails.Text = "";
            txt_particularDetailDesp.Text = "";
            dpCalculationType.SelectedIndex = 0;
            dpTypeSize.SelectedIndex = 0;
            fromSize.Text = "";
            ToSize.Text = "";
            txtCDAmount.Text = "";
            txtOther.Text = "";
            PartDetailStatus.CheckState = CheckState.Unchecked;
        }
        private void MasterTemplate_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                lblMapCode.Text = e.Row.Cells["ParHe_ParDet_MapID"].Value.ToString();
                int ParticularHead = int.Parse(e.Row.Cells["ChlnParHeadID"].Value.ToString());
                int ParticularDetial = int.Parse(e.Row.Cells["ParDetID"].Value.ToString());
                clsPluginHelper.RadDropDownSelectedbyValue(dp_ParticularHead, ParticularHead);
                clsPluginHelper.RadDropDownSelectedbyValue(dp_ParticularDetail, ParticularDetial);


                txtChlnParHeadID1.Text = e.Row.Cells["ChlnParHeadID"].Value.ToString();
                txt_particularHead1.Text = e.Row.Cells["ParticularName"].Value.ToString();
                txt_particularHeadDescp1.Text = e.Row.Cells["Ph_Description"].Value.ToString();
                Helper.clsPluginHelper.RadDropDownSelectByText(dpBusinessType1, e.Row.Cells["BusinessType"].Value.ToString());
                Helper.clsPluginHelper.RadDropDownSelectByText(dpChallanType1, e.Row.Cells["ChlnType"].Value.ToString());

                ParDetID1.Text = e.Row.Cells["ParDetID"].Value.ToString();
                Helper.clsPluginHelper.RadDropDownSelectByText(dpFeeType1, e.Row.Cells["FeeType"].Value.ToString());
                txt_particularDetails1.Text = e.Row.Cells["Particular"].Value.ToString();
                txt_particularDetailDesp1.Text = e.Row.Cells["PD_Description"].Value.ToString();
                Helper.clsPluginHelper.RadDropDownSelectByText(dpCalculationType1, e.Row.Cells["CalculationType"].Value.ToString());
                Helper.clsPluginHelper.RadDropDownSelectByText(dpTypeSize1, e.Row.Cells["TypeSize"].Value.ToString());
                fromSize1.Text = e.Row.Cells["FromSize"].Value.ToString();
                ToSize1.Text = e.Row.Cells["ToSize"].Value.ToString();
                txtCDAmount1.Text = e.Row.Cells["CDAmount"].Value.ToString();
                txtOther1.Text = e.Row.Cells["Other"].Value.ToString();
            }
            catch (Exception ex)
            {
                
            }
        }
        private void btnMapbindNew_Click(object sender, EventArgs e)
        {
            lblMapCode.Text = "0";
            dp_ParticularHead.SelectedIndex = 0;
            dp_ParticularDetail.SelectedIndex = 0;
        }
        private void dp_ParticularHead_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                SqlParameter[] param ={
                new SqlParameter("@Task","ParticularHeadInfo"),
                new SqlParameter("@ChlnParHeadID",dp_ParticularHead.SelectedItem.Value)
                 };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_ChallanCRUD", param);
                if (ds.Tables.Count > 0)
                {
                    txtChlnParHeadID1.Text = ds.Tables[0].Rows[0]["ChlnParHeadID"].ToString();
                    txt_particularHead1.Text = ds.Tables[0].Rows[0]["ParticularName"].ToString();
                    txt_particularHeadDescp1.Text = ds.Tables[0].Rows[0]["Ph_Description"].ToString();
                    Helper.clsPluginHelper.RadDropDownSelectByText(dpBusinessType1, ds.Tables[0].Rows[0]["BusinessType"].ToString());
                    Helper.clsPluginHelper.RadDropDownSelectByText(dpChallanType1, ds.Tables[0].Rows[0]["ChlnType"].ToString());
                }
            }
            catch (Exception ex)
            {

            }
           

        }
        private void dp_ParticularDetail_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                SqlParameter[] param = {
                new SqlParameter("@Task","ParticularDetailInfo"),
                new SqlParameter("@ParDetID",dp_ParticularDetail.SelectedItem.Value)
                  };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_ChallanCRUD", param);
                if (ds.Tables.Count > 0)
                {
                    ParDetID1.Text = ds.Tables[0].Rows[0]["ParDetID"].ToString();
                    Helper.clsPluginHelper.RadDropDownSelectByText(dpFeeType1, ds.Tables[0].Rows[0]["FeeType"].ToString());
                    txt_particularDetails1.Text = ds.Tables[0].Rows[0]["Particular"].ToString();
                    txt_particularDetailDesp1.Text = ds.Tables[0].Rows[0]["PD_Description"].ToString();
                    Helper.clsPluginHelper.RadDropDownSelectByText(dpCalculationType1, ds.Tables[0].Rows[0]["CalculationType"].ToString());
                    Helper.clsPluginHelper.RadDropDownSelectByText(dpTypeSize1, ds.Tables[0].Rows[0]["TypeSize"].ToString());
                    fromSize1.Text = ds.Tables[0].Rows[0]["FromSize"].ToString();
                    ToSize1.Text = ds.Tables[0].Rows[0]["ToSize"].ToString();
                    txtCDAmount1.Text = ds.Tables[0].Rows[0]["CDAmount"].ToString();
                    txtOther1.Text = ds.Tables[0].Rows[0]["Other"].ToString();
                }
            }
            catch (Exception ex)
            {
            }
           
        }

        private void btnBindPH_PD_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this,"Please Verify Particular and Particular Detail Before Processed","Warning",MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==DialogResult.Yes)
            {
                string Map_PH_PD = lblMapCode.Text;
                string ParticularID = txtChlnParHeadID1.Text;
                string ParticularDetailID = ParDetID1.Text;
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task","ChallanParticularMapping"),
                    new SqlParameter("@ParHe_ParDet_MapID",Map_PH_PD),
                    new SqlParameter("@ChlnParHeadID",ParticularID),
                    new SqlParameter("@ParDetID",ParticularDetailID)
                };
              int result =  Helper.SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_ChallanCRUD", parameters);
                if (result>0)
                {
                    MessageBox.Show("Record successfully added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnMapbindNew_Click(null, null);
                    DataLoading_PH_PD_List();
                }
            }
        }

        private void btnPlotSizeMapping_Click(object sender, EventArgs e)
        {
            P_POMapID.Text = "0";
            dp_PlotSizeMap.SelectedIndex = 0;
            drp_PlotSize.SelectedIndex = 0;
            txt_Amount.Text = "0";
        }

        private void MasterTemplate_CellClick_1(object sender, GridViewCellEventArgs e)
        {
            try
            {
                string PMPID= e.Row.Cells["P_POMapID"].Value.ToString();
                P_POMapID.Text = PMPID;
                string val = e.Row.Cells["ParticularCheck"].Value.ToString();
                clsPluginHelper.RadDropDownSelectByText(dp_PlotSizeMap, val);
                int PlotSizeID = int.Parse(e.Row.Cells["PlotSizeID"].Value.ToString());
                clsPluginHelper.RadDropDownSelectedbyValue(drp_PlotSize, PlotSizeID);
                txt_Amount.Text = e.Row.Cells["Amount"].Value.ToString();
            }
            catch (Exception ex)
            {
                
            }
        }
        private void dp_PlotSizeMap_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                string val = dp_PlotSizeMap.SelectedItem.Text;
                string[] vallist = Regex.Split(val, @"-");  //val.Split('-');
                PH_MB.Text = vallist[0];
                llbMapCode_PB.Text = vallist[1];
                lblPD_PM.Text = vallist[2];
            }
            catch (Exception ex)
            {
               
            }
        }
    }
}
