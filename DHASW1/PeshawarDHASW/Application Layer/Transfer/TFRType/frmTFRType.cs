using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsTFR;
using Telerik.WinControls;
using PeshawarDHASW.Data_Layer.clsMemberShip;
using PeshawarDHASW.Data_Layer.Owner;
using Telerik.WinControls.UI;
using PeshawarDHASW.Data_Layer;
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Application_Layer.Transfer.TFRType
{
    public partial class frmTFRType : Telerik.WinControls.UI.RadForm
    {
        public frmTFRType()
        {
            InitializeComponent();
        }
        public int MemberID { get; set; }
        public string membershipNo { get; set; }
        public int FileMapKey { get; set; }
        public int passNDCNumber { get; set; }
        public string passFileNo { get; set; }
        public int passChallanNO { get; set; }
        public int PurchaseTypeID { get; set; }
        public string CurrentDate { get; set; }
        public string RateOfSale { get; set; }
        public int TFRAppointmentID { get; set; }
        public string SellerMSNOString { get; set; }
        public string BuyerMSNOString { get; set; }
        public int reslt { get; set; }
        public int result { get; set; }
        public frmTFRType(string FileNo, int ChallanNO, int NDCNumber, int get_purchaseTypeID,int get_TFRAppID)
        {
            passFileNo = FileNo;
            passChallanNO = ChallanNO;
            passNDCNumber = NDCNumber;
            PurchaseTypeID = get_purchaseTypeID;
            TFRAppointmentID = get_TFRAppID;
            InitializeComponent();
        }

        DataSet ds_set = new DataSet();
        private void bntSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] param =
                        {
                new SqlParameter("@FileNo",clsPluginHelper.DbNullIfNullOrEmpty(txtFileNO.Text)),
                new SqlParameter("@PlotNo",clsPluginHelper.DbNullIfNullOrEmpty(txtPlotNo.Text))
            };
                DataSet ds = Data_Layer.clsTFR.cls_dl_TFR.SearchForMembership(param);
                // Attatch Current Date Column To GridView --------------
                GridViewDateTimeColumn dateTimeColumn = new GridViewDateTimeColumn();
                dateTimeColumn.Name = "Currentdate";
                dateTimeColumn.HeaderText = "Current date";
                dateTimeColumn.FieldName = "Currentdate";
                dateTimeColumn.Width = 73;
                dateTimeColumn.FormatString = "{0:dd.MM.yyyy}";
                //dateTimeColumn.Format = DateTimePickerFormat.Custom;
                //dateTimeColumn.CustomFormat = "t";
                grdSellerInfo.MasterTemplate.Columns.Add(dateTimeColumn);
                //--------------------End-----------------------------------------------
                //--------------------Bind Data With Grid and Labels--------------------
                grdSellerInfo.DataSource = ds.Tables[0];
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        FileMapKey = int.Parse(row["FileMapKey"].ToString());
                        sellerMemberID.Text = row["ID"].ToString();
                        lblFileNO.Text = row["FileNo"].ToString();
                        lblPlotNo.Text = row["PlotNo"].ToString();
                        lblSector.Text = row["Sector"].ToString();
                        lblPhase.Text = row["Phase"].ToString();
                        lblDHA.Text = row["DHA"].ToString();
                        //
                        SellerMSNOString = SellerMSNOString + row["MembershipNo"].ToString() + ",";
                        //txtsellerMSNo.Text = row["MembershipNo"].ToString();
                        //txtsellername.Text = row["Name"].ToString();
                        //txtsellfather.Text = row["Father"].ToString();
                        //txtsellcontact.Text = row["MobileNo"].ToString();
                        //txtsellnic.Text = row["NIC"].ToString();
                        //dtpSaleDate.Text = DateTime.Now.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("File No or PlotNo is not Exist", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //--------------------End-----------------------------------------------
                //--------------------Bind Data With Label "lblTransferType"------------
                TypeOfPurchase();
                //--------------------End-----------------------------------------------
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on bntSearch_Click.", ex, "frmTFRType");
                frmobj.ShowDialog();
            }
          
        }
        private void TypeOfPurchase()
        {
            try
            {
                SqlParameter[] parmtr =
                          {
                new SqlParameter("@Task","Select"),
                new SqlParameter("@TypeID",PurchaseTypeID)
            };
                ds_set = cls_dl_TypeofPurchase.TypeofPurchase_Reader(parmtr);
                lblTransferType.Text = ds_set.Tables[0].Rows[0]["Name"].ToString();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on TypeOfPurchase.", ex, "frmTFRType");
                frmobj.ShowDialog();
            }
          
        }
        private void frmOnetoOneTFR_Load(object sender, EventArgs e)
        {
            try
            {
                #region Loading Plot Size
                SqlParameter[] param =
                   {
                    new SqlParameter("@Task", "Select")
                };
                cmbPlotSize.DataSource = Data_Layer.clsPlotSize.cls_dl_PlotSize.PlotSize_Reader(param).Tables[0];
                cmbPlotSize.ValueMember = "ID";
                cmbPlotSize.DisplayMember = "PlotSize";
                #endregion
                #region GV Buyer Grid Columns Conctrols Addding
                //----------------- Attatch Current Date Column To GridView ------------
                GridViewDateTimeColumn dateTimeclmn = new GridViewDateTimeColumn();
                dateTimeclmn.Name = "Currentdate";
                dateTimeclmn.HeaderText = "Current date";
                dateTimeclmn.FieldName = "Currentdate";
                dateTimeclmn.Width = 60;
                dateTimeclmn.FormatString = "{0:dd/MM/yyyy}";
                dateTimeclmn.ReadOnly = true;
                grdBuyerInfo.MasterTemplate.Columns.Add(dateTimeclmn);
                //----------Add Textbox Column to Gridview---------------------------
                GridViewTextBoxColumn textRateOfSale = new GridViewTextBoxColumn();
                textRateOfSale.Name = "RateOfSaleTextBoxColumn";
                textRateOfSale.HeaderText = "Rate Of Sale";
                textRateOfSale.FieldName = "RateofSale";
                textRateOfSale.Width = 60;
                textRateOfSale.TextAlignment = ContentAlignment.BottomRight;
                grdBuyerInfo.MasterTemplate.Columns.Add(textRateOfSale);
                //-------------------------End------------------------------------------

                //----------------------------End------------------------------------

                // ----------------Bind DropDown To GridView Column -----------------
                //SqlParameter[] parmt =
                //{
                // new SqlParameter("@Task","Bind_TypeOfPurchaseData")
                //};
                //DataSet dds = new DataSet();
                //dds = cls_dl_Owner.Owner_Reader(parmt);
                //GridViewComboBoxColumn comboColumn = new GridViewComboBoxColumn();
                //comboColumn.HeaderText = "Type Of Purchase";
                //comboColumn.Name = "PerchaserColumn";
                ////set the column data source - the possible column values
                //comboColumn.DataSource = dds.Tables[0].DefaultView; //For Static "new String[] { "Active", "Disable" };"
                //comboColumn.DisplayMember = "PerchaseTypeName";
                //comboColumn.ValueMember = "TypeID";
                //comboColumn.Width = 120;
                //comboColumn.FieldName = "TypeID";
                ////add the column to the grid
                //grdBuyerInfo.Columns.Add(comboColumn);
                //--------------------End--------------------------------

                #endregion
                #region
                txtFileNO.Text = passFileNo;
                SqlParameter[] parameters =
                {
                new SqlParameter("@Task","NDCNo_FileNo"),
                new SqlParameter("@FileNo",clsPluginHelper.DbNullIfNullOrEmpty(passFileNo)),
                new SqlParameter("@NDCNo",clsPluginHelper.DbNullIfNullOrEmpty(passNDCNumber.ToString()))
            };
                DataSet ds = cls_dl_TFR.SearchFileNOwithNDC(parameters);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    cmbPlotSize.Text = row["PlotSize"].ToString();
                    txtFileNO.Text = row["FileNo"].ToString();
                    txtPlotNo.Text = row["PlotNo"].ToString();
                }
                bntSearch_Click(null, null);
                #endregion
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmOnetoOneTFR_Load.", ex, "frmTFRType");
                frmobj.ShowDialog();
            }
          
        }

        private void btnSaveTFR_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                if (grdBuyerInfo.Rows.Count > 0)
                {
                    #region Find Membership ID
                    //    SqlParameter[] param =
                    //    {
                    //    new SqlParameter("@MemberNo",txtpurchaseMSNO.Text)
                    //};
                    //    DataSet ds = cl_dl_SerachMembership.SearchForMembership(param);
                    //    if (ds.Tables[0].Rows.Count > 0)
                    //    {
                    //        foreach (DataRow row in ds.Tables[0].Rows)
                    //        {
                    //            MemberID = int.Parse(row["ID"].ToString());
                    //        }
                    //    }
                    #endregion
                    #region Insert New Record
                    int count_Buyer = grdBuyerInfo.Rows.Count;
                    for (int i = 0; i < count_Buyer; i++)
                    {
                        object str = grdBuyerInfo.Rows[i].Cells[7].Value == null ? clsPluginHelper.DbNullIfNullOrEmpty("") : grdBuyerInfo.Rows[i].Cells[7].Value.ToString();

                        MemberID = int.Parse(grdBuyerInfo.Rows[i].Cells[0].Value.ToString());
                        RateOfSale = str.ToString();
                        string CurrentDate = DateTime.Now.ToString("dd/MM/yyyy");
                        SqlParameter[] paramtr =
                        {
                new SqlParameter("@Task","Insert"),
                new SqlParameter("@FileMapID",FileMapKey),
                new SqlParameter("@MemberID",MemberID),
                new SqlParameter("@Status","Pending"),
                new SqlParameter("@TypePurchaseID",PurchaseTypeID),
                new SqlParameter("@userID",Models.clsUser.ID),
                new SqlParameter("@RateofSale",RateOfSale),
                new SqlParameter("@DateofPurchase",CurrentDate),
                new SqlParameter("@EntryStatus","New")

                    };
                        reslt = cls_dl_Owner.Owner_NonQuery(paramtr);
                    }
                    if (reslt > 0)
                    {
                        MessageBox.Show("Transfer Done Succefully.");
                    }
                    else
                    {
                        MessageBox.Show("Contact With Administration.");
                    }
                    #endregion
                    #region Update Previous Owner Data
                    int count_Seller = grdSellerInfo.Rows.Count;
                    for (int i = 0; i < count_Seller; i++)
                    {
                        string dateOfSale = DateTime.Now.ToString("dd/MM/yyyy");
                        int Slr_MemberID = int.Parse(grdSellerInfo.Rows[i].Cells[0].Value.ToString());
                        SqlParameter[] parameter =
                        {
                new SqlParameter("@Task","Update_Owner_SomeData"),
                //new SqlParameter("@Status","Transferee"),
                new SqlParameter("@DateofSell",dateOfSale),
                new SqlParameter("@MemberID",Slr_MemberID),
                    };
                        result = cls_dl_Owner.Owner_NonQuery(parameter);
                    }
                    if (result > 0)
                    {
                        MessageBox.Show("Updated Successfully");
                    }
                    #endregion
                    //frmTakeImage obj = new frmTakeImage(passFileNo, passNDCNumber, PurchaseTypeID, SellerMSNOString, BuyerMSNOString);
                    //obj.ShowDialog();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Please Insert Buyer Information in List.");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnSaveTFR_Click.", ex, "frmTFRType");
                frmobj.ShowDialog();
            }
        
        }
        /// <summary>
        /// Transfer Setting
        /// </summary>
        /// <returns></returns>
        /// 
        //-(1)-----Check that this Membership NO is already is the Current Owner or Previous Owner or not
        //i.e that this Membership NO already in Owner Table is exist or not------------------------------
        private bool PreviousCurrentExists(out string FileNo)
        {
            string fileno = "";
            DataSet dst = new DataSet();
            try
            {
                SqlParameter[] par =
               {
               new SqlParameter("@Task","Select"),
               new SqlParameter("@MSNO",txtpurchaseMSNO.Text)
            };
               
                dst = cls_dl_Owner.Owner_Reader(par);
                
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on PreviousCurrentExists.", ex, "frmTFRType");
                frmobj.ShowDialog();
            }
            if (dst.Tables[0].Rows.Count > 0)
            {
                fileno = dst.Tables[0].Rows[0]["FileNo"].ToString();
                FileNo = fileno;
                return false;
            }
            else
            {
                FileNo = "";
                return true;
            }

        }
        //------------(1)---------End---------------------------------------------------------------------
        //--(3)--------------Add Data To Grid-------------------------------------------------------------------
        private void AddMembertoGrid()
        {
            DataSet ds = new DataSet();
            try
            {

                SqlParameter[] parameters = {
                                    new SqlParameter("@Task","SelectMS_BuyerInfo"),
                                    new SqlParameter("@MembershipNo", txtpurchaseMSNO.Text)
                                  };
                ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameters);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridViewDataRowInfo row = new GridViewDataRowInfo(grdBuyerInfo.MasterView);
                    row.Cells[0].Value = ds.Tables[0].Rows[0]["ID"].ToString();
                    row.Cells[1].Value = ds.Tables[0].Rows[0]["MembershipNo"].ToString();
                    row.Cells[2].Value = ds.Tables[0].Rows[0]["Name"].ToString();
                    row.Cells[3].Value = ds.Tables[0].Rows[0]["Father"].ToString();
                    row.Cells[4].Value = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                    row.Cells[5].Value = ds.Tables[0].Rows[0]["NICNICOP"].ToString();
                    row.Cells[6].Value = DateTime.Now;
                    grdBuyerInfo.Rows.Add(row);
                    //----Make BuyerMSNOString
                    BuyerMSNOString = BuyerMSNOString + ds.Tables[0].Rows[0]["MembershipNo"].ToString() + ",";
                }
                else
                {
                    MessageBox.Show("This Membership Can't Exist.");
                }

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on AddMembertoGrid.", ex, "frmTFRType");
                frmobj.ShowDialog();
            }
        }
        //--(3)--------------------End--------------------------------------------------------------------------
        //---(4)-----Check that this MembershipNo is already insert into Grid or not----------------------------
        #region Extra Function
        private bool String_Comparsion(string Firststr, string SecondStr)
        {
            if (Firststr.ToUpper() == SecondStr.ToUpper())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        //---(4)-----End----------------------------------------------------------------------------------------
        private void txtpurchaseMSNO_Leave(object sender, EventArgs e)
        {
            try
            {
                #region Bind Type Of Purchase
                //SqlParameter[] parmt =
                //{
                // new SqlParameter("@Task","Bind_TypeOfPurchaseData")
                //};
                //DataSet dds = new DataSet();
                //dds = cls_dl_Owner.Owner_Reader(parmt);
                //raddpTFRType.DataSource = dds.Tables[0].DefaultView;
                //raddpTFRType.DisplayMember = "Name";
                //raddpTFRType.ValueMember = "TypeID";

                #endregion Bind Membership Data

                string fileno = "";
                if (PreviousCurrentExists(out fileno))
                {
                    //-----(2)-------Insert Exact Number of TypePurchase Data--------------------------------------
                    int atTimeBuyerAllowed = int.Parse(ds_set.Tables[0].Rows[0]["AtTimeBuyerAllowed"].ToString());
                    if (grdBuyerInfo.Rows.Count == 0)
                    {

                        AddMembertoGrid();
                    }
                    else if (atTimeBuyerAllowed == 1 && grdBuyerInfo.Rows.Count == 1)
                    {
                        MessageBox.Show("No More Entry Allowed to Add");
                    }
                    else if (atTimeBuyerAllowed > 1)
                    {
                        int row = grdBuyerInfo.Rows.Count;
                        if (row != 0)
                        {
                            for (int i = 0; i < row; i++)
                            {
                                membershipNo = grdBuyerInfo.Rows[i].Cells[1].Value.ToString();
                                CurrentDate = grdBuyerInfo.Rows[i].Cells[6].Value.ToString();
                                //RateOfSale = grdBuyerInfo.Rows[i].Cells[7].Value.ToString();
                            }
                            if (membershipNo.ToUpper() != txtpurchaseMSNO.Text.ToUpper())
                            {
                                AddMembertoGrid();
                            }
                            else
                            {
                                MessageBox.Show("This MembershipNo is already Inserted in List, Please try another.");
                            }
                        }
                        //------(2)------------End-----------------------------------------------------------------------   
                    }
                    else
                    {
                        MessageBox.Show("This MemberShip NO is already is used against FileNO =" + fileno);
                    }

                }
                else
                {
                    MessageBox.Show("This MemberShip NO is already is used against FileNO =" + fileno);
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on txtpurchaseMSNO_Leave.", ex, "frmTFRType");
                frmobj.ShowDialog();
            }
       
        }
    }
}
