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

namespace PeshawarDHASW.Application_Layer.AdventureArena
{
    public partial class AdventureArenaTicketHead : Telerik.WinControls.UI.RadForm
    {
        public AdventureArenaTicketHead()
        {
            InitializeComponent();
            DataLoadingAdventureHeadTicket();
            DataLoadingAdventureDetailTicket();
            DataLoadingAdventureHeadTicketDropDown();
            DataLoadingAgeGroupDropDown();
        }

        private void DataLoadingAdventureHeadTicket()
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Task","DataView")
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure
                    , "App.USP_tbl_AdventureTicketHead", param
                    );
                AdventureHeadDataGridView.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataLoadingAdventureHeadTicketDropDown()
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Task","TicketHead")
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure
                    , "App.USP_AdventureTicketDetail", param
                    );
                ddTicketDetailHead.DataSource = ds.Tables[0].DefaultView;
                ddTicketDetailHead.DisplayMember = "TicketHeadTitle";
                ddTicketDetailHead.ValueMember = "TicketHeadID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DataLoadingAgeGroupDropDown()
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Task","AgeGroup")
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure
                    , "App.USP_AdventureTicketDetail", param
                    );
                ddType_AgeGroup.DataSource = ds.Tables[0].DefaultView;
                ddType_AgeGroup.DisplayMember = "GroupName";
                ddType_AgeGroup.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataLoadingAdventureDetailTicket()
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Task","TicketDetailView")
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure
                    , "App.USP_AdventureTicketDetail", param
                    );
                DGVAdventureTicketDetail.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AdventureArenaTicketHead_Load(object sender, EventArgs e)
        {

        }

        private void btnAdventureTicketHeadNew_Click(object sender, EventArgs e)
        {
            TicketHeadID.Text = "0";
        }

        private void AdventureHeadDataGridView_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                TicketHeadID.Text = e.Row.Cells["TicketHeadID"].Value.ToString();
                txtTicketHeadTitle.Text = e.Row.Cells["TicketHeadTitle"].Value.ToString();
                txtTicketHeadDescription.Text = e.Row.Cells["TicketHeadDescription"].Value.ToString();
                DateTime t = DateTime.Now;
                bool dt = DateTime.TryParse(e.Row.Cells["DateofEntry"].Value.ToString(), out t);
                DateofEntry.Value = t.Date;
                chkTicketHeadstatus.CheckState = bool.Parse(e.Row.Cells["TicketHeadStatus"].Value.ToString()) == true? CheckState.Checked : CheckState.Unchecked;
                txtRemarks.Text = e.Row.Cells["Remarks"].Value.ToString();
                txtStartfromSerial.Text = e.Row.Cells["StartfromSerial"].Value.ToString();
                txtSerialEnd.Text = e.Row.Cells["SerialEnd"].Value.ToString();
                
            }
            catch (Exception ex)
            {
                
            }
        }

        private void btnadvThsave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Task","AdventureArenaNewHead"),
                    new SqlParameter("@TicketHeadID",TicketHeadID.Text),
                    new SqlParameter("@TicketHeadTitle",txtTicketHeadTitle.Text),
                    new SqlParameter("@TicketHeadDescription",txtTicketHeadDescription.Text),
                    new SqlParameter("@DateofEntry",DateofEntry.Value.Date),
                    new SqlParameter("@TicketHeadStatus",(chkTicketHeadstatus.CheckState == CheckState.Checked ? true:false)),
                    new SqlParameter("@Remarks",txtRemarks.Text),
                    new SqlParameter("@StartfromSerial",txtStartfromSerial.Text),
                    new SqlParameter("@SerialEnd", txtSerialEnd.Text),
                    new SqlParameter("@InsertBy",clsUser.ID),
                    new SqlParameter("@InsertDate",DateTime.Now),
                    new SqlParameter("@UpdateBy",clsUser.ID),
                    new SqlParameter("@UpdateDate",DateTime.Now),
                };
                int result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure
                  , "App.USP_tbl_AdventureTicketHead", param
                  );
                if (result>0)
                {
                    MessageBox.Show("Successful");
                }
                else
                {
                    MessageBox.Show("Error Occur");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DataLoadingAdventureHeadTicket();
            DataLoadingAdventureDetailTicket();
            DataLoadingAdventureHeadTicketDropDown();
            DataLoadingAgeGroupDropDown();
        }

        private void DGVAdventureTicketDetail_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                lblTicketDetailID.Text = e.Row.Cells["TicketDetailID"].Value.ToString();
                Helper.clsPluginHelper.RadDropDownSelectByText( ddTicketDetailHead,e.Row.Cells["TicketHeadTitle"].Value.ToString());
                string TypeAgeGroupVal = e.Row.Cells["Type_AgeGroup"].Value.ToString();
                ddType_AgeGroup.SelectedIndex = ddType_AgeGroup.FindString(TypeAgeGroupVal.Trim().Replace("\r\n",""));
                // Helper.clsPluginHelper.RadDropDownSelectByText( ddType_AgeGroup, e.Row.Cells["Type_AgeGroup"].Value.ToString());
                txtQuantity.Text = e.Row.Cells["Quantity"].Value.ToString();
                chkTicketDetailStatus.CheckState = bool.Parse(e.Row.Cells["TicketDetailStatus"].Value.ToString()) == true ? CheckState.Checked : CheckState.Unchecked;
                txtttdremarks.Text = e.Row.Cells["Remarks"].Value.ToString();
                txtTicketDetailTitle.Text = e.Row.Cells["TicketDetailTitle"].Value.ToString();
                txtFee.Text = e.Row.Cells["Fee"].Value.ToString();
            }
            catch (Exception)
            {

            }
            
        }

        private void btnATDNew_Click(object sender, EventArgs e)
        {
            lblTicketDetailID.Text = "0";

            
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            try
            {
                decimal Fee = 0;
                bool FeeParse = decimal.TryParse(txtFee.Text, out Fee);
                if (FeeParse==false)
                {
                    MessageBox.Show("Fee Amount is Invalid");
                    return;
                }


                SqlParameter[] param ={
                    new SqlParameter("@Task","AdventureTicketDetailNew"),
                    new SqlParameter("@TicketDetailID",lblTicketDetailID.Text),
                    new SqlParameter("@TicketDetailHead",ddTicketDetailHead.SelectedItem.Value),
                    new SqlParameter("@Type_AgeGroup",ddType_AgeGroup.SelectedItem.Text),
                    new SqlParameter("@Quantity",txtQuantity.Text),
                    new SqlParameter("@Fee",txtFee.Text),
                    new SqlParameter("@TicketDetailStatus",(chkTicketDetailStatus.CheckState == CheckState.Checked ? true:false)),
                    new SqlParameter("@Remarks",txtttdremarks.Text),
                    new SqlParameter("@TicketDetailTitle",txtTicketDetailTitle.Text),
                    new SqlParameter("@Insertby",clsUser.ID),
                    new SqlParameter("@InsertDate",DateTime.Now),
                    new SqlParameter("@Updateby",clsUser.ID),
                    new SqlParameter("@Updatedate",DateTime.Now),
                };
                int result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure
                 , "App.USP_AdventureTicketDetail", param
                 );
                if (result > 0)
                {
                    MessageBox.Show("Successful");
                }
                else
                {
                    MessageBox.Show("Error Occur");
                }
                DataLoadingAdventureHeadTicket();
                DataLoadingAdventureDetailTicket();
                DataLoadingAdventureHeadTicketDropDown();
                DataLoadingAgeGroupDropDown();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
