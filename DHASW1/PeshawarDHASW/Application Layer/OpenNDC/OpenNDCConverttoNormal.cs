using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Helper;
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
    public partial class OpenNDCConverttoNormal : Telerik.WinControls.UI.RadForm
    {
        public OpenNDCConverttoNormal()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataLoadForModification();
        }

        private void DataLoadForModification()
        {
            try
            {
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","OpenNDCSearch"),
                clsPluginHelper.SqlparameterAttachtext("@FileNo",txtFileNo.Text),
                clsPluginHelper.SqlparameterAttachtext("@NDCNo",txtNDCNo.Text)
                };
                DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.PreTransferOpenNDCSearch", prm);
                grdModify.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on DataLoadForModification.", ex, "frmNDCModify");
                frmobj.ShowDialog();
            }

        }

        private void OpenNDCConverttoNormal_Load(object sender, EventArgs e)
        {
            DataLoadForModification();
        }

        private void grdModify_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {

            if (e.Column.Name == "NDCinfo")
            {
                int ndcno = int.Parse(e.Row.Cells["NDCNo"].Value.ToString());
                string FileNo = e.Row.Cells["FilePlotNo"].Value.ToString();
                SqlParameter[] param =
                {
                    new SqlParameter("@Task","GetPenaltyNDCModification"),
                    new SqlParameter("@NDCNo",ndcno),
                    new SqlParameter("@FileNo",FileNo)
                };
                DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.OpenNDCConverttoNormal", param);
                if (ds.Tables.Count>0)
                {
                    if (ds.Tables[0].Rows.Count>0)
                    {
                        int ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                        long FileMapKey = long.Parse(ds.Tables[0].Rows[0]["FileMapKey"].ToString());
                        string FileNo_= ds.Tables[0].Rows[0]["FileNo"].ToString();
                        long NDCNo = long.Parse(ds.Tables[0].Rows[0]["NDCNo"].ToString());
                        string RegnNo = ds.Tables[0].Rows[0]["RegnNo"].ToString();
                        DateTime DealDate = DateTime.Parse(ds.Tables[0].Rows[0]["DealDate"].ToString());
                        DateTime DelayDate=DateTime.Parse(ds.Tables[0].Rows[0]["DelayDate"].ToString());
                        int DelayDays = int.Parse(ds.Tables[0].Rows[0]["DelayDays"].ToString());
                        string BussinessTitle = ds.Tables[0].Rows[0]["BussinessTitle"].ToString();
                        string BussinessAddress = ds.Tables[0].Rows[0]["BussinessAddress"].ToString();
                        string DealerName1 = ds.Tables[0].Rows[0]["DealerName1"].ToString();
                        string ContactNumber1 = ds.Tables[0].Rows[0]["ContactNumber1"].ToString();
                        string CNICNo1 = ds.Tables[0].Rows[0]["CNICNo1"].ToString();
                        decimal Amount = 0;
                        bool  amountparse = decimal.TryParse(ds.Tables[0].Rows[0]["Amount"].ToString(),out Amount);
                        if (Amount>0)
                        {

                            SqlParameter[] paramchalancheck = {
                                    new SqlParameter("@Task","ChallanVerification"),
                                    new SqlParameter("@NDCNo",NDCNo)
                            };

                            DataSet dschallan = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.OpenNDCConverttoNormal", paramchalancheck);

                            if (dschallan.Tables.Count>0)
                            {
                                if (dschallan.Tables[0].Rows.Count>0)
                                {
                                    decimal ChallanAmount = 0;
                                    bool flag = decimal.TryParse(dschallan.Tables[0].Rows[0]["ChallanAmount"].ToString(),out ChallanAmount);
                                    string ChallanNo = dschallan.Tables[0].Rows[0]["ChallanNo"].ToString();
                                    string ChallanStatus = dschallan.Tables[0].Rows[0]["ChallanStatus"].ToString();
                                    if (ChallanStatus == "Received")
                                    {
                                        if (ChallanAmount == Amount)
                                        {
                                            OpenNDCModification obj = new OpenNDCModification(ndcno, true);
                                            obj.Show();
                                        }
                                        else
                                        {
                                            OpenNDCPenaltyChallan ndc = new OpenNDCPenaltyChallan(ID, FileMapKey, FileNo_, NDCNo, RegnNo, DealDate, DelayDate, DelayDays
                                                                   , BussinessTitle, BussinessAddress, DealerName1, ContactNumber1, CNICNo1
                                                                   , (Amount- ChallanAmount));
                                            ndc.ShowDialog();

                                           // MessageBox.Show("Penalty Amount is invalid Penalty Amount:"+Amount.ToString()+" Challan No: "+ChallanNo+" Challan Amount:"+ChallanAmount);
                                        }
                                    }
                                    else if (string.IsNullOrWhiteSpace(ChallanStatus))
                                    {
                                        OpenNDCPenaltyChallan ndc = new OpenNDCPenaltyChallan(ID, FileMapKey, FileNo_, NDCNo, RegnNo, DealDate, DelayDate, DelayDays
                                                                    , BussinessTitle, BussinessAddress, DealerName1, ContactNumber1, CNICNo1
                                                                    , Amount);
                                        ndc.ShowDialog();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Challan is not Received Challan No: " + ChallanNo );
                                    }
                                }
                                else
                                {
                                    OpenNDCPenaltyChallan ndc = new OpenNDCPenaltyChallan(ID, FileMapKey, FileNo_, NDCNo, RegnNo, DealDate, DelayDate, DelayDays
                                                                    , BussinessTitle, BussinessAddress, DealerName1, ContactNumber1, CNICNo1
                                                                    , Amount);
                                    ndc.ShowDialog();
                                }
                            }
                            
                            
                        }
                        else
                        {
                            OpenNDCModification obj = new OpenNDCModification(ndcno, true);
                            obj.Show();
                        }
                    }
                    else
                    {
                        OpenNDCModification obj = new OpenNDCModification(ndcno, true);
                        obj.Show();
                    }
                }
                // if(dt.Rows.Count > 0)

              
                DataLoadForModification();
            }
        }
    }
}
