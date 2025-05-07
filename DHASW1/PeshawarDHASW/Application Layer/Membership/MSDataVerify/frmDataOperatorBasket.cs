using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsMemberShip;

using Telerik.WinControls;
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Application_Layer.Membership.MSDataVerify
{
    public partial class frmDataOperatorBasket : Telerik.WinControls.UI.RadForm
    {
        public frmDataOperatorBasket()
        {
            InitializeComponent();
        }



        private void dataloadingNotverify()
        {
            try
            {
                SqlParameter[] parameters =
                           {
                new SqlParameter("@Task", "DatabasketAllEntry"),
            };
                DataSet ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameters);
                radAllentry.DataSource = ds.Tables[0].DefaultView;
                int raddatabasketnotverify = radAllentry.RowCount;
                lblallcount.Text = raddatabasketnotverify.ToString();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on dataloadingNotverify.", ex, "frmDataOperatorBasket");
                frmobj.ShowDialog();
            }
           
        }

        private void Incomplete()
        {
            try
            {
                SqlParameter[] parameters =
                            {
                new SqlParameter("@Task", "Incomplete"),
            };
                DataSet ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameters);
                gdincomplete.DataSource = ds.Tables[0].DefaultView;
                int raddatabasketnotverify = gdincomplete.RowCount;
                lblincomplete.Text = raddatabasketnotverify.ToString();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Incomplete.", ex, "frmDataOperatorBasket");
                frmobj.ShowDialog();
            }
            
        }
        private void dataloadingAll()
        {
            try
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@Task", "DailyEntry"),
                };
                DataSet ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameters);
                raddailyentry.DataSource = ds.Tables[0].DefaultView;
                int raddgalldatacount = raddailyentry.RowCount;
                lbldialy.Text = raddgalldatacount.ToString();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on dataloadingAll.", ex, "frmDataOperatorBasket");
                frmobj.ShowDialog();
            }
        }
        private void dataloadingImageReady()
        {
            try
            {
                SqlParameter[] parameters =
           {
                new SqlParameter("@Task", "ReadyforImage"),
            };
                DataSet ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameters);
                imageready.DataSource = ds.Tables[0].DefaultView;
                int raddgalldatacount = imageready.RowCount;
                lblimageupload.Text = raddgalldatacount.ToString();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on dataloadingImageReady.", ex, "frmDataOperatorBasket");
                frmobj.ShowDialog();
            }
           
        }

        private void dataloadingReadyofrVerification()
        {
            try
            {
                SqlParameter[] parameters =
                           {
                new SqlParameter("@Task", "ReadyforVerification"),
            };
                DataSet ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameters);
                verifyready.DataSource = ds.Tables[0].DefaultView;
                int raddgalldatacount = verifyready.RowCount;
                lblverify.Text = raddgalldatacount.ToString();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on dataloadingReadyofrVerification.", ex, "frmDataOperatorBasket");
                frmobj.ShowDialog();
            }
           
        }
        private void frmDataOperatorBasket_Load(object sender, EventArgs e)
        {
            try
            {
                imageready.MasterTemplate.Columns.Add(clsPluginHelper.GdButton("MemberID", "MemberID", "Upload", "Click"));
                dataloadingNotverify();
                Incomplete();
                dataloadingAll();
                dataloadingImageReady();
                dataloadingReadyofrVerification();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmDataOperatorBasket_Load.", ex, "frmDataOperatorBasket");
                frmobj.ShowDialog();
            }
          
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataloadingNotverify();
            Incomplete();
            dataloadingAll();
            dataloadingImageReady();
            dataloadingReadyofrVerification();
        }

        private void imageready_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = imageready.CurrentCell.RowIndex;
                int columnindex = imageready.CurrentCell.ColumnIndex;
                if (e.Column.Name == "MemberID")
                {
                    string ID = imageready.Rows[rowindex].Cells[1].Value.ToString();
                    frmAddImagesTo_Membership obj = new frmAddImagesTo_Membership(ID);
                    obj.ShowDialog();
                    // MessageBox.Show("BioInfo - > " + SearchDGV.Rows[rowindex].Cells[0].Value.ToString());
                }

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on imageready_CellClick.", ex, "frmDataOperatorBasket");
                frmobj.ShowDialog();
            }
        }
    }
}
