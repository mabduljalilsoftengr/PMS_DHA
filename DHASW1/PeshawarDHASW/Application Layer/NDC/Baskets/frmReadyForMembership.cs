using PeshawarDHASW.Application_Layer.Membership;
using PeshawarDHASW.Data_Layer.clsMemberShip;
using PeshawarDHASW.Data_Layer.NDC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Models;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Application_Layer.Membership.Modify;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    public partial class frmReadyForMembership : Telerik.WinControls.UI.RadForm
    {
        public frmReadyForMembership()
        {
            InitializeComponent();
        }

        private void frmBasketMembership_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            LoadDataForBasket();
        }
        private void LoadDataForBasket()
        {
            try
            {
                DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.Text,
                               "Select * from tbl_Basket_Queries Where Status Like 'ON'");
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (row["Task_Name"].ToString() == "ReadyFormembership_TFRImageUploaded")
                    {
                        FillDataGrid(grdReady_For_Membership, row["Query"].ToString());
                    }
                    if (row["Task_Name"].ToString() == "NDCInfo")
                    {
                        FillDataGrid(grdNDC_FileNo, row["Query"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LoadDataForBasket.", ex, "frmReadyForMembership");
                frmobj.ShowDialog();
            }
           
        }
        private void FillDataGrid(RadGridView grd, string qury)
        {
            grd.DataSource = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.Text, qury).Tables[0].DefaultView;
        }

        private void grdReady_For_Membership_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = grdReady_For_Membership.CurrentCell.RowIndex;
                string fileno = grdReady_For_Membership.Rows[rowindex].Cells[1].Value.ToString();
                int ndcno = int.Parse(grdReady_For_Membership.Rows[rowindex].Cells[0].Value.ToString());

                if (e.Column.Name == "Rady_Membr_Forward")
                {
                    //#region Check the total Buyers of tbl_NDC and tbl_Membership
                    //SqlParameter[] prmt =
                    //{
                    //new SqlParameter("@Task","Check_Buyers_of_tbl_NDC_tbl_Membership"),
                    //new SqlParameter("@NDCNo",ndcno)
                    //};
                    //DataSet dst = new DataSet();
                    //dst = cls_dl_Membership.Membership_All_Retrive(prmt);
                    //if (dst.Tables.Count > 0)
                    //{
                    //    int totalbuyer = 0;
                    //    int totalMS = 0;
                    //    bool t1b = int.TryParse(dst.Tables[0].Rows[0]["TotalBuyer"].ToString(), out totalbuyer);//Buyer Of NDC
                    //    bool tb = int.TryParse(dst.Tables[0].Rows[1]["TotalBuyer"].ToString(), out totalMS);//ExistMS in tbl_Membership Table
                    //    if (totalMS == totalbuyer)
                    //    {
                    //        MessageBox.Show("Total New Memberships must not be Exceeds the Total Buyers that involve in NDC Creation.");
                    //    }
                    //    else if (totalMS < totalbuyer)
                    //    {
                            frm_AddMembership_Against_NDC obj = new frm_AddMembership_Against_NDC(ndcno, fileno);
                            obj.ShowDialog();
                            LoadDataForBasket();
                    //    }
                    //}
                    //#endregion
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on grdReady_For_Membership_CellClick.", ex, "frmReadyForMembership");
                frmobj.ShowDialog();
            }
           

        }

        private void grdNDC_FileNo_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = grdNDC_FileNo.CurrentCell.RowIndex;
                int ndcno = int.Parse(grdNDC_FileNo.Rows[rowindex].Cells[0].Value.ToString());
                string fileno = grdNDC_FileNo.Rows[rowindex].Cells[1].Value.ToString();
                if (e.Column.Name == "Next_To_TFRAppointment")
                {
                    #region Check total Memberships against NDCNo 
                    SqlParameter[] prm =
                   {
                new SqlParameter("@Task","CountMembership_AgainstNDCNo"),
                new SqlParameter("@NDCNo",ndcno)
                };
                    DataSet dst = cls_dl_Membership.Membership_PersonalInfo_Retrive(prm);
                    if (int.Parse(dst.Tables[0].Rows[0]["TotalMembership"].ToString()) > 0)
                    {
                        if (MessageBox.Show("Are You Sure you want to Move Next!", "Attention!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            SqlParameter[] prmt =
                            {
                            new SqlParameter("@Task","Update_NDC_Status"),
                            new SqlParameter("@NDCNo",ndcno),
                            new SqlParameter("@StatusofNDC","ReadyForTFRAppointment")
                            };
                            int rslt = 0;
                            rslt = cls_dl_NDC.NdcNonQuery(prmt);
                            if (rslt > 0)
                            {
                                MessageBox.Show("Move Next Successfully.");
                                LoadDataForBasket();
                            }
                        }
                    }
                    #endregion


                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on grdNDC_FileNo_CellClick.", ex, "frmReadyForMembership");
                frmobj.ShowDialog();
            }
           
           
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataForBasket();
        }
    }
}
