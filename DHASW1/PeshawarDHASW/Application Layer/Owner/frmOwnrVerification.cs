using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.Owner;
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
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Owner
{
    public partial class frmOwnrVerification : Telerik.WinControls.UI.RadForm
    {
        public frmOwnrVerification()
        {
            InitializeComponent();
        }

        private void frmOwnrVerification_Load(object sender, EventArgs e)
        {
            BindAllOwnerData();
            DGVControls();
        }
        private void BindAllOwnerData()
        {
            try
            {
                SqlParameter[] param =
                           {
                new SqlParameter("@Task","Select"),
                new SqlParameter("@EntryStatus","Pending")
            };
                DataSet ds = new DataSet();
                ds = cls_dl_Owner.Owner_Reader(param);
                grdOwnerdata.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on BindAllOwnerData.", ex, "frmOwnerVerification");
                frmobj.ShowDialog();
            }
           
        }
        private void DGVControls()
        {
            try
            {
                GridViewCommandColumn OwnerVerify = new GridViewCommandColumn();
                OwnerVerify.Name = "OnrVrfy";
                OwnerVerify.UseDefaultText = true;
                OwnerVerify.FieldName = "OnrVrfy";
                OwnerVerify.DefaultText = "Verified";
                OwnerVerify.Width = 80;
                OwnerVerify.TextAlignment = ContentAlignment.MiddleCenter;
                OwnerVerify.HeaderText = "Verify";
                grdOwnerdata.MasterTemplate.Columns.Add(OwnerVerify);

                GridViewCommandColumn OwnerRevert = new GridViewCommandColumn();
                OwnerRevert.Name = "OnrRvrt";
                OwnerRevert.UseDefaultText = true;
                OwnerRevert.FieldName = "OnrRvrt";
                OwnerRevert.DefaultText = "Revert";
                OwnerRevert.Width = 80;
                OwnerRevert.TextAlignment = ContentAlignment.MiddleCenter;
                OwnerRevert.HeaderText = "Revert";
                grdOwnerdata.MasterTemplate.Columns.Add(OwnerRevert);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on DGVControls.", ex, "frmOwnerVerification");
                frmobj.ShowDialog();
            }
      
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] param =
                    {
                new SqlParameter("@Task","Select"),
                new SqlParameter("@EntryStatus","Pending"),
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
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnSearch_Click.", ex, "frmOwnerVerification");
                frmobj.ShowDialog();
            }
     
        }

        private void grdOwnerdata_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = grdOwnerdata.CurrentCell.RowIndex;
                int columnindex = grdOwnerdata.CurrentCell.ColumnIndex;
                if (e.Column.Name == "OnrVrfy")
                {
                    int OwnerID = int.Parse(grdOwnerdata.Rows[rowindex].Cells[0].Value.ToString());
                    int Fileid = int.Parse(grdOwnerdata.Rows[rowindex].Cells[2].Value.ToString());
                    int MemberId = int.Parse(grdOwnerdata.Rows[rowindex].Cells[5].Value.ToString());
                    string Status = grdOwnerdata.Rows[rowindex].Cells[6].Value.ToString();
                    int TypePurchaseID = int.Parse(grdOwnerdata.Rows[rowindex].Cells[8].Value.ToString());
                    string RateOfSale = grdOwnerdata.Rows[rowindex].Cells[9].Value.ToString();
                    string DateOfPurchase = grdOwnerdata.Rows[rowindex].Cells[10].Value.ToString();
                    string DateOfSale = grdOwnerdata.Rows[rowindex].Cells[11].Value.ToString();
                    SqlParameter[] paramtr =
                    {
                  new SqlParameter("@Task","Update"),
                  new SqlParameter("@OwnerID",OwnerID),
                  new SqlParameter("@FileMapID",Fileid),
                  new SqlParameter("@MemberID",MemberId),
                  new SqlParameter("@Status",Status),
                  new SqlParameter("@TypePurchaseID",TypePurchaseID),
                  new SqlParameter("@userID",Models.clsUser.ID),
                  new SqlParameter("@RateofSale",RateOfSale),
                  new SqlParameter("@DateofPurchase",DateOfPurchase),
                  new SqlParameter("@DateofSell",DateOfSale),
                  new SqlParameter("@EntryStatus","Verified")
                };
                    int result = 0;
                    result = cls_dl_Owner.Owner_NonQuery(paramtr);
                    if (result > 0)
                    {
                        MessageBox.Show("Owner is Verified Successfully.");
                        BindAllOwnerData();
                    }
                    else
                    {
                        MessageBox.Show("Contact With Administration");
                    }

                }
                else if (e.Column.Name == "OnrRvrt")
                {
                    int OwnerID = int.Parse(grdOwnerdata.Rows[rowindex].Cells[0].Value.ToString());
                    int Fileid = int.Parse(grdOwnerdata.Rows[rowindex].Cells[2].Value.ToString());
                    int MemberId = int.Parse(grdOwnerdata.Rows[rowindex].Cells[5].Value.ToString());
                    string Status = grdOwnerdata.Rows[rowindex].Cells[6].Value.ToString();
                    int TypePurchaseID = int.Parse(grdOwnerdata.Rows[rowindex].Cells[8].Value.ToString());
                    string RateOfSale = grdOwnerdata.Rows[rowindex].Cells[9].Value.ToString();
                    string DateOfPurchase = grdOwnerdata.Rows[rowindex].Cells[10].Value.ToString();
                    string DateOfSale = grdOwnerdata.Rows[rowindex].Cells[11].Value.ToString();
                    SqlParameter[] paramtr =
                    {
                  new SqlParameter("@Task","Update"),
                  new SqlParameter("@OwnerID",OwnerID),
                  new SqlParameter("@FileMapID",Fileid),
                  new SqlParameter("@MemberID",MemberId),
                  new SqlParameter("@Status",Status),
                  new SqlParameter("@TypePurchaseID",TypePurchaseID),
                  new SqlParameter("@userID",Models.clsUser.ID),
                  new SqlParameter("@RateofSale",RateOfSale),
                  new SqlParameter("@DateofPurchase",DateOfPurchase),
                  new SqlParameter("@DateofSell",DateOfSale),
                  new SqlParameter("@EntryStatus","New")
                };
                    int result = 0;
                    result = cls_dl_Owner.Owner_NonQuery(paramtr);
                    if (result > 0)
                    {
                        MessageBox.Show("Owner is Revert Successfully.");
                        BindAllOwnerData();
                    }
                    else
                    {
                        MessageBox.Show("Contact With Administration");
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on grdOwnerdata_CellClick.", ex, "frmOwnerVerification");
                frmobj.ShowDialog();
            }
           

        }
           
    }
}
