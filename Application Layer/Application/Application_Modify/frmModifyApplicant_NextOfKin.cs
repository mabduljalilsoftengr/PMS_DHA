using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.clsApplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Models;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Application.Application_Modify
{
    public partial class frmModifyApplicant_NextOfKin : Telerik.WinControls.UI.RadForm
    {
        public frmModifyApplicant_NextOfKin()
        {
            InitializeComponent();
        }
        public int appID { get; set; }
        public frmModifyApplicant_NextOfKin(int appid_get)
        {
            appID = appid_get;
            InitializeComponent();
        }

        private void frmModifyApplicant_NextOfKin_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            RetriveNextOfKinData(appID);
        }
        public int NextofkinID { get; set; }
        private void RetriveNextOfKinData(int appID_Get)
        {
            try { 
            SqlParameter[] parameter = {
                        new SqlParameter("@Task","Retrive_NextOfKin"),
                        new SqlParameter("@ID",appID_Get)
                        };
            DataSet ds = cls_dl_Application.NextofKinData_Retrive(parameter);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    NextofkinID = int.Parse(row["ID"].ToString());
                    txtNKName.Text = row["Name"].ToString();
                    nkcmbGender.Text = row["Gender"].ToString();
                    txtnkFather.Text = row["Father(S/O,D/O,W/O)"].ToString();
                    txtNKNIC.Text = row["CNIC"].ToString();
                    //this.Text = row["DOB"].ToString();
                    //dtpNKDOB.Value = DateTime.ParseExact(this.Text, "dd|MM|yyyy", CultureInfo.InvariantCulture);
                    dtpNKDOB.Text = row["DOB"].ToString();
                    txtNKRelation.Text = row["RelationWApplicant"].ToString();
                    txtnkpassport.Text = row["Passport"].ToString();
                }
            }
        }
       catch (Exception ex)
        {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on RetriveNextOfKinData.", ex, "frmModifyApplicant_NextOfKin");
                frmobj.ShowDialog();

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NextOfKinSave();
        }
       private void NextOfKinSave()
        {
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@Task","UpdateNextOfKin"),
                    new SqlParameter("@ID",NextofkinID),
                    new SqlParameter("@AppID",appID),
                    new SqlParameter("@Name",txtNKName.Text),
                    new SqlParameter("@Gender",nkcmbGender.SelectedItem.ToString()),
                    new SqlParameter("@Father",txtnkFather.Text),
                    new SqlParameter("@CNIC",txtNKNIC.Text),
                    new SqlParameter("@DOB",dtpNKDOB.Text),
                    new SqlParameter("@RelationWApplicant",txtNKRelation.Text),
                    new SqlParameter("@Passport",txtnkpassport.Text),
                    new SqlParameter("@user_ID",Models.clsUser.ID)
                };
                int result = 0;
                result = cls_dl_Application.NextOfKinUpdate(param);
                if(result > 0)
                {
                    MessageBox.Show("Next of kin Data Updated Successfully");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Contact with Administrator");
                }

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on NextOfKinSave.", ex, "frmModifyApplicant_NextOfKin");
                frmobj.ShowDialog();
            }
        }
    }
}
