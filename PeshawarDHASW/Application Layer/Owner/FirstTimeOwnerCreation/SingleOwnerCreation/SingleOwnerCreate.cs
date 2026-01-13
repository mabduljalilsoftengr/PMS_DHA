using PeshawarDHASW.Data_Layer.clsMemberShip;
using PeshawarDHASW.Data_Layer.Owner;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsFileMap;
using Telerik.WinControls;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.Owner.FirstTimeOwnerCreation.SingleOwnerCreation
{
    public partial class SingleOwnerCreate : Telerik.WinControls.UI.RadForm
    {
        public SingleOwnerCreate()
        {
            InitializeComponent();
            
        }
        #region All Attributes
        
        public string FileNO { get; set; }
        public int FileID { get; set; }
        public  int PlotNo { get; set; }
        public int MemberID { get; set; }
        public int TemplateInsKey { get; set; } = 0;
        public int RecordNo { get; set; } = 0;
        public  object ExtraMBalance { get; set; }=0;
        public  string Status { get; set; }
        public string Remarks { get; set; }
        public int UserId { get; set; }
        public  string PlotSize { get; set; }
        public  int PlotBusinessTypeID { get; set; }
        public int TransferTypeID { get; set; }
        public  int OwnerCategoryID { get; set; }
        #endregion
        public SingleOwnerCreate(string get_FileNO,int tranfertypeID)
        {
            TransferTypeID = tranfertypeID;
            FileNO = get_FileNO;
            InitializeComponent();
            FileMapReader();
            Update_TransferType_IN_FileMap();
           
        }
        private void FileMapReader()
        {
            try
            {
                SqlParameter[] parameter =
                       {
             new SqlParameter("@Task","select"),
             new SqlParameter("@FileNo",FileNO)
            };
                DataSet ds = new DataSet();
                ds = cls_dl_FileMap.FileMap_Reader(parameter);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        FileID = int.Parse(row["FileMapKey"].ToString());
                        FileNO = row["FileNo"].ToString();
                        PlotNo = int.Parse(row["PlotNo"].ToString());
                        int val = 0;
                        bool ti = int.TryParse(row["TemplateInstKey"].ToString(), out val);
                        TemplateInsKey = val;
                        //  RecordNo = int.Parse(row["RecordNo"].ToString());
                        // ExtraMBalance = row["ExtraMBalance"].ToString();
                        Status = row["Status"].ToString();
                        Remarks = row["Remarks"].ToString();
                        UserId = int.Parse(row["userID"].ToString());
                        PlotSize = row["PlotSize"].ToString();
                        PlotBusinessTypeID = int.Parse(row["PlotBusinessTypeID"].ToString());

                        int val1 = 0;
                        bool ti1 = int.TryParse(row["OwnerCategoryID"].ToString(), out val1);
                        OwnerCategoryID = val1;

                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on FileMapReader.", ex, "SingleOwnerCreate");
                frmobj.ShowDialog();
            }
       
        }
        private void Update_TransferType_IN_FileMap()
        {
            try
            {
                SqlParameter[] param =
                        {
                new SqlParameter("@Task","update"),
                new SqlParameter("@FileMapKey",FileID),
                new SqlParameter("@FileNo",FileNO),
                new SqlParameter("@PlotNo",PlotNo),
                new SqlParameter("@TemplateInstKey",TemplateInsKey),
                new SqlParameter("@RecordNo",RecordNo),
                new SqlParameter("@ExtraMBalance",ExtraMBalance),
                new SqlParameter("@Status",Status),
                new SqlParameter("@Remarks",Remarks),
                new SqlParameter("@userID",UserId),
                new SqlParameter("@PlotSize",PlotSize),
                new SqlParameter("@PlotBusinessTypeID",PlotBusinessTypeID),
                new SqlParameter("@TFRTypeID",TransferTypeID),
                new SqlParameter("@OwnerCategoryID",OwnerCategoryID)
            };
                int result = 0;
                result = cls_dl_FileMap.FileMap_NonQuery(param);
                if (result > 0)
                {
                    MessageBox.Show("TransferType Updated Successfuly.");
                }
                else
                {
                    MessageBox.Show("Contact with Administration.");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Update_TransferType_IN_FileMap.", ex, "SingleOwnerCreate");
                frmobj.ShowDialog();
            }
        
        }

        private void SingleOwnerCreate_Load(object sender, EventArgs e)
        {
            SearchDataAgainstFileNO();
        }
      
        private void SearchDataAgainstFileNO()
        {
            try
            {
                SqlParameter[] parameter =
           {
             new SqlParameter("@Task","SelectDataAgainstFileNO"),
             new SqlParameter("@FileNo",FileNO)
            };
                DataSet ds = new DataSet();
                ds = cls_dl_Owner.Owner_Reader(parameter);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        FileID = int.Parse(row["FileMapKey"].ToString());
                        lblfileno.Text = row["FileNo"].ToString();
                        lblplotno.Text = row["PlotNo"].ToString();
                        lblplotsize.Text = row["PlotSize"].ToString();
                        lbltransfertype.Text = row["Name"].ToString();
                        lblplotbuisinesstype.Text = row["TypeName"].ToString();
                        lblownertype.Text = row["Category_Name"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on SearchDataAgainstFileNO.", ex, "SingleOwnerCreate");
                frmobj.ShowDialog();
            }
           
        }
        private void VerifyMembershipData()
        {
            try
            {
                SqlParameter[] param =
                         {
                new SqlParameter("@Task","VerificationOfMemberData_forOwnerCreation"),
                new SqlParameter("@MembershipNo",txtMSNo.Text)
            };
                DataSet ds = new DataSet();
                ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(param);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    MessageBox.Show("This MembershipNO is Allocated against this FileNO :" + ds.Tables[0].Rows[0]["FileNo"].ToString());
                }
                else
                {
                    SqlParameter[] parameter =
                {
                new SqlParameter("@Task","Select"),
                new SqlParameter("@MembershipNo",txtMSNo.Text)
            };
                    DataSet dst = new DataSet();
                    dst = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameter);
                    foreach (DataRow row in dst.Tables[0].Rows)
                    {
                        MemberID = int.Parse(row["ID"].ToString());
                        lblmsno.Text = row["MembershipNo"].ToString();
                        lblname.Text = row["Name"].ToString();
                        lblnic.Text = row["NICNICOP"].ToString();
                        lbldomicile.Text = row["Domicile"].ToString();
                        lblmobileno.Text = row["MobileNo"].ToString();
                        lblrank.Text = row["Rank"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on VerifyMembershipData.", ex, "SingleOwnerCreate");
                frmobj.ShowDialog();
            }
         
        }
        private void txtMSNo_Leave(object sender, EventArgs e)
        {
            VerifyMembershipData();
        }

        private void btngenerateOwner_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] param =
                          {
                new SqlParameter("@Task","Insert"),
                new SqlParameter("@FileMapID",FileID),
                new SqlParameter("@MemberID",MemberID),
                new SqlParameter("@Status","Current"),
                new SqlParameter("@TypePurchaseID",TransferTypeID),
                new SqlParameter("@userID",Models.clsUser.ID),
                new SqlParameter("@RateofSale",""),
                new SqlParameter("@DateofPurchase",DateTime.Now.ToString("dd/MM/yyyy")),
                new SqlParameter("@DateofSell",""),
                new SqlParameter("@EntryStatus","New")
            };
                int result = cls_dl_Owner.Owner_NonQuery(param);
                if (result > 0)
                {
                    MessageBox.Show("Owner Generated Successfuly.");
                    clearfn();
                }
                else
                {
                    MessageBox.Show("Contact With Administration.");
                }
                this.Hide();
                frmFileVerification obj = new frmFileVerification();
                obj.ShowDialog();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btngenerateOwner_Click.", ex, "SingleOwnerCreate");
                frmobj.ShowDialog();
            }
          
        }
        private void clearfn()
        {

            FileID = 0;
            lblfileno.Text = "";
            lblplotno.Text = "";
            lblplotsize.Text = "";
            lbltransfertype.Text = "";
            lblplotbuisinesstype.Text = "";
            lblownertype.Text = "";
            MemberID = 0;
            txtMSNo.Text = "";
            lblmsno.Text = "";
            lblname.Text = "";
            lblnic.Text = "";
            lbldomicile.Text = "";
            lblmobileno.Text = "";
            lblrank.Text = "";
        }

        private void radButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
