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
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Role_Form
{
    public partial class frm_ControlSetting : Telerik.WinControls.UI.RadForm
    {
        public frm_ControlSetting()
        {
            InitializeComponent();
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
        }
        private void DataRefreshinGrids()
        {
            DataSet ds = new DataSet();
            ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_tbl_control", new SqlParameter("@Task", "ControlInformatoin"));
            if (ds.Tables.Count > 0)
            {
                radtabdgv.DataSource = ds.Tables[0].DefaultView;
                radgroupdgv.DataSource = ds.Tables[1].DefaultView;
                radbuttondgv.DataSource = ds.Tables[2].DefaultView;
            }

            DataSet dsdp = new DataSet();
            dsdp = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_tbl_control", new SqlParameter("@Task", "DropDownList"));
            radgroupParentID.DataSource = dsdp.Tables[0].DefaultView;
            radgroupParentID.DisplayMember = "ControlName";
            radgroupParentID.ValueMember = "Control_ID";

            radButtonParentGroup.DataSource = dsdp.Tables[1].DefaultView;
            radButtonParentGroup.DisplayMember = "ControlName";
            radButtonParentGroup.ValueMember = "Control_ID";

            UserInforamtion.DataSource = dsdp.Tables[2].DefaultView;
            UserInforamtion.DisplayMember = "username";
            UserInforamtion.ValueMember = "ID";
            UserInforamtion.SelectedIndex = -1;
        }
        private void frm_ControlSetting_Load(object sender, EventArgs e)
        {
            DataRefreshinGrids();
        }

        private void radtabSave_Click(object sender, EventArgs e)
        {
            SqlParameter[] parameters = {
                                    new SqlParameter("@Task","TabSaving"),
                                    //new SqlParameter("@Control_ID",""),
                                    new SqlParameter("@ControlType",radtabControlType.Text),
                                    new SqlParameter("@DisplayName",radtabDisplayName.Text),
                                    new SqlParameter("@ControlName",radtabControlName.Text),
                                    new SqlParameter("@HierarchyLevel",0),
                                    new SqlParameter("@Status",radtabStatus.Checked),
                                    new SqlParameter("@Remarks",radtabRemarks.Text)
                                  //  new SqlParameter("@ParentID","")
                                 };
            int result = 0;
            result = SQLHelper.ExecuteNonQuery(
                                            SQLHelper.createConnection()
                                           , CommandType.StoredProcedure
                                           , "App.USP_tbl_control"
                                           , parameters
                                           );
            DataRefreshinGrids();
            radtabDisplayName.Text = "";
            radtabControlName.Text = "";
            radtabStatus.Checked = false;
            radtabRemarks.Text = "";

        }

        private void radgroupSave_Click(object sender, EventArgs e)
        {
            SqlParameter[] parameters = {
                                    new SqlParameter("@Task","Group_ButtonSaving"),
                                    //new SqlParameter("@Control_ID",""),
                                    new SqlParameter("@ControlType",radgroupControlType.Text),
                                    new SqlParameter("@DisplayName",radgroupDisplayName.Text),
                                    new SqlParameter("@ControlName",radgroupControlName.Text),
                                    new SqlParameter("@HierarchyLevel",1),
                                    new SqlParameter("@Status",radgroupStatus.Checked),
                                    new SqlParameter("@Remarks",radgroupRemarks.Text),
                                    new SqlParameter("@ParentID",radgroupParentID.SelectedItem.Value)
                                 };
            int result = 0;
            result = SQLHelper.ExecuteNonQuery(
                                            SQLHelper.createConnection()
                                           , CommandType.StoredProcedure
                                           , "App.USP_tbl_control"
                                           , parameters
                                           );
            DataRefreshinGrids();
            radgroupControlType.Text = "";
            radgroupDisplayName.Text = "";
            radgroupControlName.Text = "";
            radgroupStatus.Checked = false;
            radgroupRemarks.Text = "";
        }

        private void radButtonSave_Click(object sender, EventArgs e)
        {
            SqlParameter[] parameters = {
                                    new SqlParameter("@Task","Group_ButtonSaving"),
                                    //new SqlParameter("@Control_ID",""),
                                    new SqlParameter("@ControlType",radButtonControlType.Text),
                                    new SqlParameter("@DisplayName",radButtonDisplayName.Text),
                                    new SqlParameter("@ControlName",radButtonControlName.Text),
                                    new SqlParameter("@HierarchyLevel",2),
                                    new SqlParameter("@Status",radButtonStatus.Checked),
                                    new SqlParameter("@Remarks",radButtonRemarks.Text),
                                    new SqlParameter("@ParentID",radButtonParentGroup.SelectedItem.Value)
                                 };
            int result = 0;
            result = SQLHelper.ExecuteNonQuery(
                                            SQLHelper.createConnection()
                                           , CommandType.StoredProcedure
                                           , "App.USP_tbl_control"
                                           , parameters
                                           );
            DataRefreshinGrids();
            radButtonControlType.Text = "";
            radButtonDisplayName.Text = "";
            radButtonControlName.Text = "";
            radButtonStatus.Checked = false;
            radButtonRemarks.Text = "";
        }

        private void UserInforamtion_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(UserInforamtion.Text) || UserInforamtion.Text == "System.Data.DataRowView")
                {
                    return;
                }

                DataSet dsdp = new DataSet();
                var drv = UserInforamtion.SelectedItem.Value;
                SqlParameter[] parameter = {
                                         new SqlParameter("@Task", "UserBaseControlRetrive"),
                                         new SqlParameter("@userID",drv.ToString())
                                      };

                dsdp = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_tbl_control", parameter);
                // raddgvControlSetting.DataSource = null;
                raddgvControlSetting.DataSource = dsdp.Tables[0].DefaultView;
                //UserBaseControlRetrive
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }

        }

        private void MasterTemplate_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "Status")
                {
                    string ControlAssignID = e.Row.Cells["ControlAssignID"].Value.ToString();
                    bool status = (bool)e.Value;
                    int ContorlAssingID = 0;
                    bool M = int.TryParse(ControlAssignID, out ContorlAssingID);
                    if (M != false)
                    {
                        SqlParameter[] parameter = {
                            new SqlParameter("@Task", "UpdateControlAssignment"),
                            new SqlParameter("@ControlAssignID",ContorlAssingID),
                            new SqlParameter("@Status",status)
                        };
                        int result = SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_tbl_control", parameter);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}

