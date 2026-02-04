using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Application_Layer.NDC.Baskets;
using PeshawarDHASW.Data_Layer.clsCaution;
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

namespace PeshawarDHASW.Application_Layer.Caution
{
    public partial class Caution_Remove : Telerik.WinControls.UI.RadForm
    {
        public Caution_Remove()
        {
            InitializeComponent();
        }
        public DataSet ds { get; set; }
        private void txtFileNo_Leave(object sender, EventArgs e)
        {
            CheckCaution();
        }
        private void CheckCaution()
        {
            try
            {
                //grdMessageBox.DataSource = null;
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","Check_Caution"),
                new SqlParameter("@FileNo",txtFileNo.Text)
            };
                ds = cls_dl_Caution.Caution_Reader(prm);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdMessageBox.DataSource = ds.Tables[0].DefaultView;

                }
                else
                {
                    grdMessageBox.DataSource = null;
                }
            }
            catch (Exception ex) 
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on CheckCaution.", ex, "Caution_Remove");
                frmobj.ShowDialog();

            }


        }
        private void CheckAllCaution()
        {
            try
            {
                // grdMessageBox.DataSource = null;
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","Load_Caution"),
                new SqlParameter("@FileNo",txtFileNo.Text)
                };
                DataSet d_st = cls_dl_Caution.Caution_Reader(prm);
                if (d_st.Tables[0].Rows.Count > 0)
                {
                    grdMessageBox.DataSource = d_st.Tables[0].DefaultView;
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on CheckAllCaution.", ex, "Caution_Remove");
                frmobj.ShowDialog();

            }


        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                int gridrowCount = grdMessageBox.Rows.Count;
                int result = 0;
                for (int i = 0; i < gridrowCount; i++)
                {
                    bool chk = false;
                    chk = Convert.ToBoolean(grdMessageBox.Rows[i].Cells["Remove_Caution"].Value);
                    if (chk)
                    {
                        int Caution_ID = int.Parse(grdMessageBox.Rows[i].Cells["CautionID"].Value.ToString());
                        result += RemoveCaution(Caution_ID);
                    }
                }
                if (result > 0)
                {
                    MessageBox.Show("Caution is Removed Successfully.");
                    txtFileNo_Leave(null, null);
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnOK_Click.", ex, "Caution_Remove");
                frmobj.ShowDialog();
            }
           
            
        }
        private int RemoveCaution(int get_Cautionid)
        {
            int result = 0;
            try
            {
                SqlParameter[] prm =
                            {
                new SqlParameter("@Task","Remove_Caution"),
                new SqlParameter("@CautionID",get_Cautionid),
                new SqlParameter("@CauctionStatus","Remove"),
                new SqlParameter("@userID_Caution_Remove",Models.clsUser.ID)
            }; 
                result = cls_dl_Caution.Caution_NonQuery(prm);
               
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on RemoveCaution.", ex, "Caution_Remove");
                frmobj.ShowDialog();
            }
            return result;

        }

        private void Caution_Remove_Load(object sender, EventArgs e)
        {
            try
            {
                CheckAllCaution();
                grdMessageBox.Enabled = false;
                btnOK.Enabled = false;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Caution_Remove_Load.", ex, "Caution_Remove");
                frmobj.ShowDialog();
            }
           
        }

        private void btnRemoveCaution_Click(object sender, EventArgs e)
        {
            try
            {
                frm_Secret_Code frm = new frm_Secret_Code();
                frm.ShowDialog();
                if (clsMostUseVars.Drctr_Secret_Code == true )
                {
                    //ADDED BY SAHIB BECAUSE AFTER UNLOCK GRID DATA HIDE
                    CheckAllCaution();
                    ////////////
                    grdMessageBox.Enabled = true;
                    btnOK.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnRemoveCaution_Click.", ex, "Caution_Remove");
                frmobj.ShowDialog();
            }
           
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            CheckAllCaution();
        }

        private void grdMessageBox_CellClick(object sender, GridViewCellEventArgs e)
        {
            if(e.Column.Name == "btnCautionRemove")
            {
                string sts = e.Row.Cells["CauctionStatus"].Value.ToString();
                if( sts == "Remove")
                {
                    MessageBox.Show("Caution is already removed.");
                    return;
                }
                else
                {
                    int catnID = int.Parse(e.Row.Cells["CautionID"].Value.ToString());
                    Caution_Create frm = new Caution_Create(catnID);
                    frm.ShowDialog();
                    Caution_Remove_Load(null, null);
                }
               
            }
        }
    }
}
        
