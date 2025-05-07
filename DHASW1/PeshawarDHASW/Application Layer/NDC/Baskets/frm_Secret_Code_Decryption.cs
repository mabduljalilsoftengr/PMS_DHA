using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.clsUser;
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

namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    public partial class frm_Secret_Code_Decryption : Telerik.WinControls.UI.RadForm
    {
        public frm_Secret_Code_Decryption()
        {
            InitializeComponent();
        }

        private void frm_Secret_Code_Decryption_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            BindDataWithGrid();
        }
        private void BindDataWithGrid()
        {
            try
            {
                SqlParameter[] prm =
                           {
                new SqlParameter("@Task","Select")
            };
                DataSet ds = new DataSet();
                ds = cls_dl_User.UserReader(prm);
                int totalrows = ds.Tables[0].Rows.Count;
                for (int i = 0; i < totalrows; i++)
                {
                    string code = ds.Tables[0].Rows[i]["Secret_Code"].ToString();
                    string decrypted_Code = cls_dl_User.Decrypt(code, "sblw-3hn8-sqoy19");

                    GridViewDataRowInfo rw = new GridViewDataRowInfo(grd_SecretCode.MasterView);
                    rw.Cells[0].Value = ds.Tables[0].Rows[i]["ID"].ToString();
                    rw.Cells[1].Value = ds.Tables[0].Rows[i]["username"].ToString();
                    rw.Cells[2].Value = ds.Tables[0].Rows[i]["Name"].ToString();
                    rw.Cells[3].Value = decrypted_Code;
                    grd_SecretCode.Rows.Add(rw);

                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on BindDataWithGrid.", ex, "frm_Secret_Code_Decrytion");
                frmobj.ShowDialog();
            }
           

        }
    }
}
