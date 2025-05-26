using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.Owner;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using PeshawarDHASW.Data_Layer.clsFileMap;
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Models;

namespace PeshawarDHASW.Application_Layer.FileMap
{
    public partial class frmTransferSetting : Telerik.WinControls.UI.RadForm
    {
        public int FileKey { get; set; }
        public frmTransferSetting(int get_FileKey)
        {
            FileKey = get_FileKey;
            InitializeComponent();
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
        }
        public frmTransferSetting()
        {
            InitializeComponent();
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
        }

        private void btnFileSearch_Click(object sender, EventArgs e)
        {
           
          
        }

        private void frmTransferSetting_Load(object sender, EventArgs e)
        {
            DGVControls();
            dgWonerInformation.Columns.Move(12, 5); // To move from Index No.12 to Index No.5
            LoadOwnerInformation();


        }
        private void DGVControls()
        {
            try
            {

                GridViewComboBoxColumn comboColumn = new GridViewComboBoxColumn("OwnerStatus");
                //set the column data source - the possible column values
                comboColumn.DataSource = new String[] { "Transferee", "Current" };
                //set the FieldName - the column will retrieve the value from "Phone" column in the data table
                comboColumn.FieldName = "OwnerStatus";
                comboColumn.Name = "OwnerStatus";
                //add the column to the grid
                dgWonerInformation.Columns.Add(comboColumn);


                GridViewCommandColumn OwnerModify = new GridViewCommandColumn();
                OwnerModify.Name = "BtnUpdate";
                OwnerModify.UseDefaultText = true;
                OwnerModify.FieldName = "Select";
                OwnerModify.DefaultText = "Update";
                OwnerModify.Width = 80;
                OwnerModify.TextAlignment = ContentAlignment.MiddleCenter;
                OwnerModify.HeaderText = "Update Owner";
                dgWonerInformation.MasterTemplate.Columns.Add(OwnerModify);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on DGVControls.", ex, "frmTransferSetting");
                frmobj.ShowDialog();
            }
           

        }
        public void LoadOwnerInformation()
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task", "TransferSetting"),
                    new SqlParameter("@FileMapID", FileKey),
                };
                DataSet TransferSetting = cls_dl_Owner.Owner_Reader(parameters);
                dgWonerInformation.DataSource = TransferSetting.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LoadOwnerInformation.", ex, "frmTransferSetting");
                frmobj.ShowDialog();
            }
        }
      
        private void dgWonerInformation_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                #region Update Owner Data
                int rowindex = dgWonerInformation.CurrentCell.RowIndex;
                // int columnindex = grdFile_MultiOwner.CurrentCell.ColumnIndex;
                //this.Hide();
                if (e.Column.Name == "BtnUpdate")
                {
                    int memberid = int.Parse(dgWonerInformation.Rows[rowindex].Cells[0].Value.ToString());
                    string MSNO = dgWonerInformation.Rows[rowindex].Cells[1].Value.ToString();
                    string Name = dgWonerInformation.Rows[rowindex].Cells[2].Value.ToString();
                    string NIC = dgWonerInformation.Rows[rowindex].Cells[3].Value.ToString();
                    int OwnerId =int.Parse(dgWonerInformation.Rows[rowindex].Cells[4].Value.ToString());
                    string OwnerStatus = dgWonerInformation.Rows[rowindex].Cells[5].Value.ToString();
                    string RateOfSale = dgWonerInformation.Rows[rowindex].Cells[6].Value.ToString();
                    string DatOfPurchase = dgWonerInformation.Rows[rowindex].Cells[7].Value.ToString();
                    string dateOfSell = dgWonerInformation.Rows[rowindex].Cells[8].Value.ToString();
                    int filekey =int.Parse( dgWonerInformation.Rows[rowindex].Cells[9].Value.ToString());
                    string fileNo = dgWonerInformation.Rows[rowindex].Cells[10].Value.ToString();
                    //string plotNumber = dgWonerInformation.Rows[rowindex].Cells[11].Value.ToString();
                    string fileStatus = dgWonerInformation.Rows[rowindex].Cells[11].Value.ToString();
                    string plotSize = dgWonerInformation.Rows[rowindex].Cells[12].Value.ToString();
                    SqlParameter[] prm =
                    {
                      new SqlParameter("@Task","Update_OwnerBinding"),
                      new SqlParameter("@Status",OwnerStatus),
                      new SqlParameter("@RateofSale",RateOfSale),
                      new SqlParameter("@DateofPurchase",DatOfPurchase),
                      new SqlParameter("@DateofSell",dateOfSell),
                      new SqlParameter("@OwnerID",OwnerId),
                      new SqlParameter("@EntryStatus","Complete")
                    };
                    int rslt = 0;
                    rslt = cls_dl_Owner.Owner_NonQuery(prm);                   
                    dgWonerInformation.DataSource = null;
                    LoadOwnerInformation();

                }
                #endregion
                //frmTransferSetting_Load(null,null);

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on dgWonerInformation_CellClick.", ex, "frmTransferSetting");
                frmobj.ShowDialog();
            }
        }

        private void frmTransferSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void frmTransferSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                DialogResult rdr = MessageBox.Show("Are you sure this file is Completed", "Confrim", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rdr == DialogResult.Yes)
                {
                    #region Update Owner Status
                    SqlParameter[] prmr =
                    {
                  new SqlParameter("@Task","update_Status"),
                  new SqlParameter("@FileMapKey",FileKey),
                  new SqlParameter("@Status","Complete")
                };
                    int result = 0;
                    result = cls_dl_FileMap.FileMap_NonQuery(prmr);
                    #endregion

                }
                else
                {
                    #region Update Owner Status
                    SqlParameter[] prmr =
                    {
                  new SqlParameter("@Task","update_Status"),
                  new SqlParameter("@FileMapKey",FileKey),
                  new SqlParameter("@Status","Active")
                };
                    int result = 0;
                    result = cls_dl_FileMap.FileMap_NonQuery(prmr);
                    #endregion
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmTransferSetting_FormClosed.", ex, "frmTransferSetting");
                frmobj.ShowDialog();
            }
           
        }
    }
}
