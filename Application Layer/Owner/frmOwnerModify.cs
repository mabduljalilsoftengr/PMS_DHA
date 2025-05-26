using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Application_Layer.FileMap;
using PeshawarDHASW.Application_Layer.Membership;
using PeshawarDHASW.Application_Layer.TypeofPurchase;
using PeshawarDHASW.Data_Layer;
using PeshawarDHASW.Data_Layer.clsFileMap;
using PeshawarDHASW.Data_Layer.clsMemberShip;
using PeshawarDHASW.Data_Layer.Owner;
using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Owner
{
    public partial class frmOwnerModify : Telerik.WinControls.UI.RadForm
    {
        public frmOwnerModify()
        {
            InitializeComponent();
        }
        public string FileNO { get; set; }
        public int FileID { get; set; }
        public int MemberID { get; set; }
        public int OwnerID { get; set; }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchOwnerData();
        }
        private void SearchOwnerData()
        {
            try
            {
                SqlParameter[] param =
                          {
                new SqlParameter("@Task","Select"),
                new SqlParameter("@EntryStatus","New"),
                new SqlParameter("@Fileno",clsPluginHelper.DbNullIfNullOrEmpty(txtFileNo.Text)),
                new SqlParameter("@MSNO",clsPluginHelper.DbNullIfNullOrEmpty(txtMSNo.Text)),
               // new SqlParameter("@RateofSale",clsPluginHelper.DbNullIfNullOrEmpty(txtRateOfSale.Text))
            };
                DataSet ds = new DataSet();
                ds = cls_dl_Owner.Owner_Reader(param);
                grdOwnerdata.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on SearchOwnerData.", ex, "frmOwnerModify");
                frmobj.ShowDialog();
            }
          
        }
        private void frmOwnerModify_Load(object sender, EventArgs e)
        {
            BindAllOwnerData();
        }
        private void BindTypeOfPurchaseData()
        {
            try
            {
                RadListDataItem Select = new RadListDataItem();
                Select.Value = 0;
                Select.Text = "-- Select Type of Purchase --";
                this.ddlTypeOfPurchase.Items.Add(Select);
                SqlParameter[] param =
                {
             new SqlParameter("@Task","Select")
            };
                DataSet ds = new DataSet();
                ds = cls_dl_TypeofPurchase.TypeofPurchase_Reader(param);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    RadListDataItem dataItem = new RadListDataItem();
                    dataItem.Value = row["TypeID"].ToString();
                    dataItem.Text = row["Name"].ToString();
                    this.ddlTypeOfPurchase.Items.Add(dataItem);
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on BindTypeOfPurchaseData.", ex, "frmOwnerModify");
                frmobj.ShowDialog();
            }
          
        }
        private void DGVControls()
        {
            try
            {
                GridViewCommandColumn OwnerModify = new GridViewCommandColumn();
                OwnerModify.Name = "Onrdt";
                OwnerModify.UseDefaultText = true;
                OwnerModify.FieldName = "Onrdt";
                OwnerModify.DefaultText = "Modify";
                OwnerModify.Width = 80;
                OwnerModify.TextAlignment = ContentAlignment.MiddleCenter;
                OwnerModify.HeaderText = "Owner";
                grdOwnerdata.MasterTemplate.Columns.Add(OwnerModify);

                GridViewCommandColumn FileModify = new GridViewCommandColumn();
                FileModify.Name = "Filedt";
                FileModify.UseDefaultText = true;
                FileModify.FieldName = "Filedt";
                FileModify.DefaultText = "Modify";
                FileModify.Width = 80;
                FileModify.TextAlignment = ContentAlignment.MiddleCenter;
                FileModify.HeaderText = "File";
                grdOwnerdata.MasterTemplate.Columns.Add(FileModify);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on DGVControls.", ex, "frmOwnerModify");
                frmobj.ShowDialog();
            }
           
        }
        private void BindAllOwnerData()
        {
            try
            {
                SqlParameter[] param =
                      {
                new SqlParameter("@Task","Select"),
                new SqlParameter("@EntryStatus","New")
            };
                DataSet ds = new DataSet();
                ds = cls_dl_Owner.Owner_Reader(param);
                grdOwnerdata.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on BindAllOwnerData.", ex, "frmOwnerModify");
                frmobj.ShowDialog();
            }
      
        }

        private void grdOwnerdata_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                BindTypeOfPurchaseData();
                int rowindex = grdOwnerdata.CurrentCell.RowIndex;
                int columnindex = grdOwnerdata.CurrentCell.ColumnIndex;
                //this.Hide();
                OwnerID = int.Parse(grdOwnerdata.Rows[rowindex].Cells[0].Value.ToString());
                SqlParameter[] param =
                {
                    new SqlParameter("@Task","Select"),
                    new SqlParameter("@OwnerID",OwnerID)
                };
                DataSet ds = new DataSet();
                ds = cls_dl_Owner.Owner_Reader(param);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    txtFile_No.Text = row["FileNo"].ToString();
                    txtMS.Text = row["MembershipNo"].ToString();
                    //   ddlTypeOfPurchase.Text = row["TPName"].ToString();
                    clsPluginHelper.RadDropDownSelectByText(ddlTypeOfPurchase, row["TPName"].ToString());
                    // ddlstatus.Text = row["Status"].ToString();
                    clsPluginHelper.RadDropDownSelectByText(ddlstatus, row["Status"].ToString());
                    txt_RateOfSale.Text = row["RateofSale"].ToString();
                    string dattim = row["DateofPurchase"].ToString();
                    clsPluginHelper.DateTimePickerBinding(dtpPurchaseDate, dattim);
                    //dtpPurchaseDate.DateTimePickerElement.Value = DateTime.ParseExact(dattim,"dd/MM/yyyy",null);
                    txtDateOfSale.Text = row["DateofSell"].ToString();

                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on grdOwnerdata_CellClick.", ex, "frmOwnerModify");
                frmobj.ShowDialog();
            }
           
            
        }
        private void Clear()
        {
            txtFile_No.Text = "";
            txtMS.Text = "";
            ddlTypeOfPurchase.Text = "";
            ddlstatus.Text = "";
            txt_RateOfSale.Text = "";
            dtpPurchaseDate.Text = "";
            txtDateOfSale.Text = "";
        }
        private void btnFileView_Click(object sender, EventArgs e)
        {
            frmSearchFileRPlot obj = new frmSearchFileRPlot();
            obj.ShowDialog();
        }

        private void btnMSView_Click(object sender, EventArgs e)
        {
            frmMembershipSearch obj = new frmMembershipSearch();
            obj.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                #region FileID
                SqlParameter[] pa =
                {
                new SqlParameter("@Task","select"),
                new SqlParameter("@FileNo",txtFile_No.Text)
            };
                DataSet ds = new DataSet();
                ds = cls_dl_FileMap.FileMap_Reader(pa);
                FileID = int.Parse(ds.Tables[0].Rows[0]["FileMapKey"].ToString());
                #endregion
                #region MemberID
                SqlParameter[] par =
               {
                new SqlParameter("@Task","Select"),
                new SqlParameter("@MembershipNo",txtMS.Text)
            };
                DataSet dst = new DataSet();
                dst = cls_dl_Membership.Membership_PersonalInfo_Retrive(par);
                MemberID = int.Parse(dst.Tables[0].Rows[0]["ID"].ToString());
                #endregion

                string status = ddlstatus.SelectedItem.ToString();
                int typepurchase = int.Parse(ddlTypeOfPurchase.SelectedValue.ToString());
                SqlParameter[] para =
                {
                new SqlParameter("@Task","Update"),
                new SqlParameter("@OwnerID",OwnerID),
                new SqlParameter("@FileMapID",FileID),
                new SqlParameter("@MemberID",MemberID),
                new SqlParameter("@Status",status),
                new SqlParameter("@TypePurchaseID",typepurchase),
                new SqlParameter("@userID",Models.clsUser.ID),
                new SqlParameter("@RateofSale",txt_RateOfSale.Text),
                new SqlParameter("@DateofPurchase",dtpPurchaseDate.Text),
                new SqlParameter("@DateofSell",txtDateOfSale.Text),
                new SqlParameter("@EntryStatus","Pending")
            };
                int result = 0;
                result = cls_dl_Owner.Owner_NonQuery(para);
                if (result > 0)
                {
                    MessageBox.Show("Owner Updated Successfully.");
                    Clear();
                }
                else
                {
                    MessageBox.Show("Contact With Administration.");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnUpdate_Click.", ex, "frmOwnerModify");
                frmobj.ShowDialog();
            }

        }

        private void txtFile_No_Leave(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] param =
                           {
                new SqlParameter("@Task","FileNO_MemebershipNO_Search"),
                new SqlParameter("@Fileno",clsPluginHelper.DbNullIfNullOrEmpty(txtFile_No.Text))
            };
                DataSet ds = new DataSet();
                ds = cls_dl_Owner.Owner_Reader(param);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("This File NO is Already in use, Please try another FileNO .");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on txtFile_No_Leave.", ex, "frmOwnerModify");
                frmobj.ShowDialog();
            }
        }

        private void txtMS_Leave(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] param =
                          {
                new SqlParameter("@Task","FileNO_MemebershipNO_Search"),
                new SqlParameter("@MSNO",clsPluginHelper.DbNullIfNullOrEmpty(txtMS.Text))
            };
                DataSet ds = new DataSet();
                ds = cls_dl_Owner.Owner_Reader(param);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("This MembershipNO is Already in use, Please try another MembershipNO.");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on txtMS_Leave.", ex, "frmOwnerModify");
                frmobj.ShowDialog();
            }
        }
    }
}
