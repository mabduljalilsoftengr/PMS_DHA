using PeshawarDHASW.Application_Layer.Membership;
using PeshawarDHASW.Application_Layer.Membership.Modify;
using PeshawarDHASW.Data_Layer.clsMemberShip;
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
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    public partial class frmCheckOpenMSNO_Against_CNIC : Telerik.WinControls.UI.RadForm
    {
        public int MemberID { get; set; } = 0;
        public int NDCNo { get; set; }
        public string FileNo { get; set; }
        public frmCheckOpenMSNO_Against_CNIC()
        {
            InitializeComponent();
        }
        public frmCheckOpenMSNO_Against_CNIC(int get_ndc,string get_FileNo)
        {
            NDCNo = get_ndc;
            FileNo = get_FileNo;
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] prmtr =
                {
                new SqlParameter("@Task","Select_Open_OR_Already_Exist_MemberShip_AGainst_CNIC"),
                new SqlParameter("@NICNICOP",txtCNIC.Text)
                };
                //DataSet dst = cls_dl_Membership.Membership_All_Retrive(prmtr);
                DataSet dst = cls_dl_Membership.Membership_PersonalInfo_Retrive(prmtr);
                if (dst.Tables.Count > 0)
                {
                    //if (dst.Tables[0].Rows.Count > 0)
                    //{
                    //    MemberID = int.Parse(dst.Tables[0].Rows[0]["ID"].ToString());
                    //    frmMembership_All_Info_Modify frm = new frmMembership_All_Info_Modify(NDCNo, MemberID, FileNo);
                    //    frm.ShowDialog();
                    //}
                    if (dst.Tables[0].Rows.Count > 0)
                    {
                        int alredyExist = 1;
                        MemberID = int.Parse(dst.Tables[0].Rows[0]["ID"].ToString());
                        frmMembership_All_Info_Modify frm = new frmMembership_All_Info_Modify(NDCNo, MemberID, FileNo, alredyExist);
                        frm.ShowDialog();
                    }
                    else
                    {
                        frmMembership obj = new frmMembership(NDCNo, MemberID, txtCNIC.Text);
                        obj.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnCheck_Click.", ex, "frmCheckOpenMSNO_Against_CNIC");
                frmobj.ShowDialog();
            }
           
           
        }

        private void frmCheckOpenMSNO_Against_CNIC_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
        }
    }
}
