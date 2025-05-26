using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.clsEmployee;
using PeshawarDHASW.Data_Layer.clsRolePermission;
using PeshawarDHASW.Data_Layer.clsUser;
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

namespace PeshawarDHASW.Application_Layer.User
{
    public partial class frmUserInsertion : Telerik.WinControls.UI.RadForm
    {
        public int UserID { get; set; } = 0;
        public frmUserInsertion()
        {
            InitializeComponent();
        }
        public frmUserInsertion(int get_user)
        {
            UserID = get_user;
            InitializeComponent();
        }

        private void frmUserInsertion_Load(object sender, EventArgs e)
        {

            #region MultiColumn Combobox
            BindGrid_With_Combobox();
            BindData_With_Grid();
            #endregion
            BindRoles_Data();
            if (UserID != 0)
            {
                LoadUserData(UserID);
            }
        }
        private void LoadUserData(int get_id)
        {
            try
            {
                SqlParameter[] prmt =
                        {
                new SqlParameter("@Task","Select"),
                new SqlParameter("@ID",get_id)
            };
                DataSet ds = cls_dl_User.UserReader(prmt);
                #region Find Employee Name
                int empidd = int.Parse(ds.Tables[0].Rows[0]["EmployeeID"].ToString());
                SqlParameter[] pr =
                {
                    new SqlParameter("@Task","Select"),
                    new SqlParameter("@ID",empidd)
                };
                DataSet ds_t = cls_dl_Employee.Employee_Reader(pr, "App.usp_tbl_Employee");
                string emp_name = ds_t.Tables[0].Rows[0]["Name"].ToString();
                #endregion
                ddl_MultiColCombobox_Employee.SelectedValue = get_id;
                #region Find Role Name
                int roleid = int.Parse(ds.Tables[0].Rows[0]["Role"].ToString());
                //SqlParameter[] prm_tr =
                //{
                //    new SqlParameter("@Task","Select_Role"),
                //    new SqlParameter("@RoleID",roleid)
                //};
                //DataTable dt_tt = cls_dl_RolePermission.RolePermission_Reader(prm_tr);
                //string roleName = dt_tt.Rows[0]["RoleID"].ToString();
                #endregion
                ddl_Role.SelectedValue = roleid;
                txtUserName.Text = ds.Tables[0].Rows[0]["username"].ToString();
                txtPassword.Text = ds.Tables[0].Rows[0]["password"].ToString();
                txtFather.Text = ds.Tables[0].Rows[0]["Father"].ToString();
                txtPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
                //+++++++++++++++Decryption ++++++++++++++++++++=
                string Decrypted_Code = cls_dl_User.Decrypt(ds.Tables[0].Rows[0]["Secret_Code"].ToString(), "sblw-3hn8-sqoy19");
                txtSecretCode.Text = Decrypted_Code;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LoadUserData.", ex, "frmUserInsertion");
                frmobj.ShowDialog();
            }

        }
        private void BindRoles_Data()
        {
            try
            {
                RadListDataItem Select = new RadListDataItem();
                Select.Value = 0;
                Select.Text = "-- Select --";
                this.ddl_Role.Items.Add(Select);

                SqlParameter[] prm =
                {
                new SqlParameter("@Task","Select_Role")
            };
                DataTable dt = cls_dl_RolePermission.RolePermission_Reader(prm);
                ddl_Role.DataSource = dt.DefaultView;
                ddl_Role.DisplayMember = "RoleName";
                ddl_Role.ValueMember = "RoleID";
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on BindRoles_Data.", ex, "frmUserInsertion");
                frmobj.ShowDialog();
            }


        }
        private void BindData_With_Grid()
        {
            try
            {
                ddl_MultiColCombobox_Employee.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                SqlParameter[] prmtr =
                {
                    new SqlParameter("@Task","Select")
                };
                DataSet ds = cls_dl_Employee.Employee_Reader(prmtr, "App.usp_tbl_Employee");

                this.ddl_MultiColCombobox_Employee.DataSource = ds.Tables[0].DefaultView;
                // clsRoleMgt.Role_Reader(new SqlParameter[] { new SqlParameter("@Task", "RoleNotCreateYet"), }).DefaultView;
                foreach (GridViewDataColumn column in this.ddl_MultiColCombobox_Employee.MultiColumnComboBoxElement.Columns)
                {
                    if (column.Name == "ID")
                    {
                        column.IsVisible = false;
                    }
                    column.BestFit();
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on BindData_With_Grid.", ex, "frmUserInsertion");
                frmobj.ShowDialog();
            }

        }
        void BindGrid_With_Combobox()
        {
            try
            {
                RadGridView gridViewControl = this.ddl_MultiColCombobox_Employee.EditorControl;
                gridViewControl.MasterTemplate.AutoGenerateColumns = false;
                gridViewControl.Columns.Add(new GridViewTextBoxColumn("ID"));
                gridViewControl.Columns.Add(new GridViewTextBoxColumn("Name"));
                gridViewControl.Columns.Add(new GridViewTextBoxColumn("Rank"));
                gridViewControl.Columns.Add(new GridViewTextBoxColumn("NIC"));
                gridViewControl.Columns.Add(new GridViewTextBoxColumn("Mobile"));
                gridViewControl.Columns.Add(new GridViewTextBoxColumn("AddressPresent"));
                gridViewControl.Columns.Add(new GridViewTextBoxColumn("Email"));
                //+++++++++++++++++++++++++++++++++++     ++++++++++++++++++++++++++++++++++++++
                gridViewControl.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                //+++++++++++++++++++++++++++++++++++     ++++++++++++++++++++++++++++++++++++++
                ddl_MultiColCombobox_Employee.DisplayMember = "Name";
                ddl_MultiColCombobox_Employee.ValueMember = "ID";
                //+++++++++++++++++++++++++++++++++++     ++++++++++++++++++++++++++++++++++++++
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on BindGrid_With_Combobox.", ex, "frmUserInsertion");
                frmobj.ShowDialog();
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserID == 0)
                {
                    #region Insertion
                    int cmb_Rowindex = ddl_MultiColCombobox_Employee.SelectedIndex;
                    RadMultiColumnComboBoxElement a = ddl_MultiColCombobox_Employee.MultiColumnComboBoxElement;
                    string name = a.Rows[cmb_Rowindex].Cells[1].Value.ToString();
                    int EmployeeID = int.Parse(a.Rows[cmb_Rowindex].Cells[0].Value.ToString());
                    string mobile = a.Rows[cmb_Rowindex].Cells[4].Value.ToString();
                    string address = a.Rows[cmb_Rowindex].Cells[5].Value.ToString();
                    string email = a.Rows[cmb_Rowindex].Cells[6].Value.ToString();
                    // +++++++++++++++++++++++++ Encryption ++++++++++++++++++++++++++++++
                    #region Encryption
                    //Here key is of 128 bit  
                    //Key should be either of 128 bit or of 192 bit  
                    string scrt_code_encrpt = "";
                    if (txtSecretCode.Text != string.Empty)
                    {
                        scrt_code_encrpt = cls_dl_User.Encrypt(txtSecretCode.Text, "sblw-3hn8-sqoy19");
                    }
                    #endregion
                    SqlParameter[] prm =
                    {
                        new SqlParameter("@Task","Insert"),
                        new SqlParameter("@username",txtUserName.Text),
                        new SqlParameter("@password",txtPassword.Text),
                        new SqlParameter("@Name",name),
                        new SqlParameter("@Father",txtFather.Text),
                        new SqlParameter("@Email",email),
                        new SqlParameter("@Mobile",mobile),
                        new SqlParameter("@Phone",txtPhone.Text),
                        new SqlParameter("@Address",address),
                        new SqlParameter("@status","Disable"),
                        new SqlParameter("@Role",ddl_Role.SelectedValue.ToString()),
                        new SqlParameter("@EmployeeID",EmployeeID),
                        new SqlParameter("@Secret_Code",scrt_code_encrpt)
                    };
                    int rslt = cls_dl_User.User_NonQuery(prm);
                    if (rslt > 0)
                    {
                        MessageBox.Show("User information successfully inserted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    #endregion
                }
                else
                {
                    #region Updation
                    int cmb_Rowindex = ddl_MultiColCombobox_Employee.SelectedIndex;
                    RadMultiColumnComboBoxElement a = ddl_MultiColCombobox_Employee.MultiColumnComboBoxElement;
                    string name = a.Rows[cmb_Rowindex].Cells[1].Value.ToString();
                    int EmployeeID = int.Parse(a.Rows[cmb_Rowindex].Cells[0].Value.ToString());
                    string mobile = a.Rows[cmb_Rowindex].Cells[4].Value.ToString();
                    string address = null; //a.Rows[cmb_Rowindex].Cells[5].Value.ToString();
                    string email = a.Rows[cmb_Rowindex].Cells[6].Value.ToString();
                    // +++++++++++++++++++++++++ Encryption ++++++++++++++++++++++++++++++
                    #region Encryption
                    //Here key is of 128 bit  
                    //Key should be either of 128 bit or of 192 bit  
                    string scrt_code_encrpt = "";
                    if (txtSecretCode.Text != string.Empty)
                    {
                        scrt_code_encrpt = cls_dl_User.Encrypt(txtSecretCode.Text, "sblw-3hn8-sqoy19");
                    }
                    #endregion
                    SqlParameter[] prm =
                    {
                        new SqlParameter("@Task","Update"),
                        new SqlParameter("@username",txtUserName.Text),
                        new SqlParameter("@password",txtPassword.Text),
                        new SqlParameter("@Name",name),
                        new SqlParameter("@Father",txtFather.Text),
                        new SqlParameter("@Email",email),
                        new SqlParameter("@Mobile",mobile),
                        new SqlParameter("@Phone",txtPhone.Text),
                       // new SqlParameter("@Address",address),
                        new SqlParameter("@Role",ddl_Role.SelectedValue.ToString()),
                        new SqlParameter("@EmployeeID",EmployeeID),
                        new SqlParameter("@Secret_Code",scrt_code_encrpt),
                        new SqlParameter("@ID",UserID)
                    };
                    int rslt = cls_dl_User.User_NonQuery(prm);
                    if (rslt > 0)
                    {
                        MessageBox.Show("User information successfully updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnSave_Click.", ex, "frmUserInsertion");
                frmobj.ShowDialog();
            }


        }

        private void ddl_MultiColCombobox_Employee_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadUserData(int.Parse(ddl_MultiColCombobox_Employee.SelectedValue.ToString()));
            }
            catch (Exception)
            {


            }

        }
    }
}
