using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Launching
{
    public partial class frmDocImageViewing : Telerik.WinControls.UI.RadForm
    {
        public frmDocImageViewing()
        {
            InitializeComponent();
        }
        public frmDocImageViewing(string ApplicationID)
        {
            InitializeComponent();
            SqlParameter[] par = {
                new SqlParameter("@Task","GetDocList"),
                new SqlParameter("@ApplicationID",ApplicationID)
            };
            DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "p_Gettbl_ApplicationDocInfo", par);
            if (ds.Tables.Count>0)
            {
                if (ds.Tables[0].Rows.Count>0)
                {
                    DGV_ImageInfo.DataSource = ds.Tables[0].DefaultView;
                    foreach (var item in DGV_ImageInfo.Columns)
                    {
                        item.BestFit(); 
                    }
                }
                else
                {
                    MessageBox.Show("No Record Found.");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Connection Error");
            }
            
        }
        private void frmDocImageViewing_Load(object sender, EventArgs e)
        {

        }

        private void DGV_ImageInfo_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            
                string DocID = e.Row.Cells["DocumentTRX"].Value.ToString();
            SqlParameter[] par = {
                new SqlParameter("@Task","GetDoc"),
                new SqlParameter("@DocID",DocID)
            };

            DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "p_Gettbl_ApplicationDocInfo", par);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    byte[] imgData = (byte[])ds.Tables[0].Rows[0]["ApplicationDoc"];
                    MemoryStream ms = new MemoryStream(imgData);
                    ms.Position = 0;
                    pb_Doc.Image =  Image.FromStream(ms);
                }
                else
                {
                    MessageBox.Show("No Record Found.");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Connection Error");
            }
            // frmDocImageViewing obj = new frmDocImageViewing(ApplicationID);
            // obj.ShowDialog();

        }
    }
}
