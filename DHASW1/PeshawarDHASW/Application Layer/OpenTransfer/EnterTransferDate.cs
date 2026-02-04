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

namespace PeshawarDHASW.Application_Layer.OpenTransfer
{
    public partial class Enter_Transfer_Date : Form
    {
        public Enter_Transfer_Date()
        {
            InitializeComponent();
        }

        public string NDCNo_ { get; set; }
        public string FileNo_ { get; set; }
        public string FileID_ { get; set; }
        public string PreTransferID_ { get; set; }
        public Enter_Transfer_Date(string NDCNo, string FileNo, string FileID, string PreTransferID)
        {
            NDCNo_ = NDCNo;
            FileNo_ = FileNo;
            FileID_ = FileID;
            PreTransferID_ = PreTransferID;
            InitializeComponent();
        }


        private void btnsedate_Click(object sender, EventArgs e)
        {
           
            SqlParameter[] param = {
                    new SqlParameter("@Task","SetTransferDateofNDC"),
                    //new SqlParameter("@NDCNo",NDCNo_),
                    //new SqlParameter("@FileNo",FileNo_),
                   // new SqlParameter("@FileID", FileID_),
                    new SqlParameter("@PreTransferID",Convert.ToInt32(PreTransferID_)),
                    new SqlParameter("@TransferDate",dtptransferdate.Value)
                    
                };
            int result = SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.OpentransferReport", param);

            if (result > 0)
            {
                this.Close();
            }
        }
    }
}
