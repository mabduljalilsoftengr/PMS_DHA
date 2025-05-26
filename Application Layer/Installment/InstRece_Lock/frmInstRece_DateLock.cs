using PeshawarDHASW.Models;
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

namespace PeshawarDHASW.Application_Layer.Installment.InstRece_Lock
{
    public partial class frmInstRece_DateLock : Telerik.WinControls.UI.RadForm
    {
        public frmInstRece_DateLock()
        {
            InitializeComponent();
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
        }

        private void frmInstRece_DateLock_Load(object sender, EventArgs e)
        {
            SqlParameter[] param = {
                new SqlParameter("@Task","LockDateData")
            };
            DataSet ds = Data_Layer.Installment.cls_dl_LockDate.LockDate_Search_Reader(param);
            radDateLock.DataSource = ds.Tables[0].DefaultView;
        }

        private void radDateLock_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = radDateLock.CurrentCell.RowIndex;
                int columnindex = radDateLock.CurrentCell.ColumnIndex;

                if (e.Column.Name == "LockStatus")
                {
                    int LockDateID = 0;
                    bool M = int.TryParse(radDateLock.ChildRows[rowindex].Cells["LockDateID"].Value.ToString(), out LockDateID);
                    GridViewRowInfo row = radDateLock.Rows[rowindex];
                    object cs = row.Cells["LockStatus"].Value;
                    if (M != false)
                    {
                        SqlParameter[] param = {
                            new SqlParameter("@Task","UpdateLockEntry"),
                            new SqlParameter("@LockStatus",cs),
                            new SqlParameter("@LockDateID",LockDateID)
                        };
                        int result = Data_Layer.Installment.cls_dl_LockDate.LockDate_Create_Update(param);
                        frmInstRece_DateLock_Load(null,null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
