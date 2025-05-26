using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.clsTFR;
using PeshawarDHASW.Data_Layer.NDC;
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

namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    public partial class frmTransferTracking_Remarks : Telerik.WinControls.UI.RadForm
    {
        public int NDCNo { get; set; }
        public string FileNo { get; set; }
        public int TransferNo { get; set; }
        public frmTransferTracking_Remarks()
        {
            InitializeComponent();
        }
        public frmTransferTracking_Remarks(int get_NDCNo,string get_FileNo,int get_TransferNo)
        {
            NDCNo = get_NDCNo;
            FileNo = get_FileNo;
            TransferNo = get_TransferNo;
            InitializeComponent();
        }

        private void frmTransferTracking_Remarks_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] prmt_r =
                         {
                        new SqlParameter("@Task","Cancel_Transfer"),
                        new SqlParameter("@NDCNo",NDCNo),
                        new SqlParameter("@FileNo",FileNo),
                        new SqlParameter("@TransferNo",TransferNo),
                        new SqlParameter("@TRFTrackingStatus","Cancel"),
                        new SqlParameter("@TRFTrackingRemarks",txtRemarks.Text)
            };
                int rslt = cls_dl_TFRVerification.TFRVerification_NonQuery(prmt_r);
                if (rslt > 0)
                {
                    MessageBox.Show("Transfer Cancelled Successfully.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnSave_Click.", ex, "frmTransferTracking_Remarks");
                frmobj.ShowDialog();
            }
         
        }
    }
}
