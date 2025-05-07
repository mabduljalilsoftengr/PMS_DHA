using PeshawarDHASW.Data_Layer.clsMemberShip;
using PeshawarDHASW.Data_Layer.clsTFR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Membership.Modify
{
    public partial class frm_AddMembership_Against_NDC : Telerik.WinControls.UI.RadForm
    {
        private string File_No { get; set; }
        private int NDC_No { get; set; }
        public frm_AddMembership_Against_NDC()
        {
            InitializeComponent();
        }
        public frm_AddMembership_Against_NDC(int get_ndc_no,string get_fileno)
        {
            InitializeComponent();
            File_No = get_fileno;
            NDC_No = get_ndc_no;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (InsertionOfMembership())
            {
                Update_TFRTrackingStatus();
            }
            else
            {
                MessageBox.Show("Insertion Failled.");
            }           
        }
        private bool InsertionOfMembership()
        {
            bool blr = false;
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","Insert_MembershipAgainstNDCNo"),
                new SqlParameter("@FilePlotShopVillaApartmentNo",File_No),
                new SqlParameter("@NDCNo",NDC_No),
                new SqlParameter("@MembershipNo",txtmembershipno.Text),
                new SqlParameter("@NICNICOP",txtcnic.Text),
                new SqlParameter("@MobileNo",txtmobileno.Text),
                new SqlParameter("@Name",txtname.Text),
                new SqlParameter("@PresentAddress",txtpresentadress.Text),
                new SqlParameter("@user_ID",Models.clsUser.ID)
            };
            int rslt = cls_dl_Membership.Membership_PersonalInfo(prm);
            if (rslt > 0)
            {
                MessageBox.Show("Your Insertion is Successfull.");
                blr = true;
            }
            return blr;
        }
        private void Update_TFRTrackingStatus()
        {
            SqlParameter[] prmt =
            {
                new SqlParameter("@Task","Update_TFRHistory_Status"),
                new SqlParameter("@NDCNo",NDC_No),
                new SqlParameter("@Status","Transfer_Complete")
            };
            int rslt = cls_dl_TFRHistory.TFRHistory_NonQuery(prmt);
            if(rslt > 0)
            {
                this.Close();
            }

        }
        private void frm_AddMembership_Against_NDC_Load(object sender, EventArgs e)
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","Create_DPR")
            };
            DataSet ds = new DataSet();
            ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(prm);
            txtmembershipno.Text = ds.Tables[0].Rows[0]["MembershipNo"].ToString();
            txtfileno.Text = File_No;
            txtndcno.Text = NDC_No.ToString();
        }
    }
}
