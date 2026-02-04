using PeshawarDHASW.Data_Layer.Installment;
using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsChallanRece;
using PeshawarDHASW.Models;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.Installment.InstReceive
{
    public partial class frmDDChallanImagesUpload : Telerik.WinControls.UI.RadForm
    {
        public frmDDChallanImagesUpload()
        {
            InitializeComponent();
        }

        private void Searching()
        {
            try
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@Task", "search"),
                new SqlParameter("@FileNo", clsPluginHelper.DbNullIfNullOrEmpty(txtfileno.Text)),
                new SqlParameter("@PlotNo", clsPluginHelper.DbNullIfNullOrEmpty(txtplotno.Text)),
                new SqlParameter("@Date", clsPluginHelper.DbNullIfNullOrEmpty(txtdate.Text)),
                new SqlParameter("@MSNo", clsPluginHelper.DbNullIfNullOrEmpty(txtmsno.Text)),
                new SqlParameter("@NIC", clsPluginHelper.DbNullIfNullOrEmpty(txtnic.Text)),
                new SqlParameter("@Amount", clsPluginHelper.DbNullIfNullOrEmpty(txtamount.Text)),
                new SqlParameter("@Status", clsPluginHelper.DbNullIfNullOrEmpty(txtstatus.Text)),
                new SqlParameter("@DDStatus", clsPluginHelper.DbNullIfNullOrEmpty(txtDDstatus.Text)),
                new SqlParameter("@DDNo", clsPluginHelper.DbNullIfNullOrEmpty(txtDDno.Text)),
                new SqlParameter("@BankName", clsPluginHelper.DbNullIfNullOrEmpty(txtbankname.Text)),
                new SqlParameter("@Branch", clsPluginHelper.DbNullIfNullOrEmpty(txtbranch.Text)),
                new SqlParameter("@Remarks", clsPluginHelper.DbNullIfNullOrEmpty(txtremarks.Text))
               };
                DataSet ds = cls_dl_InstRece.Inst_Rece_Read(parameters);
                //foreach (DataRow Row in ds.Tables[0].Rows)
                //{
                //    string[] ddchallan = new string[] { Row["FileNo"].ToString(), Row["Name"].ToString(), Row["RecordNo"].ToString(), Row["Date"].ToString(), Row["Amount"].ToString(), Row["DDNo"].ToString(), Row["BankName"].ToString(), Row["Branch"].ToString(), Row["Status"].ToString(), Row["Remarks"].ToString(), Row["DDStatus"].ToString(), Row["Transferree"].ToString(), Row["Rece_ID"].ToString(), Row["FileMapKey"].ToString(), Row["DDImageID"].ToString(), Row["ID"].ToString() };
                radgdInstReceive.DataSource = ds.Tables[0].DefaultView;
                //    radgdInstReceive.Rows.Add(ddchallan);
                //}
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Searching.", ex, "frmDDChallanImageUpload");
                frmobj.ShowDialog();

            }

        }
        private void btnsearch_Click(object sender, EventArgs e)
        {
            Searching();
        }
        private void frmDDChallanImagesUpload_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            BindAllDataWithGrid();
            DD_DGVControls();
            Challan_DGVControls();
            BindAllDataWithGrid_OtherRece();
        }
        private void BindAllDataWithGrid()
        {
            try
            {

            SqlParameter[] parameters =
                       {
                new SqlParameter("@Task", "BindAllData")
               
            };
            DataSet ds = cls_dl_InstRece.Inst_Rece_Read(parameters);
            radgdInstReceive.DataSource = ds.Tables[0].DefaultView;
            //grdChallanImages.DataSource = ds.Tables[0].DefaultView;

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on BindAllDataWithGrid.", ex, "frmDDChallanImageUpload");
                frmobj.ShowDialog();
            }
        }

        private void BindAllDataWithGrid_OtherRece()
        {
            try
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@Task", "Select")

                };
                DataSet ds = cls_dl_ChallanRece.ChallanRece_Reader(parameters);
                grdChallanImages.DataSource = ds.Tables[0].DefaultView;
               
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on BindAllDataWithGrid_OtherRece.", ex, "frmDDChallanImageUpload");
                frmobj.ShowDialog();
            }
        }
        private void DD_DGVControls()
        {
            try
            {
                GridViewCommandColumn ddfront = new GridViewCommandColumn();
                ddfront.Name = "DDFront";
                ddfront.UseDefaultText = true;
                ddfront.FieldName = "DDFront";
                ddfront.DefaultText = "Upload";
                ddfront.Width = 160;
                ddfront.TextAlignment = ContentAlignment.MiddleCenter;
                ddfront.HeaderText = "DD Front";
                radgdInstReceive.MasterTemplate.Columns.Add(ddfront);

                GridViewCommandColumn NextofKin = new GridViewCommandColumn();
                NextofKin.Name = "DDBack";
                NextofKin.UseDefaultText = true;
                NextofKin.FieldName = "DDBack";
                NextofKin.DefaultText = "Upload";
                NextofKin.Width = 160;
                NextofKin.TextAlignment = ContentAlignment.MiddleCenter;
                NextofKin.HeaderText = "DD Back";
                radgdInstReceive.MasterTemplate.Columns.Add(NextofKin);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on DD_DGVControls.", ex, "frmDDChallanImageUpload");
                frmobj.ShowDialog();
            }
           
            
        }
        private void Challan_DGVControls()
        {
            #region Column
            //    SearchDGV.ColumnCount = 7;
            //    SearchDGV.Columns[0].Name = "ID";
            //    SearchDGV.Columns[0].HeaderText = "ID";
            //    SearchDGV.Columns[0].IsVisible = false;

            //    SearchDGV.Columns[1].Name = "FileNo";
            //    SearchDGV.Columns[1].HeaderText = "File No";
            //    SearchDGV.Columns[2].Name = "MSNo";
            //    SearchDGV.Columns[2].HeaderText = "MembershipNo";
            //    SearchDGV.Columns[3].Name = "Name";
            //    SearchDGV.Columns[3].HeaderText = "Name";
            //    SearchDGV.Columns[4].Name = "NICNICOP";
            //    SearchDGV.Columns[4].HeaderText = "NIC/NICOP";
            //    SearchDGV.Columns[5].Name = "Father";
            //    SearchDGV.Columns[5].HeaderText = "Father";
            //    SearchDGV.Columns[6].Name = "MobileNo";
            //    SearchDGV.Columns[6].HeaderText = "Mobile No";
            #endregion
            try
            {
                GridViewCommandColumn cllnfront = new GridViewCommandColumn();
                cllnfront.Name = "CllanFront";
                cllnfront.UseDefaultText = true;
                cllnfront.FieldName = "CllanFront";
                cllnfront.DefaultText = "Upload";
                cllnfront.Width = 160;
                cllnfront.TextAlignment = ContentAlignment.MiddleCenter;
                cllnfront.HeaderText = "Cllan Front";
                grdChallanImages.MasterTemplate.Columns.Add(cllnfront);

                GridViewCommandColumn challanBack = new GridViewCommandColumn();
                challanBack.Name = "cllnBack";
                challanBack.UseDefaultText = true;
                challanBack.FieldName = "cllnBack";
                challanBack.DefaultText = "Upload";
                challanBack.Width = 160;
                challanBack.TextAlignment = ContentAlignment.MiddleCenter;
                challanBack.HeaderText = "cllan Back";
                grdChallanImages.MasterTemplate.Columns.Add(challanBack);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Challan_DGVControls.", ex, "frmDDChallanImageUpload");
                frmobj.ShowDialog();
            }
          

        }
        private void radgdInstReceive_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = radgdInstReceive.CurrentCell.RowIndex;
                int columnindex = radgdInstReceive.CurrentCell.ColumnIndex;
                if (e.Column.Name == "DDFront")
                {                   
                    int ID = int.Parse(radgdInstReceive.CurrentRow.Cells[12].Value.ToString());
                    SqlParameter[] parameter =
                    {
                      new SqlParameter("@Task","ReturnAllIDs"),
                      new SqlParameter("@ID" , ID),
                      new SqlParameter("@ImageType","DD Front")
                     };
                    DataSet ds = cls_dl_InstRece.ReturnAllIDs(parameter);
                    int counter = int.Parse(ds.Tables[0].Rows[0]["image_exist"].ToString());
                    if (counter != 0)
                    {
                        RadMessageBox.Show("Already you are uploaded this Image.");
                    }
                    else
                    {
                        Installment.InstReceive.DDImageUpload obj = new DDImageUpload(ID, "DD Front");
                        obj.ShowDialog();
                    }
                
                }
                if (e.Column.Name == "DDBack")
                {
                    string ddb = "DD Back";
                    int ID = int.Parse(radgdInstReceive.CurrentRow.Cells[12].Value.ToString());
                    SqlParameter[] parameter =
                   {
                      new SqlParameter("@Task","ReturnAllIDs"),
                      new SqlParameter("@ID" , ID),
                      new SqlParameter("@ImageType",ddb)
                     };
                    DataSet ds = cls_dl_InstRece.ReturnAllIDs(parameter);
                    int counter = int.Parse(ds.Tables[0].Rows[0]["image_exist"].ToString());
                    if (counter != 0)
                    {
                        RadMessageBox.Show("Already you are uploaded this Image.");
                    }
                    else
                    {
                        Installment.InstReceive.DDImageUpload obj = new DDImageUpload(ID, ddb);
                        obj.ShowDialog();
                    }
                       
                    }
               
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on radgdInstReceive_CellClick.", ex, "frmDDChallanImageUpload");
                frmobj.ShowDialog();
            }
        }
        private void grdChallanImages_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
             
                if (e.Column.Name == "CllanFront")
                {
                    string cf = "Challan Front";
                    int ID = int.Parse(grdChallanImages.CurrentRow.Cells[11].Value.ToString());
                    SqlParameter[] parameter =
                  {
                      new SqlParameter("@Task","ReturnAllIDs"),
                      new SqlParameter("@ID" , ID),
                      new SqlParameter("@ImageType",cf)
                     };
                    DataSet ds = cls_dl_ChallanRece.OtherRece_Image_Retrive(parameter);
                    int counter = int.Parse(ds.Tables[0].Rows[0]["image_exist"].ToString());
                    if (counter != 0)
                    {
                        MessageBox.Show("Image is already Uploaded.");
                    }
                    else
                    {
                        Installment.InstReceive.ChallanImageUpload obj = new ChallanImageUpload(ID, cf);
                        obj.ShowDialog();
                    }
                   
                }
                if (e.Column.Name == "cllnBack")
                {
                    string cb = "Challan Back";
                    int ID = int.Parse(grdChallanImages.CurrentRow.Cells[11].Value.ToString());
                    SqlParameter[] parameter =
                 {
                      new SqlParameter("@Task","ReturnAllIDs"),
                      new SqlParameter("@ID" , ID),
                      new SqlParameter("@ImageType",cb)
                     };
                    DataSet ds = cls_dl_ChallanRece.OtherRece_Image_Retrive(parameter);
                    int counter = int.Parse(ds.Tables[0].Rows[0]["image_exist"].ToString());
                    if (counter != 0)
                    {
                        RadMessageBox.Show("Image is already Uploaded.");

                    }
                    else
                    {
                        Installment.InstReceive.ChallanImageUpload obj = new ChallanImageUpload(ID, cb);
                        obj.ShowDialog();
                    }
                    
                   
                }

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on grdChallanImages_CellClick.", ex, "frmDDChallanImageUpload");
                frmobj.ShowDialog();
            }
        }
        private void btnChallanSearch_Click(object sender, EventArgs e)
        {
            Searching();
        }

       
    }
}
