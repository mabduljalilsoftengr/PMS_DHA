using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace PeshawarDHASW
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection("Data Source=192.168.0.1;Initial Catalog=DbMembershipImages;User id=sa;Password=!#bU+Ue9;");

            //SqlCommand cmd = new SqlCommand("select ImageFile from tbl_MemberImages where id=5", con);
            byte[] imgData;

            // Of course this command should be adapted to your context
            string cmdText = "SELECT [Image]  FROM [VerifiedDbMembershipImages].[dbo].[tblTransferHistory] where [NDCNo] = 16653 and TFRH_ID = 99342";

            SqlConnection con = new SqlConnection("Server=172.16.0.1; Database=VerifiedDbMembershipImages; user Id=sa; Password=!#bU+Ue9;");
            SqlCommand cmd = new SqlCommand(cmdText, con);

                    con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // First call to get the length of binary data that we want to read back
                        long bufLength = reader.GetBytes(0, 0, null, 0, 0);

                        // Now allocate a buffer big enough to receive the bits...
                        imgData = new byte[bufLength];

                        // Get all bytes from the reader
                        reader.GetBytes(0, 0, imgData, 0, (int)bufLength);

                        // Transfer everything to the Image property of the picture box....
                        MemoryStream ms = new MemoryStream(imgData);
                        ms.Position = 0;
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
            }
        } 
    }

