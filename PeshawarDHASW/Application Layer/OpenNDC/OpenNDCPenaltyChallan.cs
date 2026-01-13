using PeshawarDHASW.Application_Layer.Chalan;
using PeshawarDHASW.Data_Layer.clsChallan;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Models;
using PeshawarDHASW.Report.Challan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.OpenNDC
{
    public partial class OpenNDCPenaltyChallan : Telerik.WinControls.UI.RadForm
    {
        public OpenNDCPenaltyChallan()
        {
            InitializeComponent();
        }

        public OpenNDCPenaltyChallan(int ID_, long FileMapKey_, string FileNo_, long NDCNo_, string RegnNo_, DateTime DealDate_, DateTime DelayDate_, int DelayDays_
              , string BussinessTitle_, string BussinessAddress_, string DealerName1_, string ContactNumber1_, string CNICNo1_
            , decimal Amount_)
        {
            InitializeComponent();
            lblID.Text = ID_.ToString();
            lblFileMapKey.Text = FileMapKey_.ToString();
            FileNo.Text = FileNo_;
            NDCNo.Text = NDCNo_.ToString();
            RegnNo.Text = RegnNo_;
            DealDate.Text = DealDate_.ToLongDateString();
            DelayDate.Text = DelayDate_.ToLongDateString();
            DelayDays.Text = DelayDays_.ToString();
            Amount.Text = Amount_.ToString();
            BusinessTitle.Text = BussinessTitle_;
            BusinessAddress.Text = BussinessAddress_;
            DealerName.Text = DealerName1_;
            MobileNo.Text = ContactNumber1_;
            DealerCNIC.Text = CNICNo1_;
        }

        private void radGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerateChallan_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@Task","GenerateChallanofPenalty"),
                    new SqlParameter("@NDCNo",NDCNo.Text),
                    new SqlParameter("@FileMapKeyBuyerChallan",lblFileMapKey.Text),
                    new SqlParameter("@MembershipIDBuyerChallan",0),
                    new SqlParameter("@NameBuyerChallan",BusinessTitle.Text),
                    new SqlParameter("@TotalAmount",Convert.ToInt32(Amount.Text)),
                    new SqlParameter("@UserID",clsUser.ID),
                    new SqlParameter("@CNICBuyerChallan",DealerCNIC.Text)
                };
                int ChallanID = int.Parse( SQLHelper.ExecuteScalar(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.OpenNDCConverttoNormal", param).ToString());
                DataSet ds = new DataSet();
                SqlParameter[] prm3 =
                {
                                new SqlParameter("@Task","GetChallReportDetail"),
                                new SqlParameter("@ChallanID",ChallanID)
                            };

                ds = cls_dl_Challan.Challan_Reader(prm3);
                ChallanDataset _ds = new ChallanDataset();

                _ds.Tables["tblChallan"].Merge(ds.Tables[0], true, MissingSchemaAction.Ignore);
                _ds.Tables["tblChallanDetail"].Merge(ds.Tables[1], true, MissingSchemaAction.Ignore);
                ds = null;
                frmChallanReportViewer obj = new frmChallanReportViewer(_ds);
                obj.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenNDCPenaltyChallan_Load(object sender, EventArgs e)
        {

        }
    }
}
