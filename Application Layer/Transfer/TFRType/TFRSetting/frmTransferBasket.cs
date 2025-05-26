using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Application_Layer.FileMap;
using PeshawarDHASW.Data_Layer.clsFileMap;
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

namespace PeshawarDHASW.Application_Layer.Transfer.TFRSetting
{
    public partial class frmTransferBasket : Telerik.WinControls.UI.RadForm
    {
        public int FileKey { get; set; }
        public frmTransferBasket()
        {
            InitializeComponent();
        }

        private void frmTransferBasket_Load(object sender, EventArgs e)
        {
            DGVControls();
            Load_Files_MultipleOwners();
            Load_File_EngageOwners();
            Load_Files_Complete();
           // Update_Owner_Status();

        }
        #region Load_File_EngageOwners
        public void Load_File_EngageOwners()
        {
            try
            {
                SqlParameter[] prmtr =
                {
                new SqlParameter("@Task","Select_File_Engage")
                };
                DataSet dst = new DataSet();
                dst = cls_dl_FileMap.FileMap_Reader(prmtr);
                grdEngageFiles.DataSource = dst.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Load_File_EngageOwners.", ex, "frmTransferBasket");
                frmobj.ShowDialog();
            }
           
        }
        #endregion
        #region Load_Files_Having_MultipleOwners
        public void Load_Files_MultipleOwners()
        {
            try
            {
                SqlParameter[] prmtr =
                         {
                new SqlParameter("@Task","Select_File_MultiOwners")
            };
                DataSet dst = new DataSet();
                dst = cls_dl_FileMap.FileMap_Reader(prmtr);
                //FileKey =int.Parse(dst.Tables[0].Rows[0]["FileKey"].ToString());
                grdFile_MultiOwner.DataSource = dst.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Load_Files_MultipleOwners.", ex, "frmTransferBasket");
                frmobj.ShowDialog();
            }
          

        }
        #endregion
        #region Load_Files_Having_Complete
        public void Load_Files_Complete()
        {
            try
            {
                SqlParameter[] prmtr =
                          {
                new SqlParameter("@Task","Select_File_Complete")
            };
                DataSet dst = new DataSet();
                dst = cls_dl_FileMap.FileMap_Reader(prmtr);
                grdFile_Complete.DataSource = dst.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Load_Files_Complete.", ex, "frmTransferBasket");
                frmobj.ShowDialog();
            }
           

        }
        #endregion

        private void DGVControls()
        {
            try
            {
                GridViewCommandColumn OwnerModify = new GridViewCommandColumn();
                OwnerModify.Name = "BtnBind";
                OwnerModify.UseDefaultText = true;
                OwnerModify.FieldName = "Select";
                OwnerModify.DefaultText = "Bind";
                OwnerModify.Width = 80;
                OwnerModify.TextAlignment = ContentAlignment.MiddleCenter;
                OwnerModify.HeaderText = "Bind";
                grdFile_MultiOwner.MasterTemplate.Columns.Add(OwnerModify);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on DGVControls.", ex, "frmTransferBasket");
                frmobj.ShowDialog();
            }
           

        }
        
        

        private void grdFile_MultiOwner_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "BtnBind")
                {
                    if (grdFile_MultiOwner.RowCount > 0)
                    {
                        FileKey = int.Parse(grdFile_MultiOwner.CurrentRow.Cells[0].Value.ToString());
                        Update_Owner_Status();
                        #region Refresh the Baskets
                        Load_Files_MultipleOwners();
                        Load_File_EngageOwners();
                        Load_Files_Complete();
                        #endregion
                        frmTransferSetting frm_obj = new frmTransferSetting(FileKey);
                        frm_obj.ShowDialog();
                        #region Refresh the Baskets
                        Load_Files_MultipleOwners();
                        Load_File_EngageOwners();
                        Load_Files_Complete();
                        #endregion
                    }
                    else
                    {
                        MessageBox.Show("No Records");
                    }
                }
               
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on grdFile_MultiOwner_CellClick.", ex, "frmTransferBasket");
                frmobj.ShowDialog();
            }
           

        }
        #region Update_Owner_Status
        public void Update_Owner_Status()
        {
            try
            {
                SqlParameter[] prmr =
                           {
                new SqlParameter("@Task","update_Status"),
                new SqlParameter("@FileMapKey",FileKey),
                new SqlParameter("@Status","Engage")
            };
                int result = 0;
                result = cls_dl_FileMap.FileMap_NonQuery(prmr);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Update_Owner_Status.", ex, "frmTransferBasket");
                frmobj.ShowDialog();
            }
           
        }
        #endregion

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Load_Files_MultipleOwners();
            Load_File_EngageOwners();
            Load_Files_Complete();
        }
    }
}
