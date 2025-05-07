using PeshawarDHASW.Data_Layer.clsMemberShip;
using PeshawarDHASW.Data_Layer.clsTFR;
using PeshawarDHASW.Data_Layer.Owner;
using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsTypeofPruchase;
using Telerik.WinControls;
using PeshawarDHASW.Data_Layer.clsFileMap;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.Owner.FirstTimeOwnerCreation.MultiOwnerCreation
{
    public partial class frmMultiOwnerCreate : Telerik.WinControls.UI.RadForm
    {
        public frmMultiOwnerCreate()
        {
            InitializeComponent();
        }

        #region All Attribute
        public string FileNO { get; set; }
        public int FileID { get; set; }
        public int PlotNo { get; set; }
        public int MemberID { get; set; }
        public int TemplateInsKey { get; set; }
        public int RecordNo { get; set; }
        public object ExtraMBalance { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public int UserId { get; set; }
        public string PlotSize { get; set; }
        public int PlotBusinessTypeID { get; set; }
        public int OwnerCategoryID { get; set; }
        public string Membership_NO { get; set; }
        public string Member_Name { get; set; }
        public int TransferTypeID { get; set; }
        public string TransferTypeName { get; set; }
        public  int result { get; set; }
        #endregion
        public frmMultiOwnerCreate(string get_FileNO, int tranfertypeID)
        {
            TransferTypeID = tranfertypeID;
            FileNO = get_FileNO;
            InitializeComponent();
            Find_TransferTypeName();
            FileMapReader();
            Update_TransferType_IN_FileMap();
        }
        private void Find_TransferTypeName()
        {
            try
            {
                SqlParameter[] param =
                           {
                new SqlParameter("@Task","Select"),
                new SqlParameter("@TrfTID",TransferTypeID)
            };
                DataSet ds = new DataSet();
                ds = cls_dl_TransferType.TypeofTansfer_Reader(param);
                TransferTypeName = ds.Tables[0].Rows[0]["Name"].ToString();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Find_TransferTypeName.", ex, "frmMultiOwnerCreate");
                frmobj.ShowDialog();

            }

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
                        TemplateInsKey = int.Parse(row["TemplateInstKey"].ToString());
                        RecordNo = int.Parse(row["RecordNo"].ToString());
                        ExtraMBalance = row["ExtraMBalance"].ToString();
                        Status = row["Status"].ToString();
                        Remarks = row["Remarks"].ToString();
                        UserId = int.Parse(row["userID"].ToString());
                        PlotSize = row["PlotSize"].ToString();
                        PlotBusinessTypeID = int.Parse(row["PlotBusinessTypeID"].ToString());
                        OwnerCategoryID = int.Parse(row["OwnerCategoryID"].ToString());

                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on FileMapReader.", ex, "frmMultiOwnerCreate");
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
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Update_TransferType_IN_FileMap.", ex, "frmMultiOwnerCreate");
                frmobj.ShowDialog();
            }
          
        }
        private void txtMSNo_Leave(object sender, EventArgs e)
        {
            VerifyMembershipData();
        }

        private void txtCNIC_Leave(object sender, EventArgs e)
        {
            VerifyMembershipData();
        }

        private void VerifyMembershipData()
        {
            try
            {
                #region Check that this Membership is already the Owner of another File Or Not ?? If "Yes", then it will don't use for this FileNo
                SqlParameter[] param =
                {
                new SqlParameter("@Task","VerificationOfMemberData_forOwnerCreation"),
                new SqlParameter("@MembershipNo",txtMSNo.Text),
                new SqlParameter("@NICNICOP",txtCNIC.Text)
                };
                DataSet ds = new DataSet();
                ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(param);
               
                if (ds.Tables[0].Rows.Count > 0)
                {

                    MessageBox.Show("This MembershipNO is Allocated against this FileNO :" + ds.Tables[0].Rows[0]["FileNo"].ToString());
                }
                #endregion
                else
                {
                    if (txtMSNo.Text != "")
                    {

                        #region Select the Membership Data and Bind with Labels
                        SqlParameter[] parameter =
                        {
                        new SqlParameter("@Task", "Select"),
                        new SqlParameter("@MembershipNo", txtMSNo.Text),
                        new SqlParameter("@NICNICOP", txtCNIC.Text)
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
                            Membership_NO = lblmsno.Text;
                            Member_Name = lblname.Text;
                        }
                        #endregion
                    }
                    else
                    {
                        MessageBox.Show("Enter Membership No | CNIC No.");
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on VerifyMembershipData.", ex, "frmMultiOwnerCreate");
                frmobj.ShowDialog();
            }
        
        }
        private void frmMultiOwnerCreate_Load(object sender, EventArgs e)
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
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on SearchDataAgainstFileNO.", ex, "frmMultiOwnerCreate");
                frmobj.ShowDialog();
            }
           
        }
        List<clsOwner> Ownerlist = new List<clsOwner>();
        private void btnAddToGrid_Click(object sender, EventArgs e)
        {
            try
            {
                Models.clsOwner obj = new clsOwner();
                obj.FileID = FileID;
                obj.FileNO = FileNO;
                obj.MemberID = MemberID;
                obj.MembershipNO = Membership_NO;
                obj.MemberName = Member_Name;
                obj.Status = "Current";
                obj.TypePurchaseID = TransferTypeID;
                obj.TypePurchaseName = TransferTypeName;
                obj.UserID = Models.clsUser.ID;
                obj.RateofSale = "0";
                obj.DateOfPurchase = DateTime.Now.ToString("dd/MM/yyyy");
                obj.DateOfSale = "";
                Ownerlist.Add(obj);
                grdOwner.TableElement.RowHeight = 50;
                grdOwner.DataSource = Ownerlist.DefaultIfEmpty();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnAddToGrid_Click.", ex, "frmMultiOwnerCreate");
                frmobj.ShowDialog();
            }
           
        }

        private void btnSaveOwner_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (clsOwner row in Ownerlist)
                {
                    SqlParameter[] param =
                    {
                    new SqlParameter("@Task","Insert"),
                    new SqlParameter("@FileMapID",row.FileID),
                    new SqlParameter("@MemberID",row.MemberID),
                    new SqlParameter("@Status",row.Status),
                    new SqlParameter("@TypePurchaseID",row.TypePurchaseID),
                    new SqlParameter("@userID",row.UserID),
                    new SqlParameter("@RateofSale",row.RateofSale),
                    new SqlParameter("@DateofPurchase",row.DateOfPurchase),
                    new SqlParameter("@DateofSell",row.DateOfSale),
                    new SqlParameter("@EntryStatus","New")
                };
                    result = cls_dl_Owner.Owner_NonQuery(param);

                }
                if (result > 0)
                {
                    MessageBox.Show("Owners Created Successfully.");
                }
                else
                {
                    MessageBox.Show("Contact with Administration.");
                }
                Ownerlist.Clear();
                grdOwner.DataSource = Ownerlist.DefaultIfEmpty();
                this.Hide();
                frmFileVerification objfrm = new frmFileVerification();
                objfrm.ShowDialog();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnSaveOwner_Click.", ex, "frmMultiOwnerCreate");
                frmobj.ShowDialog();
            }
           
        }
    }
}
