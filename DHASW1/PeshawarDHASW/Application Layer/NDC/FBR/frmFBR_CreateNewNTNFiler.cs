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

namespace PeshawarDHASW.Application_Layer.NDC.FBR
{
    public partial class frmFBR_CreateNewNTNFiler : Form
    {
        public frmFBR_CreateNewNTNFiler()
        {
            InitializeComponent();
        }
        
        private void btnSaveNTN_Click(object sender, EventArgs e)
        {
            // Get values from text fields
            string ntn = txtNTN.Text.Trim();
            string type = "Filer"; // Note: Only "Filer" will be save to DB
            string name = txtName.Text.Trim();
            string businessName = txtBusinessName.Text.Trim();

            string connectionString = clsMostUseVars.Connectionstring;

            string query = "INSERT INTO tbl_FBROwnerType (NTN, Type, Name, BUSINESS_NAME) VALUES (@NTN, @Type, @Name, @BusinessName)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NTN", ntn);
                    cmd.Parameters.AddWithValue("@Type", type); // Always "Filer"
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@BusinessName", businessName);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record inserted successfully.");
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("Insert failed.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void txtNTN_Leave(object sender, EventArgs e)
        {
            string ntn = txtNTN.Text.Trim();
            if (string.IsNullOrEmpty(ntn))
                return;

             string query = "SELECT COUNT(*) FROM tbl_FBROwnerType WHERE NTN = @NTN";

            //string query = "SELECT ISNULL(NTN, 0) AS NTNExist FROM tbl_FBROwnerType WHERE NTN = @NTN";


            using (SqlConnection conn = new SqlConnection(clsMostUseVars.Connectionstring))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@NTN", ntn);

                try
                {
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    conn.Close();

                    if (count > 0)
                    {
                        MessageBox.Show("This NTN No already exists.");
                        txtNTN.Focus();
                        txtNTN.SelectAll();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error checking NTN: " + ex.Message);
                }
            }
        }

        // Optional method to clear fields after insert
        private void ClearFields()
        {
            txtNTN.Clear();
            txtName.Clear();
            txtBusinessName.Clear();
            txtNTN.Focus();
            ddType.SelectedIndex = -1;
        }
    }
}
