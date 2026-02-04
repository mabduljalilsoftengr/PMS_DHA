using Newtonsoft.Json;
using System;
using System.Windows.Forms;
using System.Net;

using System.Text;

namespace PeshawarDHASW.Application_Layer.Chalan
{
    public partial class ChallanApiTest : Telerik.WinControls.UI.RadForm
    {
        public ChallanApiTest()
        {
            InitializeComponent();
        }

        public  class  Bank_Received_ChallanModel
        {
            public long ReciveBankChallan_ID { get; set; }
            public string Bank_Transaction_ID { get; set; }

            public string ChallanNo { get; set; }
            public string CNIC { get; set; }
            //public decimal BankAmount { get; set; }
            public string BankAmount { get; set; }
            public string AmountInWords { get; set; }
            public string FileNo { get; set; }
            public string Status { get; set; }
            //public DateTime Bank_Receivable_DateTime { get; set; }
            public string Bank_Receivable_DateTime { get; set; }
            public string CreatedDate { get; set; }
            public string Bank_IP_Address { get; set; }
            public string BankName { get; set; }
            public string BankAddress { get; set; }
            public string AccountNo { get; set; }
            public string User_Name { get; set; }
            public string SecretKey { get; set; }
            public string BranchCode { get; set; }
            public string PaymentMode { get; set; }
            public string ChequeNumber { get; set; }
        }


  

        private void btnRequestAPI_Click(object sender, EventArgs e)
        {
            using (var client = new WebClient())
            {
                Bank_Received_ChallanModel obj = new Bank_Received_ChallanModel();
                obj.User_Name = "";
                obj.SecretKey = "";
                obj.ChallanNo = "";



               //var json = client.DownloadString("http://172.16.0.1:8089/Challan/TEST?FileID=5");
               // //obj = JsonConvert.DeserializeObject<Bank_Received_ChallanModel>(json);

               //string key =  SecurityHelper.AESEncrypt(obj.User_Name, "", Encoding.UTF8);

                try
                {
                 

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        }

        private void radButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
