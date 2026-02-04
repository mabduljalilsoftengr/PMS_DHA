using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Application_Layer.Transfer.TFRSetting;
using PeshawarDHASW.Data_Layer;
using PeshawarDHASW.Data_Layer.clsFileMap;
using PeshawarDHASW.Data_Layer.Installment;
using PeshawarDHASW.Data_Layer.Owner;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Transfer.TFRType.TFRSetting
{
    public partial class frmFileMembershipBinding : Telerik.WinControls.UI.RadForm
    {
        public frmFileMembershipBinding()
        {
            InitializeComponent();
        }
        private int FileMapID { get; set; }
        public frmFileMembershipBinding(string FileNo)
        {
            InitializeComponent();
            txtFileNo.Text = FileNo;
            txtFileNo_Leave(null, null);
        }
     
        private void txtFileNo_Leave(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] prmtr =
                {
                new SqlParameter("@Task","select_Data_For_Binding"),
                new SqlParameter("@FileNo",txtFileNo.Text)
                };
                DataSet dst = new DataSet();
                dst = cls_dl_FileMap.FileMap_Reader(prmtr);
                FileMapID = int.Parse(dst.Tables[0].Rows[0]["FileMapKey"].ToString());
                lblextrabalance.Text = dst.Tables[0].Rows[0]["ExtraMBalance"].ToString();
                lblrecordno.Text = dst.Tables[0].Rows[0]["RecordNo"].ToString();
                lblremarks.Text = dst.Tables[0].Rows[0]["Remarks"].ToString();
                lblsatatus.Text = dst.Tables[0].Rows[0]["Status"].ToString();
                //FileKey =int.Parse(dst.Tables[0].Rows[0]["FileKey"].ToString());
                // grdFile_MultiOwner.DataSource = dst.Tables[0].DefaultView;

                grd_Membershipdata.DataSource =  dst.Tables[1].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on txtFileNo_Leave.", ex, "frmTransferBasket");
                frmobj.ShowDialog();
            }
        }

        private void frmFileMembershipBinding_Load(object sender, EventArgs e)
        {
            LoadPurchaseTypeData();
        }
        private void LoadPurchaseTypeData()
        {

            RadListDataItem Select = new RadListDataItem();
            Select.Value = 0;
            Select.Text = "-- Select Purchase Type --";
            this.drp_PurchaseType.Items.Add(Select);
            SqlParameter[] param =
            {
                    new SqlParameter("@Task", "Select")
            };
           
            foreach (DataRow row in cls_dl_TypeofPurchase.TypeofPurchase_Reader(param).Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["TypeID"].ToString();
                dataItem.Text = row["Name"].ToString();
                this.drp_PurchaseType.Items.Add(dataItem);
            }
            drp_PurchaseType.SelectedIndex = 0;

        }

        private void btnFileMembershipBinding_Click(object sender, EventArgs e)
        {
            if(drp_PurchaseType.SelectedIndex > 0 || grd_Membershipdata.RowCount > 0)
            {
                Update_File_PurchaseTypeID();
                InserDataInOwnerTable();
                Clear();
                this.Close();
            }
            else {
                MessageBox.Show("There is no Data of Membership OR You can't Select the Purchase Type .");
            }
          
        }
        private void InserDataInOwnerTable()
        {
            int row = grd_Membershipdata.Rows.Count;
            for (int i = 0; i < row; i++)
            {
                SqlParameter[] prm =
                {
                    new SqlParameter("@Task","Insert"),
                    new SqlParameter("@FileMapID",FileMapID),
                    new SqlParameter("@MemberID",int.Parse(grd_Membershipdata.Rows[i].Cells[0].Value.ToString())),
                    new SqlParameter("@Status","Current"),
                    new SqlParameter("@TypePurchaseID",drp_PurchaseType.SelectedValue),
                    new SqlParameter("@userID",Models.clsUser.ID),
                    new SqlParameter("@RateofSale","0"),
                    new SqlParameter("@DateofPurchase","01/01/1900"),
                    new SqlParameter("@DateofSell","01/01/1900"),
                    new SqlParameter("@EntryStatus","New")
                //grd_Membershipdata.Rows[i].Cells[0].Value.ToString();
                //grd_Membershipdata.Rows[i].Cells[1].Value.ToString();
                //grd_Membershipdata.Rows[i].Cells[2].Value.ToString();
                //grd_Membershipdata.Rows[i].Cells[3].Value.ToString();
                };
                int rslt = cls_dl_Owner.Owner_NonQuery(prm);
               
            }

        }
        private void Clear()
        {
            txtFileNo.Text = "";
            grd_Membershipdata.DataSource = null;
        }
        private void Update_File_PurchaseTypeID()
        {
            SqlParameter[] prmtr =
               {
                new SqlParameter("@Task","Update_File_PurchaseTypeID"),
                new SqlParameter("@FileMapKey",FileMapID),
                new SqlParameter("@TFRTypeID",drp_PurchaseType.SelectedValue)
                };
            int rslt = cls_dl_FileMap.FileMap_NonQuery(prmtr);
        }

        private void btnNextToTransfer_Click(object sender, EventArgs e)
        {
            frmTransferBasket frmobj = new frmTransferBasket();
            frmobj.ShowDialog(); 
        }

        private void radButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
