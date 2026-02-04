using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeshawarDHASW.Application_Layer.Role_Form
{
    public partial class frmUserAccessClone : Form
    {
        public frmUserAccessClone()
        {
            InitializeComponent();
        }

        private void frmUserAccessClone_Load(object sender, EventArgs e)
        {
            DataRefreshinGrids();

            //LoadUsers(ddExistingAccess);
            LoadUsers(ddCloneAccess);
        }

        private void DataRefreshinGrids()
        {
           

           DataSet dsdp = new DataSet();
            dsdp = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_tbl_control", new SqlParameter("@Task", "DropDownList"));
            

            //ddCloneAccess.DataSource = dsdp.Tables[2].DefaultView;
            //ddCloneAccess.DisplayMember = "username";
            //ddCloneAccess.ValueMember = "ID";
            //ddCloneAccess.SelectedIndex = -1;


            ddExistingAccess.DataSource = dsdp.Tables[2].DefaultView;
            ddExistingAccess.DisplayMember = "username";
            ddExistingAccess.ValueMember = "ID";
            ddExistingAccess.SelectedIndex = -1;



        }

        private void LoadUsers(Telerik.WinControls.UI.RadDropDownList ddAccess)
        {
            using (SqlConnection con = new SqlConnection(clsMostUseVars.Connectionstring))
            using (SqlCommand cmd = new SqlCommand("SELECT ID, username FROM tbl_User where status like 'Active'", con))
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                ddAccess.DataSource = dt;
                ddAccess.DisplayMember = "username";
                ddAccess.ValueMember = "ID";
            }
        }


        private void ddExistingAccess_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

            try
            {

                DataSet dsdp = new DataSet();
                var drv = ddExistingAccess.SelectedItem.Value;
                SqlParameter[] parameter = {
                                         new SqlParameter("@Task", "UserBaseControlRetrive"),
                                         new SqlParameter("@userID",drv.ToString())
                                      };

                dsdp = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_tbl_control", parameter);

                raddgvControlSetting.DataSource = dsdp.Tables[0].DefaultView;

            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }

        }



        private void btnCloneAccess_Click(object sender, EventArgs e)
        {
            if (ddExistingAccess.SelectedValue != null && ddCloneAccess.SelectedValue != null)
            {
                int existingUserId = Convert.ToInt32(ddExistingAccess.SelectedValue);
                int cloneUserId = Convert.ToInt32(ddCloneAccess.SelectedValue);

                if (existingUserId == cloneUserId)
                {
                    MessageBox.Show("You cannot clone access to the same user.");
                    return;
                }

                CloneAccess(existingUserId, cloneUserId);
                MessageBox.Show("Access cloned successfully!");
            }
        }

        private void CloneAccess(int fromUserId, int toUserId)
        {
            using (SqlConnection con = new SqlConnection(clsMostUseVars.Connectionstring))
            using (SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO tbl_Control_Assign_to_User (UserID, ControlID, Status)
                    SELECT @ToUserID, ControlID, Status
                    FROM tbl_Control_Assign_to_User
                    WHERE UserID = @FromUserID AND Status = 1", con))
            {
                cmd.Parameters.AddWithValue("@FromUserID", fromUserId);
                cmd.Parameters.AddWithValue("@ToUserID", toUserId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

       
    }
}
